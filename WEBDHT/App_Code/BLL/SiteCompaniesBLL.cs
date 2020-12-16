using System;
using System.Collections.Generic;
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
}