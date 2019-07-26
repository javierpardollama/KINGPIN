using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

using AutoMapper;

using Kingpin.Tier.Entities.Classes;
using Kingpin.Tier.Logging.Classes;
using Kingpin.Tier.Services.Interfaces;
using Kingpin.Tier.ViewModels.Classes.Additions;
using Kingpin.Tier.ViewModels.Classes.Updates;
using Kingpin.Tier.ViewModels.Classes.Views;

using Microsoft.AspNetCore.Identity;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Logging;

namespace Kingpin.Tier.Services.Classes
{
    public class ApplicationRoleService : BaseService, IApplicationRoleService
    {
        private readonly RoleManager<ApplicationRole> RoleManager;

        public ApplicationRoleService(IMapper iMapper,
                                      ILogger<ApplicationRoleService> iLogger,
                                      RoleManager<ApplicationRole> roleManager) : base(iMapper, iLogger) => RoleManager = roleManager;

        public async Task<ViewApplicationRole> AddApplicationRole(AddApplicationRole viewModel)
        {
            await CheckName(viewModel);

            ApplicationRole applicationRole = new ApplicationRole
            {
                Name = viewModel.Name,
                NormalizedName = viewModel.Name,
                ConcurrencyStamp = DateTime.Now.ToBinary().ToString()
            };

            await RoleManager.CreateAsync(applicationRole);

            await IContext.SaveChangesAsync();

            // Log
            string logData = applicationRole.GetType().Name
                + " with Id "
                + applicationRole.Id
                + " was added at "
                + DateTime.Now.ToShortTimeString();

            ILogger.WriteInsertItemLog(logData);

            return IMapper.Map<ViewApplicationRole>(applicationRole);
        }

        public async Task<ApplicationRole> CheckName(AddApplicationRole viewModel)
        {
            ApplicationRole applicationRole = await RoleManager.FindByNameAsync(viewModel.Name);

            if (applicationRole != null)
            {
                // Log
                string logData = applicationRole.GetType().Name
                    + " with Name "
                    + applicationRole.Name
                    + " was already found at "
                    + DateTime.Now.ToShortTimeString();

                ILogger.WriteGetItemFoundLog(logData);

                throw new Exception(applicationRole.GetType().Name
                    + " with Name "
                    + viewModel.Name
                    + " already exists");
            }

            return applicationRole;
        }

        public async Task<ICollection<ViewApplicationRole>> FindAllApplicationRole()
        {
            ICollection<ApplicationRole> applicationRoles = await RoleManager.Roles
                .AsQueryable()
                .AsNoTracking()
                .ToAsyncEnumerable()
                .ToList();

            return IMapper.Map<ICollection<ViewApplicationRole>>(applicationRoles);
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

        public async Task RemoveApplicationRoleById(int id)
        {
            ApplicationRole applicationRole = await FindApplicationRoleById(id);

            await RoleManager.DeleteAsync(applicationRole);

            await IContext.SaveChangesAsync();

            // Log
            string logData = applicationRole.GetType().Name
                + " with Id "
                + applicationRole.Id
                + " was removed at "
                + DateTime.Now.ToShortTimeString();

            ILogger.WriteDeleteItemLog(logData);
        }

        public async Task<ViewApplicationRole> UpdateApplicationRole(UpdateApplicationRole viewModel)
        {
            ApplicationRole applicationRole = await FindApplicationRoleById(viewModel.Id);

            applicationRole.Name = viewModel.Name;
            applicationRole.NormalizedName = viewModel.Name;

            await RoleManager.UpdateAsync(applicationRole);

            await IContext.SaveChangesAsync();

            // Log
            string logData = applicationRole.GetType().Name
                + " with Id "
                + applicationRole.Id
                + " was modified at "
                + DateTime.Now.ToShortTimeString();

            ILogger.WriteUpdateItemLog(logData);

            return IMapper.Map<ViewApplicationRole>(applicationRole);
        }
    }
}
