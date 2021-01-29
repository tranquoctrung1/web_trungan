using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Web;
using WcfLoggerData.ConnectDB;

namespace WcfLoggerData.Action
{
    public class GetQitAction
    {
        public double? GetQit(string channelid, DateTime current)
        {
            double? Qit = null;
            Connect connect = new Connect();
            try
            {
                string sqlQuery = $"select top(1) Value from t_Data_{channelid} where TimeStamp = convert(nvarchar, '{current}', 120)";

                connect.Connected();

                SqlDataReader reader = connect.Select(sqlQuery);   

                if(reader.HasRows)
                {
                    while(reader.Read())
                    {
                        try
                        {
                            Qit = double.Parse(reader["Value"].ToString());
                        }
                        catch(Exception ex)
                        {
                            Qit = null;
                        }
                    }
                }
            }
            catch(SqlException ex)
            {
                throw ex;
            }
            finally
            {
                connect.DisConnected();
            }

            return Qit;
        }
    }
}