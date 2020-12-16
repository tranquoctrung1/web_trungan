using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

/// <summary>
/// Truy vấn dữ liệu lịch sử thay logger
/// </summary>
/// 
[System.ComponentModel.DataObject]
public class SiteLoggerHistoriesBLL
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
    /// Lấy lịch sử theo ngày thay đổi của một mã vị trí
    /// </summary>
    /// <param name="siteId"></param>
    /// <param name="dateChanged"></param>
    /// <returns></returns>
    [System.ComponentModel.DataObjectMethod
    (System.ComponentModel.DataObjectMethodType.Select, false)]
    public SiteLoggerHistory GetBySiteIdAndDateChanged(string siteId, DateTime dateChanged)
    {
        return DataContext.SiteLoggerHistories.SingleOrDefault(h => h.SiteId == siteId && h.DateChanged == dateChanged);
    }
    /// <summary>
    /// Lấy dữ liệu lịch sử cuối
    /// </summary>
    /// <param name="siteId"></param>
    /// <returns></returns>
    [System.ComponentModel.DataObjectMethod
    (System.ComponentModel.DataObjectMethodType.Select, false)]
    public SiteLoggerHistory GetLastChanged(string siteId)
    {
        var temp = DataContext.SiteLoggerHistories.Where(h => h.SiteId == siteId).Select(h => h.DateChanged);
        if (temp == null)
        {
            return null;
        }
        else
        {
            DateTime lastDate = temp.Max();
            return DataContext.SiteLoggerHistories.SingleOrDefault(h => h.DateChanged == lastDate && h.SiteId == siteId);
        }
    }
    /// <summary>
    /// Lấy tất cả lịch sử thay đổi logger của một điểm lắp đặt
    /// </summary>
    /// <param name="siteId"></param>
    /// <returns></returns>
    [System.ComponentModel.DataObjectMethod
    (System.ComponentModel.DataObjectMethodType.Select, false)]
    public List<ReportSiteLoggerHistory> GetSiteLoggerHistory(string siteId)
    {
        return DataContext.p_History_Site_Logger_Select_By_SiteId(siteId).ToList();
    }
    /// <summary>
    /// Lấy tất cả các logger đã có lịch sử
    /// </summary>
    /// <returns></returns>
    [System.ComponentModel.DataObjectMethod
    (System.ComponentModel.DataObjectMethodType.Select, false)]
    public List<string> GetAllLoggerSerial()
    {
        var listOld = DataContext.SiteLoggerHistories.Where(h => h.OldMeterSerial != null && h.OldMeterSerial != "").Select(h => h.OldMeterSerial).Distinct().ToList();
        var listNew = DataContext.SiteLoggerHistories.Where(h => h.NewMeterSerial != null && h.NewMeterSerial != "").Select(h => h.NewMeterSerial).Distinct().ToList();
        return listOld.Union(listNew).ToList();
    }
    /// <summary>
    /// Xóa lịch sử logger
    /// </summary>
    /// <param name="siteId"></param>
    /// <param name="dateChanged"></param>
    /// <returns></returns>
    [System.ComponentModel.DataObjectMethod
    (System.ComponentModel.DataObjectMethodType.Delete, false)]
    public CommandStatus Delete(string siteId, DateTime dateChanged)
    {
        CommandStatus status = new CommandStatus();
        try
        {
            DataContext.p_History_Site_Logger_Delete(siteId, dateChanged);
            status.Deleted = true;
        }
        catch (Exception e)
        {
            status.Error = true;
            status.ErrorMessage = e.Message;
        }
        return status;
    }
    /// <summary>
    /// Thêm mới lịch sử logger
    /// </summary>
    /// <param name="history"></param>
    /// <returns></returns>
    [System.ComponentModel.DataObjectMethod
    (System.ComponentModel.DataObjectMethodType.Insert, false)]
    public CommandStatus Insert(SiteLoggerHistory history)
    {
        CommandStatus status = new CommandStatus();
        try
        {
            DataContext.p_History_Site_Logger_Insert(
                history.SiteId,
                history.DateChanged,
                history.OldMeterSerial,
                history.NewMeterSerial,
                history.OldMeterIndex,
                history.NewMeterIndex,
                history.Description);
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
    /// Cập nhật lịch sử logger
    /// </summary>
    /// <param name="history"></param>
    /// <returns></returns>
    [System.ComponentModel.DataObjectMethod
    (System.ComponentModel.DataObjectMethodType.Update, false)]
    public CommandStatus Update(SiteLoggerHistory history)
    {
        CommandStatus status = new CommandStatus();
        try
        {
            DataContext.p_History_Site_Logger_Update(
                history.SiteId,
                history.DateChanged,
                history.OldMeterSerial,
                history.NewMeterSerial,
                history.OldMeterIndex,
                history.NewMeterIndex,
                history.Description);
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