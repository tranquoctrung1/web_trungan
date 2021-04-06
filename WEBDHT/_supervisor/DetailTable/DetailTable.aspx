<%@ Page Language="C#" MasterPageFile="~/_supervisor/master_page.master" AutoEventWireup="true" CodeFile="DetailTable.aspx.cs" Inherits="_supervisor_DetaiTable_DetailTable" %>

<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="Server">
    <link href="../../css/Config.css" rel="stylesheet">

    <link rel="stylesheet" type="text/css" href="https://cdn.datatables.net/1.10.23/css/jquery.dataTables.css">
    <script type="text/javascript">
        // preventing resubmition form application
        window.history.replaceState('', '', window.location.href)
    </script>
     <style>
        .table-statistic-site table {
                width: 100%
            }
       .table-statistic-site
        {
            overflow: scroll
        }
        .RadForm.rfdScrollBars body::-webkit-scrollbar, .RadForm.rfdScrollBars textarea::-webkit-scrollbar, .RadForm.rfdScrollBars div::-webkit-scrollbar {
            height: 5px !important;
            width: 2px !important
        }

        #chart
        {
            height: 400px
        }
    </style>
     <script src="https://cdn.amcharts.com/lib/4/core.js"></script>
    <script src="https://cdn.amcharts.com/lib/4/charts.js"></script>
    <script src="https://cdn.amcharts.com/lib/4/themes/animated.js"></script>
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="Server">
    <div id="main-content2">
        <div id="main-content-title">
            <h2 class="title">Dữ Liệu Chi Tiết</h2>
        </div>
        <div class="container-fluid m-t">
            <div class="row">
                <div class="col-sm-4">
                    <div class="group-text">
                        <div class="row">
                            <span>Mã point</span>
                        </div>
                        <div class="row m-b">
                            <telerik:RadComboBox ID="cboIds" runat="server" AllowCustomText="True"
                                EnableLoadOnDemand="True" Filter="StartsWith"
                                HighlightTemplatedItems="True" DataSourceID="IdsDataSource"
                                AutoPostBack="false" 
                                TabIndex="1" onclientselectedindexchanged="OnClientSelectedIndexChanged">
                            </telerik:RadComboBox>
                            <asp:ObjectDataSource ID="IdsDataSource" runat="server"
                                OldValuesParameterFormatString="original_{0}" SelectMethod="GetAllIds"
                                TypeName="SitesBLL"></asp:ObjectDataSource>
                        </div>
                    </div>
                </div>
                <div class="col-sm-4">
                    <div class="group-text">
                        <div class="row">
                            <span>Thời Gian Bắt Đầu</span>
                        </div>  
                        <div class="row m-b">
                            <telerik:RadDatePicker ID="dtmStart" runat="server" Culture="en-GB"
                                TabIndex="2">
                                <Calendar UseColumnHeadersAsSelectors="False" UseRowHeadersAsSelectors="False"
                                    ViewSelectorText="x">
                                </Calendar>
                                <DateInput DateFormat="dd/MM/yyyy" DisplayDateFormat="dd/MM/yyyy"
                                    EnableSingleInputRendering="True" LabelWidth="64px" TabIndex="2">
                                </DateInput>
                                <DatePopupButton HoverImageUrl="" ImageUrl="" TabIndex="-1" />
                            </telerik:RadDatePicker>
                        </div>
                    </div>
                </div>
                <div class="col-sm-4">
                    <div class="group-text">
                        <div class="row">
                            <span>Thời Gian Kết Thúc</span>
                        </div>
                        <div class="row m-b">
                            <telerik:RadDatePicker ID="dtmEnd" runat="server" Culture="en-GB" TabIndex="3">
                                <Calendar UseColumnHeadersAsSelectors="False" UseRowHeadersAsSelectors="False"
                                    ViewSelectorText="x">
                                </Calendar>
                                <DateInput DateFormat="dd/MM/yyyy" DisplayDateFormat="dd/MM/yyyy"
                                    EnableSingleInputRendering="True" LabelWidth="64px" TabIndex="3">
                                </DateInput>
                                <DatePopupButton HoverImageUrl="" ImageUrl="" TabIndex="-1" />
                            </telerik:RadDatePicker>
                        </div>
                    </div>

                </div>
                <div class="text-center col-sm-12 m-t m-b no-padding" style="clear: both;">
                    <asp:Button ID="btnView" runat="server" Text="Xem" onclientclick="btnView_Click()"
                        CssClass="btn btn-primary" AutoPostBack="false"></asp:Button>
                    <asp:Button ID="btnExport" runat="server" Text="Xuất" onclientclick="btnExport_Click()"
                        CssClass="btn btn-success" AutoPostBack="false" Disabled="true"></asp:Button>

                </div>
            </div>
        </div>
        <div class="container-fluid m-t">
            <div class="row">
                <div class="col-sm-12">
                    <div class="loading-area hide" id="loading">
                        <div class="box-loading">
                            <img src="../../2.gif" />
                        </div>
                    </div>
                </div>
                <div class="col-sm-12">
                    <div id="tablePlaceHolder"></div>
                </div>
                <div class="col-sm-12" style=" display: none">
                    <table id="dataTable2">
                         <thead>
                             <th>Thời Gian</th>
                            <th>Áp lực</th>
                            <th>Lưu lượng</th>
                            <th>Index thuận</th>
                            <th>Index nghịch</th>
                            <th>Index Net</th>
                        </thead>
                        <tbody id="body2">

                        </tbody>
                    </table>
                </div>
            </div>
        </div>
    </div>
    <telerik:RadNotification ID="ntf" runat="server" Title="Message">
    </telerik:RadNotification>
    <telerik:RadAjaxManagerProxy ID="RadAjaxManagerProxy1" runat="server">
        <AjaxSettings>
            <telerik:AjaxSetting AjaxControlID="btnView">
                <UpdatedControls>
                    <telerik:AjaxUpdatedControl ControlID="ntf" />

                </UpdatedControls>
            </telerik:AjaxSetting>
            <telerik:AjaxSetting AjaxControlID="btnExport">
                <UpdatedControls>
                    <telerik:AjaxUpdatedControl ControlID="ntf" />

                </UpdatedControls>
            </telerik:AjaxSetting>
        </AjaxSettings>
    </telerik:RadAjaxManagerProxy>
    <script src="https://cdn.jsdelivr.net/npm/axios/dist/axios.min.js"></script>
    <script src="https://cdn.datatables.net/1.10.23/js/jquery.dataTables.js"></script>
    <script type="text/javascript">

        document.addEventListener('DOMContentLoaded', function () {
            //document.getElementById('ContentPlaceHolder1_btnView').click();
        });

        function OnClientSelectedIndexChanged(sender, eventArgs) {
            var item = eventArgs.get_item();
           
            

            var hostname = window.location.origin;
            if (hostname.indexOf("localhost") < 0)
                hostname = hostname + "/VivaServices/";
            else
                hostname = "http://localhost:57880";

            let urlGetCurrentTimeStampPressureChannelBySite = `${hostname}/api/getcurrenttimestamppressurechannelbysite?siteid=${item.get_text()}`;

            axios.get(urlGetCurrentTimeStampPressureChannelBySite).then((res) => {
                let start = document.getElementById('ctl00_ContentPlaceHolder1_dtmStart_dateInput_ClientState');
                let end = document.getElementById('ctl00_ContentPlaceHolder1_dtmEnd_dateInput_ClientState');

                let endTime;
                let tempEndTime;
                let startTime;

                if (res.data != null) {
                    endTime = new Date(res.data);
                    tempEndTime = new Date(res.data);
                    startTime = new Date(tempEndTime.setDate(tempEndTime.getDate() - 1));
                }
                else {
                    endTime = new Date(Date.now());
                    tempEndTime = new Date(Date.now());
                    startTime = new Date(tempEndTime.setDate(tempEndTime.getDate() - 1));
                }
                 

                let s = convertValueAsStringFromDateAPI(startTime);
                let e = convertValueAsStringFromDateAPI(endTime);

                var sValue = JSON.parse(start.value);
                sValue.validationText = s;
                sValue.valueAsString = s;
                sValue.lastSetTextBoxValue = convertLastSetTextBoxValueFromDateAPI(startTime);

                start.value = "";
                start.value = JSON.stringify(sValue);

                var eValue = JSON.parse(end.value);
                eValue.validationText = e;
                eValue.valueAsString = e;
                eValue.lastSetTextBoxValue = convertLastSetTextBoxValueFromDateAPI(endTime);

                end.value = "";
                end.value = JSON.stringify(eValue);

                document.getElementById('ContentPlaceHolder1_btnView').click();

            }).catch((err) => console.log(err));

        }

        function btnView_Click() {
            let loadingElement = document.getElementById('loading');

            // show loading area 
            if (!loadingElement.classList.contains('show')) {
                loadingElement.classList.add('show');
            }
            loadingElement.classList.remove('hide');

            let siteid = document.getElementById('ctl00_ContentPlaceHolder1_cboIds_Input');
            let start = document.getElementById('ctl00_ContentPlaceHolder1_dtmStart_dateInput_ClientState');
            let end = document.getElementById('ctl00_ContentPlaceHolder1_dtmEnd_dateInput_ClientState');

            let valueSiteid = siteid.value;
            let valueStart = JSON.parse(start.value).valueAsString;
            let valueEnd = JSON.parse(end.value).valueAsString;


            if (valueSiteid.trim() == "" || valueSiteid == null || valueSiteid == undefined) {
                alert("Chưa có mã kênh!!");
                return false;
            }
            if (valueStart.trim() == "" || valueStart == null || valueStart == undefined) {
                alert("Chưa có giờ bắt đầu!!");
                return false;
            }
            if (valueEnd.trim() == "" || valueEnd == null || valueEnd == undefined) {
                alert("Chưa có giờ kết thúc!!");
                return false;
            }
            else {
                let tempStart = ConvertDateFromValueAsString(valueStart);
                let tempEnd = ConvertDateFromValueAsString(valueEnd);


                let totalSecondStart = tempStart.getTime() / 1000;
                let totalSecondEnd = tempEnd.getTime() / 1000;

                GetData(valueSiteid, totalSecondStart, totalSecondEnd);
            }
        }

        function ConvertDateFromValueAsString(date) {
            let string = date.split('-');

            return new Date(parseFloat(string[0]), parseFloat(string[1]) - 1, parseFloat(string[2]), parseFloat(string[3]), parseFloat(string[4]), parseFloat(string[5]));
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

        function convertValueAsStringFromDateAPI(date) {
            let year = date.getFullYear();
            let month = date.getMonth() + 1 < 10 ? `0${date.getMonth() + 1}` : date.getMonth() + 1;
            let day = date.getDate() < 10 ? `0${date.getDate()}` : date.getDate();
            let hours = date.getHours() < 10 ? `0${date.getHours()}` : date.getHours();
            let minutes = date.getMinutes() < 10 ? `0${date.getMinutes()}` : date.getMinutes();
            let seconds = date.getSeconds() < 10 ? `0${date.getSeconds()}` : date.getSeconds();
            let result = `${year}-${month}-${day}-${hours}-${minutes}-${seconds}`;

            return result;
        }

        function convertLastSetTextBoxValueFromDateAPI(date) {
            let year = date.getFullYear();
            let month = date.getMonth() < 10 ? `0${date.getMonth()}` : date.getMonth();
            let day = date.getDate() < 10 ? `0${date.getDate()}` : date.getDate();
            let hours = date.getHours() < 10 ? `0${date.getHours()}` : date.getHours();
            let minutes = date.getMinutes() < 10 ? `0${date.getMinutes()}` : date.getMinutes();
            let seconds = date.getSeconds() < 10 ? `0${date.getSeconds()}` : date.getSeconds();

            let result = `${day}/${month}/${year}`;

            return result;
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

        function convertDateFromApi(date) {
            let stringSplit = date.toString().split("-");
            let year = parseInt(stringSplit[0]);
            let month = parseInt(stringSplit[1]) < 10 ? `0${parseInt(stringSplit[1])}` : parseInt(stringSplit[1]);
            let stringSplit2 = stringSplit[2].split("T");
            let day = parseInt(stringSplit2[0]) < 10 ? `0${parseInt(stringSplit2[0])}` : parseInt(stringSplit2[0]);
            let stringSplit3 = stringSplit2[1].split(":");
            let hours = parseInt(stringSplit3[0]) < 10 ? `0${parseInt(stringSplit3[0])}` : parseInt(stringSplit3[0]);
            let minutes = parseInt(stringSplit3[1]) < 10 ? `0${parseInt(stringSplit3[1])}` : parseInt(stringSplit3[1]);
            let seconds = parseInt(stringSplit3[2]) < 10 ? `0${parseInt(stringSplit3[2])}` : parseInt(stringSplit3[2]);

            let result = `${year}/${month}/${day} ${hours}:${minutes}:${seconds}`;

            return result;
        }


        function btnExport_Click() {

            let siteid = document.getElementById('ctl00_ContentPlaceHolder1_cboIds_Input');
            let start = document.getElementById('ctl00_ContentPlaceHolder1_dtmStart_dateInput_ClientState');
            let end = document.getElementById('ctl00_ContentPlaceHolder1_dtmEnd_dateInput_ClientState');

            let valueSiteid = siteid.value;
            let valueStart = JSON.parse(start.value).valueAsString;
            let valueEnd = JSON.parse(end.value).valueAsString;

            var tableToExcel = (function () {
                var uri = 'data:application/vnd.ms-excel;base64,',
                    template = '<html xmlns:o="urn:schemas-microsoft-com:office:office" xmlns:x="urn:schemas-microsoft-com:office:excel" xmlns="http://www.w3.org/TR/REC-html40"><head><!--[if gte mso 9]><xml><x:ExcelWorkbook><x:ExcelWorksheets><x:ExcelWorksheet><x:Name>{worksheet}</x:Name><x:WorksheetOptions><x:DisplayGridlines/></x:WorksheetOptions></x:ExcelWorksheet></x:ExcelWorksheets></x:ExcelWorkbook></xml><![endif]--><meta http-equiv="content-type" content="text/plain; charset=UTF-8"/></head><body><table>{table}</table></body></html>',
                    base64 = function (s) {
                        return window.btoa(unescape(encodeURIComponent(s)))
                    },
                    format = function (s, c) {
                        return s.replace(/{(\w+)}/g, function (m, p) {
                            return c[p];
                        })
                    }
                return function (table, name) {
                    if (!table.nodeType) table = document.getElementById(table)
                    var ctx = {
                        worksheet: name || 'Worksheet',
                        table: table.innerHTML
                    }
                    //window.location.href = uri + base64(format(template, ctx))
                    var blob = new Blob([format(template, ctx)]);
                    var blobURL = window.URL.createObjectURL(blob);
                    return blobURL;
                }
            })()

            let url = tableToExcel('dataTable2', `Chi tiết`);
            let a = $("<a />", {
                href: url,
                download: `Bang_Chi_Tiet_${valueSiteid}_Tu_${convertDate2(ConvertDateFromValueAsString(valueStart))}_Den_${convertDate2(ConvertDateFromValueAsString(valueEnd))}.xls`
            }).appendTo("body").get(0).click();
        }

        function convertDate2(date) {
            return `${date.getFullYear()}_${date.getMonth() + 1}_${date.getDate()}_${date.getHours()}_${date.getMinutes()}_${date.getSeconds()}`;
        }

        function GetData(siteid, start, end) {

            let loadingElement = document.getElementById('loading');

            var hostname = window.location.origin;
            if (hostname.indexOf("localhost") < 0)
                hostname = hostname + "/VivaServices/";
            else
                hostname = "http://localhost:57880";

            let urlGetDetailTalbe = `${hostname}/api/GetDetailTable?siteid=${siteid}&start=${start}&end=${end}`;

            axios.get(urlGetDetailTalbe).then(function (res) {
                loadingElement.classList.add('hide');
                loadingElement.classList.remove('show');

                createTablePlaceHolder();

                createBodyForLoggerChanged(res.data);

                createBody2(res.data);

                document.getElementById('ContentPlaceHolder1_btnExport').disabled = false;

            }).catch(err => console.log(err))
        }

        function createTablePlaceHolder() {
            let tablePlaceHolder = document.getElementById('tablePlaceHolder');

            tablePlaceHolder.innerHTML = `<table class="table-striped table-bordered table-hover text-center" id="example">
                        <thead id="headBody">
                        </thead>
                        <tbody id="dataTable">
                        </tbody>
                        <tfoot class="text-center" id="footer">
                        </tfoot>
                    </table>`;
        }

        function createBody2(data) {
            let body = document.getElementById('body2');

            let content = "";

            body.innerHTML = "";
            if (checkExistsData(data)) {
                for (let item of data) {
                    if (!isEmpty(item)) {
                        if (item != null && item != undefined) {
                            content += `<tr>`;
                            if (item.TimeStamp != null && item.TimeStamp != undefined && item.TimeStamp.toString().trim() != "") {
                                content += `<td>${convertDate(item.TimeStamp)}</td>`;
                            }
                            else {
                                content += `<td></td>`;
                            }
                            if (item.Pressure != null && item.Pressure != undefined && item.Pressure.toString().trim() != "") {
                                content += `<td>${item.Pressure}</td>`;
                            }
                            else {
                                content += `<td></td>`;
                            }
                            if (item.Flow != null && item.Flow != undefined && item.Flow.toString().trim() != "") {
                                content += `<td>${item.Flow}</td>`;
                            }
                            else {
                                content += `<td></td>`;
                            }
                            if (item.IndexForward != null && item.IndexForward != undefined && item.IndexForward.toString().trim() != "") {
                                content += `<td>${item.IndexForward}</td>`;
                            }
                            else {
                                content += `<td></td>`;
                            }
                            if (item.IndexReverse != null && item.IndexReverse != undefined && item.IndexReverse.toString().trim() != "") {
                                content += `<td>${item.IndexReverse}</td>`;
                            }
                            else {
                                content += `<td></td>`;
                            }
                            if (item.IndexNet != null && item.IndexNet != undefined && item.IndexNet.toString().trim() != "") {
                                content += `<td>${item.IndexNet}</td>`;
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
                content = `<tr><td colspan="6">Không có dữ liệu</td></tr>`;
            }

            body.innerHTML = content;

        }

        function createBodyForLoggerChanged(data) {
            let body = document.getElementById('dataTable');

            let content = "";

            body.innerHTML = "";
            if (checkExistsData(data)) {
                for (let item of data) {
                    if (!isEmpty(item)) {
                        if (item != null && item != undefined) {
                            content += `<tr>`;
                            if (item.TimeStamp != null && item.TimeStamp != undefined && item.TimeStamp.toString().trim() != "") {
                                content += `<td>${convertDate(item.TimeStamp)}</td>`;
                            }
                            else {
                                content += `<td></td>`;
                            }
                            if (item.Pressure != null && item.Pressure != undefined && item.Pressure.toString().trim() != "") {
                                content += `<td>${item.Pressure}</td>`;
                            }
                            else {
                                content += `<td></td>`;
                            }
                            if (item.Flow != null && item.Flow != undefined && item.Flow.toString().trim() != "") {
                                content += `<td>${item.Flow}</td>`;
                            }
                            else {
                                content += `<td></td>`;
                            }
                            if (item.IndexForward != null && item.IndexForward != undefined && item.IndexForward.toString().trim() != "") {
                                content += `<td>${item.IndexForward}</td>`;
                            }
                            else {
                                content += `<td></td>`;
                            }
                            if (item.IndexReverse != null && item.IndexReverse != undefined && item.IndexReverse.toString().trim() != "") {
                                content += `<td>${item.IndexReverse}</td>`;
                            }
                            else {
                                content += `<td></td>`;
                            }
                            if (item.IndexNet != null && item.IndexNet != undefined && item.IndexNet.toString().trim() != "") {
                                content += `<td>${item.IndexNet}</td>`;
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
                content = `<tr><td colspan="6">Không có dữ liệu</td></tr>`;
            }

            createHeadForLoggerChanged(data);
            createFooterForLoggerChanged(data);
            body.innerHTML = content;

            $('#example').DataTable({
                initComplete: function () {
                    this.api().columns([0, 1,2,3,4,5]).every(function () {
                        var column = this;
                        var select = $('<select><option value=""></option></select>')
                            .appendTo($(column.footer()).empty())
                            .on('change', function () {
                                var val = $.fn.dataTable.util.escapeRegex(
                                    $(this).val()
                                );

                                column
                                    .search(val ? '^' + val + '$' : '', true, false)
                                    .draw();
                            });

                        column.data().unique().sort().each(function (d, j) {
                            select.append('<option value="' + d + '">' + d + '</option>')
                        });
                    });
                   
                }
            });
        }

        function createHeadForLoggerChanged(data) {
            let head = document.getElementById('headBody');
            let content = "";

            head.innerHTML = "";
            if (checkExistsData(data)) {
                content += `<tr>
                                <th>Thời Gian</th>
                                <th>Áp lực</th>
                                <th>Lưu lượng</th>
                                <th>Index thuận</th>
                                <th>Index nghịch</th>
                                <th>Index Net</th>
                            </tr>`
            }
            head.innerHTML = content;
        }

        function createFooterForLoggerChanged(data) {
            let footer = document.getElementById('footer');
            let content = "";

            footer.innerHTML = "";
            if (checkExistsData(data)) {
                content += ` <tr>
                                <th>Thời Gian</th>
                                <th>Áp lực</th>
                                <th>Lưu lượng</th>
                                <th>Index thuận</th>
                                <th>Index nghịch</th>
                                <th>Index Net</th>
                            </tr>`
            }
            footer.innerHTML = content;
        }


    </script>
</asp:Content>