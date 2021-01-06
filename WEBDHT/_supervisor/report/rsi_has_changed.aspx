<%@ Page Title="" Language="C#" MasterPageFile="~/_supervisor/master_page.master" AutoEventWireup="true" CodeFile="rsi_has_changed.aspx.cs" Inherits="_supervisor_report_rsi_has_changed" %>

<%--<%@ Register Assembly="Microsoft.ReportViewer.WebForms, Version=10.0.0.0, Culture=neutral, PublicKeyToken=b03f5f7f11d50a3a"
    Namespace="Microsoft.Reporting.WebForms" TagPrefix="rsweb" %>--%>
<%@ Register Assembly="Microsoft.ReportViewer.WebForms, Version=12.0.0.0, Culture=neutral, PublicKeyToken=89845dcd8080cc91" Namespace="Microsoft.Reporting.WebForms" TagPrefix="rsweb" %>
<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="Server">
    <link href="../../css/Config.css" rel="stylesheet">
    <style>
        .table-statistic-site 
        {
            height: 300px;
            overflow: scroll
        }

        .table-statistic-site table 
        {
            width: 100%
        }

        .RadForm.rfdScrollBars body::-webkit-scrollbar, .RadForm.rfdScrollBars textarea::-webkit-scrollbar, .RadForm.rfdScrollBars div::-webkit-scrollbar
        {
            height: 2px !important;
            width: 2px !important
        }
    </style>
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="Server">
    <div id="main-content2">
        <div id="main-content-title">
            <h2 class="title">Hoạt động phát sinh trong kỳ</h2>
        </div>
        <div class="container-fluid m-t">
            <div class="row">
                <div class="col-sm-6">
                    <div class="group-text change-size">
                        <div class="row ">
                            <span>Loại</span>
                        </div>
                        <div class="row m-b out">
                            <telerik:RadComboBox ID="cboTypes" runat="server" AllowCustomText="True"
                                DataSourceID="TypesDataSource" EnableLoadOnDemand="True" Filter="StartsWith"
                                HighlightTemplatedItems="True">
                            </telerik:RadComboBox>
                            <asp:ObjectDataSource ID="TypesDataSource" runat="server"
                                OldValuesParameterFormatString="original_{0}"
                                SelectMethod="ListAccreditationTypes" TypeName="DataObject"></asp:ObjectDataSource>
                        </div>
                    </div>
                </div>
                <div class="col-sm-6">
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
                    OnClientClick="return btnView_Click()" CssClass="btn btn-primary">
                </asp:Button>
            </div>
        </div>
        <%--<telerik:RadNotification ID="ntf" runat="server" Title="Message">
        </telerik:RadNotification>--%>
         <div class="container-fluid m-t">
             <div class="row">
                 <div class="col-sm-12 table-statistic-site">
                     <div class="loading-area hide" id="loading">
                            <div class="box-loading">
                                <img src="../../2.gif" />
                            </div>
                        </div>
                    <table class="table-striped table-bordered table-hover text-center">
                            <thead id="headBody">
                                
                            </thead>
                            <tbody id="dataTable">
                            </tbody>
                        </table>
                </div>
             </div>
             <%-- <rsweb:ReportViewer ID="rpt" runat="server" AsyncRendering="False"
                    SizeToReportContent="True">
                </rsweb:ReportViewer>--%>
             </div>
    </div>

     <script src="https://cdn.jsdelivr.net/npm/axios/dist/axios.min.js"></script>
    <script>

        function btnView_Click() {
            let loadingElement = document.getElementById('loading');

            // show loading area 
            if (!loadingElement.classList.contains('show')) {
                loadingElement.classList.add('show');
            }
            loadingElement.classList.remove('hide');

            let cboTypes = $find('<%=cboTypes.ClientID %>');
            let start = $find('<%=dtmStart.ClientID %>');
            if (cboTypes == null || cboTypes == undefined || cboTypes.get_selectedItem() == null || cboTypes.get_selectedItem() == undefined) {
                alert("Chưa chọn loại")
                return false;
            }
            else if (start == null || start == undefined || start.get_selectedDate() == null || start.get_selectedDate() == undefined) {
                alert("Chưa chọn mốc thời gian")
                return false;
            }
            else {
                let type = cboTypes.get_selectedIndex();
                let timeStart = start.get_selectedDate();

                let totalSecondStart = timeStart.getTime() / 1000;

                var hostname = window.location.origin;
                if (hostname.indexOf("localhost") < 0)
                    hostname = hostname + "/VivaServices/";
                else
                    hostname = "http://localhost:57880";

                let urlGetDataHasChanged = `${hostname}/api/getdatahaschanged/?eventToCreate=${type}&start=${totalSecondStart}`;

                axios.get(urlGetDataHasChanged).then((res) => {
                    loadingElement.classList.add('hide');
                    loadingElement.classList.remove('show');

                    if (type == 0) {
                        createBodyForAccredited(res.data);
                    }
                    else if (type == 1) {
                        createBodyForMeterChanged(res.data);
                    }
                    else if (type == 2) {
                        createBodyForTransmitterChanged(res.data);
                    }
                    else if (type == 3) {
                        createBodyForLoggerChanged(res.data);
                    }
                    else if (type == 4) {
                        createBodyForBatteryChanged(res.data);
                    }
                    else if (type == 5) {
                        createBodyForBatteryChanged(res.data);
                    }
                    else if (type == 6) {
                        createBodyForBatteryChanged(res.data);
                    }
                    console.log(res.data)

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

        function createBodyForAccredited(data) {
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
                            if (item.ExpiryDate != null && item.ExpiryDate != undefined && item.ExpiryDate.toString().trim() != "") {
                                content += `<td>${convertDate(item.ExpiryDate)}</td>`;
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
                content = `<tr><td colspan="9">Không có dữ liệu</td></tr>`;
            }

            createHeadForAccredited(data);

            body.innerHTML = content;
        }

        function createHeadForAccredited(data) {
            let head = document.getElementById('headBody');
            let content = "";

            head.innerHTML = "";
            if (checkExistsData(data)) {
                content += `<thead>
                            <tr>
                                <th>STT</th>
                                <th>Mã Point</th>
                                <th>Vị Trí</th>
                                <th>Hiệu</th>
                                <th>Cỡ</th>
                                <th>Ngày Kiểm Định</th>
                                <th>Ngày Hết Hạn</th>
                                <th>Giấy Kiểm Định</th>
                                <th>Ghi Chú</th>
                            </tr>
                            </thead>`
            }
            head.innerHTML = content;
        }

        function createBodyForMeterChanged(data) {
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
                            if (item.OldMeter != null && item.OldMeter != undefined && item.OldMeter.toString().trim() != "") {
                                content += `<td>${item.OldMeter}</td>`;
                            }
                            else {
                                content += `<td></td>`;
                            }
                            content += `<td></td>`;
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

            createHeadForMeterChanged(data);

            body.innerHTML = content;
        }

        function createHeadForMeterChanged(data) {
            let head = document.getElementById('headBody');
            let content = "";

            head.innerHTML = "";
            if (checkExistsData(data)) {
                content += `<thead>
                            <tr>
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
                            </tr>
                            </thead>`
            }
            head.innerHTML = content;
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

            body.innerHTML = content;
        }

        function createHeadForTransmitterChanged(data) {
            let head = document.getElementById('headBody');
            let content = "";

            head.innerHTML = "";
            if (checkExistsData(data)) {
                content += `<thead>
                            <tr>
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
                            </tr>
                            </thead>`
            }
            head.innerHTML = content;
        }

        function createBodyForLoggerChanged(data) {
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
                            content += `<td></td>`;
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

            createHeadForLoggerChanged(data);

            body.innerHTML = content;
        }

        function createHeadForLoggerChanged(data) {
            let head = document.getElementById('headBody');
            let content = "";

            head.innerHTML = "";
            if (checkExistsData(data)) {
                content += `<thead>
                            <tr>
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
                            </tr>
                            </thead>`
            }
            head.innerHTML = content;
        }

        function createBodyForBatteryChanged(data) {
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
                            content += `<td></td>`;
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

            createHeadForBatteryChanged(data);

            body.innerHTML = content;
        }

        function createHeadForBatteryChanged(data) {
            let head = document.getElementById('headBody');
            let content = "";

            head.innerHTML = "";
            if (checkExistsData(data)) {
                content += `<thead>
                            <tr>
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
                            </tr>
                            </thead>`
            }
            head.innerHTML = content;
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

