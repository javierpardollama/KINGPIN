using System.Collections.Generic;

using Kingpin.Tier.Entities.Interfaces;

using Microsoft.AspNetCore.Identity;

namespace Kingpin.Tier.Entities.Classes
{
    public partial class ApplicationUser : IdentityUser<int>, IKey
    {
        public ApplicationUser()
        {
        }

        public virtual ICollection<ApplicationUserRole> ApplicationUserRoles { get; set; }

        public virtual ICollection<ApplicationUserClaim> ApplicationUserClaims { get; set; }

        public virtual ICollection<ApplicationUserLogin> ApplicationUserLogins { get; set; }

        public virtual ICollection<ApplicationUserToken> ApplicationUserTokens { get; set; }
    }
}
