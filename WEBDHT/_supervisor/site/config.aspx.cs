using System;
using System.Collections.Generic;
using System.Globalization;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

public partial class _supervisor_site_config : BasePage
{
    private string _msgEmptySiteId = "Chưa nhập mã vị trí.";
    private string _msgEmptyLoggerId = "Chưa nhập số id logger.";
    private string _msgEmptyInterval = "Chưa nhập interval";
    private string _msgEmptyStartTime = "Chưa nhập giờ bắt đầu ngày";
    private string _msgSuccess = "Đã cập nhật thành công.";
    private string _msgError = "Lỗi, thử lại.";
    CultureInfo cultureInfo = new CultureInfo("en-GB");
    SiteConfigsBLL _siteConfigsBLL = new SiteConfigsBLL();
    ChannelConfigsBLL _channelConfigsBLL = new ChannelConfigsBLL();
    protected void Page_Load(object sender, EventArgs e)
    {
        ntf.VisibleOnPageLoad = false;
        if (!IsPostBack)
        {
            nmrInterval.Text = "15";
            tmStart.SelectedDate = DateTime.Parse(DateTime.Now.ToString("dd/MM/yyyy"), cultureInfo).AddHours(7);
            cboSiteIds.Focus();
        }
    }
    protected void cboSiteIds_SelectedIndexChanged(object sender, Telerik.Web.UI.RadComboBoxSelectedIndexChangedEventArgs e)
    {
        try
        {
            SetEmpty();
            SiteConfig siteConfig = _siteConfigsBLL.GetBySiteId(cboSiteIds.Text);
            if (siteConfig != null)
            {
                List<ChannelConfig> listChannelConfig = _channelConfigsBLL.GetByLoggerId(siteConfig.Id);
                if (listChannelConfig != null)
                {
                    SetChannelConfigControlValues(listChannelConfig);
                }
                SetSiteConfigControlValues(siteConfig);
            }
        }
        catch { }
    }

    private void SetEmpty()
    {
        nmrInterval.Value = 15;
        tmStart.SelectedDate = DateTime.Parse(DateTime.Now.ToString("dd/MM/yyyy"), cultureInfo).AddHours(7);
        txtChannelId1.Text = string.Empty;
        txtChannelId2.Text = string.Empty;
        txtChannelId3.Text = string.Empty;
        txtChannelId4.Text = string.Empty;
        txtChannelName1.Text = string.Empty;
        txtChannelName2.Text = string.Empty;
        txtChannelName3.Text = string.Empty;
        txtChannelName4.Text = string.Empty;
        rdoForwardFlow1.Checked = false;
        rdoForwardFlow2.Checked = false;
        rdoForwardFlow3.Checked = false;
        rdoForwardFlow4.Checked = false;
        rdoReverseFlow1.Checked = false;
        rdoReverseFlow2.Checked = false;
        rdoReverseFlow3.Checked = false;
        rdoReverseFlow4.Checked = false;
        rdoPress1.Checked = false;
        rdoPress2.Checked = false;
        rdoPress3.Checked = false;
        rdoPress4.Checked = false;
        rdoPress11.Checked = false;
        rdoPress12.Checked = false;
        rdoPress13.Checked = false;
        rdoPress14.Checked = false;
    }

    private void SetEmpty2()
    {
        nmrInterval.Value = 15;
        cboSiteIds.SelectedIndex = -1;
        cboSiteIds.Text = string.Empty;
        tmStart.SelectedDate = DateTime.Parse(DateTime.Now.ToString("dd/MM/yyyy"), cultureInfo).AddHours(7);
        cboSerials.Text = string.Empty;
        txtChannelId1.Text = string.Empty;
        txtChannelId2.Text = string.Empty;
        txtChannelId3.Text = string.Empty;
        txtChannelId4.Text = string.Empty;
        txtChannelName1.Text = string.Empty;
        txtChannelName2.Text = string.Empty;
        txtChannelName3.Text = string.Empty;
        txtChannelName4.Text = string.Empty;
        rdoForwardFlow1.Checked = false;
        rdoForwardFlow2.Checked = false;
        rdoForwardFlow3.Checked = false;
        rdoForwardFlow4.Checked = false;
        rdoReverseFlow1.Checked = false;
        rdoReverseFlow2.Checked = false;
        rdoReverseFlow3.Checked = false;
        rdoReverseFlow4.Checked = false;
        rdoPress1.Checked = false;
        rdoPress2.Checked = false;
        rdoPress3.Checked = false;
        rdoPress4.Checked = false;
        rdoPress11.Checked = false;
        rdoPress12.Checked = false;
        rdoPress13.Checked = false;
        rdoPress14.Checked = false;
    }

