using SteamKit2;

namespace SteamKit2X2.Internal.SteamAPI
{
    /// <summary>
    /// Team Fortress 2
    /// </summary>
    internal sealed class ITFItems_440
    {
        /// <summary>
        /// 
        /// </summary>
        public void GetGoldenWrenches2()
        {
            using (dynamic data = WebAPI.GetInterface("ITFItems_440", API.AppKey))
            {
                KeyValue items = data.GetGoldenWrenches2(l: "english");
            }
        }
    }
}
