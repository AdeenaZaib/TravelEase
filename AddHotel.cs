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
    public partial class AddHotel : Form
    {
        public AddHotel()
        {
            InitializeComponent();
        }

        private void label6_Click(object sender, EventArgs e)
        {

        }

        private void button1_Click(object sender, EventArgs e)
        {
            int providerID = Program.CurrentUser.userid; // Get current logged-in service provider ID
            string hotelName = hname.Text;
            string hotelContact = contact.Text;
            string hotelAddress = address.Text;
            int totalRooms = int.Parse(rooms.Text);      // Consider validating inputs
            decimal stayRate = decimal.Parse(rate.Text); // Consider validating inputs
            DateTime joinDate = DateTime.Today;

            using (SqlConnection con = new SqlConnection("Data Source=.\\SQLEXPRESS;Initial Catalog=TravelEase;Integrated Security=True"))
            {
                con.Open();
                SqlTransaction transaction = con.BeginTransaction();

                try
                {
                    // 1. Insert into TripServices and get new ServiceID
                    string insertServiceQuery = "INSERT INTO TripServices (ServiceProviderID) VALUES (@spid); SELECT SCOPE_IDENTITY();";
                    SqlCommand cmdService = new SqlCommand(insertServiceQuery, con, transaction);
                    cmdService.Parameters.AddWithValue("@spid", providerID);
                    int newServiceID = Convert.ToInt32(cmdService.ExecuteScalar());

                    // 2. Generate a new HotelID
                    string getHotelIDQuery = "SELECT ISNULL(MAX(HotelID), 0) + 1 FROM Hotel";
                    SqlCommand cmdGetHotelID = new SqlCommand(getHotelIDQuery, con, transaction);
                    int newHotelID = Convert.ToInt32(cmdGetHotelID.ExecuteScalar());

                    // 3. Insert into Hotel table
                    string insertHotelQuery = @"
                    INSERT INTO Hotel (HotelID, ServiceID, HotelName, HotelAddress, Contact, JoiningDate, TotalRooms, StayRate)
                    VALUES (@hid, @sid, @hname, @haddr, @hcontact, @jdate, @rooms, @rate)";
                    SqlCommand cmdHotel = new SqlCommand(insertHotelQuery, con, transaction);
                    cmdHotel.Parameters.AddWithValue("@hid", newHotelID);
                    cmdHotel.Parameters.AddWithValue("@sid", newServiceID);
                    cmdHotel.Parameters.AddWithValue("@hname", hotelName);
                    cmdHotel.Parameters.AddWithValue("@haddr", hotelAddress);
                    cmdHotel.Parameters.AddWithValue("@hcontact", hotelContact);
                    cmdHotel.Parameters.AddWithValue("@jdate", joinDate);
                    cmdHotel.Parameters.AddWithValue("@rooms", totalRooms);
                    cmdHotel.Parameters.AddWithValue("@rate", stayRate);

                    cmdHotel.ExecuteNonQuery();

                    transaction.Commit();
                    MessageBox.Show("Hotel added successfully.");
                }
                catch (Exception ex)
                {
                    transaction.Rollback();
                    MessageBox.Show("Error: " + ex.Message);
                }

                Services home = new Services();
                home.Show();
                this.Hide();
            }
        }
    } 
}
