
namespace SteamKit2X2.Internal
{
    public interface ITFPromos
    {
        /// <summary>
        /// 
        /// </summary>
        /// <param name="steamid">The Steam ID to fetch items for</param>
        /// <param name="promoid">The promo ID to grant an item for</param>
        void GetItemID(ulong steamid, uint promoid);

        /// <summary>
        /// 
        /// </summary>
        /// <param name="steamid">The Steam ID to fetch items for</param>
        /// <param name="promoid">The promo ID to grant an item for</param>
        /// <remarks>POST</remarks>
        void GrantItem(ulong steamid, uint promoid);
    }
}
