using AutoMapper;

using Kingpin.Tier.Entities.Classes;
using Kingpin.Tier.ViewModels.Classes.Views;

namespace Kingpin.Tier.Mappings.Classes
{
    /// <summary>
    /// Represents a <see cref="ModelingProfile"/> class. Inherits <see cref="Profile"/>
    /// </summary>
    public class ModelingProfile : Profile
    {
        /// <summary>
        /// Initializes a new Instance of <see cref="ModelingProfile"/>
        /// </summary>
        public ModelingProfile()
        {
            CreateMap<ApplicationRole, ViewApplicationRole>();

            CreateMap<ApplicationUser, ViewApplicationUser>();

            CreateMap<ApplicationUserRole, ViewApplicationUserRole>();

            CreateMap<ApplicationUserToken, ViewApplicationUserToken>();
        }
    }
}
