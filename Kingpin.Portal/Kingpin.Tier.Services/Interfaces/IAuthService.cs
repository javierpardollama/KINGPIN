using System.Threading.Tasks;
using Kingpin.Tier.Entities.Classes;
using Kingpin.Tier.ViewModels.Classes.Users;
using Kingpin.Tier.ViewModels.Classes.Views;
using Microsoft.AspNetCore.Mvc;

namespace Kingpin.Tier.Services.Interfaces
{
    public interface IAuthService : IBaseService
    {
        Task<ActionResult<ViewApplicationUser>> SignIn(ApplicationUserSignIn viewModel);

        Task<ActionResult<ViewApplicationUser>> SignIn(ApplicationUserJoinIn viewModel);

        Task<ActionResult<ViewApplicationUser>> JoinIn(ApplicationUserJoinIn viewModel);       

        ApplicationUser FindApplicationUserByEmail(string email);
    }
}
