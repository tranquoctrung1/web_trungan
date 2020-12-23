using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

public partial class _supervisor_report_rsi_expiry : BasePage
{
    private string _msgEmptyType = "Chưa nhập loại kiểm định.";
    private string _msgEmptyEndDate = "Chưa nhập mốc thời gian cần xem.";
    private string _msgEmptyUsingTime = "Chưa nhập thời gian sử dụng.";
    SitesBLL _sitesBLL = new SitesBLL();
    protected void Page_Load(object sender, EventArgs e)
    {
        ntf.VisibleOnPageLoad = false;
        //win.VisibleOnPageLoad = false;
    }
    protected void btnView_Click(object sender, EventArgs e)
    {
        if (string.IsNullOrEmpty(cboTypes.Text))
        {
            ntf.VisibleOnPageLoad = true;
            ntf.Text = _msgEmptyType;
            cboTypes.Focus();
            return;
        }
        if (dtmEnd.SelectedDate == null)
        {
            ntf.VisibleOnPageLoad = true;
            ntf.Text = _msgEmptyEndDate;
            dtmEnd.Focus();
            return;
        }
        if (nmrUsingTime.Value == null)
        {
            ntf.VisibleOnPageLoad = true;
            ntf.Text = _msgEmptyUsingTime;
            nmrUsingTime.Focus();
            return;
        }
        List<string> listStatus = GetStatus();
        if (listStatus.Count == 0)
        {
            listStatus = GetAllStatus();
        }
        List<string> listCompanies = GetCompanies();
        if (listCompanies.Count == 0)
        {
            listCompanies = GetAllCompanies();
        }
        rpt.LocalReport.DataSources.Clear();
        DateTime endDate = (DateTime)dtmEnd.SelectedDate;
        double usingTime = (double)nmrUsingTime.Value;
        List<SiteViewModel> list = new List<SiteViewModel>();
        switch (cboTypes.SelectedIndex)
        {
            case 0://Thay đồng hồ
                list = _sitesBLL.GetAllByMeterChanged(endDate, usingTime, listCompanies, listStatus);
                break;
            case 1://Thay bộ hiển thị
                list = _sitesBLL.GetAllByTransmitterChanged(endDate, usingTime, listCompanies, listStatus);
                break;
            case 2://Thay pin bộ hiển thị
                list = _sitesBLL.GetAllByTransmitterBatteryChanged(endDate, usingTime, listCompanies, listStatus);
                break;
            case 3://Thay logger
                list = _sitesBLL.GetAllByLoggerChanged(endDate, usingTime, listCompanies, listStatus);
                break;
            case 4://Thay pin logger
                list = _sitesBLL.GetAllByLoggerBatteryChanged(endDate, usingTime, listCompanies, listStatus);
                break;
            case 5://Thay acquy
                list = _sitesBLL.GetAllByBatteryChanged(endDate, usingTime, listCompanies, listStatus);
                break;
            default:
                break;
        }
        Microsoft.Reporting.WebForms.ReportParameterCollection parms = new Microsoft.Reporting.WebForms.ReportParameterCollection();
        parms.Add(new Microsoft.Reporting.WebForms.ReportParameter("Type", cboTypes.Text));
        parms.Add(new Microsoft.Reporting.WebForms.ReportParameter("Date", endDate.ToString()));
        parms.Add(new Microsoft.Reporting.WebForms.ReportParameter("TimeOfUse", usingTime.ToString()));
        rpt.LocalReport.SetParameters(parms);
        rpt.LocalReport.DisplayName = cboTypes.Text;
        rpt.LocalReport.DataSources.Add(new Microsoft.Reporting.WebForms.ReportDataSource("DataSet1", list));
        rpt.LocalReport.Refresh();
        //win.VisibleOnPageLoad = true;
    }
    private List<string> GetAllStatus()
    {
        List<string> list = new List<string>();
        foreach (Telerik.Web.UI.RadListBoxItem item in lstStatus.Items)
        {
            list.Add(item.Text);
        }
        return list;
    }
    private List<string> GetStatus()
    {
        List<string> list = new List<string>();
        foreach (Telerik.Web.UI.RadListBoxItem item in lstStatus.Items)
        {
            if (item.Selected)
            {
                list.Add(item.Text);
            }
        }
        return list;
    }
    private List<string> GetAllCompanies()
    {
        List<string> list = new List<string>();
        foreach (Telerik.Web.UI.RadListBoxItem item in lstCompanies.Items)
        {
            list.Add(item.Text);
        }
        return list;
    }
    private List<string> GetCompanies()
    {
        List<string> list = new List<string>();
        foreach (Telerik.Web.UI.RadListBoxItem item in lstCompanies.Items)
        {
            if (item.Selected)
            {
                list.Add(item.Text);
            }
        }
        return list;
    }
}