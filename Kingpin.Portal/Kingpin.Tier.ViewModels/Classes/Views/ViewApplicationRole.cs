using System;
using System.Collections.Generic;
using System.Linq;

using Kingpin.Tier.ViewModels.Interfaces.Views;

namespace Kingpin.Tier.ViewModels.Classes.Views
{
    public class ViewApplicationRole : IViewKey, IViewBase
    {
        public ViewApplicationRole()
        {
        }

        public int Id { get; set; }

        public DateTime LastModified { get; set; }

        public string Name { get; set; }

        public string ImageUri { get; set; }

        public virtual ICollection<ViewApplicationUserRole> ApplicationUserRoles { get; set; }

        public virtual ICollection<ViewApplicationUser> ApplicationUsers => ApplicationUserRoles?.AsQueryable().Select(x => x.ApplicationUser).ToList();
    }
}
