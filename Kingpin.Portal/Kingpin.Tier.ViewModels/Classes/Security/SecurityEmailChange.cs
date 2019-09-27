using Kingpin.Tier.ViewModels.Classes.Views;

namespace Kingpin.Tier.ViewModels.Classes.Security
{
    public class SecurityEmailChange
    {
        public SecurityEmailChange()
        {
        }

        public virtual ViewApplicationUser ApplicationUser { get; set; }

        public string NewEmail { get; set; }
    }
}
