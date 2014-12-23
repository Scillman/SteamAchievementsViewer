using SteamKit2;

namespace SteamKit2X2.Internal.SteamAPI
{
    /// <summary>
    /// Dota 2
    /// </summary>
    internal class IDOTA2Fantasy_570 : IDOTA2Fantasy
    {
        /// <summary>
        /// 
        /// </summary>
        /// <param name="FantasyLeagueID">The fantasy league ID</param>
        public void GetFantasyPlayerStats(uint FantasyLeagueID)
        {
            using (dynamic data = WebAPI.GetInterface("IDOTA2Fantasy_570", API.AppKey))
            {
                KeyValue items = data.GetGameServersStatus(FantasyLeagueID: FantasyLeagueID, l: "english");
            }
        }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="FantasyLeagueID">The fantasy league ID</param>
        /// <param name="StartTime">An optional filter for minimum timestamp</param>
        /// <param name="EndTime">An optional filter for maximum timestamp</param>
        /// <param name="matchid">An optional filter for a specific match</param>
        /// <param name="SeriesID">An optional filter for a specific series</param>
        /// <param name="PlayerAccountID">An optional filter for a specific player</param>
        public void GetFantasyPlayerStats(uint FantasyLeagueID, uint StartTime, uint EndTime, ulong matchid, uint SeriesID, uint PlayerAccountID)
        {
            using (dynamic data = WebAPI.GetInterface("IDOTA2Fantasy_570", API.AppKey))
            {
                KeyValue items = data.GetGameServersStatus(FantasyLeagueID: FantasyLeagueID, StartTime: StartTime, EndTime: EndTime, matchid: matchid, SeriesID: SeriesID, PlayerAccountID: PlayerAccountID, l: "english");
            }
        }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="accountid">The account ID to look up</param>
        public void GetPlayerOfficialInfo(uint accountid)
        {
            using (dynamic data = WebAPI.GetInterface("IDOTA2Fantasy_570", API.AppKey))
            {
                KeyValue items = data.GetPlayerOfficialInfo(accountid: accountid, l: "english");
            }
        }
    }
}
