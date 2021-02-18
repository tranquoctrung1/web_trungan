using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using WcfAlarmData.ConnectDB;
using WcfLoggerData.Models;

namespace WcfAlarmData.Action
{
    class GetAllAlarmForPointAction
    {
        public List<AlarmForPointViewModel> GetAllAlarmForPoint()
        {
            List<AlarmForPointViewModel> list = new List<AlarmForPointViewModel>();
            Connect connect = new Connect();

            try
            {
                string sqlQuery = $"select [ChannelId], [Location], [StartDateAlarm], [EndDateAlarm], [TypeAlarm], [Level], [IsFinish], [Content] from [t_History_Alarm] order by StartDateAlarm";

                connect.Connected();

                SqlDataReader reader = connect.Select(sqlQuery);

                if(reader.HasRows)
                {
                    while(reader.Read())
                    {
                        AlarmForPointViewModel el = new AlarmForPointViewModel();
                        try
                        {
                            el.ChannelId = reader["ChannelId"].ToString();
                        }
                        catch(Exception ex)
                        {
                            el.ChannelId = "";
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
                            el.StartDateAlarm =DateTime.Parse(reader["StartDateAlarm"].ToString());
                        }
                        catch (Exception ex)
                        {
                            el.StartDateAlarm = null;
                        }
                        try
                        {
                            el.EndDateAlarm = DateTime.Parse(reader["EndDateAlarm"].ToString());
                        }
                        catch (Exception ex)
                        {
                            el.EndDateAlarm = null;
                        }
                        try
                        {
                            el.TypeAlarm = int.Parse(reader["TypeAlarm"].ToString());
                        }
                        catch (Exception ex)
                        {
                            el.TypeAlarm = null;
                        }
                        try
                        {
                            el.Level = reader["Level"].ToString();
                        }
                        catch (Exception ex)
                        {
                            el.Level = null;
                        }
                        try
                        {
                            el.IsFinish =bool.Parse(reader["IsFinish"].ToString());
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
                            el.Content = null;
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
