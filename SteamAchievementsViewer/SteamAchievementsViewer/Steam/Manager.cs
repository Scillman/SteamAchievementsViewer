using SteamKit2;

namespace SteamAchievementsViewer.Steam
{
    /// <summary>
    /// The manager that manages mayor SteamKit2 entities.
    /// </summary>
    public static class Manager
    {
        /**
         * The Steam client.
         *   This is used to make a connection with the Steam servers.
         */
        private static SteamKit2.SteamClient _steamClient;
        public static SteamKit2.SteamClient SteamClient
        {
            get
            {
                if (_steamClient == null)
                {
                    _steamClient = new SteamKit2.SteamClient();
                }
                return _steamClient;
            }
        }

        /**
         * The callback manager.
         *   The callback manager is used for responses from the steam server/client.
         */
        private static SteamKit2.CallbackManager _callbackManager;
        public static SteamKit2.CallbackManager CallbackManager
        {
            get
            {
                if (_callbackManager == null)
                {
                    _callbackManager = new SteamKit2.CallbackManager(SteamClient);
                }
                return _callbackManager;
            }
        }

        /**
         * The steam user.
         *   This is the actual user.
         */
        private static SteamKit2.SteamUser _steamUser;
        public static SteamKit2.SteamUser SteamUser
        {
            get
            {
                if (_steamUser == null)
                {
                    _steamUser = SteamClient.GetHandler<SteamKit2.SteamUser>();
                }
                return _steamUser;
            }
        }

        /**
         * The steam friends.
         *   The friend of the actual user.
         */
        private static SteamKit2.SteamFriends _steamFriends;
        public static SteamKit2.SteamFriends SteamFriends
        {
            get
            {
                if (_steamFriends == null)
                {
                    _steamFriends = SteamClient.GetHandler<SteamKit2.SteamFriends>();
                }
                return _steamFriends;
            }
        }
    }
}
