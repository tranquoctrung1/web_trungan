using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using WcfAlarmData.ConnectDB;

namespace WcfAlarmData.Action
{
    public class UpdateAlarmForLoggerDBAction
    {
        public int Update(string serial, int type)
        {
            int nRows = 0;
            Connect connect = new Connect();
            try
            {
                string sqlQuery = $"update t_History_Alarm_Logger set EndDate = '{DateTime.Now}', IsFinish = 'true' where Serial = '{serial}' and Type = '{type.ToString()}' and IsFinish = 'false'";

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
