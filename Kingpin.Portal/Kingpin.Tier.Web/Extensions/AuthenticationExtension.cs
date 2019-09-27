﻿using System.Text;

using Kingpin.Tier.Settings.Classes;
using Microsoft.Extensions.DependencyInjection;

namespace Kingpin.Tier.Web.Extensions
{
    public static class AuthenticationExtension
    {
        public static void AddCustomizedAuthentication(this IServiceCollection @this, JwtSettings JwtSettings)
        {
            @this.AddAuthentication(JwtBearerDefaults.AuthenticationScheme)
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
