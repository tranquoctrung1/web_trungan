<%@ Page Language="C#" MasterPageFile="~/_supervisor/master_page.master" AutoEventWireup="true" CodeFile="DataLoggerByCycle.aspx.cs" Inherits="_supervisor_logger_DataLoggerByCycle" %>

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
            <h2 class="title">Dữ Liệu Logger Theo Chu Kỳ</h2>
        </div>
        <div class="container-fluid m-t">
            <div class="row">
                <div class="col-sm-3">
                    <div class="group-text">
                        <div class="row">
                            <span>Mã point</span>
                        </div>
                        <div class="row m-b">
                            <telerik:RadComboBox ID="cboIds" runat="server" AllowCustomText="True"
                                EnableLoadOnDemand="True" Filter="StartsWith"
                                HighlightTemplatedItems="True" DataSourceID="IdsDataSource"
                                AutoPostBack="True" OnSelectedIndexChanged="cboIds_SelectedIndexChanged"
                                TabIndex="1">
                            </telerik:RadComboBox>
                            <asp:ObjectDataSource ID="IdsDataSource" runat="server"
                                OldValuesParameterFormatString="original_{0}" SelectMethod="GetAllIds"
                                TypeName="SitesBLL"></asp:ObjectDataSource>
                        </div>
                    </div>
                </div>
                <div class="col-sm-3">
                    <div class="group-text">
                        <div class="row">
                            <span>Mã Kênh</span>
                        </div>
                        <div class="row m-b">
                            <telerik:RadComboBox ID="cboChannels" runat="server" AllowCustomText="True"
                                EnableLoadOnDemand="True" Filter="StartsWith"
                                HighlightTemplatedItems="True"
                                AutoPostBack="false"
                                TabIndex="1">
                            </telerik:RadComboBox>
                        </div>
                    </div>
                </div>
                <div class="col-sm-3">
                    <div class="group-text">
                        <div class="row">
                            <span>Giờ Bắt Đầu</span>
                        </div>
                        <div class="row m-b">
                            <telerik:RadDateTimePicker ID="dtmStart" runat="server" Culture="en-GB"
                                TabIndex="2">
                                <Calendar UseColumnHeadersAsSelectors="False" UseRowHeadersAsSelectors="False"
                                    ViewSelectorText="x">
                                </Calendar>
                                <DateInput DateFormat="dd/MM/yyyy" DisplayDateFormat="dd/MM/yyyy"
                                    EnableSingleInputRendering="True" LabelWidth="64px" TabIndex="2">
                                </DateInput>
                                <DatePopupButton HoverImageUrl="" ImageUrl="" TabIndex="-1" />
                            </telerik:RadDateTimePicker>
                        </div>
                    </div>
                </div>
                <div class="col-sm-3">
                    <div class="group-text">
                        <div class="row">
                            <span>Giờ Kết Thúc</span>
                        </div>
                        <div class="row m-b">
                            <telerik:RadDateTimePicker ID="dtmEnd" runat="server" Culture="en-GB" TabIndex="3">
                                <Calendar UseColumnHeadersAsSelectors="False" UseRowHeadersAsSelectors="False"
                                    ViewSelectorText="x">
                                </Calendar>
                                <DateInput DateFormat="dd/MM/yyyy" DisplayDateFormat="dd/MM/yyyy"
                                    EnableSingleInputRendering="True" LabelWidth="64px" TabIndex="3">
                                </DateInput>
                                <DatePopupButton HoverImageUrl="" ImageUrl="" TabIndex="-1" />
                            </telerik:RadDateTimePicker>
                        </div>
                    </div>

                </div>
                <div class="text-center col-sm-12 m-t m-b no-padding" style="clear: both;">
                    <asp:Button ID="btnView" runat="server" Text="Xem" onclientclick="btnView_Click()"
                        CssClass="btn btn-primary"></asp:Button>

                </div>
            </div>
        </div>
        <div class="container-fluid m-t">
            <div class="row">
                <div class="col-sm-8">
                    <div class="loading-area hide" id="loading">
                        <div class="box-loading">
                            <img src="../../2.gif" />
                        </div>
                    </div>
                    <div id="chart"></div>
                </div>
                <div class="col-sm-4">
                    <div id="tablePlaceHolder"></div>
                </div>
            </div>
        </div>
    </div>
    <telerik:RadNotification ID="ntf" runat="server" Title="Message">
    </telerik:RadNotification>
    <telerik:RadAjaxManagerProxy ID="RadAjaxManagerProxy1" runat="server">
        <AjaxSettings>
            <telerik:AjaxSetting AjaxControlID="cboIds">
                <UpdatedControls>
                    <telerik:AjaxUpdatedControl ControlID="cboChannels" />

                </UpdatedControls>
            </telerik:AjaxSetting>
            <telerik:AjaxSetting AjaxControlID="btnView">
                <UpdatedControls>
                    <telerik:AjaxUpdatedControl ControlID="ntf" />

                </UpdatedControls>
            </telerik:AjaxSetting>

        </AjaxSettings>
    </telerik:RadAjaxManagerProxy>
    <script src="https://cdn.jsdelivr.net/npm/axios/dist/axios.min.js"></script>
    <script src="https://cdn.datatables.net/1.10.23/js/jquery.dataTables.js"></script>
    <script type="text/javascript">

        function btnView_Click() {

            let loadingElement = document.getElementById('loading');

            // show loading area 
            if (!loadingElement.classList.contains('show')) {
                loadingElement.classList.add('show');
            }
            loadingElement.classList.remove('hide');

            let channelid = document.getElementById('ctl00_ContentPlaceHolder1_cboChannels_ClientState');
            let start = document.getElementById('ctl00_ContentPlaceHolder1_dtmStart_dateInput_ClientState');
            let end = document.getElementById('ctl00_ContentPlaceHolder1_dtmEnd_dateInput_ClientState');

            let valueChannelid = JSON.parse(channelid.value).text;
            let valueStart = JSON.parse(start.value).valueAsString;
            let valueEnd = JSON.parse(end.value).valueAsString;

            if (valueChannelid.trim() == "" || valueChannelid == null || valueChannelid == undefined) {
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

                var hostname = window.location.origin;
                if (hostname.indexOf("localhost") < 0)
                    hostname = hostname + "/VivaServices/";
                else
                    hostname = "http://localhost:57880";

                let urlGetDataHistory = `${hostname}/api/GetDataHistory?channelid=${valueChannelid}&start=${totalSecondStart}&end=${totalSecondEnd}`;

                axios.get(urlGetDataHistory).then((res) => {
                    loadingElement.classList.add('hide');
                    loadingElement.classList.remove('show');

                    createTablePlaceHolder();

                    createBodyForLoggerChanged(res.data);
                    drawChartQuantity(res.data);

                }).catch(err => console.log(err))
            }
        }

        function ConvertDateFromValueAsString(date) {
            let string = date.split('-');

            return new Date(parseFloat(string[0]), parseFloat(string[1]) - 1, parseFloat(string[2]), parseFloat(string[3]), parseFloat(string[4]), parseFloat(string[5]));
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
                            if (item.Value != null && item.Value != undefined && item.Value.toString().trim() != "") {
                                content += `<td>${item.Value}</td>`;
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
                content = `<tr><td colspan="15">Không có dữ liệu</td></tr>`;
            }

            createHeadForLoggerChanged(data);
            createFooterForLoggerChanged(data);
            body.innerHTML = content;

            $('#example').DataTable({
                initComplete: function () {
                    this.api().columns([0, 1]).every(function () {
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
                                <th>Giá Trị</th>
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
                                <th>Giá Trị</th>
                            </tr>`
            }
            footer.innerHTML = content;
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


        function drawChartQuantity(data) {
            am4core.ready(function () {

                // Themes begin
                am4core.useTheme(am4themes_animated);
                // Themes end

                var chart = am4core.create(`chart`, am4charts.XYChart);

                let convertingData = [];

                if (checkExistsData(data)) {
                    for (let i = 0; i < data.length - 1; i++) {
                        let obj = {};
                        if (data[i] != null && data[i] != undefined) {
                            if (data[i].TimeStamp != null && data[i].TimeStamp != undefined && data[i].TimeStamp.trim() != "") {
                                if (data[i].Value != null && data[i].Value != undefined && data[i].Value.toString() != "") {
                                    obj.TimeStamp = new Date(convertDateFromApi(data[i].TimeStamp));
                                    obj.Value = data[i].Value;

                                    convertingData.push(obj);
                                }
                            }
                        }
                    }

                }

                convertingData = convertingData.sort(function (a, b) { return a.TimeStamp.getTime() - b.TimeStamp.getTime() });

                chart.data = convertingData;

                // Create axes
                var dateAxis = chart.xAxes.push(new am4charts.DateAxis());
                dateAxis.renderer.minGridDistance = 60;

                var valueAxis = chart.yAxes.push(new am4charts.ValueAxis());

                // Create series
                var series = chart.series.push(new am4charts.LineSeries());
                series.dataFields.valueY = "Value";
                series.dataFields.dateX = "TimeStamp";
                series.tooltipText = "{value}"

                series.tooltip.pointerOrientation = "vertical";

                chart.cursor = new am4charts.XYCursor();
                chart.cursor.snapToSeries = series;
                chart.cursor.xAxis = dateAxis;

                //chart.scrollbarY = new am4core.Scrollbar();
                chart.scrollbarX = new am4core.Scrollbar();

            });
        }
    </script>
</asp:Content>