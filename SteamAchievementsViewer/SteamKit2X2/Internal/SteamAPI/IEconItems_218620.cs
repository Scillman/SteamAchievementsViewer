using SteamKit2;

namespace SteamKit2X2.Internal.SteamAPI
{
    /// <summary>
    /// PAYDAY 2
    /// </summary>
    internal class IEconItems_218620 : IEconItems
    {
        /// <summary>
        /// 
        /// </summary>
        /// <param name="steamid">The Steam ID to fetch items for</param>
        public void GetPlayerItems(ulong steamid)
        {
            using (dynamic data = WebAPI.GetInterface("IEconItems_218620", API.AppKey))
            {
                KeyValue items = data.GetPlayerItems(steamid: steamid, l: "english");
            }
        }
    }
}
