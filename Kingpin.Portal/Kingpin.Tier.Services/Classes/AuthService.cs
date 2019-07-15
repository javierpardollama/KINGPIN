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
using System;
using System.Linq;
using System.Threading.Tasks;
using SignInResult = Microsoft.AspNetCore.Identity.SignInResult;

namespace Kingpin.Tier.Services.Classes
{
    public class AuthService : BaseService, IAuthService
    {
        private readonly SignInManager<ApplicationUser> SignInManager;

        private readonly UserManager<ApplicationUser> UserManager;

        private readonly ITokenService ITokenService;

        public AuthService(
            IMapper iMapper,
            ILogger<AuthService> iLogger,           
            UserManager<ApplicationUser> userManager,
            SignInManager<ApplicationUser> signInManager,
            ITokenService iTokenService) : base(iMapper, iLogger)
        {
            UserManager = userManager;
            SignInManager = signInManager;
            ITokenService = iTokenService;
        }

        public async Task<ActionResult<ViewUser>> SignIn(UserSignIn viewModel)
        {
            SignInResult signInResult = await SignInManager.PasswordSignInAsync(viewModel.Email, viewModel.Password, false, false);

            if (signInResult.Succeeded)
            {
                ApplicationUser identityUser = FindIdentityUserByEmail(viewModel.Email);

                // Log
                string logData = identityUser.GetType().Name
                    + " with Email "
                    + identityUser.Email
                    + " logged in at "
                    + DateTime.Now.ToShortTimeString();

                ILogger.WriteUserAuthenticatedLog(logData);

                ITokenService.WriteJwtToken(ITokenService.GenerateJwtToken(viewModel.Email, identityUser));

                return IMapper.Map<ViewUser>(identityUser);               
            }
            else
            {
                throw new ServiceException("Authentication Error");
            } 
        }

        public async Task<ActionResult<ViewUser>> JoinIn(UserJoinIn viewModel)
        {
            ApplicationUser identityUser = new ApplicationUser
            {
                UserName = viewModel.Email,
                Email = viewModel.Email,
                ConcurrencyStamp = DateTime.Now.ToBinary().ToString(),
                SecurityStamp = DateTime.Now.ToBinary().ToString()
            };

            IdentityResult identityResult = await UserManager.CreateAsync(identityUser, viewModel.Password);

            if (identityResult.Succeeded)
            {    
                await SignInManager.SignInAsync(identityUser, false);

                // Log
                string logData = identityUser.GetType().Name
                    + " with Email "
                    + identityUser.Email
                    + " logged in at "
                    + DateTime.Now.ToShortTimeString();

                ILogger.WriteUserAuthenticatedLog(logData);

                ITokenService.WriteJwtToken(ITokenService.GenerateJwtToken(viewModel.Email, identityUser));

                return IMapper.Map<ViewUser>(identityUser);
            }
            else
            {
                throw new ServiceException("Authentication Error");
            }
        }

        public ApplicationUser FindIdentityUserByEmail(string email)
        {
            ApplicationUser identityUser = UserManager.Users.SingleOrDefault(x => x.Email == email);

            if (identityUser == null)
            {
                // Log
                string logData = identityUser.GetType().Name
                    + " with Email "
                    + email
                    + " was not found at "
                    + DateTime.Now.ToShortTimeString();

                ILogger.WriteGetItemNotFoundLog(logData);

                throw new ServiceException(identityUser.GetType().Name
                    + " with Email "
                    + email
                    + " does not exist");
            }

            return identityUser;
        }
    }
}
