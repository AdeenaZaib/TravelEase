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
    public partial class Hotels : Form
    {
        public Hotels()
        {
            InitializeComponent();
        }

        private void labelButton1_Click(object sender, EventArgs e)
        {
            Services home = new Services();
            home.Show();
            this.Hide();
        }

        private void labelButton4_Click(object sender, EventArgs e)
        {
            transport ts = new transport();
            ts.Show();
            this.Hide();
        }

        private void labelButton3_Click(object sender, EventArgs e)
        {
            Hotels ht = new Hotels();
            ht.Show();
            this.Hide();
        }

        private void labelButton5_Click(object sender, EventArgs e)
        {
            meals ml = new meals();
            ml.Show();
            this.Hide();
        }

        private void labelButton2_Click(object sender, EventArgs e)
        {
            guides gd = new guides();
            gd.Show();
            this.Hide();
        }

        private void InitializelistView()
        {
            listView1.View = View.Details;
            listView1.FullRowSelect = true;
            listView1.GridLines = true;

            listView1.Columns.Clear();
            listView1.Columns.Add("HotelID", 50);
            listView1.Columns.Add("ServiceID", 100);
            listView1.Columns.Add("HotelName", 100);
            listView1.Columns.Add("Contact", 100);
            listView1.Columns.Add("TotalRooms", 100);
            listView1.Columns.Add("StayRate", 80);

            combo.Items.Add("HotelName");
            combo.Items.Add("Contact");
            combo.Items.Add("TotalRooms");
            combo.Items.Add("StayRate");
        }

        private void LoadHotelData()
        {
            listView1.Items.Clear();

            using (SqlConnection con = new SqlConnection("Data Source=.\\SQLEXPRESS;Initial Catalog=TravelEase;Integrated Security=True"))
            {
                string query = "SELECT HotelID, ServiceID, HotelName, Contact, TotalRooms, StayRate FROM Hotel";

                SqlCommand cmd = new SqlCommand(query, con);

                try
                {
                    con.Open();
                    SqlDataReader reader = cmd.ExecuteReader();

                    while (reader.Read())
                    {
                        ListViewItem item = new ListViewItem(reader["HotelID"].ToString());
                        item.SubItems.Add(reader["ServiceID"].ToString());
                        item.SubItems.Add(reader["HotelName"].ToString());
                        item.SubItems.Add(reader["Contact"].ToString());
                        item.SubItems.Add(reader["TotalRooms"].ToString());
                        item.SubItems.Add(reader["StayRate"].ToString());

                        listView1.Items.Add(item);
                    }

                    reader.Close();
                }
                catch (Exception ex)
                {
                    MessageBox.Show("Error loading transports: " + ex.Message);
                }
            }
        }

        private void button1_Click(object sender, EventArgs e)
        {
            AddHotel addHotel = new AddHotel();
            addHotel.Show();
            this.Hide();
        }

        private void Hotels_Load(object sender, EventArgs e)
        {
            InitializelistView();
            LoadHotelData();
        }

        private void update_Click(object sender, EventArgs e)
        {
            if (listView1.SelectedItems.Count == 0 || combo.SelectedItem == null || string.IsNullOrWhiteSpace(txt.Text))
            {
                MessageBox.Show("Please select a hotel, field, and provide a new value.");
                return;
            }

            var selectedItem = listView1.SelectedItems[0];
            string hotelID = selectedItem.SubItems[0].Text;
            string selectedColumn = combo.SelectedItem.ToString();
            string newValue = txt.Text;

            // Map display column to database column
            string dbColumn = "";

            if (selectedColumn == "HotelName")
                dbColumn = "HotelName";
            else if (selectedColumn == "Contact")
                dbColumn = "Contact";
            else if (selectedColumn == "TotalRooms")
                dbColumn = "TotalRooms";
            else if (selectedColumn == "StayRate")
                dbColumn = "StayRate";
            else
            {
                MessageBox.Show("Invalid column selected.");
                return;
            }

            using (SqlConnection con = new SqlConnection("Data Source=.\\SQLEXPRESS;Initial Catalog=TravelEase;Integrated Security=True"))
            {
                try
                {
                    con.Open();
                    string query = $"UPDATE Hotel SET {dbColumn} = @NewValue WHERE HotelID = @HotelID";
                    SqlCommand cmd = new SqlCommand(query, con);

                    if (dbColumn == "TotalRooms")
                        cmd.Parameters.AddWithValue("@NewValue", int.Parse(newValue));
                    else if (dbColumn == "StayRate")
                        cmd.Parameters.AddWithValue("@NewValue", float.Parse(newValue));
                    else
                        cmd.Parameters.AddWithValue("@NewValue", newValue);

                    cmd.Parameters.AddWithValue("@HotelID", hotelID);

                    int rows = cmd.ExecuteNonQuery();
                    if (rows > 0)
                    {
                        MessageBox.Show("Hotel updated successfully.");
                        LoadHotelData(); // Refresh data
                    }
                    else
                    {
                        MessageBox.Show("Update failed. No matching hotel found.");
                    }
                }
                catch (Exception ex)
                {
                    MessageBox.Show("Error updating hotel: " + ex.Message);
                }
            }
        }

        private void delete_Click(object sender, EventArgs e)
        {
            if (listView1.SelectedItems.Count == 0)
            {
                MessageBox.Show("Please select a hotel to delete.");
                return;
            }

            var selectedItem = listView1.SelectedItems[0];
            string hotelID = selectedItem.SubItems[0].Text;

            DialogResult result = MessageBox.Show("Are you sure you want to delete this hotel?", "Confirm Delete", MessageBoxButtons.YesNo);
            if (result != DialogResult.Yes)
                return;

            using (SqlConnection con = new SqlConnection("Data Source=.\\SQLEXPRESS;Initial Catalog=TravelEase;Integrated Security=True"))
            {
                try
                {
                    con.Open();
                    string query = "DELETE FROM Hotel WHERE HotelID = @HotelID";
                    SqlCommand cmd = new SqlCommand(query, con);
                    cmd.Parameters.AddWithValue("@HotelID", hotelID);

                    int rows = cmd.ExecuteNonQuery();
                    if (rows > 0)
                    {
                        MessageBox.Show("Hotel deleted successfully.");
                        LoadHotelData(); // Refresh data
                    }
                    else
                    {
                        MessageBox.Show("Delete failed. No matching hotel found.");
                    }
                }
                catch (Exception ex)
                {
                    MessageBox.Show("Error deleting hotel: " + ex.Message);
                }
            }
        }
    }
}
