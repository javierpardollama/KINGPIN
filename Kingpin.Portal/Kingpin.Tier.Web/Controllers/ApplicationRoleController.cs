using Kingpin.Tier.Services.Interfaces;
using Kingpin.Tier.ViewModels.Classes.Additions;
using Kingpin.Tier.ViewModels.Classes.Updates;
using Kingpin.Tier.ViewModels.Classes.Views;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace Kingpin.Tier.Web.Controllers
{
    [Route("api/applicationrole")]
    [Produces("application/json")]
    [Authorize]
    public class ApplicationRoleController : Controller
    {
        private readonly IApplicationRoleService Service;

        public ApplicationRoleController(IApplicationRoleService service) => Service = service;

        [HttpPut]
        [Route("updateapplicationrole")]
        public async Task<IActionResult> UpdateApplicationRole([FromBody]UpdateApplicationRole viewModel)
        {
            ViewApplicationRole applicationRole = await Service.UpdateApplicationRole(viewModel);

            return new JsonResult(applicationRole);
        }

        [HttpGet]
        [Route("findallapplicationrole")]
        public async Task<IActionResult> FindAllApplicationRole()
        {
            ICollection<ViewApplicationRole> applicationRoles = await Service.FindAllApplicationRole();

            return new JsonResult(applicationRoles);
        }

        [HttpPost]
        [Route("addapplicationrole")]
        public async Task<IActionResult> AddApplicationRole([FromBody]AddApplicationRole viewModel)
        {
            ViewApplicationRole applicationRole = await Service.AddApplicationRole(viewModel);

            return new JsonResult(applicationRole);
        }

        [HttpDelete]
        [Route("removeapplicationrolebyid/{id}")]
        public async Task<IActionResult> RemoveApplicationRoleById(int id)
        {
            await Service.RemoveApplicationRoleById(id);

            return new JsonResult(StatusCode(200));
        }
    }
}
