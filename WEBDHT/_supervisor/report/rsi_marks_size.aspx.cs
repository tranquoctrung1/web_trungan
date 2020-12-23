using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

public partial class _supervisor_report_rsi_marks_size : BasePage
{
    string _urlReportMarks = @"App_Data\reports\rsi_marks.rdlc";
    string _urlReportSize = @"App_Data\reports\rsi_size.rdlc";
    string _urlReportMarksAndSize = @"App_Data\reports\rsi_marks_size.rdlc";
    string _nameReportMarks = "_hieu_tuy_chon";
    string _nameReportSize = "_co_tuy_chon";
    string _nameReportMarksAndSize = "_hieu_co_tuy_chon";
    SitesBLL _sitesBLL = new SitesBLL();
    MetersBLL _metersBLL = new MetersBLL();

    protected void Page_Load(object sender, EventArgs e)
    {
        //win.VisibleOnPageLoad = false;
    }
    protected void btnView_Click(object sender, EventArgs e)
    {
        //win.VisibleOnPageLoad = true;
        List<string> listLevels = GetLevels();
        if (listLevels.Count == 0)
        {
            listLevels = GetAllLevels();
        }
        List<string> listGroups = GetGroups();
        if (listGroups.Count == 0)
        {
            listGroups = GetAllGroups();
        }
        List<string> listGroup2s = GetGroup2s();
        if (listGroup2s.Count == 0)
        {
            listGroup2s = GetAllGroup2s();
        }
        List<string> listCompanies = GetCompanies();
        if (listCompanies.Count == 0)
        {
            listCompanies = GetAllCompanies();
        }
        List<string> listStatus = GetStatus();
        if (listStatus.Count == 0)
        {
            listStatus = GetAllStatus();
        }
        List<string> listAvailabilities = GetAvailabilities();
        if (listAvailabilities.Count == 0)
        {
            listAvailabilities = GetAllAvailabilities();
        }
        List<string> listCalculates = GetCalculates();
        if (listCalculates.Count == 0)
        {
            listCalculates = GetAllCalculates();
        }
        List<bool> listTakeovereds = GetTakeovereds();
        if (listTakeovereds.Count == 0)
        {
            listTakeovereds = GetAllTakeovereds();
        }
        List<bool> listProperties = GetProperties();
        if (listProperties.Count == 0)
        {
            listProperties = GetAllProperties();
        }
        List<bool> listUsingLoggers = GetUsingLoggers();
        if (listUsingLoggers.Count == 0)
        {
            listUsingLoggers = GetAllUsingLoggers();
        }
        List<string> listLoggerModels = GetLoggerModels();
        if (listLoggerModels.Count == 0)
        {
            listLoggerModels = GetAllLoggerModels();
        }
        List<string> listAccreditationTypes = GetAccreditationTypes();
        if (listAccreditationTypes.Count == 0)
        {
            listAccreditationTypes = GetAllAccreditationTypes();
        }
        List<bool> listApproved = GetApproved();
        if (listApproved.Count == 0)
        {
            listApproved = GetAllApproved();
        }
        List<string> listMeterModels = GetMeterModels();
        if (listMeterModels.Count==0)
        {
            listMeterModels = GetAllMeterModels();
        }
        List<SiteViewModel> list = _sitesBLL.GetAllByConds(listLevels, listGroups,
            listCompanies, listStatus, listAvailabilities, listCalculates,
            listTakeovereds, listProperties, listUsingLoggers,
            listLoggerModels, listAccreditationTypes, listApproved,listGroup2s, listMeterModels);
        rpt.LocalReport.ReportPath = _urlReportMarksAndSize;
        rpt.LocalReport.DataSources.Clear();
        rpt.LocalReport.DataSources.Add(new Microsoft.Reporting.WebForms.ReportDataSource("DataSet1", list));
        rpt.LocalReport.DisplayName = _nameReportMarksAndSize;
        rpt.LocalReport.Refresh();
    }

    private List<string> GetAllMeterModels()
    {
        List<string> list = new List<string>();
        foreach (ListItem item in chkListMeterModels.Items)
        {
            list.Add(item.Value);
        }
        return list;
        //throw new NotImplementedException();
    }

