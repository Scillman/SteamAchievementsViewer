using SteamKit2;
using System;

namespace SteamKit2X2.Internal.SteamAPI
{
    internal sealed class ISteamUserStats
    {
        /// <summary>
        /// 
        /// </summary>
        /// <param name="gameid">GameID to retrieve the achievement percentages for</param>
        [Obsolete("Use GetGlobalAchievementPercentagesForApp2 instead.")]
        public void GetGlobalAchievementPercentagesForApp(ulong gameid)
        {
            using (dynamic data = WebAPI.GetInterface("ISteamUserStats", API.AppKey))
            {
                KeyValue items = data.GetGlobalAchievementPercentagesForApp(gameid: gameid, l: "english");
            }
        }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="gameid">GameID to retrieve the achievement percentages for</param>
        public void GetGlobalAchievementPercentagesForApp2(ulong gameid)
        {
            using (dynamic data = WebAPI.GetInterface("ISteamUserStats", API.AppKey))
            {
                KeyValue items = data.GetGlobalAchievementPercentagesForApp2(gameid: gameid, l: "english");
            }
        }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="appid">AppID that we're getting global stats for</param>
        /// <param name="count">Number of stats get data for</param>
        /// <param name="name">Names of stat to get data for</param>
        public void GetGlobalStatsForGame(uint appid, uint count, string[] name)
        {
            using (dynamic data = WebAPI.GetInterface("ISteamUserStats", API.AppKey))
            {
                KeyValue items = data.GetGlobalStatsForGame(appid: appid, count: count, name: name, l: "english");
            }
        }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="appid">AppID that we're getting global stats for</param>
        /// <param name="count">Number of stats get data for</param>
        /// <param name="name">Names of stat to get data for</param>
        /// <param name="startdate">Start date for daily totals (unix epoch timestamp)</param>
        /// <param name="enddate">End date for daily totals (unix epoch timestamp)</param>
        public void GetGlobalStatsForGame(uint appid, uint count, string[] name, uint startdate, uint enddate)
        {
            using (dynamic data = WebAPI.GetInterface("ISteamUserStats", API.AppKey))
            {
                KeyValue items = data.GetGlobalStatsForGame(appid: appid, count: count, name: name, startdate: startdate, enddate: enddate, l: "english");
            }
        }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="appid">AppID that we're getting user count for</param>
        public void GetNumberOfCurrentPlayers(uint appid)
        {
            using (dynamic data = WebAPI.GetInterface("ISteamUserStats", API.AppKey))
            {
                KeyValue items = data.GetNumberOfCurrentPlayers(appid: appid, l: "english");
            }
        }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="key">access key</param>
        /// <param name="steamid">SteamID of user</param>
        /// <param name="appid">AppID to get achievements for</param>
        public void GetPlayerAchievements(string key, ulong steamid, uint appid)
        {
            using (dynamic data = WebAPI.GetInterface("ISteamUserStats", API.AppKey))
            {
                KeyValue items = data.GetPlayerAchievements(key: key, steamid: steamid, appid: appid, l: "english");
            }
        }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="key">access key</param>
        /// <param name="steamid">SteamID of user</param>
        /// <param name="appid">AppID to get achievements for</param>
        /// <param name="l">Language to return strings for</param>
        public void GetPlayerAchievements(string key, ulong steamid, uint appid, string l)
        {
            using (dynamic data = WebAPI.GetInterface("ISteamUserStats", API.AppKey))
            {
                KeyValue items = data.GetPlayerAchievements(key: key, steamid: steamid, appid: appid, l: l);
            }
        }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="key">access key</param>
        /// <param name="appid">appid of game</param>
        [Obsolete("Use GetSchemaForGame2 instead.")]
        public void GetSchemaForGame(string key, uint appid)
        {
            using (dynamic data = WebAPI.GetInterface("ISteamUserStats", API.AppKey))
            {
                KeyValue items = data.GetSchemaForGame(key: key, appid: appid, l : "english");
            }
        }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="key">access key</param>
        /// <param name="appid">appid of game</param>
        /// <param name="l">localized langauge to return (english, french, etc.)</param>
        [Obsolete("Use GetSchemaForGame2 instead.")]
        public void GetSchemaForGame(string key, uint appid, string l)
        {
            using (dynamic data = WebAPI.GetInterface("ISteamUserStats", API.AppKey))
            {
                KeyValue items = data.GetSchemaForGame(key: key, appid: appid, l: l);
            }
        }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="key">access key</param>
        /// <param name="appid">appid of game</param>
        public void GetSchemaForGame2(string key, uint appid)
        {
            using (dynamic data = WebAPI.GetInterface("ISteamUserStats", API.AppKey))
            {
                KeyValue items = data.GetSchemaForGame2(key: key, appid: appid, l: "english");
            }
        }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="key">access key</param>
        /// <param name="appid">appid of game</param>
        /// <param name="l">localized langauge to return (english, french, etc.)</param>
        public void GetSchemaForGame2(string key, uint appid, string l)
        {
            using (dynamic data = WebAPI.GetInterface("ISteamUserStats", API.AppKey))
            {
                KeyValue items = data.GetSchemaForGame2(key: key, appid: appid, l: l);
            }
        }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="key">access key</param>
        /// <param name="steamid">SteamID of user</param>
        /// <param name="appid">appid of game</param>
        [Obsolete("Use GetUserStatsForGame2 instead.")]
        public void GetUserStatsForGame(string key, ulong steamid, uint appid)
        {
            using (dynamic data = WebAPI.GetInterface("ISteamUserStats", API.AppKey))
            {
                KeyValue items = data.GetUserStatsForGame(key: key, steamid: steamid, appid: appid, l: "english");
            }
        }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="key">access key</param>
        /// <param name="steamid">SteamID of user</param>
        /// <param name="appid">appid of game</param>
        public void GetUserStatsForGame2(string key, ulong steamid, uint appid)
        {
            using (dynamic data = WebAPI.GetInterface("ISteamUserStats", API.AppKey))
            {
                KeyValue items = data.GetUserStatsForGame2(key: key, steamid: steamid, appid: appid, l: "english");
            }
        }
    }
}
