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
    public partial class Destination : Form
    {
        public Destination()
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

        private void Destination_Load(object sender, EventArgs e)
        {

        }

        private void whiteTranslucentPanel1_Paint(object sender, PaintEventArgs e)
        {

        }

        private void panelGradientRounded1_Paint(object sender, PaintEventArgs e)
        {

        }

        private void button1_Click(object sender, EventArgs e)
        {

        }

        private void label2_Click(object sender, EventArgs e)
        {

        }

        private void label3_Click(object sender, EventArgs e)
        {

        }

        private void label4_Click(object sender, EventArgs e)
        {

        }

        private void labelButton2_Click(object sender, EventArgs e)
        {

        }

        private void pictureBox1_Click(object sender, EventArgs e)
        {

        }

        private void transparentButton2_Click(object sender, EventArgs e)
        {

        }

        private void transparentButton1_Click(object sender, EventArgs e)
        {

        }
    }
}
