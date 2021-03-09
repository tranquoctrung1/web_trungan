using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Web;

/// <summary>
/// Truy vấn dữ liệu các công ty quản lý, công ty cổ phần t_Site_Companies
/// </summary>
/// 
[System.ComponentModel.DataObject]
public class SiteCompaniesBLL
{
    /// <summary>
    /// Object LINQ
    /// </summary>
    private FMM_SGWDCDataContext _dataContext = null;
    public FMM_SGWDCDataContext DataContext
    {
        get
        {
            if (_dataContext == null)
            {
                _dataContext = new FMM_SGWDCDataContext();
                _dataContext.CommandTimeout = 60 * 30;
            }
            return _dataContext;
        }
    }
    /// <summary>
    /// Lấy tất cả các công ty
    /// </summary>
    /// <returns></returns>
    [System.ComponentModel.DataObjectMethod
    (System.ComponentModel.DataObjectMethodType.Select)]
    public IQueryable<SiteCompany> GetAll()
    {
        return DataContext.SiteCompanies.OrderBy(s => s.Company);
    }
    /// <summary>
    /// Lấy mô tả một công ty theo mã công ty
    /// </summary>
    /// <param name="company"></param>
    /// <returns></returns>
    [System.ComponentModel.DataObjectMethod
    (System.ComponentModel.DataObjectMethodType.Select)]
    public SiteCompany GetByCompany(string company)
    {
        return DataContext.SiteCompanies.SingleOrDefault(c => c.Company == company);
    }
    /// <summary>
    /// Thêm mới một công ty
    /// </summary>
    /// <param name="company"></param>
    /// <returns></returns>
    [System.ComponentModel.DataObjectMethod
    (System.ComponentModel.DataObjectMethodType.Insert)]
    public CommandStatus Insert(SiteCompany company)
    {
        CommandStatus status = new CommandStatus();
        DataContext.SiteCompanies.InsertOnSubmit(company);
        try
        {
            DataContext.SubmitChanges();
            status.Inserted = true;
        }
        catch (Exception e)
        {
            status.ErrorMessage = e.Message;
            status.Error = true;
        }
        return status;
    }
    /// <summary>
    /// Cập nhật thông tin một công ty
    /// </summary>
    /// <param name="company"></param>
    /// <returns></returns>
    [System.ComponentModel.DataObjectMethod
    (System.ComponentModel.DataObjectMethodType.Update)]
    public CommandStatus Update(SiteCompany company)
    {
        CommandStatus status = new CommandStatus();
        SiteCompany dbCompany = DataContext.SiteCompanies.SingleOrDefault(c => c.Company == company.Company);
        if (dbCompany != null)
        {
            dbCompany.Description = company.Description;
        }
        try
        {
            DataContext.SubmitChanges();
            status.Updated = true;
        }
        catch (Exception e)
        {
            status.ErrorMessage = e.Message;
            status.Error = true;
        }
        return status;
    }
    /// <summary>
    /// Xóa thông tin một công ty
    /// </summary>
    /// <param name="company"></param>
    /// <returns></returns>
    public CommandStatus Delete(string company)
    {
        CommandStatus status = new CommandStatus();
        SiteCompany dbCompany = DataContext.SiteCompanies.SingleOrDefault(c => c.Company == company);
        if (dbCompany != null)
        {
            DataContext.SiteCompanies.DeleteOnSubmit(dbCompany);
        }
        try
        {
            DataContext.SubmitChanges();
            status.Deleted = true;
        }
        catch (Exception e)
        {
            status.ErrorMessage = e.Message;
            status.Error = true;
        }
        return status;
    }

    public List<SiteCompany> GetDMAByUid()
    {
        List<SiteCompany> list = new List<SiteCompany>();
        UsersBLL usersBLL = new UsersBLL();

        var username = HttpContext.Current.User.Identity.Name;

        var u = usersBLL.GetByUid(username);

        Connect connect = new Connect();

        try
        {
            string sqlQuery = "select Company, Production, Description, Status, District, Ward, AmountDHTKH, AmountValve, AmountPool, AmountTCH, NRW, d.IdStaff from  t_Site_Companies s join t_DMA_DMA d on d.IdDMA = s.Company where Company is not null and d.IdStaff = '"+u.StaffId+"' order by Company ";

            connect.Connected();

            SqlDataReader reader = connect.Select(sqlQuery);    

            if(reader.HasRows)
            {
                while(reader.Read())
                {
                    SiteCompany el = new SiteCompany();
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
                        el.Production = bool.Parse(reader["Production"].ToString());
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