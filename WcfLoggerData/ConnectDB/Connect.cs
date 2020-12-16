﻿using System;
using System.Collections.Generic;
using System.Configuration;
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
            if(sqlConnection != null && sqlConnection.State == System.Data.ConnectionState.Closed)
            {
                sqlConnection.Open();
            }

       }

        public static void DisconnectToDataBase()
        {
            if (sqlConnection != null && sqlConnection.State == System.Data.ConnectionState.Open)
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
            sqlCommand.CommandType = System.Data.CommandType.StoredProcedure;
            sqlCommand.Clone();

            return sqlCommand;

        }
    }
}