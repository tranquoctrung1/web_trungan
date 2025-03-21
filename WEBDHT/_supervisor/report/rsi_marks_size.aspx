﻿<%@ Page Title="" Language="C#" MasterPageFile="~/_supervisor/master_page.master" AutoEventWireup="true" CodeFile="rsi_marks_size.aspx.cs" Inherits="_supervisor_report_rsi_marks_size" %>

<%--<%@ Register Assembly="Microsoft.ReportViewer.WebForms, Version=10.0.0.0, Culture=neutral, PublicKeyToken=b03f5f7f11d50a3a"
    Namespace="Microsoft.Reporting.WebForms" TagPrefix="rsweb" %>--%>
<%@ Register Assembly="Microsoft.ReportViewer.WebForms, Version=12.0.0.0, Culture=neutral, PublicKeyToken=89845dcd8080cc91" Namespace="Microsoft.Reporting.WebForms" TagPrefix="rsweb" %>
<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="Server">
    <link href="../../css/Config.css" rel="stylesheet">

    <script type="text/javascript">
        //<![CDATA[

        // preventing resubmition form application
        window.history.replaceState('', '', window.location.href)
//]]>
    </script>
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="Server">
    <div id="main-content2">
        <div id="main-content-title">
            <h2 class="title">Thống kê tùy chọn hiệu cỡ</h2>
        </div>
        <div class="container-fluid m-t">
            <div class="row">
                <div class="col-sm-2 col-md-1">
                    <label class="label" for="chkListLevels">Cấp đồng hồ</label>
                    <asp:CheckBoxList ID="chkListLevels" runat="server"
                        DataSourceID="SiteLevelsDataSource">
                    </asp:CheckBoxList>
                    <asp:ObjectDataSource ID="SiteLevelsDataSource" runat="server"
                        OldValuesParameterFormatString="original_{0}" SelectMethod="GetAllLevels"
                        TypeName="SitesBLL"></asp:ObjectDataSource>
                </div>
                <div class="col-sm-2 col-md-1">
                    <label class="label" for="chkListGroups">Nhóm ĐH</label>
                    <asp:CheckBoxList ID="chkListGroups" runat="server"
                        DataSourceID="SiteGroupsDataSource">
                    </asp:CheckBoxList>
                    <asp:ObjectDataSource ID="SiteGroupsDataSource" runat="server"
                        OldValuesParameterFormatString="original_{0}" SelectMethod="GetAllGroups"
                        TypeName="SitesBLL"></asp:ObjectDataSource>
                </div>
                <div class="col-sm-2 col-md-1">
                    <label class="label" for="chkListGroup2s">Nhóm ĐH (2)</label>
                    <asp:CheckBoxList ID="chkListGroup2s" runat="server"
                        DataSourceID="Group2sDataSource">
                    </asp:CheckBoxList>
                    <asp:ObjectDataSource ID="Group2sDataSource" runat="server"
                        OldValuesParameterFormatString="original_{0}" SelectMethod="GetAllGroup2s"
                        TypeName="SitesBLL"></asp:ObjectDataSource>
                </div>

                <div class="col-sm-2 col-md-1">
                    <label class="label" for="chkListMeterModel">Model ĐH</label>
                    <asp:CheckBoxList ID="chkListMeterModels" runat="server" DataSourceID="MeterModelsDataSource">
                    </asp:CheckBoxList>
                    <asp:ObjectDataSource ID="MeterModelsDataSource" runat="server" OldValuesParameterFormatString="original_{0}" SelectMethod="GetAllModels" TypeName="MetersBLL"></asp:ObjectDataSource>


                </div>
                <div class="col-sm-2 col-md-1">
                    <label class="label" for="chkListCompanies">Quản lý</label>
                    <asp:CheckBoxList ID="chkListCompanies" runat="server"
                        DataSourceID="SiteCompaniesDataSource" DataTextField="Company"
                        DataValueField="Company">
                    </asp:CheckBoxList>
                    <asp:ObjectDataSource ID="SiteCompaniesDataSource" runat="server"
                        OldValuesParameterFormatString="original_{0}" SelectMethod="GetAll"
                        TypeName="SiteCompaniesBLL"></asp:ObjectDataSource>
                </div>
                <div class="col-sm-2 col-md-1">
                    <label class="label" for="chkListStatus">Trạng thái</label>
                    <asp:CheckBoxList ID="chkListStatus" runat="server"
                        DataSourceID="SiteStatusDataSource">
                    </asp:CheckBoxList>
                    <asp:ObjectDataSource ID="SiteStatusDataSource" runat="server"
                        OldValuesParameterFormatString="original_{0}" SelectMethod="GetAllStatus"
                        TypeName="SitesBLL"></asp:ObjectDataSource>
                </div>


                <div class="col-sm-2 col-md-1">
                    <label class="label" for="chkListAvailabilities">Tình trạng</label>
                    <asp:CheckBoxList ID="chkListAvailabilities" runat="server"
                        DataSourceID="SiteAvailabilitiesDataSource">
                    </asp:CheckBoxList>
                    <asp:ObjectDataSource ID="SiteAvailabilitiesDataSource" runat="server"
                        OldValuesParameterFormatString="original_{0}" SelectMethod="GetAllAvailabilities"
                        TypeName="SitesBLL"></asp:ObjectDataSource>

                </div>
                <div class="col-sm-2 col-md-1">
                    <label class="label" for="chkListCalculate">Tính cho</label>
                    <asp:CheckBoxList ID="chkListCalculate" runat="server"
                        DataSourceID="SiteCompaniesDataSource" DataTextField="Company"
                        DataValueField="Company">
                    </asp:CheckBoxList>
                </div>
                <div class="col-sm-2 col-md-1">
                    <label class="label" for="chkListProperty">Tài sản</label>
                    <asp:CheckBoxList ID="chkListProperty" runat="server"
                        DataSourceID="YNDataSource" DataTextField="Display"
                        DataValueField="Display">
                    </asp:CheckBoxList>
                </div>
                <div class="col-sm-2 col-md-1">
                    <label class="label" for="chkListTakeovered">Bàn giao</label>
                    <asp:CheckBoxList ID="chkListTakeovered" runat="server" DataSourceID="YNDataSource"
                        DataTextField="Display" DataValueField="Display">
                    </asp:CheckBoxList>
                    <asp:ObjectDataSource ID="YNDataSource" runat="server"
                        OldValuesParameterFormatString="original_{0}" SelectMethod="ListYN"
                        TypeName="DataObject"></asp:ObjectDataSource>
                </div>

                <div class="col-sm-2 col-md-1">
                    <label class="label" for="chkListUsingLogger">Sử dụng logger</label>
                    <asp:CheckBoxList ID="chkListUsingLogger" runat="server"
                        DataSourceID="YNDataSource" DataTextField="Display"
                        DataValueField="Display">
                    </asp:CheckBoxList>

                </div>
                <div class="col-sm-2 col-md-1">
                    <label class="label" for="chkListLoggerModels">Model logger</label>
                    <asp:CheckBoxList ID="chkListLoggerModels" runat="server"
                        DataSourceID="LoggerModelsDataSource">
                    </asp:CheckBoxList>
                    <asp:ObjectDataSource ID="LoggerModelsDataSource" runat="server"
                        OldValuesParameterFormatString="original_{0}" SelectMethod="GetAllModels"
                        TypeName="LoggersBLL"></asp:ObjectDataSource>
                </div>
                <div class="col-sm-2 col-md-1">
                    <label class="label" for="chkListAccreditationTypes">Loại kiểm định</label>
                    <asp:CheckBoxList ID="chkListAccreditationTypes" runat="server"
                        DataSourceID="AccreditationTypesDataSource" DataTextField="AccreditationType"
                        DataValueField="AccreditationType">
                    </asp:CheckBoxList>
                    <asp:ObjectDataSource ID="AccreditationTypesDataSource" runat="server"
                        OldValuesParameterFormatString="original_{0}" SelectMethod="GetAll"
                        TypeName="MeterAccreditationTypesBLL"></asp:ObjectDataSource>
                </div>
                <div class="col-sm-2 col-md-1">
                    <label class="label" for="chkListApproved">Đã phê duyệt</label>
                    <asp:CheckBoxList ID="chkListApproved" runat="server" DataSourceID="YNDataSource"
                        DataTextField="Display" DataValueField="Display">
                    </asp:CheckBoxList>
                </div>
            </div>
            <div class="row">
                <div class="text-center col-sm-12 m-t m-b no-padding" style="clear: both;">
                    <asp:Button ID="Button1" runat="server" OnClick="btnMarks_Click" CssClass="btn btn-primary"
                        Text="Hiệu"></asp:Button>
                    <asp:Button ID="Button2" runat="server" OnClick="btnSize_Click" CssClass="btn btn-success"
                        Text="Cỡ"></asp:Button>
                    <asp:Button ID="Button3" runat="server" Text="Hiệu cỡ" CssClass="btn btn-info"
                        OnClick="btnView_Click"></asp:Button>
                </div>

            </div>

        </div>
        <div class="container-fluid m-t">
            <rsweb:ReportViewer ID="rpt" runat="server" AsyncRendering="False"
                SizeToReportContent="True">
                <LocalReport ReportPath="App_Data\reports\rsi_site_rev_02.rdlc"
                    DisplayName="_diem_lap_dat_tuy_chon" />
            </rsweb:ReportViewer>
        </div>
    </div>
</asp:Content>

