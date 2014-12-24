using SteamKit2;

namespace SteamKit2X2.Internal.SteamAPI
{
    internal sealed class ISteamRemoteStorage
    {
        /// <summary>
        /// 
        /// </summary>
        /// <param name="collectioncount">Number of collections being requested</param>
        /// <param name="publishedfileids">collection ids to get the details for</param>
        /// <remarks>POST</remarks>
        public void GetCollectionDetails(uint collectioncount, ulong[] publishedfileids)
        {
            using (dynamic data = WebAPI.GetInterface("ISteamRemoteStorage", API.AppKey))
            {
                KeyValue items = data.GetCollectionDetails(collectioncount: collectioncount, publishedfileids: publishedfileids, l: "english");
            }
        }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="itemcount">Number of items being requested</param>
        /// <param name="publishedfileids">published file id to look up</param>
        public void GetPublishedFileDetails(uint itemcount, ulong[] publishedfileids)
        {
            using (dynamic data = WebAPI.GetInterface("ISteamRemoteStorage", API.AppKey))
            {
                KeyValue items = data.GetPublishedFileDetails(itemcount: itemcount, publishedfileids: publishedfileids, l: "english");
            }
        }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="ugcid">ID of UGC file to get info for</param>
        /// <param name="appid">appID of product</param>
        public void GetUGCFileDetails(ulong ugcid, uint appid)
        {
            using (dynamic data = WebAPI.GetInterface("ISteamRemoteStorage", API.AppKey))
            {
                KeyValue items = data.GetUGCFileDetails(ugcid: ugcid, appid: appid, l: "english");
            }
        }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="ugcid">ID of UGC file to get info for</param>
        /// <param name="appid">appID of product</param>
        /// <param name="steamid">If specified, only returns details if the file is owned by the SteamID specified</param>
        public void GetUGCFileDetails(ulong ugcid, uint appid, ulong steamid)
        {
            using (dynamic data = WebAPI.GetInterface("ISteamRemoteStorage", API.AppKey))
            {
                KeyValue items = data.GetUGCFileDetails(ugcid: ugcid, appid: appid, steamid: steamid, l: "english");
            }
        }
    }
}
