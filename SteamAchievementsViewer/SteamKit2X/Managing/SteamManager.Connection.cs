using SteamKit2;
using System;
using ConnectedCallback = SteamKit2.SteamClient.ConnectedCallback;
using DisconnectedCallback = SteamKit2.SteamClient.DisconnectedCallback;

/* CONNECTION
 *   Turns the callbacks into thread-safe events.
 */
namespace SteamKit2X.Managing
{
    partial class SteamManager
    {
        /// <summary>
        /// Called when the client has connected to the Steam network.
        /// </summary>
        /// <param name="callback"></param>
        protected override void OnConnected(ConnectedCallback callback)
        {
            // Raise the connected event only when actually connected.
            if (callback.Result == EResult.OK)
                InvokeEvent(Connected);
        }

        /// <summary>
        /// Called when the client has disconnected from the Steam network.
        /// </summary>
        /// <param name="callback"></param>
        protected override void OnDisconnected(DisconnectedCallback callback)
        {
            InvokeEvent(Disconnected);
        }

        /// <summary>
        /// Called when we have successfully connected to the Steam servers.
        /// </summary>
        public event Action<EventArgs> Connected;

        /// <summary>
        /// Called when we have successfully disconnected from the Steam servers.
        /// </summary>
        public event Action<EventArgs> Disconnected;
    }
}
