namespace Kingpin.Tier.ViewModels.Classes.Views
{
    public class ViewApplicationUserToken : ViewBase
    {
        public ViewApplicationUserToken()
        {
        }

        public string Value { get; set; }

        public virtual ViewApplicationUser User { get; set; }
    }
}
