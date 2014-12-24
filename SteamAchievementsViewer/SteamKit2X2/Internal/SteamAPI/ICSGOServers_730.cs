using SteamKit2;

namespace SteamKit2X2.Internal.SteamAPI
{
    /// <summary>
    /// Counter-Strike: Global Offensive
    /// </summary>
    internal sealed class ICSGOServers_730
    {
        /// <summary>
        /// 
        /// </summary>
        public void GetGameServersStatus()
        {
            using (dynamic data = WebAPI.GetInterface("ICSGOServers_730", API.AppKey))
            {
                KeyValue items = data.GetGameServersStatus(l: "english");
            }
        }
    }
}
