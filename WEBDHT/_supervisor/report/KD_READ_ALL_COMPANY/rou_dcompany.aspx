<%@ Page Title="" Language="C#" MasterPageFile="~/_supervisor/master_page.master" AutoEventWireup="true" CodeFile="rou_dcompany.aspx.cs" Inherits="_supervisor_report_KD_READ_ALL_COMPANY_rou_dcompany" %>
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
            <h2>Sản lượng các công ty cổ phần</h2>
            <hr class="line" />
        </div>
        <div id="main-content-text">

            <table class="style3">
                <tr>
                    <td>
                        Công ty:</td>
                    <td>
                            <telerik:RadComboBox ID="cboCompanies" Runat="server"
                                HighlightTemplatedItems="True" 
                                DataTextField="Company" DataValueField="Company" DropDownWidth="275px" 
                                TabIndex="1">
                                <HeaderTemplate>
                                    <table cellpadding="0" cellspacing="0">
                                        <tr>
                                            <td style="width:70px">Công ty</td>
                                            <td style="width:200px">Mô tả</td>
                                        </tr>
                                    </table>
                                </HeaderTemplate>
                                <ItemTemplate>
                                    <table cellpadding="0" cellspacing="0">
                                        <tr>
                                            <td style="width:70px"><%#DataBinder.Eval(Container.DataItem,"Company") %></td>
                                            <td style="width:200px"><%#DataBinder.Eval(Container.DataItem,"Description") %></td>
                                        </tr>
                                    </table>
                                </ItemTemplate>
                            </telerik:RadComboBox>
                        </td>
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
                            Hiển thị ngang:</td>
                    <td>
                            <asp:RadioButton ID="rdoHorizontal" runat="server" Checked="True" 
                                GroupName="Display" TabIndex="-1" />
                        </td>
                </tr>
                <tr>
                    <td>
                        &nbsp;</td>
                    <td>
                            &nbsp;</td>
                    <td>
                            Đến ngày</td>
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
                    <td>
                            Hiển thị dọc:</td>
                    <td>
                            <asp:RadioButton ID="rdoVertical" runat="server" GroupName="Display" 
                                TabIndex="-1" />
                        </td>
                </tr>
                <tr>
                    <td align="center" colspan="6">
                        &nbsp;</td>
                </tr>
                <tr>
                    <td align="center" colspan="6">
                        <telerik:RadButton ID="btnReport" runat="server" Text="Biên bản" 
                            onclick="btnReport_Click" TabIndex="6">
                        </telerik:RadButton>
                        <telerik:RadButton ID="btnOutput" runat="server" Text="Sản lượng" 
                            onclick="btnOutput_Click" TabIndex="7">
                        </telerik:RadButton>
                        <telerik:RadButton ID="btnOutputLogger" runat="server" Text="Sản lượng logger" 
                            onclick="btnOutputLogger_Click" TabIndex="8">
                        </telerik:RadButton>
                    </td>
                </tr>
            </table>

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
    </div>
</asp:Content>

