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
    public partial class ManageReviews : Form
    {
        public ManageReviews()
        {
            InitializeComponent();
        }

        private void InitializeRatingView()
        {
            RatingView.View = View.Details;
            RatingView.FullRowSelect = true;
            RatingView.GridLines = true;

            RatingView.Columns.Clear();
            RatingView.Columns.Add("ReviewID", 100);
            RatingView.Columns.Add("First Name", 120);
            RatingView.Columns.Add("Last Name", 120);
            RatingView.Columns.Add("Category", 180);
            RatingView.Columns.Add("Rating", 120);
            RatingView.Columns.Add("Review", 200);
        }

        private void LoadLowRatedReviews()
        {
            RatingView.Items.Clear();

            using (SqlConnection con = new SqlConnection("Data Source=.\\SQLEXPRESS;Initial Catalog=TravelEase;Integrated Security=True"))
            {
                string query = @"
                SELECT R.ReviewID, U.FirstName, U.LastName, 'Trip' AS Category, TR.TripRating AS Rating, TR.TripReview AS Review
                FROM Reviews R
                INNER JOIN TripReviews TR ON R.TravellerID = TR.TravellerID AND R.TripID = TR.TripID
                INNER JOIN Users U ON R.TravellerID = U.UserID
                WHERE TR.TripRating <= 2

                UNION

                SELECT R.ReviewID, U.FirstName, U.LastName, 'Tour Operator' AS Category, TOR.TourOperatorRating, TOR.TourOperatorReview
                FROM Reviews R
                INNER JOIN TourOperatorReviews TOR ON R.TravellerID = TOR.TravellerID AND R.TourOperatorID = TOR.TourOperatorID
                INNER JOIN Users U ON R.TravellerID = U.UserID
                WHERE TOR.TourOperatorRating <= 2

                UNION

                SELECT R.ReviewID, U.FirstName, U.LastName, 'Guide' AS Category, GR.GuideRating, GR.GuideReview
                FROM Reviews R
                INNER JOIN GuideReviews GR ON R.TravellerID = GR.TravellerID AND R.GuideID = GR.GuideID
                INNER JOIN Users U ON R.TravellerID = U.UserID
                WHERE GR.GuideRating <= 2

                UNION

                SELECT R.ReviewID, U.FirstName, U.LastName, 'Hotel' AS Category, HR.HotelRating, HR.HotelReview
                FROM Reviews R
                INNER JOIN HotelReviews HR ON R.TravellerID = HR.TravellerID AND R.HotelID = HR.HotelID
                INNER JOIN Users U ON R.TravellerID = U.UserID
                WHERE HR.HotelRating <= 2";

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

                    RatingView.Items.Add(item);
                }
            }
        }

        private void ManageReviews_Load(object sender, EventArgs e)
        {
            InitializeRatingView();
            LoadLowRatedReviews();
        }

        private void delete_Click(object sender, EventArgs e)
        {
            if (RatingView.SelectedItems.Count == 0)
            {
                MessageBox.Show("Please select a review to delete.");
                return;
            }

            ListViewItem selectedItem = RatingView.SelectedItems[0];
            int reviewId = int.Parse(selectedItem.SubItems[0].Text);

            using (SqlConnection con = new SqlConnection("Data Source=.\\SQLEXPRESS;Initial Catalog=TravelEase;Integrated Security=True"))
            {
                con.Open();

                // Step 1: Get related IDs from Reviews table
                string getIdsQuery = @"
            SELECT TravellerID, TripID, TourOperatorID, GuideID, HotelID
            FROM Reviews
            WHERE ReviewID = @ReviewID";

                SqlCommand getIdsCmd = new SqlCommand(getIdsQuery, con);
                getIdsCmd.Parameters.AddWithValue("@ReviewID", reviewId);

                SqlDataReader reader = getIdsCmd.ExecuteReader();
                if (!reader.Read())
                {
                    MessageBox.Show("Review not found.");
                    return;
                }

                int travellerId = reader["TravellerID"] != DBNull.Value ? Convert.ToInt32(reader["TravellerID"]) : -1;
                int tripId = reader["TripID"] != DBNull.Value ? Convert.ToInt32(reader["TripID"]) : -1;
                int operatorId = reader["TourOperatorID"] != DBNull.Value ? Convert.ToInt32(reader["TourOperatorID"]) : -1;
                int guideId = reader["GuideID"] != DBNull.Value ? Convert.ToInt32(reader["GuideID"]) : -1;
                int hotelId = reader["HotelID"] != DBNull.Value ? Convert.ToInt32(reader["HotelID"]) : -1;
                reader.Close();

                // Step 2: Delete from specific review tables
                if (tripId != -1)
                {
                    SqlCommand cmd = new SqlCommand("DELETE FROM TripReviews WHERE TravellerID=@TravellerID AND TripID=@TripID", con);
                    cmd.Parameters.AddWithValue("@TravellerID", travellerId);
                    cmd.Parameters.AddWithValue("@TripID", tripId);
                    cmd.ExecuteNonQuery();
                }

                if (operatorId != -1)
                {
                    SqlCommand cmd = new SqlCommand("DELETE FROM TourOperatorReviews WHERE TravellerID=@TravellerID AND TourOperatorID=@OperatorID", con);
                    cmd.Parameters.AddWithValue("@TravellerID", travellerId);
                    cmd.Parameters.AddWithValue("@OperatorID", operatorId);
                    cmd.ExecuteNonQuery();
                }

                if (guideId != -1)
                {
                    SqlCommand cmd = new SqlCommand("DELETE FROM GuideReviews WHERE TravellerID=@TravellerID AND GuideID=@GuideID", con);
                    cmd.Parameters.AddWithValue("@TravellerID", travellerId);
                    cmd.Parameters.AddWithValue("@GuideID", guideId);
                    cmd.ExecuteNonQuery();
                }

                if (hotelId != -1)
                {
                    SqlCommand cmd = new SqlCommand("DELETE FROM HotelReviews WHERE TravellerID=@TravellerID AND HotelID=@HotelID", con);
                    cmd.Parameters.AddWithValue("@TravellerID", travellerId);
                    cmd.Parameters.AddWithValue("@HotelID", hotelId);
                    cmd.ExecuteNonQuery();
                }

                // Step 3: Delete from main Reviews table
                SqlCommand deleteReviewCmd = new SqlCommand("DELETE FROM Reviews WHERE ReviewID=@ReviewID", con);
                deleteReviewCmd.Parameters.AddWithValue("@ReviewID", reviewId);
                deleteReviewCmd.ExecuteNonQuery();
            }

            MessageBox.Show("Review deleted successfully from all related tables.");
            LoadLowRatedReviews();  // or your function that reloads the list
        }

        private void labelButton1_Click(object sender, EventArgs e)
        {
            Admin home = new Admin();
            home.Show();
            this.Hide();
        }

        private void labelButton2_Click(object sender, EventArgs e)
        {
            ManageUsers mu = new ManageUsers();
            mu.Show();
            this.Hide();
        }

        private void labelButton5_Click(object sender, EventArgs e)
        {
            ManageDestinations destinations = new ManageDestinations();
            destinations.Show();
            this.Hide();
        }

        private void labelButton3_Click(object sender, EventArgs e)
        {
            ManageReviews manageReviews = new ManageReviews();
            manageReviews.Show();
            this.Hide();
        }

        private void labelButton4_Click(object sender, EventArgs e)
        {
            Analytics ana = new Analytics();
            ana.Show();
            this.Hide();
        }
    }
}
