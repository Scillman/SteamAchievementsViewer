using SteamKit2;

namespace SteamKit2X2.Internal.SteamAPI
{
    internal class ISteamCDN
    {
        /// <summary>
        /// 
        /// </summary>
        /// <param name="key">access key</param>
        /// <param name="cdnname">Steam name of CDN property</param>
        public void SetClientFilters(string key, string cdnname)
        {
            using (dynamic data = WebAPI.GetInterface("ISteamCDN", API.AppKey))
            {
                KeyValue items = data.SetClientFilters(key: key, cdnname: cdnname, l: "english");
            }
        }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="key">access key</param>
        /// <param name="cdnname">Steam name of CDN property</param>
        /// <param name="allowedipblocks">comma-separated list of allowed IP address blocks in CIDR format - blank for not used</param>
        /// <param name="allowedasns">comma-separated list of allowed client network AS numbers - blank for not used</param>
        /// <param name="allowedipcountries">comma-separated list of allowed client IP country codes in ISO 3166-1 format - blank for not used</param>
        public void SetClientFilters(string key, string cdnname, string allowedipblocks, string allowedasns, string allowedipcountries)
        {
            using (dynamic data = WebAPI.GetInterface("ISteamCDN", API.AppKey))
            {
                KeyValue items = data.SetClientFilters(key: key, cdnname: cdnname, allowedipblocks: allowedipblocks, allowedasns: allowedasns, allowedipcountries: allowedipcountries, l: "english");
            }
        }
    }
}