    protected void btnMarks_Click(object sender, EventArgs e)
    {
       // win.VisibleOnPageLoad = true;
        List<string> listLevels = GetLevels();
        if (listLevels.Count == 0)
        {
            listLevels = GetAllLevels();
        }
        List<string> listGroups = GetGroups();
        if (listGroups.Count == 0)
        {
            listGroups = GetAllGroups();
        }
        List<string> listGroup2s = GetGroup2s();
        if (listGroup2s.Count == 0)
        {
            listGroup2s = GetAllGroup2s();
        }
        List<string> listCompanies = GetCompanies();
        if (listCompanies.Count == 0)
        {
            listCompanies = GetAllCompanies();
        }
        List<string> listStatus = GetStatus();
        if (listStatus.Count == 0)
        {
            listStatus = GetAllStatus();
        }
        List<string> listAvailabilities = GetAvailabilities();
        if (listAvailabilities.Count == 0)
        {
            listAvailabilities = GetAllAvailabilities();
        }
        List<string> listCalculates = GetCalculates();
        if (listCalculates.Count == 0)
        {
            listCalculates = GetAllCalculates();
        }
        List<bool> listTakeovereds = GetTakeovereds();
        if (listTakeovereds.Count == 0)
        {
            listTakeovereds = GetAllTakeovereds();
        }
        List<bool> listProperties = GetProperties();
        if (listProperties.Count == 0)
        {
            listProperties = GetAllProperties();
        }
        List<bool> listUsingLoggers = GetUsingLoggers();
        if (listUsingLoggers.Count == 0)
        {
            listUsingLoggers = GetAllUsingLoggers();
        }
        List<string> listLoggerModels = GetLoggerModels();
        if (listLoggerModels.Count == 0)
        {
            listLoggerModels = GetAllLoggerModels();
        }
        List<string> listAccreditationTypes = GetAccreditationTypes();
        if (listAccreditationTypes.Count == 0)
        {
            listAccreditationTypes = GetAllAccreditationTypes();
        }
        List<bool> listApproved = GetApproved();
        if (listApproved.Count == 0)
        {
            listApproved = GetAllApproved();
        }
        List<string> listMeterModels = GetMeterModels();
        if (listMeterModels.Count==0)
        {
            listMeterModels = GetAllMeterModels();
        }
        List<SiteViewModel> list = _sitesBLL.GetAllByConds(listLevels, listGroups,
            listCompanies, listStatus, listAvailabilities, listCalculates,
            listTakeovereds, listProperties, listUsingLoggers,
            listLoggerModels, listAccreditationTypes, listApproved,listGroup2s, listMeterModels);
        rpt.LocalReport.ReportPath = _urlReportMarks;
        rpt.LocalReport.DataSources.Clear();
        rpt.LocalReport.DataSources.Add(new Microsoft.Reporting.WebForms.ReportDataSource("DataSet1", list));
        rpt.LocalReport.DisplayName = _nameReportMarks;
        rpt.LocalReport.Refresh();
    }

    private List<string> GetMeterModels()
    {
        List<string> list = new List<string>();
        foreach (ListItem item in chkListMeterModels.Items)
        {
            if (item.Selected)
            {
                list.Add(item.Value);
            }
        }

        return list;
        //throw new NotImplementedException();
    }

