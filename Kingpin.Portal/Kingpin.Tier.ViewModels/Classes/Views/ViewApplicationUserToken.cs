namespace Kingpin.Tier.ViewModels.Classes.Views
{
    public class ViewApplicationUserToken : ViewBase
    {
        public ViewApplicationUserToken()
        {
        }

        public string Value { get; set; }

        public virtual ViewApplicationUser ApplicationUser { get; set; }
    }
}
