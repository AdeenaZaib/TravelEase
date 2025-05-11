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
    public partial class Sign : Form
    {
        public Sign()
        {
            InitializeComponent();
            this.Resize += Form1_Resize;
            CenterControls();
        }

        private void CenterControls()
        {
            // Loop through all controls on the form and center them
            foreach (Control control in this.Controls)
            {
                // Calculate new position to center each control
                int x = (this.ClientSize.Width - control.Width) / 2;
                int y = (this.ClientSize.Height - control.Height) / 2;

                // Update the location of each control
                control.Location = new Point(x, y);
            }
        }

        // This event is triggered whenever the form is resized (including maximize and restore)
        private void Form1_Resize(object sender, EventArgs e)
        {
            CenterControls();  // Re-center all controls every time the form is resized
        }

        private void textBox1_Load(object sender, EventArgs e)
        {

        }

        private void richTextBox1_TextChanged(object sender, EventArgs e)
        {

        }

        private void label1_Click(object sender, EventArgs e)
        {

        }

        private void label3_Click(object sender, EventArgs e)
        {

        }

        private void label9_Click(object sender, EventArgs e)
        {
            SignUp signUp = new SignUp();
            signUp.Show();
            this.Hide();
        }

        private void roundedButton1_Click(object sender, EventArgs e)
        {

            using (SqlConnection con = new SqlConnection("Data Source=.\\SQLEXPRESS;Initial Catalog=TravelEase;Integrated Security=True"))
            {
                try
                {
                    con.Open();

                    // First insert into Users table and get generated ID
                    string userQuery = @"INSERT INTO Users 
                                (FirstName, LastName, Email, UserPassword, Contact, City, Country, RegistrationDate)
                                VALUES (@fname, @lname, @email, @pwd, @contact, @city, @country, @regDate);
                                SELECT SCOPE_IDENTITY();"; // Get the auto-generated UserID

                    SqlCommand userCmd = new SqlCommand(userQuery, con);
                    userCmd.Parameters.AddWithValue("@fname", fname.Text);
                    userCmd.Parameters.AddWithValue("@lname", lname.Text);
                    userCmd.Parameters.AddWithValue("@email", email.Text);
                    userCmd.Parameters.AddWithValue("@pwd", pwd.Text);
                    userCmd.Parameters.AddWithValue("@contact", contact.Text);
                    userCmd.Parameters.AddWithValue("@city", city.Text);
                    userCmd.Parameters.AddWithValue("@country", country.Text);
                    userCmd.Parameters.AddWithValue("@regDate", DateTime.Now);

                    int newUserId = Convert.ToInt32(userCmd.ExecuteScalar()); // Get the inserted UserID

                    // Now insert into Traveller table using the new UserID
                    string travellerQuery = @"INSERT INTO Traveller 
                                     (TravellerID, Age, Budget) 
                                     VALUES (@id, @age, @budget)";

                    SqlCommand travellerCmd = new SqlCommand(travellerQuery, con);
                    travellerCmd.Parameters.AddWithValue("@id", newUserId);
                    travellerCmd.Parameters.AddWithValue("@age", age.Text);
                    travellerCmd.Parameters.AddWithValue("@budget", budget.Text);

                    travellerCmd.ExecuteNonQuery();

                    MessageBox.Show("Traveller Signed Up Successfully!");
                }
                catch (Exception ex)
                {
                    MessageBox.Show("Error: " + ex.Message);
                }
            }

            // Clear fields
            fname.Text = "";
            lname.Text = "";
            age.Text = "";
            email.Text = "";
            pwd.Text = "";
            contact.Text = "";
            city.Text = "";
            country.Text = "";
            budget.Text = "";

            // Navigate to traveller home
            TravellerHome home = new TravellerHome();
            home.Show();
            this.Hide();
        }

        private void Sign_Load(object sender, EventArgs e)
        {

        }
    }
}
