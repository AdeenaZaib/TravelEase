using System.Windows.Forms;

public class FullscreenForm : Form
{
    public FullscreenForm()
    {
        this.FormBorderStyle = FormBorderStyle.Sizable;
        this.WindowState = FormWindowState.Maximized;
        this.ControlBox = true;
        this.MinimizeBox = true;
        this.MaximizeBox = true;
    }
}

