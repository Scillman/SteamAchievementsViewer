using SteamKit2;

namespace SteamKit2X2.Internal.SteamAPI
{
    /// <summary>
    /// Portal 2
    /// </summary>
    internal class IEconItems_620 : IEconItems
    {
        /// <summary>
        /// 
        /// </summary>
        /// <param name="steamid">The Steam ID to fetch items for</param>
        public void GetPlayerItems(ulong steamid)
        {
            using (dynamic data = WebAPI.GetInterface("IEconItems_620", API.AppKey))
            {
                KeyValue items = data.GetPlayerItems(steamid: steamid, l: "english");
            }
        }

        /// <summary>
        /// 
        /// </summary>
        public void GetSchema()
        {
            using (dynamic data = WebAPI.GetInterface("IEconItems_620", API.AppKey))
            {
                KeyValue items = data.GetSchema(l: "english");
            }
        }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="language">The language to return the names in. Defaults to returning string keys.</param>
        public void GetSchema(string language)
        {
            using (dynamic data = WebAPI.GetInterface("IEconItems_620", API.AppKey))
            {
                KeyValue items = data.GetSchema(language: language, l: "english");
            }
        }
    }
}
