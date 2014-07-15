using System;

/* PROPERTIES
 *   This file contains all the properties
 *   that are cross-thread accessible.
 */
namespace SteamKit2X.Managing
{
    partial class SteamManager
    {
        /// <summary>
        /// Get the username of the user.
        /// </summary>
        public string Username { get; private set; }

        /// <summary>
        /// Get the password of the user.
        /// </summary>
        public string Password { get; private set; }

        /// <summary>
        /// Get the Steam Guard Code of the user.
        /// </summary>
        public string SteamGuardCode { get; private set; }

        /// <summary>
        /// Get the friends of the client.
        /// </summary>
        /// <exception cref="System.ObjectDisposedException"/>
        /// <remarks>Cross-Thread</remarks>
        public UserCollection Friends
        {
            get
            {
                // Throw an exception when the object has been disposed.
                if (Disposed)
                    throw new ObjectDisposedException("The Friends has been disposed.");

                // Lock the object so it is not modified while accessing it.
                lock (_friendsLock)
                {
                    return _friends;
                }
            }
            private set
            {
                // Lock the object so it is not modified while accessing it.
                lock (_friendsLock)
                {
                    _friends = value;
                }
            }
        }
        private UserCollection _friends; // The actual friends object.
        private object _friendsLock = new object(); // The lock used to access the object cross-thread.
    }
}
