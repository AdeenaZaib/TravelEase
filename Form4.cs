using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace dbproject
{
    public partial class SignUp : Form
    {
        public SignUp()
        {
            InitializeComponent();
            this.Resize += Form1_Resize;
            CenterControls();
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

        private void Form4_Load(object sender, EventArgs e)
        {

        }

        private void button1_Click(object sender, EventArgs e)
        {

        }

        private void label1_Click(object sender, EventArgs e)
        {

        }

        private void linkLabel1_LinkClicked(object sender, LinkLabelLinkClickedEventArgs e)
        {
            Form3 login = new Form3();
            login.Show();
            this.Hide();
        }

        private void roundedButton1_Click(object sender, EventArgs e)
        {
            Sign sign = new Sign();
            sign.Show();
            this.Hide();
        }

        private void roundedButton3_Click(object sender, EventArgs e)
        {
            OpeartorTrip opt = new OpeartorTrip();
            opt.Show();
            this.Hide();
        }

        private void roundedButton4_Click(object sender, EventArgs e)
        {
            Sign sign = new Sign();
            sign.Show();
            this.Hide();
        }
    }
}
