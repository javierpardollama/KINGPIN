using Kingpin.Tier.Entities.Classes;
using Kingpin.Tier.ViewModels.Classes.Security;
using Kingpin.Tier.ViewModels.Classes.Views;
using System.Threading.Tasks;

namespace Kingpin.Tier.Services.Interfaces
{
    public interface ISecurityService : IBaseService
    {
        Task<ApplicationUser> FindApplicationUserByEmail(string email);

        Task<ViewApplicationUser> ResetPassword(SecurityPasswordReset viewModel);

        Task<ViewApplicationUser> ChangePassword(SecurityPasswordChange viewModel);

        Task<ViewApplicationUser> ChangeEmail(SecurityEmailChange viewModel);
    }
}
