using System;
using System.ComponentModel.DataAnnotations;

namespace Kingpin.Tier.Entities.Interfaces
{
    public interface IBase
    {
        [Required]
        DateTime LastModified { get; set; }

        [Required]
        bool Deleted { get; set; }
    }
}
