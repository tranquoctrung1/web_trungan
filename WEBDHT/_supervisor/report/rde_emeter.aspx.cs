using System;

public partial class _supervisor_report_rde_emeter : BasePage
{
    MetersBLL _metersBLL = new MetersBLL();
    SitesBLL _sitesBLL = new SitesBLL();

    protected void Page_Load(object sender, EventArgs e)
    {
        win.VisibleOnPageLoad = false;
    }
    protected void cboMeters_SelectedIndexChanged(object sender, Telerik.Web.UI.RadComboBoxSelectedIndexChangedEventArgs e)
    {
        Meter meter = _metersBLL.GetBySerial(cboMeters.Text);
        Site site = _sitesBLL.GetSiteByMeterSerial(cboMeters.Text);
        Microsoft.Reporting.WebForms.ReportParameterCollection parms = new Microsoft.Reporting.WebForms.ReportParameterCollection();
        parms.Add(new Microsoft.Reporting.WebForms.ReportParameter("Serial", meter.Serial));
        parms.Add(new Microsoft.Reporting.WebForms.ReportParameter("ReceiptDate", meter.ReceiptDate !=  null ? ((DateTime)meter.ReceiptDate).ToString("dd/MM/yyyy") : ""));
        parms.Add(new Microsoft.Reporting.WebForms.ReportParameter("Provider", meter.Provider));
        parms.Add(new Microsoft.Reporting.WebForms.ReportParameter("Marks", meter.Marks));
        parms.Add(new Microsoft.Reporting.WebForms.ReportParameter("Size", meter.Size.ToString()));
        parms.Add(new Microsoft.Reporting.WebForms.ReportParameter("Model", meter.Model));
        parms.Add(new Microsoft.Reporting.WebForms.ReportParameter("Status", meter.Status));
        parms.Add(new Microsoft.Reporting.WebForms.ReportParameter("Installed", meter.Installed == true? "Yes" : "No"));
        parms.Add(new Microsoft.Reporting.WebForms.ReportParameter("Index", meter.InitialIndex.ToString()));
        parms.Add(new Microsoft.Reporting.WebForms.ReportParameter("Description", meter.Description));
        parms.Add(new Microsoft.Reporting.WebForms.ReportParameter("ApprovalDate", meter.AccreditedDate != null ? ((DateTime)meter.AccreditedDate).ToString("dd/MM/yyyy") : ""));
        parms.Add(new Microsoft.Reporting.WebForms.ReportParameter("ApprovalDecision", meter.ApprovalDecision));
        parms.Add(new Microsoft.Reporting.WebForms.ReportParameter("Approved", meter.Approved == true ? "Yes" : "No"));
        parms.Add(new Microsoft.Reporting.WebForms.ReportParameter("AccreditedDate", meter.AccreditedDate != null ? ((DateTime)meter.AccreditedDate).ToString("dd/MM/yyyy") : ""));
        parms.Add(new Microsoft.Reporting.WebForms.ReportParameter("ExpiryDate", meter.ExpiryDate != null ? ((DateTime)meter.ExpiryDate).ToString("dd/MM/yyyy") : ""));
        parms.Add(new Microsoft.Reporting.WebForms.ReportParameter("AccreditationType", meter.AccreditationType));
        parms.Add(new Microsoft.Reporting.WebForms.ReportParameter("AccreditationDocument", meter.AccreditationDocument));
        parms.Add(new Microsoft.Reporting.WebForms.ReportParameter("TransmitterSerial", meter.SerialTransmitter));
        parms.Add(new Microsoft.Reporting.WebForms.ReportParameter("SiteID", site != null ? site.Id : ""));
        parms.Add(new Microsoft.Reporting.WebForms.ReportParameter("SiteLocation", site != null ? site.Location : ""));
        parms.Add(new Microsoft.Reporting.WebForms.ReportParameter("Nation", site != null ? meter.Nationality : ""));
        rpt.LocalReport.SetParameters(parms);
        rpt.LocalReport.Refresh();
        win.VisibleOnPageLoad = true;
    }
}