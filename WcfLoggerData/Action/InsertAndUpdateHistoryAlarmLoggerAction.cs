using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Web;
using WcfLoggerData.ConnectDB;
using WcfLoggerData.Models;

namespace WcfLoggerData.Action
{
    public class InsertAndUpdateHistoryAlarmLoggerAction
    {
        public int InsertAndUpdateHistoryAlarmLogger()
        {
            int nRows = 0;

            List<AlarmForLoggerViewModel> update = GetListAlarmUpdate();
            List<DeviceLoggerViewModel> temp  = GetListInsert();
            List<AlarmForLoggerViewModel> insert = new List<AlarmForLoggerViewModel>();

            CheckAccreditationLoggerAction checkAccreditationLoggerAction = new CheckAccreditationLoggerAction();
            CheckYearBatteryAction checkYearBatteryAction = new CheckYearBatteryAction();
            CheckAccreditationAlarmLoggerAction checkAccreditationAlarmLoggerAction = new CheckAccreditationAlarmLoggerAction();
            CheckYearBatteryAlarmAction checkYearBatteryAlarmAction = new CheckYearBatteryAlarmAction();

            // udpate 
            foreach(var item in update)
            {
                if(checkAccreditationLoggerAction.CheckAccreditationLogger(item.Serial) == true)
                {
                   nRows +=  Update(item);
                }
                if(checkYearBatteryAction.CheckYearBattery(item.Serial) == true)
                {
                    nRows += Update(item);
                }
            }
            // insert 
            foreach(var item in temp)
            {
                if (checkAccreditationAlarmLoggerAction.CheckAccreditationLogger(item.Serial) == true)
                {
                    Nullable<DateTime> tmp = GetStartDateHistoryAlarmLogger(item.Serial, 1);
                    if (tmp != null)
                    {
                        if(Math.Abs((tmp.Value - DateTime.Now).TotalDays) >= 1)
                        {
                            AlarmForLoggerViewModel el = new AlarmForLoggerViewModel();
                            el.Serial = item.Serial;
                            el.Type = 1;
                            el.StartDate = DateTime.Now;
                            el.IsFinish = false;
                            el.Content = "Logger sắp đến hạn kiểm tra!!";

                            insert.Add(el);
                        }
                    }
                }
                if (checkYearBatteryAlarmAction.CheckYearBattery(item.Serial) == true)
                {
                    Nullable<DateTime> tmp = GetStartDateHistoryAlarmLogger(item.Serial, 2);
                    if (tmp != null)
                    {
                        if (Math.Abs((tmp.Value - DateTime.Now).TotalDays) >= 1)
                        {
                            AlarmForLoggerViewModel el = new AlarmForLoggerViewModel();
                            el.Serial = item.Serial;
                            el.Type = 1;
                            el.StartDate = DateTime.Now;
                            el.IsFinish = false;
                            el.Content = "Logger sắp đến hạn thay pin!!";

                            insert.Add(el);
                        }
                    }
                }
            }
            if(insert.Count != 0)
            {
                nRows += Insert(insert);
            }

            return nRows;
        }

