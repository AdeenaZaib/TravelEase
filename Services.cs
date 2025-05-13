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
using static System.Windows.Forms.VisualStyles.VisualStyleElement;

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

        private void InitializeServicesView()
        {
            servicesView.View = View.Details;
            servicesView.FullRowSelect = true;
            servicesView.GridLines = true;

            servicesView.Columns.Clear();
            servicesView.Columns.Add("ServiceID", 100);
            servicesView.Columns.Add("TourOperatorID", 120);
            servicesView.Columns.Add("TravellerID", 120);
            servicesView.Columns.Add("BookingStatus", 180);
            servicesView.Columns.Add("BookingDate", 120);
        }

        private void LoadBookings()
        {
            servicesView.Items.Clear();

            int providerID = Program.CurrentUser.userid; // Get current service provider ID

            using (SqlConnection con = new SqlConnection("Data Source=.\\SQLEXPRESS;Initial Catalog=TravelEase;Integrated Security=True"))
            {
                string query = @"
                SELECT sb.ServiceID, sb.TourOperatorID, sb.TravellerID, sb.BookingStatus, sb.BookingDate
                FROM ServicesBooked sb
                INNER JOIN TripServices ts ON sb.ServiceID = ts.ServiceID
                WHERE ts.ServiceProviderID = @ServiceProviderID"; // Filter bookings for the current service provider

                SqlCommand cmd = new SqlCommand(query, con);
                cmd.Parameters.AddWithValue("@ServiceProviderID", providerID);

                try
                {
                    con.Open();
                    SqlDataReader reader = cmd.ExecuteReader();

                    while (reader.Read())
                    {
                        ListViewItem item = new ListViewItem(reader["ServiceID"].ToString());
                        item.SubItems.Add(reader["TourOperatorID"].ToString());
                        item.SubItems.Add(reader["TravellerID"].ToString());
                        item.SubItems.Add(reader["BookingStatus"].ToString());
                        item.SubItems.Add(Convert.ToDateTime(reader["BookingDate"]).ToShortDateString());

                        servicesView.Items.Add(item);
                    }

                    reader.Close();
                }
                catch (Exception ex)
                {
                    MessageBox.Show("Error loading service bookings: " + ex.Message);
                }
            }
        }

        private void approve_Click(object sender, EventArgs e)
        {
            if (servicesView.SelectedItems.Count == 0)
            {
                MessageBox.Show("Please select a booking to accept.");
                return;
            }

            var selectedItem = servicesView.SelectedItems[0];
            int serviceID = int.Parse(selectedItem.SubItems[0].Text);
            int tourOperatorID = int.Parse(selectedItem.SubItems[1].Text);
            int travellerID = int.Parse(selectedItem.SubItems[2].Text);

            UpdateBookingStatus(serviceID, tourOperatorID, travellerID, "Booked");
        }

        private void reject_Click(object sender, EventArgs e)
        {
            if (servicesView.SelectedItems.Count == 0)
            {
                MessageBox.Show("Please select a booking to reject.");
                return;
            }

            var selectedItem = servicesView.SelectedItems[0];
            int serviceID = int.Parse(selectedItem.SubItems[0].Text);
            int tourOperatorID = int.Parse(selectedItem.SubItems[1].Text);
            int travellerID = int.Parse(selectedItem.SubItems[2].Text);

            UpdateBookingStatus(serviceID, tourOperatorID, travellerID, "Cancelled");
        }

        private void UpdateBookingStatus(int serviceID, int tourOperatorID, int travellerID, string status)
        {
            using (SqlConnection con = new SqlConnection("Data Source=.\\SQLEXPRESS;Initial Catalog=TravelEase;Integrated Security=True"))
            {
                try
                {
                    con.Open();
                    string query = "UPDATE ServicesBooked SET BookingStatus = @Status WHERE ServiceID = @ServiceID AND TourOperatorID = @TourOperatorID AND TravellerID = @TravellerID";
                    SqlCommand cmd = new SqlCommand(query, con);

                    cmd.Parameters.AddWithValue("@Status", status);
                    cmd.Parameters.AddWithValue("@ServiceID", serviceID);
                    cmd.Parameters.AddWithValue("@TourOperatorID", tourOperatorID);
                    cmd.Parameters.AddWithValue("@TravellerID", travellerID);

                    int rows = cmd.ExecuteNonQuery();
                    if (rows > 0)
                    {
                        MessageBox.Show($"{status} the booking successfully.");
                        LoadBookings(); // Refresh the list view
                    }
                    else
                    {
                        MessageBox.Show("Update failed. No matching booking found.");
                    }
                }
                catch (Exception ex)
                {
                    MessageBox.Show("Error updating booking status: " + ex.Message);
                }
            }
        }

        private void Services_Load(object sender, EventArgs e)
        {
            InitializeServicesView();
            LoadBookings();
        }
    }
}
