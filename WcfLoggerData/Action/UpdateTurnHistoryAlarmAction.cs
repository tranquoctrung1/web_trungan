using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Web;
using WcfLoggerData.ConnectDB;
using WcfLoggerData.Models;

namespace WcfLoggerData.Action
{
    public class UpdateTurnHistoryAlarmAction
    {
        public int UpdateTurnHistoryAlarm(TurnHistoryAlarmViewModel t)
        {
            int nRows = 0;

            Connect connect = new Connect();
            try
            {
                string sqlQuery = $"update [t_Turn_History_Alarm] set IsOn = '{t.IsOn}' where Type = '{t.Type}'";

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

            return nRows;
        }
    }
}