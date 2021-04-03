using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Web;
using WcfLoggerData.ConnectDB;
using WcfLoggerData.Models;

namespace WcfLoggerData.Action
{
    public class GetDataDetailTableAction
    {
        public List<DetailTableViewModel> GetDetailTable(string siteid, string start, string end)
        {
            List<DetailTableViewModel> list = new List<DetailTableViewModel>();

            DateTime startDate = new DateTime(1970, 01, 01).AddHours(7).AddSeconds(int.Parse(start));
            DateTime endDate = new DateTime(1970, 01, 01).AddHours(7).AddSeconds(int.Parse(end));

            Connect connect = new Connect();

            while(DateTime.Compare(startDate, endDate) <= 0)
            {
                try
                {
                    string store = "p_Get_Data_Detail_Table";

                    connect.Connected();

                    SqlCommand command = connect.ExcuteStoreProceduce(store);
                    command.Parameters.Add(new SqlParameter("@siteid", siteid));
                    command.Parameters.Add(new SqlParameter("@start", startDate));

                    SqlDataReader reader = command.ExecuteReader();
                    if(reader.HasRows)
                    {
                        while(reader.Read())
                        {
                            DetailTableViewModel el = new DetailTableViewModel();
                            try
                            {
                                el.TimeStamp = DateTime.Parse(reader["TimeStamp"].ToString());
                            }
                            catch(Exception ex)
                            {
                                el.TimeStamp = null;
                            }
                            try
                            {
                                el.Pressure = double.Parse(reader["Pressure"].ToString());
                            }
                            catch (Exception ex)
                            {
                                el.Pressure = null;
                            }
                            try
                            {
                                el.Flow = double.Parse(reader["Flow"].ToString());
                            }
                            catch (Exception ex)
                            {
                                el.Flow = null;
                            }
                            try
                            {
                                el.IndexForward = double.Parse(reader["IndexForward"].ToString());
                            }
                            catch (Exception ex)
                            {
                                el.IndexForward = null;
                            }
                            try
                            {
                                el.IndexReverse = double.Parse(reader["IndexReverse"].ToString());
                            }
                            catch (Exception ex)
                            {
                                el.IndexReverse = null;
                            }
                            try
                            {
                                el.IndexNet = double.Parse(reader["IndexNet"].ToString());
                            }
                            catch (Exception ex)
                            {
                                el.IndexNet = null;
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


                startDate = startDate.AddDays(1);
            }

            return list;
        }
    }
}