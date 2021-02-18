using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using WcfAlarmData.ConnectDB;

namespace WcfAlarmData.Action
{
    class GetIntervalTimeAction
    {
        public int GetIntervalTime(string loggerid)
        {
            Connect connect = new Connect();

            int interval = 15;

            try
            {
                string sqlQuery = $"select Interval from t_Devices_SitesConfigs where Id = '{loggerid}'";

                connect.Connected();

                SqlDataReader reader = connect.Select(sqlQuery);

                if(reader.HasRows)
                {
                    while(reader.Read())
                    {
                        try
                        {
                            interval = int.Parse(reader["Interval"].ToString());
                        }
                        catch
                        {
                            interval = 15;
                        }
                    }
                }

            }catch(SqlException ex)
            {
                throw ex;
            }
            finally
            {
                connect.DisConnected();
            }

            return interval;
        }
    }
}
