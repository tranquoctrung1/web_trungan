﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

/// <summary>
/// Truy vấn dữ liệu nhóm lắp đặt (2) t_Site_Group2s
/// </summary>
/// 
[System.ComponentModel.DataObject]
public class SiteGroup3sBLL
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
    public IQueryable<SiteGroup3> GetAll()
    {
        return DataContext.SiteGroup3s.OrderBy(s => s.Group);
    }
    /// <summary>
    /// Lấy thông tin một nhóm theo mã nhóm
    /// </summary>
    /// <param name="group"></param>
    /// <returns></returns>
    [System.ComponentModel.DataObjectMethod
    (System.ComponentModel.DataObjectMethodType.Select)]
    public SiteGroup3 GetByGroup(string group)
    {
        return DataContext.SiteGroup3s.SingleOrDefault(g => g.Group == group);
    }
    /// <summary>
    /// Thêm mới một nhóm
    /// </summary>
    /// <param name="group"></param>
    /// <returns></returns>
    [System.ComponentModel.DataObjectMethod
    (System.ComponentModel.DataObjectMethodType.Insert)]
    public CommandStatus Insert(SiteGroup3 group)
    {
        CommandStatus status = new CommandStatus();
        DataContext.SiteGroup3s.InsertOnSubmit(group);
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
    /// Cập nhật thông tin nhóm
    /// </summary>
    /// <param name="group"></param>
    /// <returns></returns>
    [System.ComponentModel.DataObjectMethod
    (System.ComponentModel.DataObjectMethodType.Update)]
    public CommandStatus Update(SiteGroup3 group)
    {
        CommandStatus status = new CommandStatus();
        SiteGroup3 dbGroup = DataContext.SiteGroup3s.SingleOrDefault(g => g.Group == group.Group);
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
    /// Xóa nhóm
    /// </summary>
    /// <param name="group"></param>
    /// <returns></returns>
    public CommandStatus Delete(string group)
    {
        CommandStatus status = new CommandStatus();
        SiteGroup3 dbGroup = DataContext.SiteGroup3s.SingleOrDefault(g => g.Group == group);
        if (dbGroup != null)
        {
            DataContext.SiteGroup3s.DeleteOnSubmit(dbGroup);
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