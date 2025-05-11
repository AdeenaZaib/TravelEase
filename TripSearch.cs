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

        private void TripSearch_Load(object sender, EventArgs e)
        {
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
            filterOptions.Items.Add("Destination");
            filterOptions.Items.Add("Price");
            filterOptions.Items.Add("Date");
            filterOptions.Items.Add("Activity Type");

            // Hide all controls initially
            destinationComboBox.Visible = false;
            minPriceUpDown.Visible = maxPriceUpDown.Visible = false;
            startDatePicker.Visible = endDatePicker.Visible = false;
            activityListBox.Visible = false;
        }

        private void filterOptions_ItemCheck(object sender, ItemCheckEventArgs e)
        {
            // Delay visibility change until item is actually checked
            this.BeginInvoke((MethodInvoker)(() =>
            {
                string selected = filterOptions.Items[e.Index].ToString();
                bool isChecked = filterOptions.GetItemChecked(e.Index);

                switch (selected)
                {
                    case "Destination":
                        destinationComboBox.Visible = !isChecked;
                        break;
                    case "Price":
                        minPriceUpDown.Visible = maxPriceUpDown.Visible = !isChecked;
                        break;
                    case "Date":
                        startDatePicker.Visible = endDatePicker.Visible = !isChecked;
                        break;
                    case "Activity Type":
                        activityListBox.Visible = !isChecked;
                        break;
                }
            }));
        }

        private void applyFilterButton_Click(object sender, EventArgs e)
        {
            string query = "SELECT * FROM Trips WHERE 1=1";

            if (destinationComboBox.Visible && destinationComboBox.SelectedItem != null)
                query += $" AND Destination = '{destinationComboBox.SelectedItem}'";

            if (minPriceUpDown.Visible)
                query += $" AND Price >= {minPriceUpDown.Value}";

            if (maxPriceUpDown.Visible)
                query += $" AND Price <= {maxPriceUpDown.Value}";

            if (startDatePicker.Visible)
                query += $" AND TripDate >= '{startDatePicker.Value.ToShortDateString()}'";

            if (endDatePicker.Visible)
                query += $" AND TripDate <= '{endDatePicker.Value.ToShortDateString()}'";

            if (activityListBox.Visible)
            {
                List<string> activities = new List<string>();
                foreach (var item in activityListBox.CheckedItems)
                    activities.Add($"'{item.ToString()}'");

                if (activities.Any())
                    query += $" AND ActivityType IN ({string.Join(",", activities)})";
            }

            MessageBox.Show("Generated Query:\n" + query);
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
