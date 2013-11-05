using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using JBilling.Controls;

namespace JBilling.Commercial
{
    public partial class CompanyForm : JBilling.Controls.JBillingForm
    {
        public CompanyForm()
        {
            InitializeComponent();
            InitializeForm();
        }

        #region Private variables
        JBilling.BusinessLogic.Commercial.CompanyBusinessLogic _cBusinessLogic = new BusinessLogic.Commercial.CompanyBusinessLogic();
        #endregion

        #region Properties
        protected JBilling.DataSets.Commercial.CompanyDataSet CompanyDataSet
        {
            get
            {
                return (JBilling.DataSets.Commercial.CompanyDataSet)base.MainDataSet;
            }
            set
            {
                base.MainDataSet = value;
            }
        }
        #endregion

        #region Overriden methods
        protected override void InitializeForm()
        {
            base.InitializeForm();

            CompanyDataSet = new DataSets.Commercial.CompanyDataSet();

            _cBusinessLogic.GetStaticData(CompanyDataSet);

            BindControls();

            CurrentFormMode = JBilling.Controls.FormModes.Nil;
        }

        protected override void AttachEvents()
        {
            base.AttachEvents();
            cmbCompanyName.AfterSelectEvent += new JBilling.Controls.AfterSelectEventHandler(cmbCompanyName_AfterSelectEvent);
            txtComanyName.Leave += new EventHandler(txtComanyName_Leave);
            txtCompanyAddress.Leave += new EventHandler(txtCompanyAddress_Leave);
            txtCompanyWebsite.Leave += new EventHandler(txtCompanyWebsite_Leave);
            txtContactEmail.Leave += new EventHandler(txtContactEmail_Leave);
            txtContactName.Leave += new EventHandler(txtContactName_Leave);
            txtCustomerCode.Leave += new EventHandler(txtCustomerCode_Leave);
            txtDeliveryAddress.Leave += new EventHandler(txtDeliveryAddress_Leave);
            txtSupplierCode.Leave += new EventHandler(txtSupplierCode_Leave);
            txtTaxRegNo.Leave += new EventHandler(txtTaxRegNo_Leave);
            chkIsCustomer.CheckedChanged += new EventHandler(chkIsCustomer_CheckedChanged);
            chkIsSupplier.CheckedChanged += new EventHandler(chkIsSupplier_CheckedChanged);
        }

        protected override void DetachEvents()
        {
            base.DetachEvents();
            cmbCompanyName.AfterSelectEvent -= new JBilling.Controls.AfterSelectEventHandler(cmbCompanyName_AfterSelectEvent);
            txtComanyName.Leave -= new EventHandler(txtComanyName_Leave);
            txtCompanyAddress.Leave -= new EventHandler(txtCompanyAddress_Leave);
            txtCompanyWebsite.Leave -= new EventHandler(txtCompanyWebsite_Leave);
            txtContactEmail.Leave -= new EventHandler(txtContactEmail_Leave);
            txtContactName.Leave -= new EventHandler(txtContactName_Leave);
            txtCustomerCode.Leave -= new EventHandler(txtCustomerCode_Leave);
            txtDeliveryAddress.Leave -= new EventHandler(txtDeliveryAddress_Leave);
            txtSupplierCode.Leave -= new EventHandler(txtSupplierCode_Leave);
            txtTaxRegNo.Leave -= new EventHandler(txtTaxRegNo_Leave);
            chkIsCustomer.CheckedChanged -= new EventHandler(chkIsCustomer_CheckedChanged);
            chkIsSupplier.CheckedChanged -= new EventHandler(chkIsSupplier_CheckedChanged);
        }

        protected override void FormModeChanged()
        {
            switch (CurrentFormMode)
            {
                case JBilling.Controls.FormModes.Nil:
                    base.MakeFormNil(this);
                    cmbCompanyName.Enabled = true;
                    break;
                case JBilling.Controls.FormModes.New:
                    base.MakeFormNewOrEdit(this, true);
                    txtCustomerCode.Enabled = false;
                    txtSupplierCode.Enabled = false;
                    cmbCompanyName.Enabled = false;
                    break;
                case JBilling.Controls.FormModes.Edit:
                    base.MakeFormNewOrEdit(this, false);
                    txtCustomerCode.Enabled = chkIsCustomer.Checked;
                    txtSupplierCode.Enabled = chkIsSupplier.Checked;
                    SetValuesToControls();
                    break;
            }
        }

        protected override void OnNew(object sender, EventArgs e)
        {
            base.OnNew(sender, e);

            CompanyDataSet.Company.Clear();
            DataRow dr = CompanyDataSet.Company.NewRow();
            CompanyDataSet.Company.Rows.Add(dr);
        }

        protected override void OnCancel(object sender, EventArgs e)
        {
            base.OnCancel(sender, e);
        }
        protected override bool UpdateData()
        {
            try
            {
                if (_cBusinessLogic.UpdateData(CompanyDataSet))
                {
                    DataChanged = false;
                    return true;
                }
            }
            catch (Exception ex)
            {
                JBillingMessageBox.ShowException(ex);
            }
            return false;
        }
        #endregion

