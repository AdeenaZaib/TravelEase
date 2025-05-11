using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Data.SqlClient;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using static System.Windows.Forms.VisualStyles.VisualStyleElement;

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
            actionComboBox.Items.AddRange(new string[] { "Cancel", "Confirm", "Refund", "InProgress" });
        }

        private void LoadTravellerBooking()
        {
            // Load the bookings into the ListView
            string con = "Data Source=.\\SQLEXPRESS;Initial Catalog=TravelEase;Integrated Security=True";

            int id = Program.CurrentUser.userid;

            string query = @"SELECT BookingID, TripBooking.TripID, Trip.TripTitle, Destination.DestinationName, BookingStatus, NoOfPeople, BookingDate
                            FROM TripBooking JOIN Trip ON Trip.TripID = TripBooking.TripID JOIN Destination ON Trip.DestinationID = Destination.DestinationID WHERE TravellerID = @TravellerID";

            using (SqlConnection conn = new SqlConnection(con))
            {
                try
                {
                    SqlCommand cmd = new SqlCommand(query, conn);
                    cmd.Parameters.AddWithValue("@TravellerID", id);

                    SqlDataAdapter adapter = new SqlDataAdapter(cmd);
                    DataTable dataTable = new DataTable();
                    adapter.Fill(dataTable);

                    // Clear previous content
                    bookingsView.Items.Clear();
                    bookingsView.View = View.Details;
                    bookingsView.Columns.Clear();

                    // Add columns (only once)
                    bookingsView.Columns.Add("Booking ID", 100);
                    bookingsView.Columns.Add("Trip ID", 100);
                    bookingsView.Columns.Add("Trip Title", 150);
                    bookingsView.Columns.Add("Destination", 150);
                    bookingsView.Columns.Add("Booking Status", 100);
                    bookingsView.Columns.Add("No of People", 100);
                    bookingsView.Columns.Add("Booking Date", 100);

                    // Populate the list view
                    foreach (DataRow row in dataTable.Rows)
                    {
                        ListViewItem item = new ListViewItem(row["BookingID"].ToString());
                        item.SubItems.Add(row["TripID"].ToString());
                        item.SubItems.Add(row["TripTitle"].ToString());
                        item.SubItems.Add(row["DestinationName"].ToString());
                        item.SubItems.Add(row["BookingStatus"].ToString());
                        item.SubItems.Add(row["NoOfPeople"].ToString());
                        item.SubItems.Add(row["BookingDate"].ToString());
                        bookingsView.Items.Add(item);
                    }
                }
                catch (Exception ex)
                {
                    MessageBox.Show("Error: " + ex.Message);
                }

            }
        }

        private void TravellerBooking_Load(object sender, EventArgs e)
        {
            LoadFilters();
            LoadTravellerBooking();
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

        private void bookingsView_SelectedIndexChanged(object sender, EventArgs e)
        {
            
        }

        private void apply_Click(object sender, EventArgs e)
        {
            string con = "Data Source=.\\SQLEXPRESS;Initial Catalog=TravelEase;Integrated Security=True";

            string query = @"UPDATE TripBooking SET BookingStatus = @BookingStatus WHERE BookingID = @BookingID";
            using (SqlConnection conn = new SqlConnection(con))
            {
                try
                {
                    conn.Open();
                    SqlCommand cmd = new SqlCommand(query, conn);
                    cmd.Parameters.AddWithValue("@BookingStatus", actionComboBox.SelectedItem.ToString());
                    cmd.Parameters.AddWithValue("@BookingID", bookingsView.SelectedItems[0].SubItems[0].Text);
                    int rowsAffected = cmd.ExecuteNonQuery();
                    if (rowsAffected > 0)
                    {
                        if (actionComboBox.SelectedItem.ToString() == "Cancel")
                        {
                            MessageBox.Show("Booking cancelled successfully.");
                        }
                        else if (actionComboBox.SelectedItem.ToString() == "Confirm")
                        {
                            MessageBox.Show("Booking confirmed successfully.");
                        }
                        else if (actionComboBox.SelectedItem.ToString() == "Refund")
                        {
                            MessageBox.Show("Booking refunded successfully.");
                        }
                        else
                        {
                            MessageBox.Show("Booking status updated successfully.");
                        }
                        LoadTravellerBooking();
                    }
                    else
                    {
                        MessageBox.Show("Error updating booking status.");
                    }
                }
                catch (Exception ex)
                {
                    MessageBox.Show("Error: " + ex.Message);
                }
            }

        }
    }
}
