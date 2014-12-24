using SteamKit2;

namespace SteamKit2X2.Internal.SteamAPI
{
    internal sealed class ISteamPayPalPaymentsHub
    {
        /// <summary>
        /// 
        /// </summary>
        /// <remarks>POST</remarks>
        /// <remarks>NO KEY</remarks>
        public void PayPalPaymentsHubPaymentNotification()
        {
            using (dynamic data = WebAPI.GetInterface("ISteamPayPalPaymentsHub", API.AppKey))
            {
                KeyValue items = data.PayPalPaymentsHubPaymentNotification(l: "english");
            }
        }
    }
}
