<%@ Page Language="C#" MasterPageFile="~/_supervisor/master_page.master" AutoEventWireup="true" CodeFile="cre_staff.aspx.cs" Inherits="_supervisor_admin_cre_staff" %>

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
            <h2 class="title">Tạo Nhân Viên</h2>
        </div>
        <div class="container-fluid m-t">
            <div class="row">
                <div class="col-sm-4">
                    <div class="group-text">
                        <div class="row">
                            <span>Mã nhân viên</span>
                        </div>
                        <div class="row m-b">
                            <telerik:RadComboBox ID="cboStaff" runat="server" AllowCustomText="True"
                                AutoPostBack="True" DataSourceID="StaffDataSource" DataTextField="Id"
                                DataValueField="Id" EnableLoadOnDemand="True" Filter="StartsWith"
                                HighlightTemplatedItems="True"
                                OnSelectedIndexChanged="cboStaff_SelectedIndexChanged">
                            </telerik:RadComboBox>
                            <asp:ObjectDataSource ID="StaffDataSource" runat="server"
                                OldValuesParameterFormatString="original_{0}" SelectMethod="GetAll"
                                TypeName="UserStaffsBLL"></asp:ObjectDataSource>
                        </div>
                    </div>
                </div>
                <div class="col-sm-4">
                    <div class="group-text">
                        <div class="row">
                            <span>Họ</span>
                        </div>
                        <div class="row m-b">
                            <telerik:RadTextBox ID="txtFirstName" runat="server">
                            </telerik:RadTextBox>
                        </div>
                    </div>
                </div>
                <div class="col-sm-4">
                    <div class="group-text">
                        <div class="row">
                            <span>Tên</span>
                        </div>
                        <div class="row m-b">
                            <telerik:RadTextBox ID="txtLastName" runat="server">
                            </telerik:RadTextBox>
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
                    <td>Bạn có muốn xóa nhân viên không?
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
            <telerik:AjaxSetting AjaxControlID="cboStaff">
                <UpdatedControls>
                    <telerik:AjaxUpdatedControl ControlID="cboStaff" />
                    <telerik:AjaxUpdatedControl ControlID="txtFirstName" />
                    <telerik:AjaxUpdatedControl ControlID="txtLastName" />
                </UpdatedControls>
            </telerik:AjaxSetting>
            <telerik:AjaxSetting AjaxControlID="btnAdd">
                <UpdatedControls>
                    <telerik:AjaxUpdatedControl ControlID="ntf" />
                     <telerik:AjaxUpdatedControl ControlID="cboStaff" />
                    <telerik:AjaxUpdatedControl ControlID="txtFirstName" />
                    <telerik:AjaxUpdatedControl ControlID="txtLastName" />
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

