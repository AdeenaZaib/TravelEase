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
    public partial class transport : Form
    {
        public transport()
        {
            InitializeComponent();
        }

        private void labelButton3_Click(object sender, EventArgs e)
        {
            Hotels ht = new Hotels();
            ht.Show();
            this.Hide();
        }

        private void labelButton1_Click(object sender, EventArgs e)
        {
            Services home = new Services();
            home.Show();
            this.Hide();
        }

        private void labelButton4_Click(object sender, EventArgs e)
        {
            transport tp = new transport();
            tp.Show();
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
            listView1.Columns.Add("RegID", 50);
            listView1.Columns.Add("Type", 100);
            listView1.Columns.Add("Contact", 100);
            listView1.Columns.Add("Avaibility", 100);
            listView1.Columns.Add("Rate", 80);

            combo.Items.Add("TransportType");
            combo.Items.Add("Contact");
            combo.Items.Add("Availability");
            combo.Items.Add("Rate");
        }
        private void LoadTransportData()
        {
            listView1.Items.Clear();

            using (SqlConnection con = new SqlConnection("Data Source=.\\SQLEXPRESS;Initial Catalog=TravelEase;Integrated Security=True"))
            {
                string query = "SELECT RegID, TransportType, Contact, TAvailability, Rate FROM Transport";

                SqlCommand cmd = new SqlCommand(query, con);

                try
                {
                    con.Open();
                    SqlDataReader reader = cmd.ExecuteReader();

                    while (reader.Read())
                    {
                        ListViewItem item = new ListViewItem(reader["RegID"].ToString());
                        item.SubItems.Add(reader["TransportType"].ToString());
                        item.SubItems.Add(reader["Contact"].ToString());
                        item.SubItems.Add(reader["TAvailability"].ToString());
                        item.SubItems.Add(reader["Rate"].ToString());

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
            AddTransport addTransport = new AddTransport();
            addTransport.Show();
            this.Hide();
        }

        private void transport_Load(object sender, EventArgs e)
        {
            InitializelistView();
            LoadTransportData();
        }

        private void delete_Click(object sender, EventArgs e)
        {
            if (listView1.SelectedItems.Count == 0)
            {
                MessageBox.Show("Please select a transport to delete.");
                return;
            }

            DialogResult confirm = MessageBox.Show("Are you sure you want to delete this transport?",
                                                   "Confirm Deletion", MessageBoxButtons.YesNo, MessageBoxIcon.Warning);

            if (confirm == DialogResult.Yes)
            {
                string regID = listView1.SelectedItems[0].SubItems[0].Text;

                using (SqlConnection con = new SqlConnection("Data Source=.\\SQLEXPRESS;Initial Catalog=TravelEase;Integrated Security=True"))
                {
                    try
                    {
                        con.Open();
                        string query = "DELETE FROM Transport WHERE RegID = @RegID";
                        SqlCommand cmd = new SqlCommand(query, con);
                        cmd.Parameters.AddWithValue("@RegID", regID);

                        int rows = cmd.ExecuteNonQuery();
                        if (rows > 0)
                        {
                            MessageBox.Show("Transport deleted successfully.");
                            LoadTransportData();
                        }
                        else
                        {
                            MessageBox.Show("Deletion failed. Transport not found.");
                        }
                    }
                    catch (Exception ex)
                    {
                        MessageBox.Show("Error deleting transport: " + ex.Message);
                    }
                }
            }
        }

        private void update_Click(object sender, EventArgs e)
        {
            if (listView1.SelectedItems.Count == 0 || combo.SelectedItem == null || string.IsNullOrWhiteSpace(txt.Text))
            {
                MessageBox.Show("Please select a transport, choose a field, and enter a new value.");
                return;
            }

            var selectedItem = listView1.SelectedItems[0];
            string regID = selectedItem.SubItems[0].Text;
            string selectedColumn = combo.SelectedItem.ToString();
            string newValue = txt.Text;

            // Map displayed column name to actual database column
            string dbColumn = "";

            if (selectedColumn == "Type")
                dbColumn = "TransportType";
            else if (selectedColumn == "Contact")
                dbColumn = "Contact";
            else if (selectedColumn == "Avaibility")
                dbColumn = "TAvailability";
            else if (selectedColumn == "Rate")
                dbColumn = "Rate";
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
                    string query = $"UPDATE Transport SET {dbColumn} = @NewValue WHERE RegID = @RegID";
                    SqlCommand cmd = new SqlCommand(query, con);

                    if (dbColumn == "Rate")
                        cmd.Parameters.AddWithValue("@NewValue", float.Parse(newValue));
                    else
                        cmd.Parameters.AddWithValue("@NewValue", newValue);

                    cmd.Parameters.AddWithValue("@RegID", regID);

                    int rows = cmd.ExecuteNonQuery();
                    if (rows > 0)
                    {
                        MessageBox.Show("Transport updated successfully.");
                        LoadTransportData(); // Refresh view
                    }
                    else
                    {
                        MessageBox.Show("Update failed. No matching transport found.");
                    }
                }
                catch (Exception ex)
                {
                    MessageBox.Show("Error updating transport: " + ex.Message);
                }
            }
        }
    }
}
