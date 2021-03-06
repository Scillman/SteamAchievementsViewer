﻿using SteamKit2;

namespace SteamKit2X2.Internal.SteamAPI
{
    /// <summary>
    /// Portal 2 Beta
    /// </summary>
    internal sealed class IPortal2Leaderboards_841 : IPortal2Leaderboards
    {
        /// <summary>
        /// 
        /// </summary>
        /// <param name="leaderboardName">The leaderboard name to fetch data for.</param>
        /// <remarks>NO KEY</remarks>
        public void GetBucketizedData(string leaderboardName)
        {
            using (dynamic data = WebAPI.GetInterface("IPortal2Leaderboards_841", API.AppKey))
            {
                KeyValue items = data.GetBucketizedData(leaderboardName: leaderboardName, l: "english");
            }
        }
    }
}
