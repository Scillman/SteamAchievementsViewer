
namespace SteamKit2X.Managing.Events
{
    /// <summary>
    /// Authentication related event. (log-on, log-off, Steam Guard Code, sentry, etc.)
    /// </summary>
    public class AuthenticationEventArgs : ManagerEventArgs
    {
        /// <summary>
        /// Indicates whether the event was related to security.
        /// </summary>
        public bool Security { get; private set; }

        /// <summary>
        /// Creates a new authentication related event arguments.
        /// </summary>
        /// <param name="msg">The message related to the event.</param>
        /// <param name="security">Indicator whether it is because of security.</param>
        public AuthenticationEventArgs(string msg, bool security = false) :
            base(msg)
        {
            Security = security;
        }
    }
}
