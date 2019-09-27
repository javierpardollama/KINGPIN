using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

using AutoMapper;

using Kingpin.Tier.Contexts.Interfaces;
using Kingpin.Tier.Entities.Classes;
using Kingpin.Tier.Logging.Classes;
using Kingpin.Tier.Services.Interfaces;
using Kingpin.Tier.ViewModels.Classes.Additions;
using Kingpin.Tier.ViewModels.Classes.Updates;
using Kingpin.Tier.ViewModels.Classes.Views;

using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Logging;

namespace Kingpin.Tier.Services.Classes
{
    public class ApplicationRoleService : BaseService, IApplicationRoleService
    {
        public ApplicationRoleService(IMapper mapper,
                                      IApplicationContext context,
                                      ILogger<ApplicationRoleService> logger) : base(context, mapper, logger)
        {

        }

        public async Task<ViewApplicationRole> AddApplicationRole(AddApplicationRole viewModel)
        {
            await CheckName(viewModel);

            ApplicationRole applicationRole = new ApplicationRole
            {
                Name = viewModel.Name,
                NormalizedName = viewModel.Name,
                ConcurrencyStamp = DateTime.Now.ToBinary().ToString(),
                ImageUri = viewModel.ImageUri,
            };

            await Context.ApplicationRole.AddAsync(applicationRole);

            await Context.SaveChangesAsync();

            // Log
            string logData = applicationRole.GetType().Name
                + " with Id "
                + applicationRole.Id
                + " was added at "
                + DateTime.Now.ToShortTimeString();

            Logger.WriteInsertItemLog(logData);

            return Mapper.Map<ViewApplicationRole>(applicationRole);
        }

        public async Task<ApplicationRole> CheckName(AddApplicationRole viewModel)
        {
            ApplicationRole applicationRole = await Context.ApplicationRole
                .AsNoTracking()
                .TagWith("CheckName")
                .FirstOrDefaultAsync(x => x.Name == viewModel.Name);

            if (applicationRole != null)
            {
                // Log
                string logData = applicationRole.GetType().Name
                    + " with Name "
                    + applicationRole.Name
                    + " was already found at "
                    + DateTime.Now.ToShortTimeString();

                Logger.WriteGetItemFoundLog(logData);

                throw new Exception(applicationRole.GetType().Name
                    + " with Name "
                    + viewModel.Name
                    + " already exists");
            }

            return applicationRole;
        }

        public async Task<ApplicationRole> CheckName(UpdateApplicationRole viewModel)
        {
            ApplicationRole applicationRole = await Context.ApplicationRole
                 .AsNoTracking()
                 .TagWith("CheckName")
                 .FirstOrDefaultAsync(x => x.Name == viewModel.Name && x.Id != viewModel.Id);

            if (applicationRole != null)
            {
                // Log
                string logData = applicationRole.GetType().Name
                    + " with Name "
                    + applicationRole.Name
                    + " was already found at "
                    + DateTime.Now.ToShortTimeString();

                Logger.WriteGetItemFoundLog(logData);

                throw new Exception(applicationRole.GetType().Name
                    + " with Name "
                    + viewModel.Name
                    + " already exists");
            }

            return applicationRole;
        }

        public async Task<ICollection<ViewApplicationRole>> FindAllApplicationRole()
        {
            ICollection<ApplicationRole> applicationRoles = await Context.ApplicationRole
                .TagWith("FindAllApplicationRole")
                .AsNoTracking()
                .ToAsyncEnumerable()
                .ToList();

            return Mapper.Map<ICollection<ViewApplicationRole>>(applicationRoles);
        }

        public async Task<ApplicationRole> FindApplicationRoleById(int id)
        {
            ApplicationRole applicationRole = await Context.ApplicationRole.
                TagWith("FindApplicationRoleById")
                .FirstOrDefaultAsync(x => x.Id == id);

            if (applicationRole == null)
            {
                // Log
                string logData = applicationRole.GetType().Name
                    + " with Id "
                    + id
                    + " was not found at "
                    + DateTime.Now.ToShortTimeString();

                Logger.WriteGetItemNotFoundLog(logData);

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

            Context.ApplicationRole.Remove(applicationRole);

            await Context.SaveChangesAsync();

            // Log
            string logData = applicationRole.GetType().Name
                + " with Id "
                + applicationRole.Id
                + " was removed at "
                + DateTime.Now.ToShortTimeString();

            Logger.WriteDeleteItemLog(logData);
        }

        public async Task<ViewApplicationRole> UpdateApplicationRole(UpdateApplicationRole viewModel)
        {
            await CheckName(viewModel);

            ApplicationRole applicationRole = await FindApplicationRoleById(viewModel.Id);

            applicationRole.Name = viewModel.Name;
            applicationRole.NormalizedName = viewModel.Name;
            applicationRole.ImageUri = viewModel.ImageUri;

            Context.ApplicationRole.Update(applicationRole);

            await Context.SaveChangesAsync();

            // Log
            string logData = applicationRole.GetType().Name
                + " with Id "
                + applicationRole.Id
                + " was modified at "
                + DateTime.Now.ToShortTimeString();

            Logger.WriteUpdateItemLog(logData);

            return Mapper.Map<ViewApplicationRole>(applicationRole);
        }
    }
}
