using System.Collections.Generic;

using Kingpin.Tier.Entities.Interfaces;

using Microsoft.AspNetCore.Identity;

namespace Kingpin.Tier.Entities.Classes
{
    public partial class ApplicationRole : IdentityRole<int>, IKey
    {
        public ApplicationRole()
        {
        }

        public virtual ICollection<ApplicationUserRole> ApplicationUserRoles { get; set; }

        public virtual ICollection<ApplicationRoleClaim> ApplicationRoleClaims { get; set; }
    }
}
