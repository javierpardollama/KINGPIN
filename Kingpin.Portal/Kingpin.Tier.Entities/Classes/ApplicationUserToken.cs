using System.ComponentModel.DataAnnotations.Schema;

using Microsoft.AspNetCore.Identity;

namespace Kingpin.Tier.Entities.Classes
{
    [Table("ApplicationUserToken")]
    public partial class ApplicationUserToken : IdentityUserToken<int>
    {
        public ApplicationUserToken()
        {
        }

        public virtual ApplicationUser ApplicationUser { get; set; }
    }
}
