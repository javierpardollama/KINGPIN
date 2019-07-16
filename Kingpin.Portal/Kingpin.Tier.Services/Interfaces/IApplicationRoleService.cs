using Kingpin.Tier.Entities.Classes;
using Kingpin.Tier.ViewModels.Classes.Additions;
using Kingpin.Tier.ViewModels.Classes.Updates;
using Kingpin.Tier.ViewModels.Classes.Views;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace Kingpin.Tier.Services.Interfaces
{
    public interface IApplicationRoleService : IBaseService
    {
        Task<ICollection<ViewApplicationRole>> FindAllApplicationRole();

        Task<ApplicationRole> FindApplicationRoleById(int id);

        Task RemoveApplicationRoleById(int id);

        Task<ViewApplicationRole> UpdateApplicationRole(UpdateApplicationRole viewModel);

        Task<ViewApplicationRole> AddApplicationRole(AddApplicationRole viewModel);

        Task<ApplicationRole> CheckName(AddApplicationRole viewModel);
    }
}
