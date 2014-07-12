using System;
using System.Drawing;
using System.Windows.Forms;

namespace SteamAchievementsViewer
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
            this.BackColor = Color.Black;
        }

        private void button1_Click(object sender, EventArgs e)
        {
            var terms = new TermsOfUse();
            terms.ShowDialog();
        }
    }
}
