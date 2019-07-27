using AutoMapper;

using Kingpin.Tier.Contexts.Interfaces;
using Kingpin.Tier.Services.Interfaces;
using Kingpin.Tier.Settings.Classes;

using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.Logging;

namespace Kingpin.Tier.Services.Classes
{
    public class BaseService : IBaseService
    {
        protected readonly IApplicationContext IContext;

        protected readonly IMapper IMapper;

        protected readonly ILogger ILogger;

        protected readonly IConfiguration IConfiguration;

        protected readonly JwtSettings JwtSettings;

        public BaseService(
            IApplicationContext iContext,
            IMapper iMapper,
            ILogger iLogger
           )
        {
            IContext = iContext;
            IMapper = iMapper;
            ILogger = iLogger;
        }

        public BaseService(
            IMapper iMapper,
            ILogger iLogger
           )
        {
            IMapper = iMapper;
            ILogger = iLogger;
        }

        public BaseService(
            IConfiguration iConfiguration
           )
        {
            IConfiguration = iConfiguration;

            JwtSettings = new JwtSettings();
            IConfiguration.GetSection("Jwt").Bind(JwtSettings);
        }
    }
}
