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
            listView1.Columns.Add("Meal Name", 50);
            listView1.Columns.Add("Timings", 100);
            listView1.Columns.Add("ServiceID", 100);
            listView1.Columns.Add("MealDesc", 100);

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

                    combo.Items.Add("MealName");
                    combo.Items.Add("Timings");
                    combo.Items.Add("ServiceID");
                    combo.Items.Add("Description");
                    

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

        private void delete_Click(object sender, EventArgs e)
        {
            if (listView1.SelectedItems.Count == 0)
            {
                MessageBox.Show("Please select a meal to delete.");
                return;
            }

            DialogResult result = MessageBox.Show("Are you sure you want to delete this meal? This action cannot be undone.",
                                                  "Confirm Deletion", MessageBoxButtons.YesNo, MessageBoxIcon.Warning);

            if (result == DialogResult.Yes)
            {
                // Get values from selected ListView item
                string mealName = listView1.SelectedItems[0].SubItems[0].Text;
                string timingStr = listView1.SelectedItems[0].SubItems[1].Text;

                if (!DateTime.TryParse(timingStr, out DateTime timing))
                {
                    MessageBox.Show("Invalid meal timing format.");
                    return;
                }

                string connectionString = "Data Source=.\\SQLEXPRESS;Initial Catalog=TravelEase;Integrated Security=True";

                using (SqlConnection conn = new SqlConnection(connectionString))
                {
                    try
                    {
                        conn.Open();
                        string deleteQuery = "DELETE FROM Meals WHERE MealName = @MealName AND Timings = @Timings";
                        SqlCommand cmd = new SqlCommand(deleteQuery, conn);
                        cmd.Parameters.AddWithValue("@MealName", mealName);
                        cmd.Parameters.AddWithValue("@Timings", timing);

                        int rows = cmd.ExecuteNonQuery();

                        if (rows > 0)
                        {
                            MessageBox.Show("Meal deleted successfully.");
                            LoadMeals(); // Refresh the list
                        }
                        else
                        {
                            MessageBox.Show("Meal could not be deleted.");
                        }
                    }
                    catch (Exception ex)
                    {
                        MessageBox.Show("Error: " + ex.Message);
                    }
                }
            }
        }

        private void update_Click(object sender, EventArgs e)
        {
            if (listView1.SelectedItems.Count == 0 || combo.SelectedItem == null || string.IsNullOrWhiteSpace(txt.Text))
            {
                MessageBox.Show("Please select a meal, a field to update, and provide the new value.");
                return;
            }

            var selectedItem = listView1.SelectedItems[0];
            string mealName = selectedItem.SubItems[0].Text;
            string timingStr = selectedItem.SubItems[1].Text;

            if (!DateTime.TryParse(timingStr, out DateTime originalTiming))
            {
                MessageBox.Show("Invalid original meal timing format.");
                return;
            }

            string columnToUpdate = combo.SelectedItem.ToString();
            string newValue = txt.Text;

            string connectionString = "Data Source=.\\SQLEXPRESS;Initial Catalog=TravelEase;Integrated Security=True";
            using (SqlConnection conn = new SqlConnection(connectionString))
            {
                try
                {
                    conn.Open();
                    string query = $"UPDATE Meals SET {columnToUpdate} = @newValue WHERE MealName = @MealName AND Timings = @Timings";
                    SqlCommand cmd = new SqlCommand(query, conn);

                    // Handle data type for new value
                    if (columnToUpdate == "ServiceID")
                        cmd.Parameters.AddWithValue("@newValue", int.Parse(newValue));
                    else if (columnToUpdate == "Timings")
                        cmd.Parameters.AddWithValue("@newValue", DateTime.Parse(newValue));
                    else
                        cmd.Parameters.AddWithValue("@newValue", newValue);

                    cmd.Parameters.AddWithValue("@MealName", mealName);
                    cmd.Parameters.AddWithValue("@Timings", originalTiming);

                    int rows = cmd.ExecuteNonQuery();
                    if (rows > 0)
                    {
                        MessageBox.Show("Meal updated successfully.");
                        LoadMeals(); // Refresh list
                    }
                    else
                    {
                        MessageBox.Show("Meal update failed.");
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
