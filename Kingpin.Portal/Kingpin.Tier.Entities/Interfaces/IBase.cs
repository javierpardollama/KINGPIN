using System;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Kingpin.Tier.Entities.Interfaces
{
    public interface IBase
    {
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        [Required]
        int Id { get; set; }

        [Required]
        DateTime LastModified { get; set; }

        [Required]
        bool Deleted { get; set; }
    }
}
