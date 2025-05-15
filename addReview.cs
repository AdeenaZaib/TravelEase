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
    public partial class addReview : Form
    {
        public addReview()
        {
            InitializeComponent();
        }

        string con = "Data Source=.\\SQLEXPRESS;Initial Catalog=TravelEase;Integrated Security=True";


        private void button1_Click(object sender, EventArgs e)
        {
            string tripReview = tr.Text;
            string hotelReview = hr.Text;
            string guideReview = gr.Text;
            string operatorReview = or.Text;

            int tripRating = Convert.ToInt32(trip.Text);
            //int hotelRating = Convert.ToInt32(hotel.Text);
            //int guideRating = Convert.ToInt32(guide.Text);
            //int operatorRating = Convert.ToInt32(op.Text);

            int travellerID = Program.CurrentUser.userid;
            int tripID = 2;

            using (SqlConnection conn = new SqlConnection(con))
            {
                conn.Open();

                // Trip Review
                if (!string.IsNullOrEmpty(tripReview))
                {
                    string query = @"INSERT INTO TripReviews (TripID, TravellerID, TripReview, TripRating)
                             VALUES (@TripID, @TravellerID, @Review, @Rating)";
                    using (SqlCommand cmd = new SqlCommand(query, conn))
                    {
                        cmd.Parameters.AddWithValue("@TripID", tripID);
                        cmd.Parameters.AddWithValue("@TravellerID", travellerID);
                        cmd.Parameters.AddWithValue("@Review", tripReview);
                        cmd.Parameters.AddWithValue("@Rating", tripRating);
                        cmd.ExecuteNonQuery();
                    }
                }

                // Hotel Review
                /*if (!string.IsNullOrEmpty(hotelReview))
                {
                    string query = @"INSERT INTO HotelReviews (HotelID, TravellerID, Review, Rating)
                             VALUES (@HotelID, @TravellerID, @Review, @Rating)";
                    using (SqlCommand cmd = new SqlCommand(query, conn))
                    {
                        cmd.Parameters.AddWithValue("@HotelID", hotelID);
                        cmd.Parameters.AddWithValue("@TravellerID", travellerID);
                        cmd.Parameters.AddWithValue("@Review", hotelReview);
                        cmd.Parameters.AddWithValue("@Rating", hotelRating);
                        cmd.ExecuteNonQuery();
                    }
                }*/

                // Guide Review
                /*if (!string.IsNullOrEmpty(guideReview))
                {
                    string query = @"INSERT INTO GuideReviews (GuideID, TravellerID, Review, Rating)
                             VALUES (@GuideID, @TravellerID, @Review, @Rating)";
                    using (SqlCommand cmd = new SqlCommand(query, conn))
                    {
                        cmd.Parameters.AddWithValue("@GuideID", guideID);
                        cmd.Parameters.AddWithValue("@TravellerID", travellerID);
                        cmd.Parameters.AddWithValue("@Review", guideReview);
                        cmd.Parameters.AddWithValue("@Rating", guideRating);
                        cmd.ExecuteNonQuery();
                    }
                }*/

                // Operator Review
                /*if (!string.IsNullOrEmpty(operatorReview))
                {
                    string query = @"INSERT INTO OperatorReviews (OperatorID, TravellerID, Review, Rating)
                             VALUES (@OperatorID, @TravellerID, @Review, @Rating)";
                    using (SqlCommand cmd = new SqlCommand(query, conn))
                    {
                        cmd.Parameters.AddWithValue("@OperatorID", operatorID);
                        cmd.Parameters.AddWithValue("@TravellerID", travellerID);
                        cmd.Parameters.AddWithValue("@Review", operatorReview);
                        cmd.Parameters.AddWithValue("@Rating", operatorRating);
                        cmd.ExecuteNonQuery();
                    }
                }*/

                conn.Close();
            }

            MessageBox.Show("Reviews and ratings submitted successfully (if any).");
            TravelHistory history = new TravelHistory();
            history.Show();
            this.Hide();
        }

        private void label10_Click(object sender, EventArgs e)
        {
            TravelHistory history = new TravelHistory();
            history.Show();
            this.Hide();
        }
    }
}
