using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

public partial class index : System.Web.UI.Page
{
    protected void Page_Load(object sender, EventArgs e)
    {
        FMM_SGWDCDataContext db = new FMM_SGWDCDataContext();
        var dt = (DateTime)db.Test().ReturnValue;
        Response.Write(dt);
    }
}