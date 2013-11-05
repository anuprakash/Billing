using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Data;

using JBilling.DataAccess;

namespace JBilling.BusinessLogic.Commercial
{
    public class CompanyBusinessLogic
    {
        public void GetStaticData(DataSet ds)
        {
            using (IDbConnection connection = DBAccess.OpenConnection())
            {
                DBAccess.FillDataset(connection, ds, "CompanyList", "Commercial.CompanyListSelect");
            }
        }

        public bool UpdateData(DataSet ds)
        {
            using (IDbConnection connection = DBAccess.OpenConnection())
            {
                IDbCommand insertCommand = null;
                IDbCommand updateCommand = null;

                try
                {
                    insertCommand = DBAccess.GetCommand(connection, "Commercial.CompanyInsert", "CustomerCode", "SupplierCode",
                        "CompanyName", "TaxRegistrationNo", "CompanyAddress", "DeliveryAddress", "IsCustomer", "IsSupplier", "ContactName",
                        "ContactEmail", "CompanyWebsite");

                    updateCommand = DBAccess.GetCommand(connection, "Commercial.CompanyUpdate", "CompanyID", "CustomerCode", "SupplierCode",
                        "CompanyName", "TaxRegistrationNo", "CompanyAddress", "DeliveryAddress", "IsCustomer", "IsSupplier", "ContactName",
                        "ContactEmail", "CompanyWebsite");

                    DBAccess.UpdateDataset(ds, insertCommand, updateCommand, null, "Company");

                    return true;
                }
                catch
                {
                    throw;
                }
                finally
                {
                    #region Clean Off
                    if (insertCommand != null)
                    {
                        insertCommand.Dispose();
                        insertCommand = null;
                    }

                    if (updateCommand != null)
                    {
                        updateCommand.Dispose();
                        updateCommand = null;
                    }
                    #endregion
                }
            }
        }

        public void GetCompanyData(DataSet ds, int companyID)
        {
            using (IDbConnection connection = DBAccess.OpenConnection())
            {
                DBAccess.FillDataset(connection, ds, "Company", "Commercial.CompanySelect", companyID);
            }
        }
    }
}
