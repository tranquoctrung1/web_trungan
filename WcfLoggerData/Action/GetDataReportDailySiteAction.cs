﻿using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Web;
using WcfLoggerData.ConnectDB;
using WcfLoggerData.Models;

namespace WcfLoggerData.Action
{
    public class GetDataReportDailySiteAction
    {
        public List<DataReportDailySiteViewModel> GetDataReportDailySite(string siteid, string start, string end)
        {
            List<DataReportDailySiteViewModel> list = new List<DataReportDailySiteViewModel>();
            DateTime timeStart = new DateTime(1970, 01, 01).AddSeconds(int.Parse(start)).AddHours(7);
            DateTime timeEnd = new DateTime(1970, 01, 01).AddSeconds(int.Parse(end)).AddHours(7);

            // this el is total data
            DataReportDailySiteViewModel totalData = new DataReportDailySiteViewModel();
            totalData.TimeStamp = new DateTime(1970, 01, 01);
            totalData.Value = 0;

            Connect connect = new Connect();
            try
            {
                string store = "p_Calculate_Daily_Site";

                connect.Connected();

                SqlCommand command =  connect.ExcuteStoreProceduce(store);
                command.Parameters.Add(new SqlParameter("@siteid", siteid));
                command.Parameters.Add(new SqlParameter("@start", timeStart));
                command.Parameters.Add(new SqlParameter("@end", timeEnd));

                SqlDataReader reader = command.ExecuteReader();

                if(reader.HasRows)
                {
                    while(reader.Read())
                    {
                        DataReportDailySiteViewModel el = new DataReportDailySiteViewModel();
                        try
                        {
                            el.TimeStamp = DateTime.Parse(reader["TimeStamp"].ToString());
                        }
                        catch(Exception ex)
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
            catch(SqlException ex)
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