using System;
using System.Drawing;
using System.Drawing.Drawing2D;
using System.Windows.Forms;

public class LabelButton : Button
{
    public int CornerRadius { get; set; } = 10;
    public Color FillColor { get; set; } = Color.Transparent; // semi-transparent blue
    public Color BorderColor { get; set; } = Color.Transparent;
    public int BorderThickness { get; set; } = 2;

    public LabelButton()
    {
        this.FlatStyle = FlatStyle.Flat;
        this.FlatAppearance.BorderSize = 0;
        this.BackColor = Color.Transparent;
        this.ForeColor = Color.Black;
        this.DoubleBuffered = true;
        this.SetStyle(ControlStyles.SupportsTransparentBackColor | ControlStyles.AllPaintingInWmPaint | ControlStyles.OptimizedDoubleBuffer | ControlStyles.UserPaint, true);
    }

    protected override void OnPaint(PaintEventArgs e)
    {
        base.OnPaint(e);
        Graphics g = e.Graphics;
        g.SmoothingMode = SmoothingMode.AntiAlias;

        Rectangle bounds = this.ClientRectangle;
        using (GraphicsPath path = GetRoundRectangle(bounds, CornerRadius))
        using (SolidBrush brush = new SolidBrush(FillColor))
        using (Pen pen = new Pen(BorderColor, BorderThickness))
        {
            g.FillPath(brush, path);
            g.DrawPath(pen, path);
        }

        // Draw text centered
        TextRenderer.DrawText(g, this.Text, this.Font, bounds, this.ForeColor, TextFormatFlags.HorizontalCenter | TextFormatFlags.VerticalCenter);
    }

    private GraphicsPath GetRoundRectangle(Rectangle r, int radius)
    {
        GraphicsPath path = new GraphicsPath();
        int d = radius * 2;
        path.StartFigure();
        path.AddArc(r.Left, r.Top, d, d, 180, 90);
        path.AddArc(r.Right - d, r.Top, d, d, 270, 90);
        path.AddArc(r.Right - d, r.Bottom - d, d, d, 0, 90);
        path.AddArc(r.Left, r.Bottom - d, d, d, 90, 90);
        path.CloseFigure();
        return path;
    }
}