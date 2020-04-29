
using System;
using System.Collections.Generic;
using System.IdentityModel.Tokens.Jwt;
using System.Linq;

using Kingpin.Tier.Contexts.Classes;
using Kingpin.Tier.Entities.Classes;
using Kingpin.Tier.Services.Classes;

using NUnit.Framework;

namespace Kingpin.Tier.Services.Tests.Classes
{
    /// <summary>
    /// Represents a <see cref="TestTokenService"/> class. Inherits <see cref="TestBaseService"/>
    /// </summary>
    [TestFixture]
    public class TestTokenService : TestBaseService
    {
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
            SetUpMapper();

            SetUpOptions();
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
        public void GenerateJwtToken()
        {
            using (ApplicationContext @context = new ApplicationContext(this.Options))
            {
                SetUpContext(@context);

                SetUpConfiguration();

                TokenService @service = new TokenService(Configuration);

                @service.GenerateJwtToken(@context.ApplicationUser.FirstOrDefault());
            };

            Assert.Pass();
        }

        [Test]
        public void WriteJwtToken()
        {
            JwtSecurityToken JwtSecurityToken = new JwtSecurityToken();

            using (ApplicationContext @context = new ApplicationContext(this.Options))
            {
                SetUpContext(@context);

                SetUpConfiguration();

                TokenService @service = new TokenService(Configuration);

                @service.WriteJwtToken(JwtSecurityToken);
            };

            Assert.Pass();
        }

        [Test]
        public void GenerateSymmetricSecurityKey()
        {
            using (ApplicationContext @context = new ApplicationContext(this.Options))
            {
                SetUpContext(@context);

                SetUpConfiguration();

                TokenService @service = new TokenService(Configuration);

                @service.GenerateSymmetricSecurityKey();
            };

            Assert.Pass();
        }

        [Test]
        public void GenerateSigningCredentials()
        {
            using (ApplicationContext @context = new ApplicationContext(this.Options))
            {
                SetUpContext(@context);

                SetUpConfiguration();

                TokenService @service = new TokenService(Configuration);

                @service.GenerateSigningCredentials(@service.GenerateSymmetricSecurityKey());
            };

            Assert.Pass();
        }

        [Test]
        public void GenerateTokenExpirationDate()
        {
            using (ApplicationContext @context = new ApplicationContext(this.Options))
            {
                SetUpContext(@context);

                SetUpConfiguration();

                TokenService @service = new TokenService(Configuration);

                @service.GenerateTokenExpirationDate();
            };

            Assert.Pass();
        }

        [Test]
        public void GenerateJwtClaims()
        {
            using (ApplicationContext @context = new ApplicationContext(this.Options))
            {
                SetUpContext(@context);

                SetUpConfiguration();

                TokenService @service = new TokenService(Configuration);

                @service.GenerateJwtClaims(@context.ApplicationUser.FirstOrDefault());
            };

            Assert.Pass();
        }
    }    
}
