using SteamKit2;

namespace SteamKit2X2.Internal.SteamAPI
{
    /// <summary>
    /// Dota 2 Test
    /// </summary>
    internal class IGCVersion_205790 : IGCVersion
    {
        /// <summary>
        /// 
        /// </summary>
        public void GetClientVersion()
        {
            using (dynamic data = WebAPI.GetInterface("IGCVersion_205790", API.AppKey))
            {
                KeyValue items = data.GetClientVersion(l: "english");
            }
        }

        /// <summary>
        /// 
        /// </summary>
        public void GetServerVersion()
        {
            using (dynamic data = WebAPI.GetInterface("IGCVersion_205790", API.AppKey))
            {
                KeyValue items = data.GetServerVersion(l: "english");
            }
        }
    }
}
