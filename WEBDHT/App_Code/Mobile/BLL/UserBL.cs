using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Web;

/// <summary>
/// Summary description for UserBL
/// </summary>
public class UserBL: IDisposable
{
    private bool disposedValue = false;

    public t_Users GetUser(string username)
    {

        t_Users u = new t_Users();
        Connect connect = new Connect();

        try
        {
            string sqlQuery = "select Uid, StaffId, Pwd, Salt, Role, Active, TimeStamp, Ip, LogCount, Zoom, Company,  Language from t_User_Users where Uid = '"+username+"'" ;

            connect.Connected();

            SqlDataReader reader = connect.Select(sqlQuery);

            if(reader.HasRows)
            {
                while(reader.Read())
                {
                    try
                    {
                        u.Username = reader["Uid"].ToString();
                    }
                    catch(Exception ex)
                    {
                        u.Username = "";
                    }
                    try
                    {
                        u.StaffId = reader["StaffId"].ToString();
                    }
                    catch (Exception ex)
                    {
                        u.StaffId = "";
                    }
                    try
                    {
                        u.Password = reader["Pwd"].ToString();
                    }
                    catch (Exception ex)
                    {
                        u.Password = "";
                    }
                    try
                    {
                        u.Salt = reader["Salt"].ToString();
                    }
                    catch (Exception ex)
                    {
                        u.Salt = "";
                    }
                    try
                    {
                        u.Role = reader["Role"].ToString();
                    }
                    catch (Exception ex)
                    {
                        u.Role = "";
                    }
                    try
                    {
                        u.Active =bool.Parse( reader["Active"].ToString());
                    }
                    catch (Exception ex)
                    {
                        u.Active = null;
                    }
                    try
                    {
                        u.TimeStamp = DateTime.Parse(reader["TimeStamp"].ToString());
                    }
                    catch (Exception ex)
                    {
                        u.TimeStamp = null;
                    }
                    try
                    {
                        u.Ip = reader["Ip"].ToString();
                    }
                    catch (Exception ex)
                    {
                        u.Ip = "";
                    }
                    try
                    {
                        u.LogCount =int.Parse( reader["LogCount"].ToString());
                    }
                    catch (Exception ex)
                    {
                        u.LogCount = null;
                    }
                    try
                    {
                        u.Zoom = byte.Parse(reader["Zoom"].ToString());
                    }
                    catch (Exception ex)
                    {
                        u.Zoom = null;
                    }
                    try
                    {
                        u.Company = reader["Company"].ToString();
                    }
                    catch (Exception ex)
                    {
                        u.Company = "";
                    }
                    try
                    {
                        u.Language = reader["Language"].ToString();
                    }
                    catch (Exception ex)
                    {
                        u.Language = "";
                    }

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

        return u;
    }


    protected virtual void Dispose(bool disposing)
    {
        if (!this.disposedValue)
        {
            if (disposing)
            {
            }
        }
        this.disposedValue = true;
    }

    public void Dispose()
    {
        Dispose(true);
        GC.SuppressFinalize(this);
    }
}