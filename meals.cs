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
    public partial class meals : Form
    {
        public meals()
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
            listView1.Columns.Add("GuideID", 50);
            listView1.Columns.Add("Name", 100);
            listView1.Columns.Add("Contact", 100);
            listView1.Columns.Add("Joining Date", 100);
            listView1.Columns.Add("Avaibility", 100);
            listView1.Columns.Add("Hourly Rate", 80);

        }

        private void LoadMeals()
        {
            string connectionString = "Data Source=.\\SQLEXPRESS;Initial Catalog=TravelEase;Integrated Security=True";

            using (SqlConnection con = new SqlConnection(connectionString))
            {
                try
                {
                    con.Open();
                    string query = "SELECT MealName, Timings, ServiceID, MealDesc FROM Meals ORDER BY Timings";
                    SqlCommand cmd = new SqlCommand(query, con);
                    SqlDataReader reader = cmd.ExecuteReader();

                    // Clear previous items and columns
                    listView1.Items.Clear();
                    listView1.Columns.Clear();
                    listView1.View = View.Details;

                    // Add columns (only once)
                    listView1.Columns.Add("Meal Name", 120);
                    listView1.Columns.Add("Timings", 150);
                    listView1.Columns.Add("Service ID", 100);
                    listView1.Columns.Add("Description", 200);

                    // Populate ListView
                    while (reader.Read())
                    {
                        ListViewItem item = new ListViewItem(reader["MealName"].ToString());
                        item.SubItems.Add(Convert.ToDateTime(reader["Timings"]).ToString("g")); // "g" = general date/time pattern
                        item.SubItems.Add(reader["ServiceID"].ToString());
                        item.SubItems.Add(reader["MealDesc"].ToString());

                        listView1.Items.Add(item);
                    }

                    reader.Close();
                }
                catch (Exception ex)
                {
                    MessageBox.Show("Error loading meals: " + ex.Message);
                }
            }
        }



        private void button1_Click(object sender, EventArgs e)
        {
            AddMeal addMeal = new AddMeal();
            addMeal.Show();
            this.Hide();
        }

        private void meals_Load(object sender, EventArgs e)
        {
            InitializelistView();
            LoadMeals();
        }
    }
}
