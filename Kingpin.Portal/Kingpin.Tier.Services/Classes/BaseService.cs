using AutoMapper;
using Kingpin.Tier.Contexts.Interfaces;
using Kingpin.Tier.Services.Interfaces;
using Microsoft.Extensions.Logging;

namespace Kingpin.Tier.Services.Classes
{
    public class BaseService : IBaseService
    {
        protected readonly IApplicationContext Icontext;

        protected readonly IMapper Imapper;

        protected readonly ILogger ILogger;

        public BaseService(
            IApplicationContext iContext,
            IMapper iMapper,
            ILogger iLogger)
        {
            Icontext = iContext;
            Imapper = iMapper;
            ILogger = iLogger;
        }
    }
}
