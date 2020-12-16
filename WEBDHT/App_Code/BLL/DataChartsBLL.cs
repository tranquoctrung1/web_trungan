using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

/// <summary>
/// Lấy dữ liệu cho webservice dùng cho các đồ thị
/// </summary>
/// 
[System.ComponentModel.DataObject]
public class DataChartsBLL
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
    /// Lấy dữ liệu một điểm lắp đặt theo ngày bắt đầu và ngày kết thúc
    /// </summary>
    /// <param name="siteId"></param>
    /// <param name="start"></param>
    /// <param name="end"></param>
    /// <returns></returns>
    [System.ComponentModel.DataObjectMethod
    (System.ComponentModel.DataObjectMethodType.Select, false)]
    public List<ChartData> GetOneSiteData(string siteId, DateTime start, DateTime end)
    {
        return DataContext.p_Calculate_One_Site_Daily_Output(siteId, start, end).ToList();
    }
    /// <summary>
    /// Lấy dữ liệu một nhóm điểm lắp đặt theo ngày bắt đầu và ngày kết thúc
    /// </summary>
    /// <param name="group"></param>
    /// <param name="start"></param>
    /// <param name="end"></param>
    /// <returns></returns>
    [System.ComponentModel.DataObjectMethod
    (System.ComponentModel.DataObjectMethodType.Select, false)]
    public List<ChartData> GetOneGroupData(string group, DateTime start, DateTime end)
    {
        return DataContext.p_Calculate_One_Group_Daily_Output(group, start, end).ToList();
    }
    /// <summary>
    /// Lấy dữ liệu nhóm điểm lắp đặt 2 theo ngày bắt đầu và ngày kết thúc
    /// </summary>
    /// <param name="group"></param>
    /// <param name="start"></param>
    /// <param name="end"></param>
    /// <returns></returns>
    [System.ComponentModel.DataObjectMethod
    (System.ComponentModel.DataObjectMethodType.Select, false)]
    public List<ChartData> GetOneGroup2Data(string group, DateTime start, DateTime end)
    {
        return DataContext.p_Calculate_One_Group2_Daily_Output(group, start, end).ToList();
    }

    /// <summary>
    /// Lấy dữ liệu nhóm điểm lắp đặt 3 theo ngày bắt đầu và ngày kết thúc
    /// </summary>
    /// <param name="group"></param>
    /// <param name="start"></param>
    /// <param name="end"></param>
    /// <returns></returns>
    [System.ComponentModel.DataObjectMethod
    (System.ComponentModel.DataObjectMethodType.Select, false)]
    public List<ChartData> GetOneGroup3Data(string group, DateTime start, DateTime end)
    {
        return DataContext.p_Calculate_One_Group3_Daily_Output(group, start, end).ToList();
    }

    /// <summary>
    /// Lấy dữ liệu nhóm điểm lắp đặt 4 theo ngày bắt đầu và ngày kết thúc
    /// </summary>
    /// <param name="group"></param>
    /// <param name="start"></param>
    /// <param name="end"></param>
    /// <returns></returns>
    [System.ComponentModel.DataObjectMethod
    (System.ComponentModel.DataObjectMethodType.Select, false)]
    public List<ChartData> GetOneGroup4Data(string group, DateTime start, DateTime end)
    {
        return DataContext.p_Calculate_One_Group4_Daily_Output(group, start, end).ToList();
    }

    /// <summary>
    /// Lấy dữ liệu nhóm điểm lắp đặt 5 theo ngày bắt đầu và ngày kết thúc
    /// </summary>
    /// <param name="group"></param>
    /// <param name="start"></param>
    /// <param name="end"></param>
    /// <returns></returns>
    [System.ComponentModel.DataObjectMethod
    (System.ComponentModel.DataObjectMethodType.Select, false)]
    public List<ChartData> GetOneGroup5Data(string group, DateTime start, DateTime end)
    {
        return DataContext.p_Calculate_One_Group5_Daily_Output(group, start, end).ToList();
    }

    [System.ComponentModel.DataObjectMethod
    (System.ComponentModel.DataObjectMethodType.Select, false)]
    public List<ChartData> GetOneCompanyData(string company, DateTime start, DateTime end)
    {
        return DataContext.p_Calculate_One_Company_Output(company, start, end).ToList();
    }

    [System.ComponentModel.DataObjectMethod
    (System.ComponentModel.DataObjectMethodType.Select, false)]
    public List<ChartData> GetOneMCompanyData(string company, DateTime start, DateTime end)
    {
        return DataContext.p_Calculate_One_MCompany_Output(company, start, end).ToList();
    }
}