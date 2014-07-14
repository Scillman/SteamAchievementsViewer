using SteamKit2;
using System;
using System.Threading;
using System.Threading.Tasks;
using ConnectedCallback = SteamKit2.SteamClient.ConnectedCallback;
using DisconnectedCallback = SteamKit2.SteamClient.DisconnectedCallback;

namespace SteamKit2X
{
    partial class SteamClient
    {
        /// <summary>
        /// The client that is used to connect to the Steam servers.
        /// </summary>
        private SteamKit2.SteamClient client;

        /// <summary>
        /// The callback manager used for the client.
        /// </summary>
        private CallbackManager manager;

        /// <summary>
        /// Indicates whether or not the connection is running.
        /// </summary>
        private bool running;

        /// <summary>
        /// Intializes the connection with the Steam servers.
        /// </summary>
        private void InitializeConnection()
        {
            // We are not currently running the message loop.
            running = false;

            // Create the new client and manager.
            client = new SteamKit2.SteamClient();
            manager = new CallbackManager(client);

            // Register the connected and disconnected callbacks.
            manager.Register(new Callback<ConnectedCallback>(OnConnected));
            manager.Register(new Callback<DisconnectedCallback>(OnDisconnected));
        }

        /// <summary>
        /// Connect to the Steam servers.
        /// </summary>
        public void Connect()
        {
            // Only connect when not yet connected.
            if (!running)
                running = true;

            // Start handling the messages.
            MessageLoop();
        }

        /// <summary>
        /// Connect to the Steam servers.
        /// </summary>
        /// <param name="username">The username that must used to connect to Steam.</param>
        /// <param name="password">The password that must used to connect to Steam.</param>
        /// <param name="steamGuardCode">The Steam Guard Code that must used to connect to Steam.</param>
        public void Connect(string username, string password, string steamGuardCode = null)
        {
            this.Username = username;
            this.Password = password;
            this.SteamGuardCode = steamGuardCode;
        }

        /// <summary>
        /// The message loop keeps retrieving messages from the Steam client.
        /// </summary>
        private async void MessageLoop()
        {
            // Connect to the Steam servers.
            client.Connect();

            do
            {
                await Task.Run(() => manager.RunWaitCallbacks(TimeSpan.FromSeconds(1)));
            }
            while (running);
        }

        /// <summary>
        /// Called when we have successfully connected to the Steam servers.
        /// </summary>
        public event Action Connected;

        /// <summary>
        /// Called when 
        /// </summary>
        /// <param name="callback"></param>
        protected virtual void OnConnected(ConnectedCallback callback)
        {
            // Only fire the connected event when we have successfully connected.
            if (callback.Result == EResult.OK)
            {
                if (Connected != null)
                {
                    Connected();
                }
            }
        }

        /// <summary>
        /// Called when we have successfully disconnected from the Steam servers.
        /// </summary>
        public event Action Disconnected;

        /// <summary>
        /// Disconnect from the Steam servers.
        /// </summary>
        public void Disconnect()
        {
            // Stop running the messages.
            running = false;
        }

        /// <summary>
        /// Called when the client has been disconnected from the Steam servers.
        /// </summary>
        /// <param name="callback"></param>
        protected virtual void OnDisconnected(DisconnectedCallback callback)
        {
            if (Disconnected != null)
            {
                Disconnected();
            }
        }
    }
}
