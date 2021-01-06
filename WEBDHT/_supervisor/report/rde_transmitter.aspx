<%@ Page Title="" Language="C#" MasterPageFile="~/_supervisor/master_page.master" AutoEventWireup="true" CodeFile="rde_transmitter.aspx.cs" Inherits="_supervisor_report_rde_transmitter" %>

<%--<%@ Register Assembly="Microsoft.ReportViewer.WebForms, Version=10.0.0.0, Culture=neutral, PublicKeyToken=b03f5f7f11d50a3a"
    Namespace="Microsoft.Reporting.WebForms" TagPrefix="rsweb" %>--%>
<%@ Register Assembly="Microsoft.ReportViewer.WebForms, Version=12.0.0.0, Culture=neutral, PublicKeyToken=89845dcd8080cc91" Namespace="Microsoft.Reporting.WebForms" TagPrefix="rsweb" %>
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
                        OnClientClick="return  btnView_Click()" CssClass="btn btn-primary"></asp:Button>
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
         <%--<div class="container-fluid m-t">
              <rsweb:ReportViewer ID="rpt" runat="server" AsyncRendering="False"
                    SizeToReportContent="True">
                    <LocalReport ReportPath="App_Data\reports\rde_transmitter.rdlc"
                        DisplayName="_bo_hien_thi_tuy_chon" />
                </rsweb:ReportViewer>
             </div>--%>
      
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

            let listProvider = CheckBoxListProvider();
            let listMark = CheckBoxListMark();
            let listSize = CheckBoxListSize();
            let listModel = CheckBoxListModel();
            let listStatus = CheckBoxListStatus();
            let listInstall = CheckBoxListInstall();
            let listSiteStatus = CheckBoxListSiteStatus();
            let listSiteCompany = CheckBoxListSiteCompany();

            var hostname = window.location.origin;
            if (hostname.indexOf("localhost") < 0)
                hostname = hostname + "/VivaServices/";
            else
                hostname = "http://localhost:57880";

            if (listProvider.length <= 0) {
                listProvider = "none";
            }
            else {
                listProvider = listProvider.join('|');
            }
            
            if (listMark.length <= 0) {
                listMark = "none";
            }
            else {
                listMark = listMark.join('|');
            }
            if (listSize.length <= 0) {
                listSize = "none";
            }
            else {
                listSize = listSize.join('|');
            }
            if (listModel.length <= 0) {
                listModel = "none";
            }
            else {
                listModel = listModel.join('|');
            }
            if (listStatus.length <= 0) {
                listStatus = "none";
            }
            else {
                listStatus = listStatus.join('|');
            }
            if (listInstall.length <= 0) {
                listInstall = "none";
            }
            else {
                listInstall = listInstall.join('|');
            }
            if (listSiteStatus.length <= 0) {
                listSiteStatus = "none";
            }
            else {
                listSiteStatus = listSiteStatus.join('|');
            }
            if (listSiteCompany.length <= 0) {
                listSiteCompany = "none";
            }
            else {
                listSiteCompany = listSiteCompany.join('|');
            }

            let urlGetDataStatisticSite = `${hostname}/api/getdatastatistictransmitter/?provider=${listProvider}&mark=${listMark}&size=${listSize}&model=${listModel}&status=${listStatus}&install=${listInstall}&siteStatus=${listSiteStatus}&company=${listSiteCompany}`;

            axios.get(urlGetDataStatisticSite).then((res) => {
                console.log(res.data);
                loadingElement.classList.add('hide');
                loadingElement.classList.remove('show');
                createBody(res.data);
            }).catch(err => console.log(err))

            //return false to avoid refresh web 

            return false;
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
                            if (item.Serial != null && item.Serial != undefined && item.Serial.toString().trim() != "") {
                                content += `<td>${item.Serial}</td>`;
                            }
                            else {
                                content += `<td></td>`;
                            }
                            if (item.Provider != null && item.Provider != undefined && item.Provider.toString().trim() != "") {
                                content += `<td>${item.Provider}</td>`;
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
                            if (item.Installed != null && item.Installed != undefined && item.Installed.toString().trim() != "") {
                                content += `<td>${item.Installed == false ? "N" : "Y"}</td>`;
                            }
                            else {
                                content += `<td></td>`;
                            }
                            if (item.SiteId != null && item.SiteId != undefined && item.SiteId.toString().trim() != "") {
                                content += `<td>${item.SiteId}</td>`;
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
                            if (item.Status != null && item.Status != undefined && item.Status.toString().trim() != "") {
                                content += `<td>${item.Status}</td>`;
                            }
                            else {
                                content += `<td></td>`;
                            }
                            if (item.SiteStatus != null && item.SiteStatus != undefined && item.SiteStatus.toString().trim() != "") {
                                content += `<td>${item.SiteStatus}</td>`;
                            }
                            else {
                                content += `<td></td>`;
                            }
                            if (item.SiteCompany != null && item.SiteCompany != undefined && item.SiteCompany.toString().trim() != "") {
                                content += `<td>${item.SiteCompany}</td>`;
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
                content = `<tr><td colspan="16">Không có dữ liệu</td></tr>`;
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
                                <th>Số Seri</th>
                                <th>Nhà SX</th>
                                <th>Hiệu</th>
                                <th>Cỡ</th>
                                <th>Model</th>
                                <th>Lắp Đặt</th>
                                <th>Mã Point</th>
                                <th>Vị Trí</th>
                                <th>Trạng Thái</th>
                                <th>Tình Trạng</th>
                                 <th>Quản Lý</th>
                                <th>Ghi Chú</th>
                            </tr>
                            </thead>`
            }
            head.innerHTML = content;

        }


        function CheckBoxListProvider() {
            let varTbody = document.getElementById('<%=chkListProviders.ClientID %>');
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


        function CheckBoxListMark() {
            let varTbody = document.getElementById('<%=chkListMarks.ClientID %>');
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

        function CheckBoxListSize() {
            let varTbody = document.getElementById('<%=chkListSizes.ClientID %>');
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

        function CheckBoxListModel() {
            let varTbody = document.getElementById('<%=chkListModels.ClientID %>');
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

        function CheckBoxListInstall() {
            let varTbody = document.getElementById('<%=chkListInstalleds.ClientID %>');
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

        function CheckBoxListSiteStatus() {
            let varTbody = document.getElementById('<%=chkListSiteStatus.ClientID %>');
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

        function CheckBoxListSiteCompany() {
            let varTbody = document.getElementById('<%=chkListSiteCompanies.ClientID %>');
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
    </script>
</asp:Content>

