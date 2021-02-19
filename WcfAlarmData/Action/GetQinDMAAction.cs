using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using WcfAlarmData.ConnectDB;

namespace WcfAlarmData.Action
{
    public class GetQinDMAAction
    {
        public double? GetQinDMA(string dma, DateTime start, DateTime end)
        {
            double? result = null;

            Connect connect = new Connect();

            try
            {
                string store = "p_Calculate_One_Company_Output";

                connect.Connected();

                SqlCommand command = connect.ExcuteStoreProceduce(store);
                command.Parameters.Add(new SqlParameter("@Company", dma));
                command.Parameters.Add(new SqlParameter("@StartDate", start));
                command.Parameters.Add(new SqlParameter("@EndDate", end));

                SqlDataReader reader = command.ExecuteReader();
                if(reader.HasRows)
                {
                    while(reader.Read())
                    {
                        try
                        {
                            result = double.Parse(reader["Value"].ToString());
                        }
                        catch(Exception ex)
                        {
                            result = null;
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
