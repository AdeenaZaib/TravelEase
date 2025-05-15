using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Data.SqlClient;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace dbproject
{
    public partial class BookTrip : Form
    {
        private int tripId;
        public BookTrip(int tripID)
        {
            InitializeComponent();
            this.tripId = tripID;
        }

        private void label9_Click(object sender, EventArgs e)
        {
            TripSearch ts = new TripSearch();
            ts.Show();
            this.Hide();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            TravellerBooking book = new TravellerBooking();
            book.Show();
            this.Hide();
        }



    }
}
