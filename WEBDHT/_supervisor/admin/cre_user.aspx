<%@ Page Title="" Language="C#" MasterPageFile="~/_supervisor/master_page.master" AutoEventWireup="true" CodeFile="cre_user.aspx.cs" Inherits="_supervisor_admin_cre_user" %>

<asp:Content ID="Content1" ContentPlaceHolderID="head" Runat="Server">
    <style type="text/css">
        .style1
        {
            width: 50%;
            table-layout:fixed;
        }
    </style>
    <script type="text/javascript" id="telerikClientEvents1">
//<![CDATA[

        function btnDelete_Clicked(sender, args) {
            var win = $find('<%=winConfirmDelete.ClientID %>');
            win.show();
        }
        function btnCancel_Clicked(sender, args) {
            var win = $find('<%=winConfirmDelete.ClientID %>');
            win.close();
        }
//]]>
</script>
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" Runat="Server">
    <div id="main-content">
        <telerik:RadAjaxPanel ID="RadAjaxPanel1" runat="server">
        <div id="main-content-title">
            <h2>Người dùng</h2>
            <hr class="line" />
            </div>
        <div id="main-content-text">
            <table class="style1">
                <tr>
                    <td>
                        Người dùng:</td>
                    <td>
                        <telerik:RadComboBox ID="cboUid" Runat="server" AllowCustomText="True" 
                            AutoPostBack="True" DataSourceID="UsersDataSource" DataTextField="Uid" 
                            DataValueField="Uid" EnableLoadOnDemand="True" Filter="StartsWith" 
                            HighlightTemplatedItems="True" 
                            onselectedindexchanged="cboUid_SelectedIndexChanged">
                        </telerik:RadComboBox>
                        <asp:ObjectDataSource ID="UsersDataSource" runat="server" 
                            OldValuesParameterFormatString="original_{0}" SelectMethod="Get4View" 
                            TypeName="UsersBLL"></asp:ObjectDataSource>
                    </td>
                </tr>
                <tr>
                    <td>
                        Mật khẩu:</td>
                    <td>
                        <telerik:RadTextBox ID="txtPwd" Runat="server">
                        </telerik:RadTextBox>
                    </td>
                </tr>
                <tr>
                    <td>
                        Công ty:</td>
                    <td>
                        <telerik:RadComboBox ID="cboCompanies" Runat="server" AllowCustomText="True" 
                            DataSourceID="SiteCompaniesDataSource" DataTextField="Company" 
                            DataValueField="Company" DropDownWidth="275px" EnableLoadOnDemand="True" 
                            Filter="StartsWith" HighlightTemplatedItems="True" TabIndex="21">
                            <HeaderTemplate>
                                <table cellpadding="0" cellspacing="0">
                                    <tr>
                                        <td style="width:70px">
                                            Công ty</td>
                                        <td style="width:200px">
                                            Mô tả</td>
                                    </tr>
                                </table>
                            </HeaderTemplate>
                            <ItemTemplate>
                                <table cellpadding="0" cellspacing="0">
                                    <tr>
                                        <td style="width:70px">
                                            <%#DataBinder.Eval(Container.DataItem,"Company") %>
                                        </td>
                                        <td style="width:200px">
                                            <%#DataBinder.Eval(Container.DataItem,"Description") %>
                                        </td>
                                    </tr>
                                </table>
                            </ItemTemplate>
                        </telerik:RadComboBox>
                        <asp:ObjectDataSource ID="SiteCompaniesDataSource" runat="server" 
                            OldValuesParameterFormatString="original_{0}" SelectMethod="GetAll" 
                            TypeName="SiteCompaniesBLL"></asp:ObjectDataSource>
                    </td>
                </tr>
                <tr>
                    <td>
                        Quyền:</td>
                    <td>
                        <telerik:RadComboBox ID="cboRoles" Runat="server" AllowCustomText="True" 
                            DataSourceID="RolesDataSource" DataTextField="Role" DataValueField="Role" 
                            EnableLoadOnDemand="True" Filter="StartsWith" 
                            HighlightTemplatedItems="True" DropDownWidth="400px">
                            <HeaderTemplate>
                                <table cellpadding="0" cellspacing="0">
                                    <tr>
                                        <td style="width:200px">Quyền</td>
                                        <td style="width:200px">Mô tả</td>
                                    </tr>
                                </table>
                            </HeaderTemplate>
                            <ItemTemplate>
                                <table cellpadding="0" cellspacing="0">
                                    <tr>
                                        <td style="width:200px"><%#DataBinder.Eval(Container.DataItem,"Role") %></td>
                                        <td style="width:200px"><%#DataBinder.Eval(Container.DataItem,"Description") %></td>
                                    </tr>
                                </table>
                            </ItemTemplate>
                        </telerik:RadComboBox>
                        <asp:ObjectDataSource ID="RolesDataSource" runat="server" 
                            OldValuesParameterFormatString="original_{0}" SelectMethod="GetAll" 
                            TypeName="UserRolesBLL"></asp:ObjectDataSource>
                    </td>
                </tr>
                <tr>
                    <td>
                        Mã nhân viên:</td>
                    <td>
                        <telerik:RadComboBox ID="cboStaffs" Runat="server" AllowCustomText="True" 
                            DataSourceID="StaffDataSource" DataTextField="Id" DataValueField="Id" 
                            DropDownWidth="300" EnableLoadOnDemand="True" Filter="StartsWith" 
                            HighlightTemplatedItems="True" TabIndex="7">
                            <HeaderTemplate>
                                <table cellpadding="0" cellspacing="0">
                                    <tr>
                                        <td style="width:50px">
                                            Mã NV</td>
                                        <td style="width:100px">
                                            Tên</td>
                                        <td style="width:150px">
                                            Họ</td>
                                    </tr>
                                </table>
                            </HeaderTemplate>
                            <ItemTemplate>
                                <table cellpadding="0" cellspacing="0">
                                    <tr>
                                        <td style="width:50px">
                                            <%#DataBinder.Eval(Container.DataItem,"Id") %>
                                        </td>
                                        <td style="width:100px">
                                            <%#DataBinder.Eval(Container.DataItem,"FirstName") %>
                                        </td>
                                        <td style="width:150px">
                                            <%#DataBinder.Eval(Container.DataItem,"LastName") %>
                                        </td>
                                    </tr>
                                </table>
                            </ItemTemplate>
                        </telerik:RadComboBox>
                        <asp:ObjectDataSource ID="StaffDataSource" runat="server" 
                            OldValuesParameterFormatString="original_{0}" SelectMethod="GetAll" 
                            TypeName="UserStaffsBLL"></asp:ObjectDataSource>
                    </td>
                </tr>
                <tr>
                    <td>
                        &nbsp;</td>
                    <td>
                        <telerik:RadButton ID="btnAdd" runat="server" Text="Thêm/Sửa" 
                            onclick="btnAdd_Click">
                        </telerik:RadButton>
                        <telerik:RadButton ID="btnDelete" runat="server" Text="Xóa" 
                            AutoPostBack="False" 
                            onclientclicked="btnDelete_Clicked">
                        </telerik:RadButton>
                    </td>
                </tr>
            </table>
            <telerik:RadWindow ID="winConfirmDelete" runat="server" Modal="True" 
                    VisibleStatusbar="False" Height="160">
                    <ContentTemplate>
                        <table style="text-align:center;width:100%">
                            <tr>
                                <td>
                                    Bạn có muốn xóa người dùng không?
                                </td>
                            </tr>
                            <tr>
                                <td>&nbsp</td>
                            </tr>
                            <tr>
                                <td>
                                    <telerik:RadButton ID="btnConfim" runat="server" OnClick="btnConfim_Click" Text="Xóa">
                                    </telerik:RadButton>
                                    <telerik:RadButton ID="btnCancel" runat="server" 
                                        onclientclicked="btnCancel_Clicked"
                                        Text="Hủy thao tác" AutoPostBack="False">
                                    </telerik:RadButton>
                                </td>
                            </tr>
                        </table>
                    </ContentTemplate>
                </telerik:RadWindow>
                <telerik:RadNotification ID="ntf" runat="server" Title="Message">
                </telerik:RadNotification>
        </div>
        </telerik:RadAjaxPanel>
    </div>
</asp:Content>

