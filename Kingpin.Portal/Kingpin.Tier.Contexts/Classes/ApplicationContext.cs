using System;
using System.Threading.Tasks;

using Kingpin.Tier.Contexts.Interfaces;
using Kingpin.Tier.Entities.Classes;

using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.ChangeTracking;

namespace Kingpin.Tier.Contexts.Classes
{
    public class ApplicationContext : IdentityDbContext<ApplicationUser, ApplicationRole, int, ApplicationUserClaim, ApplicationUserRole, ApplicationUserLogin, ApplicationRoleClaim, ApplicationUserToken>, IApplicationContext
    {
        public ApplicationContext(DbContextOptions<ApplicationContext> options) : base(options)
        {
        }

        public DbSet<ApplicationRole> ApplicationRole { get; set; }

        public DbSet<ApplicationRoleClaim> ApplicationRoleClaim { get; set; }

        public DbSet<ApplicationUser> ApplicationUser { get; set; }

        public DbSet<ApplicationUserClaim> ApplicationUserClaim { get; set; }

        public DbSet<ApplicationUserLogin> ApplicationUserLogin { get; set; }

        public DbSet<ApplicationUserRole> ApplicationUserRole { get; set; }

        public DbSet<ApplicationUserToken> ApplicationUserToken { get; set; }

        public override int SaveChanges()
        {
            UpdateSoftStatus();
            return base.SaveChanges();
        }

        public async Task<int> SaveChangesAsync()
        {
            UpdateSoftStatus();
            return await base.SaveChangesAsync();
        }

        private void UpdateSoftStatus()
        {
            foreach (EntityEntry entity in ChangeTracker.Entries())
            {
                switch (entity.State)
                {
                    case EntityState.Added:
                        entity.CurrentValues["LastModified"] = DateTime.Now;
                        entity.State = EntityState.Added;
                        entity.CurrentValues["Deleted"] = false;
                        break;

                    case EntityState.Modified:
                        entity.CurrentValues["LastModified"] = DateTime.Now;
                        entity.State = EntityState.Modified;
                        entity.CurrentValues["Deleted"] = false;
                        break;

                    case EntityState.Deleted:
                        entity.CurrentValues["LastModified"] = DateTime.Now;
                        entity.State = EntityState.Modified;
                        entity.CurrentValues["Deleted"] = true;
                        break;
                }
            }
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);

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
