using AutoMapper;
using Kingpin.Tier.Entities.Classes;
using Kingpin.Tier.ViewModels.Classes.Views;

namespace Kingpin.Tier.Mappings.Classes
{
    public class ModelingProfile : Profile
    {
        public ModelingProfile()
        {
            CreateMap<ApplicationRole, ViewRole>();

            CreateMap<ApplicationUser, ViewUser>();
        }
    }
}
