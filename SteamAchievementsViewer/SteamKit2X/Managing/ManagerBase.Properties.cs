using SteamKit2;
using System;

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
        private CallbackManager CallbackManager { get; set; }

        /// <summary>
        /// Get the <see cref="SteamKit2.SteamClient"/> of the manager.
        /// </summary>
        /// <exception cref="System.ObjectDisposedException"/>
        protected SteamClient SteamClient
        {
            get
            {
                // Throw an exception when the object has been disposed.
                if (Disposed)
                    throw new ObjectDisposedException("The SteamClient has been disposed.");

                lock (_steamClientLock)
                {
                    return _steamClient;
                }
            }
            private set
            {
                // Throw an exception when the object has been disposed.
                if (Disposed)
                    throw new ObjectDisposedException("The SteamClient has been disposed.");

                lock (_steamClientLock)
                {
                    _steamClient = value;
                }
            }
        }
        private SteamClient _steamClient;
        private object _steamClientLock = new object();

        /// <summary>
        /// Get the <see cref="SteamKit2.SteamUser"/> of the manager.
        /// </summary>
        /// <exception cref="System.ObjectDisposedException"/>
        protected SteamUser SteamUser
        {
            get
            {
                // Throw an exception when the object has been disposed.
                if (Disposed)
                    throw new ObjectDisposedException("The SteamUser has been disposed.");

                lock (_steamUserLock)
                {
                    return _steamUser;
                }
            }
            set
            {
                // Throw an exception when the object has been disposed.
                if (Disposed)
                    throw new ObjectDisposedException("The SteamUser has been disposed.");

                lock (_steamUserLock)
                {
                    _steamUser = value;
                }
            }
        }
        private SteamUser _steamUser;
        private object _steamUserLock = new object();

        /// <summary>
        /// Get the <see cref="SteamKit2.SteamFriends"/> of the manager.
        /// </summary>
        /// <exception cref="System.ObjectDisposedException"/>
        protected SteamFriends SteamFriends
        {
            get
            {
                // Throw an exception when the object has been disposed.
                if (Disposed)
                    throw new ObjectDisposedException("The SteamFriends has been disposed.");

                lock (_steamFriendsLock)
                {
                    return _steamFriends;
                }
            }
            set
            {
                // Throw an exception when the object has been disposed.
                if (Disposed)
                    throw new ObjectDisposedException("The SteamFriends has been disposed.");

                lock (_steamFriendsLock)
                {
                    _steamFriends = value;
                }
            }
        }
        private SteamFriends _steamFriends;
        private object _steamFriendsLock = new object();
    }
}
