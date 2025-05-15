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
    public partial class TripSearch : Form
    {
        public TripSearch()
        {
            InitializeComponent();
        }

        string con = "Data Source=.\\SQLEXPRESS;Initial Catalog=TravelEase;Integrated Security=True";

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
                    destinationComboBox.Items.Add(destReader["DestinationName"].ToString());
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

                string accquery = "SELECT DISTINCT Accessibility FROM Trip";
                SqlCommand accCmd = new SqlCommand(accquery, conn);
                SqlDataReader accReader = accCmd.ExecuteReader();
                while (accReader.Read())
                {
                    comboBox1.Items.Add(accReader["Accessibility"].ToString());
                }

                // You can also add for price range or group size etc.
            }
        }

        private void destinationComboBox_SelectedIndexChanged(object sender, EventArgs e)
        {
            reviewview.Visible = false;
            tripview.Visible = true;
        }

        private void typecombo_SelectedIndexChanged(object sender, EventArgs e)
        {
            reviewview.Visible = false;
            tripview.Visible = true;
        }

        private void price_TextChanged(object sender, EventArgs e)
        {
            reviewview.Visible = false;
            tripview.Visible = true;
        }

        private void minPriceUpDown_ValueChanged(object sender, EventArgs e)
        {
            reviewview.Visible = false;
            tripview.Visible = true;
        }


        private void TripSearch_Load(object sender, EventArgs e)
        {
            //filterOptions.Items.Add("Destination");
            //filterOptions.Items.Add("Trip Type");
            //filterOptions.Items.Add("Price Range");
            //filterOptions.Items.Add("Group Size");
            //filterOptions.Items.Add("Date Range");
            //filterOptions.Items.Add("Accessibility");
            LoadFilterOptions();
            reviewview.Visible = false;
            tripview.Visible = true;

            string con = "Data Source=.\\SQLEXPRESS;Initial Catalog=TravelEase;Integrated Security=True";

            string query = @"SELECT TripID, TripTitle, Destination.DestinationName, TripType, Capacity, CapacityType, PriceRange, Accessibility, StartDate, EndDate FROM Trip JOIN Destination ON Trip.DestinationID = Destination.DestinationID WHERE Trip.StartDate > GETDATE()";

            using (SqlConnection conn = new SqlConnection(con))
            {
                try
                {
                    SqlDataAdapter adapter = new SqlDataAdapter(query, conn);
                    DataTable dataTable = new DataTable();
                    adapter.Fill(dataTable);

                    // Clear previous content
                    tripview.Items.Clear();
                    tripview.View = View.Details;
                    tripview.Columns.Clear();

                    // Add columns (only once)
                    tripview.Columns.Add("Trip ID", 100);
                    tripview.Columns.Add("Trip Title", 150);
                    tripview.Columns.Add("Destination", 150);
                    tripview.Columns.Add("Trip Type", 100);
                    tripview.Columns.Add("Capacity", 100);
                    tripview.Columns.Add("Capacity Type", 100);
                    tripview.Columns.Add("Price Range", 100);
                    tripview.Columns.Add("Accessibility", 100);
                    tripview.Columns.Add("Start Date", 100);
                    tripview.Columns.Add("End Date", 100);

                    // Populate the list view
                    foreach (DataRow row in dataTable.Rows)
                    {
                        ListViewItem item = new ListViewItem(row["TripID"].ToString());
                        item.SubItems.Add(row["TripTitle"].ToString());
                        item.SubItems.Add(row["DestinationName"].ToString());
                        item.SubItems.Add(row["TripType"].ToString());
                        item.SubItems.Add(row["Capacity"].ToString());
                        item.SubItems.Add(row["CapacityType"].ToString());
                        item.SubItems.Add(row["PriceRange"].ToString());
                        item.SubItems.Add(row["Accessibility"].ToString());
                        item.SubItems.Add(Convert.ToDateTime(row["StartDate"]).ToString("yyyy-MM-dd"));
                        item.SubItems.Add(Convert.ToDateTime(row["EndDate"]).ToString("yyyy-MM-dd"));
                        tripview.Items.Add(item);
                    }
                }
                catch (Exception ex)
                {
                    MessageBox.Show("Error: " + ex.Message);
                }

            }
            
        }

        private void comboBox1_SelectedIndexChanged(object sender, EventArgs e)
        {
            reviewview.Visible = false;
            tripview.Visible = true;
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

        private void labelButton4_Click_1(object sender, EventArgs e)
        {
            TripSearch ts = new TripSearch();
            ts.Show();
            this.Hide();
        }

        private void labelButton3_Click_1(object sender, EventArgs e)
        {
            TravellerBooking book = new TravellerBooking();
            book.Show();
            this.Hide();
        }

        private void labelButton5_Click_1(object sender, EventArgs e)
        {
            TravelHistory history = new TravelHistory();
            history.Show();
            this.Hide();
        }

        private void labelButton2_Click(object sender, EventArgs e)
        {
            TravellerPass tp = new TravellerPass();
            tp.Show();
            this.Hide();
        }

        private void apply_Click(object sender, EventArgs e)
        {
            reviewview.Visible = false;
            tripview.Visible = true;
            // Get selected filter values
            string selectedDestination = destinationComboBox.SelectedItem as string;
            string selectedType = typecombo.SelectedItem as string;
            string selectedAccessibility = comboBox1.SelectedItem as string;
            string priceRangeText = price.Text.Trim();
            int groupSize = (int)minPriceUpDown.Value;

            // Build the query dynamically based on selected filters
            StringBuilder query = new StringBuilder();
            query.Append(@"SELECT TripID, TripTitle, Destination.DestinationName, TripType, Capacity, CapacityType, PriceRange, Accessibility, StartDate, EndDate
                   FROM Trip
                   JOIN Destination ON Trip.DestinationID = Destination.DestinationID
                   WHERE Trip.StartDate > GETDATE()");

            // Add filter conditions
            if (!string.IsNullOrEmpty(selectedDestination))
                query.Append(" AND Destination.DestinationName = @DestinationName");
            if (!string.IsNullOrEmpty(selectedType))
                query.Append(" AND Trip.TripType = @TripType");
            if (!string.IsNullOrEmpty(selectedAccessibility))
                query.Append(" AND Trip.Accessibility = @Accessibility");
            if (!string.IsNullOrEmpty(priceRangeText))
                query.Append(" AND Trip.PriceRange = @PriceRange");
            if (groupSize > 0)
                query.Append(" AND Trip.Capacity >= @GroupSize");

            using (SqlConnection conn = new SqlConnection(con))
            {
                try
                {
                    SqlCommand cmd = new SqlCommand(query.ToString(), conn);

                    // Add parameters only if filters are selected
                    if (!string.IsNullOrEmpty(selectedDestination))
                        cmd.Parameters.AddWithValue("@DestinationName", selectedDestination);
                    if (!string.IsNullOrEmpty(selectedType))
                        cmd.Parameters.AddWithValue("@TripType", selectedType);
                    if (!string.IsNullOrEmpty(selectedAccessibility))
                        cmd.Parameters.AddWithValue("@Accessibility", selectedAccessibility);
                    if (!string.IsNullOrEmpty(priceRangeText))
                        cmd.Parameters.AddWithValue("@PriceRange", priceRangeText);
                    if (groupSize > 0)
                        cmd.Parameters.AddWithValue("@GroupSize", groupSize);

                    SqlDataAdapter adapter = new SqlDataAdapter(cmd);
                    DataTable dataTable = new DataTable();
                    adapter.Fill(dataTable);

                    // Update the ListView
                    tripview.Items.Clear();
                    foreach (DataRow row in dataTable.Rows)
                    {
                        ListViewItem item = new ListViewItem(row["TripID"].ToString());
                        item.SubItems.Add(row["TripTitle"].ToString());
                        item.SubItems.Add(row["DestinationName"].ToString());
                        item.SubItems.Add(row["TripType"].ToString());
                        item.SubItems.Add(row["Capacity"].ToString());
                        item.SubItems.Add(row["CapacityType"].ToString());
                        item.SubItems.Add(row["PriceRange"].ToString());
                        item.SubItems.Add(row["Accessibility"].ToString());
                        item.SubItems.Add(Convert.ToDateTime(row["StartDate"]).ToString("yyyy-MM-dd"));
                        item.SubItems.Add(Convert.ToDateTime(row["EndDate"]).ToString("yyyy-MM-dd"));
                        tripview.Items.Add(item);
                    }
                }
                catch (Exception ex)
                {
                    MessageBox.Show("Error: " + ex.Message);
                }
            }
        }

        private void viewbut_Click(object sender, EventArgs e)
        {
            // Ensure a trip is selected
            if (tripview.SelectedItems.Count == 0)
            {
                MessageBox.Show("Please select a trip to view its reviews.");
                return;
            }

            // Get the selected TripID
            int selectedTripID = int.Parse(tripview.SelectedItems[0].SubItems[0].Text);

            // Make the reviewview visible
            reviewview.Visible = true;

            // Clear previous reviews and set up columns if needed
            reviewview.Items.Clear();
            reviewview.View = View.Details;
            if (reviewview.Columns.Count == 0)
            {
                reviewview.Columns.Add("Traveller ID", 100);
                reviewview.Columns.Add("Trip ID", 100);
                reviewview.Columns.Add("Rating", 70);
                reviewview.Columns.Add("Review", 500);
            }

            string query = "SELECT * FROM TripReviews WHERE TripID = @TripID";

            using (SqlConnection conn = new SqlConnection(con))
            {
                try
                {
                    SqlCommand cmd = new SqlCommand(query, conn);
                    cmd.Parameters.AddWithValue("@TripID", selectedTripID);
                    conn.Open();
                    SqlDataReader reader = cmd.ExecuteReader();

                    bool hasReviews = false;
                    while (reader.Read())
                    {
                        hasReviews = true;
                        ListViewItem item = new ListViewItem(reader["TravellerID"].ToString());
                        item.SubItems.Add(reader["TripID"].ToString());
                        item.SubItems.Add(reader["TripRating"].ToString());
                        item.SubItems.Add(reader["TripReview"].ToString());
                        reviewview.Items.Add(item);
                    }

                    if (!hasReviews)
                    {
                        ListViewItem item = new ListViewItem("No reviews found");
                        item.SubItems.Add("");
                        item.SubItems.Add("");
                        reviewview.Items.Add(item);
                    }
                }
                catch (Exception ex)
                {
                    MessageBox.Show("Error loading reviews: " + ex.Message);
                }
            }
        }


    }
}