        #region General Purpose methods
        private void BindControls()
        {
            cmbCompanyName.Table = CompanyDataSet.CompanyList;
            cmbCompanyName.DisplayMember = "CompanyName";
            cmbCompanyName.ColumnsToDisplay = new string[] { "CompanyName", "CustomerCode", "SupplierCode" };
        }

        private void SetValuesToControls()
        {
            chkIsSupplier.Checked = CompanyDataSet.Company[0].IsIsSupplierNull() ? false : CompanyDataSet.Company[0].IsSupplier;
            chkIsCustomer.Checked = CompanyDataSet.Company[0].IsIsCustomerNull() ? false : CompanyDataSet.Company[0].IsCustomer;
            txtTaxRegNo.Text = CompanyDataSet.Company[0].IsTaxRegistrationNoNull() ? string.Empty : CompanyDataSet.Company[0].TaxRegistrationNo;
            txtSupplierCode.Text = CompanyDataSet.Company[0].IsSupplierCodeNull() ? string.Empty : CompanyDataSet.Company[0].SupplierCode;
            txtCustomerCode.Text = CompanyDataSet.Company[0].IsCustomerCodeNull() ? string.Empty : CompanyDataSet.Company[0].CustomerCode;
            txtDeliveryAddress.Text = CompanyDataSet.Company[0].IsDeliveryAddressNull() ? string.Empty : CompanyDataSet.Company[0].DeliveryAddress;
            txtComanyName.Text = CompanyDataSet.Company[0].IsCompanyNameNull() ? string.Empty : CompanyDataSet.Company[0].CompanyName;
            txtCompanyAddress.Text = CompanyDataSet.Company[0].IsCompanyAddressNull() ? string.Empty : CompanyDataSet.Company[0].CompanyAddress;
            txtCompanyWebsite.Text = CompanyDataSet.Company[0].IsCompanyWebsiteNull() ? string.Empty : CompanyDataSet.Company[0].CompanyWebsite;
            txtContactName.Text = CompanyDataSet.Company[0].IsContactNameNull() ? string.Empty : CompanyDataSet.Company[0].ContactName;
            txtContactEmail.Text = CompanyDataSet.Company[0].IsContactEmailNull() ? string.Empty : CompanyDataSet.Company[0].ContactEmail;
        }
        #endregion

        #region Event Handlers

        void cmbCompanyName_AfterSelectEvent(object sender, DataRow selectedRow)
        {
            if (selectedRow != null && selectedRow["CompanyID"] != DBNull.Value)
            {
                CompanyDataSet.Company.Clear();
                _cBusinessLogic.GetCompanyData(CompanyDataSet, Convert.ToInt32(selectedRow["CompanyID"].ToString()));
                CurrentFormMode = JBilling.Controls.FormModes.Edit;
            }
        }

        void chkIsSupplier_CheckedChanged(object sender, EventArgs e)
        {
            txtSupplierCode.Enabled = chkIsSupplier.Checked;
            CompanyDataSet.Company[0].IsSupplier = chkIsSupplier.Checked;
            DataChanged = true;
        }

        void chkIsCustomer_CheckedChanged(object sender, EventArgs e)
        {
            txtCustomerCode.Enabled = chkIsCustomer.Checked;
            CompanyDataSet.Company[0].IsCustomer = chkIsCustomer.Checked;
            DataChanged = true;
        }

        void txtTaxRegNo_Leave(object sender, EventArgs e)
        {
            CompanyDataSet.Company[0].TaxRegistrationNo = txtTaxRegNo.Text;
            DataChanged = true;
        }

        void txtSupplierCode_Leave(object sender, EventArgs e)
        {
            CompanyDataSet.Company[0].SupplierCode = txtSupplierCode.Text;
            DataChanged = true;
        }

        void txtDeliveryAddress_Leave(object sender, EventArgs e)
        {
            CompanyDataSet.Company[0].DeliveryAddress = txtDeliveryAddress.Text;
            DataChanged = true;
        }

        void txtCustomerCode_Leave(object sender, EventArgs e)
        {
            CompanyDataSet.Company[0].CustomerCode = txtCustomerCode.Text;
            DataChanged = true;
        }

        void txtContactName_Leave(object sender, EventArgs e)
        {
            CompanyDataSet.Company[0].ContactName = txtContactName.Text;
            DataChanged = true;
        }

        void txtContactEmail_Leave(object sender, EventArgs e)
        {
            CompanyDataSet.Company[0].ContactEmail = txtContactEmail.Text;
            DataChanged = true;
        }

        void txtCompanyWebsite_Leave(object sender, EventArgs e)
        {
            CompanyDataSet.Company[0].CompanyWebsite = txtCompanyWebsite.Text;
            DataChanged = true;
        }

        void txtCompanyAddress_Leave(object sender, EventArgs e)
        {
            CompanyDataSet.Company[0].CompanyAddress = txtCompanyAddress.Text;
            DataChanged = true;
        }

        void txtComanyName_Leave(object sender, EventArgs e)
        {
            CompanyDataSet.Company[0].CompanyName = txtComanyName.Text;
            DataChanged = true;
        }

        #endregion

    }
}
