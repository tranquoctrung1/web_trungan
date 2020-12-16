using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

public partial class _supervisor_admin_cre_dbrecord : BasePage
{
    private string _msgEmptyLevel = "Chưa nhập cấp điểm lắp đặt.";
    private string _msgEmptyGroup = "Chưa nhập nhóm điểm lắp đặt.";
    private string _msgEmptyStatus = "Chưa nhập tình trạng điểm lắp đặt.";
    private string _msgEmptyCompany = "Chưa nhập quản lý điểm lắp đặt.";
    private string _msgEmptyAvailability = "Chưa nhập trạng thái điểm lắp đặt.";
    private string _msgEmptyDeviceStatus = "Chưa nhập tình trạng thiết bị.";
    private string _msgEmptyAccreditationType = "Chưa nhập loại kiểm định đồng hồ.";
    private string _msgEmptyRole = "Chưa nhập quyền sử dụng.";
    private string _msgEmtyStaff = "Chưa nhập mã nhân viên.";
    private string _msgLevelInserted = "Đã thêm mới cấp điểm lắp đặt.";
    private string _msgGroupInserted = "Đã thêm mới nhóm điểm lắp đặt.";
    private string _msgCompanyInserted = "Đã thêm mới quản lý điểm lắp đặt.";
    private string _msgStatusInserted = "Đã thêm mới tình trạng điểm lắp đặt.";
    private string _msgAvailabilityInserted = "Đã thêm mới trạng thái điểm lắp đặt.";
    private string _msgDeviceStatusInserted = "Đã thêm mới tình trạng thiết bị.";
    private string _msgAccreditationInserted = "Đã thêm mới loại kiểm định.";
    private string _msgRoleInserted = "Đã thêm mới quyền sử dụng.";
    private string _msgStaffInserted = "Đã thêm mới nhân viên.";
    private string _msgLevelUpdated = "Đã sửa cấp điểm lắp đặt.";
    private string _msgGroupUpdated = "Đã sửa nhóm điểm lắp đặt.";
    private string _msgCompanyUpdated = "Đã sửa quản lý điểm lắp đặt.";
    private string _msgStatusUpdated = "Đã sửa tình trạng điểm lắp đặt.";
    private string _msgAvailabilityUpdated = "Đã sửa trạng thái điểm lắp đặt.";
    private string _msgDeviceStatusUpdated = "Đã sửa tình trạng thiết bị.";
    private string _msgAccrediatationTypeUpdated = "Đã sửa loại kiểm định.";
    private string _msgRoleUpdated = "Đã sửa quyền sử dụng.";
    private string _msgStaffUpdated = "Đã sửa nhân viên.";
    private string _msgLevelDeleted = "Đã xóa cấp điểm lắp đặt.";
    private string _msgGroupDeleted = "Đã xóa nhóm điểm lắp đặt.";
    private string _msgCompanyDeleted = "Đã xóa quản lý điểm lắp đặt.";
    private string _msgStatusDeleted = "Đã xóa tình trạng điểm lắp đặt.";
    private string _msgAvailabilityDeleted = "Đã xóa trạng thái điểm lắp đặt.";
    private string _msgDeviceStatusDeleted = "Đã xóa tình trạng thiết bị.";
    private string _msgAccreditationTypeDeleted = "Đã xóa loại kiểm định.";
    private string _msgRoleDeleted = "Đã xóa quyền sử dụng.";
    private string _msgStaffDeleted = "Đã xóa nhân viên.";
    private string _msgError = "Lỗi: ";
    SiteLevelsBLL _siteLevelsBLL = new SiteLevelsBLL();
    SiteGroupsBLL _siteGroupsBLL = new SiteGroupsBLL();
    SiteGroup2sBLL _siteGroup2sBLL = new SiteGroup2sBLL();
    SiteGroup3sBLL _siteGroup3sBLL = new SiteGroup3sBLL();
    SiteGroup4sBLL _siteGroup4sBLL = new SiteGroup4sBLL();
    SiteGroup5sBLL _siteGroup5sBLL = new SiteGroup5sBLL();
    SiteCompaniesBLL _siteCompaniesBLL = new SiteCompaniesBLL();
    SiteStatusBLL _siteStatusBLL = new SiteStatusBLL();
    SiteAvailabilitiesBLL _siteAvailabilitiesBLL = new SiteAvailabilitiesBLL();
    DeviceStatusBLL _deviceStatusBLL = new DeviceStatusBLL();
    MeterAccreditationTypesBLL _meterAccreditationTypesBLL = new MeterAccreditationTypesBLL();
    UserRolesBLL _userRolesBLL = new UserRolesBLL();
    UserStaffsBLL _userStaffsBLL = new UserStaffsBLL();
    protected void Page_Load(object sender, EventArgs e)
    {
        ntf.VisibleOnPageLoad = false;
    }
    protected void cboLevels_SelectedIndexChanged(object sender, Telerik.Web.UI.RadComboBoxSelectedIndexChangedEventArgs e)
    {
        txtLevel.Text = cboLevels.Text;
        txtLevelDescription.Text = cboLevels.SelectedValue;
        txtLevelDescription.Focus();
    }
    protected void btnLevelAdd_Click(object sender, EventArgs e)
    {
        ntf.VisibleOnPageLoad = true;
        SiteLevel level = GetLevel();
        CommandStatus status = new CommandStatus();
        SiteLevel dbLevel = _siteLevelsBLL.GetByLevel(level.Level);
        if (dbLevel == null)
        {
            status = _siteLevelsBLL.Insert(level);
        }
        else
        {
            status = _siteLevelsBLL.Update(level);
        }
        if (status.Inserted)
        {
            ntf.Text = _msgLevelInserted;
        }
        else if (status.Updated)
        {
            ntf.Text = _msgLevelUpdated;
        }
        else if (status.Error)
        {
            ntf.Text = _msgError + status.ErrorMessage;
        }
        cboLevels.Focus();
    }
    private SiteLevel GetLevel()
    {
        SiteLevel level = new SiteLevel();
        level.Level = txtLevel.Text;
        level.Description = txtLevelDescription.Text;
        return level;
    }
    protected void btnLevelDelete_Click(object sender, EventArgs e)
    {
        ntf.VisibleOnPageLoad = true;
        CommandStatus status = new CommandStatus();
        status = _siteLevelsBLL.Delete(txtLevel.Text);
        if (status.Deleted)
        {
            ntf.Text = _msgLevelDeleted;
            SetDefaultLevelControls();
        }
        else
        {
            cboLevels.Focus();
            ntf.Text = _msgError + status.ErrorMessage;
        }
        cboLevels.Focus();
    }
    private void SetDefaultLevelControls()
    {
        LevelsDataSource.DataBind();
        cboLevels.DataBind();
        txtLevel.Text = string.Empty;
        txtLevelDescription.Text = string.Empty;
    }
    protected void cboGroups_SelectedIndexChanged(object sender, Telerik.Web.UI.RadComboBoxSelectedIndexChangedEventArgs e)
    {
        txtGroup.Text = cboGroups.Text;
        txtGroupDescription.Text = cboGroups.SelectedValue;
        txtGroupDescription.Focus();
    }
    protected void btnGroupAdd_Click(object sender, EventArgs e)
    {
        ntf.VisibleOnPageLoad = true;
        SiteGroup group = GetGroup();
        CommandStatus status = new CommandStatus();
        SiteGroup dbGroup = _siteGroupsBLL.GetByGroup(group.Group);
        if (dbGroup == null)
        {
            status = _siteGroupsBLL.Insert(group);
        }
        else
        {
            status = _siteGroupsBLL.Update(group);
        }
        if (status.Inserted)
        {
            ntf.Text = _msgGroupInserted;
        }
        else if (status.Updated)
        {
            ntf.Text = _msgGroupUpdated;
        }
        else if (status.Error)
        {
            ntf.Text = _msgError + status.ErrorMessage;
        }
        cboGroups.Focus();
    }
    private SiteGroup GetGroup()
    {
        SiteGroup group = new SiteGroup();
        group.Group = txtGroup.Text;
        group.Description = txtGroupDescription.Text;
        return group;
    }
    protected void btnGroupDelete_Click(object sender, EventArgs e)
    {
        ntf.VisibleOnPageLoad = true;
        CommandStatus status = new CommandStatus();
        status = _siteGroupsBLL.Delete(txtGroup.Text);
        if (status.Deleted)
        {
            ntf.Text = _msgLevelDeleted;
            SetDefaultGroupControls();
        }
        else
        {
            ntf.Text = _msgError + status.ErrorMessage;
        }
        cboGroups.Focus();
    }
    private void SetDefaultGroupControls()
    {
        GroupsDataSource.DataBind();
        cboGroups.DataBind();
        txtGroup.Text = string.Empty;
        txtGroupDescription.Text = string.Empty;
    }
    //
    protected void cboGroup2s_SelectedIndexChanged(object sender, Telerik.Web.UI.RadComboBoxSelectedIndexChangedEventArgs e)
    {
        txtGroup2.Text = cboGroup2s.Text;
        txtGroup2Description.Text = cboGroup2s.SelectedValue;
        txtGroup2Description.Focus();
    }
    protected void btnGroup2Add_Click(object sender, EventArgs e)
    {
        ntf.VisibleOnPageLoad = true;
        SiteGroup2 group2 = GetGroup2();
        CommandStatus status = new CommandStatus();
        SiteGroup2 dbGroup2 = _siteGroup2sBLL.GetByGroup(group2.Group);
        if (dbGroup2 == null)
        {
            status = _siteGroup2sBLL.Insert(group2);
        }
        else
        {
            status = _siteGroup2sBLL.Update(group2);
        }
        if (status.Inserted)
        {
            ntf.Text = _msgGroupInserted;
        }
        else if (status.Updated)
        {
            ntf.Text = _msgGroupUpdated;
        }
        else if (status.Error)
        {
            ntf.Text = _msgError + status.ErrorMessage;
        }
        cboGroup2s.Focus();
    }
    private SiteGroup2 GetGroup2()
    {
        SiteGroup2 group2 = new SiteGroup2();
        group2.Group = txtGroup2.Text;
        group2.Description = txtGroup2Description.Text;
        return group2;
    }
    protected void btnGroup2Delete_Click(object sender, EventArgs e)
    {
        ntf.VisibleOnPageLoad = true;
        CommandStatus status = new CommandStatus();
        status = _siteGroup2sBLL.Delete(txtGroup2.Text);
        if (status.Deleted)
        {
            ntf.Text = _msgLevelDeleted;
            SetDefaultGroup2Controls();
        }
        else
        {
            ntf.Text = _msgError + status.ErrorMessage;
        }
        cboGroup2s.Focus();
    }
    private void SetDefaultGroup2Controls()
    {
        Group2sDataSource.DataBind();
        cboGroup2s.DataBind();
        txtGroup2.Text = string.Empty;
        txtGroup2Description.Text = string.Empty;
    }
    //

