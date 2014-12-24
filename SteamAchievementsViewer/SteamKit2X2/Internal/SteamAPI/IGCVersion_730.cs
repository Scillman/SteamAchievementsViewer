using SteamKit2;

namespace SteamKit2X2.Internal.SteamAPI
{
    /// <summary>
    /// Counter-Strike: Global Offensive
    /// </summary>
    internal sealed class IGCVersion_730 : IGCVersion
    {
        /// <summary>
        /// 
        /// </summary>
        public void GetServerVersion()
        {
            using (dynamic data = WebAPI.GetInterface("IGCVersion_730", API.AppKey))
            {
                KeyValue items = data.GetServerVersion(l: "english");
            }
        }
    }
}
