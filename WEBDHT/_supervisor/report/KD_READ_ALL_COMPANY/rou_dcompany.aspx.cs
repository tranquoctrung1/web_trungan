using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

public partial class _supervisor_report_KD_READ_ALL_COMPANY_rou_dcompany : BasePage
{
    private string _urlReportHorizontal = @"App_Data\reports\rou_horizontal.rdlc";
    private string _urlReportVertical = @"App_Data\reports\rou_vertical.rdlc";
    private string _urlReport = @"App_Data\reports\rou_report.rdlc";
    private string _msgEmptyEndDate = "Chưa nhập ngày kết thúc.";
    private string _msgEmptyStartDate = "Chưa nhập ngày bắt đầu.";
    private string _msgEmptyCompany = "Chưa nhập công ty.";
    ReportOutputsBLL _reportOutputsBLL = new ReportOutputsBLL();
    SiteCompaniesBLL _siteCompaniesBLL = new SiteCompaniesBLL();
    protected void Page_Load(object sender, EventArgs e)
    {
        win.VisibleOnPageLoad = false;
        ntf.VisibleOnPageLoad = false;
        if (!IsPostBack)
        {
            string[] listCompanies=new string[]{"cl","gd","nb","pt","sg","td","ta","th"};
            cboCompanies.Focus();
            var list = _siteCompaniesBLL.GetAll().ToList();
            List<SiteCompany> newList = new List<SiteCompany>();
            foreach (var item in list)
            {
                if (listCompanies.Contains(item.Company.ToLower()))
                {
                    newList.Add(item);
                }
            }
            cboCompanies.DataSource = newList;
            cboCompanies.DataBind();
        }
    }
    protected void btnReport_Click(object sender, EventArgs e)
    {
        if (string.IsNullOrEmpty(cboCompanies.Text))
        {
            ntf.VisibleOnPageLoad = true;
            ntf.Text = _msgEmptyCompany;
            cboCompanies.Focus();
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
        string company = cboCompanies.SelectedValue;
        List<ReportData> list = _reportOutputsBLL.GetDalilyReport(cboCompanies.Text, start, end);
        rpt.LocalReport.ReportPath = _urlReport;
        Microsoft.Reporting.WebForms.ReportParameterCollection parms = new Microsoft.Reporting.WebForms.ReportParameterCollection();
        parms.Add(new Microsoft.Reporting.WebForms.ReportParameter("Start", start.ToString()));
        parms.Add(new Microsoft.Reporting.WebForms.ReportParameter("End", end.ToString()));
        parms.Add(new Microsoft.Reporting.WebForms.ReportParameter("Company", company));
        rpt.LocalReport.SetParameters(parms);
        rpt.LocalReport.DataSources.Clear();
        rpt.LocalReport.DataSources.Add(new Microsoft.Reporting.WebForms.ReportDataSource("DataSet1", list));
        rpt.LocalReport.DisplayName = "_bao_cao_san_luong_" + company + "_ky_" + end.Month.ToString() + "_" + end.Year.ToString();
        rpt.LocalReport.Refresh();
        win.VisibleOnPageLoad = true;
    }
    protected void btnOutput_Click(object sender, EventArgs e)
    {
        if (string.IsNullOrEmpty(cboCompanies.Text))
        {
            ntf.VisibleOnPageLoad = true;
            ntf.Text = _msgEmptyCompany;
            cboCompanies.Focus();
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
        string company = cboCompanies.SelectedValue;
        List<ReportDailyData> list = _reportOutputsBLL.GetDailyOutput(cboCompanies.Text, start, end);
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
        rpt.LocalReport.DisplayName = "_san_luong_" + company + "_ky_" + end.Month.ToString() + "_" + end.Year.ToString();
        rpt.LocalReport.Refresh();
        win.VisibleOnPageLoad = true;
    }
    protected void btnOutputLogger_Click(object sender, EventArgs e)
    {
        if (string.IsNullOrEmpty(cboCompanies.Text))
        {
            ntf.VisibleOnPageLoad = true;
            ntf.Text = _msgEmptyCompany;
            cboCompanies.Focus();
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
        string company = cboCompanies.SelectedValue;
        List<ReportDailyData> list = _reportOutputsBLL.GetAllDailyLoggerOutput(cboCompanies.Text, start, end);
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
        rpt.LocalReport.DisplayName = "_san_luong_" + company + "_ky_" + end.Month.ToString() + "_" + end.Year.ToString();
        rpt.LocalReport.Refresh();
        win.VisibleOnPageLoad = true;
    }
}