<%@ Page Title="" Language="C#" MasterPageFile="~/_supervisor/master_page.master" AutoEventWireup="true" CodeFile="rou_all.aspx.cs" Inherits="_supervisor_report_rou_all" %>
<%--<%@ Register Assembly="Microsoft.ReportViewer.WebForms, Version=10.0.0.0, Culture=neutral, PublicKeyToken=b03f5f7f11d50a3a"
    Namespace="Microsoft.Reporting.WebForms" TagPrefix="rsweb" %>--%>
<%@ Register Assembly="Microsoft.ReportViewer.WebForms, Version=12.0.0.0, Culture=neutral, PublicKeyToken=89845dcd8080cc91" Namespace="Microsoft.Reporting.WebForms" TagPrefix="rsweb" %>
<asp:Content ID="Content1" ContentPlaceHolderID="head" Runat="Server">
    <style type="text/css">
        .style3
    {
        width: 100%;
    }
    </style>
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" Runat="Server">
    <div id="main-content">
    <div id="main-content-title">
            <h2>Sản lượng tổng hợp</h2>
            <hr class="line" />
        </div>
        <div id="main-content-text">

            <table class="style3">
                <tr>
                    <td>
                            Từ ngày:</td>
                    <td>
                            <telerik:RadDatePicker ID="dtmStart" Runat="server" Culture="en-GB" 
                                TabIndex="2">
                                <Calendar UseColumnHeadersAsSelectors="False" UseRowHeadersAsSelectors="False" 
                                    ViewSelectorText="x">
                                </Calendar>
                                <DateInput DateFormat="dd/MM/yyyy" DisplayDateFormat="dd/MM/yyyy" 
                                    EnableSingleInputRendering="True" LabelWidth="64px" TabIndex="2">
                                </DateInput>
                                <DatePopupButton HoverImageUrl="" ImageUrl="" TabIndex="-1" />
                            </telerik:RadDatePicker>
                        </td>
                    <td>
                            Đến ngày:</td>
                    <td>
                            <telerik:RadDatePicker ID="dtmEnd" Runat="server" Culture="en-GB" TabIndex="3">
                                <Calendar UseColumnHeadersAsSelectors="False" UseRowHeadersAsSelectors="False" 
                                    ViewSelectorText="x">
                                </Calendar>
                                <DateInput DateFormat="dd/MM/yyyy" DisplayDateFormat="dd/MM/yyyy" 
                                    EnableSingleInputRendering="True" LabelWidth="64px" TabIndex="3">
                                </DateInput>
                                <DatePopupButton HoverImageUrl="" ImageUrl="" TabIndex="-1" />
                            </telerik:RadDatePicker>
                        </td>
                </tr>
                <tr>
                    <td>
                            &nbsp;</td>
                    <td>
                            &nbsp;</td>
                    <td>
                            &nbsp;</td>
                    <td>
                            &nbsp;</td>
                </tr>
                <tr>
                    <td align="center" colspan="4">
                        <telerik:RadButton ID="btnOutput" runat="server" Text="Sản lượng" 
                            onclick="btnOutput_Click" TabIndex="7">
                        </telerik:RadButton>
                    </td>
                </tr>
            </table>

            <telerik:RadWindow ID="win" runat="server" InitialBehaviors="Maximize" 
                Modal="True" VisibleStatusbar="False">
                <ContentTemplate>
                    <rsweb:ReportViewer ID="rpt" runat="server" AsyncRendering="False" 
                            SizeToReportContent="True">
                            <LocalReport ReportPath="App_Data\reports\rou_all.rdlc"></LocalReport>
                    </rsweb:ReportViewer>
                </ContentTemplate>
            </telerik:RadWindow>
            <telerik:RadNotification ID="ntf" runat="server" Title="Message">
                </telerik:RadNotification>
        </div>
    </div>
</asp:Content>

