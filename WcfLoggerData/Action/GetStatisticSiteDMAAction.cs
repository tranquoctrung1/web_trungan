using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Web;
using WcfLoggerData.ConnectDB;
using WcfLoggerData.Models;

namespace WcfLoggerData.Action
{
    public class GetStatisticSiteDMAAction
    {
        public List<StatisticSiteDMAViewModel> GetStatisticSiteDMA()
        {
            List<StatisticSiteDMAViewModel> list = new List<StatisticSiteDMAViewModel>();
            Connect connect = new Connect();
            try
            {
                string sqlQuery = $" select ROW_NUMBER() over(order by s.Company) as NumberOrder,s.Id,m.Marks,m.Size, s.Location, s.Level, s.Company, s.Availability, s.Status, s.UsingLogger, s.Description  from t_Site_Sites s join t_Devices_Meters m on s.Meter = m.Serial order by s.Company";
                connect.Connected();

                SqlDataReader reader = connect.Select(sqlQuery);

                if(reader.HasRows)
                {
                    while(reader.Read())
                    {
                        StatisticSiteDMAViewModel el = new StatisticSiteDMAViewModel();
                        try
                        {
                            el.OrderNumber = int.Parse(reader["NumberOrder"].ToString());
                        }
                        catch(Exception ex)
                        {
                            el.OrderNumber = null;
                        }
                        try
                        {
                            el.SiteId = reader["Id"].ToString();
                        }
                        catch(Exception ex)
                        {
                            el.SiteId = "";
                        }
                        try
                        {
                            el.Model = reader["Marks"].ToString();
                        }
                        catch(Exception ex)
                        {
                            el.Model = "";
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
                            el.Location = reader["Location"].ToString();
                        }
                        catch(Exception ex)
                        {
                            el.Location = "";
                        }
                        try
                        {
                            el.Level = reader["Level"].ToString();
                        }
                        catch (Exception ex)
                        {
                            el.Level = "";
                        }
                        try
                        {
                            el.Manager = reader["Company"].ToString();
                        }
                        catch(Exception ex)
                        {
                            el.Manager = "";
                        }
                        try
                        {
                            el.Availability = reader["Availability"].ToString();
                        }
                        catch (Exception ex)
                        {
                            el.Availability = "";
                        }
                        try
                        {
                            el.Status = reader["Status"].ToString();
                        }
                        catch (Exception ex)
                        {
                            el.Status = "";
                        }
                        try
                        {
                            el.UsingLogger = reader["UsingLogger"].ToString();
                        }
                        catch (Exception ex)
                        {
                            el.UsingLogger = "";
                        }
                        if(el.UsingLogger == "0")
                        {
                            el.UsingLogger = "N";
                        }
                        else
                        {
                            el.UsingLogger = "Y";
                        }
                        try
                        {
                            el.Description = reader["Description"].ToString();
                        }
                        catch (Exception ex)
                        {
                            el.Description = "";
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

            return list;
        }
    }
}