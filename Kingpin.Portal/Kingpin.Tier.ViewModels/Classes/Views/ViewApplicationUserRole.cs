namespace Kingpin.Tier.ViewModels.Classes.Views
{
    public class ViewApplicationUserRole
    {
        public ViewApplicationUserRole()
        {
        }

        public virtual ViewApplicationRole ApplicationRole { get; set; }

        public virtual ViewApplicationUser ApplicationUser { get; set; }
    }
}
