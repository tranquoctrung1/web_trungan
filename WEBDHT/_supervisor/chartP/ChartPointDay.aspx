<%@ Page Language="C#" MasterPageFile="~/_supervisor/master_page.master" AutoEventWireup="true" CodeFile="ChartPointDay.aspx.cs" Inherits="_supervisor_chartP_ChartPointDay" %>
<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="Server">
     <link href="../../css/Config.css" rel="stylesheet">
    <style type="text/css">
        

        #chart {
            position: relative;
            bottom: -40px;
            height: 440px
        }
         #titleChart {
            font-weight: bolder;
            font-size: xx-large
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
        <div id="main-content-title">
            <h2 class="title">Đồ Thị Ngày Theo Point</h2>
        </div>
        <div class="container-fluid m-t">
            <div class="row">
                <div class="col-sm-4">
                    <div class="group-text">
                        <div class="row">
                            <span>Mã point</span>
                        </div>
                        <div class="row m-b">
                            <telerik:RadComboBox ID="cboSiteIds" runat="server"
                                DataSourceID="SitesDataSource" DataTextField="Id" DataValueField="Id"
                                AllowCustomText="True" DropDownWidth="350px" EnableLoadOnDemand="True"
                                Filter="StartsWith" HighlightTemplatedItems="True"
                                AutoPostBack="false" onclientselectedindexchanged="OnClientSelectedIndexChanged">
                                <HeaderTemplate>
                                    <%--OnSelectedIndexChanged="cboSiteIds_SelectedIndexChanged"--%>
                                    <table cellpadding="0" cellspacing="0">
                                        <tr>
                                            <td style="width: 50px">Mã vị trí</td>
                                            <td style="width: 250px">Vị trí</td>
                                        </tr>
                                    </table>
                                </HeaderTemplate>
                                <ItemTemplate>
                                    <table cellpadding="0" cellspacing="0">
                                        <tr>
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

                <div class="col-sm-4">
                    <div class="group-text">
                        <div class="row">
                            <span>Ngày bắt đầu</span>
                        </div>
                        <div class="row m-b">
                            <telerik:RadDatePicker ID="dtmStart" runat="server" Culture="en-GB">
                                <Calendar UseColumnHeadersAsSelectors="False" UseRowHeadersAsSelectors="False"
                                    ViewSelectorText="x">
                                </Calendar>
                                <DateInput DateFormat="dd/MM/yyyy" DisplayDateFormat="dd/MM/yyyy"
                                    EnableSingleInputRendering="True" LabelWidth="64px">
                                </DateInput>
                                <DatePopupButton HoverImageUrl="" ImageUrl="" TabIndex="-1" />
                            </telerik:RadDatePicker>
                        </div>
                    </div>
                </div>
                <div class="col-sm-4">
                    <div class="group-text">
                        <div class="row">
                            <span>Ngày kết thúc</span>
                        </div>
                        <div class="row m-b">
                            <telerik:RadDatePicker ID="dtmEnd" runat="server" Culture="en-GB">
                                <Calendar UseColumnHeadersAsSelectors="False" UseRowHeadersAsSelectors="False"
                                    ViewSelectorText="x">
                                </Calendar>
                                <DateInput DateFormat="dd/MM/yyyy" DisplayDateFormat="dd/MM/yyyy"
                                    EnableSingleInputRendering="True" LabelWidth="64px">
                                </DateInput>
                                <DatePopupButton HoverImageUrl="" ImageUrl="" TabIndex="-1" />
                            </telerik:RadDatePicker>
                        </div>
                    </div>
                </div>
            </div>
            <div class="row">
                <div class="text-center col-sm-12 m-t no-padding" style="clear: both;">
                    <button class="btn btn-primary" id="btnView" onclick="btnViewOnClick(); return false;">Xem</button>
                </div>
            </div>
        </div>
        <div class="container-fluid m-t">
            <div class="row">
                <div class="col">
                    <div id="titleChart" class="text-center"></div>
                    <div id="chart">
                    </div>
                </div>
            </div>
        </div>
    </div>
     <script src="https://cdn.jsdelivr.net/npm/axios/dist/axios.min.js"></script>
    <script>


        function btnViewOnClick() {
            let siteIDCbo = $find('<%=cboSiteIds.ClientID %>');
            let start = $find('<%=dtmStart.ClientID %>');
            let end = $find('<%=dtmEnd.ClientID %>');
            if (siteIDCbo == null || siteIDCbo == undefined || siteIDCbo.get_selectedItem() == null || siteIDCbo.get_selectedItem() == undefined) {
                alert("Chưa chọn mã point")
                return false;
            }
            else if (start == null || start == undefined || start.get_selectedDate() == null || start.get_selectedDate() == undefined) {
                alert("Chưa chọn ngày bắt đầu")
                return false;
            }
            else if (end == null || end == undefined || end.get_selectedDate() == null || end.get_selectedDate() == undefined) {
                alert("Chưa chọn ngày kết thúc")
                return false;
            }
            else {
                let siteID = siteIDCbo.get_selectedItem().get_value();
               

                callAPIAndDrawChart(siteID, end, start)
            }
        }

        function OnClientSelectedIndexChanged(sender, eventArgs) {
            let siteid = eventArgs.get_item().get_value();
            let start = $find('<%=dtmStart.ClientID %>');
            let end = $find('<%=dtmEnd.ClientID %>');

            callAPITimeAndDrawChart(siteid, end, start)
        }

        function callAPIAndDrawChart(siteid, end, start) {
            // call api to set time end and time start

            // detection localhost or ip address
            var hostname = window.location.origin;
            if (hostname.indexOf("localhost") < 0)
                hostname = hostname + "/VivaServices/";
            else
                hostname = "http://localhost:57880";

            let timeStart = start.get_selectedDate();
            let timeEnd = end.get_selectedDate();

            let totalSecondStart = timeStart.getTime() / 1000;
            let totalSecondEnd = timeEnd.getTime() / 1000;

            let urlGetDataChart = `${hostname}/api/getdatareportdailysite/${siteid}/${totalSecondStart}/${totalSecondEnd}`;

            axios.get(urlGetDataChart).then((res) => {
                if (checkExistsData(res.data)) {
                    //drawChart(sortingData(convertData(res.data)), getListChannel(res.data));
                    let titleChart = document.getElementById('titleChart');
                    titleChart.innerHTML = `Đồ thị sản lượng ngày theo point ${siteid}`;
                    drawChartQuantity(converDataQuantity(res.data));
                }
                else {
                    start.set_selectedDate(null);
                    end.set_selectedDate(null);
                    document.getElementById("chart").innerHTML = "";
                }
            }).catch(err => console.log(err));

        }

        function checkExistsData(data) {
            if (data.length > 0)
                return true;
            return false;
        }

        function callAPITimeAndDrawChart(siteid, end, start) {
            // call api to set time end and time start

            // detection localhost or ip address
            var hostname = window.location.origin;
            if (hostname.indexOf("localhost") < 0)
                hostname = hostname + "/VivaServices/";
            else
                hostname = "http://localhost:57880";

            let urlGetTime = `${hostname}/api/gettime/?siteid=${siteid}`;
            axios.get(urlGetTime).then((res) => {
                // set default time for start and end 
                if (res.data != null && res.data != undefined && res.data.trim() != "") {
                    let date = new Date(Date.parse(convertDateFromApi(res.data)))
                    let temp = new Date(Date.parse(convertDateFromApi(res.data)))
                    let startDate = new Date(temp.setDate(temp.getDate() - 10));
                    startDate = new Date(startDate.getFullYear(), startDate.getMonth(), startDate.getDate(), 0, 0, 0);

                    start.set_selectedDate(startDate);
                    end.set_selectedDate(date);

                    let totalSecondStart = startDate.getTime() / 1000;
                    let totalSecondEnd = date.getTime() / 1000;

                    let urlGetDataChart = `${hostname}/api/getdatareportdailysite/${siteid}/${totalSecondStart}/${totalSecondEnd}`;

                    axios.get(urlGetDataChart).then((res) => {
                        if (checkExistsData(res.data)) {
                            //drawChart(sortingData(convertData(res.data)), getListChannel(res.data));
                            let titleChart = document.getElementById('titleChart');
                            titleChart.innerHTML = `Đồ thị sản lượng ngày theo point ${siteid}`;
                            drawChartQuantity(converDataQuantity(res.data));
                        }
                        else {
                            start.set_selectedDate(null);
                            end.set_selectedDate(null);
                            document.getElementById("chart").innerHTML = "";
                        }
                    }).catch(err => console.log(err));
                }
                else {
                    start.set_selectedDate(null);
                    end.set_selectedDate(null);
                    document.getElementById("chart").innerHTML = "";
                }
            }).catch((err) => {
                console.log(err);
            })
        }

        function converDataQuantity(data) {
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

            return convertingData;
        }

        // unnecessary
        function getListChannel(data) {
            let listChannel = [];

            for (let item of data) {
                if (item.length > 0) {
                    listChannel.push(item[0].ChannelName)
                }
            }

            return listChannel;
        }

        // unnecessary
        function convertData(data) {
            let convertData = [];
            let isFirst = 0;

            let listChannel = getListChannel(data);

            for (let i of data) {
                if (i.length > 0) {
                    if (isFirst == 0) {
                        for (let item of i) {
                            let obj = {
                                TimeStamp: new Date(convertDateFromApi(item.TimeStamp))
                            }
                            for (let channel of listChannel) {
                                if (channel == item.ChannelName) {
                                    if (item.Value != null && item.Value != undefined) {
                                        obj[channel] = item.Value;
                                    }
                                }
                                else {
                                    obj[channel] = 0;
                                }
                            }
                            convertData.push(obj)
                        }
                        isFirst++;
                    }
                    else {
                        for (let item of i) {
                            let timeStamp = new Date(convertDateFromApi(item.TimeStamp));
                            let result = recursiveFunction(convertData, timeStamp, 0, convertData.length);
                            if (result == -1) {
                                let obj = {
                                    TimeStamp: timeStamp
                                }
                                for (let channel of listChannel) {
                                    if (channel == item.ChannelName) {
                                        if (item.Value != null && item.Value != undefined) {
                                            obj[channel] = item.Value;
                                        }
                                    }
                                    else {
                                        obj[channel] = 0;
                                    }
                                }
                                convertData.push(obj)
                            }
                            else {
                                if (item.Value != null && item.Value != undefined) {
                                    convertData[result][item.ChannelName] = item.Value;
                                }
                                else {
                                    convertData[result][item.ChannelName] = 0;
                                }
                            }
                        }
                    }
                }
            }
            return convertData;
        }

        // unnecessary
        function sortingData(data) {
            return data.sort(function (a, b) { return a.TimeStamp.getTime() - b.TimeStamp.getTime() });
        }

        // unnecessary
        let recursiveFunction = function (arr, x, start, end) {

            // Base Condition 
            if (start > end) return -1;


            // Find the middle index 
            let mid = Math.floor((start + end) / 2);

            // Compare mid with given key x 
            if (arr[mid].TimeStamp.getTime() === x.getTime()) return mid;

            // If element at mid is greater than x, 
            // search in the left half of mid 
            if (arr[mid].TimeStamp.getTime() < x.getTime())
                return recursiveFunction(arr, x, start, mid - 1);
            else

                // If element at mid is smaller than x, 
                // search in the right half of mid 
                return recursiveFunction(arr, x, mid + 1, end);
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

        // unnecessary
        function drawChart(data, listChannel) {
            am4core.ready(function () {

                // Themes begin
                am4core.useTheme(am4themes_animated);
                // Themes end
                am4core.addLicense("ch-custom-attribution");
                // Create chart
                var chart = am4core.create("chart", am4charts.XYChart);

                chart.data = data;

                var dateAxis = chart.xAxes.push(new am4charts.DateAxis());
                dateAxis.renderer.grid.template.location = 0;
                dateAxis.renderer.labels.template.fill = am4core.color("#e59165");

                var dateAxis2 = chart.xAxes.push(new am4charts.DateAxis());
                dateAxis2.renderer.grid.template.location = 0;
                dateAxis2.renderer.labels.template.fill = am4core.color("#dfcc64");

                var valueAxis = chart.yAxes.push(new am4charts.ValueAxis());
                valueAxis.tooltip.disabled = true;
                valueAxis.renderer.labels.template.fill = am4core.color("#e59165");

                valueAxis.renderer.minWidth = 60;

                var valueAxis2 = chart.yAxes.push(new am4charts.ValueAxis());
                valueAxis2.tooltip.disabled = true;
                valueAxis2.renderer.labels.template.fill = am4core.color("#dfcc64");
                valueAxis2.renderer.minWidth = 60;
                valueAxis2.syncWithAxis = valueAxis;

                let colors = ["red", "blue", "green", "yellow", "pink", "orange"];

                for (let channel of listChannel) {

                    let color = colors[Math.floor(Math.random() * 6)];

                    var series = chart.series.push(new am4charts.LineSeries());
                    series.name = channel;
                    series.dataFields.dateX = "TimeStamp";
                    series.dataFields.valueY = channel;
                    series.tooltipText = "{name}: [bold]{valueY.value}[/]";
                    series.fill = am4core.color(color);
                    series.stroke = am4core.color(color);
                    //series.strokeWidth = 3;
                }


                chart.cursor = new am4charts.XYCursor();
                chart.cursor.xAxis = dateAxis2;

                var scrollbarX = new am4charts.XYChartScrollbar();
                scrollbarX.series.push(series);
                chart.scrollbarX = scrollbarX;

                chart.legend = new am4charts.Legend();
                chart.legend.parent = chart.plotContainer;
                chart.legend.zIndex = 100;

                valueAxis2.renderer.grid.template.strokeOpacity = 0.07;
                dateAxis2.renderer.grid.template.strokeOpacity = 0.07;
                dateAxis.renderer.grid.template.strokeOpacity = 0.07;
                valueAxis.renderer.grid.template.strokeOpacity = 0.07;

            }); // end am4core.ready()
        }

        function drawChartQuantity(data) {
            am4core.ready(function () {

                // Themes begin
                am4core.useTheme(am4themes_animated);
                // Themes end
                am4core.addLicense("ch-custom-attribution");
                var chart = am4core.create(`chart`, am4charts.XYChart);

                chart.data = data;

                // Create axes
                var dateAxis = chart.xAxes.push(new am4charts.DateAxis());
                dateAxis.renderer.minGridDistance = 60;

                var valueAxis = chart.yAxes.push(new am4charts.ValueAxis());

                let siteIDCbo = $find('<%=cboSiteIds.ClientID %>');
                let siteID = siteIDCbo.get_selectedItem().get_value();

                // Create series
                var series = chart.series.push(new am4charts.LineSeries());
                series.name = siteID;
                series.dataFields.valueY = "Value";
                series.dataFields.dateX = "TimeStamp";
                series.tooltipText = "{name}: [bold]{valueY.value}[/] m3";

                series.tooltip.pointerOrientation = "vertical";

                chart.cursor = new am4charts.XYCursor();
                chart.cursor.snapToSeries = series;
                chart.cursor.xAxis = dateAxis;

                chart.legend = new am4charts.Legend();
                chart.legend.parent = chart.plotContainer;
                chart.legend.zIndex = 100;

                //chart.scrollbarY = new am4core.Scrollbar();
                chart.scrollbarX = new am4core.Scrollbar();

            });
        }
    </script>
</asp:Content>
