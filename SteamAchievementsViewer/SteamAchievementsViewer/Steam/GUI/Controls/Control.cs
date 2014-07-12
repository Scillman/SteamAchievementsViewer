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

            // Set the font on the control to Arial.
            this.Font = new Font("Arial", 9.0f, FontStyle.Regular);
        }

        /// <summary>
        /// Called when a key has been pressed.
        /// </summary>
        /// <param name="e"></param>
        protected override void OnKeyPress(KeyPressEventArgs e)
        {
            // Raise a click event when the enter key has been pressed.
            if (Focused && e.KeyChar == (char)Keys.Enter)
                base.OnClick(e);
            base.OnKeyPress(e);
        }
    }
}
