
using System;
using System.Drawing;
using System.Drawing.Drawing2D;
namespace SteamAchievementsViewer
{
    /// <summary>
    /// This class is used for commonly used methods.
    /// </summary>
    public static class Utility
    {
        /**
         * Author: Dylan Vester
         * Source: http://stackoverflow.com/questions/628261/how-to-draw-rounded-rectangle-with-variable-width-border-inside-of-specific-boun
         */
        /// <summary>
        /// Draws a rectangle with round corners.
        /// </summary>
        /// <param name="gfx">The graphics device that is being drawn to.</param>
        /// <param name="Bounds">The rectangle that has to be drawn.</param>
        /// <param name="CornerRadius">The radius used for the rounded corners.</param>
        /// <param name="DrawPen">The pen used to draw the edge of the rectangle.</param>
        /// <param name="FillColor">The color used to fill the rectangle.</param>
        public static void DrawRoundedRectangle(this Graphics gfx, Rectangle Bounds, int CornerRadius, Pen DrawPen, Color FillColor)
        {
            int strokeOffset = Convert.ToInt32(Math.Ceiling(DrawPen.Width));
            Bounds = Rectangle.Inflate(Bounds, -strokeOffset, -strokeOffset);

            DrawPen.EndCap = DrawPen.StartCap = LineCap.Round;

            GraphicsPath gfxPath = new GraphicsPath();
            gfxPath.AddArc(Bounds.X, Bounds.Y, CornerRadius, CornerRadius, 180, 90);
            gfxPath.AddArc(Bounds.X + Bounds.Width - CornerRadius, Bounds.Y, CornerRadius, CornerRadius, 270, 90);
            gfxPath.AddArc(Bounds.X + Bounds.Width - CornerRadius, Bounds.Y + Bounds.Height - CornerRadius, CornerRadius, CornerRadius, 0, 90);
            gfxPath.AddArc(Bounds.X, Bounds.Y + Bounds.Height - CornerRadius, CornerRadius, CornerRadius, 90, 90);
            gfxPath.CloseAllFigures();

            gfx.FillPath(new SolidBrush(FillColor), gfxPath);
            gfx.DrawPath(DrawPen, gfxPath);
        }
    }
}
