<%@ Page Title="" Language="C#" MasterPageFile="~/_supervisor/master_page.master" AutoEventWireup="true" CodeFile="rsi_meter_has_accredited.aspx.cs" Inherits="_supervisor_report_rsi_meter_has_accredited" %>
<%--<%@ Register Assembly="Microsoft.ReportViewer.WebForms, Version=10.0.0.0, Culture=neutral, PublicKeyToken=b03f5f7f11d50a3a"
    Namespace="Microsoft.Reporting.WebForms" TagPrefix="rsweb" %>--%>
<%@ Register Assembly="Microsoft.ReportViewer.WebForms, Version=12.0.0.0, Culture=neutral, PublicKeyToken=89845dcd8080cc91" Namespace="Microsoft.Reporting.WebForms" TagPrefix="rsweb" %>
<asp:Content ID="Content1" ContentPlaceHolderID="head" Runat="Server">
<style type="text/css">
        .style2
    {
        width: 50%;
        table-layout:fixed;
    }
    </style>
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" Runat="Server">
<div id="main-content">
        <div id="main-content-title">
            <h2>Điểm lắp đặt mới kiểm định đồng hồ</h2>
            <hr class="line" />
        </div>
        <div id="main-content-text">
            <table class="style2">
                <tr>
                    <td>Mốc thời gian:</td>
                    <td>
                        <telerik:RadDatePicker ID="dtmStart" Runat="server">
                        </telerik:RadDatePicker>
                    </td>
                </tr>
                <tr>
                    <td>&nbsp</td>
                    <td>
                        <telerik:RadButton ID="btnView" runat="server" Text="Xem" 
                            onclick="btnView_Click">
                        </telerik:RadButton>
                    </td>
                </tr>
            </table>
            <telerik:RadWindow ID="win" runat="server" InitialBehaviors="Maximize" 
                Modal="True" VisibleStatusbar="False">
                <ContentTemplate>
                    <rsweb:ReportViewer ID="rpt" runat="server" AsyncRendering="False" 
                            SizeToReportContent="True">
                        <LocalReport ReportPath="App_Data\reports\rsi_meter_has_accredited.rdlc" />
                    </rsweb:ReportViewer>
                </ContentTemplate>
            </telerik:RadWindow>
            <telerik:RadNotification ID="ntf" runat="server" Title="Message">
            </telerik:RadNotification>
        </div>
    </div>
</asp:Content>

