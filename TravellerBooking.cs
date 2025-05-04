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
    }
}
