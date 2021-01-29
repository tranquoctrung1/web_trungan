
using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Web;
using WcfLoggerData.ConnectDB;

namespace WcfLoggerData.Action
{
    public class GetCurrentTimeAction
    {
        public DateTime GetCurrentTime(string channelid)
        {
            DateTime date = new DateTime(1970, 01, 01);
            Connect connect = new Connect();
            try
            {
                string sqlQuery = $"select top(1) TimeStamp from t_Data_{channelid} order by TimeStamp desc";

                connect.Connected();

                SqlDataReader reader = connect.Select(sqlQuery);

                if(reader.HasRows)
                {
                    while(reader.Read())
                    {
                        try
                        {
                            date = DateTime.Parse( reader["TimeStamp"].ToString());
                        }
                        catch(Exception ex)
                        {
                            date = new DateTime(1970, 01, 01);
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

            return date;
        }
    }
}