<%@ Page Language="C#" MasterPageFile="~/_customer/master_page.master" AutoEventWireup="true" CodeFile="MonthlyLogger.aspx.cs" Inherits="_customer_logger_MonthlyLogger" %>
<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="Server">
    <link href="../../css/Config.css" rel="stylesheet">
    <style>
        #dataTable
        {
            width: 100%;
            text-align: center;

            font-weight: 500;
            font-size: 1.4rem
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
            <h2 class="title">Sản Lượng Tháng Theo Point</h2>
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
                                AutoPostBack="false">
                                <HeaderTemplate>

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
                                OldValuesParameterFormatString="original_{0}" SelectMethod="GetAllByUserName"
                                TypeName="SitesBLL"></asp:ObjectDataSource>
                        </div>
                    </div>

                </div>
                <div class="col-sm-4">
                    <div class="group-text">
                        <div class="row">
                            <span>Từ tháng</span>
                        </div>
                        <div class="row m-b">
                            <telerik:RadMonthYearPicker ID="dtmStart" runat="server" Culture="en-GB" CssClass="custom-picker full-width h-33">
                                <DateInput DisplayDateFormat="MM/yyyy" DateFormat="MM/yyyy" LabelWidth="40%"></DateInput>

                                <DatePopupButton ImageUrl="" HoverImageUrl="" BackColor="White"></DatePopupButton>
                            </telerik:RadMonthYearPicker>
                        </div>
                    </div>
                </div>
                <div class="col-sm-4">
                    <div class="group-text">
                        <div class="row">
                            <span>Đến tháng</span>
                        </div>
                        <div class="row m-b">
                           <telerik:RadMonthYearPicker ID="dtmEnd" runat="server" Culture="en-GB" CssClass="custom-picker full-width h-33">
                                <DateInput DisplayDateFormat="MM/yyyy" DateFormat="MM/yyyy" LabelWidth="40%"></DateInput>

                                <DatePopupButton ImageUrl="" HoverImageUrl="" BackColor="White"></DatePopupButton>
                            </telerik:RadMonthYearPicker>
                           
                        </div>
                    </div>

                </div>
            </div>
            <div class="row">
                <div class="text-center col-sm-12 m-t m-b no-padding" style="clear: both;">
                    <button class="btn btn-primary" id="btnView" onclick="btnViewOnClick(); return false;">Xem</button>
                    <button class="btn btn-success" id="btnExport" onclick="btnExportOnClick(); return false;">Xuất Excel</button>
                </div>
            </div>
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
                        <table id="dataTable" class="table-striped table-bordered table-hover">
                           
                        </table>
                    </div>
                </div>
            </div>
        </div>
    </div>

    <script src="https://cdn.jsdelivr.net/npm/axios/dist/axios.min.js"></script>
    <script>
        
        let dataTable = document.getElementById('dataTable');
        let loadingElement = document.getElementById('loading');

        function btnViewOnClick() {

            // show loading area 
            if (!loadingElement.classList.contains('show')) {
                loadingElement.classList.add('show');
            }
            loadingElement.classList.remove('hide');


            let siteIDCbo = $find('<%=cboSiteIds.ClientID %>');
            let start = $find('<%=dtmStart.ClientID %>');
            let end = $find('<%=dtmEnd.ClientID %>');
            if (siteIDCbo == null || siteIDCbo == undefined || siteIDCbo.get_selectedItem() == null || siteIDCbo.get_selectedItem() == undefined) {
                alert("Chưa chọn mã point")
                return false;
            }
            else if (start == null || start == undefined || start.get_selectedDate() == null || start.get_selectedDate() == undefined) {
                alert("Chưa chọn tháng bắt đầu")
                return false;
            }
            else if (end == null || end == undefined || end.get_selectedDate() == null || end.get_selectedDate() == undefined) {
                alert("Chưa chọn tháng kết thúc")
                return false;
            }
            else {
                let siteID = siteIDCbo.get_selectedItem().get_value();

                getData(siteID, start, end)
            }
        }

        function getData(siteid, start, end) {
            var hostname = window.location.origin;
            if (hostname.indexOf("localhost") < 0)
                hostname = hostname + "/VivaServices/";
            else
                hostname = "http://localhost:57880";

            dataTable.innerHTML = "";


            let timeStart = start.get_selectedDate();
            let timeEnd = end.get_selectedDate();

            let totalSecondStart = timeStart.getTime() / 1000;
            let totalSecondEnd = timeEnd.getTime() / 1000;

            let urlGetDataDailySite = `${hostname}/api/getdatareportmonthlysite/${siteid}/${totalSecondStart}/${totalSecondEnd}`;


            axios.get(urlGetDataDailySite).then((res) => {
                createTable(res.data);
            }).catch(err => console.log(err))

        }

        function createTable(data) {
            loadingElement.classList.add('hide');
            loadingElement.classList.remove('show');
            let content = "";

            content += createHeader(data);
            content += createBody(data);
            content += createFooter(data);
            dataTable.innerHTML = content;
        }

        function createHeader(data) {
            let contentHeader = "";

            if (checkExistData(data)) {
                let index = firstElementHasData(data);
                if (index != -1) {
                    contentHeader += `<thead><tr>`;

                    for (let pro in data[index]) {
                        if (pro == "TimeStamp") {
                            contentHeader += `<th>Thời Gian</th>`;
                        }
                        else if (pro == "Value") {
                            contentHeader += `<th>Giá Trị</th>`;
                        }
                        else {
                            contentHeader += `<th>${pro}</th>`;
                        }
                    }

                    contentHeader += `</tr></thead>`

                }
            }
            return contentHeader;
        }

        function createBody(data) {
            let contentBody = "";
            let count = 0;

            if (checkExistData(data)) {

                contentBody += `<tbody>`;

                for (let item of data) {
                    if (count < data.length - 1) {
                        contentBody += `<tr>`
                        for (let pro in item) {
                            if (item[pro].toString().trim() != "" && item[pro] != null && item[pro] != undefined) {
                                if (pro == "TimeStamp") {
                                    contentBody += `<td>${convertDate(item[pro])}</td>`;
                                }
                                else {
                                    contentBody += `<td>${item[pro].toString()}</td>`;
                                }
                            }
                            else {
                                contentBody += `<td> </td>`
                            }
                        }
                        contentBody += `</tr>`;
                        count++;
                    }
                }

                contentBody += `</tbody>`
            }

            return contentBody;
        }

        function createFooter(data) {
            let contentFooter = "";

            if (checkExistData(data)) {
                contentFooter += `<tfoot style="color: white"><tr><td>Tổng Cộng</td><td>${data[data.length - 1].Value.toString()}</td></tr></tfoot>`;
            }

            return contentFooter;
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

        function firstElementHasData(data) {
            let count = 0;
            for (let item of data) {
                if (!isEmpty(item)) {
                    return count;
                }
                else {
                    count++;
                }
            }

            return -1;
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

        function convertDate2(date) {
            return `${date.getFullYear()}_${date.getMonth() + 1}_${date.getDate()}_${date.getHours()}_${date.getMinutes()}_${date.getSeconds()}`;
        }

        function btnExportOnClick(e) {
            let siteIDCbo = $find('<%=cboSiteIds.ClientID %>');
            let start = $find('<%=dtmStart.ClientID %>');
            let end = $find('<%=dtmEnd.ClientID %>');

            var tableToExcel = (function () {
                var uri = 'data:application/vnd.ms-excel;base64,',
                    template = '<html xmlns:o="urn:schemas-microsoft-com:office:office" xmlns:x="urn:schemas-microsoft-com:office:excel" xmlns="http://www.w3.org/TR/REC-html40"><head><!--[if gte mso 9]><xml><x:ExcelWorkbook><x:ExcelWorksheets><x:ExcelWorksheet><x:Name>{worksheet}</x:Name><x:WorksheetOptions><x:DisplayGridlines/></x:WorksheetOptions></x:ExcelWorksheet></x:ExcelWorksheets></x:ExcelWorkbook></xml><![endif]--><meta http-equiv="content-type" content="text/plain; charset=UTF-8"/></head><body><table>{table}</table></body></html>',
                    base64 = function (s) {
                        return window.btoa(unescape(encodeURIComponent(s)))
                    },
                    format = function (s, c) {
                        return s.replace(/{(\w+)}/g, function (m, p) {
                            return c[p];
                        })
                    }
                return function (table, name) {
                    if (!table.nodeType) table = document.getElementById(table)
                    var ctx = {
                        worksheet: name || 'Worksheet',
                        table: table.innerHTML
                    }
                    //window.location.href = uri + base64(format(template, ctx))
                    var blob = new Blob([format(template, ctx)]);
                    var blobURL = window.URL.createObjectURL(blob);
                    return blobURL;
                }
            })()

            let url = tableToExcel('dataTable', `SL`);
            let a = $("<a />", {
                href: url,
                download: `San_Luong_Thang_${siteIDCbo.get_text()}_Tu_${convertDate2(start.get_selectedDate())}_Den_${convertDate2(end.get_selectedDate())}.xls`
            }).appendTo("body").get(0).click();

        }

    </script>
</asp:Content>
