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
    public partial class TravellerPass : Form
    {
        public TravellerPass()
        {
            InitializeComponent();
        }

        string con = "Data Source=.\\SQLEXPRESS;Initial Catalog=TravelEase;Integrated Security=True";

        private void label4_Click(object sender, EventArgs e)
        {

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
            TravellerBooking tb = new TravellerBooking();
            tb.Show();
            this.Hide();
        }

        private void labelButton5_Click(object sender, EventArgs e)
        {
            TravelHistory th = new TravelHistory();
            th.Show();
            this.Hide();
        }

        private void labelButton2_Click(object sender, EventArgs e)
        {
            TravellerPass tp = new TravellerPass();
            tp.Show();
            this.Hide();
        }

        private void LoadActivityPass()
        {
            string query = @"SELECT * FROM ActivityPass JOIN TripBooking ON TripBooking.BookingID = ActivityPass.BookingID WHERE TripBooking.TravellerID = @UserID";

            using (SqlConnection conn = new SqlConnection(con))
            {
                conn.Open();
                SqlCommand cmd = new SqlCommand(query, conn);
                cmd.Parameters.AddWithValue("@UserID", Program.CurrentUser.userid);
                SqlDataAdapter da = new SqlDataAdapter(cmd);
                DataTable dt = new DataTable();
                da.Fill(dt);
                ap.Items.Clear();
                if (dt.Rows.Count == 0)
                {
                    ListViewItem item = new ListViewItem("No Pass");
                    item.SubItems.Add("");
                    item.SubItems.Add("");
                    item.SubItems.Add("");
                    ap.Items.Add(item);
                }
                else
                {
                    foreach (DataRow row in dt.Rows)
                    {
                        ListViewItem item = new ListViewItem(row["ActivityPassID"].ToString());
                        item.SubItems.Add(row["Activity"].ToString());
                        item.SubItems.Add(row["Description"].ToString());
                        item.SubItems.Add(row["Discount"].ToString());
                        item.SubItems.Add(row["Valid For (weeks)"].ToString());
                        ap.Items.Add(item);
                    }
                }
            }
        }

        private void LoadETickets()
        {
            string query = @"SELECT * FROM ETickets JOIN TripBooking ON TripBooking.BookingID = ActivityPass.BookingID WHERE TripBooking.TravellerID = @UserID";

            using (SqlConnection conn = new SqlConnection(con))
            {
                conn.Open();
                SqlCommand cmd = new SqlCommand(query, conn);
                cmd.Parameters.AddWithValue("@UserID", Program.CurrentUser.userid);
                SqlDataAdapter da = new SqlDataAdapter(cmd);
                DataTable dt = new DataTable();
                da.Fill(dt);
                et.Items.Clear();
                if (dt.Rows.Count == 0)
                {
                    ListViewItem item = new ListViewItem("No Tickets");
                    item.SubItems.Add("");
                    item.SubItems.Add("");
                    item.SubItems.Add("");
                    et.Items.Add(item);
                }
                else
                {
                    foreach (DataRow row in dt.Rows)
                    {
                        ListViewItem item = new ListViewItem(row["TicketID"].ToString());
                        item.SubItems.Add(row["Description"].ToString());
                        item.SubItems.Add(row["Discount"].ToString());
                        item.SubItems.Add(row["Valid For (weeks)"].ToString());
                        et.Items.Add(item);
                    }
                }
            }
        }

        private void LoadVouchers()
        {
            string query = @"SELECT * FROM HotelVoucher JOIN TripBooking ON TripBooking.BookingID = ActivityPass.BookingID WHERE TripBooking.TravellerID = @UserID";

            using (SqlConnection conn = new SqlConnection(con))
            {
                conn.Open();
                SqlCommand cmd = new SqlCommand(query, conn);
                cmd.Parameters.AddWithValue("@UserID", Program.CurrentUser.userid);
                SqlDataAdapter da = new SqlDataAdapter(cmd);
                DataTable dt = new DataTable();
                da.Fill(dt);
                hv.Items.Clear();
                if (dt.Rows.Count == 0)
                {
                    ListViewItem item = new ListViewItem("No Vouchers");
                    item.SubItems.Add("");
                    item.SubItems.Add("");
                    item.SubItems.Add("");
                    hv.Items.Add(item);
                }
                else
                {
                    foreach (DataRow row in dt.Rows)
                    {
                        ListViewItem item = new ListViewItem(row["VoucherID"].ToString());
                        item.SubItems.Add(row["Description"].ToString());
                        item.SubItems.Add(row["Discount"].ToString());
                        item.SubItems.Add(row["Valid For (weeks)"].ToString());
                        hv.Items.Add(item);
                    }
                }
            }
        }

        private void TravellerPass_Load(object sender, EventArgs e)
        {
            LoadActivityPass();
            LoadETickets();
            LoadVouchers();
        }
    }
}
