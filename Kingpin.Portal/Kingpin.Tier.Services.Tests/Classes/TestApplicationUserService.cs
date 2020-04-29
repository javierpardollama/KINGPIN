using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

using Kingpin.Tier.Contexts.Classes;
using Kingpin.Tier.Entities.Classes;
using Kingpin.Tier.Services.Classes;
using Kingpin.Tier.ViewModels.Classes.Updates;
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
            @context.ApplicationUser.Add(new ApplicationUser { Email = "firstuser@email.com", LastModified = DateTime.Now, Deleted = false, ApplicationUserRoles = new List<ApplicationUserRole>() });
            @context.ApplicationUser.Add(new ApplicationUser { Email = "seconduser@email.com", LastModified = DateTime.Now, Deleted = false, ApplicationUserRoles = new List<ApplicationUserRole>() });
            @context.ApplicationUser.Add(new ApplicationUser { Email = "thirstuser@email.com", LastModified = DateTime.Now, Deleted = false, ApplicationUserRoles = new List<ApplicationUserRole>() });

            @context.ApplicationRole.Add(new ApplicationRole { Name = "Role 1", LastModified = DateTime.Now, Deleted = false });
            @context.ApplicationRole.Add(new ApplicationRole { Name = "Role 2", LastModified = DateTime.Now, Deleted = false });
            @context.ApplicationRole.Add(new ApplicationRole { Name = "Role 3", LastModified = DateTime.Now, Deleted = false });

            @context.SaveChanges();
        }

        [Test]
        public async Task FindAllApplicationUser()
        {
            using (ApplicationContext @context = new ApplicationContext(this.Options))
            {
                SetUpContext(@context);

                ApplicationUserService @service = new ApplicationUserService(Mapper, @context, Logger);

                await @service.FindAllApplicationUser();
            };

            Assert.Pass();
        }

        [Test]
        public async Task FindApplicationUserById()
        {
            using (ApplicationContext @context = new ApplicationContext(this.Options))
            {
                SetUpContext(@context);

                ApplicationUserService @service = new ApplicationUserService(Mapper, @context, Logger);

                await @service.FindApplicationUserById(@context.ApplicationUser.FirstOrDefault().Id);
            };

            Assert.Pass();
        }

        [Test]
        public async Task RemoveApplicationUserById()
        {
            using (ApplicationContext @context = new ApplicationContext(this.Options))
            {
                SetUpContext(@context);

                ApplicationUserService @service = new ApplicationUserService(Mapper, @context, Logger);

                await @service.RemoveApplicationUserById(@context.ApplicationUser.FirstOrDefault().Id);
            };

            Assert.Pass();
        }

        [Test]
        public async Task UpdateApplicationUser()
        {
            UpdateApplicationUser viewModel = new UpdateApplicationUser()
            {
                Id = 2,
                ApplicationRolesId = new List<int> { 1 }
            };

            using (ApplicationContext @context = new ApplicationContext(this.Options))
            {
                SetUpContext(@context);

                ApplicationUserService @service = new ApplicationUserService(Mapper, @context, Logger);

                await @service.UpdateApplicationUser(viewModel);
            };

            Assert.Pass();
        }

        [Test]
        public void UpdateApplicationUserRole()
        {
            UpdateApplicationUser viewModel = new UpdateApplicationUser()
            {
                Id = 2,
                ApplicationRolesId = new List<int> { 2 }
            };

            using (ApplicationContext @context = new ApplicationContext(this.Options))
            {
                SetUpContext(@context);

                ApplicationUserService @service = new ApplicationUserService(Mapper, @context, Logger);

                @service.UpdateApplicationUserRole(viewModel, @context.ApplicationUser.FirstOrDefault());
            };

            Assert.Pass();
        }

        [Test]
        public async Task FindApplicationRoleById()
        {
            using (ApplicationContext @context = new ApplicationContext(this.Options))
            {
                SetUpContext(@context);

                ApplicationUserService @service = new ApplicationUserService(Mapper, @context, Logger);

                await @service.FindApplicationRoleById(@context.ApplicationRole.FirstOrDefault().Id);
            };

            Assert.Pass();
        }
    }
}
