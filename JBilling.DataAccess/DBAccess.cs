using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Data;
using System.Data.SqlClient;

namespace JBilling.DataAccess
{
    public class DBAccess
    {
        private static string GetConnectionString()
        {
            return @"Data Source=MIHIRJOSHI-HP\SQLEXPRESS; Initial Catalog=JBilling; Integrated Security=true"; //User ID=JUser; Password=jbilling@123";
        }

        /// <summary>
        /// Gets connection to database.
        /// </summary>
        /// <returns></returns>
        public static IDbConnection OpenConnection()
        {
            IDbConnection connection = new SqlConnection();
            connection.ConnectionString = GetConnectionString();

            try
            {
                connection.Open();

                return connection;
            }
            catch (Exception)
            {
                throw;
            }
        }

        /// <summary>
        /// Closes an open connection.
        /// </summary>
        /// <param name="connection"></param>
        public static void CloseConnection(IDbConnection connection)
        {
            if (connection != null && connection.State == ConnectionState.Open)
            {
                connection.Close();
                connection.Dispose();
                connection = null;
            }
        }

        /// <summary>
        /// Fills dataset with row collection obtained from stored procedure.
        /// </summary>
        /// <param name="connection">An open connection to database.</param>
        /// <param name="dataSet">Data set reference.</param>
        /// <param name="strTableName">Table name in which the result is to be filled.</param>
        /// <param name="strProcName">Procedure which will be executed.</param>
        /// <param name="parameters">Parameters passed to stored procedure.</param>
        public static void FillDataset(IDbConnection connection, DataSet dataSet, string strTableName, string strProcName, params object[] parameters)
        {
            if (connection == null || dataSet == null || strProcName == null || strTableName == null)
                return;

            if (dataSet.Tables[strTableName] != null)
                dataSet.Tables[strTableName].Clear();

            using(IDbCommand command = new SqlCommand())
            {
                SqlDataAdapter adapter = new SqlDataAdapter();

                command.Connection = connection;
                command.CommandText = strProcName;
                command.CommandType = CommandType.StoredProcedure;

                AttachParameters(command, parameters);

                adapter.SelectCommand = (SqlCommand)command;

                adapter.Fill(dataSet, strTableName);
            }
        }

        /// <summary>
        /// Attaches parameters to Stored procedure and populates Parameters collection.
        /// </summary>
        /// <param name="command">SqlCommand which will be used to populate parameters.</param>
        /// <param name="strProcName">Stored procedure name for which paramters are to be derived.</param>
        /// <param name="parameters">List of parameters passed to stored procedure.</param>
        private static void AttachParameters(IDbCommand command,  params object[] parameters)
        {
            SqlCommandBuilder.DeriveParameters((SqlCommand)command);

            for (int i = 0; i < parameters.Length; i++)
            {
                ((SqlCommand)command).Parameters[i + 1].Value = parameters[i];
            }
        }

        /// Attaches parameters to Stored procedure and populates Parameters collection.
        /// </summary>
        /// <param name="command">SqlCommand which will be used to populate parameters.</param>
        /// <param name="strProcName">Stored procedure name for which paramters are to be derived.</param>
        /// <param name="parameters">List of parameters passed to stored procedure.</param>
        private static void AttachParameters(IDbCommand command, params string[] parameters)
        {
            SqlCommandBuilder.DeriveParameters((SqlCommand)command);

            IDataParameterCollection parameterCollection = command.Parameters;
            
            for (int i = 0; i < parameters.Length; i++)
            {
                ((IDataParameter)parameterCollection[i + 1]).SourceColumn = parameters[i];
            }
        }

        /// <summary>
        /// Calls the respective INSERT, UPDATE, or DELETE statements for each inserted, updated, 
        /// or deleted row in the System.Data.DataSet with the specified System.Data.DataTable name.
        /// </summary>
        /// <param name="dataSet">Dataset to be updated.</param>
        /// <param name="insertCommand">A valid insert command.</param>
        /// <param name="updateCommand">A valid update command.</param>
        /// <param name="deleteCommand">A valid delete command.</param>
        /// <param name="strTableName">Table name which is to be referred for changes.</param>
        /// <returns></returns>
        public static int UpdateDataset(DataSet dataSet, IDbCommand insertCommand, IDbCommand updateCommand, IDbCommand deleteCommand, string strTableName)
        {
            SqlDataAdapter adapter = new SqlDataAdapter();

            if (insertCommand != null) adapter.InsertCommand = (SqlCommand)insertCommand;
            if (updateCommand != null) adapter.UpdateCommand = (SqlCommand)updateCommand;
            if (deleteCommand != null) adapter.DeleteCommand = (SqlCommand)deleteCommand;
            
            return adapter.Update(dataSet, strTableName);
        }

        public static IDbCommand GetCommand(IDbConnection connection, string strProcName, params string[] parameters)
        {
            IDbCommand command = new SqlCommand();
            command.Connection = connection;
            command.CommandText = strProcName;
            command.CommandType = CommandType.StoredProcedure;

            AttachParameters(command, parameters);

            return command;
        }

        public static IDbCommand GetCommand(IDbConnection connection, IDbTransaction tran, string strProcName, params string[] parameters)
        {
            IDbCommand command = new SqlCommand();
            command.Connection = connection;
            command.CommandText = strProcName;
            command.CommandType = CommandType.StoredProcedure;
            command.Transaction = tran;

            AttachParameters(command, parameters);

            return command;
        }
    }
}
