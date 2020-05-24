﻿using System.Threading.Tasks;

using Kingpin.Tier.Services.Interfaces;
using Kingpin.Tier.ViewModels.Classes.Auth;

using Microsoft.AspNetCore.Mvc;

namespace Kingpin.Tier.Web.Controllers
{
    /// <summary>
    /// Represents a <see cref="AuthController"/> class. Inherits <see cref="ControllerBase"/>
    /// </summary>
    [Route("api/auth")]
    [Produces("application/json")]
    [ApiController]
    public class AuthController : ControllerBase
    {
        /// <summary>
        /// Instance of <see cref="IAuthService"/>
        /// </summary>
        private readonly IAuthService Service;

        /// <summary>
        /// Initializes a new Instance of <see cref="AuthController"/>
        /// </summary>
        /// <param name="service">Injected <see cref="IAuthService"/></param>
        public AuthController(IAuthService @service) => Service = @service;

        /// <summary>
        /// Signs In
        /// </summary>
        /// <param name="viewModel">Injected <see cref="AuthSignIn"/></param>
        /// <returns>Instance of <see cref="Task{JsonResult}"/></returns>
        [HttpPost]
        [Route("signin")]
        public async Task<IActionResult> SignIn([FromBody]AuthSignIn @viewModel) => new JsonResult(value: await Service.SignIn(@viewModel));

        /// <summary>
        /// Joins In
        /// </summary>
        /// <param name="viewModel">Injected <see cref="AuthJoinIn"/></param>
        /// <returns>Instance of <see cref="Task{JsonResult}"/></returns>
        [HttpPost]
        [Route("joinin")]
        public async Task<IActionResult> JoinIn([FromBody]AuthJoinIn @viewModel) => new JsonResult(value: await Service.JoinIn(@viewModel));
    }
}
