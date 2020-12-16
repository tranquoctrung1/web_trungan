<%@ Page Title="" Language="C#" MasterPageFile="~/_supervisor/master_page.master" AutoEventWireup="true" CodeFile="rsi_history.aspx.cs" Inherits="_supervisor_report_rsi_history" %>

<%--<%@ Register Assembly="Microsoft.ReportViewer.WebForms, Version=10.0.0.0, Culture=neutral, PublicKeyToken=b03f5f7f11d50a3a"
    Namespace="Microsoft.Reporting.WebForms" TagPrefix="rsweb" %>--%>
<%@ Register Assembly="Microsoft.ReportViewer.WebForms, Version=12.0.0.0, Culture=neutral, PublicKeyToken=89845dcd8080cc91" Namespace="Microsoft.Reporting.WebForms" TagPrefix="rsweb" %>
<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="Server">
    <link href="../../css/Config.css" rel="stylesheet">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="Server">
    <div id="main-content2">
        <div id="main-content-title">
            <h2 class="title">Lịch sử điểm lắp đặt</h2>
        </div>
        <div class="container-fluid m-t">
            <div class="row">
                <div class="col-sm-12">
                    <div class="group-text">
                          <div class="row">
                            <span>Mã point</span>
                        </div>
                        <div class="row m-b">
                            <telerik:RadComboBox ID="cboSiteIds" runat="server" AllowCustomText="True"
                                AutoPostBack="True" DataSourceID="SiteDataSource" DataTextField="Id"
                                DataValueField="Id" EnableLoadOnDemand="True" Filter="StartsWith"
                                HighlightTemplatedItems="True" DropDownWidth="350px"
                                OnSelectedIndexChanged="cboSiteIds_SelectedIndexChanged">
                                <HeaderTemplate>
                                    <table cellpadding="0" cellspacing="0">
                                        <tr>
                                            <td style="width: 50px">Mã NV</td>
                                            <td style="width: 50px">Mã vị trí</td>
                                            <td style="width: 250px">Vị trí</td>
                                        </tr>
                                    </table>
                                </HeaderTemplate>
                                <ItemTemplate>
                                    <table cellpadding="0" cellspacing="0">
                                        <tr>
                                            <td style="width: 50px"><%#DataBinder.Eval(Container.DataItem,"StaffId") %></td>
                                            <td style="width: 50px"><%#DataBinder.Eval(Container.DataItem,"Id") %></td>
                                            <td style="width: 250px"><%#DataBinder.Eval(Container.DataItem,"Location") %></td>
                                        </tr>
                                    </table>
                                </ItemTemplate>
                            </telerik:RadComboBox>
                            <asp:ObjectDataSource ID="SiteDataSource" runat="server"
                                OldValuesParameterFormatString="original_{0}" SelectMethod="GetAll"
                                TypeName="SitesBLL"></asp:ObjectDataSource>
                        </div>
                    </div>
                </div>
            </div>

            <telerik:RadWindow ID="win" runat="server" InitialBehaviors="Maximize"
                Modal="True" VisibleStatusbar="False">
                <ContentTemplate>
                    <rsweb:ReportViewer ID="rpt" runat="server" AsyncRendering="False"
                        SizeToReportContent="True">
                        <LocalReport ReportPath="App_Data\reports\rsi_history_rev_02.rdlc" />
                    </rsweb:ReportViewer>
                </ContentTemplate>
            </telerik:RadWindow>
        </div>
    </div>
</asp:Content>

