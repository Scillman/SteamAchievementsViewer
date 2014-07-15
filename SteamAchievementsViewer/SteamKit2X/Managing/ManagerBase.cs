using SteamKit2;
using SteamKit2X.Exceptions;
using System;
using System.Diagnostics;
using System.Threading;
// SteamKit2 Callbacks
using AccountInfoCallback       = SteamKit2.SteamUser.AccountInfoCallback;
using BaseJobCallback           = SteamKit2.SteamClient.BaseJobCallback;
using ChatActionResultCallback  = SteamKit2.SteamFriends.ChatActionResultCallback;
using ChatEnterCallback         = SteamKit2.SteamFriends.ChatEnterCallback;
using ChatInviteCallback        = SteamKit2.SteamFriends.ChatInviteCallback;
using ChatMemberInfoCallback    = SteamKit2.SteamFriends.ChatMemberInfoCallback;
using ChatMsgCallback           = SteamKit2.SteamFriends.ChatMsgCallback;
using ClanStateCallback         = SteamKit2.SteamFriends.ClanStateCallback;
using CMListCallback            = SteamKit2.SteamClient.CMListCallback;
using ConnectedCallback         = SteamKit2.SteamClient.ConnectedCallback;
using DisconnectedCallback      = SteamKit2.SteamClient.DisconnectedCallback;
using FriendAddedCallback       = SteamKit2.SteamFriends.FriendAddedCallback;
using FriendMsgCallback         = SteamKit2.SteamFriends.FriendMsgCallback;
using FriendsListCallback       = SteamKit2.SteamFriends.FriendsListCallback;
using IgnoreFriendCallback      = SteamKit2.SteamFriends.IgnoreFriendCallback;
using LoggedOffCallback         = SteamKit2.SteamUser.LoggedOffCallback;
using LoggedOnCallback          = SteamKit2.SteamUser.LoggedOnCallback;
using MarketingMessageCallback  = SteamKit2.SteamUser.MarketingMessageCallback;
using PersonaStateCallback      = SteamKit2.SteamFriends.PersonaStateCallback;
using ProfileInfoCallback       = SteamKit2.SteamFriends.ProfileInfoCallback;
using ServerListCallback        = SteamKit2.SteamClient.ServerListCallback;
using SessionTokenCallback      = SteamKit2.SteamUser.SessionTokenCallback;
using UpdateMachineAuthCallback = SteamKit2.SteamUser.UpdateMachineAuthCallback;
using WalletInfoCallback        = SteamKit2.SteamUser.WalletInfoCallback;
using WebAPIUserNonceCallback   = SteamKit2.SteamUser.WebAPIUserNonceCallback;

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

            // Class critical, do not allow override!
            callbackManager.Register(new Callback<DisconnectedCallback>(Disconnected));

            // Register the overridable callbacks
            {
                #region SteamClient
                callbackManager.Register(new Callback<BaseJobCallback>(OnBaseJob));
                callbackManager.Register(new Callback<CMListCallback>(OnCMList));
                callbackManager.Register(new Callback<ConnectedCallback>(OnConnected));
                callbackManager.Register(new Callback<DisconnectedCallback>(OnDisconnected));
                callbackManager.Register(new Callback<ServerListCallback>(OnServerList));
                #endregion // SteamClient

                #region SteamFriends
                callbackManager.Register(new Callback<ChatActionResultCallback>(OnChatActionResult));
                callbackManager.Register(new Callback<ChatEnterCallback>(OnChatEnter));
                callbackManager.Register(new Callback<ChatInviteCallback>(OnChatInvite));
                callbackManager.Register(new Callback<ChatMemberInfoCallback>(OnChatMemberInfo));
                callbackManager.Register(new Callback<ChatMsgCallback>(OnChatMsg));
                callbackManager.Register(new Callback<ClanStateCallback>(OnClanState));
                callbackManager.Register(new Callback<FriendAddedCallback>(OnFriendAdded));
                callbackManager.Register(new Callback<FriendMsgCallback>(OnFriendMsg));
                callbackManager.Register(new Callback<FriendsListCallback>(OnFriendsList));
                callbackManager.Register(new Callback<IgnoreFriendCallback>(OnIgnoreFriend));
                callbackManager.Register(new Callback<PersonaStateCallback>(OnPersonaState));
                callbackManager.Register(new Callback<ProfileInfoCallback>(OnProfileInfo));
                #endregion // SteamFriends

                #region SteamUser
                callbackManager.Register(new Callback<AccountInfoCallback>(OnAccountInfo));
                callbackManager.Register(new Callback<LoggedOffCallback>(OnLoggedOff));
                callbackManager.Register(new Callback<LoggedOnCallback>(OnLoggedOn));
                callbackManager.Register(new Callback<MarketingMessageCallback>(OnMarketingMessage));
                callbackManager.Register(new Callback<SessionTokenCallback>(OnSessionToken));
                callbackManager.Register(new Callback<UpdateMachineAuthCallback>(OnUpdateMachineAuth));
                callbackManager.Register(new Callback<WalletInfoCallback>(OnWalletInfo));
                callbackManager.Register(new Callback<WebAPIUserNonceCallback>(OnWebAPIUserNonce));
                #endregion // SteamUser
            }
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

        private void Disconnected(DisconnectedCallback callback)
        {
            // When disconnected we should stop listening for callbacks.
            IsRunning = false;
        }

        #region Callbacks

        #region SteamClient

        /// <summary>
        /// Called when...
        /// </summary>
        /// <param name="callback"></param>
        protected virtual void OnBaseJob(BaseJobCallback callback) { }

        /// <summary>
        /// Called when the cleint received the CM list from Steam.
        /// </summary>
        /// <param name="callback"></param>
        protected virtual void OnCMList(CMListCallback callback) { }

        /// <summary>
        /// Called when the client has connected to the Steam network.
        /// </summary>
        /// <param name="callback"></param>
        protected virtual void OnConnected(ConnectedCallback callback) { }

        /// <summary>
        /// Called when the client has disconnected from the Steam network.
        /// </summary>
        /// <param name="callback"></param>
        protected virtual void OnDisconnected(DisconnectedCallback callback) { }

        /// <summary>
        /// Called when the client received a list of publically available Steam servers.
        /// </summary>
        /// <remarks>
        /// This may be called multiple times for different lists of servers.
        /// </remarks>
        /// <param name="callback"></param>
        protected virtual void OnServerList(ServerListCallback callback) { }

        #endregion // SteamClient

        #region SteamFriends

        /// <summary>
        /// Called when a chat related action has completed. (kick, ban, new owner, etc.)
        /// </summary>
        /// <param name="callback"></param>
        protected virtual void OnChatActionResult(ChatActionResultCallback callback) { }

        /// <summary>
        /// Called when attempting to join a chat.
        /// </summary>
        /// <param name="callback"></param>
        protected virtual void OnChatEnter(ChatEnterCallback callback) { }

        /// <summary>
        /// Called when a chat invite has been received.
        /// </summary>
        /// <param name="callback"></param>
        protected virtual void OnChatInvite(ChatInviteCallback callback) { }

        /// <summary>
        /// Called when the user information of a chatroom member has been received.
        /// </summary>
        /// <param name="callback"></param>
        protected virtual void OnChatMemberInfo(ChatMemberInfoCallback callback) { }

        /// <summary>
        /// Called when a chatroom message has been received.
        /// </summary>
        /// <param name="callback"></param>
        protected virtual void OnChatMsg(ChatMsgCallback callback) { }

        /// <summary>
        /// Called when the state of a clan has changed.
        /// </summary>
        /// <param name="callback"></param>
        protected virtual void OnClanState(ClanStateCallback callback) { }

        /// <summary>
        /// Called when the client added a friend to the friendslist.
        /// </summary>
        /// <param name="callback"></param>
        protected virtual void OnFriendAdded(FriendAddedCallback callback) { }

        /// <summary>
        /// Called when a message has been received from a friend.
        /// </summary>
        /// <param name="callback"></param>
        protected virtual void OnFriendMsg(FriendMsgCallback callback) { }

        /// <summary>
        /// Called when the friendslist has been received.
        /// </summary>
        /// <param name="callback"></param>
        protected virtual void OnFriendsList(FriendsListCallback callback) { }

        /// <summary>
        /// Called when trying to ignore a friend.
        /// </summary>
        /// <param name="callback"></param>
        protected virtual void OnIgnoreFriend(IgnoreFriendCallback callback) { }

        /// <summary>
        /// Called when the information of a friend has changed.
        /// </summary>
        /// <param name="callback"></param>
        protected virtual void OnPersonaState(PersonaStateCallback callback) { }

        /// <summary>
        /// Called when profile info of an user has been received.
        /// </summary>
        /// <param name="callback"></param>
        protected virtual void OnProfileInfo(ProfileInfoCallback callback) { }

        #endregion // SteamFriends

        #region SteamUser

        /// <summary>
        /// Called when the account information has been received.
        /// </summary>
        /// <remarks>
        /// Regularly this happens shortly after log on.
        /// </remarks>
        /// <param name="callback"></param>
        protected virtual void OnAccountInfo(AccountInfoCallback callback) { }

        /// <summary>
        /// Called when an user attempts to log off the Steam network.
        /// </summary>
        /// <param name="callback"></param>
        protected virtual void OnLoggedOff(LoggedOffCallback callback) { }

        /// <summary>
        /// Called when an user attempts to log on to the Steam network.
        /// </summary>
        /// <param name="callback"></param>
        protected virtual void OnLoggedOn(LoggedOnCallback callback) { }

        /// <summary>
        /// Called when the client received a marketing message update.
        /// </summary>
        /// <param name="callback"></param>
        protected virtual void OnMarketingMessage(MarketingMessageCallback callback) { }

        /// <summary>
        /// Called when the client receives a session token.
        /// The token is used for content downloading that requires authentication.
        /// </summary>
        /// <param name="callback"></param>
        protected virtual void OnSessionToken(SessionTokenCallback callback) { }

        /// <summary>
        /// Called when the local machine's authentication data has to be updated.
        /// </summary>
        /// <param name="callback"></param>
        protected virtual void OnUpdateMachineAuth(UpdateMachineAuthCallback callback) { }

        /// <summary>
        /// Called when wallet information has been received.
        /// </summary>
        /// <param name="callback"></param>
        protected virtual void OnWalletInfo(WalletInfoCallback callback) { }

        /// <summary>
        /// Called when requesting a new WebAPI authentication user nonce.
        /// </summary>
        /// <param name="callback"></param>
        protected virtual void OnWebAPIUserNonce(WebAPIUserNonceCallback callback) { }

        #endregion // SteamUser

        #endregion // Callbacks
    }
}
