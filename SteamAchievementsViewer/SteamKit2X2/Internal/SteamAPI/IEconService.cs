using SteamKit2;

namespace SteamKit2X2.Internal.SteamAPI
{
    internal class IEconService
    {
        /// <summary>
        /// Get a list of sent or received trade offers
        /// </summary>
        /// <param name="key">Access key</param>
        /// <param name="get_sent_offers">Request the list of sent offers.</param>
        /// <param name="get_received_offers">Request the list of received offers.</param>
        /// <param name="get_descriptions">If set, the item display data for the items included in the returned trade offers will also be returned.</param>
        /// <param name="language">The language to use when loading item display data.</param>
        /// <param name="active_only">Indicates we should only return offers which are still active, or offers that have changed in state since the time_historical_cutoff</param>
        /// <param name="historical_only">Indicates we should only return offers which are not active.</param>
        /// <param name="time_historical_cutoff">When active_only is set, offers updated since this time will also be returned</param>
        public void GetTradeOffers(string key, bool get_sent_offers, bool get_received_offers, bool get_descriptions, string language,
            bool active_only, bool historical_only, uint time_historical_cutoff)
        {
            using (dynamic data = WebAPI.GetInterface("IEconService", API.AppKey))
            {
                KeyValue items = data.GetTradeOffers(key: key, get_sent_offers: get_sent_offers, get_received_offers: get_received_offers, get_descriptions: get_descriptions, language: language, active_only: active_only, historical_only: historical_only, time_historical_cutoff: time_historical_cutoff, l: "english");
            }
        }

        /// <summary>
        /// Gets a specific trade offer
        /// </summary>
        /// <param name="key">Access key</param>
        /// <param name="tradeofferid"></param>
        /// <param name="language"></param>
        public void GetTradeOffer(string key, ulong tradeofferid, string language)
        {
            using (dynamic data = WebAPI.GetInterface("IEconService", API.AppKey))
            {
                KeyValue items = data.GetTradeOffer(key: key, tradeofferid: tradeofferid, language: language, l: "english");
            }
        }

        /// <summary>
        /// Get counts of pending and new trade offers
        /// </summary>
        /// <param name="key">Access key</param>
        /// <param name="time_last_visit">The time the user last visited.  If not passed, will use the time the user last visited the trade offer page.</param>
        public void GetTradeOffersSummary(string key, uint time_last_visit)
        {
            using (dynamic data = WebAPI.GetInterface("IEconService", API.AppKey))
            {
                KeyValue items = data.GetTradeOffersSummary(key: key, time_last_visit: time_last_visit, l: "english");
            }
        }

        /// <summary>
        /// Decline a trade offer someone sent to us
        /// </summary>
        /// <param name="key">Access key</param>
        /// <param name="tradeofferid"></param>
        /// <remarks>POST</remarks>
        public void DeclineTradeOffer(string key, ulong tradeofferid)
        {
            using (dynamic data = WebAPI.GetInterface("IEconService", API.AppKey))
            {
                KeyValue items = data.DeclineTradeOffer(key: key, tradeofferid: tradeofferid, l: "english");
            }
        }

        /// <summary>
        /// Cancel a trade offer we sent
        /// </summary>
        /// <param name="key">Access key</param>
        /// <param name="tradeofferid"></param>
        public void CancelTradeOffer(string key, ulong tradeofferid)
        {
            using (dynamic data = WebAPI.GetInterface("IEconService", API.AppKey))
            {
                KeyValue items = data.CancelTradeOffer(key: key, tradeofferid: tradeofferid, l: "english");
            }
        }
    }
}
