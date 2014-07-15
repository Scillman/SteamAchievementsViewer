using SteamKit2;
using SteamKit2X.Managing.Events;
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
            {
                // First do the user code.
                InvokeEvent(Connected, new ConnectionEventArgs(true, "Connected successfully."));

                // Then continue with our code.
                SteamManager_Connected();
            }
            else
            {
                // Raise the failed event when unsuccessfull.
                InvokeEvent(ConnectionFailed, new ConnectionEventArgs(false, "Could not connect to the Steam network."));
            }
        }

        /// <summary>
        /// Called when the client has disconnected from the Steam network.
        /// </summary>
        /// <param name="callback"></param>
        protected override void OnDisconnected(DisconnectedCallback callback)
        {
            InvokeEvent(Disconnected, new ConnectionEventArgs(true, "Disconnected successfully."));
        }

        /// <summary>
        /// Called when we have successfully connected to the Steam servers.
        /// </summary>
        public event Action<ConnectionEventArgs> Connected;

        /// <summary>
        /// Called when the connection to the Steam network failed.
        /// </summary>
        public event Action<ConnectionEventArgs> ConnectionFailed;

        /// <summary>
        /// Called when we have successfully disconnected from the Steam servers.
        /// </summary>
        public event Action<ConnectionEventArgs> Disconnected;
    }
}
