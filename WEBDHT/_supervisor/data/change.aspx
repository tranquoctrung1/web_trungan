<%@ Page Title="" Language="C#" MasterPageFile="~/_supervisor/master_page.master" AutoEventWireup="true" CodeFile="change.aspx.cs" Inherits="_supervisor_data_change" %>

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
            <h2 class="title">Sửa dữ liệu nhập tay</h2>
        </div>
        <div class="container-fluid m-t">
            <div class="row">
                <div class="col-sm-6">
                    <div class="group-text">
                        <div class="row">
                            <span>Mã point</span>
                        </div>
                        <div class="row m-b">
                            <telerik:RadComboBox ID="cboIds" runat="server" AccessKey="S"
                                AllowCustomText="True" AutoPostBack="True" DataSourceID="SiteIdsDataSource"
                                DataTextField="Id" DataValueField="Id" Filter="StartsWith" HighlightTemplatedItems="True"
                                OnSelectedIndexChanged="cboIds_SelectedIndexChanged">
                            </telerik:RadComboBox>
                            <asp:ObjectDataSource ID="SiteIdsDataSource" runat="server"
                                OldValuesParameterFormatString="original_{0}" SelectMethod="GetAll"
                                TypeName="SitesBLL"></asp:ObjectDataSource>
                        </div>
                    </div>

                    <div class="group-text">
                        <div class="row">
                            <span>Mã nhân viên</span>
                        </div>
                        <div class="row m-b">
                            <telerik:RadComboBox ID="cboStaffs" runat="server" AllowCustomText="True"
                                EnableLoadOnDemand="True" Filter="StartsWith"
                                HighlightTemplatedItems="True" DataSourceID="StaffDataSource"
                                DataTextField="Id" DataValueField="Id" TabIndex="-1">
                            </telerik:RadComboBox>
                            <asp:ObjectDataSource ID="StaffDataSource" runat="server"
                                OldValuesParameterFormatString="original_{0}" SelectMethod="GetAll"
                                TypeName="UserStaffsBLL"></asp:ObjectDataSource>
                        </div>
                    </div>

                    <div class="group-text">
                        <div class="row">
                            <span>Từ ngày</span>
                        </div>
                        <div class="row m-b">
                            <telerik:RadDatePicker ID="dtmStart" runat="server" Culture="en-GB">
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
                </div>

                <div class="col-sm-6">
                    <div class="group-text">
                        <div class="row">
                            <span>Đồng hồ</span>
                        </div>
                        <div class="row m-b">
                            <telerik:RadComboBox ID="cboMeters" runat="server" AllowCustomText="True"
                                EnableLoadOnDemand="True" Filter="StartsWith"
                                HighlightTemplatedItems="True" DataSourceID="MetersDataSource"
                                DataTextField="Serial" DataValueField="Serial"
                                TabIndex="-1">
                            </telerik:RadComboBox>
                            <asp:ObjectDataSource ID="MetersDataSource" runat="server"
                                OldValuesParameterFormatString="original_{0}" SelectMethod="GetAllByInstalled"
                                TypeName="MetersBLL">
                                <SelectParameters>
                                    <asp:Parameter DefaultValue="true" Name="installed" Type="Boolean" />
                                </SelectParameters>
                            </asp:ObjectDataSource>
                        </div>
                    </div>

                    <div class="group-text">
                        <div class="row">
                            <span>Vị trí</span>
                        </div>
                        <div class="row m-b">
                            <telerik:RadTextBox ID="txtLocation" runat="server" Height="50px"
                                TextMode="MultiLine" TabIndex="-1">
                            </telerik:RadTextBox>
                        </div>
                    </div>

                    <div class="group-text">
                        <div class="row">
                            <span>Đến ngày</span>
                        </div>
                        <div class="row m-b">
                            <telerik:RadDatePicker ID="dtmEnd" runat="server" Culture="en-GB">
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
                </div>
            </div>
            <div class="row">
                <div class="text-center col-sm-12 m-t m-b no-padding" style="clear: both;">
                    <asp:Button ID="btnView" runat="server" CausesValidation="False"
                        OnClick="btnView_Click" Text="Xem [V]" UseSubmitBehavior="false"
                        AccessKey="V" CssClass="btn btn-primary"></asp:Button>
                    <asp:Button ID="btnChange" runat="server" OnClick="btnChange_Click"
                        Text="Thêm/Sửa [A]" UseSubmitBehavior="false" AccessKey="A" CssClass="btn btn-success"></asp:Button>
                    <asp:Button ID="btnDelete" runat="server" Text="Xóa dữ liệu [C]"
                        UseSubmitBehavior="false" AccessKey="C" AutoPostBack="False"
                        OnClientClick="btnDelete_Clicked()" CssClass="btn btn-danger"></asp:Button>
                </div>

            </div>
        </div>
        <telerik:RadGrid ID="grvData" runat="server" AutoGenerateColumns="False">
            <ClientSettings>
                <Selecting CellSelectionMode="None" />
            </ClientSettings>
            <MasterTableView>
                <CommandItemSettings ExportToPdfText="Export to PDF" />
                <RowIndicatorColumn FilterControlAltText="Filter RowIndicator column"
                    Visible="True">
                </RowIndicatorColumn>
                <ExpandCollapseColumn FilterControlAltText="Filter ExpandColumn column"
                    Visible="True">
                </ExpandCollapseColumn>
                <Columns>
                    <telerik:GridTemplateColumn HeaderText="Ghi chú" ItemStyle-Width="40%"
                        UniqueName="Description">
                        <ItemTemplate>
                            <telerik:RadTextBox ID="txtDescription" runat="server" Height="44"
                                TabIndex="-1" Text='<%#Bind("Description") %>' TextMode="MultiLine"
                                Width="100%">
                            </telerik:RadTextBox>
                        </ItemTemplate>
                        <ItemStyle Width="40%" />
                    </telerik:GridTemplateColumn>
                    <telerik:GridTemplateColumn HeaderText="Ngày" ItemStyle-Width="20%"
                        UniqueName="TimeStamp">
                        <ItemTemplate>
                            <telerik:RadDatePicker ID="dtmTimeStamp" runat="server"
                                DatePopupButton-TabIndex="-1" DbSelectedDate='<%# Bind("TimeStamp") %>'
                                Height="44" Width="100%">
                                <Calendar UseColumnHeadersAsSelectors="False" UseRowHeadersAsSelectors="False"
                                    ViewSelectorText="x">
                                </Calendar>
                                <DateInput DateFormat="dd/MM/yyyy" DisplayDateFormat="dd/MM/yyyy"
                                    EnableSingleInputRendering="True" LabelWidth="64px">
                                </DateInput>
                                <DatePopupButton HoverImageUrl="" ImageUrl="" />
                            </telerik:RadDatePicker>
                        </ItemTemplate>
                        <ItemStyle Width="20%" />
                    </telerik:GridTemplateColumn>
                    <telerik:GridTemplateColumn HeaderText="Chỉ số" ItemStyle-Width="20%"
                        UniqueName="Index">
                        <ItemTemplate>
                            <telerik:RadNumericTextBox ID="nmrIndex" runat="server" AutoPostBack="true"
                                DbValue='<%# Bind("Index") %>' Height="44" NumberFormat-DecimalDigits="0"
                                Width="100%">
                            </telerik:RadNumericTextBox>
                        </ItemTemplate>
                        <ItemStyle Width="20%" />
                    </telerik:GridTemplateColumn>
                    <telerik:GridTemplateColumn HeaderText="Sản lượng" ItemStyle-Width="20%"
                        UniqueName="Output">
                        <ItemTemplate>
                            <telerik:RadNumericTextBox ID="nmrOutput" runat="server"
                                DbValue='<%# Bind("Output") %>' Height="44" NumberFormat-DecimalDigits="0"
                                TabIndex="-1" Width="100%">
                            </telerik:RadNumericTextBox>
                        </ItemTemplate>
                        <ItemStyle Width="20%" />
                    </telerik:GridTemplateColumn>
                </Columns>
                <EditFormSettings>
                    <EditColumn FilterControlAltText="Filter EditCommandColumn column">
                    </EditColumn>
                </EditFormSettings>
            </MasterTableView>
            <FilterMenu EnableImageSprites="False">
            </FilterMenu>
        </telerik:RadGrid>
        <telerik:RadNotification ID="ntf" runat="server" Title="Message">
        </telerik:RadNotification>
    </div>
    <telerik:RadWindow ID="winConfirmDelete" runat="server" Modal="True"
        VisibleStatusbar="False" Height="120">
        <ContentTemplate>
            <table style="text-align: center; width: 100%" cellpadding="5">
                <tr>
                    <td>Bạn có muốn xóa dữ liệu không?
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
    <telerik:RadAjaxManagerProxy ID="RadAjaxManagerProxy1" runat="server">
        <AjaxSettings>
            <telerik:AjaxSetting AjaxControlID="cboIds">
                <UpdatedControls>
                    <telerik:AjaxUpdatedControl ControlID="cboIds" />
                    <telerik:AjaxUpdatedControl ControlID="cboMeters" />
                    <telerik:AjaxUpdatedControl ControlID="cboStaffs" />
                    <telerik:AjaxUpdatedControl ControlID="txtLocation" />
                    <telerik:AjaxUpdatedControl ControlID="grvData" />
                    <telerik:AjaxUpdatedControl ControlID="dtmStart" />
                    <telerik:AjaxUpdatedControl ControlID="dtmEnd" />
                </UpdatedControls>
            </telerik:AjaxSetting>
            <telerik:AjaxSetting AjaxControlID="btnView">
                <UpdatedControls>
                    <telerik:AjaxUpdatedControl ControlID="ntf" />
                    <telerik:AjaxUpdatedControl ControlID="cboIds" />
                    <telerik:AjaxUpdatedControl ControlID="cboMeters" />
                    <telerik:AjaxUpdatedControl ControlID="cboStaffs" />
                    <telerik:AjaxUpdatedControl ControlID="txtLocation" />
                    <telerik:AjaxUpdatedControl ControlID="grvData" />
                    <telerik:AjaxUpdatedControl ControlID="dtmStart" />
                    <telerik:AjaxUpdatedControl ControlID="dtmEnd" />
                </UpdatedControls>
            </telerik:AjaxSetting>
            <telerik:AjaxSetting AjaxControlID="btnAdd">
                <UpdatedControls>
                    <telerik:AjaxUpdatedControl ControlID="ntf" />
                    <telerik:AjaxUpdatedControl ControlID="cboIds" />
                    <telerik:AjaxUpdatedControl ControlID="cboMeters" />
                    <telerik:AjaxUpdatedControl ControlID="cboStaffs" />
                    <telerik:AjaxUpdatedControl ControlID="txtLocation" />
                    <telerik:AjaxUpdatedControl ControlID="grvData" />
                    <telerik:AjaxUpdatedControl ControlID="dtmStart" />
                    <telerik:AjaxUpdatedControl ControlID="dtmEnd" />
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

