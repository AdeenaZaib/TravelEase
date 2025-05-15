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
    public partial class TravellerHome : Form
    {
        public TravellerHome()
        {
            InitializeComponent();
        }

        private void label5_Click(object sender, EventArgs e)
        {

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

        private void labelButton2_Click(object sender, EventArgs e)
        {
            TravellerPass tp = new TravellerPass();
            tp.Show();
            this.Hide();
        }

        private void updates_Load(object sender, EventArgs e)
        {
            string con = "Data Source=.\\SQLEXPRESS;Initial Catalog=TravelEase;Integrated Security=True";
            int userId = Program.CurrentUser.userid;

            string reminderQuery = "SELECT Rem FROM Reminders WHERE TravellerID = @TravellerID";

            using (SqlConnection conn = new SqlConnection(con))
            {
                try
                {
                    conn.Open();
                    SqlCommand cmd = new SqlCommand(reminderQuery, conn);
                    cmd.Parameters.AddWithValue("@TravellerID", userId);
                    SqlDataReader reader = cmd.ExecuteReader();

                    updates.Items.Clear();
                    updates.View = View.List; // This makes each item appear on a separate line
                    while (reader.Read())
                    {
                        updates.Items.Add(reader["Rem"].ToString());
                    }

                }
                catch (Exception ex)
                {
                    MessageBox.Show("Error loading reminders: " + ex.Message);
                }
            }
        }


        private void TravellerHome_Load(object sender, EventArgs e)
        {
            updates_Load(sender, e);

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
                    listView1.Items.Clear();
                    listView1.View = View.Details;
                    listView1.Columns.Clear();

                    // Add columns (only once)
                    listView1.Columns.Add("Trip ID", 100);
                    listView1.Columns.Add("Trip Title", 150);
                    listView1.Columns.Add("Destination", 150);

                    // Populate the list view
                    foreach (DataRow row in dataTable.Rows)
                    {
                        ListViewItem item = new ListViewItem(row["TripID"].ToString());
                        item.SubItems.Add(row["TripTitle"].ToString());
                        item.SubItems.Add(row["DestinationName"].ToString());
                        listView1.Items.Add(item);
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
