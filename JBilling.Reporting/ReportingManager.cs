using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using NeoDataType.MyNeoReport;
using System.Data;
using System.IO;
using JBilling.DataAccess;

namespace JBilling.Reporting
{
    public class ReportingManager
    {
        Report report = new Report();

        public ReportingManager()
        {
            
        }

        public ReportingManager(ReportTypes reportType) : this()
        {
            ReportType = reportType;
        }

        public enum ReportTypes
        {
            SalesInvoice = 0
        }

        public DataTable Table
        {
            get;
            set;
        }

        public ReportTypes ReportType
        {
            get;
            set;
        }

        public void SetLabelValue(string section, string labelName, string value)
        {
            Label dataLabel = report.Page.Sections[section].Items[labelName] as Label;
            dataLabel.Text = value;
        }

        public void LoadReport()
        {
            Stream s = new FileStream(GetReportFileName(), FileMode.Open);

            report.LoadFrom(s);

            SetReportHeader();

            SetPageHeader();

            SetDetails();
        }

        public void ShowPreview()
        {
            report.ShowPreview();
        }

        private string GetReportFileName()
        {
            switch (ReportType)
            {
                case ReportTypes.SalesInvoice:
                    return "ReportDefs/sales_invoice.mr6";
                default:
                    return "ReportDefs/sample_report.mr6";
            }
        }

        private string GetReportTitle()
        {
            switch (ReportType)
            {
                case ReportTypes.SalesInvoice:
                    return "Sales Invoice";
                default:
                    return "Sample";
            }
        }

        private void SetReportHeader()
        {
            DataSet ds = new DataSet();
            JBilling.BusinessLogic.Settings.CompanyDetailsBusinessLogic _cdBusinessLogic = new BusinessLogic.Settings.CompanyDetailsBusinessLogic();

            _cdBusinessLogic.GetCompanyData(ds);

            Label dlblCompanyName = report.Page.ReportHeader.Items["dlblCompanyName"] as Label;
            dlblCompanyName.Text = ds.Tables["CompanyDetails"].Rows[0]["CompanyName"].ToString();

            Label dlblCompanyAddr = report.Page.ReportHeader.Items["dlblCompanyAddress"] as Label;
            dlblCompanyAddr.Text = ds.Tables["CompanyDetails"].Rows[0]["CompanyAddress"].ToString();

            Label dlblTaxNo = report.Page.ReportFooter.Items["dlblTaxNo"] as Label;
            dlblTaxNo.Text = ds.Tables["CompanyDetails"].Rows[0]["TaxRegistrationNo"].ToString();

            Label dlblContactNo = report.Page.ReportFooter.Items["dlblContactNo"] as Label;
            if (!string.IsNullOrEmpty(ds.Tables["CompanyDetails"].Rows[0]["ContactNo"].ToString()))
            {
                dlblContactNo.Text = ds.Tables["CompanyDetails"].Rows[0]["ContactNo"].ToString();
            }
            else
            {
                dlblContactNo.Visible = false;
                Label lblContactNo = report.Page.ReportFooter.Items["lblContactNo"] as Label;
                lblContactNo.Visible = false;
            }

            Label dlblDate = report.Page.ReportHeader.Items["dlblDate"] as Label;
            dlblDate.Text = DateTime.Now.Date.ToShortDateString();

            Label dlblOwnerName = report.Page.ReportFooter.Items["dlblOwnerName"] as Label;
            dlblOwnerName.Text = ds.Tables["CompanyDetails"].Rows[0]["ContactName"].ToString();
        }

        private void SetPageHeader()
        {
            SetReportName();
            PopulateColumnNames();
        }

        private void PopulateColumnNames()
        {

        }

        private void SetReportName()
        {
        }

        private void SetDetails()
        {
            TableDataSource dataSource = new TableDataSource();
            dataSource.Table = Table;

            report.Page.Details.DataSource = dataSource;
        }
    }
}
