using SteamKit2;
using SteamKit2X.Exceptions;
using System;
using System.Threading;
using AccountInfoCallback = SteamKit2.SteamUser.AccountInfoCallback;
using ConnectedCallback = SteamKit2.SteamClient.ConnectedCallback;
using DisconnectedCallback = SteamKit2.SteamClient.DisconnectedCallback;
using FriendsListCallback = SteamKit2.SteamFriends.FriendsListCallback;
using LoggedOffCallback = SteamKit2.SteamUser.LoggedOffCallback;
using LoggedOnCallback = SteamKit2.SteamUser.LoggedOnCallback;
using PersonaStateCallback = SteamKit2.SteamFriends.PersonaStateCallback;
using UpdateMachineAuthCallback = SteamKit2.SteamUser.UpdateMachineAuthCallback;

namespace SteamKit2X.Managing
{
    /// <summary>
    /// The base class is responsible for the connection to the Steam network.
    /// </summary>
    public abstract class ManagerBase
    {
        /// <summary>
        /// Indicates whether the manager thread is running or not.
        /// </summary>
        protected bool IsRunning { get; private set; }

        /// <summary>
        /// The manager thread.
        /// </summary>
        private Thread managerThread;

        /**
         * SteamKit2 objects.
         */
        private SteamClient client;
        private CallbackManager manager;
        private SteamUser user;
        private SteamFriends friends;

        /// <summary>
        /// Creates a new manager base.
        /// </summary>
        protected ManagerBase()
        {
            IsRunning = false;
        }

        /// <summary>
        /// Start the manager thread.
        /// </summary>
        /// <exception cref="SteamKit2X.Exceptions.ManagerRunningException"/>
        protected void Start()
        {
            // Only create a new thread when it does not yet exist.
            if (managerThread != null)
                throw new ManagerRunningException("The manager thread is already running.");

            // Create and start the thread.
            managerThread = new Thread(() => Run());
            managerThread.Start();
        }

        /// <summary>
        /// This is the actual thread method.
        /// </summary>
        private void Run()
        {
            // First initialize all the variables.
            Initialize();

            // Do the actual work.
            DoWork();

            // Release all the used resources.
            Dispose();
        }

        /// <summary>
        /// Initialize for a new execution.
        /// </summary>
        private void Initialize()
        {
            // SteamKit2
            client = new SteamClient();
            manager = new CallbackManager(client);
            user = client.GetHandler<SteamUser>();
            friends = client.GetHandler<SteamFriends>();

            // Register the callbacks
            manager.Register(new Callback<ConnectedCallback>(OnConnected));
            manager.Register(new Callback<DisconnectedCallback>(OnDisconnected));
            manager.Register(new Callback<LoggedOnCallback>(OnLoggedOn));
            manager.Register(new Callback<LoggedOffCallback>(OnLoggedOff));
            manager.Register(new Callback<UpdateMachineAuthCallback>(OnMachineAuth));
            manager.Register(new Callback<AccountInfoCallback>(OnAccountInfo));
            manager.Register(new Callback<FriendsListCallback>(OnFriendsList));
            manager.Register(new Callback<PersonaStateCallback>(OnPersonaState));
        }

        /// <summary>
        /// This does the actual work on the manager thread.
        /// </summary>
        private void DoWork()
        {
            // Connect to the Steam network when not yet connected.
            if (!client.IsConnected)
                client.Connect();

            do
            {
                // Wait 1 second between receiving callbacks.
                manager.RunWaitCallbacks(TimeSpan.FromSeconds(1));
            }
            while (IsRunning);
        }

        /// <summary>
        /// Dispose of the used resources.
        /// </summary>
        private void Dispose()
        {
            // Log the user off.
            if (user != null)
            {
                user.LogOff();
                user = null;
            }

            // Disconnect from the Steam network.
            if (client != null)
            {
                client.Disconnect();
                client = null;
            }

            // Release the references to the remaining SteamKit2 objects.
            friends = null;
            manager = null;

            // Release the reference to this thread, it has stopped and change the running state aswell.
            managerThread = null;
            IsRunning = false;
        }

        #region Callbacks
        #region Connection
        /// <summary>
        /// Called when the client has connected to the Steam network.
        /// </summary>
        /// <param name="callback"></param>
        protected abstract void OnConnected(ConnectedCallback callback);

        /// <summary>
        /// Called when the client has disconnected from the Steam network.
        /// </summary>
        /// <param name="callback"></param>
        protected virtual void OnDisconnected(DisconnectedCallback callback)
        {
            // When disconnected we should stop listening for callbacks.
            IsRunning = false;
        }
        #endregion // Connection

        #region User
        /// <summary>
        /// Called when an user has logged on to the Steam network.
        /// </summary>
        /// <param name="callback"></param>
        protected abstract void OnLoggedOn(LoggedOnCallback callback);

        /// <summary>
        /// Called when an user has logged off the Steam network.
        /// </summary>
        /// <param name="callback"></param>
        protected abstract void OnLoggedOff(LoggedOffCallback callback);
        #endregion // User

        #region Authentication
        /// <summary>
        /// Called when the machine's authentication data has to be updated.
        /// </summary>
        /// <param name="callback"></param>
        protected abstract void OnMachineAuth(UpdateMachineAuthCallback callback);
        #endregion // Authentication

        #region Friendslist
        /// <summary>
        /// Called shortly after the user has logged on.
        /// </summary>
        /// <param name="callback"></param>
        protected abstract void OnAccountInfo(AccountInfoCallback callback);

        /// <summary>
        /// Called when the friendslist has been received.
        /// </summary>
        /// <param name="callback"></param>
        protected abstract void OnFriendsList(FriendsListCallback callback);

        /// <summary>
        /// Called when the information of a friend has changed.
        /// </summary>
        /// <param name="callback"></param>
        protected abstract void OnPersonaState(PersonaStateCallback callback);
        #endregion // Friendslist
        #endregion // Callbacks
    }
}
