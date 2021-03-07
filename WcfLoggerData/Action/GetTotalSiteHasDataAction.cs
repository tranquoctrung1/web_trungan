using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Web;
using WcfLoggerData.ConnectDB;

namespace WcfLoggerData.Action
{
    public class GetTotalSiteHasDataAction
    {
        public int GetTotalSiteHasData()
        {
            int result = 0;
            Connect connect = new Connect();
            try
            {
                string store = "p_Total_Site_Has_Data";

                connect.Connected();

                SqlCommand command = connect.ExcuteStoreProceduce(store);

                SqlDataReader reader = command.ExecuteReader();

                if (reader.HasRows)
                {
                    while (reader.Read())
                    {
                        try
                        {
                            result = int.Parse(reader["Result"].ToString());
                        }
                        catch (Exception ex)
                        {
                            result = 0;
                        }
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

            return result;
        }
    }
}