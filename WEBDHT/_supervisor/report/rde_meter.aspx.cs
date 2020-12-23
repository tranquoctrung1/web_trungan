using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

public partial class _supervisor_report_rde_meter : BasePage
{
    MetersBLL _metersBLL = new MetersBLL();
    protected void Page_Load(object sender, EventArgs e)
    {
        //win.VisibleOnPageLoad = false;
    }
    protected void btnView_Click(object sender, EventArgs e)
    {
       // win.VisibleOnPageLoad = true;
        List<string> listProviders = GetProviders();
        if (listProviders.Count == 0)
        {
            listProviders = GetAllProviders();
        }
        List<string> listMarks = GetMarks();
        if (listMarks.Count == 0)
        {
            listMarks = GetAllMarks();
        }
        List<string> listModels = GetModels();
        if (listModels.Count == 0)
        {
            listModels = GetAllModels();
        }
        List<short> listSizes = GetSizes();
        if (listSizes.Count == 0)
        {
            listSizes = GetAllSizes();
        }
        List<bool> listInstalleds = GetInstalleds();
        if (listInstalleds.Count == 0)
        {
            listInstalleds = GetAllInstalleds();
        }
        List<string> listStatus = GetStatus();
        if (listStatus.Count == 0)
        {
            listStatus = GetAllStatus();
        }
        List<string> listSiteStatus = GetSiteStatus();
        if (listSiteStatus.Count==0)
        {
            listSiteStatus = GetAllSiteStatus();
        }
        List<string> listSiteCompanies = GetSiteCompanies();
        if (listSiteCompanies.Count==0)
        {
            listSiteCompanies = GetAllSiteCompanies();
        }
        List<string> listNations = GetNations();
        if (listNations.Count==0)
        {
            listNations = GetAllNations();
        }
        List<MeterViewModel> list = _metersBLL.GetAllByConds(listProviders, listMarks, listModels, listSizes, listStatus, listInstalleds,listSiteStatus,listSiteCompanies, listNations);
        rpt.LocalReport.DataSources.Clear();
        rpt.LocalReport.DataSources.Add(new Microsoft.Reporting.WebForms.ReportDataSource("DataSet1", list));
        rpt.LocalReport.Refresh();
    }

    private List<string> GetAllNations()
    {
        List<string> list = new List<string>();
        foreach (ListItem item in chkListNation.Items)
        {
            list.Add(item.Value);
        }
return list;
        //throw new NotImplementedException();
    }

    private List<string> GetNations()
    {
        List<string> list = new List<string>();
        foreach (ListItem item in chkListNation.Items)
        {
            if (item.Selected)
            {
                list.Add(item.Value);
            }
            
        }
return list;
        //throw new NotImplementedException();
    }

    private List<string> GetAllProviders()
    {
        List<string> list = new List<string>();
        foreach (ListItem item in chkListProviders.Items)
        {
            list.Add(item.Value);
        }
        return list;
    }
    private List<string> GetProviders()
    {
        List<string> list = new List<string>();
        foreach (ListItem item in chkListProviders.Items)
        {
            if (item.Selected)
            {
                list.Add(item.Value);
            }
        }
        return list;
    }
    private List<string> GetAllMarks()
    {
        List<string> list = new List<string>();
        foreach (ListItem item in chkListMarks.Items)
        {
            list.Add(item.Value);
        }
        return list;
    }
    private List<string> GetMarks()
    {
        List<string> list = new List<string>();
        foreach (ListItem item in chkListMarks.Items)
        {
            if (item.Selected)
            {
                list.Add(item.Value);
            }
        }
        return list;
    }
    private List<string> GetAllModels()
    {
        List<string> list = new List<string>();
        foreach (ListItem item in chkListModels.Items)
        {
            list.Add(item.Value);
        }
        return list;
    }
    private List<string> GetModels()
    {
        List<string> list = new List<string>();
        foreach (ListItem item in chkListModels.Items)
        {
            if (item.Selected)
            {
                list.Add(item.Value);
            }
        }
        return list;
    }
    private List<short> GetAllSizes()
    {
        List<short> list = new List<short>();
        foreach (ListItem item in chkListSizes.Items)
        {
            list.Add(short.Parse(item.Value));
        }
        return list;
    }
    private List<short> GetSizes()
    {
        List<short> list = new List<short>();
        foreach (ListItem item in chkListSizes.Items)
        {
            if (item.Selected)
            {
                list.Add(short.Parse(item.Value));
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
    private List<bool> GetAllInstalleds()
    {
        List<bool> list = new List<bool>();
        list.Add(true);
        list.Add(false);
        return list;
    }
    private List<bool> GetInstalleds()
    {
        List<bool> list = new List<bool>();
        foreach (ListItem item in chkListInstalleds.Items)
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
    private List<string> GetAllSiteStatus()
    {
        List<string> list = new List<string>();
        foreach (ListItem item in chkListSiteStatus.Items)
        {
            list.Add(item.Value);
        }
        list.Add(string.Empty);
        return list;
    }
    private List<string> GetSiteStatus()
    {
        List<string> list = new List<string>();
        foreach (ListItem item in chkListSiteStatus.Items)
        {
            if (item.Selected)
            {
                list.Add(item.Value);
            }
        }
        return list;
    }
    private List<string> GetAllSiteCompanies()
    {
        List<string> list = new List<string>();
        foreach (ListItem item in chkListSiteCompanies.Items)
        {
            list.Add(item.Value);
        }
        list.Add(string.Empty);
        return list;
    }
    private List<string> GetSiteCompanies()
    {
        List<string> list = new List<string>();
        foreach (ListItem item in chkListSiteCompanies.Items)
        {
            if (item.Selected)
            {
                list.Add(item.Value); 
            }
        }
        return list;
    }
}