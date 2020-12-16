using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Script.Services;
using System.Web.Security;
using System.Web.Services;

/// <summary>
/// Summary description for Pi1
/// </summary>
[WebService(Namespace = "http://tempuri.org/")]
[WebServiceBinding(ConformsTo = WsiProfiles.BasicProfile1_1)]
[ScriptService]
// To allow this Web Service to be called from script, using ASP.NET AJAX, uncomment the following line. 
// [System.Web.Script.Services.ScriptService]
public class Pi1 : System.Web.Services.WebService
{

    public Pi1()
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
    public string Logout_pi()
    {
            Context.Response.Cookies.Remove(FormsAuthentication.FormsCookieName);
            Context.Response.Cache.SetExpires(DateTime.Now.AddSeconds(-1));
            HttpCookie cookie = Context.Request.Cookies[FormsAuthentication.FormsCookieName];
            if (cookie != null)
                cookie.Expires = DateTime.Now.AddDays(-1);
            Context.Response.Cookies.Add(cookie);

            return "/Login.aspx";
    }



}
