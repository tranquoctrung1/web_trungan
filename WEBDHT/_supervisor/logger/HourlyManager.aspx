<%@ Page Language="C#" MasterPageFile="~/_supervisor/master_page.master" AutoEventWireup="true" CodeFile="HourlyManager.aspx.cs" Inherits="_supervisor_logger_HourlyManager" %>

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
            <h2 class="title">Sản Lượng Giờ Theo DMA</h2>
        </div>
        <div class="container-fluid m-t">
            <div class="row">
                <div class="col-sm-4">
                    <div class="group-text">
                        <div class="row">
                            <span>Mã DMA</span>
                        </div>
                        <div class="row m-b">
                             <telerik:RadComboBox ID="cboCompanies" Runat="server" AllowCustomText="True" 
                                EnableLoadOnDemand="True" Filter="StartsWith" 
                                HighlightTemplatedItems="True" DataSourceID="SiteCompaniesDataSource" 
                                DataTextField="Company" DataValueField="Company" DropDownWidth="275px" 
                                TabIndex="1">
                                <HeaderTemplate>
                                    <table cellpadding="0" cellspacing="0">
                                        <tr>
                                            <td style="width:70px">DMA</td>
                                            <td style="width:200px">Mô tả</td>
                                        </tr>
                                    </table>
                                </HeaderTemplate>
                                <ItemTemplate>
                                    <table cellpadding="0" cellspacing="0">
                                        <tr>
                                            <td style="width:70px"><%#DataBinder.Eval(Container.DataItem,"Company") %></td>
                                            <td style="width:200px"><%#DataBinder.Eval(Container.DataItem,"Description") %></td>
                                        </tr>
                                    </table>
                                </ItemTemplate>
                            </telerik:RadComboBox>
                            <asp:ObjectDataSource ID="SiteCompaniesDataSource" runat="server" 
                                OldValuesParameterFormatString="original_{0}" SelectMethod="GetAll" 
                                TypeName="SiteCompaniesBLL"></asp:ObjectDataSource>
                        </div>
                    </div>

                </div>
                <div class="col-sm-4">
                    <div class="group-text">
                        <div class="row">
                            <span>Giờ Bắt Đầu</span>
                        </div>
                        <div class="row m-b">
                            <telerik:RadDateTimePicker ID="dtmStart" runat="server" Culture="en-GB"
                                TabIndex="2">
                                <Calendar UseColumnHeadersAsSelectors="False" UseRowHeadersAsSelectors="False"
                                    ViewSelectorText="x">
                                </Calendar>
                                <DateInput DateFormat="dd/MM/yyyy" DisplayDateFormat="dd/MM/yyyy"
                                    EnableSingleInputRendering="True" LabelWidth="64px" TabIndex="2">
                                </DateInput>
                                <DatePopupButton HoverImageUrl="" ImageUrl="" TabIndex="-1" />
                            </telerik:RadDateTimePicker>
                        </div>
                    </div>
                </div>
                <div class="col-sm-4">
                    <div class="group-text">
                        <div class="row">
                            <span>Giờ Kết Thúc</span>
                        </div>
                        <div class="row m-b">
                            <telerik:RadDateTimePicker ID="dtmEnd" runat="server" Culture="en-GB" TabIndex="3">
                                <Calendar UseColumnHeadersAsSelectors="False" UseRowHeadersAsSelectors="False"
                                    ViewSelectorText="x">
                                </Calendar>
                                <DateInput DateFormat="dd/MM/yyyy" DisplayDateFormat="dd/MM/yyyy"
                                    EnableSingleInputRendering="True" LabelWidth="64px" TabIndex="3">
                                </DateInput>
                                <DatePopupButton HoverImageUrl="" ImageUrl="" TabIndex="-1" />
                            </telerik:RadDateTimePicker>
                        </div>
                    </div>

                </div>
            </div>
            <div class="row">
                <div class="text-center col-sm-12 m-t m-b no-padding" style="clear: both;">
                    <button class="btn btn-primary" id="btnView" onclick="btnViewOnClick(); return false;">Xem</button>
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


            let siteIDCbo = $find('<%=cboCompanies.ClientID %>');
            let start = $find('<%=dtmStart.ClientID %>');
            let end = $find('<%=dtmEnd.ClientID %>');
            if (siteIDCbo == null || siteIDCbo == undefined || siteIDCbo.get_selectedItem() == null || siteIDCbo.get_selectedItem() == undefined) {
                alert("Chưa chọn mã DMA")
                return false;
            }
            else if (start == null || start == undefined || start.get_selectedDate() == null || start.get_selectedDate() == undefined) {
                alert("Chưa chọn giờ bắt đầu")
                return false;
            }
            else if (end == null || end == undefined || end.get_selectedDate() == null || end.get_selectedDate() == undefined) {
                alert("Chưa chọn giờ kết thúc")
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

            let urlGetDataDailySite = `${hostname}/api/getdatareporthourlycompany/?company=${siteid}&start=${totalSecondStart}&end=${totalSecondEnd}`;


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
    </script>
</asp:Content>

