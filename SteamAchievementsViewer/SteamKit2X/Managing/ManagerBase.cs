using SteamKit2;
using SteamKit2X.Exceptions;
using System;
using System.Diagnostics;
using System.Threading;
using AccountInfoCallback = SteamKit2.SteamUser.AccountInfoCallback;
using ConnectedCallback = SteamKit2.SteamClient.ConnectedCallback;
using DisconnectedCallback = SteamKit2.SteamClient.DisconnectedCallback;
using FriendsListCallback = SteamKit2.SteamFriends.FriendsListCallback;
using LoggedOffCallback = SteamKit2.SteamUser.LoggedOffCallback;
using LoggedOnCallback = SteamKit2.SteamUser.LoggedOnCallback;
using PersonaStateCallback = SteamKit2.SteamFriends.PersonaStateCallback;
using UpdateMachineAuthCallback = SteamKit2.SteamUser.UpdateMachineAuthCallback;

/* TODO
 *   - Clean this up.
 *   - Add additional callback methods.
 *   - Remove the locks if no longer needed.
 */
namespace SteamKit2X.Managing
{
    /// <summary>
    /// The base class is responsible for the connection to the Steam network. (Not thread-safe!)
    /// </summary>
    /// <remarks>This class is NOT thread-safe!</remarks>
    public abstract partial class ManagerBase
    {
        /// <summary>
        /// Indicates whether the manager thread is running or not.
        /// </summary>
        protected bool IsRunning { get; set; }

        /// <summary>
        /// The manager thread.
        /// </summary>
        private Thread managerThread;

        /// <summary>
        /// Indicates whether or not the resources have been disposed.
        /// </summary>
        protected bool Disposed { get; private set; }

        /// <summary>
        /// Creates a new manager base.
        /// </summary>
        protected ManagerBase()
        {
            IsRunning = false;
            Disposed = true; // The resources are not yet set, so they are disposed.
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
            managerThread.Name = "Manager Thread";
            managerThread.Start();
        }

        /// <summary>
        /// This is the actual thread method.
        /// </summary>
        private void Run()
        {
            try
            {
                // Indicates the manager thread is running.
                IsRunning = true;

                // First initialize all the variables.
                Initialize();

                // Do the actual work.
                DoWork();
            }
            catch (Exception ex)
            {
                Debug.WriteLine(ex.Message);
            }
            finally
            {
                // Release all the used resources.
                Dispose();
            }

#if DEBUG
            // Give a message so we know it has quited.
            Debug.WriteLine("Manager thread quited!");
#endif
        }

        /// <summary>
        /// Initialize for a new execution.
        /// </summary>
        private void Initialize()
        {
            // SteamKit2
            steamClient = new SteamClient();
            callbackManager = new CallbackManager(steamClient);
            steamUser = steamClient.GetHandler<SteamUser>();
            steamFriends = steamClient.GetHandler<SteamFriends>();

            // Register the callbacks
            callbackManager.Register(new Callback<ConnectedCallback>(OnConnected));
            callbackManager.Register(new Callback<DisconnectedCallback>(OnDisconnected));
            callbackManager.Register(new Callback<LoggedOnCallback>(OnLoggedOn));
            callbackManager.Register(new Callback<LoggedOffCallback>(OnLoggedOff));
            callbackManager.Register(new Callback<UpdateMachineAuthCallback>(OnMachineAuth));
            callbackManager.Register(new Callback<AccountInfoCallback>(OnAccountInfo));
            callbackManager.Register(new Callback<FriendsListCallback>(OnFriendsList));
            callbackManager.Register(new Callback<PersonaStateCallback>(OnPersonaState));
        }

        /// <summary>
        /// This does the actual work on the manager thread.
        /// </summary>
        private void DoWork()
        {
            // Connect to the Steam network.
            steamClient.Connect();

            do
            {
                // Wait 1 second between receiving callbacks.
                callbackManager.RunWaitCallbacks(TimeSpan.FromSeconds(1));
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
            steamUser.LogOff();
            steamUser = null;

            // Disconnect from the Steam network.
            steamClient.Disconnect();
            steamClient = null;

            // Release the references to the remaining SteamKit2 objects.
            steamFriends = null;
            callbackManager = null;

            // Release the reference to this thread, it has stopped and change the running state aswell.
            managerThread = null;
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
