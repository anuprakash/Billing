using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using JBilling.DataAccess;
using System.Data;

namespace JBilling.BusinessLogic.Stores
{
    public class PartBusinessLogic
    {
        public void GetStaticData(DataSet ds)
        {
            using (IDbConnection connection = DBAccess.OpenConnection())
            {
                DBAccess.FillDataset(connection, ds, "PartList", "Stores.PartListSelect");
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
                    insertCommand = DBAccess.GetCommand(connection, "Stores.PartInsert", "PartNumber", "PartDescription", "PartPrice");

                    updateCommand = DBAccess.GetCommand(connection, "Stores.PartUpdate", "PartID", "PartNumber", "PartDescription", "PartPrice");

                    DBAccess.UpdateDataset(ds, insertCommand, updateCommand, null, "Parts");

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

        public void GetPartData(DataSet ds, int partID)
        {
            using (IDbConnection connection = DBAccess.OpenConnection())
            {
                DBAccess.FillDataset(connection, ds, "Parts", "Stores.PartSelect", partID);
            }
        }
    }
}
