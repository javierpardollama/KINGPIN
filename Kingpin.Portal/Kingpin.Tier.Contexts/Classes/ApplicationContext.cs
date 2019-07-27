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

            modelBuilder.Entity<ApplicationUserRole>(applicationUserRole =>
            {
                applicationUserRole.ToTable("ApplicationUserRole");

                applicationUserRole.HasOne(x => x.ApplicationUser)
            .WithMany(x => x.ApplicationUserRoles)
            .HasForeignKey(x => x.UserId);

                applicationUserRole.HasOne(x => x.ApplicationRole)
            .WithMany(x => x.ApplicationUserRoles)
            .HasForeignKey(x => x.RoleId);
            });

            modelBuilder.Entity<ApplicationRoleClaim>(applicationRoleClaim =>
            {
                applicationRoleClaim.ToTable("ApplicationRoleClaim");

                applicationRoleClaim.HasOne(x => x.ApplicationRole)
           .WithMany(x => x.ApplicationRoleClaims)
           .HasForeignKey(x => x.RoleId);
            });

            modelBuilder.Entity<ApplicationUserClaim>(applicationUserClaim =>
            {
                applicationUserClaim.ToTable("ApplicationUserClaim");

                applicationUserClaim.HasOne(x => x.ApplicationUser)
         .WithMany(x => x.ApplicationUserClaims)
         .HasForeignKey(x => x.UserId);
            });


            modelBuilder.Entity<ApplicationUserLogin>(applicationUserLogin =>
            {
                applicationUserLogin.ToTable("ApplicationUserLogin");

                applicationUserLogin.HasOne(x => x.ApplicationUser)
      .WithMany(x => x.ApplicationUserLogins)
      .HasForeignKey(x => x.UserId);

            });


            modelBuilder.Entity<ApplicationUserToken>(applicationUserToken =>
            {
                applicationUserToken.ToTable("ApplicationUserToken");

                applicationUserToken.HasOne(x => x.ApplicationUser)
     .WithMany(x => x.ApplicationUserTokens)
     .HasForeignKey(x => x.UserId);
            });

            modelBuilder.Entity<ApplicationUser>(applicationUser =>
            {
                applicationUser.ToTable("ApplicationUser");
            });

            modelBuilder.Entity<ApplicationRole>(applicationRole =>
            {
                applicationRole.ToTable("ApplicationRole");
            });


            // Configure entity filters               
        }
    }
}
