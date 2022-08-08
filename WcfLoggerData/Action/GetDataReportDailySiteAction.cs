using System;
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
                if (siteid != "")
                {
                    string[] siteid_split = siteid.Split(new char[] { '|' }, StringSplitOptions.None);

                    if (siteid_split.Length > 0)
                    {
                        foreach (string site in siteid_split)
                        {
                            try
                            {
                                string store = "p_Calculate_Daily_Site";

                                connect.Connected();

                                SqlCommand command = connect.ExcuteStoreProceduce(store);
                                command.Parameters.Add(new SqlParameter("@siteid", site));
                                command.Parameters.Add(new SqlParameter("@start", timeStart));
                                command.Parameters.Add(new SqlParameter("@end", timeEnd));

                                SqlDataReader reader = command.ExecuteReader();

                                if (reader.HasRows)
                                {
                                    while (reader.Read())
                                    {
                                        DataReportDailySiteViewModel el = new DataReportDailySiteViewModel();
                                        try
                                        {
                                            el.SiteId = reader["SiteId"].ToString();
                                        }
                                        catch (Exception ex)
                                        {
                                            el.SiteId = "";
                                        }
                                        try
                                        {
                                            el.Location = reader["Location"].ToString();
                                        }
                                        catch (Exception ex)
                                        {
                                            el.Location = "";
                                        }
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
                                        catch (Exception ex)
                                        {
                                            el.StartTime = null;
                                        }
                                        try
                                        {
                                            el.EndTime = DateTime.Parse(reader["EndTime"].ToString());
                                        }
                                        catch (Exception ex)
                                        {
                                            el.EndTime = null;
                                        }
                                        try
                                        {
                                            el.StartIndex = double.Parse(reader["StartIndex"].ToString());
                                        }
                                        catch (Exception ex)
                                        {
                                            el.StartIndex = null;
                                        }
                                        try
                                        {
                                            el.EndIndex = double.Parse(reader["EndIndex"].ToString());
                                        }
                                        catch (Exception ex)
                                        {
                                            el.EndIndex = null;
                                        }
                                        try
                                        {
                                            el.Value = double.Parse(reader["Value"].ToString());
                                            el.Value = Math.Round(el.Value.Value, 2);
                                            totalData.Value += el.Value;
                                            totalData.Value = Math.Round(totalData.Value.Value, 2);
                                        }
                                        catch (Exception ex)
                                        {
                                            el.Value = null;
                                        }

                                        list.Add(el);
                                    }
                                }
                            }
                            catch (Exception ex)
                            {

                            }

                        }
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

            list = list.OrderBy(el => el.TimeStamp).ToList();

            list.Add(totalData);

            return list;
        }
    }
}