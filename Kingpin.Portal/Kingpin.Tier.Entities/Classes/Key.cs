using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

using Kingpin.Tier.Entities.Interfaces;

namespace Kingpin.Tier.Entities.Classes
{
    public abstract class Key : IKey
    {
        [Required]
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int Id { get; set; }
    }
}
