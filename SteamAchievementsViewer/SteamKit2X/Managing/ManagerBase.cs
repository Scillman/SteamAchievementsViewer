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
    /// <remarks>This class is NOT thread-safe!</remarks>
    public abstract partial class ManagerBase
    {
        /// <summary>
        /// Indicates whether the manager thread is running or not.
        /// </summary>
        protected bool IsRunning { get; private set; }

        /// <summary>
        /// The manager thread.
        /// </summary>
        private Thread managerThread;

        /// <summary>
        /// Indicates whether or not the resources have been disposed.
        /// </summary>
        private bool Disposed { get; set; }

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
            // Ensure the manager thread is not already running.
            if (managerThread != null || IsRunning)
                throw new ManagerRunningException("The manager thread is already running.");

            // When the resource have not been disposed, dispose them now.
            if (!Disposed)
                Dispose();
            Disposed = false;

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
            this.SteamClient = new SteamClient();
            this.CallbackManager = new CallbackManager(this.SteamClient);
            this.SteamUser = this.SteamClient.GetHandler<SteamUser>();
            this.SteamFriends = this.SteamClient.GetHandler<SteamFriends>();

            // Register the callbacks
            this.CallbackManager.Register(new Callback<ConnectedCallback>(OnConnected));
            this.CallbackManager.Register(new Callback<DisconnectedCallback>(OnDisconnected));
            this.CallbackManager.Register(new Callback<LoggedOnCallback>(OnLoggedOn));
            this.CallbackManager.Register(new Callback<LoggedOffCallback>(OnLoggedOff));
            this.CallbackManager.Register(new Callback<UpdateMachineAuthCallback>(OnMachineAuth));
            this.CallbackManager.Register(new Callback<AccountInfoCallback>(OnAccountInfo));
            this.CallbackManager.Register(new Callback<FriendsListCallback>(OnFriendsList));
            this.CallbackManager.Register(new Callback<PersonaStateCallback>(OnPersonaState));
        }

        /// <summary>
        /// This does the actual work on the manager thread.
        /// </summary>
        private void DoWork()
        {
            // Connect to the Steam network when not yet connected.
            if (!this.SteamClient.IsConnected)
                this.SteamClient.Connect();

            do
            {
                // Wait 1 second between receiving callbacks.
                this.CallbackManager.RunWaitCallbacks(TimeSpan.FromSeconds(1));
            }
            while (IsRunning);
        }

        /// <summary>
        /// Dispose of the used resources.
        /// </summary>
        private void Dispose()
        {
            // Notify about the disposed resources.
            Disposed = true;

            // Log the user off.
            lock (_steamUserLock)
            {
                if (_steamUser != null)
                {
                    _steamUser.LogOff();
                    _steamUser = null;
                }
            }

            // Disconnect from the Steam network.
            lock (_steamClientLock)
            {
                if (_steamClient != null)
                {
                    _steamClient.Disconnect();
                    _steamClient = null;
                }
            }

            // Release the references to the remaining SteamKit2 objects.
            lock (_steamFriendsLock)
            {
                _steamFriends = null;
            }
            this.CallbackManager = null;

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
