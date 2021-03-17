<%@ Page Title="" Language="C#" MasterPageFile="~/_supervisor/master_page.master" AutoEventWireup="true" CodeFile="info.aspx.cs" Inherits="_supervisor_site_info" %>

<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="Server">
    <link href="../../css/Config.css" rel="stylesheet">
    <link href="../../css/leaflet/leaflet.1.6.0.css" rel="stylesheet" />
    <link href="../../css/leaflet/context-menu.min.css" rel="stylesheet" />

    <script src="../../js/leaflet/leaflet.1.6.0.js"></script>
    <script src="../../js/leaflet/context-menu.js"></script>
    <script src="../../js/leaflet/kmllayer.js"></script>


    <style>
        .ruButton {
            height: 33px !important;
        }

        .change-height {
            height: 55px !important;
            display: flex;
            align-items: center;
        }
        #showMap 
        {
            cursor: pointer
        }


        #map.show {
            height: 300px;
        }
        #map.hide {
            height: 0px;
        }

    </style>
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
    <script type="text/javascript" id="telerikClientEvents2">
        //<![CDATA[

        function btnDownload_Clicked(sender, args) {
            //Add JavaScript handler code here
        }
//]]>
    </script>
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="Server">
    <div id="main-content2">
        <div id="main-content-title">
            <h2 class="title">Điểm lắp đặt</h2>
        </div>
        <div class="container-fluid m-t">
            <div class="row">
                <div class="col-sm-4">
                    <div class="group-text">
                        <div class="row">
                            <span>Mã point</span>
                        </div>
                        <div class="row m-b">
                            <telerik:RadComboBox ID="cboIds" runat="server" AllowCustomText="True"
                                EnableLoadOnDemand="True" Filter="StartsWith"
                                HighlightTemplatedItems="True" DataSourceID="IdsDataSource" DataTextField="Id" DataValueField="Id"
                                AutoPostBack="True" OnSelectedIndexChanged="cboIds_SelectedIndexChanged"
                                TabIndex="1">
                                <HeaderTemplate>
                                    <table cellpadding="0" cellspacing="0">
                                        <tr>
                                            <td style="width: 75px">Id</td>
                                            <td style="width: 175px">Tên point</td>
                                        </tr>
                                    </table>
                                </HeaderTemplate>
                                <ItemTemplate>
                                    <table cellpadding="0" cellspacing="0">
                                        <tr>
                                            <td style="width: 75px">
                                                <%#DataBinder.Eval(Container.DataItem,"Id") %>
                                            </td>
                                            <td style="width: 175px">
                                                <%#DataBinder.Eval(Container.DataItem,"Location") %>
                                            </td>
                                        </tr>
                                    </table>
                                </ItemTemplate>
                            </telerik:RadComboBox>
                            <asp:ObjectDataSource ID="IdsDataSource" runat="server"
                                OldValuesParameterFormatString="original_{0}" SelectMethod="GetAll"
                                TypeName="SitesBLL"></asp:ObjectDataSource>
                        </div>
                    </div>
                    <div class="group-text">
                        <div class="row">
                            <span>Tên point</span>
                        </div>
                        <div class="row m-b">
                            <telerik:RadTextBox ID="txtLocation" runat="server" Height="50px"
                                TextMode="MultiLine" TabIndex="3">
                            </telerik:RadTextBox>
                        </div>
                    </div>
                    <div class="group-text">
                        <div class="row">
                            <span>Địa chỉ</span>
                        </div>
                        <div class="row m-b">
                            <telerik:RadTextBox ID="txtAddress" runat="server" Height="50px" TabIndex="3"
                                TextMode="MultiLine">
                            </telerik:RadTextBox>
                        </div>
                    </div>
                    <div class="group-text">
                        <div class="row">
                            <span>Đồng hồ</span>
                        </div>
                        <div class="row m-b">
                            <telerik:RadComboBox ID="cboMeters" runat="server" AllowCustomText="True"
                                DataSourceID="MetersDataSource" DataTextField="Serial" DataValueField="Serial"
                                DropDownWidth="300px" EnableLoadOnDemand="True" Filter="StartsWith"
                                HighlightTemplatedItems="True" TabIndex="8">
                                <HeaderTemplate>
                                    <table cellpadding="0" cellspacing="0">
                                        <tr>
                                            <td style="width: 175px">Serial</td>
                                            <td style="width: 75px">Hiệu</td>
                                            <td style="width: 50px">Cỡ</td>
                                        </tr>
                                    </table>
                                </HeaderTemplate>
                                <ItemTemplate>
                                    <table cellpadding="0" cellspacing="0">
                                        <tr>
                                            <td style="width: 175px">
                                                <%#DataBinder.Eval(Container.DataItem,"Serial") %>
                                            </td>
                                            <td style="width: 75px">
                                                <%#DataBinder.Eval(Container.DataItem,"Marks") %>
                                            </td>
                                            <td style="width: 50px">
                                                <%#DataBinder.Eval(Container.DataItem,"Size") %>
                                            </td>
                                        </tr>
                                    </table>
                                </ItemTemplate>
                            </telerik:RadComboBox>
                            <asp:ObjectDataSource ID="MetersDataSource" runat="server"
                                OldValuesParameterFormatString="original_{0}" SelectMethod="GetAllByInstalled"
                                TypeName="MetersBLL">
                                <SelectParameters>
                                    <asp:Parameter DefaultValue="false" Name="installed" Type="Boolean" />
                                </SelectParameters>
                            </asp:ObjectDataSource>
                        </div>
                    </div>

                    <div class="group-text">
                        <div class="row">
                            <span>Giấy kiểm định đồng hồ</span>
                        </div>
                        <div class="row m-b">
                            <telerik:RadTextBox ID="txtAccreditationDocument" runat="server">
                            </telerik:RadTextBox>
                        </div>
                    </div>

                    <div class="group-text">
                        <div class="row">
                            <span>Ngày hết hạn kiểm định đồng hồ</span>
                        </div>
                        <div class="row m-b">
                            <telerik:RadDatePicker ID="dtmExpiry" runat="server" Culture="en-GB">
                                <Calendar UseColumnHeadersAsSelectors="False" UseRowHeadersAsSelectors="False"
                                    ViewSelectorText="x">
                                </Calendar>
                                <DateInput DateFormat="dd/MM/yyyy" DisplayDateFormat="dd/MM/yyyy"
                                    EnableSingleInputRendering="True" LabelWidth="64px">
                                </DateInput>
                                <DatePopupButton HoverImageUrl="" ImageUrl="" TabIndex="-1" />
                            </telerik:RadDatePicker>
                        </div>
                    </div>
                    <div class="group-text">
                        <div class="row">
                            <span>Loại kiểm định đồng hồ</span>
                        </div>
                        <div class="row m-b">
                            <telerik:RadComboBox ID="cboAccreditationTypes" runat="server"
                                AllowCustomText="True" DataSourceID="MeterAccreditationTypesDataSource"
                                DataTextField="AccreditationType" DataValueField="AccreditationType"
                                EnableLoadOnDemand="True" Filter="StartsWith" HighlightTemplatedItems="True">
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
                                            <td style="width: 50px">
                                                <%#DataBinder.Eval(Container.DataItem,"AccreditationType") %>
                                            </td>
                                            <td style="width: 110px">
                                                <%#DataBinder.Eval(Container.DataItem,"Description") %>
                                            </td>
                                        </tr>
                                    </table>
                                </ItemTemplate>
                            </telerik:RadComboBox>
                            <asp:ObjectDataSource ID="MeterAccreditationTypesDataSource" runat="server"
                                OldValuesParameterFormatString="original_{0}" SelectMethod="GetAll"
                                TypeName="MeterAccreditationTypesBLL"></asp:ObjectDataSource>
                        </div>
                    </div>
                    <div class="group-text">
                        <div class="row">
                            <span>Ngày kiểm định đồng hồ</span>
                        </div>
                        <div class="row m-b">
                            <telerik:RadDatePicker ID="dtmAccredited" runat="server" Culture="en-GB">
                                <Calendar UseColumnHeadersAsSelectors="False" UseRowHeadersAsSelectors="False"
                                    ViewSelectorText="x">
                                </Calendar>
                                <DateInput DateFormat="dd/MM/yyyy" DisplayDateFormat="dd/MM/yyyy"
                                    EnableSingleInputRendering="True" LabelWidth="64px">
                                </DateInput>
                                <DatePopupButton HoverImageUrl="" ImageUrl="" TabIndex="-1" />
                            </telerik:RadDatePicker>
                        </div>
                    </div>
                     <div class="group-text">
                        <div class="row">
                            <span>Ngày thay đồng hồ</span>
                        </div>
                        <div class="row m-b">
                            <telerik:RadDatePicker ID="dtmMeterChanged" runat="server" Culture="en-GB"
                                TabIndex="11">
                                <Calendar UseColumnHeadersAsSelectors="False" UseRowHeadersAsSelectors="False"
                                    ViewSelectorText="x">
                                </Calendar>
                                <DateInput DateFormat="dd/MM/yyyy" DisplayDateFormat="dd/MM/yyyy"
                                    EnableSingleInputRendering="True" LabelWidth="64px" TabIndex="11">
                                </DateInput>
                                <DatePopupButton HoverImageUrl="" ImageUrl="" TabIndex="-1" />
                            </telerik:RadDatePicker>
                        </div>
                    </div>

                </div>
                <div class="col-sm-4">
                    <div class="group-text">
                        <div class="row">
                            <span>Vĩ độ</span>
                            <i class="fa fa-map" aria-hidden="true" class="m-l" id="showMap" onclick="showMap()"></i>
                        </div>
                        <div class="row m-b">
                            <telerik:RadNumericTextBox ID="nmrLatitude" runat="server" TabIndex="4" Width="90">
                                <NumberFormat DecimalDigits="7" ZeroPattern="n" />
                            </telerik:RadNumericTextBox>
                            
                        </div>
                        
                    </div>

                    <div id="map" class="show" style="width: 450px; height: 300px"></div>

                    <div class="group-text">
                        <div class="row">
                            <span>Mã point cũ</span>
                        </div>
                        <div class="row m-b">
                            <telerik:RadComboBox ID="cboOldIds" runat="server" AllowCustomText="True"
                                EnableLoadOnDemand="True" Filter="StartsWith"
                                HighlightTemplatedItems="True" DataSourceID="OldDataSource" TabIndex="2">
                            </telerik:RadComboBox>
                            <asp:ObjectDataSource ID="OldDataSource" runat="server"
                                OldValuesParameterFormatString="original_{0}" SelectMethod="GetAllOldIds"
                                TypeName="SitesBLL"></asp:ObjectDataSource>
                        </div>
                    </div>
                    <div class="group-text">
                        <div class="row">
                            <span>Quận</span>
                        </div>
                        <div class="row m-b">
                            <telerik:RadComboBox ID="cboDistricts" runat="server" AllowCustomText="True" DataSourceID="DistrictsDataSource" HighlightTemplatedItems="True"
                                EnableLoadOnDemand="True" Filter="StartsWith" DataTextField="IdDistrict" DataValueField="IdDistrict">
                                <HeaderTemplate>
                                    <table cellpadding="0" cellspacing="0">
                                        <tr>
                                            <td style="width: 50px">Id</td>
                                            <td style="width: 75px">Tên</td>
                                            <td style="width: 200px">Mô tả</td>
                                        </tr>
                                    </table>
                                </HeaderTemplate>
                                <ItemTemplate>
                                    <table cellpadding="0" cellspacing="0">
                                        <tr>
                                            <td style="width: 50px"><%#DataBinder.Eval(Container.DataItem, "IdDistrict")%></td>
                                            <td style="width: 75px"><%#DataBinder.Eval(Container.DataItem,"Name") %></td>
                                            <td style="width: 200px">
                                                <%#DataBinder.Eval(Container.DataItem,"Description") %>
                                            </td>
                                        </tr>
                                    </table>
                                </ItemTemplate>
                            </telerik:RadComboBox>
                            <asp:ObjectDataSource ID="DistrictsDataSource" runat="server" OldValuesParameterFormatString="original_{0}" SelectMethod="GetDistricts" TypeName="DistrictBLL"></asp:ObjectDataSource>
                        </div>
                    </div>
                    <div class="group-text">
                        <div class="row">
                            <span>Bộ hiển thị</span>
                        </div>
                        <div class="row m-b">
                            <telerik:RadComboBox ID="cboTransmitters" runat="server" AllowCustomText="True"
                                EnableLoadOnDemand="True" Filter="StartsWith"
                                HighlightTemplatedItems="True" DataSourceID="TransmitterDataSource"
                                DataTextField="Serial" DataValueField="Serial" DropDownWidth="375px"
                                TabIndex="9">
                                <HeaderTemplate>
                                    <table cellpadding="0" cellspacing="0">
                                        <tr>
                                            <td style="width: 200px">Serial</td>
                                            <td style="width: 75px">Hiệu</td>
                                            <td style="width: 50px">Cỡ</td>
                                        </tr>
                                    </table>
                                </HeaderTemplate>
                                <ItemTemplate>
                                    <table cellpadding="0" cellspacing="0">
                                        <tr>
                                            <td style="width: 200px"><%#DataBinder.Eval(Container.DataItem, "Serial")%></td>
                                            <td style="width: 75px"><%#DataBinder.Eval(Container.DataItem,"Marks") %></td>
                                            <td style="width: 50px">
                                                <%#DataBinder.Eval(Container.DataItem,"Size") %>
                                            </td>
                                        </tr>
                                    </table>
                                </ItemTemplate>
                            </telerik:RadComboBox>
                            <asp:ObjectDataSource ID="TransmitterDataSource" runat="server"
                                OldValuesParameterFormatString="original_{0}" SelectMethod="GetAllByInstalled"
                                TypeName="TransmittersBLL">
                                <SelectParameters>
                                    <asp:Parameter DefaultValue="false" Name="installed" Type="Boolean" />
                                </SelectParameters>
                            </asp:ObjectDataSource>
                        </div>
                    </div>

                    

                   

                    <div class="group-text">
                        <div class="row">
                            <span>Ngày thay bộ hiển thị</span>
                        </div>
                        <div class="row m-b">
                            <telerik:RadDatePicker ID="dtmTransmitterChanged" runat="server"
                                Culture="en-GB" TabIndex="12">
                                <Calendar UseColumnHeadersAsSelectors="False" UseRowHeadersAsSelectors="False"
                                    ViewSelectorText="x">
                                </Calendar>
                                <DateInput DateFormat="dd/MM/yyyy" DisplayDateFormat="dd/MM/yyyy"
                                    EnableSingleInputRendering="True" LabelWidth="64px" TabIndex="12">
                                </DateInput>
                                <DatePopupButton HoverImageUrl="" ImageUrl="" TabIndex="-1" />
                            </telerik:RadDatePicker>
                        </div>
                    </div>

                      <div class="group-text">
                        <div class="row">
                            <span>Ngày thay pin bộ hiển thị</span>
                        </div>
                        <div class="row m-b">
                            <telerik:RadDatePicker ID="dtmTransmitterBatteryChanged" runat="server"
                                Culture="en-GB" TabIndex="15">
                                <Calendar UseColumnHeadersAsSelectors="False" UseRowHeadersAsSelectors="False"
                                    ViewSelectorText="x">
                                </Calendar>
                                <DateInput DateFormat="dd/MM/yyyy" DisplayDateFormat="dd/MM/yyyy"
                                    EnableSingleInputRendering="True" LabelWidth="64px" TabIndex="15">
                                </DateInput>
                                <DatePopupButton HoverImageUrl="" ImageUrl="" TabIndex="-1" />
                            </telerik:RadDatePicker>
                        </div>
                    </div>

                    <div class="group-text">
                        <div class="row">
                            <span>Ghi chú</span>
                        </div>
                        <div class="row m-b">
                            <telerik:RadTextBox ID="txtChangeDescription" runat="server" Height="50px"
                                TabIndex="18" Style="top: 0px; left: 0px" TextMode="MultiLine">
                            </telerik:RadTextBox>
                        </div>
                    </div>

                   
                    <div class="group-text">
                        <div class="row">
                            <span>DMA vào</span>
                        </div>
                        <div class="row m-b">
                            <asp:ObjectDataSource ID="SiteCompaniesDataSource" runat="server" OldValuesParameterFormatString="original_{0}" SelectMethod="GetDMAs" TypeName="DMABLL"></asp:ObjectDataSource>
                            <telerik:RadComboBox ID="cboCompanies" runat="server" AllowCustomText="True" DataSourceID="SiteCompaniesDataSource" DataTextField="Company" DataValueField="Company" DropDownWidth="275px" EnableLoadOnDemand="True" Filter="StartsWith" HighlightTemplatedItems="True" TabIndex="21">
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
                                            <td style="width: 70px"><%#DataBinder.Eval(Container.DataItem,"Company") %></td>
                                            <td style="width: 200px"><%#DataBinder.Eval(Container.DataItem,"Description") %></td>
                                        </tr>
                                    </table>
                                </ItemTemplate>
                            </telerik:RadComboBox>
                        </div>
                    </div>

                    <div class="group-text">
                        <div class="row">
                            <span>DMA ra</span>
                        </div>
                        <div class="row m-b">
                            <asp:ObjectDataSource ID="SiteCompanyOutDataSource" runat="server" OldValuesParameterFormatString="original_{0}" SelectMethod="GetDMAs" TypeName="DMABLL"></asp:ObjectDataSource>
                            <telerik:RadComboBox ID="cboCompaniesOut" runat="server" AllowCustomText="True" DataSourceID="SiteCompanyOutDataSource" DataTextField="Company" DataValueField="Company" DropDownWidth="275px" EnableLoadOnDemand="True" Filter="StartsWith" HighlightTemplatedItems="True" TabIndex="21">
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
                                            <td style="width: 70px"><%#DataBinder.Eval(Container.DataItem,"Company") %></td>
                                            <td style="width: 200px"><%#DataBinder.Eval(Container.DataItem,"Description") %></td>
                                        </tr>
                                    </table>
                                </ItemTemplate>
                            </telerik:RadComboBox>
                        </div>
                    </div>

                   
                </div>
                <div class="col-sm-4">
                    <div class="group-text">
                        <div class="row">
                            <span>Kinh độ</span>
                        </div>
                        <div class="row m-b">
                            <telerik:RadNumericTextBox ID="nmrLogitude" runat="server" TabIndex="5">
                                <NumberFormat DecimalDigits="7" ZeroPattern="n" />
                            </telerik:RadNumericTextBox>
                        </div>
                    </div>
                   

                    <div class="group-text">
                        <div class="row">
                            <span>Logger</span>
                        </div>
                        <div class="row m-b">
                             <telerik:RadTextBox ID="txtLogger" Enabled="false" runat="server" ReadOnly="true" TabIndex="40">
                            </telerik:RadTextBox>
                           
                        </div>
                    </div>

                
                  
                    <div class="group-text">
                        <div class="row">
                            <span>Ngày thay pin logger</span>
                        </div>
                        <div class="row m-b">
                            <telerik:RadDatePicker ID="dtmLoggerBatteryChanged" runat="server"
                                Culture="en-GB" TabIndex="16">
                                <Calendar UseColumnHeadersAsSelectors="False" UseRowHeadersAsSelectors="False"
                                    ViewSelectorText="x">
                                </Calendar>
                                <DateInput DateFormat="dd/MM/yyyy" DisplayDateFormat="dd/MM/yyyy"
                                    EnableSingleInputRendering="True" LabelWidth="64px" TabIndex="16">
                                </DateInput>
                                <DatePopupButton HoverImageUrl="" ImageUrl="" TabIndex="-1" />
                            </telerik:RadDatePicker>
                        </div>
                    </div>
                     <div class="group-text">
                        <div class="row">
                            <span>Ngày thay logger</span>
                        </div>
                        <div class="row m-b">
                            <telerik:RadDatePicker ID="dtmLoggerChanged" runat="server" Culture="en-GB"
                                TabIndex="13">
                                <Calendar UseColumnHeadersAsSelectors="False" UseRowHeadersAsSelectors="False"
                                    ViewSelectorText="x">
                                </Calendar>
                                <DateInput DateFormat="dd/MM/yyyy" DisplayDateFormat="dd/MM/yyyy"
                                    EnableSingleInputRendering="True" LabelWidth="64px" TabIndex="13">
                                </DateInput>
                                <DatePopupButton HoverImageUrl="" ImageUrl="" TabIndex="-1" />
                            </telerik:RadDatePicker>
                        </div>
                    </div>


                    <div class="group-text">
                        <div class="row">
                            <span>Trạng thái</span>
                        </div>
                        <div class="row m-b">
                            <telerik:RadComboBox ID="cboStatus" runat="server" AllowCustomText="True"
                                EnableLoadOnDemand="True" Filter="StartsWith" DropDownWidth="200px"
                                HighlightTemplatedItems="True" DataSourceID="SiteStatusDataSource"
                                DataTextField="Status" DataValueField="Status" TabIndex="24">
                                <HeaderTemplate>
                                    <table cellpadding="0" cellspacing="0">
                                        <tr>
                                            <td style="width: 80px">Trạng thái</td>
                                            <td style="width: 120px">Mô tả</td>
                                        </tr>
                                    </table>
                                </HeaderTemplate>
                                <ItemTemplate>
                                    <table cellpadding="0" cellspacing="0">
                                        <tr>
                                            <td style="width: 80px"><%#DataBinder.Eval(Container.DataItem,"Status") %></td>
                                            <td style="width: 120px"><%#DataBinder.Eval(Container.DataItem,"Description") %></td>
                                        </tr>
                                    </table>
                                </ItemTemplate>
                            </telerik:RadComboBox>
                            <asp:ObjectDataSource ID="SiteStatusDataSource" runat="server"
                                OldValuesParameterFormatString="original_{0}" SelectMethod="GetAll"
                                TypeName="SiteStatusBLL"></asp:ObjectDataSource>
                        </div>
                    </div>


                    <div class="group-text">
                        <div class="row">
                            <span>Tình trạng</span>
                        </div>
                        <div class="row m-b">
                            <telerik:RadComboBox ID="cboAvailabilities" runat="server" AllowCustomText="True"
                                EnableLoadOnDemand="True" Filter="StartsWith"
                                HighlightTemplatedItems="True" DataSourceID="SiteAvailabilitiesDataSource"
                                DataTextField="Availability" DataValueField="Availability" TabIndex="25">
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
                                            <td style="width: 80px"><%#DataBinder.Eval(Container.DataItem,"Availability") %></td>
                                            <td style="width: 80px"><%#DataBinder.Eval(Container.DataItem,"Description") %></td>
                                        </tr>
                                    </table>
                                </ItemTemplate>
                            </telerik:RadComboBox>
                            <asp:ObjectDataSource ID="SiteAvailabilitiesDataSource" runat="server"
                                OldValuesParameterFormatString="original_{0}" SelectMethod="GetAll"
                                TypeName="SiteAvailabilitiesBLL"></asp:ObjectDataSource>
                        </div>
                    </div>

                   

                    <div class="group-text">
                        <div class="row">
                            <span>Upload</span>
                        </div>
                        <div class="row m-b">
                            <telerik:RadAsyncUpload ID="asynUpload" runat="server"
                                MultipleFileSelection="Automatic" Width="200px"
                                OnFileUploaded="asynUpload_FileUploaded"
                                TargetFolder="~/App_Data/files/site/" TabIndex="-1">
                            </telerik:RadAsyncUpload>
                            <asp:Button ID="btnUpload" runat="server" Text="Upload"
                                OnClick="btnUpload_Click" TabIndex="-1" CssClass="btn btn-primary"></asp:Button>
                            <asp:Button ID="btnDownload" runat="server" Text="Download"
                                OnClick="btnDownload_Click" TabIndex="-1" CssClass="btn btn-success"></asp:Button>
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
            <table width="100%" style="text-align: center">
                <tr>
                    <td>Bạn có muốn xóa dữ liệu điểm lắp đặt không?
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
            <telerik:AjaxSetting AjaxControlID="cboIds">
                <UpdatedControls>
                    <telerik:AjaxUpdatedControl ControlID="cboSerials" />
                    <telerik:AjaxUpdatedControl ControlID="nmrLatitude" />
                    <telerik:AjaxUpdatedControl ControlID="cboOldIds" />
                    <telerik:AjaxUpdatedControl ControlID="nmrLogitude" />
                    <telerik:AjaxUpdatedControl ControlID="txtLocation" />
                    <telerik:AjaxUpdatedControl ControlID="cboViewGroups" />
                    <telerik:AjaxUpdatedControl ControlID="cboCompaniesOut" />
                    <telerik:AjaxUpdatedControl ControlID="txtAddress" />
                    <telerik:AjaxUpdatedControl ControlID="cboDistricts" />
                    <telerik:AjaxUpdatedControl ControlID="cboMeters" />
                    <telerik:AjaxUpdatedControl ControlID="cboTransmitters" />
                    <telerik:AjaxUpdatedControl ControlID="txtLogger" />
                    <telerik:AjaxUpdatedControl ControlID="txtAccreditationDocument" />
                    <telerik:AjaxUpdatedControl ControlID="cboAccreditationTypes" />
                    <telerik:AjaxUpdatedControl ControlID="dtmAccredited" />
                    <telerik:AjaxUpdatedControl ControlID="dtmExpiry" />
                    <telerik:AjaxUpdatedControl ControlID="dtmMeterChanged" />
                    <telerik:AjaxUpdatedControl ControlID="dtmBatteryChanged" />
                    <telerik:AjaxUpdatedControl ControlID="dtmTransmitterChanged" />
                    <telerik:AjaxUpdatedControl ControlID="dtmTransmitterBatteryChanged" />
                    <telerik:AjaxUpdatedControl ControlID="nmrIndex1" />
                    <telerik:AjaxUpdatedControl ControlID="dtmLoggerChanged" />
                    <telerik:AjaxUpdatedControl ControlID="dtmLoggerBatteryChanged" />
                    <telerik:AjaxUpdatedControl ControlID="txtChangeDescription" />
                    <telerik:AjaxUpdatedControl ControlID="cboLevels" />
                    <telerik:AjaxUpdatedControl ControlID="cboStatus" />
                    <telerik:AjaxUpdatedControl ControlID="cboMeterDirections" />
                    <telerik:AjaxUpdatedControl ControlID="cboGroups" />
                    <telerik:AjaxUpdatedControl ControlID="cboAvailabilities" />
                    <telerik:AjaxUpdatedControl ControlID="cboProductionCompanies" />
                    <telerik:AjaxUpdatedControl ControlID="cboGroup2s" />
                    <telerik:AjaxUpdatedControl ControlID="chkDisplay" />
                    <telerik:AjaxUpdatedControl ControlID="cboGroup3s" />
                    <telerik:AjaxUpdatedControl ControlID="chkIstDoNotCalculateReverse" />
                    <telerik:AjaxUpdatedControl ControlID="chkProperty" />
                    <telerik:AjaxUpdatedControl ControlID="chkQndDoNotCalculateReverse" />
                    <telerik:AjaxUpdatedControl ControlID="cboGroup4s" />
                    <telerik:AjaxUpdatedControl ControlID="cboGroup5s" />
                    <telerik:AjaxUpdatedControl ControlID="chkUsingLogger" />
                    <telerik:AjaxUpdatedControl ControlID="txtDescription" />
                    <telerik:AjaxUpdatedControl ControlID="chkTakeovered" />
                    <telerik:AjaxUpdatedControl ControlID="cboCompanies" />
                    <telerik:AjaxUpdatedControl ControlID="dtmTakeovered" />
                    <telerik:AjaxUpdatedControl ControlID="cboCoverIDs" />
                    <telerik:AjaxUpdatedControl ControlID="txtCoverMaterial" />
                    <telerik:AjaxUpdatedControl ControlID="txtCoverNL" />
                    <telerik:AjaxUpdatedControl ControlID="txtCoverL" />
                    <telerik:AjaxUpdatedControl ControlID="txtCoverW" />
                    <telerik:AjaxUpdatedControl ControlID="txtCoverH" />
                </UpdatedControls>
            </telerik:AjaxSetting>
            <telerik:AjaxSetting AjaxControlID="btnAdd">
                <UpdatedControls>
                    <telerik:AjaxUpdatedControl ControlID="ntf" />
                    <telerik:AjaxUpdatedControl ControlID="cboIds" />
                    <telerik:AjaxUpdatedControl ControlID="cboSerials" />
                    <telerik:AjaxUpdatedControl ControlID="nmrLatitude" />
                    <telerik:AjaxUpdatedControl ControlID="cboOldIds" />
                    <telerik:AjaxUpdatedControl ControlID="nmrLogitude" />
                    <telerik:AjaxUpdatedControl ControlID="txtLocation" />
                    <telerik:AjaxUpdatedControl ControlID="cboViewGroups" />
                    <telerik:AjaxUpdatedControl ControlID="cboCompaniesOut" />
                    <telerik:AjaxUpdatedControl ControlID="txtAddress" />
                    <telerik:AjaxUpdatedControl ControlID="cboDistricts" />
                    <telerik:AjaxUpdatedControl ControlID="cboMeters" />
                    <telerik:AjaxUpdatedControl ControlID="cboTransmitters" />
                    <telerik:AjaxUpdatedControl ControlID="txtLogger" />
                    <telerik:AjaxUpdatedControl ControlID="txtAccreditationDocument" />
                    <telerik:AjaxUpdatedControl ControlID="cboAccreditationTypes" />
                    <telerik:AjaxUpdatedControl ControlID="dtmAccredited" />
                    <telerik:AjaxUpdatedControl ControlID="dtmExpiry" />
                    <telerik:AjaxUpdatedControl ControlID="dtmMeterChanged" />
                    <telerik:AjaxUpdatedControl ControlID="dtmBatteryChanged" />
                    <telerik:AjaxUpdatedControl ControlID="dtmTransmitterChanged" />
                    <telerik:AjaxUpdatedControl ControlID="dtmTransmitterBatteryChanged" />
                    <telerik:AjaxUpdatedControl ControlID="nmrIndex1" />
                    <telerik:AjaxUpdatedControl ControlID="dtmLoggerChanged" />
                    <telerik:AjaxUpdatedControl ControlID="dtmLoggerBatteryChanged" />
                    <telerik:AjaxUpdatedControl ControlID="txtChangeDescription" />
                    <telerik:AjaxUpdatedControl ControlID="cboLevels" />
                    <telerik:AjaxUpdatedControl ControlID="cboStatus" />
                    <telerik:AjaxUpdatedControl ControlID="cboMeterDirections" />
                    <telerik:AjaxUpdatedControl ControlID="cboGroups" />
                    <telerik:AjaxUpdatedControl ControlID="cboAvailabilities" />
                    <telerik:AjaxUpdatedControl ControlID="cboProductionCompanies" />
                    <telerik:AjaxUpdatedControl ControlID="cboGroup2s" />
                    <telerik:AjaxUpdatedControl ControlID="chkDisplay" />
                    <telerik:AjaxUpdatedControl ControlID="cboGroup3s" />
                    <telerik:AjaxUpdatedControl ControlID="chkIstDoNotCalculateReverse" />
                    <telerik:AjaxUpdatedControl ControlID="chkProperty" />
                    <telerik:AjaxUpdatedControl ControlID="chkQndDoNotCalculateReverse" />
                    <telerik:AjaxUpdatedControl ControlID="cboGroup4s" />
                    <telerik:AjaxUpdatedControl ControlID="cboGroup5s" />
                    <telerik:AjaxUpdatedControl ControlID="chkUsingLogger" />
                    <telerik:AjaxUpdatedControl ControlID="txtDescription" />
                    <telerik:AjaxUpdatedControl ControlID="chkTakeovered" />
                    <telerik:AjaxUpdatedControl ControlID="cboCompanies" />
                    <telerik:AjaxUpdatedControl ControlID="dtmTakeovered" />
                    <telerik:AjaxUpdatedControl ControlID="cboCoverIDs" />
                    <telerik:AjaxUpdatedControl ControlID="txtCoverMaterial" />
                    <telerik:AjaxUpdatedControl ControlID="txtCoverNL" />
                    <telerik:AjaxUpdatedControl ControlID="txtCoverL" />
                    <telerik:AjaxUpdatedControl ControlID="txtCoverW" />
                    <telerik:AjaxUpdatedControl ControlID="txtCoverH" />
                </UpdatedControls>
            </telerik:AjaxSetting>
            <telerik:AjaxSetting AjaxControlID="btnDelete">
                <UpdatedControls>
                    <telerik:AjaxUpdatedControl ControlID="ntf" />
                </UpdatedControls>
            </telerik:AjaxSetting>
        </AjaxSettings>
    </telerik:RadAjaxManagerProxy>

    <script>
        var map;

        map = L.map('map', {
        }).setView([10.7611111, 106.675], 12);

        L.tileLayer('https://api.mapbox.com/styles/v1/mapbox/streets-v11/tiles/256/{z}/{x}/{y}?access_token=pk.eyJ1IjoidHJhbnF1b2N0cnVuZyIsImEiOiJja2J6eTA1bXQxZTY4MnVudGxtM3BjMzI4In0.c0ylnh0g8KaZ83XlK_qGqw', {
            attribution: '<a href="https://www.mapbox.com/about/maps/">Mapbox</a> © <a href="http://www.openstreetmap.org/copyright">OpenStreetMap</a> <strong><a href="https://www.mapbox.com/map-feedback/" target="_blank">Improve this map</a></strong>',
            maxZoom: 18,
        }).addTo(map);

        var marker;

        function onMapClick(e) {
           
            marker = L.marker(e.latlng).addTo(map);
            marker.bindPopup(`<strong>Vị trí: ${marker.getLatLng().lat}, ${marker.getLatLng().lng}</strong>`).openPopup();

            let lat = document.getElementById('ctl00_ContentPlaceHolder1_nmrLatitude');
            let long = document.getElementById('ctl00_ContentPlaceHolder1_nmrLogitude');

            long.value = marker.getLatLng().lng;
            lat.value = marker.getLatLng().lat;
        }

        map.on('click', onMapClick);


        // hide map
        document.getElementById('map').classList.add('hide')

        function showMap() {

            let showMap = document.getElementById('map');

            if (showMap.classList.contains("hide")) {
                showMap.classList.remove("hide")
                showMap.classList.add("show")
            }
            else if (showMap.classList.contains("show")) {
                showMap.classList.remove("show")
                showMap.classList.add("hide")
            }
        }
    </script>
</asp:Content>

