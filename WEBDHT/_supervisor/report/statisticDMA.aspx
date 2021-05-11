<%@ Page Language="C#"  MasterPageFile="~/_supervisor/master_page.master" AutoEventWireup="true" CodeFile="statisticDMA.aspx.cs" Inherits="_supervisor_report_statisticDMA" %>


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
            <h2 class="title">Thống Kê DMA</h2>
        </div>
        
        <div class="container-fluid m-t">
            <table id="example" class="display" style="width: 100%">
                <thead>
                    <tr>
                        <th>Mã DMA</th>
                        <th>Mã Nhân Viên</th>
                        <th>Tình Trạng</th>
                        <th>Quận/Huyện</th>
                        <th>Phường/Xã</th>
                        <th>Số Lượng DHTKH</th>
                        <th>Số Lượng Van</th>
                        <th>Số Lượng Bể Ký Trước</th>
                        <th>Số Lượng TCH</th>
                         <th>NRW</th>
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
                        <th>Mã DMA</th>
                        <th>Mã Nhân Viên</th>
                        <th>Tình Trạng</th>
                        <th>Quận/Huyện</th>
                        <th>Phường/Xã</th>
                        <th>Số Lượng DHTKH</th>
                        <th>Số Lượng Van</th>
                        <th>Số Lượng Bể Ký Trước</th>
                        <th>Số Lượng TCH</th>
                         <th>NRW</th>
                        <th>Ghi chú</th>
                    </tr>
                </tfoot>
            </table>
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

        function getData() {

            loadingElement.classList.add('show');
            loadingElement.classList.remove('hide');

            var hostname = window.location.origin;
            if (hostname.indexOf("localhost") < 0)
                hostname = hostname + "/VivaServices/";
            else
                hostname = "http://localhost:57880";

            let url = `${hostname}/api/getstatisticdma`;
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
                        this.api().columns([1, 2, 3, 4]).every(function () {
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
                            title: 'Thong_Ke_DMA_Theo_Tinh_Trang'
                        },
                        {
                            extend: 'csvHtml5',
                            title: 'Thong_Ke_DMA_Theo_Tinh_Trang'
                        },
                        {
                            extend: 'pdfHtml5',
                            title: 'Thong_Ke_DMA_Theo_Tinh_Trang'
                        }
                    ]
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
                        content += `<td>${item.Company}</td>`;
                        content += `<td>${item.StaffId}</td>`;
                        content += `<td>${item.Status}</td>`;
                        content += `<td>${item.Disctrict}</td>`;
                        content += `<td>${item.Ward}</td>`;
                        content += `<td>${item.AmountDHTKH == null ? "" : item.AmountDHTKH}</td>`;
                        content += `<td>${item.AmountValve == null ? "" : item.AmountValve}</td>`;
                        content += `<td>${item.AmountPool == null ? "" : item.AmountPool}</td>`;
                        content += `<td>${item.AmountTCH == null ? "" : item.AmountTCH}</td>`;
                        content += `<td>${item.NRW == null ? "" : item.NRW}</td>`;
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


        getData();

        //reload.addEventListener('click', function () {
        //    createBody(data);
        //})


    </script>
</asp:Content>


