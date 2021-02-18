using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using WcfAlarmData.ConnectDB;
using WcfLoggerData.Models;

namespace WcfAlarmData.Action
{
    class InsertAlarmDBAction
    {
        public int InsertAlarmDB(List<AlarmForPointViewModel> list )
        {
            int nRows = 0;
            Connect connect = new Connect();
            if(list.Count != 0)
            {
                try
                {
                    string sqlQuery = $"insert into t_History_Alarm values";

                    for (int i = 0; i < list.Count - 1; i++)
                    {
                        sqlQuery += $"('{list[i].ChannelId}', '{list[i].Location}', '{list[i].StartDateAlarm}', NULL, '{list[i].TypeAlarm}', '{list[i].Level}', '{list[i].IsFinish}', '{list[i].Content}'),";
                    }
                    sqlQuery += $"('{list[list.Count - 1].ChannelId}', '{list[list.Count - 1].Location}', '{list[list.Count - 1].StartDateAlarm}', NULL, '{list[list.Count - 1].TypeAlarm}', '{list[list.Count - 1].Level}', '{list[list.Count - 1].IsFinish}', '{list[list.Count - 1].Content}')";
                    connect.Connected();


                    nRows = connect.ExcuteNonQuery(sqlQuery);

                }
                catch (SqlException ex)
                {
                    throw ex;
                }
                finally
                {
                    connect.DisConnected();
                }

            }

            return nRows;
        }
    }
}
