using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Data;
using JBilling.DataAccess;

namespace JBilling.BusinessLogic.Sales
{
    public class SalesOrderBusinessLogic
    {
        public void GetStaticData(DataSet ds)
        {
            using (IDbConnection connection = DBAccess.OpenConnection())
            {
                DBAccess.FillDataset(connection, ds, "SalesOrdersList", "Sales.SalesOrderListSelect");
                DBAccess.FillDataset(connection, ds, "CompanyList", "Commercial.CompanyListSelect");
                DBAccess.FillDataset(connection, ds, "PartList", "Stores.PartListSelect");
            }
        }

        public void GetSalesOrderData(DataSet ds, string strSalesOrderNumber)
        {
            using (IDbConnection connection = DBAccess.OpenConnection())
            {
                DBAccess.FillDataset(connection, ds, "SalesOrders", "Sales.SalesOrderSelect", strSalesOrderNumber);
                DBAccess.FillDataset(connection, ds, "SalesOrderDetails", "Sales.SalesOrderDetailsSelect", strSalesOrderNumber);
            }
        }

        public bool UpdateData(DataSet ds)
        {
            using (IDbConnection connection = DBAccess.OpenConnection())
            {
                IDbCommand insertCommand = null;
                IDbCommand updateCommand = null;
                IDbCommand deleteCommand = null;
                IDbTransaction tran = null;

                try
                {
                    tran = connection.BeginTransaction();

                    insertCommand = DBAccess.GetCommand(connection, tran, "Sales.SalesOrderInsert", "SalesOrderNumber", "CompanyID", "Tax");
                    updateCommand = DBAccess.GetCommand(connection, tran, "Sales.SalesOrderUpdate", "SalesOrderNumber", "Tax");

                    DBAccess.UpdateDataset(ds, insertCommand, updateCommand, null, "SalesOrders");

                    insertCommand = DBAccess.GetCommand(connection, tran, "Sales.SalesOrderDetailsInsert", "SalesOrderNumber", "LineNumber", "DeliveryDate", "PartNumber", "Quantity", "PartPrice", "LineTotal");
                    updateCommand = DBAccess.GetCommand(connection, tran, "Sales.SalesOrderDetailsUpdate", "SalesOrderNumber", "LineNumber", "DeliveryDate", "PartNumber", "Quantity", "PartPrice", "LineTotal");
                    deleteCommand = DBAccess.GetCommand(connection, tran, "Sales.SalesOrderDetailsDelete", "SalesOrderNumber", "LineNumber");

                    DBAccess.UpdateDataset(ds, insertCommand, updateCommand, deleteCommand, "SalesOrderDetails");

                    tran.Commit();

                    return true;
                }
                catch
                {
                    if (tran != null)
                        tran.Rollback();
                    throw;
                }
                finally
                {
                    #region Clean off
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

                    if (deleteCommand != null)
                    {
                        deleteCommand.Dispose();
                        deleteCommand = null;
                    }

                    if (tran != null)
                    {
                        tran.Dispose();
                        tran = null;
                    }
                    #endregion
                }
            }
        }
    }
}
