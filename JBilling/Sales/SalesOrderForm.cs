using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;

namespace JBilling.Sales
{
    public partial class SalesOrderForm : JBilling.Controls.JBillingForm
    {
        public SalesOrderForm()
        {
            InitializeComponent();
            InitializeForm();
        }

        #region Properties
        protected JBilling.DataSets.Sales.SalesOrderDataSet SalesOrderDataSet
        {
            get
            {
                return (JBilling.DataSets.Sales.SalesOrderDataSet)base.MainDataSet;
            }
            set
            {
                base.MainDataSet = value;
            }
        }

        private string CurrentSalesOrderNumber
        {
            get;
            set;
        }
        #endregion

        JBilling.BusinessLogic.Sales.SalesOrderBusinessLogic _sBusinessLogic = new BusinessLogic.Sales.SalesOrderBusinessLogic();

        protected override void InitializeForm()
        {
            SalesOrderDataSet = new DataSets.Sales.SalesOrderDataSet();

            base.InitializeForm();

            dgSalesOrder.MainDataSet = SalesOrderDataSet;
            dgSalesOrder.TableName = "SalesOrderDetails";

            dgSalesOrder.Initialize();

            _sBusinessLogic.GetStaticData(SalesOrderDataSet);

            BindControls();

            CurrentFormMode = JBilling.Controls.FormModes.Nil;
        }

        private void BindControls()
        {
            txtSalesOrderNumber.SetDataBindings(SalesOrderDataSet, "SalesOrders", "SalesOrderNumber");
            txtTax.SetDataBindings(SalesOrderDataSet, "SalesOrders", "Tax");

            cmbSalesOrder.Table = SalesOrderDataSet.SalesOrdersList;
            cmbSalesOrder.DisplayMember = "SalesOrderNumber";
            cmbSalesOrder.ValueMember = "SalesOrderNumber";
            cmbSalesOrder.ColumnsToDisplay = new string[] {"SalesOrderNumber", "CompanyName" };

            cmbCompanyName.Table = SalesOrderDataSet.CompanyList;
            cmbCompanyName.DisplayMember = "CompanyName";
            cmbCompanyName.ValueMember = "CompanyID";
            cmbCompanyName.ColumnsToDisplay = new string[] { "CompanyName", "CustomerCode" };
        }

        protected override void FormModeChanged()
        {
            switch (CurrentFormMode)
            {
                case JBilling.Controls.FormModes.Nil:
                    this.MakeFormNil(this);
                    cmbSalesOrder.Enabled = true;
                    break;
                case JBilling.Controls.FormModes.Edit:
                    this.MakeFormNewOrEdit(this, false);
                    cmbSalesOrder.Enabled = true;
                    cmbCompanyName.Enabled = false;
                    txtSalesOrderNumber.Enabled = false;
                    btnPrint.Enabled = true;
                    break;
                case JBilling.Controls.FormModes.New:
                    this.MakeFormNewOrEdit(this, true);
                    cmbSalesOrder.Enabled = false;
                    cmbCompanyName.Enabled = true;
                    btnPrint.Enabled = false;
                    break;
            }
        }

        protected override void AttachEvents()
        {
            base.AttachEvents();
            cmbSalesOrder.AfterSelectEvent += new JBilling.Controls.AfterSelectEventHandler(cmbSalesOrder_AfterSelectEvent);
            txtSalesOrderNumber.Leave += new EventHandler(txtSalesOrderNumber_Leave);
            cmbCompanyName.AfterSelectEvent += new JBilling.Controls.AfterSelectEventHandler(cmbCompanyName_AfterSelectEvent);
            SalesOrderDataSet.SalesOrderDetails.RowChanged += new DataRowChangeEventHandler(SalesOrderDetails_RowChanged);
            SalesOrderDataSet.SalesOrderDetails.ColumnChanged += new DataColumnChangeEventHandler(SalesOrderDetails_ColumnChanged);
            SalesOrderDataSet.SalesOrderDetails.RowDeleted += new DataRowChangeEventHandler(SalesOrderDetails_RowDeleted);
            txtTax.Leave += new EventHandler(txtTax_Leave);
            btnPrint.Click += new EventHandler(btnPrint_Click);
        }

        void txtTax_Leave(object sender, EventArgs e)
        {
            try
            {
                dlblTax.Text = Convert.ToDecimal(txtTax.Text).ToString();
                CalculateGridTotal();
                DataChanged = true;
            }
            catch (FormatException)
            {
                JBilling.Controls.JBillingMessageBox.ShowException("Tax value should be numeric");
            }
        }

        void SalesOrderDetails_ColumnChanged(object sender, DataColumnChangeEventArgs e)
        {
            DetachEvents();

            try
            {
                if (e.Column.ColumnName.Equals("PartNumber") && e.Row["PartNumber"] != DBNull.Value)
                {
                    string strPartNumber = e.Row["PartNumber"].ToString();

                    DataRow[] partRows = SalesOrderDataSet.PartList.Select("PartNumber = '" + strPartNumber + "'");

                    if (partRows.Length > 0)
                    {
                        e.Row["PartPrice"] = partRows[0]["PartPrice"];
                    }
                }

                if (e.Column.ColumnName.Equals("Quantity") || e.Column.ColumnName.Equals("PartPrice"))
                {
                    CalculateGridTotal();

                    if (e.Row["Quantity"] != DBNull.Value && e.Row["PartPrice"] != DBNull.Value)
                    {
                        e.Row["LineTotal"] = Convert.ToDecimal(e.Row["Quantity"]) * Convert.ToDecimal(e.Row["PartPrice"]);
                    }
                }

                DataChanged = true;
            }
            finally
            {
                AttachEvents();
            }
        }

