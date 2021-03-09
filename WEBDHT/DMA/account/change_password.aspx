<%@ Page Language="C#" MasterPageFile="~/DMA/master_page.master" AutoEventWireup="true" CodeFile="change_password.aspx.cs" Inherits="DMA_account_change_password" %>

<asp:Content ID="Content1" ContentPlaceHolderID="head" Runat="Server">
    <style type="text/css">
        .style1
        {
            width:50%;
            table-layout: fixed;
        }
        .title-change-password
        {
            text-transform: uppercase;
            font-size: 2.5rem;
            padding-top: 1rem;
            text-align: center;
            font-weight: 600
        }
        .col-md-4 
        {
            padding-left: 0px !important;
            padding-right: 30px !important;
        }
        .col-md-4 label
        {
            font-weight: 500 !important;
            margin-bottom: 2px !important
        }
       .btn 
       {
           display: block !important;
           margin: 0 auto
       }
    </style>
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" Runat="Server">
    <div id="main-content">
        <telerik:RadAjaxPanel ID="RadAjaxPanel1" runat="server">
        <div id="main-content-title">
            <h2 class="title-change-password">Đổi mật khẩu</h2>
            <hr class="line" />
            <div class="form-row">
                <div class="form-group col-md-4">
                    <label for="txtOldPwd">Mật khẩu cũ</label>
                    <%--<input type="email" class="form-control" id="inputEmail4">--%>
                     <asp:TextBox ID="txtOldPwd" Runat="server" CssClass="form-control" TextMode="Password" > </asp:TextBox>
                </div>
                <div class="form-group col-md-4">
                    <label for="txtNewPwd">Mật khẩu mới</label>
                    <%--<input type="password" class="form-control" id="inputPassword4">--%>
                     <asp:TextBox ID="txtNewPwd" Runat="server" CssClass="form-control" TextMode="Password">
                        </asp:TextBox>
                </div>
                <div class="form-group col-md-4">
                    <label for="txtComfirm">Nhập lại mật khẩu mới</label>
                    <%--<input type="password" class="form-control" id="inputPassword4">--%>
                     <asp:TextBox ID="txtComfirm" Runat="server"  CssClass="form-control" TextMode="Password">
                        </asp:TextBox>
                </div>
               
                    <asp:Button ID="btnSubmit" runat="server" Text="Thay đổi"  CssClass="btn btn-primary"
                        onclick="btnSubmit_Click">
                    </asp:Button>
                
            </div>
            <telerik:RadNotification ID="ntf" runat="server" Title="Message">
            </telerik:RadNotification>
            </div>
        </telerik:RadAjaxPanel>
    </div>
</asp:Content>

