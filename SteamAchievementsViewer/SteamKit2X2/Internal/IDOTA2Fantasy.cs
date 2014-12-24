
namespace SteamKit2X2.Internal
{
    public interface IDOTA2Fantasy
    {
        /// <summary>
        /// 
        /// </summary>
        /// <param name="FantasyLeagueID">The fantasy league ID</param>
        void GetFantasyPlayerStats(uint FantasyLeagueID);

        /// <summary>
        /// 
        /// </summary>
        /// <param name="FantasyLeagueID">The fantasy league ID</param>
        /// <param name="StartTime">An optional filter for minimum timestamp</param>
        /// <param name="EndTime">An optional filter for maximum timestamp</param>
        /// <param name="matchid">An optional filter for a specific match</param>
        /// <param name="SeriesID">An optional filter for a specific series</param>
        /// <param name="PlayerAccountID">An optional filter for a specific player</param>
        void GetFantasyPlayerStats(uint FantasyLeagueID, uint StartTime, uint EndTime, ulong matchid, uint SeriesID, uint PlayerAccountID);

        /// <summary>
        /// 
        /// </summary>
        /// <param name="accountid">The account ID to look up</param>
        void GetPlayerOfficialInfo(uint accountid);
    }
}
