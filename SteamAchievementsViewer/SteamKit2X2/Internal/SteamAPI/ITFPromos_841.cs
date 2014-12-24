using SteamKit2;

namespace SteamKit2X2.Internal.SteamAPI
{
    /// <summary>
    /// Portal 2 Beta
    /// </summary>
    internal sealed class ITFPromos_841 : ITFPromos
    {
        /// <summary>
        /// 
        /// </summary>
        /// <param name="steamid">The Steam ID to fetch items for</param>
        /// <param name="promoid">The promo ID to grant an item for</param>
        public void GetItemID(ulong steamid, uint promoid)
        {
            using (dynamic data = WebAPI.GetInterface("ITFPromos_841", API.AppKey))
            {
                KeyValue items = data.GetItemID(steamid: steamid, PromoID: promoid, l: "english");
            }
        }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="steamid">The Steam ID to fetch items for</param>
        /// <param name="promoid">The promo ID to grant an item for</param>
        /// <remarks>POST</remarks>
        public void GrantItem(ulong steamid, uint promoid)
        {
            using (dynamic data = WebAPI.GetInterface("ITFPromos_841", API.AppKey))
            {
                KeyValue items = data.GrantItem(steamid: steamid, PromoID: promoid, l: "english");
            }
        }
    }
}
