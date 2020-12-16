using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

/// <summary>
/// Truy vấn dữ liệu lịch sử thay bộ hiển thị 
/// </summary>
/// 
[System.ComponentModel.DataObject]
public class SiteTransmitterHistoriesBLL
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
    /// Lấy dữ liệu lịch sử thay bộ hiển thị một điểm lắp đặt tại một ngày xác định
    /// </summary>
    /// <param name="siteId"></param>
    /// <param name="dateChanged"></param>
    /// <returns></returns>
    [System.ComponentModel.DataObjectMethod
    (System.ComponentModel.DataObjectMethodType.Select, false)]
    public SiteTransmitterHistory GetBySiteIdAndDateChanged(string siteId, DateTime dateChanged)
    {
        return DataContext.SiteTransmitterHistories.SingleOrDefault(h => h.SiteId == siteId && h.DateChanged == dateChanged);
    }
    /// <summary>
    /// Lấy lịch sử thay bộ hiển thị cuối cùng của một điểm lắp đặt
    /// </summary>
    /// <param name="siteId"></param>
    /// <returns></returns>
    [System.ComponentModel.DataObjectMethod
    (System.ComponentModel.DataObjectMethodType.Select, false)]
    public SiteTransmitterHistory GetLastChanged(string siteId)
    {
        var temp = DataContext.SiteTransmitterHistories.Where(h => h.SiteId == siteId).Select(h => h.DateChanged);
        if (temp == null)
        {
            return null;
        }
        else
        {
            DateTime lastDate = temp.Max();
            return DataContext.SiteTransmitterHistories.SingleOrDefault(h => h.DateChanged == lastDate && h.SiteId == siteId);
        }
    }
    /// <summary>
    /// Lất tất cả lịch sử thay thiết bị bộ hiển thị của một điểm lắp đặt
    /// </summary>
    /// <param name="siteId"></param>
    /// <returns></returns>
    [System.ComponentModel.DataObjectMethod
    (System.ComponentModel.DataObjectMethodType.Select, false)]
    public List<ReportSiteTransmitterHistory> GetSiteTransmitterHistory(string siteId)
    {
        return DataContext.p_History_Site_Transmitter_Select_By_SiteId(siteId).ToList();
    }
    /// <summary>
    /// Lấy tất cả số seri bộ hiển thị đã có trong lịch sử
    /// </summary>
    /// <returns></returns>
    [System.ComponentModel.DataObjectMethod
    (System.ComponentModel.DataObjectMethodType.Select, false)]
    public List<string> GetAllTransmmiterSerial()
    {
        var listOld = DataContext.SiteTransmitterHistories.Where(h => h.OldMeterSerial != null && h.OldMeterSerial != "").Select(h => h.OldMeterSerial).Distinct().ToList();
        var listNew = DataContext.SiteTransmitterHistories.Where(h => h.NewMeterSerial != null && h.NewMeterSerial != "").Select(h => h.NewMeterSerial).Distinct().ToList();
        return listOld.Union(listNew).ToList();
    }
    /// <summary>
    /// Xóa lịch sử thay bộ hiển thị
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
            DataContext.p_History_Site_Transmitter_Delete(siteId, dateChanged);
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
    /// Thêm mới lịch sử
    /// </summary>
    /// <param name="history"></param>
    /// <returns></returns>
    [System.ComponentModel.DataObjectMethod
    (System.ComponentModel.DataObjectMethodType.Insert, false)]
    public CommandStatus Insert(SiteTransmitterHistory history)
    {
        CommandStatus status = new CommandStatus();
        try
        {
            DataContext.p_History_Site_Transmitter_Insert(
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
    /// Cập nhật lịch sử
    /// </summary>
    /// <param name="history"></param>
    /// <returns></returns>
    [System.ComponentModel.DataObjectMethod
    (System.ComponentModel.DataObjectMethodType.Update, false)]
    public CommandStatus Update(SiteTransmitterHistory history)
    {
        CommandStatus status = new CommandStatus();
        try
        {
            DataContext.p_History_Site_Transmitter_Update(
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