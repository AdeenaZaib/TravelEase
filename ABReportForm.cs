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
    public partial class ABReportForm : Form
    {
        public ABReportForm()
        {
            InitializeComponent();
        }

        private void ABReportForm_Load(object sender, EventArgs e)
        {
            ABookingDataSet ds = new ABookingDataSet();

            // Fill each DataTable in the dataset using the respective adapters
            new ABookingDataSetTableAdapters.View_HighPriceTableAdapter().Fill(ds.View_HighPrice);
            new ABookingDataSetTableAdapters.View_IncompleteBookingsTableAdapter().Fill(ds.View_IncompleteBookings);
            new ABookingDataSetTableAdapters.View_PaymentFailureTableAdapter().Fill(ds.View_PaymentFailure);
            new ABookingDataSetTableAdapters.View_RecoveryRateTableAdapter().Fill(ds.View_RecoveryRate);
            new ABookingDataSetTableAdapters.View_RevenueLossTableAdapter().Fill(ds.View_RevenueLoss);

            // Clear any previous data sources and bind each dataset to the report
            reportViewer1.LocalReport.DataSources.Clear();
            reportViewer1.LocalReport.ReportEmbeddedResource = "dbproject.ABReport.rdlc";  // Make sure this path is correct

            reportViewer1.LocalReport.DataSources.Add(new Microsoft.Reporting.WinForms.ReportDataSource("View_HighPrice", (DataTable)ds.View_HighPrice));
            reportViewer1.LocalReport.DataSources.Add(new Microsoft.Reporting.WinForms.ReportDataSource("View_IncompleteBookings", (DataTable)ds.View_IncompleteBookings));
            reportViewer1.LocalReport.DataSources.Add(new Microsoft.Reporting.WinForms.ReportDataSource("View_PaymentFailure", (DataTable)ds.View_PaymentFailure));
            reportViewer1.LocalReport.DataSources.Add(new Microsoft.Reporting.WinForms.ReportDataSource("View_RecoveryRate", (DataTable)ds.View_RecoveryRate));
            reportViewer1.LocalReport.DataSources.Add(new Microsoft.Reporting.WinForms.ReportDataSource("View_RevenueLoss", (DataTable)ds.View_RevenueLoss));

            this.reportViewer1.RefreshReport();
        }

        private void label3_Click(object sender, EventArgs e)
        {
            Analytics analytics = new Analytics();
            analytics.Show();
            this.Hide();
        }
    }
}
