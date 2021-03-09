using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Web;
using WcfLoggerData.ConnectDB;
using WcfLoggerData.Models;

namespace WcfLoggerData.Action
{
    public class GetDistrictBySupervisorIdAction
    {
        public List<DistrictViewModel> GetDistrictBySupervisorId(string id)
        {

            // get staff id of user 

            GetUserByUidAction action = new GetUserByUidAction();

            UserViewModel user = action.GetUser(id);


            List<DistrictViewModel> list = new List<DistrictViewModel>();

            Connect connect = new Connect();

            try
            {
                string sqlQuery = $"select d.[IdDistrict], d.[Name], d.[Description] from t_Supervisor_District sd join [t_District] d on d.[IdDistrict] = sd.[IdDistrict] where sd.[IdStaff] = '{user.StaffId}'";

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
                        catch (Exception ex)
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