    //
    protected void cboGroup3s_SelectedIndexChanged(object sender, Telerik.Web.UI.RadComboBoxSelectedIndexChangedEventArgs e)
    {
        txtGroup3.Text = cboGroup3s.Text;
        txtGroup3Description.Text = cboGroup3s.SelectedValue;
        txtGroup3Description.Focus();
    }
    protected void btnGroup3Add_Click(object sender, EventArgs e)
    {
        ntf.VisibleOnPageLoad = true;
        SiteGroup3 group3 = GetGroup3();
        CommandStatus status = new CommandStatus();
        SiteGroup3 dbGroup3 = _siteGroup3sBLL.GetByGroup(group3.Group);
        if (dbGroup3 == null)
        {
            status = _siteGroup3sBLL.Insert(group3);
        }
        else
        {
            status = _siteGroup3sBLL.Update(group3);
        }
        if (status.Inserted)
        {
            ntf.Text = _msgGroupInserted;
        }
        else if (status.Updated)
        {
            ntf.Text = _msgGroupUpdated;
        }
        else if (status.Error)
        {
            ntf.Text = _msgError + status.ErrorMessage;
        }
        cboGroup3s.Focus();
    }
    private SiteGroup3 GetGroup3()
    {
        SiteGroup3 group3 = new SiteGroup3();
        group3.Group = txtGroup3.Text;
        group3.Description = txtGroup3Description.Text;
        return group3;
    }
    protected void btnGroup3Delete_Click(object sender, EventArgs e)
    {
        ntf.VisibleOnPageLoad = true;
        CommandStatus status = new CommandStatus();
        status = _siteGroup3sBLL.Delete(txtGroup3.Text);
        if (status.Deleted)
        {
            ntf.Text = _msgLevelDeleted;
            SetDefaultGroup3Controls();
        }
        else
        {
            ntf.Text = _msgError + status.ErrorMessage;
        }
        cboGroup3s.Focus();
    }
    private void SetDefaultGroup3Controls()
    {
        Group3sDataSource.DataBind();
        cboGroup3s.DataBind();
        txtGroup3.Text = string.Empty;
        txtGroup3Description.Text = string.Empty;
    }
    //

