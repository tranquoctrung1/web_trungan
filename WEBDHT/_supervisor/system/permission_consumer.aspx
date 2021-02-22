<%@ Page Language="C#" MasterPageFile="~/_supervisor/master_page.master"  AutoEventWireup="true" CodeFile="permission_consumer.aspx.cs" Inherits="_supervisor_system_permission_consumer" %>


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
            <h2 class="title">Phân Quyền Point Theo Nhân Viên</h2>
        </div>
        <div class="container-fluid m-t">
            <div class="row">
                <div class="col-sm-6">
                    <div class="group-text">
                        <div class="row">
                            <span>Mã khách hàng</span>
                        </div>
                        <div class="row m-b">
                            <telerik:RadComboBox ID="cboConsumer" runat="server" AllowCustomText="True"
                                DataSourceID="ConsumerDataSource" DataTextField="Id" DataValueField="Id"
                                DropDownWidth="400" EnableLoadOnDemand="True" Filter="StartsWith" AutoPostBack="true"
                                HighlightTemplatedItems="True" TabIndex="7" OnSelectedIndexChanged="cboConsumer_SelectedIndexChanged">
                                <HeaderTemplate>
                                    <table cellpadding="0" cellspacing="0">
                                        <tr>
                                            <td style="width: 50px">Mã NV</td>
                                            <td style="width: 100px">Họ</td>
                                            <td style="width: 150px">Tên</td>
                                            <td style="width: 150px">Tài Khoản</td>
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
                                             <td style="width: 150px">
                                                <%#DataBinder.Eval(Container.DataItem,"Uid") %>
                                            </td>
                                        </tr>
                                    </table>
                                </ItemTemplate>
                            </telerik:RadComboBox>
                            <asp:ObjectDataSource ID="ConsumerDataSource" runat="server"
                                OldValuesParameterFormatString="original_{0}" SelectMethod="GetStaffConsumer"
                                TypeName="UserStaffsBLL"></asp:ObjectDataSource>
                        </div>
                    </div>
                </div>
                <div class="col-sm-6">
                    <div class="group-text">
                        <div class="row">
                            <span>Mã Point</span>
                        </div>
                        <div class="row m-b">
                            <telerik:RadComboBox ID="cboSiteIds" runat="server"
                                DataSourceID="SitesDataSource" DataTextField="Id" DataValueField="Id"
                                AllowCustomText="True" DropDownWidth="350px" EnableLoadOnDemand="True"
                                Filter="StartsWith" HighlightTemplatedItems="True" 
                                 EnableCheckAllItemsCheckBox="true" CheckBoxes="true"
                                AutoPostBack="True">
                                <HeaderTemplate>
                                    <table cellpadding="0" cellspacing="0">
                                        <tr>
                                            <td style="width: 50px">Mã vị trí</td>
                                            <td style="width: 250px">Vị trí</td>
                                        </tr>
                                    </table>
                                </HeaderTemplate>
                                <ItemTemplate>
                                    <table cellpadding="0" cellspacing="0">
                                        <tr>
                                            <td style="width: 50px"><%#DataBinder.Eval(Container.DataItem,"Id") %></td>
                                            <td style="width: 250px"><%#DataBinder.Eval(Container.DataItem,"Location") %></td>
                                        </tr>
                                    </table>
                                </ItemTemplate>
                            </telerik:RadComboBox>
                            <asp:ObjectDataSource ID="SitesDataSource" runat="server"
                                OldValuesParameterFormatString="original_{0}" SelectMethod="GetAll"
                                TypeName="SitesBLL"></asp:ObjectDataSource>
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
            <telerik:AjaxSetting AjaxControlID="cboConsumer">
                <UpdatedControls>
                    <telerik:AjaxUpdatedControl ControlID="cboSiteIds" />
                </UpdatedControls>
            </telerik:AjaxSetting>
            <telerik:AjaxSetting AjaxControlID="btnAdd">
                <UpdatedControls>
                    <telerik:AjaxUpdatedControl ControlID="ntf" />
                    <telerik:AjaxUpdatedControl ControlID="cboConsumer" />
                    <telerik:AjaxUpdatedControl ControlID="cboSiteIds" />
                </UpdatedControls>
            </telerik:AjaxSetting>
        </AjaxSettings>
    </telerik:RadAjaxManagerProxy>
</asp:Content>

