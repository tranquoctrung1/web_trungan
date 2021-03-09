using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

public partial class _supervisores_map_Map2 : System.Web.UI.Page
{
    public const string _STRING_URL_CLIENT = "~/Content/Clients/Output.aspx";
    public const string _STRING_URL_KD_READ_ALL_COMPANY = "~/_supervisor/report/KD_READ_ALL_COMPANY/rou_dcompany.aspx";
    public const string _STRING_URL_KT_READ_ALL_COMPANY = "~/_supervisor/report/rsi_sgwdc.aspx";
    UsersBLL _usersBLL = new UsersBLL();

    public string GetVisitorIpAddress()
    {
        string stringIpAddress;
        stringIpAddress = Request.ServerVariables["HTTP_X_FORWARDED_FOR"];
        if (stringIpAddress == null) //may be the HTTP_X_FORWARDED_FOR is null
        {
            stringIpAddress = Request.ServerVariables["REMOTE_ADDR"];//we can use REMOTE_ADDR
        }
        return stringIpAddress;
    }

    //Get Lan Connected IP address method
    public string GetLanIPAddress()
    {
        //Get the Host Name
        string stringHostName = Dns.GetHostName();
        //Get The Ip Host Entry
        IPHostEntry ipHostEntries = Dns.GetHostEntry(stringHostName);
        //Get The Ip Address From The Ip Host Entry Address List
        IPAddress[] arrIpAddress = ipHostEntries.AddressList;
        return arrIpAddress[arrIpAddress.Length - 1].ToString();
    }
    protected void Page_Load(object sender, EventArgs e)
    {
        if (!string.IsNullOrEmpty(HttpContext.Current.User.Identity.Name))
        {
            //string url = Request.Url.AbsoluteUri;
            //_usersBLL.UpdateUserStatus(HttpContext.Current.User.Identity.Name);
            //if (!IsPostBack)
            //{
            //    string role = "";
            //    System.Web.Security.FormsIdentity ident = HttpContext.Current.User.Identity as System.Web.Security.FormsIdentity;
            //    if (HttpContext.Current.User.Identity.IsAuthenticated)
            //    {
            //        System.Web.Security.FormsAuthenticationTicket ticket = ident.Ticket;
            //        role = ticket.UserData.Split('|')[0];
            //    }
            //    if (string.Equals(role, "adminviewer") && (url.Contains("device") || url.Contains("site") || url.Contains("data") || url.Contains("download")))
            //    {
            //        DisableControls(Page);
            //    }
            //    if (string.Equals(role,"KT_READ_ALL_COMPANY"))
            //    {
            //        SiteMapDataSource1.SiteMapProvider = "SiteMap3";
            //        mnuLeft.DataBind();
            //    }
            //    if (string.Equals(role,"KD_READ_ALL_COMPANY"))
            //    {
            //        SiteMapDataSource1.SiteMapProvider = "SiteMap4";
            //        mnuLeft.DataBind();
            //    }
            //    if (string.Equals(role, "Statis_read_all"))
            //    {
            //        SiteMapDataSource1.SiteMapProvider = "SiteMap5";
            //        mnuLeft.DataBind();
            //    }
            //    if (string.Equals(role, "Utility_read_all"))
            //    {
            //        SiteMapDataSource1.SiteMapProvider = "SiteMap6";
            //        mnuLeft.DataBind();
            //    }
            //    if (string.Equals(role, "Volume_read_all"))
            //    {
            //        SiteMapDataSource1.SiteMapProvider = "SiteMap7";
            //        mnuLeft.DataBind();
            //    }
            //    if (string.Equals(role, "meter_logger_tran"))
            //    {
            //        SiteMapDataSource1.SiteMapProvider = "SiteMap9";
            //        mnuLeft.DataBind();
            //    }
            //}

            string IP = GetLanIPAddress();
            if (string.IsNullOrEmpty(IP) || IP.Contains('%'))
            {
                IP = GetVisitorIpAddress();
            }
            if (HttpContext.Current.User.Identity.IsAuthenticated)
            {
                //t_Users user = new t_Users();
                string username = HttpContext.Current.User.Identity.Name;
                // hdpValueUID.Value = username;
                // Update name - Pi-solution developer
                lbUserName.Text = username;
                //t_Users dbUser = _userBL.GetUser(username);
                //user = dbUser;
                //user.Active = true;
                //string hostName = Dns.GetHostName();
                //user.Ip = Dns.GetHostAddresses(hostName).GetValue(0).ToString();
                //user.Ip = IP;
                //user.TimeStamp = DateTime.Now;
                //_userBL.UpdateUser(user, dbUser);
                //string role = user.Role;
                ////RoleFunciton
                //t_RoleFunction _functions = new t_RoleFunction();
                //List<int> dbfunction = (from a in _roleFunctionBL.FindAll(s => s.Role == role && s.Active == true).ToList() select a.FunctionId).ToList();
                ////URL by Role
                //List<string> fun = (from q in languageobj.FindAll(s => dbfunction.Contains(s.FunctionId) && s.Language == "vi").ToList() select q.URL).ToList();
                //hidListMenu.Value = "@";
                //foreach (var _f in fun)
                //{
                //    hidListMenu.Value = hidListMenu.Value + _f + "@";
                //}


            }
            else
            {
                Response.Redirect("~/Login.aspx");
            }
        }
    }
    protected void DisableControls(Control parent)
    {
        foreach (Control c in parent.Controls)
        {
            if (c is Telerik.Web.UI.RadButton)
                if (((Telerik.Web.UI.RadButton)c).Text != "Download")
                    ((Telerik.Web.UI.RadButton)c).Enabled = false;
            DisableControls(c);
        }
    }
    protected void mnuLeft_ItemDataBound(object sender, Telerik.Web.UI.RadMenuEventArgs e)
    {
        e.Item.TabIndex = -1;
    }

    protected void mnuUser_ItemClick(object sender, Telerik.Web.UI.RadMenuEventArgs e)
    {
        var lang = e.Item.Text;
        string lit = "";
        if (lang == "Tiếng Anh" || lang == "English")
        {
            lit = "en-GB";
        }
        else if (lang == "Tiếng Việt" || lang == "Vietnamese")
        {
            lit = "vi-VN";
        }
        else
        {
            lit = "vi-VN";
        }
        var user = _usersBLL.GetByUid(HttpContext.Current.User.Identity.Name);
        user.Language = lit;
        _usersBLL.Update(user);
        Response.Redirect(Request.RawUrl);
    }
}