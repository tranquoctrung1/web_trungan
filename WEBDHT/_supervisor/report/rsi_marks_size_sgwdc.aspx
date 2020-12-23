<%@ Page Title="" Language="C#" MasterPageFile="~/_supervisor/master_page.master" AutoEventWireup="true" CodeFile="rsi_marks_size_sgwdc.aspx.cs" Inherits="_supervisor_report_rsi_marks_size_sgwdc" %>

<%--<%@ Register Assembly="Microsoft.ReportViewer.WebForms, Version=10.0.0.0, Culture=neutral, PublicKeyToken=b03f5f7f11d50a3a"
    Namespace="Microsoft.Reporting.WebForms" TagPrefix="rsweb" %>--%>
<%@ Register Assembly="Microsoft.ReportViewer.WebForms, Version=12.0.0.0, Culture=neutral, PublicKeyToken=89845dcd8080cc91" Namespace="Microsoft.Reporting.WebForms" TagPrefix="rsweb" %>
<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="Server">
    <link href="../../css/Config.css" rel="stylesheet">
   
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="Server">
    <div id="main-content2">
        <div id="main-content-title">
            <h2 class="title">Thống kê hiệu cỡ (DMA)</h2>
        </div>
        <div class="container-fluid m-t">
            <div class="row">
                <div class="text-center col-sm-12 m-t m-b no-padding" style="clear: both;">
                    <asp:Button ID="btnView" runat="server" Text="Xem"
                        OnClick="btnView_Click" CssClass="btn btn-primary"></asp:Button>

                </div>
            </div>
        </div>
        <div class="container-fluid m-t">
            <%--<telerik:RadWindow ID="win" runat="server" InitialBehaviors="Maximize"
                Modal="True" VisibleStatusbar="False">
                <ContentTemplate>--%>
                    <rsweb:ReportViewer ID="rpt" runat="server" AsyncRendering="False"
                        SizeToReportContent="True">
                        <LocalReport ReportPath="App_Data\reports\rsi_marks_size.rdlc"
                            DisplayName="_hieu_co_XNQL" />
                    </rsweb:ReportViewer>
              <%--  </ContentTemplate>
            </telerik:RadWindow>--%>
        </div>
    </div>
</asp:Content>

