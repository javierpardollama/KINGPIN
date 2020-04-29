﻿using System.Collections.Generic;
using System.Threading.Tasks;

using Kingpin.Tier.Entities.Classes;
using Kingpin.Tier.ViewModels.Classes.Updates;
using Kingpin.Tier.ViewModels.Classes.Views;

namespace Kingpin.Tier.Services.Interfaces
{
    /// <summary>
    /// Represents a <see cref="IApplicationUserService"/> interface. Inherits <see cref="IBaseService"/>
    /// </summary>
    public interface IApplicationUserService : IBaseService
    {
        /// <summary>
        /// Finds All Application User
        /// </summary>
        /// <returns>Instance of <see cref="ICollection{ViewApplicationUser}"/></returns>
        Task<ICollection<ViewApplicationUser>> FindAllApplicationUser();

        /// <summary>
        /// Finds Application User By Id
        /// </summary>
        /// <param name="id">Injected <see cref="int"/></param>
        /// <returns>Instance of <see cref="ApplicationUser"/></returns>
        Task<ApplicationUser> FindApplicationUserById(int @id);

        /// <summary>
        /// Removes Application User By Id
        /// </summary>
        /// <param name="id">Injected <see cref="int"/></param>
        /// <returns>Instance of <see cref="Task"/></returns>
        Task RemoveApplicationUserById(int @id);

        /// <summary>
        /// Updates Application User
        /// </summary>
        /// <param name="viewModel">Injected <see cref="UpdateApplicationUser"/></param>
        /// <returns>Instance of <see cref="ViewApplicationUser"/></returns>
        Task<ViewApplicationUser> UpdateApplicationUser(UpdateApplicationUser @viewModel);

        /// <summary>
        /// Updates Application User Role
        /// </summary>
        /// <param name="viewModel">Injected <see cref="UpdateApplicationUser"/></param>
        /// <param name="entity">Injected <see cref="ApplicationUser"/></param>
        void UpdateApplicationUserRole(UpdateApplicationUser @viewModel, ApplicationUser @entity);

        /// <summary>
        /// Finds Application Role By Id
        /// </summary>
        /// <param name="id">Injected <see cref="int"/></param>
        /// <returns>Instance of <see cref="ApplicationRole"/></returns>
        Task<ApplicationRole> FindApplicationRoleById(int @id);
    }
}
