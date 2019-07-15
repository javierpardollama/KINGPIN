using Microsoft.Extensions.DependencyInjection;

namespace Kingpin.Tier.Web.Extensions
{
    public static class CrossOriginRequestsConfiguration
    {
        public static void AddCustomCrossOriginRequests(this IServiceCollection services)
        {
            services.AddCors(options =>
            {
                options.AddPolicy("EnableCORS", builder =>
                {
                    builder.AllowAnyOrigin().AllowAnyHeader().AllowAnyMethod().AllowCredentials().Build();
                });
            });
        }
    }
}
