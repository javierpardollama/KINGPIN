using System.Collections.Generic;

using AutoMapper;

using Kingpin.Tier.Contexts.Classes;
using Kingpin.Tier.Mappings.Classes;

using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;

namespace Kingpin.Tier.Services.Tests.Classes
{
    /// <summary>
    /// Represents a <see cref="TestBaseService"/> class.
    /// </summary>
    public class TestBaseService
    {
        /// <summary>
        /// Instance of <see cref="DbContextOptions{ApplicationContext}"/>
        /// </summary>
        public DbContextOptions<ApplicationContext> Options;

        /// <summary>
        /// Instance of <see cref="IMapper"/>
        /// </summary>
        public IMapper Mapper;

        /// <summary>
        /// Instance of <see cref="ConfigurationBuilder"/>
        /// </summary>
        public ConfigurationBuilder ConfigurationBuilder;

        /// <summary>
        /// Instance of <see cref="IConfiguration"/>
        /// </summary>
        public IConfiguration Configuration;

        /// <summary>
        /// Sets Up Mapper
        /// </summary>
        public void SetUpMapper()
        {
            MapperConfiguration @config = new MapperConfiguration(cfg =>
            {
                cfg.AddProfile(new ModelingProfile());
            });

            Mapper = @config.CreateMapper();
        }

        /// <summary>
        /// Sets Up Options
        /// </summary>
        public void SetUpOptions()
        {
            Options = new DbContextOptionsBuilder<ApplicationContext>()
           .UseInMemoryDatabase(databaseName: "Data Source=kingpin.db")
           .Options;
        }

        /// <summary>
        /// Sets Up Configuration
        /// </summary>
        public void SetUpConfiguration()
        {
            Dictionary<string, string> JwtSettings = new Dictionary<string, string>           
            {
                { "Jwt:JwtKey", "SOME_RANDOM_KEY_DO_NOT_SHARE"},
                { "Jwt:JwtIssuer", "http://localhost:15208"},
                { "Jwt:JwtAudience", " http://localhost:4200"},
                { "Jwt:JwtExpireDays", "30"},               
            };

            Configuration = new ConfigurationBuilder().AddInMemoryCollection(JwtSettings).Build();
        }
    }
}