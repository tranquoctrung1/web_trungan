using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

public partial class _supervisor_report_rsi_history : BasePage
{
    SitesBLL _sitesBLL = new SitesBLL();
    MetersBLL _metersBLL = new MetersBLL();
    SiteHistoriesBLL _sitesHistoriesBLL = new SiteHistoriesBLL();
    SiteMeterHistoriesBLL _siteMeterHistoriesBLL = new SiteMeterHistoriesBLL();
    SiteTransmitterHistoriesBLL _siteTransmitterHistoriesBLL = new SiteTransmitterHistoriesBLL();
    SiteLoggerHistoriesBLL _siteLoggerHistoriesBLL = new SiteLoggerHistoriesBLL();
    protected void Page_Load(object sender, EventArgs e)
    {
        win.VisibleOnPageLoad = false;
        if (!IsPostBack)
        {
            cboSiteIds.Focus();
        }
    }
    protected void cboSiteIds_SelectedIndexChanged(object sender, Telerik.Web.UI.RadComboBoxSelectedIndexChangedEventArgs e)
    {
        win.VisibleOnPageLoad = true;
        rpt.LocalReport.DataSources.Clear();
        rpt.LocalReport.EnableExternalImages = true;
        Microsoft.Reporting.WebForms.ReportParameterCollection parms = new Microsoft.Reporting.WebForms.ReportParameterCollection();
        Site site = _sitesBLL.Get(cboSiteIds.Text);
        Meter meter = _metersBLL.Get(site.Meter);
        if (meter != null)
        {
            parms.Add(new Microsoft.Reporting.WebForms.ReportParameter("Size", (meter.Size ?? 0).ToString()));
            parms.Add(new Microsoft.Reporting.WebForms.ReportParameter("Marks", meter.Marks ?? string.Empty));
        }
        else
        {
            parms.Add(new Microsoft.Reporting.WebForms.ReportParameter("Size", "0"));
            parms.Add(new Microsoft.Reporting.WebForms.ReportParameter("Marks", string.Empty));
        }
        parms.Add(new Microsoft.Reporting.WebForms.ReportParameter("Id", site.Id));
        parms.Add(new Microsoft.Reporting.WebForms.ReportParameter("Location", site.Location));
        parms.Add(new Microsoft.Reporting.WebForms.ReportParameter("Meter", site.Meter));
        parms.Add(new Microsoft.Reporting.WebForms.ReportParameter("Transmitter", site.Transmitter));
        parms.Add(new Microsoft.Reporting.WebForms.ReportParameter("Logger", site.Logger));
        parms.Add(new Microsoft.Reporting.WebForms.ReportParameter("Company", site.Company));
        parms.Add(new Microsoft.Reporting.WebForms.ReportParameter("Status", site.Status));
        parms.Add(new Microsoft.Reporting.WebForms.ReportParameter("Availability", site.Availability));
        parms.Add(new Microsoft.Reporting.WebForms.ReportParameter("Takeovered", site.Takeovered.ToString()));
        parms.Add(new Microsoft.Reporting.WebForms.ReportParameter("MeterDirection", site.MeterDirection));
        parms.Add(new Microsoft.Reporting.WebForms.ReportParameter("Description", site.Description));
        parms.Add(new Microsoft.Reporting.WebForms.ReportParameter("CalculatedCompanies", site.ProductionCompany + " " + site.IstDistributionCompany + " " + site.QndDistributionCompany));
        string folder = System.Configuration.ConfigurationManager.AppSettings["SiteFilesFolder"];
        parms.Add(new Microsoft.Reporting.WebForms.ReportParameter("Image", Server.MapPath(folder) + "_" + cboSiteIds.Text + "_image.jpg"));
        rpt.LocalReport.SetParameters(parms);
        var siteMeterHistory = _siteMeterHistoriesBLL.GetSiteMeterHistory(cboSiteIds.Text);
        var siteTransmitterHistory = _siteTransmitterHistoriesBLL.GetSiteTransmitterHistory(cboSiteIds.Text);
        var siteLoggerHistory = _siteLoggerHistoriesBLL.GetSiteLoggerHistory(cboSiteIds.Text);
        rpt.LocalReport.DataSources.Add(new Microsoft.Reporting.WebForms.ReportDataSource("DataSet1", siteMeterHistory));
        rpt.LocalReport.DataSources.Add(new Microsoft.Reporting.WebForms.ReportDataSource("DataSet2", siteTransmitterHistory));
        rpt.LocalReport.DataSources.Add(new Microsoft.Reporting.WebForms.ReportDataSource("DataSet3", siteLoggerHistory));
        rpt.LocalReport.Refresh();
        win.VisibleOnPageLoad = true;
    }
}