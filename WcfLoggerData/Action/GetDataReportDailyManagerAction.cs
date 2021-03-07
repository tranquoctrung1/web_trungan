using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Web;
using WcfLoggerData.ConnectDB;
using WcfLoggerData.Models;

namespace WcfLoggerData.Action
{
    public class GetDataReportDailyManagerAction
    {
        public List<DataReportDailyManagerViewModel> GetDataReportDailyManager(string managerid, string start, string end)
        {
            List<DataReportDailyManagerViewModel> list = new List<DataReportDailyManagerViewModel>();
            DateTime timeStart = new DateTime(1970, 01, 01).AddSeconds(int.Parse(start)).AddHours(7);
            DateTime timeEnd = new DateTime(1970, 01, 01).AddSeconds(int.Parse(end)).AddHours(7);

            // this el is total data
            DataReportDailyManagerViewModel totalData = new DataReportDailyManagerViewModel();
            totalData.TimeStamp = new DateTime(1970, 01, 01);
            totalData.Value = 0;
            Connect connect = new Connect();
            try
            {
                string store = "p_Calculate_Daily_Data_DMA";

                connect.Connected();

                SqlCommand command = connect.ExcuteStoreProceduce(store);
                command.Parameters.Add(new SqlParameter("@dmaid", managerid));
                command.Parameters.Add(new SqlParameter("@start", timeStart));
                command.Parameters.Add(new SqlParameter("@end", timeEnd));

                SqlDataReader reader = command.ExecuteReader();

                if (reader.HasRows)
                {
                    while (reader.Read())
                    {
                        DataReportDailyManagerViewModel el = new DataReportDailyManagerViewModel();
                        try
                        {
                            el.TimeStamp = DateTime.Parse(reader["TimeStamp"].ToString());
                        }
                        catch (Exception ex)
                        {
                            el.TimeStamp = null;
                        }
                        try
                        {
                            el.Value = double.Parse(reader["Value"].ToString());
                            totalData.Value += el.Value;
                        }
                        catch (Exception ex)
                        {
                            el.Value = null;
                        }

                        list.Add(el);
                    }
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

            list.Add(totalData);

            return list;
        }
    }
}