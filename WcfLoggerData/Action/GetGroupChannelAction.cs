using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Web;
using WcfLoggerData.ConnectDB;
using WcfLoggerData.Models;

namespace WcfLoggerData.Action
{
    public class GetGroupChannelAction
    {
        public List<GroupChannelViewModel> GetGroupChannel()
        {
            List<GroupChannelViewModel> list = new List<GroupChannelViewModel>();
            Connect connect = new Connect();
            try
            {
                string sqlQuery = $"select GroupChannel, Description, Status from t_GroupChannel";

                connect.Connected();

                SqlDataReader reader = connect.Select(sqlQuery);

                if(reader.HasRows)
                {
                    while(reader.Read())
                    {
                        GroupChannelViewModel el = new GroupChannelViewModel();
                        try
                        {
                            el.GroupChannel = reader["GroupChannel"].ToString();
                        }
                        catch(Exception ex)
                        {
                            el.GroupChannel = "";
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
                            el.Status = bool.Parse(reader["Status"].ToString());
                        }
                        catch (Exception ex)
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
    }
}