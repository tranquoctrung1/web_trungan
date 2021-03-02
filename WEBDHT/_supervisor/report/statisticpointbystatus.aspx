<%@ Page Language="C#" MasterPageFile="~/_supervisor/master_page.master" AutoEventWireup="true" CodeFile="statisticpointbystatus.aspx.cs" Inherits="_supervisor_report_statisticpointbystatus" %>

<asp:Content ID="Content1" ContentPlaceHolderID="head" Runat="Server">
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
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" Runat="Server">
    <div id="main-content2">
        <div id="main-content-title">
            <h2 class="title">Thống Kê Point Theo Tình Trạng</h2>
        </div>
         <div class="container-fluid m-t">
            <table id="example" class="display" style="width:100%">
        <thead>
            <tr>
                <th>Mã Point</th>
                <th>Mã Point Cũ</th>
                <th>Vị Trí</th>
                <th>Meter</th>
                <th>Transmitter</th>
                <th>Logger</th>
                <th>DMA vào</th>
                <th>DMA ra</th>
                <th>Quận</th>
                <th>Tình Trạng</th>
            </tr>
        </thead>
        <tbody id="body" class="text-center">
             <div class="loading">
                <img id="loading" class="hide" src="../../2.gif" />
            </div>
        </tbody>
        <tfoot  class="text-center">
            <tr>
                <th>Mã Point</th>
                <th>Mã Point Cũ</th>
                <th>Vị Trí</th>
                <th>Meter</th>
                <th>Transmitter</th>
                <th>Logger</th>
                <th>DMA vào</th>
                <th>DMA ra</th>
                <th>Quận</th>
                <th>Tình Trạng</th>
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

        function getData() {

            loadingElement.classList.add('show');
            loadingElement.classList.remove('hide');

            var hostname = window.location.origin;
            if (hostname.indexOf("localhost") < 0)
                hostname = hostname + "/VivaServices/";
            else
                hostname = "http://localhost:57880";

            let url = `${hostname}/api/getstatisticsitebystatus`;
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
                        this.api().columns([6, 7, 8, 9]).every(function () {
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

        function createBody(data) {
            let body = document.getElementById('body');

            let content = "";

            if (checkExistsData(data)) {
                for (let item of data) {
                    content += `<tr>`;
                    if (isEmpty(item) == false && item != null && item != undefined) {
                        content += `<td>${item.Id}</td>`;
                        content += `<td>${item.OldId}</td>`;
                        content += `<td>${item.Location}</td>`;
                        content += `<td>${item.Meter}</td>`;
                        content += `<td>${item.Transmitter}</td>`;
                        content += `<td>${item.Logger}</td>`;
                        content += `<td>${item.Company}</td>`;
                        content += `<td>${item.DMAOut}</td>`;
                        content += `<td>${item.District}</td>`;
                        content += `<td>${item.Status}</td>`;
                    }
                    content += `</tr>`;
                }

            }
            else {
                content = `<tr><td colspan="10">Không có dữ liệu</td</tr>`
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

