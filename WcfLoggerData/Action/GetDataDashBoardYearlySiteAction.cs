﻿using System;
using System.Collections.Generic;
using System.Configuration;
using System.Data.SqlClient;
using System.Linq;
using System.Web;
using WcfLoggerData.Models;

namespace WcfLoggerData.Action
{
    public class GetDataDashBoardYearlySiteAction
    {
        public List<DataReportYearlySiteViewModel> GetDataReportYearlySite(string siteid, string start, string end)
        {
            List<DataReportYearlySiteViewModel> list = new List<DataReportYearlySiteViewModel>();
            DateTime timeStart = new DateTime(1970, 01, 01).AddSeconds(int.Parse(start)).AddHours(7);
            DateTime timeEnd = new DateTime(1970, 01, 01).AddSeconds(int.Parse(end)).AddHours(7);

            // this el is total data
            DataReportYearlySiteViewModel totalData = new DataReportYearlySiteViewModel();
            totalData.TimeStamp = new DateTime(1970, 01, 01);
            totalData.Value = 0;

            string connectionString = ConfigurationManager.ConnectionStrings["db"].ConnectionString;

            using (SqlConnection sqlConnection = new SqlConnection(connectionString))
            {
                string store = "p_Calculate_Yearly_Site";

                sqlConnection.Open();
                using (SqlCommand sqlCommand = new SqlCommand(store, sqlConnection))
                {
                    sqlCommand.CommandType = System.Data.CommandType.StoredProcedure;
                    sqlCommand.Parameters.Add(new SqlParameter("@siteid", siteid));
                    sqlCommand.Parameters.Add(new SqlParameter("@start", timeStart));
                    sqlCommand.Parameters.Add(new SqlParameter("@end", timeEnd));

                    SqlDataReader reader = sqlCommand.ExecuteReader();

                    if (reader.HasRows)
                    {
                        while (reader.Read())
                        {
                            DataReportYearlySiteViewModel el = new DataReportYearlySiteViewModel();
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
            }
            return list;
        }
    }
}