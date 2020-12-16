<%@ Page Title="" Language="C#" MasterPageFile="~/_supervisor/master_page.master" AutoEventWireup="true" CodeFile="rde_etransmitter.aspx.cs" Inherits="_supervisor_report_rde_etransmitter" %>
<%--<%@ Register Assembly="Microsoft.ReportViewer.WebForms, Version=10.0.0.0, Culture=neutral, PublicKeyToken=b03f5f7f11d50a3a"
    Namespace="Microsoft.Reporting.WebForms" TagPrefix="rsweb" %>--%>
<%@ Register Assembly="Microsoft.ReportViewer.WebForms, Version=12.0.0.0, Culture=neutral, PublicKeyToken=89845dcd8080cc91" Namespace="Microsoft.Reporting.WebForms" TagPrefix="rsweb" %>
<asp:Content ID="Content1" ContentPlaceHolderID="head" Runat="Server">
    <link href="../../css/Config.css" rel="stylesheet">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" Runat="Server">
<div id="main-content2">
        <div id="main-content-title">
            <h2 class="title">Hồ sơ bộ hiển thị</h2>
        </div>
        <div class="container-fluid m-t">
            <div class="row">
                <div class="col-sm-12">
                    <div class="group-text">
                          <div class="row">
                            <span>Serial</span>
                        </div>
                        <div class="row m-b">
                            <telerik:RadComboBox ID="cboTransmitters" Runat="server" AllowCustomText="True" 
                                EnableLoadOnDemand="True" Filter="StartsWith" 
                                HighlightTemplatedItems="True" DataSourceID="TransmitterDataSource" 
                                DataTextField="Serial" DataValueField="Serial" DropDownWidth="275px" 
                                TabIndex="9" AutoPostBack="True" 
                                onselectedindexchanged="cboTransmitters_SelectedIndexChanged">
                                <HeaderTemplate>
                                    <table cellpadding="0" cellspacing="0">
                                        <tr>
                                            <td style="width:150px">Serial</td>
                                            <td style="width:75px">Hiệu</td>
                                            <td style="width:50px">Cỡ</td>
                                        </tr>
                                    </table>
                                </HeaderTemplate>
                                <ItemTemplate>
                                    <table cellpadding="0" cellspacing="0">
                                        <tr>
                                            <td style="width:150px"><%#DataBinder.Eval(Container.DataItem,"Serial") %></td>
                                            <td style="width:75px"><%#DataBinder.Eval(Container.DataItem,"Marks") %></td>
                                            <td style="width:50px"><%#DataBinder.Eval(Container.DataItem,"Size") %></td>
                                        </tr>
                                    </table
                                </ItemTemplate>
                            </telerik:RadComboBox>
                            <asp:ObjectDataSource ID="TransmitterDataSource" runat="server" 
                                OldValuesParameterFormatString="original_{0}" SelectMethod="GetAll" 
                                TypeName="TransmittersBLL">
                            </asp:ObjectDataSource>
                        </div>
                    </div>
                </div>
            </div>
        </div>

           
            <telerik:RadWindow ID="win" runat="server" InitialBehaviors="Maximize" 
                Modal="True" VisibleStatusbar="False">
                <ContentTemplate>
                    <rsweb:ReportViewer ID="rpt" runat="server" AsyncRendering="False" 
                            SizeToReportContent="True">
                        <LocalReport ReportPath="App_Data\reports\rde_etransmitter.rdlc"
                            DisplayName="_ho_so_bo_hien_thi" />
                    </rsweb:ReportViewer>
                </ContentTemplate>
            </telerik:RadWindow>
        </div>
</asp:Content>

