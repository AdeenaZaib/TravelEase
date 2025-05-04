using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace dbproject
{
    public partial class TripSearch : Form
    {
        public TripSearch()
        {
            InitializeComponent();
        }

        private void TripSearch_Load(object sender, EventArgs e)
        {
            filterOptions.Items.Add("Destination");
            filterOptions.Items.Add("Price");
            filterOptions.Items.Add("Date");
            filterOptions.Items.Add("Activity Type");

            // Hide all controls initially
            destinationComboBox.Visible = false;
            minPriceUpDown.Visible = maxPriceUpDown.Visible = false;
            startDatePicker.Visible = endDatePicker.Visible = false;
            activityListBox.Visible = false;
        }

        private void filterOptions_ItemCheck(object sender, ItemCheckEventArgs e)
        {
            // Delay visibility change until item is actually checked
            this.BeginInvoke((MethodInvoker)(() =>
            {
                string selected = filterOptions.Items[e.Index].ToString();
                bool isChecked = filterOptions.GetItemChecked(e.Index);

                switch (selected)
                {
                    case "Destination":
                        destinationComboBox.Visible = !isChecked;
                        break;
                    case "Price":
                        minPriceUpDown.Visible = maxPriceUpDown.Visible = !isChecked;
                        break;
                    case "Date":
                        startDatePicker.Visible = endDatePicker.Visible = !isChecked;
                        break;
                    case "Activity Type":
                        activityListBox.Visible = !isChecked;
                        break;
                }
            }));
        }

        private void applyFilterButton_Click(object sender, EventArgs e)
        {
            string query = "SELECT * FROM Trips WHERE 1=1";

            if (destinationComboBox.Visible && destinationComboBox.SelectedItem != null)
                query += $" AND Destination = '{destinationComboBox.SelectedItem}'";

            if (minPriceUpDown.Visible)
                query += $" AND Price >= {minPriceUpDown.Value}";

            if (maxPriceUpDown.Visible)
                query += $" AND Price <= {maxPriceUpDown.Value}";

            if (startDatePicker.Visible)
                query += $" AND TripDate >= '{startDatePicker.Value.ToShortDateString()}'";

            if (endDatePicker.Visible)
                query += $" AND TripDate <= '{endDatePicker.Value.ToShortDateString()}'";

            if (activityListBox.Visible)
            {
                List<string> activities = new List<string>();
                foreach (var item in activityListBox.CheckedItems)
                    activities.Add($"'{item.ToString()}'");

                if (activities.Any())
                    query += $" AND ActivityType IN ({string.Join(",", activities)})";
            }

            MessageBox.Show("Generated Query:\n" + query);
        }


        private void comboBox1_SelectedIndexChanged(object sender, EventArgs e)
        {

        }

    }
}
