﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

using Kingpin.Tier.Entities.Classes;
using Kingpin.Tier.Services.Classes;
using Kingpin.Tier.ViewModels.Classes.Auth;

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

        /// <summary>
        /// Instance of <see cref="TokenService"/>
        /// </summary>>
        private TokenService TokenService;

        /// <summary>
        /// Instance of <see cref="AuthService"/>
        /// </summary>
        private AuthService Service;


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
            SetUpJwtSettings();

            SetUpConfiguration();

            SetUpServices();

            SetUpMapper();

            SetUpLogger();

            SetUpContext();

            TokenService = new TokenService(Configuration);

            Service = new AuthService(Mapper, Logger, UserManager, SignInManager, TokenService);
        }

        /// <summary>
        /// Tears Down
        /// </summary>
        [TearDown]
        public void TearDown()
        {
            Context.ApplicationUser.RemoveRange(Context.ApplicationUser.ToList());
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
        private void SetUpContext()
        {
            Context.ApplicationUser.Add(new ApplicationUser { PasswordHash = "dcb97c304778b75e4309bdd51d61c906dc184cd37df1256fdafd3e54cf6218bb", UserName = "firstuser@email.com", Email = "firstuser@email.com", LastModified = DateTime.Now, Deleted = false, ConcurrencyStamp = new Guid().ToString(), SecurityStamp = new Guid().ToString(), ApplicationUserRoles = new List<ApplicationUserRole>() });
            Context.ApplicationUser.Add(new ApplicationUser { PasswordHash = "dcb97c304778b75e4309bdd51d61c906dc184cd37df1256fdafd3e54cf6218bb", UserName = "seconduser@email.com", Email = "seconduser@email.com", LastModified = DateTime.Now, Deleted = false, ConcurrencyStamp = new Guid().ToString(), SecurityStamp = new Guid().ToString(), ApplicationUserRoles = new List<ApplicationUserRole>() });
            Context.ApplicationUser.Add(new ApplicationUser { PasswordHash = "dcb97c304778b75e4309bdd51d61c906dc184cd37df1256fdafd3e54cf6218bb", UserName = "thirstuser@email.com", Email = "thirstuser@email.com", LastModified = DateTime.Now, Deleted = false, ConcurrencyStamp = new Guid().ToString(), SecurityStamp = new Guid().ToString(), ApplicationUserRoles = new List<ApplicationUserRole>() });

            Context.SaveChanges();
        }

        [Test]
        public void SignIn()
        {
            AuthSignIn viewModel = new AuthSignIn()
            {
                Email = "firstuser@email.com",
                Password = "P@55w0rd"
            };          

            Exception exception = Assert.ThrowsAsync<Exception>(async () => await Service.SignIn(viewModel));

            Assert.Pass();
        }

        [Test]
        public async Task JoinIn()
        {
            AuthJoinIn viewModel = new AuthJoinIn()
            {
                Email = "fourthuser@email.com",
                Password = "P@55w0rd"
            };

            await Service.JoinIn(viewModel);

            Assert.Pass();
        }

        [Test]
        public async Task FindApplicationUserByEmail()
        {
            await Service.FindApplicationUserByEmail(Context.ApplicationUser.FirstOrDefault().Email);

            Assert.Pass();
        }

        [Test]
        public void CheckEmail()
        {
            AuthJoinIn viewModel = new AuthJoinIn()
            {
                Email = "firstuser@email.com",
                Password = "P@55w0rd"
            };

            Exception exception = Assert.ThrowsAsync<Exception>(async () => await Service.CheckEmail(viewModel));

            Assert.Pass();
        }
    }
}
