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
    public partial class OperatorSignup : Form
    {
        public OperatorSignup()
        {
            InitializeComponent();
        }

        private void label7_Click(object sender, EventArgs e)
        {

        }

        private void roundedButton1_Click(object sender, EventArgs e)
        {
            using (SqlConnection con = new SqlConnection("Data Source=.\\SQLEXPRESS;Initial Catalog=users12;Integrated Security=True"))
            {
                con.Open();

                // Step 1: Insert into Users
                string userQuery = @"
                INSERT INTO Users (FirstName, LastName, Email, UserPassword, Contact, City, Country, RegistrationDate)
                VALUES (@FirstName, @LastName, @Email, @Password, @Contact, @City, @Country, @regDate);
                SELECT SCOPE_IDENTITY();"; // Gets the auto-generated UserID

                SqlCommand userCmd = new SqlCommand(userQuery, con);
                userCmd.Parameters.AddWithValue("@FirstName", fname.Text);
                userCmd.Parameters.AddWithValue("@LastName", lname.Text);
                userCmd.Parameters.AddWithValue("@Email", email.Text);
                userCmd.Parameters.AddWithValue("@Password", pwd.Text);
                userCmd.Parameters.AddWithValue("@Contact", contact.Text);
                userCmd.Parameters.AddWithValue("@City", city.Text);
                userCmd.Parameters.AddWithValue("@Country", country.Text);
                userCmd.Parameters.AddWithValue("@regDate", DateTime.Now);

                int newUserID = Convert.ToInt32(userCmd.ExecuteScalar()); // get the new UserID

                // Step 2: Insert into TourOperator
                string operatorQuery = "INSERT INTO TourOperator (TourOperatorID, Comission) VALUES (@ID, @Commission)";
                SqlCommand operatorCmd = new SqlCommand(operatorQuery, con);
                operatorCmd.Parameters.AddWithValue("@ID", newUserID);
                operatorCmd.Parameters.AddWithValue("@Commission", commision.Text); // make sure it's a valid decimal

                operatorCmd.ExecuteNonQuery();

                MessageBox.Show("Tour Operator registered successfully!");

                // Clear form
                fname.Text = lname.Text = email.Text = pwd.Text = contact.Text = city.Text = country.Text = commision.Text = "";


                Operator op = new Operator();
                op.Show();
                this.Hide();
            }
        }

        private void label9_Click(object sender, EventArgs e)
        {
            SignUp signUp = new SignUp();
            signUp.Show();
            this.Hide();
        }
    }
}
