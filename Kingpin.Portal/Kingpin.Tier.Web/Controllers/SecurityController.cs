﻿using System.Threading.Tasks;

using Kingpin.Tier.Services.Interfaces;
using Kingpin.Tier.ViewModels.Classes.Security;

using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace Kingpin.Tier.Web.Controllers
{
    /// <summary>
    /// Represents a <see cref="ApplicationUserController"/> class. Inherits <see cref="ControllerBase"/>
    /// </summary>
    [Route("api/security")]
    [Produces("application/json")]
    [ApiController]
    public class SecurityController : ControllerBase
    {
        /// <summary>
        /// Instance of <see cref="ISecurityService"/>
        /// </summary>
        private readonly ISecurityService Service;

        /// <summary>
        /// Initializes a new Instance of <see cref="SecurityController"/>
        /// </summary>
        /// <param name="service">Injected <see cref="ISecurityService"/></param>
        public SecurityController(ISecurityService @service) => Service = @service;

        /// <summary>
        /// Resets Password
        /// </summary>
        /// <param name="viewModel">Injected <see cref="SecurityPasswordReset"/></param>
        /// <returns>Instance of <see cref="JsonResult"/></returns>
        [HttpPut]
        [Route("resetpassword")]
        public async Task<IActionResult> ResetPassword([FromBody]SecurityPasswordReset @viewModel) => new JsonResult(value: await Service.ResetPassword(@viewModel));

        /// <summary>
        /// Changes Password
        /// </summary>
        /// <param name="viewModel">Injected <see cref="SecurityPasswordChange"/></param>
        /// <returns>Instance of <see cref="JsonResult"/></returns>
        [HttpPut]
        [Route("changepassword")]
        [Authorize]
        public async Task<IActionResult> ChangePassword([FromBody]SecurityPasswordChange @viewModel) => new JsonResult(value: await Service.ChangePassword(@viewModel));

        /// <summary>
        /// Changes Email
        /// </summary>>
        /// <param name="viewModel">Injected <see cref="SecurityEmailChange"/></param>
        /// <returns>Instance of <see cref="JsonResult"/></returns>
        [HttpPut]
        [Route("changeemail")]
        [Authorize]
        public async Task<IActionResult> ChangeEmail([FromBody]SecurityEmailChange @viewModel) => new JsonResult(value: await Service.ChangeEmail(@viewModel));
    }
}