        public Nullable<DateTime> GetStartDateHistoryAlarmLogger(string serial, int type)
        {
            Nullable<DateTime> date = null;

            Connect connect = new Connect();
            try
            {
                string sqlQuery = $"select top(1) StartDate from t_History_Alarm_Logger where Serial = '{serial}' and Type = '{type}' order by StartDate desc";

                connect.Connected();

                SqlDataReader reader = connect.Select(sqlQuery);

                if (reader.HasRows)
                {
                    while(reader.Read())
                    {
                        try
                        {
                            date = DateTime.Parse(reader["StartDate"].ToString());
                        }
                        catch(Exception ex)
                        {
                            date = null;
                        }
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

            return date;
        }

        public bool CheckExistsAlarmLogger(string serial, DateTime startDate, int type)
        {
            bool check = false;
            Connect connect = new Connect();
            try
            {
                string sqlQuery = $"select Serial from t_History_Alarm_Logger where Serial = '{serial}' and StartDate = convert(nvarchar, '{startDate}', 120) and Type = '{type}'";

                connect.Connected();

                SqlDataReader reader = connect.Select(sqlQuery);

                if(reader.HasRows)
                {
                    check = true;
                }
                else
                {
                    check = false;
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

            return check;
        }

        public int Insert(List<AlarmForLoggerViewModel> list)
        {
            int nRows = 0;

            Connect connect = new Connect();
            try
            {
                string sqlQuery = $"insert into t_History_Alarm_Logger values";

                for(int i = 0; i < list.Count - 1; i++)
                {
                    sqlQuery += $"('{list[i].Serial}', '{list[i].Type}', '{list[i].StartDate}', '{list[i].EndDate}', '0', N'{list[i].Content}'),";
                }
                sqlQuery += $"('{list[list.Count - 1].Serial}', '{list[list.Count - 1].Type}', '{list[list.Count - 1].StartDate}', '{list[list.Count - 1].EndDate}', '0', N'{list[list.Count - 1].Content}')";

                connect.Connected();

                nRows = connect.ExcuteNonQuery(sqlQuery);
            }
            catch (SqlException ex)
            {
                throw ex;
            }
            finally
            {
                connect.DisConnected();
            }

            return nRows;
        }


        public int Update(AlarmForLoggerViewModel al)
        {
            int nRows = 0;

            Connect connect = new Connect();
            try
            {
                string sqlQuery = $"update t_History_Alarm_Logger set EndDate = '{DateTime.Now}' where Serial = '{al.Serial}' and StartDate = '{al.StartDate}' and Type = '{al.Type}'";

                connect.Connected();

                nRows = connect.ExcuteNonQuery(sqlQuery);
            }
            catch (SqlException ex)
            {
                throw ex;
            }
            finally
            {
                connect.DisConnected();
            }

            return nRows;
        }

        public List<AlarmForLoggerViewModel> GetListAlarmUpdate()
        {
            List<AlarmForLoggerViewModel> list = new List<AlarmForLoggerViewModel>();
            Connect connect = new Connect();
            try
            {
                string sqlQuery = $"select Serial, Type, StartDate, EndDate, IsFinish, [Content] from t_History_Alarm_Logger where IsFinish = 0  order by IsFinish";
                connect.Connected();

                SqlDataReader reader = connect.Select(sqlQuery);

                if (reader.HasRows)
                {
                    while (reader.Read())
                    {
                        AlarmForLoggerViewModel el = new AlarmForLoggerViewModel();
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
                            el.Type = int.Parse(reader["Type"].ToString());
                        }
                        catch (Exception ex)
                        {
                            el.Type = null;
                        }
                        try
                        {
                            el.StartDate = DateTime.Parse(reader["StartDate"].ToString());
                        }
                        catch (Exception ex)
                        {
                            el.StartDate = null;
                        }
                        try
                        {
                            el.EndDate = DateTime.Parse(reader["EndDate"].ToString());
                        }
                        catch (Exception ex)
                        {
                            el.EndDate = null;
                        }
                        try
                        {
                            el.IsFinish = bool.Parse(reader["IsFinish"].ToString());
                        }
                        catch (Exception ex)
                        {
                            el.IsFinish = null;
                        }
                        try
                        {
                            el.Content = reader["Content"].ToString();
                        }
                        catch (Exception ex)
                        {
                            el.Content = "";
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

        public List<DeviceLoggerViewModel> GetListInsert()
        {
            List<DeviceLoggerViewModel> list = new List<DeviceLoggerViewModel>();
            Connect connect = new Connect();
            try
            {
                string sqlQuery = $"select Serial, ReceiptDate, Provider, Marks, Model, Status, Installed, Description, DateAccreditation, DateInstallBattery, YearBattery from t_Devices_Loggers where DateAccreditation is not null or (DateInstallBattery is not null and YearBattery is not null)";

                connect.Connected();

                SqlDataReader reader = connect.Select(sqlQuery);

                if(reader.HasRows)
                {
                    while(reader.Read())
                    {
                        DeviceLoggerViewModel el = new DeviceLoggerViewModel();
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
                            el.ReceiptDate =DateTime.Parse(reader["ReceiptDate"].ToString());
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