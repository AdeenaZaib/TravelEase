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
    public partial class Services : Form
    {
        public Services()
        {
            InitializeComponent();
        }

        private void labelButton4_Click(object sender, EventArgs e)
        {
            transport ts = new transport();
            ts.Show();
            this.Hide();
        }

        private void labelButton1_Click(object sender, EventArgs e)
        {
            Services home = new Services();
            home.Show();
            this.Hide();
        }

        private void labelButton3_Click(object sender, EventArgs e)
        {
            Hotels ht = new Hotels();
            ht.Show();
            this.Hide();
        }

        private void labelButton5_Click(object sender, EventArgs e)
        {
            meals ml = new meals();
            ml.Show();
            this.Hide();
        }

        private void labelButton2_Click(object sender, EventArgs e)
        {
            guides gd = new guides();
            gd.Show();
            this.Hide();
        }
    }
}
