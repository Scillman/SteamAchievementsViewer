using SteamKit2;

namespace SteamKit2X2.Internal.SteamAPI
{
    /// <summary>
    /// Portal 2
    /// </summary>
    internal sealed class IPortal2Leaderboards_620 : IPortal2Leaderboards
    {
        /// <summary>
        /// 
        /// </summary>
        /// <param name="leaderboardName">The leaderboard name to fetch data for.</param>
        public void GetBucketizedData(string leaderboardName)
        {
            using (dynamic data = WebAPI.GetInterface("IPortal2Leaderboards_620", API.AppKey))
            {
                KeyValue items = data.GetBucketizedData(leaderboardName: leaderboardName, l: "english");
            }
        }
    }
}
