using System;
using System.Windows.Forms;

namespace SteamAchievementsViewer
{
    public partial class LoginForm : SteamAchievementsViewer.Steam.GUI.SteamGUI
    {
        public LoginForm()
        {
            InitializeComponent();
        }

        private void ButtonLogin_Click(object sender, EventArgs e)
        {

        }

        private void ButtonExit_Click(object sender, EventArgs e)
        {
            Application.Exit();
        }
    }
}
