using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

public partial class _supervisor_site_change_transmitter : BasePage
{
    private string _msgEmptySiteId = "Chưa nhập mã vị trí.";
    private string _msgEmptyDateChanged = "Chưa nhập ngày thay đổi.";
    private string _msgError = "Lỗi ";
    private string _msgSuccess = "Đã cập nhật lịch sử thay thiết bị.";
    private string _msgDeleted = "Đã xóa lịch sử.";
    SiteTransmitterHistoriesBLL _siteTransmitterHistoriesBLL = new SiteTransmitterHistoriesBLL();
    SitesBLL _sitesBLL = new SitesBLL();
    TransmittersBLL _transmittersBLL = new TransmittersBLL();
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
        SiteTransmitterHistory history = GetControlValues();
        SiteTransmitterHistory dbHistory = _siteTransmitterHistoriesBLL.GetBySiteIdAndDateChanged(siteId, dateChanged);
        CommandStatus status = new CommandStatus();
        if (dbHistory == null)
        {
            status = _siteTransmitterHistoriesBLL.Insert(history);
        }
        else
        {
            status = _siteTransmitterHistoriesBLL.Update(history);
        }
        if (status.Error)
        {
            ntf.Text = _msgError + status.ErrorMessage;
        }
        else
        {
            ntf.Text = _msgSuccess;
            SiteIdDataSource.DataBind();
            cboSiteIds.DataBind();
        }
        try
        {
            Transmitter oldTransmitter = _transmittersBLL.GetBySerial(cboOldSerials.Text);
            oldTransmitter.Installed = false;
            Transmitter newTransmitter = _transmittersBLL.GetBySerial(cboNewSerials.Text);
            newTransmitter.Installed = true;
            Site site = _sitesBLL.GetById(cboSiteIds.Text);
            SiteTransmitterHistory _lastChanged = _siteTransmitterHistoriesBLL.GetLastChanged(cboSiteIds.Text);
            if (_lastChanged == null || _lastChanged.DateChanged <= dtmDateChanged.SelectedDate)
            {
                site.DateOfTransmitterChange = dtmDateChanged.SelectedDate;
                site.Transmitter = newTransmitter.Serial;
                _sitesBLL.Update(site);
            }
            _transmittersBLL.Update(oldTransmitter);
            _transmittersBLL.Update(newTransmitter);
        }
        catch (Exception ex)
        {
            ntf.Text = _msgError + ex.Message;
        }
    }
    private void SetControlValues(SiteTransmitterHistory history)
    {
        cboSiteIds.SelectedIndex = -1;
        cboSiteIds.Text = history.SiteId;
        dtmDateChanged.SelectedDate = history.DateChanged;
        cboOldSerials.Text = history.OldMeterSerial;
        cboNewSerials.Text = history.NewMeterSerial;
        nmrOldIndex.Value = history.OldMeterIndex ?? 0;
        nmrNewIndex.Value = history.NewMeterIndex ?? 0;
        txtDescription.Text = history.Description;
    }
    private SiteTransmitterHistory GetControlValues()
    {
        SiteTransmitterHistory history = new SiteTransmitterHistory();
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
        CommandStatus status = _siteTransmitterHistoriesBLL.Delete(siteId, dateChanged);
        if (status.Deleted)
        {
            ntf.Text = _msgDeleted;
            SiteIdDataSource.DataBind();
            cboSiteIds.DataBind();
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