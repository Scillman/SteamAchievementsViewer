
namespace SteamKit2X2.Internal
{
    interface IEconDOTA2
    {
        /// <summary>
        /// 
        /// </summary>
        /// <param name="eventid">The League ID of the compendium you're looking for.</param>
        /// <param name="accountid">The account ID to look up.</param>
        void GetEventStatsForAccount(uint eventid, uint accountid);

        /// <summary>
        /// 
        /// </summary>
        /// <param name="eventid">The League ID of the compendium you're looking for.</param>
        /// <param name="accountid">The account ID to look up.</param>
        /// <param name="language">The language to provide hero names in.</param>
        void GetEventStatsForAccount(uint eventid, uint accountid, string language);

        /// <summary>
        /// 
        /// </summary>
        void GetGameItems();

        /// <summary>
        /// 
        /// </summary>
        /// <param name="language">The language to provide item names in.</param>
        void GetGameItems(string language);

        /// <summary>
        /// 
        /// </summary>
        void GetHeroes();

        /// <summary>
        /// 
        /// </summary>
        /// <param name="language">The language to provide hero names in.</param>
        /// <param name="itemizedonly">Return a list of itemized heroes only.</param>
        void GetHeroes(string language, bool itemizedonly);

        /// <summary>
        /// 
        /// </summary>
        /// <param name="iconname">The item icon name to get the CDN path of</param>
        void GetItemIconPath(string iconname);

        /// <summary>
        /// 
        /// </summary>
        void GetRarities();

        /// <summary>
        /// 
        /// </summary>
        /// <param name="language">The language to provide rarity names in.</param>
        void GetRarities(string language);

        /// <summary>
        /// 
        /// </summary>
        void GetTournamentPrizePool();

        /// <summary>
        /// 
        /// </summary>
        /// <param name="leagueid">The ID of the league to get the prize pool of</param>
        void GetTournamentPrizePool(uint leagueid);
    }
}
