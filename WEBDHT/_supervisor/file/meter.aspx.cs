using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

public partial class _supervisor_file_meter : BasePage
{
    private string _msgDeleted = "Đã xóa files.";
    private string _msgError = "Có lỗi, thử lại.";
    private string _msgNoFile = "Không có file hoặc chưa chọn file.";
    FilesUTL _filesUTL = new FilesUTL();
    MeterFilesBLL _meterFilesBLL = new MeterFilesBLL();
    protected void Page_Load(object sender, EventArgs e)
    {
        ntf.VisibleOnPageLoad = false;
        if (!IsPostBack)
        {
            string meterSerial = Request.QueryString["sr"];
            if (!string.IsNullOrEmpty(meterSerial))
            {
                cboSerials.SelectedValue = meterSerial;
            }
            cboSerials.Focus();
        }
    }
    protected void btnDownload_Click(object sender, EventArgs e)
    {
        ntf.VisibleOnPageLoad = true;
        List<string> listFiles = GetFiles();
        if (listFiles.Count == 0)
        {
            ntf.Text = _msgNoFile;
            return;
        }
        string folder = Server.MapPath(System.Configuration.ConfigurationManager.AppSettings["MeterFilesFolder"]);
        _filesUTL.DownloadMultiFiles(cboSerials.Text, listFiles, folder, Response);
    }
    protected void cboSerials_SelectedIndexChanged(object sender, Telerik.Web.UI.RadComboBoxSelectedIndexChangedEventArgs e)
    {

    }
    protected void btnConfirmDelete_Click(object sender, EventArgs e)
    {
        ntf.VisibleOnPageLoad = true;
        CommandStatus status = new CommandStatus();
        string folder = System.Configuration.ConfigurationManager.AppSettings["MeterFilesFolder"];
        List<string> listFiles = GetFiles();
        if (listFiles.Count == 0)
        {
            ntf.Text = _msgNoFile;
            return;
        }
        _filesUTL.DeleteFiles(folder, listFiles);
        status = _meterFilesBLL.Delete(listFiles);
        if (status.Deleted)
        {
            ntf.Text = _msgDeleted;
        }
        else
        {
            ntf.Text = _msgError;
        }
        FilesDataSource.DataBind();
        grv.DataBind();
    }
    private List<string> GetFiles()
    {
        List<string> listFiles = new List<string>();
        foreach (Telerik.Web.UI.GridDataItem row in grv.SelectedItems)
        {
            listFiles.Add(row["FileName"].Text);
        }
        return listFiles;
    }
}