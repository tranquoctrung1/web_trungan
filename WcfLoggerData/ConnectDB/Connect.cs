using System;
using System.Collections.Generic;
using System.Configuration;
using System.Data;
using System.Data.OleDb;
using System.Data.SqlClient;
using System.Linq;
using System.Security.Policy;
using System.Web;

namespace WcfLoggerData.ConnectDB
{
    public static class Connect
    {

        static string connectionString = ConfigurationManager.ConnectionStrings["db"].ConnectionString;
        static SqlConnection sqlConnection = new SqlConnection(connectionString);
        public static void ConnectToDataBase()
        {
            if (sqlConnection != null && sqlConnection.State == ConnectionState.Closed)
            {
                sqlConnection.Open();
            }
            else if(sqlConnection.State == ConnectionState.Connecting)
            {
                sqlConnection.Close();
                sqlConnection.Open();
            }
        }

        public static void DisconnectToDataBase()
        {
            if (sqlConnection != null && sqlConnection.State == ConnectionState.Open)
            {
                sqlConnection.Close();
            }

        }

        public static SqlDataReader Select(string sqlQuery)
        {
            SqlCommand command = new SqlCommand(sqlQuery, sqlConnection);
            SqlDataReader reader = command.ExecuteReader();
            command.CommandTimeout = 0;
            command.Dispose();

            return reader;

        }

        public static SqlCommand ExcuteStoreProceduce(string sqlquery)
        {

            SqlCommand sqlCommand = new SqlCommand(sqlquery, sqlConnection);
            sqlCommand.CommandTimeout = 0;
            sqlCommand.CommandType = System.Data.CommandType.StoredProcedure;
            sqlCommand.Clone();

            return sqlCommand;
        }
    }
}