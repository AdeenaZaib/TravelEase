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
            //reportViewer1.LocalReport.DataSources.Clear();
            //reportViewer1.LocalReport.ReportEmbeddedResource = "dbproject.TBReport.rdlc"; // adjust namespace if needed

            // Create adapter and fill dataset
            
            /*TripBookingDataSet ds = new TripBookingDataSet();
            var adapter = new TripBookingDataSetTableAdapters.View_TotalBookingsTableAdapter();
            new TripBookingDataSetTableAdapters.View_TotalBookingsTableAdapter().Fill(ds.View_TotalBookings);
            new TripBookingDataSetTableAdapters.View_RevenueByCategoryTableAdapter().Fill(ds.View_RevenueByCategory);
            new TripBookingDataSetTableAdapters.View_CancellationRateTableAdapter().Fill(ds.View_CancellationRate);
            adapter.Fill(ds.View_TotalBookings);*/

            // Bind to report
           /* ReportDataSource rds = new ReportDataSource("View_TotalBookings", (DataTable)ds.View_TotalBookings);
            reportViewer1.LocalReport.DataSources.Add(rds);
            reportViewer1.RefreshReport();*/
            // Create an instance of your dataset
            TripBookingDataSet ds = new TripBookingDataSet();

            // Fill each DataTable in the dataset using the respective adapters
            new TripBookingDataSetTableAdapters.View_TotalBookingsTableAdapter().Fill(ds.View_TotalBookings);
            new TripBookingDataSetTableAdapters.View_CategoryRevenueTableAdapter().Fill(ds.View_CategoryRevenue);
            new TripBookingDataSetTableAdapters.View_CapacityRevenueTableAdapter().Fill(ds.View_CapacityRevenue);
            new TripBookingDataSetTableAdapters.View_CancellationRateTableAdapter().Fill(ds.View_CancellationRate);
            new TripBookingDataSetTableAdapters.View_AvgRevenueTableAdapter().Fill(ds.View_AvgRevenue);
            new TripBookingDataSetTableAdapters.View_BookingPeriodTableAdapter().Fill(ds.View_BookingPeriod);

            // Clear any previous data sources and bind each dataset to the report
            reportViewer1.LocalReport.DataSources.Clear();
            reportViewer1.LocalReport.ReportEmbeddedResource = "dbproject.TBReport.rdlc";  // Make sure this path is correct

            reportViewer1.LocalReport.DataSources.Add(new Microsoft.Reporting.WinForms.ReportDataSource("View_TotalBookings", (DataTable)ds.View_TotalBookings));
            reportViewer1.LocalReport.DataSources.Add(new Microsoft.Reporting.WinForms.ReportDataSource("View_CategoryRevenue", (DataTable)ds.View_CategoryRevenue));
            reportViewer1.LocalReport.DataSources.Add(new Microsoft.Reporting.WinForms.ReportDataSource("View_CapacityRevenue", (DataTable)ds.View_CapacityRevenue));
            reportViewer1.LocalReport.DataSources.Add(new Microsoft.Reporting.WinForms.ReportDataSource("View_CancellationRate", (DataTable)ds.View_CancellationRate));
            reportViewer1.LocalReport.DataSources.Add(new Microsoft.Reporting.WinForms.ReportDataSource("View_AvgRevenue", (DataTable)ds.View_AvgRevenue));
            reportViewer1.LocalReport.DataSources.Add(new Microsoft.Reporting.WinForms.ReportDataSource("View_BookingPeriod", (DataTable)ds.View_BookingPeriod));

            // Refresh the report
            reportViewer1.RefreshReport();

        }

        private void reportViewer1_Load(object sender, EventArgs e)
        {

        }

        private void label3_Click(object sender, EventArgs e)
        {
            Analytics analytics = new Analytics();
            analytics.Show();
            this.Hide();
        }
    }
}
