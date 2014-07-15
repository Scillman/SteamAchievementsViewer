using System;

namespace SteamKit2X.Managing.Events
{
    /// <summary>
    /// The base class for all the manager related events.
    /// </summary>
    public abstract class ManagerEventArgs : EventArgs
    {
        /// <summary>
        /// The message of the event.
        /// </summary>
        public string Message { get; private set; }

        /// <summary>
        /// Creates a new <see cref="SteamKit2X.Managing.Events.ManagerEventArgs"/> instance.
        /// </summary>
        /// <param name="msg">The message bound to the event.</param>
        public ManagerEventArgs(string msg)
        {
            Message = msg;
        }
    }
}
