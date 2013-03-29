using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;

namespace JBilling.Controls
{
    public partial class JBillingForm : Form
    {
        public JBillingForm()
        {
            InitializeComponent();
        }

        #region Variable
        private bool _dataChanged = false;
        #endregion

        #region Properties

        /// <summary>
        /// Gets or sets data set associated with the form.
        /// </summary>
        protected virtual DataSet MainDataSet
        {
            get;
            set;
        }

        /// <summary>
        /// Provided to manually set the whether any change has occured on form.
        /// </summary>
        protected virtual bool DataChanged
        {
            get
            {
                return _dataChanged;
            }
            set
            {
                btnSave.Enabled = value;
                btnCancel.Enabled = value;
                btnSaveClose.Enabled = value;
                _dataChanged = value;
            }
        }

        /// <summary>
        /// Gets whether form has any changes.
        /// </summary>
        protected bool FormHasChanged
        {
            get
            {
                return DataChanged || MainDataSet.HasChanges();
            }
        }

        protected virtual BindingManagerBase JBindingManager
        {
            get
            {
                return null;
            }
        }
        #endregion

        #region Virtual methods
        protected virtual void InitializeForm()
        {
            AttachEvents();
            btnSave.Enabled = false;
            btnCancel.Enabled = false;
            btnSaveClose.Enabled = false;
        }

        protected virtual void AttachEvents()
        {
            btnSave.Click += new EventHandler(btnSave_Click);
            btnCancel.Click += new EventHandler(btnCancel_Click);
            btnSaveClose.Click += new EventHandler(btnSaveClose_Click);
        }

        protected virtual void DetachEvents()
        {
            btnSave.Click -= new EventHandler(btnSave_Click);
            btnCancel.Click -= new EventHandler(btnCancel_Click);
            btnSaveClose.Click -= new EventHandler(btnSaveClose_Click);
        }

        protected virtual void OnSaveClose(object sender, EventArgs e)
        {
            
        }

        protected virtual void OnCancel(object sender, EventArgs e)
        {
            try
            {
                EndEdit(MainDataSet);
                if (FormHasChanged)
                {
                    MainDataSet.RejectChanges();
                    if(JBindingManager != null)
                        ((CurrencyManager)JBindingManager).EndCurrentEdit();
                    DataChanged = false;
                }
            }
            catch (Exception ex)
            {
                JBillingMessageBox.ShowException(ex);
            }
        }

        protected virtual void OnSave(object sender, EventArgs e)
        {
            try
            {
                if (FormHasChanged)
                {
                    if (UpdateData())
                    {
                        MainDataSet.AcceptChanges();
                        DataChanged = false;
                    }
                }
            }
            catch (Exception ex)
            {
                JBillingMessageBox.ShowException(ex);
            }
        }

        protected virtual bool UpdateData()
        {
            return true;
        }
        #endregion

        #region Event Handlers

        void btnSaveClose_Click(object sender, EventArgs e)
        {
            OnSaveClose(sender, e);
        }

        void btnCancel_Click(object sender, EventArgs e)
        {
            OnCancel(sender, e);
        }

        void btnSave_Click(object sender, EventArgs e)
        {
            OnSave(sender, e);
        }
        
        #endregion
    }
}
