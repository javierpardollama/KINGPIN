using System.Threading.Tasks;

using Kingpin.Tier.Entities.Classes;
using Kingpin.Tier.ViewModels.Classes.ApplicationUsers;
using Kingpin.Tier.ViewModels.Classes.Views;

namespace Kingpin.Tier.Services.Interfaces
{
    public interface IAuthService : IBaseService
    {
        Task<ViewApplicationUser> SignIn(ApplicationUserSignIn viewModel);

        Task<ViewApplicationUser> SignIn(ApplicationUserJoinIn viewModel);

        Task<ViewApplicationUser> JoinIn(ApplicationUserJoinIn viewModel);

        ApplicationUser FindApplicationUserByEmail(string email);
    }
}
