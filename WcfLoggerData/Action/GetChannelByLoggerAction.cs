using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Web;
using WcfLoggerData.ConnectDB;
using WcfLoggerData.Models;

namespace WcfLoggerData.Action
{
    public class GetChannelByLoggerAction
    {
        public List<ChannelByLoggerViewModel> GetChannelByLogger(string loggerid)
        {
            List<ChannelByLoggerViewModel> list = new List<ChannelByLoggerViewModel>();
            Connect connect = new Connect();

            try
            {
                string store = "p_GetChannelByLoggerIdForMap";

                connect.Connected();

                SqlCommand command = connect.ExcuteStoreProceduce(store);

                command.Parameters.Add(new SqlParameter("@loggerid ", loggerid));

                SqlDataReader reader = command.ExecuteReader();

                if (reader.HasRows)
                {
                    while (reader.Read())
                    {
                        ChannelByLoggerViewModel el = new ChannelByLoggerViewModel();

                        int? timeDelay = null;
                        double? basemax = null;
                        double? basemin = null;
                        double? pressure = null;
                        bool check = false;
                        try
                        {
                            el.ChannelId = reader["Id"].ToString();
                        }
                        catch (Exception ex)
                        {
                            el.ChannelId = "";
                        }
                        try
                        {
                            el.ChannelName = reader["Name"].ToString();
                        }
                        catch (Exception ex)
                        {
                            el.ChannelName = "";
                        }
                        try
                        {
                            el.Unit = reader["Unit"].ToString();
                        }
                        catch (Exception ex)
                        {
                            el.Unit = "";
                        }
                        try
                        {
                            el.Press1 = bool.Parse(reader["Pressure1"].ToString());
                        }
                        catch (Exception ex)
                        {
                            el.Press1 = null;
                        }
                        try
                        {
                            el.Press2 = bool.Parse(reader["Pressure2"].ToString());
                        }
                        catch (Exception ex)
                        {
                            el.Press2 = null;
                        }
                        try
                        {
                            el.Flow1 = bool.Parse(reader["ForwardFlow"].ToString());
                        }
                        catch (Exception ex)
                        {
                            el.Flow1 = null;
                        }
                        try
                        {
                            el.Flow2 = bool.Parse(reader["ReverseFlow"].ToString());
                        }
                        catch (Exception ex)
                        {
                            el.Flow2 = null;
                        }
                        try
                        {
                            el.Timestamp = DateTime.Parse(reader["Timestamp"].ToString());
                        }
                        catch (Exception ex)
                        {
                            el.Timestamp = null;
                        }
                        try
                        {
                            el.Val = double.Parse(reader["LastValue"].ToString());
                        }
                        catch (Exception ex)
                        {
                            el.Val = null;
                        }
                        try
                        {
                            el.IndexTimestamp = DateTime.Parse(reader["IndexTimeStamp"].ToString());
                        }
                        catch (Exception ex)
                        {
                            el.IndexTimestamp = null;
                        }
                        try
                        {
                            el.LastIndex = double.Parse(reader["LastIndex"].ToString());
                        }
                        catch (Exception ex)
                        {
                            el.LastIndex = null;
                        }
                        try
                        {
                            el.GroupChannelStatus = int.Parse(reader["Status"].ToString());
                        }
                        catch (Exception ex)
                        {
                            el.GroupChannelStatus = 0;
                        }
                        el.DisplayLabel = true;

                        try
                        {
                            timeDelay = int.Parse(reader["DelayTime"].ToString());
                        }
                        catch (Exception ex)
                        {
                            timeDelay = 60;
                        }
                        try
                        {
                            basemax = double.Parse(reader["BaseMax"].ToString());
                        }
                        catch (Exception ex)
                        {
                            basemax = null;
                        }
                        try
                        {
                            basemin = double.Parse(reader["BaseMin"].ToString());
                        }
                        catch (Exception ex)
                        {
                            basemin = null;
                        }
                        if(el.Press1 == true || el.Press2 == true)
                        {
                            pressure = el.Val;
                        }

                        el.Status = 1;
                        if(el.Timestamp == null)
                        {
                            el.Status = 2;
                            check = true;
                        }
                        if (check == false)
                        {
                            if (timeDelay != null)
                            {
                                if (el.Timestamp != null)
                                {
                                    if ((DateTime.Now - el.Timestamp.Value).TotalMinutes > timeDelay)
                                    {
                                        el.Status = 4;
                                        check = true;
                                    }
                                }
                            }
                        }
                        if(check == false )
                        {
                            if(pressure != null)
                            {
                                if(pressure <= 0)
                                {
                                    el.Status = 2;
                                    check = true;
                                }
                            }
                        }
                        if (check == false)
                        {
                            if (basemin != null)
                            {
                                if (el.Val < basemin)
                                {
                                    el.Status = 2;
                                    check = true;
                                }
                            }
                        }
                        if (check == false)
                        {
                            if (basemax != null)
                            {
                                if (el.Val > basemax.Value)
                                {
                                    el.Status = 2;
                                    check = true;
                                }
                            }
                        }
                        if(check == false)
                        {
                            if (el.Timestamp != null)
                            {
                                GetHistoryDataLoggerAtOneTimeAction getHistoryDataLoggerAtOneTimeAction = new GetHistoryDataLoggerAtOneTimeAction();

                                var data = getHistoryDataLoggerAtOneTimeAction.GetHistoryDataLoggerAtOneTime(el.ChannelId, el.Timestamp.Value);

                                if(data.Value != null)
                                {
                                    if((el.Val / data.Value.Value) >= 0.3)
                                    {
                                        el.Status = 3;
                                        check = true;
                                    }
                                }
                            }
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