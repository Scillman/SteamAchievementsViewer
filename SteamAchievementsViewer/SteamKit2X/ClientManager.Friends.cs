using SteamKit2;
using SteamKit2X.Users;
using System;
using System.Diagnostics;
using AccountInfoCallback = SteamKit2.SteamUser.AccountInfoCallback;
using FriendsListCallback = SteamKit2.SteamFriends.FriendsListCallback;
using PersonaStateCallback = SteamKit2.SteamFriends.PersonaStateCallback;

/* Friends
 *   This file is used for friends information.
 */

namespace SteamKit2X
{
    partial class ClientManager
    {
        /// <summary>
        /// The friends of the user on steam.
        /// </summary>
        private SteamFriends friends;

        /// <summary>
        /// Initialize the friends.
        /// </summary>
        private void InitializeFriends()
        {
            // Get the friends handler.
            friends = client.GetHandler<SteamFriends>();

            // Friendslist
            manager.Register(new Callback<AccountInfoCallback>(OnAccountInfo));
            manager.Register(new Callback<FriendsListCallback>(OnFriendsList));

            // Friends information
            manager.Register(new Callback<PersonaStateCallback>(OnPersonaState));
        }

        /// <summary>
        /// Called shortly after login.
        /// </summary>
        /// <param name="callback"></param>
        private void OnAccountInfo(AccountInfoCallback callback)
        {
            // Go online so we can retrieve the user's friendslist.
            friends.SetPersonaState(EPersonaState.Online);
        }

        /// <summary>
        /// Called when we can access the friends list of the user.
        /// </summary>
        /// <param name="callback"></param>
        private void OnFriendsList(FriendsListCallback callback)
        {
            // Get the amount of players inside the friends list.
            var count = friends.GetFriendCount();
            Debug.WriteLine("I have {0} friends!", count);
        }

        /// <summary>
        /// Called when an user's information changes.
        /// </summary>
        /// <param name="callback"></param>
        private void OnPersonaState(PersonaStateCallback callback)
        {
            var user = new User(callback.FriendID, callback.Name);
            Friends.Add(user);
            OnFriendsUpdate();
        }

        /// <summary>
        /// Raised when a change in the friends list has occured.
        /// </summary>
        public event Action FriendsUpdate;

        /// <summary>
        /// Called when a change in the friends list has occured.
        /// </summary>
        protected virtual void OnFriendsUpdate()
        {
            if (FriendsUpdate != null)
                Invoke(FriendsUpdate);
        }
    }
}
