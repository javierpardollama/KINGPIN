using Kingpin.Tier.Services.Interfaces;
using Kingpin.Tier.ViewModels.Classes.Users;
using Microsoft.AspNetCore.Mvc;
using System.Threading.Tasks;

namespace Kingpin.Tier.Web.Controllers
{
    [Route("api/auth")]
    [Produces("application/json")]
    public class AuthController
    {
        private readonly IAuthService Service;

        public AuthController(IAuthService service) => this.Service = service;

        [HttpPost]
        [Route("signin")]
        public async Task<IActionResult> SignIn([FromBody]UserSignIn viewModel)
        {
            return new JsonResult(await Service.SignIn(viewModel));
        }

        [HttpPost]
        [Route("joinin")]
        public async Task<IActionResult> JoinIn([FromBody]UserJoinIn viewModel)
        {
            return new JsonResult(await Service.JoinIn(viewModel));
        }
    }
}
