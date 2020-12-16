using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

public partial class _supervisor_report_rsi_4_staff : BasePage
{
    SitesBLL _sitesBLL = new SitesBLL();
    string _nameReport = "_mau_in_doc_so_";
    protected void Page_Load(object sender, EventArgs e)
    {
        win.VisibleOnPageLoad = false;
    }
    protected void cboStaffs_SelectedIndexChanged(object sender, Telerik.Web.UI.RadComboBoxSelectedIndexChangedEventArgs e)
    {
        win.VisibleOnPageLoad = true;
        string staffId = cboStaffs.SelectedValue;
        List<SiteViewModel> list = _sitesBLL.GetAll4Staff(staffId);
        rpt.LocalReport.DataSources.Clear();
        rpt.LocalReport.DataSources.Add(new Microsoft.Reporting.WebForms.ReportDataSource("DataSet1", list));
        rpt.LocalReport.DisplayName = _nameReport + cboStaffs.Text;
        rpt.LocalReport.Refresh();
    }
}