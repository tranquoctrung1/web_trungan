using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
public partial class _customer_customer : System.Web.UI.MasterPage
{
    UsersBLL _usersBLL = new UsersBLL();

    protected void Page_Load(object sender, EventArgs e)
    {
        if (!string.IsNullOrEmpty(HttpContext.Current.User.Identity.Name))
        {
            _usersBLL.UpdateUserStatus(HttpContext.Current.User.Identity.Name);

            var user = _usersBLL.GetByUid(HttpContext.Current.User.Identity.Name);

            if (user.Role == "customer_boo")
            {
                SiteMapDataSource1.Provider = SiteMap.Providers["SiteMap8"];
            }
        }
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
