<%@ Page Title="" Language="C#" MasterPageFile="~/_customer/customer.master" AutoEventWireup="true" CodeFile="change_password.aspx.cs" Inherits="_customer_change_password" %>

<asp:Content ID="Content1" ContentPlaceHolderID="head" Runat="Server">
<style type="text/css">
        .style1
        {
            width:50%;
            table-layout:fixed;
        }
    </style>
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" Runat="Server">
<div id="main-content">
        <telerik:RadAjaxPanel ID="RadAjaxPanel1" runat="server">
        <div id="main-content-title">
            <h2>Đổi mật khẩu</h2>
            <hr class="line" />
            <table class="style1">
                <tr>
                    <td>
                        Mật khẩu cũ:</td>
                    <td>
                        <telerik:RadTextBox ID="txtOldPwd" Runat="server" TextMode="Password">
                        </telerik:RadTextBox>
                    </td>
                </tr>
                <tr>
                    <td>
                        Mật khẩu mới:</td>
                    <td>
                        <telerik:RadTextBox ID="txtNewPwd" Runat="server" TextMode="Password">
                        </telerik:RadTextBox>
                    </td>
                </tr>
                <tr>
                    <td>
                        Nhập lại mật khẩu mới:</td>
                    <td>
                        <telerik:RadTextBox ID="txtComfirm" Runat="server" TextMode="Password">
                        </telerik:RadTextBox>
                    </td>
                </tr>
                <tr>
                    <td>
                        &nbsp;</td>
                    <td>
                        <telerik:RadButton ID="btnSubmit" runat="server" Text="Thay đổi" 
                            onclick="btnSubmit_Click">
                        </telerik:RadButton>
                    </td>
                </tr>
            </table>
            <telerik:RadNotification ID="ntf" runat="server" Title="Message">
            </telerik:RadNotification>
            </div>
        </telerik:RadAjaxPanel>
    </div>
</asp:Content>

