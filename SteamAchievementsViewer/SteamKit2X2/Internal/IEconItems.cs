
namespace SteamKit2X2.Internal
{
    public interface IEconItems
    {
        /// <summary>
        /// 
        /// </summary>
        /// <param name="steamid">The Steam ID to fetch items for</param>
        void GetPlayerItems(ulong steamid);
    }
}
