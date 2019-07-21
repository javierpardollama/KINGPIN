﻿using System.Threading.Tasks;

using Kingpin.Tier.Services.Interfaces;
using Kingpin.Tier.ViewModels.Classes.ApplicationUsers;

using Microsoft.AspNetCore.Mvc;

namespace Kingpin.Tier.Web.Controllers
{
    [Route("api/auth")]
    [Produces("application/json")]
    public class AuthController
    {
        private readonly IAuthService Service;

        public AuthController(IAuthService service) => Service = service;

        [HttpPost]
        [Route("signin")]
        public async Task<IActionResult> SignIn([FromBody]ApplicationUserSignIn viewModel)
        {
            return new JsonResult(value: await Service.SignIn(viewModel));
        }

        [HttpPost]
        [Route("joinin")]
        public async Task<IActionResult> JoinIn([FromBody]ApplicationUserJoinIn viewModel)
        {
            return new JsonResult(value: await Service.JoinIn(viewModel));
        }
    }
}
