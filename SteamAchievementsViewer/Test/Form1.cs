using System.Windows.Forms;
using SteamKit2X;
using System;

namespace Test
{
    public partial class Form1 : Form
    {
        private ClientManager manager;

        public Form1()
        {
            InitializeComponent();
        }

        private void InitializeManager()
        {
            if (manager == null)
            {
                manager = new ClientManager(this, username.Text, password.Text);

                // Connection
                manager.Connected += manager_Connected;
                manager.Disconnected += manager_Disconnected;

                // User
                manager.LoggedOn += manager_LoggedOn;
                manager.LoggedOff += manager_LoggedOff;

                // Friends
                manager.FriendsUpdate += manager_FriendsUpdate;
            }
            else
            {
                manager.SteamGuardCode = steamGuardCode.Text;
            }
        }

        private void manager_FriendsUpdate()
        {
            var friends = manager.Friends;
            if (friends.Count > 0)
            {
                var newFriend = friends[friends.Count - 1];
                Console.WriteLine("Friend count: {0}, ID: {1}, Name: {2}", manager.Friends.Count, newFriend.SteamID, newFriend.Name);
            }
        }

        private void manager_LoggedOn()
        {
            MessageBox.Show("Successfully logged on to your profile.", "Logged on", MessageBoxButtons.OK, MessageBoxIcon.Information);
        }

        private void manager_LoggedOff()
        {
            MessageBox.Show("Successfully logged off your profile.", "Logged off", MessageBoxButtons.OK, MessageBoxIcon.Information);
        }

        private void manager_Connected()
        {
            MessageBox.Show("Successfully connected to the Steam servers.", "Connected", MessageBoxButtons.OK, MessageBoxIcon.Information);

            try
            {
                manager.LogOn();
            }
            catch (SteamKit2X.Exceptions.SteamGuardException)
            {
                MessageBox.Show("Please enter your Steam Guard Code.", "Steam Guard Code", MessageBoxButtons.OK, MessageBoxIcon.Question);
            }
        }

        private void manager_Disconnected()
        {
            MessageBox.Show("Successfully disconnected from the Steam servers.", "Disconnected", MessageBoxButtons.OK, MessageBoxIcon.Information);
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

        private void button1_Click(object sender, EventArgs e)
        {
            InitializeManager();
            manager.Connect(username.Text, password.Text, string.IsNullOrWhiteSpace(steamGuardCode.Text) ? null : steamGuardCode.Text);
        }

        private void button2_Click(object sender, EventArgs e)
        {
            manager.LogOff();
        }

        private void button3_Click(object sender, EventArgs e)
        {
            manager.Disconnect();
        }
    }
}
