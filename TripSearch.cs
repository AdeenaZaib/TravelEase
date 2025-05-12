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

                // You can also add for price range or group size etc.
            }
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

            string con = "Data Source=.\\SQLEXPRESS;Initial Catalog=TravelEase;Integrated Security=True";

            string query = @"SELECT TripID, TripTitle, Destination.DestinationName FROM Trip JOIN Destination ON Trip.DestinationID = Destination.DestinationID WHERE Trip.StartDate > GETDATE()";

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

                    // Populate the list view
                    foreach (DataRow row in dataTable.Rows)
                    {
                        ListViewItem item = new ListViewItem(row["TripID"].ToString());
                        item.SubItems.Add(row["TripTitle"].ToString());
                        item.SubItems.Add(row["DestinationName"].ToString());
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
    }
}
