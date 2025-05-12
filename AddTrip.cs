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
    public partial class AddTrip : Form
    {
        public AddTrip()
        {
            InitializeComponent();
        }

        string con = "Data Source=.\\SQLEXPRESS;Initial Catalog=TravelEase;Integrated Security=True";
        private void AddTrip_Load(object sender, EventArgs e)
        {
            LoadFilterOptions();
        }

        private void roundedRichTextBox6_Load(object sender, EventArgs e)
        {

        }

        private void roundedRichTextBox8_Load(object sender, EventArgs e)
        {

        }

        void LoadFilterOptions()
        {
            using (SqlConnection conn = new SqlConnection(con))
            {
                conn.Open();

                // Populate Destination comboBox
                string destQuery = "SELECT DISTINCT DestinationName FROM Destination";
                SqlCommand destCmd = new SqlCommand(destQuery, conn);
                SqlDataReader destReader = destCmd.ExecuteReader();
                while (destReader.Read())
                {
                    destinationCombo.Items.Add(destReader["DestinationName"].ToString());
                }
                destReader.Close();

                // Populate Trip Type comboBox
                string typeQuery = "SELECT DISTINCT TripType FROM Trip";
                SqlCommand typeCmd = new SqlCommand(typeQuery, conn);
                SqlDataReader typeReader = typeCmd.ExecuteReader();
                while (typeReader.Read())
                {
                    typecombo.Items.Add(typeReader["TripType"].ToString());
                }
                typeReader.Close();

                string capacityQuery = "SELECT DISTINCT CapacityType FROM Trip";
                SqlCommand capacityCmd = new SqlCommand(capacityQuery, conn);
                SqlDataReader capacityReader = capacityCmd.ExecuteReader();
                while (capacityReader.Read())
                {
                    capcombo.Items.Add(capacityReader["CapacityType"].ToString());
                }
                capacityReader.Close();

                string accQuery = "SELECT DISTINCT Accessibility FROM Trip";
                SqlCommand accCmd = new SqlCommand(accQuery, conn);
                SqlDataReader accReader = accCmd.ExecuteReader();
                while (accReader.Read())
                {
                    accecombo.Items.Add(accReader["Accessibility"].ToString());
                }
            }
        }

        private void roundedButton1_Click(object sender, EventArgs e)
        {
            string connectionString = "Data Source=.\\SQLEXPRESS;Initial Catalog=TravelEase;Integrated Security=True";
            int operatorId = Program.CurrentUser.userid;

            // Input validation (basic)
            if (string.IsNullOrWhiteSpace(tripTitle.Text) ||
                destinationCombo.SelectedIndex == -1 ||
                typecombo.SelectedIndex == -1 ||
                cap.Value == 0 ||
                string.IsNullOrWhiteSpace(price.Text))
            {
                MessageBox.Show("Please fill in all required fields.");
                return;
            }

            using (SqlConnection conn = new SqlConnection(connectionString))
            {
                try
                {
                    conn.Open();

                    // Get DestinationID from name (if destinationCombo holds names)
                    int destinationId;
                    string destQuery = "SELECT DestinationID FROM Destination WHERE DestinationName = @DestinationName";
                    using (SqlCommand destCmd = new SqlCommand(destQuery, conn))
                    {
                        destCmd.Parameters.AddWithValue("@DestinationName", destinationCombo.SelectedItem.ToString());
                        destinationId = (int)destCmd.ExecuteScalar();
                    }

                    // Insert the Trip
                    string insertQuery = @"INSERT INTO Trip 
                (TripTitle, DestinationID, TripType, Capacity, CapacityType, PriceRange, Accessibility, StartDate, EndDate, TourOperatorID)
                VALUES 
                (@TripTitle, @DestinationID, @TripType, @Capacity, @CapacityType, @PriceRange, @Accessibility, @StartDate, @EndDate, @TourOperatorID)";

                    SqlCommand cmd = new SqlCommand(insertQuery, conn);
                    cmd.Parameters.AddWithValue("@TripTitle", tripTitle.Text);
                    cmd.Parameters.AddWithValue("@DestinationID", destinationId);
                    cmd.Parameters.AddWithValue("@TripType", typecombo.SelectedItem.ToString());
                    cmd.Parameters.AddWithValue("@Capacity", (int)cap.Value);
                    cmd.Parameters.AddWithValue("@CapacityType", capcombo.SelectedItem.ToString());
                    cmd.Parameters.AddWithValue("@PriceRange", price.Text);
                    cmd.Parameters.AddWithValue("@Accessibility", accecombo.SelectedItem.ToString());
                    cmd.Parameters.AddWithValue("@StartDate", start.Value.Date);
                    cmd.Parameters.AddWithValue("@EndDate", end.Value.Date);
                    cmd.Parameters.AddWithValue("@TourOperatorID", operatorId);

                    int rows = cmd.ExecuteNonQuery();

                    if (rows > 0)
                    {
                        MessageBox.Show("Trip added successfully.");
                        OpeartorTrip otp = new OpeartorTrip();
                        otp.Show();
                        this.Hide();
                    }
                    else
                    {
                        MessageBox.Show("Trip insertion failed.");
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
