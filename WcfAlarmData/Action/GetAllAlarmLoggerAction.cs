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
    public class GetAllAlarmLoggerAction
    {
        public List<AlarmForLoggerViewModel> GetAllAlarmForLogger()
        {
            List<AlarmForLoggerViewModel> list = new List<AlarmForLoggerViewModel>();
            Connect connect = new Connect();
            try
            {
                string sqlQuery = $"select Serial, Type, StartDate, EndDate, IsFinish, Content from t_History_Alarm_Logger order by StartDate";

                connect.Connected();

                SqlDataReader reader = connect.Select(sqlQuery);

                if(reader.HasRows)
                {
                    while(reader.Read())
                    {
                        AlarmForLoggerViewModel el = new AlarmForLoggerViewModel();

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
