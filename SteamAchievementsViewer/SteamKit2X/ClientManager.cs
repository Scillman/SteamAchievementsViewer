using System;
using System.Windows.Forms;

/*
 * The idea of the SteamKit2X.ClientManager is to
 * make it easier to access certain information.
 * 
 * I for example need the username, password,
 * Steam Guard Code, friends and achievements of
 * all the users (user+friends).
 */

namespace SteamKit2X
{
    /// <summary>
    /// The <see cref="SteamKit2X.ClientManager"/> is a wrapper for easy access.
    /// </summary>
    public partial class ClientManager : IDisposable
    {
        /// <summary>
        /// Creates a new <see cref="SteamKit2X.ClientManager"/> instance.
        /// </summary>
        /// <param name="parent">The form for whom to create the manager.</param>
        /// <param name="username">The username that must used to connect to Steam.</param>
        /// <param name="password">The password that must used to connect to Steam.</param>
        /// <param name="steamGuardCode">The Steam Guard Code that must used to connect to Steam.</param>
        public ClientManager(Control parent, string username, string password, string steamGuardCode = null)
        {
            // Used for Cross-Thread-Safe invokes.
            this.parent = parent;

            // Set the user's information.
            this.Username = username;
            this.Password = password;
            this.SteamGuardCode = steamGuardCode;

            // Initialize the remaining.
            Initialize();
        }

        /// <summary>
        /// Initialize everything inside the class.
        /// </summary>
        private void Initialize()
        {
            InitializeThreadSafety();
            InitializeConnection();
            InitializeUser();
            InitializeAuthentication();
            InitializeFriends();
        }

        /// <summary>
        /// Dispose of all the used resources.
        /// </summary>
        public void Dispose()
        {
            Dispose(true);
            GC.SuppressFinalize(this);
        }

        /// <summary>
        /// Release the used system resources.
        /// </summary>
        /// <param name="disposing">false to release unmanaged resources; true to release all resources.</param>
        protected virtual void Dispose(bool disposing)
        {
            // Release managed resources.
            if (disposing)
            {
                // First log the user off then disconnect from the servers.
                LogOff();
                Disconnect();
            }

            // Release unmanaged resources.
            {
                // Currently there are no unmanaged resources.
            }
        }
    }
}
