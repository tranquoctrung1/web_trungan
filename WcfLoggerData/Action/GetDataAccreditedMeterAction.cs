using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Web;
using WcfLoggerData.ConnectDB;
using WcfLoggerData.Models;

namespace WcfLoggerData.Action
{
    public class GetDataAccreditedMeterAction
    {
        public List<StatisticSiteViewModel> GetDataAccreditedMeter(string start)
        {
            List<StatisticSiteViewModel> list = new List<StatisticSiteViewModel>();
            DateTime startDate = new DateTime(1970, 01, 01).AddSeconds(int.Parse(start)).AddHours(7);
            Connect connect = new Connect();

            try
            {
                string sqlQuery = $"select s.Id, s.Location, m.Marks, m.Size, m.AccreditedDate, s.DescriptionOfChange, m.AccreditationDocument, m.ExpiryDate from t_Site_Sites s join t_Devices_Meters m on s.Meter = m.Serial where m.AccreditedDate is not null and m.AccreditedDate >= convert(nvarchar, '{startDate}', 120)";

                connect.Connected();

                SqlDataReader reader = connect.Select(sqlQuery);

                int numberOrdered = 1;

                if(reader.HasRows)
                {
                    while(reader.Read())
                    {
                        StatisticSiteViewModel el = new StatisticSiteViewModel();
                        try
                        {
                            el.NumberOrdered = numberOrdered++;
                        }
                        catch(Exception ex)
                        {
                            el.NumberOrdered = numberOrdered;
                        }
                        try
                        {
                            el.Id = reader["Id"].ToString();
                        }
                        catch(Exception ex)
                        {
                            el.Id = "";
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
                            el.Marks = reader["Marks"].ToString();
                        }
                        catch (Exception ex)
                        {
                            el.Marks = "";
                        }
                        try
                        {
                            el.Size = int.Parse(reader["Size"].ToString());
                        }
                        catch (Exception ex)
                        {
                            el.Size = null;
                        }
                        try
                        {
                            el.DateOfChange = DateTime.Parse(reader["AccreditedDate"].ToString());
                        }
                        catch (Exception ex)
                        {
                            el.DateOfChange = null;
                        }
                        try
                        {
                            el.DescriptionOfChange = reader["DescriptionOfChange"].ToString();
                        }
                        catch (Exception ex)
                        {
                            el.DescriptionOfChange = "";
                        }
                        try
                        {
                            el.AccreditationDocument = reader["AccreditationDocument"].ToString();
                        }
                        catch (Exception ex)
                        {
                            el.AccreditationDocument = "";
                        }
                        try
                        {
                            el.ExpiryDate = DateTime.Parse(reader["ExpiryDate"].ToString());
                        }
                        catch (Exception ex)
                        {
                            el.ExpiryDate = null;
                        }

                        list.Add(el);
                    }
                }

            }
            catch(SqlException ex)
            {

            }
            finally
            {
                connect.DisConnected();
            }

            return list;
        }
    }
}