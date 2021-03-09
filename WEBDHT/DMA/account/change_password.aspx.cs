using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

public partial class DMA_account_change_password : System.Web.UI.Page
{
    private string _msgEmptyOldPassword = "Chưa nhập mật khẩu cũ.";
    private string _msgEmptyNewPassword = "Chưa nhập mật khẩu mới.";
    private string _msgEmptyConfirmPassword = "Chưa nhập mật khẩu xác nhận.";
    private string _msgConfirmIsNotTheSame = "Mật khẩu xác nhận không đúng.";
    private string _msgWrongPassword = "Mật khẩu cũ không đúng.";
    private string _msgUpdated = "Đã đổi mật khẩu.";
    private string _msgError = "Lỗi: ";
    UsersBLL _usersBLL = new UsersBLL();
    StringUTL _stringUTL = new StringUTL();
    protected void Page_Load(object sender, EventArgs e)
    {
        ntf.VisibleOnPageLoad = false;
    }
    protected void btnSubmit_Click(object sender, EventArgs e)
    {
        txtOldPwd.Focus();
        ntf.VisibleOnPageLoad = true;
        if (string.IsNullOrEmpty(txtOldPwd.Text))
        {
            ntf.Text = _msgEmptyOldPassword;
            return;
        }
        string username = HttpContext.Current.User.Identity.Name;
        User user = _usersBLL.GetByUid(username);
        string hashedPassword = _stringUTL.HashMD5(_stringUTL.HashMD5(txtOldPwd.Text) + user.Salt);
        if (!string.Equals(hashedPassword, user.Pwd))
        {
            ntf.Text = _msgWrongPassword;
            return;
        }
        if (string.IsNullOrEmpty(txtNewPwd.Text))
        {
            ntf.Text = _msgEmptyNewPassword;
            return;
        }
        if (string.IsNullOrEmpty(txtComfirm.Text))
        {
            ntf.Text = _msgEmptyConfirmPassword;
            return;
        }
        if (!string.Equals(txtNewPwd.Text, txtComfirm.Text))
        {
            ntf.Text = _msgConfirmIsNotTheSame;
            return;
        }
        string newSalt = _stringUTL.CreateSalt(8);
        string hashedNewPassword = _stringUTL.HashMD5(_stringUTL.HashMD5(txtNewPwd.Text) + newSalt);
        CommandStatus status = new CommandStatus();
        user.Salt = newSalt;
        user.Pwd = hashedNewPassword;
        status = _usersBLL.Update(user);
        if (status.Updated)
        {
            ntf.Text = _msgUpdated;
        }
        else
        {
            ntf.Text = _msgError + status.ErrorMessage;
        }
    }
}