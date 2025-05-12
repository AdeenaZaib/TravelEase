using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Data.SqlClient;
using System.Drawing;
using System.Linq;
using System.Reflection.Emit;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Windows.Forms.VisualStyles;
using static System.Windows.Forms.VisualStyles.VisualStyleElement;

namespace dbproject
{
    public partial class ManageUsers : Form
    {
        public ManageUsers()
        {
            InitializeComponent();
        }

        private void labelButton2_Click(object sender, EventArgs e)
        {
            ManageUsers us = new ManageUsers();
            us.Show();
            this.Hide();
        }

        private void labelButton5_Click(object sender, EventArgs e)
        {
            ManageDestinations ds = new ManageDestinations();
            ds.Show();
            this.Hide();
        }

        private void labelButton1_Click(object sender, EventArgs e)
        {
            Admin home = new Admin();
            home.Show();
            this.Hide();
        }

        private void pendingView_SelectedIndexChanged(object sender, EventArgs e)
        {

        }

        private void InitializePendingView()
        {
            pendingView.View = View.Details;
            pendingView.FullRowSelect = true;
            pendingView.GridLines = true;

            pendingView.Columns.Clear();
            pendingView.Columns.Add("User ID", 100);
            pendingView.Columns.Add("First Name", 120);
            pendingView.Columns.Add("Last Name", 120);
            pendingView.Columns.Add("Email", 180);
            pendingView.Columns.Add("Role", 120);
        }

        private void LoadPendingUsers()
        {
            
            pendingView.Items.Clear();
            using (SqlConnection con = new SqlConnection("Data Source=.\\SQLEXPRESS;Initial Catalog=TravelEase;Integrated Security=True"))
            {
                string query = @"
            SELECT U.UserID, U.FirstName, U.LastName, U.Email,
                   'Traveller' AS Role
            FROM Users U
            INNER JOIN Traveller T ON U.UserID = T.TravellerID
            WHERE T.TravellerStatus = 'Pending'
            UNION
            SELECT U.UserID, U.FirstName, U.LastName, U.Email,
                   'Tour Operator' AS Role
            FROM Users U
            INNER JOIN TourOperator O ON U.UserID = O.TourOperatorID
            WHERE O.OperatorStatus = 'Pending'
            UNION
            SELECT U.UserID, U.FirstName, U.LastName, U.Email,
                    'Service Provider' AS Role
            FROM Users U
            INNER JOIN ServiceProvider S ON U.UserID = S.ServiceProviderID
            WHERE S.SPStatus = 'Pending' ";

                SqlCommand cmd = new SqlCommand(query, con);
                con.Open();
                SqlDataReader reader = cmd.ExecuteReader();

                while (reader.Read())
                {
                    ListViewItem item = new ListViewItem(reader["UserID"].ToString());
                    item.SubItems.Add(reader["FirstName"].ToString());
                    item.SubItems.Add(reader["LastName"].ToString());
                    item.SubItems.Add(reader["Email"].ToString());
                    item.SubItems.Add(reader["Role"].ToString());
                    pendingView.Items.Add(item);
                }
            }
        }

        private void ManageUsers_Load(object sender, EventArgs e)
        {
           InitializePendingView();
            LoadPendingUsers();

        }

        private void apply_Click(object sender, EventArgs e)
        {
            UpdateUserStatus("Approved");
        }

        private void comboBox1_SelectedIndexChanged(object sender, EventArgs e)
        {

        }

        private void UpdateUserStatus(string newStatus)
        {
            if (pendingView.SelectedItems.Count == 0)
            {
                MessageBox.Show("Please select a user.");
                return;
            }

            ListViewItem selectedItem = pendingView.SelectedItems[0];
            string userId = selectedItem.SubItems[0].Text;
            string role = selectedItem.SubItems[4].Text;

            string tableName = null;
            string idColumn = null;
            string statusColumn = null;

            switch (role)
            {
                case "Traveller":
                    tableName = "Traveller";
                    idColumn = "TravellerID";
                    statusColumn = "TravellerStatus";
                    break;
                case "Tour Operator":
                    tableName = "TourOperator";
                    idColumn = "TourOperatorID";
                    statusColumn = "OperatorStatus";
                    break;
                case "Service Provider":
                    tableName = "ServiceProvider";
                    idColumn = "ServiceProviderID";
                    statusColumn = "SPStatus";
                    break;
                default:
                    MessageBox.Show("Unknown role type.");
                    return;
            }

            using (SqlConnection con = new SqlConnection("Data Source=.\\SQLEXPRESS;Initial Catalog=TravelEase;Integrated Security=True"))
            {
                string query = $"UPDATE {tableName} SET {statusColumn} = @status WHERE {idColumn} = @userId";
                SqlCommand cmd = new SqlCommand(query, con);
                cmd.Parameters.AddWithValue("@status", newStatus);
                cmd.Parameters.AddWithValue("@userId", userId);

                con.Open();
                int rowsAffected = cmd.ExecuteNonQuery();

                if (rowsAffected > 0)
                {
                    MessageBox.Show($"User {newStatus.ToLower()} successfully.");
                    LoadPendingUsers();
                }
                else
                {
                    MessageBox.Show("Failed to update user status.");
                }
         
            }
        }

        private void reject_Click(object sender, EventArgs e)
        {
            UpdateUserStatus("Rejected");
        }
    }
}
