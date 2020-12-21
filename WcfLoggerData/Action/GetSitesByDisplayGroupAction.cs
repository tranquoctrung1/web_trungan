using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Web;
using WcfLoggerData.ConnectDB;
using WcfLoggerData.Models;

namespace WcfLoggerData.Action
{
    public class GetSitesByDisplayGroupAction
    {
        public List<SiteByDisplayGroupViewModel> GetSiteByDisplayGroup(string displayGroup)
        {
            List<SiteByDisplayGroupViewModel> list = new List<SiteByDisplayGroupViewModel>();

            try
            {
                string sqlQuery = $"select s.Id, s.Location, ds.Id as LoggerId, s.Company, s.Meter from t_Site_Sites s join t_Devices_SitesConfigs ds on ds.SiteId = s.Id where s.Company = '{displayGroup}'";
                Connect.ConnectToDataBase();

                SqlDataReader reader = Connect.Select(sqlQuery);

                if(reader.HasRows)
                {
                    while(reader.Read())
                    {
                        SiteByDisplayGroupViewModel el = new SiteByDisplayGroupViewModel();
                        try
                        {
                            el.SiteID = reader["Id"].ToString();
                        }
                        catch(Exception ex)
                        {
                            el.SiteID = "";
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
                            el.MeterSerial = reader["Meter"].ToString();
                        }
                        catch (Exception ex)
                        {
                            el.MeterSerial = "";
                        }
                        try
                        {
                            el.DisplayGroup = reader["Company"].ToString();
                        }
                        catch (Exception ex)
                        {
                            el.DisplayGroup = "";
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
                //Connect.DisconnectToDataBase();
            }

            return list;
        }
    }
}