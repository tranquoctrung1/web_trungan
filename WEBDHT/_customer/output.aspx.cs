using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

public partial class _customer_output : BasePage
{
    private string _urlReportHorizontal = @"App_Data\reports\rou_horizontal.rdlc";
    private string _urlReportVertical = @"App_Data\reports\rou_vertical.rdlc";
    private string _urlReport = @"App_Data\reports\rou_report.rdlc";
    private string _msgEmptyEndDate = "Chưa nhập ngày kết thúc.";
    private string _msgEmptyStartDate = "Chưa nhập ngày bắt đầu.";
    ReportOutputsBLL _reportOutputsBLL = new ReportOutputsBLL();

    UsersBLL _usersBLL = new UsersBLL();

    protected void Page_Load(object sender, EventArgs e)
    {
        win.VisibleOnPageLoad = false;
        ntf.VisibleOnPageLoad = false;

        var user = _usersBLL.GetByUid(HttpContext.Current.User.Identity.Name);

        if (user.Role == "customer_boo")
        {
            btnOutput.Visible = false;
        }

        if (!IsPostBack)
        {
            
        }
    }
    private string _company
    {
        get
        {
            System.Web.Security.FormsIdentity ident = HttpContext.Current.User.Identity as System.Web.Security.FormsIdentity;
            if (ident.IsAuthenticated)
                return ident.Ticket.UserData.Split('|')[1];
            else return null;
        }
    }
    protected void btnReport_Click(object sender, EventArgs e)
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
        List<ReportData> list = _reportOutputsBLL.GetDalilyReport(_company, start, end);
        rpt.LocalReport.ReportPath = _urlReport;
        Microsoft.Reporting.WebForms.ReportParameterCollection parms = new Microsoft.Reporting.WebForms.ReportParameterCollection();
        parms.Add(new Microsoft.Reporting.WebForms.ReportParameter("Start", start.ToString()));
        parms.Add(new Microsoft.Reporting.WebForms.ReportParameter("End", end.ToString()));
        parms.Add(new Microsoft.Reporting.WebForms.ReportParameter("Company", _company));
        rpt.LocalReport.SetParameters(parms);
        rpt.LocalReport.DataSources.Clear();
        rpt.LocalReport.DataSources.Add(new Microsoft.Reporting.WebForms.ReportDataSource("DataSet1", list));
        rpt.LocalReport.DisplayName = "Sản lượng " + _company + " kỳ " + end.Month.ToString();
        rpt.LocalReport.Refresh();
        win.VisibleOnPageLoad = true;
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
        List<ReportDailyData> list = _reportOutputsBLL.GetDailyOutput(_company, start, end);
        if (chkHorizontal.Checked || (!chkHorizontal.Checked && !chkVertical.Checked))
        {
            rpt.LocalReport.ReportPath = _urlReportHorizontal;
        }
        else if (chkVertical.Checked)
        {
            rpt.LocalReport.ReportPath = _urlReportVertical;
        }
        Microsoft.Reporting.WebForms.ReportParameterCollection parms = new Microsoft.Reporting.WebForms.ReportParameterCollection();
        parms.Add(new Microsoft.Reporting.WebForms.ReportParameter("Start", start.ToString()));
        parms.Add(new Microsoft.Reporting.WebForms.ReportParameter("End", end.ToString()));
        parms.Add(new Microsoft.Reporting.WebForms.ReportParameter("Company", _company));
        rpt.LocalReport.SetParameters(parms);
        rpt.LocalReport.DataSources.Clear();
        rpt.LocalReport.DataSources.Add(new Microsoft.Reporting.WebForms.ReportDataSource("DataSet1", list));
        rpt.LocalReport.DisplayName = "Sản lượng " + _company + " kỳ " + end.Month.ToString();
        rpt.LocalReport.Refresh();
        win.VisibleOnPageLoad = true;
    }
    protected void btnOutputLogger_Click(object sender, EventArgs e)
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
        List<ReportDailyData> list = _reportOutputsBLL.GetAllDailyLoggerOutput(_company, start, end);
        if (chkHorizontal.Checked || (!chkHorizontal.Checked && !chkVertical.Checked))
        {
            rpt.LocalReport.ReportPath = _urlReportHorizontal;
        }
        else if (chkVertical.Checked)
        {
            rpt.LocalReport.ReportPath = _urlReportVertical;
        }
        Microsoft.Reporting.WebForms.ReportParameterCollection parms = new Microsoft.Reporting.WebForms.ReportParameterCollection();
        parms.Add(new Microsoft.Reporting.WebForms.ReportParameter("Start", start.ToString()));
        parms.Add(new Microsoft.Reporting.WebForms.ReportParameter("End", end.ToString()));
        parms.Add(new Microsoft.Reporting.WebForms.ReportParameter("Company", _company));
        rpt.LocalReport.SetParameters(parms);
        rpt.LocalReport.DataSources.Clear();
        rpt.LocalReport.DataSources.Add(new Microsoft.Reporting.WebForms.ReportDataSource("DataSet1", list));
        rpt.LocalReport.DisplayName = "Sản lượng " + _company + " kỳ " + end.Month.ToString();
        rpt.LocalReport.Refresh();
        win.VisibleOnPageLoad = true;
    }
}