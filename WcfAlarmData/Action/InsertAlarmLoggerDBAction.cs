using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using WcfAlarmData.ConnectDB;
using WcfAlarmData.Model;

namespace WcfAlarmData.Action
{
    public class InsertAlarmLoggerDBAction
    {
        public int Insert(List<AlarmForLoggerViewModel> list)
        {
            int nRows = 0;
            Connect connect = new Connect();
            try
            {
                string sqlQuery = $"insert into t_History_Alarm_Logger values ";

                for(int i = 0; i < list.Count - 1; i++)
                {
                    sqlQuery += $"('{list[i].Serial}', '{list[i].Type}', '{list[i].StartDate}', NULL, '{list[i].IsFinish}', N'{list[i].Content}'),";
                }

                sqlQuery += $"('{list[list.Count - 1].Serial}', '{list[list.Count - 1].Type}', '{list[list.Count - 1].StartDate}', NULL, '{list[list.Count - 1].IsFinish}', N'{list[list.Count - 1].Content}')";
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
