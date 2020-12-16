<%@ Page Title="" Language="C#" MasterPageFile="~/_supervisor/master_page.master" AutoEventWireup="true" CodeFile="logger.aspx.cs" Inherits="_supervisor_device_logger" %>

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
            <h2 class="title">Logger</h2>
        </div>
        <div class="container-fluid m-t">
            <div class="row">
                <div class="col-sm-6">
                    <div class="group-text">
                        <div class="row">
                            <span>Serial</span>
                        </div>
                        <div class="row m-b">
                            <telerik:RadComboBox ID="cboSerials" runat="server" AllowCustomText="True"
                                EnableLoadOnDemand="True" Filter="StartsWith"
                                HighlightTemplatedItems="True" DataSourceID="SerialsDataSource"
                                OnSelectedIndexChanged="cboSerials_SelectedIndexChanged"
                                AutoPostBack="True" AccessKey="S" TabIndex="1">
                            </telerik:RadComboBox>
                            <asp:ObjectDataSource ID="SerialsDataSource" runat="server"
                                OldValuesParameterFormatString="original_{0}" SelectMethod="GetAllSerials"
                                TypeName="TransmittersBLL"></asp:ObjectDataSource>
                        </div>
                    </div>

                    <div class="group-text">
                        <div class="row">
                            <span>Nhà sản xuất</span>
                        </div>
                        <div class="row m-b">
                            <telerik:RadComboBox ID="cboProviders" runat="server" AllowCustomText="True"
                                EnableLoadOnDemand="True" Filter="StartsWith"
                                HighlightTemplatedItems="True" DataSourceID="ProvidersDataSource"
                                TabIndex="3">
                            </telerik:RadComboBox>
                            <asp:ObjectDataSource ID="ProvidersDataSource" runat="server"
                                OldValuesParameterFormatString="original_{0}" SelectMethod="GetAllProviders"
                                TypeName="LoggersBLL"></asp:ObjectDataSource>
                        </div>
                    </div>

                    <div class="group-text">
                        <div class="row">
                            <span>Model</span>
                        </div>
                        <div class="row m-b">
                            <telerik:RadComboBox ID="cboModels" runat="server" AllowCustomText="True"
                                EnableLoadOnDemand="True" Filter="StartsWith"
                                HighlightTemplatedItems="True" DataSourceID="ModelsDataSource"
                                TabIndex="5">
                            </telerik:RadComboBox>
                            <asp:ObjectDataSource ID="ModelsDataSource" runat="server"
                                OldValuesParameterFormatString="original_{0}" SelectMethod="GetAllModels"
                                TypeName="LoggersBLL"></asp:ObjectDataSource>
                        </div>
                    </div>

                    <div class="group-text">
                        <div class="row">
                            <span>Ghi chú</span>
                        </div>
                        <div class="row m-b">
                            <telerik:RadTextBox ID="txtDescription" runat="server" Height="50px"
                                TextMode="MultiLine" TabIndex="8" Style="top: 0px; left: 0px">
                            </telerik:RadTextBox>
                        </div>
                    </div>
                </div>
                <div class="col-sm-6">

                    <div class="group-text">
                        <div class="row">
                            <span>Ngày nhập kho</span>
                        </div>
                        <div class="row m-b">
                            <telerik:RadDatePicker ID="dtmReceipt" runat="server" Culture="en-GB"
                                TabIndex="2">
                                <Calendar UseRowHeadersAsSelectors="False" UseColumnHeadersAsSelectors="False" ViewSelectorText="x"></Calendar>

                                <DateInput DisplayDateFormat="dd/MM/yyyy" DateFormat="dd/MM/yyyy" EnableSingleInputRendering="True"
                                    LabelWidth="64px" TabIndex="2">
                                </DateInput>

                                <DatePopupButton ImageUrl="" HoverImageUrl="" TabIndex="-1"></DatePopupButton>
                            </telerik:RadDatePicker>
                        </div>
                    </div>

                    <div class="group-text">
                        <div class="row">
                            <span>Hiệu</span>
                        </div>
                        <div class="row m-b">
                            <telerik:RadComboBox ID="cboMarks" runat="server" AllowCustomText="True"
                                EnableLoadOnDemand="True" Filter="StartsWith"
                                HighlightTemplatedItems="True" DataSourceID="MarksDataSource" TabIndex="4">
                            </telerik:RadComboBox>
                            <asp:ObjectDataSource ID="MarksDataSource" runat="server"
                                OldValuesParameterFormatString="original_{0}" SelectMethod="GetAllMarks"
                                TypeName="LoggersBLL"></asp:ObjectDataSource>
                        </div>
                    </div>

                    <div class="group-text">
                        <div class="row">
                            <span>Tình trạng</span>
                        </div>
                        <div class="row m-b">
                            <div class="col-sm-6 no-padding">
                                <telerik:RadComboBox ID="cboStatus" runat="server" AllowCustomText="True"
                                    EnableLoadOnDemand="True" Filter="StartsWith"
                                    HighlightTemplatedItems="True" DataSourceID="DeviceStatusDataSource"
                                    DataTextField="Status" DataValueField="Status" TabIndex="6">
                                    <HeaderTemplate>
                                        <table cellpadding="0" cellspacing="0">
                                            <tr>
                                                <td style="width: 80px">Tình trạng</td>
                                                <td style="width: 80px">Mô tả</td>
                                            </tr>
                                        </table>
                                    </HeaderTemplate>
                                    <ItemTemplate>
                                        <table cellpadding="0" cellspacing="0">
                                            <tr>
                                                <td style="width: 80px"><%#DataBinder.Eval(Container.DataItem,"Status") %></td>
                                                <td style="width: 80px"><%#DataBinder.Eval(Container.DataItem,"Description") %></td>
                                            </tr>
                                        </table>
                                    </ItemTemplate>
                                </telerik:RadComboBox>
                                <asp:ObjectDataSource ID="DeviceStatusDataSource" runat="server"
                                    OldValuesParameterFormatString="original_{0}" SelectMethod="GetAll"
                                    TypeName="DeviceStatusBLL"></asp:ObjectDataSource>
                            </div>
                            <div class="col-sm-6 no-padding">
                                <div class="checkbox checkbox-info chkMobile" style="margin: 8px 5px;">
                                    <asp:CheckBox ID="chkInstalled" runat="server" Text="lắp đặt" />
                                </div>
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
    </div>
    <telerik:RadNotification ID="ntf" runat="server" Title="Message"></telerik:RadNotification>
    <telerik:RadWindowManager ID="RadWindowManager1" runat="server">
        <Windows>
            <telerik:RadWindow ID="winConfirmDelete" runat="server" Modal="True"
                VisibleStatusbar="False" Height="120">
                <ContentTemplate>
                    <table cellpadding="5" style="text-align: center; width: 100%">
                        <tr>
                            <td>Bạn có muốn xóa dữ liệu logger không?
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
    <telerik:RadAjaxManagerProxy ID="RadAjaxManagerProxy1" runat="server">
        <AjaxSettings>
            <telerik:AjaxSetting AjaxControlID="cboSerials">
                <UpdatedControls>
                    <telerik:AjaxUpdatedControl ControlID="cboSerials" />
                    <telerik:AjaxUpdatedControl ControlID="dtmReceipt" />
                    <telerik:AjaxUpdatedControl ControlID="cboProviders" />
                    <telerik:AjaxUpdatedControl ControlID="cboMarks" />
                    <telerik:AjaxUpdatedControl ControlID="cboModels" />
                    <telerik:AjaxUpdatedControl ControlID="cboStatus" />
                    <telerik:AjaxUpdatedControl ControlID="chkInstalled" />
                    <telerik:AjaxUpdatedControl ControlID="txtDescription" />
                </UpdatedControls>
            </telerik:AjaxSetting>
            <telerik:AjaxSetting AjaxControlID="btnAdd">
                <UpdatedControls>
                    <telerik:AjaxUpdatedControl ControlID="ntf" />
                    <telerik:AjaxUpdatedControl ControlID="cboSerials" />
                    <telerik:AjaxUpdatedControl ControlID="dtmReceipt" />
                    <telerik:AjaxUpdatedControl ControlID="cboProviders" />
                    <telerik:AjaxUpdatedControl ControlID="cboMarks" />
                    <telerik:AjaxUpdatedControl ControlID="cboModels" />
                    <telerik:AjaxUpdatedControl ControlID="cboStatus" />
                    <telerik:AjaxUpdatedControl ControlID="chkInstalled" />
                    <telerik:AjaxUpdatedControl ControlID="txtDescription" />
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

