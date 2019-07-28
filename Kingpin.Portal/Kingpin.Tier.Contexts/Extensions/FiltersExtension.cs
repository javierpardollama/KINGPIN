using Kingpin.Tier.Entities.Classes;

using Microsoft.EntityFrameworkCore;

namespace Kingpin.Tier.Contexts.Extensions
{
    public static class FiltersExtension
    {
        public static void AddCustomizedFilters(this ModelBuilder modelBuilder)
        {
            // Configure entity filters      
            modelBuilder.Entity<ApplicationRole>().HasQueryFilter(p => !p.Deleted);
            modelBuilder.Entity<ApplicationRoleClaim>().HasQueryFilter(p => !p.Deleted);
            modelBuilder.Entity<ApplicationUser>().HasQueryFilter(p => !p.Deleted);
            modelBuilder.Entity<ApplicationUserClaim>().HasQueryFilter(p => !p.Deleted);
            modelBuilder.Entity<ApplicationUserLogin>().HasQueryFilter(p => !p.Deleted);
            modelBuilder.Entity<ApplicationUserRole>().HasQueryFilter(p => !p.Deleted);
            modelBuilder.Entity<ApplicationUserToken>().HasQueryFilter(p => !p.Deleted);           
        }
    }
}
