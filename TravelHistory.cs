using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Data.SqlClient;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using static System.Windows.Forms.VisualStyles.VisualStyleElement;

namespace dbproject
{
    public partial class TravelHistory : Form
    {
        public TravelHistory()
        {
            InitializeComponent();
        }

        private void travellerhistory()
        {
            string con = "Data Source=.\\SQLEXPRESS;Initial Catalog=TravelEase;Integrated Security=True";

            int id = Program.CurrentUser.userid;

            string query = @"SELECT TripBooking.TripID, Trip.TripTitle, Destination.DestinationName, Trip.StartDate, Trip.EndDate FROM TripBooking
            JOIN Trip ON Trip.TripID = TripBooking.TripID JOIN Destination ON Trip.DestinationID = Destination.DestinationID WHERE TripBooking.TravellerID = @UserID AND TripBooking.BookingStatus = 'Booked'" ;

            using (SqlConnection conn = new SqlConnection(con))
            {
                try
                {
                    SqlCommand cmd = new SqlCommand(query, conn);
                    cmd.Parameters.AddWithValue("@UserID", id);

                    SqlDataAdapter adapter = new SqlDataAdapter(cmd);
                    DataTable dataTable = new DataTable();
                    adapter.Fill(dataTable);

                    // Clear previous content
                    history.Items.Clear();
                    history.View = View.Details;
                    history.Columns.Clear();

                    // Add columns (only once)
                    history.Columns.Add("Trip ID", 100);
                    history.Columns.Add("Trip Title", 150);
                    history.Columns.Add("Destination", 150);
                    history.Columns.Add("Start Date", 100);
                    history.Columns.Add("End Date", 100);

                    // Populate the list view
                    foreach (DataRow row in dataTable.Rows)
                    {
                        ListViewItem item = new ListViewItem(row["TripID"].ToString());
                        item.SubItems.Add(row["TripTitle"].ToString());
                        item.SubItems.Add(row["DestinationName"].ToString());
                        item.SubItems.Add(Convert.ToDateTime(row["StartDate"]).ToString("yyyy-MM-dd"));
                        item.SubItems.Add(Convert.ToDateTime(row["EndDate"]).ToString("yyyy-MM-dd"));
                        history.Items.Add(item);
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
            TravellerHome home = new TravellerHome();
            home.Show();
            this.Hide();
        }

        private void labelButton4_Click(object sender, EventArgs e)
        {
            TripSearch ts = new TripSearch();
            ts.Show();
            this.Hide();
        }

        private void labelButton3_Click(object sender, EventArgs e)
        {
            TravellerBooking book = new TravellerBooking();
            book.Show();
            this.Hide();
        }

        private void labelButton5_Click(object sender, EventArgs e)
        {
            TravelHistory history = new TravelHistory();
            history.Show();
            this.Hide();
        }

        private void TravelHistory_Load(object sender, EventArgs e)
        {
            travellerhistory();
        }

        private void labelButton3_Click_1(object sender, EventArgs e)
        {
            TravellerBooking book = new TravellerBooking();
            book.Show();
            this.Hide();
        }

        private void labelButton5_Click_1(object sender, EventArgs e)
        {
            TravelHistory history = new TravelHistory();
            history.Show();
            this.Hide();
        }

        private void labelButton2_Click(object sender, EventArgs e)
        {
            TravellerPass tp = new TravellerPass();
            tp.Show();
            this.Hide();
        }

        private void listView1_SelectedIndexChanged(object sender, EventArgs e)
        {

        }

        private void add_Click(object sender, EventArgs e)
        {
            addReview rev = new addReview();
            rev.Show();
            this.Hide();
        }

        private void viewbut_Click(object sender, EventArgs e)
        {
            listView1.Items.Clear();

            using (SqlConnection con = new SqlConnection("Data Source=.\\SQLEXPRESS;Initial Catalog=TravelEase;Integrated Security=True"))
            {
                string query = @"
                SELECT R.ReviewID, U.FirstName, U.LastName, 'Trip' AS Category, TR.TripRating AS Rating, TR.TripReview AS Review
                FROM Reviews R
                INNER JOIN TripReviews TR ON R.TravellerID = TR.TravellerID AND R.TripID = TR.TripID
                INNER JOIN Users U ON R.TravellerID = U.UserID

                UNION

                SELECT R.ReviewID, U.FirstName, U.LastName, 'Tour Operator' AS Category, TOR.TourOperatorRating, TOR.TourOperatorReview
                FROM Reviews R
                INNER JOIN TourOperatorReviews TOR ON R.TravellerID = TOR.TravellerID AND R.TourOperatorID = TOR.TourOperatorID
                INNER JOIN Users U ON R.TravellerID = U.UserID

                UNION

                SELECT R.ReviewID, U.FirstName, U.LastName, 'Guide' AS Category, GR.GuideRating, GR.GuideReview
                FROM Reviews R
                INNER JOIN GuideReviews GR ON R.TravellerID = GR.TravellerID AND R.GuideID = GR.GuideID
                INNER JOIN Users U ON R.TravellerID = U.UserID

                UNION

                SELECT R.ReviewID, U.FirstName, U.LastName, 'Hotel' AS Category, HR.HotelRating, HR.HotelReview
                FROM Reviews R
                INNER JOIN HotelReviews HR ON R.TravellerID = HR.TravellerID AND R.HotelID = HR.HotelID
                INNER JOIN Users U ON R.TravellerID = U.UserID";

                SqlCommand cmd = new SqlCommand(query, con);
                con.Open();
                SqlDataReader reader = cmd.ExecuteReader();

                while (reader.Read())
                {
                    ListViewItem item = new ListViewItem(reader["ReviewID"].ToString());
                    item.SubItems.Add(reader["FirstName"].ToString());
                    item.SubItems.Add(reader["LastName"].ToString());
                    item.SubItems.Add(reader["Category"].ToString());
                    item.SubItems.Add(reader["Rating"].ToString());
                    item.SubItems.Add(reader["Review"].ToString());

                    listView1.Items.Add(item);
                }
            }
        }

        private void listView1_SelectedIndexChanged_1(object sender, EventArgs e)
        {

        }
    }
}

