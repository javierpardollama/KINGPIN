﻿using Kingpin.Tier.Entities.Interfaces;
using Microsoft.AspNetCore.Identity;
using System;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Kingpin.Tier.Entities.Classes
{
    public partial class ApplicationUserClaim : IdentityUserClaim<int>, IBase
    {
        [Required]
        public DateTime LastModified { get; set; }

        [Required]
        public bool Deleted { get; set; }        

        [Required]
        [ForeignKey("ApplicationUserId")]
        public virtual ApplicationUser ApplicationUser { get; set; }
    }
}