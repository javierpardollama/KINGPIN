using System;
using System.Linq;
using System.Threading.Tasks;

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
        /// Instance of <see cref="ApplicationRoleService"/>
        /// </summary>
        private ApplicationRoleService Service;

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
            SetUpJwtSettings();

            SetUpServices();

            SetUpMapper();

            SetUpLogger();

            SetUpContext();

            Service = new ApplicationRoleService(Mapper, Context, Logger);          
        }

        /// <summary>
        /// Tears Down
        /// </summary>
        [TearDown]
        public void TearDown()
        {
            Context.ApplicationUser.RemoveRange(Context.ApplicationUser.ToList());
            Context.ApplicationRole.RemoveRange(Context.ApplicationRole.ToList());

            Context.SaveChanges();
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
        private void SetUpContext()
        {
            Context.ApplicationRole.Add(new ApplicationRole { Name = "Role 1", LastModified = DateTime.Now, Deleted = false, ImageUri = "URL/Role_1_500px.png" });
            Context.ApplicationRole.Add(new ApplicationRole { Name = "Role 2", LastModified = DateTime.Now, Deleted = false, ImageUri = "URL/Role_2_500px.png" });
            Context.ApplicationRole.Add(new ApplicationRole { Name = "Role 3", LastModified = DateTime.Now, Deleted = false, ImageUri = "URL/Role_3_500px.png" });

            Context.SaveChanges();
        }

        [Test]
        public async Task FindAllApplicationRole()
        {
            await Service.FindAllApplicationRole();

            Assert.Pass();
        }

        [Test]
        public async Task FindApplicationRoleById()
        {
            await Service.FindApplicationRoleById(Context.ApplicationRole.FirstOrDefault().Id);

            Assert.Pass();
        }

        [Test]
        public async Task RemoveApplicationRoleById()
        {
            await Service.RemoveApplicationRoleById(Context.ApplicationRole.FirstOrDefault().Id);

            Assert.Pass();
        }

        [Test]
        public async Task UpdateApplicationRole()
        {
            UpdateApplicationRole viewModel = new UpdateApplicationRole()
            {
                Id = Context.ApplicationRole.FirstOrDefault().Id,
                Name = "Role 21",
                ImageUri = "URL/Role_21_500px.png",
            };

            await Service.UpdateApplicationRole(viewModel);

            Assert.Pass();
        }

        [Test]
        public async Task AddApplicationRole()
        {
            AddApplicationRole viewModel = new AddApplicationRole()
            {
                Name = "Role 41",
                ImageUri = "URL/Role_41_500px.png",
            };

            await Service.AddApplicationRole(viewModel);

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

            Exception exception = Assert.ThrowsAsync<Exception>(async () => await Service.CheckName(viewModel));

            Assert.Pass();
        }
    }
}
