using System.ComponentModel.DataAnnotations.Schema;

using Microsoft.AspNetCore.Identity;

namespace Kingpin.Tier.Entities.Classes
{
    [Table("ApplicationUserRole")]
    public partial class ApplicationUserRole : IdentityUserRole<int>
    {
        public ApplicationUserRole()
        {
        }

        public virtual ApplicationRole ApplicationRole { get; set; }

        public virtual ApplicationUser ApplicationUser { get; set; }
    }
}
