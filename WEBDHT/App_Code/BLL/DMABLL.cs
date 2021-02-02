using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Web;

/// <summary>
/// Summary description for DMABLL
/// </summary>
public class DMABLL
{
    public List<DMAViewModel> GetDMAs()
    {
        List<DMAViewModel> list = new List<DMAViewModel>();
        Connect connect = new Connect();

        try
        {
            string sqlQuery = "select Company, Production, Description, Status, District, Ward, AmountDHTKH, AmountValve, AmountPool, AmountTCH, NRW from t_Site_Companies order by Company";

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
                        el.District = reader["District"].ToString();
                    }
                    catch (Exception ex)
                    {
                        el.District = "";
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
                        el.NRW = double.Parse(reader["NRW"].ToString());
                    }
                    catch (Exception ex)
                    {
                        el.NRW = null;
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

    public DMAViewModel GetDMAByID(string id)
    {
        DMAViewModel dma = new DMAViewModel();
        Connect connect = new Connect();

        try
        {
            string sqlQuery = "select Company, Production, Description, Status, District, Ward, AmountDHTKH, AmountValve, AmountPool, AmountTCH, NRW from t_Site_Companies where Company = '" + id+"' order by Company";

            connect.Connected();

            SqlDataReader reader = connect.Select(sqlQuery);

            if (reader.HasRows)
            {
                while (reader.Read())
                {
                    try
                    {
                        dma.Company = reader["Company"].ToString();
                    }
                    catch (Exception ex)
                    {
                        dma.Company = "";
                    }
                    try
                    {
                        dma.Production = bool.Parse(reader["Production"].ToString());
                    }
                    catch (Exception ex)
                    {
                        dma.Production = null;
                    }
                    try
                    {
                        dma.Description = reader["Description"].ToString();
                    }
                    catch (Exception ex)
                    {
                        dma.Description = "";
                    }
                    try
                    {
                        dma.Status = reader["Status"].ToString();
                    }
                    catch (Exception ex)
                    {
                        dma.Status = "";
                    }
                    try
                    {
                        dma.District = reader["District"].ToString();
                    }
                    catch (Exception ex)
                    {
                        dma.District = "";
                    }
                    try
                    {
                        dma.Ward = reader["Ward"].ToString();
                    }
                    catch (Exception ex)
                    {
                        dma.Ward = "";
                    }
                    try
                    {
                        dma.AmountDHTKH = int.Parse(reader["AmountDHTKH"].ToString());
                    }
                    catch (Exception ex)
                    {
                        dma.AmountDHTKH = null;
                    }
                    try
                    {
                        dma.AmountValve = int.Parse(reader["AmountValve"].ToString());
                    }
                    catch (Exception ex)
                    {
                        dma.AmountValve = null;
                    }
                    try
                    {
                        dma.AmountPool = int.Parse(reader["AmountPool"].ToString());
                    }
                    catch (Exception ex)
                    {
                        dma.AmountPool = null;
                    }
                    try
                    {
                        dma.AmountTCH = int.Parse(reader["AmountTCH"].ToString());
                    }
                    catch (Exception ex)
                    {
                        dma.AmountTCH = null;
                    }
                    try
                    {
                        dma.NRW = double.Parse(reader["NRW"].ToString());
                    }
                    catch (Exception ex)
                    {
                        dma.NRW = null;
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

        return dma;
    }


    public int Insert(DMAViewModel dma)
    {
        int nRows = 0;

        Connect connect = new Connect();
        try
        {
            string sqlQuery = "insert into t_Site_Companies values (N'" + dma.Company + "', '" + dma.Production + "', N'" + dma.Description + "', N'" + dma.Status + "',N'" + dma.District + "',N'" + dma.Ward + "', '" + dma.AmountDHTKH + "', '" + dma.AmountValve + "', '" + dma.AmountPool + "', '" + dma.AmountTCH + "', '" + dma.NRW + "')";

            connect.Connected();

            nRows = connect.ExcuteNonQuery(sqlQuery);
        }
        catch (SqlException ex)
        {
            throw ex;
        }
        finally
        {
            connect.DisConnected();
        }

        return nRows;
    }

    public int Update(DMAViewModel dma)
    {
        int nRows = 0;

        Connect connect = new Connect();
        try
        {
            string sqlQuery = "update t_Site_Companies set Production = '"+dma.Production+"', Status = N'"+dma.Status+"', Description = N'"+dma.Description+"', District = N'"+dma.District+"', Ward = N'"+dma.Ward+ "', AmountDHTKH  = '"+dma.AmountDHTKH+ "', AmountValve = '"+dma.AmountValve+ "', AmountPool = '"+dma.AmountPool+ "', AmountTCH = '"+dma.AmountTCH+"', NRW = '"+dma.NRW+"' where Company = '"+dma.Company+"'";

            connect.Connected();

            nRows = connect.ExcuteNonQuery(sqlQuery);
        }
        catch (SqlException ex)
        {
            throw ex;
        }
        finally
        {
            connect.DisConnected();
        }

        return nRows;
    }

    public int Delete(string id)
    {
        int nRows = 0;

        Connect connect = new Connect();
        try
        {
            string sqlQuery = "delete from  t_Site_Companies where Company = '" + id + "'";

            connect.Connected();

            nRows = connect.ExcuteNonQuery(sqlQuery);
        }
        catch (SqlException ex)
        {
            throw ex;
        }
        finally
        {
            connect.DisConnected();
        }

        return nRows;
    }
}