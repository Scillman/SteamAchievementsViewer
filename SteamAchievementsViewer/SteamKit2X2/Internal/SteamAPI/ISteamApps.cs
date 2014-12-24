using SteamKit2;
using System;

namespace SteamKit2X2.Internal.SteamAPI
{
    internal sealed class ISteamApps
    {
        /// <summary>
        /// 
        /// </summary>
        [Obsolete("Use GetAppList2 instead.")]
        public void GetAppList()
        {
            using (dynamic data = WebAPI.GetInterface("ISteamApps", API.AppKey))
            {
                KeyValue items = data.GetAppList(l: "english");
            }
        }

        /// <summary>
        /// 
        /// </summary>
        public void GetAppList2()
        {
            using (dynamic data = WebAPI.GetInterface("ISteamApps", API.AppKey))
            {
                KeyValue items = data.GetAppList2(l: "english");
            }
        }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="addr">IP or IP:queryport to list</param>
        public void GetServersAtAddress(string addr)
        {
            using (dynamic data = WebAPI.GetInterface("ISteamApps", API.AppKey))
            {
                KeyValue items = data.GetServersAtAddress(addr: addr, l: "english");
            }
        }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="appid">AppID of game</param>
        /// <param name="version">The installed version of the game</param>
        public void UpToDateCheck(uint appid, uint version)
        {
            using (dynamic data = WebAPI.GetInterface("ISteamApps", API.AppKey))
            {
                KeyValue items = data.UpToDateCheck(appid: appid, version: version, l: "english");
            }
        }
    }
}
