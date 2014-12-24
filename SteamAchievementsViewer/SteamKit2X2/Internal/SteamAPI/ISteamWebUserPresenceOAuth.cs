using SteamKit2;

namespace SteamKit2X2.Internal.SteamAPI
{
    internal sealed class ISteamWebUserPresenceOAuth
    {
        /// <summary>
        /// 
        /// </summary>
        /// <param name="steamid">Steam ID of the user</param>
        /// <param name="umqid">UMQ Session ID</param>
        /// <param name="message">Message that was last known to the user</param>
        public void PollStatus(string steamid, ulong umqid, uint message)
        {
            using (dynamic data = WebAPI.GetInterface("ISteamWebUserPresenceOAuth", API.AppKey))
            {
                KeyValue items = data.PollStatus(steamid: steamid, umqid: umqid, message: message, l: "english");
            }
        }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="steamid">Steam ID of the user</param>
        /// <param name="umqid">UMQ Session ID</param>
        /// <param name="message">Message that was last known to the user</param>
        /// <param name="pollid">Caller-specific poll id</param>
        /// <param name="sectimeout">Long-poll timeout in seconds</param>
        /// <param name="secidletime">How many seconds is client considering itself idle, e.g. screen is off</param>
        /// <param name="use_accountids">Boolean, 0 (default): return steamid_from in output, 1: return accountid_from</param>
        public void PollStatus(string steamid, ulong umqid, uint message, uint pollid, uint sectimeout, uint secidletime, uint use_accountids)
        {
            using (dynamic data = WebAPI.GetInterface("ISteamWebUserPresenceOAuth", API.AppKey))
            {
                KeyValue items = data.PollStatus(steamid: steamid, umqid: umqid, message: message, pollid: pollid, sectimeout: sectimeout, secidletime: secidletime, use_accountids: use_accountids, l: "english");
            }
        }
    }
}
