<%@ Page Language="C#"  MasterPageFile="~/_supervisor/master_page.master" AutoEventWireup="true" CodeFile="statisticTransmitterChanged.aspx.cs" Inherits="_supervisor_report_statisticTransmitterChanged" %>


<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="Server">
    <link href="../../css/Config.css" rel="stylesheet">
    <link rel="stylesheet" type="text/css" href="https://cdn.datatables.net/1.10.23/css/jquery.dataTables.css">
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
    </style>
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="Server">
    <div id="main-content2">
        <div id="main-content-title">
            <h2 class="title">Thống Kê Thay Bộ Hiển Thị</h2>
        </div>
        <div class="container-fluid m-t">
            <div class="row">
                <div class="col-sm-12">
                    <div class="group-text change-size">
                        <div class="row ">
                            <span>Mốc thời gian</span>
                        </div>
                        <div class="row m-b out">
                            <telerik:RadDatePicker ID="dtmStart" runat="server">
                            </telerik:RadDatePicker>
                        </div>
                    </div>
                </div>
            </div>
            <div class="text-center col-sm-12 m-t m-b no-padding" style="clear: both;">
                <asp:Button ID="btnView" runat="server" Text="Xem"
                    OnClientClick="return btnView_Click()" CssClass="btn btn-primary"></asp:Button>
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
                    <div id="tablePlaceHolder"></div>
                </div>
            </div>
        </div>
    </div>

    <script src="https://cdn.jsdelivr.net/npm/axios/dist/axios.min.js"></script>
    <script src="https://cdn.datatables.net/1.10.23/js/jquery.dataTables.js"></script>
     <script src="https://cdn.datatables.net/buttons/1.7.0/js/dataTables.buttons.min.js"></script>
    <script src="https://cdnjs.cloudflare.com/ajax/libs/jszip/3.1.3/jszip.min.js"></script>
    <script src="https://cdnjs.cloudflare.com/ajax/libs/pdfmake/0.1.53/pdfmake.min.js"></script>
    <script src="https://cdnjs.cloudflare.com/ajax/libs/pdfmake/0.1.53/vfs_fonts.js"></script>
    <script src="https://cdn.datatables.net/buttons/1.7.0/js/buttons.html5.min.js"></script>
    <script src="https://cdn.datatables.net/buttons/1.7.0/js/buttons.print.min.js"></script>
    <script>
        function btnView_Click() {
            let loadingElement = document.getElementById('loading');

            // show loading area 
            if (!loadingElement.classList.contains('show')) {
                loadingElement.classList.add('show');
            }
            loadingElement.classList.remove('hide');

            let start = $find('<%=dtmStart.ClientID %>');
            if (start == null || start == undefined || start.get_selectedDate() == null || start.get_selectedDate() == undefined) {
                alert("Chưa chọn mốc thời gian")
                return false;
            }
            else {
                let timeStart = start.get_selectedDate();

                let totalSecondStart = timeStart.getTime() / 1000;

                var hostname = window.location.origin;
                if (hostname.indexOf("localhost") < 0)
                    hostname = hostname + "/VivaServices/";
                else
                    hostname = "http://localhost:57880";

                let urlGetDataHasChanged = `${hostname}/api/getdatahaschanged/?eventToCreate=${2}&start=${totalSecondStart}`;

                axios.get(urlGetDataHasChanged).then((res) => {
                    loadingElement.classList.add('hide');
                    loadingElement.classList.remove('show');

                    createTablePlaceHolder();

                    createBodyForTransmitterChanged(res.data);

                }).catch(err => console.log(err))

            }
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

        function createBodyForTransmitterChanged(data) {
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
                            content += `<td></td>`;
                            if (item.OldTran != null && item.OldTran != undefined && item.OldTran.toString().trim() != "") {
                                content += `<td>${item.OldTran}</td>`;
                            }
                            else {
                                content += `<td></td>`;
                            }

                            content += `<td></td>`;
                            if (item.Meter != null && item.Meter != undefined && item.Meter.toString().trim() != "") {
                                content += `<td>${item.Meter}</td>`;
                            }
                            else {
                                content += `<td></td>`;
                            }
                            content += `<td></td>`;
                            if (item.Transmitter != null && item.Transmitter != undefined && item.Transmitter.toString().trim() != "") {
                                content += `<td>${item.Transmitter}</td>`;
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
                            if (item.DateOfChange != null && item.DateOfChange != undefined && item.DateOfChange.toString().trim() != "") {
                                content += `<td>${convertDate(item.DateOfChange)}</td>`;
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
                            if (item.ExpiryDate != null && item.ExpiryDate != undefined && item.ExpiryDate.toString().trim() != "") {
                                content += `<td>${convertDate(item.ExpiryDate)}</td>`;
                            }
                            else {
                                content += `<td></td>`;
                            }
                            if (item.DescriptionOfChange != null && item.DescriptionOfChange != undefined && item.DescriptionOfChange.toString().trim() != "") {
                                content += `<td>${item.DescriptionOfChange}</td>`;
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

            createHeadForTransmitterChanged(data);
            createFooterForTransmitterChanged(data);

            body.innerHTML = content;

            $('#example').DataTable({
                initComplete: function () {
                    this.api().columns([1, 2, 3, 4, 5, 6, 7, 8, 9, 10, 11, 12, 13]).every(function () {
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
                },
                dom: 'Bfrtip',
                buttons: [
                    {
                        extend: 'excelHtml5',
                        title: 'Thong_Ke_Thay_Bo_Hien_Thi'
                    },
                    {
                        extend: 'csvHtml5',
                        title: 'Thong_Ke_Thay_Bo_Hien_Thi'
                    },
                    {
                        extend: 'pdfHtml5',
                        title: 'Thong_Ke_Thay_Bo_Hien_Thi'
                    }
                ]
            });

        }

        function createHeadForTransmitterChanged(data) {
            let head = document.getElementById('headBody');
            let content = "";

            head.innerHTML = "";
            if (checkExistsData(data)) {
                content += `<tr>
                                <th>STT</th>
                                <th>Mã Point</th>
                                <th>Vị Trí</th>
                                <th>Đồng Hồ Cũ</th>
                                <th>Bổ Hiển Thị Cũ</th>
                                <th>Mã ĐH</th>
                                <th>Đồng Hồ</th>
                                <th>Mã BHT</th>
                                <th>Bổ Hiển Thị</th>
                                <th>Hiệu</th>
                                <th>Cỡ</th>
                                <th>Ngày Thay</th>
                                <th>Giấy Kiểm Định</th>
                                <th>Ngày Hết Hạn KĐ</th>
                                <th>Ghi Chú</th>
                            </tr>`
            }
            head.innerHTML = content;
        }

        function createFooterForTransmitterChanged(data) {
            let footer = document.getElementById('footer');
            let content = "";

            footer.innerHTML = "";
            if (checkExistsData(data)) {
                content += `  <tr>
                                <th>STT</th>
                                <th>Mã Point</th>
                                <th>Vị Trí</th>
                                <th>Đồng Hồ Cũ</th>
                                <th>Bổ Hiển Thị Cũ</th>
                                <th>Mã ĐH</th>
                                <th>Đồng Hồ</th>
                                <th>Mã BHT</th>
                                <th>Bổ Hiển Thị</th>
                                <th>Hiệu</th>
                                <th>Cỡ</th>
                                <th>Ngày Thay</th>
                                <th>Giấy Kiểm Định</th>
                                <th>Ngày Hết Hạn KĐ</th>
                                <th>Ghi Chú</th>
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
    </script>
</asp:Content>
