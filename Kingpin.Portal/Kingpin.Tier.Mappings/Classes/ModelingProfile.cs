using AutoMapper;

using Kingpin.Tier.Entities.Classes;
using Kingpin.Tier.ViewModels.Classes.Views;

namespace Kingpin.Tier.Mappings.Classes
{
    public class ModelingProfile : Profile
    {
        public ModelingProfile()
        {
            CreateMap<ApplicationRole, ViewApplicationRole>();

            CreateMap<ApplicationUser, ViewApplicationUser>();

            CreateMap<ApplicationUserRole, ViewApplicationUserRole>();

            CreateMap<ApplicationUserToken, ViewApplicationUserToken>();
        }
    }
}