    //
    protected void cboGroup4s_SelectedIndexChanged(object sender, Telerik.Web.UI.RadComboBoxSelectedIndexChangedEventArgs e)
    {
        txtGroup4.Text = cboGroup4s.Text;
        txtGroup4Description.Text = cboGroup4s.SelectedValue;
        txtGroup4Description.Focus();
    }
    protected void btnGroup4Add_Click(object sender, EventArgs e)
    {
        ntf.VisibleOnPageLoad = true;
        SiteGroup4 group4 = GetGroup4();
        CommandStatus status = new CommandStatus();
        SiteGroup4 dbGroup4 = _siteGroup4sBLL.GetByGroup(group4.Group);
        if (dbGroup4 == null)
        {
            status = _siteGroup4sBLL.Insert(group4);
        }
        else
        {
            status = _siteGroup4sBLL.Update(group4);
        }
        if (status.Inserted)
        {
            ntf.Text = _msgGroupInserted;
        }
        else if (status.Updated)
        {
            ntf.Text = _msgGroupUpdated;
        }
        else if (status.Error)
        {
            ntf.Text = _msgError + status.ErrorMessage;
        }
        cboGroup4s.Focus();
    }
    private SiteGroup4 GetGroup4()
    {
        SiteGroup4 group4 = new SiteGroup4();
        group4.Group = txtGroup4.Text;
        group4.Description = txtGroup4Description.Text;
        return group4;
    }
    protected void btnGroup4Delete_Click(object sender, EventArgs e)
    {
        ntf.VisibleOnPageLoad = true;
        CommandStatus status = new CommandStatus();
        status = _siteGroup4sBLL.Delete(txtGroup4.Text);
        if (status.Deleted)
        {
            ntf.Text = _msgLevelDeleted;
            SetDefaultGroup4Controls();
        }
        else
        {
            ntf.Text = _msgError + status.ErrorMessage;
        }
        cboGroup4s.Focus();
    }
    private void SetDefaultGroup4Controls()
    {
        Group4sDataSource.DataBind();
        cboGroup4s.DataBind();
        txtGroup4.Text = string.Empty;
        txtGroup4Description.Text = string.Empty;
    }
    //

