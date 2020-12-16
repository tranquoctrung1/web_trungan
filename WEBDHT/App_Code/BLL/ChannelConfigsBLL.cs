using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

/// <summary>
/// Giao tiếp bảng t_Channels_Configs
/// </summary>
public class ChannelConfigsBLL
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
    /// Xóa cấu hình một kênh logger</summary>
    /// <param name="channelConfig">Cấu hình cần xóa</param>
    /// <returns>Trạng thái</returns>
    [System.ComponentModel.DataObjectMethod
    (System.ComponentModel.DataObjectMethodType.Delete, false)]
    public CommandStatus Delete(ChannelConfig channelConfig)
    {
        CommandStatus status = new CommandStatus();
        try
        {
            var dbChannelConfig = DataContext.ChannelConfigs.SingleOrDefault(cc => cc.Id == channelConfig.Id);
            DataContext.ChannelConfigs.DeleteOnSubmit(dbChannelConfig);
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
    /// Lấy cấu hình một kênh
    /// </summary>
    /// <param name="channelId">string</param>
    /// <returns>ChannelConfig</returns>
    [System.ComponentModel.DataObjectMethod
    (System.ComponentModel.DataObjectMethodType.Select, false)]
    public ChannelConfig Get(string channelId)
    {
        
        return DataContext.ChannelConfigs.SingleOrDefault(cc => cc.Id == channelId);
    }
    /// <summary>
    /// Lấy tất cả cấu hình một logger
    /// </summary>
    /// <param name="loggerId">string</param>
    /// <returns></returns>
    [System.ComponentModel.DataObjectMethod
    (System.ComponentModel.DataObjectMethodType.Select, false)]
    public List<ChannelConfig> GetByLoggerId(string loggerId)
    {
        return DataContext.ChannelConfigs.Where(cc => cc.LoggerId == loggerId).ToList();
    }
    /// <summary>
    /// Thêm mới cấu hình một kênh
    /// </summary>
    /// <param name="channelConfig"></param>
    /// <returns></returns>
    [System.ComponentModel.DataObjectMethod
    (System.ComponentModel.DataObjectMethodType.Insert, false)]
    public CommandStatus Insert(ChannelConfig channelConfig)
    {
        CommandStatus status = new CommandStatus();
        var dbConfig = DataContext.ChannelConfigs.SingleOrDefault(cc => cc.Id == channelConfig.Id);
        if (dbConfig == null)
        {
            DataContext.ChannelConfigs.InsertOnSubmit(channelConfig);
            DataContext.p_Data_Logger_CreateTable(channelConfig.Id);
        }
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
    /// Cập nhật cấu hình một kênh
    /// </summary>
    /// <param name="channelConfig"></param>
    /// <returns></returns>
    [System.ComponentModel.DataObjectMethod
    (System.ComponentModel.DataObjectMethodType.Update, false)]
    public CommandStatus Update(ChannelConfig channelConfig)
    {
        CommandStatus status = new CommandStatus();
        var dbConfig = DataContext.ChannelConfigs.SingleOrDefault(cc => cc.Id == channelConfig.Id);
        if (dbConfig != null)
        {
            dbConfig.Description = channelConfig.Description;
            //dbConfig.Id = channelConfig.Id;
            dbConfig.LoggerId = channelConfig.LoggerId;
            dbConfig.Name = channelConfig.Name;
            dbConfig.Unit = channelConfig.Unit;
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