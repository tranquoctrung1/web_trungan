using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Web;

/// <summary>
/// Summary description for SiteBL
/// </summary>
public class SiteBL
{
   public List<t_SiteCustomer> GetSitesForMapByConsumerIdCustom(string consumerid)
    {
        List<t_SiteCustomer> list = new List<t_SiteCustomer>();

        Connect connect = new Connect();

        try
        {
            string sqlQuery = "select s.[Id], s.[OldId], s.[Location], s.[Longitude], s.[Latitude], ds.[Id] as Logger, s.[Address], s.[District], s.[Company], s.[Status], s.[Availability], ds.[DelayTime]  from [t_Site_Sites] s join [t_Devices_SitesConfigs] ds on ds.[SiteId] = s.[Id] join [t_Site_Consumer] c on c.[SiteId] = s.[Id] where c.[ConsumerId] = '" + consumerid+"'";

            connect.Connected();

            SqlDataReader reader = connect.Select(sqlQuery);

            if(reader.HasRows)
            {
                while(reader.Read())
                {
                    t_SiteCustomer el = new t_SiteCustomer();
                    try
                    {
                        el.Id = reader["Id"].ToString();
                    }
                    catch(Exception ex)
                    {
                        el.Id = "";
                    }
                    try
                    {
                        el.OldId = reader["OldId"].ToString();
                    }
                    catch (Exception ex)
                    {
                        el.OldId = "";
                    }
                    try
                    {
                        el.Location = reader["Location"].ToString();
                    }
                    catch (Exception ex)
                    {
                        el.Location = "";
                    }
                    try
                    {
                        el.Longitude =double.Parse (reader["Longitude"].ToString());
                    }
                    catch (Exception ex)
                    {
                        el.Longitude = null;
                    }
                    try
                    {
                        el.Latitude = double.Parse(reader["Latitude"].ToString());
                    }
                    catch (Exception ex)
                    {
                        el.Latitude = null;
                    }
                    try
                    {
                        el.Logger = reader["Logger"].ToString();
                    }
                    catch (Exception ex)
                    {
                        el.Logger = "";
                    }
                    try
                    {
                        el.Address = reader["Address"].ToString();
                    }
                    catch (Exception ex)
                    {
                        el.Address = "";
                    }
                    try
                    {
                        el.District = reader["District"].ToString();
                    }
                    catch (Exception ex)
                    {
                        el.District = "";
                    }
                    try
                    {
                        el.Company = reader["Company"].ToString();
                    }
                    catch (Exception ex)
                    {
                        el.Company = "";
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
                        el.Availability = reader["Availability"].ToString();
                    }
                    catch (Exception ex)
                    {
                        el.Availability = "";
                    }
                    try
                    {
                        el.SetDelayTime =int.Parse( reader["DelayTime"].ToString());
                    }
                    catch(Exception ex)
                    {
                        el.SetDelayTime = null;
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

    public List<t_SiteCustomer> GetSitesForMapByConsumerIdCustomLimit(string consumerid)
    {
        List<t_SiteCustomer> list = new List<t_SiteCustomer>();

        Connect connect = new Connect();

        try
        {
            string sqlQuery = "select top(50) s.[Id], s.[OldId], s.[Location], s.[Longitude], s.[Latitude], ds.[Id] as Logger, s.[Address], s.[District], s.[Company], s.[Status], s.[Availability], ds.[DelayTime]  from [t_Site_Sites] s join [t_Devices_SitesConfigs] ds on ds.[SiteId] = s.[Id] join [t_Site_Consumer] c on c.[SiteId] = s.[Id] where c.[ConsumerId] = '" + consumerid + "'";

            connect.Connected();

            SqlDataReader reader = connect.Select(sqlQuery);

            if (reader.HasRows)
            {
                while (reader.Read())
                {
                    t_SiteCustomer el = new t_SiteCustomer();
                    try
                    {
                        el.Id = reader["Id"].ToString();
                    }
                    catch (Exception ex)
                    {
                        el.Id = "";
                    }
                    try
                    {
                        el.OldId = reader["OldId"].ToString();
                    }
                    catch (Exception ex)
                    {
                        el.OldId = "";
                    }
                    try
                    {
                        el.Location = reader["Location"].ToString();
                    }
                    catch (Exception ex)
                    {
                        el.Location = "";
                    }
                    try
                    {
                        el.Longitude = double.Parse(reader["Longitude"].ToString());
                    }
                    catch (Exception ex)
                    {
                        el.Longitude = null;
                    }
                    try
                    {
                        el.Latitude = double.Parse(reader["Latitude"].ToString());
                    }
                    catch (Exception ex)
                    {
                        el.Latitude = null;
                    }
                    try
                    {
                        el.Logger = reader["Logger"].ToString();
                    }
                    catch (Exception ex)
                    {
                        el.Logger = "";
                    }
                    try
                    {
                        el.Address = reader["Address"].ToString();
                    }
                    catch (Exception ex)
                    {
                        el.Address = "";
                    }
                    try
                    {
                        el.District = reader["District"].ToString();
                    }
                    catch (Exception ex)
                    {
                        el.District = "";
                    }
                    try
                    {
                        el.Company = reader["Company"].ToString();
                    }
                    catch (Exception ex)
                    {
                        el.Company = "";
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
                        el.Availability = reader["Availability"].ToString();
                    }
                    catch (Exception ex)
                    {
                        el.Availability = "";
                    }
                    try
                    {
                        el.SetDelayTime = int.Parse(reader["DelayTime"].ToString());
                    }
                    catch (Exception ex)
                    {
                        el.SetDelayTime = null;
                    }

                    list.Add(el);
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


    public List<t_SiteCustomer> GetSitesForMapByStaffIdCustom(string staffId)
    {
        List<t_SiteCustomer> list = new List<t_SiteCustomer>();

        Connect connect = new Connect();

        try
        {
            string sqlQuery = "select s.[Id], s.[OldId], s.[Location], s.[Longitude], s.[Latitude], ds.[Id] as Logger, s.[Address], s.[District], s.[Company], s.[Status], s.[Availability], ds.[DelayTime]  from [t_Site_Sites] s join [t_Devices_SitesConfigs] ds on ds.[SiteId] = s.[Id] join [t_Site_Consumer] c on c.[SiteId] = s.[Id] where c.[ConsumerId] = '" + staffId + "'";

            connect.Connected();

            SqlDataReader reader = connect.Select(sqlQuery);

            if (reader.HasRows)
            {
                while (reader.Read())
                {
                    t_SiteCustomer el = new t_SiteCustomer();
                    try
                    {
                        el.Id = reader["Id"].ToString();
                    }
                    catch (Exception ex)
                    {
                        el.Id = "";
                    }
                    try
                    {
                        el.OldId = reader["OldId"].ToString();
                    }
                    catch (Exception ex)
                    {
                        el.OldId = "";
                    }
                    try
                    {
                        el.Location = reader["Location"].ToString();
                    }
                    catch (Exception ex)
                    {
                        el.Location = "";
                    }
                    try
                    {
                        el.Longitude = double.Parse(reader["Longitude"].ToString());
                    }
                    catch (Exception ex)
                    {
                        el.Longitude = null;
                    }
                    try
                    {
                        el.Latitude = double.Parse(reader["Latitude"].ToString());
                    }
                    catch (Exception ex)
                    {
                        el.Latitude = null;
                    }
                    try
                    {
                        el.Logger = reader["Logger"].ToString();
                    }
                    catch (Exception ex)
                    {
                        el.Logger = "";
                    }
                    try
                    {
                        el.Address = reader["Address"].ToString();
                    }
                    catch (Exception ex)
                    {
                        el.Address = "";
                    }
                    try
                    {
                        el.District = reader["District"].ToString();
                    }
                    catch (Exception ex)
                    {
                        el.District = "";
                    }
                    try
                    {
                        el.Company = reader["Company"].ToString();
                    }
                    catch (Exception ex)
                    {
                        el.Company = "";
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
                        el.Availability = reader["Availability"].ToString();
                    }
                    catch (Exception ex)
                    {
                        el.Availability = "";
                    }
                    try
                    {
                        el.SetDelayTime = int.Parse(reader["DelayTime"].ToString());
                    }
                    catch (Exception ex)
                    {
                        el.SetDelayTime = null;
                    }

                    list.Add(el);
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

    public List<t_SiteCustomer> GetSitesForMapByStaffIdCustomLimit(string staffId)
    {
        List<t_SiteCustomer> list = new List<t_SiteCustomer>();

        Connect connect = new Connect();

        try
        {
            string sqlQuery = "select top(50) s.[Id], s.[OldId], s.[Location], s.[Longitude], s.[Latitude], ds.[Id] as Logger, s.[Address], s.[District], s.[Company], s.[Status], s.[Availability], ds.[DelayTime]  from [t_Site_Sites] s join [t_Devices_SitesConfigs] ds on ds.[SiteId] = s.[Id] join [t_Site_Consumer] c on c.[SiteId] = s.[Id] where c.[ConsumerId] = '" + staffId + "'";

            connect.Connected();

            SqlDataReader reader = connect.Select(sqlQuery);

            if (reader.HasRows)
            {
                while (reader.Read())
                {
                    t_SiteCustomer el = new t_SiteCustomer();
                    try
                    {
                        el.Id = reader["Id"].ToString();
                    }
                    catch (Exception ex)
                    {
                        el.Id = "";
                    }
                    try
                    {
                        el.OldId = reader["OldId"].ToString();
                    }
                    catch (Exception ex)
                    {
                        el.OldId = "";
                    }
                    try
                    {
                        el.Location = reader["Location"].ToString();
                    }
                    catch (Exception ex)
                    {
                        el.Location = "";
                    }
                    try
                    {
                        el.Longitude = double.Parse(reader["Longitude"].ToString());
                    }
                    catch (Exception ex)
                    {
                        el.Longitude = null;
                    }
                    try
                    {
                        el.Latitude = double.Parse(reader["Latitude"].ToString());
                    }
                    catch (Exception ex)
                    {
                        el.Latitude = null;
                    }
                    try
                    {
                        el.Logger = reader["Logger"].ToString();
                    }
                    catch (Exception ex)
                    {
                        el.Logger = "";
                    }
                    try
                    {
                        el.Address = reader["Address"].ToString();
                    }
                    catch (Exception ex)
                    {
                        el.Address = "";
                    }
                    try
                    {
                        el.District = reader["District"].ToString();
                    }
                    catch (Exception ex)
                    {
                        el.District = "";
                    }
                    try
                    {
                        el.Company = reader["Company"].ToString();
                    }
                    catch (Exception ex)
                    {
                        el.Company = "";
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
                        el.Availability = reader["Availability"].ToString();
                    }
                    catch (Exception ex)
                    {
                        el.Availability = "";
                    }
                    try
                    {
                        el.SetDelayTime = int.Parse(reader["DelayTime"].ToString());
                    }
                    catch (Exception ex)
                    {
                        el.SetDelayTime = null;
                    }

                    list.Add(el);
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

    public List<t_SiteCustomer> GetSiteForMapBySupervisorCustom(string supervisorId)
    {
        List<t_SiteCustomer> list = new List<t_SiteCustomer>();

        Connect connect = new Connect();

        try
        {
            string sqlQuery = "select s.[Id], s.[OldId], s.[Location], s.[Longitude], s.[Latitude], ds.[Id] as Logger, s.[Address], s.[District], s.[Company], s.[Status], s.[Availability], ds.[DelayTime]  from [t_Site_Sites] s join [t_Devices_SitesConfigs] ds on ds.[SiteId] = s.[Id] join [t_Supervisor_District] c on c.[IdDistrict] = s.[District] where c.[IdStaff] = '" + supervisorId + "'";

            connect.Connected();

            SqlDataReader reader = connect.Select(sqlQuery);

            if (reader.HasRows)
            {
                while (reader.Read())
                {
                    t_SiteCustomer el = new t_SiteCustomer();
                    try
                    {
                        el.Id = reader["Id"].ToString();
                    }
                    catch (Exception ex)
                    {
                        el.Id = "";
                    }
                    try
                    {
                        el.OldId = reader["OldId"].ToString();
                    }
                    catch (Exception ex)
                    {
                        el.OldId = "";
                    }
                    try
                    {
                        el.Location = reader["Location"].ToString();
                    }
                    catch (Exception ex)
                    {
                        el.Location = "";
                    }
                    try
                    {
                        el.Longitude = double.Parse(reader["Longitude"].ToString());
                    }
                    catch (Exception ex)
                    {
                        el.Longitude = null;
                    }
                    try
                    {
                        el.Latitude = double.Parse(reader["Latitude"].ToString());
                    }
                    catch (Exception ex)
                    {
                        el.Latitude = null;
                    }
                    try
                    {
                        el.Logger = reader["Logger"].ToString();
                    }
                    catch (Exception ex)
                    {
                        el.Logger = "";
                    }
                    try
                    {
                        el.Address = reader["Address"].ToString();
                    }
                    catch (Exception ex)
                    {
                        el.Address = "";
                    }
                    try
                    {
                        el.District = reader["District"].ToString();
                    }
                    catch (Exception ex)
                    {
                        el.District = "";
                    }
                    try
                    {
                        el.Company = reader["Company"].ToString();
                    }
                    catch (Exception ex)
                    {
                        el.Company = "";
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
                        el.Availability = reader["Availability"].ToString();
                    }
                    catch (Exception ex)
                    {
                        el.Availability = "";
                    }
                    try
                    {
                        el.SetDelayTime = int.Parse(reader["DelayTime"].ToString());
                    }
                    catch (Exception ex)
                    {
                        el.SetDelayTime = null;
                    }

                    list.Add(el);
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

    public List<t_SiteCustomer> GetSiteForMapBySupervisorCustomLimit(string supervisorId)
    {
        List<t_SiteCustomer> list = new List<t_SiteCustomer>();

        Connect connect = new Connect();

        try
        {
            string sqlQuery = "select top(50) s.[Id], s.[OldId], s.[Location], s.[Longitude], s.[Latitude], ds.[Id] as Logger, s.[Address], s.[District], s.[Company], s.[Status], s.[Availability], ds.[DelayTime]  from [t_Site_Sites] s join [t_Devices_SitesConfigs] ds on ds.[SiteId] = s.[Id] join [t_Supervisor_District] c on c.[IdDistrict] = s.[District] where c.[IdStaff] = '" + supervisorId + "'";

            connect.Connected();

            SqlDataReader reader = connect.Select(sqlQuery);

            if (reader.HasRows)
            {
                while (reader.Read())
                {
                    t_SiteCustomer el = new t_SiteCustomer();
                    try
                    {
                        el.Id = reader["Id"].ToString();
                    }
                    catch (Exception ex)
                    {
                        el.Id = "";
                    }
                    try
                    {
                        el.OldId = reader["OldId"].ToString();
                    }
                    catch (Exception ex)
                    {
                        el.OldId = "";
                    }
                    try
                    {
                        el.Location = reader["Location"].ToString();
                    }
                    catch (Exception ex)
                    {
                        el.Location = "";
                    }
                    try
                    {
                        el.Longitude = double.Parse(reader["Longitude"].ToString());
                    }
                    catch (Exception ex)
                    {
                        el.Longitude = null;
                    }
                    try
                    {
                        el.Latitude = double.Parse(reader["Latitude"].ToString());
                    }
                    catch (Exception ex)
                    {
                        el.Latitude = null;
                    }
                    try
                    {
                        el.Logger = reader["Logger"].ToString();
                    }
                    catch (Exception ex)
                    {
                        el.Logger = "";
                    }
                    try
                    {
                        el.Address = reader["Address"].ToString();
                    }
                    catch (Exception ex)
                    {
                        el.Address = "";
                    }
                    try
                    {
                        el.District = reader["District"].ToString();
                    }
                    catch (Exception ex)
                    {
                        el.District = "";
                    }
                    try
                    {
                        el.Company = reader["Company"].ToString();
                    }
                    catch (Exception ex)
                    {
                        el.Company = "";
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
                        el.Availability = reader["Availability"].ToString();
                    }
                    catch (Exception ex)
                    {
                        el.Availability = "";
                    }
                    try
                    {
                        el.SetDelayTime = int.Parse(reader["DelayTime"].ToString());
                    }
                    catch (Exception ex)
                    {
                        el.SetDelayTime = null;
                    }

                    list.Add(el);
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

    public List<t_SiteCustomer> GetSiteForMapByDMACustom(string dmaid)
    {
        List<t_SiteCustomer> list = new List<t_SiteCustomer>();

        Connect connect = new Connect();

        try
        {
            string sqlQuery = "select s.[Id], s.[OldId], s.[Location], s.[Longitude], s.[Latitude], ds.[Id] as Logger, s.[Address], s.[District], s.[Company], s.[Status], s.[Availability], ds.[DelayTime]  from [t_Site_Sites] s join [t_Devices_SitesConfigs] ds on ds.[SiteId] = s.[Id] join [t_DMA_DMA] c on c.[IdDMA] = s.[Company] where c.[IdStaff] = '" + dmaid + "'";

            connect.Connected();

            SqlDataReader reader = connect.Select(sqlQuery);

            if (reader.HasRows)
            {
                while (reader.Read())
                {
                    t_SiteCustomer el = new t_SiteCustomer();
                    try
                    {
                        el.Id = reader["Id"].ToString();
                    }
                    catch (Exception ex)
                    {
                        el.Id = "";
                    }
                    try
                    {
                        el.OldId = reader["OldId"].ToString();
                    }
                    catch (Exception ex)
                    {
                        el.OldId = "";
                    }
                    try
                    {
                        el.Location = reader["Location"].ToString();
                    }
                    catch (Exception ex)
                    {
                        el.Location = "";
                    }
                    try
                    {
                        el.Longitude = double.Parse(reader["Longitude"].ToString());
                    }
                    catch (Exception ex)
                    {
                        el.Longitude = null;
                    }
                    try
                    {
                        el.Latitude = double.Parse(reader["Latitude"].ToString());
                    }
                    catch (Exception ex)
                    {
                        el.Latitude = null;
                    }
                    try
                    {
                        el.Logger = reader["Logger"].ToString();
                    }
                    catch (Exception ex)
                    {
                        el.Logger = "";
                    }
                    try
                    {
                        el.Address = reader["Address"].ToString();
                    }
                    catch (Exception ex)
                    {
                        el.Address = "";
                    }
                    try
                    {
                        el.District = reader["District"].ToString();
                    }
                    catch (Exception ex)
                    {
                        el.District = "";
                    }
                    try
                    {
                        el.Company = reader["Company"].ToString();
                    }
                    catch (Exception ex)
                    {
                        el.Company = "";
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
                        el.Availability = reader["Availability"].ToString();
                    }
                    catch (Exception ex)
                    {
                        el.Availability = "";
                    }
                    try
                    {
                        el.SetDelayTime = int.Parse(reader["DelayTime"].ToString());
                    }
                    catch (Exception ex)
                    {
                        el.SetDelayTime = null;
                    }

                    list.Add(el);
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

    public List<t_SiteCustomer> GetSiteForMapByDMACustomLimit(string dmaid)
    {
        List<t_SiteCustomer> list = new List<t_SiteCustomer>();

        Connect connect = new Connect();

        try
        {
            string sqlQuery = "select top(50) s.[Id], s.[OldId], s.[Location], s.[Longitude], s.[Latitude], ds.[Id] as Logger, s.[Address], s.[District], s.[Company], s.[Status], s.[Availability], ds.[DelayTime]  from [t_Site_Sites] s join [t_Devices_SitesConfigs] ds on ds.[SiteId] = s.[Id] join [t_DMA_DMA] c on c.[IdDMA] = s.[Company] where c.[IdStaff] = '" + dmaid + "'";

            connect.Connected();

            SqlDataReader reader = connect.Select(sqlQuery);

            if (reader.HasRows)
            {
                while (reader.Read())
                {
                    t_SiteCustomer el = new t_SiteCustomer();
                    try
                    {
                        el.Id = reader["Id"].ToString();
                    }
                    catch (Exception ex)
                    {
                        el.Id = "";
                    }
                    try
                    {
                        el.OldId = reader["OldId"].ToString();
                    }
                    catch (Exception ex)
                    {
                        el.OldId = "";
                    }
                    try
                    {
                        el.Location = reader["Location"].ToString();
                    }
                    catch (Exception ex)
                    {
                        el.Location = "";
                    }
                    try
                    {
                        el.Longitude = double.Parse(reader["Longitude"].ToString());
                    }
                    catch (Exception ex)
                    {
                        el.Longitude = null;
                    }
                    try
                    {
                        el.Latitude = double.Parse(reader["Latitude"].ToString());
                    }
                    catch (Exception ex)
                    {
                        el.Latitude = null;
                    }
                    try
                    {
                        el.Logger = reader["Logger"].ToString();
                    }
                    catch (Exception ex)
                    {
                        el.Logger = "";
                    }
                    try
                    {
                        el.Address = reader["Address"].ToString();
                    }
                    catch (Exception ex)
                    {
                        el.Address = "";
                    }
                    try
                    {
                        el.District = reader["District"].ToString();
                    }
                    catch (Exception ex)
                    {
                        el.District = "";
                    }
                    try
                    {
                        el.Company = reader["Company"].ToString();
                    }
                    catch (Exception ex)
                    {
                        el.Company = "";
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
                        el.Availability = reader["Availability"].ToString();
                    }
                    catch (Exception ex)
                    {
                        el.Availability = "";
                    }
                    try
                    {
                        el.SetDelayTime = int.Parse(reader["DelayTime"].ToString());
                    }
                    catch (Exception ex)
                    {
                        el.SetDelayTime = null;
                    }

                    list.Add(el);
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

    public List<t_SiteCustomer> GetSitesForMapCustom()
    {
        List<t_SiteCustomer> list = new List<t_SiteCustomer>();

        Connect connect = new Connect();

        try
        {
            string sqlQuery = "select s.[Id], s.[OldId], s.[Location], s.[Longitude], s.[Latitude], ds.[Id] as Logger, s.[Address], s.[District], s.[Company], s.[Status], s.[Availability], ds.[DelayTime]  from [t_Site_Sites] s join [t_Devices_SitesConfigs] ds on ds.[SiteId] = s.[Id]";

            connect.Connected();

            SqlDataReader reader = connect.Select(sqlQuery);

            if (reader.HasRows)
            {
                while (reader.Read())
                {
                    t_SiteCustomer el = new t_SiteCustomer();
                    try
                    {
                        el.Id = reader["Id"].ToString();
                    }
                    catch (Exception ex)
                    {
                        el.Id = "";
                    }
                    try
                    {
                        el.OldId = reader["OldId"].ToString();
                    }
                    catch (Exception ex)
                    {
                        el.OldId = "";
                    }
                    try
                    {
                        el.Location = reader["Location"].ToString();
                    }
                    catch (Exception ex)
                    {
                        el.Location = "";
                    }
                    try
                    {
                        el.Longitude = double.Parse(reader["Longitude"].ToString());
                    }
                    catch (Exception ex)
                    {
                        el.Longitude = null;
                    }
                    try
                    {
                        el.Latitude = double.Parse(reader["Latitude"].ToString());
                    }
                    catch (Exception ex)
                    {
                        el.Latitude = null;
                    }
                    try
                    {
                        el.Logger = reader["Logger"].ToString();
                    }
                    catch (Exception ex)
                    {
                        el.Logger = "";
                    }
                    try
                    {
                        el.Address = reader["Address"].ToString();
                    }
                    catch (Exception ex)
                    {
                        el.Address = "";
                    }
                    try
                    {
                        el.District = reader["District"].ToString();
                    }
                    catch (Exception ex)
                    {
                        el.District = "";
                    }
                    try
                    {
                        el.Company = reader["Company"].ToString();
                    }
                    catch (Exception ex)
                    {
                        el.Company = "";
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
                        el.Availability = reader["Availability"].ToString();
                    }
                    catch (Exception ex)
                    {
                        el.Availability = "";
                    }
                    try
                    {
                        el.SetDelayTime = int.Parse(reader["DelayTime"].ToString());
                    }
                    catch (Exception ex)
                    {
                        el.SetDelayTime = null;
                    }

                    list.Add(el);
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

    public List<t_SiteCustomer> GetSitesForMapCustomLimit()
    {
        List<t_SiteCustomer> list = new List<t_SiteCustomer>();

        Connect connect = new Connect();

        try
        {
            string sqlQuery = "select top(50) s.[Id], s.[OldId], s.[Location], s.[Longitude], s.[Latitude], ds.[Id] as Logger, s.[Address], s.[District], s.[Company], s.[Status], s.[Availability], ds.[DelayTime]  from [t_Site_Sites] s join [t_Devices_SitesConfigs] ds on ds.[SiteId] = s.[Id]";

            connect.Connected();

            SqlDataReader reader = connect.Select(sqlQuery);

            if (reader.HasRows)
            {
                while (reader.Read())
                {
                    t_SiteCustomer el = new t_SiteCustomer();
                    try
                    {
                        el.Id = reader["Id"].ToString();
                    }
                    catch (Exception ex)
                    {
                        el.Id = "";
                    }
                    try
                    {
                        el.OldId = reader["OldId"].ToString();
                    }
                    catch (Exception ex)
                    {
                        el.OldId = "";
                    }
                    try
                    {
                        el.Location = reader["Location"].ToString();
                    }
                    catch (Exception ex)
                    {
                        el.Location = "";
                    }
                    try
                    {
                        el.Longitude = double.Parse(reader["Longitude"].ToString());
                    }
                    catch (Exception ex)
                    {
                        el.Longitude = null;
                    }
                    try
                    {
                        el.Latitude = double.Parse(reader["Latitude"].ToString());
                    }
                    catch (Exception ex)
                    {
                        el.Latitude = null;
                    }
                    try
                    {
                        el.Logger = reader["Logger"].ToString();
                    }
                    catch (Exception ex)
                    {
                        el.Logger = "";
                    }
                    try
                    {
                        el.Address = reader["Address"].ToString();
                    }
                    catch (Exception ex)
                    {
                        el.Address = "";
                    }
                    try
                    {
                        el.District = reader["District"].ToString();
                    }
                    catch (Exception ex)
                    {
                        el.District = "";
                    }
                    try
                    {
                        el.Company = reader["Company"].ToString();
                    }
                    catch (Exception ex)
                    {
                        el.Company = "";
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
                        el.Availability = reader["Availability"].ToString();
                    }
                    catch (Exception ex)
                    {
                        el.Availability = "";
                    }
                    try
                    {
                        el.SetDelayTime = int.Parse(reader["DelayTime"].ToString());
                    }
                    catch (Exception ex)
                    {
                        el.SetDelayTime = null;
                    }

                    list.Add(el);
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

    public List<t_SiteCustomer> GetSite(string id)
    {
        List<t_SiteCustomer> list = new List<t_SiteCustomer>();

        Connect connect = new Connect();

        try
        {
            string sqlQuery = "select s.[Id], s.[OldId], s.[Location], s.[Longitude], s.[Latitude], ds.[Id] as Logger, s.[Address], s.[District], s.[Company], s.[Status], s.[Availability], ds.[DelayTime]  from [t_Site_Sites] join [t_Devices_SitesConfigs] ds on ds.[SiteId] = s.[Id] where s.[Id] = '"+id+"'";

            connect.Connected();

            SqlDataReader reader = connect.Select(sqlQuery);

            if (reader.HasRows)
            {
                while (reader.Read())
                {
                    t_SiteCustomer el = new t_SiteCustomer();
                    try
                    {
                        el.Id = reader["Id"].ToString();
                    }
                    catch (Exception ex)
                    {
                        el.Id = "";
                    }
                    try
                    {
                        el.OldId = reader["OldId"].ToString();
                    }
                    catch (Exception ex)
                    {
                        el.OldId = "";
                    }
                    try
                    {
                        el.Location = reader["Location"].ToString();
                    }
                    catch (Exception ex)
                    {
                        el.Location = "";
                    }
                    try
                    {
                        el.Longitude = double.Parse(reader["Longitude"].ToString());
                    }
                    catch (Exception ex)
                    {
                        el.Longitude = null;
                    }
                    try
                    {
                        el.Latitude = double.Parse(reader["Latitude"].ToString());
                    }
                    catch (Exception ex)
                    {
                        el.Latitude = null;
                    }
                    try
                    {
                        el.Logger = reader["Logger"].ToString();
                    }
                    catch (Exception ex)
                    {
                        el.Logger = "";
                    }
                    try
                    {
                        el.Address = reader["Address"].ToString();
                    }
                    catch (Exception ex)
                    {
                        el.Address = "";
                    }
                    try
                    {
                        el.District = reader["District"].ToString();
                    }
                    catch (Exception ex)
                    {
                        el.District = "";
                    }
                    try
                    {
                        el.Company = reader["Company"].ToString();
                    }
                    catch (Exception ex)
                    {
                        el.Company = "";
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
                        el.Availability = reader["Availability"].ToString();
                    }
                    catch (Exception ex)
                    {
                        el.Availability = "";
                    }
                    try
                    {
                        el.SetDelayTime = int.Parse(reader["DelayTime"].ToString());
                    }
                    catch (Exception ex)
                    {
                        el.SetDelayTime = null;
                    }

                    list.Add(el);
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


    public List<SiteDataAll> GetSiteForMobileByConsumerId(string consumerid)
    {
        List<SiteDataAll> list = new List<SiteDataAll>();

        Connect connect = new Connect();

        try
        {
            string sqlQuery = "select s.[Id], s.[Location], s.[Longitude], s.[Latitude], ds.[Id] as Logger, s.[Address], s.[District], s.[Company], ds.[DelayTime]  from [t_Site_Sites] s join [t_Devices_SitesConfigs] ds on ds.[SiteId] = s.[Id] join [t_Site_Consumer] c on c.[SiteId] = s.[Id] where c.[ConsumerId] = '" + consumerid + "'";

            connect.Connected();

            SqlDataReader reader = connect.Select(sqlQuery);

            if (reader.HasRows)
            {
                while (reader.Read())
                {
                    SiteDataAll el = new SiteDataAll();
                    try
                    {
                        el.SiteId = reader["Id"].ToString();
                    }
                    catch (Exception ex)
                    {
                        el.SiteId = "";
                    }
                    try
                    {
                        el.SiteAliasName = reader["Location"].ToString();
                    }
                    catch (Exception ex)
                    {
                        el.SiteAliasName = "";
                    }
                    try
                    {
                        el.Longitude = double.Parse(reader["Longitude"].ToString());
                    }
                    catch (Exception ex)
                    {
                        el.Longitude = 0;
                    }
                    try
                    {
                        el.Latitude = double.Parse(reader["Latitude"].ToString());
                    }
                    catch (Exception ex)
                    {
                        el.Latitude = 0;
                    }
                    try
                    {
                        el.LoggerId = reader["Logger"].ToString();
                    }
                    catch (Exception ex)
                    {
                        el.LoggerId = "";
                    }
                    try
                    {
                        el.Location = reader["Address"].ToString();
                    }
                    catch (Exception ex)
                    {
                        el.Location = "";
                    }
                    try
                    {
                        el.District = reader["District"].ToString();
                    }
                    catch (Exception ex)
                    {
                        el.District = "";
                    }
                    try
                    {
                        el.DisplayGroup = reader["Company"].ToString();
                    }
                    catch (Exception ex)
                    {
                        el.DisplayGroup = "";
                    }
                    try
                    {
                        el.DelayTime = int.Parse(reader["DelayTime"].ToString());
                    }
                    catch (Exception ex)
                    {
                        el.DelayTime = 60;
                    }

                    list.Add(el);
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

    public List<SiteDataAll> GetSitesFormMobileConsumerIdLimit(string consumerid)
    {
        List<SiteDataAll> list = new List<SiteDataAll>();

        Connect connect = new Connect();

        try
        {
            string sqlQuery = "select top(50) s.[Id], s.[Location], s.[Longitude], s.[Latitude], ds.[Id] as Logger, s.[Address], s.[District], s.[Company], ds.[DelayTime]  from [t_Site_Sites] s join [t_Devices_SitesConfigs] ds on ds.[SiteId] = s.[Id] join [t_Site_Consumer] c on c.[SiteId] = s.[Id] where c.[ConsumerId] = '" + consumerid + "'";

            connect.Connected();

            SqlDataReader reader = connect.Select(sqlQuery);

            if (reader.HasRows)
            {
                while (reader.Read())
                {
                    SiteDataAll el = new SiteDataAll();
                    try
                    {
                        el.SiteId = reader["Id"].ToString();
                    }
                    catch (Exception ex)
                    {
                        el.SiteId = "";
                    }
                    try
                    {
                        el.SiteAliasName = reader["Location"].ToString();
                    }
                    catch (Exception ex)
                    {
                        el.SiteAliasName = "";
                    }
                    try
                    {
                        el.Longitude = double.Parse(reader["Longitude"].ToString());
                    }
                    catch (Exception ex)
                    {
                        el.Longitude = 0;
                    }
                    try
                    {
                        el.Latitude = double.Parse(reader["Latitude"].ToString());
                    }
                    catch (Exception ex)
                    {
                        el.Latitude = 0;
                    }
                    try
                    {
                        el.LoggerId = reader["Logger"].ToString();
                    }
                    catch (Exception ex)
                    {
                        el.LoggerId = "";
                    }
                    try
                    {
                        el.Location = reader["Address"].ToString();
                    }
                    catch (Exception ex)
                    {
                        el.Location = "";
                    }
                    try
                    {
                        el.District = reader["District"].ToString();
                    }
                    catch (Exception ex)
                    {
                        el.District = "";
                    }
                    try
                    {
                        el.DisplayGroup = reader["Company"].ToString();
                    }
                    catch (Exception ex)
                    {
                        el.DisplayGroup = "";
                    }
                    try
                    {
                        el.DelayTime = int.Parse(reader["DelayTime"].ToString());
                    }
                    catch (Exception ex)
                    {
                        el.DelayTime = 60;
                    }

                    list.Add(el);
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

    public List<SiteDataAll> GetSitesForMobileByStaffId(string staffId)
    {
        List<SiteDataAll> list = new List<SiteDataAll>();

        Connect connect = new Connect();

        try
        {
            string sqlQuery = "select s.[Id], s.[Location], s.[Longitude], s.[Latitude], ds.[Id] as Logger, s.[Address], s.[District], s.[Company],  ds.[DelayTime]  from [t_Site_Sites] s join [t_Devices_SitesConfigs] ds on ds.[SiteId] = s.[Id] join [t_Site_Consumer] c on c.[SiteId] = s.[Id] where c.[ConsumerId] = '" + staffId + "'";

            connect.Connected();

            SqlDataReader reader = connect.Select(sqlQuery);

            if (reader.HasRows)
            {
                while (reader.Read())
                {
                    SiteDataAll el = new SiteDataAll();
                    try
                    {
                        el.SiteId = reader["Id"].ToString();
                    }
                    catch (Exception ex)
                    {
                        el.SiteId = "";
                    }
                    try
                    {
                        el.SiteAliasName = reader["Location"].ToString();
                    }
                    catch (Exception ex)
                    {
                        el.SiteAliasName = "";
                    }
                    try
                    {
                        el.Longitude = double.Parse(reader["Longitude"].ToString());
                    }
                    catch (Exception ex)
                    {
                        el.Longitude = 0;
                    }
                    try
                    {
                        el.Latitude = double.Parse(reader["Latitude"].ToString());
                    }
                    catch (Exception ex)
                    {
                        el.Latitude = 0;
                    }
                    try
                    {
                        el.LoggerId = reader["Logger"].ToString();
                    }
                    catch (Exception ex)
                    {
                        el.LoggerId = "";
                    }
                    try
                    {
                        el.Location = reader["Address"].ToString();
                    }
                    catch (Exception ex)
                    {
                        el.Location = "";
                    }
                    try
                    {
                        el.District = reader["District"].ToString();
                    }
                    catch (Exception ex)
                    {
                        el.District = "";
                    }
                    try
                    {
                        el.DisplayGroup = reader["Company"].ToString();
                    }
                    catch (Exception ex)
                    {
                        el.DisplayGroup = "";
                    }
                    try
                    {
                        el.DelayTime = int.Parse(reader["DelayTime"].ToString());
                    }
                    catch (Exception ex)
                    {
                        el.DelayTime = 60;
                    }

                    list.Add(el);
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

    public List<SiteDataAll> GetSitesForMobileByStaffIdLimit(string staffId)
    {
        List<SiteDataAll> list = new List<SiteDataAll>();

        Connect connect = new Connect();

        try
        {
            string sqlQuery = "select top(50) s.[Id], s.[Location], s.[Longitude], s.[Latitude], ds.[Id] as Logger, s.[Address], s.[District], s.[Company],  ds.[DelayTime]  from [t_Site_Sites] s join [t_Devices_SitesConfigs] ds on ds.[SiteId] = s.[Id] join [t_Site_Consumer] c on c.[SiteId] = s.[Id] where c.[ConsumerId] = '" + staffId + "'";

            connect.Connected();

            SqlDataReader reader = connect.Select(sqlQuery);

            if (reader.HasRows)
            {
                while (reader.Read())
                {
                    SiteDataAll el = new SiteDataAll();
                    try
                    {
                        el.SiteId = reader["Id"].ToString();
                    }
                    catch (Exception ex)
                    {
                        el.SiteId = "";
                    }
                    try
                    {
                        el.SiteAliasName = reader["Location"].ToString();
                    }
                    catch (Exception ex)
                    {
                        el.SiteAliasName = "";
                    }
                    try
                    {
                        el.Longitude = double.Parse(reader["Longitude"].ToString());
                    }
                    catch (Exception ex)
                    {
                        el.Longitude = 0;
                    }
                    try
                    {
                        el.Latitude = double.Parse(reader["Latitude"].ToString());
                    }
                    catch (Exception ex)
                    {
                        el.Latitude = 0;
                    }
                    try
                    {
                        el.LoggerId = reader["Logger"].ToString();
                    }
                    catch (Exception ex)
                    {
                        el.LoggerId = "";
                    }
                    try
                    {
                        el.Location = reader["Address"].ToString();
                    }
                    catch (Exception ex)
                    {
                        el.Location = "";
                    }
                    try
                    {
                        el.District = reader["District"].ToString();
                    }
                    catch (Exception ex)
                    {
                        el.District = "";
                    }
                    try
                    {
                        el.DisplayGroup = reader["Company"].ToString();
                    }
                    catch (Exception ex)
                    {
                        el.DisplayGroup = "";
                    }
                    try
                    {
                        el.DelayTime = int.Parse(reader["DelayTime"].ToString());
                    }
                    catch (Exception ex)
                    {
                        el.DelayTime = 60;
                    }

                    list.Add(el);
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

    public List<SiteDataAll> GetSiteForMobileBySupervisorId(string supervisorId)
    {
        List<SiteDataAll> list = new List<SiteDataAll>();

        Connect connect = new Connect();

        try
        {
            string sqlQuery = "select s.[Id], s.[Location], s.[Longitude], s.[Latitude], ds.[Id] as Logger, s.[Address], s.[District], s.[Company],  ds.[DelayTime]  from [t_Site_Sites] s join [t_Devices_SitesConfigs] ds on ds.[SiteId] = s.[Id] join [t_Supervisor_District] c on c.[IdDistrict] = s.[District] where c.[IdStaff] = '" + supervisorId + "'";

            connect.Connected();

            SqlDataReader reader = connect.Select(sqlQuery);

            if (reader.HasRows)
            {
                while (reader.Read())
                {
                    SiteDataAll el = new SiteDataAll();
                    try
                    {
                        el.SiteId = reader["Id"].ToString();
                    }
                    catch (Exception ex)
                    {
                        el.SiteId = "";
                    }
                    try
                    {
                        el.SiteAliasName = reader["Location"].ToString();
                    }
                    catch (Exception ex)
                    {
                        el.SiteAliasName = "";
                    }
                    try
                    {
                        el.Longitude = double.Parse(reader["Longitude"].ToString());
                    }
                    catch (Exception ex)
                    {
                        el.Longitude = 0;
                    }
                    try
                    {
                        el.Latitude = double.Parse(reader["Latitude"].ToString());
                    }
                    catch (Exception ex)
                    {
                        el.Latitude = 0;
                    }
                    try
                    {
                        el.LoggerId = reader["Logger"].ToString();
                    }
                    catch (Exception ex)
                    {
                        el.LoggerId = "";
                    }
                    try
                    {
                        el.Location = reader["Address"].ToString();
                    }
                    catch (Exception ex)
                    {
                        el.Location = "";
                    }
                    try
                    {
                        el.District = reader["District"].ToString();
                    }
                    catch (Exception ex)
                    {
                        el.District = "";
                    }
                    try
                    {
                        el.DisplayGroup = reader["Company"].ToString();
                    }
                    catch (Exception ex)
                    {
                        el.DisplayGroup = "";
                    }
                    try
                    {
                        el.DelayTime = int.Parse(reader["DelayTime"].ToString());
                    }
                    catch (Exception ex)
                    {
                        el.DelayTime = 60;
                    }

                    list.Add(el);
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

    public List<SiteDataAll> GetSiteForMobileBySupervisorIdLimit(string supervisorId)
    {
        List<SiteDataAll> list = new List<SiteDataAll>();

        Connect connect = new Connect();

        try
        {
            string sqlQuery = "select top(50) s.[Id], s.[Location], s.[Longitude], s.[Latitude], ds.[Id] as Logger, s.[Address], s.[District], s.[Company],  ds.[DelayTime]  from [t_Site_Sites] s join [t_Devices_SitesConfigs] ds on ds.[SiteId] = s.[Id] join [t_Supervisor_District] c on c.[IdDistrict] = s.[District] where c.[IdStaff] = '" + supervisorId + "'";

            connect.Connected();

            SqlDataReader reader = connect.Select(sqlQuery);

            if (reader.HasRows)
            {
                while (reader.Read())
                {
                    SiteDataAll el = new SiteDataAll();
                    try
                    {
                        el.SiteId = reader["Id"].ToString();
                    }
                    catch (Exception ex)
                    {
                        el.SiteId = "";
                    }
                    try
                    {
                        el.SiteAliasName = reader["Location"].ToString();
                    }
                    catch (Exception ex)
                    {
                        el.SiteAliasName = "";
                    }
                    try
                    {
                        el.Longitude = double.Parse(reader["Longitude"].ToString());
                    }
                    catch (Exception ex)
                    {
                        el.Longitude = 0;
                    }
                    try
                    {
                        el.Latitude = double.Parse(reader["Latitude"].ToString());
                    }
                    catch (Exception ex)
                    {
                        el.Latitude = 0;
                    }
                    try
                    {
                        el.LoggerId = reader["Logger"].ToString();
                    }
                    catch (Exception ex)
                    {
                        el.LoggerId = "";
                    }
                    try
                    {
                        el.Location = reader["Address"].ToString();
                    }
                    catch (Exception ex)
                    {
                        el.Location = "";
                    }
                    try
                    {
                        el.District = reader["District"].ToString();
                    }
                    catch (Exception ex)
                    {
                        el.District = "";
                    }
                    try
                    {
                        el.DisplayGroup = reader["Company"].ToString();
                    }
                    catch (Exception ex)
                    {
                        el.DisplayGroup = "";
                    }
                    try
                    {
                        el.DelayTime = int.Parse(reader["DelayTime"].ToString());
                    }
                    catch (Exception ex)
                    {
                        el.DelayTime = 60;
                    }

                    list.Add(el);
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

    public List<SiteDataAll> GetSiteForMobileByDMAId(string dmaid)
    {
        List<SiteDataAll> list = new List<SiteDataAll>();

        Connect connect = new Connect();

        try
        {
            string sqlQuery = "select s.[Id], s.[Location], s.[Longitude], s.[Latitude], ds.[Id] as Logger, s.[Address], s.[District], s.[Company], ds.[DelayTime]  from [t_Site_Sites] s join [t_Devices_SitesConfigs] ds on ds.[SiteId] = s.[Id] join [t_DMA_DMA] c on c.[IdDMA] = s.[Company] where c.[IdStaff] = '" + dmaid + "'";

            connect.Connected();

            SqlDataReader reader = connect.Select(sqlQuery);

            if (reader.HasRows)
            {
                while (reader.Read())
                {
                    SiteDataAll el = new SiteDataAll();
                    try
                    {
                        el.SiteId = reader["Id"].ToString();
                    }
                    catch (Exception ex)
                    {
                        el.SiteId = "";
                    }
                    try
                    {
                        el.SiteAliasName = reader["Location"].ToString();
                    }
                    catch (Exception ex)
                    {
                        el.SiteAliasName = "";
                    }
                    try
                    {
                        el.Longitude = double.Parse(reader["Longitude"].ToString());
                    }
                    catch (Exception ex)
                    {
                        el.Longitude = 0;
                    }
                    try
                    {
                        el.Latitude = double.Parse(reader["Latitude"].ToString());
                    }
                    catch (Exception ex)
                    {
                        el.Latitude = 0;
                    }
                    try
                    {
                        el.LoggerId = reader["Logger"].ToString();
                    }
                    catch (Exception ex)
                    {
                        el.LoggerId = "";
                    }
                    try
                    {
                        el.Location = reader["Address"].ToString();
                    }
                    catch (Exception ex)
                    {
                        el.Location = "";
                    }
                    try
                    {
                        el.District = reader["District"].ToString();
                    }
                    catch (Exception ex)
                    {
                        el.District = "";
                    }
                    try
                    {
                        el.DisplayGroup = reader["Company"].ToString();
                    }
                    catch (Exception ex)
                    {
                        el.DisplayGroup = "";
                    }
                    try
                    {
                        el.DelayTime = int.Parse(reader["DelayTime"].ToString());
                    }
                    catch (Exception ex)
                    {
                        el.DelayTime = 60;
                    }

                    list.Add(el);
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

    public List<SiteDataAll> GetSiteForMobileByDMAIdLimit(string dmaid)
    {
        List<SiteDataAll> list = new List<SiteDataAll>();

        Connect connect = new Connect();

        try
        {
            string sqlQuery = "select top(50) s.[Id], s.[Location], s.[Longitude], s.[Latitude], ds.[Id] as Logger, s.[Address], s.[District], s.[Company], ds.[DelayTime]  from [t_Site_Sites] s join [t_Devices_SitesConfigs] ds on ds.[SiteId] = s.[Id] join [t_DMA_DMA] c on c.[IdDMA] = s.[Company] where c.[IdStaff] = '" + dmaid + "'";

            connect.Connected();

            SqlDataReader reader = connect.Select(sqlQuery);

            if (reader.HasRows)
            {
                while (reader.Read())
                {
                    SiteDataAll el = new SiteDataAll();
                    try
                    {
                        el.SiteId = reader["Id"].ToString();
                    }
                    catch (Exception ex)
                    {
                        el.SiteId = "";
                    }
                    try
                    {
                        el.SiteAliasName = reader["Location"].ToString();
                    }
                    catch (Exception ex)
                    {
                        el.SiteAliasName = "";
                    }
                    try
                    {
                        el.Longitude = double.Parse(reader["Longitude"].ToString());
                    }
                    catch (Exception ex)
                    {
                        el.Longitude = 0;
                    }
                    try
                    {
                        el.Latitude = double.Parse(reader["Latitude"].ToString());
                    }
                    catch (Exception ex)
                    {
                        el.Latitude = 0;
                    }
                    try
                    {
                        el.LoggerId = reader["Logger"].ToString();
                    }
                    catch (Exception ex)
                    {
                        el.LoggerId = "";
                    }
                    try
                    {
                        el.Location = reader["Address"].ToString();
                    }
                    catch (Exception ex)
                    {
                        el.Location = "";
                    }
                    try
                    {
                        el.District = reader["District"].ToString();
                    }
                    catch (Exception ex)
                    {
                        el.District = "";
                    }
                    try
                    {
                        el.DisplayGroup = reader["Company"].ToString();
                    }
                    catch (Exception ex)
                    {
                        el.DisplayGroup = "";
                    }
                    try
                    {
                        el.DelayTime = int.Parse(reader["DelayTime"].ToString());
                    }
                    catch (Exception ex)
                    {
                        el.DelayTime = 60;
                    }

                    list.Add(el);
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

    public List<SiteDataAll> GetSitesForMobile()
    {
        List<SiteDataAll> list = new List<SiteDataAll>();

        Connect connect = new Connect();

        try
        {
            string sqlQuery = "select s.[Id], s.[Location], s.[Longitude], s.[Latitude], ds.[Id] as Logger, s.[Address], s.[District], s.[Company], ds.[DelayTime]  from [t_Site_Sites] s join [t_Devices_SitesConfigs] ds on ds.[SiteId] = s.[Id]";

            connect.Connected();

            SqlDataReader reader = connect.Select(sqlQuery);

            if (reader.HasRows)
            {
                while (reader.Read())
                {
                    SiteDataAll el = new SiteDataAll();
                    try
                    {
                        el.SiteId = reader["Id"].ToString();
                    }
                    catch (Exception ex)
                    {
                        el.SiteId = "";
                    }
                    try
                    {
                        el.SiteAliasName = reader["Location"].ToString();
                    }
                    catch (Exception ex)
                    {
                        el.SiteAliasName = "";
                    }
                    try
                    {
                        el.Longitude = double.Parse(reader["Longitude"].ToString());
                    }
                    catch (Exception ex)
                    {
                        el.Longitude = 0;
                    }
                    try
                    {
                        el.Latitude = double.Parse(reader["Latitude"].ToString());
                    }
                    catch (Exception ex)
                    {
                        el.Latitude = 0;
                    }
                    try
                    {
                        el.LoggerId = reader["Logger"].ToString();
                    }
                    catch (Exception ex)
                    {
                        el.LoggerId = "";
                    }
                    try
                    {
                        el.Location = reader["Address"].ToString();
                    }
                    catch (Exception ex)
                    {
                        el.Location = "";
                    }
                    try
                    {
                        el.District = reader["District"].ToString();
                    }
                    catch (Exception ex)
                    {
                        el.District = "";
                    }
                    try
                    {
                        el.DisplayGroup = reader["Company"].ToString();
                    }
                    catch (Exception ex)
                    {
                        el.DisplayGroup = "";
                    }
                    try
                    {
                        el.DelayTime = int.Parse(reader["DelayTime"].ToString());
                    }
                    catch (Exception ex)
                    {
                        el.DelayTime = 60;
                    }

                    list.Add(el);
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


    public List<SiteDataAll> GetSitesForMobileLimit()
    {
        List<SiteDataAll> list = new List<SiteDataAll>();

        Connect connect = new Connect();

        try
        {
            string sqlQuery = "select top(50) s.[Id], s.[Location], s.[Longitude], s.[Latitude], ds.[Id] as Logger, s.[Address], s.[District], s.[Company], ds.[DelayTime]  from [t_Site_Sites] s join [t_Devices_SitesConfigs] ds on ds.[SiteId] = s.[Id]";

            connect.Connected();

            SqlDataReader reader = connect.Select(sqlQuery);

            if (reader.HasRows)
            {
                while (reader.Read())
                {
                    SiteDataAll el = new SiteDataAll();
                    try
                    {
                        el.SiteId = reader["Id"].ToString();
                    }
                    catch (Exception ex)
                    {
                        el.SiteId = "";
                    }
                    try
                    {
                        el.SiteAliasName = reader["Location"].ToString();
                    }
                    catch (Exception ex)
                    {
                        el.SiteAliasName = "";
                    }
                    try
                    {
                        el.Longitude = double.Parse(reader["Longitude"].ToString());
                    }
                    catch (Exception ex)
                    {
                        el.Longitude = 0;
                    }
                    try
                    {
                        el.Latitude = double.Parse(reader["Latitude"].ToString());
                    }
                    catch (Exception ex)
                    {
                        el.Latitude = 0;
                    }
                    try
                    {
                        el.LoggerId = reader["Logger"].ToString();
                    }
                    catch (Exception ex)
                    {
                        el.LoggerId = "";
                    }
                    try
                    {
                        el.Location = reader["Address"].ToString();
                    }
                    catch (Exception ex)
                    {
                        el.Location = "";
                    }
                    try
                    {
                        el.District = reader["District"].ToString();
                    }
                    catch (Exception ex)
                    {
                        el.District = "";
                    }
                    try
                    {
                        el.DisplayGroup = reader["Company"].ToString();
                    }
                    catch (Exception ex)
                    {
                        el.DisplayGroup = "";
                    }
                    try
                    {
                        el.DelayTime = int.Parse(reader["DelayTime"].ToString());
                    }
                    catch (Exception ex)
                    {
                        el.DelayTime = 60;
                    }

                    list.Add(el);
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

