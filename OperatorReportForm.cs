﻿using System;
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
    public partial class OperatorReportForm : Form
    {
        public OperatorReportForm()
        {
            InitializeComponent();
        }

        private void OperatorReportForm_Load(object sender, EventArgs e)
        {
            TourOperatorDataSet ds = new TourOperatorDataSet();

            // Fill each DataTable in the dataset using the respective adapters
            new TourOperatorDataSetTableAdapters.View_OperatorEarningTableAdapter().Fill(ds.View_OperatorEarning);
            new TourOperatorDataSetTableAdapters.View_ResponseTimeTableAdapter().Fill(ds.View_ResponseTime);

            // Clear any previous data sources and bind each dataset to the report
            reportViewer1.LocalReport.DataSources.Clear();
            reportViewer1.LocalReport.ReportEmbeddedResource = "dbproject.TOReport.rdlc";  // Make sure this path is correct

            reportViewer1.LocalReport.DataSources.Add(new Microsoft.Reporting.WinForms.ReportDataSource("View_OperatorEarning", (DataTable)ds.View_OperatorEarning));
            reportViewer1.LocalReport.DataSources.Add(new Microsoft.Reporting.WinForms.ReportDataSource("View_ResponseTime", (DataTable)ds.View_ResponseTime));


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
