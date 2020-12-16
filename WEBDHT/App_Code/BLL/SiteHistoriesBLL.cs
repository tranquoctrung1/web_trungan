using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

/// <summary>
/// Lịch sử điểm lắp đặt
/// </summary>
/// 
[System.ComponentModel.DataObject]
public class SiteHistoriesBLL
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
    /// Lất tất cả lịch sử của một vị trí
    /// </summary>
    /// <param name="siteId"></param>
    /// <returns></returns>
    [System.ComponentModel.DataObjectMethod
    (System.ComponentModel.DataObjectMethodType.Select)]
    public List<SiteHistory> GetAllBySiteId(string siteId)
    {
        return DataContext.SiteHistories.Where(h => h.SiteId == siteId && h.Meter == true).ToList();
    }
    /// <summary>
    /// Lấy lịch sử theo 1 ngày của một điểm lắp đặt
    /// </summary>
    /// <param name="siteId"></param>
    /// <param name="date"></param>
    /// <returns></returns>
    [System.ComponentModel.DataObjectMethod
    (System.ComponentModel.DataObjectMethodType.Select)]
    public SiteHistory GetAllBySiteIdAndDate(string siteId, DateTime date)
    {
        return DataContext.SiteHistories.SingleOrDefault(h => h.Date == date && h.SiteId == siteId);
    }
    /// <summary>
    /// Thêm mới lịch sử
    /// </summary>
    /// <param name="history"></param>
    /// <returns></returns>
    [System.ComponentModel.DataObjectMethod
    (System.ComponentModel.DataObjectMethodType.Insert)]
    public CommandStatus InsertOrUpdate(SiteHistory history)
    {
        bool? s = null;
        CommandStatus status = new CommandStatus();
        try
        {
            DataContext.p_History_Site_InsertOrUpdate(history.SiteId,
                history.Date,
                history.Meter,
                history.SerialMeter,
                history.Transmitter,
                history.SerialTransmitter,
                history.Logger,
                history.SeriLogger,
                history.Battery,
                history.TransmitterBattery,
                history.LoggerBattery,
                history.Description,
                history.Index,
                ref s);
            status.Inserted = true;
        }
        catch (Exception e)
        {
            status.Error = true;
            status.ErrorMessage = e.Message;
        }
        return status;
    }
    /// <summary>
    /// Xóa lịch sử
    /// </summary>
    /// <param name="siteId"></param>
    /// <returns></returns>
    public CommandStatus DeleteBySiteId(string siteId)
    {
        CommandStatus status = new CommandStatus();
        bool? s = null;
        try
        {
            DataContext.p_History_Site_Delete(siteId, ref s);
            status.Deleted = true;
        }
        catch (Exception e)
        {
            status.Error = true;
            status.ErrorMessage = e.Message;
        }
        return status;
    }
}