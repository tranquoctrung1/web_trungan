using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using WcfAlarmData.ConnectDB;

namespace WcfAlarmData.Action
{
    class GetLoggerByChannelIdAction
    {
        public string GetSiteByChannelId(string channelid)
        {
            string loggerid = "";
            Connect connect = new Connect();

            try
            {
                string sqlQuery = $"select LoggerId from t_Devices_ChannelsConfigs where Id = '{channelid}'";

                connect.Connected();

                SqlDataReader reader = connect.Select(sqlQuery);

                if(reader.HasRows)
                {
                    while(reader.Read())
                    {
                        try
                        {
                            loggerid = reader["LoggerId"].ToString();
                        }
                        catch
                        {
                            loggerid = "";
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

            return loggerid;
        }
    }
}
