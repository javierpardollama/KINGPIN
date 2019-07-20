using System;

using Kingpin.Tier.Contexts.Classes;

using Microsoft.AspNetCore;
using Microsoft.AspNetCore.Hosting;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.DependencyInjection;

namespace Kingpin.Tier.Web
{
    public class Program
    {
        public static void Main(string[] args)
        {
            IWebHost host = BuildWebHost(args);

            ApplyWebHostMigrations(host.Services);

            host.Run();
        }

        public static IWebHost BuildWebHost(string[] args) => WebHost.CreateDefaultBuilder(args).UseStartup<Startup>().Build();

        public static void ApplyWebHostMigrations(IServiceProvider serviceProvider)
        {
            using (IServiceScope serviceScope = serviceProvider.CreateScope())
            {
                IServiceProvider scopeServiceProvider = serviceScope.ServiceProvider;

                using (ApplicationContext applicationContext = scopeServiceProvider.GetService<ApplicationContext>())
                {
                    applicationContext.Database.Migrate();
                }
            }
        }
    }
}
