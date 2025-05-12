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
    public partial class AddTransport : Form
    {
        public AddTransport()
        {
            InitializeComponent();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            string name = type.Text.Trim();
            string contactInfo = contact.Text.Trim();
            decimal hourlyRate;

            if (!decimal.TryParse(rate.Text.Trim(), out hourlyRate))
            {
                MessageBox.Show("Invalid hourly rate.");
                return;
            }

            int serviceProviderID = Program.CurrentUser.userid;
            string availability = "Available";

            using (SqlConnection con = new SqlConnection("Data Source=.\\SQLEXPRESS;Initial Catalog=TravelEase;Integrated Security=True"))
            {
                con.Open();
                SqlTransaction transaction = con.BeginTransaction();

                try
                {
                    // Step 1: Insert into TripServices
                    string insertServiceQuery = @"
                INSERT INTO TripServices (ServiceProviderID) 
                VALUES (@spid);
                SELECT SCOPE_IDENTITY();";

                    SqlCommand serviceCmd = new SqlCommand(insertServiceQuery, con, transaction);
                    serviceCmd.Parameters.AddWithValue("@spid", serviceProviderID);

                    int newServiceID = Convert.ToInt32(serviceCmd.ExecuteScalar());

                    // Step 2: Insert into TourGuide
                    string insertTransportQuery = @"
                INSERT INTO Transport 
                (ServiceID, TransportType, Contact, TAvailability, Rate)
                VALUES 
                (@sid, @type, @contact, @availability, @rate)";

                    SqlCommand transportCmd = new SqlCommand(insertTransportQuery, con, transaction);
                    transportCmd.Parameters.AddWithValue("@sid", newServiceID);
                    transportCmd.Parameters.AddWithValue("@type", name);
                    transportCmd.Parameters.AddWithValue("@contact", contactInfo);
                    transportCmd.Parameters.AddWithValue("@availability", availability);
                    transportCmd.Parameters.AddWithValue("@rate", hourlyRate);

                    transportCmd.ExecuteNonQuery();

                    transaction.Commit();
                    MessageBox.Show("Guide added successfully.");
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
