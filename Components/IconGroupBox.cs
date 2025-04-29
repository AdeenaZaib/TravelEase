using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Components
{
    public class IconGroupBox : GroupBox
    {
        private Image icon;
        private string headingText = "Heading";

        //[Category("Appearance")]
        //[Description("The icon displayed next to the heading text.")]
        public Image Icon
        {
            get { return icon; }
            set { icon = value; Invalidate(); }
        }

        //[Category("Appearance")]
        //[Description("The heading text displayed at the top of the group box.")]
        public string HeadingText
        {
            get { return headingText; }
            set { headingText = value; Invalidate(); }
        }

        public IconGroupBox()
        {
            this.DoubleBuffered = true;
        }

        protected override void OnPaint(PaintEventArgs e)
        {
            base.OnPaint(e);

            Graphics g = e.Graphics;

            // Draw the icon
            if (icon != null)
            {
                int iconWidth = 20; // Adjust as needed
                int iconHeight = 20; // Adjust as needed
                g.DrawImage(icon, new Rectangle(5, 5, iconWidth, iconHeight));
            }

            // Draw the heading text
            int textX = icon != null ? 30 : 5;
            int textY = 8;
            using (var brush = new SolidBrush(this.ForeColor))
            {
                g.DrawString(headingText, this.Font, brush, new PointF(textX, textY));
            }
        }
    }
}
