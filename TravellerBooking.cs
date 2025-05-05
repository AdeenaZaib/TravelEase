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
    public partial class TravellerBooking : Form
    {
        public TravellerBooking()
        {
            InitializeComponent();
        }

        private void LoadFilters()
        {
            actionComboBox.Items.AddRange(new string[] { "Cancel", "Confirm", "Refund" });
        }

        private void TravellerBooking_Load(object sender, EventArgs e)
        {
            LoadFilters();
        }



        private void label2_Click(object sender, EventArgs e)
        {

        }

        private void labelButton1_Click(object sender, EventArgs e)
        {
            TravellerHome home = new TravellerHome();
            home.Show();
            this.Hide();
        }

        private void labelButton4_Click(object sender, EventArgs e)
        {
            TripSearch ts = new TripSearch();  
            ts.Show();
            this.Hide();
        }

        private void labelButton3_Click(object sender, EventArgs e)
        {
            TravellerBooking book = new TravellerBooking();
            book.Show();
            this.Hide();
        }

        private void labelButton5_Click(object sender, EventArgs e)
        {
            TravelHistory history = new TravelHistory();   
            history.Show();
            this.Hide();
        }

        private void button1_Click(object sender, EventArgs e)
        {

        }

        private void labelButton2_Click(object sender, EventArgs e)
        {
            TravellerPass tp = new TravellerPass();
            tp.Show();
            this.Hide();
        }
    }
}
