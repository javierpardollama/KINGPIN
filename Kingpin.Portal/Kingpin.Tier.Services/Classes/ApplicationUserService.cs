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

        public ApplicationUserService(IMapper iMapper,
                                      IApplicationContext iContext,
                                      ILogger<ApplicationUserService> iLogger) : base(iContext, iMapper, iLogger)
        {          
        }

        public async Task<ICollection<ViewApplicationUser>> FindAllApplicationUser()
        {
            ICollection<ApplicationUser> applicationUsers = await IContext.ApplicationUser
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
            ApplicationUser applicationUser = await IContext.ApplicationUser.AsQueryable()
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

            // Override Identity ApplicationUser Unique Constraint Properties
            applicationUser.Email = DateTime.Now.ToBinary().ToString();
            applicationUser.NormalizedEmail = DateTime.Now.ToBinary().ToString();
            applicationUser.UserName = DateTime.Now.ToBinary().ToString();
            applicationUser.NormalizedUserName = DateTime.Now.ToBinary().ToString();

            IContext.ApplicationUser.Remove(applicationUser);

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

            IContext.ApplicationUser.Update(applicationUser);

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

        public async Task UpdateApplicationUserRole(UpdateApplicationUser viewModel, ApplicationUser applicationUser)
        {
            await viewModel.ApplicationRolesId.ToAsyncEnumerable().ForEachAsync(async x =>
            {
                ApplicationRole applicationRole = await FindApplicationRoleById(x);

                ApplicationUserRole applicationUserRole = new ApplicationUserRole
                {
                    UserId = applicationUser.Id,
                    RoleId = applicationRole.Id,
                };

                applicationUser.ApplicationUserRoles.Add(applicationUserRole);
            });
        }

        public async Task<ApplicationRole> FindApplicationRoleById(int id)
        {
            ApplicationRole applicationRole = await IContext.ApplicationRole.FirstOrDefaultAsync(x=>x.Id == id);

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