    protected void btnSize_Click(object sender, EventArgs e)
    {
        //win.VisibleOnPageLoad = true;
        List<string> listLevels = GetLevels();
        if (listLevels.Count == 0)
        {
            listLevels = GetAllLevels();
        }
        List<string> listGroups = GetGroups();
        if (listGroups.Count == 0)
        {
            listGroups = GetAllGroups();
        }
        List<string> listGroup2s = GetGroup2s();
        if (listGroup2s.Count == 0)
        {
            listGroup2s = GetAllGroup2s();
        }
        List<string> listCompanies = GetCompanies();
        if (listCompanies.Count == 0)
        {
            listCompanies = GetAllCompanies();
        }
        List<string> listStatus = GetStatus();
        if (listStatus.Count == 0)
        {
            listStatus = GetAllStatus();
        }
        List<string> listAvailabilities = GetAvailabilities();
        if (listAvailabilities.Count == 0)
        {
            listAvailabilities = GetAllAvailabilities();
        }
        List<string> listCalculates = GetCalculates();
        if (listCalculates.Count == 0)
        {
            listCalculates = GetAllCalculates();
        }
        List<bool> listTakeovereds = GetTakeovereds();
        if (listTakeovereds.Count == 0)
        {
            listTakeovereds = GetAllTakeovereds();
        }
        List<bool> listProperties = GetProperties();
        if (listProperties.Count == 0)
        {
            listProperties = GetAllProperties();
        }
        List<bool> listUsingLoggers = GetUsingLoggers();
        if (listUsingLoggers.Count == 0)
        {
            listUsingLoggers = GetAllUsingLoggers();
        }
        List<string> listLoggerModels = GetLoggerModels();
        if (listLoggerModels.Count == 0)
        {
            listLoggerModels = GetAllLoggerModels();
        }
        List<string> listAccreditationTypes = GetAccreditationTypes();
        if (listAccreditationTypes.Count == 0)
        {
            listAccreditationTypes = GetAllAccreditationTypes();
        }
        List<bool> listApproved = GetApproved();
        if (listApproved.Count == 0)
        {
            listApproved = GetAllApproved();
        }
        List<string> listMeterModels = GetMeterModels();
        if (listMeterModels.Count == 0)
        {
            listMeterModels = GetAllMeterModels();
        }
        List<SiteViewModel> list = _sitesBLL.GetAllByConds(listLevels, listGroups, listCompanies,
            listStatus, listAvailabilities, listCalculates, listTakeovereds, listProperties,
            listUsingLoggers, listLoggerModels, listAccreditationTypes, listApproved, listGroup2s, listMeterModels);
        rpt.LocalReport.ReportPath = _urlReportSize;
        rpt.LocalReport.DataSources.Clear();
        rpt.LocalReport.DataSources.Add(new Microsoft.Reporting.WebForms.ReportDataSource("DataSet1", list));
        rpt.LocalReport.DisplayName = _nameReportSize;
        rpt.LocalReport.Refresh();
    }

