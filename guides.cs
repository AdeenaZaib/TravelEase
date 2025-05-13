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
    public partial class guides : Form
    {
        public guides()
        {
            InitializeComponent();
        }

        private void InitializelistView()
        {
            listView1.View = View.Details;
            listView1.FullRowSelect = true;
            listView1.GridLines = true;

            listView1.Columns.Clear();
            listView1.Columns.Add("GuideID", 50);
            listView1.Columns.Add("Name", 100);
            listView1.Columns.Add("Contact", 100);
            listView1.Columns.Add("Joining Date", 100);
            listView1.Columns.Add("Avaibility", 100);
            listView1.Columns.Add("Hourly Rate", 80);

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

        private void LoadGuides()
        {
            listView1.Items.Clear();

            using (SqlConnection con = new SqlConnection("Data Source=.\\SQLEXPRESS;Initial Catalog=TravelEase;Integrated Security=True"))
            {
                string query = @"SELECT GuideID, GuideName, Contact, JoiningDate, GuideAvailability, HourlyRate FROM TourGuide";

                SqlCommand cmd = new SqlCommand(query, con);

                try
                {
                    con.Open();
                    SqlDataReader reader = cmd.ExecuteReader();

                    while (reader.Read())
                    {
                        ListViewItem item = new ListViewItem(reader["GuideID"].ToString());
                        item.SubItems.Add(reader["GuideName"].ToString());
                        item.SubItems.Add(reader["Contact"].ToString());
                        item.SubItems.Add(Convert.ToDateTime(reader["JoiningDate"]).ToShortDateString());
                        item.SubItems.Add(reader["GuideAvailability"].ToString());
                        item.SubItems.Add(reader["HourlyRate"].ToString());

                        listView1.Items.Add(item);
                    }

                    reader.Close();
                }
                catch (Exception ex)
                {
                    MessageBox.Show("Error loading guides: " + ex.Message);
                }
            }
        }

        private void button1_Click(object sender, EventArgs e)
        {
            AddGuide home = new AddGuide();
            home.Show();
            this.Hide();
        }

        private void guides_Load(object sender, EventArgs e)
        {
            InitializelistView();
            LoadGuides();
        }
    }
}
