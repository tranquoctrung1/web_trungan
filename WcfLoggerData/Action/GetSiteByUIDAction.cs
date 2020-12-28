using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Web;
using WcfLoggerData.ConnectDB;
using WcfLoggerData.Models;

namespace WcfLoggerData.Action
{
    public class GetSiteByUIDAction
    {
        public List<SiteResultByUIDViewModel> GetSiteResultByUID(string uid)
        {
            List<SiteResultByUIDViewModel> list = new List<SiteResultByUIDViewModel>();

            try
            {
                string sqlQuery = $"select top(150) s.Company, s.Latitude, s.Longitude, s.Id as SiteId, s.Location , t.Id as LoggerId from t_Site_Sites s join t_Devices_SitesConfigs t on t.SiteId = s.Id where exists (select * from t_Devices_ChannelsConfigs dc where dc.LoggerId = t.Id)";

                Connect.ConnectToDataBase();

                SqlDataReader reader = Connect.Select(sqlQuery);

                if(reader.HasRows)
                {
                    while(reader.Read())
                    {
                        SiteResultByUIDViewModel el = new SiteResultByUIDViewModel();
                        try
                        {
                            el.DisplayGroup = reader["Company"].ToString();
                        }
                        catch(Exception ex)
                        {
                            el.DisplayGroup = "";
                        }
                        try
                        {
                            el.Latitude = double.Parse(reader["Latitude"].ToString());
                        }
                        catch (Exception ex)
                        {
                            el.Latitude = null;
                        }
                        try
                        {
                            el.Longitude = double.Parse(reader["Longitude"].ToString());
                        }
                        catch (Exception ex)
                        {
                            el.Longitude = null;
                        }
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
                            el.LoggerId = reader["LoggerId"].ToString();
                        }
                        catch (Exception ex)
                        {
                            el.LoggerId = "";
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
               // Connect.DisconnectToDataBase();
            }

            return list;
        }
    }
}