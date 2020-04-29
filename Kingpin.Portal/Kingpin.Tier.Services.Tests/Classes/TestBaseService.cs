﻿using AutoMapper;

using Microsoft.EntityFrameworkCore;

using Kingpin.Tier.Contexts.Classes;
using Kingpin.Tier.Mappings.Classes;

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
        /// Instance of <see cref="IApplicationContext"/>
        /// </summary>
        public IMapper Mapper;

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
    }
}