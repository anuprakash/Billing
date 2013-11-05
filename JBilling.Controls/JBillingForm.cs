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
        private FormModes formMode;
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
                btnNew.Enabled = !value;
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

        protected FormModes CurrentFormMode
        {
            get
            {
                return formMode;
            }
            set
            {
                formMode = value;
                FormModeChanged();
            }
        }

        #endregion

        #region Virtual methods

        protected virtual void FormModeChanged()
        {
            
        }

        protected virtual void InitializeForm()
        {
            AttachEvents();
            btnSave.Enabled = false;
            btnCancel.Enabled = false;
            btnSaveClose.Enabled = false;

            this.AutoSize = false;
        }

        protected virtual void AttachEvents()
        {
            btnNew.Click += new EventHandler(btnNew_Click);
            btnSave.Click += new EventHandler(btnSave_Click);
            btnCancel.Click += new EventHandler(btnCancel_Click);
            btnSaveClose.Click += new EventHandler(btnSaveClose_Click);
        }

        protected virtual void DetachEvents()
        {
            btnNew.Click -= new EventHandler(btnNew_Click);
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
                    if (JBindingManager != null)
                        ((CurrencyManager)JBindingManager).CancelCurrentEdit();
                    MainDataSet.RejectChanges();
                    DataChanged = false;
                    CurrentFormMode = FormModes.Edit;
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
                    EndEdit(MainDataSet);
                    if (UpdateData())
                    {
                        MainDataSet.AcceptChanges();
                        DataChanged = false;
                    }
                    CurrentFormMode = FormModes.Edit;
                }
            }
            catch (Exception ex)
            {
                JBillingMessageBox.ShowException(ex);
            }
        }

        protected virtual void OnNew(object sender, EventArgs e)
        {
            try
            {
                CurrentFormMode = FormModes.New;   
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

        protected void MakeFormNil(Control control)
        {
            foreach (Control c in control.Controls)
            {
                if (c is GroupBox)
                {
                    c.Enabled = false;
                    MakeFormNil(c);
                }
                if (c is TextBox)
                {
                    c.Text = string.Empty;
                    c.Enabled = false;
                }
            }
        }

        protected void MakeFormNewOrEdit(Control control, bool newPressed)
        {
            foreach (Control c in control.Controls)
            {
                if (c is GroupBox)
                {
                    c.Enabled = true;
                    MakeFormNewOrEdit(c, newPressed);
                }
                if (c is TextBox)
                {
                    if(newPressed)
                        c.Text = string.Empty;

                    c.Enabled = true;
                }
            }

            btnNew.Enabled = !newPressed;
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

        void btnNew_Click(object sender, EventArgs e)
        {
            OnNew(sender, e);
        }
        
        #endregion

        #region General purpoes methods
        /// <summary>
        /// Ends edit for each column for each table in data set.
        /// </summary>
        /// <param name="MainDataSet">Data Set whose end edit is to be called.</param>
        private void EndEdit(DataSet MainDataSet)
        {
            for (int i = 0; i < MainDataSet.Tables.Count; i++)
            {
                foreach (DataRow row in MainDataSet.Tables[i].Rows)
                {
                    row.EndEdit();
                }
                MainDataSet.Tables[i].EndInit();
            }
        }

        #endregion
    }

    public enum FormModes
    {
        New = 0,
        Edit = 1,
        ReadOnly = 2,
        Nil = 3
    }
}
