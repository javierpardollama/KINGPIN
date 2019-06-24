using Kingpin.Tier.Exceptions.Classes;
using Kingpin.Tier.ViewModels.Classes.Views;
using Microsoft.AspNetCore.Http;
using Newtonsoft.Json;
using System.Net;
using System.Threading.Tasks;

namespace Kingpin.Tier.ExceptionHandling.Middlewares
{
    public class ExceptionMiddleware
    {
        private readonly RequestDelegate RequestDelegate;

        public ExceptionMiddleware(RequestDelegate request) => this.RequestDelegate = request;

        public async Task InvokeAsync(HttpContext httpContext)
        {
            try
            {
                await this.RequestDelegate(httpContext);
            }
            catch (ServiceException ex)
            {
                await HandleExceptionAsync(httpContext, ex);
            }
        }

        private static Task HandleExceptionAsync(
            HttpContext context,
            ServiceException exception)
        {
            context.Response.ContentType = "application/json";
            context.Response.StatusCode = (int)HttpStatusCode.InternalServerError;

            ViewException viewException = new ViewException
            {
                StatusCode = context.Response.StatusCode,
                Message = exception.Message
            };

            return context.Response.WriteAsync(JsonConvert.SerializeObject(viewException));
        }
    }
}