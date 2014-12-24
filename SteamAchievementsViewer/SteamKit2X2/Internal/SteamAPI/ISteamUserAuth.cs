using SteamKit2;

namespace SteamKit2X2.Internal.SteamAPI
{
    internal sealed class ISteamUserAuth
    {
        /// <summary>
        /// 
        /// </summary>
        /// <param name="steamid">Should be the users steamid, unencrypted.</param>
        /// <param name="sessionkey">Should be a 32 byte random blob of data, which is then encrypted with RSA using the Steam system's public key.  Randomness is important here for security.</param>
        /// <param name="encrypted_loginkey">Should be the users hashed loginkey, AES encrypted with the sessionkey.</param>
        /// <remarks>POST</remarks>
        public void AuthenticateUser(ulong steamid, byte[] sessionkey, byte[] encrypted_loginkey)
        {
            using (dynamic data = WebAPI.GetInterface("ISteamUserAuth", API.AppKey))
            {
                KeyValue items = data.AuthenticateUser(steamid: steamid, sessionkey: sessionkey, encrypted_loginkey: encrypted_loginkey, l: "english");
            }
        }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="key">access key</param>
        /// <param name="appid">appid of game</param>
        /// <param name="ticket">Ticket from GetAuthSessionTicket.</param>
        public void AuthenticateUserTicket(string key, uint appid, string ticket)
        {
            using (dynamic data = WebAPI.GetInterface("ISteamUserAuth", API.AppKey))
            {
                KeyValue items = data.AuthenticateUserTicket(key: key, appid: appid, ticket: ticket, l: "english");
            }
        }
    }
}
