using AutoMapper;
using Kingpin.Tier.Entities.Classes;
using Kingpin.Tier.Exceptions.Classes;
using Kingpin.Tier.Logging.Classes;
using Kingpin.Tier.Services.Interfaces;
using Kingpin.Tier.ViewModels.Classes.Additions;
using Kingpin.Tier.ViewModels.Classes.Updates;
using Kingpin.Tier.ViewModels.Classes.Views;
using Microsoft.AspNetCore.Identity;
using Microsoft.Extensions.Logging;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Kingpin.Tier.Services.Classes
{
    public class RoleService : BaseService, IRoleService
    {
        private readonly RoleManager<ApplicationRole> RoleManager;

        public RoleService(
            IMapper iMapper,
            ILogger iLogger,
             RoleManager<ApplicationRole> roleManager) : base(iMapper, iLogger)
        {
            RoleManager = roleManager;
        }

        public async Task<ViewRole> AddIdentityRole(AddRole viewModel)
        {
            await CheckName(viewModel);

            ApplicationRole identityRole = new ApplicationRole
            {              
                Name = viewModel.Name,
                ConcurrencyStamp = DateTime.Now.ToBinary().ToString()
            };

            await RoleManager.CreateAsync(identityRole);

            // Log
            string logData = identityRole.GetType().Name
                + " with Id "
                + identityRole.Id
                + " was added at "
                + DateTime.Now.ToShortTimeString();

            ILogger.WriteInsertItemLog(logData);

            return IMapper.Map<ViewRole>(identityRole);
        }

        public async Task<ApplicationRole> CheckName(AddRole viewModel)
        {
            ApplicationRole identityRole = await RoleManager.FindByNameAsync(viewModel.Name);

            if (identityRole != null)
            {
                // Log
                string logData = identityRole.GetType().Name
                    + " with Name "
                    + identityRole.Name
                    + " was already found at "
                    + DateTime.Now.ToShortTimeString();

                ILogger.WriteGetItemFoundLog(logData);

                throw new ServiceException(identityRole.GetType().Name
                    + " with Name "
                    + viewModel.Name
                    + " already exists");
            }

            return identityRole;
        }

        public async Task<ICollection<ViewRole>> FindAllIdentityRole()
        {
            ICollection<ApplicationRole> roles = await RoleManager.Roles
                .AsQueryable()
                .ToAsyncEnumerable()
                .ToList();

            return IMapper.Map<ICollection<ViewRole>>(roles);
        }

        public async Task<ApplicationRole> FindIdentityRoleById(int id)
        {
            ApplicationRole identityRole = await RoleManager.FindByIdAsync(id.ToString());

            if (identityRole == null)
            {
                // Log
                string logData = identityRole.GetType().Name
                    + " with Id "
                    + id
                    + " was not found at "
                    + DateTime.Now.ToShortTimeString();

                ILogger.WriteGetItemNotFoundLog(logData);

                throw new ServiceException(identityRole.GetType().Name
                    + " with Id "
                    + id
                    + " does not exist");
            }

            return identityRole;
        }

        public async Task RemoveIdentityRoleById(int id)
        {
            ApplicationRole identityRole = await FindIdentityRoleById(id);

            await RoleManager.DeleteAsync(identityRole);

            // Log
            string logData = identityRole.GetType().Name
                + " with Id "
                + identityRole.Id
                + " was removed at "
                + DateTime.Now.ToShortTimeString();

            ILogger.WriteDeleteItemLog(logData);
        }

        public async Task<ViewRole> UpdateIdentityRole(UpdateRole viewModel)
        {
            ApplicationRole identityRole = await FindIdentityRoleById(viewModel.Id);

            identityRole.Name = viewModel.Name;

            await RoleManager.UpdateAsync(identityRole);            

            // Log
            string logData = identityRole.GetType().Name
                + " with Id "
                + identityRole.Id
                + " was modified at "
                + DateTime.Now.ToShortTimeString();

            ILogger.WriteUpdateItemLog(logData);

            return IMapper.Map<ViewRole>(identityRole);
        }
    }
}
