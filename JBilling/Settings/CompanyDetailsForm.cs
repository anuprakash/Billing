using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using JBilling.Controls;

namespace JBilling.Settings
{
    public partial class CompanyDetailsForm : JBilling.Controls.JBillingForm
    {
        public CompanyDetailsForm()
        {
            InitializeComponent();

            InitializeForm();
        }

        #region Properties
        /// <summary>
        /// Company Details data set.
        /// </summary>
        protected JBilling.DataSets.Settings.CompanyDetailsDataSet CompanyDetailsDataSet
        {
            get
            {
                return (JBilling.DataSets.Settings.CompanyDetailsDataSet)base.MainDataSet;
            }
            set
            {
                base.MainDataSet = value;
            }
        }

        /// <summary>
        /// Provides binding to the controls bearing data from CompanyDetails data table.
        /// </summary>
        protected override BindingManagerBase JBindingManager
        {
            get
            {
                return this.BindingContext[CompanyDetailsDataSet, "CompanyDetails"];
            }
        }
        #endregion

        #region Variables
        private JBilling.BusinessLogic.Settings.CompanyDetailsBusinessLogic _businessLogic = new BusinessLogic.Settings.CompanyDetailsBusinessLogic();
        #endregion

        #region Overriden Methods
        protected override void InitializeForm()
        {
            base.InitializeForm();

            CompanyDetailsDataSet = new DataSets.Settings.CompanyDetailsDataSet();
            btnNew.Visible = false;

            BindControls();

            _businessLogic.GetCompanyData(CompanyDetailsDataSet);

            SetValuesToControls();
        }

        protected override bool UpdateData()
        {
            try
            {
                if (_businessLogic.Update(CompanyDetailsDataSet))
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

        protected override void AttachEvents()
        {
            base.AttachEvents();
            txtCompanyName.Leave += new EventHandler(TextBoxLeft);
            txtCompanyDesc.Leave += new EventHandler(TextBoxLeft);
            txtCompanyAddress.Leave += new EventHandler(TextBoxLeft);
            txtContactEmail.Leave += new EventHandler(TextBoxLeft);
            txtContactPerson.Leave += new EventHandler(TextBoxLeft);
            txtContactNo.Leave += new EventHandler(ChangeData);
            txtTaxRegNo.Leave += new EventHandler(ChangeData);
        }

        void ChangeData(object sender, EventArgs e)
        {
            DataChanged = true;
        }

        protected override void DetachEvents()
        {
            base.DetachEvents();
            txtCompanyName.Leave -= new EventHandler(TextBoxLeft);
            txtCompanyDesc.Leave -= new EventHandler(TextBoxLeft);
            txtCompanyAddress.Leave -= new EventHandler(TextBoxLeft);
            txtContactEmail.Leave -= new EventHandler(TextBoxLeft);
            txtContactPerson.Leave -= new EventHandler(TextBoxLeft);
            txtContactNo.Leave -= new EventHandler(ChangeData);
            txtTaxRegNo.Leave -= new EventHandler(ChangeData);
        }

        protected override void OnCancel(object sender, EventArgs e)
        {
            base.OnCancel(sender, e);

            txtCompanyName.Text = CompanyDetailsDataSet.CompanyDetails[0].CompanyName;
            txtCompanyDesc.Text = CompanyDetailsDataSet.CompanyDetails[0].CompanyDesc;
            txtCompanyAddress.Text = CompanyDetailsDataSet.CompanyDetails[0].CompanyAddress;
            txtContactEmail.Text = CompanyDetailsDataSet.CompanyDetails[0].CompanyEmail;
            txtContactPerson.Text = CompanyDetailsDataSet.CompanyDetails[0].ContactName;
            txtCompanyWebsite.Text = CompanyDetailsDataSet.CompanyDetails[0].CompanyWebsite;
        }
        #endregion

        #region General Purpose Methods

        /// <summary>
        /// Adds data bindings to the controls.
        /// </summary>
        private void BindControls()
        {
            txtCompanyName.DataBindings.Add("Text", CompanyDetailsDataSet.CompanyDetails, CompanyDetailsDataSet.CompanyDetails.CompanyNameColumn.ToString());
            txtCompanyAddress.DataBindings.Add("Text", CompanyDetailsDataSet, "CompanyDetails.CompanyAddress");
            pbCompanyImage.DataBindings.Add("Image", CompanyDetailsDataSet, "CompanyDetails.CompanyLogo");
            txtCompanyDesc.DataBindings.Add("Text", CompanyDetailsDataSet, "CompanyDetails.CompanyDesc");
            txtTaxRegNo.SetDataBindings(CompanyDetailsDataSet, "CompanyDetails", "TaxRegistrationNo");
            txtContactNo.SetDataBindings(CompanyDetailsDataSet, "CompanyDetails", "ContactNo");
        }

        private void SetValuesToControls()
        {
            txtCompanyName.Text = CompanyDetailsDataSet.CompanyDetails[0].CompanyName;
            txtCompanyAddress.Text = CompanyDetailsDataSet.CompanyDetails[0].CompanyAddress;
            txtCompanyDesc.Text = CompanyDetailsDataSet.CompanyDetails[0].CompanyDesc;
            txtContactPerson.Text = CompanyDetailsDataSet.CompanyDetails[0].ContactName;
            txtContactEmail.Text = CompanyDetailsDataSet.CompanyDetails[0].CompanyEmail;
            txtCompanyWebsite.Text = CompanyDetailsDataSet.CompanyDetails[0].CompanyWebsite;
        }

        void TextBoxLeft(object sender, EventArgs e)
        {
            TextBox txtSender = (TextBox)sender;
            
            switch (txtSender.Name)
            {
                case "txtCompanyName":
                    if (CompanyDetailsDataSet.CompanyDetails[0].CompanyName == txtSender.Text)
                        return;

                    CompanyDetailsDataSet.CompanyDetails[0].CompanyName = txtSender.Text;
                    break;

                case "txtCompanyAddress":
                    if (CompanyDetailsDataSet.CompanyDetails[0].CompanyAddress == txtSender.Text)
                        return;

                    CompanyDetailsDataSet.CompanyDetails[0].CompanyAddress = txtSender.Text;
                    break;

                case "txtCompanyDesc":
                    if (CompanyDetailsDataSet.CompanyDetails[0].CompanyDesc == txtSender.Text)
                        return;

                    CompanyDetailsDataSet.CompanyDetails[0].CompanyDesc = txtSender.Text;
                    break;

                case "txtContactPerson":
                    if (CompanyDetailsDataSet.CompanyDetails[0].ContactName == txtSender.Text)
                        return;

                    CompanyDetailsDataSet.CompanyDetails[0].ContactName = txtSender.Text;
                    break;

                case "txtContactEmail":
                    if (CompanyDetailsDataSet.CompanyDetails[0].CompanyEmail == txtSender.Text)
                        return;

                    CompanyDetailsDataSet.CompanyDetails[0].CompanyEmail = txtSender.Text;
                    break;
                case "txtCompanyWebsite":
                    if (CompanyDetailsDataSet.CompanyDetails[0].CompanyWebsite == txtSender.Text)
                        return;

                    CompanyDetailsDataSet.CompanyDetails[0].CompanyWebsite = txtSender.Text;
                    break;
            }

            DataChanged = true;
        }

        #endregion
    }
}
