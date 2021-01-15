<%@ Page Title="" Language="C#" MasterPageFile="~/_supervisor/master_page.master" AutoEventWireup="true" CodeFile="cre_user.aspx.cs" Inherits="_supervisor_admin_cre_user" %>

<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="Server">
    <link href="../../css/Config.css" rel="stylesheet">
   
    <script type="text/javascript">
        //<![CDATA[

        function btnDelete_Clicked() {
            var win = $find('<%=winConfirmDelete.ClientID %>');
            win.show();
        }
        function btnCancel_Clicked() {
            var win = $find('<%=winConfirmDelete.ClientID %>');
            win.close();
        }
        //]]>

        window.history.replaceState('', '', window.location.href);
    </script>
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="Server">
    <div id="main-content2">
        <div id="main-content-title">
            <h2 class="title">Tạo Người dùng</h2>
        </div>
        <div class="container-fluid m-t">
            <div class="row">
                <div class="col-sm-3">
                    <div class="group-text">
                        <div class="row">
                            <span>Người dùng</span>
                        </div>
                        <div class="row m-b">
                            <telerik:RadComboBox ID="cboUid" runat="server" AllowCustomText="True"
                                AutoPostBack="True" DataSourceID="UsersDataSource" DataTextField="Uid"
                                DataValueField="Uid" EnableLoadOnDemand="True" Filter="StartsWith"
                                HighlightTemplatedItems="True"
                                OnSelectedIndexChanged="cboUid_SelectedIndexChanged">
                            </telerik:RadComboBox>
                            <asp:ObjectDataSource ID="UsersDataSource" runat="server"
                                OldValuesParameterFormatString="original_{0}" SelectMethod="Get4View"
                                TypeName="UsersBLL"></asp:ObjectDataSource>
                        </div>
                    </div>
                </div>
                <div class="col-sm-3">
                    <div class="group-text">
                        <div class="row">
                            <span>Mật khẩu</span>
                        </div>
                        <div class="row m-b">
                            <telerik:RadTextBox ID="txtPwd" runat="server">
                            </telerik:RadTextBox>
                        </div>
                    </div>
                </div>
