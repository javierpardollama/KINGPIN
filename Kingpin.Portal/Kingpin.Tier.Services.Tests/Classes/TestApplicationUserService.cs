﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

using Kingpin.Tier.Contexts.Classes;
using Kingpin.Tier.Entities.Classes;
using Kingpin.Tier.Services.Classes;
using Kingpin.Tier.ViewModels.Classes.Updates;

using Microsoft.EntityFrameworkCore;
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
        /// Instance of <see cref="ApplicationUserService"/>
        /// </summary>
        private ApplicationUserService Service;

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
            SetUpJwtSettings();

            SetUpConfiguration();

            SetUpServices();

            SetUpMapper();

            SetUpLogger();
            
            SetUpContext();

            Service = new ApplicationUserService(Mapper, Context, Logger);          
        }

        /// <summary>
        /// Tears Down
        /// </summary>
        [TearDown]
        public void TearDown()
        {
            Context.ApplicationUser.RemoveRange(Context.ApplicationUser.ToList());
            Context.ApplicationRole.RemoveRange(Context.ApplicationRole.ToList());
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
        private void SetUpContext()
        {
            Context.ApplicationUser.Add(new ApplicationUser { Email = "firstuser@email.com", LastModified = DateTime.Now, Deleted = false, SecurityStamp = new Guid().ToString(), ApplicationUserRoles = new List<ApplicationUserRole>() });
            Context.ApplicationUser.Add(new ApplicationUser { Email = "seconduser@email.com", LastModified = DateTime.Now, Deleted = false, SecurityStamp = new Guid().ToString(), ApplicationUserRoles = new List<ApplicationUserRole>() });
            Context.ApplicationUser.Add(new ApplicationUser { Email = "thirstuser@email.com", LastModified = DateTime.Now, Deleted = false, SecurityStamp = new Guid().ToString(), ApplicationUserRoles = new List<ApplicationUserRole>() });

            Context.ApplicationRole.Add(new ApplicationRole { Name = "Role 1", LastModified = DateTime.Now, Deleted = false, ImageUri = "URL/Role_1_500px.png" });
            Context.ApplicationRole.Add(new ApplicationRole { Name = "Role 2", LastModified = DateTime.Now, Deleted = false, ImageUri = "URL/Role_2_500px.png" });
            Context.ApplicationRole.Add(new ApplicationRole { Name = "Role 3", LastModified = DateTime.Now, Deleted = false, ImageUri = "URL/Role_3_500px.png" });

            Context.SaveChanges();
        }

        [Test]
        public async Task FindAllApplicationUser()
        {
            await Service.FindAllApplicationUser();

            Assert.Pass();
        }

        [Test]
        public async Task FindApplicationUserById()
        {
            await Service.FindApplicationUserById(Context.ApplicationUser.FirstOrDefault().Id);

            Assert.Pass();
        }

        [Test]
        public async Task RemoveApplicationUserById()
        {
            await Service.RemoveApplicationUserById(Context.ApplicationUser.FirstOrDefault().Id);

            Assert.Pass();
        }

        [Test]
        public async Task UpdateApplicationUser()
        {
            UpdateApplicationUser viewModel = new UpdateApplicationUser()
            {
                Id = Context.ApplicationUser.FirstOrDefault().Id,
                ApplicationRolesId = new List<int> { Context.ApplicationRole.FirstOrDefault().Id }
            };

            await Service.UpdateApplicationUser(viewModel);

            Assert.Pass();
        }

        [Test]
        public void UpdateApplicationUserRole()
        {
            UpdateApplicationUser viewModel = new UpdateApplicationUser()
            {
                Id = Context.ApplicationUser.FirstOrDefault().Id,
                ApplicationRolesId = new List<int> { 2 }
            };

            Service.UpdateApplicationUserRole(viewModel, Context.ApplicationUser.FirstOrDefault());

            Assert.Pass();
        }

        [Test]
        public async Task FindApplicationRoleById()
        {
            await Service.FindApplicationRoleById(Context.ApplicationRole.FirstOrDefault().Id);

            Assert.Pass();
        }
    }
}
