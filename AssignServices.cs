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

        private void LoadServiceData(string serviceType)
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
        }


        private void LoadScreen()
        {
            string tquery = @"SELECT TripBooking.BookingID, TripBooking.TripID, Trip.TripTitle, TripBooking.TravellerID, TripBooking.NoOfPeople, TripBooking.BookingDate
                            FROM TripBooking JOIN Trip ON TripBooking.TripID = Trip.TripID
                            WHERE TripBooking.BookingStatus = 'Confirmed' OR TripBooking.BookingStatus = 'Confirm'
                            AND Trip,TourOperatorID = Program.Current.UserID";

            string squery = @"SELECT 
                        s.ServiceID, s.ServiceProvider, s.ServicePrice, s.ServiceDescription,
                        CASE 
                        WHEN h.ServiceID IS NOT NULL THEN 'Hotel'
                        WHEN tg.ServiceID IS NOT NULL THEN 'TourGuide'
                        WHEN t.ServiceID IS NOT NULL THEN 'Transport'
                        WHEN m.ServiceID IS NOT NULL THEN 'Meals'
                        ELSE 'Unknown'
                        END AS Role,
                        r.RoomID,
                        r.RoomType,
                        r.RoomPrice
                        FROM 
                        Service s
                        LEFT JOIN Hotel h ON s.ServiceID = h.ServiceID
                        LEFT JOIN Rooms r ON h.HotelID = r.HotelID
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
                    serv.Items.Clear();
                    serv.View = View.Details;
                    serv.Columns.Clear();

                    // Add columns (only once)
                    serv.Columns.Add("Booking ID", 100);
                    serv.Columns.Add("Trip ID", 100);
                    serv.Columns.Add("Trip Title", 150);
                    serv.Columns.Add("Traveller ID", 150);
                    serv.Columns.Add("No Of People", 150);
                    serv.Columns.Add("Booking Date", 150);

                    // Populate the list view
                    foreach (DataRow row in dataTable.Rows)
                    {
                        ListViewItem item = new ListViewItem(row["BookingID"].ToString());
                        item.SubItems.Add(row["TripID"].ToString());
                        item.SubItems.Add(row["TripTitle"].ToString());
                        item.SubItems.Add(row["TravellerID"].ToString());
                        item.SubItems.Add(row["NoOfPeople"].ToString());
                        item.SubItems.Add(row["BookingDate"].ToString());
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
                             VALUES (@ServiceID, @UserID, @TravellerID, 'Pending', GETDTAE())";

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
