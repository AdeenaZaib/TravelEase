using System;
using System.Drawing;
using System.Drawing.Drawing2D;
using System.Windows.Forms;

public class TranslucentRoundedButton : Button
{
    public Color FillColor { get; set; } = Color.Blue;  // default base color
    public int Opacity { get; set; } = 128; // 0 = fully transparent, 255 = fully opaque
    public int CornerRadius { get; set; } = 20;

    public TranslucentRoundedButton()
    {
        this.FlatStyle = FlatStyle.Flat;
        this.FlatAppearance.BorderSize = 0;
        this.BackColor = Color.Transparent;
        this.ForeColor = Color.White;
        this.SetStyle(ControlStyles.AllPaintingInWmPaint |
                      ControlStyles.UserPaint |
                      ControlStyles.OptimizedDoubleBuffer |
                      ControlStyles.SupportsTransparentBackColor, true);
    }

    protected override void OnPaint(PaintEventArgs pevent)
    {
        Graphics g = pevent.Graphics;
        g.SmoothingMode = SmoothingMode.AntiAlias;

        // Translucent custom color
        using (SolidBrush brush = new SolidBrush(Color.FromArgb(Opacity, FillColor)))
        {
            GraphicsPath path = new GraphicsPath();
            int radius = CornerRadius;
            path.AddArc(0, 0, radius, radius, 180, 90);
            path.AddArc(this.Width - radius, 0, radius, radius, 270, 90);
            path.AddArc(this.Width - radius, this.Height - radius, radius, radius, 0, 90);
            path.AddArc(0, this.Height - radius, radius, radius, 90, 90);
            path.CloseAllFigures();

            g.FillPath(brush, path);
            g.DrawPath(Pens.Gray, path);
        }

        // Draw the text
        TextRenderer.DrawText(g, this.Text, this.Font, this.ClientRectangle, this.ForeColor,
                              TextFormatFlags.HorizontalCenter | TextFormatFlags.VerticalCenter);
    }
}
