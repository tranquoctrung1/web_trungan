using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

public partial class _supervisor_device_delete_useless_loggers : BasePage
{
    private string _msgDeleted = "Đã xóa logger.";
    private string _msgError = "Lỗi: ";
    LoggersBLL _loggersBLL = new LoggersBLL();
    protected void Page_Load(object sender, EventArgs e)
    {
        ntf.VisibleOnPageLoad = false;
    }
    protected void btnConfirmDelete_Click(object sender, EventArgs e)
    {
        ntf.VisibleOnPageLoad = true;
        CommandStatus status = new CommandStatus();
        List<string>listSelected = GetSeletedSerials();
        status = _loggersBLL.DeleteUseless(listSelected);
        if (status.Deleted)
        {
            ntf.Text = _msgDeleted;
        }
        else
        {
            ntf.Text = _msgError;
        }
        LoggersDataSource.DataBind();
        grv.DataBind();
    }
    private List<string> GetSeletedSerials()
    {
        List<string> listSelectedSerial = new List<string>();
        foreach (Telerik.Web.UI.GridDataItem row in grv.SelectedItems)
        {
            listSelectedSerial.Add(row["Serial"].Text);
        }
        return listSelectedSerial;
    }
}