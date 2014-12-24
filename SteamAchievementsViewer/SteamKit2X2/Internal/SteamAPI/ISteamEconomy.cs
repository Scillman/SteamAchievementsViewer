using SteamKit2;

namespace SteamKit2X2.Internal.SteamAPI
{
    internal sealed class ISteamEconomy
    {
        /// <summary>
        /// 
        /// </summary>
        /// <param name="appid">Must be a steam economy app.</param>
        /// <param name="class_count">Number of classes requested. Must be at least one.</param>
        /// <param name="classid0">Class ID of the nth class.</param>
        public void GetAssetClassInfo(uint appid, uint class_count, ulong classid0)
        {
            using (dynamic data = WebAPI.GetInterface("ISteamEconomy", API.AppKey))
            {
                KeyValue items = data.GetAssetClassInfo(appid: appid, class_count: class_count, classid0: classid0, l: "english");
            }
        }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="appid">Must be a steam economy app.</param>
        /// <param name="class_count">Number of classes requested. Must be at least one.</param>
        /// <param name="classid0">Class ID of the nth class.</param>
        /// <param name="instanceid0">Instance ID of the nth class.</param>
        /// <param name="language">The user's local language</param>
        public void GetAssetClassInfo(uint appid, uint class_count, ulong classid0, ulong instanceid0, string language)
        {
            using (dynamic data = WebAPI.GetInterface("ISteamEconomy", API.AppKey))
            {
                KeyValue items = data.GetAssetClassInfo(appid: appid, language: language, class_count: class_count, classid0: classid0, instanceid0: instanceid0, l: "english");
            }
        }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="appid">Must be a steam economy app.</param>
        public void GetAssetPrices(uint appid)
        {
            using (dynamic data = WebAPI.GetInterface("ISteamEconomy", API.AppKey))
            {
                KeyValue items = data.GetAssetPrices(appid: appid, l: "english");
            }
        }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="appid">Must be a steam economy app.</param>
        /// <param name="currency">The currency to filter for</param>
        /// <param name="language">The user's local language</param>
        public void GetAssetPrices(uint appid, string currency, string language)
        {
            using (dynamic data = WebAPI.GetInterface("ISteamEconomy", API.AppKey))
            {
                KeyValue items = data.GetAssetPrices(appid: appid, currency: currency, language: language, l: "english");
            }
        }
    }
}
