using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Web;
using WcfLoggerData.ConnectDB;
using WcfLoggerData.Models;

namespace WcfLoggerData.Action
{
    public class UpdateHistoryAlarmAction
    {
        public int UpdateHistoryAlarm(AlarmForPointViewModel alp)
        {
            int nRows = 0;

            Connect connect = new Connect();
            try
            {
                string sqlQuery = $"update t_History_Alarm set EndDateAlarm = '{alp.EndDateAlarm}' where ChannelId = '{alp.ChannelId}'";
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