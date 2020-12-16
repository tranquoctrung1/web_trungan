using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

/// <summary>
/// Truy vấn dữ liệu cấu hình logger điểm lắp đặt
/// </summary>
/// 
[System.ComponentModel.DataObject]
public class SiteConfigsBLL
{
	/// <summary>
	/// LINQ Object
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
    /// Xóa cấu hình
    /// </summary>
    /// <param name="siteConfig"></param>
    /// <returns></returns>
    [System.ComponentModel.DataObjectMethod
    (System.ComponentModel.DataObjectMethodType.Delete,false)]
    public CommandStatus Delete(SiteConfig siteConfig)
    {
        CommandStatus status = new CommandStatus();
        try
        {
            var dbSiteConfig = DataContext.SiteConfigs.SingleOrDefault(sc => sc.SiteId == siteConfig.SiteId);
            DataContext.SiteConfigs.DeleteOnSubmit(dbSiteConfig);
            DataContext.SubmitChanges();
            status.Deleted = true;
        }
        catch (Exception e)
        {
            status.Error = true;
            status.ErrorMessage = e.Message;
            //throw;
        }
        return status;
    }
    /// <summary>
    /// Lấy thông tin cấu hình của một điểm lắp đặt
    /// </summary>
    /// <param name="siteId"></param>
    /// <returns></returns>
    [System.ComponentModel.DataObjectMethod
    (System.ComponentModel.DataObjectMethodType.Select, false)]
    public SiteConfig GetBySiteId(string siteId)
    {
        return DataContext.SiteConfigs.SingleOrDefault(sc => sc.SiteId == siteId);
    }
    /// <summary>
    /// Thêm mới cấu hình điểm lắp đặt
    /// </summary>
    /// <param name="siteConfig"></param>
    /// <returns></returns>
    [System.ComponentModel.DataObjectMethod
    (System.ComponentModel.DataObjectMethodType.Insert, false)]
    public CommandStatus Insert(SiteConfig siteConfig)
    {
        CommandStatus status = new CommandStatus();
        DataContext.SiteConfigs.InsertOnSubmit(siteConfig);
        try
        {
            DataContext.SubmitChanges();
            status.Inserted = true;
        }
        catch (Exception e)
        {
            status.Error = true;
            status.ErrorMessage = e.Message;
            //throw;
        }
        return status;
    }
    /// <summary>
    /// Cập nhật cấu hình điểm lắp đặt
    /// </summary>
    /// <param name="siteConfig"></param>
    /// <returns></returns>
    [System.ComponentModel.DataObjectMethod
    (System.ComponentModel.DataObjectMethodType.Update, false)]
    public CommandStatus Update(SiteConfig siteConfig)
    {
        CommandStatus status = new CommandStatus();
        var dbConfig = DataContext.SiteConfigs.SingleOrDefault(sc => sc.SiteId == siteConfig.SiteId);
        if (dbConfig != null)
        {
            dbConfig.BeginTime = siteConfig.BeginTime;
            dbConfig.Forward = siteConfig.Forward;
            dbConfig.Id = siteConfig.Id;
            dbConfig.Interval = siteConfig.Interval;
            dbConfig.Pressure = siteConfig.Pressure;
            dbConfig.Pressure1 = siteConfig.Pressure1;
            dbConfig.Reverse = siteConfig.Reverse;
            dbConfig.SiteId = siteConfig.SiteId;
            dbConfig.Tel = siteConfig.Tel;
            dbConfig.ZoomInit = siteConfig.ZoomInit;
            dbConfig.ZoomOn = siteConfig.ZoomOn;
        }
        try
        {
            DataContext.SubmitChanges();
            status.Updated = true;
        }
        catch (Exception e)
        {
            status.Error = true;
            status.ErrorMessage = e.Message;
            //throw;
        }
        return status;
    }
}