using Kingpin.Tier.Services.Classes;
using Kingpin.Tier.Services.Interfaces;
using Microsoft.Extensions.DependencyInjection;

namespace Kingpin.Tier.Web.Extensions
{
    public static class ServicesExtension
    {
        public static void AddCustomServices(this IServiceCollection services)
        {
            services.AddTransient<ITokenService, TokenService>();
            services.AddTransient<IAuthService, AuthService>();
            services.AddTransient<IApplicationRoleService, ApplicationRoleService>();
            // Add other services here
        }
    }
}
