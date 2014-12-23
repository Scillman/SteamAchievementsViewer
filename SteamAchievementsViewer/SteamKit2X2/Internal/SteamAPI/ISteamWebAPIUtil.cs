using SteamKit2;

namespace SteamKit2X2.Internal.SteamAPI
{
    internal class ISteamWebAPIUtil
    {
        /// <summary>
        /// 
        /// </summary>
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
        public void GetSupportedAPIList(string key)
        {
            using (dynamic data = WebAPI.GetInterface("ISteamWebAPIUtil", API.AppKey))
            {
                KeyValue items = data.GetSupportedAPIList(key: key, l: "english");
            }
        }
    }
}
