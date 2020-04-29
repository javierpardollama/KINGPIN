using Kingpin.Tier.Contexts.Classes;
using Kingpin.Tier.Services.Classes;

using Microsoft.Extensions.Logging;

using NUnit.Framework;

namespace Kingpin.Tier.Services.Tests.Classes
{
    /// <summary>
    /// Represents a <see cref="TestApplicationUserService"/> class. Inherits <see cref="TestBaseService"/>
    /// </summary>
    [TestFixture]
    public class TestApplicationUserService : TestBaseService
    {
        /// <summary>
        /// Instance of <see cref="ILogger{ApplicationUserService}"/>
        /// </summary>
        private ILogger<ApplicationUserService> Logger;

        /// <summary>
        /// Initializes a new Instance of <see cref="TestApplicationUserService"/>
        /// </summary>
        public TestApplicationUserService()
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

            Logger = @loggerFactory.CreateLogger<ApplicationUserService>();
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
