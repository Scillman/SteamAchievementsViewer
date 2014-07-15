using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SteamKit2X.Managing.Events
{
    /// <summary>
    /// An event related to Steam friends.
    /// </summary>
    public class FriendsEventArgs : ManagerEventArgs
    {
        /// <summary>
        /// Indicates whether only a single user was altered or multiple users.
        /// </summary>
        public bool SingleUser { get; private set; }

        /// <summary>
        /// If <see cref="SingleUser"/> is set to true, this will contain the Steam ID of the user.
        /// </summary>
        public ulong SteamID { get; private set; }

        /// <summary>
        /// Creates a new friends related event.
        /// </summary>
        /// <param name="singleUser">Indicates whether one or more users have been altered.</param>
        /// <param name="msg">The message related to the event.</param>
        /// <param name="steamID">The Steam ID of the single user.</param>
        public FriendsEventArgs(bool singleUser, string msg, ulong steamID = ((ulong)(0xFFFFFFFFFFFFFFFF))) :
            base(msg)
        {
            SingleUser = singleUser;
            SteamID = steamID;
        }
    }
}
