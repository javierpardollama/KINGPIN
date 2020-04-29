using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

using Kingpin.Tier.Contexts.Classes;
using Kingpin.Tier.Entities.Classes;
using Kingpin.Tier.Services.Classes;
using Kingpin.Tier.ViewModels.Classes.Auth;

using Microsoft.AspNetCore.Identity;
using Microsoft.Extensions.Logging;

using NUnit.Framework;

namespace Kingpin.Tier.Services.Tests.Classes
{
    /// <summary>
    /// Represents a <see cref="TestAuthService"/> class. Inherits <see cref="TestBaseService"/>
    /// </summary>
    [TestFixture]
    public class TestAuthService : TestBaseService
    {
        /// <summary>
        /// Instance of <see cref="ILogger{AuthService}"/>
        /// </summary>
        private ILogger<AuthService> Logger;

        private IUserStore<ApplicationUser> UserStore;

        /// <summary>
        /// Initializes a new Instance of <see cref="TestAuthService"/>
        /// </summary>
        public TestAuthService()
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

            Logger = @loggerFactory.CreateLogger<AuthService>();
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
        public async Task SignIn() 
        {
            AuthSignIn viewModel = new AuthSignIn()
            {
                Email = "firstuser@email.com",
                Password ="P@55w0rd"
            };

            using (ApplicationContext @context = new ApplicationContext(this.Options))
            {
                SetUpContext(@context);

                AuthService @service = new AuthService(Mapper, Logger,null, null,null );

                await @service.SignIn(viewModel);
            };

            Assert.Pass();
        }

        [Test]
        public async Task JoinIn()
        {
            AuthJoinIn viewModel = new AuthJoinIn()
            {
                Email = "firstuser@email.com",
                Password = "P@55w0rd"
            };

            using (ApplicationContext @context = new ApplicationContext(this.Options))
            {
                SetUpContext(@context);

                AuthService @service = new AuthService(Mapper, Logger, null, null, null);

                await @service.JoinIn(viewModel);
            };

            Assert.Pass();
        }

        [Test]
        public async Task FindApplicationUserByEmail()
        {
            using (ApplicationContext @context = new ApplicationContext(this.Options))
            {
                SetUpContext(@context);

                AuthService @service = new AuthService(Mapper, Logger, null, null, null);

                await @service.FindApplicationUserByEmail(@context.ApplicationUser.FirstOrDefault().Email);
            };

            Assert.Pass();
        }

        [Test]
        public async Task CheckEmail()
        {
            AuthJoinIn viewModel = new AuthJoinIn()
            {
                Email = "firstuser@email.com",
                Password = "P@55w0rd"
            };

            using (ApplicationContext @context = new ApplicationContext(this.Options))
            {
                SetUpContext(@context);

                AuthService @service = new AuthService(Mapper, Logger, null, null, null);

                await @service.CheckEmail(viewModel);
            };

            Assert.Pass();
        }
    }
}
