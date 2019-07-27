
using Kingpin.Tier.Entities.Interfaces;

using Microsoft.AspNetCore.Identity;

namespace Kingpin.Tier.Entities.Classes
{
    public partial class ApplicationRoleClaim : IdentityRoleClaim<int>, IKey
    {
        public ApplicationRoleClaim()
        {
        }

        public virtual ApplicationRole ApplicationRole { get; set; }
    }
}
