using SteamKit2;

namespace SteamKit2X2.Internal.SteamAPI
{
    /// <summary>
    /// Team Fortress 2
    /// </summary>
    internal sealed class IGCVersion_440 : IGCVersion
    {
        /// <summary>
        /// 
        /// </summary>
        public void GetClientVersion()
        {
            using (dynamic data = WebAPI.GetInterface("IGCVersion_440", API.AppKey))
            {
                KeyValue items = data.GetClientVersion(l: "english");
            }
        }

        /// <summary>
        /// 
        /// </summary>
        public void GetServerVersion()
        {
            using (dynamic data = WebAPI.GetInterface("IGCVersion_440", API.AppKey))
            {
                KeyValue items = data.GetServerVersion(l: "english");
            }
        }
    }
}
