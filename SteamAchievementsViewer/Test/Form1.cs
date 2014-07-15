using System.Windows.Forms;
using SteamKit2X.Managing;
using System;

namespace Test
{
    public partial class Form1 : Form
    {
        private SteamManager manager;

        public Form1()
        {
            InitializeComponent();
            InitializeManager();
        }

        /// <summary>
        /// Clean up any resources being used.
        /// </summary>
        /// <param name="disposing">true if managed resources should be disposed; otherwise, false.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing)
            {
                if (manager != null)
                    manager.Dispose();
            }
            base.Dispose(disposing);
        }

        /// <summary>
        /// Initialize the manager.
        /// </summary>
        private void InitializeManager()
        {
            if (manager == null)
            {
                manager = new SteamManager(this);

                // Connection
                manager.Connected += manager_Connected;
                manager.Disconnected += manager_Disconnected;

                // User
                manager.LoggedOn += manager_LoggedOn;
                manager.LoggedOff += manager_LoggedOff;

                // Authentication
                manager.RequestsSteamGuardCode += manager_RequestsSteamGuardCode;

                // Friends
                manager.FriendsUpdate += manager_FriendsUpdate;
            }
        }

        /**
         * The user has to enter a Steam Guard Code to continue.
         */
        private void manager_RequestsSteamGuardCode(EventArgs e)
        {
            Console.WriteLine("Please enter your Steam Guard Code.", "Steam Guard Code", MessageBoxButtons.OK, MessageBoxIcon.Question);
        }

        /**
         * The friendslist has updated.
         */
        private void manager_FriendsUpdate(EventArgs e)
        {
            var friends = manager.Friends;
            if (friends.Count > 0)
            {
                var newFriend = friends[friends.Count - 1];
                Console.WriteLine("Friend count: {0}, ID: {1}, Name: {2}", manager.Friends.Count, newFriend.SteamID, newFriend.Name);
            }
        }

        /**
         * Log-On/Log-Off notifications
         */
        private void manager_LoggedOn(EventArgs e)
        {
            Console.WriteLine("Successfully logged on to your profile.", "Logged on", MessageBoxButtons.OK, MessageBoxIcon.Information);
        }

        private void manager_LoggedOff(EventArgs e)
        {
            Console.WriteLine("Successfully logged off your profile.", "Logged off", MessageBoxButtons.OK, MessageBoxIcon.Information);
        }

        /**
         * Connection (not so important in the form)
         */
        private void manager_Connected(EventArgs e)
        {
            Console.WriteLine("Successfully connected to the Steam servers.", "Connected", MessageBoxButtons.OK, MessageBoxIcon.Information);
        }

        private void manager_Disconnected(EventArgs e)
        {
            Console.WriteLine("Successfully disconnected from the Steam servers.", "Disconnected", MessageBoxButtons.OK, MessageBoxIcon.Information);
        }

        /**
         * Log-On/Log-Off
         */
        private void button1_Click(object sender, EventArgs e)
        {
            manager.LogOn(username.Text, password.Text, string.IsNullOrWhiteSpace(steamGuardCode.Text) ? null : steamGuardCode.Text);
        }

        private void button2_Click(object sender, EventArgs e)
        {
            manager.LogOff();
        }
    }
}
