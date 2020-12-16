using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

public partial class _supervisor_device_transmitter : BasePage
{
    private string _msgEmptySerial = "Chưa nhập serial.";
    private string _msgEmptyProvider = "Chưa nhập nhà sản xuất.";
    private string _msgEmptyMarks = "Chưa nhập hiệu.";
    private string _msgEmptySize = "Chưa nhập cỡ.";
    private string _msgEmptyModel = "Chưa nhập model.";
    private string _msgUpdated = "Đã cập nhật dữ liệu.";
    private string _msgInserted = "Đã thêm mới bộ hiển thị.";
    private string _msgDeleted = "Đã xóa bộ hiển thị.";
    private string _msgError = "Lỗi: ";
    TransmittersBLL _transmittersBLL = new TransmittersBLL();
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
        var transmitter = _transmittersBLL.GetBySerial(serial);
        if (transmitter != null)
        {
            SetControlValues(transmitter);
            dtmReceipt.Focus();
        }
        else
        {
            SetControlValues(new Transmitter());
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
        Transmitter transmitter = GetControlValues();
        var dbTransmitter = _transmittersBLL.GetBySerial(transmitter.Serial);
        CommandStatus status = new CommandStatus();
        if (dbTransmitter == null)
        {
            status = _transmittersBLL.Insert(transmitter);
            SerialsDataSource.DataBind();
            cboSerials.DataBind();
        }
        else
        {
            status = _transmittersBLL.Update(transmitter);
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
        Transmitter transmitter = GetControlValues();
        var dbTransmitter = _transmittersBLL.GetBySerial(transmitter.Serial);
        CommandStatus status = new CommandStatus();
        status = _transmittersBLL.Delete(transmitter.Serial);
        if (status.Deleted)
        {
            ntf.Text = _msgDeleted;
            SerialsDataSource.DataBind();
            cboSerials.DataBind();
            SetControlValues(new Transmitter());
        }
        else if (status.Error)
        {
            ntf.Text = _msgError + status.ErrorMessage;
        }
    }
    private Transmitter GetControlValues()
    {
        Transmitter transmitter = new Transmitter();
        transmitter.ApprovalDate = dtmApproved.SelectedDate;
        transmitter.ApprovalDecision = txtApprovalDecision.Text;
        transmitter.Approved = chkApproved.Checked;
        transmitter.Description = txtDescription.Text;
        transmitter.InitialIndex = nmrIndex.Value;
        transmitter.Installed = chkInstalled.Checked;
        transmitter.Marks = cboMarks.Text;
        transmitter.Model = cboModels.Text;
        transmitter.Provider = cboProviders.Text;
        transmitter.ReceiptDate = dtmReceipt.SelectedDate;
        transmitter.Serial = cboSerials.Text;
        short size = 0;
        short.TryParse(cboSizes.Text, out size);
        transmitter.Size = size;
        transmitter.Status = cboStatus.Text;
        transmitter.AccreditationDocument = txtAccreditationDocument.Text;
        transmitter.AccreditationType = cboAccreditationTypes.Text;
        transmitter.AccreditedDate = dtmAccredited.SelectedDate;
        transmitter.MeterSerial = cboMeterSerials.Text;
        return transmitter;

    }
    private void SetControlValues(Transmitter transmitter)
    {
        //dtmApproved.SelectedDate = null;
        //txtApprovalDecision.Text = string.Empty;
        //chkApproved.Checked = false;
        //txtDescription.Text = string.Empty;
        //nmrIndex.Value = null;
        //chkInstalled.Checked = false;
        //cboMarks.SelectedIndex = -1;
        ////cboMarks.SelectedValue = null;
        //cboMarks.Text = string.Empty;
        //cboModels.SelectedIndex = -1;
        ////cboModels.SelectedValue = null;
        //cboModels.Text = string.Empty;
        //cboProviders.SelectedIndex = -1;
        ////cboProviders.SelectedValue = null;
        //cboProviders.Text = string.Empty;
        //dtmReceipt.SelectedDate = null;
        //cboSerials.SelectedIndex = -1;
        //cboSerials.Text = string.Empty;
        ////cboSerials.SelectedValue = null;
        //cboSizes.SelectedIndex = -1;
        ////cboSizes.SelectedValue = null;
        //cboSizes.Text = string.Empty;
        //cboStatus.SelectedIndex = -1;
        ////cboStatus.SelectedValue = null;
        //cboStatus.Text = string.Empty;
        //dtmAccredited.SelectedDate = null;
        //cboAccreditationTypes.Text = string.Empty;
        ////cboAccreditationTypes.SelectedValue = null;
        //cboAccreditationTypes.SelectedIndex = -1;
        //txtAccreditationDocument.Text = string.Empty;
        //cboMeterSerials.SelectedIndex = -1;
        ////cboMeterSerials.SelectedValue = null;
        //cboMeterSerials.Text = string.Empty;


        dtmApproved.SelectedDate = transmitter.ApprovalDate;
        txtApprovalDecision.Text = transmitter.ApprovalDecision;
        chkApproved.Checked = transmitter.Approved ?? false;
        txtDescription.Text = transmitter.Description;
        nmrIndex.Value = transmitter.InitialIndex;
        chkInstalled.Checked = transmitter.Installed ?? false;
        cboMarks.SelectedIndex = -1;
        cboMarks.Text = transmitter.Marks;
        cboModels.SelectedIndex = -1;
        cboModels.Text = transmitter.Model;
        cboProviders.SelectedIndex = -1;
        cboProviders.Text = transmitter.Provider;
        dtmReceipt.SelectedDate = transmitter.ReceiptDate;
        cboSerials.SelectedIndex = -1;
        cboSerials.Text = transmitter.Serial;
        cboSizes.SelectedIndex = -1;
        cboSizes.Text = transmitter.Size.ToString();
        cboStatus.SelectedIndex = -1;
        cboStatus.Text = transmitter.Status;
        dtmAccredited.SelectedDate = transmitter.AccreditedDate;
        cboAccreditationTypes.SelectedIndex = -1;
        cboAccreditationTypes.Text = transmitter.AccreditationType;
        txtAccreditationDocument.Text = transmitter.AccreditationDocument;
        cboMeterSerials.SelectedIndex = -1;
        cboMeterSerials.Text = transmitter.MeterSerial;
    }
}