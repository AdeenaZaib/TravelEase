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
    public partial class Sign : Form
    {
        public Sign()
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

        private void textBox1_Load(object sender, EventArgs e)
        {

        }

        private void richTextBox1_TextChanged(object sender, EventArgs e)
        {

        }

        private void label1_Click(object sender, EventArgs e)
        {

        }

        private void label3_Click(object sender, EventArgs e)
        {

        }

        private void label9_Click(object sender, EventArgs e)
        {
            SignUp signUp = new SignUp();
            signUp.Show();
            this.Hide();
        }

        private void roundedButton1_Click(object sender, EventArgs e)
        {
            TravellerHome home = new TravellerHome();
            home.Show();
            this.Hide();
        }

        private void Sign_Load(object sender, EventArgs e)
        {

        }
    }
}
