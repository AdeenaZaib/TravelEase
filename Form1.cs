using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Data.SqlClient;
using System.Drawing;
using System.Drawing.Drawing2D;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using static System.Windows.Forms.VisualStyles.VisualStyleElement.ListView;

namespace dbproject
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
            //panel1.Size = new Size(200, 100); 
            this.Resize += Form1_Resize;
            CenterControls();
            SetRoundedRegion(panel1, 10);  // Use 30 for rounded corners radius
            //panel1.Paint += Panel1_Paint;
        }

        private void CenterControls()
        {
            // Loop through all controls on the form and center them
            foreach (Control control in this.Controls)
            {
                // Calculate new position to center each control
                int x = (this.ClientSize.Width - control.Width) / 2;
                int y = (this.ClientSize.Height - control.Height) / 2;

                // Update the location of each control
                control.Location = new Point(x, y);
            }
        }

        // This event is triggered whenever the form is resized (including maximize and restore)
        private void Form1_Resize(object sender, EventArgs e)
        {
            CenterControls();  // Re-center all controls every time the form is resized
        }


        private void SetRoundedRegion(Panel panel, int radius)
        {
            // Ensure the panel is visible
            if (panel.Width == 0 || panel.Height == 0)
                return;

            // Define the rectangle for the panel
            Rectangle bounds = new Rectangle(0, 0, panel.Width, panel.Height);

            // Create the graphics path for rounding corners
            GraphicsPath path = new GraphicsPath();

            // Calculate the diameter from the radius (to create circular arcs)
            int diameter = radius * 2;

            // Start the path and add rounded corners using arcs
            path.StartFigure();
            path.AddArc(bounds.X, bounds.Y, diameter, diameter, 180, 90);
            path.AddArc(bounds.Right - diameter, bounds.Y, diameter, diameter, 270, 90);
            path.AddArc(bounds.Right - diameter, bounds.Bottom - diameter, diameter, diameter, 0, 90);
            path.AddArc(bounds.X, bounds.Bottom - diameter, diameter, diameter, 90, 90);
            path.CloseFigure();

            // Set the panel's region to the path (this rounds the corners)
            panel.Region = new Region(path);
        }

        private void Panel1_Paint(object sender, PaintEventArgs e)
        {
            Panel panel = sender as Panel;

            if (panel == null) return;

            // Create a shadow effect
            int shadowOffset = 5;  // How much the shadow is offset from the panel
            Color shadowColor = Color.FromArgb(100, 0, 0, 0);  // Transparent black shadow color

            // Draw the shadow
            using (Brush shadowBrush = new SolidBrush(shadowColor))
            {
                // Offset the shadow to the bottom-right corner (adjust as needed)
                e.Graphics.FillRectangle(shadowBrush, new Rectangle(panel.Left + shadowOffset, panel.Top + shadowOffset, panel.Width, panel.Height));
            }
        }

        private void label1_Click(object sender, EventArgs e)
        {

        }

        private void label2_Click(object sender, EventArgs e)
        {

        }

        private void button1_Click(object sender, EventArgs e)
        {
            SqlConnection con = new SqlConnection("Data Source=.\\SQLEXPRESS;Initial Catalog=TravelEase;Integrated Security=True");
            con.Open();

            SqlCommand cm;
            string em = Email.Text;
            string ps = Password.Text;

            string query = "SELECT COUNT(*) FROM Users WHERE Email = @Email AND UserPassword = @Password";
            SqlCommand cmd = new SqlCommand(query, con);

            cmd.Parameters.AddWithValue("@Email", em);
            cmd.Parameters.AddWithValue("@Password", ps);

            int count = (int)cmd.ExecuteScalar();

            if (count > 0)
            {
                MessageBox.Show("Login successful!");
            }
            else
            {
                MessageBox.Show("Invalid email or password.");
            }

            cmd.Dispose();
            con.Close();
        }
    }
}
