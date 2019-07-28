using Kingpin.Tier.Entities.Classes;

using Microsoft.EntityFrameworkCore;

namespace Kingpin.Tier.Contexts.Extensions
{
    public static class IdentitiesExtension
    {
        public static void AddCustomizedIdentities(this ModelBuilder modelBuilder)
        {
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
        }
    }
}
