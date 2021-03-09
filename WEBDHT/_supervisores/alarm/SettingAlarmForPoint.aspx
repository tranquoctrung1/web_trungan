<%@ Page Language="C#"  MasterPageFile="~/_supervisores/master_page.master" AutoEventWireup="true" CodeFile="SettingAlarmForPoint.aspx.cs" Inherits="_supervisores_alarm_SettingAlarmForPoint" %>


<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="Server">
    <link href="../../css/Config.css" rel="stylesheet">
    <script type="text/javascript">

        function btnDelete_Clicked() {
            var win = $find('<%=winConfirmDelete.ClientID %>');
            win.show();
        }
        function btnCancel_Clicked() {
            var win = $find('<%=winConfirmDelete.ClientID %>');
            win.close();
        }

        // preventing resubmition form application
        window.history.replaceState('', '', window.location.href)
    </script>
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="Server">
    <div id="main-content2">
        <div id="main-content-title">
            <h2 class="title">Cài Đặt Cảnh Báo Cho Point</h2>
        </div>
        <div class="container-fluid m-t">
            <div class="row">
                <div class="col-sm-6">
                    <div class="group-text">
                        <div class="row">
                            <span>Cấp Độ</span>
                        </div>
                        <div class="row m-b">
                            <telerik:RadComboBox ID="cboLevel" runat="server" AllowCustomText="True"
                                EnableLoadOnDemand="True" Filter="StartsWith"
                                HighlightTemplatedItems="True" DataSourceID="LevelDataSource"
                                AutoPostBack="True" DataTextField="Level" DataValueField="Level"
                                OnSelectedIndexChanged="cboLevel_SelectedIndexChanged"
                                TabIndex="1">
                            </telerik:RadComboBox>
                            <asp:ObjectDataSource ID="LevelDataSource" runat="server"
                                OldValuesParameterFormatString="original_{0}" SelectMethod="GetLevelAlarms"
                                TypeName="LevelAlarmBLL"></asp:ObjectDataSource>
                        </div>
                    </div>

                </div>
                <div class="col-sm-6">
                    <div class="group-text">
                        <div class="row">
                            <span>Giá Trị</span>
                        </div>
                        <div class="row m-b">
                            <telerik:RadNumericTextBox RenderMode="Lightweight" runat="server" ID="txtValue"
                                Width="190px" Value="0"  MinValue="0"
                                ShowSpinButtons="true">
                            </telerik:RadNumericTextBox>
                        </div>
                    </div>
                </div>
                <div class="text-center col-sm-12 m-t m-b no-padding" style="clear: both;">
                    <asp:Button ID="btnUpdate" runat="server" Text="Thêm/Sửa"
                        OnClick="btnUpdate_Click" CssClass="btn btn-success"></asp:Button>
                     <asp:Button ID="btnDelete" runat="server" AutoPostBack="false"
                        OnClientClick="btnDelete_Clicked()" Text="Xóa"
                        CssClass="btn btn-danger"></asp:Button>
                </div>
            </div>
        </div>
        <telerik:RadWindow ID="winConfirmDelete" runat="server" Modal="True"
        VisibleStatusbar="False" Height="160">
        <ContentTemplate>
            <table width="100%" style="text-align: center">
                <tr>
                    <td>Bạn có muốn xóa quận không?
                    </td>
                </tr>
                <tr>
                    <td>&nbsp</td>
                </tr>
                <tr>
                    <td>
                        <asp:Button ID="btnConfim" runat="server" Text="Xóa"
                            OnClick="btnConfim_Click" CssClass="btn btn-danger"></asp:Button>
                        <asp:Button ID="btnCancel" runat="server"
                            OnClientClick="btnCancel_Clicked()" CssClass="btn btn-success"
                            Text="Hủy thao tác" AutoPostBack="False"></asp:Button>
                    </td>
                </tr>
            </table>
        </ContentTemplate>
    </telerik:RadWindow>
        <telerik:RadNotification ID="ntf" runat="server" Title="Message">
        </telerik:RadNotification>
        <telerik:RadAjaxManagerProxy ID="RadAjaxManagerProxy1" runat="server">
            <AjaxSettings>
                <telerik:AjaxSetting AjaxControlID="cboLevel">
                    <UpdatedControls>
                        <telerik:AjaxUpdatedControl ControlID="txtValue" />
                    </UpdatedControls>
                </telerik:AjaxSetting>
                <telerik:AjaxSetting AjaxControlID="btnUpdate">
                    <UpdatedControls>
                        <telerik:AjaxUpdatedControl ControlID="ntf" />
                        <telerik:AjaxUpdatedControl ControlID="txtValue" />
                        <telerik:AjaxUpdatedControl ControlID="cboLevel" />
                    </UpdatedControls>
                </telerik:AjaxSetting>
                <telerik:AjaxSetting AjaxControlID="btnDelete">
                    <UpdatedControls>
                        <telerik:AjaxUpdatedControl ControlID="ntf" />
                    </UpdatedControls>
                </telerik:AjaxSetting>
            </AjaxSettings>
        </telerik:RadAjaxManagerProxy>
        <%--<script src="https://cdn.jsdelivr.net/npm/axios/dist/axios.min.js"></script>--%>
</asp:Content>
