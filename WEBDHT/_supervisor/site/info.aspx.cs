using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

public partial class _supervisor_site_info : BasePage
{
    private string _urlDownload = "~/_supervisor/file/site.aspx?id=";
    private string _msgSiteDoNotExist = "Không tồn tại điểm lắp đặt.";
    private string _msgEmptyId = "Chưa nhập mã vị trí.";
    private string _msgInserted = "Đã thêm điểm lắp đặt.";
    private string _msgUpdated = "Đã cập nhật điểm lắp đặt.";
    private string _msgDeleted = "Đã xóa điểm lắp đặt.";
    private string _msgError = "Lỗi :";
    private string _msgUploaded = "Đã tải lên file điểm lắp đặt.";
    SitesBLL _sitesBLL = new SitesBLL();
    FilesUTL _filesUTL = new FilesUTL();
    MetersBLL _metersBLL = new MetersBLL();
    StringUTL _stringUTL = new StringUTL();
    SiteFilesBLL _siteFilesBLL = new SiteFilesBLL();
    SiteHistoriesBLL _siteHistoriesBLL = new SiteHistoriesBLL();
    SiteCoversBLL _siteCoversBLL = new SiteCoversBLL();

    protected void Page_Load(object sender, EventArgs e)
    {
        ntf.VisibleOnPageLoad = false;
        if (!IsPostBack)
        {
            cboIds.Focus();
        }
    }
    protected void cboIds_SelectedIndexChanged(object sender, Telerik.Web.UI.RadComboBoxSelectedIndexChangedEventArgs e)
    {
        string siteId = cboIds.Text;
        cboIds.Focus();
        var dbSite = _sitesBLL.GetById(cboIds.Text);
        if (dbSite != null)
        {
            SetAllControlValues(cboIds.Text);
        }
        else
        {
            SetDefaultControlValues();
            cboOldIds.Focus();
            cboIds.Text = siteId;
        }
    }

    private void SetDefaultControlValues()
    {
        cboOldIds.Text = string.Empty;
        txtLocation.Text = string.Empty;
        nmrLogitude.Value = null;
        nmrLatitude.Value = null;
        //cboViewGroups.Text = string.Empty;
        //cboStaffs.Text = string.Empty;
        cboMeters.Text = string.Empty;
        cboTransmitters.Text = string.Empty;
        cboLoggers.Text = string.Empty;
        txtAccreditationDocument.Text = string.Empty;
        cboAccreditationTypes.Text = string.Empty;
        dtmAccredited.SelectedDate = null;
        dtmExpiry.SelectedDate = null;
        dtmMeterChanged.SelectedDate = null;
        dtmTransmitterChanged.SelectedDate = null;
        dtmLoggerChanged.SelectedDate = null;
        //dtmBatteryChanged.SelectedDate = null;
        dtmLoggerBatteryChanged.SelectedDate = null;
        dtmTransmitterBatteryChanged.SelectedDate = null;
       // nmrIndex.Value = null;
        //nmrIndex1.Value = null;
        txtChangeDescription.Text = null;
        //cboLevels.Text = string.Empty;
        //boGroups.Text = string.Empty;
        //cboGroup2s.Text = string.Empty;
        //cboGroup3s.Text = string.Empty;
        //cboGroup4s.Text = string.Empty;
        //cboGroup5s.Text = string.Empty;
        cboCompanies.Text = string.Empty;
        //dtmTakeovered.SelectedDate = null;
        //chkTakeovered.Checked = false;
        cboStatus.Text = string.Empty;
        cboAvailabilities.Text = string.Empty;
        //chkDisplay.Checked = false;
        //chkProperty.Checked = false;
        //chkUsingLogger.Checked = false;
        //cboMeterDirections.Text = string.Empty;
        //cboProductionCompanies.Text = string.Empty;
        //cboQndDistributionCompanies.Text = string.Empty;
        //cboIstDistributionCompanies.Text = string.Empty;
        //txtDescription.Text = string.Empty;
        txtAddress.Text = string.Empty;
        //cboCoverIDs.Text = string.Empty;
        //txtCoverW.Text = string.Empty;
        //txtCoverL.Text = string.Empty;
        //txtCoverH.Text = string.Empty;
        //txtCoverMaterial.Text = string.Empty;
        //txtCoverNL.Text = string.Empty;
        cboDistricts.Text = string.Empty;
        cboCompaniesOut.Text = string.Empty;

    }

