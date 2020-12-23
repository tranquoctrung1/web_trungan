using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

public partial class _supervisor_report_rsi_marks_size_sgwdc : BasePage
{
    SitesBLL _sitesBLL = new SitesBLL();
    protected void Page_Load(object sender, EventArgs e)
    {
        //win.VisibleOnPageLoad = false;
        if (!IsPostBack)
        {
            Show();
        }
    }

    protected void btnView_Click(object sender, EventArgs e)
    {
        Show();
    }
    private void Show()
    {
        //win.VisibleOnPageLoad = true;
        List<SiteViewModel> list = _sitesBLL.GetAll4SGWDC();
        rpt.LocalReport.DataSources.Clear();
        rpt.LocalReport.DataSources.Add(new Microsoft.Reporting.WebForms.ReportDataSource("DataSet1", list));
        rpt.LocalReport.Refresh();
    }
}