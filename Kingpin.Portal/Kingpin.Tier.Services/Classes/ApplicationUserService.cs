using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

using AutoMapper;

using Kingpin.Tier.Entities.Classes;
using Kingpin.Tier.Logging.Classes;
using Kingpin.Tier.Services.Interfaces;
using Kingpin.Tier.ViewModels.Classes.Updates;
using Kingpin.Tier.ViewModels.Classes.Views;

using Microsoft.AspNetCore.Identity;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Logging;

namespace Kingpin.Tier.Services.Classes
{
    public class ApplicationUserService : BaseService, IApplicationUserService
    {
        private readonly UserManager<ApplicationUser> UserManager;

        private readonly RoleManager<ApplicationRole> RoleManager;

        public ApplicationUserService(IMapper iMapper,
                          ILogger<ApplicationUserService> iLogger,
                          UserManager<ApplicationUser> userManager,
                          RoleManager<ApplicationRole> roleManager
                          ) : base(iMapper, iLogger)
        {
            UserManager = userManager;
            RoleManager = roleManager;
        }

        public async Task<ICollection<ViewApplicationUser>> FindAllApplicationUser()
        {
            ICollection<ApplicationUser> applicationUsers = await UserManager.Users
               .AsQueryable()
               .AsNoTracking()
               .Include(x => x.ApplicationUserTokens)
               .Include(x => x.ApplicationUserRoles)
               .ThenInclude(x => x.ApplicationRole)
               .ToAsyncEnumerable()
               .ToList();

            return IMapper.Map<ICollection<ViewApplicationUser>>(applicationUsers);
        }

        public async Task<ApplicationUser> FindApplicationUserById(int id)
        {
            ApplicationUser applicationUser = await UserManager.Users.AsQueryable()
               .Include(x => x.ApplicationUserTokens)
               .Include(x => x.ApplicationUserRoles)
               .ThenInclude(x => x.ApplicationRole)
               .FirstOrDefaultAsync(x => x.Id == id);

            if (applicationUser == null)
            {
                // Log
                string logData = applicationUser.GetType().Name
                    + " with Email "
                    + applicationUser.Email
                    + " was not found at "
                    + DateTime.Now.ToShortTimeString();

                ILogger.WriteGetItemNotFoundLog(logData);

                throw new Exception(applicationUser.GetType().Name
                    + " with Email "
                    + applicationUser.Email
                    + " does not exist");
            }

            return applicationUser;
        }

        public async Task RemoveApplicationUserById(int id)
        {
            ApplicationUser applicationUser = await FindApplicationUserById(id);

            await UserManager.DeleteAsync(applicationUser);

            await IContext.SaveChangesAsync();

            // Log
            string logData = applicationUser.GetType().Name
                + " with Id "
                + applicationUser.Id
                + " was removed at "
                + DateTime.Now.ToShortTimeString();

            ILogger.WriteDeleteItemLog(logData);
        }

        public async Task<ViewApplicationUser> UpdateApplicationUser(UpdateApplicationUser viewModel)
        {
            ApplicationUser applicationUser = await FindApplicationUserById(viewModel.Id);

            applicationUser.ApplicationUserRoles = new List<ApplicationUserRole>();

            await UserManager.UpdateAsync(applicationUser);

            await UpdateApplicationUserRole(viewModel, applicationUser);

            await IContext.SaveChangesAsync();

            // Log
            string logData = applicationUser.GetType().Name
                + " with Id"
                + applicationUser.Id
                + " was modified at "
                + DateTime.Now.ToShortTimeString();

            ILogger.WriteUpdateItemLog(logData);

            return IMapper.Map<ViewApplicationUser>(applicationUser); ;
        }

        public async Task UpdateApplicationUserRole(UpdateApplicationUser viewModel, ApplicationUser entity)
        {
            await viewModel.ApplicationRolesId.ToAsyncEnumerable().ForEachAsync(async x =>
            {
                ApplicationRole applicationRole = await FindApplicationRoleById(x);

                ApplicationUserRole applicationUserRole = new ApplicationUserRole
                {
                    ApplicationUser = entity,
                    ApplicationRole = applicationRole,
                };

                await IContext.ApplicationUserRole.AddAsync(applicationUserRole);
            });
        }

        public async Task<ApplicationRole> FindApplicationRoleById(int id)
        {
            ApplicationRole applicationRole = await RoleManager.FindByIdAsync(id.ToString());

            if (applicationRole == null)
            {
                // Log
                string logData = applicationRole.GetType().Name
                    + " with Id "
                    + id
                    + " was not found at "
                    + DateTime.Now.ToShortTimeString();

                ILogger.WriteGetItemNotFoundLog(logData);

                throw new Exception(applicationRole.GetType().Name
                    + " with Id "
                    + id
                    + " does not exist");
            }

            return applicationRole;
        }
    }
}
