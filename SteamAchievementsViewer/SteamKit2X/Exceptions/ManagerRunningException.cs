using System;

namespace SteamKit2X.Exceptions
{
    /// <summary>
    /// An exception indicating that the manager thread is already running.
    /// </summary>
    public class ManagerRunningException : Exception
    {
        /// <summary>
        /// Creates a new instance of <see cref="SteamKit2X.Exceptions.ManagerRunningException"/>
        /// </summary>
        /// <param name="msg">The message of the exception.</param>
        public ManagerRunningException(string msg) :
            base(msg)
        {
            // Do something...
        }
    }
}
