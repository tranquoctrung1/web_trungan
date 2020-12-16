<%@ Page Title="" Language="C#" MasterPageFile="~/_supervisor/master_page.master" AutoEventWireup="true" CodeFile="cover.aspx.cs" Inherits="_supervisor_device_cover" %>

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

        // preventing resubmition form application
        window.history.replaceState('', '', window.location.href)
//]]>
    </script>
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="Server">
    <div id="main-content2">
        <div id="main-content-title">
            <h2 class="title">Nắp hầm</h2>
        </div>
        <div class="container-fluid m-t">
            <div class="col-sm-6">
                <div class="group-text">
                    <div class="row">
                        <span>Mã nắp hầm</span>
                    </div>
                    <div class="row m-b">
                        <telerik:RadComboBox ID="cboCoverIDs" runat="server" AllowCustomText="True"
                            EnableLoadOnDemand="True" Filter="StartsWith"
                            HighlightTemplatedItems="True" DataSourceID="CoverIDsDataSource"
                            OnSelectedIndexChanged="cboSerials_SelectedIndexChanged"
                            AutoPostBack="True" TabIndex="1">
                        </telerik:RadComboBox>
                        <asp:ObjectDataSource ID="CoverIDsDataSource" runat="server"
                            OldValuesParameterFormatString="original_{0}" SelectMethod="GetAllCoverIDs"
                            TypeName="SiteCoversBLL"></asp:ObjectDataSource>
                    </div>
                </div>

                <div class="group-text">
                    <div class="row">
                        <span>Số tấm</span>
                    </div>
                    <div class="row m-b">
                        <telerik:RadComboBox ID="cboCoverNL" runat="server" AllowCustomText="True"
                            EnableLoadOnDemand="True" Filter="StartsWith"
                            HighlightTemplatedItems="True" DataSourceID="CoverNLsDataSource" TabIndex="3">
                        </telerik:RadComboBox>
                        <asp:ObjectDataSource ID="CoverNLsDataSource" runat="server"
                            OldValuesParameterFormatString="original_{0}" SelectMethod="GetAllCoverNLs"
                            TypeName="SiteCoversBLL"></asp:ObjectDataSource>
                    </div>
                </div>


                <div class="group-text">
                    <div class="row">
                        <span>Rộng</span>
                    </div>
                    <div class="row m-b">
                        <telerik:RadComboBox ID="cboCoverW" runat="server" AllowCustomText="True"
                            EnableLoadOnDemand="True" Filter="StartsWith"
                            HighlightTemplatedItems="True" DataSourceID="CoverWsDataSource" TabIndex="5">
                        </telerik:RadComboBox>
                        <asp:ObjectDataSource ID="CoverWsDataSource" runat="server"
                            OldValuesParameterFormatString="original_{0}" SelectMethod="GetAllCoverWs"
                            TypeName="SiteCoversBLL"></asp:ObjectDataSource>
                    </div>
                </div>
            </div>
            <div class="col-sm-6">

                <div class="group-text">
                    <div class="row">
                        <span>Vật liệu</span>
                    </div>
                    <div class="row m-b">
                        <telerik:RadComboBox ID="cboMaterials" runat="server" AllowCustomText="True"
                            EnableLoadOnDemand="True" Filter="StartsWith"
                            HighlightTemplatedItems="True" DataSourceID="CoverMaterialsDataSource" TabIndex="2">
                        </telerik:RadComboBox>
                        <asp:ObjectDataSource ID="CoverMaterialsDataSource" runat="server"
                            OldValuesParameterFormatString="original_{0}"
                            SelectMethod="GetAllCoverMaterials" TypeName="SiteCoversBLL"></asp:ObjectDataSource>
                    </div>
                </div>

                <div class="group-text">
                    <div class="row">
                        <span>Dài</span>
                    </div>
                    <div class="row m-b">
                        <telerik:RadComboBox ID="cboCoverL" runat="server" AllowCustomText="True"
                            EnableLoadOnDemand="True" Filter="StartsWith"
                            HighlightTemplatedItems="True" DataSourceID="CoverLsDataSource" TabIndex="4">
                        </telerik:RadComboBox>
                        <asp:ObjectDataSource ID="CoverLsDataSource" runat="server"
                            OldValuesParameterFormatString="original_{0}" SelectMethod="GetAllCoverLs"
                            TypeName="SiteCoversBLL"></asp:ObjectDataSource>
                    </div>
                </div>

                <div class="group-text">
                    <div class="row">
                        <span>Cao</span>
                    </div>
                    <div class="row m-b">
                        <telerik:RadComboBox ID="cboCoverH" runat="server" AllowCustomText="True"
                            EnableLoadOnDemand="True" Filter="StartsWith"
                            HighlightTemplatedItems="True" DataSourceID="CoverHsDataSource" TabIndex="6">
                        </telerik:RadComboBox>
                        <asp:ObjectDataSource ID="CoverHsDataSource" runat="server"
                            OldValuesParameterFormatString="original_{0}" SelectMethod="GetAllCoverHs"
                            TypeName="SiteCoversBLL"></asp:ObjectDataSource>
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
    <telerik:RadWindowManager ID="RadWindowManager1" runat="server">
        <Windows>
            <telerik:RadWindow ID="winConfirmDelete" runat="server" Modal="True"
                VisibleStatusbar="False" Height="120">
                <ContentTemplate>
                    <table cellpadding="5" style="text-align: center; width: 100%">
                        <tr>
                            <td>Bạn có muốn xóa dữ liệu nắp hầm không?
                            </td>
                        </tr>
                        <tr>
                            <td>
                                <asp:Button ID="btnConfim" runat="server" OnClick="btnConfim_Click" Text="Xóa" CssClass="btn btn-danger"></asp:Button>
                                <asp:Button ID="btnCancel" runat="server"
                                    OnClientClick="btnCancel_Clicked()"
                                    Text="Hủy thao tác" AutoPostBack="False" CssClass="btn btn-success"></asp:Button>
                            </td>
                        </tr>
                    </table>
                </ContentTemplate>
            </telerik:RadWindow>
        </Windows>
    </telerik:RadWindowManager>
    <telerik:RadNotification ID="ntf" runat="server" Title="Message">
    </telerik:RadNotification>
    <telerik:RadAjaxManagerProxy ID="RadAjaxManagerProxy1" runat="server">
        <AjaxSettings>
            <telerik:AjaxSetting AjaxControlID="cboCoverIDs">
                <UpdatedControls>
                    <telerik:AjaxUpdatedControl ControlID="cboSerials" />
                    <telerik:AjaxUpdatedControl ControlID="cboMaterials" />
                    <telerik:AjaxUpdatedControl ControlID="cboCoverNL" />
                    <telerik:AjaxUpdatedControl ControlID="cboCoverL" />
                    <telerik:AjaxUpdatedControl ControlID="cboCoverW" />
                    <telerik:AjaxUpdatedControl ControlID="cboCoverH" />
                </UpdatedControls>
            </telerik:AjaxSetting>
            <telerik:AjaxSetting AjaxControlID="btnAdd">
                <UpdatedControls>
                    <telerik:AjaxUpdatedControl ControlID="ntf" />
                    <telerik:AjaxUpdatedControl ControlID="cboSerials" />
                    <telerik:AjaxUpdatedControl ControlID="cboMaterials" />
                    <telerik:AjaxUpdatedControl ControlID="cboCoverNL" />
                    <telerik:AjaxUpdatedControl ControlID="cboCoverL" />
                    <telerik:AjaxUpdatedControl ControlID="cboCoverW" />
                    <telerik:AjaxUpdatedControl ControlID="cboCoverH" />
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

