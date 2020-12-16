using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

public partial class _supervisor_data_change : BasePage
{
    private string _msgEmptySiteId = "Chưa nhập mã vị trí.";
    private string _msgEmptyStartDate = "Chưa nhập ngày bắt đầu.";
    private string _msgEmptyEndDate = "Chưa nhập ngày kết thúc.";
    private string _msgInserted = "Đã cập nhật dữ liệu đọc số.";
    private string _msgDeleted = "Đã xóa dữ liệu đọc số.";
    private string _msgError = "Lỗi: ";
    SitesBLL _sitesBLL = new SitesBLL();
    DataBLL _dataBLL = new DataBLL();
    protected void Page_Load(object sender, EventArgs e)
    {
        ntf.VisibleOnPageLoad = false;
        if (!IsPostBack)
        {
            grvData.Visible = false;
            cboIds.Focus();
        }
    }
    protected void btnView_Click(object sender, EventArgs e)
    {
        DateTime start = default(DateTime);
        DateTime end = default(DateTime);
        string id = default(string);
        bool valid = GetInputValue(ref id, ref start, ref end);
        if (!valid) return;
        start = (DateTime)dtmStart.SelectedDate;
        end = (DateTime)dtmEnd.SelectedDate;
        id = cboIds.Text;
        grvData.DataSource = _dataBLL.Get(id, start, end);
        grvData.DataBind();
        grvData.Visible = true;
    }
    protected void cboIds_SelectedIndexChanged(object sender, Telerik.Web.UI.RadComboBoxSelectedIndexChangedEventArgs e)
    {
        string siteId = cboIds.Text;
        Site site = _sitesBLL.GetById(siteId);
        if (site != null)
        {
            cboStaffs.Text = site.StaffId;
            txtLocation.Text = site.Location;
            cboMeters.Text = site.Meter;
            dtmStart.Focus();
        }
    }
    protected void btnChange_Click(object sender, EventArgs e)
    {
        CommandStatus status = new CommandStatus();
        List<ManualData> list = GetGridData();
        status = _dataBLL.InsertOrUpdate(list);
        if (!status.Error)
        {
            ntf.Text = _msgInserted;
            WriteLogFileWhenUpdate(list);
        }
        else
        {
            ntf.Text = _msgError;
        }
        ntf.VisibleOnPageLoad = true;
    }
    private List<ManualData> GetGridData()
    {
        List<ManualData> list = new List<ManualData>();
        foreach (Telerik.Web.UI.GridItem item in grvData.Items)
        {
            Telerik.Web.UI.RadTextBox txtDescription = (Telerik.Web.UI.RadTextBox)item.FindControl("txtDescription");
            Telerik.Web.UI.RadDatePicker dtmTimeStamp = (Telerik.Web.UI.RadDatePicker)item.FindControl("dtmTimeStamp");
            Telerik.Web.UI.RadNumericTextBox nmrIndex = (Telerik.Web.UI.RadNumericTextBox)item.FindControl("nmrIndex");
            Telerik.Web.UI.RadNumericTextBox nmrOutput = (Telerik.Web.UI.RadNumericTextBox)item.FindControl("nmrOutput");
            ManualData data = new ManualData();
            data.Description = txtDescription.Text;
            data.Index = nmrIndex.Value;
            data.Output = nmrOutput.Value;
            data.TimeStamp = dtmTimeStamp.SelectedDate;
            data.SiteId = cboIds.Text;
            list.Add(data);
        }
        return list;
    }
    protected void btnConfim_Click(object sender, EventArgs e)
    {
        DateTime start = default(DateTime);
        DateTime end = default(DateTime);
        string id = default(string);
        bool valid = GetInputValue(ref id, ref start, ref end);
        if (!valid) return;
        start = (DateTime)dtmStart.SelectedDate;
        end = (DateTime)dtmEnd.SelectedDate;
        id = cboIds.Text;
        List<ManualData> list = GetGridData();
        CommandStatus status = _dataBLL.Delete(id, start, end);
        if (status.Deleted)
        {
            ntf.Text = _msgDeleted;
            WriteLogFileWhenDelete(list);
        }
        else
        {
            ntf.Text = _msgError + status.ErrorMessage;
        }
        ntf.VisibleOnPageLoad = true;
        grvData.DataSource = new List<ManualData>();
        grvData.DataBind();
    }
    private bool GetInputValue(ref string siteId, ref DateTime start, ref DateTime end)
    {
        if (string.IsNullOrEmpty(cboIds.Text))
        {
            ntf.Text = _msgEmptySiteId;
            ntf.VisibleOnPageLoad = true;
            cboIds.Focus();
            return false;
        }
        if (dtmStart.SelectedDate == null)
        {
            ntf.Text = _msgEmptyStartDate;
            ntf.VisibleOnPageLoad = true;
            dtmStart.Focus();
            return false;
        }
        if (dtmEnd.SelectedDate == null)
        {
            ntf.Text = _msgEmptyEndDate;
            ntf.VisibleOnPageLoad = true;
            dtmEnd.Focus();
            return false;
        }
        return true;
    }
    private void WriteLogFileWhenUpdate(List<ManualData> list)
    {
        FilesUTL _filesUTL = new FilesUTL();
        string user = HttpContext.Current.User.Identity.Name;
        string serverFilePath = Server.MapPath(System.Web.Configuration.WebConfigurationManager.AppSettings["LogFile"]);
        string content = "";
        foreach (var item in list)
        {
            if (item.TimeStamp != null)
            {
                content = "UPDATE MANUAL DATA: " + item.SiteId + "|index:" + item.Index.ToString() + "|output:" + item.Output.ToString() + "|description:" + item.Description;
                try
                {
                    _filesUTL.WriteLogFile(serverFilePath, user, content);
                }
                catch (Exception ex)
                {

                    //throw ex;
                }
            }
        }
    }
    private void WriteLogFileWhenDelete(List<ManualData> list)
    {
        FilesUTL _filesUTL = new FilesUTL();
        string user = HttpContext.Current.User.Identity.Name;
        string serverFilePath = Server.MapPath(System.Web.Configuration.WebConfigurationManager.AppSettings["LogFile"]);
        string content = "";
        foreach (var item in list)
        {
            if (item.TimeStamp != null)
            {
                content = "DELETE MANUAL DATA: " + item.SiteId + "|timestamp:" +item.TimeStamp.ToString()+ "|index:" + item.Index.ToString() + "|output:" + item.Output.ToString() + "|description:" + item.Description;
                try
                {
                    _filesUTL.WriteLogFile(serverFilePath, user, content);
                }
                catch (Exception ex)
                {

                    //throw ex;
                }
            }
        }
    }
}