using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using WcfAlarmData.ConnectDB;

namespace WcfAlarmData.Action
{
    public class UpdateAlarmForDMAAction
    {
        public int Update(string dma, int type )
        {
            int nRow = 0;
            Connect connect = new Connect();
            try
            {
                string sqlQuery = $"update t_Histoty_Alarm_DMA set EndDate = '{DateTime.Now}', IsFinish = 1 where DMAId = '{dma}' and Type = '{type}' and IsFinish = 0";

                connect.Connected();

                nRow = connect.ExcuteNonQuery(sqlQuery);
            }
            catch(SqlException ex)
            {
                throw ex;
            }
            finally
            {
                connect.DisConnected();
            }

            return nRow;
        }
    }
}
