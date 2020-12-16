using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Services;

/// <summary>
/// Summary description for SitesService
/// </summary>
[WebService(Namespace = "http://tempuri.org/")]
[WebServiceBinding(ConformsTo = WsiProfiles.BasicProfile1_1)]
// To allow this Web Service to be called from script, using ASP.NET AJAX, uncomment the following line. 
// [System.Web.Script.Services.ScriptService]
public class SitesService : System.Web.Services.WebService {
    SitesBLL _sitesBLL=new SitesBLL();
    SiteGroupsBLL _sitesGroupsBLL = new SiteGroupsBLL();
    SiteGroup2sBLL _siteGroup2sBLL = new SiteGroup2sBLL();
    SiteGroup3sBLL _siteGroup3sBLL = new SiteGroup3sBLL();
    SiteGroup4sBLL _siteGroup4sBLL = new SiteGroup4sBLL();
    SiteGroup5sBLL _siteGroup5sBLL = new SiteGroup5sBLL();
    SiteCompaniesBLL _siteCompaniesBLL = new SiteCompaniesBLL();

    public SitesService () {

        //Uncomment the following line if using designed components 
        //InitializeComponent(); 
    }

    [WebMethod]
    public string HelloWorld() {
        return "Hello World";
    }
    /// <summary>
    /// Lấy tất cả điểm lắp đặt
    /// </summary>
    /// <returns></returns>
    [WebMethod]
    public List<Site> GetAllSites()
    {
        return _sitesBLL.GetAll().ToList();
    }
    /// <summary>
    /// Lấy tất cả nhóm điểm lắp đặt
    /// </summary>
    /// <returns></returns>
    [WebMethod]
    public List<SiteGroup>GetAllGroup()
    {
        return _sitesGroupsBLL.GetAll().ToList();
    }
    /// <summary>
    /// Lấy tất cả nhóm điểm lắp đặt 2
    /// </summary>
    /// <returns></returns>
    [WebMethod]
    public List<SiteGroup2> GetAllGroup2()
    {
        return _siteGroup2sBLL.GetAll().ToList();
    }
    /// <summary>
    /// Lấy tất cả nhóm điểm lắp đặt 3
    /// </summary>
    /// <returns></returns>
    [WebMethod]
    public List<SiteGroup3> GetAllGroup3()
    {
        return _siteGroup3sBLL.GetAll().ToList();
    }
    /// <summary>
    /// Lấy tất cả nhóm điểm lắp đặt 4
    /// </summary>
    /// <returns></returns>
    [WebMethod]
    public List<SiteGroup4> GetAllGroup4()
    {
        return _siteGroup4sBLL.GetAll().ToList();
    }
    /// <summary>
    /// Lấy tất cả nhóm điểm lắp đặt 5
    /// </summary>
    /// <returns></returns>
    [WebMethod]
    public List<SiteGroup5> GetAllGroup5()
    {
        return _siteGroup5sBLL.GetAll().ToList();
    }
    /// <summary>
    /// Lấy tất cả công ty cấp nước
    /// </summary>
    /// <returns></returns>
    [WebMethod]
    public List<SiteCompany> GetAllCompanies()
    {
        return _siteCompaniesBLL.GetAll().ToList();
    }
}
