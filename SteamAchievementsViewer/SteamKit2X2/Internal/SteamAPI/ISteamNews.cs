using SteamKit2;
using System;

namespace SteamKit2X2.Internal.SteamAPI
{
    internal sealed class ISteamNews
    {
        /// <summary>
        /// 
        /// </summary>
        /// <param name="appid">AppID to retrieve news for</param>
        /// <remarks>NO KEY</remarks>
        [Obsolete("Use GetNewsForApp2 instead.")]
        public void GetNewsForApp(uint appid)
        {
            using (dynamic data = WebAPI.GetInterface("ISteamNews", API.AppKey))
            {
                KeyValue items = data.GetNewsForApp(appid: appid, l: "english");
            }
        }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="appid">AppID to retrieve news for</param>
        /// <param name="maxlength">Maximum length for the content to return, if this is 0 the full content is returned, if it's less then a blurb is generated to fit.</param>
        /// <param name="enddate">Retrieve posts earlier than this date (unix epoch timestamp)</param>
        /// <param name="count"># of posts to retrieve (default 20)</param>
        /// <remarks>NO KEY</remarks>
        [Obsolete("Use GetNewsForApp2 instead.")]
        public void GetNewsForApp(uint appid, uint maxlength, uint enddate, uint count)
        {
            using (dynamic data = WebAPI.GetInterface("ISteamNews", API.AppKey))
            {
                KeyValue items = data.GetNewsForApp(appid: appid, maxlength: maxlength, enddate: enddate, count: count, l: "english");
            }
        }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="appid">AppID to retrieve news for</param>
        /// <remarks>NO KEY</remarks>
        public void GetNewsForApp2(uint appid)
        {
            using (dynamic data = WebAPI.GetInterface("ISteamNews", API.AppKey))
            {
                KeyValue items = data.GetNewsForApp2(appid: appid, l: "english");
            }
        }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="appid">AppID to retrieve news for</param>
        /// <param name="maxlength">Maximum length for the content to return, if this is 0 the full content is returned, if it's less then a blurb is generated to fit.</param>
        /// <param name="enddate">Retrieve posts earlier than this date (unix epoch timestamp)</param>
        /// <param name="count"># of posts to retrieve (default 20)</param>
        /// <param name="feeds">Comma-seperated list of feed names to return news for</param>
        /// <remarks>NO KEY</remarks>
        public void GetNewsForApp2(uint appid, uint maxlength, uint enddate, uint count, string feeds)
        {
            using (dynamic data = WebAPI.GetInterface("ISteamNews", API.AppKey))
            {
                KeyValue items = data.GetNewsForApp2(appid: appid, maxlength: maxlength, enddate: enddate, count: count, feeds: feeds, l: "english");
            }
        }
    }
}
