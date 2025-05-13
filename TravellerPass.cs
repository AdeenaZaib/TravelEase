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
                ap.View = View.Details;
                ap.Columns.Clear();
                ap.Columns.Add("Pass ID");
                ap.Columns.Add("Description");
                ap.Columns.Add("Discount");
                ap.Columns.Add("Valid For (weeks)");
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
                        ListViewItem item = new ListViewItem(row["PassID"].ToString());
                        item.SubItems.Add(row["ActivityType"].ToString());
                        item.SubItems.Add(row["ActivityDesc"].ToString());
                        item.SubItems.Add(row["Discount"].ToString());
                        item.SubItems.Add(row["ValidFor"].ToString());
                        ap.Items.Add(item);
                    }
                }
            }
        }

        private void LoadETickets()
        {
            string query = @"SELECT * FROM ETickets JOIN TripBooking ON TripBooking.BookingID = ETickets.BookingID WHERE TripBooking.TravellerID = @UserID";

            using (SqlConnection conn = new SqlConnection(con))
            {
                conn.Open();
                SqlCommand cmd = new SqlCommand(query, conn);
                cmd.Parameters.AddWithValue("@UserID", Program.CurrentUser.userid);
                SqlDataAdapter da = new SqlDataAdapter(cmd);
                DataTable dt = new DataTable();
                da.Fill(dt);
                et.Items.Clear();
                et.View = View.Details;
                et.Columns.Clear();
                et.Columns.Add("Ticket ID");
                et.Columns.Add("Description");
                et.Columns.Add("Discount");
                et.Columns.Add("Valid For (weeks)");

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
                        item.SubItems.Add(row["Descrip"].ToString());
                        item.SubItems.Add(row["Discount"].ToString());
                        item.SubItems.Add(row["ValidFor"].ToString());
                        et.Items.Add(item);
                    }
                }
            }
        }

        private void LoadVouchers()
        {
            string query = @"SELECT * FROM HotelVoucher JOIN TripBooking ON TripBooking.BookingID = HotelVoucher.BookingID WHERE TripBooking.TravellerID = @UserID";

            using (SqlConnection conn = new SqlConnection(con))
            {
                conn.Open();
                SqlCommand cmd = new SqlCommand(query, conn);
                cmd.Parameters.AddWithValue("@UserID", Program.CurrentUser.userid);
                SqlDataAdapter da = new SqlDataAdapter(cmd);
                DataTable dt = new DataTable();
                da.Fill(dt);
                hv.Items.Clear();
                hv.View = View.Details;
                hv.Columns.Clear();
                hv.Columns.Add("Voucher ID");
                hv.Columns.Add("Description");
                hv.Columns.Add("Discount");
                hv.Columns.Add("Valid For (weeks)");
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
                        item.SubItems.Add(row["Descrip"].ToString());
                        item.SubItems.Add(row["Discount"].ToString());
                        item.SubItems.Add(row["ValidFor"].ToString());
                        hv.Items.Add(item);
                    }
                }
            }
        }

        private void TravellerPass_Load(object sender, EventArgs e)
        {
            nopass.Visible = false;
            LoadActivityPass();
            LoadETickets();
            LoadVouchers();
        }
    }
}
