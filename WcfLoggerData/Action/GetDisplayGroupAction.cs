using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Web;
using WcfLoggerData.ConnectDB;

namespace WcfLoggerData.Action
{
    public class GetDisplayGroupAction
    {
        public List<string> GetDisplayGroup()
        {
            List<string> list = new List<string>();

            try
            {
                string sqlQuery = $"select Company from t_Site_Companies";

                Connect.ConnectToDataBase();

                SqlDataReader reader = Connect.Select(sqlQuery);

                if(reader.HasRows)
                {
                    while(reader.Read())
                    {
                        string company = "";
                        try
                        {
                            company = reader["Company"].ToString();
                        }
                        catch(Exception ex)
                        {
                            company = "";
                        }

                        list.Add(company);
                    }
                }
            }
            catch(SqlException ex)
            {
                throw ex;
            }
            finally
            {
                //Connect.DisconnectToDataBase();
            }

            return list;
        }
    }
}