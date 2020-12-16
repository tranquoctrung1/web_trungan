using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

/// <summary>
/// Tính toán các báo cáo sản lượng sử dụng store procedure
/// </summary>
/// 
[System.ComponentModel.DataObject]
public class ReportOutputsBLL
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
    /// Tính toán báo cáo biên bản sản lượng đơn vị ngày
    /// </summary>
    /// <param name="company"></param>
    /// <param name="start"></param>
    /// <param name="end"></param>
    /// <returns></returns>
    [System.ComponentModel.DataObjectMethod
    (System.ComponentModel.DataObjectMethodType.Select, false)]
    public List<ReportData> GetDalilyReport(string company, DateTime start, DateTime end)
    {
        return DataContext.p_Calculate_Daily_Report(company, start, end).ToList();
    }
    /// <summary>
    /// Tính toán báo cáo sản lượng
    /// </summary>
    /// <param name="company"></param>
    /// <param name="start"></param>
    /// <param name="end"></param>
    /// <returns></returns>
    [System.ComponentModel.DataObjectMethod
    (System.ComponentModel.DataObjectMethodType.Select, false)]
    public List<ReportDailyData> GetDailyOutput(string company, DateTime start, DateTime end)
    {
        return DataContext.p_Calculate_Daily_Output(company, start, end).ToList();
    }
    /// <summary>
    /// Tính toán sản lượng logger
    /// </summary>
    /// <param name="company"></param>
    /// <param name="start"></param>
    /// <param name="end"></param>
    /// <returns></returns>
    [System.ComponentModel.DataObjectMethod
    (System.ComponentModel.DataObjectMethodType.Select, false)]
    public List<ReportDailyData> GetAllDailyLoggerOutput(string company, DateTime start, DateTime end)
    {
        return DataContext.p_Calculate_Logger_Daily_Output(company, start, end).ToList();
    }
    /// <summary>
    /// Tính toán sản lượng theo cho các đơn vị quản lý
    /// </summary>
    /// <param name="company"></param>
    /// <param name="start"></param>
    /// <param name="end"></param>
    /// <returns></returns>
    [System.ComponentModel.DataObjectMethod
    (System.ComponentModel.DataObjectMethodType.Select, false)]
    public List<ReportDailyData> GetDailyOutputByCompany(string company, DateTime start, DateTime end)
    {
        return DataContext.p_Calculate_Daily_Output_By_Company(company, start, end).ToList();
    }
    /// <summary>
    /// Tính toán báo cáo cho nhóm đồng hồ
    /// </summary>
    /// <param name="group"></param>
    /// <param name="start"></param>
    /// <param name="end"></param>
    /// <returns></returns>
    [System.ComponentModel.DataObjectMethod
    (System.ComponentModel.DataObjectMethodType.Select, false)]
    public List<ReportDailyData> GetDailyOutputByGroup(string group, DateTime start, DateTime end)
    {
        return DataContext.p_Calculate_Daily_Output_By_Group(group, start, end).ToList();
    }
    /// <summary>
    /// Tính toán báo cáo cho nhóm đồng hồ 2
    /// </summary>
    /// <param name="group"></param>
    /// <param name="start"></param>
    /// <param name="end"></param>
    /// <returns></returns>
    [System.ComponentModel.DataObjectMethod
    (System.ComponentModel.DataObjectMethodType.Select, false)]
    public List<ReportDailyData> GetDailyOutputByGroup2(string group, DateTime start, DateTime end)
    {
        return DataContext.p_Calculate_Daily_Output_By_Group2(group, start, end).ToList();
    }
    /// <summary>
    /// Tính toán báo cáo cho nhóm đồng hồ 3
    /// </summary>
    /// <param name="group"></param>
    /// <param name="start"></param>
    /// <param name="end"></param>
    /// <returns></returns>
    [System.ComponentModel.DataObjectMethod
    (System.ComponentModel.DataObjectMethodType.Select, false)]
    public List<ReportDailyData> GetDailyOutputByGroup3(string group, DateTime start, DateTime end)
    {
        return DataContext.p_Calculate_Daily_Output_By_Group3(group, start, end).ToList();
    }
    /// <summary>
    /// Tính toán báo cáo cho nhóm đồng hồ 4
    /// </summary>
    /// <param name="group"></param>
    /// <param name="start"></param>
    /// <param name="end"></param>
    /// <returns></returns>
    [System.ComponentModel.DataObjectMethod
    (System.ComponentModel.DataObjectMethodType.Select, false)]
    public List<ReportDailyData> GetDailyOutputByGroup4(string group, DateTime start, DateTime end)
    {
        return DataContext.p_Calculate_Daily_Output_By_Group4(group, start, end).ToList();
    }
    /// <summary>
    /// Tính toán báo cáo cho nhóm đồng hồ 5
    /// </summary>
    /// <param name="group"></param>
    /// <param name="start"></param>
    /// <param name="end"></param>
    /// <returns></returns>
    [System.ComponentModel.DataObjectMethod
    (System.ComponentModel.DataObjectMethodType.Select, false)]
    public List<ReportDailyData> GetDailyOutputByGroup5(string group, DateTime start, DateTime end)
    {
        return DataContext.p_Calculate_Daily_Output_By_Group5(group, start, end).ToList();
    }
    /// <summary>
    /// Tính toán báo cáo sản lượng theo cấp đồng hồ
    /// </summary>
    /// <param name="level"></param>
    /// <param name="start"></param>
    /// <param name="end"></param>
    /// <returns></returns>
    [System.ComponentModel.DataObjectMethod
    (System.ComponentModel.DataObjectMethodType.Select, false)]
    public List<ReportDailyData> GetDailyOutputByLevel(string level, DateTime start, DateTime end)
    {
        return DataContext.p_Calculate_Daily_Output_By_Level(level, start, end).ToList();
    }
    /// <summary>
    /// Tính toán báo cáo sản lượng tổng hợp
    /// </summary>
    /// <param name="start"></param>
    /// <param name="end"></param>
    /// <returns></returns>
    [System.ComponentModel.DataObjectMethod
    (System.ComponentModel.DataObjectMethodType.Select, false)]
    public List<ReportDailyData> GetAllDailyOutput(DateTime start, DateTime end)
    {
        return DataContext.p_Calculate_Daily_Output_All(start, end).ToList();
    }
}