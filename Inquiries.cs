using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Data.SqlClient;
using System.Drawing;
using System.Linq;
using System.Reflection.Emit;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace dbproject
{
    public partial class Inquiries : Form
    {
        public Inquiries()
        {
            InitializeComponent();
        }

        string con = "Data Source=.\\SQLEXPRESS;Initial Catalog=TravelEase;Integrated Security=True";

        private void Inquiries_Load(object sender, EventArgs e)
        {
            int id = Program.CurrentUser.inqid;
            string query = @"SELECT Inquiry FROM Inquiries WHERE InquiryID = @InqID";
       
            using (SqlConnection conn = new SqlConnection(con))
            {
                conn.Open();
                SqlCommand cmd = new SqlCommand(query, conn);
                cmd.Parameters.AddWithValue(@"InqID", id);
                object result = cmd.ExecuteScalar();  // Gets the first column of the first row

                if (result != null)
                {
                    inqui.Text = result.ToString();  // Assign to a Label
                    det.Text = "The inquiry ID is " + id.ToString();
                }
                else
                {
                    inqui.Text = "";
                }

            }
        }

        private void button1_Click(object sender, EventArgs e)
        {
            int iid = Program.CurrentUser.inqid;
            int uid = Program.CurrentUser.userid;
            string query = @"INSERT INTO (InquiryID, OperatorID, Response, ResponseTime) AS @iid, @uid, @response, GETDATE()";

            using (SqlConnection conn = new SqlConnection(con))
            {
                try
                {
                    conn.Open();
                    SqlCommand cmd = new SqlCommand(query, conn);
                    cmd.Parameters.AddWithValue(@"iid", iid);
                    cmd.Parameters.AddWithValue(@"uid", uid);
                    cmd.Parameters.AddWithValue(@"response", response.Text);
                    object result = cmd.ExecuteScalar();  // Gets the first column of the first row

                    int rowsAffected = cmd.ExecuteNonQuery();

                    if (rowsAffected > 0)
                    {
                        MessageBox.Show("Response submitted successfully.");
                        OperatorBookings ob = new OperatorBookings();
                        ob.Show();
                        this.Hide();
                    }
                    else
                    {
                        MessageBox.Show("Response not submitted");
                        return;
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
            OperatorBookings operatorBookings = new OperatorBookings();
            operatorBookings.Show();
            this.Hide();
        }
    }
}
