using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Web;
using WcfLoggerData.ConnectDB;
using WcfLoggerData.Models;

namespace WcfLoggerData.Action
{
    public class GetHistoryDataLoggerAtOneTimeAction
    {
        public DataGraphViewModel GetHistoryDataLoggerAtOneTime(string channelid, DateTime start)
        {

            DataGraphViewModel el = new DataGraphViewModel();
            Connect connect = new Connect();

            try
            {
                string sqlQuery = $"select TimeStamp, Value from t_Data_{channelid} where TimeStamp = convert(nvarchar, '{start}', 120) order by TimeStamp desc";

                connect.Connected();

                SqlDataReader reader = connect.Select(sqlQuery);

                if (reader.HasRows)
                {
                    while (reader.Read())
                    {
                        try
                        {
                            el.TimeStamp = DateTime.Parse(reader["TimeStamp"].ToString());
                        }
                        catch (Exception ex)
                        {
                            el.TimeStamp = null;
                        }
                        try
                        {
                            el.Value = double.Parse(reader["Value"].ToString());
                        }
                        catch (Exception ex)
                        {
                            el.Value = null;
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

            return el;
        }
    }
}