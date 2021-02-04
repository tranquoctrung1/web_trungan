using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

public partial class _supervisor_device_logger : BasePage
{
    private string _msgEmptySerial = "Chưa nhập serial.";
    private string _msgEmptyProvider = "Chưa nhập nhà sản xuất.";
    private string _msgEmptyModel = "Chưa nhập model.";
    private string _msgUpdated = "Đã cập nhật dữ liệu.";
    private string _msgInserted = "Đã thêm mới logger.";
    private string _msgDeleted = "Đã xóa logger.";
    private string _msgError = "Lỗi: ";
    LoggersBLL _loggersBLL = new LoggersBLL();
    protected void Page_Load(object sender, EventArgs e)
    {
        ntf.VisibleOnPageLoad = false;
        if (!IsPostBack)
        {
            cboSerials.Focus();
        }
    }
    protected void cboSerials_SelectedIndexChanged(object sender, Telerik.Web.UI.RadComboBoxSelectedIndexChangedEventArgs e)
    {
        string serial = cboSerials.Text;
        var logger = _loggersBLL.GetBySerial(serial);
        if (logger != null)
        {
            SetControlValues(logger);
            dtmReceipt.Focus();
        }
        else
        {
            SetControlValues(new Logger());
            dtmReceipt.Focus();
            cboSerials.Text = serial;
        }
    }
    protected void btnAdd_Click(object sender, EventArgs e)
    {
        ntf.VisibleOnPageLoad = true;
        if (string.IsNullOrEmpty(cboSerials.Text))
        {
            ntf.Text = _msgEmptySerial;
            cboSerials.Focus();
            return;
        }
        if (string.IsNullOrEmpty(cboProviders.Text))
        {
            ntf.Text = _msgEmptyProvider;
            cboProviders.Focus();
            return;
        }
        if (string.IsNullOrEmpty(cboModels.Text))
        {
            ntf.Text = _msgEmptyModel;
            cboModels.Focus();
            return;
        }
        Logger logger = GetControlValues();
        var dbLogger = _loggersBLL.GetBySerial(logger.Serial);
        CommandStatus status = new CommandStatus();
        if (dbLogger == null)
        {
            status = _loggersBLL.Insert(logger);
            SerialsDataSource.DataBind();
            cboSerials.DataBind();
        }
        else
        {
            status = _loggersBLL.Update(logger);
        }
        if (status.Inserted)
        {
            ntf.Text = _msgInserted;
        }
        else if (status.Updated)
        {
            ntf.Text = _msgUpdated;
        }
        else if (status.Error)
        {
            ntf.Text = _msgError + status.ErrorMessage;
        }
    }
    protected void btnConfim_Click(object sender, EventArgs e)
    {
        ntf.VisibleOnPageLoad = true;
        if (string.IsNullOrEmpty(cboSerials.Text))
        {
            ntf.Text = _msgEmptySerial;
            return;
        }
        Logger logger = GetControlValues();
        var dbLogger = _loggersBLL.GetBySerial(logger.Serial);
        CommandStatus status = new CommandStatus();
        status = _loggersBLL.Delete(logger.Serial);
        if (status.Deleted)
        {
            ntf.Text = _msgDeleted;
            SerialsDataSource.DataBind();
            cboSerials.DataBind();
            SetControlValues(new Logger());
        }
        else if (status.Error)
        {
            ntf.Text = _msgError + status.ErrorMessage;
        }
    }
    private Logger GetControlValues()
    {
        Logger logger = new Logger();
        logger.Description = txtDescription.Text;
        logger.Installed = chkInstalled.Checked;
        logger.Marks = cboMarks.Text;
        logger.Model = cboModels.Text;
        logger.Provider = cboProviders.Text;
        logger.ReceiptDate = dtmReceipt.SelectedDate;
        logger.Serial = cboSerials.Text;
        logger.Status = cboStatus.Text;
        logger.DateAccreditation = dtmAccreditation.SelectedDate;
        logger.DateInstallBattery = dtmInstallBattery.SelectedDate;
        logger.YearBattery = int.Parse(yearBattery.Text);
        return logger;
    }
    private void SetControlValues(Logger logger)
    {
        txtDescription.Text = logger.Description;
        chkInstalled.Checked = logger.Installed ?? false;
        cboMarks.Text = logger.Marks;
        cboMarks.SelectedIndex = -1;
        cboModels.Text = logger.Model;
        cboModels.SelectedIndex = -1;
        cboProviders.Text = logger.Provider;
        cboProviders.SelectedIndex = -1;
        dtmReceipt.SelectedDate = logger.ReceiptDate;
        cboSerials.SelectedIndex = -1;
        cboSerials.Text = logger.Serial;
        cboStatus.SelectedIndex = -1;
        cboStatus.Text = logger.Status;
        dtmAccreditation.SelectedDate = logger.DateAccreditation;
        dtmInstallBattery.SelectedDate = logger.DateInstallBattery;
        yearBattery.Text = logger.YearBattery.ToString();
    }
}