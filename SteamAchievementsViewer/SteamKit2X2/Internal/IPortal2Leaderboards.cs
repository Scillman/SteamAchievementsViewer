
namespace SteamKit2X2.Internal
{
    public interface IPortal2Leaderboards
    {
        /// <summary>
        /// 
        /// </summary>
        /// <param name="leaderboardName">The leaderboard name to fetch data for.</param>
        void GetBucketizedData(string leaderboardName);
    }
}
