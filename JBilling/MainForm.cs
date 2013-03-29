using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using System.Xml;

namespace JBilling
{
    public partial class MainForm : Form
    {
        public MainForm()
        {
            components = new Container();

            InitializeComponent();
            InitializeForm();
        }

        private void InitializeForm()
        {
            PrepareMenu();
        }

        /// <summary>
        /// Read XML and generate Menu.
        /// </summary>
        private void PrepareMenu()
        {
            MainMenu mainMenu = new MainMenu(components);
            this.Menu = mainMenu;

            XmlDocument xDoc = new XmlDocument();

            xDoc.Load("Menu.xml");

            XmlNodeList xnlList = xDoc.SelectNodes("/MenuItems/MenuItem");

            AddMenus(xnlList, mainMenu);
        }

        /// <summary>
        /// Add First level Menus.
        /// </summary>
        /// <param name="xnlList"></param>
        /// <param name="mainMenu"></param>
        private void AddMenus(XmlNodeList xnlList, MainMenu mainMenu)
        {
            foreach (XmlNode xNode in xnlList)
            {
                if (xNode.Attributes["type"] != null && xNode.Attributes["type"].Value.ToString().Equals("container"))
                {
                    MenuItem mnu = new MenuItem(xNode.Attributes["text"].Value);

                    this.Menu.MenuItems.Add(mnu);

                    AddChildMenus(xNode.ChildNodes, mnu);
                }
            }
        }

        /// <summary>
        /// Adds child menus.
        /// </summary>
        /// <param name="xnlChildNodeList"></param>
        /// <param name="mnuParent"></param>
        private void AddChildMenus(XmlNodeList xnlChildNodeList, MenuItem mnuParent)
        {
            foreach (XmlNode xNode in xnlChildNodeList)
            {
                MenuItem mnu = new MenuItem(xNode.Attributes["text"].Value);
                mnu.Tag = xNode.Attributes["formid"].Value;

                mnuParent.MenuItems.Add(mnu);

                if (xNode.Attributes["type"] != null && xNode.Attributes["type"].Value.ToString().Equals("container"))
                {
                    AddChildMenus(xNode.ChildNodes, mnu);
                }

                mnu.Click += new EventHandler(mnu_Click);
            }
        }

        void mnu_Click(object sender, EventArgs e)
        {
            MenuItem mnu = (MenuItem)sender;

            CreateForm(mnu.Tag.ToString());
        }

        private void CreateForm(string formID)
        {
            JBilling.Controls.JBillingForm baseForm = null;

            switch (formID)
            {
                case "PartForm":
                    baseForm = new JBilling.Stores.PartForm();
                    break;

                case "SalesOrderForm":
                    baseForm = new JBilling.Sales.SalesOrderForm();
                    break;

                case "SalesInvoiceForm":
                    baseForm = new JBilling.Accounts.SalesInvoiceForm();
                    break;

                case "CompanyForm":
                    baseForm = new JBilling.Commercial.CompanyForm();
                    break;
                
                case "CompanyDetailsForm":
                    baseForm = new JBilling.Settings.CompanyDetailsForm();
                    break;
            }

            if (baseForm != null)
            {
                baseForm.StartPosition = FormStartPosition.CenterScreen;
                baseForm.MdiParent = this;
                baseForm.Show();
            }
        }
    }
}
