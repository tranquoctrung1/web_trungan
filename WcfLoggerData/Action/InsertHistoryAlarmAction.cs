using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Web;
using WcfLoggerData.ConnectDB;
using WcfLoggerData.Models;

namespace WcfLoggerData.Action
{
    public class InsertHistoryAlarmAction
    {
        public int InsertHistoryAlarm(List<AlarmForPointViewModel> list )
        {
            int nRows = 0;

            Connect connect = new Connect();

            try
            {
                string sqlQurey = $"insert into t_History_Alarm values ";

                for (int i = 0; i < list.Count - 1; i++)
                {
                    sqlQurey += $"('{list[i].ChannelId}', '{list[i].Location}', '{list[i].StartDateAlarm}', '{list[i].EndDateAlarm}', '{list[i].TypeAlarm}', '{list[i].Level}', ''{list[i].IsFinish}'),";
                }

                sqlQurey += $"('{list[list.Count - 1].ChannelId}', '{list[list.Count - 1].Location}', '{list[list.Count - 1].StartDateAlarm}', '{list[list.Count - 1].EndDateAlarm}', '{list[list.Count - 1].TypeAlarm}', '{list[list.Count - 1].Level}', ''{list[list.Count - 1].IsFinish}')";

                connect.Connected();

                nRows = connect.ExcuteNonQuery(sqlQurey);
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