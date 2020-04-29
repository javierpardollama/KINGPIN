using System.Threading.Tasks;

using Kingpin.Tier.Entities.Classes;
using Kingpin.Tier.ViewModels.Classes.Auth;
using Kingpin.Tier.ViewModels.Classes.Views;

namespace Kingpin.Tier.Services.Interfaces
{
    public interface IAuthService : IBaseService
    {
        Task<ViewApplicationUser> SignIn(AuthSignIn @viewModel);

        Task<ViewApplicationUser> SignIn(AuthJoinIn @viewModel);

        Task<ViewApplicationUser> JoinIn(AuthJoinIn @viewModel);

        Task<ApplicationUser> FindApplicationUserByEmail(string @email);

        Task<ApplicationUser> CheckEmail(AuthJoinIn @viewModel);
    }
}
