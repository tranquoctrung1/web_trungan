using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Web;
using WcfLoggerData.ConnectDB;
using WcfLoggerData.Models;

namespace WcfLoggerData.Action
{
    public class GetDataReportHourlySiteAction
    {
        public List<DataReportHourlySiteViewModel> GetDataReportHourlySite(string siteid, string start, string end)
        {
            List<DataReportHourlySiteViewModel> list = new List<DataReportHourlySiteViewModel>();
            DateTime timeStart = new DateTime(1970, 01, 01).AddSeconds(int.Parse(start)).AddHours(7);
            DateTime timeEnd = new DateTime(1970, 01, 01).AddSeconds(int.Parse(end)).AddHours(7);

            // this el is total data
            DataReportHourlySiteViewModel totalData = new DataReportHourlySiteViewModel();
            totalData.TimeStamp = new DateTime(1970, 01, 01);
            totalData.Value = 0;
            Connect connect = new Connect();
            try
            {
                string store = "p_Calculate_Hourly_Site";

                connect.Connected();

                SqlCommand command = connect.ExcuteStoreProceduce(store);
                command.Parameters.Add(new SqlParameter("@siteid", siteid));
                command.Parameters.Add(new SqlParameter("@start", timeStart));
                command.Parameters.Add(new SqlParameter("@end", timeEnd));

                SqlDataReader reader = command.ExecuteReader();

                if (reader.HasRows)
                {
                    while (reader.Read())
                    {
                        DataReportHourlySiteViewModel el = new DataReportHourlySiteViewModel();
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
                            el.StartTime = DateTime.Parse(reader["StartTime"].ToString());
                        }
                        catch(Exception ex)
                        {
                            el.StartTime = null;
                        }
                        try
                        {
                            el.EndTime = DateTime.Parse(reader["EndTime"].ToString());
                        }
                        catch(Exception ex)
                        {
                            el.EndTime = null;
                        }
                        try
                        {
                            el.StartIndex = double.Parse(reader["StartIndex"].ToString());
                        }
                        catch(Exception ex)
                        {
                            el.StartIndex = null;
                        }
                        try
                        {
                            el.EndIndex = double.Parse(reader["EndIndex"].ToString());
                        }
                        catch(Exception ex)
                        {
                            el.EndIndex = null;
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