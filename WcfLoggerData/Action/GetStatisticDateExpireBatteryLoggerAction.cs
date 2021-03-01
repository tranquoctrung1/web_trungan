using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Web;
using WcfLoggerData.ConnectDB;
using WcfLoggerData.Models;

namespace WcfLoggerData.Action
{
    public class GetStatisticDateExpireBatteryLoggerAction
    {
        public List<DeviceLoggerViewModel> GetDeviceLogger(string start, string end)
        {
            DateTime timeStart = new DateTime(1970, 01, 01).AddSeconds(int.Parse(start)).AddHours(7);
            DateTime timeEnd = new DateTime(1970, 01, 01).AddSeconds(int.Parse(end)).AddHours(7);

            List<DeviceLoggerViewModel> list = new List<DeviceLoggerViewModel>();
            Connect connect = new Connect();

            try
            {
                string sqlQuery = $"SELECT d.[Serial], d.[ReceiptDate], d.[Provider], d.[Marks], d.[Model], d.[Status], d.[Installed], d.[Description], d.[DateAccreditation], d.[DateInstallBattery], d.[YearBattery], s.[Company], s.[District] FROM [t_Devices_Loggers] d join [t_Site_Sites] s on s.Logger = d.Serial where convert(nvarchar, '{timeStart}', 120) <= DATEADD(MONTH,d.YearBattery, d.DateInstallBattery ) and DATEADD(MONTH,d.YearBattery, d.DateInstallBattery ) <= convert(nvarchar, '{timeEnd}', 120) order by [Serial]";

                connect.Connected();

                SqlDataReader reader = connect.Select(sqlQuery);

                if (reader.HasRows)
                {
                    while (reader.Read())
                    {
                        DeviceLoggerViewModel el = new DeviceLoggerViewModel();
                        try
                        {
                            el.Serial = reader["Serial"].ToString();
                        }
                        catch (Exception ex)
                        {
                            el.Serial = "";
                        }
                        try
                        {
                            el.ReceiptDate = DateTime.Parse(reader["ReceiptDate"].ToString());
                        }
                        catch (Exception ex)
                        {
                            el.ReceiptDate = null;
                        }
                        try
                        {
                            el.Provider = reader["Provider"].ToString();
                        }
                        catch (Exception ex)
                        {
                            el.Provider = "";
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
                            el.Model = reader["Model"].ToString();
                        }
                        catch (Exception ex)
                        {
                            el.Model = "";
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
                            el.Installed = bool.Parse(reader["Installed"].ToString());
                        }
                        catch (Exception ex)
                        {
                            el.Installed = null;
                        }
                        try
                        {
                            el.Description = reader["Description"].ToString();
                        }
                        catch (Exception ex)
                        {
                            el.Description = "";
                        }
                        try
                        {
                            el.DateAccreditation = DateTime.Parse(reader["DateAccreditation"].ToString());
                        }
                        catch (Exception ex)
                        {
                            el.DateAccreditation = null;
                        }
                        try
                        {
                            el.DateInstallBattery = DateTime.Parse(reader["DateInstallBattery"].ToString());
                        }
                        catch (Exception ex)
                        {
                            el.DateInstallBattery = null;
                        }
                        try
                        {
                            el.YearBattery = int.Parse(reader["YearBattery"].ToString());
                        }
                        catch (Exception ex)
                        {
                            el.YearBattery = null;
                        }
                        try
                        {
                            el.Company = reader["Company"].ToString();
                        }
                        catch (Exception ex)
                        {
                            el.Company = "";
                        }
                        try
                        {
                            el.District = reader["District"].ToString();
                        }
                        catch (Exception ex)
                        {
                            el.District = "";
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