using SteamKit2X.Users;
using System.Collections.Generic;

namespace SteamKit2X.Managing
{
    /// <summary>
    /// A collection of user objects.
    /// </summary>
    public class UserCollection : List<User>
    {
        /// <summary>
        /// Creates a new instance of <see cref="SteamKit2X.Managing.UserCollection"/>.
        /// </summary>
        public UserCollection()
        {
            // Do something...
        }

        /// <summary>
        /// Update the user with the given ID.
        /// </summary>
        /// <param name="steamID">The Steam ID of the user.</param>
        /// <param name="name">The name of the user.</param>
        internal void Update(ulong steamID, string name)
        {
            for (int i = 0; i < Count; i++)
            {
                // Get the user from the list.
                var user = this[i];

                // Compare the user.
                if (user.SteamID == steamID)
                {
                    // Update the user.
                    user.Name = name;
                    this[i] = user;
                    break;
                }
            }
        }
    }
}
