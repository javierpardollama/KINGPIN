using System;

using Kingpin.Tier.ViewModels.Interfaces.Views;

namespace Kingpin.Tier.ViewModels.Classes.Views
{
    public class ViewApplicationUserToken : IViewBase
    {
        public ViewApplicationUserToken()
        {
        }

        public DateTime LastModified { get; set; }

        public string Value { get; set; }

        public virtual ViewApplicationUser ApplicationUser { get; set; }
    }
}
