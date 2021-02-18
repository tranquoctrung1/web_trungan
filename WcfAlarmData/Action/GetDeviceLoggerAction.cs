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
    public class GetDeviceLoggerAction
    {
        public List<LoggerViewModel> GetLogger()
        {
            List<LoggerViewModel> list = new List<LoggerViewModel>();
            Connect connect = new Connect();

            try
            {
                string sqlQuery = $"SELECT [Serial], [ReceiptDate], [Provider], [Marks], [Model], [Status], [Installed], [Description], [DateAccreditation], [DateInstallBattery], [YearBattery] FROM [t_Devices_Loggers] where [DateAccreditation] is not null or ([DateInstallBattery] is not null and [YearBattery] is not null) order by [Serial]";

                connect.Connected();

                SqlDataReader reader = connect.Select(sqlQuery);

                if(reader.HasRows)
                {
                    while(reader.Read())
                    {
                        LoggerViewModel el = new LoggerViewModel();
                        try
                        {
                            el.Serial = reader["Serial"].ToString();
                        }
                        catch(Exception ex)
                        {
                            el.Serial = "";
                        }
                        try
                        {
                            el.ReceiptDate =DateTime.Parse( reader["ReceiptDate"].ToString());
                        }
                        catch (Exception ex)
                        {
                            el.ReceiptDate= null;
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
