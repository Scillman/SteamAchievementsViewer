using SteamKit2X.Managing;
using SteamKit2X.Managing.Events;
using SteamKit2X.Users;
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

            // The SteamKit2X.Users.User object is put inside the listBox1.
            // The properties Name and SteamID are used for display and retrieval.
            listBox1.DisplayMember = "Name";
            listBox1.ValueMember = "SteamID";
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

            if (e.SingleUser)
            {
                User user = friends[e.SteamID];
                if (user != null)
                {
                    listBox1.Items.Remove(user);
                    listBox1.Items.Add(user);
                }
            }
            else
            {
                listBox1.Items.Clear();
                if (friends.Count > 0)
                {
                    var newFriend = friends[friends.Count - 1];
                    listBox1.Items.Add(newFriend);
                    Console.WriteLine("Friends count: {0}, ID: {1}, Name: {2}", manager.Friends.Count, newFriend.SteamID, newFriend.Name);
                }
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

        private void listBox1_SelectedIndexChanged(object sender, EventArgs e)
        {
            var user = listBox1.Items[listBox1.SelectedIndex] as User;
            if (user != null)
                MessageBox.Show(string.Format("SteamID: {0}", user.SteamID), "SteamID", MessageBoxButtons.OK, MessageBoxIcon.Information);
        }
    }
}