        private void CalculateGridTotal()
        {
            decimal sum = 0;

            dlblTax.Text = txtTax.Text;

            foreach (DataRow row in SalesOrderDataSet.SalesOrderDetails.Rows)
            {
                if (row["Quantity"] != DBNull.Value && row["PartPrice"] != DBNull.Value)
                {
                    sum += Convert.ToDecimal(row["Quantity"]) * Convert.ToDecimal(row["PartPrice"]);
                }
            }

            dllblSum.Text = sum.ToString();
            decimal decTax = Convert.ToDecimal(txtTax.Text);

            dlblTotal.Text = Convert.ToString((decTax / 100) * sum + sum);
        }

        void SalesOrderDetails_RowChanged(object sender, DataRowChangeEventArgs e)
        {
            DetachEvents();
            try
            {
                if (e.Row["SalesOrderNumber"] == DBNull.Value)
                    e.Row["SalesOrderNumber"] = CurrentSalesOrderNumber;

                if (e.Row["LineNumber"] == DBNull.Value)
                    e.Row["LineNumber"] = GetNextLineNumber();
            }
            finally
            {
                AttachEvents();
            }
        }

        void SalesOrderDetails_RowDeleted(object sender, DataRowChangeEventArgs e)
        {
            DataChanged = true;
        }

        private int GetNextLineNumber()
        {
            object maxLineNumber = SalesOrderDataSet.SalesOrderDetails.Compute("MAX(LineNumber)", string.Empty);

            if(maxLineNumber == DBNull.Value)
                return 1;

            return Convert.ToInt32(maxLineNumber) + 1;
        }

        void cmbCompanyName_AfterSelectEvent(object sender, DataRow selectedRow)
        {
            if (selectedRow != null && selectedRow["CompanyID"] != DBNull.Value)
            {
                SalesOrderDataSet.SalesOrders[0].CompanyID = Convert.ToInt32(selectedRow["CompanyID"]);
            }
        }

        void txtSalesOrderNumber_Leave(object sender, EventArgs e)
        {
            CurrentSalesOrderNumber = txtSalesOrderNumber.Text;
            DataChanged = true;
        }

        void btnPrint_Click(object sender, EventArgs e)
        {
            JBilling.Reporting.ReportingManager rm = new Reporting.ReportingManager();
            rm.ReportType = Reporting.ReportingManager.ReportTypes.SalesInvoice;
            rm.Table = SalesOrderDataSet.SalesOrderDetails;
            rm.LoadReport();
            SetCustomLabels(rm);
            rm.ShowPreview();
        }

        private void SetCustomLabels(Reporting.ReportingManager rm)
        {
            rm.SetLabelValue("PageFooter", "dlblSum", dllblSum.Text);
            DataRow[] rows = SalesOrderDataSet.SalesOrdersList.Select("SalesOrderNumber = '" + CurrentSalesOrderNumber + "'");
            if(rows.Length > 0)
                rm.SetLabelValue("ReportHeader", "dlblCustomerName", rows[0]["CompanyName"].ToString());
            rm.SetLabelValue("ReportHeader", "dlblSalesOrderNumber", CurrentSalesOrderNumber);
            rm.SetLabelValue("PageFooter", "dlblTotal", dlblTotal.Text);
            rm.SetLabelValue("PageFooter", "dlblTax", txtTax.Text + "%");
        }

        void cmbSalesOrder_AfterSelectEvent(object sender, DataRow selectedRow)
        {
            if (selectedRow != null && selectedRow["SalesOrderNumber"] != DBNull.Value)
            {
                CurrentSalesOrderNumber = selectedRow["SalesOrderNumber"].ToString();

                _sBusinessLogic.GetSalesOrderData(SalesOrderDataSet, selectedRow["SalesOrderNumber"].ToString());

                cmbCompanyName.SelectedKey = selectedRow["CompanyID"];

                SalesOrderDataSet.SalesOrders.AcceptChanges();

                CurrentFormMode = JBilling.Controls.FormModes.Edit;

                CalculateGridTotal();
            }
        }

        protected override void DetachEvents()
        {
            base.DetachEvents();
            cmbSalesOrder.AfterSelectEvent -= new JBilling.Controls.AfterSelectEventHandler(cmbSalesOrder_AfterSelectEvent);
            txtSalesOrderNumber.Leave -= new EventHandler(txtSalesOrderNumber_Leave);
            cmbCompanyName.AfterSelectEvent -= new JBilling.Controls.AfterSelectEventHandler(cmbCompanyName_AfterSelectEvent);
            SalesOrderDataSet.SalesOrderDetails.RowChanged -= new DataRowChangeEventHandler(SalesOrderDetails_RowChanged);
            SalesOrderDataSet.SalesOrderDetails.ColumnChanged -= new DataColumnChangeEventHandler(SalesOrderDetails_ColumnChanged);
            SalesOrderDataSet.SalesOrderDetails.RowDeleted -= new DataRowChangeEventHandler(SalesOrderDetails_RowDeleted);
            btnPrint.Click -= new EventHandler(btnPrint_Click);
        }

        protected override void OnNew(object sender, EventArgs e)
        {
            base.OnNew(sender, e);

            SalesOrderDataSet.SalesOrders.Clear();
            SalesOrderDataSet.SalesOrders.Rows.Add(SalesOrderDataSet.SalesOrders.NewRow());

            SalesOrderDataSet.SalesOrderDetails.Clear();

            cmbSalesOrder.SelectedKey = DBNull.Value;
            cmbCompanyName.SelectedKey = DBNull.Value;
        }

        protected override bool UpdateData()
        {
            if (_sBusinessLogic.UpdateData(SalesOrderDataSet))
            {
                CurrentFormMode = JBilling.Controls.FormModes.Edit;
                return true;
            }

            return false;
        }
    }
}
