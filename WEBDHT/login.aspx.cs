﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Net;

public partial class login : BasePage
{
    private string _msgWrong = "Sai ký danh hoặc mật khẩu.";
    private string _msgEmptyUid = "Chưa nhập ký danh.";
    private string _msgEmptyPwd = "Chưa nhập mật khẩu.";
    private string _urlDefault = "~/_supervisor/DashBoard/DashBoard.aspx";
    private string _urlCustomer = "~/_customer/output.aspx";
    UsersBLL _usersBLL = new UsersBLL();
    StringUTL _stringUTL = new StringUTL();
    protected void Page_Load(object sender, EventArgs e)
    {
        ntf.VisibleOnPageLoad = false;
        if (!IsPostBack)
        {
            txtUid.Focus();
            if (HttpContext.Current.User.Identity.IsAuthenticated)
            {

                var user = _usersBLL.GetByUid(HttpContext.Current.User.Identity.Name);
                if (user != null)
                {
                    user.Active = false;
                }
                try
                {
                    _usersBLL.Update(user);
                }
                catch (Exception ex)
                {

                    //throw;
                }
            }
        }
    }
    protected void btnOk_Click(object sender, EventArgs e)
    {
        ntf.VisibleOnPageLoad = true;
        if (string.IsNullOrEmpty(txtUid.Text))
        {
            ntf.Text = _msgEmptyUid;
            txtUid.Focus();
            return;
        }
        if (string.IsNullOrEmpty(txtPwd.Text))
        {
            ntf.Text = _msgEmptyPwd;
            txtPwd.Focus();
            return;
        }
        User dbUser = _usersBLL.GetByUid(txtUid.Text);
        string hashedPassword = _stringUTL.HashMD5(_stringUTL.HashMD5(txtPwd.Text) + dbUser.Salt);
        if (string.Equals(hashedPassword, dbUser.Pwd))
        {
            HttpCookie cookie;
            System.Web.Security.FormsAuthenticationTicket ticket = new System.Web.Security.FormsAuthenticationTicket(1, dbUser.Uid, DateTime.Now,
                        DateTime.Now.AddMinutes(HttpContext.Current.Session.Timeout),
                        true, dbUser.Role + "|" + dbUser.Company, System.Web.Security.FormsAuthentication.FormsCookiePath);
            string hashCookie = System.Web.Security.FormsAuthentication.Encrypt(ticket);
            cookie = new HttpCookie(System.Web.Security.FormsAuthentication.FormsCookieName, hashCookie);
            Response.Cookies.Add(cookie);
            if (dbUser.LogCount == null)
            {
                dbUser.LogCount = 1;
            }
            else
            {
                dbUser.LogCount += 1;
            }
            _usersBLL.Update(dbUser);
            if (dbUser.Role != "customer" && dbUser.Role != "customer_boo")
            {
                Response.Redirect(_urlDefault);
            }
            else
            {
                Response.Redirect(_urlCustomer);
            }
        }
        else
        {
            ntf.Text = _msgWrong;
            txtUid.Focus();
        }
    }
}