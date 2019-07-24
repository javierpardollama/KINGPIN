using System.Threading.Tasks;

using Kingpin.Tier.Services.Interfaces;
using Kingpin.Tier.ViewModels.Classes.Updates;

using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace Kingpin.Tier.Web.Controllers
{
    [Route("api/applicationuser")]
    [Produces("application/json")]
    [Authorize]
    public class ApplicationUserController : Controller
    {
        private readonly IApplicationUserService Service;

        public ApplicationUserController(IApplicationUserService service) => Service = service;

        [HttpPut]
        [Route("updateapplicationuser")]
        public async Task<IActionResult> UpdateApplicationUser([FromBody]UpdateApplicationUser viewModel)
        {
            return new JsonResult(value: await Service.UpdateApplicationUser(viewModel));
        }

        [HttpGet]
        [Route("findallapplicationuser")]
        public async Task<IActionResult> FindAllApplicationUser()
        {
            return new JsonResult(value: await Service.FindAllApplicationUser());
        }

        [HttpDelete]
        [Route("removeapplicationuserbyid/{id}")]
        public async Task<IActionResult> RemoveApplicationUserById(int id)
        {
            await Service.RemoveApplicationUserById(id);

            return new JsonResult(StatusCode(200));
        }
    }
}
