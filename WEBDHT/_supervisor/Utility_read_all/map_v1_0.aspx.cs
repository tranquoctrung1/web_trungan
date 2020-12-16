using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

public partial class _supervisor_Utility_read_all_map_v1_0 : System.Web.UI.Page
{
    private string qs;

    protected void Page_Load(object sender, EventArgs e)
    {
        qs = Request.QueryString["co"];
        RadSlidingPane1.Title = "Sites: " + qs;
        if (string.IsNullOrEmpty(qs))
        {
            Response.Redirect(HttpContext.Current.Request.Url.AbsoluteUri +  "?co=XN");
            cboCompanies.SelectedValue = "XN";
           
        }
    }

    protected void cboCompanies_SelectedIndexChanged(object sender, Telerik.Web.UI.RadComboBoxSelectedIndexChangedEventArgs e)
    {
        Response.Redirect(HttpContext.Current.Request.Url.AbsoluteUri.Replace(Request.QueryString["co"],"") + cboCompanies.SelectedValue);
    }
}