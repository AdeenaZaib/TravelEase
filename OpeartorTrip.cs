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
using static System.Windows.Forms.VisualStyles.VisualStyleElement.ListView;

namespace dbproject
{
    public partial class OpeartorTrip : Form
    {
        public OpeartorTrip()
        {
            InitializeComponent();
        }

        private void circularPictureBox1_Click(object sender, EventArgs e)
        {

        }

        private void roundedButton1_Click(object sender, EventArgs e)
        {

        }

        private void listView1_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (listView1.SelectedItems.Count > 0)
            {
                var selectedItem = listView1.SelectedItems[0];
                if (combo.SelectedItem != null)
                {
                    string columnName = combo.SelectedItem.ToString();

                    // Get the column index based on name
                    int columnIndex = listView1.Columns
                        .Cast<ColumnHeader>()
                        .ToList()
                        .FindIndex(c => c.Text.Replace(" ", "") == columnName);

                    if (columnIndex >= 0)
                        txt.Text = selectedItem.SubItems[columnIndex].Text;
                }
            }
        }

        private void labelButton1_Click(object sender, EventArgs e)
        {
            Operator op = new Operator();
            op.Show();
            this.Hide();
        }

        private void labelButton4_Click(object sender, EventArgs e)
        {
            OpeartorTrip ot = new OpeartorTrip();
            ot.Show();
            this.Hide();
        }

        private void labelButton3_Click(object sender, EventArgs e)
        {
            AssignServices ass = new AssignServices();
            ass.Show();
            this.Hide();
        }

        private void labelButton5_Click(object sender, EventArgs e)
        {
            OperatorBookings ob = new OperatorBookings();
            ob.Show();
            this.Hide();
        }

        private void labelButton6_Click(object sender, EventArgs e)
        {
            OpeartorAnalytics oa = new OpeartorAnalytics();
            oa.Show();
            this.Hide();
        }

        private void OpeartorTrip_Load(object sender, EventArgs e)
        {
            string con = "Data Source=.\\SQLEXPRESS;Initial Catalog=TravelEase;Integrated Security=True";

            int id = Program.CurrentUser.userid;

            string query = @"SELECT TripID, TripTitle, Destination.DestinationName, TripType, Capacity, CapacityType, PriceRange, Accessibility, StartDate, EndDate  FROM Trip JOIN Destination ON Trip.DestinationID = Destination.DestinationID WHERE Trip.TourOperatorID = @UserID";

            using (SqlConnection conn = new SqlConnection(con))
            {
                try
                {
                    SqlCommand cmd = new SqlCommand(query, conn);
                    cmd.Parameters.AddWithValue("@UserID", id);

                    SqlDataAdapter adapter = new SqlDataAdapter(cmd);
                    DataTable dataTable = new DataTable();
                    adapter.Fill(dataTable);

                    // Clear previous content
                    listView1.Items.Clear();
                    listView1.View = View.Details;
                    listView1.Columns.Clear();

                    // Add columns (only once)
                    listView1.Columns.Add("Trip ID", 100);
                    listView1.Columns.Add("Trip Title", 150);
                    listView1.Columns.Add("Destination", 150);
                    listView1.Columns.Add("Trip Type", 100);
                    listView1.Columns.Add("Capacity", 100);
                    listView1.Columns.Add("Capacity Type", 100);
                    listView1.Columns.Add("Price Range", 100);
                    listView1.Columns.Add("Accessibility", 100);
                    listView1.Columns.Add("Start Date", 100);
                    listView1.Columns.Add("End Date", 100);

                    combo.Items.Add("TripTitle");
                    combo.Items.Add("PriceRange");
                    combo.Items.Add("TripType");
                    combo.Items.Add("Capacity");
                    combo.Items.Add("CapacityType");
                    combo.Items.Add("Accessibility");
                    combo.Items.Add("StartDate");
                    combo.Items.Add("EndDate");
                    combo.Items.Add("DestinationName");

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
                        listView1.Items.Add(item);
                    }
                }
                catch (Exception ex)
                {
                    MessageBox.Show("Error: " + ex.Message);
                }

            }
        }

        private void button2_Click(object sender, EventArgs e)
        {

        }

        private void update_Click(object sender, EventArgs e)
        {
            if (listView1.SelectedItems.Count == 0 || combo.SelectedItem == null || string.IsNullOrWhiteSpace(txt.Text))
            {
                MessageBox.Show("Please select a trip, field, and provide new value.");
                return;
            }

            var selectedItem = listView1.SelectedItems[0];
            int tripID = int.Parse(selectedItem.SubItems[0].Text); // Assuming TripID is first column
            string columnToUpdate = combo.SelectedItem.ToString();
            string newValue = txt.Text;

            string con = "Data Source=.\\SQLEXPRESS;Initial Catalog=TravelEase;Integrated Security=True";
            using (SqlConnection conn = new SqlConnection(con))
            {
                try
                {
                    conn.Open();
                    string query = $"UPDATE Trip SET {columnToUpdate} = @newValue WHERE TripID = @TripID";
                    SqlCommand cmd = new SqlCommand(query, conn);

                    if (columnToUpdate == "Capacity") // if integer field
                        cmd.Parameters.AddWithValue("@newValue", int.Parse(newValue));
                    else if (columnToUpdate.Contains("Date"))
                        cmd.Parameters.AddWithValue("@newValue", DateTime.Parse(newValue));
                    else
                        cmd.Parameters.AddWithValue("@newValue", newValue);

                    cmd.Parameters.AddWithValue("@TripID", tripID);

                    int rows = cmd.ExecuteNonQuery();
                    if (rows > 0)
                    {
                        MessageBox.Show("Trip updated successfully.");
                        OpeartorTrip_Load(sender, e); // Reload data
                    }
                    else
                    {
                        MessageBox.Show("Update failed.");
                    }
                }
                catch (Exception ex)
                {
                    MessageBox.Show("Error: " + ex.Message);
                }
            }
        }

        private void delete_Click(object sender, EventArgs e)
        {
            if (listView1.SelectedItems.Count == 0)
            {
                MessageBox.Show("Please select a trip to delete.");
                return;
            }

            DialogResult result = MessageBox.Show("Are you sure you want to delete this trip? This action cannot be undone.",
                                                  "Confirm Deletion", MessageBoxButtons.YesNo, MessageBoxIcon.Warning);

            if (result == DialogResult.Yes)
            {
                int tripID = int.Parse(listView1.SelectedItems[0].SubItems[0].Text); // TripID

                string con = "Data Source=.\\SQLEXPRESS;Initial Catalog=TravelEase;Integrated Security=True";

                using (SqlConnection conn = new SqlConnection(con))
                {
                    try
                    {
                        conn.Open();
                        string deleteQuery = "DELETE FROM Trip WHERE TripID = @TripID";
                        SqlCommand cmd = new SqlCommand(deleteQuery, conn);
                        cmd.Parameters.AddWithValue("@TripID", tripID);
                        int rows = cmd.ExecuteNonQuery();

                        if (rows > 0)
                        {
                            MessageBox.Show("Trip deleted successfully.");
                            OpeartorTrip_Load(null, null); // Refresh the list
                        }
                        else
                        {
                            MessageBox.Show("Trip could not be deleted.");
                        }
                    }
                    catch (Exception ex)
                    {
                        MessageBox.Show("Error: " + ex.Message);
                    }
                }
            }
        }

        private void button1_Click(object sender, EventArgs e)
        {
            AddTrip trip = new AddTrip();
            trip.Show();
            this.Hide();
        }
    }
}
