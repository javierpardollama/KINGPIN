using System.Net;
using System.Threading.Tasks;

using Kingpin.Tier.Services.Interfaces;
using Kingpin.Tier.ViewModels.Classes.Additions;
using Kingpin.Tier.ViewModels.Classes.Updates;

using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace Kingpin.Tier.Web.Controllers
{
    [Route("api/applicationrole")]
    [Produces("application/json")]
    [Authorize]
    [ApiController]
    public class ApplicationRoleController : ControllerBase
    {
        private readonly IApplicationRoleService Service;

        public ApplicationRoleController(IApplicationRoleService @service) => Service = @service;

        [HttpPut]
        [Route("updateapplicationrole")]
        public async Task<IActionResult> UpdateApplicationRole([FromBody]UpdateApplicationRole @viewModel) => new JsonResult(value: await Service.UpdateApplicationRole(@viewModel));

        [HttpGet]
        [Route("findallapplicationrole")]
        public async Task<IActionResult> FindAllApplicationRole() => new JsonResult(value: await Service.FindAllApplicationRole());

        [HttpPost]
        [Route("addapplicationrole")]
        public async Task<IActionResult> AddApplicationRole([FromBody]AddApplicationRole @viewModel) => new JsonResult(value: await Service.AddApplicationRole(@viewModel));

        [HttpDelete]
        [Route("removeapplicationrolebyid/{id}")]
        public async Task<IActionResult> RemoveApplicationRoleById(int @id)
        {
            await Service.RemoveApplicationRoleById(@id);

            return new JsonResult((int)HttpStatusCode.OK);
        }
    }
}
