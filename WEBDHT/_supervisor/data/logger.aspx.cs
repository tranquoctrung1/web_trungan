using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

public partial class _supervisor_data_logger : BasePage
{
    private string _msgInserted = "Đã cập nhật dữ liệu.";
    private string _msgError = "Lỗi: ";
    SitesBLL _sitesBLL = new SitesBLL();
    DataBLL _dataBLL = new DataBLL();
    protected void Page_Load(object sender, EventArgs e)
    {
        if (!IsPostBack)
        {
            grvData.Visible = false;
        }
        cboIds.Focus();
        ntf.VisibleOnPageLoad = false;

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
            SetLastData(siteId);
            grvData.Visible = true;
        }
    }
    protected void txtOutput_TextChanged(object sender, EventArgs e)
    {
        List<ManualData> list = GetGridData();
        if (list[list.Count - 1].Output == null)
        {
            return;
        }
        _dataBLL.CalculateGridOutput(ref list);
        grvData.DataSource = list;
        grvData.DataBind();
    }
    private void SetLastData(string siteId)
    {
        List<ManualData> list = _dataBLL.GetLatest(siteId);
        list.Add(new ManualData());
        grvData.DataSource = list;
        grvData.DataBind();
    }
    private void SetFocus()
    {
        grvData.Focus();
        int rowCount = grvData.Items.Count;
        Telerik.Web.UI.GridItem item = grvData.Items[rowCount - 1];
        Telerik.Web.UI.RadDatePicker dtmTimeStamp = (Telerik.Web.UI.RadDatePicker)item.FindControl("dtmTimeStamp");
        dtmTimeStamp.Focus();
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
    protected void btnAdd_Click(object sender, EventArgs e)
    {
        ntf.VisibleOnPageLoad = true;
        List<ManualData> list = GetGridData();
        CommandStatus status = _dataBLL.InsertOrUpdate(list);
        if (!status.Error)
        {
            ntf.Text = _msgInserted;
            WriteLogFile(list);
        }
        else
        {
            ntf.Text = _msgError + status.ErrorMessage;
        }
    }
    protected void grvData_DataBound(object sender, EventArgs e)
    {
        SetFocus();
    }
    protected void btnDelete_Click(object sender, EventArgs e)
    {
        SetLastData(cboIds.Text);
    }
    private void WriteLogFile(List<ManualData> list)
    {
        FilesUTL _filesUTL = new FilesUTL();
        string user = HttpContext.Current.User.Identity.Name;
        string serverFilePath = Server.MapPath(System.Web.Configuration.WebConfigurationManager.AppSettings["LogFile"]);
        string content = "";
        foreach (var item in list)
        {
            if (item.TimeStamp != null)
            {
                content = "INSERT/UPDATE MANUAL DATA: " + item.SiteId + "|timestamp:" + item.TimeStamp.ToString() + "|index:" + item.Index.ToString() + "|output:" + item.Output.ToString() + "|description:" + item.Description;
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