    protected void cboGroup5s_SelectedIndexChanged(object sender, Telerik.Web.UI.RadComboBoxSelectedIndexChangedEventArgs e)
    {
        txtGroup5.Text = cboGroup5s.Text;
        txtGroup5Description.Text = cboGroup5s.SelectedValue;
        txtGroup5Description.Focus();
    }
    protected void btnGroup5Add_Click(object sender, EventArgs e)
    {
        ntf.VisibleOnPageLoad = true;
        SiteGroup5 group5 = GetGroup5();
        CommandStatus status = new CommandStatus();
        SiteGroup5 dbGroup5 = _siteGroup5sBLL.GetByGroup(group5.Group);
        if (dbGroup5 == null)
        {
            status = _siteGroup5sBLL.Insert(group5);
        }
        else
        {
            status = _siteGroup5sBLL.Update(group5);
        }
        if (status.Inserted)
        {
            ntf.Text = _msgGroupInserted;
        }
        else if (status.Updated)
        {
            ntf.Text = _msgGroupUpdated;
        }
        else if (status.Error)
        {
            ntf.Text = _msgError + status.ErrorMessage;
        }
        cboGroup5s.Focus();
    }
    private SiteGroup5 GetGroup5()
    {
        SiteGroup5 group5 = new SiteGroup5();
        group5.Group = txtGroup5.Text;
        group5.Description = txtGroup5Description.Text;
        return group5;
    }
    protected void btnGroup5Delete_Click(object sender, EventArgs e)
    {
        ntf.VisibleOnPageLoad = true;
        CommandStatus status = new CommandStatus();
        status = _siteGroup5sBLL.Delete(txtGroup5.Text);
        if (status.Deleted)
        {
            ntf.Text = _msgLevelDeleted;
            SetDefaultGroup5Controls();
        }
        else
        {
            ntf.Text = _msgError + status.ErrorMessage;
        }
        cboGroup5s.Focus();
    }
    private void SetDefaultGroup5Controls()
    {
        Group5sDataSource.DataBind();
        cboGroup5s.DataBind();
        txtGroup5.Text = string.Empty;
        txtGroup5Description.Text = string.Empty;
    }
    //

