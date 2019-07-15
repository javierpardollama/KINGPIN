using Kingpin.Tier.Entities.Classes;
using Kingpin.Tier.ViewModels.Classes.Users;
using Kingpin.Tier.ViewModels.Classes.Views;
using Microsoft.AspNetCore.Mvc;
using System.Threading.Tasks;

namespace Kingpin.Tier.Services.Interfaces
{
    public interface IAuthService : IBaseService
    {
        Task<ActionResult<ViewUser>> SignIn(UserSignIn viewModel);

        Task<ActionResult<ViewUser>> JoinIn(UserJoinIn viewModel);

        ApplicationUser FindIdentityUserByEmail(string email);
    }
}
