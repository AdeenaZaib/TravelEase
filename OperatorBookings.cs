﻿using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Data.SqlClient;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using static System.Windows.Forms.VisualStyles.VisualStyleElement;

namespace dbproject
{
    public partial class OperatorBookings : Form
    {
        public OperatorBookings()
        {
            InitializeComponent();
        }

        string con = "Data Source=.\\SQLEXPRESS;Initial Catalog=TravelEase;Integrated Security=True";

        private void label6_Click(object sender, EventArgs e)
        {

        }

        private void label5_Click(object sender, EventArgs e)
        {

        }

        private void labelButton1_Click(object sender, EventArgs e)
        {
            Operator op = new Operator();
            op.Show();
            this.Hide();
        }

        private void labelButton4_Click(object sender, EventArgs e)
        {
            OpeartorTrip ot = new OpeartorTrip();
            ot.Show();
            this.Hide();
        }

        private void labelButton3_Click(object sender, EventArgs e)
        {
            AssignServices ass = new AssignServices();
            ass.Show();
            this.Hide();
        }

        private void labelButton5_Click(object sender, EventArgs e)
        {
            OperatorBookings ob = new OperatorBookings();
            ob.Show();
            this.Hide();
        }

        private void labelButton6_Click(object sender, EventArgs e)
        {
            OpeartorAnalytics oa = new OpeartorAnalytics();
            oa.Show();
            this.Hide();
        }

        private void LoadInquiries()
        {
            string query = @"SELECT InquiryID, TravellerID, Inquiry FROM Inquiries";

            using (SqlConnection conn = new SqlConnection(con))
            {
                try
                {
                    SqlDataAdapter adapter = new SqlDataAdapter(query, conn);
                    DataTable dataTable = new DataTable();
                    adapter.Fill(dataTable);

                    // Clear previous content
                    inq.Items.Clear();
                    inq.View = View.Details;
                    inq.Columns.Clear();

                    // Add columns (only once)
                    inq.Columns.Add("Inquiry ID", 100);
                    inq.Columns.Add("Traveller ID", 150);
                    inq.Columns.Add("Inquiry", 150);

                    // Populate the list view
                    foreach (DataRow row in dataTable.Rows)
                    {
                        ListViewItem item = new ListViewItem(row["InquiryID"].ToString());
                        item.SubItems.Add(row["TravellerID"].ToString());
                        item.SubItems.Add(row["Inquiry"].ToString());

                        inq.Items.Add(item);
                    }
                }
                catch (Exception ex)
                {
                    MessageBox.Show("Error: " + ex.Message);
                }

            }
        }

        private void LoadUpdates()
        {
            string query = @"SELECT s.ServiceID, s.TravellerID, 
            CASE 
            WHEN h.ServiceID IS NOT NULL THEN 'Hotel'
            WHEN tg.ServiceID IS NOT NULL THEN 'TourGuide'
            WHEN t.ServiceID IS NOT NULL THEN 'Transport'
            WHEN m.ServiceID IS NOT NULL THEN 'Meals'
            ELSE 'Unknown'
             END AS Service
    FROM 
        ServicesBooked s
        LEFT JOIN Hotel h ON s.ServiceID = h.ServiceID
        LEFT JOIN TourGuide tg ON s.ServiceID = tg.ServiceID
        LEFT JOIN Transport t ON s.ServiceID = t.ServiceID
        LEFT JOIN Meals m ON s.ServiceID = m.ServiceID
    WHERE 
        s.BookingStatus = 'Confirmed'";


            using (SqlConnection conn = new SqlConnection(con))
            {
                try
                {
                    SqlDataAdapter adapter = new SqlDataAdapter(query, conn);
                    DataTable dataTable = new DataTable();
                    adapter.Fill(dataTable);

                    // Clear previous content
                    reservation.Items.Clear();
                    reservation.View = View.Details;
                    reservation.Columns.Clear();

                    // Add columns (only once)
                    reservation.Columns.Add("Service ID", 100);
                    reservation.Columns.Add("Traveller ID", 150);
                    reservation.Columns.Add("Service", 150);

                    // Populate the list view
                    foreach (DataRow row in dataTable.Rows)
                    {
                        ListViewItem item = new ListViewItem(row["ServiceID"].ToString());
                        item.SubItems.Add(row["TravellerID"].ToString());
                        item.SubItems.Add(row["Service"].ToString());

                        reservation.Items.Add(item);
                    }
                }
                catch (Exception ex)
                {
                    MessageBox.Show("Error: " + ex.Message);
                }

            }
        }

