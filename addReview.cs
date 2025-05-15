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
        int tripID = 0;
        int travellerID = 0;
        public addReview(int TripID)
        {
            InitializeComponent();
            this.tripID = TripID;
            this.travellerID = Program.CurrentUser.userid;
        }

        string con = "Data Source=.\\SQLEXPRESS;Initial Catalog=TravelEase;Integrated Security=True";


        private void button1_Click(object sender, EventArgs e)
        {

            int tripRating = Convert.ToInt32(triptb.Text);
            int hotelRating = Convert.ToInt32(hotel.Text);
            int guideRating = Convert.ToInt32(guide.Text);
            int operatorRating = Convert.ToInt32(op.Text);

            int? tourOperatorID = null;
            int? guideID = null;
            int? hotelID = null;
            
            using (SqlConnection conn = new SqlConnection(con))
            {
                conn.Open();

                // Get TourOperatorID from Trip
                using (SqlCommand cmd = new SqlCommand("SELECT TourOperatorID FROM Trip WHERE TripID = @TripID", conn))
                {
                    cmd.Parameters.AddWithValue("@TripID", tripID);
                    tourOperatorID = (int?)cmd.ExecuteScalar();
                }

                // Get ServiceIDs from ServicesBooked
                List<int> serviceIDs = new List<int>();
                using (SqlCommand cmd = new SqlCommand(
                    "SELECT ServiceID FROM ServicesBooked WHERE TourOperatorID = @TourOperatorID AND TravellerID = @TravellerID", conn))
                {
                    cmd.Parameters.AddWithValue("@TourOperatorID", tourOperatorID);
                    cmd.Parameters.AddWithValue("@TravellerID", travellerID);
                    using (SqlDataReader reader = cmd.ExecuteReader())
                    {
                        while (reader.Read())
                            serviceIDs.Add(reader.GetInt32(0));
                    }
                }

                // Find GuideID
                foreach (int serviceID in serviceIDs)
                {
                    using (SqlCommand cmd = new SqlCommand("SELECT GuideID FROM TourGuide WHERE ServiceID = @ServiceID", conn))
                    {
                        cmd.Parameters.AddWithValue("@ServiceID", serviceID);
                        var result = cmd.ExecuteScalar();
                        if (result != null)
                        {
                            guideID = (int?)result;
                            break;
                        }
                    }
                }

                // Find HotelID
                foreach (int serviceID in serviceIDs)
                {
                    using (SqlCommand cmd = new SqlCommand("SELECT HotelID FROM Hotel WHERE ServiceID = @ServiceID", conn))
                    {
                        cmd.Parameters.AddWithValue("@ServiceID", serviceID);
                        var result = cmd.ExecuteScalar();
                        if (result != null)
                        {
                            hotelID = (int?)result;
                            break;
                        }
                    }
                }

                // Insert into Reviews
                using (SqlCommand cmd = new SqlCommand(@"INSERT INTO Reviews 
            ( TravellerID, TripID, TourOperatorID, GuideID, HotelID) 
            VALUES ( @TravellerID, @TripID, @TourOperatorID, @GuideID, @HotelID)", conn))
                {
                    
                    cmd.Parameters.AddWithValue("@TravellerID", travellerID);
                    cmd.Parameters.AddWithValue("@TripID", tripID);
                    cmd.Parameters.AddWithValue("@TourOperatorID", tourOperatorID);
                    cmd.Parameters.AddWithValue("@GuideID", (object)guideID ?? DBNull.Value);
                    cmd.Parameters.AddWithValue("@HotelID", (object)hotelID ?? DBNull.Value);
                    cmd.ExecuteNonQuery();
                }

                // Insert into TripReviews
                using (SqlCommand cmd = new SqlCommand("INSERT INTO TripReviews VALUES (@TravellerID, @TripID, @Rating, @Review)", conn))
                {
                    cmd.Parameters.AddWithValue("@TravellerID", travellerID);
                    cmd.Parameters.AddWithValue("@TripID", tripID);
                    cmd.Parameters.AddWithValue("@Rating", tripRating);
                    cmd.Parameters.AddWithValue("@Review", tr.Text);
                    cmd.ExecuteNonQuery();
                }

                // Insert into TourOperatorReviews
                using (SqlCommand cmd = new SqlCommand("INSERT INTO TourOperatorReviews VALUES (@TravellerID, @TripID, @OperatorID, @Rating, @Review)", conn))
                {
                    cmd.Parameters.AddWithValue("@TravellerID", travellerID);
                    cmd.Parameters.AddWithValue("@TripID", tripID);
                    cmd.Parameters.AddWithValue("@OperatorID", tourOperatorID);
                    cmd.Parameters.AddWithValue("@Rating", operatorRating);
                    cmd.Parameters.AddWithValue("@Review", or.Text);
                    cmd.ExecuteNonQuery();
                }

                // Insert into GuideReviews
                if (guideID != null)
                {
                    using (SqlCommand cmd = new SqlCommand("INSERT INTO GuideReviews VALUES (@TravellerID, @TripID, @GuideID, @Rating, @Review)", conn))
                    {
                        cmd.Parameters.AddWithValue("@TravellerID", travellerID);
                        cmd.Parameters.AddWithValue("@TripID", tripID);
                        cmd.Parameters.AddWithValue("@GuideID", guideID);
                        cmd.Parameters.AddWithValue("@Rating", guideRating);
                        cmd.Parameters.AddWithValue("@Review", gr.Text);
                        cmd.ExecuteNonQuery();
                    }
                }

                // Insert into HotelReviews
                if (hotelID != null)
                {
                    using (SqlCommand cmd = new SqlCommand("INSERT INTO HotelReviews VALUES (@TravellerID, @TripID, @HotelID, @Rating, @Review)", conn))
                    {
                        cmd.Parameters.AddWithValue("@TravellerID", travellerID);
                        cmd.Parameters.AddWithValue("@TripID", tripID);
                        cmd.Parameters.AddWithValue("@HotelID", hotelID);
                        cmd.Parameters.AddWithValue("@Rating", hotelRating);
                        cmd.Parameters.AddWithValue("@Review", hr.Text);
                        cmd.ExecuteNonQuery();
                    }
                }



                MessageBox.Show("Reviews and ratings submitted successfully (if any).");
                TravelHistory history = new TravelHistory();
                history.Show();
                this.Hide();
            }
        }

        private void label10_Click(object sender, EventArgs e)
        {
            TravelHistory history = new TravelHistory();
            history.Show();
            this.Hide();
        }
    }
}
