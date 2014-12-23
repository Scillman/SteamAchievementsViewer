using SteamKit2;

namespace SteamKit2X2.Internal.SteamAPI
{
    /// <summary>
    /// Dota 2 Test
    /// </summary>
    internal class IEconDOTA2_205790 : IEconDOTA2
    {
        /// <summary>
        /// 
        /// </summary>
        /// <param name="eventid">The League ID of the compendium you're looking for.</param>
        /// <param name="accountid">The account ID to look up.</param>
        public void GetEventStatsForAccount(uint eventid, uint accountid)
        {
            using (dynamic data = WebAPI.GetInterface("IEconDOTA2_205790", API.AppKey))
            {
                KeyValue items = data.GetEventStatsForAccount(eventid: eventid, accountid: accountid, l: "english");
            }
        }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="eventid">The League ID of the compendium you're looking for.</param>
        /// <param name="accountid">The account ID to look up.</param>
        /// <param name="language">The language to provide hero names in.</param>
        public void GetEventStatsForAccount(uint eventid, uint accountid, string language)
        {
            using (dynamic data = WebAPI.GetInterface("IEconDOTA2_205790", API.AppKey))
            {
                KeyValue items = data.GetEventStatsForAccount(eventid: eventid, accountid: accountid, language: language, l: "english");
            }
        }

        /// <summary>
        /// 
        /// </summary>
        public void GetGameItems()
        {
            using (dynamic data = WebAPI.GetInterface("IEconDOTA2_205790", API.AppKey))
            {
                KeyValue items = data.GetGameItems(l: "english");
            }
        }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="language">The language to provide item names in.</param>
        public void GetGameItems(string language)
        {
            using (dynamic data = WebAPI.GetInterface("IEconDOTA2_205790", API.AppKey))
            {
                KeyValue items = data.GetGameItems(language: language, l: "english");
            }
        }

        /// <summary>
        /// 
        /// </summary>
        public void GetHeroes()
        {
            using (dynamic data = WebAPI.GetInterface("IEconDOTA2_205790", API.AppKey))
            {
                KeyValue items = data.GetHeroes(l: "english");
            }
        }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="language">The language to provide hero names in.</param>
        /// <param name="itemizedonly">Return a list of itemized heroes only.</param>
        public void GetHeroes(string language, bool itemizedonly)
        {
            using (dynamic data = WebAPI.GetInterface("IEconDOTA2_205790", API.AppKey))
            {
                KeyValue items = data.GetHeroes(language: language, itemizedonly: itemizedonly, l: "english");
            }
        }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="iconname">The item icon name to get the CDN path of</param>
        public void GetItemIconPath(string iconname)
        {
            using (dynamic data = WebAPI.GetInterface("IEconDOTA2_205790", API.AppKey))
            {
                KeyValue items = data.GetItemIconPath(iconname: iconname, l: "english");
            }
        }

        /// <summary>
        /// 
        /// </summary>
        public void GetRarities()
        {
            using (dynamic data = WebAPI.GetInterface("IEconDOTA2_205790", API.AppKey))
            {
                KeyValue items = data.GetRarities(l: "english");
            }
        }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="language">The language to provide rarity names in.</param>
        public void GetRarities(string language)
        {
            using (dynamic data = WebAPI.GetInterface("IEconDOTA2_205790", API.AppKey))
            {
                KeyValue items = data.GetRarities(language: language, l: "english");
            }
        }

        /// <summary>
        /// 
        /// </summary>
        public void GetTournamentPrizePool()
        {
            using (dynamic data = WebAPI.GetInterface("IEconDOTA2_205790", API.AppKey))
            {
                KeyValue items = data.GetTournamentPrizePool(l: "english");
            }
        }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="leagueid">The ID of the league to get the prize pool of</param>
        public void GetTournamentPrizePool(uint leagueid)
        {
            using (dynamic data = WebAPI.GetInterface("IEconDOTA2_205790", API.AppKey))
            {
                KeyValue items = data.GetTournamentPrizePool(leagueid: leagueid, l: "english");
            }
        }
    }
}
