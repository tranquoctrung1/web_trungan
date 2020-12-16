<%@ Page Title="" Language="C#" MasterPageFile="~/_supervisor/master_page.master" AutoEventWireup="true" CodeFile="meter.aspx.cs" Inherits="_supervisor_device_meter" %>

<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="Server">
    <link href="../../css/Config.css" rel="stylesheet" >

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
            <h2 class="title">Đồng hồ</h2>
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
                            AutoPostBack="True" TabIndex="1" AccessKey="S">
                           </telerik:RadComboBox>
                           <asp:ObjectDataSource ID="SerialsDataSource" runat="server"
                            OldValuesParameterFormatString="original_{0}" SelectMethod="GetAllSerials"
                            TypeName="MetersBLL">
                           </asp:ObjectDataSource>
                        </div>
                      </div>

                    <div class="group-text">
                        <div class="row">
                            <span>Mã đồng hồ</span>
                        </div>
                        <div class="row m-b">
                             <telerik:RadTextBox ID="txtApprovalDecision" runat="server" CssClass="form-control">
                             </telerik:RadTextBox>
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
                                TypeName="MetersBLL"></asp:ObjectDataSource>
                        </div>
                     </div>
                    <div class="group-text">
                        <div class="row">
                            <span>Quốc gia sản xuất</span>
                        </div>
                        <div class="row m-b">
                             <telerik:RadComboBox ID="cboNationalities" runat="server" DataSourceID="NationalitiesDataSource" AllowCustomText="True" HighlightTemplatedItems="True">
                            </telerik:RadComboBox>
                            <asp:ObjectDataSource ID="NationalitiesDataSource" runat="server" OldValuesParameterFormatString="original_{0}"
                                SelectMethod="GetAllNationalities"
                                TypeName="MetersBLL"></asp:ObjectDataSource>
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
                            TypeName="MetersBLL"></asp:ObjectDataSource>
                        </div>
                    </div>
                    <div class="group-text">
                        <div class="row">
                            <span>Cỡ</span>
                        </div>
                        <div class="row m-b">
                             <telerik:RadComboBox ID="cboSizes" runat="server" AllowCustomText="True"
                                EnableLoadOnDemand="True" Filter="StartsWith"
                                HighlightTemplatedItems="True" DataSourceID="SizesDataSource" TabIndex="5">
                            </telerik:RadComboBox>
                            <asp:ObjectDataSource ID="SizesDataSource" runat="server"
                                OldValuesParameterFormatString="original_{0}" SelectMethod="GetAllSizes"
                                TypeName="MetersBLL"></asp:ObjectDataSource>
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
                                TabIndex="6">
                            </telerik:RadComboBox>
                            <asp:ObjectDataSource ID="ModelsDataSource" runat="server"
                                OldValuesParameterFormatString="original_{0}" SelectMethod="GetAllModels"
                                TypeName="MetersBLL"></asp:ObjectDataSource>
                        </div>
                     </div>
                    <div class="group-text">
                        <div class="row">
                            <span>Tình trạng</span>
                        </div>
                        <div class="row m-b">
                            <telerik:RadComboBox ID="cboStatus" runat="server" AllowCustomText="True"
                                EnableLoadOnDemand="True" Filter="StartsWith"
                                HighlightTemplatedItems="True" DataSourceID="DeviceStatusDataSource"
                                DataTextField="Status" DataValueField="Status" TabIndex="7">
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
                     </div>
                     <div class="group-text">
                        <div class="row">
                            <span>Chỉ số khách hàng</span>
                        </div>
                        <div class="row m-b">
                            <div class="col-sm-6 no-padding">
                                <telerik:RadNumericTextBox ID="nmrIndex" runat="server" TabIndex="9">
                                    <NumberFormat DecimalDigits="0" ZeroPattern="n" />
                                </telerik:RadNumericTextBox>
                            </div>
                            <div class="col-sm-6 no-padding">
                                <div class="checkbox checkbox-info chkMobile" style="margin: 8px 10px;">
                                    <asp:CheckBox ID="chkInstalled" runat="server" Text="Lắp đặt" />
                                 </div>
                            </div>
                        </div>
                    </div>
                     
                </div>
                 <div class="col-sm-6">
                     <div class="group-text">
                        <div class="row">
                            <span>Ngày phê duyệt</span>
                        </div>
                        <div class="row m-b">
                            <div class="col-sm-6 no-padding">
                             <telerik:RadDatePicker ID="dtmApproved" runat="server" Culture="en-GB">
                                <Calendar UseRowHeadersAsSelectors="False" UseColumnHeadersAsSelectors="False" ViewSelectorText="x"></Calendar>

                                <DateInput DisplayDateFormat="dd/MM/yyyy" DateFormat="dd/MM/yyyy"
                                    LabelWidth="40%">
                                </DateInput>

                                <DatePopupButton ImageUrl="" HoverImageUrl=""></DatePopupButton>
                            </telerik:RadDatePicker>
                            </div>
                            <div class="col-sm-6 no-padding">
                                <div class="checkbox checkbox-info chkMobile" style="margin: 8px 5px;">
                                <asp:CheckBox ID="chkApproved" runat="server" Text="Đã phê duyệt" />
                             </div>
                            </div>
                        </div>
                     </div>
                      <div class="group-text">
                        <div class="row">
                            <span>Ngày nhập kho</span>
                        </div>
                        <div class="row m-b">
                            <telerik:RadDatePicker ID="dtmReceipt" runat="server" Culture="en-GB">
                                <Calendar UseRowHeadersAsSelectors="False" UseColumnHeadersAsSelectors="False" ViewSelectorText="x"></Calendar>

                                <DateInput DisplayDateFormat="dd/MM/yyyy" DateFormat="dd/MM/yyyy" EnableSingleInputRendering="True"
                                    LabelWidth="40%">
                                </DateInput>

                                <DatePopupButton ImageUrl="" HoverImageUrl=""></DatePopupButton>
                            </telerik:RadDatePicker>
                        </div>
                      </div>
                     <div class="group-text">
                        <div class="row">
                            <span>Ngày kiểm định</span>
                        </div>
                        <div class="row m-b">
                             <telerik:RadDatePicker ID="dtmAccredited" runat="server" Culture="en-GB">
                                <Calendar UseRowHeadersAsSelectors="False" UseColumnHeadersAsSelectors="False" ViewSelectorText="x"></Calendar>

                                <DateInput DisplayDateFormat="dd/MM/yyyy" DateFormat="dd/MM/yyyy" EnableSingleInputRendering="True"
                                    LabelWidth="40%">
                                </DateInput>

                                <DatePopupButton ImageUrl="" HoverImageUrl=""></DatePopupButton>
                            </telerik:RadDatePicker>
                        </div>
                     </div>
                     <div class="group-text">
                        <div class="row">
                            <span>Ngày hết hiệu lực kiểm định</span>
                        </div>
                        <div class="row m-b">
                             <telerik:RadDatePicker ID="dtmExpiry" runat="server" Culture="en-GB">
                                <Calendar UseRowHeadersAsSelectors="False" UseColumnHeadersAsSelectors="False" ViewSelectorText="x"></Calendar>

                                <DateInput DisplayDateFormat="dd/MM/yyyy" DateFormat="dd/MM/yyyy" EnableSingleInputRendering="True"
                                    LabelWidth="40%">
                                </DateInput>

                                <DatePopupButton ImageUrl="" HoverImageUrl=""></DatePopupButton>
                            </telerik:RadDatePicker>
                        </div>
                     </div>
                     <div class="group-text">
                        <div class="row">
                            <span>Loại kiểm định</span>
                        </div>
                        <div class="row m-b">
                              <telerik:RadComboBox ID="cboAccreditationTypes" runat="server" AllowCustomText="True"
                                EnableLoadOnDemand="True" Filter="StartsWith"
                                HighlightTemplatedItems="True" DataSourceID="AccreditationTypesDataSource"
                                DataTextField="AccreditationType" DataValueField="AccreditationType"
                                TabIndex="16">
                                <HeaderTemplate>
                                    <table cellpadding="0" cellspacing="0">
                                        <tr>
                                            <td style="width: 50px">Loại</td>
                                            <td style="width: 110px">Mô tả</td>
                                        </tr>
                                    </table>
                                </HeaderTemplate>
                                <ItemTemplate>
                                    <table cellpadding="0" cellspacing="0">
                                        <tr>
                                            <td style="width: 50px"><%#DataBinder.Eval(Container.DataItem,"AccreditationType") %></td>
                                            <td style="width: 110px"><%#DataBinder.Eval(Container.DataItem,"Description") %></td>
                                        </tr>
                                    </table>
                                </ItemTemplate>
                            </telerik:RadComboBox>
                            <asp:ObjectDataSource ID="AccreditationTypesDataSource" runat="server"
                                OldValuesParameterFormatString="original_{0}" SelectMethod="GetAll"
                                TypeName="MeterAccreditationTypesBLL"></asp:ObjectDataSource>
                        </div>
                     </div>
                      <div class="group-text">
                        <div class="row">
                            <span>Giấy kiểm định</span>
                        </div>
                        <div class="row m-b">
                             <telerik:RadTextBox ID="txtAccreditationDocument" runat="server" CssClass="form-control">
                             </telerik:RadTextBox>
                        </div>
                      </div>
                     <div class="group-text">
                        <div class="row">
                            <span>Serial bộ hiển thị</span>
                        </div>
                        <div class="row m-b">
                            <telerik:RadComboBox ID="cboTransmitters" runat="server"
                                AllowCustomText="True" AutoPostBack="True"
                                DataSourceID="TransmittersDataSource" EnableLoadOnDemand="True"
                                Filter="StartsWith" HighlightTemplatedItems="True"
                                OnSelectedIndexChanged="cboSerials_SelectedIndexChanged" TabIndex="18">
                            </telerik:RadComboBox>
                            <asp:ObjectDataSource ID="TransmittersDataSource" runat="server"
                                OldValuesParameterFormatString="original_{0}" SelectMethod="GetAllSerials"
                                TypeName="TransmittersBLL"></asp:ObjectDataSource>
                        </div>
                      </div>
                     <div class="group-text">
                        <div class="row">
                            <span>Upload giấy kiểm định</span>
                        </div>
                        <div class="row m-b">
                            <div class="col-sm-6 no-padding">
                             <telerik:RadAsyncUpload ID="asyncUpload" runat="server" Width="200px"
                                OnFileUploaded="asyncUpload_FileUploaded" MultipleFileSelection="Automatic"
                                TargetFolder="~/App_Data/files/meter/" TabIndex="19">
                            </telerik:RadAsyncUpload>
                            </div>
                            <div class="col-sm-6" style="padding-left: 8px;">
                            <asp:Button ID="btnUpload" runat="server" Text="Upload"
                                OnClick="btnUpload_Click" CssClass="btn btn-primary"></asp:Button>
                            <asp:Button ID="btnDownload" runat="server"
                                Text="Download" OnClick="btnDownload_Click" CssClass="btn btn-success"></asp:Button>
                            </div>
                            </div>
                     </div>
                     <div class="group-text">
                        <div class="row">
                            <span>Ghi chú</span>
                        </div>
                        <div class="row m-b">
                             <telerik:RadTextBox ID="txtDescription" runat="server" Height="50px"
                                TabIndex="10" TextMode="MultiLine">
                            </telerik:RadTextBox>
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
    <telerik:RadWindowManager ID="RadWindowManager1" runat="server">
        <Windows>
            <telerik:RadWindow ID="winConfirmDelete" runat="server" Modal="True"
                VisibleStatusbar="False" Height="120">
                <ContentTemplate>
                    <table cellpadding="5" style="text-align: center; width: 100%">
                        <tr>
                            <td>Bạn có muốn xóa dữ liệu đồng hồ không?
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
            <telerik:AjaxSetting AjaxControlID="cboSerials">
                <UpdatedControls>
                    <telerik:AjaxUpdatedControl ControlID="cboSerials" />
                    <telerik:AjaxUpdatedControl ControlID="dtmApproved" />
                    <telerik:AjaxUpdatedControl ControlID="txtApprovalDecision" />
                    <telerik:AjaxUpdatedControl ControlID="dtmReceipt" />
                    <telerik:AjaxUpdatedControl ControlID="cboProviders" />
                    <telerik:AjaxUpdatedControl ControlID="chkApproved" />
                    <telerik:AjaxUpdatedControl ControlID="cboNationalities" />
                    <telerik:AjaxUpdatedControl ControlID="cboMarks" />
                    <telerik:AjaxUpdatedControl ControlID="dtmAccredited" />
                    <telerik:AjaxUpdatedControl ControlID="cboSizes" />
                    <telerik:AjaxUpdatedControl ControlID="dtmExpiry" />
                    <telerik:AjaxUpdatedControl ControlID="cboModels" />
                    <telerik:AjaxUpdatedControl ControlID="cboStatus" />
                    <telerik:AjaxUpdatedControl ControlID="cboAccreditationTypes" />
                    <telerik:AjaxUpdatedControl ControlID="txtAccreditationDocument" />
                    <telerik:AjaxUpdatedControl ControlID="cboTransmitters" />
                    <telerik:AjaxUpdatedControl ControlID="chkInstalled" />
                    <telerik:AjaxUpdatedControl ControlID="nmrIndex" />
                    <telerik:AjaxUpdatedControl ControlID="txtDescription" />
                    <telerik:AjaxUpdatedControl ControlID="btnUpload" />
                    <telerik:AjaxUpdatedControl ControlID="btnDownload" />
                </UpdatedControls>
            </telerik:AjaxSetting>
            <telerik:AjaxSetting AjaxControlID="btnAdd">
                <UpdatedControls>
                    <telerik:AjaxUpdatedControl ControlID="ntf" />
                    <telerik:AjaxUpdatedControl ControlID="cboSerials" />
                    <telerik:AjaxUpdatedControl ControlID="dtmApproved" />
                    <telerik:AjaxUpdatedControl ControlID="txtApprovalDecision" />
                    <telerik:AjaxUpdatedControl ControlID="dtmReceipt" />
                    <telerik:AjaxUpdatedControl ControlID="cboProviders" />
                    <telerik:AjaxUpdatedControl ControlID="chkApproved" />
                    <telerik:AjaxUpdatedControl ControlID="cboNationalities" />
                    <telerik:AjaxUpdatedControl ControlID="cboMarks" />
                    <telerik:AjaxUpdatedControl ControlID="dtmAccredited" />
                    <telerik:AjaxUpdatedControl ControlID="cboSizes" />
                    <telerik:AjaxUpdatedControl ControlID="dtmExpiry" />
                    <telerik:AjaxUpdatedControl ControlID="cboModels" />
                    <telerik:AjaxUpdatedControl ControlID="cboStatus" />
                    <telerik:AjaxUpdatedControl ControlID="cboAccreditationTypes" />
                    <telerik:AjaxUpdatedControl ControlID="txtAccreditationDocument" />
                    <telerik:AjaxUpdatedControl ControlID="cboTransmitters" />
                    <telerik:AjaxUpdatedControl ControlID="chkInstalled" />
                    <telerik:AjaxUpdatedControl ControlID="nmrIndex" />
                    <telerik:AjaxUpdatedControl ControlID="txtDescription" />
                    <telerik:AjaxUpdatedControl ControlID="btnUpload" />
                    <telerik:AjaxUpdatedControl ControlID="btnDownload" />
                </UpdatedControls>
            </telerik:AjaxSetting>
            <telerik:AjaxSetting AjaxControlID="btnDelete">
                <UpdatedControls>
                    <telerik:AjaxUpdatedControl ControlID="ntf" />
                </UpdatedControls>
            </telerik:AjaxSetting>

            <%--<telerik:AjaxSetting AjaxControlID="btnConfim">
                <UpdatedControls>
                    <telerik:AjaxUpdatedControl ControlID="ntf" />
                    <telerik:AjaxUpdatedControl ControlID="cboSerials" />
                    <telerik:AjaxUpdatedControl ControlID="dtmApproved" />
                    <telerik:AjaxUpdatedControl ControlID="txtApprovalDecision" />
                    <telerik:AjaxUpdatedControl ControlID="dtmReceipt" />
                    <telerik:AjaxUpdatedControl ControlID="cboProviders" />
                    <telerik:AjaxUpdatedControl ControlID="chkApproved" />
                    <telerik:AjaxUpdatedControl ControlID="cboNationalities" />
                    <telerik:AjaxUpdatedControl ControlID="cboMarks" />
                    <telerik:AjaxUpdatedControl ControlID="dtmAccredited" />
                    <telerik:AjaxUpdatedControl ControlID="cboSizes" />
                    <telerik:AjaxUpdatedControl ControlID="dtmExpiry" />
                    <telerik:AjaxUpdatedControl ControlID="cboModels" />
                    <telerik:AjaxUpdatedControl ControlID="cboStatus" />
                    <telerik:AjaxUpdatedControl ControlID="cboAccreditationTypes" />
                    <telerik:AjaxUpdatedControl ControlID="txtAccreditationDocument" />
                    <telerik:AjaxUpdatedControl ControlID="cboTransmitters" />
                    <telerik:AjaxUpdatedControl ControlID="chkInstalled" />
                    <telerik:AjaxUpdatedControl ControlID="nmrIndex" />
                    <telerik:AjaxUpdatedControl ControlID="txtDescription" />
                    <telerik:AjaxUpdatedControl ControlID="btnUpload" />
                    <telerik:AjaxUpdatedControl ControlID="btnDownload" />
                </UpdatedControls>
            </telerik:AjaxSetting> --%>
        </AjaxSettings>
    </telerik:RadAjaxManagerProxy>


</asp:Content>

