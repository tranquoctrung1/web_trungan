using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

public partial class _supervisor_admin_cre_staff : System.Web.UI.Page
{
    private string _msgEmptyUid = "Chưa nhập mã nhân viên.";
    private string _msgEmptyFirstName = "Chưa nhập họ.";
    private string _msgEmptyLastName = "Chưa nhập họ.";
    private string _msgUpdated = "Đã cập nhật nhân viên.";
    private string _msgInserted = "Đã thêm mới nhân viên.";
    private string _msgDeleted = "Đã xóa nhân viên.";
    private string _msgError = "Lỗi: ";
    protected void Page_Load(object sender, EventArgs e)
    {
        ntf.VisibleOnPageLoad = false;
        if (!IsPostBack)
        {
            cboStaff.Focus();
        }
    }
    protected void cboStaff_SelectedIndexChanged(object sender, Telerik.Web.UI.RadComboBoxSelectedIndexChangedEventArgs e)
    {
        UserStaffsBLL userStaffsBLL = new UserStaffsBLL();

        UserStaff staff = userStaffsBLL.GetById(cboStaff.Text);
        if (staff != null)
        {
            SetControlValues(staff);
        }
    }

    protected void btnAdd_Click(object sender, EventArgs e)
    {
        ntf.VisibleOnPageLoad = true;
        if (string.IsNullOrEmpty(cboStaff.Text))
        {
            ntf.Text = _msgEmptyUid;
            cboStaff.Focus();
            return;
        }
        if (string.IsNullOrEmpty(txtFirstName.Text))
        {
            ntf.Text = _msgEmptyFirstName;
            txtFirstName.Focus();
            return;
        }
        if (string.IsNullOrEmpty(txtLastName.Text))
        {
            ntf.Text = _msgEmptyLastName;
            txtLastName.Focus();
            return;
        }
        CommandStatus status = new CommandStatus();
        UserStaffsBLL userStaffsBLL = new UserStaffsBLL();
        UserStaff staff = GetControlValues();
        UserStaff dbStaff = userStaffsBLL.GetById(staff.Id);
        if (dbStaff == null)
        {
            status = userStaffsBLL.Insert(staff);
            cboStaff.DataBind();
        }
        else
        {
            status = userStaffsBLL.Update(staff);
            cboStaff.DataBind();
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
        if (string.IsNullOrEmpty(cboStaff.Text))
        {
            ntf.Text = _msgEmptyUid;
            cboStaff.Focus();
            return;
        }
        CommandStatus status = new CommandStatus();
        UserStaffsBLL userStaffsBLL = new UserStaffsBLL();
        status = userStaffsBLL.Delete(cboStaff.Text);
        if (status.Deleted)
        {
            ntf.Text = _msgDeleted;
            SetDefaultControls();
            cboStaff.DataBind();
        }
        else
        {
            ntf.Text = _msgError + status.ErrorMessage;
        }
    }

    private void SetControlValues(UserStaff staff)
    {
        cboStaff.SelectedIndex = -1;
        cboStaff.Text = staff.Id;
        txtFirstName.Text = staff.FirstName;
        txtLastName.Text = staff.LastName;
    }

    private UserStaff GetControlValues()
    {
        UserStaff staff = new UserStaff();
        staff.Id = cboStaff.Text;
        staff.FirstName = txtFirstName.Text;
        staff.LastName = txtLastName.Text;
        return staff;
    }

    private void SetDefaultControls()
    {
        cboStaff.SelectedIndex = -1;
        cboStaff.Text = string.Empty;
        txtFirstName.Text = string.Empty;
        txtLastName.Text = string.Empty;
    }
}