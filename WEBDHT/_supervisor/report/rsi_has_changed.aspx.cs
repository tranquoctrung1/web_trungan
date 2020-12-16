using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;


public partial class _supervisor_report_rsi_has_changed : BasePage
{
    private string _msgEmptyType = "Chưa nhập loại thay thiết bị.";
    private string _msgEmptyStartDate = "Chưa nhập mốc thời gian.";
    private string _nameReportMeterAccredited = "_diem_lap_dat_vua_kiem_dinh";
    private string _nameReportMeterChanged = "_diem_lap_dat_moi_thay_dong_ho";
    private string _nameReportTransmitterChanged = "_diem_lap_dat_moi_thay_bo_hien_thi";
    private string _nameReportLoggerChanged = "_diem_lap_dat_moi_thay_logger";
    private string _nameReportBatteryChanged = "_diem_lap_dat_moi_thay_acquy";
    private string _nameReportTransmitterBatteryChanged = "_diem_lap_dat_moi_thay_pin_bo_hien_thi";
    private string _nameReportLoggerBatteryChanged = "_diem_lap_dat_moi_thay_pin_logger";
    SitesBLL _sitesBLL = new SitesBLL();
    protected void Page_Load(object sender, EventArgs e)
    {
        ntf.VisibleOnPageLoad = false;
        win.VisibleOnPageLoad = false;
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
        if (dtmStart.SelectedDate == null)
        {
            ntf.VisibleOnPageLoad = true;
            ntf.Text = _msgEmptyStartDate;
            dtmStart.Focus();
            return;
        }
        DateTime startDate = (DateTime)dtmStart.SelectedDate;
        rpt.LocalReport.DataSources.Clear();
        List<SiteViewModel> list = new List<SiteViewModel>();
        switch (cboTypes.SelectedIndex)
        {
            case 0://Kiểm định đồng hồ
                list = _sitesBLL.GetAllByHasAccredited(startDate);
                rpt.LocalReport.DisplayName = _nameReportMeterAccredited;
                rpt.LocalReport.ReportPath = @"App_Data\reports\rsi_meter_has_accredited.rdlc";
                Microsoft.Reporting.WebForms.ReportParameterCollection parms0 = new Microsoft.Reporting.WebForms.ReportParameterCollection();
                parms0.Add(new Microsoft.Reporting.WebForms.ReportParameter("Date", startDate.ToString()));
                rpt.LocalReport.SetParameters(parms0);
                rpt.LocalReport.DataSources.Add(new Microsoft.Reporting.WebForms.ReportDataSource("DataSet1", list));
                rpt.LocalReport.Refresh();
                win.VisibleOnPageLoad = true;
                return;
                break;
            case 1://Thay đồng hồ
                list = _sitesBLL.GetAllByMeterHasChanged(startDate);
                rpt.LocalReport.DisplayName = _nameReportMeterChanged;
                break;
            case 2://Thay bộ hiển thị
                list = _sitesBLL.GetAllByTransmitterHasChanged(startDate);
                rpt.LocalReport.DisplayName = _nameReportTransmitterChanged;
                break;
            case 3://Thay pin bộ hiển thị
                list = _sitesBLL.GetAllByTransmitterBatteryHasChanged(startDate);
                rpt.LocalReport.DisplayName = _nameReportTransmitterBatteryChanged;
                break;
            case 4://Thay logger
                list = _sitesBLL.GetAllByLoggerHasChanged(startDate);
                rpt.LocalReport.DisplayName = _nameReportLoggerChanged;
                break;
            case 5://Thay pin logger
                list = _sitesBLL.GetAllByLoggerBatteryHasChanged(startDate);
                rpt.LocalReport.DisplayName = _nameReportLoggerBatteryChanged;
                break;
            case 6://Thay acquy
                list = _sitesBLL.GetAllByBatteryHasChanged(startDate);
                rpt.LocalReport.DisplayName = _nameReportBatteryChanged;
                break;
            default:
                break;
        }
        rpt.LocalReport.ReportPath = @"App_Data\reports\rsi_has_changed.rdlc";
        rpt.LocalReport.DisplayName = cboTypes.SelectedValue;
        Microsoft.Reporting.WebForms.ReportParameterCollection parms = new Microsoft.Reporting.WebForms.ReportParameterCollection();
        parms.Add(new Microsoft.Reporting.WebForms.ReportParameter("Type", cboTypes.Text));
        parms.Add(new Microsoft.Reporting.WebForms.ReportParameter("Date", startDate.ToString()));
        rpt.LocalReport.SetParameters(parms);
        rpt.LocalReport.DataSources.Add(new Microsoft.Reporting.WebForms.ReportDataSource("DataSet1", list));
        rpt.LocalReport.Refresh();
        win.VisibleOnPageLoad = true;
    }
}