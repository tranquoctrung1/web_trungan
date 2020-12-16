using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

/// <summary>
/// Truy vấn xữ lý dữ liệu lưu thông tin các file đồng hồ đã upload 
/// </summary>
/// 
[System.ComponentModel.DataObject]
public class MeterFilesBLL
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
    /// Xóa thông tin các file đã lựa chọn
    /// </summary>
    /// <param name="listFiles"></param>
    /// <returns></returns>
    [System.ComponentModel.DataObjectMethod
    (System.ComponentModel.DataObjectMethodType.Delete, false)]
    public CommandStatus Delete(List<string> listFiles)
    {
        CommandStatus status = new CommandStatus();
        foreach (var fileName in listFiles)
        {
            var dbFile = DataContext.MeterFiles.SingleOrDefault(f => f.FileName == fileName);
            if (dbFile != null)
            {
                DataContext.MeterFiles.DeleteOnSubmit(dbFile);
            }
        }
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
    /// Lấy thông tin một file theo tên file
    /// </summary>
    /// <param name="fileName"></param>
    /// <returns></returns>
    [System.ComponentModel.DataObjectMethod
    (System.ComponentModel.DataObjectMethodType.Select, false)]
    public MeterFile GetByFileName(string fileName)
    {
        return DataContext.MeterFiles.SingleOrDefault(f => f.FileName == fileName);
    }
    /// <summary>
    /// Lấy tất cả thông tin file của một đồng hồ
    /// </summary>
    /// <param name="meterSerial"></param>
    /// <returns></returns>
    [System.ComponentModel.DataObjectMethod
    (System.ComponentModel.DataObjectMethodType.Select, false)]
    public IQueryable<MeterFile> GetAllByMeterSerial(string meterSerial)
    {
        return DataContext.MeterFiles.OrderBy(f => f.FileName).Where(f => f.Serial == meterSerial);
    }
    /// <summary>
    /// Thêm mới thông tin một file vào database khi upload
    /// </summary>
    /// <param name="file"></param>
    /// <returns></returns>
    [System.ComponentModel.DataObjectMethod
    (System.ComponentModel.DataObjectMethodType.Insert, false)]
    public CommandStatus Insert(MeterFile file)
    {
        CommandStatus status = new CommandStatus();
        DataContext.MeterFiles.InsertOnSubmit(file);
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
    /// Cập nhật thông tin file
    /// </summary>
    /// <param name="file"></param>
    /// <returns></returns>
    [System.ComponentModel.DataObjectMethod
    (System.ComponentModel.DataObjectMethodType.Update, false)]
    public CommandStatus Update(MeterFile file)
    {
        CommandStatus status = new CommandStatus();
        var dbFile = DataContext.MeterFiles.SingleOrDefault(f => f.FileName == file.FileName && f.Serial == file.Serial);
        if (dbFile != null)
        {
            dbFile.MIMEType = file.MIMEType;
            dbFile.FileName = file.FileName;
            dbFile.Path = file.Path;
            dbFile.Serial = file.Serial;
            dbFile.Size = file.Size;
            dbFile.UploadDate = file.UploadDate;
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
        }
        return status;
    }
}