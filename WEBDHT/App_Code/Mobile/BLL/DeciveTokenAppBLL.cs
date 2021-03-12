using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Web;

/// <summary>
/// Summary description for DeciveTokenAppBLL
/// </summary>
public class DeciveTokenAppBLL
{
    public List<DeviceTokenApp> GetDeviceTokenApps (string siteid)
    {
        List<DeviceTokenApp> list = new List<DeviceTokenApp>();

        Connect connect = new Connect();

        try
        {
            string store = "p_GetDataDeviceToken";

            connect.Connected();

            SqlCommand command = connect.ExcuteStoreProceduce(store);
            command.Parameters.Add(new SqlParameter("@SiteId", siteid));

            SqlDataReader reader = command.ExecuteReader();

            if(reader.HasRows)
            {
                while(reader.Read())
                {
                    DeviceTokenApp el = new DeviceTokenApp();

                    try
                    {
                        el.DeviceToken = reader["DeviceToken"].ToString();
                    }
                    catch(Exception ex)
                    {
                        el.DeviceToken = "";
                    }
                    try
                    {
                        el.UserName = reader["Username"].ToString();
                    }
                    catch(Exception ex)
                    {
                        el.UserName = "";
                    }
                    try
                    {
                        el.Status = bool.Parse(reader["Status"].ToString());
                    }
                    catch(Exception ex)
                    {
                        el.Status = false;
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

    public int UpdatePushNotification(string token, bool status)
    {
        int result = 0;

        Connect connect = new Connect();

        try
        {
            string store = "UpdateStatusPushNoti";

            connect.Connected();

            SqlCommand command = connect.ExcuteStoreProceduce(store);
            command.Parameters.Add(new SqlParameter("@Token", token));
            command.Parameters.Add(new SqlParameter("@Status", status));


            result = command.ExecuteNonQuery();
        }
        catch(SqlException ex)
        {
            throw ex;
        }
        finally
        {
            connect.DisConnected();
        }

        return result;
    }

    public int RemoveDeviceTokenApp(string token)
    {
        int result = 0;

        Connect connect = new Connect();

        try
        {
            string store = "p_RemoveTokenLogoutApp";

            connect.Connected();

            SqlCommand command = connect.ExcuteStoreProceduce(store);
            command.Parameters.Add(new SqlParameter("@Token", token));


            result = command.ExecuteNonQuery();
        }
        catch (SqlException ex)
        {
            throw ex;
        }
        finally
        {
            connect.DisConnected();
        }

        return result;
    }

    public int InsertDeviceTokenApp(string username, string token)
    {
        int result = 0;

        Connect connect = new Connect();

        try
        {
            string store = "InsertDeviceToken";

            connect.Connected();

            SqlCommand command = connect.ExcuteStoreProceduce(store);
            command.Parameters.Add(new SqlParameter("@UserName", username));
            command.Parameters.Add(new SqlParameter("@Token", token));

            result = command.ExecuteNonQuery();
        }
        catch (SqlException ex)
        {
            throw ex;
        }
        finally
        {
            connect.DisConnected();
        }

        return result;
    }
}