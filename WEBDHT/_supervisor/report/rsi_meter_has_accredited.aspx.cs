using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

public partial class _supervisor_report_rsi_meter_has_accredited : BasePage
{
    private string _msgEmptyStartDate = "Chưa nhập ngày bắt đầu";
    SitesBLL _sitesBLL = new SitesBLL();
    protected void Page_Load(object sender, EventArgs e)
    {
        ntf.VisibleOnPageLoad = false;
        win.VisibleOnPageLoad = false;
    }
    protected void btnView_Click(object sender, EventArgs e)
    {
        if (dtmStart.SelectedDate == null)
        {
            ntf.VisibleOnPageLoad = true;
            ntf.Text = _msgEmptyStartDate;
            dtmStart.Focus();
            return;
        }
        DateTime startDate = (DateTime)dtmStart.SelectedDate;
        rpt.LocalReport.DataSources.Clear();
        List<SiteViewModel> list = _sitesBLL.GetAllByHasAccredited(startDate);
        Microsoft.Reporting.WebForms.ReportParameterCollection parms = new Microsoft.Reporting.WebForms.ReportParameterCollection();
        parms.Add(new Microsoft.Reporting.WebForms.ReportParameter("Date", startDate.ToString()));
        rpt.LocalReport.SetParameters(parms);
        rpt.LocalReport.DataSources.Add(new Microsoft.Reporting.WebForms.ReportDataSource("DataSet1", list));
        rpt.LocalReport.Refresh();
        win.VisibleOnPageLoad = true;
    }
}