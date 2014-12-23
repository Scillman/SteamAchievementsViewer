
namespace SteamKit2X2.Internal
{
    interface IDOTA2Match
    {
        /// <summary>
        /// 
        /// </summary>
        void GetLeagueListing();

        /// <summary>
        /// 
        /// </summary>
        void GetLiveLeagueGames();

        /// <summary>
        /// 
        /// </summary>
        /// <param name="league_id">Only show matches of the specified league id</param>
        /// <param name="match_id">Only show matches of the specified match id</param>
        void GetLiveLeagueGames(uint league_id, ulong match_id);

        /// <summary>
        /// 
        /// </summary>
        /// <param name="match_id">Match id</param>
        void GetMatchDetails(ulong match_id);

        /// <summary>
        /// 
        /// </summary>
        void GetMatchHistory();

        /// <summary>
        /// 
        /// </summary>
        /// <param name="hero_id">The ID of the hero that must be in the matches being queried</param>
        /// <param name="game_mode">Which game mode to return matches for</param>
        /// <param name="skill">The average skill range of the match, these can be [1-3] with lower numbers being lower skill. Ignored if an account ID is specified</param>
        /// <param name="min_players">Minimum number of human players that must be in a match for it to be returned</param>
        /// <param name="account_id">An account ID to get matches from. This will fail if the user has their match history hidden</param>
        /// <param name="league_id">The league ID to return games from</param>
        /// <param name="start_at_match_id">The minimum match ID to start from</param>
        /// <param name="matches_requested">The number of requested matches to return</param>
        /// <param name="tournament_games_only">Whether or not tournament games should only be returned</param>
        void GetMatchHistory(uint hero_id, uint game_mode, uint skill, string min_players, string account_id, string league_id, ulong start_at_match_id, string matches_requested, string tournament_games_only);

        /// <summary>
        /// 
        /// </summary>
        void GetMatchHistoryBySequenceNum();

        /// <summary>
        /// 
        /// </summary>
        /// <param name="start_at_match_seq_num"></param>
        /// <param name="matches_requested"></param>
        void GetMatchHistoryBySequenceNum(ulong start_at_match_seq_num, uint matches_requested);

        /// <summary>
        /// 
        /// </summary>
        void GetScheduledLeagueGames();

        /// <summary>
        /// 
        /// </summary>
        /// <param name="date_min">The starting time stamp to collect scheduled games from. If ignored, it will use the current time</param>
        /// <param name="date_max">The ending time stamp. If this is more than 7 days past the starting time stamp, it will be clamped to 7 days.</param>
        void GetScheduledLeagueGames(uint date_min, uint date_max);

        /// <summary>
        /// 
        /// </summary>
        void GetTeamInfoByTeamID();

        /// <summary>
        /// 
        /// </summary>
        /// <param name="start_at_team_id"></param>
        /// <param name="teams_requested"></param>
        void GetTeamInfoByTeamID(ulong start_at_team_id, uint teams_requested);

        /// <summary>
        /// 
        /// </summary>
        /// <param name="account_id"></param>
        void GetTournamentPlayerStats(string account_id);

        /// <summary>
        /// 
        /// </summary>
        /// <param name="account_id"></param>
        /// <param name="league_id"></param>
        /// <param name="hero_id"></param>
        /// <param name="time_frame"></param>
        /// <param name="match_id"></param>
        void GetTournamentPlayerStats(string account_id, string league_id, string hero_id, string time_frame, ulong match_id);
    }
}
