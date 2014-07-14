using System;

namespace SteamKit2X
{
    /// <summary>
    /// Creates a new Steam client. (W.I.P.)
    /// </summary>
    public partial class SteamClient : IDisposable
    {
        /// <summary>
        /// The username that is used to connect to Steam.
        /// </summary>
        public string Username { get; private set; }

        /// <summary>
        /// The password that is used to connect to Steam.
        /// </summary>
        public string Password { get; private set; }

        /// <summary>
        /// The Steam Guard Code that is used to connect to Steam.
        /// </summary>
        public string SteamGuardCode { get; set; }

        /// <summary>
        /// Creates a new Steam client instance.
        /// </summary>
        public SteamClient()
        {
            Initialize();
        }

        /// <summary>
        /// Creates a new Steam client instance.
        /// </summary>
        /// <param name="username">The username that must used to connect to Steam.</param>
        /// <param name="password">The password that must used to connect to Steam.</param>
        /// <param name="steamGuardCode">The Steam Guard Code that must used to connect to Steam.</param>
        public SteamClient(string username, string password, string steamGuardCode = null)
        {
            this.Username = username;
            this.Password = password;
            this.SteamGuardCode = steamGuardCode;
            Initialize();
        }

        /// <summary>
        /// Initialize everything inside the class.
        /// </summary>
        private void Initialize()
        {
            InitializeConnection();
            InitializeUser();
            InitializeAuthentication();
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

            }
        }
    }
}
