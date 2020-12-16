using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

public partial class _supervisor_admin_cre_user : BasePage
{
    private string _msgEmptyUid = "Chưa nhập ký danh.";
    private string _msgEmptyPwd = "Chưa nhập mật khẩu.";
    private string _msgEmptyCompany = "Chưa nhập công ty.";
    private string _msgEmptyRole = "Chưa nhập quyền người dùng.";
    private string _msgUpdated = "Đã cập nhật người dung.";
    private string _msgInserted = "Đã thêm mới người dùng.";
    private string _msgDeleted = "Đã xóa người dùng.";
    private string _msgError = "Lỗi: ";
    StringUTL _stringUTL = new StringUTL();
    UsersBLL _usersBLL = new UsersBLL();
    protected void Page_Load(object sender, EventArgs e)
    {
        ntf.VisibleOnPageLoad = false;
        if (!IsPostBack)
        {
            cboUid.Focus();
        }
    }
    protected void cboUid_SelectedIndexChanged(object sender, Telerik.Web.UI.RadComboBoxSelectedIndexChangedEventArgs e)
    {
        User user = _usersBLL.GetByUid(cboUid.Text);
        if (user != null)
        {
            SetControlValues(user);
        }
        txtPwd.Focus();
    }
    protected void btnAdd_Click(object sender, EventArgs e)
    {
        ntf.VisibleOnPageLoad = true;
        if (string.IsNullOrEmpty(cboUid.Text))
        {
            ntf.Text = _msgEmptyUid;
            cboUid.Focus();
            return;
        }
        if (string.IsNullOrEmpty(txtPwd.Text))
        {
            ntf.Text = _msgEmptyPwd;
            txtPwd.Focus();
            return;
        }
        if (string.IsNullOrEmpty(cboCompanies.Text))
        {
            ntf.Text = _msgEmptyCompany;
            cboCompanies.Focus();
            return;
        }
        if (string.IsNullOrEmpty(cboRoles.Text))
        {
            ntf.Text = _msgEmptyRole;
            cboRoles.Focus();
            return;
        }
        CommandStatus status=new CommandStatus();
        User user = GetControlValues();
        User dbUser = _usersBLL.GetByUid(user.Uid);
        if (dbUser != null && string.Equals(txtPwd.Text, "********"))
        {
            user.Pwd = dbUser.Pwd;
            user.Salt = dbUser.Salt;
        }
        if (dbUser == null)
        {
            status = _usersBLL.Insert(user);
        }
        else
        {
            status = _usersBLL.Update(user);
        }
        if (status.Inserted)
        {
            ntf.Text = _msgInserted;
        }
        else if (status.Updated)
        {
            ntf.Text = _msgUpdated;
        }
        else if (status.Error)
        {
            ntf.Text = _msgError + status.ErrorMessage;
        }
    }
    protected void btnConfim_Click(object sender, EventArgs e)
    {
        ntf.VisibleOnPageLoad = true;
        if (string.IsNullOrEmpty(cboUid.Text))
        {
            ntf.Text = _msgEmptyUid;
            cboUid.Focus();
            return;
        }
        CommandStatus status = new CommandStatus();
        status = _usersBLL.Delete(cboUid.Text);
        if (status.Deleted)
        {
            ntf.Text = _msgDeleted;
            SetDefaultControls();
        }
        else
        {
            ntf.Text = _msgError + status.ErrorMessage;
        }
    }
    private void SetControlValues(User user)
    {
        cboUid.SelectedIndex = -1;
        cboUid.Text = user.Uid;
        txtPwd.Text = "********";
        cboCompanies.Text = user.Company;
        cboRoles.Text = user.Role;
        cboStaffs.Text = user.StaffId;
    }
    private User GetControlValues()
    {
        User user = new User();
        user.Uid = cboUid.Text;
        user.Salt = _stringUTL.CreateSalt(8);
        user.Pwd = _stringUTL.HashMD5(_stringUTL.HashMD5(txtPwd.Text) + user.Salt);
        user.Role = cboRoles.Text;
        user.StaffId = cboStaffs.Text;
        user.Company = cboCompanies.Text;
        return user;
    }

    private void SetDefaultControls()
    {
        cboUid.SelectedIndex = -1;
        cboRoles.SelectedIndex = -1;
        cboStaffs.SelectedIndex = -1;
        cboCompanies.SelectedIndex = -1;
        cboCompanies.Text = string.Empty;
        cboRoles.Text = string.Empty;
        cboStaffs.Text = string.Empty;
        cboUid.Text = string.Empty;
        txtPwd.Text = string.Empty;
    }
}