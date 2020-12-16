using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

public partial class _supervisor_report_rou_all : BasePage
{
    private string _msgEmptyEndDate = "Chưa nhập ngày kết thúc.";
    private string _msgEmptyStartDate = "Chưa nhập ngày bắt đầu.";
    ReportOutputsBLL _reportOutputsBLL = new ReportOutputsBLL();
    protected void Page_Load(object sender, EventArgs e)
    {
        win.VisibleOnPageLoad = false;
        ntf.VisibleOnPageLoad = false;
        if (!IsPostBack)
        {
            dtmStart.Focus();
        }
    }
    protected void btnOutput_Click(object sender, EventArgs e)
    {
        if (dtmStart.SelectedDate == null)
        {
            ntf.Text = _msgEmptyStartDate;
            ntf.VisibleOnPageLoad = true;
            dtmStart.Focus();
            return;
        }
        if (dtmEnd.SelectedDate == null)
        {
            ntf.Text = _msgEmptyEndDate;
            ntf.VisibleOnPageLoad = true;
            dtmEnd.Focus();
            return;
        }
        DateTime start = (DateTime)dtmStart.SelectedDate;
        DateTime end = (DateTime)dtmEnd.SelectedDate;
        List<ReportDailyData> list = _reportOutputsBLL.GetAllDailyOutput(start, end);
        Microsoft.Reporting.WebForms.ReportParameterCollection parms = new Microsoft.Reporting.WebForms.ReportParameterCollection();
        parms.Add(new Microsoft.Reporting.WebForms.ReportParameter("Start", start.ToString()));
        parms.Add(new Microsoft.Reporting.WebForms.ReportParameter("End", end.ToString()));
        rpt.LocalReport.SetParameters(parms);
        rpt.LocalReport.DataSources.Clear();
        rpt.LocalReport.DataSources.Add(new Microsoft.Reporting.WebForms.ReportDataSource("DataSet1", list));
        rpt.LocalReport.DisplayName = "Sản lượng tổng hợp kỳ " + end.Month.ToString();
        rpt.LocalReport.Refresh();
        win.VisibleOnPageLoad = true;
    }
}