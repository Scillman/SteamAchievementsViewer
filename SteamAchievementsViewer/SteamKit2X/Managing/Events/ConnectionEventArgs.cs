
namespace SteamKit2X.Managing.Events
{
    /// <summary>
    /// Connection related event arguments.
    /// </summary>
    public class ConnectionEventArgs : ManagerEventArgs
    {
        /// <summary>
        /// Indicates whether or not the operation was successfull.
        /// </summary>
        public bool Sucessfull { get; private set; }

        /// <summary>
        /// Creates a new empty connection event.
        /// </summary>
        public ConnectionEventArgs() :
            this(true, string.Empty)
        {
            // Do something...
        }

        /// <summary>
        /// Creates a new connection event.
        /// </summary>
        /// <param name="successfull">An indicator whether or not the operation was successfull.</param>
        /// <param name="msg">The message related to the operation.</param>
        public ConnectionEventArgs(bool successfull, string msg) :
            base(msg)
        {
            Sucessfull = successfull;
        }
    }
}
