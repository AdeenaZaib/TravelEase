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
using System.Xml.Linq;

namespace dbproject
{
    public partial class AddDestination : Form
    {
        public AddDestination()
        {
            InitializeComponent();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            string destinationName = name.Text.Trim();
            string destinationCountry = country.Text.Trim();
            int adminID = Program.CurrentUser.userid; // Ensure this is set when admin logs in

            if (string.IsNullOrWhiteSpace(destinationName) || string.IsNullOrWhiteSpace(destinationCountry))
            {
                MessageBox.Show("Please enter both destination name and country.");
                return;
            }

            using (SqlConnection con = new SqlConnection("Data Source=.\\SQLEXPRESS;Initial Catalog=TravelEase;Integrated Security=True"))
            {
                string query = @"
                INSERT INTO Destination (DestinationName, Country, AddedDate, AdminID)
                VALUES (@name, @country, GETDATE(), @adminID)";

                SqlCommand cmd = new SqlCommand(query, con);
                cmd.Parameters.AddWithValue("@name", destinationName);
                cmd.Parameters.AddWithValue("@country", destinationCountry);
                cmd.Parameters.AddWithValue("@adminID", adminID);

                try
                {
                    con.Open();
                    cmd.ExecuteNonQuery();
                    MessageBox.Show("Destination added successfully.");
                }
                catch (Exception ex)
                {
                    MessageBox.Show("Error: " + ex.Message);
                }

                Admin home = new Admin();
                home.Show();
                this.Hide();
            }
        }

        private void label9_Click(object sender, EventArgs e)
        {
            ManageDestinations d = new ManageDestinations();
            d.Show();
            this.Hide();
        }
    }
}
