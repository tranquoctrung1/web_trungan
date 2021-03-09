<%@ Page Language="C#" MasterPageFile="~/_supervisores/master_page.master" AutoEventWireup="true" CodeFile="AlarmTableForPoint.aspx.cs" Inherits="_supervisores_alarm_AlarmTableForPoint" %>

<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="Server">
    <link href="../../css/Config.css" rel="stylesheet">
    <style>
        #body {
            background: #5db7fe69;
            font-weight: 500
        }

        .table-hover > tbody > tr:hover {
            background-color: #539ed9 !important;
        }

        .d-flex {
            justify-content: space-between;
            align-items: center;
            margin-bottom: 10px;
            padding: 0 15px !important
        }

        .search-area {
            display: flex;
            justify-content: center;
            align-items: center;
        }

        .table-result {
            width: 100%;
            height: 85vh;
            overflow-y: scroll;
            overflow-x: scroll;
        }

         #loading {
            width: 50px;
            height: 50px
        }

            #loading.hide {
                display: none;
            }
            #loading.show 
            {
                display: inline
            }


    </style>
    <script type="text/javascript">
        // preventing resubmition form application
        window.history.replaceState('', '', window.location.href)
    </script>
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="Server">
    <div id="main-content2">
        <div id="main-content-title">
            <h2 class="title">Bảng Cảnh Báo Cho Point</h2>
        </div>
        <div class="container-fluid m-t">
            <div class="row">
                <div class="col-sm-12">
                    <div>
                        <div class="col-sm-5">
                            <div class="m-b col-sm-6 ">
                                <span>Ngày bắt đầu: </span>
                                <telerik:RadDatePicker ID="dtmStart" runat="server" Culture="en-GB"
                                    TabIndex="2">
                                    <Calendar UseRowHeadersAsSelectors="False" UseColumnHeadersAsSelectors="False" ViewSelectorText="x"></Calendar>

                                    <DateInput DisplayDateFormat="dd/MM/yyyy" DateFormat="dd/MM/yyyy" EnableSingleInputRendering="True"
                                        LabelWidth="64px" TabIndex="2">
                                    </DateInput>

                                    <DatePopupButton ImageUrl="" HoverImageUrl="" TabIndex="-1"></DatePopupButton>
                                </telerik:RadDatePicker>
                            </div>
                            <div class="m-b col-sm-6 ">
                                <span>Ngày kết thúc: </span>
                                <telerik:RadDatePicker ID="dtmEnd" runat="server" Culture="en-GB"
                                    TabIndex="2">
                                    <Calendar UseRowHeadersAsSelectors="False" UseColumnHeadersAsSelectors="False" ViewSelectorText="x"></Calendar>

                                    <DateInput DisplayDateFormat="dd/MM/yyyy" DateFormat="dd/MM/yyyy" EnableSingleInputRendering="True"
                                        LabelWidth="64px" TabIndex="2">
                                    </DateInput>

                                    <DatePopupButton ImageUrl="" HoverImageUrl="" TabIndex="-1"></DatePopupButton>
                                </telerik:RadDatePicker>
                            </div>
                        </div>
                        <div class="col-sm-3 m-b">
                            <button class="btn btn-info m-r" onclick="view(); return false;">Xem</button>
                            <%--<button class="btn btn-info m-r" onclick="turn(); return false;" id="btnTurnAlarm" data-turn="-1"></button>--%>
                        </div>
                        <div class="col-sm-4 search-area m-b">
                            <input class="form-control me-2" type="text" placeholder="Vị trí" id="txtSearch">
                            <button class="btn btn-success m-l" type="submit" onclick="searchHandle(); return false;">Tìm Kiếm</button>
                        </div>

                    </div>
                    <div class="table-result">
                        <table class="table table-success table-hover table-bordered">
                            <thead>
                                <tr>
                                    <th scope="col"></th>
                                    <th scope="col">Mã Kênh</th>
                                    <th scope="col">Vị Trí</th>
                                    <th scope="col">Thời Gian Bắt Đầu</th>
                                    <th scope="col">Thời Gian Kết Thúc</th>
                                    <th scope="col">Nội Dung</th>
                                    <th scope="col">Cấp Cảnh Báo</th>
                                </tr>
                            </thead>
                            <tbody id="body">
                                <div class="loading">
                                    <img id="loading" class="hide" src="../../2.gif" />
                                </div>
                            </tbody>
                        </table>
                    </div>
                </div>
            </div>
        </div>
    </div>
    <script src="https://cdn.jsdelivr.net/npm/axios/dist/axios.min.js"></script>
    <script>

        let loadingElement = document.getElementById('loading');

        var hostname = window.location.origin;
        if (hostname.indexOf("localhost") < 0)
            hostname = hostname + "/VivaServices/";
        else
            hostname = "http://localhost:57880";

        function checkExistsData(data) {
            if (data.length > 0)
                return true;
            return false;
        }

      
        let data = [];
        let filterData = [];
        let isFilter = false;

        function getData() {

            loadingElement.classList.add('show');
            loadingElement.classList.remove('hide');

            var start = $find('<%=dtmStart.ClientID %>');
            var end = $find('<%=dtmEnd.ClientID %>');
          
            let now = Date.now();
            now = new Date(now);
            let date = new Date(now.getFullYear(), now.getMonth(), now.getDate(), 0, 0, 0);
            let temp = new Date(now.getFullYear(), now.getMonth(), now.getDate(), 0, 0, 0);
            let startDate = new Date(temp.setDate(temp.getDate() - 1));

            start.set_selectedDate(startDate);
            end.set_selectedDate(date);

            let totalSecondStart = startDate.getTime() / 1000;
            let totalSecondEnd = date.getTime() / 1000;

            console.log(localStorage.getItem("supervisor"))

            let url = `${hostname}/api/getalarmforpointbyuid?uid=${localStorage.getItem("supervisor")}&start=${totalSecondStart}&end=${totalSecondEnd}`;

            axios.get(url).then((res) => {
                data = res.data;
                loadingElement.classList.add('hide');
                createBody(data);
            }).catch((err) => console.log(err))
        }

        function isEmpty(obj) {
            for (var prop in obj) {
                if (obj.hasOwnProperty(prop))
                    return false;
            }

            return true;
        }

        function createBody(data) {
            let body = document.getElementById('body');

            let content = "";

            if (checkExistsData(data)) {
                for (let item of data) {
                    let color = "black";
                    let contentAlarm = "";
                    if (item != null && item != undefined && !isEmpty(item)) {

                        if (item.IsFinish == false || item.IsFinish == 0) {
                            color = "red";
                        }

                        content += `<tr style="color: ${color}">`;

                        // font alert
                        if (item.IsFinish == false || item.IsFinish == 0) {
                            content += `<td><i class="fa fa-exclamation-circle" aria-hidden="true"></i></td>`;
                        }
                        else {
                            content += `<td><i class="fa fa-check-circle" aria-hidden="true" style="color: lime"></i></td>`;
                        }

                        content += `<td>${item.ChannelId}</td>`;

                        content += `<td>${item.Location}</td>`;

                        content += `<td>${convertDateTime(item.StartDateAlarm)}</td>`;

                        content += `<td>${convertDateTime(item.EndDateAlarm)}</td>`;

                        content += `<td>${item.Content}</td>`;

                        content += `<td>${item.Level}</td>`;

                        content += `<tr>`;
                        }
                    }

            }
            else {
                content += `<tr><td  colspan="7"> Không có dữ liệu</td></tr>`
            }

            if (content != null && content != undefined && content.trim() != "") {
                body.innerHTML = "";
                body.innerHTML = content;
            }
        }


        function convertDateTime(date) {
            if (date != null) {
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
            return "";
        }

        function searchHandle() {
            let txtSearch = document.getElementById('txtSearch');

            filterData = data.filter((item) => item.Location.toLowerCase().indexOf(txtSearch.value.toLowerCase()) !== -1);

            createBody(filterData);

            isFilter = true;
        }

        function view() {
            let start = $find('<%=dtmStart.ClientID %>');
            let end = $find('<%=dtmEnd.ClientID %>');

            if (start == null || start == undefined || start.get_selectedDate() == null || start.get_selectedDate() == undefined) {
                alert("Chưa chọn ngày bắt đầu")
                return false;
            }
            else if (end == null || end == undefined || end.get_selectedDate() == null || end.get_selectedDate() == undefined) {
                alert("Chưa chọn ngày kết thúc")
                return false;
            }
            else {
                getDataWithTime(start, end);
            }
        }

        function getDataWithTime(start, end) {
            let timeStart = start.get_selectedDate();
            let timeEnd = end.get_selectedDate();

            let totalSecondStart = timeStart.getTime() / 1000;
            let totalSecondEnd = timeEnd.getTime() / 1000;

            let url = `${hostname}/api/getalarmforpointbyuid?uid=${localStorage.getItem("supervisor")}&start=${totalSecondStart}&end=${totalSecondEnd}`;

            axios.get(url).then((res) => {
                data = res.data;
                loadingElement.classList.add('hide');
                createBody(data);
            }).catch((err) => console.log(err))

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

        //function getTurnHistotyAlarm() {
        //    let url = `${hostname}/api/getturnhistoryalarm?type=Point`;

        //    axios.get(url).then((res) => {
        //        if (res.data == false || res.data == "false") {
        //            let btnTurnAlarm = document.getElementById('btnTurnAlarm');
        //            btnTurnAlarm.innerHTML = "Bật cảnh báo";
        //            btnTurnAlarm.dataset.turn = "true"
        //        }
        //        else if (res.data == true || res.data == "true") {
        //            let btnTurnAlarm = document.getElementById('btnTurnAlarm');
        //            btnTurnAlarm.innerHTML = "Tắt cảnh báo";
        //            btnTurnAlarm.dataset.turn = "false"
        //        }
        //    }).catch(err => console.log(err))
        //}

        //function turn() {
        //    let btnTurnAlarm = document.getElementById('btnTurnAlarm');

        //    let url = `${hostname}/api/updateturnhistoryalarm?ison=${btnTurnAlarm.dataset.turn}&type=Point`;

        //    axios.post(url).then((res) => {
        //        if (res.data.toString() == "1") {
        //            if (btnTurnAlarm.dataset.turn == "true") {
        //                btnTurnAlarm.innerHTML = "Tắt cảnh báo";
        //                btnTurnAlarm.dataset.turn = "false"
        //                alert("Bật cảnh báo thành công")
        //            }
        //            else {
        //                btnTurnAlarm.innerHTML = "Bật cảnh báo";
        //                btnTurnAlarm.dataset.turn = "true"
        //                let body = document.getElementById('body');
        //                body.innerHTML = `<tr><td  colspan="7"> Không có dữ liệu</td></tr>`;
        //                alert("Tắt cảnh báo thành công")
        //            }
        //        }
        //    }).catch(err => console.log(err))
        //}

        window.addEventListener('load', (event) => {
            //getTurnHistotyAlarm();
            // call get data
            getData();
          
        });

    </script>

</asp:Content>
