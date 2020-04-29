using Kingpin.Tier.Services.Classes;
using Kingpin.Tier.Services.Interfaces;

using Microsoft.Extensions.DependencyInjection;

namespace Kingpin.Tier.Web.Extensions
{
    /// <summary>
    /// Represents a <see cref="ServicesExtension"/> class.
    /// </summary>
    public static class ServicesExtension
    {
        /// <summary>
        /// Extends Customized Services
        /// </summary>
        /// <param name="this">Injected <see cref="IServiceCollection"/></param>
        public static void AddCustomizedServices(this IServiceCollection @this)
        {
            @this.AddTransient<ITokenService, TokenService>();
            @this.AddTransient<IAuthService, AuthService>();
            @this.AddTransient<IApplicationRoleService, ApplicationRoleService>();
            @this.AddTransient<IApplicationUserService, ApplicationUserService>();
            @this.AddTransient<ISecurityService, SecurityService>();

            // Add other services here
        }
    }
}
