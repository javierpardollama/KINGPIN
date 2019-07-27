using System;
using System.ComponentModel.DataAnnotations;

using Kingpin.Tier.Entities.Interfaces;

namespace Kingpin.Tier.Entities.Classes
{
    public abstract class Base : Key, IBase
    {
        [Required]
        public DateTime LastModified { get; set; }

        [Required]
        public bool Deleted { get; set; }
    }
}
