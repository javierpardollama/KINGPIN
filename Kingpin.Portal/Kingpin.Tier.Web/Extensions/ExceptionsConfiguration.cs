using Kingpin.Tier.ExceptionHandling.Middlewares;
using Microsoft.AspNetCore.Builder;

namespace Kingpin.Tier.Web.Extensions
{
    public static class ExceptionsConfiguration
    {
        public static void UseCustomExceptionMiddlewares(this IApplicationBuilder app)
        {
            app.UseMiddleware<ExceptionMiddleware>();
        }
    }
}
