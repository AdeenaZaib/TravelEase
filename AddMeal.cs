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
    public partial class AddMeal : Form
    {
        public AddMeal()
        {
            InitializeComponent();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            int providerID = Program.CurrentUser.userid; // Get current logged-in service provider ID
            string mealName = Mname.Text;
            string mealDesc = description.Text;
            DateTime timings = DateTime.Parse(timing.Text); // You may use DateTimePicker instead for better input control

            using (SqlConnection con = new SqlConnection("Data Source=.\\SQLEXPRESS;Initial Catalog=TravelEase;Integrated Security=True"))
            {
                con.Open();
                SqlTransaction transaction = con.BeginTransaction();

                try
                {
                    // 1. Insert into TripServices and get new ServiceID
                    string insertServiceQuery = "INSERT INTO TripServices (ServiceProviderID) VALUES (@spid); SELECT SCOPE_IDENTITY();";
                    SqlCommand cmdService = new SqlCommand(insertServiceQuery, con, transaction);
                    cmdService.Parameters.AddWithValue("@spid", providerID);
                    int newServiceID = Convert.ToInt32(cmdService.ExecuteScalar());

                    // 2. Insert into Meals table
                    string insertMealQuery = @"
                INSERT INTO Meals (MealName, Timings, ServiceID, MealDesc)
                VALUES (@mname, @timing, @sid, @desc)";
                    SqlCommand cmdMeal = new SqlCommand(insertMealQuery, con, transaction);
                    cmdMeal.Parameters.AddWithValue("@mname", mealName);
                    cmdMeal.Parameters.AddWithValue("@timing", timings);
                    cmdMeal.Parameters.AddWithValue("@sid", newServiceID);
                    cmdMeal.Parameters.AddWithValue("@desc", mealDesc);

                    cmdMeal.ExecuteNonQuery();

                    transaction.Commit();
                    MessageBox.Show("Meal added successfully.");
                }
                catch (Exception ex)
                {
                    transaction.Rollback();
                    MessageBox.Show("Error: " + ex.Message);
                }
            }
            meals m = new meals();
            m.Show();
            this.Hide();
        }

        private void label9_Click(object sender, EventArgs e)
        {
            meals m = new meals();
            m.Show();
            this.Hide();
        }
    }
}
