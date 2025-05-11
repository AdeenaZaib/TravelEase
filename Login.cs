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
    public partial class Login : Form
    {
        public Login()
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
        private void transparentRoundedPanel1_Paint(object sender, PaintEventArgs e)
        {

        }

        private void transparentRoundedPanel1_Paint_1(object sender, PaintEventArgs e)
        {

        }

        private void Form3_Load(object sender, EventArgs e)
        {

        }

        private void linkLabel1_LinkClicked(object sender, LinkLabelLinkClickedEventArgs e)
        {
            SignUp signUp = new SignUp();
            signUp.Show();
            this.Hide();
        }

        private void login_Click(object sender, EventArgs e)
        {

        }

        private void Login_Click_1(object sender, EventArgs e)
        {
            Destination des = new Destination();
            des.Show();
            this.Hide();
        }

        private void Loginn_Click(object sender, EventArgs e)
        {
            string email = emailtxt.Text;
            string password = pwd.Text;

            MessageBox.Show($"Email: '{email}'\nPassword: '{password}'");

            if (email == "" || password == "")
            {
                MessageBox.Show("Please enter both email and password.");
                return;
            }

            string connectionString = "Data Source=.\\SQLEXPRESS;Initial Catalog=TravelEase;Integrated Security=True";

            using (SqlConnection con = new SqlConnection(connectionString))
            {
                try
                {
                    con.Open();
                    string query = "SELECT UserID, FirstName, LastName, Email FROM Users WHERE Email = @Email AND UserPassword = @Password";
                    SqlCommand cmd = new SqlCommand(query, con);
                    cmd.Parameters.AddWithValue("@Email", email);
                    cmd.Parameters.AddWithValue("@Password", password);

                    SqlDataReader reader = cmd.ExecuteReader();

                    if (reader.Read())
                    {
                        Program.CurrentUser.userid = reader.GetInt32(0);
                        Program.CurrentUser.fisrtName = reader.GetString(1);
                        Program.CurrentUser.lastName = reader.GetString(2);
                        Program.CurrentUser.email = reader.GetString(3);
                        Program.CurrentUser.password = password;
                        MessageBox.Show("Login successful!");

                        reader.Close();

                        string usertype = "";
                        string typeQuery = @"
                            SELECT 'Traveller' AS Role FROM Traveller WHERE TravellerID = @UserID
                            UNION
                            SELECT 'TourOperator' FROM TourOperator WHERE TourOperatorID = @UserID
                            UNION
                            SELECT 'ServiceProvider' FROM ServiceProvider WHERE ServiceProviderID = @UserID;";
                        SqlCommand typeCmd = new SqlCommand(typeQuery, con);
                        typeCmd.Parameters.AddWithValue("@UserID", Program.CurrentUser.userid);

                        object result = typeCmd.ExecuteScalar();
                        if (result != null)
                        {
                            usertype = result.ToString();
                            this.Hide();
                            if (usertype == "Traveller")
                            {
                                TravellerHome home = new TravellerHome();
                                home.Show();
                            }
                            else if (usertype == "TourOperator")
                            {
                                Operator home = new Operator();
                                home.Show();
                            }
                            else if (usertype == "ServiceProvider")
                            {
                                Services home = new Services();
                                home.Show();
                            }
                        }
                        else
                        {
                            MessageBox.Show("User type not found.");
                        }
                    }
                    else
                    {
                        MessageBox.Show("Invalid email or password.");
                    }
                }
                catch (Exception ex)
                {
                    MessageBox.Show("Error: " + ex.Message);
                }
            }
        }

        private void label3_Click(object sender, EventArgs e)
        {

        }
    }
}
