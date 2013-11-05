using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using System.ComponentModel;
using System.Data;

namespace JBilling.Controls
{
    public class JBillingTextBox : TextBox
    {
        private DataSet DataSource
        {
            get;
            set;
        }

        private string TableName
        {
            set;
            get;
        }

        private int Index
        {
            get;
            set;
        }

        private string ColumnName
        {
            get;
            set;
        }

        public void SetDataBindings(DataSet dataSource, string tableName, string columnName)
        {
            SetDataBindings(dataSource, tableName, columnName, 0);
        }

        public void SetDataBindings(DataSet dataSource, string tableName, string columnName, int index)
        {
            DataSource = dataSource;
            TableName = tableName;
            ColumnName = columnName;
            Index = index;

            DataSource.Tables[TableName].RowChanged += new DataRowChangeEventHandler(JBillingTextBox_RowChanged);
        }

        void JBillingTextBox_RowChanged(object sender, DataRowChangeEventArgs e)
        {
            Text = DataSource.Tables[TableName].Rows[Index][ColumnName].ToString();
        }

        protected override void OnLeave(EventArgs e)
        {
            DataSource.Tables[TableName].RowChanged -= new DataRowChangeEventHandler(JBillingTextBox_RowChanged);
            try
            {
                DataSource.Tables[TableName].Rows[Index][ColumnName] = Text;
                base.OnLeave(e);
            }
            catch(Exception ex)
            {
                JBillingMessageBox.ShowException(ex);
            }
            finally
            {
                DataSource.Tables[TableName].RowChanged += new DataRowChangeEventHandler(JBillingTextBox_RowChanged);
            }
        }
    }
}
