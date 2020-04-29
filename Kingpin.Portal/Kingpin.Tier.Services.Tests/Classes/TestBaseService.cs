using System.Collections.Generic;

using AutoMapper;

using Kingpin.Tier.Contexts.Classes;
using Kingpin.Tier.Entities.Classes;
using Kingpin.Tier.Mappings.Classes;

using Microsoft.AspNetCore.Identity;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;

namespace Kingpin.Tier.Services.Tests.Classes
{
    /// <summary>
    /// Represents a <see cref="TestBaseService"/> class.
    /// </summary>
    public class TestBaseService
    {
        /// <summary>
        /// Instance of <see cref="IMapper"/>
        /// </summary>
        public IMapper Mapper;        

        /// <summary>
        /// Instance of <see cref="IConfiguration"/>
        /// </summary>
        public IConfiguration Configuration;

        /// <summary>
        /// Instance of <see cref="Dictionary{string, string}"/>
        /// </summary>
        private Dictionary<string, string> JwtSettings;

        /// <summary>
        /// Instance of <see cref="ApplicationContext"/>
        /// </summary>
        public ApplicationContext Context;

        /// <summary>
        /// Instance of <see cref="UserManager{ApplicationUser}"/>
        /// </summary>
        public UserManager<ApplicationUser> UserManager;

        /// <summary>
        /// Instance of <see cref="UserManager{ApplicationUser}"/>
        /// </summary>
        public SignInManager<ApplicationUser> SignInManager;

        /// <summary>
        /// Instance of <see cref="ServiceCollection"/>
        /// </summary>
        private ServiceCollection Services;

        /// <summary>
        /// Instance of <see cref="ServiceProvider"/>
        /// </summary>
        private ServiceProvider ServiceProvider;

        /// <summary>
        /// Sets Up Services
        /// </summary>
        public void SetUpServices() 
        {
            Services = new ServiceCollection();

            Services
                .AddSingleton(Configuration)
                .AddDbContext<ApplicationContext>(o => o.UseSqlite("Data Source=kingpin.db"))
                .AddIdentity<ApplicationUser, ApplicationRole>()
                .AddEntityFrameworkStores<ApplicationContext>()
                .AddDefaultTokenProviders(); ;

            Services.AddLogging();

            Services.Configure<IdentityOptions>(config =>
            {
                config.Password.RequiredLength = 6;
                config.Password.RequireDigit = false;
                config.Password.RequireLowercase = false;
                config.Password.RequireNonAlphanumeric = false;
                config.Password.RequireUppercase = false;
            });

            ServiceProvider = Services.BuildServiceProvider();

            Context = ServiceProvider.GetRequiredService<ApplicationContext>();
            UserManager = ServiceProvider.GetRequiredService<UserManager<ApplicationUser>>();
            SignInManager = ServiceProvider.GetRequiredService<SignInManager<ApplicationUser>>();           
        }  

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
        /// Sets Up Jwt Settings
        /// </summary>
        public void SetUpJwtSettings()
        {
            JwtSettings = new Dictionary<string, string>           
            {
                { "Jwt:JwtKey", "SOME_RANDOM_KEY_DO_NOT_SHARE"},
                { "Jwt:JwtIssuer", "http://localhost:15208"},
                { "Jwt:JwtAudience", " http://localhost:4200"},
                { "Jwt:JwtExpireDays", "30"},               
            };
        }

        /// <summary>
        /// Sets Up Configuration
        /// </summary>
        public void SetUpConfiguration()
        {     
            Configuration = new ConfigurationBuilder().AddInMemoryCollection(JwtSettings).Build();
        }
    }
}