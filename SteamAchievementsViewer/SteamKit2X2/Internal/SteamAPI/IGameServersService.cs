using SteamKit2;

/**
 * Seems like a Valve only interface; please verify.
 *  IT IS NOT VALVE ONLY, IT ALLOWS NORMAL USERS TO CREATE A SPECIAL SERVER ACCOUNT USING THEIR WEB-API KEY.
 */
namespace SteamKit2X2.Internal.SteamAPI
{
    internal sealed class IGameServersService
    {
        /// <summary>
        /// Gets a list of game server accounts with their logon tokens
        /// </summary>
        /// <param name="key">Access key</param>
        public void GetAccountList(string key)
        {
            using (dynamic data = WebAPI.GetInterface("IGameServersService", API.AppKey))
            {
                KeyValue items = data.GetAccountList(key: key, l: "english");
            }
        }

        /// <summary>
        /// Creates a persistent game server account
        /// </summary>
        /// <param name="key">Access key</param>
        /// <param name="appid">The app to use the account for</param>
        /// <param name="memo">The memo to set on the new account</param>
        /// <remarks>POST</remarks>
        public void CreateAccount(string key, uint appid, string memo)
        {
            using (dynamic data = WebAPI.GetInterface("IGameServersService", API.AppKey))
            {
                KeyValue items = data.CreateAccount(key: key, appid: appid, memo: memo, l: "english");
            }
        }

        /// <summary>
        /// This method changes the memo associated with the game server account. Memos do not affect the account in any way. The memo shows up in the GetAccountList response and serves only as a reminder of what the account is used for.
        /// </summary>
        /// <param name="key">Access key</param>
        /// <param name="steamid">The SteamID of the game server to set the memo on</param>
        /// <param name="memo">The memo to set on the new account</param>
        /// <remarks>POST</remarks>
        public void SetMemo(string key, ulong steamid, string memo)
        {
            using (dynamic data = WebAPI.GetInterface("IGameServersService", API.AppKey))
            {
                KeyValue items = data.CreateAccount(key: key, steamid: steamid, memo: memo, l: "english");
            }
        }

        /// <summary>
        /// Generates a new login token for the specified game server
        /// </summary>
        /// <param name="key">Access key</param>
        /// <param name="steamid">The SteamID of the game server to reset the login token of</param>
        /// <remarks>POST</remarks>
        public void ResetLoginToken(string key, ulong steamid)
        {
            using (dynamic data = WebAPI.GetInterface("IGameServersService", API.AppKey))
            {
                KeyValue items = data.ResetLoginToken(key: key, steamid: steamid, l: "english");
            }
        }

        /// <summary>
        /// Gets public information about a given game server account
        /// </summary>
        /// <param name="key">Access key</param>
        /// <param name="steamid">The SteamID of the game server to get info on</param>
        public void GetAccountPublicInfo(string key, ulong steamid)
        {
            using (dynamic data = WebAPI.GetInterface("IGameServersService", API.AppKey))
            {
                KeyValue items = data.GetAccountPublicInfo(key: key, steamid: steamid, l: "english");
            }
        }

        /// <summary>
        /// Gets a list of server SteamIDs given a list of IPs
        /// </summary>
        /// <param name="key">Access key</param>
        /// <param name="server_ips"></param>
        public void GetServerSteamIDsByIP(string key, string server_ips)
        {
            using (dynamic data = WebAPI.GetInterface("IGameServersService", API.AppKey))
            {
                KeyValue items = data.GetServerSteamIDsByIP(key: key, server_ips: server_ips, l: "english");
            }
        }

        /// <summary>
        /// Gets a list of server IP addresses given a list of SteamIDs
        /// </summary>
        /// <param name="key">Access key</param>
        /// <param name="server_steamids"></param>
        public void GetServerIPsBySteamID(string key, string server_steamids)
        {
            using (dynamic data = WebAPI.GetInterface("IGameServersService", API.AppKey))
            {
                KeyValue items = data.GetServerIPsBySteamID(key: key, server_steamids: server_steamids, l: "english");
            }
        }
    }
}