<%--                <div class="col-sm-3">
                    <div class="group-text">
                        <div class="row">
                            <span>Công ty</span>
                        </div>
                        <div class="row m-b">
                            <telerik:RadComboBox ID="cboCompanies" runat="server" AllowCustomText="True"
                                DataSourceID="SiteCompaniesDataSource" DataTextField="Company"
                                DataValueField="Company" DropDownWidth="275px" EnableLoadOnDemand="True"
                                Filter="StartsWith" HighlightTemplatedItems="True" TabIndex="21">
                                <HeaderTemplate>
                                    <table cellpadding="0" cellspacing="0">
                                        <tr>
                                            <td style="width: 70px">Công ty</td>
                                            <td style="width: 200px">Mô tả</td>
                                        </tr>
                                    </table>
                                </HeaderTemplate>
                                <ItemTemplate>
                                    <table cellpadding="0" cellspacing="0">
                                        <tr>
                                            <td style="width: 70px">
                                                <%#DataBinder.Eval(Container.DataItem,"Company") %>
                                            </td>
                                            <td style="width: 200px">
                                                <%#DataBinder.Eval(Container.DataItem,"Description") %>
                                            </td>
                                        </tr>
                                    </table>
                                </ItemTemplate>
                            </telerik:RadComboBox>
                            <asp:ObjectDataSource ID="SiteCompaniesDataSource" runat="server"
                                OldValuesParameterFormatString="original_{0}" SelectMethod="GetAll"
                                TypeName="SiteCompaniesBLL"></asp:ObjectDataSource>
                        </div>
                    </div>
                </div>--%>
                <div class="col-sm-3">
                    <div class="group-text">
                        <div class="row">
                            <span>Quyền</span>
                        </div>
                        <div class="row m-b">
                            <telerik:RadComboBox ID="cboRoles" runat="server" AllowCustomText="True"
                                DataSourceID="RolesDataSource" DataTextField="Role" DataValueField="Role"
                                EnableLoadOnDemand="True" Filter="StartsWith"
                                HighlightTemplatedItems="True" DropDownWidth="400px">
                                <HeaderTemplate>
                                    <table cellpadding="0" cellspacing="0">
                                        <tr>
                                            <td style="width: 200px">Quyền</td>
                                            <td style="width: 200px">Mô tả</td>
                                        </tr>
                                    </table>
                                </HeaderTemplate>
                                <ItemTemplate>
                                    <table cellpadding="0" cellspacing="0">
                                        <tr>
                                            <td style="width: 200px"><%#DataBinder.Eval(Container.DataItem,"Role") %></td>
                                            <td style="width: 200px"><%#DataBinder.Eval(Container.DataItem,"Description") %></td>
                                        </tr>
                                    </table>
                                </ItemTemplate>
                            </telerik:RadComboBox>
                            <asp:ObjectDataSource ID="RolesDataSource" runat="server"
                                OldValuesParameterFormatString="original_{0}" SelectMethod="GetAll"
                                TypeName="UserRolesBLL"></asp:ObjectDataSource>
                        </div>
                    </div>
                </div>
                <div class="col-sm-3">
                    <div class="group-text">
                        <div class="row">
                            <span>Mã nhân viên</span>
                        </div>
                        <div class="row m-b">
                            <telerik:RadComboBox ID="cboStaffs" runat="server" AllowCustomText="True"
                                DataSourceID="StaffDataSource" DataTextField="Id" DataValueField="Id"
                                DropDownWidth="300" EnableLoadOnDemand="True" Filter="StartsWith"
                                HighlightTemplatedItems="True" TabIndex="7">
                                <HeaderTemplate>
                                    <table cellpadding="0" cellspacing="0">
                                        <tr>
                                            <td style="width: 50px">Mã NV</td>
                                            <td style="width: 100px">Tên</td>
                                            <td style="width: 150px">Họ</td>
                                        </tr>
                                    </table>
                                </HeaderTemplate>
                                <ItemTemplate>
                                    <table cellpadding="0" cellspacing="0">
                                        <tr>
                                            <td style="width: 50px">
                                                <%#DataBinder.Eval(Container.DataItem,"Id") %>
                                            </td>
                                            <td style="width: 100px">
                                                <%#DataBinder.Eval(Container.DataItem,"FirstName") %>
                                            </td>
                                            <td style="width: 150px">
                                                <%#DataBinder.Eval(Container.DataItem,"LastName") %>
                                            </td>
                                        </tr>
                                    </table>
                                </ItemTemplate>
                            </telerik:RadComboBox>
                            <asp:ObjectDataSource ID="StaffDataSource" runat="server"
                                OldValuesParameterFormatString="original_{0}" SelectMethod="GetAll"
                                TypeName="UserStaffsBLL"></asp:ObjectDataSource>
                        </div>
                    </div>
                </div>
            </div>
            <div class="text-center col-sm-12 m-t m-b no-padding" style="clear: both;">
                <asp:Button ID="btnAdd" runat="server" Text="Thêm/Sửa [A]"
                    OnClick="btnAdd_Click" CssClass="btn btn-success" AccessKey="A"></asp:Button>
                <asp:Button ID="btnDelete" runat="server"
                    OnClientClick="btnDelete_Clicked()" Text="Xóa" AutoPostBack="False"
                    CssClass="btn btn-danger"></asp:Button>
            </div>
        </div>
    </div>
    <telerik:RadWindow ID="winConfirmDelete" runat="server" Modal="True"
        VisibleStatusbar="False" Height="160">
        <ContentTemplate>
            <table style="text-align: center; width: 100%">
                <tr>
                    <td>Bạn có muốn xóa người dùng không?
                    </td>
                </tr>
                <tr>
                    <td>&nbsp</td>
                </tr>
                <tr>
                    <td>
                        <asp:Button ID="btnConfim" runat="server" OnClick="btnConfim_Click" Text="Xóa" CssClass="btn btn-danger">
                        </asp:Button>
                        <asp:Button ID="btnCancel" runat="server"
                            OnClientClick="btnCancel_Clicked()"
                            Text="Hủy thao tác" AutoPostBack="False" CssClass="btn btn-success" >
                        </asp:Button>
                    </td>
                </tr>
            </table>
        </ContentTemplate>
    </telerik:RadWindow>
    <telerik:RadNotification ID="ntf" runat="server" Title="Message">
    </telerik:RadNotification>

    <telerik:RadAjaxManagerProxy ID="RadAjaxManagerProxy1" runat="server">
        <AjaxSettings>
            <telerik:AjaxSetting AjaxControlID="cboUid">
                <UpdatedControls>
                    <telerik:AjaxUpdatedControl ControlID="cboUid" />
                    <telerik:AjaxUpdatedControl ControlID="txtPwd" />
                    <telerik:AjaxUpdatedControl ControlID="cboRoles" />
                    <telerik:AjaxUpdatedControl ControlID="cboStaffs" />
                </UpdatedControls>
            </telerik:AjaxSetting>
            <telerik:AjaxSetting AjaxControlID="btnAdd">
                <UpdatedControls>
                    <telerik:AjaxUpdatedControl ControlID="ntf" />
                    <telerik:AjaxUpdatedControl ControlID="cboUid" />
                    <telerik:AjaxUpdatedControl ControlID="txtPwd" />
                    <telerik:AjaxUpdatedControl ControlID="cboRoles" />
                    <telerik:AjaxUpdatedControl ControlID="cboStaffs" />
                </UpdatedControls>
            </telerik:AjaxSetting>
            <telerik:AjaxSetting AjaxControlID="btnDelete">
                <UpdatedControls>
                    <telerik:AjaxUpdatedControl ControlID="ntf" />
                </UpdatedControls>
            </telerik:AjaxSetting>
        </AjaxSettings>
    </telerik:RadAjaxManagerProxy>
</asp:Content>

