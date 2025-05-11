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
    public partial class payments : Form
    {
        private bool methodUserChange = true;
        private string paymentmethod = "";
        public payments()
        {
            InitializeComponent();
        }

        private void translucentRoundedPanel1_Paint(object sender, PaintEventArgs e)
        {

        }

        private void label4_Click(object sender, EventArgs e)
        {

        }

        private void method_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (!methodUserChange)
                return;

            paymentmethod = method.SelectedItem.ToString();

            // Hide all by default

            methodUserChange = false; // Prevent the event from being triggered again

            switch (paymentmethod)
            {
                case "Credit Card":
                    cvv.Visible = true;
                    exp.Visible = true;
                    label9.Visible = true;
                    label5.Visible = true;
                    method.SelectedIndex = -1;
                    break;

                case "PayPal":
                    label5.Visible = false;
                    label9.Visible = false;
                    exp.Visible = false;
                    cvv.Visible = false;
                    method.SelectedIndex = -1;
                    break;

                case "Bank Transfer":
                    label5.Visible = false;
                    label9.Visible = false;
                    exp.Visible = false;
                    cvv.Visible = false;
                    method.SelectedIndex = -1;
                    break;
            }
        }

        private void pay_Click(object sender, EventArgs e)
        {
            /*if (string.IsNullOrWhiteSpace(method.Text) ||
            string.IsNullOrWhiteSpace(cvv.Text) ||
            string.IsNullOrWhiteSpace(cardHolder.Text) ||
            string.IsNullOrWhiteSpace(expiryDate.Text) ||
            string.IsNullOrWhiteSpace(cvv.Text))
            {
                MessageBox.Show("Payment unsuccessful. Please fill all the fields.");
                return;
            }*/

            string con = "Data Source=.\\SQLEXPRESS;Initial Catalog=TravelEase;Integrated Security=True";

            int bid = Program.CurrentUser.bookingid;

            using (SqlConnection conn = new SqlConnection(con))
            {
                try
                {
                    conn.Open();

                    // Check if payment record already exists
                    string checkQuery = "SELECT COUNT(*) FROM Payments WHERE TripBookingID = @BookingID";
                    SqlCommand checkCmd = new SqlCommand(checkQuery, conn);
                    checkCmd.Parameters.AddWithValue("@BookingID", bid);
                    int count = (int)checkCmd.ExecuteScalar();

                    SqlCommand cmd;
                    if (count > 0)
                    {
                        // Update existing payment record
                        string updateQuery = "UPDATE Payments SET PaymentStatus = @PaymentStatus, PaymentMethod = @PaymentMethod, Amount = @Amount, PaymentTimestamp = GETDATE() WHERE TripBookingID = @BookingID";
                        cmd = new SqlCommand(updateQuery, conn);
                    }
                    else
                    {
                        // Insert new payment record
                        string insertQuery = "INSERT INTO Payments (TripBookingID, PaymentMethod, Amount, PaymentStatus, PaymentTimestamp) VALUES (@BookingID, @PaymentMethod, @Amount, @PaymentStatus, GETDATE())";
                        cmd = new SqlCommand(insertQuery, conn);
                    }

                    cmd.Parameters.AddWithValue("@PaymentMethod", method.SelectedItem.ToString());
                    cmd.Parameters.AddWithValue("@BookingID", bid);
                    cmd.Parameters.AddWithValue("@PaymentStatus", "Successful");
                    cmd.Parameters.AddWithValue("@Amount", amount.Text);
                    int rowsAffected = cmd.ExecuteNonQuery();

                    // Update booking status to "Booked"
                    string query1 = "UPDATE TripBooking SET BookingStatus = @BookingStatus WHERE BookingID = @BookingID";
                    SqlCommand cmd2 = new SqlCommand(query1, conn);
                    cmd2.Parameters.AddWithValue("@BookingStatus", "Booked");
                    cmd2.Parameters.AddWithValue("@BookingID", bid);
                    cmd2.ExecuteNonQuery();

                    if (rowsAffected > 0)
                    {
                        MessageBox.Show("Payment successful.");
                        TravellerBooking booking = new TravellerBooking();
                        booking.Show();
                        this.Hide();
                    }
                    else
                    {
                        //string paymentStatus = "Pending";
                        string fallbackQuery;

                        if (count > 0)
                        {
                            fallbackQuery = "UPDATE Payments SET PaymentStatus = 'Pending', PaymentMethod = @PaymentMethod, Amount = @Amount, PaymentTimestamp = GETDATE() WHERE TripBookingID = @BookingID";
                        }
                        else
                        {
                            fallbackQuery = "INSERT INTO Payments (TripBookingID, PaymentMethod, Amount, PaymentStatus, PaymentTimestamp) VALUES (@BookingID, @PaymentMethod, @Amount, 'Pending', GETDATE())";
                        }

                        cmd = new SqlCommand(fallbackQuery, conn);
                        cmd.Parameters.AddWithValue("@BookingID", bid);
                        cmd.Parameters.AddWithValue("@PaymentMethod", method.SelectedItem.ToString());
                        cmd.Parameters.AddWithValue("@Amount", amount.Text);
                        cmd.ExecuteNonQuery();

                        // Set booking status to pending
                        string statusQuery = "UPDATE TripBooking SET BookingStatus = 'Pending' WHERE BookingID = @BookingID";
                        SqlCommand statusCmd = new SqlCommand(statusQuery, conn);
                        statusCmd.Parameters.AddWithValue("@BookingID", bid);
                        statusCmd.ExecuteNonQuery();

                        MessageBox.Show("Payment unsuccessful.");
                    }
                }
                catch (Exception ex)
                {
                    MessageBox.Show("Error: " + ex.Message);
                }
            }
        }

        private void payments_Load(object sender, EventArgs e)
        {
            method.Items.AddRange(new string[] { "Credit Card", "Bank Transfer", "PayPal" });
            label5.Visible = false;
            label9.Visible = false;
            exp.Visible = false;
            cvv.Visible = false;
            method.SelectedIndexChanged += method_SelectedIndexChanged;
        }
    }
}
