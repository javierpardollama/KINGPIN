using System.Collections.Generic;
using System.Linq;

namespace Kingpin.Tier.ViewModels.Classes.Views
{
    public class ViewApplicationRole : ViewBase
    {
        public ViewApplicationRole()
        {
        }

        public string Name { get; set; }

        public virtual ICollection<ViewApplicationUserRole> ApplicationUserRoles { get; set; }

        public virtual ICollection<ViewApplicationUser> ApplicationUsers => ApplicationUserRoles?.AsQueryable().Select(x => x.ApplicationUser).ToList();
    }
}
