using System;
using System.Drawing;
using System.Drawing.Drawing2D;
using System.Windows.Forms;

public class RoundedRichTextBox : UserControl
{
    private RichTextBox _richTextBox = new RichTextBox();

    public int CornerRadius { get; set; } = 15;
    public Color BorderColor { get; set; } = Color.Gray;
    public int BorderWidth { get; set; } = 1;

    public RichTextBox InnerTextBox => _richTextBox;

    public override string Text
    {
        get => _richTextBox.Text;
        set => _richTextBox.Text = value;
    }

    public RoundedRichTextBox()
    {
        this.SetStyle(ControlStyles.UserPaint |
                      ControlStyles.AllPaintingInWmPaint |
                      ControlStyles.OptimizedDoubleBuffer, true);

        _richTextBox.BorderStyle = BorderStyle.None;
        _richTextBox.BackColor = this.BackColor;
        _richTextBox.ForeColor = this.ForeColor;
        _richTextBox.Location = new Point(BorderWidth + 2, BorderWidth + 2);
        _richTextBox.Anchor = AnchorStyles.Top | AnchorStyles.Bottom | AnchorStyles.Left | AnchorStyles.Right;
        _richTextBox.Width = this.Width - 2 * BorderWidth - 4;
        _richTextBox.Height = this.Height - 2 * BorderWidth - 4;

        this.Controls.Add(_richTextBox);
        this.Padding = new Padding(BorderWidth + 2);
        this.BackColor = Color.White;
        this.Resize += (s, e) =>
        {
            _richTextBox.Width = this.Width - 2 * BorderWidth - 4;
            _richTextBox.Height = this.Height - 2 * BorderWidth - 4;
        };
    }

    protected override void OnPaint(PaintEventArgs e)
    {
        base.OnPaint(e);
        e.Graphics.SmoothingMode = SmoothingMode.AntiAlias;

        using (GraphicsPath path = RoundedRect(new Rectangle(0, 0, this.Width - 1, this.Height - 1), CornerRadius))
        using (Pen pen = new Pen(BorderColor, BorderWidth))
        {
            this.Region = new Region(path);
            e.Graphics.DrawPath(pen, path);
        }
    }

    private GraphicsPath RoundedRect(Rectangle bounds, int radius)
    {
        int diameter = radius * 2;
        GraphicsPath path = new GraphicsPath();

        path.StartFigure();
        path.AddArc(bounds.X, bounds.Y, diameter, diameter, 180, 90);
        path.AddArc(bounds.Right - diameter, bounds.Y, diameter, diameter, 270, 90);
        path.AddArc(bounds.Right - diameter, bounds.Bottom - diameter, diameter, diameter, 0, 90);
        path.AddArc(bounds.X, bounds.Bottom - diameter, diameter, diameter, 90, 90);
        path.CloseFigure();

        return path;
    }
}
