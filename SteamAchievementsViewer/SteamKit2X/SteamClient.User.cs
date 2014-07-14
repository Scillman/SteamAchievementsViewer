using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using SteamKit2;
using LoggedOnCallback = SteamKit2.SteamUser.LoggedOnCallback;
using LoggedOffCallback = SteamKit2.SteamUser.LoggedOffCallback;

namespace SteamKit2X
{
    partial class SteamClient
    {
        /// <summary>
        /// The Steam user attached to this client.
        /// </summary>
        public SteamUser SteamUser { get; private set; }

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
        public void LogOn()
        {
            SteamUser.LogOn(new SteamUser.LogOnDetails
            {
                // User credentials
                Username = this.Username,
                Password = this.Password,

                // Steam Guard Code
                AuthCode = SteamGuardCode,

                SentryFileHash = GetSentryHash()
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
        protected virtual void OnLoggedOn(LoggedOnCallback callback)
        {
            if (callback.Result == EResult.AccountLogonDenied)
            {
                //
            }

            if (callback.Result == EResult.OK)
            {
                LoggedOn();
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
            if (callback.Result == EResult.OK)
            {
                LoggedOff();
            }
        }
    }
}
