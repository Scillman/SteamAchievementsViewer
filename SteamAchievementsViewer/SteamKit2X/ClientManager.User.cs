using SteamKit2;
using SteamKit2X.Exceptions;
using System;
using LoggedOffCallback = SteamKit2.SteamUser.LoggedOffCallback;
using LoggedOnCallback = SteamKit2.SteamUser.LoggedOnCallback;

namespace SteamKit2X
{
    partial class ClientManager
    {
        /// <summary>
        /// The Steam user attached to this client.
        /// </summary>
        private SteamUser SteamUser { get; set; }

        /// <summary>
        /// Initialize the Steam user.
        /// </summary>
        private void InitializeUser()
        {
            SteamUser = client.GetHandler<SteamUser>();

            // Register the user related callbacks.
            manager.Register(new Callback<LoggedOnCallback>(OnLoggedOn));
            manager.Register(new Callback<LoggedOffCallback>(OnLoggedOff));
        }

        /// <summary>
        /// Called when the user has to logon.
        /// </summary>
        /// <exception cref="SteamKit2X.Exceptions.SteamGuardException"/>
        public void LogOn()
        {
            SteamUser.LogOn(new SteamUser.LogOnDetails
            {
                // User credentials
                Username = this.Username,
                Password = this.Password,

                // Steam Guard Code
                AuthCode = SteamGuardCode,

                SentryFileHash = null //GetSentryHash()
            });
        }

        /// <summary>
        /// Raised when the user has succesfully logged on.
        /// </summary>
        public event Action LoggedOn;

        /// <summary>
        /// Called when the user has logged on.
        /// </summary>
        /// <param name="callback"></param>
        /// <exception cref="SteamKit2X.Exceptions.SteamGuardException"/>
        protected virtual void OnLoggedOn(LoggedOnCallback callback)
        {
            // Throw a new SteamGuardException because we do not have the user's SteamGuardCode.
            if (callback.Result == EResult.AccountLogonDenied)
                return; // throw new SteamGuardException("Steam Guard Code is required!");

            // When we have logged on successfully we raise the LoggedOn event.
            if (callback.Result == EResult.OK)
            {
                // Raise the event when there are listeners.
                if (LoggedOn != null)
                    Invoke(LoggedOn);
            }
        }

        /// <summary>
        /// Log the user off.
        /// </summary>
        public void LogOff()
        {
            SteamUser.LogOff();
        }

        /// <summary>
        /// Raised when the user has successfully logged off.
        /// </summary>
        public event Action LoggedOff;

        /// <summary>
        /// Called when the user has logged off.
        /// </summary>
        /// <param name="callback"></param>
        protected virtual void OnLoggedOff(LoggedOffCallback callback)
        {
            // Only continue when logged off successfully.
            if (callback.Result == EResult.OK)
            {
                // Raise the LoggedOff event when we have successfully logged off.
                if (LoggedOff != null)
                    Invoke(LoggedOff);
            }
        }
    }
}
