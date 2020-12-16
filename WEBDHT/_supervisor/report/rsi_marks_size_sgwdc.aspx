<%@ Page Title="" Language="C#" MasterPageFile="~/_supervisor/master_page.master" AutoEventWireup="true" CodeFile="rsi_marks_size_sgwdc.aspx.cs" Inherits="_supervisor_report_rsi_marks_size_sgwdc" %>
<%--<%@ Register Assembly="Microsoft.ReportViewer.WebForms, Version=10.0.0.0, Culture=neutral, PublicKeyToken=b03f5f7f11d50a3a"
    Namespace="Microsoft.Reporting.WebForms" TagPrefix="rsweb" %>--%>
<%@ Register Assembly="Microsoft.ReportViewer.WebForms, Version=12.0.0.0, Culture=neutral, PublicKeyToken=89845dcd8080cc91" Namespace="Microsoft.Reporting.WebForms" TagPrefix="rsweb" %>
<asp:Content ID="Content1" ContentPlaceHolderID="head" Runat="Server">
<style type="text/css">
        .style1
        {
            width: 100%;
        }
    </style>
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" Runat="Server">
<div id="main-content">
        <div id="main-content-title">
            <h2>Thống kê hiệu cỡ (XNQL)</h2>
            <hr class="line" />
        </div>
        <div id="main-content-text">
            
            
            <table class="style1">
                <tr>
                    <td align="center">
                        <telerik:RadButton ID="btnView" runat="server" onclick="btnView_Click" 
                            Text="Xem">
                        </telerik:RadButton>
                    </td>
                </tr>
            </table>
            
            
            <telerik:RadWindow ID="win" runat="server" InitialBehaviors="Maximize" 
                Modal="True" VisibleStatusbar="False">
                <ContentTemplate>
                    <rsweb:ReportViewer ID="rpt" runat="server" AsyncRendering="False" 
                            SizeToReportContent="True">
                        <LocalReport ReportPath="App_Data\reports\rsi_marks_size.rdlc"
                            DisplayName="_hieu_co_XNQL" />
                    </rsweb:ReportViewer>
                </ContentTemplate>
            </telerik:RadWindow>
        </div>
    </div>
</asp:Content>

