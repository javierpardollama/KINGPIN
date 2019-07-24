using System;
using System.Net;
using System.Threading.Tasks;

using Kingpin.Tier.ViewModels.Classes.Views;

using Microsoft.AspNetCore.Http;

using Newtonsoft.Json;

namespace Kingpin.Tier.ExceptionHandling.Middlewares
{
    public class ExceptionMiddleware
    {
        private readonly RequestDelegate RequestDelegate;

        public ExceptionMiddleware(RequestDelegate request) => RequestDelegate = request;

        public async Task InvokeAsync(HttpContext httpContext)
        {
            try
            {
                await RequestDelegate(httpContext);
            }
            catch (Exception ex)
            {
                await HandleExceptionAsync(httpContext, ex);
            }
        }

        private static Task HandleExceptionAsync(
            HttpContext httpContext,
            Exception exception)
        {
            httpContext.Response.ContentType = "application/json";
            httpContext.Response.StatusCode = (int)HttpStatusCode.InternalServerError;

            ViewException viewException = new ViewException
            {
                StatusCode = httpContext.Response.StatusCode,
                Message = exception.Message
            };

            return httpContext.Response.WriteAsync(JsonConvert.SerializeObject(viewException));
        }
    }
}