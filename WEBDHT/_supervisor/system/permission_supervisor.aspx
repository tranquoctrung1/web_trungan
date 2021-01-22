<%@ Page Language="C#" AutoEventWireup="true" MasterPageFile="~/_supervisor/master_page.master" CodeFile="permission_supervisor.aspx.cs" Inherits="_supervisor_system_permission_supervisor" %>


<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="Server">
    <link href="../../css/Config.css" rel="stylesheet">

    <script type="text/javascript">
        //<![CDATA[
        window.history.replaceState('', '', window.location.href);
    </script>
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="Server">
    <div id="main-content2">
        <div id="main-content-title">
            <h2 class="title">Phân Quyền Quận Theo Nhân Viên</h2>
        </div>
        <div class="container-fluid m-t">
            <div class="row">
                <div class="col-sm-6">
                    <div class="group-text">
                        <div class="row">
                            <span>Mã nhân viên</span>
                        </div>
                        <div class="row m-b">
                            <telerik:RadComboBox ID="cboStaffs" runat="server" AllowCustomText="True"
                                DataSourceID="StaffDataSource" DataTextField="Id" DataValueField="Id"
                                DropDownWidth="300" EnableLoadOnDemand="True" Filter="StartsWith" AutoPostBack="true"
                                HighlightTemplatedItems="True" TabIndex="7" OnSelectedIndexChanged="cboStaffs_SelectedIndexChanged">
                                <HeaderTemplate>
                                    <table cellpadding="0" cellspacing="0">
                                        <tr>
                                            <td style="width: 50px">Mã NV</td>
                                            <td style="width: 100px">Họ</td>
                                            <td style="width: 150px">Tên</td>
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
                                OldValuesParameterFormatString="original_{0}" SelectMethod="GetStaffSupervisor"
                                TypeName="UserStaffsBLL"></asp:ObjectDataSource>
                        </div>
                    </div>
                </div>
                <div class="col-sm-6">
                    <div class="group-text">
                        <div class="row">
                            <span>Mã Quận</span>
                        </div>
                        <div class="row m-b">
                            <telerik:RadComboBox ID="cboDistrict" runat="server" AllowCustomText="True"
                                EnableLoadOnDemand="True" Filter="StartsWith" AutoPostBack="true"
                                HighlightTemplatedItems="True" DataSourceID="DistrictDataSource"
                                DataTextField="IdDistrict" DataValueField="IdDistrict" DropDownWidth="275px"
                                TabIndex="1" EnableCheckAllItemsCheckBox="true" CheckBoxes="true">
                                <HeaderTemplate>
                                    <table cellpadding="0" cellspacing="0">
                                        <tr>
                                            <td style="width: 70px">Id</td>
                                            <td style="width: 100px">Tên Quận</td>
                                            <td style="width: 100px">Mô tả</td>
                                        </tr>
                                    </table>
                                </HeaderTemplate>
                                <ItemTemplate>
                                    <table cellpadding="0" cellspacing="0">
                                        <tr>
                                            <td style="width: 70px"><%#DataBinder.Eval(Container.DataItem,"IdDistrict") %></td>
                                            <td style="width: 100px"><%#DataBinder.Eval(Container.DataItem,"Name") %></td>
                                            <td style="width: 100px"><%#DataBinder.Eval(Container.DataItem,"Description") %></td>
                                        </tr>
                                    </table>
                                </ItemTemplate>
                            </telerik:RadComboBox>
                            <asp:ObjectDataSource ID="DistrictDataSource" runat="server"
                                OldValuesParameterFormatString="original_{0}" SelectMethod="GetDistricts"
                                TypeName="DistrictBLL"></asp:ObjectDataSource>
                        </div>
                    </div>
                </div>
                <div class="text-center col-sm-12 m-t m-b no-padding" style="clear: both;">
                    <asp:Button ID="btnAdd" runat="server" Text="Cập nhật"
                        OnClick="btnAdd_Click" CssClass="btn btn-success" AccessKey="A"></asp:Button>
                </div>
            </div>
        </div>
    </div>
    <telerik:RadNotification ID="ntf" runat="server" Title="Message">
    </telerik:RadNotification>

    <telerik:RadAjaxManagerProxy ID="RadAjaxManagerProxy1" runat="server">
        <AjaxSettings>
            <telerik:AjaxSetting AjaxControlID="cboStaffs">
                <UpdatedControls>
                    <telerik:AjaxUpdatedControl ControlID="cboDistrict" />
                </UpdatedControls>
            </telerik:AjaxSetting>
            <telerik:AjaxSetting AjaxControlID="btnAdd">
                <UpdatedControls>
                    <telerik:AjaxUpdatedControl ControlID="ntf" />
                    <telerik:AjaxUpdatedControl ControlID="cboStaffs" />
                    <telerik:AjaxUpdatedControl ControlID="cboDistrict" />
                </UpdatedControls>
            </telerik:AjaxSetting>
        </AjaxSettings>
    </telerik:RadAjaxManagerProxy>
</asp:Content>

