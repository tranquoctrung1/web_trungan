using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using WcfAlarmData.ConnectDB;
using WcfAlarmData.Model;

namespace WcfAlarmData.Action
{
    class GetDMAAction
    {
        public List<DMAViewModel> GetDMA()
        {
            List<DMAViewModel> list = new List<DMAViewModel>();
            Connect connect = new Connect();
            try
            {
                string sqlQuery = $"select Id, SiteId, Tel, Pressure, Forward, Reverse, Interval, BeginTime, ZoomInit, ZoomOn, Pressure1, DelayTime from t_Devices_SitesConfigs order by Id";

                connect.Connected();

                SqlDataReader reader = connect.Select(sqlQuery);
                if(reader.HasRows)
                {
                    while(reader.Read())
                    {
                        DMAViewModel el = new DMAViewModel();
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
                            el.SiteId = reader["SiteId"].ToString();
                        }
                        catch (Exception ex)
                        {
                            el.SiteId = "";
                        }
                        try
                        {
                            el.Tel = reader["Tel"].ToString();
                        }
                        catch (Exception ex)
                        {
                            el.Tel = "";
                        }
                        try
                        {
                            el.Forward = byte.Parse(reader["Forward"].ToString());
                        }
                        catch (Exception ex)
                        {
                            el.Forward = null;
                        }
                        try
                        {
                            el.Pressure = byte.Parse(reader["Pressure"].ToString());
                        }
                        catch (Exception ex)
                        {
                            el.Pressure = null;
                        }
                        try
                        {
                            el.Reverse = byte.Parse(reader["Reverse"].ToString());
                        }
                        catch (Exception ex)
                        {
                            el.Reverse = null;
                        }
                        try
                        {
                            el.Interval = short.Parse(reader["Interval"].ToString());
                        }
                        catch (Exception ex)
                        {
                            el.Interval = null;
                        }
                        try
                        {
                            el.BeginTime = DateTime.Parse(reader["BeginTime"].ToString());
                        }
                        catch (Exception ex)
                        {
                            el.BeginTime = null;
                        }
                        try
                        {
                            el.ZoomInit = byte.Parse(reader["ZoomInit"].ToString());
                        }
                        catch (Exception ex)
                        {
                            el.ZoomInit = null;
                        }
                        try
                        {
                            el.ZoomOn = byte.Parse(reader["ZoomOn"].ToString());
                        }
                        catch (Exception ex)
                        {
                            el.ZoomOn = null;
                        }
                        try
                        {
                            el.Pressure1 = byte.Parse(reader["Pressure1"].ToString());
                        }
                        catch (Exception ex)
                        {
                            el.Pressure1 = null;
                        }
                        try
                        {
                            el.DelayTime = int.Parse(reader["DelayTime"].ToString());
                        }
                        catch (Exception ex)
                        {
                            el.DelayTime = null;
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

            return list;
        }
    }
}
