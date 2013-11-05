using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using System.Data;
using System.Xml;
using System.ComponentModel;

namespace JBilling.Controls
{
    public class JBillingDataGridView : DataGrid
    {
        public string TableName
        {
            get;
            set;
        }

        public DataSet MainDataSet
        {
            get;
            set;
        }

        public JBillingDataGridView()
        {
            AddContextMenu();
        }

        public BindingManagerBase BindingManager
        {
            get
            {
                return this.BindingContext[MainDataSet, TableName];
            }
        }

        private void AddContextMenu()
        {
            MenuItem item = null;

            base.ContextMenu = new ContextMenu();

            item = new MenuItem("New");
            base.ContextMenu.MenuItems.Add(item);

            item = new MenuItem("Delete");
            base.ContextMenu.MenuItems.Add(item);

            base.ContextMenu.MenuItems[0].Click += new EventHandler(JBillingDataGridView_Click);
            base.ContextMenu.MenuItems[1].Click += new EventHandler(JBillingDataGridView_Click);
        }

        void JBillingDataGridView_Click(object sender, EventArgs e)
        {
            switch (((MenuItem)sender).Index)
            {
                case 0: // New
                    DataRow row = MainDataSet.Tables[TableName].NewRow();
                    MainDataSet.Tables[TableName].Rows.Add(row);
                    break;
                case 1: // Delete
                    if (MainDataSet.Tables[TableName].Rows.Count > 0)
                    {
                        //((DataRowView)BindingManager.Current).EndEdit();
                        //((DataRowView)BindingManager.Current).Delete();
                        MainDataSet.Tables[TableName].Rows[CurrentRowIndex].Delete();
                        MainDataSet.Tables[TableName].Rows[CurrentRowIndex].EndEdit();
                    }
                    break;
            }
        }

        public void Initialize()
        {
            if (string.IsNullOrEmpty(TableName))
                throw new ArgumentNullException("Table");

            XmlDocument xDoc = new XmlDocument();
            xDoc.Load("DataGridConfig.xml");

            XmlNode xNode = xDoc.SelectSingleNode("descendant::DataGrid[@name = '" + this.Name + "']");

            XmlNodeList xNodeChildren = xNode.ChildNodes;

            this.DataSource = ((DataView)MainDataSet.Tables[TableName].DefaultView);
            
            DataGridTableStyle tbStyle = new DataGridTableStyle();
            tbStyle.AllowSorting = true;

            base.TableStyles.Add(tbStyle);
            base.TableStyles[0].DataGrid = this;

            foreach (XmlNode node in xNodeChildren)
            {
                DataGridTextBoxColumn txtColumn = new DataGridTextBoxColumn();

                txtColumn.MappingName = node.Attributes["mapto"].Value;

                txtColumn.HeaderText = node.Attributes["text"].Value;

                if (node.Attributes["readonly"] != null)
                    txtColumn.ReadOnly = Convert.ToBoolean(node.Attributes["readonly"].Value);

                if (node.Attributes["width"] != null)
                    txtColumn.Width = Convert.ToInt32(node.Attributes["width"].Value);
                else
                    txtColumn.Width = 150;

                txtColumn.NullText = string.Empty;

                
                this.Controls.Add(txtColumn.TextBox);
                base.TableStyles[0].GridColumnStyles.Add(txtColumn);
            }

            base.TableStyles[0].MappingName = TableName;
            base.TableStyles[0].GridLineStyle = DataGridLineStyle.Solid;
        }
    }
}
