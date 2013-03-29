using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Data;
using JBilling.DataAccess;
using System.Data.SqlClient;

namespace JBilling.BusinessLogic.Settings
{
    public class CompanyDetailsBusinessLogic
    {
        public bool Update(DataSet ds)
        {
            try
            {
                using (IDbConnection connection = DBAccess.OpenConnection())
                {
                    using (IDbCommand updateCommand = DBAccess.GetCommand(connection, "Settings.CompanyDetailsUpdate", "CompanyName", "CompanyDesc", "CompanyAddress", "CompanyEmail", "ContactName", "CompanyLogo"))
                    {
                        DBAccess.UpdateDataset(ds, null, updateCommand, null, "CompanyDetails");
                    }
                }

                return true;
            }
            catch
            {
                return false;
            }
        }

        public void GetCompanyData(DataSet ds)
        {
            using (IDbConnection connection = DBAccess.OpenConnection())
            {
                DBAccess.FillDataset(connection, ds, "CompanyDetails", "Settings.CompanyDetailsSelect");
            }
        }
    }
}
