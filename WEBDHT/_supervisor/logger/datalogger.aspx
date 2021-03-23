<%@ Page Language="C#" MasterPageFile="~/_supervisor/master_page.master" AutoEventWireup="true" CodeFile="datalogger.aspx.cs" Inherits="_supervisor_logger_datalogger" %>

<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="Server">
    <link href="https://cdn.jsdelivr.net/npm/bootstrap@5.0.0-beta1/dist/css/bootstrap.min.css" rel="stylesheet" integrity="sha384-giJF6kkoqNQ00vy+HMDP7azOuL0xtbfIcaT9wjKHr8RbDVddVHyTfAAsrekwKmP1" crossorigin="anonymous">
     <link href="../../css/Config.css" rel="stylesheet">
    <style>
        .card-title {
            border: none !important;
            padding: 10px !important
        }

        .card-header, .content-card {
            display: flex;
            justify-content: space-between;
            align-items: center;
        }

        .loading, #loadMore {
            display: flex;
            justify-content: center;
            align-items: center;
            border: none !important;
            font-size: 2rem !important;
            font-weight: bold !important;
        }

        .d-flex{
            justify-content: space-between;
            align-items: center;

            margin-bottom: 10px;

            padding: 0 15px !important
        }
        .search-area 
        {
             display: flex;
            justify-content: center;
            align-items: center;
        }

        
        #loading 
        {
            width: 50px;
            height: 50px
        }

        #loadMore
        {
            padding: 10px 0
        }

        .name {
            padding: 10px
        }

        #loadMoreButton.hide
        {
            display: none
        }

        #loadMoreButton.show
        {
            display: block
        }

        #loading.hide 
        {
            display: none;
        }

        .title-data-logger {
            text-transform: uppercase;
            font-size: 2.5rem;
            padding-top: 1rem;
            text-align: center;
            font-weight: 600;
            position: relative;
            margin-bottom: 15px;
        }

        .title-data-logger::after {
            position: absolute;
            display: block;
            content: '';
            width: 100%;
            height: 2px;
            border-radius: 5px;
            bottom: -10px;
            left: 50%;
            transform: translate(-50%, -50%);
            background: #b2bec3
        }

        .card 
        {
            border-top: 3px solid #74b9ff !important
        }

        .bolder 
        {
            font-weight: 500
        }

        .bolder.value 
        {
            color: #0984e3
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
            <h2 class="title">Dữ Liệu Logger</h2>
        </div>
        <div class="container-fluid m-t">
            <div class="row">
                <div class="d-flex">
                    <div>
                        <button class="btn btn-info" onclick="reload(); return false;">Tải lại</button>
                    </div>
                    <div class="search-area">
                        <input class="form-control me-2" type="text" placeholder="Vị trí" id="txtSearch" >
                        <button class="btn btn-success" type="submit" onclick="searchHandle(); return false;">Tìm Kiếm</button>
                    </div>
                   
                </div>
            </div>
            <div class="row" id="data">
                <div class="loading">
                    <img id="loading" src="../../2.gif" />
                </div>
            </div>
            <div id="loadMore">
                <button class="btn btn-sm btn-primary" id="loadMoreButton" onclick="onLoadMoreClick(); return false;">
                    Xem Thêm
                </button>
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

        let urlGetDataComplex = `${hostname}/api/getdatacomplex`;

        let dataElement = document.getElementById('data');
        let loadMoreButton = document.getElementById('loadMoreButton');
        let loadingElement = document.getElementById('loading');

        let startPage = 0;
        let totalPage;

        // alway hide when page start load
        loadMoreButton.classList.add('hide');

        let totalData = [];

        axios.get(urlGetDataComplex).then(function (res) {
            totalData = res.data;
            totalPage = Math.ceil(res.data.length / 12);

            dataElement.insertAdjacentHTML("beforeend", createTable(totalData, startPage));

            loadingElement.classList.add('hide');

            if (totalPage > 10) {
                loadMoreButton.classList.remove('hide');
                loadMoreButton.classList.add('show');
            }
          

        }).catch(function (err) {
            console.log(err);
            alert("Không Thể Tải Danh Sách")
        })

        function createTable(data, startPage) {

            let content = "";


            for (let item of [...data.slice(startPage * 12, (startPage + 1) * 12)]) {

                content += `<div class="col-md-6 col-lg-3">
                    <div class="card text-dark bg-light mb-3">
                        <div class="card-header">
                            <span>Tên</span>
                            <span class="bolder">${item.SiteID}</span>
                        </div>
                        <div class="card-body">
                            <div class="content-card">
                                <p>Mã cũ</p>
                                <p class="bolder">${(item.OldID != null && item.OldID != undefined) ? item.OldID : ""}</p>
                            </div>
                            <div class="content-card">
                                <p>Vị Trí</p>
                                <p class="bolder">${item.Location}</p>
                            </div>
                            <div class="content-card">
                                <p>LoggerId</p>
                                <p class="bolder">${item.LoggerID}</p>
                            </div>
                            ${createListChannel(item.ListChannel)}
                        </div>
                    </div>

                </div>`;
            }

            return content;
        }

        function createTableForSearch(data) {

            let content = "";


            for (let item of data) {

                content += `<div class="col-md-6 col-lg-3">
                    <div class="card text-dark bg-light mb-3">
                        <div class="card-header">
                            <span>Tên</span>
                            <span class="bolder">${item.SiteID}</span>
                        </div>
                        <div class="card-body">
                            <div class="content-card">
                                <p>Mã cũ</p>
                                <p class="bolder">${(item.OldID != null && item.OldID != undefined) ? item.OldID : ""}</p>
                            </div>
                            <div class="content-card">
                                <p>Vị Trí</p>
                                <p class="bolder">${item.Location}</p>
                            </div>
                            <div class="content-card">
                                <p>LoggerId</p>
                                <p class="bolder">${item.LoggerID}</p>
                            </div>
                            ${createListChannel(item.ListChannel)}
                        </div>
                    </div>

                </div>`;
            }

            return content;
        }

        function createListChannel(data) {
            let content = "";

            if (data != null) {
                for (let item of data) {
                    content += ` <div class="content-card">
                                <p class="bolder">${(item.ChannelId != null && item.ChannelId != undefined) ? item.ChannelId : ""}</p>
                                <p class="bolder">${(item.TimeStamp != null && item.TimeStamp != undefined) ? convertDateTime(item.TimeStamp) : ""}</p>
                                <p class="bolder value">${(item.Value != null && item.Value != undefined) ? item.Value + `<span> ${item.Unit}</span>` : ""}</p>
                            </div>`
                }

            }

            
            return content;
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

        function onLoadMoreClick() {
            startPage += 1;

            dataElement.insertAdjacentHTML("beforeend", createTable(totalData, startPage));

            if (startPage == totalPage) {
                loadMoreButton.classList.add('hide');
                loadMoreButton.classList.remove('show');
            }
        }

        function searchHandle() {
            let txtSearch = document.getElementById('txtSearch');

            let data = totalData.filter((item) => item.Location.toLowerCase().indexOf(txtSearch.value.toLowerCase()) !== -1);

            loadMoreButton.classList.add('hide');
            loadMoreButton.classList.remove('show');

            dataElement.innerHTML = createTableForSearch(data);

        }

        function reload() {
            startPage = 0;

            dataElement.innerHTML = "";

            // hide button is first
            loadMoreButton.classList.add('hide');

            dataElement.insertAdjacentHTML("beforeend", createTable(totalData, startPage));

            // show button when load all data
            loadingElement.classList.add('hide');

            if (totalPage > 10) {
                loadMoreButton.classList.remove('hide');
                loadMoreButton.classList.add('show');
            }

        }

    </script>
</asp:Content>

