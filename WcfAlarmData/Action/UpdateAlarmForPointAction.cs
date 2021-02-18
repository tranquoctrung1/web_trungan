using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using WcfAlarmData.ConnectDB;

namespace WcfAlarmData.Action
{
    class UpdateAlarmForPointAction
    {
        public int UpdateAlarmForPoint(string channelid)
        {
            int nRows = 0;
            Connect connect = new Connect();

            try
            {
                string sqlQuery = $"update t_History_Alarm set EndDateAlarm = '{DateTime.Now}', IsFinish = 1 where ChannelId = '{channelid}' and IsFinish = 0";
                connect.Connected();

                nRows = connect.ExcuteNonQuery(sqlQuery);

            }
            catch(SqlException ex)
            {
                throw ex;
            }
            finally
            {
                connect.DisConnected();
            }

            return nRows;
        }
    }
}
