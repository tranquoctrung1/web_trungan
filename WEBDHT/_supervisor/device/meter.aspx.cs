using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

public partial class _supervisor_device_meter : BasePage
{
    private string _urlDownload = "~/_supervisor/file/meter.aspx?sr=";
    private string _msgUploaded = "Đã upload file.";
    private string _msgEmptySerial = "Chưa nhập serial.";
    private string _msgEmptyProvider = "Chưa nhập nhà sản xuất.";
    private string _msgEmptyMarks = "Chưa nhập hiệu.";
    private string _msgEmptySize = "Chưa nhập cỡ.";
    private string _msgEmptyModel = "Chưa nhập model.";
    private string _msgUpdated = "Đã cập nhật dữ liệu.";
    private string _msgInserted = "Đã thêm mới đồng hồ.";
    private string _msgDeleted = "Đã xóa đồng hồ.";
    private string _msgError = "Lỗi: ";
    MetersBLL _metersBLL = new MetersBLL();
    StringUTL _stringUTL = new StringUTL();
    MeterFilesBLL _meterFilesBLL = new MeterFilesBLL();
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
        var meter = _metersBLL.GetBySerial(serial);
        if (meter != null)
        {
            SetControlValues(meter);
            dtmReceipt.Focus();
        }
        else
        {
            SetControlValues(new Meter());
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
        if (string.IsNullOrEmpty(cboSizes.Text))
        {
            ntf.Text = _msgEmptySize;
            cboSizes.Focus();
            return;
        }
        if (string.IsNullOrEmpty(cboModels.Text))
        {
            ntf.Text = _msgEmptyModel;
            cboModels.Focus();
            return;
        }
        Meter meter = GetControlValues();
        var dbMeter = _metersBLL.GetBySerial(meter.Serial);
        CommandStatus status = new CommandStatus();
        if (dbMeter == null)
        {
            status = _metersBLL.Insert(meter);
            SerialsDataSource.DataBind();
            cboSerials.DataBind();
        }
        else
        {
            status = _metersBLL.Update(meter);
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
        Meter meter = GetControlValues();
        var dbMeter = _metersBLL.GetBySerial(meter.Serial);
        CommandStatus status = new CommandStatus();
        status = _metersBLL.Delete(meter.Serial);
        if (status.Deleted)
        {
            ntf.Text = _msgDeleted;
            SerialsDataSource.DataBind();
            cboSerials.DataBind();
            SetControlValues(new Meter());
        }
        else if (status.Error)
        {
            ntf.Text = _msgError + status.ErrorMessage;
        }


    }
    private Meter GetControlValues()
    {
        Meter meter = new Meter();
        meter.AccreditationDocument = txtAccreditationDocument.Text;
        meter.AccreditationType = cboAccreditationTypes.Text;
        meter.AccreditedDate = dtmAccredited.SelectedDate;
        meter.ApprovalDate = dtmApproved.SelectedDate;
        meter.ApprovalDecision = txtApprovalDecision.Text;
        meter.Approved = chkApproved.Checked;
        meter.Description = txtDescription.Text;
        meter.ExpiryDate = dtmExpiry.SelectedDate;
        meter.InitialIndex = nmrIndex.Value;
        meter.Installed = chkInstalled.Checked;
        meter.Marks = cboMarks.Text;
        meter.Model = cboModels.Text;
        meter.Provider = cboProviders.Text;
        meter.ReceiptDate = dtmReceipt.SelectedDate;
        meter.Serial = cboSerials.Text;
        short size = 0;
        short.TryParse(cboSizes.Text, out size);
        meter.Size = size;
        meter.Status = cboStatus.Text;
        meter.SerialTransmitter = cboTransmitters.Text;
        meter.Nationality = cboNationalities.Text;
        return meter;
    }
    private void SetControlValues(Meter meter)
    {
        txtAccreditationDocument.Text = meter.AccreditationDocument;
        cboAccreditationTypes.Text = meter.AccreditationType;
        cboAccreditationTypes.SelectedIndex = -1;
        dtmAccredited.SelectedDate = meter.AccreditedDate;
        dtmApproved.SelectedDate = meter.ApprovalDate;
        txtApprovalDecision.Text = meter.ApprovalDecision;
        chkApproved.Checked = meter.Approved ?? false;
        txtDescription.Text = meter.Description;
        dtmExpiry.SelectedDate = meter.ExpiryDate;
        nmrIndex.Value = meter.InitialIndex;
        chkInstalled.Checked = meter.Installed ?? false;
        cboMarks.Text = meter.Marks;
        cboMarks.SelectedIndex = -1;
        cboModels.Text = meter.Model;
        cboModels.SelectedIndex = -1;
        cboProviders.Text = meter.Provider;
        cboProviders.SelectedIndex = -1;
        dtmReceipt.SelectedDate = meter.ReceiptDate;
        cboSerials.SelectedIndex = -1;
        cboSerials.Text = meter.Serial;
        cboSizes.Text = meter.Size.ToString();
        cboSizes.SelectedIndex = -1;
        cboStatus.Text = meter.Status;
        cboTransmitters.Text = meter.SerialTransmitter;
        cboTransmitters.SelectedIndex = -1;
        cboNationalities.Text = meter.Nationality;
        cboNationalities.SelectedIndex = -1;
    }
    protected void btnUpload_Click(object sender, EventArgs e)
    {

    }
    protected void asyncUpload_FileUploaded(object sender, Telerik.Web.UI.FileUploadedEventArgs e)
    {
        ntf.VisibleOnPageLoad = true;
        if (string.IsNullOrEmpty(cboSerials.Text))
        {
            ntf.Text = _msgEmptySerial;
            return;
        }
        string targetFolder = asyncUpload.TargetFolder;
        string newName = "_" + cboSerials.Text + "_" + _stringUTL.RemoveSign4VietnameseString(e.File.GetName());
        e.File.SaveAs(System.IO.Path.Combine(Server.MapPath(targetFolder), newName));
        CommandStatus status = new CommandStatus();
        MeterFile dbFile = _meterFilesBLL.GetByFileName(newName);
        MeterFile file = new MeterFile();
        file.FileName = newName;
        file.MIMEType = e.File.ContentType;
        file.Path = System.IO.Path.Combine(Server.MapPath(targetFolder), file.FileName);
        file.Serial = cboSerials.Text;
        file.Size = (int)e.File.ContentLength;
        file.UploadDate = DateTime.Now;
        if (dbFile != null)
        {
            status = _meterFilesBLL.Update(file);
        }
        else
        {
            status = _meterFilesBLL.Insert(file);
        }
        if (status.Updated || status.Inserted)
        {
            ntf.Text = _msgUploaded;
        }
        else if (status.Error)
        {
            ntf.Text = _msgError + status.ErrorMessage;
        }
    }
    protected void btnDownload_Click(object sender, EventArgs e)
    {
        Response.Redirect(_urlDownload + cboSerials.Text);
    }
}