    protected void btnAdd_Click(object sender, EventArgs e)
    {
        ntf.VisibleOnPageLoad = true;
        if (string.IsNullOrEmpty(cboIds.Text))
        {
            ntf.Text = _msgEmptyId;
            return;
        }
        var dbSite = _sitesBLL.GetById(cboIds.Text);
        var site = GetSiteControlValues();
        CommandStatus status = new CommandStatus();
        if (dbSite == null)
        {
            status = _sitesBLL.Insert(site);
            cboIds.DataBind();
            IdsDataSource.DataBind();
        }
        else
        {
            status = _sitesBLL.Update(site);
            cboIds.DataBind();
            IdsDataSource.DataBind();
        }
        if (status.Inserted)
        {
            ntf.Text = _msgInserted;
        }
        else if (status.Updated)
        {
            ntf.Text = _msgUpdated;
        }
        else
        {
            ntf.Text = _msgError + status.ErrorMessage;
        }
    }
    protected void btnConfim_Click(object sender, EventArgs e)
    {
        ntf.VisibleOnPageLoad = true;
        if (string.IsNullOrEmpty(cboIds.Text))
        {
            ntf.Text = _msgEmptyId;
            return;
        }
        var dbSite = _sitesBLL.GetById(cboIds.Text);
        CommandStatus status = new CommandStatus();
        if (dbSite != null)
        {
            status = _sitesBLL.Delete(cboIds.Text);

        }
        if (status.Deleted)
        {
            ntf.Text = _msgDeleted;
            cboIds.DataBind();
            IdsDataSource.DataBind();
            SetMeterControlValues(new Meter());
            SetSiteControlValues(new Site());
        }
        else if (status.Error)
        {
            ntf.Text = _msgError + status.ErrorMessage;
        }
        else
        {
            ntf.Text = _msgSiteDoNotExist;
        }
    }
    protected void btnUpload_Click(object sender, EventArgs e)
    {

    }
    private Site GetSiteControlValues()
    {
        Site site = new Site();
        site.Availability = cboAvailabilities.Text;
        //site.ChangeIndex = nmrIndex.Value;
        site.Company = cboCompanies.Text;
        //site.DateOfBatteryChange = dtmBatteryChanged.SelectedDate;
        site.DateOfLoggerBatteryChange = dtmLoggerBatteryChanged.SelectedDate;
        site.DateOfLoggerChange = dtmLoggerChanged.SelectedDate;
        site.DateOfMeterChange = dtmMeterChanged.SelectedDate;
        site.DateOfTransmitterBatteryChange = dtmTransmitterBatteryChanged.SelectedDate;
        site.DateOfTransmitterChange = dtmTransmitterChanged.SelectedDate;
        //site.Description = txtDescription.Text;
        site.DescriptionOfChange = txtChangeDescription.Text;
        //site.Display = chkDisplay.Checked;
        //site.Group = cboGroups.Text;
        site.Id = cboIds.Text;
        //site.IstDistributionCompany = cboIstDistributionCompanies.Text;
        //site.IstDoNotCalculateReverse = chkIstDoNotCalculateReverse.Checked;
        site.Latitude = nmrLatitude.Value;
        //site.Level = cboLevels.Text;
        site.Location = txtLocation.Text;
        site.Logger = cboLoggers.Text ;
        site.Longitude = nmrLogitude.Value;
        site.Meter = cboMeters.Text;
        //site.MeterDirection = cboMeterDirections.Text;
        site.OldId = cboOldIds.Text;
        //site.ProductionCompany = cboProductionCompanies.Text;
        //site.Property = chkProperty.Checked;
        //site.QndDistributionCompany = cboQndDistributionCompanies.Text;
        //site.QndDoNotCalculateReverse = chkQndDoNotCalculateReverse.Checked;
        //site.StaffId = cboStaffs.Text;
        site.StaffId = "";
        site.Status = cboStatus.Text;
        //site.TakeoverDate = dtmTakeovered.SelectedDate;
        //site.Takeovered = chkTakeovered.Checked;
        site.Transmitter = cboTransmitters.Text;
        //site.UsingLogger = chkUsingLogger.Checked;
       // site.ViewGroup = cboViewGroups.Text;
        //site.ChangeIndex1 = nmrIndex1.Value;
        //site.Group2 = cboGroup2s.Text;
        //site.Group3 = cboGroup3s.Text;
        //site.Group4 = cboGroup4s.Text;
        //site.Group5 = cboGroup5s.Text;
        site.Address = txtAddress.Text;
        //site.CoverID = cboCoverIDs.Text;
        site.District = cboDistricts.Text;
        site.DMAOut = cboCompaniesOut.Text;
        return site;
    }
    private void SetSiteControlValues(Site site)
    {
        cboAvailabilities.Text = site.Availability;
        cboAvailabilities.SelectedIndex = -1;
        //nmrIndex.Value = site.ChangeIndex;
        cboCompanies.Text = site.Company;
        cboCompanies.SelectedIndex = -1;
        //dtmBatteryChanged.SelectedDate = site.DateOfBatteryChange;
        dtmLoggerBatteryChanged.SelectedDate = site.DateOfLoggerBatteryChange;
        dtmLoggerChanged.SelectedDate = site.DateOfLoggerChange;
        dtmMeterChanged.SelectedDate = site.DateOfMeterChange;
        dtmTransmitterBatteryChanged.SelectedDate = site.DateOfTransmitterBatteryChange;
        dtmTransmitterChanged.SelectedDate = site.DateOfTransmitterChange;
       // txtDescription.Text = site.Description;
        txtChangeDescription.Text = site.DescriptionOfChange;
       // chkDisplay.Checked = site.Display ?? false;
       // cboGroups.SelectedIndex = -1;
       // cboGroups.Text = site.Group;
        cboIds.SelectedIndex = -1;
        cboIds.Text = site.Id;
       //cboIstDistributionCompanies.SelectedIndex = -1;
       // cboIstDistributionCompanies.Text = site.IstDistributionCompany;
        //chkIstDoNotCalculateReverse.Checked = site.IstDoNotCalculateReverse ?? false;
        nmrLatitude.Value = site.Latitude;
       // cboLevels.SelectedIndex = -1;
       // cboLevels.Text = site.Level;
        txtLocation.Text = site.Location;
        cboLoggers.SelectedIndex = -1;
        cboLoggers.Text = site.Logger;
        nmrLogitude.Value = site.Longitude;
        cboMeters.SelectedIndex = -1;
        cboMeters.Text = site.Meter;
        //cboMeterDirections.SelectedIndex = -1;
        //cboMeterDirections.Text = site.MeterDirection;
        cboOldIds.SelectedIndex = -1;
        cboOldIds.Text = site.OldId;
       // cboProductionCompanies.SelectedIndex = -1;
        //cboProductionCompanies.Text = site.ProductionCompany;
        //chkProperty.Checked = site.Property ?? false;
        //cboIstDistributionCompanies.SelectedIndex = -1;
        //cboIstDistributionCompanies.Text = site.IstDistributionCompany;
        //cboQndDistributionCompanies.SelectedIndex = -1;
        //cboQndDistributionCompanies.Text = site.QndDistributionCompany;
        //chkQndDoNotCalculateReverse.Checked = site.QndDoNotCalculateReverse ?? false;
        //cboStaffs.SelectedIndex = -1;
        //cboStaffs.Text = site.StaffId;
        cboStatus.SelectedIndex = -1;
        cboStatus.Text = site.Status;
        //dtmTakeovered.SelectedDate = site.TakeoverDate;
        //chkTakeovered.Checked = site.Takeovered ?? false;
        cboTransmitters.SelectedIndex = -1;
        cboTransmitters.Text = site.Transmitter;
       // chkUsingLogger.Checked = site.UsingLogger ?? false;
        //cboViewGroups.SelectedIndex = -1;
        //cboViewGroups.Text = site.ViewGroup;
        //nmrIndex1.Value = site.ChangeIndex1;
        //cboGroup2s.SelectedIndex = -1;
        //cboGroup2s.Text = site.Group2;
        //cboGroup3s.SelectedIndex = -1;
        //cboGroup3s.Text = site.Group3;
        //cboGroup4s.SelectedIndex = -1;
        //cboGroup4s.Text = site.Group4;
        //cboGroup5s.SelectedIndex = -1;
        //cboGroup5s.Text = site.Group5;
        txtAddress.Text = site.Address;


        //cboCoverIDs.SelectedIndex = -1;
        //cboCoverIDs.Text = string.Empty;
        //txtCoverW.Text = string.Empty;
        //txtCoverL.Text = string.Empty;
        //txtCoverH.Text = string.Empty;
        //txtCoverMaterial.Text = string.Empty;
        //txtCoverNL.Text = string.Empty;
        var cover = _siteCoversBLL.GetCoverByID(site.CoverID);
        if (cover != null)
        {
            SetCoverControlValues(cover);
        }
        cboDistricts.SelectedIndex = -1;

        cboDistricts.Text = site.District;
        cboCompaniesOut.Text = site.DMAOut;
    }
    private void SetMeterControlValues(Meter meter)
    {
        txtAccreditationDocument.Text = meter.AccreditationDocument;
        cboAccreditationTypes.SelectedIndex = -1;
        cboAccreditationTypes.Text = meter.AccreditationType;
        dtmAccredited.SelectedDate = meter.AccreditedDate;
        dtmExpiry.SelectedDate = meter.ExpiryDate;
    }
    private void SetAllControlValues(string siteId)
    {
        var site = _sitesBLL.GetById(siteId);
        if (site != null)
        {
            SetSiteControlValues(site);

            var meter = _metersBLL.GetBySerial(site.Meter);
            if (meter != null)
            {
                SetMeterControlValues(meter);
            }
        }
    }

