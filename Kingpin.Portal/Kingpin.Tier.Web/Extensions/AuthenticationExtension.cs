﻿using System.Text;

using Kingpin.Tier.Settings.Classes;

using Microsoft.AspNetCore.Authentication.JwtBearer;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.IdentityModel.Tokens;

namespace Kingpin.Tier.Web.Extensions
{
    public static class AuthenticationExtension
    {
        public static void AddCustomAuthentication(this IServiceCollection services, JwtSettings JwtSettings)
        {
            services.AddAuthentication(JwtBearerDefaults.AuthenticationScheme)
               .AddJwtBearer(options =>
               {
                   options.TokenValidationParameters = new TokenValidationParameters
                   {
                       ValidateIssuer = true,
                       ValidateAudience = true,
                       ValidateLifetime = true,
                       ValidateIssuerSigningKey = true,

                       ValidIssuer = JwtSettings.JwtIssuer,
                       ValidAudience = JwtSettings.JwtAudience,
                       IssuerSigningKey = new SymmetricSecurityKey(Encoding.UTF8.GetBytes(JwtSettings.JwtKey))
                   };
               });
        }
    }
}
