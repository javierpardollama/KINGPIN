using Kingpin.Tier.Entities.Interfaces;
using Microsoft.AspNetCore.Identity;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace Kingpin.Tier.Entities.Classes
{
    public partial class ApplicationRole : IdentityRole<int>, IBase
    {
        [Required]
        public DateTime LastModified { get; set; }

        [Required]
        public bool Deleted { get; set; }

        public virtual ICollection<ApplicationUserRole> ApplicationUserRoles { get; set; }

        public virtual ICollection<ApplicationRoleClaim> ApplicationRoleClaims { get; set; }
    }
}
