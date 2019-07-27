using Kingpin.Tier.Entities.Interfaces;

using Microsoft.AspNetCore.Identity;

namespace Kingpin.Tier.Entities.Classes
{
    public partial class ApplicationUserClaim : IdentityUserClaim<int>, IKey
    {
        public ApplicationUserClaim()
        {
        }

        public virtual ApplicationUser ApplicationUser { get; set; }
    }
}
