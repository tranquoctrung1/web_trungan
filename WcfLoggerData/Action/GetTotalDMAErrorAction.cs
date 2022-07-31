using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Web;
using WcfLoggerData.ConnectDB;
using WcfLoggerData.Models;

namespace WcfLoggerData.Action
{
    public class GetTotalDMAErrorAction
    {
        public List<TotalDMAErrorModel> GetTotalDMAError()
        {
            List<TotalDMAErrorModel> list = new List<TotalDMAErrorModel>();

            Connect connect = new Connect();

            try
            {
                string store = "p_Total_DMA_Error";

                connect.Connected();

                SqlCommand command = connect.ExcuteStoreProceduce(store);

                SqlDataReader reader = command.ExecuteReader();

                if(reader.HasRows)
                {
                    while(reader.Read())
                    {
                        TotalDMAErrorModel el = new TotalDMAErrorModel();

                        try
                        {
                            el.Result = int.Parse(reader["Result"].ToString());
                        }
                        catch(Exception ex)
                        {
                            el.Result = 0;
                        }

                        try
                        {
                            el.DMA = reader["DMA"].ToString();
                        }
                        catch(Exception ex)
                        {
                            el.DMA = "";
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