using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

/// <summary>
/// Truy vẫn dữ liệu thiết bị logger t_Devices_Loggers
/// </summary>
/// 
[System.ComponentModel.DataObject]
public class LoggersBLL
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
    /// Xóa dữ liệu một logger
    /// </summary>
    /// <param name="serial"></param>
    /// <returns></returns>
    [System.ComponentModel.DataObjectMethod
    (System.ComponentModel.DataObjectMethodType.Delete, false)]
    public CommandStatus Delete(string serial)
    {
        CommandStatus status = new CommandStatus();
        var dbLogger = DataContext.Loggers.SingleOrDefault(l => l.Serial == serial);
        DataContext.Loggers.DeleteOnSubmit(dbLogger);
        try
        {
            DataContext.SubmitChanges();
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
    /// Xóa tất cả các logger không sử dụng (không tồn tại trong lịch sử và điểm lắp đặt)
    /// </summary>
    /// <param name="listSerial"></param>
    /// <returns></returns>
    [System.ComponentModel.DataObjectMethod
    (System.ComponentModel.DataObjectMethodType.Delete, false)]
    public CommandStatus DeleteUseless(List<string> listSerial)
    {
        CommandStatus status = new CommandStatus();
        var uselessLoggers = DataContext.Loggers.Where(l => listSerial.Contains(l.Serial));
        DataContext.Loggers.DeleteAllOnSubmit(uselessLoggers);
        try
        {
            DataContext.SubmitChanges();
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
    /// Lấy tất cả các logger
    /// </summary>
    /// <returns></returns>
    [System.ComponentModel.DataObjectMethod
    (System.ComponentModel.DataObjectMethodType.Select, false)]
    public IOrderedQueryable<Logger> GetAll()
    {
        return DataContext.Loggers.OrderBy(l => l.Serial);
    }
    /// <summary>
    /// Lấy tất cả các logger không sử dụng
    /// </summary>
    /// <returns></returns>
    [System.ComponentModel.DataObjectMethod
    (System.ComponentModel.DataObjectMethodType.Select, false)]
    public IOrderedQueryable<Logger> GetAllUseless()
    {
        SiteLoggerHistoriesBLL _siteLoggerHistoriesBLL = new SiteLoggerHistoriesBLL();
        var list = _siteLoggerHistoriesBLL.GetAllLoggerSerial();
        var usingLoggers = DataContext.Sites.Select(s => s.Logger).Distinct();
        return DataContext.Loggers.Where(l => !usingLoggers.Contains(l.Serial) && !list.Contains(l.Serial)).OrderBy(l => l.Serial);
    }
    /// <summary>
    /// Lấy tất cả các logger đã lắp đặt
    /// </summary>
    /// <param name="installed"></param>
    /// <returns></returns>
    [System.ComponentModel.DataObjectMethod
    (System.ComponentModel.DataObjectMethodType.Select, false)]
    public IQueryable<Logger> GetAllByInstalled(bool installed)
    {
        return DataContext.Loggers.OrderBy(l => l.Serial).Where(l => l.Installed == installed);
    }
    /// <summary>
    /// Lấy tất cả số seri logger
    /// </summary>
    /// <returns></returns>
    [System.ComponentModel.DataObjectMethod
    (System.ComponentModel.DataObjectMethodType.Select, false)]
    public IQueryable<string> GetAllSerials()
    {
        return DataContext.Loggers.OrderBy(l => l.Serial).Select(l => l.Serial);
    }
    /// <summary>
    /// Lấy tất cả nhà sản xuất
    /// </summary>
    /// <returns></returns>
    [System.ComponentModel.DataObjectMethod
    (System.ComponentModel.DataObjectMethodType.Select, false)]
    public IQueryable<string> GetAllProviders()
    {
        return DataContext.Loggers.OrderBy(l => l.Provider).Select(l => l.Provider ?? string.Empty).Distinct();
    }
    /// <summary>
    /// Lấy tất cả hiệu
    /// </summary>
    /// <returns></returns>
    [System.ComponentModel.DataObjectMethod
    (System.ComponentModel.DataObjectMethodType.Select, false)]
    public IQueryable<string> GetAllMarks()
    {
        return DataContext.Loggers.OrderBy(l => l.Marks).Select(l => l.Marks ?? string.Empty).Distinct();
    }
    /// <summary>
    /// Lấy tất cả model
    /// </summary>
    /// <returns></returns>
    [System.ComponentModel.DataObjectMethod
    (System.ComponentModel.DataObjectMethodType.Select, false)]
    public IQueryable<string> GetAllModels()
    {
        return DataContext.Loggers.OrderBy(l => l.Model).Select(l => l.Model ?? string.Empty).Distinct();
    }
    /// <summary>
    /// Lấy thông tin một logger theo số seri
    /// </summary>
    /// <param name="serial"></param>
    /// <returns></returns>
    [System.ComponentModel.DataObjectMethod
    (System.ComponentModel.DataObjectMethodType.Select, false)]
    public Logger GetBySerial(string serial)
    {
        return DataContext.Loggers.SingleOrDefault(l => l.Serial == serial);
    }
    /// <summary>
    /// Thêm mới một logger
    /// </summary>
    /// <param name="logger"></param>
    /// <returns></returns>
    [System.ComponentModel.DataObjectMethod
    (System.ComponentModel.DataObjectMethodType.Insert, false)]
    public CommandStatus Insert(Logger logger)
    {
        CommandStatus status = new CommandStatus();
        DataContext.Loggers.InsertOnSubmit(logger);
        try
        {
            DataContext.SubmitChanges();
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
    /// Cập nhật dữ liệu một logger
    /// </summary>
    /// <param name="logger"></param>
    /// <returns></returns>
    [System.ComponentModel.DataObjectMethod
    (System.ComponentModel.DataObjectMethodType.Update, false)]
    public CommandStatus Update(Logger logger)
    {
        CommandStatus status = new CommandStatus();
        var dbLogger = DataContext.Loggers.SingleOrDefault(l => l.Serial == logger.Serial);
        dbLogger.Description = logger.Description;
        dbLogger.Installed = logger.Installed;
        dbLogger.Marks = logger.Marks;
        dbLogger.Model = logger.Model;
        dbLogger.Provider = logger.Provider;
        dbLogger.ReceiptDate = logger.ReceiptDate;
        dbLogger.Serial = logger.Serial;
        dbLogger.Status = logger.Status;
        try
        {
            DataContext.SubmitChanges();
            status.Updated = true;
        }
        catch (Exception e)
        {
            status.Error = true;
            status.ErrorMessage = e.Message;
        }
        return status;
    }
    /// <summary>
    /// List các logger theo tiêu chí về: nhà sản xuất, hiệu, model, trạng thái thiết bị, đã lắp đặt, trạng thái điểm lắp đặt, quản lý
    /// </summary>
    /// <param name="listProviders"></param>
    /// <param name="listMarks"></param>
    /// <param name="listModels"></param>
    /// <param name="listStatus"></param>
    /// <param name="listInstalled"></param>
    /// <param name="listSiteStatus"></param>
    /// <param name="listSiteCompanies"></param>
    /// <returns></returns>
    public List<LoggerViewModel> GetAllByConds(List<string> listProviders, List<string> listMarks,
        List<string> listModels, List<string> listStatus, List<bool> listInstalled,
        List<string> listSiteStatus, List<string> listSiteCompanies)
    {
        var list = (from l in DataContext.Loggers
                    join s in DataContext.Sites on l.Serial equals s.Logger into ls
                    where listProviders.Contains(l.Provider ?? "")
                    && listMarks.Contains(l.Marks ?? "")
                    && listModels.Contains(l.Model ?? "")
                    && listStatus.Contains(l.Status ?? "")
                    && listInstalled.Contains(l.Installed ?? false)
                    orderby l.Serial
                    from s in ls.DefaultIfEmpty()
                    where l.Serial != string.Empty
                    && listSiteStatus.Contains(s.Status ?? "")
                    && listSiteCompanies.Contains(s.Company ?? "")
                    select new LoggerViewModel
                    {
                        Serial = l.Serial,
                        ReceiptDate = l.ReceiptDate,
                        Provider = l.Provider,
                        Marks = l.Marks,
                        Model = l.Model,
                        Status = l.Status,
                        Installed = l.Installed,
                        Description = l.Description,
                        SiteId = s.Id,
                        Location = s.Location,
                        SiteStatus = s.Status,
                        SiteCompany = s.Company
                    }).ToList();
        foreach (var item in list)
        {
            var loggerConfig = DataContext.SiteConfigs.SingleOrDefault(c => c.SiteId == item.SiteId);
            if (loggerConfig!=null)
            {
                item.LoggerId = loggerConfig.Id;
            }
        }
        return list;
    }
}