using WcfLoggerData.ConnectDB;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Data.SqlClient;

namespace WcfLoggerData.Action
{
    public class GetTotalSiteActionAction
    {
        public int GetTotalSiteAction()
        {
            int result = 0;
            Connect connect = new Connect();
            try
            {
                string store = "p_Total_Site_Action";

                connect.Connected();

                SqlCommand command = connect.ExcuteStoreProceduce(store);

                SqlDataReader reader = command.ExecuteReader();

                if(reader.HasRows)
                {
                    while(reader.Read())
                    {
                        try
                        {
                            result = int.Parse( reader["Result"].ToString());
                        }
                        catch(Exception ex)
                        {
                            result = 0;
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

            return result;
        }
    }
}