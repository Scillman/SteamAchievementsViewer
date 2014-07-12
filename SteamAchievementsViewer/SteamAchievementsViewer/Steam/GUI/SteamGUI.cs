using System;
using System.Drawing;
using System.Drawing.Drawing2D;
using System.Windows.Forms;

namespace SteamAchievementsViewer.Steam.GUI
{
    /// <summary>
    /// Creates a Steam style Windows form.
    /// </summary>
    public class SteamGUI : Form
    {
        #region Drawing Constants
        // The colors used for the background radiant.
        private static readonly Color GRADIENT_COLOR_A = Color.FromArgb(0x20, 0x1F, 0x1E);
        private static readonly Color GRADIENT_COLOR_B = Color.FromArgb(0x38, 0x36, 0x35);

        // The font used it to draw the text.
        private static readonly string TEXT_FONT_FAMILY = "Arial";
        private static readonly Font TEXT_FONT = new Font(TEXT_FONT_FAMILY, 13, FontStyle.Regular);
        private static readonly Color TEXT_COLOR = Color.White;

        // The mode that is used to draw the background radient.
        private static readonly LinearGradientMode GRADIENT_MODE = LinearGradientMode.Vertical;
        #endregion

        // The brush used to draw the background gradient.
        private LinearGradientBrush backgroundBrush;

        // The brush used to draw the text.
        private Brush brush;

        // The point at which the text is drawn.
        private Point textPoint;

        /// <summary>
        /// Creates a new instance of the interface.
        /// </summary>
        public SteamGUI() :
            base()
        {
            this.DoubleBuffered = true;

            // Display the border style, we will use our own.
            this.FormBorderStyle = FormBorderStyle.None;

            // This is the default for Windows, lets keep it.
            this.AutoScaleMode = AutoScaleMode.Font;

            // Create the brush for the title.
            brush = new SolidBrush(TEXT_COLOR);

            // The brush used for the background.
            backgroundBrush = new LinearGradientBrush(new Rectangle(0, 0, this.Width, 100), GRADIENT_COLOR_A, GRADIENT_COLOR_B, GRADIENT_MODE);

            // The point at which the text is drawn.
            textPoint = new Point(6, 4);
        }

        /// <summary>
        /// Releases all the used resources.
        /// </summary>
        /// <param name="disposing"></param>
        protected override void Dispose(bool disposing)
        {
            if (disposing)
            {
                Dispose(ref brush);
                Dispose(ref backgroundBrush);
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
        /// Called when it has to be drawn.
        /// </summary>
        /// <param name="e"></param>
        protected override void OnPaint(PaintEventArgs e)
        {
            base.OnPaint(e);
            
            // Clear the background of the interface.
            var g = e.Graphics;
            g.Clear(GRADIENT_COLOR_B);

            g.FillRectangle(backgroundBrush, backgroundBrush.Rectangle);

            // Draw the title of the form.
            g.DrawString(Text, TEXT_FONT, brush, textPoint);
        }

        /// <summary>
        /// Open a successor form.
        /// </summary>
        /// <param name="form">The form that has to be opened after this form.</param>
        protected void Successor(Form form)
        {
            form.FormClosed += Form_FormClosed;
            Hide();
            form.Show();
        }

        /// <summary>
        /// Close this form when the successor has closed.
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void Form_FormClosed(object sender, FormClosedEventArgs e)
        {
            Close();
        }
    }
}
