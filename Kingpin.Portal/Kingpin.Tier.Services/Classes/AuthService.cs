﻿using System;
using System.Linq;
using System.Threading.Tasks;
using AutoMapper;
using Kingpin.Tier.Entities.Classes;
using Kingpin.Tier.Exceptions.Classes;
using Kingpin.Tier.Logging.Classes;
using Kingpin.Tier.Services.Interfaces;
using Kingpin.Tier.ViewModels.Classes.Users;
using Kingpin.Tier.ViewModels.Classes.Views;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using SignInResult = Microsoft.AspNetCore.Identity.SignInResult;

namespace Kingpin.Tier.Services.Classes
{
    public class AuthService : BaseService, IAuthService
    {
        private readonly SignInManager<ApplicationUser> SignInManager;

        private readonly UserManager<ApplicationUser> UserManager;

        private readonly ITokenService ITokenService;

        public AuthService(IMapper iMapper,
                           ILogger<AuthService> iLogger,
                           UserManager<ApplicationUser> userManager,
                           SignInManager<ApplicationUser> signInManager,
                           ITokenService iTokenService) : base(iMapper, iLogger)
        {
            UserManager = userManager;
            SignInManager = signInManager;
            ITokenService = iTokenService;
        }

        public async Task<ActionResult<ViewApplicationUser>> SignIn(ApplicationUserSignIn viewModel)
        {
            SignInResult signInResult = await SignInManager.PasswordSignInAsync(viewModel.Email, viewModel.Password, false, false);

            if (signInResult.Succeeded)
            {
                ApplicationUser applicationUser = FindApplicationUserByEmail(viewModel.Email);

                // Log
                string logData = applicationUser.GetType().Name
                    + " with Email "
                    + applicationUser.Email
                    + " logged in at "
                    + DateTime.Now.ToShortTimeString();

                ILogger.WriteUserAuthenticatedLog(logData);

                ITokenService.WriteJwtToken(ITokenService.GenerateJwtToken(viewModel.Email, applicationUser));

                return IMapper.Map<ViewApplicationUser>(applicationUser);
            }
            else
            {
                throw new ServiceException("Authentication Error");
            }
        }

        public async Task<ActionResult<ViewApplicationUser>> JoinIn(ApplicationUserJoinIn viewModel)
        {
            ApplicationUser applicationUser = new ApplicationUser
            {
                UserName = viewModel.Email,
                Email = viewModel.Email,
                ConcurrencyStamp = DateTime.Now.ToBinary().ToString(),
                SecurityStamp = DateTime.Now.ToBinary().ToString()
            };

            IdentityResult identityResult = await UserManager.CreateAsync(applicationUser, viewModel.Password);

            if (identityResult.Succeeded)
            {
                await SignInManager.SignInAsync(applicationUser, false);

                // Log
                string logData = applicationUser.GetType().Name
                    + " with Email "
                    + applicationUser.Email
                    + " logged in at "
                    + DateTime.Now.ToShortTimeString();

                ILogger.WriteUserAuthenticatedLog(logData);

                ITokenService.WriteJwtToken(ITokenService.GenerateJwtToken(viewModel.Email, applicationUser));

                return IMapper.Map<ViewApplicationUser>(applicationUser);
            }
            else
            {
                throw new ServiceException("Authentication Error");
            }
        }

        public ApplicationUser FindApplicationUserByEmail(string email)
        {
            ApplicationUser applicationUser = UserManager.Users.SingleOrDefault(x => x.Email == email);

            if (applicationUser == null)
            {
                // Log
                string logData = applicationUser.GetType().Name
                    + " with Email "
                    + email
                    + " was not found at "
                    + DateTime.Now.ToShortTimeString();

                ILogger.WriteGetItemNotFoundLog(logData);

                throw new ServiceException(applicationUser.GetType().Name
                    + " with Email "
                    + email
                    + " does not exist");
            }

            return applicationUser;
        }
    }
}
