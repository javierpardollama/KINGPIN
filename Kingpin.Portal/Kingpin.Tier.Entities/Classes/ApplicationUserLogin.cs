
using Microsoft.AspNetCore.Identity;

namespace Kingpin.Tier.Entities.Classes
{
    public partial class ApplicationUserLogin : IdentityUserLogin<int>
    {
        public ApplicationUserLogin()
        {
        }

        public virtual ApplicationUser ApplicationUser { get; set; }
    }
}
