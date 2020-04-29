using System.Threading.Tasks;

using Kingpin.Tier.Services.Interfaces;
using Kingpin.Tier.ViewModels.Classes.Auth;

using Microsoft.AspNetCore.Mvc;

namespace Kingpin.Tier.Web.Controllers
{
    [Route("api/auth")]
    [Produces("application/json")]
    [ApiController]
    public class AuthController : ControllerBase
    {
        private readonly IAuthService Service;

        public AuthController(IAuthService @service) => Service = @service;

        [HttpPost]
        [Route("signin")]
        public async Task<IActionResult> SignIn([FromBody]AuthSignIn @viewModel) => new JsonResult(value: await Service.SignIn(@viewModel));

        [HttpPost]
        [Route("joinin")]
        public async Task<IActionResult> JoinIn([FromBody]AuthJoinIn @viewModel) => new JsonResult(value: await Service.JoinIn(@viewModel));
    }
}
