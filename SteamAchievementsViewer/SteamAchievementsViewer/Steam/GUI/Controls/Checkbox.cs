using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace SteamAchievementsViewer.Steam.GUI.Controls
{
    /// <summary>
    /// A Steam style checkbox.
    /// </summary>
    public class Checkbox : Control
    {
        #region Drawing Constants
        // The steam colors for active users.
        private static readonly Color STATE_CHECKED = Color.FromArgb(0x82, 0xB3, 0x59);
        private static readonly Color STATE_UNCHECKED = Color.FromArgb(0x6F, 0xB5, 0xD9);
        //private static readonly Color STATE_OFFLINE = Color.FromArgb(0xA6, 0xA4, 0xA1);

        private const float PEN_THICKNESS = 2.5f;
        #endregion

        // The brushes that are used to draw the text.
        private SolidBrush brushChecked;
        private SolidBrush brushUnchecked;

        // The pens used to draw the check.
        private Pen penChecked;
        private Pen penUnchecked;

        public Checkbox() :
            base()
        {
            Checked = false;

            // The brushes used to draw the text.
            brushChecked = new SolidBrush(STATE_CHECKED);
            brushUnchecked = new SolidBrush(STATE_UNCHECKED);

            // The pens used to draw the check.
            penChecked = new Pen(brushChecked, PEN_THICKNESS);
            penUnchecked = new Pen(brushUnchecked, PEN_THICKNESS);
        }

        /// <summary>
        /// Release all the used resources.
        /// </summary>
        /// <param name="disposing"></param>
        protected override void Dispose(bool disposing)
        {
            if (disposing)
            {
                Dispose(ref penChecked);
                Dispose(ref penUnchecked);

                Dispose(ref brushChecked);
                Dispose(ref brushUnchecked);
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
        /// Indicates whether the checkbox is currently checked or not.
        /// </summary>
        [Category("Appearance")]
        [Description("Indicates whether the checkbox is currently checked or not.")]
        public bool Checked { get; set; }

        /// <summary>
        /// Lets the designer know the default value is false.
        /// </summary>
        /// <returns>true when the value is not false; false otherwise.</returns>
        public bool ShouldSerializeChecked()
        {
            return (Checked != false);
        }

        protected override void OnPaint(PaintEventArgs e)
        {
            base.OnPaint(e);
            
            // Get the device that has to be drawn to.
            var g = e.Graphics;

            // Draw the text
            var brush = Checked ? brushChecked : brushUnchecked;
            var pen = Checked ? penChecked : penUnchecked;

            var height = this.Height / 2;
            g.DrawEllipse(pen, new Rectangle(0, 0, height, height));
            g.DrawString(Text, Font, brush, new PointF(0, height + 6));
        }
    }
}
