using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Web;
using WcfAlarmData.ConnectDB;

namespace WcfLoggerData.Action
{
    public class GetMinNightFlowAction
    {
        public double? GetMinNightFlow(string channelid, DateTime start, DateTime end)
        {
            double? min = null;
            Connect connect = new Connect();
            try
            {
                string sqlQuery = $"select min(Value) as Min from t_Data_{channelid} where TimeStamp between convert(nvarchar, '{start}', 120) and convert(nvarchar, '{end}', 120)";
                connect.Connected();

                SqlDataReader reader = connect.Select(sqlQuery);

                if(reader.HasRows)
                {
                    while(reader.Read())
                    {
                        try
                        {
                            min = double.Parse(reader["Min"].ToString());
                        }
                        catch
                        {
                            min = null;
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

            return min;
        }
    }
}