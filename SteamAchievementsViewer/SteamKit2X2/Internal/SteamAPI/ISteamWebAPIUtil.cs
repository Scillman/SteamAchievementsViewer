using SteamKit2;

namespace SteamKit2X2.Internal.SteamAPI
{
    internal sealed class ISteamWebAPIUtil
    {
        /// <summary>
        /// 
        /// </summary>
        /// <remarks>NO KEY</remarks>
        public void GetServerInfo()
        {
            using (dynamic data = WebAPI.GetInterface("ISteamWebAPIUtil", API.AppKey))
            {
                KeyValue items = data.GetServerInfo(l: "english");
            }
        }

        /// <summary>
        /// 
        /// </summary>
        /// <remarks>NO KEY</remarks>
        public void GetSupportedAPIList()
        {
            using (dynamic data = WebAPI.GetInterface("ISteamWebAPIUtil", API.AppKey))
            {
                KeyValue items = data.GetSupportedAPIList(l: "english");
            }
        }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="key">access key</param>
        /// <remarks>NO KEY</remarks>
        public void GetSupportedAPIList(string key)
        {
            using (dynamic data = WebAPI.GetInterface("ISteamWebAPIUtil", API.AppKey))
            {
                KeyValue items = data.GetSupportedAPIList(key: key, l: "english");
            }
        }
    }
}
