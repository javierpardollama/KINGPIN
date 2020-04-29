using Kingpin.Tier.Contexts.Classes;
using Kingpin.Tier.Services.Classes;

using Microsoft.Extensions.Logging;

using NUnit.Framework;

namespace Kingpin.Tier.Services.Tests.Classes
{
    /// <summary>
    /// Represents a <see cref="TestSecurityService"/> class. Inherits <see cref="TestBaseService"/>
    /// </summary>
    [TestFixture]
    public class TestSecurityService : TestBaseService
    {
        /// <summary>
        /// Instance of <see cref="ILogger{SecurityService}"/>
        /// </summary>
        private ILogger<SecurityService> Logger;

        /// <summary>
        /// Initializes a new Instance of <see cref="TestSecurityService"/>
        /// </summary>
        public TestSecurityService()
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

            Logger = @loggerFactory.CreateLogger<SecurityService>();
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
