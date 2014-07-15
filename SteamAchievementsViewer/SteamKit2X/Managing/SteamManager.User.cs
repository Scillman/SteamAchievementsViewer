using SteamKit2;
using SteamKit2X.Exceptions;
using System;
using LoggedOffCallback = SteamKit2.SteamUser.LoggedOffCallback;
using LoggedOnCallback = SteamKit2.SteamUser.LoggedOnCallback;

/* USER
 *   This file does the user log-on and log-off.
 */
namespace SteamKit2X.Managing
{
    partial class SteamManager
    {
        /// <summary>
        /// Initialize the user part.
        /// </summary>
        private void InitializeUser()
        {
            Connected += SteamManager_Connected;
        }

        /// <summary>
        /// Called when we have succesfully connected to the Steam network.
        /// </summary>
        /// <param name="obj"></param>
        private void SteamManager_Connected(EventArgs obj)
        {
            SteamUser.LogOn(new SteamUser.LogOnDetails
            {
                // User credentials
                Username = this.Username,
                Password = this.Password,

                // Steam Guard Code
                AuthCode = this.SteamGuardCode,

                // Machine's sentry file
                SentryFileHash = GetSentryHash()
            });
        }

        /// <summary>
        /// Called when an user has logged on to the Steam network.
        /// </summary>
        /// <param name="callback"></param>
        protected override void OnLoggedOn(LoggedOnCallback callback)
        {
            // Raise the Steam Guard Code event when we need the Steam Guard Code.
            if (callback.Result == EResult.AccountLogonDenied)
                InvokeEvent(RequestsSteamGuardCode);

            // Raise the logged on event when successfully logged on.
            if (callback.Result == EResult.OK)
                InvokeEvent(LoggedOn);
        }

        /// <summary>
        /// Called when an user has logged off the Steam network.
        /// </summary>
        /// <param name="callback"></param>
        protected override void OnLoggedOff(LoggedOffCallback callback)
        {
            // Raise the logged off event when successfully logged off.
            if (callback.Result == EResult.OK)
                InvokeEvent(LoggedOff);
        }

        /// <summary>
        /// Log on with the given user credentials.
        /// </summary>
        /// <param name="username">The username of the user.</param>
        /// <param name="password">The password of the user.</param>
        /// <param name="steamGuardCode">The Steam Guard Code of the user.</param>
        /// <exception cref="System.ObjectDisposedException"/>
        /// <exception cref="SteamKit2X.Exceptions.ManagerRunningException"/>
        public void LogOn(string username, string password, string steamGuardCode = null)
        {
            // Throw an exception when the manager is still running.
            if (IsRunning)
                throw new ManagerRunningException("The manager thread is still running.");

            // Store the user credentials.
            Username = username;
            Password = password;
            SteamGuardCode = steamGuardCode;

            // Start logging on.
            Start();
        }

        /// <summary>
        /// Log the user off.
        /// </summary>
        /// <exception cref="System.ObjectDisposedException"/>
        public void LogOff()
        {
            // Disconnect by ending the callback loop.
            // This will make the user log off automatically.
            IsRunning = false;
        }

        /// <summary>
        /// Called when the user's account/machine has to be authenticated with the Steam Guard Code.
        /// </summary>
        public event Action<EventArgs> RequestsSteamGuardCode;


        /// <summary>
        /// Raised when the user has logged on.
        /// </summary>
        public event Action<EventArgs> LoggedOn;

        /// <summary>
        /// Raised when the user has logged off.
        /// </summary>
        public event Action<EventArgs> LoggedOff;
    }
}