    protected void cboCompanies_SelectedIndexChanged(object sender, Telerik.Web.UI.RadComboBoxSelectedIndexChangedEventArgs e)
    {
        txtCompany.Text = cboCompanies.Text;
        txtCompanyDescription.Text = cboCompanies.SelectedValue;
        txtCompanyDescription.Focus();
    }
    protected void btnCompanyAdd_Click(object sender, EventArgs e)
    {
        ntf.VisibleOnPageLoad = true;
        SiteCompany company = GetCompany();
        CommandStatus status = new CommandStatus();
        SiteCompany dbCompany = _siteCompaniesBLL.GetByCompany(company.Company);
        if (dbCompany == null)
        {
            status = _siteCompaniesBLL.Insert(company);
        }
        else
        {
            status = _siteCompaniesBLL.Update(company);
        }
        if (status.Inserted)
        {
            ntf.Text = _msgCompanyInserted;
        }
        else if (status.Updated)
        {
            ntf.Text = _msgCompanyUpdated;
        }
        else if (status.Error)
        {
            ntf.Text = _msgError + status.ErrorMessage;
        }
        cboCompanies.Focus();
    }
    private SiteCompany GetCompany()
    {
        SiteCompany company = new SiteCompany();
        company.Company = txtCompany.Text;
        company.Description = txtCompanyDescription.Text;
        return company;
    }
    protected void btnCompanyDelete_Click(object sender, EventArgs e)
    {
        ntf.VisibleOnPageLoad = true;
        CommandStatus status = new CommandStatus();
        status = _siteCompaniesBLL.Delete(txtCompany.Text);
        if (status.Deleted)
        {
            ntf.Text = _msgCompanyDeleted;
            SetDefaultCompanyControls();
        }
        else
        {
            ntf.Text = _msgError + status.ErrorMessage;
        }
        cboCompanies.Focus();
    }
    private void SetDefaultCompanyControls()
    {
        CompaniesDataSource.DataBind();
        cboCompanies.DataBind();
        txtCompany.Text = string.Empty;
        txtCompanyDescription.Text = string.Empty;
    }
    protected void cboStatus_SelectedIndexChanged(object sender, Telerik.Web.UI.RadComboBoxSelectedIndexChangedEventArgs e)
    {
        txtStatus.Text = cboStatus.Text;
        txtStatusDescription.Text = cboStatus.SelectedValue;
        txtStatus.Focus();
    }
    protected void btnStatusAdd_Click(object sender, EventArgs e)
    {
        ntf.VisibleOnPageLoad = true;
        SiteStatus siteStatus = GetStatus();
        CommandStatus status = new CommandStatus();
        SiteStatus dbStatus = _siteStatusBLL.GetByStatus(siteStatus.Status);
        if (dbStatus == null)
        {
            status = _siteStatusBLL.Insert(siteStatus);
        }
        else
        {
            status = _siteStatusBLL.Update(siteStatus);
        }
        if (status.Inserted)
        {
            ntf.Text = _msgCompanyInserted;
        }
        else if (status.Updated)
        {
            ntf.Text = _msgCompanyUpdated;
        }
        else if (status.Error)
        {
            ntf.Text = _msgError + status.ErrorMessage;
        }
        cboStatus.Focus();
    }
    private SiteStatus GetStatus()
    {
        SiteStatus status = new SiteStatus();
        status.Status = txtStatus.Text;
        status.Description = txtStatusDescription.Text;
        return status;
    }
    protected void btnStatusDelete_Click(object sender, EventArgs e)
    {
        ntf.VisibleOnPageLoad = true;
        CommandStatus status = new CommandStatus();
        status = _siteStatusBLL.Delete(txtStatus.Text);
        if (status.Deleted)
        {
            ntf.Text = _msgStatusDeleted;
            SetDefaultStatusControls();
        }
        else
        {
            ntf.Text = _msgError + status.ErrorMessage;
        }
        cboStatus.Focus();
    }
    private void SetDefaultStatusControls()
    {
        StatusDataSource.DataBind();
        cboStatus.DataBind();
        txtStatus.Text = string.Empty;
        txtStatusDescription.Text = string.Empty;
    }
    protected void cboAvailabilities_SelectedIndexChanged(object sender, Telerik.Web.UI.RadComboBoxSelectedIndexChangedEventArgs e)
    {
        txtAvailability.Text = cboAvailabilities.Text;
        txtAvailabilityDescription.Text = cboAvailabilities.SelectedValue;
        txtAvailabilityDescription.Focus();
    }
    protected void btnAvailabilityAdd_Click(object sender, EventArgs e)
    {
        ntf.VisibleOnPageLoad = true;
        SiteAvailability availability = GetAvailability();
        CommandStatus status = new CommandStatus();
        SiteAvailability dbAvailability = _siteAvailabilitiesBLL.GetByAvailability(availability.Availability);
        if (dbAvailability == null)
        {
            status = _siteAvailabilitiesBLL.Insert(availability);
        }
        else
        {
            status = _siteAvailabilitiesBLL.Update(availability);
        }
        if (status.Inserted)
        {
            ntf.Text = _msgAvailabilityInserted;
        }
        else if (status.Updated)
        {
            ntf.Text = _msgAvailabilityUpdated;
        }
        else if (status.Error)
        {
            ntf.Text = _msgError + status.ErrorMessage;
        }
        cboAvailabilities.Focus();
    }
    private SiteAvailability GetAvailability()
    {
        SiteAvailability availability = new SiteAvailability();
        availability.Availability = txtAvailability.Text;
        availability.Description = txtAvailabilityDescription.Text;
        return availability;
    }
    protected void btnAvailabilityDelete_Click(object sender, EventArgs e)
    {
        ntf.VisibleOnPageLoad = true;
        CommandStatus status = new CommandStatus();
        status = _siteAvailabilitiesBLL.Delete(txtAvailability.Text);
        if (status.Deleted)
        {
            ntf.Text = _msgAvailabilityDeleted;
            SetDefaultAvailabilityControls();
        }
        else
        {
            ntf.Text = _msgError + status.ErrorMessage;
        }
        cboAvailabilities.Focus();
    }
    private void SetDefaultAvailabilityControls()
    {
        AvailabilitiesDataSource.DataBind();
        cboAvailabilities.Focus();
        txtAvailability.Text = string.Empty;
        txtAvailabilityDescription.Text = string.Empty;
    }
    protected void cboStatusDevice_SelectedIndexChanged(object sender, Telerik.Web.UI.RadComboBoxSelectedIndexChangedEventArgs e)
    {
        txtStatusDevice.Text = cboStatusDevice.Text;
        txtStatusDeviceDescription.Text = cboStatusDevice.SelectedValue;
        txtStatusDeviceDescription.Focus();
    }
    protected void btnStatusDeviceAdd_Click(object sender, EventArgs e)
    {
        ntf.VisibleOnPageLoad = true;
        DeviceStatus deviceStatus = GetStatusDevice();
        CommandStatus status = new CommandStatus();
        DeviceStatus dbStatus = _deviceStatusBLL.GetByStatus(deviceStatus.Status);
        if (dbStatus == null)
        {
            status = _deviceStatusBLL.Insert(deviceStatus);
        }
        else
        {
            status = _deviceStatusBLL.Update(deviceStatus);
        }
        if (status.Inserted)
        {
            ntf.Text = _msgDeviceStatusInserted;
        }
        else if (status.Updated)
        {
            ntf.Text = _msgDeviceStatusUpdated;
        }
        else if (status.Error)
        {
            ntf.Text = _msgError + status.ErrorMessage;
        }
        cboStatusDevice.Focus();
    }
    private DeviceStatus GetStatusDevice()
    {
        DeviceStatus status = new DeviceStatus();
        status.Status = txtStatusDevice.Text;
        status.Description = txtStatusDeviceDescription.Text;
        return status;
    }
    protected void btnStatusDeviceDelete_Click(object sender, EventArgs e)
    {
        ntf.VisibleOnPageLoad = true;
        CommandStatus status = new CommandStatus();
        status = _deviceStatusBLL.Delete(txtStatusDevice.Text);
        if (status.Deleted)
        {
            ntf.Text = _msgDeviceStatusDeleted;
            SetDefaultStatusDeviceControls();
        }
        else
        {
            ntf.Text = _msgError + status.ErrorMessage;
        }
        cboStatusDevice.Focus();
    }
    private void SetDefaultStatusDeviceControls()
    {
        DeviceStatusDataSource.DataBind();
        cboStatusDevice.DataBind();
        txtStatusDevice.Text = string.Empty;
        txtStatusDeviceDescription.Text = string.Empty;
    }
    protected void cboMeterAccreditationTypes_SelectedIndexChanged(object sender, Telerik.Web.UI.RadComboBoxSelectedIndexChangedEventArgs e)
    {
        txtMeterAccreditationType.Text = cboMeterAccreditationTypes.Text;
        txtMeterAccreditationTypeDescription.Text = cboMeterAccreditationTypes.SelectedValue;
        txtMeterAccreditationTypeDescription.Focus();
    }
    protected void btnMeterAccreditationTypeAdd_Click(object sender, EventArgs e)
    {
        ntf.VisibleOnPageLoad = true;
        MeterAccreditationType accreditationType = GetAccreditationType();
        CommandStatus status = new CommandStatus();
        MeterAccreditationType dbAccreditationType = _meterAccreditationTypesBLL.GetByAccreditationType(accreditationType.AccreditationType);
        if (dbAccreditationType == null)
        {
            status = _meterAccreditationTypesBLL.Insert(accreditationType);
        }
        else
        {
            status = _meterAccreditationTypesBLL.Update(accreditationType);
        }
        if (status.Inserted)
        {
            ntf.Text = _msgDeviceStatusInserted;
        }
        else if (status.Updated)
        {
            ntf.Text = _msgDeviceStatusUpdated;
        }
        else if (status.Error)
        {
            ntf.Text = _msgError + status.ErrorMessage;
        }
        cboMeterAccreditationTypes.Focus();
    }
    private MeterAccreditationType GetAccreditationType()
    {
        MeterAccreditationType accreditationType = new MeterAccreditationType();
        accreditationType.AccreditationType = txtMeterAccreditationType.Text;
        accreditationType.Description = txtMeterAccreditationTypeDescription.Text;
        return accreditationType;
    }
    protected void btnMeterAccreditationTypeDelete_Click(object sender, EventArgs e)
    {
        ntf.VisibleOnPageLoad = true;
        CommandStatus status = new CommandStatus();
        status = _meterAccreditationTypesBLL.Delete(txtMeterAccreditationType.Text);
        if (status.Deleted)
        {
            ntf.Text = _msgDeviceStatusDeleted;
            SetDefaultAccreditationTypeControls();
        }
        else
        {
            ntf.Text = _msgError + status.ErrorMessage;
        }
        cboMeterAccreditationTypes.Focus();
    }
    private void SetDefaultAccreditationTypeControls()
    {
        AccreditationTypesDataSource.DataBind();
        cboMeterAccreditationTypes.DataBind();
        txtMeterAccreditationType.Text = string.Empty;
        txtMeterAccreditationTypeDescription.Text = string.Empty;
    }
    protected void cboRoles_SelectedIndexChanged(object sender, Telerik.Web.UI.RadComboBoxSelectedIndexChangedEventArgs e)
    {
        txtRole.Text = cboRoles.Text;
        txtRoleDecription.Text = cboRoles.SelectedValue;
        txtRoleDecription.Focus();
    }
    protected void btnRoleAdd_Click(object sender, EventArgs e)
    {
        ntf.VisibleOnPageLoad = true;
        UserRole role = GetRole();
        CommandStatus status = new CommandStatus();
        UserRole dbRole = _userRolesBLL.GetByRole(role.Role);
        if (dbRole == null)
        {
            status = _userRolesBLL.Insert(role);
        }
        else
        {
            status = _userRolesBLL.Update(role);
        }
        if (status.Inserted)
        {
            ntf.Text = _msgRoleInserted;
        }
        else if (status.Updated)
        {
            ntf.Text = _msgRoleUpdated;
        }
        else if (status.Error)
        {
            ntf.Text = _msgError + status.ErrorMessage;
        }
        cboRoles.Focus();
    }
    private UserRole GetRole()
    {
        UserRole role = new UserRole();
        role.Role = txtRole.Text;
        role.Description = txtRoleDecription.Text;
        return role;
    }
    protected void btnRoleDelete_Click(object sender, EventArgs e)
    {
        ntf.VisibleOnPageLoad = true;
        CommandStatus status = new CommandStatus();
        status = _userRolesBLL.Delete(txtRole.Text);
        if (status.Deleted)
        {
            ntf.Text = _msgRoleDeleted;
            SetDefaultRoleControls();
        }
        else
        {
            ntf.Text = _msgError + status.ErrorMessage;
        }
        cboRoles.Focus();
    }
    private void SetDefaultRoleControls()
    {
        RolesDataSource.DataBind();
        cboRoles.DataBind();
        txtRole.Text = string.Empty;
        txtRoleDecription.Text = string.Empty;
    }
    protected void cboStaffs_SelectedIndexChanged(object sender, Telerik.Web.UI.RadComboBoxSelectedIndexChangedEventArgs e)
    {
        UserStaff staff = _userStaffsBLL.GetById(cboStaffs.Text);
        if (staff != null)
        {
            txtFirstName.Text = staff.FirstName;
            txtLastName.Text = staff.LastName;
        }
        txtFirstName.Focus();
    }
    protected void btnStaffAdd_Click(object sender, EventArgs e)
    {
        ntf.VisibleOnPageLoad = true;
        UserStaff staff = GetStaff();
        CommandStatus status = new CommandStatus();
        UserStaff dbStaff = _userStaffsBLL.GetById(staff.Id);
        if (dbStaff == null)
        {
            status = _userStaffsBLL.Insert(staff);
        }
        else
        {
            status = _userStaffsBLL.Update(staff);
        }
        if (status.Inserted)
        {
            ntf.Text = _msgStaffInserted;
        }
        else if (status.Updated)
        {
            ntf.Text = _msgStaffUpdated;
        }
        else if (status.Error)
        {
            ntf.Text = _msgError + status.ErrorMessage;
        }
        cboStaffs.Focus();
    }
    private UserStaff GetStaff()
    {
        UserStaff staff = new UserStaff();
        staff.Id = cboStaffs.Text;
        staff.FirstName = txtFirstName.Text;
        staff.LastName = txtLastName.Text;
        return staff;
    }
    protected void btnStaffDelete_Click(object sender, EventArgs e)
    {
        ntf.VisibleOnPageLoad = true;
        CommandStatus status = new CommandStatus();
        status = _userStaffsBLL.Delete(cboStaffs.Text);
        if (status.Deleted)
        {
            ntf.Text = _msgStaffDeleted;
            SetDefaultStaffControls();
        }
        else
        {
            ntf.Text = _msgError + status.ErrorMessage;
        }
        cboStaffs.Focus();
    }
    private void SetDefaultStaffControls()
    {
        StaffDataSource.DataBind();
        cboStaffs.DataBind();
        txtFirstName.Text = string.Empty;
        txtLastName.Text = string.Empty;
    }
}