using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

public partial class _supervisor_site_change_logger : BasePage
{
    private string _msgEmptySiteId = "Chưa nhập mã vị trí.";
    private string _msgEmptyDateChanged = "Chưa nhập ngày thay đổi.";
    private string _msgError = "Lỗi ";
    private string _msgSuccess = "Đã cập nhật lịch sử thay thiết bị.";
    private string _msgDeleted = "Đã xóa lịch sử.";
    SiteLoggerHistoriesBLL _siteLoggerHistoriesBLL = new SiteLoggerHistoriesBLL();
    SitesBLL _sitesBLL = new SitesBLL();
    LoggersBLL _loggersBLL = new LoggersBLL();
    protected void Page_Load(object sender, EventArgs e)
    {
        ntf.VisibleOnPageLoad = false;
        if (!IsPostBack)
        {
            cboSiteIds.Focus();
        }
    }
    protected void btnSubmit_Click(object sender, EventArgs e)
    {
        ntf.VisibleOnPageLoad = true;
        if (string.IsNullOrEmpty(cboSiteIds.Text))
        {
            ntf.Text = _msgEmptySiteId;
            cboSiteIds.Focus();
            return;
        }
        if (dtmDateChanged.SelectedDate == null)
        {
            ntf.Text = _msgEmptyDateChanged;
            dtmDateChanged.Focus();
            return;
        }
        string siteId = cboSiteIds.Text;
        DateTime dateChanged = (DateTime)dtmDateChanged.SelectedDate;
        SiteLoggerHistory history = GetControlValues();
        SiteLoggerHistory dbHistory = _siteLoggerHistoriesBLL.GetBySiteIdAndDateChanged(siteId, dateChanged);
        CommandStatus status = new CommandStatus();
        if (dbHistory == null)
        {
            status = _siteLoggerHistoriesBLL.Insert(history);
        }
        else
        {
            status = _siteLoggerHistoriesBLL.Update(history);
        }
        if (status.Error)
        {
            ntf.Text = _msgError + status.ErrorMessage;
        }
        else
        {
            ntf.Text = _msgSuccess;
        }
        try
        {
            Logger oldLogger = _loggersBLL.GetBySerial(cboOldSerials.Text);
            oldLogger.Installed = false;
            Logger newLogger = _loggersBLL.GetBySerial(cboNewSerials.Text);
            newLogger.Installed = true;
            Site site = _sitesBLL.GetById(cboSiteIds.Text);
            SiteLoggerHistory _lastChanged = _siteLoggerHistoriesBLL.GetLastChanged(cboSiteIds.Text);
            if (_lastChanged == null || _lastChanged.DateChanged <= dtmDateChanged.SelectedDate)
            {
                site.DateOfLoggerChange = dtmDateChanged.SelectedDate;
                site.Logger = newLogger.Serial;
                _sitesBLL.Update(site);
            }
            _loggersBLL.Update(oldLogger);
            _loggersBLL.Update(newLogger);
        }
        catch (Exception ex)
        {
            ntf.Text = _msgError + ex.Message;
        }
    }
    private void SetControlValues(SiteLoggerHistory history)
    {
        cboSiteIds.SelectedIndex = -1;
        cboSiteIds.Text = history.SiteId;
        dtmDateChanged.SelectedDate = history.DateChanged;
        cboOldSerials.Text = history.OldMeterSerial;
        cboNewSerials.Text = history.NewMeterSerial;
        nmrOldIndex.Value = history.OldMeterIndex;
        nmrNewIndex.Value = history.NewMeterIndex;
        txtDescription.Text = history.Description;
    }
    private SiteLoggerHistory GetControlValues()
    {
        SiteLoggerHistory history = new SiteLoggerHistory();
        history.DateChanged = (DateTime)dtmDateChanged.SelectedDate;
        history.Description = txtDescription.Text;
        history.NewMeterIndex = nmrNewIndex.Value ?? 0;
        history.NewMeterSerial = cboNewSerials.Text;
        history.OldMeterIndex = nmrOldIndex.Value ?? 0;
        history.OldMeterSerial = cboOldSerials.Text;
        history.SiteId = cboSiteIds.Text;
        return history;
    }
    protected void btnConfim_Click(object sender, EventArgs e)
    {
        ntf.VisibleOnPageLoad = true;
        string siteId = cboSiteIds.Text;
        if (string.IsNullOrEmpty(siteId))
        {
            ntf.Text = _msgEmptySiteId;
            cboSiteIds.Focus();
            return;
        }
        if (dtmDateChanged.SelectedDate == null)
        {
            ntf.Text = _msgEmptyDateChanged;
            dtmDateChanged.Focus();
            return;
        }
        DateTime dateChanged = (DateTime)dtmDateChanged.SelectedDate;
        CommandStatus status = _siteLoggerHistoriesBLL.Delete(siteId, dateChanged);
        if (status.Deleted)
        {
            ntf.Text = _msgDeleted;
            SetDefaultControls();
        }
        else if (status.Error)
        {
            ntf.Text = _msgError + status.Error;
        }
    }
    private void SetDefaultControls()
    {
        cboOldSerials.SelectedIndex = -1;
        cboNewSerials.SelectedIndex = -1;
        cboOldSerials.Text = string.Empty;
        cboNewSerials.Text = string.Empty;
        nmrOldIndex.Value = null;
        nmrNewIndex.Value = null;
        txtDescription.Text = string.Empty;
    }
}