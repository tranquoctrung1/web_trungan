using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

public partial class _supervisor_report_rde_elogger : BasePage
{
    SitesBLL _sitesBLL = new SitesBLL();
    LoggersBLL _loggersBLL = new LoggersBLL();
    protected void Page_Load(object sender, EventArgs e)
    {
        win.VisibleOnPageLoad = false;
    }
    protected void cboLoggers_SelectedIndexChanged(object sender, Telerik.Web.UI.RadComboBoxSelectedIndexChangedEventArgs e)
    {
        Site site = _sitesBLL.GetSiteByLoggerSerial(cboLoggers.Text);
        Logger logger = _loggersBLL.GetBySerial(cboLoggers.Text);
        Microsoft.Reporting.WebForms.ReportParameterCollection parms = new Microsoft.Reporting.WebForms.ReportParameterCollection();
        parms.Add(new Microsoft.Reporting.WebForms.ReportParameter("Serial", logger.Serial));
        parms.Add(new Microsoft.Reporting.WebForms.ReportParameter("ReceiptDate", logger.ReceiptDate != null ? ((DateTime)logger.ReceiptDate).ToString("dd/MM/yyyy") : ""));
        parms.Add(new Microsoft.Reporting.WebForms.ReportParameter("Provider", logger.Provider));
        parms.Add(new Microsoft.Reporting.WebForms.ReportParameter("Marks", logger.Marks));
        parms.Add(new Microsoft.Reporting.WebForms.ReportParameter("Model", logger.Model));
        parms.Add(new Microsoft.Reporting.WebForms.ReportParameter("Status", logger.Status));
        parms.Add(new Microsoft.Reporting.WebForms.ReportParameter("Installed", logger.Installed == true ? "Yes" : "No"));
        parms.Add(new Microsoft.Reporting.WebForms.ReportParameter("Description", logger.Description));

        parms.Add(new Microsoft.Reporting.WebForms.ReportParameter("SiteID", site != null ? site.Id : ""));
        parms.Add(new Microsoft.Reporting.WebForms.ReportParameter("SiteLocation", site != null ? site.Location : ""));
        rpt.LocalReport.SetParameters(parms);
        rpt.LocalReport.Refresh();
        win.VisibleOnPageLoad = true;
    }
}