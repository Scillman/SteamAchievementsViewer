using System;
using System.Windows.Forms;

namespace SteamAchievementsViewer
{
    /// <summary>
    /// A 'Terms of Use' window.
    /// </summary>
    public partial class TermsOfUse : Steam.GUI.SteamGUI
    {
        public TermsOfUse()
        {
            InitializeComponent();
        }

        /// <summary>
        /// The user is not accepting the terms of use; exit.
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void buttonCancel_Click(object sender, EventArgs e)
        {
            Application.Exit();
        }

        /// <summary>
        /// The user is accepting the terms of use.
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void buttonOk_Click(object sender, EventArgs e)
        {
            Successor(new LoginForm());
        }
    }
}
