using System;
using System.ComponentModel;
using System.Collections;
using System.Diagnostics;
using System.Data;
using System.Windows.Forms;
using System.Drawing;

namespace JBilling.Controls
{
    /// <summary>
    /// Summary description for MultiColumnComboBox.
    /// </summary>
    public delegate void AfterSelectEventHandler(object sender, DataRow selectedRow);
    public class MultiColumnComboBox : System.Windows.Forms.ComboBox
    {
        /// <summary>
        /// Required designer variable.
        /// </summary>
        private System.ComponentModel.Container components = null;
        private DataRow selectedRow = null;
        private string displayMember = "";
        private string displayValue = "";
        private DataTable dataTable = null;
        private DataRow[] dataRows = null;
        private string[] columnsToDisplay = null;
        public event AfterSelectEventHandler AfterSelectEvent;
        private Keys m_kcLastKey;
        private StringList m_slSuggestions = new StringList();

        public MultiColumnComboBox(System.ComponentModel.IContainer container)
        {
            /// <summary>
            /// Required for Windows.Forms Class Composition Designer support
            /// </summary>
            container.Add(this);
            InitializeComponent();

            //
            // TODO: Add any constructor code after InitializeComponent call
            //
        }

        public MultiColumnComboBox()
        {
            InitializeComponent();

            base.AutoCompleteSource = System.Windows.Forms.AutoCompleteSource.CustomSource;
            base.AutoCompleteMode = System.Windows.Forms.AutoCompleteMode.Suggest;
        }

        #region Component Designer generated code
        /// <summary>
        /// Required method for Designer support - do not modify
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            components = new System.ComponentModel.Container();
        }

        protected override void WndProc(ref  Message m)
        {
            
            base.WndProc(ref m);
        }
        #endregion

        protected override void OnKeyDown(KeyEventArgs e)
        {
            try
            {
                InitSuggestionList();
                base.OnKeyDown(e);
                m_kcLastKey = e.KeyCode;
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message + "\r\nIn ColumnComboBox.OnKeyDown(KeyEventArgs).");
            }
        }

        private void InitSuggestionList()
        {
            m_slSuggestions.Clear();
            foreach (DataRowView drv in Table.DefaultView)
            {
                string sTemp = drv[displayMember].ToString();
                m_slSuggestions.Add(sTemp);
            }
        }

        protected override void OnDropDown(System.EventArgs e)
        {
            Form parent = this.FindForm();
            if (this.dataTable != null || this.dataRows != null)
            {
                MultiColumnComboPopup popup = new MultiColumnComboPopup(this.dataTable, ref this.selectedRow, columnsToDisplay);
                popup.AfterRowSelectEvent += new AfterRowSelectEventHandler(MultiColumnComboBox_AfterSelectEvent);
                popup.Location = new Point(parent.Left + this.Left + 10, parent.Top + this.Bottom + this.Height + 52);
                popup.Show();
                if (popup.SelectedRow != null)
                {
                    try
                    {
                        this.selectedRow = popup.SelectedRow;
                        this.displayValue = popup.SelectedRow[this.displayMember].ToString();
                        this.Text = this.displayValue;
                    }
                    catch (Exception e2)
                    {
                        MessageBox.Show(e2.Message, "Error");
                    }
                }
                //if (AfterSelectEvent != null)
                //    AfterSelectEvent(this, selectedRow);
                popup.BringToFront();
            }
            //base.OnDropDown(e);
            base.DroppedDown = false;
        }

        private void MultiColumnComboBox_AfterSelectEvent(object sender, DataRow drow)
        {
            try
            {
                if (drow != null)
                {
                    this.Text = drow[displayMember].ToString();

                    if (AfterSelectEvent != null)
                        AfterSelectEvent(this, drow);
                }
            }
            catch (Exception exp)
            {
                MessageBox.Show(this, exp.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        public DataRow SelectedRow
        {
            get
            {
                return selectedRow;
            }
        }

        public object SelectedKey
        {
            set
            {
                if (value == DBNull.Value)
                {
                    this.SelectedItem = value;
                    this.Text = string.Empty;
                    this.SelectedIndex = -1;
                    return;
                }

                DataRow[] rows = Table.Select(ValueMember + "= '" + value + "'");
                if (rows.Length > 0)
                {
                    MultiColumnComboBox_AfterSelectEvent(this, rows[0]);
                }
            }
        }

        public string DisplayValue
        {
            get
            {
                return displayValue;
            }
        }

        public string ValueMember
        {
            set;
            get;
        }

        public new string DisplayMember
        {
            set
            {
                displayMember = value;

                if (Table == null)
                {
                    JBillingMessageBox.ShowException("Table not set. Cannot build AutoCompleteSource");
                    return;
                }

                SetAutoCompleteSource();
            }
        }

        private void SetAutoCompleteSource()
        {
            AutoCompleteStringCollection strings = new AutoCompleteStringCollection();
            foreach (DataRow row in Table.Rows)
            {
                strings.Add(row[displayMember].ToString());
            }

            base.AutoCompleteCustomSource = strings;
        }

        public DataTable Table
        {
            get
            {
                return dataTable;
            }
            set
            {
                dataTable = value;
                if (dataTable == null)
                    return;
                selectedRow = dataTable.NewRow();
            }
        }

        public DataRow[] Rows
        {
            set
            {
                dataRows = value;
            }
        }

        public string[] ColumnsToDisplay
        {
            set
            {
                columnsToDisplay = value;
            }
        }
    }
}
