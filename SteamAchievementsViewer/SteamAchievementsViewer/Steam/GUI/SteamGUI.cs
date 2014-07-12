using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace SteamAchievementsViewer.Steam.GUI
{
    public class SteamGUI : Form
    {
        public SteamGUI() :
            base()
        {
            // Display the border style, we will use our own.
            this.FormBorderStyle = FormBorderStyle.None;
        }
    }
}
