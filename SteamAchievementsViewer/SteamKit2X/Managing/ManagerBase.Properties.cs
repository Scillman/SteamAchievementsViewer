using SteamKit2;

/* Properties
 *   This file contains the properties of the manager's base class.
 */
namespace SteamKit2X.Managing
{
    partial class ManagerBase
    {
        /// <summary>
        /// The callback manager of the client.
        /// </summary>
        private CallbackManager callbackManager;

        /// <summary>
        /// Get the <see cref="SteamKit2.SteamClient"/> of the manager.
        /// </summary>
        protected SteamClient steamClient;

        /// <summary>
        /// Get the <see cref="SteamKit2.SteamUser"/> of the manager.
        /// </summary>
        protected SteamUser steamUser;

        /// <summary>
        /// Get the <see cref="SteamKit2.SteamFriends"/> of the manager.
        /// </summary>
        protected SteamFriends steamFriends;
    }
}
