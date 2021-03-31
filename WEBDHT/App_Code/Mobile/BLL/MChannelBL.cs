using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Web;

/// <summary>
/// Summary description for MChannelBL
/// </summary>
public class MChannelBL
{
    public List<MChannel> GetChannelsConfiguration(string loggerid, int delaytime)
    {
        List<MChannel> list = new List<MChannel>();

        Connect connect = new Connect();

        try
        {

            string store = "p_GetChannelByLoggerIdForMap";

            connect.Connected();

            SqlCommand command = connect.ExcuteStoreProceduce(store);

            command.Parameters.Add(new SqlParameter("@loggerid", loggerid));

            SqlDataReader reader = command.ExecuteReader();

            if (reader.HasRows)
            {
                while (reader.Read())
                {
                    MChannel el = new MChannel();
                    double? basemin = null;
                    double? basemax = null;
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
                        el.LoggerId = reader["LoggerId"].ToString();
                    }
                    catch (Exception ex)
                    {
                        el.LoggerId = "";
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
                        el.Description = reader["Description"].ToString();
                    }
                    catch (Exception ex)
                    {
                        el.Description = "";
                    }
                    try
                    {
                        el.GroupChannel = reader["GroupChannel"].ToString();
                    }
                    catch (Exception ex)
                    {
                        el.GroupChannel = "";
                    }
                    try
                    {
                        el.Pressure1 = bool.Parse(reader["Pressure1"].ToString());
                    }
                    catch (Exception ex)
                    {
                        el.Pressure1 = null;
                    }
                    try
                    {
                        el.Pressure2 = bool.Parse(reader["Pressure2"].ToString());
                    }
                    catch (Exception ex)
                    {
                        el.Pressure2 = null;
                    }
                    try
                    {
                        el.ForwardFlow = bool.Parse(reader["ForwardFlow"].ToString());
                    }
                    catch (Exception ex)
                    {
                        el.ForwardFlow = null;
                    }
                    try
                    {
                        el.ReverseFlow = bool.Parse(reader["ReverseFlow"].ToString());
                    }
                    catch (Exception ex)
                    {
                        el.ReverseFlow = null;
                    }
                    try
                    {
                        el.TimeStamp = (reader["TimeStamp"] == null ? "NO DATA" : DateTime.Parse(reader["TimeStamp"].ToString()).ToString("dd/MM/yyyy HH:mm"));
                    }
                    catch (Exception ex)
                    {
                        el.TimeStamp = "NO DATA";
                    }
                    try
                    {
                        el.LastValue = (reader["LastValue"] == null ? "NO DATA" : double.Parse(reader["LastValue"].ToString()).ToString());
                    }
                    catch (Exception ex)
                    {
                        el.LastValue = "NO DATA";
                    }
                    try
                    {
                        el.IndexTimeStamp = (reader["IndexTimeStamp"] == null ? "NO DATA" : DateTime.Parse(reader["IndexTimeStamp"].ToString()).ToString("dd/MM/yyyy HH:mm"));
                    }
                    catch (Exception ex)
                    {
                        el.IndexTimeStamp = "NO DATA";
                    }
                    try
                    {
                        el.LastIndex = (reader["LastIndex"] == null ? "NO DATA" : double.Parse(reader["LastIndex"].ToString()).ToString());
                    }
                    catch (Exception ex)
                    {
                        el.LastIndex = "NO DATA";
                    }
                    try
                    {
                        el.yyyy = (reader["TimeStamp"] == null ? "NO DATA" : DateTime.Parse(reader["TimeStamp"].ToString()).Year.ToString());
                    }
                    catch(Exception ex)
                    {
                        el.yyyy = "NO DATA";
                    }
                    try
                    {
                        el.MM = (reader["TimeStamp"] == null ? "NO DATA" : DateTime.Parse(reader["TimeStamp"].ToString()).Month.ToString());
                    }
                    catch (Exception ex)
                    {
                        el.MM = "NO DATA";
                    }
                    try
                    {
                        el.dd = (reader["TimeStamp"] == null ? "NO DATA" : DateTime.Parse(reader["TimeStamp"].ToString()).Day.ToString());
                    }
                    catch(Exception ex)
                    {
                        el.dd = "NO DATA";
                    }
                    try
                    {
                        el.HH = (reader["TimeStamp"] == null ? "NO DATA" : DateTime.Parse(reader["TimeStamp"].ToString()).Hour.ToString());
                    }
                    catch(Exception ex)
                    {
                        el.HH = "NO DATA";
                    }
                    try
                    {
                        el.mm = (reader["TimeStamp"] == null ? "NO DATA" : DateTime.Parse(reader["TimeStamp"].ToString()).Minute.ToString());
                    }
                    catch(Exception ex)
                    {
                        el.mm = "NO DATA";
                    }
                    try
                    {
                        basemax = double.Parse(reader["BaseMax"].ToString());
                    }
                    catch(Exception ex)
                    {
                        basemax = null;
                    }
                    try
                    {
                        basemin = double.Parse(reader["BaseMin"].ToString());
                    }
                    catch(Exception ex)
                    {
                        basemin = null;
                    }
                    int status = 0;
                    bool check = false;
                    if (reader["TimeStamp"] == null)
                    {
                        status = 4;
                        check = true;
                    }
                    if(check == false)
                    {
                        if(el.LastValue != "NO DATA")
                        {
                            if (basemax != null)
                            {
                                if (double.Parse(el.LastValue) > basemax)
                                {
                                    status = 4;
                                    check = true;
                                }
                            }
                        }
                       
                    }
                    if(check ==  false)
                    {
                        if (el.LastValue != "NO DATA")
                        {
                            if (basemin != null)
                            {
                                if (double.Parse(el.LastValue) < basemin)
                                {
                                    status = 4;
                                    check = true;
                                }
                            }
                        }
                            
                    }
                    if (check == false)
                    {
                        if (el.TimeStamp  != "NO DATA")
                        {
                            if ((DateTime.Now - DateTime.Parse(reader["TimeStamp"].ToString())).TotalMinutes > delaytime)
                            {
                                status = 2;
                                check = true;
                            }
                        }
                    }
                    if (check == false)
                    {
                        status = 1;
                    }
                    el.Status = status;
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