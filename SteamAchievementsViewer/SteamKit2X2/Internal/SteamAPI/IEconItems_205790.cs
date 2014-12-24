using SteamKit2;

namespace SteamKit2X2.Internal.SteamAPI
{
    /// <summary>
    /// Dota 2 Test
    /// </summary>
    internal sealed class IEconItems_205790 : IEconItems
    {
        /// <summary>
        /// 
        /// </summary>
        /// <param name="steamid">The Steam ID to fetch items for</param>
        public void GetPlayerItems(ulong steamid)
        {
            using (dynamic data = WebAPI.GetInterface("IEconItems_205790", API.AppKey))
            {
                KeyValue items = data.GetPlayerItems(steamid: steamid, l: "english");
            }
        }

        /// <summary>
        /// 
        /// </summary>
        public void GetSchema()
        {
            using (dynamic data = WebAPI.GetInterface("IEconItems_205790", API.AppKey))
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
            using (dynamic data = WebAPI.GetInterface("IEconItems_205790", API.AppKey))
            {
                KeyValue items = data.GetSchema(language: language, l: "english");
            }
        }

        /// <summary>
        /// 
        /// </summary>
        public void GetSchemaURL()
        {
            using (dynamic data = WebAPI.GetInterface("IEconItems_205790", API.AppKey))
            {
                KeyValue items = data.GetSchemaURL(l: "english");
            }
        }

        /// <summary>
        /// 
        /// </summary>
        public void GetStoreMetaData()
        {
            using (dynamic data = WebAPI.GetInterface("IEconItems_205790", API.AppKey))
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
            using (dynamic data = WebAPI.GetInterface("IEconItems_205790", API.AppKey))
            {
                KeyValue items = data.GetStoreMetaData(language: language, l: "english");
            }
        }
    }
}
