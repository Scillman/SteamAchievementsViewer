using SteamKit2;
using SteamKit2X.Users;
using System;
using AccountInfoCallback = SteamKit2.SteamUser.AccountInfoCallback;
using FriendsListCallback = SteamKit2.SteamFriends.FriendsListCallback;
using PersonaStateCallback = SteamKit2.SteamFriends.PersonaStateCallback;

/* FRIENDS
 *   Managed the friendslist and raises a thread-safe
 *   event when changes have been made.
 */
namespace SteamKit2X.Managing
{
    partial class SteamManager
    {
        /// <summary>
        /// Initialize the friends.
        /// </summary>
        private void InitializeFriends()
        {
            Friends = new UserCollection();
        }

        /// <summary>
        /// Called shortly after the user has logged on.
        /// </summary>
        /// <param name="callback"></param>
        protected override void OnAccountInfo(AccountInfoCallback callback)
        {
            // Go online so we can retrieve the user's friendslist.
            SteamFriends.SetPersonaState(EPersonaState.Online);
        }

        /// <summary>
        /// Called when the friendslist has been received.
        /// </summary>
        /// <param name="callback"></param>
        protected override void OnFriendsList(FriendsListCallback callback)
        {
            // Get the list of friends.
            var friends = callback.FriendList;

            // Lock the friends, so we can clear it and add all the friends to the collection.
            lock (_friendsLock)
            {
                // Clear the friendslist prior to changing it.
                _friends.Clear();

                // Add the friend to the friendslist.
                foreach (var friend in friends)
                    _friends.Add(new User(friend.SteamID));
            }

            // Raise the event as we modified the list.
            OnFriendsUpdate();
        }

        /// <summary>
        /// Called when the information of a friend has changed.
        /// </summary>
        /// <param name="callback"></param>
        protected override void OnPersonaState(PersonaStateCallback callback)
        {
            // Update the information of the friend.
            Friends.Update(callback.FriendID, callback.Name);

            // Raise the event as we modified the list.
            OnFriendsUpdate();
        }

        /// <summary>
        /// Called when a change in the friendslist has been made.
        /// </summary>
        protected virtual void OnFriendsUpdate()
        {
            InvokeEvent(FriendsUpdate);
        }

        /// <summary>
        /// Raised when a change in the friendslist has occured.
        /// </summary>
        public event Action<EventArgs> FriendsUpdate;
    }
}
