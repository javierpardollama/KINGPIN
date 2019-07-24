using System.Collections.Generic;

namespace Kingpin.Tier.ViewModels.Classes.Updates
{
    public class UpdateApplicationUser : UpdateBase
    {
        public UpdateApplicationUser()
        {
        }

        public virtual ICollection<int> ApplicationRolesId { get; set; }
    }
}
