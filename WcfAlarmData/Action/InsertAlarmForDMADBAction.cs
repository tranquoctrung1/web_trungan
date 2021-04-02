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
    class InsertAlarmForDMADBAction
    {
        public int Insert(List<AlarmForDMAViewModel> list)
        {
            int nRows = 0;

            Connect connect = new Connect();
            if(list.Count > 0)
            {
                try
                {
                    string sqlQuery = $"insert into t_Histoty_Alarm_DMA values";

                    for (int i = 0; i < list.Count; i++)
                    {
                        sqlQuery += $"('{list[i].Company}', N'{list[i].Description}', '{list[i].StartDate}', NULL, '{list[i].Type}', N'{list[i].Content}', N'{list[i].Level}', '{list[i].IsFinish}'),";
                    }

                    sqlQuery += $"('{list[list.Count - 1].Company}', N'{list[list.Count - 1].Description}', '{list[list.Count - 1].StartDate}', NULL, '{list[list.Count - 1].Type}', N'{list[list.Count - 1].Content}', N'{list[list.Count - 1].Level}' , '{list[list.Count - 1].IsFinish}')";

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
