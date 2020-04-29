using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

using Kingpin.Tier.Contexts.Classes;
using Kingpin.Tier.Entities.Classes;
using Kingpin.Tier.Services.Classes;
using Kingpin.Tier.ViewModels.Classes.Security;
using Kingpin.Tier.ViewModels.Classes.Views;
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
            @context.ApplicationUser.Add(new ApplicationUser { Email = "firstuser@email.com", LastModified = DateTime.Now, Deleted = false, ApplicationUserRoles = new List<ApplicationUserRole>() });
            @context.ApplicationUser.Add(new ApplicationUser { Email = "seconduser@email.com", LastModified = DateTime.Now, Deleted = false, ApplicationUserRoles = new List<ApplicationUserRole>() });
            @context.ApplicationUser.Add(new ApplicationUser { Email = "thirstuser@email.com", LastModified = DateTime.Now, Deleted = false, ApplicationUserRoles = new List<ApplicationUserRole>() });

            @context.SaveChanges();
        }

        [Test]
        public async Task FindApplicationUserByEmail()
        {
            using (ApplicationContext @context = new ApplicationContext(this.Options))
            {
                SetUpContext(@context);

                SecurityService @service = new SecurityService(Mapper, Logger, null, null);

                await @service.FindApplicationUserByEmail(@context.ApplicationUser.FirstOrDefault().Email);
            };

            Assert.Pass();
        }

        [Test]
        public async Task ResetPassword()
        {
            SecurityPasswordReset viewModel = new SecurityPasswordReset()
            {
                Email = "firstuser@email.com",
                NewPassword = "P@55w0rd"
            };

            using (ApplicationContext @context = new ApplicationContext(this.Options))
            {
                SetUpContext(@context);

                SecurityService @service = new SecurityService(Mapper, Logger, null, null);

                await @service.ResetPassword(viewModel);
            };

            Assert.Pass();
        }

        [Test]
        public async Task ChangePassword()
        {
            SecurityPasswordChange viewModel = new SecurityPasswordChange()
            {
                CurrentPassword = "P@55w0rd",
                NewPassword = "P@55w0rd",
                ApplicationUser = new ViewApplicationUser
                {
                    Id = 1,
                    Email = "firstuser@email.com"
                }
            };

            using (ApplicationContext @context = new ApplicationContext(this.Options))
            {
                SetUpContext(@context);

                SecurityService @service = new SecurityService(Mapper, Logger, null, null);

                await @service.ChangePassword(viewModel);
            };

            Assert.Pass();
        }

        [Test]
        public async Task ChangeEmail()
        {
            SecurityEmailChange viewModel = new SecurityEmailChange()
            {
                NewEmail= "newfirstuser@email.com",
                ApplicationUser = new ViewApplicationUser
                {
                    Id = 1,
                    Email = "firstuser@email.com"
                }
            };

            using (ApplicationContext @context = new ApplicationContext(this.Options))
            {
                SetUpContext(@context);

                SecurityService @service = new SecurityService(Mapper, Logger, null, null);

                await @service.ChangeEmail(viewModel);
            };

            Assert.Pass();
        }
    }
}
