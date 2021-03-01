<%@ Page Language="C#" MasterPageFile="~/_supervisor/master_page.master" AutoEventWireup="true" CodeFile="statisticDateExpireLogger.aspx.cs" Inherits="_supervisor_report_statisticDateExpireLogger" %>

<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="Server">
    <link href="../../css/Config.css" rel="stylesheet">
    <link rel="stylesheet" type="text/css" href="https://cdn.datatables.net/1.10.23/css/jquery.dataTables.css">
    <style>
        #loading {
            width: 50px;
            height: 50px
        }

            #loading.hide {
                display: none;
            }

            #loading.show {
                display: inline
            }
    </style>

</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="Server">
    <div id="main-content2">
        <div id="main-content-title">
            <h2 class="title">Thống Kê Logger Theo Tình Trạng</h2>
        </div>
        <div class="container-fluid m-t">
            <div class="m-b col-sm-5 ">
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
            <div class="m-b col-sm-5 ">
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
             <div class="m-b col-sm-2 ">
                 <button class="btn btn-info" onclick="view(); return false">Xem</button>
             </div>
        </div>
        <div class="container-fluid m-t">
            <table id="example" class="display" style="width: 100%">
                <thead>
                    <tr>
                        <th>Serial</th>
                        <th>nhà Cung Cấp</th>
                        <th>Nhãn</th>
                        <th>Hiệu</th>
                        <th>Tình Trạng</th>
                        <th>Ngày Kiểm Định</th>
                        <th>Ngày Lắp Pin</th>
                        <th>Tuổi Thọ Pin</th>
                         <th>Quận</th>
                        <th>DMA</th>
                        <th>Ghi chú</th>
                    </tr>
                </thead>
                <tbody id="body" class="text-center">
                    <div class="loading">
                        <img id="loading" class="hide" src="../../2.gif" />
                    </div>
                </tbody>
                <tfoot class="text-center">
                    <tr>
                        <th>Serial</th>
                        <th>nhà Cung Cấp</th>
                        <th>Nhãn</th>
                        <th>Hiệu</th>
                        <th>Tình Trạng</th>
                        <th>Ngày Kiểm Định</th>
                        <th>Ngày Lắp Pin</th>
                        <th>Tuổi Thọ Pin</th>
                         <th>Quận</th>
                        <th>DMA</th>
                        <th>Ghi chú</th>
                    </tr>
                </tfoot>
            </table>
        </div>

    </div>
    <script src="https://cdn.jsdelivr.net/npm/axios/dist/axios.min.js"></script>
    <script src="https://cdn.datatables.net/1.10.23/js/jquery.dataTables.js"></script>
    <script>

        let loadingElement = document.getElementById('loading');
        //let reload = document.getElementById('reload');
        let table;

        let data = [];

        function checkExistsData(data) {
            if (data.length > 0)
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

        function getData(start, end) {

            loadingElement.classList.add('show');
            loadingElement.classList.remove('hide');

            var hostname = window.location.origin;
            if (hostname.indexOf("localhost") < 0)
                hostname = hostname + "/VivaServices/";
            else
                hostname = "http://localhost:57880";

            let url = `${hostname}/api/getstatisticdateexpirebatterylogger?start=${start}&end=${end}`;
            console.log(url)

            axios.get(url).then((res) => {

                data = res.data;

                loadingElement.classList.add('hide');
                createBody(res.data);

                //table = $('#example').DataTable({
                //    "pagingType": "full_numbers"
                //});

                talbe = $('#example').DataTable({
                    initComplete: function () {
                        this.api().columns([3, 4, 8, 9]).every(function () {
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

            }).catch(err => console.log(err))

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

        function createBody(data) {
            let body = document.getElementById('body');

            let content = "";

            if (checkExistsData(data)) {
                for (let item of data) {
                    content += `<tr>`;
                    if (isEmpty(item) == false && item != null && item != undefined) {
                        content += `<td>${item.Serial}</td>`;
                        content += `<td>${item.Provider}</td>`;
                        content += `<td>${item.Marks}</td>`;
                        content += `<td>${item.Model}</td>`;
                        content += `<td>${item.Status}</td>`;
                        content += `<td>${convertDateTime(item.DateAccreditation)}</td>`;
                        content += `<td>${convertDateTime(item.DateInstallBattery) }</td>`;
                        content += `<td>${item.YearBattery == null ? "" : item.YearBattery}</td>`;
                        content += `<td>${item.District}</td>`;
                        content += `<td>${item.Company}</td>`;
                        content += `<td>${item.Description}</td>`;
                    }
                    content += `</tr>`;
                }

            }
            else {
                content = `<tr><td colspan="11">Không có dữ liệu</td</tr>`
            }

            body.innerHTML = content;
        }

        //function OnClientSelectedIndexChanged(sender, eventArgs) {
        //    var newItem = eventArgs.get_item();

        //    table.search(newItem.get_text()).draw();
        //}


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
                let timeStart = start.get_selectedDate();
                let timeEnd = end.get_selectedDate();

                let totalSecondStart = timeStart.getTime() / 1000;
                let totalSecondEnd = timeEnd.getTime() / 1000;

                getData(totalSecondStart, totalSecondEnd);
            }

        }


        //reload.addEventListener('click', function () {
        //    createBody(data);
        //})


    </script>
</asp:Content>



