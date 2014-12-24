using SteamKit2;

namespace SteamKit2X2.Internal.SteamAPI
{
    internal sealed class ISteamDirectory
    {
        /// <summary>
        /// 
        /// </summary>
        /// <param name="cellid">Client's Steam cell ID</param>
        /// <remarks>NO KEY</remarks>
        public void GetCMList(uint cellid)
        {
            using (dynamic data = WebAPI.GetInterface("ISteamDirectory", API.AppKey))
            {
                KeyValue items = data.GetCMList(cellid: cellid, l: "english");
            }
        }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="cellid">Client's Steam cell ID</param>
        /// <param name="maxcount">Max number of servers to return</param>
        /// <remarks>NO KEY</remarks>
        public void GetCMList(uint cellid, uint maxcount)
        {
            using (dynamic data = WebAPI.GetInterface("ISteamDirectory", API.AppKey))
            {
                KeyValue items = data.GetCMList(cellid: cellid, maxcount: maxcount, l: "english");
            }
        }
    }
}
