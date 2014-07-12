using System.Windows.Forms;

namespace SteamAchievementsViewer.Steam.GUI
{
    /// <summary>
    /// Creates a Steam style Windows form.
    /// </summary>
    public class SteamGUI : Form
    {
        /// <summary>
        /// Creates a new instance of the interface.
        /// </summary>
        public SteamGUI() :
            base()
        {
            // Display the border style, we will use our own.
            this.FormBorderStyle = FormBorderStyle.None;

            // This is the default for Windows, lets keep it.
            this.AutoScaleMode = AutoScaleMode.Font;
        }
    }
}
