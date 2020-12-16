using System;
using System.Data;
using System.Configuration;
using System.Web;
using System.Web.Security;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Web.UI.WebControls.WebParts;
using System.Web.UI.HtmlControls;
using System.Globalization;
using System.Threading;

/// <summary>
/// Summary description for BasePage
/// </summary>
public class BasePage : System.Web.UI.Page
{
    protected override void InitializeCulture()
    {
        UsersBLL _usersBLL = new UsersBLL();
        var user = _usersBLL.GetByUid(HttpContext.Current.User.Identity.Name);
        if (user == null)
        {
            return;
        }
        if (!string.IsNullOrEmpty(user.Language))
        {
            CultureInfo culture = new CultureInfo(user.Language);
            System.Threading.Thread.CurrentThread.CurrentCulture = culture;
            System.Threading.Thread.CurrentThread.CurrentUICulture = culture;
            base.InitializeCulture();
        }
    }
}
