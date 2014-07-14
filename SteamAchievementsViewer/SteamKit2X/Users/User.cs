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
        public SteamID SteamID { get; private set; }

        /// <summary>
        /// Get the name of the user.
        /// </summary>
        public string Name { get; private set; }

        /// <summary>
        /// Creates a new user instance.
        /// </summary>
        /// <param name="steamId"></param>
        /// <param name="name"></param>
        public User(SteamID steamId, string name)
        {
            this.SteamID = steamId;
            this.Name = name;
        }
    }
}
