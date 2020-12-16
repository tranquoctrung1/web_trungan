using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

/// <summary>
/// Xử lý dữ liệu nhập tay, truy vấn bảng t_Data_Manuals
/// </summary>
/// 
[System.ComponentModel.DataObject]
public class DataBLL
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
    /// Xóa dữ liệu nhập tay theo mã vị trí, ngày bắt đầu, ngày kết thúc
    /// </summary>
    /// <param name="siteId"></param>
    /// <param name="start"></param>
    /// <param name="end"></param>
    /// <returns></returns>
    [System.ComponentModel.DataObjectMethod
    (System.ComponentModel.DataObjectMethodType.Delete)]
    public CommandStatus Delete(string siteId, DateTime start, DateTime end)
    {
        CommandStatus status = new CommandStatus();
        IEnumerable<ManualData> dbData = from d in DataContext.ManualDatas
                                         where d.SiteId == siteId && d.TimeStamp >= start && d.TimeStamp <= end
                                         select d;
        DataContext.ManualDatas.DeleteAllOnSubmit(dbData);
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
    /// Lấy dữ liệu nhập tay theo mã vị trí, ngày bắt đầu, ngày kết thúc
    /// </summary>
    /// <param name="siteId"></param>
    /// <param name="start"></param>
    /// <param name="end"></param>
    /// <returns></returns>
    [System.ComponentModel.DataObjectMethod
    (System.ComponentModel.DataObjectMethodType.Select)]
    public List<ManualData> Get(string siteId, DateTime start, DateTime end)
    {
        return DataContext.ManualDatas.Where(d => d.SiteId == siteId && d.TimeStamp >= start && d.TimeStamp <= end).OrderBy(d=>d.TimeStamp).ToList();
    }
    /// <summary>
    /// Lấy dữ liệu nhập tay cuối cùng của một mã vị trí
    /// </summary>
    /// <param name="siteId"></param>
    /// <returns></returns>
    [System.ComponentModel.DataObjectMethod
    (System.ComponentModel.DataObjectMethodType.Select)]
    public List<ManualData> GetLatest(string siteId)
    {
        List<ManualData> list = new List<ManualData>();
        DateTime? lastDate = DataContext.ManualDatas.Where(d => d.SiteId == siteId).Select(d => d.TimeStamp).Max();
        if (lastDate != null)
        {
            ManualData data = DataContext.ManualDatas.SingleOrDefault(d => d.SiteId == siteId && d.TimeStamp == lastDate);
            list.Add(data);
        }
        return list;
    }
    /// <summary>
    /// Lấy dữ liệu nhập tay một ngày của một mã vị trí
    /// </summary>
    /// <param name="siteId"></param>
    /// <param name="timeStamp"></param>
    /// <returns></returns>
    [System.ComponentModel.DataObjectMethod
    (System.ComponentModel.DataObjectMethodType.Select)]
    public ManualData Get(string siteId, DateTime timeStamp)
    {
        return DataContext.ManualDatas.SingleOrDefault(d => d.SiteId == siteId && d.TimeStamp == timeStamp);
    }
    /// <summary>
    /// Thêm hoặc cập nhật dữ liệu nhập tay
    /// </summary>
    /// <param name="list"></param>
    /// <returns></returns>
    [System.ComponentModel.DataObjectMethod
    (System.ComponentModel.DataObjectMethodType.Insert)]
    public CommandStatus InsertOrUpdate(List<ManualData> list){
        CommandStatus status=new CommandStatus();
        foreach (var data in list)
        {
            ManualData dbData = new ManualData();
            dbData = DataContext.ManualDatas.SingleOrDefault(d => d.SiteId == data.SiteId && d.TimeStamp == data.TimeStamp);
            if (dbData == null)
            {
                DataContext.ManualDatas.InsertOnSubmit(data);
            }
            else
            {
                dbData.Description = data.Description;
                dbData.Index = data.Index;
                dbData.Output = data.Output;
            }
        }
        try
        {
            DataContext.SubmitChanges();
        }
        catch (Exception ex)
        {
            status.ErrorMessage = ex.Message;
            status.Error = true;
        }
        return status;
	}
    /// <summary>
    /// Tính toán chia trung bình để hiển thị lên giao diện nhập chỉ số
    /// </summary>
    /// <param name="list"></param>
    public void CalculateGridIndex(ref List<ManualData> list)
    {
        int rowCount = list.Count();
        if (rowCount == 1)
        {
            list.Add(new ManualData());
            return;
        }
        string siteId = list[0].SiteId;
        string description = list[rowCount - 1].Description;
        double lastIndex = (double)list[rowCount - 1].Index;
        double previousIndex = (double)list[rowCount - 2].Index;
        DateTime lastDate = (DateTime)list[rowCount - 1].TimeStamp;
        DateTime previousDate = (DateTime)list[rowCount - 2].TimeStamp;
        int totalDay = Convert.ToInt32(lastDate.Subtract(previousDate).TotalDays);
        int totalOutput = Convert.ToInt32(lastIndex - previousIndex);
        if (totalDay == 1) list[rowCount - 1].Output = totalOutput;
        else if (totalDay <= 0) return;
        else
        {
            list.RemoveAt(rowCount - 1);
            int modulus = totalOutput % totalDay;
            int avgOutput = totalOutput / totalDay;
            for (int i = 1; i <= totalDay; i++)
            {
                ManualData data = new ManualData();
                data.Description = description;
                data.SiteId = siteId;
                if (i == totalDay)
                {
                    data.TimeStamp = lastDate;
                    data.Index = lastIndex;
                    data.Output = avgOutput + modulus;
                }
                else
                {
                    data.TimeStamp = previousDate.AddDays(i);
                    data.Index = previousIndex + avgOutput * i;
                    data.Output = avgOutput;
                }
                list.Add(data);
            }
        }
        list.Add(new ManualData());
    }
    /// <summary>
    /// Tính toán chia trung bình hiển thị lên giao diện nhập sản lượng
    /// </summary>
    /// <param name="list"></param>
    public void CalculateGridOutput(ref List<ManualData> list)
    {
        int rowCount = list.Count();
        if (rowCount == 1)
        {
            list.Add(new ManualData());
            return;
        }
        string siteId = list[0].SiteId;
        string description = list[rowCount - 1].Description;
        double lastOutput = (double)list[rowCount - 1].Output;
        double previousOutput = (double)list[rowCount - 2].Output;
        DateTime lastDate = (DateTime)list[rowCount - 1].TimeStamp;
        DateTime previousDate = (DateTime)list[rowCount - 2].TimeStamp;
        int totalDay = Convert.ToInt32(lastDate.Subtract(previousDate).TotalDays);
        if (totalDay == 1) list[rowCount - 1].Output = lastOutput;
        else if (totalDay <= 0)
        {
            return;
        }
        else
        {
            list.RemoveAt(rowCount - 1);
            int t = Convert.ToInt32(lastOutput);
            int modulus = t % totalDay;
            int avgOutput = t / totalDay;
            for (int i = 1; i <= totalDay; i++)
            {
                ManualData data = new ManualData();
                data.Description = description;
                data.SiteId = siteId;
                if (i == totalDay)
                {
                    data.TimeStamp = lastDate;
                    data.Output = avgOutput + modulus;
                }
                else
                {
                    data.TimeStamp = previousDate.AddDays(i);
                    data.Output = avgOutput;
                }
                list.Add(data);
            }
        }
        list.Add(new ManualData());
    }
}