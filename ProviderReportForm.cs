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
    public partial class ProviderReportForm : Form
    {
        public ProviderReportForm()
        {
            InitializeComponent();
        }

        private void ProviderReportForm_Load(object sender, EventArgs e)
        {
            ServiceProviderDataSet ds = new ServiceProviderDataSet();

            // Fill each DataTable in the dataset using the respective adapters
            new ServiceProviderDataSetTableAdapters.View_GuideRatingTableAdapter().Fill(ds.View_GuideRating);
            new ServiceProviderDataSetTableAdapters.View_OccupancyRateTableAdapter ().Fill(ds.View_OccupancyRate);
            new ServiceProviderDataSetTableAdapters.View_OnTimeTableAdapter().Fill(ds.View_OnTime);

            // Clear any previous data sources and bind each dataset to the report
            reportViewer1.LocalReport.DataSources.Clear();
            reportViewer1.LocalReport.ReportEmbeddedResource = "dbproject.SPReport.rdlc";  // Make sure this path is correct

            reportViewer1.LocalReport.DataSources.Add(new Microsoft.Reporting.WinForms.ReportDataSource("View_GuideRating", (DataTable)ds.View_GuideRating));
            reportViewer1.LocalReport.DataSources.Add(new Microsoft.Reporting.WinForms.ReportDataSource("View_OccupancyRate", (DataTable)ds.View_OccupancyRate));
            reportViewer1.LocalReport.DataSources.Add(new Microsoft.Reporting.WinForms.ReportDataSource("View_OnTime", (DataTable)ds.View_OnTime));

            this.reportViewer1.RefreshReport();
        }
    }
}
