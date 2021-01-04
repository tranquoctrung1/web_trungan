<%@ Page Title="" Language="C#" MasterPageFile="~/_supervisor/master_page.master" AutoEventWireup="true" CodeFile="rsi_.aspx.cs" Inherits="_supervisor_report_rsi_" %>

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
            <h2 class="title">Thống kê điểm lắp đặt</h2>
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
                    <asp:CheckBoxList ID="chkListMeterModel" runat="server" DataSourceID="MeterModelDataSource" />
                    <asp:ObjectDataSource ID="MeterModelDataSource" runat="server" OldValuesParameterFormatString="original_{0}" SelectMethod="GetAllModels" TypeName="MetersBLL"></asp:ObjectDataSource>

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
                    <asp:Button ID="btn_View" runat="server" Text="Xem" AutoPostBack="false"
                        OnClientClick=" return btnView_Click()" CssClass="btn btn-primary"></asp:Button>
                </div>
            </div>
        </div>
       <%-- <div class="container-fluid m-t">
             <rsweb:ReportViewer ID="rpt" runat="server" AsyncRendering="False"
                        SizeToReportContent="True">
                        <LocalReport ReportPath="App_Data\reports\rsi_site_rev_02.rdlc"
                            DisplayName="_diem_lap_dat_tuy_chon" />
                    </rsweb:ReportViewer>
        </div>--%>
    </div>
    <script src="https://cdn.jsdelivr.net/npm/axios/dist/axios.min.js"></script>
    <script>

        function btnView_Click() {

            let listLevel = CheckBoxListLevels();
            let listGroups = CheckBoxListGroups();
            let listGroups2s = CheckBoxListGroups2s();
            let listMeterModel = CheckBoxListMeterModel();
            let listCompanies = CheckBoxListCompanies();
            let listStatus = CheckBoxListStatus();
            let listAvailability = CheckBoxListAvailabilities();
            let listCaculate = CheckBoxListCaculate();
            let listProperty = CheckBoxListProperty();
            let listTakeovered = CheckBoxListTakeovered();
            let listUsingLogger = CheckBoxListUsingLogger();
            let listModelLogger = CheckBoxListLoggerModels();
            let listAccre = CheckBoxListAccreditationTypes();
            let listApproved = CheckBoxListApproved();

            var hostname = window.location.origin;
            if (hostname.indexOf("localhost") < 0)
                hostname = hostname + "/VivaServices/";
            else
                hostname = "http://localhost:57880";

            if (listLevel.length <= 0) {
                listLevel = "none";
            }
            else {
                listLevel = listLevel.join('|');
            }

            if (listGroups.length <= 0) {
                listGroups = "none";
            }
            else {
                listGroups = listGroups.join('|');
            }

            if (listGroups2s.length <= 0) {
                listGroups2s = "none";
            }
            else {
                listGroups2s = listGroups2s.join('|');

            }

            if (listMeterModel.length <= 0) {
                listMeterModel = "none";
            }
            else {
                listMeterModel = listMeterModel.join('|');
            }

            if (listCompanies.length <= 0) {
                listCompanies = "none";
            }
            else {
                listCompanies = listCompanies.join('|');

            }
            if (listStatus.length <= 0) {
                listStatus = "none";
            }
            else {
                listStatus = listStatus.join('|');
            }
            if (listAvailability.length <= 0) {
                listAvailability = "none";
            }
            else {
                listAvailability = listAvailability.join('|');
            }

            if (listCaculate.length <= 0) {
                listCaculate = "none";
            }
            else {
                listCaculate = listCaculate.join('|');
            }

            if (listProperty.length <= 0) {
                listProperty = "none";
            }
            else {
                listProperty = listProperty.join('|');
            }
            if (listTakeovered.length <= 0) {
                listTakeovered = "none";
            }
            else {
                listTakeovered = listTakeovered.join('|');

            }
            if (listUsingLogger.length <= 0) {
                listUsingLogger = "none";
            }
            else {
                listUsingLogger = listUsingLogger.join('|');

            }

            if (listModelLogger.length <= 0) {
                listModelLogger = "none";
            }
            else {
                listModelLogger = listModelLogger.join('|');

            }
            if (listAccre.length <= 0) {
                listAccre = "none";
            }
            else {
                listAccre = listAccre.join('|');
            }
            if (listApproved.length <= 0) {
                listApproved = "none";
            }
            else {
                listApproved = listApproved.join('|');

            }

            let urlGetDataStatisticSite = `${hostname}/api/getdatastatisticsite/${listLevel}/${listGroups}/${listGroups2s}/${listMeterModel}/${listCompanies}/${listStatus}/${listCompanies}/${listCaculate}/${listProperty}/${listTakeovered}/${listUsingLogger}/${listModelLogger}/${listAccre}/${listApproved}`;

            axios.get(urlGetDataStatisticSite).then((res) => {
                console.log(res.data);
            }).catch(err => console.log(err))

            //return false to avoid refresh web 

            return false;
        }

        function checkExistsData(data) {
            if (data.length > 0) {
                return true;
            }
            return false;
        }


        function CheckBoxListLevels() {
            let varTbody = document.getElementById('<%=chkListLevels.ClientID %>');
            let td = varTbody.getElementsByTagName("td")
            let tgname = varTbody.getElementsByTagName("input")

            var str;
            str = [];
            for (i = 0; i < td.length; i++) {
                if (tgname[i].checked == true) {
                    str.push(tgname[i].value);
                }
            }

            return str;
        }

        function CheckBoxListGroups() {
            let varTbody = document.getElementById('<%=chkListGroups.ClientID %>');
            let td = varTbody.getElementsByTagName("td")
            let tgname = varTbody.getElementsByTagName("input")

            var str;
            str = [];
            for (i = 0; i < td.length; i++) {
                if (tgname[i].checked == true) {

                    str.push(tgname[i].value);
                }
            }

            return str;
        }

        function CheckBoxListGroups2s() {
            let varTbody = document.getElementById('<%=chkListGroup2s.ClientID %>');
            let td = varTbody.getElementsByTagName("td")
            let tgname = varTbody.getElementsByTagName("input")

            var str;
            str = [];
            for (i = 0; i < td.length; i++) {
                if (tgname[i].checked == true) {

                    str.push(tgname[i].value);
                }
            }

            return str;
        }

        function CheckBoxListMeterModel() {
            let varTbody = document.getElementById('<%=chkListMeterModel.ClientID %>');
            let td = varTbody.getElementsByTagName("td")
            let tgname = varTbody.getElementsByTagName("input")

            var str;
            str = [];
            for (i = 0; i < td.length; i++) {
                if (tgname[i].checked == true) {

                    str.push(tgname[i].value);
                }
            }

            return str;
        }

        function CheckBoxListCompanies() {
            let varTbody = document.getElementById('<%=chkListCompanies.ClientID %>');
            let td = varTbody.getElementsByTagName("td")
            let tgname = varTbody.getElementsByTagName("input")

            var str;
            str = [];
            for (i = 0; i < td.length; i++) {
                if (tgname[i].checked == true) {

                    str.push(tgname[i].value);
                }
            }

            return str;
        }

        function CheckBoxListStatus() {
            let varTbody = document.getElementById('<%=chkListStatus.ClientID %>');
            let td = varTbody.getElementsByTagName("td")
            let tgname = varTbody.getElementsByTagName("input")

            var str;
            str = [];
            for (i = 0; i < td.length; i++) {
                if (tgname[i].checked == true) {

                    str.push(tgname[i].value);
                }
            }

            return str;
        }

        function CheckBoxListAvailabilities() {
            let varTbody = document.getElementById('<%=chkListAvailabilities.ClientID %>');
            let td = varTbody.getElementsByTagName("td")
            let tgname = varTbody.getElementsByTagName("input")

            var str;
            str = [];
            for (i = 0; i < td.length; i++) {
                if (tgname[i].checked == true) {

                    str.push(tgname[i].value);
                }
            }

            return str;
        }

        function CheckBoxListCaculate() {
            let varTbody = document.getElementById('<%=chkListCalculate.ClientID %>');
            let td = varTbody.getElementsByTagName("td")
            let tgname = varTbody.getElementsByTagName("input")

            var str;
            str = [];
            for (i = 0; i < td.length; i++) {
                if (tgname[i].checked == true) {

                    str.push(tgname[i].value);
                }
            }

            return str;
        }

        function CheckBoxListProperty() {
            let varTbody = document.getElementById('<%=chkListProperty.ClientID %>');
            let td = varTbody.getElementsByTagName("td")
            let tgname = varTbody.getElementsByTagName("input")

            var str;
            str = [];
            for (i = 0; i < td.length; i++) {
                if (tgname[i].checked == true) {
                    if (tgname[i].value == "Y") {
                        str.push("1");
                    }
                    else {
                        str.push("0");
                    }
                }
            }

            return str;
        }

        function CheckBoxListTakeovered() {
            let varTbody = document.getElementById('<%=chkListTakeovered.ClientID %>');
            let td = varTbody.getElementsByTagName("td")
            let tgname = varTbody.getElementsByTagName("input")

            var str;
            str = [];
            for (i = 0; i < td.length; i++) {
                if (tgname[i].checked == true) {
                    if (tgname[i].value == "Y") {
                        str.push("1");
                    }
                    else {
                        str.push("0");
                    }
                }
            }

            return str;
        }

        function CheckBoxListUsingLogger() {
            let varTbody = document.getElementById('<%=chkListUsingLogger.ClientID %>');
            let td = varTbody.getElementsByTagName("td")
            let tgname = varTbody.getElementsByTagName("input")

            var str;
            str = [];
            for (i = 0; i < td.length; i++) {
                if (tgname[i].checked == true) {
                    if (tgname[i].value == "Y") {
                        str.push("1");
                    }
                    else {
                        str.push("0");
                    }
                }
            }

            return str;
        }

        function CheckBoxListLoggerModels() {
            let varTbody = document.getElementById('<%=chkListLoggerModels.ClientID %>');
            let td = varTbody.getElementsByTagName("td")
            let tgname = varTbody.getElementsByTagName("input")

            var str;
            str = [];
            for (i = 0; i < td.length; i++) {
                if (tgname[i].checked == true) {

                    str.push(tgname[i].value);
                }
            }

            return str;
        }

        function CheckBoxListAccreditationTypes() {
            let varTbody = document.getElementById('<%=chkListAccreditationTypes.ClientID %>');
            let td = varTbody.getElementsByTagName("td")
            let tgname = varTbody.getElementsByTagName("input")

            var str;
            str = [];
            for (i = 0; i < td.length; i++) {
                if (tgname[i].checked == true) {

                    str.push(tgname[i].value);
                }
            }

            return str;
        }

        function CheckBoxListApproved() {
            let varTbody = document.getElementById('<%=chkListApproved.ClientID %>');
            let td = varTbody.getElementsByTagName("td")
            let tgname = varTbody.getElementsByTagName("input")

            var str;
            str = [];
            for (i = 0; i < td.length; i++) {
                if (tgname[i].checked == true) {
                    if (tgname[i].value == "Y") {
                        str.push("1");
                    }
                    else {
                        str.push("0");
                    }
                }
            }

            return str;
        }

    </script>
</asp:Content>
