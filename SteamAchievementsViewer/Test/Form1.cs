using SteamKit2X.Managing;
using SteamKit2X.Managing.Events;
using System;
using System.Windows.Forms;

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
                manager.Connected += EventLog;
                manager.Disconnected += EventLog;

                // User
                manager.LoggedOn += EventLog;
                manager.LoggedOff += EventLog;
                manager.LogOnFailed += EventLog;
                manager.LogOffFailed += EventLog;

                // Authentication
                manager.RequestsSteamGuardCode += manager_RequestsSteamGuardCode;

                // Friends
                manager.FriendsUpdate += manager_FriendsUpdate;
            }
        }

        /**
         * The user has to enter a Steam Guard Code to continue.
         */
        private void manager_RequestsSteamGuardCode(AuthenticationEventArgs e)
        {
            MessageBox.Show("Please enter your Steam Guard Code.", "Steam Guard Code", MessageBoxButtons.OK, MessageBoxIcon.Question);
            Log(e.Message);
        }

        /**
         * The friendslist has updated.
         */
        private void manager_FriendsUpdate(FriendsEventArgs e)
        {
            var friends = manager.Friends;
            if (friends.Count > 0)
            {
                var newFriend = friends[friends.Count - 1];
                Console.WriteLine("Friends count: {0}, ID: {1}, Name: {2}", manager.Friends.Count, newFriend.SteamID, newFriend.Name);
            }
            Log(e.Message);
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

        private void EventLog(ManagerEventArgs e)
        {
            Log(e.Message);
        }

        private void Log(string message)
        {
            message = string.Format("{0}\r\n", message);
            richTextBox1.AppendText(message);
            System.Diagnostics.Debug.Write(message);
        }
    }
}
