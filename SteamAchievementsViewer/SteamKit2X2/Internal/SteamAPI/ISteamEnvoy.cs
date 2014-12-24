using SteamKit2;

namespace SteamKit2X2.Internal.SteamAPI
{
    internal sealed class ISteamEnvoy
    {
        /// <summary>
        /// 
        /// </summary>
        /// <remarks>POST</remarks>
        /// <remarks>NO KEY</remarks>
        public void PaymentOutNotification()
        {
            using (dynamic data = WebAPI.GetInterface("ISteamEnvoy", API.AppKey))
            {
                KeyValue items = data.PaymentOutNotification(l: "english");
            }
        }

        /// <summary>
        /// 
        /// </summary>
        /// <remarks>POST</remarks>
        /// <remarks>NO KEY</remarks>
        public void PaymentOutReversalNotification()
        {
            using (dynamic data = WebAPI.GetInterface("ISteamEnvoy", API.AppKey))
            {
                KeyValue items = data.PaymentOutReversalNotification(l: "english");
            }
        }
    }
}
