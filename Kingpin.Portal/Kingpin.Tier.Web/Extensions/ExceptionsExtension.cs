using Kingpin.Tier.ExceptionHandling.Middlewares;

using Microsoft.AspNetCore.Builder;

namespace Kingpin.Tier.Web.Extensions
{
    public static class ExceptionsExtension
    {
        public static void UseCustomizedExceptionMiddlewares(this IApplicationBuilder @this)
        {
            @this.UseMiddleware<ExceptionMiddleware>();
        }
    }
}
