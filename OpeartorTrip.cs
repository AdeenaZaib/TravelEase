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
            //string connectionString = "Data Source=YOUR_SERVER;Initial Catalog=YOUR_DATABASE;Integrated Security=True";

            string constr ="Data Source=.\\SQLEXPRESS;Initial Catalog=TravelEase;Integrated Security=True";
            //con.Open();

            //SqlCommand cm;
            
            string query = "SELECT UserID, FirstName, LastName FROM Users JOIN Traveller ON Users.UserID = Traveller.TravellerID";
            using (SqlConnection con = new SqlConnection(constr))
            {
                try
                {
                    SqlDataAdapter adapter = new SqlDataAdapter(query, con);
                    DataTable dataTable = new DataTable();
                    adapter.Fill(dataTable);

                    // Clear previous content
                    listView1.Items.Clear();
                    listView1.View = View.Details;
                    listView1.Columns.Clear();

                    // Add columns (only once)
                    listView1.Columns.Add("User ID", 100);
                    listView1.Columns.Add("First Name", 150);
                    listView1.Columns.Add("Last Name", 150);

                    // Populate the list view
                    foreach (DataRow row in dataTable.Rows)
                    {
                        ListViewItem item = new ListViewItem(row["UserID"].ToString());
                        item.SubItems.Add(row["FirstName"].ToString());
                        item.SubItems.Add(row["LastName"].ToString());
                        listView1.Items.Add(item);
                    }
                }
                catch (Exception ex)
                {
                    MessageBox.Show("Error: " + ex.Message);
                }

            }
            

            //con.Close();

        }

        private void listView1_SelectedIndexChanged(object sender, EventArgs e)
        {

        }
    }
}