    protected void asynUpload_FileUploaded(object sender, Telerik.Web.UI.FileUploadedEventArgs e)
    {
        ntf.VisibleOnPageLoad = true;
        if (string.IsNullOrEmpty(cboIds.Text))
        {
            ntf.Text = _msgEmptyId;
            return;
        }
        string targetFolder = asynUpload.TargetFolder;
        string newName = "_" + cboIds.Text + "_" + _stringUTL.RemoveSign4VietnameseString(e.File.GetName());
        e.File.SaveAs(System.IO.Path.Combine(Server.MapPath(targetFolder), newName));
        CommandStatus status = new CommandStatus();
        SiteFile dbFile = _siteFilesBLL.GetByFileName(newName);
        SiteFile file = new SiteFile();
        file.FileName = newName;
        file.MIMEType = e.File.ContentType;
        file.Path = System.IO.Path.Combine(Server.MapPath(targetFolder), file.FileName);
        file.SiteId = cboIds.Text;
        file.Size = (int)e.File.ContentLength;
        file.UploadDate = DateTime.Now;
        if (dbFile != null)
        {
            status = _siteFilesBLL.Update(file);
        }
        else
        {
            status = _siteFilesBLL.Insert(file);
        }
        if (status.Updated || status.Inserted)
        {
            ntf.Text = _msgUploaded;
        }
        else if (status.Error)
        {
            ntf.Text = _msgError + status.ErrorMessage;
        }
    }
    private void UpdateHistory(Site site)
    {
        CommandStatus statusHistoryBatteryChanged = new CommandStatus();
        CommandStatus statusHistoryLoggerChanged = new CommandStatus();
        CommandStatus statusHistoryTransmitterChanged = new CommandStatus();
        CommandStatus statusHistoryMeterChanged = new CommandStatus();
        CommandStatus statusHistoryLoggerBatteryChanged = new CommandStatus();
        CommandStatus statusHistoryTransmitterBatteryChanged = new CommandStatus();
        if (site.DateOfBatteryChange != null)
        {
            SiteHistory dbHistory = _siteHistoriesBLL.GetAllBySiteIdAndDate(site.Id, (DateTime)site.DateOfBatteryChange);
            if (dbHistory != null)
            {
                dbHistory.Battery = true;
                dbHistory.Index = site.ChangeIndex;
                if (!dbHistory.Description.Contains(site.DescriptionOfChange))
                {
                    dbHistory.Description += "; " + site.DescriptionOfChange;
                }
                statusHistoryBatteryChanged = _siteHistoriesBLL.InsertOrUpdate(dbHistory);
            }
            else
            {
                SiteHistory history = new SiteHistory();
                history.SiteId = site.Id;
                history.Battery = true;
                history.Description = txtChangeDescription.Text;
                history.Index = site.ChangeIndex;
                history.Date = (DateTime)site.DateOfBatteryChange;
                statusHistoryBatteryChanged = _siteHistoriesBLL.InsertOrUpdate(history);
            }
        }
        if (site.DateOfLoggerBatteryChange != null)
        {
            SiteHistory dbHistory = _siteHistoriesBLL.GetAllBySiteIdAndDate(site.Id, (DateTime)site.DateOfLoggerBatteryChange);
            if (dbHistory != null)
            {
                dbHistory.LoggerBattery = true;
                dbHistory.Index = site.ChangeIndex;
                if (!dbHistory.Description.Contains(site.DescriptionOfChange))
                {
                    dbHistory.Description += "; " + site.DescriptionOfChange;
                }
                statusHistoryLoggerBatteryChanged = _siteHistoriesBLL.InsertOrUpdate(dbHistory);
            }
            else
            {
                SiteHistory history = new SiteHistory();
                history.SiteId = site.Id;
                history.LoggerBattery = true;
                history.Description = txtChangeDescription.Text;
                history.Index = site.ChangeIndex;
                history.Date = (DateTime)site.DateOfLoggerBatteryChange;
                statusHistoryLoggerBatteryChanged = _siteHistoriesBLL.InsertOrUpdate(history);
            }
        }
        if (site.DateOfLoggerChange != null)
        {
            SiteHistory dbHistory = _siteHistoriesBLL.GetAllBySiteIdAndDate(site.Id, (DateTime)site.DateOfLoggerChange);
            if (dbHistory != null)
            {
                dbHistory.LoggerBattery = true;
                dbHistory.Index = site.ChangeIndex;
                if (!dbHistory.Description.Contains(site.DescriptionOfChange))
                {
                    dbHistory.Description += "; " + site.DescriptionOfChange;
                }
                statusHistoryLoggerChanged = _siteHistoriesBLL.InsertOrUpdate(dbHistory);
            }
            else
            {
                SiteHistory history = new SiteHistory();
                history.SiteId = site.Id;
                history.Logger = true;
                history.Description = txtChangeDescription.Text;
                history.Index = site.ChangeIndex;
                history.Date = (DateTime)site.DateOfLoggerChange;
                statusHistoryLoggerChanged = _siteHistoriesBLL.InsertOrUpdate(history);
            }
        }
        if (site.DateOfMeterChange != null)
        {
            SiteHistory dbHistory = _siteHistoriesBLL.GetAllBySiteIdAndDate(site.Id, (DateTime)site.DateOfMeterChange);
            if (dbHistory != null)
            {
                dbHistory.Meter = true;
                dbHistory.Index = site.ChangeIndex;
                if (!dbHistory.Description.Contains(site.DescriptionOfChange))
                    dbHistory.Description += "; " + site.DescriptionOfChange;
                statusHistoryMeterChanged = _siteHistoriesBLL.InsertOrUpdate(dbHistory);
            }
            else
            {
                SiteHistory history = new SiteHistory();
                history.SiteId = site.Id;
                history.Meter = true;
                history.Description = txtChangeDescription.Text;
                history.Index = site.ChangeIndex;
                history.Date = (DateTime)site.DateOfMeterChange;
                statusHistoryMeterChanged = _siteHistoriesBLL.InsertOrUpdate(history);
            }
        }
        if (site.DateOfTransmitterBatteryChange != null)
        {
            SiteHistory dbHistory = _siteHistoriesBLL.GetAllBySiteIdAndDate(site.Id, (DateTime)site.DateOfTransmitterBatteryChange);
            if (dbHistory != null)
            {
                dbHistory.TransmitterBattery = true;
                dbHistory.Index = site.ChangeIndex;
                if (!dbHistory.Description.Contains(site.DescriptionOfChange))
                {
                    dbHistory.Description += "; " + site.DescriptionOfChange;
                }
                statusHistoryTransmitterBatteryChanged = _siteHistoriesBLL.InsertOrUpdate(dbHistory);
            }
            else
            {
                SiteHistory history = new SiteHistory();
                history.SiteId = site.Id;
                history.TransmitterBattery = true;
                history.Description = txtChangeDescription.Text;
                history.Index = site.ChangeIndex;
                history.Date = (DateTime)site.DateOfTransmitterBatteryChange;
                statusHistoryTransmitterBatteryChanged = _siteHistoriesBLL.InsertOrUpdate(history);
            }
        }
        if (site.DateOfTransmitterChange != null)
        {
            SiteHistory dbHistory = _siteHistoriesBLL.GetAllBySiteIdAndDate(site.Id, (DateTime)site.DateOfTransmitterChange);
            if (dbHistory != null)
            {
                dbHistory.Transmitter = true;
                dbHistory.Index = site.ChangeIndex;
                if (!dbHistory.Description.Contains(site.DescriptionOfChange))
                {
                    dbHistory.Description += "; " + site.DescriptionOfChange;
                }
                statusHistoryBatteryChanged = _siteHistoriesBLL.InsertOrUpdate(dbHistory);
            }
            else
            {
                SiteHistory history = new SiteHistory();
                history.SiteId = site.Id;
                history.Transmitter = true;
                history.Description = txtChangeDescription.Text;
                history.Index = site.ChangeIndex;
                history.Date = (DateTime)site.DateOfTransmitterChange;
                statusHistoryTransmitterChanged = _siteHistoriesBLL.InsertOrUpdate(history);
            }
        }
    }
    protected void btnDownload_Click(object sender, EventArgs e)
    {
        Response.Redirect(_urlDownload + cboIds.Text);
    }

    protected void cboCoverIDs_SelectedIndexChanged(object sender, Telerik.Web.UI.RadComboBoxSelectedIndexChangedEventArgs e)
    {
        //var cover = _siteCoversBLL.GetCoverByID(cboCoverIDs.Text);
        //if (cover != null)
        //{
        //    SetCoverControlValues(cover);
        //}
        //else
        //{
        //    txtCoverW.Text = string.Empty;
        //    txtCoverL.Text = string.Empty;
        //    txtCoverH.Text = string.Empty;
        //    txtCoverMaterial.Text = string.Empty;
        //    txtCoverNL.Text = string.Empty;
        //}
    }

    public void SetCoverControlValues(Cover cover)
    {
        //cboCoverIDs.Text = cover.CoverID;
        //txtCoverH.Text = cover.CoverH.ToString();
        //txtCoverL.Text = cover.CoverL.ToString();
        //txtCoverMaterial.Text = cover.CoverMaterial.ToString();
        //txtCoverNL.Text = cover.CoverNL.ToString();
        //txtCoverW.Text = cover.CoverW.ToString();
    }
}