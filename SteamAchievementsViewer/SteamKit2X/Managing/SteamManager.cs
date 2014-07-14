using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using SteamKit2;
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
    /// The <see cref="SteamKit2X.Managing.SteamManager"/> is resposible for most interaction.
    /// </summary>
    public class SteamManager : ManagerBase
    {
        /// <summary>
        /// Creates a new instance of the <see cref="SteamKit2X.Managing.SteamManager"/>.
        /// </summary>
        public SteamManager()
        {

        }

        /// <summary>
        /// Called when the client has connected to the Steam network.
        /// </summary>
        /// <param name="callback"></param>
        protected override void OnConnected(ConnectedCallback callback)
        {
            throw new NotImplementedException();
        }

        /// <summary>
        /// Called when the client has disconnected from the Steam network.
        /// </summary>
        /// <param name="callback"></param>
        protected override void OnDisconnected(DisconnectedCallback callback)
        {
            throw new NotImplementedException();
        }

        /// <summary>
        /// Called when an user has logged on to the Steam network.
        /// </summary>
        /// <param name="callback"></param>
        protected override void OnLoggedOn(LoggedOnCallback callback)
        {
            throw new NotImplementedException();
        }

        /// <summary>
        /// Called when an user has logged off the Steam network.
        /// </summary>
        /// <param name="callback"></param>
        protected override void OnLoggedOff(LoggedOffCallback callback)
        {
            throw new NotImplementedException();
        }

        /// <summary>
        /// Called when the machine's authentication data has to be updated.
        /// </summary>
        /// <param name="callback"></param>
        protected override void OnMachineAuth(UpdateMachineAuthCallback callback)
        {
            throw new NotImplementedException();
        }

        /// <summary>
        /// Called shortly after the user has logged on.
        /// </summary>
        /// <param name="callback"></param>
        protected override void OnAccountInfo(AccountInfoCallback callback)
        {
            throw new NotImplementedException();
        }

        /// <summary>
        /// Called when the friendslist has been received.
        /// </summary>
        /// <param name="callback"></param>
        protected override void OnFriendsList(FriendsListCallback callback)
        {
            throw new NotImplementedException();
        }

        /// <summary>
        /// Called when the information of a friend has changed.
        /// </summary>
        /// <param name="callback"></param>
        protected override void OnPersonaState(PersonaStateCallback callback)
        {
            throw new NotImplementedException();
        }
    }
}
