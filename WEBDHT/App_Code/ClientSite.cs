using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Services;

/// <summary>
/// Summary description for ClientSite
/// </summary>
[WebService(Namespace = "http://tempuri.org/")]
[WebServiceBinding(ConformsTo = WsiProfiles.BasicProfile1_1)]
// To allow this Web Service to be called from script, using ASP.NET AJAX, uncomment the following line. 
// [System.Web.Script.Services.ScriptService]
public class ClientSite : System.Web.Services.WebService {
    SitesBLL _sitesBLL=new SitesBLL();
    DataChartsBLL _dataChartsBLL=new DataChartsBLL();
    UsersBLL _usersBLL = new UsersBLL();
    public ClientSite () {

        //Uncomment the following line if using designed components 
        //InitializeComponent(); 
    }

    [WebMethod]
    public string HelloWorld() {
        return "Hello World";
    }
    /// <summary>
    /// Lấy công ty đang đăng nhập
    /// </summary>
    /// <returns></returns>
    [WebMethod]
    public string GetCompany()
    {
        string username = HttpContext.Current.User.Identity.Name;
        var user = _usersBLL.GetByUid(username);
        return user.Company;
    }
    /// <summary>
    /// Lấy tất cả các điểm lắp đặt của công ty cung cấp
    /// </summary>
    /// <param name="company"></param>
    /// <returns></returns>
    [WebMethod]
    public List<Site> GetAllByCompany(string company)
    {
        return _sitesBLL.GetAllSitesByCalculatedCompany(company);
    }
    /// <summary>
    /// Lấy dữ liệu điểm lắp đặt
    /// </summary>
    /// <param name="siteId"></param>
    /// <param name="start"></param>
    /// <param name="end"></param>
    /// <returns></returns>
    [WebMethod]
    public List<ChartData> GetData(string siteId, DateTime start, DateTime end)
    {
        return _dataChartsBLL.GetOneSiteData(siteId, start, end);
    }
}
