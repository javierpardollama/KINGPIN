using Kingpin.Tier.Services.Interfaces;
using Kingpin.Tier.ViewModels.Classes.Additions;
using Kingpin.Tier.ViewModels.Classes.Updates;
using Kingpin.Tier.ViewModels.Classes.Views;
using Microsoft.AspNetCore.Mvc;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace Kingpin.Tier.Web.Controllers
{
    [Route("api/role")]
    [Produces("application/json")]
    public class RoleController : Controller
    {
        private readonly IRoleService Service;

        public RoleController(IRoleService service) => Service = service;

        [HttpPut]
        [Route("updaterole")]
        public async Task<IActionResult> UpdateIdentityRole([FromBody]UpdateRole viewModel)
        {
            ViewRole bandera = await Service.UpdateIdentityRole(viewModel);

            return new JsonResult(bandera);
        }

        [HttpGet]
        [Route("findallrole")]
        public async Task<IActionResult> FindAllIdentityRole()
        {
            ICollection<ViewRole> banderas = await Service.FindAllIdentityRole();

            return new JsonResult(banderas);
        }

        [HttpPost]
        [Route("addrole")]
        public async Task<IActionResult> AddIdentityRole([FromBody]AddRole viewModel)
        {
            ViewRole bandera = await Service.AddIdentityRole(viewModel);

            return new JsonResult(bandera);
        }

        [HttpDelete]
        [Route("removerolebyid/{id}")]
        public async Task<IActionResult> RemoveIdentityRoleById(int id)
        {
            await Service.RemoveIdentityRoleById(id);

            return new JsonResult(StatusCode(200));
        }
    }
}
