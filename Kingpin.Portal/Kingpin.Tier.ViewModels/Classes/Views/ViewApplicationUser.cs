using System.Collections.Generic;
using System.Linq;

namespace Kingpin.Tier.ViewModels.Classes.Views
{
    public class ViewApplicationUser : ViewKey
    {
        public ViewApplicationUser()
        {
        }

        public string Email { get; set; }

        public virtual ICollection<ViewApplicationUserRole> ApplicationUserRoles { get; set; }

        public virtual ICollection<ViewApplicationRole> ApplicationRoles => ApplicationUserRoles?.AsQueryable().Select(x => x.ApplicationRole).ToList();

        public virtual ICollection<ViewApplicationUserToken> ApplicationUserTokens { get; set; }


        public virtual ViewApplicationUserToken ApplicationUserToken => ApplicationUserTokens?.AsQueryable().LastOrDefault();
    }
}
