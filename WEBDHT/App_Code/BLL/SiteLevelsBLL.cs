using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

/// <summary>
/// Truy vấn dữ liệu các cấp đồng hồ t_Site_Levels
/// </summary>
/// 
[System.ComponentModel.DataObject]
public class SiteLevelsBLL
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
    /// Lấy tất cả cấp điểm lắp đặt
    /// </summary>
    /// <returns></returns>
    [System.ComponentModel.DataObjectMethod
    (System.ComponentModel.DataObjectMethodType.Select)]
    public IQueryable<SiteLevel> GetAll()
    {
        return DataContext.SiteLevels.OrderBy(s => s.Level);
    }
    /// <summary>
    /// Lấy thông tin một cấp điểm lắp đặt theo mã
    /// </summary>
    /// <param name="level"></param>
    /// <returns></returns>
    [System.ComponentModel.DataObjectMethod
    (System.ComponentModel.DataObjectMethodType.Select)]
    public SiteLevel GetByLevel(string level)
    {
        return DataContext.SiteLevels.SingleOrDefault(l => l.Level == level);
    }
    /// <summary>
    /// Thêm mới một cấp
    /// </summary>
    /// <param name="level"></param>
    /// <returns></returns>
    [System.ComponentModel.DataObjectMethod
    (System.ComponentModel.DataObjectMethodType.Insert)]
    public CommandStatus Insert(SiteLevel level)
    {
        CommandStatus status = new CommandStatus();
        DataContext.SiteLevels.InsertOnSubmit(level);
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
    /// Cập nhật một cấp
    /// </summary>
    /// <param name="level"></param>
    /// <returns></returns>
    [System.ComponentModel.DataObjectMethod
    (System.ComponentModel.DataObjectMethodType.Update)]
    public CommandStatus Update(SiteLevel level)
    {
        CommandStatus status = new CommandStatus();
        SiteLevel dbLevel = DataContext.SiteLevels.SingleOrDefault(l => l.Level == level.Level);
        if (dbLevel != null)
        {
            dbLevel.Description = level.Description;
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
    /// Xóa một cấp
    /// </summary>
    /// <param name="level"></param>
    /// <returns></returns>
    public CommandStatus Delete(string level)
    {
        CommandStatus status = new CommandStatus();
        SiteLevel dbLevel = DataContext.SiteLevels.SingleOrDefault(l => l.Level == level);
        if (dbLevel != null)
        {
            DataContext.SiteLevels.DeleteOnSubmit(dbLevel);
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