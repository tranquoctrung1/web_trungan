<%@ Page Language="C#" MasterPageFile="~/_supervisor/master_page.master" AutoEventWireup="true" CodeFile="DashBoard.aspx.cs" Inherits="_supervisor_Dashboard_DashBoard" %>

<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="Server">
    <link href="../../css/Config.css" rel="stylesheet">
    <style>
        .box2 {
            text-align: center;
            border-radius: 5px;
            box-shadow: 0 0 3px 0 rgba(0,0,0,.2);
            padding: 5px
        }

            .box2 h5 {
                border-bottom: none !important;
                font-weight: 500 !important;
                color: #0984e3 !important;
                font-size: 1.5rem !important
            }

                .box2 h5.prev {
                    color: #0f5aa6 !important
                }

            .box2 .fa {
                color: #74b9ff;
                margin-right: 5px;
                font-size: 1.8rem
            }

            .box2 span {
                font-weight: 500;
                font-size: 1.5rem !important
            }

        .chart {
            width: 100%;
            height: 400px
        }

        .table {
            height: 200px;
            text-align: center
        }

        .box-table {
            height: 200px;
            overflow-x: scroll;
            overflow-y: scroll
        }
    </style>

    <script type="text/javascript">
        // preventing resubmition form application
        window.history.replaceState('', '', window.location.href)
    </script>
    <script src="https://cdn.amcharts.com/lib/4/core.js"></script>
    <script src="https://cdn.amcharts.com/lib/4/charts.js"></script>
    <script src="https://cdn.amcharts.com/lib/4/themes/animated.js"></script>
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="Server">
    <div id="main-content2">
        <div class="container-fluid m-t">
            <div class="row">
                <div class="col-sm-12">
                    <div class="group-text">
                        <div class="row">
                            <span>Mã point</span>
                        </div>
                        <div class="row m-b">
                            <telerik:RadComboBox ID="cboSiteIds" runat="server"
                                DataSourceID="SitesDataSource" DataTextField="Id" DataValueField="Id"
                                AllowCustomText="True" DropDownWidth="350px" EnableLoadOnDemand="True"
                                Filter="StartsWith" HighlightTemplatedItems="True" OnClientSelectedIndexChanged="cboSiteIds_selectedindexchanged"
                                AutoPostBack="false">
                                <HeaderTemplate>

                                    <table cellpadding="0" cellspacing="0">
                                        <tr>
                                            <td style="width: 50px">Mã NV</td>
                                            <td style="width: 50px">Mã vị trí</td>
                                            <td style="width: 250px">Vị trí</td>
                                        </tr>
                                    </table>
                                </HeaderTemplate>
                                <ItemTemplate>
                                    <table cellpadding="0" cellspacing="0">
                                        <tr>
                                            <td style="width: 50px"><%#DataBinder.Eval(Container.DataItem,"StaffId") %></td>
                                            <td style="width: 50px"><%#DataBinder.Eval(Container.DataItem,"Id") %></td>
                                            <td style="width: 250px"><%#DataBinder.Eval(Container.DataItem,"Location") %></td>
                                        </tr>
                                    </table>
                                </ItemTemplate>
                            </telerik:RadComboBox>
                            <asp:ObjectDataSource ID="SitesDataSource" runat="server"
                                OldValuesParameterFormatString="original_{0}" SelectMethod="GetAll"
                                TypeName="SitesBLL"></asp:ObjectDataSource>
                        </div>
                    </div>
                </div>
                <div class="col-sm-4 m-t">
                    <div class="row">
                        <div class="col-sm-6">
                            <div class="box2">
                                <h5>Hôm nay (m<sup>3</sup>)</h5>
                                <div>
                                    <i class="fa fa-tint" aria-hidden="true"></i>
                                    <span id="today"></span>
                                </div>
                            </div>
                        </div>
                        <div class="col-sm-6">
                            <div class="box2">
                                <h5 class="prev">Hôm qua (m<sup>3</sup>)</h5>
                                <div>
                                    <i class="fa fa-tint" aria-hidden="true"></i>
                                    <span id="yesterday"></span>
                                </div>
                            </div>
                        </div>
                    </div>
                    <div class="col-sm-12">
                        <div id="chart-day" class="chart">
                        </div>
                    </div>
                    <div class="col-sm-12">
                        <div class="box-table">
                            <table class="table table-striped table-hover table-bordered">
                                <thead>
                                    <tr>
                                        <th scope="col">Thời Gian</th>
                                        <th scope="col">Giá Trị</th>
                                    </tr>
                                </thead>
                                <tbody id="tableDay">
                                </tbody>
                            </table>
                        </div>
                    </div>
                </div>
                <div class="col-sm-4 m-t">
                    <div class="row">
                        <div class="col-sm-6">
                            <div class="box2">
                                <h5>Tháng nay (m<sup>3</sup>)</h5>
                                <div>
                                    <i class="fa fa-tint" aria-hidden="true"></i>
                                    <span id="currentMonth"></span>
                                </div>
                            </div>
                        </div>
                        <div class="col-sm-6">
                            <div class="box2">
                                <h5 class="prev">Tháng trước (m<sup>3</sup>)</h5>
                                <div>
                                    <i class="fa fa-tint" aria-hidden="true"></i>
                                    <span id="lastMonth"></span>
                                </div>
                            </div>
                        </div>
                        <div class="col-sm-12">
                            <div id="chart-month" class="chart">
                            </div>
                        </div>
                        <div class="col-sm-12">
                            <div class="box-table">
                                <table class="table table-striped table-hover table-bordered">
                                    <thead>
                                        <tr>
                                            <th scope="col">Thời Gian</th>
                                            <th scope="col">Giá Trị</th>
                                        </tr>
                                    </thead>
                                    <tbody id="tableMonth">
                                    </tbody>
                                </table>
                            </div>
                        </div>
                    </div>
                </div>
                <div class="col-sm-4 m-t">
                    <div class="row">
                        <div class="col-sm-6">
                            <div class="box2">
                                <h5>Năm nay (m<sup>3</sup>)</h5>
                                <div>
                                    <i class="fa fa-tint" aria-hidden="true"></i>
                                    <span id="currentYear"></span>
                                </div>
                            </div>
                        </div>
                        <div class="col-sm-6">
                            <div class="box2">
                                <h5 class="prev">Năm trước (m<sup>3</sup>)</h5>
                                <div>
                                    <i class="fa fa-tint" aria-hidden="true"></i>
                                    <span id="lastYear"></span>
                                </div>
                            </div>
                        </div>
                        <div class="col-sm-12">
                            <div id="chart-year" class="chart">
                            </div>
                        </div>
                        <div class="col-sm-12">
                            <div class="box-table">
                                <table class="table table-striped table-hover table-bordered">
                                    <thead>
                                        <tr>
                                            <th scope="col">Thời Gian</th>
                                            <th scope="col">Giá Trị</th>
                                        </tr>
                                    </thead>
                                    <tbody id="tableYear">
                                    </tbody>
                                </table>
                            </div>
                        </div>
                    </div>
                </div>
            </div>

        </div>
       
    </div>
    <script src="https://cdn.jsdelivr.net/npm/axios/dist/axios.min.js"></script>
    <script>
        let isDone = true;
        function checkExistData(data) {
            if (data.length != 0)
                return true;
            return false;
        }

        function isEmpty(obj) {
            for (var prop in obj) {
                if (obj.hasOwnProperty(prop))
                    return false;
            }

            return true;
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

        async function getDataForDay() {
            var hostname = window.location.origin;
            if (hostname.indexOf("localhost") < 0)
                hostname = hostname + "/VivaServices/";
            else
                hostname = "http://localhost:57880";

            let siteIDCbo = $find('<%=cboSiteIds.ClientID %>');
            if (CheckSiteIdExists(siteIDCbo)) {
                let siteid = siteIDCbo.get_selectedItem().get_value();
                console.log(siteid)

                // date time now 
                let now = Date.now();
                now = new Date(now);
                let year = now.getFullYear();
                let month = now.getMonth();
                let day = now.getDate();
                let startDateNow = new Date(year, month, day, 0, 0, 0);
                let temp = new Date(year, month, day, 0, 0, 0);
                let endDateNow = new Date(temp.setDate(temp.getDate() + 1));

                let startDatePre = new Date(year, month, day - 1, 0, 0, 0);
                let temp2 = new Date(year, month, day - 1, 0, 0, 0);
                let endDatePre = new Date(temp2.setDate(temp2.getDate() + 1));

                let totalTimeStartNow = startDateNow.getTime() / 1000;
                let totalTimeEndNow = endDateNow.getTime() / 1000;

                let totalTimeStartPre = startDatePre.getTime() / 1000;
                let totalTimeEndPre = endDatePre.getTime() / 1000;

                let urlGetDataNow = `${hostname}/api/getdatadashboarddailysite/${siteid}/${totalTimeStartNow}/${totalTimeEndNow}`;
                let urlGetDataPre = `${hostname}/api/getdatadashboarddailysite/${siteid}/${totalTimeStartPre}/${totalTimeEndPre}`;
                let urlGetDataHourNow = `${hostname}/api/getdatadashboardhourlysite/?siteid=${siteid}&start=${totalTimeStartNow}&end=${totalTimeEndNow}`;

                let dataDayForNow = await axios.get(urlGetDataNow);
                fillDataDaynow(dataDayForNow.data, "today");
                let dataDayFowPre = await axios.get(urlGetDataPre);
                fillDataDayPre(dataDayFowPre.data, "yesterday");
                let dataHourForNow = await axios.get(urlGetDataHourNow);

                drawChart(dataHourForNow.data, "chart-day");
                createBodyTable(dataHourForNow.data, "tableDay")
            }
            else {
                alert("Mã point rỗng");
                return;
            }
        }

        async function getDataForMonth() {
            var hostname = window.location.origin;
            if (hostname.indexOf("localhost") < 0)
                hostname = hostname + "/VivaServices/";
            else
                hostname = "http://localhost:57880";

            let siteIDCbo = $find('<%=cboSiteIds.ClientID %>');
            if (CheckSiteIdExists(siteIDCbo)) {
                let siteid = siteIDCbo.get_selectedItem().get_value();

                // date time now 
                let now = Date.now();
                now = new Date(now);
                let year = now.getFullYear();
                let month = now.getMonth();
                let day = now.getDate();
                let startDateNow = new Date(year, month, 1, 0, 0, 0);
                let temp = new Date(year, month, 1, 0, 0, 0);
                let temp2 = new Date(year, month, 1, 0, 0, 0);
                let endDateNow = new Date(temp.setMonth(temp.getMonth() + 1));

                let startDatePre = new Date(temp2.setMonth(temp2.getMonth() - 1));
                let endDatePre = startDateNow;

                let totalTimeStartNow = startDateNow.getTime() / 1000;
                let totalTimeEndNow = endDateNow.getTime() / 1000;

                let totalTimeStartPre = startDatePre.getTime() / 1000;
                let totalTimeEndPre = endDatePre.getTime() / 1000;

                let urlGetDataNow = `${hostname}/api/getdatadashboardmonthlysite/${siteid}/${totalTimeStartNow}/${totalTimeEndNow}`;
                let urlGetDataPre = `${hostname}/api/getdatadashboardmonthlysite/${siteid}/${totalTimeStartPre}/${totalTimeEndPre}`;
                let urlGetDataHourNow = `${hostname}/api/getdatadashboarddailysite/${siteid}/${totalTimeStartNow}/${totalTimeEndNow}`;

                let dataDayForNow = await axios.get(urlGetDataNow);
                fillDataDaynow(dataDayForNow.data, "currentMonth");
                let dataDayFowPre = await axios.get(urlGetDataPre);
                fillDataDayPre(dataDayFowPre.data, "lastMonth");
                let dataHourForNow = await axios.get(urlGetDataHourNow);

                drawChart(dataHourForNow.data, "chart-month");
                createBodyTable(dataHourForNow.data, "tableMonth")
            }
            else {
                alert("Mã point rỗng");
                return;
            }
        }

        async function getDataForYear() {
            var hostname = window.location.origin;
            if (hostname.indexOf("localhost") < 0)
                hostname = hostname + "/VivaServices/";
            else
                hostname = "http://localhost:57880";

            let siteIDCbo = $find('<%=cboSiteIds.ClientID %>');
            if (CheckSiteIdExists(siteIDCbo)) {
                let siteid = siteIDCbo.get_selectedItem().get_value();

                // date time now 
                let now = Date.now();
                now = new Date(now);
                let year = now.getFullYear();
                let month = now.getMonth();
                let day = now.getDate();
                let startDateNow = new Date(year, 0, 1, 0, 0, 0);
                let temp = new Date(year, 1, 0, 0, 0, 0);
                let temp2 = new Date(year, 1, 0, 0, 0, 0);
                let endDateNow = new Date(temp.setFullYear(temp.getFullYear() + 1));

                let startDatePre = new Date(temp2.setFullYear(temp2.getFullYear() - 1));
                let endDatePre = startDateNow;

                let totalTimeStartNow = startDateNow.getTime() / 1000;
                let totalTimeEndNow = endDateNow.getTime() / 1000;

                let totalTimeStartPre = startDatePre.getTime() / 1000;
                let totalTimeEndPre = endDatePre.getTime() / 1000;

                let urlGetDataNow = `${hostname}/api/getdatadashboardyearlysite/${siteid}/${totalTimeStartNow}/${totalTimeEndNow}`;
                let urlGetDataPre = `${hostname}/api/getdatadashboardyearlysite/${siteid}/${totalTimeStartPre}/${totalTimeEndPre}`;
                let urlGetDataHourNow = `${hostname}/api/getdatadashboardmonthlysite/${siteid}/${totalTimeStartNow}/${totalTimeEndNow}`;

                let dataDayForNow = await axios.get(urlGetDataNow);
                fillDataDaynow(dataDayForNow.data, "currentYear");
                let dataDayFowPre = await axios.get(urlGetDataPre);
                fillDataDayPre(dataDayFowPre.data, "lastYear");
                let dataHourForNow = await axios.get(urlGetDataHourNow);

                drawChart(dataHourForNow.data, "chart-year");
                createBodyTable(dataHourForNow.data, "tableYear")
            }
            else {
                alert("Mã point rỗng");
                return;
            }
        }

        function fillDataDaynow(data, location) {
            let today = document.getElementById(`${location}`);
            if (checkExistData(data)) {
                today.innerHTML = data[0].Value;
            }
            else {
                today.innerHTML = "";
            }
        }

        function fillDataDayPre(data, location) {
            let yesterday = document.getElementById(`${location}`);
            if (checkExistData(data)) {
                yesterday.innerHTML = data[0].Value;
            }
            else {
                yesterday.innerHTML = "";
            }
        }

        function CheckSiteIdExists(siteIDCbo) {
            if (siteIDCbo == null || siteIDCbo == undefined || siteIDCbo.get_selectedItem() == null || siteIDCbo.get_selectedItem() == undefined || siteIDCbo.get_selectedItem().toString().trim() == "") {
                return false;
            }
            return true;
        }

        function createBodyTable(data, location) {
            let dataTable = document.getElementById(`${location}`);

            dataTable.innerHTML = "";
            let content = "";

            for (let i = 0; i < data.length - 1; i++) {
                content += `<tr>`;
                content += `<td>${convertDate(data[i].TimeStamp)}</td><td>${data[i].Value}</td>`;
                content += `</tr>`;
            }

            if (content == "") {
                content = `<tr><td>Không có dữ liệu</td></tr>`
            }

            dataTable.innerHTML = content;
        }

        function drawChart(dataInput, location) {
            am4core.ready(function () {

                // Themes begin
                am4core.useTheme(am4themes_animated);
                // Themes end

                var chart = am4core.create(`${location}`, am4charts.XYChart);

                var data = [];
                for (let i = 0; i < dataInput.length - 1; i++) {
                    if (dataInput[i] != null && dataInput[i] != undefined) {
                        let obj = {};
                        if (dataInput[i].TimeStamp != null && dataInput[i].TimeStamp != undefined) {
                            let date = new Date(convertDateFromApi(dataInput[i].TimeStamp));
                            obj.date = date;
                        }
                        if (dataInput[i].Value != null && dataInput[i].Value != undefined) {
                            let value = dataInput[i].Value;
                            obj.value = value;
                        }
                        data.push(obj);
                    }
                }

                chart.data = data;

                // Create axes
                var dateAxis = chart.xAxes.push(new am4charts.DateAxis());
                dateAxis.renderer.minGridDistance = 60;

                var valueAxis = chart.yAxes.push(new am4charts.ValueAxis());

                // Create series
                var series = chart.series.push(new am4charts.LineSeries());
                series.dataFields.valueY = "value";
                series.dataFields.dateX = "date";
                series.tooltipText = "{value}"

                series.tooltip.pointerOrientation = "vertical";

                chart.cursor = new am4charts.XYCursor();
                chart.cursor.snapToSeries = series;
                chart.cursor.xAxis = dateAxis;

                //chart.scrollbarY = new am4core.Scrollbar();
                chart.scrollbarX = new am4core.Scrollbar();

            });
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


        window.addEventListener('DOMContentLoaded', (event) => {
            setTimeout(function () {
                getDataForDay();
            }, 0);
            setTimeout(function () { getDataForMonth(); }, 0);
            setTimeout(function () { getDataForYear(); }, 0);
        });

        function cboSiteIds_selectedindexchanged(sender, eventArgs) {
            setTimeout(function () {
                getDataForDay();
            }, 0);
            setTimeout(function () { getDataForMonth(); }, 0);
            setTimeout(function () { getDataForYear(); }, 0);
        }

    </script>
</asp:Content>
