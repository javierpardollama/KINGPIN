using Kingpin.Tier.Entities.Classes;
using Kingpin.Tier.ViewModels.Classes.Additions;
using Kingpin.Tier.ViewModels.Classes.Updates;
using Kingpin.Tier.ViewModels.Classes.Views;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace Kingpin.Tier.Services.Interfaces
{
    public interface IRoleService : IBaseService
    {
        Task<ICollection<ViewRole>> FindAllIdentityRole();

        Task<ApplicationRole> FindIdentityRoleById(int id);

        Task RemoveIdentityRoleById(int id);

        Task<ViewRole> UpdateIdentityRole(UpdateRole viewModel);

        Task<ViewRole> AddIdentityRole(AddRole viewModel);

        Task<ApplicationRole> CheckName(AddRole viewModel);
    }
}
