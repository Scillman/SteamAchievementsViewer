using SteamKit2;

namespace SteamKit2X2.Internal.SteamAPI
{
    internal sealed class IPlayerService
    {
        /// <summary>
        /// Gets information about a player's recently played games
        /// </summary>
        /// <param name="key">Access key</param>
        /// <param name="steamid">The player we're asking about</param>
        /// <param name="count">The number of games to return (0/unset: all)</param>
        public void GetRecentlyPlayedGames(string key, ulong steamid, uint count)
        {
            using (dynamic data = WebAPI.GetInterface("IPlayerService", API.AppKey))
            {
                KeyValue items = data.GetRecentlyPlayedGames(key: key, steamid: steamid, count: count, l: "english");
            }
        }

        /// <summary>
        /// Return a list of games owned by the player
        /// </summary>
        /// <param name="key">Access key</param>
        /// <param name="steamid">The player we're asking about</param>
        /// <param name="include_appinfo">true if we want additional details (name, icon) about each game</param>
        /// <param name="include_played_free_games">Free games are excluded by default.  If this is set, free games the user has played will be returned.</param>
        /// <param name="appids_filter">if set, restricts result set to the passed in apps</param>
        public void GetOwnedGames(string key, ulong steamid, bool include_appinfo, bool include_played_free_games, uint appids_filter)
        {
            using (dynamic data = WebAPI.GetInterface("IPlayerService", API.AppKey))
            {
                KeyValue items = data.GetOwnedGames(key: key, steamid: steamid, include_appinfo: include_appinfo, include_played_free_games: include_played_free_games, appids_filter: appids_filter, l: "english");
            }
        }

        /// <summary>
        /// Returns the Steam Level of a user
        /// </summary>
        /// <param name="key">Access key</param>
        /// <param name="steamid">The player we're asking about</param>
        public void GetSteamLevel(string key, ulong steamid)
        {
            using (dynamic data = WebAPI.GetInterface("IPlayerService", API.AppKey))
            {
                KeyValue items = data.GetSteamLevel(key: key, steamid: steamid, l: "english");
            }
        }

        /// <summary>
        /// Gets badges that are owned by a specific user
        /// </summary>
        /// <param name="key">Access key</param>
        /// <param name="steamid">The player we're asking about</param>
        public void GetBadges(string key, ulong steamid)
        {
            using (dynamic data = WebAPI.GetInterface("IPlayerService", API.AppKey))
            {
                KeyValue items = data.GetBadges(key: key, steamid: steamid, l: "english");
            }
        }

        /// <summary>
        /// Gets all the quests needed to get the specified badge, and which are completed
        /// </summary>
        /// <param name="key">Access key</param>
        /// <param name="steamid">The player we're asking about</param>
        /// <param name="badgeid">The badge we're asking about</param>
        public void GetCommunityBadgeProgress(string key, ulong steamid, uint badgeid)
        {
            using (dynamic data = WebAPI.GetInterface("IPlayerService", API.AppKey))
            {
                KeyValue items = data.GetCommunityBadgeProgress(key: key, steamid: steamid, badgeid: badgeid, l: "english");
            }
        }

        /// <summary>
        /// Returns valid lender SteamID if game currently played is borrowed
        /// </summary>
        /// <param name="key">Access key</param>
        /// <param name="steamid">The player we're asking about</param>
        /// <param name="appid_playing">The game player is currently playing</param>
        public void IsPlayingSharedGame(string key, ulong steamid, uint appid_playing)
        {
            using (dynamic data = WebAPI.GetInterface("IPlayerService", API.AppKey))
            {
                KeyValue items = data.IsPlayingSharedGame(key: key, steamid: steamid, appid_playing: appid_playing, l: "english");
            }
        }
    }
}
