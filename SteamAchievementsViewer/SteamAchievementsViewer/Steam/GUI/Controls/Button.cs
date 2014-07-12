using System;
using System.Collections.Generic;
using System.Diagnostics;
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
        private const int CONTROL_HEIGHT = 24;

        /**
         * The constants used for drawing the button.
         *   Active:    When the control has focus.
         *   Inactive:  When the control does not have focus.
         */
        #region Drawing Constants
        // The colors that are used for the background gradient.
        private static readonly Color GRADIENT_COLOR_ACTIVE_TOP = Color.FromArgb(0x66, 0x63, 0x60);
        private static readonly Color GRADIENT_COLOR_ACTIVE_BOTTOM = Color.FromArgb(0x4B, 0x49, 0x47);
        private static readonly Color GRADIENT_COLOR_INACTIVE_TOP = Color.FromArgb(0x5C, 0x59, 0x56);
        private static readonly Color GRADIENT_COLOR_INACTIVE_BOTTOM = Color.FromArgb(0x4A, 0x48, 0x46);

        // The mode that is used to draw the background radient.
        private static readonly LinearGradientMode GRADIENT_MODE = LinearGradientMode.Vertical;

        // The colors used for drawing the edge.
        private static readonly Color EDGE_COLOR = Color.White;
        private static readonly Color EDGE_COLOR_ACTIVE = Color.FromArgb(0x40, EDGE_COLOR);
        private static readonly Color EDGE_COLOR_INACTIVE = Color.FromArgb(0x20, EDGE_COLOR);

        // The font used it to draw the text.
        private static readonly string TEXT_FONT_FAMILY = "Arial";
        private static readonly Font TEXT_FONT = new Font(TEXT_FONT_FAMILY, 9, FontStyle.Regular);
        private static readonly Color TEXT_COLOR = Color.White;
        #endregion

        // The brushes used for drawing the backgrounds.
        private LinearGradientBrush brushActive;
        private LinearGradientBrush brushInactive;

        // The brushes/pens used for drawing the edge.
        private SolidBrush brushEdgeActive;
        private SolidBrush brushEdgeInactive;
        private Pen penActive;
        private Pen penInactive;

        // The brush used to draw the text on a button.
        private Brush textBrush = new SolidBrush(TEXT_COLOR);

        // Indicates whether to draw with the 'active' or 'inactive' brush.
        private bool active;

        // The bounds used for drawing the background.
        private Rectangle bounds;
        private Rectangle edge;

        // The point at which the text is drawn.
        private PointF textPoint;

        public Button()
        {
            // Settings for the control.
            this.Width = CONTROL_WIDTH;
            this.Height = CONTROL_HEIGHT;

            // Set the focus.
            this.active = false;
            this.textPoint = PointF.Empty;

            // Load the pens for drawing the edge.
            brushEdgeActive = new SolidBrush(EDGE_COLOR_ACTIVE);
            brushEdgeInactive = new SolidBrush(EDGE_COLOR_INACTIVE);
            penActive = new Pen(brushEdgeActive);
            penInactive = new Pen(brushEdgeInactive);

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
                // Background
                Dispose(ref brushActive);
                Dispose(ref brushInactive);

                // Edge
                Dispose(ref penActive);
                Dispose(ref penInactive);
                Dispose(ref brushEdgeActive);
                Dispose(ref brushEdgeInactive);  

                // Text
                Dispose(ref textBrush);
            }

            base.Dispose(disposing);
        }

        /// <summary>
        /// Disposes of a object.
        /// </summary>
        /// <param name="obj">The object that has to be disposed.</param>
        /// <typeparam name="T">The object has to be an class with the interface IDisposable.</typeparam>
        private void Dispose<T>(ref T obj) where T : class, IDisposable
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

            // Change it to match the control.
            const int OFFSET = 1; // The offset needed by the edge.
            var widthB = Width > OFFSET ? Width - OFFSET : CONTROL_WIDTH - OFFSET;
            var heightB = Height > OFFSET ? Height - OFFSET : CONTROL_HEIGHT - OFFSET;
            edge = new Rectangle(0, 0, widthB, heightB);

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
        /// Called when the text on the control changes.
        /// </summary>
        /// <param name="e"></param>
        protected override void OnTextChanged(EventArgs e)
        {
            // Measure the size of the text.
            var text = Text.ToUpper();
            var size = TextRenderer.MeasureText(text, TEXT_FONT);

            // Set the new point of the text.
            textPoint.X = ((Width - size.Width) / 2);
            textPoint.Y = ((Height - size.Height) / 2);

            base.OnTextChanged(e);
        }

        /// <summary>
        /// Called when the control gains focus.
        /// </summary>
        /// <param name="e"></param>
        protected override void OnGotFocus(EventArgs e)
        {
            SetActive(true);
            base.OnGotFocus(e);
        }

        /// <summary>
        /// Called when the focus on the control is lost.
        /// </summary>
        /// <param name="e"></param>
        protected override void OnLostFocus(EventArgs e)
        {
            SetActive(false);
            base.OnLostFocus(e);
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

        /// <summary>
        /// Called when the device has to be drawn.
        /// </summary>
        /// <param name="e"></param>
        protected override void OnPaint(PaintEventArgs e)
        {
            base.OnPaint(e);

            // The graphics device that has to be drawn to.
            var g = e.Graphics;

            // Draw the button's background radiant.
            var brush = active ? brushActive : brushInactive;
            g.FillRectangle(brush, bounds);

            // Draw the edge of the control.
            var pen = active ? penActive : penInactive;
            g.DrawRectangle(pen, edge);

            // Draw the text on the control.
            g.DrawString(Text.ToUpper(), TEXT_FONT, textBrush, textPoint);
        }
    }
}
