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
    public partial class Analytics : Form
    {
        public Analytics()
        {
            InitializeComponent();
        }

        private void label1_Click(object sender, EventArgs e)
        {

        }

        private void label3_Click(object sender, EventArgs e)
        {

        }

        private void label4_Click(object sender, EventArgs e)
        {

        }

        private void button1_Click(object sender, EventArgs e)
        {
            BookingReportForm brf = new BookingReportForm();
            brf.Show();
            this.Hide();
        }

        private void button2_Click(object sender, EventArgs e)
        {
            TravellerReportForm trf = new TravellerReportForm();
            trf.Show();
            this.Hide();
        }

        private void button3_Click(object sender, EventArgs e)
        {
            OperatorReportForm orf = new OperatorReportForm();
            orf.Show();
            this.Hide();
        }

        private void button4_Click(object sender, EventArgs e)
        {
            ProviderReportForm prf = new ProviderReportForm();
            prf.Show();
            this.Hide();
        }

        private void button5_Click(object sender, EventArgs e)
        {
            ABReportForm abf = new ABReportForm();
            abf.Show();
            this.Hide();
        }

        private void label9_Click(object sender, EventArgs e)
        {
            Admin ah = new Admin();
            ah.Show();
            this.Hide();
        }
    }
}
