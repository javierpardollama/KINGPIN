using System.Collections.Generic;
using System.Linq;

namespace Kingpin.Tier.ViewModels.Classes.Views
{
    public class ViewApplicationRole : ViewBase
    {
        public string Name { get; set; }

        public virtual ICollection<ViewApplicationUserRole> ApplicationUserRoles { get; set; }

        public virtual ICollection<ViewApplicationUser> ApplicationUsers
        {
            get
            {
                return this.ApplicationUserRoles?.AsQueryable().Select(x => x.ApplicationUser).ToList();
            }
        }
    }
}
