using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

using AutoMapper;

using Kingpin.Tier.Contexts.Interfaces;
using Kingpin.Tier.Entities.Classes;
using Kingpin.Tier.Logging.Classes;
using Kingpin.Tier.Services.Interfaces;
using Kingpin.Tier.ViewModels.Classes.Updates;
using Kingpin.Tier.ViewModels.Classes.Views;

using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Logging;

namespace Kingpin.Tier.Services.Classes
{
    public class ApplicationUserService : BaseService, IApplicationUserService
    {

        public ApplicationUserService(IMapper @mapper,
                                      IApplicationContext @context,
                                      ILogger<ApplicationUserService> @logger) : base(@context, @mapper, @logger)
        {
        }

        public async Task<ICollection<ViewApplicationUser>> FindAllApplicationUser()
        {
            ICollection<ApplicationUser> @applicationUsers = await Context.ApplicationUser
               .TagWith("FindAllApplicationUser")
               .AsQueryable()
               .AsNoTracking()
               .Include(x => x.ApplicationUserTokens)
               .Include(x => x.ApplicationUserRoles)
               .ThenInclude(x => x.ApplicationRole)
               .ToListAsync();

            return Mapper.Map<ICollection<ViewApplicationUser>>(@applicationUsers);
        }

        public async Task<ApplicationUser> FindApplicationUserById(int @id)
        {
            ApplicationUser @applicationUser = await Context.ApplicationUser
               .TagWith("FindApplicationUserById")
               .AsQueryable()
               .Include(x => x.ApplicationUserTokens)
               .Include(x => x.ApplicationUserRoles)
               .ThenInclude(x => x.ApplicationRole)
               .FirstOrDefaultAsync(x => x.Id == @id);

            if (@applicationUser == null)
            {
                // Log
                string @logData = @applicationUser.GetType().Name
                    + " with Email "
                    + @applicationUser.Email
                    + " was not found at "
                    + DateTime.Now.ToShortTimeString();

                Logger.WriteGetItemNotFoundLog(@logData);

                throw new Exception(@applicationUser.GetType().Name
                    + " with Email "
                    + applicationUser.Email
                    + " does not exist");
            }

            return @applicationUser;
        }

        public async Task RemoveApplicationUserById(int @id)
        {
            ApplicationUser @applicationUser = await FindApplicationUserById(@id);

            Context.ApplicationUser.Remove(@applicationUser);

            await Context.SaveChangesAsync();

            // Log
            string @logData = @applicationUser.GetType().Name
                + " with Id "
                + @applicationUser.Id
                + " was removed at "
                + DateTime.Now.ToShortTimeString();

            Logger.WriteDeleteItemLog(@logData);
        }

        public async Task<ViewApplicationUser> UpdateApplicationUser(UpdateApplicationUser @viewModel)
        {
            ApplicationUser @applicationUser = await FindApplicationUserById(@viewModel.Id);

            @applicationUser.ApplicationUserRoles = new List<ApplicationUserRole>();

            Context.ApplicationUser.Update(@applicationUser);

            UpdateApplicationUserRole(@viewModel, @applicationUser);

            await Context.SaveChangesAsync();

            // Log
            string logData = @applicationUser.GetType().Name
                + " with Id"
                + @applicationUser.Id
                + " was modified at "
                + DateTime.Now.ToShortTimeString();

            Logger.WriteUpdateItemLog(@logData);

            return Mapper.Map<ViewApplicationUser>(@applicationUser); ;
        }

        public void UpdateApplicationUserRole(UpdateApplicationUser @viewModel, ApplicationUser @applicationUser)
        {
            @viewModel.ApplicationRolesId.AsQueryable().ToList().ForEach(async x =>
            {
                ApplicationRole @applicationRole = await FindApplicationRoleById(x);

                ApplicationUserRole @applicationUserRole = new ApplicationUserRole
                {
                    UserId = @applicationUser.Id,
                    RoleId = @applicationUser.Id,
                };

                @applicationUser.ApplicationUserRoles.Add(@applicationUserRole);
            });
        }

        public async Task<ApplicationRole> FindApplicationRoleById(int @id)
        {
            ApplicationRole @applicationRole = await Context.ApplicationRole
                .TagWith("FindApplicationRoleById")
                .FirstOrDefaultAsync(x => x.Id == @id);

            if (@applicationRole == null)
            {
                // Log
                string @logData = @applicationRole.GetType().Name
                    + " with Id "
                    + @id
                    + " was not found at "
                    + DateTime.Now.ToShortTimeString();

                Logger.WriteGetItemNotFoundLog(@logData);

                throw new Exception(@applicationRole.GetType().Name
                    + " with Id "
                    + @id
                    + " does not exist");
            }

            return @applicationRole;
        }
    }
}
