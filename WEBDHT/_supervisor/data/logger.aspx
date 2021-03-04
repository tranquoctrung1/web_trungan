<%@ Page Title="" Language="C#" MasterPageFile="~/_supervisor/master_page.master" AutoEventWireup="true" CodeFile="logger.aspx.cs" Inherits="_supervisor_data_logger" %>

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
            <h2 class="title">Nhập tay sản lượng</h2>
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
                                DataTextField="Id" DataValueField="Id" Filter="StartsWith" HighlightTemplatedItems="True">
                            </telerik:RadComboBox>
                            <asp:ObjectDataSource ID="SiteIdsDataSource" runat="server"
                                OldValuesParameterFormatString="original_{0}" SelectMethod="GetAll"
                                TypeName="SitesBLL"></asp:ObjectDataSource>
                        </div>
                    </div>

                    <div class="group-text">
                        <div class="row">
                            <span>Giá trị</span>
                        </div>
                        <div class="row m-b">
                            <telerik:RadNumericTextBox ID="nmrIndex" runat="server" TabIndex="9">
                                <NumberFormat DecimalDigits="2" ZeroPattern="n" />
                            </telerik:RadNumericTextBox>
                        </div>
                    </div>
                </div>

                <div class="col-sm-6">
                    <div class="group-text">
                        <div class="row">
                            <span>Thời gian</span>
                        </div>
                        <div class="row m-b">
                            <telerik:RadDatePicker ID="dtmTimeStamp" runat="server" Culture="en-GB">
                                <Calendar UseRowHeadersAsSelectors="False" UseColumnHeadersAsSelectors="False" ViewSelectorText="x"></Calendar>

                                <DateInput DisplayDateFormat="dd/MM/yyyy" DateFormat="dd/MM/yyyy"
                                    LabelWidth="40%">
                                </DateInput>

                                <DatePopupButton ImageUrl="" HoverImageUrl=""></DatePopupButton>
                            </telerik:RadDatePicker>
                        </div>
                    </div>

                    <div class="group-text">
                        <div class="row">
                            <span>Ghi chú</span>
                        </div>
                        <div class="row m-b">
                            <telerik:RadTextBox ID="txtDescription" runat="server" Height="50px"
                                TextMode="MultiLine" TabIndex="-1">
                            </telerik:RadTextBox>
                        </div>
                    </div>
                </div>
            </div>
            <div class="row">
                <div class="text-center col-sm-12 m-t m-b no-padding" style="clear: both;">
                    <asp:Button ID="btnAdd" runat="server" OnClick="btnAdd_Click"
                        Text="Thêm/Sửa" CssClass="btn btn-success" UseSubmitBehavior="false"></asp:Button>
                    <asp:Button ID="btnDelete" runat="server" OnClientClick="btnDelete_Clicked()"
                        Text="Xóa " CssClass="btn btn-danger auto-width" UseSubmitBehavior="false"></asp:Button>
                </div>

            </div>

            <telerik:RadNotification ID="ntf" runat="server" Title="Message">
            </telerik:RadNotification>
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
        </div>
    </div>
    <telerik:RadAjaxManagerProxy ID="RadAjaxManagerProxy1" runat="server">
        <AjaxSettings>
            <telerik:AjaxSetting AjaxControlID="cboIds">
                <UpdatedControls>
                    <telerik:AjaxUpdatedControl ControlID="cboIds" />
                    <telerik:AjaxUpdatedControl ControlID="nmrIndex" />
                    <telerik:AjaxUpdatedControl ControlID="dtmTimeStamp" />
                    <telerik:AjaxUpdatedControl ControlID="txtDescription" />
                </UpdatedControls>
            </telerik:AjaxSetting>
            <telerik:AjaxSetting AjaxControlID="btnAdd">
                <UpdatedControls>
                    <telerik:AjaxUpdatedControl ControlID="ntf" />
                    <telerik:AjaxUpdatedControl ControlID="cboIds" />
                    <telerik:AjaxUpdatedControl ControlID="nmrIndex" />
                    <telerik:AjaxUpdatedControl ControlID="dtmTimeStamp" />
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

