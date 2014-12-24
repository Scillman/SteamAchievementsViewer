using SteamKit2;

namespace SteamKit2X2.Internal.SteamAPI
{
    /// <summary>
    /// Counter-Strike: Global Offensive
    /// </summary>
    internal sealed class IEconItems_730 : IEconItems
    {
        /// <summary>
        /// 
        /// </summary>
        /// <param name="steamid">The Steam ID to fetch items for</param>
        public void GetPlayerItems(ulong steamid)
        {
            using (dynamic data = WebAPI.GetInterface("IEconItems_730", API.AppKey))
            {
                KeyValue items = data.GetPlayerItems(steamid: steamid, l: "english");
            }
        }

        /// <summary>
        /// 
        /// </summary>
        public void GetSchema2()
        {
            using (dynamic data = WebAPI.GetInterface("IEconItems_730", API.AppKey))
            {
                KeyValue items = data.GetSchema2(l: "english");
            }
        }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="language">The language to return the names in. Defaults to returning string keys.</param>
        public void GetSchema2(string language)
        {
            using (dynamic data = WebAPI.GetInterface("IEconItems_730", API.AppKey))
            {
                KeyValue items = data.GetSchema2(language: language, l: "english");
            }
        }

        /// <summary>
        /// 
        /// </summary>
        public void GetSchemaURL2()
        {
            using (dynamic data = WebAPI.GetInterface("IEconItems_730", API.AppKey))
            {
                KeyValue items = data.GetSchemaURL2(l: "english");
            }
        }

        /// <summary>
        /// 
        /// </summary>
        public void GetStoreMetaData()
        {
            using (dynamic data = WebAPI.GetInterface("IEconItems_730", API.AppKey))
            {
                KeyValue items = data.GetStoreMetaData(l: "english");
            }
        }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="language">The language to results in.</param>
        public void GetStoreMetaData(string language)
        {
            using (dynamic data = WebAPI.GetInterface("IEconItems_730", API.AppKey))
            {
                KeyValue items = data.GetStoreMetaData(language: language, l: "english");
            }
        }
    }
}
