using System;
using System.ComponentModel.DataAnnotations;

using Kingpin.Tier.Entities.Interfaces;

using Microsoft.AspNetCore.Identity;

namespace Kingpin.Tier.Entities.Classes
{
    public partial class ApplicationUserToken : IdentityUserToken<int>, IBase
    {
        public ApplicationUserToken()
        {
        }

        [Required]
        public DateTime LastModified { get; set; }

        [Required]
        public bool Deleted { get; set; }

        public virtual ApplicationUser ApplicationUser { get; set; }
    }
}
