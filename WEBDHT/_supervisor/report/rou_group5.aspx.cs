using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

public partial class _supervisor_report_rou_group5 : BasePage
{
    private string _urlReportHorizontal = @"App_Data\reports\rou_horizontal.rdlc";
    private string _urlReportVertical = @"App_Data\reports\rou_vertical.rdlc";
    private string _msgEmptyEndDate = "Chưa nhập ngày kết thúc.";
    private string _msgEmptyStartDate = "Chưa nhập ngày bắt đầu.";
    private string _msgEmptyCompany = "Chưa nhập nhóm đồng hồ.";
    ReportOutputsBLL _reportOutputsBLL = new ReportOutputsBLL();
    protected void Page_Load(object sender, EventArgs e)
    {
        win.VisibleOnPageLoad = false;
        ntf.VisibleOnPageLoad = false;
        if (!IsPostBack)
        {
            cboGroups.Focus();
        }
    }
    protected void btnOutput_Click(object sender, EventArgs e)
    {
        if (string.IsNullOrEmpty(cboGroups.Text))
        {
            ntf.VisibleOnPageLoad = true;
            ntf.Text = _msgEmptyCompany;
            cboGroups.Focus();
            return;
        }
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
        string company = cboGroups.SelectedValue;
        List<ReportDailyData> list = _reportOutputsBLL.GetDailyOutputByGroup5(cboGroups.Text, start, end);
        if (rdoHorizontal.Checked || (!rdoHorizontal.Checked && !rdoVertical.Checked))
        {
            rpt.LocalReport.ReportPath = _urlReportHorizontal;
        }
        else if (rdoVertical.Checked)
        {
            rpt.LocalReport.ReportPath = _urlReportVertical;
        }
        Microsoft.Reporting.WebForms.ReportParameterCollection parms = new Microsoft.Reporting.WebForms.ReportParameterCollection();
        parms.Add(new Microsoft.Reporting.WebForms.ReportParameter("Start", start.ToString()));
        parms.Add(new Microsoft.Reporting.WebForms.ReportParameter("End", end.ToString()));
        parms.Add(new Microsoft.Reporting.WebForms.ReportParameter("Company", company));
        rpt.LocalReport.SetParameters(parms);
        rpt.LocalReport.DataSources.Clear();
        rpt.LocalReport.DataSources.Add(new Microsoft.Reporting.WebForms.ReportDataSource("DataSet1", list));
        rpt.LocalReport.DisplayName = "_san_luong_nhom_" + company + "_ky_" + end.Month.ToString() + "_" + end.Year.ToString();
        rpt.LocalReport.Refresh();
        win.VisibleOnPageLoad = true;
    }
}