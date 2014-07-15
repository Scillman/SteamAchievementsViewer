using SteamKit2;

namespace SteamKit2X.Users
{
    /// <summary>
    /// A steam user.
    /// </summary>
    public class User
    {
        /// <summary>
        /// Get the steamd id of the user.
        /// </summary>
        public ulong SteamID { get; private set; }

        /// <summary>
        /// Get the name of the user.
        /// </summary>
        public string Name { get; internal set; }

        /// <summary>
        /// Creates a new user instance.
        /// </summary>
        /// <param name="steamID">The SteamID of the user.</param>
        /// <param name="name">The name of the user.</param>
        public User(ulong steamID, string name = "[unknown]")
        {
            this.SteamID = steamID;
            this.Name = name;
        }
    }
}
