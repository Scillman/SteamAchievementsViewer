using SteamKit2;

namespace SteamKit2X2.Internal.SteamAPI
{
    /// <summary>
    /// Dota 2 Test
    /// </summary>
    internal class IDOTA2Match_205790
    {
        /// <summary>
        /// 
        /// </summary>
        public void GetLeagueListing()
        {
            using (dynamic data = WebAPI.GetInterface("IDOTA2Match_205790", API.AppKey))
            {
                KeyValue items = data.GetLeagueListing(l: "english");
            }
        }

        /// <summary>
        /// 
        /// </summary>
        public void GetLiveLeagueGames()
        {
            using (dynamic data = WebAPI.GetInterface("IDOTA2Match_205790", API.AppKey))
            {
                KeyValue items = data.GetLiveLeagueGames(l: "english");
            }
        }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="league_id">Only show matches of the specified league id</param>
        /// <param name="match_id">Only show matches of the specified match id</param>
        public void GetLiveLeagueGames(uint league_id, ulong match_id)
        {
            using (dynamic data = WebAPI.GetInterface("IDOTA2Match_205790", API.AppKey))
            {
                KeyValue items = data.GetLiveLeagueGames(league_id: league_id, match_id: match_id, l: "english");
            }
        }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="match_id">Match id</param>
        public void GetMatchDetails(ulong match_id)
        {
            using (dynamic data = WebAPI.GetInterface("IDOTA2Match_205790", API.AppKey))
            {
                KeyValue items = data.GetMatchDetails(match_id: match_id, l: "english");
            }
        }

        /// <summary>
        /// 
        /// </summary>
        public void GetMatchHistory()
        {
            using (dynamic data = WebAPI.GetInterface("IDOTA2Match_205790", API.AppKey))
            {
                KeyValue items = data.GetMatchHistory(l: "english");
            }
        }

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
        public void GetMatchHistory(uint hero_id, uint game_mode, uint skill, string min_players, string account_id, string league_id, ulong start_at_match_id, string matches_requested, string tournament_games_only)
        {
            using (dynamic data = WebAPI.GetInterface("IDOTA2Match_205790", API.AppKey))
            {
                KeyValue items = data.GetMatchHistory(hero_id: hero_id, game_mode: game_mode, skill: skill, min_players: min_players, account_id: account_id, league_id: league_id, start_at_match_id: start_at_match_id, matches_requested: matches_requested, tournament_games_only: tournament_games_only, l: "english");
            }
        }

        /// <summary>
        /// 
        /// </summary>
        public void GetMatchHistoryBySequenceNum()
        {
            using (dynamic data = WebAPI.GetInterface("IDOTA2Match_205790", API.AppKey))
            {
                KeyValue items = data.GetMatchHistoryBySequenceNum(l: "english");
            }
        }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="start_at_match_seq_num"></param>
        /// <param name="matches_requested"></param>
        public void GetMatchHistoryBySequenceNum(ulong start_at_match_seq_num, uint matches_requested)
        {
            using (dynamic data = WebAPI.GetInterface("IDOTA2Match_205790", API.AppKey))
            {
                KeyValue items = data.GetMatchHistoryBySequenceNum(start_at_match_seq_num: start_at_match_seq_num, matches_requested: matches_requested, l: "english");
            }
        }

        /// <summary>
        /// 
        /// </summary>
        public void GetScheduledLeagueGames()
        {
            using (dynamic data = WebAPI.GetInterface("IDOTA2Match_205790", API.AppKey))
            {
                KeyValue items = data.GetScheduledLeagueGames(l: "english");
            }
        }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="date_min">The starting time stamp to collect scheduled games from. If ignored, it will use the current time</param>
        /// <param name="date_max">The ending time stamp. If this is more than 7 days past the starting time stamp, it will be clamped to 7 days.</param>
        public void GetScheduledLeagueGames(uint date_min, uint date_max)
        {
            using (dynamic data = WebAPI.GetInterface("IDOTA2Match_205790", API.AppKey))
            {
                KeyValue items = data.GetScheduledLeagueGames(date_min: date_min, date_max: date_max, l: "english");
            }
        }

        /// <summary>
        /// 
        /// </summary>
        public void GetTeamInfoByTeamID()
        {
            using (dynamic data = WebAPI.GetInterface("IDOTA2Match_205790", API.AppKey))
            {
                KeyValue items = data.GetTeamInfoByTeamID(l: "english");
            }
        }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="start_at_team_id"></param>
        /// <param name="teams_requested"></param>
        public void GetTeamInfoByTeamID(ulong start_at_team_id, uint teams_requested)
        {
            using (dynamic data = WebAPI.GetInterface("IDOTA2Match_205790", API.AppKey))
            {
                KeyValue items = data.GetTeamInfoByTeamID(l: "english");
            }
        }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="account_id"></param>
        public void GetTournamentPlayerStats(string account_id)
        {
            using (dynamic data = WebAPI.GetInterface("IDOTA2Match_205790", API.AppKey))
            {
                KeyValue items = data.GetTournamentPlayerStats(account_id: account_id, l: "english");
            }
        }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="account_id"></param>
        /// <param name="league_id"></param>
        /// <param name="hero_id"></param>
        /// <param name="time_frame"></param>
        /// <param name="match_id"></param>
        public void GetTournamentPlayerStats(string account_id, string league_id, string hero_id, string time_frame, ulong match_id)
        {
            using (dynamic data = WebAPI.GetInterface("IDOTA2Match_205790", API.AppKey))
            {
                KeyValue items = data.GetTournamentPlayerStats(account_id: account_id, league_id: league_id, hero_id: hero_id, time_frame: time_frame, match_id: match_id, l: "english");
            }
        }
    }
}
