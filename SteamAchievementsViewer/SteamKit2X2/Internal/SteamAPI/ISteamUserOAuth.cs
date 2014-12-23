using SteamKit2;

namespace SteamKit2X2.Internal.SteamAPI
{
    internal class ISteamUserOAuth
    {
        /// <summary>
        /// 
        /// </summary>
        /// <param name="access_token">OAuth2 token for which to return details</param>
        public void GetTokenDetails(string access_token)
        {
            using (dynamic data = WebAPI.GetInterface("ISteamUserOAuth", API.AppKey))
            {
                KeyValue items = data.GetTokenDetails(access_token: access_token, l: "english");
            }
        }
    }
}
