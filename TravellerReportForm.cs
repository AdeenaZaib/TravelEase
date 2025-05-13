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
    public partial class TravellerReportForm : Form
    {
        public TravellerReportForm()
        {
            InitializeComponent();
        }

        private void TravellerReportForm_Load(object sender, EventArgs e)
        {
            TravellerDataSet ds = new TravellerDataSet();

            // Fill each DataTable in the dataset using the respective adapters
            new TravellerDataSetTableAdapters.View_AgeGroupTableAdapter().Fill(ds.View_AgeGroup);
            new TravellerDataSetTableAdapters.View_AvgBudgetTableAdapter().Fill(ds.View_AvgBudget);
            new TravellerDataSetTableAdapters.View_NationalityTableAdapter().Fill(ds.View_Nationality);

            // Clear any previous data sources and bind each dataset to the report
            reportViewer1.LocalReport.DataSources.Clear();
            reportViewer1.LocalReport.ReportEmbeddedResource = "dbproject.TReport.rdlc";  // Make sure this path is correct

            reportViewer1.LocalReport.DataSources.Add(new Microsoft.Reporting.WinForms.ReportDataSource("View_AgeGroup", (DataTable)ds.View_AgeGroup));
            reportViewer1.LocalReport.DataSources.Add(new Microsoft.Reporting.WinForms.ReportDataSource("View_AvgBudget", (DataTable)ds.View_AvgBudget));
            reportViewer1.LocalReport.DataSources.Add(new Microsoft.Reporting.WinForms.ReportDataSource("View_Nationality", (DataTable)ds.View_Nationality));

            this.reportViewer1.RefreshReport();
        }
    }
}
