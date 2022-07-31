using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Web;
using WcfLoggerData.ConnectDB;
using WcfLoggerData.Models;

namespace WcfLoggerData.Action
{
    public class GetTotalSiteHasDataAction
    {
        public List<TotalSiteHasValueModel> GetTotalSiteHasData()
        {
            List<TotalSiteHasValueModel> list = new List<TotalSiteHasValueModel>();

            Connect connect = new Connect();
            try
            {
                string store = "p_Total_Site_Has_Data";

                connect.Connected();

                SqlCommand command = connect.ExcuteStoreProceduce(store);

                SqlDataReader reader = command.ExecuteReader();

                if (reader.HasRows)
                {
                    while (reader.Read())
                    {
                        TotalSiteHasValueModel el = new TotalSiteHasValueModel();

                        try
                        {
                            el.Result = int.Parse(reader["Result"].ToString());
                        }
                        catch (Exception ex)
                        {
                            el.Result = 0;
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