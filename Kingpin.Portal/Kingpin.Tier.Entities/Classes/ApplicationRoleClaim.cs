﻿
using System;
using System.ComponentModel.DataAnnotations;

using Kingpin.Tier.Entities.Interfaces;

using Microsoft.AspNetCore.Identity;

namespace Kingpin.Tier.Entities.Classes
{
    public partial class ApplicationRoleClaim : IdentityRoleClaim<int>, IKey, IBase
    {
        public ApplicationRoleClaim()
        {
        }

        [Required]
        public DateTime LastModified { get; set; }

        [Required]
        public bool Deleted { get; set; }

        public virtual ApplicationRole ApplicationRole { get; set; }
    }
}
