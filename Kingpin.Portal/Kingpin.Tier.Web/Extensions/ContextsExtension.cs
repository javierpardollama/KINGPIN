using Kingpin.Tier.Contexts.Classes;
using Kingpin.Tier.Contexts.Interfaces;

using Microsoft.Extensions.DependencyInjection;

namespace Kingpin.Tier.Web.Extensions
{
    public static class ContextsExtension
    {
        public static void AddCustomContexts(this IServiceCollection services)
        {
            services.AddScoped<IApplicationContext, ApplicationContext>();

            // Add other services here
        }
    }
}
