using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using WcfAlarmData.ConnectDB;

namespace WcfAlarmData.Action
{
    class CheckExistsAlarmAction
    {
        public bool CheckExistsAlarm(string channelid, DateTime timeStamp, int type)
        {
            bool check = false;
            Connect connect = new Connect();

            try
            {
                string sqlQuery = $"select * from t_History_Alarm where ChannelId = '{channelid}' and StartDate = convert(nvarchar, '{timeStamp}', 120) and TypeAlarm = '{type.ToString()}'";
                connect.Connected();

                SqlDataReader reader = connect.Select(sqlQuery);

                if(reader.HasRows)
                {
                    check = true;
                }
                else
                {
                    check = false;
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

            return check;
        }

    }
}
