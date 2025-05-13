using System;
using System.Collections;
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
    public partial class AssignServices : Form
    {
        public AssignServices()
        {
            InitializeComponent();
        }

        private string con = "Data Source=.\\SQLEXPRESS;Initial Catalog=TravelEase;Integrated Security=True";

        private void translucentRoundedPanel1_Paint(object sender, PaintEventArgs e)
        {

        }

        private void LoadFilters()
        {
            combo.Items.AddRange(new string[] { "Hotel", "Transport", "Meals", "Tour Guides" });
        }

        /*private void LoadServiceData(string serviceType)
        {
            string query = "";
            switch (serviceType)
            {
                case "Hotel":
                    query = @"SELECT h.HotelID, s.ServiceProvider, s.ServicePrice, h.HotelName, r.RoomType, r.RoomPrice 
                      FROM Hotel h
                      JOIN Service s ON h.ServiceID = s.ServiceID
                      LEFT JOIN Rooms r ON h.HotelID = r.HotelID";
                    break;

                case "Meals":
                    query = @"SELECT m.MealID, s.ServiceProvider, s.ServicePrice, m.MealType, m.Description 
                      FROM Meals m
                      JOIN Service s ON m.ServiceID = s.ServiceID";
                    break;

                case "TourGuide":
                    query = @"SELECT tg.GuideID, s.ServiceProvider, s.ServicePrice, tg.Language, tg.YearsOfExperience 
                      FROM TourGuide tg
                      JOIN Service s ON tg.ServiceID = s.ServiceID";
                    break;

                case "Transport":
                    query = @"SELECT t.TransportID, s.ServiceProvider, s.ServicePrice, t.VehicleType, t.Capacity 
                      FROM Transport t
                      JOIN Service s ON t.ServiceID = s.ServiceID";
                    break;
            }

            serv.Items.Clear();
            serv.Columns.Clear();
            serv.View = View.Details;

            using (SqlConnection conn = new SqlConnection(con))
            {
                SqlCommand cmd = new SqlCommand(query, conn);
                conn.Open();
                SqlDataReader reader = cmd.ExecuteReader();

                // Define columns based on selected type
                switch (serviceType)
                {
                    case "Hotel":
                        serv.Columns.Add("Hotel ID");
                        serv.Columns.Add("Provider");
                        serv.Columns.Add("Price");
                        serv.Columns.Add("Hotel Name");
                        serv.Columns.Add("Room Type");
                        serv.Columns.Add("Room Price");
                        break;

                    case "Meals":
                        serv.Columns.Add("Meal ID");
                        serv.Columns.Add("Provider");
                        serv.Columns.Add("Price");
                        serv.Columns.Add("Meal Type");
                        serv.Columns.Add("Description");
                        break;

                    case "TourGuide":
                        serv.Columns.Add("Guide ID");
                        serv.Columns.Add("Provider");
                        serv.Columns.Add("Price");
                        serv.Columns.Add("Language");
                        serv.Columns.Add("Experience (Years)");
                        break;

                    case "Transport":
                        serv.Columns.Add("Transport ID");
                        serv.Columns.Add("Provider");
                        serv.Columns.Add("Price");
                        serv.Columns.Add("Vehicle Type");
                        serv.Columns.Add("Capacity");
                        break;
                }

                // Populate list view
                while (reader.Read())
                {
                    ListViewItem item = new ListViewItem(reader[0].ToString());
                    for (int i = 1; i < reader.FieldCount; i++)
                    {
                        item.SubItems.Add(reader[i]?.ToString() ?? "");
                    }
                    serv.Items.Add(item);
                }

                reader.Close();
            }
        }*/

        private void LoadServiceData(string serviceType)
        {
            string query = "";

            // Build query based on service type
            switch (serviceType)
            {
                case "Hotel":
                    query = @"
                SELECT h.HotelID, h.ServiceID, s.ServiceProviderID, u.FirstName, h.HotelName, r.RoomNo, r.ExtraCharges 
                FROM Hotel h
                JOIN TripServices s ON h.ServiceID = s.ServiceID
                JOIN Users u ON u.UserID = s.ServiceProviderID
                LEFT JOIN Rooms r ON h.HotelID = r.HotelID";
                    break;

                case "Meals":
                    query = @"
                SELECT m.ServiceID, s.ServiceProviderID, u.FirstName, m.MealName, m.Timings, m.MealDesc
                FROM Meals m
                JOIN TripServices s ON m.ServiceID = s.ServiceID
                JOIN Users u ON u.UserID = s.ServiceProviderID";
                    break;

                case "TourGuide":
                    query = @"
                SELECT *, s.ServiceProviderID, u.FirstName
                FROM TourGuide tg
                JOIN TripServices s ON tg.ServiceID = s.ServiceID
                JOIN Users u ON u.UserID = s.ServiceProviderID";
                    break;

                case "Transport":
                    query = @"
                SELECT *, s.ServiceProviderID, u.FirstName
                FROM Transport t
                JOIN TripServices s ON t.ServiceID = s.ServiceID
                JOIN Users u ON u.UserID = s.ServiceProviderID";
                    break;

                default:
                    MessageBox.Show("Invalid service type selected.");
                    return;
            }

            serv.Items.Clear();
            serv.Columns.Clear();
            serv.View = View.Details;

            // Add columns based on the service type
            switch (serviceType)
            {
                case "Hotel":
                    serv.Columns.Add("Hotel ID", 100);
                    serv.Columns.Add("Provider", 150);
                    serv.Columns.Add("Price", 100);
                    serv.Columns.Add("Hotel Name", 150);
                    serv.Columns.Add("Room Type", 120);
                    serv.Columns.Add("Room Price", 100);
                    break;

                case "Meals":
                    serv.Columns.Add("Meal ID", 100);
                    serv.Columns.Add("Provider", 150);
                    serv.Columns.Add("Price", 100);
                    serv.Columns.Add("Meal Type", 120);
                    serv.Columns.Add("Description", 200);
                    break;

                case "TourGuide":
                    serv.Columns.Add("Guide ID", 100);
                    serv.Columns.Add("Provider", 150);
                    serv.Columns.Add("Price", 100);
                    serv.Columns.Add("Language", 120);
                    serv.Columns.Add("Experience (Years)", 150);
                    break;

                case "Transport":
                    serv.Columns.Add("Transport ID", 100);
                    serv.Columns.Add("Provider", 150);
                    serv.Columns.Add("Price", 100);
                    serv.Columns.Add("Vehicle Type", 120);
                    serv.Columns.Add("Capacity", 100);
                    break;
            }

            // Execute query and populate list view
            using (SqlConnection conn = new SqlConnection(con))
            {
                try
                {
                    conn.Open();
                    SqlCommand cmd = new SqlCommand(query, conn);
                    SqlDataReader reader = cmd.ExecuteReader();

                    while (reader.Read())
                    {
                        ListViewItem item = new ListViewItem(reader[0].ToString());
                        for (int i = 1; i < reader.FieldCount; i++)
                        {
                            item.SubItems.Add(reader[i]?.ToString() ?? "");
                        }
                        serv.Items.Add(item);
                    }

                    reader.Close();
                }
                catch (Exception ex)
                {
                    MessageBox.Show("Query execution failed: " + ex.Message);
                }
            }
        }

        private void LoadScreen()
        {
            string tquery = @"SELECT TripBooking.BookingID, TripBooking.TripID, Trip.TripTitle, TripBooking.TravellerID, TripBooking.NoOfPeople, TripBooking.BookingDate
            FROM TripBooking JOIN Trip ON TripBooking.TripID = Trip.TripID
            WHERE TripBooking.BookingStatus = 'Booked' 
            AND Trip.TourOperatorID = " + Program.CurrentUser.userid;

            string squery = @"SELECT 
                        s.ServiceID, s.ServiceProviderID,
                        CASE 
                        WHEN h.ServiceID IS NOT NULL THEN 'Hotel'
                        WHEN tg.ServiceID IS NOT NULL THEN 'TourGuide'
                        WHEN t.ServiceID IS NOT NULL THEN 'Transport'
                        WHEN m.ServiceID IS NOT NULL THEN 'Meals'
                        ELSE 'Unknown'
                        END AS Service
                        FROM TripServices s
                        LEFT JOIN Hotel h ON s.ServiceID = h.ServiceID  
                        LEFT JOIN TourGuide tg ON s.ServiceID = tg.ServiceID
                        LEFT JOIN Transport t ON s.ServiceID = t.ServiceID
                        LEFT JOIN Meals m ON s.ServiceID = m.ServiceID";
            using (SqlConnection conn = new SqlConnection(con))
            {
                try
                {
                    SqlDataAdapter adapter = new SqlDataAdapter(tquery, conn);
                    DataTable dataTable = new DataTable();
                    adapter.Fill(dataTable);

                    // Clear previous content
                    trav.Items.Clear();
                    trav.View = View.Details;
                    trav.Columns.Clear();

                    // Add columns (only once)
                    trav.Columns.Add("Booking ID", 100);
                    trav.Columns.Add("Trip ID", 100);
                    trav.Columns.Add("Trip Title", 150);
                    trav.Columns.Add("Traveller ID", 150);
                    trav.Columns.Add("No Of People", 150);
                    trav.Columns.Add("Booking Date", 150);

                    // Populate the list view
                    foreach (DataRow row in dataTable.Rows)
                    {
                        ListViewItem item = new ListViewItem(row["BookingID"].ToString());
                        item.SubItems.Add(row["TripID"].ToString());
                        item.SubItems.Add(row["TripTitle"].ToString());
                        item.SubItems.Add(row["TravellerID"].ToString());
                        item.SubItems.Add(row["NoOfPeople"].ToString());
                        item.SubItems.Add(row["BookingDate"].ToString());
                        trav.Items.Add(item);
                    }

                    SqlDataAdapter adapter2 = new SqlDataAdapter(squery, conn);
                    DataTable dt2 = new DataTable();
                    adapter2.Fill(dt2);

                    serv.Items.Clear();
                    serv.View = View.Details;
                    serv.Columns.Clear();

                    serv.Columns.Add("Service ID", 100);
                    serv.Columns.Add("Service", 100);
                    serv.Columns.Add("ProviderID", 150);

                    foreach (DataRow row in dt2.Rows)
                    {
                        ListViewItem item = new ListViewItem(row["ServiceID"].ToString());
                        item.SubItems.Add(row["Service"].ToString());
                        item.SubItems.Add(row["ServiceProviderID"].ToString());
                        serv.Items.Add(item); 
                    }
                }
                catch (Exception ex)
                {
                    MessageBox.Show("Error: " + ex.Message);
                }

            }
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

        private void AssignServices_Load(object sender, EventArgs e)
        {
            LoadFilters();
            LoadScreen();
        }

        private void combo_SelectedIndexChanged(object sender, EventArgs e)
        {
            string selected = combo.SelectedItem.ToString();
            LoadServiceData(selected);
        }

        private void roundedButton1_Click(object sender, EventArgs e)
        {
            string assign = @"INSERT INTO ServicesBooked (ServiceID, TourOperatorID, TravellerID, BookingStatus, BookingDate)
                             VALUES (@ServiceID, @UserID, @TravellerID, 'Pending', GETDATE())";

            using (SqlConnection conn = new SqlConnection(con))
            {
                try
                {
                    conn.Open();
                    SqlCommand cmd = new SqlCommand(assign, conn);
                    cmd.Parameters.AddWithValue("@ServiceID", Convert.ToInt32(sid.Text)); // Replace with correct source for ServiceID
                    cmd.Parameters.AddWithValue("@UserID", Program.CurrentUser.userid);
                    cmd.Parameters.AddWithValue("@TravellerID", Convert.ToInt32(tid.Text));
                    int rowsAffected = cmd.ExecuteNonQuery();
                    if (rowsAffected > 0)
                    {
                        MessageBox.Show("Service assigned successfully.");
                    }
                    else
                    {
                        MessageBox.Show("Failed to assign service.");
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