    private List<string> GetAllLevels()
    {
        List<string> list = new List<string>();
        foreach (ListItem item in chkListLevels.Items)
        {
            list.Add(item.Value);
        }
        list.Add(string.Empty);
        return list;
    }
    private List<string> GetLevels()
    {
        List<string> list = new List<string>();
        foreach (ListItem item in chkListLevels.Items)
        {
            if (item.Selected)
            {
                list.Add(item.Value);
            }
        }
        return list;
    }
    private List<string> GetAllGroups()
    {
        List<string> list = new List<string>();
        foreach (ListItem item in chkListGroups.Items)
        {
            list.Add(item.Value);
        }
        list.Add(string.Empty);
        return list;
    }
    private List<string> GetGroups()
    {
        List<string> list = new List<string>();
        foreach (ListItem item in chkListGroups.Items)
        {
            if (item.Selected)
            {
                list.Add(item.Value);
            }
        }
        return list;
    }
    private List<string> GetAllGroup2s()
    {
        List<string> list = new List<string>();
        foreach (ListItem item in chkListGroup2s.Items)
        {
            list.Add(item.Value);
        }
        list.Add(string.Empty);
        list.Add(null);
        return list;
    }
    private List<string> GetGroup2s()
    {
        List<string> list = new List<string>();
        foreach (ListItem item in chkListGroup2s.Items)
        {
            if (item.Selected)
            {
                list.Add(item.Value);
            }
        }
        return list;
    }
    private List<string> GetAllCompanies()
    {
        List<string> list = new List<string>();
        foreach (ListItem item in chkListCompanies.Items)
        {
            list.Add(item.Value);
        }
        list.Add(string.Empty);
        return list;
    }
    private List<string> GetCompanies()
    {
        List<string> list = new List<string>();
        foreach (ListItem item in chkListCompanies.Items)
        {
            if (item.Selected)
            {
                list.Add(item.Value);
            }
        }
        return list;
    }
    private List<string> GetAllStatus()
    {
        List<string> list = new List<string>();
        foreach (ListItem item in chkListStatus.Items)
        {
            list.Add(item.Value);
        }
        list.Add(string.Empty);
        return list;
    }
    private List<string> GetStatus()
    {
        List<string> list = new List<string>();
        foreach (ListItem item in chkListStatus.Items)
        {
            if (item.Selected)
            {
                list.Add(item.Value);
            }
        }
        return list;
    }
    private List<string> GetAllAvailabilities()
    {
        List<string> list = new List<string>();
        foreach (ListItem item in chkListAvailabilities.Items)
        {
            list.Add(item.Value);
        }
        list.Add(string.Empty);
        return list;
    }
    private List<string> GetAvailabilities()
    {
        List<string> list = new List<string>();
        foreach (ListItem item in chkListAvailabilities.Items)
        {
            if (item.Selected)
            {
                list.Add(item.Value);
            }
        }
        return list;
    }
    private List<string> GetAllCalculates()
    {
        List<string> list = new List<string>();
        foreach (ListItem item in chkListCalculate.Items)
        {
            list.Add(item.Value);
        }
        list.Add(string.Empty);
        return list;
    }
    private List<string> GetCalculates()
    {
        List<string> list = new List<string>();
        foreach (ListItem item in chkListCalculate.Items)
        {
            if (item.Selected)
            {
                list.Add(item.Value);
            }
        }
        return list;
    }
    private List<bool> GetAllTakeovereds()
    {
        List<bool> list = new List<bool>();
        list.Add(true);
        list.Add(false);
        return list;
    }
    private List<bool> GetTakeovereds()
    {
        List<bool> list = new List<bool>();
        foreach (ListItem item in chkListTakeovered.Items)
        {
            if (item.Selected)
            {
                if (item.Value == "Y")
                {
                    list.Add(true);
                }
                else if (item.Value == "N")
                {
                    list.Add(false);
                }
            }
        }
        return list;
    }
    private List<bool> GetAllProperties()
    {
        List<bool> list = new List<bool>();
        list.Add(true);
        list.Add(false);
        return list;
    }
    private List<bool> GetProperties()
    {
        List<bool> list = new List<bool>();
        foreach (ListItem item in chkListProperty.Items)
        {
            if (item.Selected)
            {
                if (item.Value == "Y")
                {
                    list.Add(true);
                }
                else if (item.Value == "N")
                {
                    list.Add(false);
                }
            }
        }
        return list;
    }
    private List<bool> GetAllUsingLoggers()
    {
        List<bool> list = new List<bool>();
        list.Add(true);
        list.Add(false);
        return list;
    }
    private List<bool> GetUsingLoggers()
    {
        List<bool> list = new List<bool>();
        foreach (ListItem item in chkListUsingLogger.Items)
        {
            if (item.Selected)
            {
                if (item.Value == "Y")
                {
                    list.Add(true);
                }
                else if (item.Value == "N")
                {
                    list.Add(false);
                }
            }
        }
        return list;
    }
    private List<string> GetLoggerModels()
    {
        List<string> list = new List<string>();
        foreach (ListItem item in chkListLoggerModels.Items)
        {
            if (item.Selected)
            {
                list.Add(item.Value);
            }
        }
        return list;
    }
    private List<string> GetAllLoggerModels()
    {
        List<string> list = new List<string>();
        foreach (ListItem item in chkListLoggerModels.Items)
        {
            list.Add(item.Value);
        }
        list.Add(string.Empty);
        return list;
    }
    private List<string> GetAccreditationTypes()
    {
        List<string> list = new List<string>();
        foreach (ListItem item in chkListAccreditationTypes.Items)
        {
            if (item.Selected)
            {
                list.Add(item.Value);
            }
        }
        return list;
    }
    private List<string> GetAllAccreditationTypes()
    {
        List<string> list = new List<string>();
        foreach (ListItem item in chkListAccreditationTypes.Items)
        {
            list.Add(item.Value);
        }
        list.Add(string.Empty);
        return list;
    }
    private List<bool> GetAllApproved()
    {
        List<bool> list = new List<bool>();
        list.Add(true);
        list.Add(false);
        return list;
    }
    private List<bool> GetApproved()
    {
        List<bool> list = new List<bool>();
        foreach (ListItem item in chkListApproved.Items)
        {
            if (item.Selected)
            {
                if (item.Value == "Y")
                {
                    list.Add(true);
                }
                else if (item.Value == "N")
                {
                    list.Add(false);
                }
            }
        }
        return list;
    }
}