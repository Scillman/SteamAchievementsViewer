using System.Drawing;
using System.Windows.Forms;

namespace SteamAchievementsViewer.Steam.GUI.Controls
{
    /// <summary>
    /// The control used for drawing Steam like controls.
    /// </summary>
    public class Control : System.Windows.Forms.Control
    {
        /// <summary>
        /// Creates a new instance of the control.
        /// </summary>
        public Control() :
            base()
        {
            // Set the double buffered property.
            this.DoubleBuffered = true;

            // Sets the background to be transparent.
            this.SetStyle(ControlStyles.SupportsTransparentBackColor, true);
            this.BackColor = Color.Transparent;
        }
    }
}
