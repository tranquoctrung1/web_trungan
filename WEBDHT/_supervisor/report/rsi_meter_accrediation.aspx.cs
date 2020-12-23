using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

public partial class _supervisor_report_rsi_meter_accrediation : BasePage
{
    private string _msgEmptyEndDate = "Chưa nhập mốc thời gian cần xem";
    SitesBLL _sitesBLL = new SitesBLL();
    protected void Page_Load(object sender, EventArgs e)
    {
        ntf.VisibleOnPageLoad = false;
        //win.VisibleOnPageLoad = false;
    }
    protected void btnView_Click(object sender, EventArgs e)
    {
        if (dtmEnd.SelectedDate == null)
        {
            ntf.VisibleOnPageLoad = true;
            ntf.Text = _msgEmptyEndDate;
            return;
        }
        DateTime endDate=(DateTime)dtmEnd.SelectedDate;
        var list = _sitesBLL.GetAllByAccreditedDate(endDate);
        Microsoft.Reporting.WebForms.ReportParameterCollection prms = new Microsoft.Reporting.WebForms.ReportParameterCollection();
        prms.Add(new Microsoft.Reporting.WebForms.ReportParameter("Date", endDate.ToString()));
        rpt.LocalReport.SetParameters(prms);
        rpt.LocalReport.DataSources.Clear();
        rpt.LocalReport.DataSources.Add(new Microsoft.Reporting.WebForms.ReportDataSource("DataSet1", list));
        rpt.LocalReport.Refresh();
        //win.VisibleOnPageLoad = true;
    }
}