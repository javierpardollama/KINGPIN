using System.Collections.Generic;
using System.Threading.Tasks;

using Kingpin.Tier.Entities.Classes;
using Kingpin.Tier.ViewModels.Classes.Updates;
using Kingpin.Tier.ViewModels.Classes.Views;

namespace Kingpin.Tier.Services.Interfaces
{
    public interface IApplicationUserService : IBaseService
    {
        Task<ICollection<ViewApplicationUser>> FindAllApplicationUser();

        Task<ApplicationUser> FindApplicationUserById(int @id);

        Task RemoveApplicationUserById(int @id);

        Task<ViewApplicationUser> UpdateApplicationUser(UpdateApplicationUser @viewModel);

        void UpdateApplicationUserRole(UpdateApplicationUser @viewModel, ApplicationUser @entity);

        Task<ApplicationRole> FindApplicationRoleById(int @id);
    }
}
