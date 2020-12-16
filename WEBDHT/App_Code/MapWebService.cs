using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Services;

/// <summary>
/// Summary description for MapWebService
/// </summary>
[WebService(Namespace = "http://tempuri.org/")]
[WebServiceBinding(ConformsTo = WsiProfiles.BasicProfile1_1)]
// To allow this Web Service to be called from script, using ASP.NET AJAX, uncomment the following line. 
[System.Web.Script.Services.ScriptService]
public class MapWebService : System.Web.Services.WebService
{
    MapDataBLL _mapDataBLL = new MapDataBLL();
    public MapWebService()
    {

        //Uncomment the following line if using designed components 
        //InitializeComponent(); 
    }

    [WebMethod]
    public string HelloWorld()
    {
        return "Hello World";
    }

    [WebMethod]
    public List<MapSite> Map_GetSites_ByCompany(string company)
    {
        return _mapDataBLL.GetSite_ByCompany(company);
    }

    [WebMethod]
    public List<MapChannel>Map_GetChannels_ByLoggerId(string id)
    {
        return _mapDataBLL.GetChannels_ByLoggerId(id);
    }
}
