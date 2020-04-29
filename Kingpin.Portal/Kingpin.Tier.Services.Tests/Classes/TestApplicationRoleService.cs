using Kingpin.Tier.Contexts.Classes;
using Kingpin.Tier.Services.Classes;

using Microsoft.Extensions.Logging;

using NUnit.Framework;

namespace Kingpin.Tier.Services.Tests.Classes
{
    public class TestApplicationRoleService : TestBaseService
    {
        /// <summary>
        /// Instance of <see cref="ILogger{ApplicationRoleService}"/>
        /// </summary>
        private ILogger<ApplicationRoleService> Logger;

        /// <summary>
        /// Initializes a new Instance of <see cref="TestApplicationRoleService"/>
        /// </summary>
        public TestApplicationRoleService()
        {

        }

        /// <summary>
        /// Sets Up
        /// </summary>
        [SetUp]
        public void Setup()
        {
            SetUpMapper();

            SetUpOptions();

            SetUpLogger();
        }

        /// <summary>
        /// Sets Up Logger
        /// </summary>
        private void SetUpLogger()
        {
            ILoggerFactory @loggerFactory = LoggerFactory.Create(builder =>
            {
                builder
                    .AddFilter("Microsoft", LogLevel.Warning)
                    .AddFilter("System", LogLevel.Warning)
                    .AddConsole();
            });

            Logger = @loggerFactory.CreateLogger<ApplicationRoleService>();
        }

        /// <summary>
        /// Sets Up Context
        /// </summary>
        /// <param name="context">Injected <see cref="ApplicationContext"/></param>
        private void SetUpContext(ApplicationContext @context)
        {           

            @context.SaveChanges();
        }
    }
}
