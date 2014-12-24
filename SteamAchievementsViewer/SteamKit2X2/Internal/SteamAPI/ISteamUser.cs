using SteamKit2;
using System;

namespace SteamKit2X2.Internal.SteamAPI
{
    internal sealed class ISteamUser
    {
        /// <summary>
        /// 
        /// </summary>
        /// <param name="key">access key</param>
        /// <param name="steamid">SteamID of user</param>
        public void GetFriendList(string key, ulong steamid)
        {
            using (dynamic data = WebAPI.GetInterface("ISteamUser", API.AppKey))
            {
                KeyValue items = data.GetFriendList(key: key, steamid: steamid, l: "english");
            }
        }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="key">access key</param>
        /// <param name="steamid">SteamID of user</param>
        /// <param name="relationship">relationship type (ex: friend)</param>
        public void GetFriendList(string key, ulong steamid, string relationship)
        {
            using (dynamic data = WebAPI.GetInterface("ISteamUser", API.AppKey))
            {
                KeyValue items = data.GetFriendList(key: key, steamid: steamid, relationship: relationship, l: "english");
            }
        }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="key">access key</param>
        /// <param name="steamids">Comma-delimited list of SteamIDs</param>
        public void GetPlayerBans(string key, string steamids)
        {
            using (dynamic data = WebAPI.GetInterface("ISteamUser", API.AppKey))
            {
                KeyValue items = data.GetPlayerBans(key: key, steamids: steamids, l: "english");
            }
        }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="key">access key</param>
        /// <param name="steamids">Comma-delimited list of SteamIDs</param>
        [Obsolete("Use GetPlayerSummaries2 instead.")]
        public void GetPlayerSummaries(string key, string steamids)
        {
            using (dynamic data = WebAPI.GetInterface("ISteamUser", API.AppKey))
            {
                KeyValue items = data.GetPlayerSummaries(key: key, steamids: steamids, l: "english");
            }
        }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="key">access key</param>
        /// <param name="steamids">Comma-delimited list of SteamIDs (max: 100)</param>
        public void GetPlayerSummaries2(string key, string steamids)
        {
            using (dynamic data = WebAPI.GetInterface("ISteamUser", API.AppKey))
            {
                KeyValue items = data.GetPlayerSummaries2(key: key, steamids: steamids, l: "english");
            }
        }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="key">access key</param>
        /// <param name="steamid">SteamID of user</param>
        public void GetUserGroupList(string key, ulong steamid)
        {
            using (dynamic data = WebAPI.GetInterface("ISteamUser", API.AppKey))
            {
                KeyValue items = data.GetUserGroupList(key: key, steamid: steamid, l: "english");
            }
        }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="key">access key</param>
        /// <param name="vanityurl">The vanity URL to get a SteamID for</param>
        public void ResolveVanityURL(string key, string vanityurl)
        {
            using (dynamic data = WebAPI.GetInterface("ISteamUser", API.AppKey))
            {
                KeyValue items = data.ResolveVanityURL(key: key, vanityurl: vanityurl, l: "english");
            }
        }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="key">access key</param>
        /// <param name="vanityurl">The vanity URL to get a SteamID for</param>
        /// <param name="url_type">The type of vanity URL. 1 (default): Individual profile, 2: Group, 3: Official game group</param>
        public void ResolveVanityURL(string key, string vanityurl, int url_type)
        {
            using (dynamic data = WebAPI.GetInterface("ISteamUser", API.AppKey))
            {
                KeyValue items = data.ResolveVanityURL(key: key, vanityurl: vanityurl, url_type: url_type, l: "english");
            }
        }
    }
}
