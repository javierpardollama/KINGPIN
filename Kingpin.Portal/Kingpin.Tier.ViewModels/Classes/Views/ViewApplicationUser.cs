using System.Collections.Generic;
using System.Linq;

namespace Kingpin.Tier.ViewModels.Classes.Views
{
    public class ViewApplicationUser : ViewBase
    {
        public string Email { get; set; }

        public virtual ICollection<ViewApplicationUserRole> ApplicationUserRoles { get; set; }

        public virtual ICollection<ViewApplicationRole> ApplicationRoles
        {
            get
            {
                return this.ApplicationUserRoles?.AsQueryable().Select(x => x.ApplicationRole).ToList();
            }
        }
    }
}
