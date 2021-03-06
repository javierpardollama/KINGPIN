﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

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
        private ILogger<SecurityService> SecurityLogger;

        /// <summary>
        /// Instance of <see cref="ILogger{TokenService}"/>
        /// </summary>
        private ILogger<TokenService> TokenLogger;

        /// <summary>
        /// Instance of <see cref="TokenService"/>
        /// </summary>>
        private TokenService TokenService;

        /// <summary>
        /// Instance of <see cref="SecurityService"/>
        /// </summary>
        private SecurityService Service;


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
            SetUpContextOptions();

            SetUpJwtOptions();

            SetUpServices();

            SetUpMapper();

            SetUpLogger();

            SetUpContext();

            TokenService = new TokenService(TokenLogger, JwtOptions);

            Service = new SecurityService(Mapper, SecurityLogger, JwtOptions, UserManager, TokenService);
        }

        /// <summary>
        /// Tears Down
        /// </summary>
        [TearDown]
        public void TearDown()
        {
            Context.ApplicationUser.RemoveRange(Context.ApplicationUser.ToList());

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

            SecurityLogger = @loggerFactory.CreateLogger<SecurityService>();
            TokenLogger = @loggerFactory.CreateLogger<TokenService>();
        }

        /// <summary>
        /// Sets Up Context
        /// </summary>
        private void SetUpContext()
        {
            Context.ApplicationUser.Add(new ApplicationUser { PasswordHash = "dcb97c304778b75e4309bdd51d61c906dc184cd37df1256fdafd3e54cf6218bb", UserName = "firstuser@email.com", Email = "firstuser@email.com", LastModified = DateTime.Now, Deleted = false, ConcurrencyStamp = new Guid().ToString(), SecurityStamp = new Guid().ToString(), ApplicationUserRoles = new List<ApplicationUserRole>() });
            Context.ApplicationUser.Add(new ApplicationUser { PasswordHash = "dcb97c304778b75e4309bdd51d61c906dc184cd37df1256fdafd3e54cf6218bb", UserName = "seconduser@email.com", Email = "seconduser@email.com", LastModified = DateTime.Now, Deleted = false, ConcurrencyStamp = new Guid().ToString(), SecurityStamp = new Guid().ToString(), ApplicationUserRoles = new List<ApplicationUserRole>() });
            Context.ApplicationUser.Add(new ApplicationUser { PasswordHash = "dcb97c304778b75e4309bdd51d61c906dc184cd37df1256fdafd3e54cf6218bb", UserName = "thirstuser@email.com", Email = "thirdtuser@email.com", LastModified = DateTime.Now, Deleted = false, ConcurrencyStamp = new Guid().ToString(), SecurityStamp = new Guid().ToString(), ApplicationUserRoles = new List<ApplicationUserRole>() });

            Context.SaveChanges();
        }

        /// <summary>
        /// Finds Application User By Email
        /// </summary>
        /// <returns>Instance of <see cref="Task"/></returns>
        [Test]
        public async Task FindApplicationUserByEmail()
        {
            await Service.FindApplicationUserByEmail(Context.ApplicationUser.FirstOrDefault().Email);

            Assert.Pass();
        }

        /// <summary>
        /// Resets Password
        /// </summary>
        /// <returns>Instance of <see cref="Task"/></returns>
        [Test]
        public async Task ResetPassword()
        {
            SecurityPasswordReset viewModel = new SecurityPasswordReset()
            {
                Email = Context.ApplicationUser.FirstOrDefault(x=>x.Email =="firstuser@email.com").Email,
                NewPassword = "P@55w0rd"
            };

            await Service.ResetPassword(viewModel);

            Assert.Pass();
        }

        /// <summary>
        /// Changes Password
        /// </summary>
        [Test]
        public void ChangePassword()
        {
            SecurityPasswordChange viewModel = new SecurityPasswordChange()
            {
                CurrentPassword = "P@55w0rd",
                NewPassword = "P@55w0rd",
                ApplicationUser = new ViewApplicationUser
                {
                    Id = Context.ApplicationUser.FirstOrDefault(x => x.Email == "seconduser@email.com").Id,
                    Email = Context.ApplicationUser.FirstOrDefault(x => x.Email == "seconduser@email.com").Email
                }
            };

            Exception exception = Assert.ThrowsAsync<Exception>(async () => await Service.ChangePassword(viewModel));

            Assert.Pass();
        }

        /// <summary>
        /// Changes Email
        /// </summary>
        /// <returns>Instance of <see cref="Task"/></returns>
        [Test]
        public async Task ChangeEmail()
        {
            SecurityEmailChange viewModel = new SecurityEmailChange()
            {
                NewEmail = "newthirduser@email.com",
                ApplicationUser = new ViewApplicationUser
                {
                    Id = Context.ApplicationUser.FirstOrDefault(x => x.Email == "thirdtuser@email.com").Id,
                    Email = Context.ApplicationUser.FirstOrDefault(x => x.Email == "thirdtuser@email.com").Email
                }
            };

            await Service.ChangeEmail(viewModel);

            Assert.Pass();
        }
    }
}
