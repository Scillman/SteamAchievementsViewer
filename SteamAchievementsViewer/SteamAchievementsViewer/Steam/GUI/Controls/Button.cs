using System;
using System.Collections.Generic;
using System.Drawing;
using System.Drawing.Drawing2D;
using System.Linq;
using System.Runtime.InteropServices;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace SteamAchievementsViewer.Steam.GUI.Controls
{
    [ComVisibleAttribute(true)]
    public class Button : Control
    {
        /**
         * The default size of the control.
         */
        private const int CONTROL_WIDTH = 100;
        private const int CONTROL_HEIGHT = 26;

        /**
         * The colors used for the background of the button.
         *   Active:    When the control has focus.
         *   Inactive:  When the control does not have focus.
         */
        private readonly Color GRADIENT_COLOR_ACTIVE_TOP = Color.FromArgb(0x66, 0x63, 0x60);
        private readonly Color GRADIENT_COLOR_ACTIVE_BOTTOM = Color.FromArgb(0x4B, 0x49, 0x47);
        private readonly Color GRADIENT_COLOR_INACTIVE_TOP = Color.FromArgb(0x5C, 0x59, 0x56);
        private readonly Color GRADIENT_COLOR_INACTIVE_BOTTOM = Color.FromArgb(0x4A, 0x48, 0x46);

        // The mode that is used to draw the background radient.
        private readonly LinearGradientMode GRADIENT_MODE = LinearGradientMode.Vertical;

        // The brushes used for drawing the backgrounds.
        private LinearGradientBrush brushActive;
        private LinearGradientBrush brushInactive;

        // Indicates whether to draw with the 'active' or 'inactive' brush.
        private bool active;

        // The bounds used for drawing the background.
        private Rectangle bounds;

        public Button()
        {
            // Settings for the control.
            this.Width = CONTROL_WIDTH;
            this.Height = CONTROL_HEIGHT;

            // Set the focus.
            this.active = false;

            // Prepare for drawing the control.
            SetBounds();
        }

        /// <summary>
        /// Dispose of all the used resources.
        /// </summary>
        /// <param name="disposing"></param>
        protected override void Dispose(bool disposing)
        {
            if (disposing)
            {
                Dispose(ref brushActive);
                Dispose(ref brushInactive);
            }

            base.Dispose(disposing);
        }

        /// <summary>
        /// Disposes of a single brush.
        /// </summary>
        /// <param name="obj"></param>
        private void Dispose(ref LinearGradientBrush obj)
        {
            if (obj != null)
            {
                obj.Dispose();
                obj = null;
            }
        }

        /// <summary>
        /// Reloads the used brushes.
        /// </summary>
        private void ReloadBrushes()
        {
            // First dispose of the brushes.
            Dispose(ref brushActive);
            Dispose(ref brushInactive);

            // Create the new brushes.
            brushActive = new LinearGradientBrush(bounds, GRADIENT_COLOR_ACTIVE_TOP, GRADIENT_COLOR_ACTIVE_BOTTOM, GRADIENT_MODE);
            brushInactive = new LinearGradientBrush(bounds, GRADIENT_COLOR_INACTIVE_TOP, GRADIENT_COLOR_INACTIVE_BOTTOM, GRADIENT_MODE);
        }

        /// <summary>
        /// Set the bounds for drawing the background.
        /// </summary>
        private void SetBounds()
        {
            // Change it to match the control.
            var width = Width > 0 ? Width : CONTROL_WIDTH;
            var height = Height > 0 ? Height : CONTROL_HEIGHT;
            bounds = new Rectangle(0, 0, width, height);

            // Reload the brushes to match the new bounds.
            ReloadBrushes();
        }

        /// <summary>
        /// Called when the control has been resized.
        /// </summary>
        /// <param name="e"></param>
        protected override void OnResize(EventArgs e)
        {
            SetBounds();
            base.OnResize(e);
        }

        /// <summary>
        /// Set the control to an active or inactive state.
        /// </summary>
        /// <param name="value">true when the control has to be active; false otherwise.</param>
        private void SetActive(bool value)
        {
            active = value;
            Invalidate();
        }

        /// <summary>
        /// Called when the mouse enters the control.
        /// </summary>
        /// <param name="e"></param>
        protected override void OnMouseHover(EventArgs e)
        {
            SetActive(true);
            this.Invalidate();
        }

        /// <summary>
        /// Called when the mouse leaves the control.
        /// </summary>
        /// <param name="e"></param>
        protected override void OnMouseLeave(EventArgs e)
        {
            SetActive(false);
            this.Invalidate();
        }

        /// <summary>
        /// Called when the device has to be drawn.
        /// </summary>
        /// <param name="e"></param>
        protected override void OnPaint(PaintEventArgs e)
        {
            // The graphics device that has to be drawn to.
            var g = e.Graphics;

            // Draw the button's background radiant.
            var brush = active ? brushActive : brushInactive;
            g.FillRectangle(brush, new Rectangle(0, 0, this.Width, this.Height));

            base.OnPaint(e);
        }
    }
}
