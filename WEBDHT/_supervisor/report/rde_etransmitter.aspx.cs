using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

public partial class _supervisor_report_rde_etransmitter : BasePage
{
    MetersBLL _metersBLL = new MetersBLL();
    SitesBLL _sitesBLL = new SitesBLL();
    TransmittersBLL _transmittersBLL = new TransmittersBLL();
    protected void Page_Load(object sender, EventArgs e)
    {
        //win.VisibleOnPageLoad = false;
    }
    protected void cboTransmitters_SelectedIndexChanged(object sender, Telerik.Web.UI.RadComboBoxSelectedIndexChangedEventArgs e)
    {
        Meter meter = _metersBLL.GetByTransmitterSerial(cboTransmitters.Text);
        if (meter == null)
        {
            meter = new Meter();
        }
        Site site = _sitesBLL.GetSiteByTranSerial(cboTransmitters.Text);
        Transmitter transmitter = _transmittersBLL.GetBySerial(cboTransmitters.Text);
        Microsoft.Reporting.WebForms.ReportParameterCollection parms = new Microsoft.Reporting.WebForms.ReportParameterCollection();
        parms.Add(new Microsoft.Reporting.WebForms.ReportParameter("Serial", transmitter.Serial));
        parms.Add(new Microsoft.Reporting.WebForms.ReportParameter("ReceiptDate", transmitter.ReceiptDate != null ? ((DateTime)transmitter.ReceiptDate).ToString("dd/MM/yyyy") : ""));
        parms.Add(new Microsoft.Reporting.WebForms.ReportParameter("Provider", transmitter.Provider));
        parms.Add(new Microsoft.Reporting.WebForms.ReportParameter("Marks", transmitter.Marks));
        parms.Add(new Microsoft.Reporting.WebForms.ReportParameter("Size", transmitter.Size.ToString()));
        parms.Add(new Microsoft.Reporting.WebForms.ReportParameter("Model", transmitter.Model));
        parms.Add(new Microsoft.Reporting.WebForms.ReportParameter("Status", transmitter.Status));
        parms.Add(new Microsoft.Reporting.WebForms.ReportParameter("Installed", transmitter.Installed == true ? "Yes" : "No"));
        parms.Add(new Microsoft.Reporting.WebForms.ReportParameter("Index", transmitter.InitialIndex.ToString()));
        parms.Add(new Microsoft.Reporting.WebForms.ReportParameter("Description", transmitter.Description));
        parms.Add(new Microsoft.Reporting.WebForms.ReportParameter("ApprovalDate", meter.AccreditedDate != null ? ((DateTime)meter.AccreditedDate).ToString("dd/MM/yyyy") : ""));
        parms.Add(new Microsoft.Reporting.WebForms.ReportParameter("ApprovalDecision", transmitter.ApprovalDecision));
        parms.Add(new Microsoft.Reporting.WebForms.ReportParameter("Approved", transmitter.Approved == true ? "Yes" : "No"));
        parms.Add(new Microsoft.Reporting.WebForms.ReportParameter("AccreditedDate", meter.AccreditedDate != null ? ((DateTime)meter.AccreditedDate).ToString("dd/MM/yyyy") : ""));
        parms.Add(new Microsoft.Reporting.WebForms.ReportParameter("ExpiryDate", meter.ExpiryDate != null ? ((DateTime)meter.ExpiryDate).ToString("dd/MM/yyyy") : ""));
        parms.Add(new Microsoft.Reporting.WebForms.ReportParameter("AccreditationType", meter.AccreditationType));
        parms.Add(new Microsoft.Reporting.WebForms.ReportParameter("AccreditationDocument", meter.AccreditationDocument));
        parms.Add(new Microsoft.Reporting.WebForms.ReportParameter("SiteID", site != null ? site.Id : ""));
        parms.Add(new Microsoft.Reporting.WebForms.ReportParameter("SiteLocation", site != null ? site.Location : ""));
        rpt.LocalReport.SetParameters(parms);
        rpt.LocalReport.Refresh();
        //win.VisibleOnPageLoad = true;
    }
}