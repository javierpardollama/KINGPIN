﻿
using System;
using System.Collections.Generic;
using System.IdentityModel.Tokens.Jwt;
using System.Linq;

using Kingpin.Tier.Contexts.Classes;
using Kingpin.Tier.Entities.Classes;
using Kingpin.Tier.Services.Classes;

using Microsoft.Extensions.Logging;

using NUnit.Framework;

namespace Kingpin.Tier.Services.Tests.Classes
{
    /// <summary>
    /// Represents a <see cref="TestTokenService"/> class. Inherits <see cref="TestBaseService"/>
    /// </summary>
    [TestFixture]
    public class TestTokenService : TestBaseService
    {
        private TokenService Service;

        /// <summary>
        /// Instance of <see cref="ILogger{TokenService}"/>
        /// </summary>
        private ILogger<TokenService> Logger;

        /// <summary>
        /// Initializes a new Instance of <see cref="TestTokenService"/>
        /// </summary>
        public TestTokenService()
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

            SetUpContext(Context);

            Service = new TokenService(Logger, JwtOptions);
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

            Logger = @loggerFactory.CreateLogger<TokenService>();
        }

        /// <summary>
        /// Generates Jwt Token
        /// </summary>
        [Test]
        public void GenerateJwtToken()
        {
            Service.GenerateJwtToken(Context.ApplicationUser.FirstOrDefault());

            Assert.Pass();
        }

        /// <summary>
        /// Writes Jwt Token
        /// </summary>
        [Test]
        public void WriteJwtToken()
        {
            JwtSecurityToken JwtSecurityToken = new JwtSecurityToken();

            Service.WriteJwtToken(JwtSecurityToken);

            Assert.Pass();
        }

        /// <summary>
        /// Generates Symmetric Security Key
        /// </summary>
        [Test]
        public void GenerateSymmetricSecurityKey()
        {
            Service.GenerateSymmetricSecurityKey();

            Assert.Pass();
        }

        /// <summary>
        /// Generates Signing Credentials
        /// </summary>
        [Test]
        public void GenerateSigningCredentials()
        {
            Service.GenerateSigningCredentials(Service.GenerateSymmetricSecurityKey());

            Assert.Pass();
        }

        /// <summary>
        /// Generates Token Expiration Date
        /// </summary>
        [Test]
        public void GenerateTokenExpirationDate()
        {
            Service.GenerateTokenExpirationDate();

            Assert.Pass();
        }

        /// <summary>
        /// Generates Jwt Claims
        /// </summary>
        [Test]
        public void GenerateJwtClaims()
        {
            Service.GenerateJwtClaims(Context.ApplicationUser.FirstOrDefault());

            Assert.Pass();
        }
    }
}
