﻿using System;
using System.Net;
using System.Text.Json;
using System.Threading.Tasks;

using Kingpin.Tier.ViewModels.Classes.Views;
using Microsoft.AspNetCore.Http;

namespace Kingpin.Tier.ExceptionHandling.Middlewares
{
    public class ExceptionMiddleware
    {
        private readonly RequestDelegate Request;

        public ExceptionMiddleware(RequestDelegate @request) => Request = @request;

        public async Task InvokeAsync(HttpContext @context)
        {
            try
            {
                await Request(@context);
            }
            catch (Exception @exception)
            {
                await HandleExceptionAsync(@context, @exception);
            }
        }

        private static Task HandleExceptionAsync(
            HttpContext @context,
            Exception @exception)
        {
            @context.Response.ContentType = "application/json";
            @context.Response.StatusCode = (int)HttpStatusCode.InternalServerError;

            ViewException @viewException = new ViewException
            {
                StatusCode = context.Response.StatusCode,
                Message = @exception.Message
            };

            return @context.Response.WriteAsync(JsonSerializer.Serialize(@viewException, new JsonSerializerOptions() { WriteIndented = true }));
        }
    }
}