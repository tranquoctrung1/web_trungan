<%@ Page Title="" Language="C#" MasterPageFile="~/_supervisor/master_page.master" AutoEventWireup="true" CodeFile="rsi_has_changed.aspx.cs" Inherits="_supervisor_report_rsi_has_changed" %>

<%--<%@ Register Assembly="Microsoft.ReportViewer.WebForms, Version=10.0.0.0, Culture=neutral, PublicKeyToken=b03f5f7f11d50a3a"
    Namespace="Microsoft.Reporting.WebForms" TagPrefix="rsweb" %>--%>
<%@ Register Assembly="Microsoft.ReportViewer.WebForms, Version=12.0.0.0, Culture=neutral, PublicKeyToken=89845dcd8080cc91" Namespace="Microsoft.Reporting.WebForms" TagPrefix="rsweb" %>
<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="Server">
    <link href="../../css/Config.css" rel="stylesheet">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="Server">
    <div id="main-content2">
        <div id="main-content-title">
            <h2 class="title">Hoạt động phát sinh trong kỳ</h2>
        </div>
        <div class="container-fluid m-t">
            <div class="row">
                <div class="col-sm-6">
                    <div class="group-text change-size">
                        <div class="row ">
                            <span>Loại</span>
                        </div>
                        <div class="row m-b out">
                            <telerik:RadComboBox ID="cboTypes" runat="server" AllowCustomText="True"
                                DataSourceID="TypesDataSource" EnableLoadOnDemand="True" Filter="StartsWith"
                                HighlightTemplatedItems="True">
                            </telerik:RadComboBox>
                            <asp:ObjectDataSource ID="TypesDataSource" runat="server"
                                OldValuesParameterFormatString="original_{0}"
                                SelectMethod="ListAccreditationTypes" TypeName="DataObject"></asp:ObjectDataSource>
                        </div>
                    </div>
                </div>
                <div class="col-sm-6">
                    <div class="group-text change-size">
                        <div class="row ">
                            <span>Mốc thời gian</span>
                        </div>
                        <div class="row m-b out">
                            <telerik:RadDatePicker ID="dtmStart" runat="server">
                            </telerik:RadDatePicker>
                        </div>
                    </div>
                </div>
            </div>
            <div class="text-center col-sm-12 m-t m-b no-padding" style="clear: both;">
                <asp:Button ID="btnView" runat="server" Text="Xem"
                    OnClick="btnView_Click" CssClass="btn btn-primary">
                </asp:Button>
            </div>
        </div>
        <telerik:RadWindow ID="win" runat="server" InitialBehaviors="Maximize"
            Modal="True" VisibleStatusbar="False">
            <ContentTemplate>
                <rsweb:ReportViewer ID="rpt" runat="server" AsyncRendering="False"
                    SizeToReportContent="True">
                </rsweb:ReportViewer>
            </ContentTemplate>
        </telerik:RadWindow>
        <telerik:RadNotification ID="ntf" runat="server" Title="Message">
        </telerik:RadNotification>
    </div>
</asp:Content>

