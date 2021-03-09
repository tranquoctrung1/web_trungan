using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Web;
using WcfLoggerData.ConnectDB;
using WcfLoggerData.Models;

namespace WcfLoggerData.Action
{
    public class GetUserByUidAction
    {
        public UserViewModel GetUser(string uid)
        {
            UserViewModel u = new UserViewModel();

            Connect connect = new Connect();

            try
            {
                string sqlQuery = $"select Uid, StaffId, Pwd, Salt, Role, Active, TimeStamp, Ip, LogCount, Zoom, Company, Language from [t_User_Users] where Uid = '{uid}'";
                connect.Connected();

                SqlDataReader reader = connect.Select(sqlQuery);

                if(reader.HasRows)
                {
                    while(reader.Read())
                    {
                        try
                        {
                            u.Uid = reader["Uid"].ToString();
                        }
                        catch(Exception ex)
                        {
                            u.Uid = "";
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
                            u.StaffId = reader["StaffId"].ToString();
                        }
                        catch (Exception ex)
                        {
                            u.StaffId = "";
                        }
                        try
                        {
                            u.Pwd = reader["Pwd"].ToString();
                        }
                        catch (Exception ex)
                        {
                            u.Pwd = "";
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
                            u.Zoom = int.Parse(reader["Zoom"].ToString());
                        }
                        catch (Exception ex)
                        {
                            u.Zoom = null;
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
    }
}