        private void OperatorBookings_Load(object sender, EventArgs e)
        {
            LoadInquiries();
            LoadUpdates();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            Program.CurrentUser.inqid = Convert.ToInt32(inq.SelectedItems[0].SubItems[0].Text);
            Inquiries resp = new Inquiries();
            resp.Show();
            this.Hide();
        }

        private void button2_Click(object sender, EventArgs e)
        {
            if (reservation.SelectedItems.Count > 0)
            {
                // Get the first selected item
                ListViewItem selectedItem = reservation.SelectedItems[0];

                // Assuming travellerID is in column 0, bookingStatus is in column 1
                string travellerID = selectedItem.SubItems[1].Text;
                string serviceID = selectedItem.SubItems[0].Text;
                string service = "";

                string query = @"
                    SELECT s.ServiceID, s.TravellerID, 
                    CASE 
                        WHEN h.ServiceID IS NOT NULL THEN 'Hotel'
                        WHEN tg.ServiceID IS NOT NULL THEN 'TourGuide'
                        WHEN t.ServiceID IS NOT NULL THEN 'Transport'
                        WHEN m.ServiceID IS NOT NULL THEN 'Meals'
                        ELSE 'Unknown'
                        END AS Service
                    FROM 
                        ServicesBooked s
                        LEFT JOIN Hotel h ON s.ServiceID = h.ServiceID
                        LEFT JOIN TourGuide tg ON s.ServiceID = tg.ServiceID
                        LEFT JOIN Transport t ON s.ServiceID = t.ServiceID
                        LEFT JOIN Meals m ON s.ServiceID = m.ServiceID
                     WHERE s.ServiceID = @serviceID";

                using (SqlConnection conn = new SqlConnection(con))
                {
                    using (SqlCommand cmd = new SqlCommand(query, conn))
                    {
                        cmd.Parameters.AddWithValue("@serviceID", serviceID);

                        conn.Open();
                        SqlDataReader reader = cmd.ExecuteReader();

                        if (reader.Read())
                        {
                            service = reader["Service"].ToString();
                        }
                        else
                        {
                            MessageBox.Show("Service not found.");
                            return;
                        }

                        conn.Close();
                    }
                }

                // Create the reminder message
                string rem = $"Your {service} booking is confirmed";

                // Generate a unique remid (could also be auto-incremented in DB)
                //string remid = Guid.NewGuid().ToString();

                // Insert into database
                using (SqlConnection conn = new SqlConnection(con))
                {
                    string insertQuery = "INSERT INTO Reminders (OperatorID, TravellerID, Rem) VALUES (@id, @travellerID, @rem)";
                    using (SqlCommand cmd = new SqlCommand(insertQuery, conn))
                    {
                        cmd.Parameters.AddWithValue("@rem", rem);
                        cmd.Parameters.AddWithValue("@travellerID", travellerID);
                        cmd.Parameters.AddWithValue("@id", Program.CurrentUser.userid);

                        conn.Open();
                        cmd.ExecuteNonQuery();
                        conn.Close();
                    }
                }

                MessageBox.Show("Reminder saved successfully.");
            }
            else
            {
                MessageBox.Show("Please select a booking from the list.");
            }
        }
    }
}

