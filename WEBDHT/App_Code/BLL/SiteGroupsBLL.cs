using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

/// <summary>
/// Truy vấn thông tin nhóm điểm lắp đăt t_Site_Groups
/// </summary>
/// 
[System.ComponentModel.DataObject]
public class SiteGroupsBLL
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
    /// Lấy tất cả các nhóm
    /// </summary>
    /// <returns></returns>
    [System.ComponentModel.DataObjectMethod
    (System.ComponentModel.DataObjectMethodType.Select)]
    public IQueryable<SiteGroup> GetAll()
    {
        return DataContext.SiteGroups.OrderBy(s => s.Group);
    }
    /// <summary>
    /// Lấy thông tin một nhóm theo mã 
    /// </summary>
    /// <param name="group"></param>
    /// <returns></returns>
    [System.ComponentModel.DataObjectMethod
    (System.ComponentModel.DataObjectMethodType.Select)]
    public SiteGroup GetByGroup(string group)
    {
        return DataContext.SiteGroups.SingleOrDefault(g => g.Group == group);
    }
    /// <summary>
    /// Thêm mới một nhóm
    /// </summary>
    /// <param name="group"></param>
    /// <returns></returns>
    [System.ComponentModel.DataObjectMethod
    (System.ComponentModel.DataObjectMethodType.Insert)]
    public CommandStatus Insert(SiteGroup group)
    {
        CommandStatus status = new CommandStatus();
        DataContext.SiteGroups.InsertOnSubmit(group);
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
    /// Cập nhật thông tin một nhóm
    /// </summary>
    /// <param name="group"></param>
    /// <returns></returns>
    [System.ComponentModel.DataObjectMethod
    (System.ComponentModel.DataObjectMethodType.Update)]
    public CommandStatus Update(SiteGroup group)
    {
        CommandStatus status = new CommandStatus();
        SiteGroup dbGroup = DataContext.SiteGroups.SingleOrDefault(g => g.Group == group.Group);
        if (dbGroup != null)
        {
            dbGroup.Description = group.Description;
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
    /// Xóa một nhóm
    /// </summary>
    /// <param name="group"></param>
    /// <returns></returns>
    public CommandStatus Delete(string group)
    {
        CommandStatus status = new CommandStatus();
        SiteGroup dbGroup = DataContext.SiteGroups.SingleOrDefault(g => g.Group == group);
        if (dbGroup != null)
        {
            DataContext.SiteGroups.DeleteOnSubmit(dbGroup);
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