using System;

namespace SteamKit2X.Exceptions
{
    /// <summary>
    /// A Steam Guard Code exception.
    /// </summary>
    public class SteamGuardException : Exception
    {
        /// <summary>
        /// Create a new instance of the <see cref="SteamKit2X.Exceptions.SteamGuardException"/>.
        /// </summary>
        /// <param name="msg">The message that has to be thrown.</param>
        public SteamGuardException(string msg) :
            base(msg)
        {
            // Do something...
        }
    }
}
