<%@ Page Title="" Language="C#" MasterPageFile="~/_supervisor/master_page.master" AutoEventWireup="true" CodeFile="rsi_.aspx.cs" Inherits="_supervisor_report_rsi_" %>

<%--<%@ Register Assembly="Microsoft.ReportViewer.WebForms, Version=10.0.0.0, Culture=neutral, PublicKeyToken=b03f5f7f11d50a3a"
    Namespace="Microsoft.Reporting.WebForms" TagPrefix="rsweb" %>--%>
<%--<%@ Register Assembly="Microsoft.ReportViewer.WebForms, Version=12.0.0.0, Culture=neutral, PublicKeyToken=89845dcd8080cc91" Namespace="Microsoft.Reporting.WebForms" TagPrefix="rsweb" %>--%>
<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="Server">
    <link href="../../css/Config.css" rel="stylesheet">

    <style>
        .table-statistic-site 
        {
            height: 300px;
            overflow: scroll
        }

        .table-statistic-site table 
        {
            width: 100%
        }

        .RadForm.rfdScrollBars body::-webkit-scrollbar, .RadForm.rfdScrollBars textarea::-webkit-scrollbar, .RadForm.rfdScrollBars div::-webkit-scrollbar
        {
            height: 2px !important;
            width: 2px !important
        }
    </style>

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
        <div class="container-fluid m-t">
            <div class="row">
                <div class="col-sm-12 table-statistic-site">
                     <div class="loading-area hide" id="loading">
                            <div class="box-loading">
                                <img src="../../2.gif" />
                            </div>
                        </div>
                    <table class="table-striped table-bordered table-hover text-center">
                            <thead id="headBody">
                                
                            </thead>
                            <tbody id="dataTable">
                            </tbody>
                        </table>
                </div>
            </div>
        </div>
       <%-- <rsweb:ReportViewer ID="rpt" runat="server" AsyncRendering="False"
                        SizeToReportContent="True">
                        <LocalReport ReportPath="App_Data\reports\rsi_site_rev_02.rdlc"
                            DisplayName="_diem_lap_dat_tuy_chon" />
                    </rsweb:ReportViewer>--%>
    </div>
    <script src="https://cdn.jsdelivr.net/npm/axios/dist/axios.min.js"></script>
    <script>

        function btnView_Click() {

            let loadingElement = document.getElementById('loading');

            // show loading area 
            if (!loadingElement.classList.contains('show')) {
                loadingElement.classList.add('show');
            }
            loadingElement.classList.remove('hide');

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
                loadingElement.classList.add('hide');
                loadingElement.classList.remove('show');
                createBody(res.data);
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

        function isEmpty(obj) {
            for (var prop in obj) {
                if (obj.hasOwnProperty(prop))
                    return false;
            }

            return true;
        }


        function createBody(data) {
            let body = document.getElementById('dataTable');

            let content = "";

            body.innerHTML = "";

            if (checkExistsData(data)) {
                for (let item of data) {
                    if (!isEmpty(item)) {
                        if (item != null && item != undefined) {
                            content += `<tr>`;
                            if (item.NumberOrdered != null && item.NumberOrdered != undefined && item.NumberOrdered.toString().trim() != "") {
                                content += `<td>${item.NumberOrdered}</td>`;
                            }
                            else {
                                content += `<td></td>`;
                            }
                            if (item.Id != null && item.Id != undefined && item.Id.toString().trim() != "") {
                                content += `<td>${item.Id}</td>`;
                            }
                            else {
                                content += `<td></td>`;
                            }
                            if (item.Location != null && item.Location != undefined && item.Location.toString().trim() != "") {
                                content += `<td>${item.Location}</td>`;
                            }
                            else {
                                content += `<td></td>`;
                            }
                            // device id
                            content += `<td></td>`;
                            if (item.Meter != null && item.Meter != undefined && item.Meter.toString().trim() != "") {
                                content += `<td>${item.Meter}</td>`;
                            }
                            else {
                                content += `<td></td>`;
                            }
                            if (item.Marks != null && item.Marks != undefined && item.Marks.toString().trim() != "") {
                                content += `<td>${item.Marks}</td>`;
                            }
                            else {
                                content += `<td></td>`;
                            }
                            if (item.Size != null && item.Size != undefined && item.Size.toString().trim() != "") {
                                content += `<td>${item.Size}</td>`;
                            }
                            else {
                                content += `<td></td>`;
                            }
                            if (item.Model != null && item.Model != undefined && item.Model.toString().trim() != "") {
                                content += `<td>${item.Model}</td>`;
                            }
                            else {
                                content += `<td></td>`;
                            }
                            if (item.Transmitter != null && item.Transmitter != undefined && item.Transmitter.toString().trim() != "") {
                                content += `<td>${item.Transmitter}</td>`;
                            }
                            else {
                                content += `<td></td>`;
                            }
                            if (item.Logger != null && item.Logger != undefined && item.Logger.toString().trim() != "") {
                                content += `<td>${item.Logger}</td>`;
                            }
                            else {
                                content += `<td></td>`;
                            }
                            if (item.AccreditationDocument != null && item.AccreditationDocument != undefined && item.AccreditationDocument.toString().trim() != "") {
                                content += `<td>${item.AccreditationDocument}</td>`;
                            }
                            else {
                                content += `<td></td>`;
                            }
                            if (item.AccreditedDate != null && item.AccreditedDate != undefined && item.AccreditedDate.toString().trim() != "") {
                                content += `<td>${convertDate(item.AccreditedDate)}</td>`;
                            }
                            else {
                                content += `<td></td>`;
                            }
                            if (item.ExpiryDate != null && item.ExpiryDate != undefined && item.ExpiryDate.toString().trim() != "") {
                                content += `<td>${convertDate(item.ExpiryDate)}</td>`;
                            }
                            else {
                                content += `<td></td>`;
                            }
                            if (item.DateOfChange != null && item.DateOfChange != undefined && item.DateOfChange.toString().trim() != "") {
                                content += `<td>${convertDate(item.DateOfChange)}</td>`;
                            }
                            else {
                                content += `<td></td>`;
                            }
                            if (item.Level != null && item.Level != undefined && item.Level.toString().trim() != "") {
                                content += `<td>${item.Level}</td>`;
                            }
                            else {
                                content += `<td></td>`;
                            }
                            if (item.Group != null && item.Group != undefined && item.Group.toString().trim() != "") {
                                content += `<td>${item.Group}</td>`;
                            }
                            else {
                                content += `<td></td>`;
                            }
                            if (item.Group2 != null && item.Group2 != undefined && item.Group2.toString().trim() != "") {
                                content += `<td>${item.Group2}</td>`;
                            }
                            else {
                                content += `<td></td>`;
                            }
                            if (item.Company != null && item.Company != undefined && item.Company.toString().trim() != "") {
                                content += `<td>${item.Company}</td>`;
                            }
                            else {
                                content += `<td></td>`;
                            }
                            if (item.Availability != null && item.Availability != undefined && item.Availability.toString().trim() != "") {
                                content += `<td>${item.Availability}</td>`;
                            }
                            else {
                                content += `<td></td>`;
                            }
                            if (item.Status != null && item.Status != undefined && item.Status.toString().trim() != "") {
                                content += `<td>${item.Status}</td>`;
                            }
                            else {
                                content += `<td></td>`;
                            }
                            if (item.LoggerModel != null && item.LoggerModel != undefined && item.LoggerModel.toString().trim() != "") {
                                content += `<td>${item.LoggerModel}</td>`;
                            }
                            else {
                                content += `<td></td>`;
                            }
                            if (item.Description != null && item.Description != undefined && item.Description.toString().trim() != "") {
                                content += `<td>${item.Description}</td>`;
                            }
                            else {
                                content += `<td></td>`;
                            }
                            content += `</tr>`;
                        }
                    }
                }
            }
            else {
                content = `<tr><td colspan="22">Không có dữ liệu</td></tr>`;
            }

            createHead(data);

            body.innerHTML = content;
        }

        function createHead(data) {
            let head = document.getElementById('headBody');
            let content = "";

            head.innerHTML = "";

            if (checkExistsData(data)) {
                content += `<thead>
                            <tr>
                                <th>STT</th>
                                <th>Mã Point</th>
                                <th>Vị Trí</th>
                                <th>Mã TB</th>
                                <th>Đồng Hồ</th>
                                <th>Hiệu</th>
                                <th>Cỡ</th>
                                <th>Model</th>
                                <th>Bộ Hiển Thị</th>
                                <th>Logger</th>
                                <th>Giấy Kiểm Định</th>
                                <th>Ngày Kiểm Định</th>
                                <th>Ngày Hết Hạn</th>
                                <th>Ngày Thay/Bàn Giao</th>
                                <th>Cấp ĐH</th>
                                <th>Nhóm ĐH</th>
                                <th>Nhóm ĐH 2</th>
                                <th>Quản Lý</th>
                                <th>Tình Trạng</th>
                                <th>Trạng Thái</th>
                                <th>Model Logger</th>
                                <th>Ghi Chú</th>
                            </tr>
                            </thead>`
            }
            head.innerHTML = content;

        }

        function convertDate(date) {
            let stringSplit = date.toString().split("-");
            let year = parseInt(stringSplit[0]);
            let month = parseInt(stringSplit[1]) < 10 ? `0${parseInt(stringSplit[1])}` : parseInt(stringSplit[1]);
            let stringSplit2 = stringSplit[2].split("T");
            let day = parseInt(stringSplit2[0]) < 10 ? `0${parseInt(stringSplit2[0])}` : parseInt(stringSplit2[0]);
            let stringSplit3 = stringSplit2[1].split(":");
            let hours = parseInt(stringSplit3[0]) < 10 ? `0${parseInt(stringSplit3[0])}` : parseInt(stringSplit3[0]);
            let minutes = parseInt(stringSplit3[1]) < 10 ? `0${parseInt(stringSplit3[1])}` : parseInt(stringSplit3[1]);
            let seconds = parseInt(stringSplit3[2]) < 10 ? `0${parseInt(stringSplit3[2])}` : parseInt(stringSplit3[2]);

            let result = `${day}/${month}/${year} ${hours}:${minutes}:${seconds}`;

            return result;
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
