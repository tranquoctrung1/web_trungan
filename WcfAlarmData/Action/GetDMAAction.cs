using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using WcfAlarmData.ConnectDB;
using WcfAlarmData.Model;

namespace WcfAlarmData.Action
{
    class GetDMAAction
    {
        public List<DMAViewModel> GetDMA()
        {
            List<DMAViewModel> list = new List<DMAViewModel>();
            Connect connect = new Connect();
            try
            {
                string sqlQuery = $"select Company, Production, Description, Status, District, Ward, AmountDHTKH, AmountValve, AmountPool, AmountTCH, NRW from  t_Site_Companies where Company is not null order by Company ";

                connect.Connected();

                SqlDataReader reader = connect.Select(sqlQuery);
                if(reader.HasRows)
                {
                    while(reader.Read())
                    {
                        DMAViewModel el = new DMAViewModel();
                        try
                        {
                            el.Company = reader["Company"].ToString();
                        }
                        catch(Exception ex)
                        {
                            el.Company = "";
                        }
                        try
                        {
                            el.Production =bool.Parse( reader["Production"].ToString());
                        }
                        catch (Exception ex)
                        {
                            el.Production = null;
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
                            el.Status = reader["Status"].ToString();
                        }
                        catch (Exception ex)
                        {
                            el.Status = "";
                        }
                        try
                        {
                            el.Disctrict = reader["Disctrict"].ToString();
                        }
                        catch (Exception ex)
                        {
                            el.Disctrict = "";
                        }
                        try
                        {
                            el.Ward = reader["Ward"].ToString();
                        }
                        catch (Exception ex)
                        {
                            el.Ward = "";
                        }
                        try
                        {
                            el.AmountDHTKH = int.Parse(reader["AmountDHTKH"].ToString());
                        }
                        catch (Exception ex)
                        {
                            el.AmountDHTKH = null;
                        }
                        try
                        {
                            el.AmountValve = int.Parse(reader["AmountValve"].ToString());
                        }
                        catch (Exception ex)
                        {
                            el.AmountValve = null;
                        }
                        try
                        {
                            el.AmountPool = int.Parse(reader["AmountPool"].ToString());
                        }
                        catch (Exception ex)
                        {
                            el.AmountPool = null;
                        }
                        try
                        {
                            el.AmountTCH = int.Parse(reader["AmountTCH"].ToString());
                        }
                        catch (Exception ex)
                        {
                            el.AmountTCH = null;
                        }
                        try
                        {
                            el.NRW = double.Parse(reader["Pressure1"].ToString());
                        }
                        catch (Exception ex)
                        {
                            el.NRW = null;
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
