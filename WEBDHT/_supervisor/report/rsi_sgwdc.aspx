<%@ Page Title="" Language="C#" MasterPageFile="~/_supervisor/master_page.master" AutoEventWireup="true" CodeFile="rsi_sgwdc.aspx.cs" Inherits="_supervisor_report_rsi_sgwdc" %>

<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="Server">
    <link href="../../css/Config.css" rel="stylesheet">
    <style>
        thead 
        {
            background: #0984e3;
            color: white;
            font-weight: 500;
        }
        .col-sm-12 
        {
            overflow: scroll;
            height: 90vh;
        }
    </style>
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="Server">
    <div id="main-content2">
        <div id="main-content-title">
            <h2 class="title">Thống kê điểm lắp đặt (DMA)</h2>
        </div>
        <div class="container-fluid m-t">
            <div class="row">
                <div class="col-sm-12">
                    <div class="m-t">
                        <div class="loading-area hide" id="loading">
                            <div class="box-loading">
                                <img src="../../2.gif" />
                            </div>
                        </div>
                        <table class="table-striped table-bordered table-hover text-center">
                            <thead id="headBody">
                                <tr>
                                    <td>STT</td>
                                    <td>Mã Point</td>
                                    <td>Hiệu</td>
                                    <td>Cỡ</td>
                                    <td>Vị Trí</td>
                                    <td>Cấp Độ</td>
                                    <td>DMA</td>
                                    <td>Tình Trạng</td>
                                    <td>Trạng Thái</td>
                                    <td>Sử Dụng Logger</td>
                                    <td>Ghi Chú</td>
                                </tr>
                            </thead>
                            <tbody id="dataTable">
                            </tbody>
                        </table>
                    </div>
                </div>
            </div>
        </div>
        <%--<div class="container-fluid m-t">
           <telerik:RadWindow ID="win" runat="server" InitialBehaviors="Maximize"
                Modal="True" VisibleStatusbar="False">
                <ContentTemplate>
                    <rsweb:ReportViewer ID="rpt" runat="server" AsyncRendering="False"
                        SizeToReportContent="True">
                        <LocalReport ReportPath="App_Data\reports\rsi_site_swdc.rdlc"
                            DisplayName="_diem_lap_dat_XNQL" />
                    </rsweb:ReportViewer>
               </ContentTemplate>
            </telerik:RadWindow>
        </div>--%>
    </div>
    <script src="https://cdn.jsdelivr.net/npm/axios/dist/axios.min.js"></script>
    <script>

        var hostname = window.location.origin;
        if (hostname.indexOf("localhost") < 0)
            hostname = hostname + "/VivaServices/";
        else
            hostname = "http://localhost:57880";

        let dataTable = document.getElementById('dataTable');
        let loadingElement = document.getElementById('loading');

        loadingElement.classList.add('show');
        loadingElement.classList.remove('hide');

        let urlGetStatisticSiteDMA = `${hostname}/api/getstatisticsitedma`;

        axios.get(urlGetStatisticSiteDMA).then((res) => {
            loadingElement.classList.add('hide');
            loadingElement.classList.remove('show');
            
            createBody(res.data);
        }).catch(err => console.log(err))


        function createBody(data) {
            let content = "";

            dataTable.innerHTML = "";

            if (checkExistData(data)) {
                for (let item of data) {
                    if (!isEmpty(item)) {
                        if (item != undefined && item != null) {
                            content += `<tr>`;
                            for (let pro in item) {
                                if (item[pro] != null && item[pro] != undefined && item[pro].toString().trim() != "") {
                                    content += `<td>${item[pro]}</td>`;
                                }
                                else {
                                    content += `<td></td>`;
                                }
                            }
                            content += `</tr>`;
                        }
                    }
                }
            }
            else {
                content = `<tr><td col-span="${11}">Không có dữ liệu</td></tr>`;
            }

            dataTable.innerHTML = content;
        }

        function isEmpty(obj) {
            for (var prop in obj) {
                if (obj.hasOwnProperty(prop))
                    return false;
            }

            return true;
        }

        function checkExistData(data) {
            if (data.length != 0)
                return true;
            return false;
        }
    </script>
</asp:Content>

