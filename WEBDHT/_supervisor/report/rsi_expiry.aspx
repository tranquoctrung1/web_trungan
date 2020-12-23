<%@ Page Title="" Language="C#" MasterPageFile="~/_supervisor/master_page.master" AutoEventWireup="true" CodeFile="rsi_expiry.aspx.cs" Inherits="_supervisor_report_rsi_expiry" %>

<%--<%@ Register Assembly="Microsoft.ReportViewer.WebForms, Version=10.0.0.0, Culture=neutral, PublicKeyToken=b03f5f7f11d50a3a"
    Namespace="Microsoft.Reporting.WebForms" TagPrefix="rsweb" %>--%>
<%@ Register Assembly="Microsoft.ReportViewer.WebForms, Version=12.0.0.0, Culture=neutral, PublicKeyToken=89845dcd8080cc91" Namespace="Microsoft.Reporting.WebForms" TagPrefix="rsweb" %>
<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="Server">
    <link href="../../css/Config.css" rel="stylesheet">

    <script type="text/javascript">
        // preventing resubmition form application
        window.history.replaceState('', '', window.location.href)
    </script>
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="Server">
    <div id="main-content2">
        <div id="main-content-title">
            <h2 class="title">Thời gian đồng hồ hoạt động</h2>
        </div>
        <div class="container-fluid m-t">
            <div class="row">
                <div class="col-sm-4">
                    <div class="group-text">
                        <div class="row">
                            <span>Loại ngiệp vụ</span>
                        </div>
                        <div class="row m-b">
                            <telerik:RadComboBox ID="cboTypes" runat="server" AllowCustomText="True"
                                DataSourceID="TypesDataSource" EnableLoadOnDemand="True" Filter="StartsWith"
                                HighlightTemplatedItems="True">
                            </telerik:RadComboBox>
                            <asp:ObjectDataSource ID="TypesDataSource" runat="server"
                                OldValuesParameterFormatString="original_{0}" SelectMethod="ListChangeTypes" TypeName="DataObject"></asp:ObjectDataSource>
                        </div>
                    </div>
                </div>
                <div class="col-sm-4">
                    <div class="group-text">
                        <div class="row">
                            <span>Mốc tính</span>
                        </div>
                        <div class="row m-b">
                            <telerik:RadDatePicker ID="dtmEnd" runat="server" Culture="en-GB">
                                <Calendar UseRowHeadersAsSelectors="False" UseColumnHeadersAsSelectors="False" ViewSelectorText="x"></Calendar>

                                <DateInput DisplayDateFormat="dd/MM/yyyy" DateFormat="dd/MM/yyyy" EnableSingleInputRendering="True"
                                    LabelWidth="64px">
                                </DateInput>

                                <DatePopupButton ImageUrl="" HoverImageUrl=""></DatePopupButton>
                            </telerik:RadDatePicker>
                        </div>
                    </div>
                </div>
                <div class="col-sm-4">
                    <div class="group-text">
                        <div class="row">
                            <span>Thời gian sử dụng</span>
                        </div>
                        <div class="row m-b">
                            <telerik:RadNumericTextBox ID="nmrUsingTime" runat="server">
                            </telerik:RadNumericTextBox>
                        </div>
                    </div>
                </div>
            </div>
            <div class="row">
                <div class="col-sm-6">
                    <div class="group-text">
                        <div class="row">
                            <span>Quản lý</span>
                        </div>
                        <div class="row m-b">
                            <telerik:RadListBox ID="lstCompanies" runat="server" DataKeyField="Company"
                                DataSourceID="CompaniesDataSource" DataTextField="Company"
                                DataValueField="Company" Height="100px" SelectionMode="Multiple" Width="160px">
                            </telerik:RadListBox>
                            <asp:ObjectDataSource ID="CompaniesDataSource" runat="server"
                                OldValuesParameterFormatString="original_{0}" SelectMethod="GetAll"
                                TypeName="SiteCompaniesBLL"></asp:ObjectDataSource>
                        </div>
                    </div>
                </div>
                <div class="col-sm-6">
                    <div class="group-text">
                        <div class="row">
                            <span>Trạng thái</span>
                        </div>
                        <div class="row m-b">
                            <telerik:RadListBox ID="lstStatus" runat="server" DataKeyField="Status"
                                DataSourceID="StatusDataSource" DataTextField="Status" DataValueField="Status"
                                Height="100px" SelectionMode="Multiple" Width="160px">
                            </telerik:RadListBox>
                            <asp:ObjectDataSource ID="StatusDataSource" runat="server"
                                OldValuesParameterFormatString="original_{0}" SelectMethod="GetAll"
                                TypeName="SiteStatusBLL"></asp:ObjectDataSource>
                        </div>
                    </div>
                </div>
            </div>
            <div class="row">
                <div class="text-center col-sm-12 m-t m-b no-padding" style="clear: both;">
                    <asp:Button ID="btnView" runat="server" Text="Xem"
                        OnClick="btnView_Click" CssClass="btn btn-primary"></asp:Button>
                </div>
            </div>
        </div>

        <div class="container-fluid m-t">
            <rsweb:ReportViewer ID="rpt" runat="server" AsyncRendering="False"
                    SizeToReportContent="True">
                    <LocalReport ReportPath="App_Data\reports\rsi_expiry.rdlc" />
                </rsweb:ReportViewer>
            </div>
       
        <telerik:RadNotification ID="ntf" runat="server" Title="Message">
        </telerik:RadNotification>
    </div>
</asp:Content>

