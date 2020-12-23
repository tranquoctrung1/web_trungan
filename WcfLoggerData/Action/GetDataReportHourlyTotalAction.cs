using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Web;
using WcfLoggerData.ConnectDB;
using WcfLoggerData.Models;

namespace WcfLoggerData.Action
{
    public class GetDataReportHourlyTotalAction
    {
        public List<DataReportHourlyTotalViewModel> GetDataReportHourlyTotal(string start, string end)
        {
            List<DataReportHourlyTotalViewModel> list = new List<DataReportHourlyTotalViewModel>();
            DateTime timeStart = new DateTime(1970, 01, 01).AddSeconds(int.Parse(start)).AddHours(7);
            DateTime timeEnd = new DateTime(1970, 01, 01).AddSeconds(int.Parse(end)).AddHours(7);

            // this el is total data
            DataReportHourlyTotalViewModel totalData = new DataReportHourlyTotalViewModel();
            totalData.TimeStamp = new DateTime(1970, 01, 01);
            totalData.Value = 0;

            try
            {
                string store = "p_Calculate_Hourly_Output_All";

                Connect.ConnectToDataBase();

                SqlCommand command = Connect.ExcuteStoreProceduce(store);
                command.Parameters.Add(new SqlParameter("@StartDate", timeStart));
                command.Parameters.Add(new SqlParameter("@EndDate", timeEnd));

                command.CommandTimeout = 3600;

                SqlDataReader reader = command.ExecuteReader();

                if (reader.HasRows)
                {
                    while (reader.Read())
                    {
                        DataReportHourlyTotalViewModel el = new DataReportHourlyTotalViewModel();
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
                Connect.DisconnectToDataBase();
            }

            list.Add(totalData);

            return list;
        }
    }
}