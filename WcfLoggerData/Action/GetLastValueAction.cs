using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Web;
using WcfLoggerData.ConnectDB;

namespace WcfLoggerData.Action
{
    public class GetLastValueAction
    {
        public double? GetLastValue(string channelid)
        {
            double? value = null;
            Connect connect = new Connect();
            try
            {
                string sqlQuery = "select top(1) Value from t_Data_" + channelid + " order by TimeStamp desc";

                connect.Connected();

                SqlDataReader reader = connect.Select(sqlQuery);

                if (reader.HasRows)
                {
                    while (reader.Read())
                    {
                        try
                        {
                            value = double.Parse(reader["Value"].ToString());
                        }
                        catch (Exception ex)
                        {
                            value = null;
                        }
                    }
                }
            }
            catch (SqlException ex)
            {
                throw ex;
            }
            finally
            {
                connect.DisConnected();
            }

            return value;
        }
    }
}