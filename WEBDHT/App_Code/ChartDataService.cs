using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Services;

/// <summary>
/// Summary description for ChartDataService
/// </summary>
[WebService(Namespace = "http://tempuri.org/")]
[WebServiceBinding(ConformsTo = WsiProfiles.BasicProfile1_1)]
// To allow this Web Service to be called from script, using ASP.NET AJAX, uncomment the following line. 
// [System.Web.Script.Services.ScriptService]
public class ChartDataService : System.Web.Services.WebService {
    DataChartsBLL _dataChartsBLL = new DataChartsBLL();
    SitesBLL _sitesBLL = new SitesBLL();
    public ChartDataService () {

        //Uncomment the following line if using designed components 
        //InitializeComponent(); 
    }

    [WebMethod]
    public string HelloWorld() {
        return "Hello World";
    }
    /// <summary>
    /// Lấy dữ liệu sản lượng một điểm lắp đặt
    /// </summary>
    /// <param name="siteId"></param>
    /// <param name="start"></param>
    /// <param name="end"></param>
    /// <returns></returns>
    [WebMethod]
    public List<ChartData> GetSiteData(string siteId, DateTime start, DateTime end)
    {
        return _dataChartsBLL.GetOneSiteData(siteId, start, end);
    }
    /// <summary>
    /// Lấy dữ liệu sản lượng nhóm điểm lắp đặt
    /// </summary>
    /// <param name="group"></param>
    /// <param name="start"></param>
    /// <param name="end"></param>
    /// <returns></returns>
    [WebMethod]
    public List<ChartData> GetGroupData(string group, DateTime start, DateTime end)
    {
        return _dataChartsBLL.GetOneGroupData(group, start, end);
    }
    /// <summary>
    /// Lấy dữ liệu sản lượng một nhóm và một điểm
    /// </summary>
    /// <param name="siteId"></param>
    /// <param name="group"></param>
    /// <param name="start"></param>
    /// <param name="end"></param>
    /// <returns></returns>
    [WebMethod]
    public ChartSiteAndGroupData GetSiteAndGroupData(string siteId, string group, DateTime start, DateTime end)
    {
        ChartSiteAndGroupData obj = new ChartSiteAndGroupData();
        obj.ListGroupData = GetGroupData(group, start, end);
        obj.ListSiteData = GetSiteData(siteId, start, end);
        return obj;
    }
    /// <summary>
    /// Lấy dữ liệu nhóm (2)
    /// </summary>
    /// <param name="group"></param>
    /// <param name="start"></param>
    /// <param name="end"></param>
    /// <returns></returns>
    [WebMethod]
    public List<ChartData> GetGroup2Data(string group, DateTime start, DateTime end)
    {
        return _dataChartsBLL.GetOneGroup2Data(group, start, end);
    }

    /// <summary>
    /// Lấy dữ liệu nhóm (3)
    /// </summary>
    /// <param name="group"></param>
    /// <param name="start"></param>
    /// <param name="end"></param>
    /// <returns></returns>
    [WebMethod]
    public List<ChartData> GetGroup3Data(string group, DateTime start, DateTime end)
    {
        return _dataChartsBLL.GetOneGroup3Data(group, start, end);
    }

    /// <summary>
    /// Lấy dữ liệu nhóm (4)
    /// </summary>
    /// <param name="group"></param>
    /// <param name="start"></param>
    /// <param name="end"></param>
    /// <returns></returns>
    [WebMethod]
    public List<ChartData> GetGroup4Data(string group, DateTime start, DateTime end)
    {
        return _dataChartsBLL.GetOneGroup4Data(group, start, end);
    }

    /// <summary>
    /// Lấy dữ liệu nhóm (5)
    /// </summary>
    /// <param name="group"></param>
    /// <param name="start"></param>
    /// <param name="end"></param>
    /// <returns></returns>
    [WebMethod]
    public List<ChartData> GetGroup5Data(string group, DateTime start, DateTime end)
    {
        return _dataChartsBLL.GetOneGroup5Data(group, start, end);
    }

    /// <summary>
    /// Lấy dữ liệu sản lượng một nhóm và một điểm
    /// </summary>
    /// <param name="siteId"></param>
    /// <param name="group"></param>
    /// <param name="start"></param>
    /// <param name="end"></param>
    /// <returns></returns>
    [WebMethod]
    public ChartSiteAndGroupData GetSiteAndGroup2Data(string siteId, string group, DateTime start, DateTime end)
    {
        ChartSiteAndGroupData obj = new ChartSiteAndGroupData();
        obj.ListGroupData = GetGroup2Data(group, start, end);
        obj.ListSiteData = GetSiteData(siteId, start, end);
        return obj;
    }

    [WebMethod]
    public List<ChartData> GetCompanyData(string company, DateTime start, DateTime end)
    {
        return _dataChartsBLL.GetOneCompanyData(company, start, end);
    }

    [WebMethod]
    public List<ChartData> GetMCompanyData(string company, DateTime start, DateTime end)
    {
        return _dataChartsBLL.GetOneMCompanyData(company, start, end);
    }

    [WebMethod]
    public ChartCompanyAndGroupData GetCompanyAndGroupData(string company, string group, DateTime start, DateTime end)
    {
        ChartCompanyAndGroupData obj = new ChartCompanyAndGroupData();
        obj.ListGroupData = GetGroupData(group, start, end);
        obj.ListCompanyData = GetCompanyData(company, start, end);
        return obj;
    }

    [WebMethod]
    public ChartCompanyAndGroupData GetCompanyAndGroup2Data(string company, string group, DateTime start, DateTime end)
    {
        ChartCompanyAndGroupData obj = new ChartCompanyAndGroupData();
        obj.ListGroupData = GetGroup2Data(group, start, end);
        obj.ListCompanyData = GetCompanyData(company, start, end);
        return obj;
    }

    [WebMethod]
    public ChartSiteAndCompanyData GetSiteAndCompanyData(string site, string company, DateTime start, DateTime end)
    {
        ChartSiteAndCompanyData obj = new ChartSiteAndCompanyData();
        obj.ListSiteData = GetSiteData(site, start, end);
        obj.ListCompanyData = GetCompanyData(company, start, end);
        return obj;
    }
}
public class ChartSiteAndGroupData
{
    public List<ChartData> ListSiteData { get; set; }
    public List<ChartData> ListGroupData { get; set; }
}

public class ChartCompanyAndGroupData
{
    public List<ChartData> ListCompanyData { get; set; }
    public List<ChartData> ListGroupData { get; set; }
}

public class ChartSiteAndCompanyData{
    public List<ChartData>ListSiteData{get;set;}
    public List<ChartData>ListCompanyData{get;set;}
}

