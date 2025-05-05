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
    public partial class ManageUsers : Form
    {
        public ManageUsers()
        {
            InitializeComponent();
        }

        private void labelButton2_Click(object sender, EventArgs e)
        {
            ManageUsers us = new ManageUsers();
            us.Show();
            this.Hide();
        }

        private void labelButton5_Click(object sender, EventArgs e)
        {
            ManageDestinations ds = new ManageDestinations();
            ds.Show();
            this.Hide();
        }

        private void labelButton1_Click(object sender, EventArgs e)
        {
            Admin home = new Admin();
            home.Show();
            this.Hide();
        }
    }
}
