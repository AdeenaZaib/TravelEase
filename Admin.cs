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
    public partial class Admin : Form
    {
        public Admin()
        {
            InitializeComponent();
        }

        private void labelButton2_Click(object sender, EventArgs e)
        {
            ManageUsers home = new ManageUsers();
            home.Show();
            this.Hide();
        }

        private void labelButton1_Click(object sender, EventArgs e)
        {
            Admin users = new Admin();
            users.Show();
            this.Hide();
        }

        private void labelButton5_Click(object sender, EventArgs e)
        {
            ManageDestinations ds = new ManageDestinations();
            ds.Show();
            this.Hide();
        }

        private void labelButton3_Click(object sender, EventArgs e)
        {
            ManageReviews mr = new ManageReviews();
            mr.Show();
            this.Hide();
        }

        private void labelButton4_Click(object sender, EventArgs e)
        {
            BookingReportForm brf = new BookingReportForm();
            brf.Show();
            this.Hide();
        }
    }
}
