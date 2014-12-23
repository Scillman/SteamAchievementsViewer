﻿using SteamKit2;

namespace SteamKit2X2.Internal.SteamAPI
{
    internal class ISteamPayPalPaymentsHub
    {
        /// <summary>
        /// 
        /// </summary>
        /// <remarks>POST</remarks>
        public void PayPalPaymentsHubPaymentNotification()
        {
            using (dynamic data = WebAPI.GetInterface("ISteamPayPalPaymentsHub", API.AppKey))
            {
                KeyValue items = data.PayPalPaymentsHubPaymentNotification(l: "english");
            }
        }
    }
}