    protected void btnAdd_Click(object sender, EventArgs e)
    {
        ntf.VisibleOnPageLoad = true;
        if (string.IsNullOrEmpty(cboSiteIds.Text))
        {
            ntf.Text = _msgEmptySiteId;
            return;
        }
        if (string.IsNullOrEmpty(cboSerials.Text))
        {
            ntf.Text = _msgEmptyLoggerId;
            return;
        }
        if (nmrInterval.Value == null)
        {
            ntf.Text = _msgEmptyInterval;
            return;
        }
        if (tmStart.SelectedDate == null)
        {
            ntf.Text = _msgEmptyStartTime;
            return;
        }
        SiteConfig siteConfig = GetSiteConfigControlValues();
        List<ChannelConfig> listChannelConfigs = GetChannelConfigControlValues();
        SiteConfig dbSiteConfig = _siteConfigsBLL.GetBySiteId(cboSiteIds.Text);
        CommandStatus statusSite = new CommandStatus();
        CommandStatus[] statusChannels = new CommandStatus[4];
        if (dbSiteConfig == null)
        {
            statusSite = _siteConfigsBLL.Insert(siteConfig);
        }
        else
        {
            statusSite = _siteConfigsBLL.Update(siteConfig);
        }
        int i = 0;
        foreach (var channelConfig in listChannelConfigs)
        {
            ChannelConfig dbChannelConfig = _channelConfigsBLL.Get(channelConfig.Id);
            if (dbChannelConfig == null)
            {
                statusChannels[i] = _channelConfigsBLL.Insert(channelConfig);
            }
            else
            {
                statusChannels[i] = _channelConfigsBLL.Update(channelConfig);
            }
            i++;
        }
        if (!statusSite.Error)
        {
            ntf.Text = _msgSuccess;
            SitesDataSource.DataBind();
            cboSiteIds.DataBind();
        }
        else
        {
            ntf.Text = _msgError;
        }
    }
    private void SetSiteConfigControlValues(SiteConfig siteConfig)
    {
        cboSerials.Text = siteConfig.Id;
        nmrInterval.Value = siteConfig.Interval;
        tmStart.SelectedDate = siteConfig.BeginTime;

        string _c1 = "";
        string _c2 = "";
        string _c3 = "";
        string _c4 = "";
        if (!string.IsNullOrEmpty(txtChannelId1.Text))
            _c1 = txtChannelId1.Text.Split('_')[1];
        
        if (!string.IsNullOrEmpty(txtChannelId2.Text))
            _c2 = txtChannelId2.Text.Split('_')[1];
        if (!string.IsNullOrEmpty(txtChannelId3.Text))
            _c3 = txtChannelId3.Text.Split('_')[1];
        if (!string.IsNullOrEmpty(txtChannelId4.Text))
            _c4 = txtChannelId4.Text.Split('_')[1];

        RadioButton rdoForward = null;
        RadioButton rdoReverse = null;
        RadioButton rdoPress = null;
        RadioButton rdoPress1 = null;


        ContentPlaceHolder cph = (ContentPlaceHolder)this.Master.FindControl("ContentPlaceHolder1");

        //rdoForward = (RadioButton)RadAjaxPanel1.FindControl("rdoForwardFlow2");

        if ("0" + siteConfig.Forward.ToString() == _c1)
            rdoForward = (RadioButton)cph.FindControl("rdoForwardFlow1");
        if ("0" + siteConfig.Forward.ToString() == _c2)
            rdoForward = (RadioButton)cph.FindControl("rdoForwardFlow2");
        if ("0" + siteConfig.Forward.ToString() == _c3)
            rdoForward = (RadioButton)cph.FindControl("rdoForwardFlow3");
        if ("0" + siteConfig.Forward.ToString() == _c4)
            rdoForward = (RadioButton)cph.FindControl("rdoForwardFlow4");

        //rdoReverse = (RadioButton)RadAjaxPanel1.FindControl("rdoReverseFlow1");

        if ("0" + siteConfig.Reverse.ToString() == _c1)
            rdoReverse = (RadioButton)cph.FindControl("rdoReverseFlow1");
        if ("0" + siteConfig.Reverse.ToString() == _c2)
            rdoReverse = (RadioButton)cph.FindControl("rdoReverseFlow2");
        if ("0" + siteConfig.Reverse.ToString() == _c3)
            rdoReverse = (RadioButton)cph.FindControl("rdoReverseFlow3");
        if ("0" + siteConfig.Reverse.ToString() == _c4)
            rdoReverse = (RadioButton)cph.FindControl("rdoReverseFlow4");

        //rdoPress = (RadioButton)RadAjaxPanel1.FindControl("rdoPress1");

        if ("0" + siteConfig.Pressure.ToString() == _c1)
            rdoPress = (RadioButton)cph.FindControl("rdoPress1");
        if ("0" + siteConfig.Pressure.ToString() == _c2)
            rdoPress = (RadioButton)cph.FindControl("rdoPress2");
        if ("0" + siteConfig.Pressure.ToString() == _c3)
            rdoPress = (RadioButton)cph.FindControl("rdoPress3");
        if ("0" + siteConfig.Pressure.ToString() == _c4)
            rdoPress = (RadioButton)cph.FindControl("rdoPress4");

        //rdoPress1 = (RadioButton)RadAjaxPanel1.FindControl("rdoPress11");

        if ("0" + siteConfig.Pressure1.ToString() == _c1)
            rdoPress1 = (RadioButton)cph.FindControl("rdoPress11");
        if ("0" + siteConfig.Pressure1.ToString() == _c2)
            rdoPress1 = (RadioButton)cph.FindControl("rdoPress12");
        if ("0" + siteConfig.Pressure1.ToString() == _c3)
            rdoPress1 = (RadioButton)cph.FindControl("rdoPress13");
        if ("0" + siteConfig.Pressure1.ToString() == _c4)
            rdoPress1 = (RadioButton)cph.FindControl("rdoPress14");

        if (rdoForward != null)
        {
            rdoForward.Checked = true;
        }
        if (rdoReverse != null)
        {
            rdoReverse.Checked = true;
        }
        if (rdoPress != null)
        {
            rdoPress.Checked = true;
        }
        if (rdoPress1 != null)
        {
            rdoPress1.Checked = true;
        }
    }
    private void SetChannelConfigControlValues(List<ChannelConfig> channelConfigs)
    {
        ContentPlaceHolder cph = (ContentPlaceHolder)this.Master.FindControl("ContentPlaceHolder1");

        for (int i = 0; i < channelConfigs.Count; i++)
        {
            Telerik.Web.UI.RadTextBox txtChannelId = (Telerik.Web.UI.RadTextBox)cph.FindControl("txtChannelId" + (i + 1).ToString());
            Telerik.Web.UI.RadTextBox txtChannelName = (Telerik.Web.UI.RadTextBox)cph.FindControl("txtChannelName" + (i + 1).ToString());
            Telerik.Web.UI.RadComboBox cboUnit = (Telerik.Web.UI.RadComboBox)cph.FindControl("cboUnit" + (i + 1).ToString());
            if (txtChannelId != null)
            {
                txtChannelId.Text = channelConfigs[i].Id;
            }
            if (txtChannelName != null)
            {
                txtChannelName.Text = channelConfigs[i].Name;
            }
            if (cboUnit != null)
            {
                cboUnit.Text = channelConfigs[i].Unit;
            }
        }
    }
    private SiteConfig GetSiteConfigControlValues()
    {
        byte? _f;
        byte? _r;
        byte? _p;
        byte? _p1;
        _f = rdoForwardFlow1.Checked ? 1 : rdoForwardFlow2.Checked ? 2 : rdoForwardFlow3.Checked ? 3 : rdoForwardFlow4.Checked ? 4 : default(byte?);
        _r = rdoReverseFlow1.Checked ? 1 : rdoReverseFlow2.Checked ? 2 : rdoReverseFlow3.Checked ? 3 : rdoReverseFlow4.Checked ? 4 : default(byte?); ;
        _p = rdoPress1.Checked ? 1 : rdoPress2.Checked ? 2 : rdoPress3.Checked ? 3 : rdoPress4.Checked ? 4 : default(byte?);
        _p1 = rdoPress11.Checked ? 1 : rdoPress12.Checked ? 2 : rdoPress13.Checked ? 3 : rdoPress14.Checked ? 4 : default(byte?);
        string _c1 = "";
        string _c2 = "";
        string _c3 = "";
        string _c4 = "";
        if (!string.IsNullOrEmpty(txtChannelId1.Text))
            _c1 = txtChannelId1.Text.Split('_')[1];
        if (!string.IsNullOrEmpty(txtChannelId2.Text))
            _c2 = txtChannelId2.Text.Split('_')[1];
        if (!string.IsNullOrEmpty(txtChannelId3.Text))
            _c3 = txtChannelId3.Text.Split('_')[1];
        if (!string.IsNullOrEmpty(txtChannelId4.Text))
            _c4 = txtChannelId4.Text.Split('_')[1];
        SiteConfig siteConfig = new SiteConfig();
        siteConfig.BeginTime = tmStart.SelectedDate;
        switch (_f)
        {
            case 1:
                if (!string.IsNullOrEmpty(_c1))
                    siteConfig.Forward = byte.Parse(_c1);
                break;
            case 2:
                if (!string.IsNullOrEmpty(_c2))
                    siteConfig.Forward = byte.Parse(_c2);
                break;
            case 3:
                if (!string.IsNullOrEmpty(_c3))
                    siteConfig.Forward = byte.Parse(_c3);
                break;
            case 4:
                if (!string.IsNullOrEmpty(_c4))
                    siteConfig.Forward = byte.Parse(_c4);
                break;
            default:
                break;
        }
        switch (_r)
        {
            case 1:
                if (!string.IsNullOrEmpty(_c1))
                    siteConfig.Reverse = byte.Parse(_c1);
                break;
            case 2:
                if (!string.IsNullOrEmpty(_c2))
                    siteConfig.Reverse = byte.Parse(_c2);
                break;
            case 3:
                if (!string.IsNullOrEmpty(_c3))
                    siteConfig.Reverse = byte.Parse(_c3);
                break;
            case 4:
                if (!string.IsNullOrEmpty(_c4))
                    siteConfig.Reverse = byte.Parse(_c4);
                break;
            default:
                break;
        }
        switch (_p)
        {
            case 1:
                if (!string.IsNullOrEmpty(_c1))
                    siteConfig.Pressure = byte.Parse(_c1);
                break;
            case 2:
                if (!string.IsNullOrEmpty(_c2))
                    siteConfig.Pressure = byte.Parse(_c2);
                break;
            case 3:
                if (!string.IsNullOrEmpty(_c3))
                    siteConfig.Pressure = byte.Parse(_c3);
                break;
            case 4:
                if (!string.IsNullOrEmpty(_c4))
                    siteConfig.Pressure = byte.Parse(_c4);
                break;
            default:
                break;
        }
        switch (_p1)
        {
            case 1:
                if (!string.IsNullOrEmpty(_c1))
                    siteConfig.Pressure1 = byte.Parse(_c1);
                break;
            case 2:
                if (!string.IsNullOrEmpty(_c2))
                    siteConfig.Pressure1 = byte.Parse(_c2);
                break;
            case 3:
                if (!string.IsNullOrEmpty(_c3))
                    siteConfig.Pressure1 = byte.Parse(_c3);
                break;
            case 4:
                if (!string.IsNullOrEmpty(_c4))
                    siteConfig.Pressure1 = byte.Parse(_c4);
                break;
            default:
                break;
        }

        //siteConfig.Forward = rdoForwardFlow1.Checked ? 1 : rdoForwardFlow2.Checked ? 2 : rdoForwardFlow3.Checked ? 3 : rdoForwardFlow4.Checked? 4 : default(byte?);
        //siteConfig.Reverse = rdoReverseFlow1.Checked ? 1 : rdoReverseFlow2.Checked ? 2 : rdoReverseFlow3.Checked ? 3 : rdoReverseFlow4.Checked? 4 : default(byte?);
        //siteConfig.Pressure = rdoPress1.Checked ? 1 : rdoPress2.Checked ? 2 : rdoPress3.Checked ? 3 : rdoPress4.Checked ? 4 : default(byte?);
        //siteConfig.Pressure1 = rdoPress11.Checked ? 1 : rdoPress12.Checked ? 2 : rdoPress13.Checked ? 3 : rdoPress14.Checked ? 4 : default(byte?);
        siteConfig.Id = cboSerials.Text;
        siteConfig.Interval = (short?)nmrInterval.Value;
        siteConfig.SiteId = cboSiteIds.Text;
        return siteConfig;
    }
    private List<ChannelConfig> GetChannelConfigControlValues()
    {
        List<ChannelConfig> channelConfigs = new List<ChannelConfig>();
        if (!string.IsNullOrEmpty(txtChannelId1.Text) && txtChannelId1.Text.Split('_')[0] == cboSerials.Text)
        {
            ChannelConfig config1 = new ChannelConfig();
            config1.Id = txtChannelId1.Text;
            config1.Name = txtChannelName1.Text;
            config1.Unit = cboUnit1.Text;
            config1.LoggerId = cboSerials.Text;
            channelConfigs.Add(config1);
        }
        if (!string.IsNullOrEmpty(txtChannelId2.Text) && txtChannelId2.Text.Split('_')[0] == cboSerials.Text)
        {
            ChannelConfig config2 = new ChannelConfig();
            config2.Id = txtChannelId2.Text;
            config2.Name = txtChannelName2.Text;
            config2.Unit = cboUnit2.Text;
            config2.LoggerId = cboSerials.Text;
            channelConfigs.Add(config2);
        }
        if (!string.IsNullOrEmpty(txtChannelId3.Text) && txtChannelId3.Text.Split('_')[0] == cboSerials.Text)
        {
            ChannelConfig config3 = new ChannelConfig();
            config3.Id = txtChannelId3.Text;
            config3.Name = txtChannelName3.Text;
            config3.Unit = cboUnit3.Text;
            config3.LoggerId = cboSerials.Text;
            channelConfigs.Add(config3);
        }
        if (!string.IsNullOrEmpty(txtChannelId4.Text) && txtChannelId4.Text.Split('_')[0] == cboSerials.Text)
        {
            ChannelConfig config4 = new ChannelConfig();
            config4.Id = txtChannelId4.Text;
            config4.Name = txtChannelName4.Text;
            config4.Unit = cboUnit4.Text;
            config4.LoggerId = cboSerials.Text;
            channelConfigs.Add(config4);
        }
        return channelConfigs;
    }

    protected void btnDelete_Click(object sender, EventArgs e)
    {
        ntf.VisibleOnPageLoad = true;
        var listChannelConfigs = GetChannelConfigControlValues();
        var siteConfig = _siteConfigsBLL.GetBySiteId(cboSiteIds.Text);
        try
        {
            foreach (var item in listChannelConfigs)
            {
                _channelConfigsBLL.Delete(item);
            }
            _siteConfigsBLL.Delete(siteConfig);
            ntf.Text = "Đã xóa cấu hình.";
            SetEmpty2();
            SitesDataSource.DataBind();
            cboSiteIds.DataBind();
        }
        catch (Exception ex)
        {
            ntf.Text = "Lỗi: " + ex.Message;
        }
    }
}