using SteamKit2X.Users;
using System.Collections.Generic;

/* Properties
 *   The properties in this file are made thread-safe.
 */

namespace SteamKit2X
{
    partial class ClientManager
    {
        /// <summary>
        /// Get the username that is used to connect to Steam.
        /// </summary>
        public string Username
        {
            get
            {
                // Store the username locally to prevent long term blocking.
                string username;

                // Lock the username so we are sure it isn't being changed.
                lock (_usernameLock)
                {
                    username = _username;
                }

                // Return the username.
                return username;
            }
            private set
            {
                lock (_usernameLock)
                {
                    _username = value;
                }
            }
        }
        private string _username;
        private object _usernameLock = new object();

        /// <summary>
        /// Get the password that is used to connect to Steam.
        /// </summary>
        public string Password
        {
            get
            {
                // Store the password locally to prevent long term blocking.
                string password;

                // Lock the password so we are sure it isn't being changed.
                lock (_passwordLock)
                {
                    password = _password;
                }

                // Return the password.
                return password;
            }
            private set
            {
                lock (_passwordLock)
                {
                    _password = value;
                }
            }
        }
        private string _password;
        private object _passwordLock = new object();

        /// <summary>
        /// Get or set the Steam Guard Code that is used to connect to Steam.
        /// </summary>
        public string SteamGuardCode
        {
            get
            {
                // Store the Steam Guard Code locally to prevent long term blocking.
                string steamGuardCode;

                // Lock the Steam Guard Code so we are sure it isn't being changed.
                lock (_steamGuardCodeLock)
                {
                    steamGuardCode = _steamGuardCode;
                }

                // Return the Steam Guard Code.
                return steamGuardCode;
            }
            set
            {
                lock (_steamGuardCodeLock)
                {
                    _steamGuardCode = value;
                }
            }
        }
        private string _steamGuardCode;
        private object _steamGuardCodeLock = new object();

        /// <summary>
        /// Get the friends of the user.
        /// </summary>
        public List<User> Friends
        {
            get
            {
                // Store the friends locally to prevent long term blocking.
                List<User> friends;

                // Lock the friends so we are sure it isn't being changed.
                lock (_friendsLock)
                {
                    friends = _friends;
                }

                // Return the Steam Guard Code.
                return friends;
            }
            private set
            {
                lock (_friendsLock)
                {
                    _friends = value;
                }
            }
        }
        private List<User> _friends;
        private object _friendsLock = new object();
    }
}
