<%@ Page Title="" Language="C#" MasterPageFile="~/_supervisor/master_page.master" AutoEventWireup="true" CodeFile="rde_transmitter.aspx.cs" Inherits="_supervisor_report_rde_transmitter" %>

<%--<%@ Register Assembly="Microsoft.ReportViewer.WebForms, Version=10.0.0.0, Culture=neutral, PublicKeyToken=b03f5f7f11d50a3a"
    Namespace="Microsoft.Reporting.WebForms" TagPrefix="rsweb" %>--%>
<%@ Register Assembly="Microsoft.ReportViewer.WebForms, Version=12.0.0.0, Culture=neutral, PublicKeyToken=89845dcd8080cc91" Namespace="Microsoft.Reporting.WebForms" TagPrefix="rsweb" %>
<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="Server">
    <link href="../../css/Config.css" rel="stylesheet">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="Server">
    <div id="main-content2">
        <div id="main-content-title">
            <h2 class="title">Thống kê bộ hiển thị</h2>
        </div>
        <div class="container-fluid m-t">
            <div class="row">
                <div class="col-sm-2 col-md-1">
                    <label class="label" for="chkListProviders">Nhà sản xuất</label>
                    <asp:CheckBoxList ID="chkListProviders" runat="server"
                        DataSourceID="ProvidersDataSource">
                    </asp:CheckBoxList>
                    <asp:ObjectDataSource ID="ProvidersDataSource" runat="server"
                        OldValuesParameterFormatString="original_{0}" SelectMethod="GetAllProviders"
                        TypeName="MetersBLL"></asp:ObjectDataSource>
                </div>
                <div class="col-sm-2 col-md-1">
                    <label class="label" for="chkListMarks">Hiệu</label>
                    <asp:CheckBoxList ID="chkListMarks" runat="server"
                        DataSourceID="MarksDataSource">
                    </asp:CheckBoxList>
                    <asp:ObjectDataSource ID="MarksDataSource" runat="server"
                        OldValuesParameterFormatString="original_{0}" SelectMethod="GetAllMarks"
                        TypeName="MetersBLL"></asp:ObjectDataSource>
                </div>


                <div class="col-sm-2 col-md-1">
                    <label class="label" for="chkListSizes">Cỡ</label>
                    <asp:CheckBoxList ID="chkListSizes" runat="server"
                        DataSourceID="SizesDataSource">
                    </asp:CheckBoxList>
                    <asp:ObjectDataSource ID="SizesDataSource" runat="server"
                        OldValuesParameterFormatString="original_{0}" SelectMethod="GetAllSizes"
                        TypeName="MetersBLL"></asp:ObjectDataSource>
                </div>
                <div class="col-sm-2 col-md-1">
                    <label class="label" for="chkListModels">Model</label>
                    <asp:CheckBoxList ID="chkListModels" runat="server"
                        DataSourceID="ModelsDataSource">
                    </asp:CheckBoxList>
                    <asp:ObjectDataSource ID="ModelsDataSource" runat="server"
                        OldValuesParameterFormatString="original_{0}" SelectMethod="GetAllModels"
                        TypeName="MetersBLL"></asp:ObjectDataSource>

                </div>
                <div class="col-sm-2 col-md-1">
                    <label class="label" for="chkListStatus">Tình trạng</label>
                    <asp:CheckBoxList ID="chkListStatus" runat="server"
                        DataSourceID="StatusDataSource" DataTextField="Status"
                        DataValueField="Status">
                    </asp:CheckBoxList>
                    <asp:ObjectDataSource ID="StatusDataSource" runat="server"
                        OldValuesParameterFormatString="original_{0}" SelectMethod="GetAll"
                        TypeName="DeviceStatusBLL"></asp:ObjectDataSource>
                </div>


                <div class="col-sm-2 col-md-1">
                    <label class="label" for="chkListInstalleds">Lăp đặt</label>
                    <asp:CheckBoxList ID="chkListInstalleds" runat="server"
                        DataSourceID="InstalledDataSource" DataTextField="Display"
                        DataValueField="Display">
                    </asp:CheckBoxList>
                    <asp:ObjectDataSource ID="InstalledDataSource" runat="server"
                        OldValuesParameterFormatString="original_{0}" SelectMethod="ListYN"
                        TypeName="DataObject"></asp:ObjectDataSource>
                </div>
                <div class="col-sm-2 col-md-1">
                    <label class="label" for="chkListSiteStatus">Trạng thái</label>
                    <asp:CheckBoxList ID="chkListSiteStatus" runat="server"
                        DataSourceID="SiteStatusDataSource" DataTextField="Status"
                        DataValueField="Status">
                    </asp:CheckBoxList>
                    <asp:ObjectDataSource ID="SiteStatusDataSource" runat="server"
                        OldValuesParameterFormatString="original_{0}" SelectMethod="GetAll"
                        TypeName="SiteStatusBLL"></asp:ObjectDataSource>

                </div>
                <div class="col-sm-2 col-md-1">
                    <label class="label" for="chkListSiteCompanies">Quản lý</label>
                    <asp:CheckBoxList ID="chkListSiteCompanies" runat="server"
                        DataSourceID="SiteCompaniesDataSource" DataTextField="Company"
                        DataValueField="Company">
                    </asp:CheckBoxList>
                    <asp:ObjectDataSource ID="SiteCompaniesDataSource" runat="server"
                        OldValuesParameterFormatString="original_{0}" SelectMethod="GetAll"
                        TypeName="SiteCompaniesBLL"></asp:ObjectDataSource>
                </div>
            </div>

            <div class="row">

                <div class="text-center col-sm-12 m-t m-b no-padding" style="clear: both;">
                    <asp:Button ID="btnView" runat="server" Text="Xem"
                        OnClick="btnView_Click" CssClass="btn btn-primary"></asp:Button>
                </div>
            </div>
        </div>
         <div class="container-fluid m-t">
              <rsweb:ReportViewer ID="rpt" runat="server" AsyncRendering="False"
                    SizeToReportContent="True">
                    <LocalReport ReportPath="App_Data\reports\rde_transmitter.rdlc"
                        DisplayName="_bo_hien_thi_tuy_chon" />
                </rsweb:ReportViewer>
             </div>
      
    </div>
</asp:Content>

