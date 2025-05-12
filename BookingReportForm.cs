using Microsoft.Reporting.WinForms;
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
    public partial class BookingReportForm : Form
    {
        public BookingReportForm()
        {
            InitializeComponent();
        }

        private void BookingReportForm_Load(object sender, EventArgs e)
        {
            // Clear and set report path
            reportViewer1.LocalReport.DataSources.Clear();
            reportViewer1.LocalReport.ReportEmbeddedResource = "dbproject.TBReport.rdlc"; // adjust namespace if needed

            // Create adapter and fill dataset
            TripBookingDataSet ds = new TripBookingDataSet();
            var adapter = new TripBookingDataSetTableAdapters.View_TotalBookingsTableAdapter();
            adapter.Fill(ds.View_TotalBookings);

            // Bind to report
            ReportDataSource rds = new ReportDataSource("View_TotalBookings", (DataTable)ds.View_TotalBookings);
            reportViewer1.LocalReport.DataSources.Add(rds);
            reportViewer1.RefreshReport();
        }

        private void reportViewer1_Load(object sender, EventArgs e)
        {

        }
    }
}
