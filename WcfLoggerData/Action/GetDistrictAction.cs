using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Web;
using WcfLoggerData.ConnectDB;
using WcfLoggerData.Models;

namespace WcfLoggerData.Action
{
    public class GetDistrictAction
    {
        public List<DistrictViewModel> GetDistrict()
        {

            List<DistrictViewModel> list = new List<DistrictViewModel>();
            Connect connect = new Connect();

            try
            {
                string sqlQuery = $"select IdDistrict, Name, Description from t_District";

                connect.Connected();

                SqlDataReader reader = connect.Select(sqlQuery);

                if(reader.HasRows)
                {
                    while(reader.Read())
                    {
                        DistrictViewModel el = new DistrictViewModel();

                        try
                        {
                            el.IdDistrict = reader["IdDistrict"].ToString();
                        }
                        catch(Exception ex)
                        {
                            el.IdDistrict = "";
                        }
                        try
                        {
                            el.Name = reader["Name"].ToString();
                        }
                        catch(Exception ex)
                        {
                            el.Name = "";
                        }
                        try
                        {
                            el.Description = reader["Description"].ToString();
                        }
                        catch(Exception ex)
                        {
                            el.Description = "";
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