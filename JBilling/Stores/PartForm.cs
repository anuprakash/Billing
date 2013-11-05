using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using JBilling.BusinessLogic.Stores;
using JBilling.Controls;

namespace JBilling.Stores
{
    public partial class PartForm : JBilling.Controls.JBillingForm
    {
        public PartForm()
        {
            InitializeComponent();
            InitializeForm();
        }

        #region Properties

        protected JBilling.DataSets.Stores.PartDataSet PartDataSet
        {
            get
            {
                return (JBilling.DataSets.Stores.PartDataSet)base.MainDataSet;
            }
            set
            {
                base.MainDataSet = value;
            }
        }
        #endregion

        #region Variables
        PartBusinessLogic _pBusinessLogic = new PartBusinessLogic();
        #endregion

        #region Overriden Methods
        protected override void InitializeForm()
        {
            base.InitializeForm();

            PartDataSet = new DataSets.Stores.PartDataSet();

            _pBusinessLogic.GetStaticData(PartDataSet);

            BindControls();

            CurrentFormMode = JBilling.Controls.FormModes.Nil;
        }

        protected override void AttachEvents()
        {
            base.AttachEvents();
            cmbPart.AfterSelectEvent += new JBilling.Controls.AfterSelectEventHandler(cmbPart_AfterSelectEvent);
            txtPartNumber.Leave += new EventHandler(txtPartNumber_Leave);
            txtPartDesc.Leave += new EventHandler(txtPartDesc_Leave);
            txtPartPrice.Leave += new EventHandler(txtPartPrice_Leave);
        }

        protected override void DetachEvents()
        {
            base.DetachEvents();
            cmbPart.AfterSelectEvent -= new JBilling.Controls.AfterSelectEventHandler(cmbPart_AfterSelectEvent);
            txtPartNumber.Leave -= new EventHandler(txtPartNumber_Leave);
            txtPartDesc.Leave -= new EventHandler(txtPartDesc_Leave);
            txtPartPrice.Leave -= new EventHandler(txtPartPrice_Leave);
        }

        protected override void FormModeChanged()
        {
            switch (CurrentFormMode)
            {
                case JBilling.Controls.FormModes.Nil:
                    base.MakeFormNil(this);
                    cmbPart.Enabled = true;
                    break;
                case JBilling.Controls.FormModes.New:
                    base.MakeFormNewOrEdit(this, true);
                    cmbPart.Enabled = false;
                    break;
                case JBilling.Controls.FormModes.Edit:
                    base.MakeFormNewOrEdit(this, false);
                    cmbPart.Enabled = true;
                    SetValuesToControls();
                    txtPartNumber.Enabled = false;
                    break;
            }
        }

        protected override void OnNew(object sender, EventArgs e)
        {
            base.OnNew(sender, e);

            PartDataSet.Parts.Clear();
            DataRow dr = PartDataSet.Parts.NewRow();
            PartDataSet.Parts.Rows.Add(dr);
        }

        protected override bool UpdateData()
        {
            try
            {
                if (_pBusinessLogic.UpdateData(PartDataSet))
                {
                    DataChanged = false;
                    CurrentFormMode = JBilling.Controls.FormModes.Edit;
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
        private void SetValuesToControls()
        {
            txtPartNumber.Text = PartDataSet.Parts[0].PartNumber;
            txtPartDesc.Text = PartDataSet.Parts[0].PartDescription;
            txtPartPrice.Text = PartDataSet.Parts[0].PartPrice.ToString();
        }

        private void BindControls()
        {
            cmbPart.Table = PartDataSet.PartList;
            cmbPart.DisplayMember = "PartNumber";
            cmbPart.ColumnsToDisplay = new string[] { "PartNumber", "PartDescription"}; 
        }

        #endregion

        #region Event Handlers

        void txtPartDesc_Leave(object sender, EventArgs e)
        {
            PartDataSet.Parts[0].PartDescription = txtPartDesc.Text;
            DataChanged = true;
        }

        void txtPartNumber_Leave(object sender, EventArgs e)
        {
            PartDataSet.Parts[0].PartNumber = txtPartNumber.Text;
            DataChanged = true;
        }

        void txtPartPrice_Leave(object sender, EventArgs e)
        {
            try
            {
                PartDataSet.Parts[0].PartPrice = Convert.ToDecimal(txtPartPrice.Text);
                DataChanged = true;
            }
            catch (FormatException)
            {
                JBillingMessageBox.ShowException("Price must be a numeric value.");
                txtPartPrice.Text = PartDataSet.Parts[0].PartPrice.ToString();
            }
        }

        void cmbPart_AfterSelectEvent(object sender, DataRow selectedRow)
        {
            if (selectedRow != null && selectedRow["PartID"] != DBNull.Value)
            {
                PartDataSet.Parts.Clear();

                _pBusinessLogic.GetPartData(PartDataSet, Convert.ToInt32(selectedRow["PartID"].ToString()));

                CurrentFormMode = JBilling.Controls.FormModes.Edit;
            }
        }

        #endregion
    }
}
