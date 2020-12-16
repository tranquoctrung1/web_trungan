<%@ Page Title="" Language="C#" MasterPageFile="~/_supervisor/master_page.master" AutoEventWireup="true" CodeFile="rsi_4_staff.aspx.cs" Inherits="_supervisor_report_rsi_4_staff" %>

<%@ Register Assembly="Microsoft.ReportViewer.WebForms, Version=12.0.0.0, Culture=neutral, PublicKeyToken=89845dcd8080cc91" Namespace="Microsoft.Reporting.WebForms" TagPrefix="rsweb" %>
<%--<%@ Register Assembly="Microsoft.ReportViewer.WebForms, Version=10.0.0.0, Culture=neutral, PublicKeyToken=b03f5f7f11d50a3a"
    Namespace="Microsoft.Reporting.WebForms" TagPrefix="rsweb" %>--%>
<asp:Content ID="Content1" ContentPlaceHolderID="head" Runat="Server">
    <style type="text/css">
        .style3
    {
        width: 50%;
        table-layout:fixed;
    }
    </style>
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" Runat="Server">
    <div id="main-content">
        <div id="main-content-title">
            <h2>Mẫu in đọc số</h2>
            <hr class="line" />
        </div>
        <div id="main-content-text">

            <table class="style3">
                <tr>
                    <td>
                        Nhân viên:</td>
                    <td>
                        <telerik:RadComboBox ID="cboStaffs" Runat="server" AllowCustomText="True" 
                            EnableLoadOnDemand="True" Filter="StartsWith" DropDownWidth="300" 
                            HighlightTemplatedItems="True" DataSourceID="StaffDataSource" 
                            DataTextField="Id" DataValueField="Id" 
                            onselectedindexchanged="cboStaffs_SelectedIndexChanged" 
                            AutoPostBack="True">
                            <HeaderTemplate>
                                <table cellpadding="0" cellspacing="0">
                                    <tr>
                                        <td style="width:50px">Mã NV</td>
                                        <td style="width:100px">Tên</td>
                                        <td style="width:150px">Họ</td>
                                    </tr>
                                </table>
                            </HeaderTemplate>
                            <ItemTemplate>
                                <table cellpadding="0" cellspacing="0">
                                    <tr>
                                        <td style="width:50px"><%#DataBinder.Eval(Container.DataItem,"Id") %></td>
                                        <td style="width:100px"><%#DataBinder.Eval(Container.DataItem,"FirstName") %></td>
                                        <td style="width:150px"><%#DataBinder.Eval(Container.DataItem,"LastName") %></td>
                                    </tr>
                                </table>
                            </ItemTemplate>
                        </telerik:RadComboBox>
                        <asp:ObjectDataSource ID="StaffDataSource" runat="server" 
                            OldValuesParameterFormatString="original_{0}" SelectMethod="GetAll" 
                            TypeName="UserStaffsBLL"></asp:ObjectDataSource>
                        </td>
                </tr>
            </table>
            <telerik:RadWindow ID="win" runat="server" InitialBehaviors="Maximize" 
                Modal="True" VisibleStatusbar="False">
                <ContentTemplate>
                    <rsweb:ReportViewer ID="rpt" runat="server" AsyncRendering="False" 
                            SizeToReportContent="True">
                        <LocalReport ReportPath="App_Data\reports\rsi_4_staff.rdlc" />
                    </rsweb:ReportViewer>
                </ContentTemplate>
            </telerik:RadWindow>
        </div>
    </div>
</asp:Content>

