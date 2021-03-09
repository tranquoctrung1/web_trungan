using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Web;
using WcfLoggerData.ConnectDB;
using WcfLoggerData.Models;

namespace WcfLoggerData.Action
{
    public class GetDisplayGroupByUidAction
    {
        public List<string> GetDisplayGroupByUid(string uid)
        {
            List<string> list = new List<string>();

            GetUserByUidAction action = new GetUserByUidAction();

            UserViewModel u = action.GetUser(uid);

            Connect connect = new Connect();

            try
            {
                string sqlQuery = $"select IdDMA from t_DMA_DMA where IdStaff = '{u.StaffId}'";

                connect.Connected();

                SqlDataReader reader = connect.Select(sqlQuery);

                if(reader.HasRows)
                {
                    while(reader.Read())
                    {
                        string el = "";

                        try
                        {
                            el = reader["IdDMA"].ToString();
                        }
                        catch (Exception ex)
                        {
                            el = "";
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