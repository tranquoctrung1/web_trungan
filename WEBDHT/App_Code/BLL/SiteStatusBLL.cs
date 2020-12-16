using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

/// <summary>
/// Truy vấn dữ lieuj trạng thái điểm lắp đặt t_Site_Status
/// </summary>
/// 
[System.ComponentModel.DataObject]
public class SiteStatusBLL
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
    /// Lấy tất cả trạng thái điểm lắp đặt
    /// </summary>
    /// <returns></returns>
    [System.ComponentModel.DataObjectMethod
    (System.ComponentModel.DataObjectMethodType.Select)]
    public IQueryable<SiteStatus> GetAll()
    {
        return DataContext.SiteStatus.OrderBy(s => s.Status);
    }
    /// <summary>
    /// Lấy mô tả một trạng thái theo mã trạng thái
    /// </summary>
    /// <param name="siteStatus"></param>
    /// <returns></returns>
    [System.ComponentModel.DataObjectMethod
    (System.ComponentModel.DataObjectMethodType.Select)]
    public SiteStatus GetByStatus(string siteStatus)
    {
        return DataContext.SiteStatus.SingleOrDefault(s => s.Status == siteStatus);
    }
    /// <summary>
    /// Thêm mới một trạng thái
    /// </summary>
    /// <param name="siteStatus"></param>
    /// <returns></returns>
    [System.ComponentModel.DataObjectMethod
    (System.ComponentModel.DataObjectMethodType.Insert)]
    public CommandStatus Insert(SiteStatus siteStatus)
    {
        CommandStatus status = new CommandStatus();
        DataContext.SiteStatus.InsertOnSubmit(siteStatus);
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
    /// Cập nhật một trạng thái
    /// </summary>
    /// <param name="siteStatus"></param>
    /// <returns></returns>
    [System.ComponentModel.DataObjectMethod
    (System.ComponentModel.DataObjectMethodType.Update)]
    public CommandStatus Update(SiteStatus siteStatus)
    {
        CommandStatus status = new CommandStatus();
        SiteStatus dbStatus = DataContext.SiteStatus.SingleOrDefault(s => s.Status == siteStatus.Status);
        if (dbStatus != null)
        {
            dbStatus.Description = siteStatus.Description;
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
    /// Xóa một trạng thái
    /// </summary>
    /// <param name="siteStatus"></param>
    /// <returns></returns>
    public CommandStatus Delete(string siteStatus)
    {
        CommandStatus status = new CommandStatus();
        SiteStatus dbStatus = DataContext.SiteStatus.SingleOrDefault(s => s.Status == siteStatus);
        if (dbStatus != null)
        {
            DataContext.SiteStatus.DeleteOnSubmit(dbStatus);
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