using System;
using System.Linq;
using System.Threading.Tasks;

using Kingpin.Tier.Contexts.Classes;
using Kingpin.Tier.Entities.Classes;
using Kingpin.Tier.Services.Classes;
using Kingpin.Tier.ViewModels.Classes.Additions;
using Kingpin.Tier.ViewModels.Classes.Updates;
using Microsoft.Extensions.Logging;

using NUnit.Framework;

namespace Kingpin.Tier.Services.Tests.Classes
{
    /// <summary>
    /// Represents a <see cref="TestApplicationRoleService"/> class. Inherits <see cref="TestBaseService"/>
    /// </summary>
    [TestFixture]
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
            @context.ApplicationRole.Add(new ApplicationRole { Name = "Role 1", LastModified = DateTime.Now, Deleted = false });
            @context.ApplicationRole.Add(new ApplicationRole { Name = "Role 2", LastModified = DateTime.Now, Deleted = false });
            @context.ApplicationRole.Add(new ApplicationRole { Name = "Role 3", LastModified = DateTime.Now, Deleted = false });

            @context.SaveChanges();
        }

        [Test]
        public async Task FindAllApplicationRole() 
        {
            using (ApplicationContext @context = new ApplicationContext(this.Options))
            {
                SetUpContext(@context);

                ApplicationRoleService @service = new ApplicationRoleService(Mapper, @context, Logger);

                await @service.FindAllApplicationRole();
            };

            Assert.Pass();
        }

        [Test]
        public async Task FindApplicationRoleById() 
        {
            using (ApplicationContext @context = new ApplicationContext(this.Options))
            {
                SetUpContext(@context);

                ApplicationRoleService @service = new ApplicationRoleService(Mapper, @context, Logger);

                await @service.FindApplicationRoleById(@context.ApplicationRole.FirstOrDefault().Id);
            };

            Assert.Pass();
        }

        [Test]
        public async Task RemoveApplicationRoleById() 
        {
            using (ApplicationContext @context = new ApplicationContext(this.Options))
            {
                SetUpContext(@context);

                ApplicationRoleService @service = new ApplicationRoleService(Mapper, @context, Logger);

                await @service.RemoveApplicationRoleById(@context.ApplicationRole.FirstOrDefault().Id);
            };

            Assert.Pass();
        }

        [Test]
        public async Task UpdateApplicationRole() 
        {
            UpdateApplicationRole viewModel = new UpdateApplicationRole()
            {
                Id = 2,
                Name = "Role 21",
                ImageUri = "URL/Role_21_500px.png",
            };

            using (ApplicationContext @context = new ApplicationContext(this.Options))
            {
                SetUpContext(@context);

                ApplicationRoleService @service = new ApplicationRoleService(Mapper, @context, Logger);

                await @service.UpdateApplicationRole(viewModel);
            };

            Assert.Pass();
        }

        [Test]
        public async Task AddApplicationRole() 
        {
            AddApplicationRole viewModel = new AddApplicationRole()
            {
                Name = "Role 31",
                ImageUri = "URL/Role_31_500px.png",
            };

            using (ApplicationContext @context = new ApplicationContext(this.Options))
            {
                SetUpContext(@context);

                ApplicationRoleService @service = new ApplicationRoleService(Mapper, @context, Logger);

                await @service.AddApplicationRole(viewModel);
            };

            Assert.Pass();
        }

        [Test]
        public void CheckName() 
        {
            AddApplicationRole viewModel = new AddApplicationRole()
            {
                Name = "Role 2",
                ImageUri = "URL/Role_2_500px.png",
            };

            using (ApplicationContext @context = new ApplicationContext(this.Options))
            {
                SetUpContext(@context);

                ApplicationRoleService @service = new ApplicationRoleService(Mapper, @context, Logger);

                Exception exception = Assert.ThrowsAsync<Exception>(async () => await @service.CheckName(viewModel));
            };

            Assert.Pass();
        }
    }
}
