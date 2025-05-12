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
    public partial class ManageDestinations : Form
    {
        public ManageDestinations()
        {
            InitializeComponent();
        }

        private void ManageDestinations_Load(object sender, EventArgs e)
        {
            InitializeDestinationView();
            LoadDestinations();
        }

        private void InitializeDestinationView()
        {
            destinationView.View = View.Details;
            destinationView.FullRowSelect = true;
            destinationView.GridLines = true;

            destinationView.Columns.Clear();
            destinationView.Columns.Add("Destination ID", 100);
            destinationView.Columns.Add("Destination Name", 150);
            destinationView.Columns.Add("Country", 120);
            destinationView.Columns.Add("Added Date", 120);
        }

        private void LoadDestinations()
        {
            destinationView.Items.Clear();

            using (SqlConnection con = new SqlConnection("Data Source=.\\SQLEXPRESS;Initial Catalog=TravelEase;Integrated Security=True"))
            {
                string query = "SELECT DestinationID, DestinationName, Country, AddedDate FROM Destination";
                SqlCommand cmd = new SqlCommand(query, con);
                con.Open();
                SqlDataReader reader = cmd.ExecuteReader();

                while (reader.Read())
                {
                    ListViewItem item = new ListViewItem(reader["DestinationID"].ToString());
                    item.SubItems.Add(reader["DestinationName"].ToString());
                    item.SubItems.Add(reader["Country"].ToString());
                    item.SubItems.Add(Convert.ToDateTime(reader["AddedDate"]).ToShortDateString());
                    destinationView.Items.Add(item);
                }
            }
        }

        private void add_Click(object sender, EventArgs e)
        {
            AddDestination AD = new AddDestination();
            AD.Show();
            this.Hide();
        }

        private void labelButton1_Click(object sender, EventArgs e)
        {
            Admin home = new Admin();
            home.Show();
            this.Hide();
        }

        private void labelButton2_Click(object sender, EventArgs e)
        {
            ManageUsers manageUsers = new ManageUsers();
            manageUsers.Show();
            this.Hide();
        }

        private void labelButton5_Click(object sender, EventArgs e)
        {
            ManageDestinations manageDestinations = new ManageDestinations();
            manageDestinations.Show();
            this.Hide();
        }

        private void labelButton3_Click(object sender, EventArgs e)
        {
            ManageReviews manageReviews = new ManageReviews();
            manageReviews.Show();
            this.Hide();

        }

        private void delete_Click(object sender, EventArgs e)
        {
            if (destinationView.SelectedItems.Count == 0)
            {
                MessageBox.Show("Please select a destination to delete.");
                return;
            }

            ListViewItem selectedItem = destinationView.SelectedItems[0];
            int destinationID = int.Parse(selectedItem.SubItems[0].Text);

            DialogResult confirm = MessageBox.Show("Are you sure you want to delete this destination?", "Confirm Delete", MessageBoxButtons.YesNo);
            if (confirm == DialogResult.Yes)
            {
                using (SqlConnection con = new SqlConnection("Data Source=.\\SQLEXPRESS;Initial Catalog=TravelEase;Integrated Security=True"))
                {
                    string query = "DELETE FROM Destination WHERE DestinationID = @id";
                    SqlCommand cmd = new SqlCommand(query, con);
                    cmd.Parameters.AddWithValue("@id", destinationID);
                    con.Open();
                    cmd.ExecuteNonQuery();
                }

                LoadDestinations();
                MessageBox.Show("Destination deleted successfully.");
            }
        }
    }
}
