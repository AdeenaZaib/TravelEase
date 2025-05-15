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
    public partial class AddGuide : Form
    {
        public AddGuide()
        {
            InitializeComponent();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            string name = guideName.Text.Trim();
            string contactInfo = contact.Text.Trim();
            string experienceText = experience.Text.Trim();
            decimal hourlyRate;

            if (!decimal.TryParse(rate.Text.Trim(), out hourlyRate))
            {
                MessageBox.Show("Invalid hourly rate.");
                return;
            }

            int serviceProviderID = Program.CurrentUser.userid;
            DateTime joiningDate = DateTime.Now;
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
                    string insertGuideQuery = @"
                INSERT INTO TourGuide 
                (ServiceID, GuideName, Contact, JoiningDate, GuideAvailability, HourlyRate, Experience)
                VALUES 
                (@sid, @name, @contact, @joiningDate, @availability, @rate, @experience)";

                    SqlCommand guideCmd = new SqlCommand(insertGuideQuery, con, transaction);
                    guideCmd.Parameters.AddWithValue("@sid", newServiceID);
                    guideCmd.Parameters.AddWithValue("@name", name);
                    guideCmd.Parameters.AddWithValue("@contact", contactInfo);
                    guideCmd.Parameters.AddWithValue("@joiningDate", joiningDate);
                    guideCmd.Parameters.AddWithValue("@availability", availability);
                    guideCmd.Parameters.AddWithValue("@rate", hourlyRate);
                    guideCmd.Parameters.AddWithValue("@experience", experienceText);

                    guideCmd.ExecuteNonQuery();

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

        private void label9_Click(object sender, EventArgs e)
        {
            guides gd = new guides();
            gd.Show();
            this.Hide();
        }
    }
}
