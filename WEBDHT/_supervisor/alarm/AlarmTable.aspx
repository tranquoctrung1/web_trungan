<%@ Page Language="C#" MasterPageFile="~/_supervisor/master_page.master" AutoEventWireup="true" CodeFile="AlarmTable.aspx.cs" Inherits="_supervisor_alarm_AlarmTable" %>

<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="Server">
    <link href="../../css/Config.css" rel="stylesheet">
    <style>
        #body {
            background: #5db7fe
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
        .table-result 
        {
            width: 100%;
            height: 85vh;
            overflow-y: scroll;
            overflow-x: scroll;
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
            <h2 class="title">Bảng Cảnh Báo</h2>
        </div>
        <div class="container-fluid m-t">
            <div class="row">
                <div class="col-sm-12">
                    <div class="d-flex">
                        <div>
                            <button class="btn btn-info m-r" onclick="reload(); return false;">Tải lại</button>
                        </div>
                        <div class="search-area">
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
                                    <th scope="col" style="width: 17%">Vị Trí</th>
                                    <th scope="col" style="width: 15%">Thời Gian</th>
                                    <th scope="col" style="width: 40%">Nội Dung</th>
                                    <th scope="col" style="width: 7%">Ngưỡng Trên</th>
                                    <th scope="col" style="width: 7%">Ngưỡng Dưới</th>
                                </tr>
                            </thead>
                            <tbody id="body">
                            </tbody>
                        </table>
                    </div>
                </div>
            </div>
        </div>
    </div>
    <script src="https://cdn.jsdelivr.net/npm/axios/dist/axios.min.js"></script>
    <script>

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
            let url = `${hostname}/api/getvaluealarm/?uid=admin`

            axios.get(url).then((res) => {
                data = res.data;
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
                        if (item.Status != null && item.Status != undefined && item.Status.trim() != "") {
                            if (item.Status == "Delay") {
                                color = "yellow" // yellow for delay signal
                                contentAlarm = `Kênh ${item.Namepath} đã gữi trễ dữ liệu `;
                            }
                            else if (item.Status == "High" || item.Status == "Low") {
                                color = "#eb2f06" // red for over base signal
                                if (item.Status == "High") {
                                    contentAlarm = `Kênh ${item.Namepath} đã vượt ngưỡng trên ${item.BaseMax} với giá trị hiện tại là ${item.LasValue}`;
                                }
                                else {
                                    contentAlarm = `Kênh ${item.Namepath} đã vượt ngưỡng dưới ${item.BaseMin} với giá trị hiện tại là ${item.LasValue}`;
                                }
                            }

                            content += `<tr style="color: ${color}">`;
                            // font alert
                            content += `<td><i class="fa fa-exclamation-circle" aria-hidden="true"></i></td>`;
                            // channel id
                            if (item.Namepath != null && item.Namepath != undefined && item.Namepath.trim() != "") {
                                content += `<td>${item.Namepath}</td>`;
                            }
                            else {
                                content += `<td> </td>`;
                            }
                            // localtion 
                            if (item.AliasName != null && item.AliasName != undefined && item.AliasName.trim() != "") {
                                content += `<td>${item.AliasName}</td>`;
                            }
                            else {
                                content += `<td> </td>`;
                            }
                            // timestamp
                            if (item.TimeStamp != null && item.TimeStamp != undefined && item.TimeStamp.trim() != "") {
                                content += `<td>${convertDateTime(item.TimeStamp)}</td>`;
                            }
                            else {
                                content += `<td> </td>`;
                            }
                            // content 
                            if (contentAlarm != null && contentAlarm != undefined && contentAlarm != "") {
                                content += `<td>${contentAlarm}</td>`;
                            }
                            if (item.BaseMax != null && item.BaseMax != undefined && item.BaseMax.toString().trim() != "") {
                                content += `<td>${item.BaseMax}</td>`;
                            }
                            else {
                                content += `<td> </td>`;
                            }
                            if (item.BaseMin != null && item.BaseMin != undefined && item.BaseMin.toString().trim() != "") {
                                content += `<td>${item.BaseMin}</td>`;
                            }
                            else {
                                content += `<td> </td>`;
                            }
                            content += `<tr>`;
                        }
                    }

                }
            }
            else {
                content += `<tr colspan="7">Không có dữ liệu</tr>`
            }

            if (content != null && content != undefined && content.trim() != "") {
                body.innerHTML = "";
                body.innerHTML = content;
            }
        }


        function convertDateTime(date) {
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

        function searchHandle() {
            let txtSearch = document.getElementById('txtSearch');

            filterData = data.filter((item) => item.AliasName.toLowerCase().indexOf(txtSearch.value.toLowerCase()) !== -1);

            createBody(filterData);

            isFilter = true;
        }



        function reload() {
            createBody(data);

            let txtSearch = document.getElementById('txtSearch');
            txtSearch.innerHTML = "";

            isFilter = false;
        }

        // call get data
        getData();

        setInterval(function () {
            var hostname = window.location.origin;
            if (hostname.indexOf("localhost") < 0)
                hostname = hostname + "/VivaServices/";
            else
                hostname = "http://localhost:57880";

            let url = `${hostname}/api/getvaluealarm/?uid=admin`

            axios.get(url).then((res) => {
                data = res.data;
                if (isFilter == true) {
                    let txtSearch = document.getElementById('txtSearch');

                    filterData = data.filter((item) => item.AliasName.toLowerCase().indexOf(txtSearch.value.toLowerCase()) !== -1);

                    createBody(filterData);

                }
                else {
                    createBody(data);
                }
            }).catch((err) => console.log(err))

        }, 30000);
    </script>

</asp:Content>
