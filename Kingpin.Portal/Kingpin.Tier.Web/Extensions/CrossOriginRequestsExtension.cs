﻿using Kingpin.Tier.Settings.Classes;

using Microsoft.Extensions.DependencyInjection;

namespace Kingpin.Tier.Web.Extensions
{
    public static class CrossOriginRequestsExtension
    {
        public static void AddCustomizedCrossOriginRequests(this IServiceCollection @this, JwtSettings JwtSettings)
        {
            @this.AddCors(options =>
            {
                options.AddPolicy("Authentication", builder =>
                {
                    builder.WithOrigins(JwtSettings.JwtAudience).AllowAnyOrigin().AllowAnyHeader().AllowAnyMethod().Build();
                });
            });
        }
    }
}
