using System;
using System.Linq;
using System.Threading.Tasks;

using AutoMapper;

using Kingpin.Tier.Contexts.Interfaces;
using Kingpin.Tier.Entities.Classes;
using Kingpin.Tier.Logging.Classes;
using Kingpin.Tier.Services.Interfaces;
using Kingpin.Tier.ViewModels.Classes.ApplicationUsers;
using Kingpin.Tier.ViewModels.Classes.Views;

using Microsoft.AspNetCore.Identity;
using Microsoft.EntityFrameworkCore;
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
                           IApplicationContext iContext,
                           ILogger<AuthService> iLogger,
                           UserManager<ApplicationUser> userManager,
                           SignInManager<ApplicationUser> signInManager,
                           ITokenService iTokenService) : base(iContext, iMapper, iLogger)
        {
            UserManager = userManager;
            SignInManager = signInManager;
            ITokenService = iTokenService;
        }

        public async Task<ViewApplicationUser> SignIn(ApplicationUserSignIn viewModel)
        {
            SignInResult signInResult = await SignInManager.PasswordSignInAsync(viewModel.Email,
                                                                                viewModel.Password,
                                                                                false,
                                                                                false);

            if (signInResult.Succeeded)
            {
                ApplicationUser applicationUser = await FindApplicationUserByEmail(viewModel.Email);

                applicationUser.ApplicationUserTokens.Add(new ApplicationUserToken
                {
                    ApplicationUser = applicationUser,
                    UserId = applicationUser.Id,
                    Value = ITokenService.WriteJwtToken(ITokenService.GenerateJwtToken(viewModel.Email, applicationUser))
                });

                // Log
                string logData = applicationUser.GetType().Name
                    + " with Email "
                    + applicationUser.Email
                    + " logged in at "
                    + DateTime.Now.ToShortTimeString();

                ILogger.WriteUserAuthenticatedLog(logData);

                return IMapper.Map<ViewApplicationUser>(applicationUser);
            }
            else
            {
                throw new Exception("Authentication Error");
            }
        }

        public async Task<ViewApplicationUser> SignIn(ApplicationUserJoinIn viewModel)
        {
            SignInResult signInResult = await SignInManager.PasswordSignInAsync(viewModel.Email,
                                                                                viewModel.Password,
                                                                                false,
                                                                                false);

            if (signInResult.Succeeded)
            {
                ApplicationUser applicationUser = await FindApplicationUserByEmail(viewModel.Email);

                applicationUser.ApplicationUserTokens.Add(new ApplicationUserToken
                {
                    ApplicationUser = applicationUser,
                    UserId = applicationUser.Id,
                    Value = ITokenService.WriteJwtToken(ITokenService.GenerateJwtToken(viewModel.Email,
                                                                                       applicationUser))
                });

                // Log
                string logData = applicationUser.GetType().Name
                    + " with Email "
                    + applicationUser.Email
                    + " logged in at "
                    + DateTime.Now.ToShortTimeString();

                ILogger.WriteUserAuthenticatedLog(logData);

                return IMapper.Map<ViewApplicationUser>(applicationUser);
            }
            else
            {
                throw new Exception("Authentication Error");
            }
        }

        public async Task<ViewApplicationUser> JoinIn(ApplicationUserJoinIn viewModel)
        {
            ApplicationUser applicationUser = new ApplicationUser
            {
                UserName = viewModel.Email,
                Email = viewModel.Email,
                ConcurrencyStamp = DateTime.Now.ToBinary().ToString(),
                SecurityStamp = DateTime.Now.ToBinary().ToString(),
                NormalizedEmail = viewModel.Email,
                NormalizedUserName = viewModel.Email,
            };

            IdentityResult identityResult = await UserManager.CreateAsync(applicationUser,
                                                                          viewModel.Password);

            if (identityResult.Succeeded)
            {
                await IContext.SaveChangesAsync();

                return await SignIn(viewModel);
            }
            else
            {
                throw new Exception("Authentication Error");
            }
        }

        public async Task<ApplicationUser> FindApplicationUserByEmail(string email)
        {
            ApplicationUser applicationUser = await UserManager.Users.AsQueryable()
                .Include(x => x.ApplicationUserTokens)
                .Include(x => x.ApplicationUserRoles)
                .ThenInclude(x => x.ApplicationRole)
                .FirstOrDefaultAsync(x => x.Email == email);

            if (applicationUser == null)
            {
                // Log
                string logData = applicationUser.GetType().Name
                    + " with Email "
                    + email
                    + " was not found at "
                    + DateTime.Now.ToShortTimeString();

                ILogger.WriteGetItemNotFoundLog(logData);

                throw new Exception(applicationUser.GetType().Name
                    + " with Email "
                    + email
                    + " does not exist");
            }

            return applicationUser;
        }
    }
}
