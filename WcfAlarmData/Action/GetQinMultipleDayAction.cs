using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using WcfAlarmData.ConnectDB;

namespace WcfAlarmData.Action
{
    public class GetQinMultipleDayAction
    {
        public List<double?> GetQinMultipleDay(string dma, DateTime start , DateTime end)
        {
            List<double?> list = new List<double?>();
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
                if (reader.HasRows)
                {
                    while (reader.Read())
                    {
                        double? result = null;

                        try
                        {
                            result = double.Parse(reader["Value"].ToString());
                        }
                        catch (Exception ex)
                        {
                            result = null;
                        }
                        list.Add(result);
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
}
