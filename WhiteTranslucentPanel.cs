using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Drawing;
using System.Drawing.Drawing2D;
using System.Windows.Forms;

namespace Components
{
    public class WhiteTranslucentPanel : Panel
    {
        private int _cornerRadius = 10;
        private Color _borderColor = Color.Black;
        private int _borderWidth = 1;

        public int CornerRadius
        {
            get { return _cornerRadius; }
            set { _cornerRadius = value; Invalidate(); }
        }

        public Color BorderColor
        {
            get { return _borderColor; }
            set { _borderColor = value; Invalidate(); }
        }

        public int BorderWidth
        {
            get { return _borderWidth; }
            set { _borderWidth = value; Invalidate(); }
        }

        public WhiteTranslucentPanel()
        {
            DoubleBuffered = true;
            SetStyle(ControlStyles.SupportsTransparentBackColor, true);
            BackColor = Color.Transparent; // Ensure panel background is transparent
        }

        // Set transparency through alpha value in the background
        public void SetTransparency(int alpha)
        {
            this.BackColor = Color.FromArgb(alpha, 255, 255, 255); // Adjust alpha for transparency
        }

        protected override void OnPaint(PaintEventArgs e)
        {
            base.OnPaint(e);

            // Shadow effect
            using (Brush shadowBrush = new SolidBrush(Color.FromArgb(80, Color.White)))
            {
                e.Graphics.FillPath(shadowBrush, RoundedRectangle.Create(5, 5, Width - 1, Height - 1, _cornerRadius));
            }

            // Actual panel background (translucent white)
            GraphicsPath path = RoundedRectangle.Create(0, 0, Width - 1, Height - 1, _cornerRadius);
            Region = new Region(path);

            using (Brush backgroundBrush = new SolidBrush(BackColor))
            {
                e.Graphics.FillPath(backgroundBrush, path);  // <-- THIS was missing
            }

            using (Pen pen = new Pen(_borderColor, _borderWidth))
            {
                e.Graphics.DrawPath(pen, path);
            }
        }

    }

    public static class WhiteRoundedRectangle
    {
        public static GraphicsPath Create(int x, int y, int width, int height, int radius)
        {
            GraphicsPath path = new GraphicsPath();
            path.StartFigure();
            path.AddArc(x, y, radius * 2, radius * 2, 180, 90);
            path.AddLine(x + radius, y, x + width - radius * 2, y);
            path.AddArc(x + width - radius * 2, y, radius * 2, radius * 2, 270, 90);
            path.AddLine(x + width, y + radius * 2, x + width, y + height - radius * 2);
            path.AddArc(x + width - radius * 2, y + height - radius * 2, radius * 2, radius * 2, 0, 90);
            path.AddLine(x + width - radius * 2, y + height, x + radius * 2, y + height);
            path.AddArc(x, y + height - radius * 2, radius * 2, radius * 2, 90, 90);
            path.AddLine(x, y + height - radius * 2, x, y + radius * 2);
            path.CloseFigure();
            return path;
        }
    }
}
