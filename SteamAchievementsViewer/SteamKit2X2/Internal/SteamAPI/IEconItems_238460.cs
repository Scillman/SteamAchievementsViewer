using SteamKit2;

namespace SteamKit2X2.Internal.SteamAPI
{
    /// <summary>
    /// BattleBlock Theater
    /// </summary>
    internal sealed class IEconItems_238460 : IEconItems
    {
        /// <summary>
        /// 
        /// </summary>
        /// <param name="steamid">The Steam ID to fetch items for</param>
        public void GetPlayerItems(ulong steamid)
        {
            using (dynamic data = WebAPI.GetInterface("IEconItems_238460", API.AppKey))
            {
                KeyValue items = data.GetPlayerItems(steamid: steamid, l: "english");
            }
        }
    }
}
