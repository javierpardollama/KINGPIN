using System.Threading.Tasks;

using Kingpin.Tier.Entities.Classes;
using Kingpin.Tier.ViewModels.Classes.Auth;
using Kingpin.Tier.ViewModels.Classes.Views;

namespace Kingpin.Tier.Services.Interfaces
{
    /// <summary>
    /// Represents a <see cref="IAuthService"/> interface. Inherits <see cref="IBaseService"/>
    /// </summary>
    public interface IAuthService : IBaseService
    {
        /// <summary>
        /// Signs In
        /// </summary>
        /// <param name="viewModel">Injected <see cref="AuthSignIn"/></param>
        /// <returns>Instance of <see cref="Task{ViewApplicationUser}"/></returns>
        Task<ViewApplicationUser> SignIn(AuthSignIn @viewModel);

        /// <summary>
        /// Signs In
        /// </summary>
        /// <param name="viewModel">Injected <see cref="AuthJoinIn"/></param>
        /// <returns>Instance of <see cref="Task{ViewApplicationUser}"/></returns>
        Task<ViewApplicationUser> SignIn(AuthJoinIn @viewModel);

        /// <summary>
        /// Joins In
        /// </summary>
        /// <param name="viewModel">Injected <see cref="AuthJoinIn"/></param>
        /// <returns>Instance of <see cref="Task{ViewApplicationUser}"/></returns>
        Task<ViewApplicationUser> JoinIn(AuthJoinIn @viewModel);

        /// <summary>
        /// Finds Application User By Email
        /// </summary>
        /// <param name="email">Injected <see cref="string"/></param>
        /// <returns>Instance of <see cref="Task{ApplicationUser}"/></returns>
        Task<ApplicationUser> FindApplicationUserByEmail(string @email);

        /// <summary>
        /// Checks Email
        /// </summary>
        /// <param name="viewModel">Injected <see cref="AuthJoinIn"/></param>
        /// <returns>Instance of <see cref="Task{ApplicationUser}"/></returns>
        Task<ApplicationUser> CheckEmail(AuthJoinIn @viewModel);
    }
}
