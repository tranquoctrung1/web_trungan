<%@ Page Title="" Language="C#" MasterPageFile="~/_supervisor/master_page.master" AutoEventWireup="true" CodeFile="rsi_meter_accrediation.aspx.cs" Inherits="_supervisor_report_rsi_meter_accrediation" %>

<%--<%@ Register Assembly="Microsoft.ReportViewer.WebForms, Version=10.0.0.0, Culture=neutral, PublicKeyToken=b03f5f7f11d50a3a"
    Namespace="Microsoft.Reporting.WebForms" TagPrefix="rsweb" %>--%>
<%@ Register Assembly="Microsoft.ReportViewer.WebForms, Version=12.0.0.0, Culture=neutral, PublicKeyToken=89845dcd8080cc91" Namespace="Microsoft.Reporting.WebForms" TagPrefix="rsweb" %>
<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="Server">
    <link href="../../css/Config.css" rel="stylesheet">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="Server">
    <div id="main-content2">
        <div id="main-content-title">
            <h2 class="title">Điểm lắp đặt đến hạn kiểm định</h2>
        </div>
        <div class="container-fluid m-t">
            <div class="col-sm-6">
                <div class="group-text">
                    <div class="row">
                        <span>Mốc thời gian</span>
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
            <div class="col-sm-6">
                <div class="group-text">
                    <div class="row">
                        <span>&nbsp</span>
                    </div>
                    <div>
                        <asp:Button ID="btnView" runat="server" Text="Xem" CssClass="btn btn-primary"
                            OnClick="btnView_Click"></asp:Button>
                    </div>
                </div>

            </div>
        </div>

        <telerik:RadNotification ID="ntf" runat="server" Title="Message">
        </telerik:RadNotification>
        <div class="container-fluid m-t">
            <rsweb:ReportViewer ID="rpt" runat="server" AsyncRendering="False"
                SizeToReportContent="True">
                <LocalReport ReportPath="App_Data\reports\rsi_meter_expiration.rdlc" />
            </rsweb:ReportViewer>
        </div>
    </div>
</asp:Content>

