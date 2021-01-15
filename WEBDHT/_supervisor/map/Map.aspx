<%@ Page Language="C#" MasterPageFile="~/Empty.master" AutoEventWireup="true" CodeFile="Map.aspx.cs" Inherits="_supervisor_map_Map" %>

<asp:Content ID="Content1" ContentPlaceHolderID="ContentPlaceHolder1" runat="Server">

    <head>
        <title></title>
        <script type="text/javascript" src="https://www.google.com/jsapi"></script>
        <script type="text/javascript" src="https://maps.googleapis.com/maps/api/js?key=AIzaSyAXcBIH-8x-fgsegv6OedGZmh7g0JZyGr0"></script>


        <script src="../../js/markerwithlabel.js"></script>
        <script src="../../js/ContextMenu.js"></script>
        <script src="../../js/jquery-1.7.2.min.js"></script>
        <script src="../../js/amcharts/amcharts.js"></script>
        <script src="../../js/amcharts/serial.js"></script>
        <script src="../../js/amcharts/exporting/amexport.js"></script>
        <script src="../../js/amcharts/exporting/canvg.js"></script>
        <script src="../../js/amcharts/exporting/filesaver.js"></script>
        <script src="../../js/amcharts/exporting/jspdf.js"></script>
        <script src="../../js/amcharts/exporting/jspdf.plugin.addimage.js"></script>
        <script src="../../js/amcharts/exporting/rgbcolor.js"></script>
        <script src="../../js/randomColor.js"></script>
        <script src="../../js/arcgislink.js"></script>
        <script src="../../js/markerclusterer.js"></script>
        <link href="../../App_Themes/common.css" rel="stylesheet" />
        <link href="../../css/CssMap.css" rel="stylesheet" />

        <script src="https://www.amcharts.com/lib/4/core.js"></script>
        <script src="https://www.amcharts.com/lib/4/charts.js"></script>
        <script src="https://www.amcharts.com/lib/4/themes/animated.js"></script>

        <style type="text/css">
            #map_canvas {
                padding: 0;
                margin: 0;
                height: 100%;
            }

            .auto-style1 {
                width: 50%;
            }

            .auto-style2 {
                width: 18px;
            }

            .tCenter {
                text-align: center
            }

            .tBold {
                font-weight: bold
            }


            #chart_table_MinMax table {
                width: 96%;
                padding-left: 15px;
            }

                #chart_table_MinMax table th, #chart_table_MinMax table td {
                    text-align: center;
                    padding: 5px 7px;
                }

                #chart_table_MinMax table th {
                    background: #25a0da;
                    color: #fff;
                    position: sticky;
                    top: 0px;
                    white-space: nowrap;
                }

                #chart_table_MinMax table td {
                    border-bottom: 1px solid #eee;
                }

                    #chart_table_MinMax table td.row-title {
                        font-weight: bold;
                    }

            .gm-style-iw-d {
                overflow: hidden !important;
            }

            .main-wrapper2 {
                width: 100%;
                height: 100%;
                overflow-y: auto;
                overflow-x: hidden;
            }


            #MapJSItem ul {
                padding-left: 20px
            }

            #MapJSItem span {
                color: white;
            }

            .RadSplitter_Metro {
                width: 100% !important;
            }

            #RAD_SPLITTER_PANE_CONTENT_ctl00_ContentPlaceHolder1_RadPane2 {
                width: 100% !important;
                overflow: unset !important;
            }

            .content-wrapper .content {
                min-height: 100% !important;
                height: 100% !important;
                width: 100% !important;
            }

            .content-wrapper {
                min-height: unset !important;
                overflow: hidden !important;
                margin-left: 42px !important;
            }
        </style>


    </head>
    <%--   <body class="hold-transition skin-blue sidebar-mini">--%>
    <body>
        <form id="form1">
            <!-- Modal -->
            <div class="modal fade" id="myModal" role="dialog">
                <div class="modal-dialog modal-sm">
                    <div class="modal-content">
                        <div class="modal-header">
                            <button type="button" class="close" data-dismiss="modal">&times;</button>
                            <h4 class="modal-title">Cài đặt hiển thị nhóm kênh</h4>
                        </div>
                        <div class="modal-body">
                            <div id="body_modal_setting"></div>
                        </div>
                        <div class="modal-footer">
                            <button type="button" class="btn btn-success" data-dismiss="modal" onclick="CloseModal()">Close</button>
                        </div>
                    </div>
                </div>
            </div>
            <%--modal--%>

            <div class="wrapper">
                <header class="main-header">
                    <!-- Header Navbar -->
                    <nav class="navbar navbar-static-top menu-top-mobile" role="navigation">
                        <!-- Sidebar toggle button-->
                        <div class="icon-menu" onclick="displayMenuList(); return false">
                            <asp:ImageButton ToolTip="Menu" ImageUrl="~/App_Themes/menu-list.jpg" runat="server" />
                            <%--<span class="sr-only">Toggle navigation</span>--%>
                        </div>
                        <!-- Navbar Right Menu -->
                    </nav>
                </header>
                <aside class="main-sidebar box-shadow menu-main-mobile" id="tab-icon-menu">

                    <!-- sidebar: style can be found in sidebar.less -->
                    <div class="sidebar">
                        <ul class="sidebar-menu" data-widget="tree">
                            <!-- Optionally, you can add icons to the links -->
                            <%--<li class="treeview">
                                <a class="logo brand-link" href="/">
                                    <img src="../../App_Themes/logo.png" alt="Logo" class="brand-image img-circle elevation-3" style="opacity: .8" runat="server" id="imgLogo">
                                </a>
                            </li>--%>
                            <li>
                                <a href="/_supervisor/map/Map.aspx">
                                    <i class="fa fa-home"></i>
                                    <asp:Label ID="lbMap" runat="server" Text="Bản Đồ Tổng Thể"></asp:Label>
                                </a>
                            </li>
                             <li>
                                <a href="/_supervisor/map/Map2.aspx">
                                    <i class="fa fa-home"></i>
                                    <asp:Label ID="lbMap2" runat="server" Text="Bản Đồ Tổng Thể 2"></asp:Label>
                                </a>
                            </li>
                            <li>
                                <a href="/_supervisor/DashBoard/DashBoard.aspx">
                                    <i class="fa fa-table"></i>
                                    <asp:Label ID="lbDashBoard" runat="server" Text="DashBoard"></asp:Label>
                                </a>
                            </li>
                               
                         <li>
                            <a href="/_supervisor/logger/datalogger.aspx">
                                <i class="fa fa-table"></i>
                                <asp:Label ID="lbDataLoggerTable" runat="server" Text="Dữ Liệu Logger"></asp:Label>
                            </a>
                        </li>
                            <li class="treeview">
                                <a href="#ThietBi"><i class="fa fa-flag"></i>
                                    <asp:Label ID="lbDevice" runat="server" Text="Thiết Bị"></asp:Label>
                                    <span class="pull-right-container">
                                        <i class="fa fa-angle-left pull-right fa-block" style="display: none;"></i>
                                    </span>
                                </a>
                                <ul class="treeview-menu">
                                    <li>
                                        <a href="/_supervisor/device/meter.aspx">
                                            <asp:Label ID="lbMeter" runat="server" Text="Đồng Hồ"></asp:Label>
                                        </a>
                                    </li>
                                    <li>
                                        <a href="/_supervisor/device/transmitter.aspx">
                                            <asp:Label ID="lbTransmitter" runat="server" Text="Bộ Hiển Thị"></asp:Label>
                                        </a>
                                    </li>
                                    <li>
                                        <a href="/_supervisor/device/logger.aspx">
                                            <asp:Label ID="lbLogger" runat="server" Text="Logger"></asp:Label>
                                        </a>
                                    </li>
                                    <li>
                                        <a href="/_supervisor/device/cover.aspx">
                                            <asp:Label ID="lbCover" runat="server" Text="Nắp Hầm"></asp:Label>
                                        </a>
                                    </li>
                                    <li>
                                        <a href="/_supervisor/file/meter.aspx">
                                            <asp:Label ID="lbDownloadMeterFile" runat="server" Text="Download File Đồng Hồ"></asp:Label>
                                        </a>
                                    </li>
                                    <li>
                                        <a href="/_supervisor/device/delete_useless_meters.aspx">
                                            <asp:Label ID="lbDeleteMeterNotUse" runat="server" Text="Xóa Đồng Hồ Không Sử Dụng"></asp:Label>
                                        </a>
                                    </li>
                                    <li>
                                        <a href="/_supervisor/device/delete_useless_transmitters.aspx">
                                            <asp:Label ID="lbDeleteTransmitterNotUse" runat="server" Text="Xóa Bộ Hiển Thị Không Sử Dụng"></asp:Label>
                                        </a>
                                    </li>
                                    <li>
                                        <a href="/_supervisor/device/delete_useless_loggers.aspx">
                                            <asp:Label ID="lbDeleteLoggerNotUse" runat="server" Text="Xóa Logger Không Sử Dụng"></asp:Label>
                                        </a>
                                    </li>
                                </ul>
                            </li>

                            <li class="treeview">
                                <a href="#ViTriLapDat"><i class="fa fa-map-marker"></i>
                                    <asp:Label ID="blEAndsL" runat="server" Text="Điểm Lắp Đặt"></asp:Label>
                                    <span class="pull-right-container">
                                        <i class="fa fa-angle-left pull-right fa-block" style="display: none;"></i>
                                    </span>
                                </a>
                                <ul class="treeview-menu">
                                    <li>
                                        <a href="/_supervisor/site/info.aspx">
                                            <asp:Label ID="lbInfo" runat="server" Text="Thông Tin Điểm Lắp Đặt"></asp:Label>
                                        </a>
                                    </li>
                                    <li>
                                        <a href="/_supervisor/site/config.aspx">
                                            <asp:Label ID="lbConfig" runat="server" Text="Cấu Hình Logger"></asp:Label>
                                        </a>
                                    </li>
                                    <li>
                                        <a href="/_supervisor/site/change_meter.aspx">
                                            <asp:Label ID="lbChangeMeter" runat="server" Text="Thay Đồng Hồ"></asp:Label>
                                        </a>
                                    </li>
                                    <li>
                                        <a href="/_supervisor/site/change_transmitter.aspx">
                                            <asp:Label ID="lbChangeTransmitter" runat="server" Text="Thay Bộ Hiển Thị"></asp:Label>
                                        </a>
                                    </li>
                                    <li>
                                        <a href="/_supervisor/site/change_logger.aspx">
                                            <asp:Label ID="lbChangeLogger" runat="server" Text="Thay Logger"></asp:Label>
                                        </a>
                                    </li>
                                    <li>
                                        <a href="/_supervisor/file/site.aspx">
                                            <asp:Label ID="lbDownloadFileConfig" runat="server" Text="Download File Điểm Lắp Đặt"></asp:Label>
                                        </a>
                                    </li>
                                </ul>
                            </li>
                            <li class="treeview">
                                <a href="#ThongKe"><i class="fa fa-balance-scale"></i>
                                    <asp:Label ID="lbThongKe" runat="server" Text="Thống Kê"></asp:Label>
                                    <span class="pull-right-container">
                                        <i class="fa fa-angle-left pull-right fa-block" style="display: none;"></i>
                                    </span>
                                </a>
                                <ul class="treeview-menu">
                                    <li>
                                        <a href="/_supervisor/report/rsi_sgwdc.aspx">
                                            <asp:Label ID="lbReportRSI" runat="server" Text="Điểm Lắp Đặt Theo DMA"></asp:Label>
                                        </a>
                                    </li>
                                    <li>
                                        <a href="/_supervisor/report/rsi_marks_size_sgwdc.aspx">
                                            <asp:Label ID="lbReportRSIMark" runat="server" Text="Theo Hiệu Cỡ (DMA)"></asp:Label>
                                        </a>
                                    </li>
                                    <li>
                                        <a href="/_supervisor/report/rsi_.aspx">
                                            <asp:Label ID="lbRSI_" runat="server" Text="Thống Kê Tùy Chọn Điểm Lắp Đặt"></asp:Label>
                                        </a>
                                    </li>
                                    <li>
                                        <a href="/_supervisor/report/rsi_marks_size.aspx">
                                            <asp:Label ID="lbRSIMarkSize" runat="server" Text="Thống Kê Tùy Chọn Hiệu Cỡ"></asp:Label>
                                        </a>
                                    </li>
                                    <li>
                                        <a href="/_supervisor/report/rsi_has_changed.aspx">
                                            <asp:Label ID="lbRSIChange" runat="server" Text="Hoạt Động Phát Sinh Trong Kỳ"></asp:Label>
                                        </a>
                                    </li>
                                    <li>
                                        <a href="/_supervisor/report/rde_meter.aspx">
                                            <asp:Label ID="lbRDEMeter" runat="server" Text="Thống Kê Đồng Hồ"></asp:Label>
                                        </a>
                                    </li>
                                    <li>
                                        <a href="/_supervisor/report/rde_transmitter.aspx">
                                            <asp:Label ID="lbRDETransmitter" runat="server" Text="Thống Kê Bộ Hiển Thị"></asp:Label>
                                        </a>
                                    </li>
                                    <li>
                                        <a href="/_supervisor/report/rde_logger.aspx">
                                            <asp:Label ID="lbRDELogger" runat="server" Text="Thống Kê Bộ Logger"></asp:Label>
                                        </a>
                                    </li>
                                    <li>
                                        <a href="/_supervisor/report/rsi_history.aspx">
                                            <asp:Label ID="lbRSIHistory" runat="server" Text="Lịch Sử Điểm Lắp Đặt"></asp:Label>
                                        </a>
                                    </li>
                                    <li>
                                        <a href="/_supervisor/report/rsi_expiry.aspx">
                                            <asp:Label ID="lbRSIExpiry" runat="server" Text="Thời Gian Đồng Hồ Hoạt Động"></asp:Label>
                                        </a>
                                    </li>
                                    <li>
                                        <a href="/_supervisor/report/rsi_meter_accrediation.aspx">
                                            <asp:Label ID="lbRSIMeterAccredaition" runat="server" Text="Đồng Hồ Đến Hạn Kiểm Định"></asp:Label>
                                        </a>
                                    </li>
                                    <li>
                                        <a href="/_supervisor/report/rde_emeter.aspx">
                                            <asp:Label ID="lbRDEEmeter" runat="server" Text="Hồ Sơ Thiết Bị Đồng Hồ"></asp:Label>
                                        </a>
                                    </li>
                                    <li>
                                        <a href="/_supervisor/report/rde_etransmitter.aspx">
                                            <asp:Label ID="lbRDERTransmitter" runat="server" Text="Hồ Sơ Thiết Bị Bộ Hiển Thị"></asp:Label>
                                        </a>
                                    </li>
                                    <li>
                                        <a href="/_supervisor/report/rde_elogger.aspx">
                                            <asp:Label ID="lbRDERLogger" runat="server" Text="Hồ Sơ Thiết Bị Logger"></asp:Label>
                                        </a>
                                    </li>
                                </ul>
                            </li>
                            <li class="treeview">
                                <a href="#NhapLieu"><i class="fa fa-pencil-square-o"></i>
                                    <asp:Label ID="lbNhapLieu" runat="server" Text="Nhập Liệu"></asp:Label>
                                    <span class="pull-right-container">
                                        <i class="fa fa-angle-left pull-right fa-block" style="display: none;"></i>
                                    </span>
                                </a>
                                <ul class="treeview-menu">
                                    <li>
                                        <a href="/_supervisor/data/raw.aspx">
                                            <asp:Label ID="lbDataRaw" runat="server" Text="Nhập Tay Chỉ Số"></asp:Label>
                                        </a>
                                    </li>
                                    <li>
                                        <a href="/_supervisor/data/logger.aspx">
                                            <asp:Label ID="lbDataLogger" runat="server" Text="Nhập Tay Sản Lượng"></asp:Label>
                                        </a>
                                    </li>
                                    <li>
                                        <a href="/_supervisor/data/change.aspx">
                                            <asp:Label ID="lbDataChange" runat="server" Text="Sữa Dữ Liệu Nhập Tay"></asp:Label>
                                        </a>
                                    </li>
                                </ul>
                            </li>
                             <li class="treeview">
                            <a href="#QuanLyNguoiDung"><i class="fa fa-users"></i>
                                <asp:Label ID="lbAdminPanel" runat="server" Text="Admin Panel"></asp:Label>
                                <span class="pull-right-container">
                                    <i class="fa fa-angle-left pull-right fa-block" style="display: none;"></i>
                                </span>
                            </a>
                            <ul class="treeview-menu">
                               
                                <li>
                                    <a href="/_supervisor/admin/cre_user.aspx">
                                        <asp:Label ID="lbCreateUsers" runat="server" Text="Tạo Mới Người Dùng"></asp:Label>
                                    </a>
                                </li>
                                <li>
                                    <a href="/_supervisor/admin/cre_staff.aspx">
                                        <asp:Label ID="lbCreateStaff" runat="server" Text="Tạo Mới Nhân Viên"></asp:Label>
                                    </a>
                                </li>
                            </ul>
                        </li>
                         

                            <li class="treeview">
                                <a href="#SanLuong"><i class="fa fa-database"></i>
                                    <asp:Label ID="lbQuantity" runat="server" Text="Sản Lượng"></asp:Label>
                                    <span class="pull-right-container">
                                        <i class="fa fa-angle-left pull-right fa-block" style="display: none;"></i>
                                    </span>
                                </a>
                                <ul class="treeview-menu">
                                    <li>
                                        <a href="/_supervisor/logger/datalogger.aspx">
                                            <asp:Label ID="lbDataLoggerComplex" runat="server" Text="Dữ Liệu Logger"></asp:Label>
                                        </a>
                                    </li>
                                    <li>
                                        <a href="/_supervisor/logger/HourlyLogger.aspx">
                                            <asp:Label ID="lbQuantityHourlyLogger" runat="server" Text="Sản Lượng Giờ Theo Point"></asp:Label>
                                        </a>
                                    </li>
                                    <li>
                                        <a href="/_supervisor/logger/DailyLogger.aspx">
                                            <asp:Label ID="lbDailyQuantityPoint" runat="server" Text="Sản Lượng Ngày Theo Point"></asp:Label>
                                        </a>
                                    </li>
                                    <li>
                                        <a href="/_supervisor/logger/MonthlyLogger.aspx">
                                            <asp:Label ID="lbmonthlyQuantityLogger" runat="server" Text="Sản Lượng Tháng Theo Point"></asp:Label>
                                        </a>
                                    </li>
                                    <li>
                                        <a href="/_supervisor/logger/HourlyManager.aspx">
                                            <asp:Label ID="lbQuantityHourlyManager" runat="server" Text="Sản Lượng Giờ Theo DMA"></asp:Label>
                                        </a>
                                    </li>
                                    <li>
                                        <a href="/_supervisor/logger/DailyManager.aspx">
                                            <asp:Label ID="lbDailyQuantityManager" runat="server" Text="Sản Lượng Ngày Theo DMA"></asp:Label>
                                        </a>
                                    </li>
                                    <li>
                                        <a href="/_supervisor/logger/MonthlyCompany.aspx">
                                            <asp:Label ID="lbMonthlyQuantityManager" runat="server" Text="Sản Lượng Tháng Theo DMA"></asp:Label>
                                        </a>
                                    </li>
                                    <li>
                                        <a href="/_supervisor/logger/HourlyTotal.aspx">
                                            <asp:Label ID="lbHourlyQuantityTotal" runat="server" Text="Sản Lượng Giờ Tổng Công Ty"></asp:Label>
                                        </a>
                                    </li>
                                    <li>
                                        <a href="/_supervisor/logger/DailyTotal.aspx">
                                            <asp:Label ID="lbDailyQuantityTotal" runat="server" Text="Sản Lượng Ngày Tổng Công Ty"></asp:Label>
                                        </a>
                                    </li>
                                    <li>
                                        <a href="/_supervisor/logger/MonthlyTotal.aspx">
                                            <asp:Label ID="lbMonthlyQuantityTotal" runat="server" Text="Sản Lượng Tháng Tổng Công Ty"></asp:Label>
                                        </a>
                                    </li>
                                </ul>
                            </li>

                            <li class="treeview">
                                <a href="#DoThi"><i class="fa fa-line-chart"></i>
                                    <asp:Label ID="lbChart" runat="server" Text="Đồ Thị"></asp:Label>
                                    <span class="pull-right-container">
                                        <i class="fa fa-angle-left pull-right fa-block" style="display: none;"></i>
                                    </span>
                                </a>
                                <ul class="treeview-menu">
                                    <li>
                                        <a href="/_supervisor/chartP/ChartPoint.aspx">
                                            <asp:Label ID="lbPointChart" runat="server" Text="Đồ Thị Giờ Theo Point"></asp:Label>
                                        </a>
                                    </li>
                                    <li>
                                        <a href="/_supervisor/chartP/ChartPointDay.aspx">
                                            <asp:Label ID="lbChartPointDaily" runat="server" Text="Đồ Thị Ngày Theo Point"></asp:Label>
                                        </a>
                                    </li>
                                     <li>
                                        <a href="/_supervisor/chartP/ChartPointMonthly.aspx">
                                            <asp:Label ID="lbChartPointMonthly" runat="server" Text="Đồ Thị Tháng Theo Point"></asp:Label>
                                        </a>
                                    </li>
                                     <li>
                                        <a href="/_supervisor/chartP/ChartManagerHourly.aspx">
                                            <asp:Label ID="lbChartHourlyManager" runat="server" Text="Đồ Thị Giờ Theo DMA"></asp:Label>
                                        </a>
                                    </li>
                                    <li>
                                        <a href="/_supervisor/chartP/ChartManagerDaily.aspx">
                                            <asp:Label ID="lbChartDailyManager" runat="server" Text="Đồ Thị Ngày Theo DMA"></asp:Label>
                                        </a>
                                    </li>
                                    <li>
                                        <a href="/_supervisor/chartP/ChartManagerMonthly.aspx">
                                            <asp:Label ID="lbChartMonthlyManager" runat="server" Text="Đồ Thị Tháng Theo DMA"></asp:Label>
                                        </a>
                                    </li>
                                    <li>
                                        <a href="/_supervisor/chartP/ChartTotalHourly.aspx">
                                            <asp:Label ID="lbChartHourlyTotal" runat="server" Text="Đồ Thị Giờ Tổng"></asp:Label>
                                        </a>
                                    </li>
                                    <li>
                                        <a href="/_supervisor/chartP/ChartDailyTotal.aspx">
                                            <asp:Label ID="lbChartDailyTotal" runat="server" Text="Đồ Thị Ngày Tổng"></asp:Label>
                                        </a>
                                    </li>
                                    <li>
                                        <a href="/_supervisor/chartP/ChartMonthlyTotal.aspx">
                                            <asp:Label ID="lbChartMonthlyTotal" runat="server" Text="Đồ Thị Tháng Tổng"></asp:Label>
                                        </a>
                                    </li>
                                </ul>
                            </li>

                            <li class="treeview">
                                <a href="#CanhBao"><i class="fa fa-bell"></i>
                                    <asp:Label ID="lbAlarm" runat="server" Text="Cảnh Báo"></asp:Label>
                                    <span class="pull-right-container">
                                        <i class="fa fa-angle-left pull-right fa-block" style="display: none;"></i>
                                    </span>
                                </a>
                                <ul class="treeview-menu">
                                    <li>
                                        <a href="/_supervisor/alarm/AlarmTable.aspx">
                                            <asp:Label ID="lbTableAlarm" runat="server" Text="Bảng Cảnh Báo"></asp:Label>
                                        </a>
                                    </li>
                                    <li>
                                        <a href="/_supervisor/alarm/SettingAlarm.aspx">
                                            <asp:Label ID="lbSettingAlarm" runat="server" Text="Cài Đặt Cảnh Báo"></asp:Label>
                                        </a>
                                    </li>
                                </ul>
                            </li>

                            <li class="treeview">
                                <a href="#DMA"><i class="fa fa-plus-square"></i>
                                    <asp:Label ID="lbDMA" runat="server" Text="DMA"></asp:Label>
                                    <span class="pull-right-container">
                                        <i class="fa fa-angle-left pull-right fa-block" style="display: none;"></i>
                                    </span>
                                </a>
                                <ul class="treeview-menu">
                                    <li>
                                        <a href="/_supervisor/DMA/AddDMA.aspx">
                                            <asp:Label ID="lbAddDMA" runat="server" Text="Thêm DMA"></asp:Label>
                                        </a>
                                    </li>
                                    <li>
                                        <a href="/_supervisor/DMA/SeparateDMA.aspx">
                                            <asp:Label ID="lbSeoerateDMA" runat="server" Text="Phân DMA"></asp:Label>
                                        </a>
                                    </li>
                                </ul>
                            </li>
                            <%-- <li class="treeview">
                            <a href="#QuanLyNgonNgu"><i class="fa fa-language"></i>
                                <asp:Label ID="lbLanguageManagement" runat="server" Text="Quản Lý Ngôn Ngữ"></asp:Label>
                                <span class="pull-right-container">
                                    <i class="fa fa-angle-left pull-right fa-block" style="display: none;"></i>
                                </span>
                            </a>
                            <ul class="treeview-menu">
                                <li>
                                    <a href="/Supervisor/Language/ChangeFunction.aspx">
                                        <asp:Label ID="lbFunctions" runat="server" Text="Tính Năng"></asp:Label>
                                    </a>
                                </li>
                                <li>
                                    <a href="/Supervisor/Language/ChangeContent.aspx">
                                        <asp:Label ID="lbContents" runat="server" Text="Nội Dung Chi Tiết"></asp:Label>
                                    </a>
                                </li>
                            </ul>
                        </li>--%>

                            <%-- <li class="treeview">
                            <a href="#QuanLyHeThong"><i class="fa fa-plug"></i>
                                <asp:Label ID="lbConfigSystem" runat="server" Text="Quản Lý Hệ Thống"></asp:Label>
                                <span class="pull-right-container">
                                    <i class="fa fa-angle-left pull-right fa-block" style="display: none;"></i>
                                </span>
                            </a>
                            <ul class="treeview-menu">
                                <li>
                                    <a href="/Supervisor/System/General.aspx">
                                        <asp:Label ID="lbGeneralSystem" runat="server" Text="Hệ Thống Chung"></asp:Label>
                                    </a>
                                </li>
                                <li>
                                    <a href="/Supervisor/System/Users.aspx">
                                        <asp:Label ID="lbUserManagement" runat="server" Text="Quản lý tài khoản"></asp:Label>
                                    </a>
                                </li>
                                <li>
                                    <a href="/Supervisor/System/Roles.aspx">
                                        <asp:Label ID="lbRoleManagement" runat="server" Text="Quản lý vai trò người dùng"></asp:Label>
                                    </a>
                                </li>
                                <li>
                                    <a href="/Supervisor/System/RoleFunction.aspx">
                                        <asp:Label ID="lbRoleFunctionManagement" runat="server" Text="Quản lý quyền truy cập"></asp:Label>
                                    </a>
                                </li>
                            </ul>
                        </li>--%>
                            <%-- <li class="treeview">
                            <a href="#FullScreen">
                                <i class="fa fa-arrows-alt"></i>
                                <span class="name">
                                    <asp:Label ID="lbFullScreen" runat="server" Text="Toàn màn hình"></asp:Label>
                                </span>
                            </a>
                        </li>--%>
                            <%--<li class="treeview">
                            <a href="#Alert" id="btnShowAlarm" class="click">
                                <i class="fa fa-bell-o"></i>
                                <span class="name">
                                    <asp:Label ID="lbAlert" runat="server" Text="Cảnh báo"></asp:Label>
                                </span>
                                <span class="pull-right-container" id="txtCountAlarm">
                                        
                                </span>
                            </a>
                        </li>--%>

                            <%-- <li class="treeview">
                            <a href="#NgonNgu">
                                <i class="fa fa-language"></i>
                                <asp:Label ID="Label1" runat="server" Text="Ngôn ngữ"></asp:Label>
                                <span class="name">
                                    <asp:Label ID="lbLang" runat="server" Text=""></asp:Label>
                                </span>
                                <span class="pull-right-container">
                                    <i class="fa fa-angle-left pull-right fa-block" style="display: none;"></i>
                                </span>
                            </a>
                            <ul class="treeview-menu">
                                <li>
                                    <a href="#"  runat="server">
                                        <asp:Label ID="lbVi" runat="server" Text="VietNamese"></asp:Label>
                                    </a>
                                </li>
                                <li>
                                    <a href="#"  runat="server">
                                        <asp:Label ID="lbEn" runat="server" Text="English"></asp:Label>
                                    </a>
                                </li>
                                <li>
                                    <a href="#" runat="server">
                                        <asp:Label ID="lbOther" runat="server" Text="Other"></asp:Label>
                                    </a>
                                </li>
                            </ul>
                        </li>--%>

                            <li class="treeview">
                                <a href="#DangXuat">
                                    <i class="fa fa-user-circle"></i>
                                    <span class="name">
                                        <asp:Label ID="lbUserName" runat="server" Text="User's name"></asp:Label>
                                    </span>
                                    <span class="pull-right-container">
                                        <i class="fa fa-angle-left pull-right fa-block" style="display: none;"></i>
                                    </span>
                                </a>
                                <ul class="treeview-menu">
                                    <li>
                                        <a href="/_supervisor/account/change_password.aspx">
                                            <%--<i class="fa fa-gear icon"></i>--%>
                                            <asp:Label ID="lbChangePassword" runat="server" Text="Đổi Mật Khẩu"></asp:Label>
                                        </a>
                                    </li>
                                    <li></li>
                                </ul>
                            </li>
                            <li class="treeview">
                                <a href="#" id="btnLogout">
                                    <i class="fa fa-power-off icon"></i>
                                    <asp:Label ID="lbLogout" runat="server" Text="Logout"></asp:Label>
                                </a>

                            </li>

                        </ul>
                        <asp:HiddenField ID="hidListMenu" runat="server" />
                        <!-- /.sidebar-menu -->
                    </div>
                    <!-- /.sidebar -->
                </aside>

                <div class="custom-show-alarm  showup" id="form_Show_Alarm">
                    <div class="col-md-12 col-xs-12" id="body_form_show_alarm">
                        <div class="box box-solid">
                            <div class="box-header with-border">
                                <button type="button" class="click close" onclick="btnAlarm_Click()">&times;</button>
                                <h3 class="box-title">Cảnh báo</h3>
                            </div>
                            <div class="box-body" style="max-height: 200px; overflow: auto;">
                                <table class="table table-bordered">
                                    <thead>
                                        <tr>
                                            <th style="width: 10px">STT</th>
                                            <th>Alias Name</th>
                                            <th>TimeStamp</th>
                                            <th>Parameter </th>
                                            <th>Value</th>
                                            <th>Status</th>
                                        </tr>
                                    </thead>
                                    <tbody id="bodyFormAlarm">
                                    </tbody>
                                </table>
                            </div>
                            <div id="noAlarm" class="m-t m-l text-black cls-display-none">
                                <span>Không có cảnh báo nào.</span>
                            </div>
                            <!-- /.box-body -->
                            <div class="box-footer clearfix">
                                <input id="btnConfirmAlarm" class="btn btn-info btn-right" type="button" value="Xác Nhận" onclick="btnConfirmAlarm_Click()" />
                            </div>
                        </div>
                        <!-- /.box -->
                    </div>
                </div>
                <!-- Content Wrapper. Contains page content -->
                <div class="content-wrapper">
                    <!-- Main content -->
                    <section class="content no-padding">

                        <telerik:RadSplitter ID="RadSplitter1" runat="server" Height="100%" Width="100%">

                            <telerik:RadPane ID="RadPane2" runat="server" Height="100%">
                                <a href="#" class="zoom-icon  custom-tooltip" onclick="resetZoom()">
                                    <img src="../../App_Themes/zoom.png" />
                                    <span class="tooltiptext">ZOOM-OUT</span>
                                </a>
                                <a href="#" class="icon-right width-search-icon custom-tooltip" data-toggle="control-sidebar" id="icon_collap_rightmenu" onclick="customPositionIcon()">
                                    <img src="../../App_Themes/setting.png" />
                                    <span class="tooltiptext">CHỌN ĐỊA ĐIỂM</span>
                                </a>
                                <a href="#" class="icon-right width-setting-icon custom-tooltip" data-toggle="control-sidebar" id="icon_collap_setting_menu" onclick="customPosStting()">
                                    <img src="../../App_Themes/setting.png" />
                                    <span class="tooltiptext">CẤU HÌNH</span>
                                </a>
                                <a href="#" class="icon-right width-filter-icon custom-tooltip" data-toggle="control-sidebar" id="icon_collap_filter_menu" onclick="customFilter()">
                                    <img src="../../App_Themes/filter.png" />
                                    <span class="tooltiptext">LỌC SITES</span>
                                </a>
                                <a href="#" class="icon-right width-layer-icon custom-tooltip" data-toggle="control-sidebar" id="icon_collap_layer_menu" style="display: none" onclick="customLayer()">
                                    <img src="../../App_Themes/layer.png" />
                                    <span class="tooltiptext">LAYERS</span>
                                </a>

                                <div id="map_canvas">
                                </div>

                                <div class="bottom-popup-esri-siteinfo col-md-6 col-sm-12 col-xs-12 cls-display-none no-padding" id="bottom_popup_siteinfo">
                                    <div class="bg-primary col-md-12 col-xs-12">
                                        <div class="col-md-6 col-xs-6">
                                            <span class="text-white"></span>
                                        </div>
                                        <div class="col-md-6 col-xs-6 text-right ">
                                            <a class="" href="#" onclick="closePopupSiteInfo()">
                                                <img style="height: 20px" src="../../_imgs/close-icon.png" />
                                            </a>
                                        </div>
                                    </div>

                                    <div class="col-md-12 col-xs-12">
                                        <table class="table table-striped">
                                            <tbody>
                                                <tr>
                                                    <td>Vị trí:</td>
                                                    <td><span id="txtAliasName"></span></td>
                                                    <td>Id:</td>
                                                    <td><span id="txtSiteId"></span></td>
                                                    <td>Mô tả:</td>
                                                    <td><span id="txtDescription"></span></td>
                                                </tr>
                                                <tr>
                                                    <td>Cỡ ống:</td>
                                                    <td><span id="txtPieSize"></span></td>
                                                    <td>Phone:</td>
                                                    <td><span id="txtPhone"></span></td>
                                                    <td>Delay:</td>
                                                    <td><span id="txtDelay"></span></td>
                                                </tr>
                                                <tr>
                                                    <td>DMA vào:</td>
                                                    <td><span id="txtDmain"></span></td>
                                                    <td>DMA ra:</td>
                                                    <td><span id="txtDmaout"></span></td>
                                                    <td>Start hour:</td>
                                                    <td><span id="txtStarthour"></span></td>
                                                </tr>
                                            </tbody>
                                        </table>
                                    </div>
                                </div>



                                <div class="bottom-popup-esri cls-display-none" id="bottom_popup_esri" style="height: 240px; max-height: 240px; overflow: hidden">

                                    <div class="col-md-3 no-padding" style="height: 240px; max-height: 240px;">
                                        <div class="col-md-12 text-center bg-primary fix-header">
                                            <label style="color: white !important; padding-top: 5px" id="header_table_bottom_eri"></label>
                                            <asp:HiddenField runat="server" ID="hdpLoggerIdPopup" />
                                            <a href="#" onclick="showPopupInfoSite()">
                                                <img style="height: 18px; margin-left: 20px" src="../../_imgs/warning-icon.png" /></a>
                                        </div>
                                        <div style="width: 100%; height: 213px; max-height: 213px; overflow-y: auto;">
                                            <table class="table table-striped">
                                                <tbody id="body_table_bottom_eri">
                                                </tbody>
                                            </table>
                                        </div>
                                    </div>


                                    <div class="col-md-5  no-padding" style="height: 240px; max-height: 240px;">
                                        <div class="col-md-12  text-center bg-primary fix-header" style="z-index: 2000">
                                            <label style="color: white !important; padding-top: 5px">Lịch sử dữ liệu</label>
                                            <a href="#" data-toggle="modal" data-target="#myModal">
                                                <img style="height: 18px; margin-left: 20px" src="../../_imgs/setting-icon.png" /></a>
                                        </div>
                                        <div style="width: 100%; height: 213px; max-height: 213px; overflow-y: auto; overflow-x: hidden">
                                            <div id="chart_data_with" style="width: 100%; height: 160px;"></div>
                                            <div id="legend_chart_data_with" style="width: 100%; position: relative"></div>

                                            <div class="text-center">
                                                <img style="height: 100px;" id="img_error_chart_with" class="cls-display-none" src="../../_imgs/error_data.png" />
                                            </div>
                                        </div>
                                    </div>
                                    <div class="col-md-4 no-padding">
                                        <div class="col-md-12  text-center bg-primary fix-header" style="z-index: 2000; padding-top: 5px;">
                                            <label style="color: white !important;">Thống kê</label>
                                            <a href="#" onclick="closeBottomPopup()" title="Close popup">
                                                <img style="height: 18px; margin-left: 20px; float: right;" src="../../_imgs/close-icon.png" /></a>
                                        </div>
                                        <div style="width: 100%; margin-top: 30px">
                                            <div id="chart_data_with_column" style="width: 100%; height: 180px;"></div>
                                        </div>
                                        <div class="text-center">
                                            <img style="height: 100px;" id="img_error_chart_with_column" class="cls-display-none" src="../../_imgs/error_data.png" />
                                        </div>
                                    </div>




                                </div>
                                <%-- control-sidebar-open--%>
                                <div class="control-sidebar control-sidebar-dark config-menu" style="padding-top: 10px">
                                    <!-- Tab panes -->
                                    <div class="tab-content" id="tab_menu_1">
                                        <div class="row m-b5">
                                            <div class="col-xs-9 text-left">
                                                <input id="txtSearchTree" type="text" class="text-black" onkeyup="searchTree(value)" placeholder="Filter" />
                                            </div>
                                            <div class="col-xs-3 text-right">
                                                <a href="#" onclick="CollapRadTreeView()">
                                                    <img style="height: 20px; margin-left: 20px" id="iconCollap" src="../../_imgs/expan-icon.png" />
                                                    <img style="height: 20px; margin-left: 20px" class="cls-display-none" id="iconExpan" src="../../_imgs/collap-icon.png" />
                                                </a>
                                            </div>
                                        </div>
                                        <telerik:RadTreeView ID="radTreeViewSite" runat="server" EnableDragAndDrop="true" EnableDragAndDropBetweenNodes="false" OnClientNodeDropping="radTreeViewSite_NodeDropping" OnClientNodeClicked="radTreeViewSite_NodeClicked">
                                        </telerik:RadTreeView>
                                        <div id="NoResultFound" class="m-t text-white cls-display-none">
                                            <span>No items found</span>
                                        </div>
                                    </div>
                                    <div class="tab-content cls-display-none" id="tab_menu_2">
                                        <div>
                                            <h4 class="text-white">
                                                <asp:Label Text="Thiết lập bản đồ" ID="txtSettingMap" runat="server" />
                                            </h4>
                                        </div>
                                        <%--<div class="checkbox">
                                            <div>
                                                <input type="checkbox" class="custom-checkbox" checked="checked" value="" id="cbkGroupLogger">
                                                <asp:Label Text="Gom nhóm Logger" ID="ckGroupLogger" runat="server" />
                                            </div>
                                        </div>--%>
                                        <div class="checkbox">
                                            <div>
                                                <input type="checkbox" class="custom-checkbox" checked="checked" value="" id="cbkShowInfo">
                                                <asp:Label Text="Hiển thị thông số hiện tại" ID="ckShowDetail" runat="server" />
                                            </div>
                                        </div>

                                        <div>
                                            <h4 class="text-white">
                                                <asp:Label Text="Hiển thị popup" ID="txtShowPopup" runat="server" />
                                            </h4>
                                        </div>

                                        <div class="checkbox">
                                            <div>
                                                <input type="checkbox" class="custom-checkbox" checked="checked" value="" id="cbkShowTableDetal">
                                                <asp:Label Text="Chi tiết bảng" ID="ckDetailTable" runat="server" />

                                            </div>
                                        </div>
                                        <div class="checkbox">
                                            <div>
                                                <input type="checkbox" class="custom-checkbox" value="" id="cbkRemoveApLL">
                                                <asp:Label Text="Đơn giản áp lực, lưu lượng" ID="ckRemoveALLL" runat="server" />
                                            </div>
                                        </div>
                                        <div class="checkbox">
                                            <div>
                                                <input type="checkbox" class="custom-checkbox" value="" id="cbkRemoveApluc">
                                                <asp:Label Text="Đơn giản áp lực" ID="ckRemoveAL" runat="server" />
                                            </div>
                                        </div>
                                        <div class="checkbox">
                                            <div>
                                                <input type="checkbox" class="custom-checkbox" value="" id="cbkRemoveLuuLuong">
                                                <asp:Label Text="Đơn giản lưu lượng" ID="ckRemoveLL" runat="server" />
                                            </div>
                                        </div>

                                        <div>
                                            <h4 class="text-white">
                                                <asp:Label Text="Danh sách nhóm logger" ID="txtListGroupLogger" runat="server" />
                                            </h4>
                                        </div>

                                        <div class="checkbox">
                                            <div>
                                                <input type="checkbox" class="custom-checkbox" checked="checked" value="" id="cbkbinhthuong">
                                                <asp:Label Text="Bình thường" ID="ckBinhThuong" runat="server" />
                                            </div>
                                        </div>
                                        <div class="checkbox">
                                            <div>
                                                <input type="checkbox" class="custom-checkbox" checked="checked" value="" id="cbkvuotnguong">
                                                <asp:Label Text="Vượt ngưỡng" ID="ckVuotNguong" runat="server" />
                                            </div>
                                        </div>
                                        <div class="checkbox">
                                            <div>
                                                <input type="checkbox" class="custom-checkbox" checked="checked" value="" id="cbkbaotre">
                                                <asp:Label Text="Báo trễ" ID="ckBaoTre" runat="server" />
                                            </div>
                                        </div>
                                        <div class="checkbox">
                                            <div>
                                                <input type="checkbox" class="custom-checkbox" checked="checked" value="" id="cbkkhongapluc">
                                                <asp:Label Text="Không áp lực" ID="ckKhongApLuc" runat="server" />
                                            </div>
                                        </div>

                                        <div>
                                            <h4 class="text-white">
                                                <asp:Label Text="Danh sách nhóm kênh" ID="txtListGroupChannel" runat="server" />
                                            </h4>
                                        </div>
                                        <div id="plhListGroupChannel"></div>
                                    </div>
                                    <div class="tab-content" id="tab_menu_3">
                                        <div>
                                            <h4 class="text-white">
                                                <asp:Label Text="Lọc sites" ID="lbFilterSites" runat="server" />
                                            </h4>
                                        </div>
                                        <div id="filterSitesArea">
                                        </div>

                                    </div>
                                    <div class="tab-content" id="tab_menu_4">
                                        <div>
                                            <h4 class="text-white">
                                                <asp:Label Text="Layers" ID="lbFilterLayer" runat="server" />
                                            </h4>
                                        </div>
                                        <div id="layerArea">
                                            <div class="checkbox">
                                                <div>
                                                    <input type="checkbox" class="custom-checkbox" value="1" id="ckArea">
                                                    <asp:Label Text="Vùng" ID="lbAreaLayer" runat="server" />
                                                </div>
                                            </div>
                                            <div class="checkbox">
                                                <div>
                                                    <input type="checkbox" class="custom-checkbox" value="1" id="ckPipeLV1">
                                                    <asp:Label Text="Tuyến Ống 1" ID="lbPipeLV1Layer" runat="server" />
                                                </div>
                                            </div>
                                            <div class="checkbox">
                                                <div>
                                                    <input type="checkbox" class="custom-checkbox" value="2" id="ckPipeLineLV2">
                                                    <asp:Label Text="Tuyến Ống 2" ID="lbPipeLV2Layer" runat="server" />
                                                </div>
                                            </div>
                                        </div>

                                    </div>
                                </div>
                                <div class="control-sidebar-bg"></div>
                            </telerik:RadPane>
                        </telerik:RadSplitter>

                        <telerik:RadWindow Behaviors="Pin, Move, Minimize, Maximize , Close" ID="radminmaxPress" runat="server" VisibleStatusbar="False" Title="Chart">
                            <ContentTemplate>
                                <div class="row" style="width: 100%;">
                                    <div class="col-md-4 col-sm-5 m-t custom-fill">
                                        &nbsp;Start Date: &nbsp;
                                        <telerik:RadDateTimePicker ID="radDateTimePicker5" CssClass="custom-picker h-33" runat="server" Culture="en-GB">
                                            <TimeView CellSpacing="-1" Culture="en-GB">
                                            </TimeView>
                                            <TimePopupButton HoverImageUrl="" ImageUrl="" />
                                            <Calendar EnableWeekends="True" UseColumnHeadersAsSelectors="False" UseRowHeadersAsSelectors="False">
                                            </Calendar>
                                            <DateInput DateFormat="dd/MM/yyyy" DisplayDateFormat="dd/MM/yyyy" Height="33px" LabelWidth="40%">
                                                <EmptyMessageStyle Resize="None" />
                                                <ReadOnlyStyle Resize="None" />
                                                <FocusedStyle Resize="None" />
                                                <DisabledStyle Resize="None" />
                                                <InvalidStyle Resize="None" />
                                                <HoveredStyle Resize="None" />
                                                <EnabledStyle Resize="None" />
                                            </DateInput>
                                            <DatePopupButton HoverImageUrl="" ImageUrl="" />
                                        </telerik:RadDateTimePicker>
                                    </div>
                                    <div class="col-md-4 col-sm-5 m-t custom-fill">
                                        &nbsp; End Date: &nbsp;&nbsp;&nbsp;
                                        <telerik:RadDateTimePicker ID="radDateTimePicker6" runat="server" CssClass="custom-picker h-33" Culture="en-GB">
                                            <TimeView CellSpacing="-1" Culture="en-GB">
                                            </TimeView>
                                            <TimePopupButton HoverImageUrl="" ImageUrl="" />
                                            <Calendar EnableWeekends="True" UseColumnHeadersAsSelectors="False" UseRowHeadersAsSelectors="False">
                                            </Calendar>
                                            <DateInput DateFormat="dd/MM/yyyy" DisplayDateFormat="dd/MM/yyyy" Height="33px" LabelWidth="40%">
                                                <EmptyMessageStyle Resize="None" />
                                                <ReadOnlyStyle Resize="None" />
                                                <FocusedStyle Resize="None" />
                                                <DisabledStyle Resize="None" />
                                                <InvalidStyle Resize="None" />
                                                <HoveredStyle Resize="None" />
                                                <EnabledStyle Resize="None" />
                                            </DateInput>
                                            <DatePopupButton HoverImageUrl="" ImageUrl="" />
                                        </telerik:RadDateTimePicker>
                                    </div>
                                    <div class="col-md-4 col-sm-5 m-t custom-fill h-33">
                                        <input id="btnUpdateChartMinMax" class="btn btn-success" type="button" value="Update" onclick="btnUpdateChartMinMax_Clicked(); return false;" />
                                        <input id="btnClearChartMinMax" class="btn btn-warning" type="button" value="Clear" onclick="btnClearChartMinMax_Clicked(); return false;" />
                                    </div>

                                </div>
                                <div id="chart_canvas_MinMax" style="width: 100%; height: 55%"></div>
                                <div id="summary_MinMax" style="width: 38%; height: 20%; border: dotted; float: left;">
                                    <div style="float: left; width: 100%; margin: 5px;"><b>Summary</b> </div>
                                    <div style="float: left; width: 100%; margin: 5px;">
                                        <div style="float: left;">Minimum Press Day: </div>
                                        <div id="minPress" style="float: left; color: blue"></div>
                                        <div style="float: left; color: blue">(m)</div>
                                    </div>
                                    <div style="float: left; width: 100%; margin: 5px;">
                                        <div style="float: left;">Maximum Press Day: </div>
                                        <div id="maxPress" style="float: left; color: blue"></div>
                                        <div style="float: left; color: blue">(m)</div>
                                    </div>

                                </div>
                                <div id="chart_table_MinMax" style="width: 60%; height: 35%; float: left; overflow: auto"></div>



                            </ContentTemplate>
                        </telerik:RadWindow>

                        <telerik:RadWindow Behaviors="Pin, Move, Minimize, Maximize , Close" ID="radWindowChart" runat="server" VisibleStatusbar="False" Title="Chart">
                            <ContentTemplate>
                                <div class="row" style="width: 100%;">
                                    <div class="col-md-4 col-sm-5 m-t custom-fill">
                                        &nbsp;Start Date: &nbsp;

                                        <telerik:RadDateTimePicker ID="radDateTimePickerStart" runat="server" CssClass="custom-picker h-33" Culture="en-GB">
                                            <TimeView CellSpacing="-1" Culture="en-GB">
                                            </TimeView>
                                            <TimePopupButton HoverImageUrl="" ImageUrl="" />
                                            <Calendar EnableWeekends="True" UseColumnHeadersAsSelectors="False" UseRowHeadersAsSelectors="False">
                                            </Calendar>
                                            <DateInput DateFormat="dd/MM/yyyy" DisplayDateFormat="dd/MM/yyyy" LabelWidth="40%">
                                                <EmptyMessageStyle Resize="None" />
                                                <ReadOnlyStyle Resize="None" />
                                                <FocusedStyle Resize="None" />
                                                <DisabledStyle Resize="None" />
                                                <InvalidStyle Resize="None" />
                                                <HoveredStyle Resize="None" />
                                                <EnabledStyle Resize="None" />
                                            </DateInput>
                                            <DatePopupButton HoverImageUrl="" ImageUrl="" />
                                        </telerik:RadDateTimePicker>
                                    </div>
                                    <div class="col-md-4 col-sm-5 m-t custom-fill">
                                        &nbsp;End Date:&nbsp;&nbsp;&nbsp
                                    
                                        <telerik:RadDateTimePicker ID="radDateTimePickerEnd" CssClass="custom-picker h-33" runat="server" Culture="en-GB">
                                            <TimeView CellSpacing="-1" Culture="en-GB">
                                            </TimeView>
                                            <TimePopupButton HoverImageUrl="" ImageUrl="" />
                                            <Calendar EnableWeekends="True" UseColumnHeadersAsSelectors="False" UseRowHeadersAsSelectors="False">
                                            </Calendar>
                                            <DateInput DateFormat="dd/MM/yyyy" DisplayDateFormat="dd/MM/yyyy" LabelWidth="40%">
                                                <EmptyMessageStyle Resize="None" />
                                                <ReadOnlyStyle Resize="None" />
                                                <FocusedStyle Resize="None" />
                                                <DisabledStyle Resize="None" />
                                                <InvalidStyle Resize="None" />
                                                <HoveredStyle Resize="None" />
                                                <EnabledStyle Resize="None" />
                                            </DateInput>
                                            <DatePopupButton HoverImageUrl="" ImageUrl="" />
                                        </telerik:RadDateTimePicker>
                                    </div>
                                    <div class="col-md-4 col-sm-5 m-t custom-fill h-33">
                                        <input id="btnUpdateChart" type="button" class="btn btn-success" value="Update" onclick="btnUpdateChart_Clicked(); return false;" />
                                        <input id="btnClearChart" type="button" class="btn btn-warning" value="Clear" onclick="btnClearChart_Clicked(); return false;" />
                                    </div>

                                </div>
                                <div id="chart_canvas" style="width: 100%; height: 90%"></div>

                            </ContentTemplate>
                        </telerik:RadWindow>

                        <telerik:RadWindow Behaviors="Close" ID="winAlarm" runat="server" Height="400px" Width="800px" VisibleStatusbar="false" CssClass="myRadWindow"
                            Title="Alarm Bar" OnClientBeforeClose="OnClientBeforeClose">
                        </telerik:RadWindow>


                        <telerik:RadScriptBlock ID="RadScriptBlock1" runat="server">
                            <script type="text/javascript">

                                function OnClientBeforeClose(sender, args) {
                                    args.set_cancel(!confirm("Are you sure that you want to close alarm bar?"));
                                }

                                /* END EXTERNAL SOURCE */

                                /* BEGIN EXTERNAL SOURCE */

                                //<![CDATA[

                                function radTreeViewSite_NodeDropping(sender, args) {
                                    //Add JavaScript handler code here
                                    if (args.get_htmlElement().toString() == "[object SVGPathElement]") {
                                        //alert()
                                        var channelInfo = args.get_sourceNode().get_value();
                                        var cDtStart = $find("<%=radDateTimePickerStart.ClientID %>");
                                        var cDtEnd = $find("<%=radDateTimePickerEnd.ClientID %>");
                                        var treeViewSite = $find("<%= radTreeViewSite.ClientID %>");
                                        var flag = false;
                                        var info = channelInfo.split('|');
                                        var channel = { id: info[0], namePath: (info[1] + " | " + info[2]), unit: info[3] }
                                        for (var i = 0; i < channels.length; i++) {
                                            if (channels[i].id == channel.id) {
                                                flag = true;
                                            }
                                        }
                                        if (flag == false) channels.push(channel);
                                        if (cDtStart.get_selectedDate() == null || cDtStart.get_selectedDate() == 'undefined') {
                                            end = new Date();
                                            start = new Date();
                                            start = new Date(start.setDate(start.getDate() - 1));
                                            //start = toOADate(start);
                                            //end = toOADate(end);
                                            start = start.getTime() / 1000;
                                            end = end.getTime() / 1000;
                                            //start = start.toString().replace('.', '_');
                                            //end = end.toString().replace('.', '_');
                                            updateChart(start, end);
                                        }
                                        else {
                                            start = new Date(cDtStart.get_selectedDate());
                                            end = new Date(cDtEnd.get_selectedDate());

                                            start = start.getTime() / 1000;
                                            end = end.getTime() / 1000;
                                            updateChart(start, end);
                                        }
                                    }
                                }
                                //]]>

                                /* END EXTERNAL SOURCE */

                                /* BEGIN EXTERNAL SOURCE */

                                //<![CDATA[

                                function btnUpdateChart_Clicked(sender, args) {
                                    var cDtStart = $find("<%=radDateTimePickerStart.ClientID %>");
                                    var cDtEnd = $find("<%=radDateTimePickerEnd.ClientID %>");
                                    if (cDtStart.get_selectedDate() == null || cDtEnd.get_selectedDate() == null) {
                                        alert("Chưa nhập ngày!");
                                        return false;
                                    }
                                    start = new Date(cDtStart.get_selectedDate());
                                    end = new Date(cDtEnd.get_selectedDate());

                                    start = start.getTime() / 1000;
                                    end = end.getTime() / 1000;
                                    updateChart(start, end);

                                    //updateChart(toOADate(new Date(cDtStart.get_selectedDate())).toString().replace('.', '_'), toOADate(new Date(cDtEnd.get_selectedDate())).toString().replace('.', '_'));
                                    return false;
                                }

                                function btnClearChart_Clicked(sender, args) {
                                    while (chart.graphs.length != 0) {
                                        chart.removeGraph(chart.graphs[0]);
                                    }
                                    colors = [];
                                    mreds = [];
                                    mblues = [];
                                    channels = [];
                                    chartData = [];
                                    chart.dataProvider = chartData;
                                    chart.validateData();
                                    chart.validateNow();
                                    return false;
                                }

                                /* END EXTERNAL SOURCE */

                                /* BEGIN EXTERNAL SOURCE */

                                //<![CDATA[
                                function btnUpdateChartMinMax_Clicked(sender, args) {
                                    // alert("aa");
                                    var cDtStart = $find("<%=radDateTimePicker5.ClientID %>");
                                    var cDtEnd = $find("<%=radDateTimePicker6.ClientID %>");
                                    if (cDtStart.get_selectedDate() == null || cDtEnd.get_selectedDate() == null) {
                                        alert("Chưa nhập ngày!");

                                        return false;
                                    }
                                    updateChartMinMax(toOADate(new Date(cDtStart.get_selectedDate())).toString().replace('.', '_'), toOADate(new Date(cDtEnd.get_selectedDate())).toString().replace('.', '_'));
                                    return false;
                                    //]]>
                                }

                                /* END EXTERNAL SOURCE */

                                /* BEGIN EXTERNAL SOURCE */



                                /* END EXTERNAL SOURCE */

                                /* BEGIN EXTERNAL SOURCE */


                                function radTreeViewSite_NodeClicked(sender, args) {
                                    //Add JavaScript handler code here
                                    var node = args.get_node();
                                    zoom = 12;
                                    map.setZoom(zoom);
                                    openWin(node.get_value());
                                    node.toggle();
                                    var loggerid = node.get_category();
                                    var location = node.get_text();
                                    if (loggerid != null) {
                                        funtionShowInfo(node.get_value(), loggerid, location);
                                    }
                                }

                                var isClickIconSearch = false;
                                var isClickIconSetting = false;

                                function customPositionIcon() {
                                    $("#tab_menu_2").addClass("cls-display-none");
                                    $("#tab_menu_1").removeClass("cls-display-none");
                                    if (isClickIconSearch) {
                                        $("#icon_collap_rightmenu").addClass("width-search-icon");
                                        $("#icon_collap_rightmenu").removeClass("custom-width-search-icon");
                                        isClickIconSearch = false;
                                    } else {
                                        $("#icon_collap_rightmenu").addClass("custom-width-search-icon");
                                        $("#icon_collap_rightmenu").removeClass("width-search-icon");
                                        isClickIconSearch = true;
                                    }
                                    //isDisableCluster = false;
                                    //window_init();
                                }
                                var isCollapMenu = true;
                                function CollapRadTreeView() {
                                    var treeViewSiteMap = $find("<%= radTreeViewSite.ClientID %>");
                                    var nodes = treeViewSiteMap.get_allNodes();
                                    if (isCollapMenu) {
                                        $("#iconCollap").addClass("cls-display-none");
                                        $("#iconExpan").removeClass("cls-display-none");
                                        for (var i = 0; i < nodes.length; i++) {
                                            if (nodes[i].get_nodes() != null) {
                                                nodes[i].expand();
                                                isCollapMenu = false;
                                            }
                                        }
                                    } else {
                                        $("#iconExpan").addClass("cls-display-none");
                                        $("#iconCollap").removeClass("cls-display-none");
                                        for (var i = 0; i < nodes.length; i++) {
                                            if (nodes[i].get_nodes() != null) {
                                                nodes[i].collapse();
                                                isCollapMenu = true
                                            }
                                        }
                                    }

                                }

                                function searchTree(textSearch) {
                                    var treeViewSiteMap = $find("<%= radTreeViewSite.ClientID %>");
                                    var nodes = treeViewSiteMap.get_allNodes();
                                    $("#NoResultFound").addClass("cls-display-none");

                                    for (var i = 0; i < treeViewSiteMap.get_nodes().get_count(); i++) {
                                        var nodeGroupSite = treeViewSiteMap.get_nodes().getNode(i);
                                        nodeGroupSite.set_visible(true);
                                        for (var j = 0; j < nodeGroupSite.get_nodes().get_count(); j++) {
                                            var nodeSite = nodeGroupSite.get_nodes().getNode(j);
                                            nodeSite.set_visible(true);
                                            for (var k = 0; k < nodeSite.get_nodes().get_count(); k++) {
                                                nodeChannel = nodeSite.get_nodes().getNode(k);
                                                nodeChannel.set_visible(true);
                                            }
                                        }
                                    }

                                    if (textSearch == "") {
                                        $("#iconExpan").addClass("cls-display-none");
                                        $("#iconCollap").removeClass("cls-display-none");
                                        for (var i = 0; i < nodes.length; i++) {
                                            nodes[i].collapse();
                                            isCollapMenu = true
                                        }
                                    } else {
                                        var noResult = 0;
                                        for (var i = 0; i < treeViewSiteMap.get_nodes().get_count(); i++) {
                                            var hasSiteResult = false;
                                            var nodeGroupSite = treeViewSiteMap.get_nodes().getNode(i);
                                            for (var j = 0; j < nodeGroupSite.get_nodes().get_count(); j++) {
                                                var hasChannelResult = false;
                                                var nodeSite = nodeGroupSite.get_nodes().getNode(j);
                                                if (nodeSite.get_nodes().get_count() > 0) {
                                                    for (var k = 0; k < nodeSite.get_nodes().get_count(); k++) {
                                                        nodeChannel = nodeSite.get_nodes().getNode(k);
                                                        if (nodeChannel.get_text().toLowerCase().normalize("NFD").replace(/[\u0300-\u036f]/g, "").replace(/đ/g, "d").replace(/Đ/g, "D")
                                                            .includes(textSearch.toLowerCase().normalize("NFD").replace(/[\u0300-\u036f]/g, "").replace(/đ/g, "d").replace(/Đ/g, "D"))) {
                                                            nodeSite.expand();
                                                            $("#iconExpan").removeClass("cls-display-none");
                                                            $("#iconCollap").addClass("cls-display-none");
                                                            hasChannelResult = true;
                                                        } else {
                                                            //nodeChannel hide
                                                            nodeChannel.set_visible(false);
                                                        }
                                                    }
                                                }
                                                if (nodeSite.get_text().toLowerCase().normalize("NFD").replace(/[\u0300-\u036f]/g, "").replace(/đ/g, "d").replace(/Đ/g, "D")
                                                    .includes(textSearch.toLowerCase().normalize("NFD").replace(/[\u0300-\u036f]/g, "").replace(/đ/g, "d").replace(/Đ/g, "D"))) {
                                                    nodeGroupSite.expand();
                                                    $("#iconExpan").removeClass("cls-display-none");
                                                    $("#iconCollap").addClass("cls-display-none");
                                                    hasSiteResult = true;
                                                    if (!hasChannelResult) {
                                                        if (nodeSite.get_nodes().get_count() > 0) {
                                                            for (var k = 0; k < nodeSite.get_nodes().get_count(); k++) {
                                                                nodeChannel = nodeSite.get_nodes().getNode(k);
                                                                nodeChannel.set_visible(true);
                                                            }
                                                        }
                                                        nodeSite.collapse();
                                                    }
                                                } else {
                                                    if (!hasChannelResult) {
                                                        //nodeSite hide
                                                        nodeSite.set_visible(false);
                                                    } else {
                                                        hasSiteResult = true;
                                                        nodeGroupSite.expand();
                                                    }
                                                }
                                            }
                                            if (!nodeGroupSite.get_text().toLowerCase().normalize("NFD").replace(/[\u0300-\u036f]/g, "").replace(/đ/g, "d").replace(/Đ/g, "D")
                                                .includes(textSearch.toLowerCase().normalize("NFD").replace(/[\u0300-\u036f]/g, "").replace(/đ/g, "d").replace(/Đ/g, "D"))) {
                                                if (!hasSiteResult) {
                                                    //nodeGroupSite hide
                                                    nodeGroupSite.set_visible(false);
                                                    noResult++;
                                                }
                                            } else {
                                                if (!hasSiteResult) {
                                                    for (var j = 0; j < nodeGroupSite.get_nodes().get_count(); j++) {
                                                        var nodeSite = nodeGroupSite.get_nodes().getNode(j);
                                                        nodeSite.set_visible(true);
                                                        for (var k = 0; k < nodeSite.get_nodes().get_count(); k++) {
                                                            nodeChannel = nodeSite.get_nodes().getNode(k);
                                                            nodeChannel.set_visible(true);
                                                        }
                                                    }
                                                    nodeGroupSite.collapse();
                                                }
                                            }
                                        }
                                        if (noResult == treeViewSiteMap.get_nodes().get_count()) {
                                            $("#NoResultFound").removeClass("cls-display-none");
                                        }
                                    }
                                }

                                //$('#cbkGroupLogger').click(function () {
                                //    if ($(this).is(':checked')) {
                                //        isDisableCluster = true;
                                //        omarkers = [];
                                //        markers = [];
                                //        window_init();
                                //    } else {

                                //        isDisableCluster = false;
                                //        omarkers = [];
                                //        markers = [];
                                //        window_init();
                                //    }
                                //    updateMap();
                                //});

                                //cbkShowInfo
                                $('#cbkShowInfo').click(function () {
                                    if ($(this).is(':checked')) {
                                        isShowInfoHtml = true;
                                        for (var i = 0; i < markers.length; i++) {
                                            markers[i].setVisible(true);
                                        }
                                    } else {
                                        isShowInfoHtml = false;
                                        for (var i = 0; i < markers.length; i++) {
                                            markers[i].setVisible(false);
                                        }

                                    }
                                });

                                //set show marker in map
                                $('#cbkbinhthuong').click(function () {
                                    if ($(this).is(':checked')) {
                                        statusImage_nor = true;
                                    } else {
                                        statusImage_nor = false;
                                    }
                                    //omarkers = [];
                                    //markers = [];
                                    //window_init();
                                    updateMap();
                                });

                                $('#cbkbaotre').click(function () {
                                    if ($(this).is(':checked')) {
                                        statusImage_press = true;
                                    } else {
                                        statusImage_press = false;
                                    }
                                    //omarkers = [];
                                    //markers = [];
                                    //window_init();
                                    updateMap();
                                });
                                $('#cbkvuotnguong').click(function () {
                                    if ($(this).is(':checked')) {
                                        statusImage_delay = true;
                                    } else {
                                        statusImage_delay = false;
                                    }
                                    //omarkers = [];
                                    //markers = [];
                                    //window_init();
                                    updateMap();
                                });
                                $('#cbkkhongapluc').click(function () {
                                    if ($(this).is(':checked')) {
                                        statusImage_previous = true;
                                    } else {
                                        statusImage_previous = false;
                                    }
                                    //omarkers = [];
                                    //markers = [];
                                    //window_init();
                                    updateMap();
                                });


                                $('#cbkShowTableDetal').click(function () {
                                    if ($(this).is(':checked')) {
                                        statusShowAll = true;
                                        statusRemoveAlLL = false;
                                        statusRemoveApLuc = false;
                                        statusRemoveLuuLuong = false;
                                        $("#cbkRemoveLuuLuong").prop("checked", false);
                                        $("#cbkRemoveApluc").prop("checked", false);
                                        $("#cbkRemoveApLL").prop("checked", false);
                                        updateMap();
                                    }
                                });

                                $('#cbkRemoveApLL').click(function () {
                                    if ($(this).is(':checked')) {
                                        statusShowAll = false;
                                        statusRemoveAlLL = true;
                                        statusRemoveApLuc = false;
                                        statusRemoveLuuLuong = false;
                                        $("#cbkRemoveLuuLuong").prop("checked", false);
                                        $("#cbkRemoveApluc").prop("checked", false);
                                        $("#cbkShowTableDetal").prop("checked", false);
                                        updateMap();
                                    }
                                });
                                $('#cbkRemoveApluc').click(function () {
                                    if ($(this).is(':checked')) {
                                        statusShowAll = false;
                                        statusRemoveAlLL = false;
                                        statusRemoveApLuc = true;
                                        statusRemoveLuuLuong = false;
                                        $("#cbkRemoveLuuLuong").prop("checked", false);
                                        $("#cbkRemoveApLL").prop("checked", false);
                                        $("#cbkShowTableDetal").prop("checked", false);
                                        updateMap();
                                    }
                                });
                                $('#cbkRemoveLuuLuong').click(function () {
                                    if ($(this).is(':checked')) {
                                        statusShowAll = false;
                                        statusRemoveAlLL = false;
                                        statusRemoveApLuc = false;
                                        statusRemoveLuuLuong = true;
                                        $("#cbkRemoveApluc").prop("checked", false);
                                        $("#cbkRemoveApLL").prop("checked", false);
                                        $("#cbkShowTableDetal").prop("checked", false);
                                        updateMap();
                                    }
                                });


                                //end set show marker in map

                                function customPosStting() {
                                    $("#tab_menu_1").addClass("cls-display-none");
                                    $("#tab_menu_2").removeClass("cls-display-none");
                                    $("#tab_menu_3").addClass("cls-display-none");
                                    $("#tab_menu_4").addClass("cls-display-none");
                                    if (isClickIconSetting) {
                                        $("#icon_collap_setting_menu").addClass("width-setting-icon");
                                        $("#icon_collap_setting_menu").removeClass("custom-width-setting-icon");
                                        isClickIconSetting = false;
                                    } else {
                                        $("#icon_collap_setting_menu").addClass("custom-width-setting-icon");
                                        $("#icon_collap_setting_menu").removeClass("width-setting-icon");
                                        isClickIconSetting = true;
                                    }
                                }

                                function customFilter() {
                                    $("#tab_menu_1").addClass("cls-display-none");
                                    $("#tab_menu_2").addClass("cls-display-none");
                                    $("#tab_menu_3").removeClass("cls-display-none");
                                    $("#tab_menu_4").addClass("cls-display-none");
                                    if ($("#icon_collap_filter_menu").hasClass('active')) {
                                        $("#icon_collap_filter_menu").removeClass('active');
                                    }
                                    else {
                                        $("#icon_collap_filter_menu").addClass('active');
                                    }
                                }

                                function customLayer() {
                                    $("#tab_menu_1").addClass("cls-display-none");
                                    $("#tab_menu_2").addClass("cls-display-none");
                                    $("#tab_menu_3").addClass("cls-display-none");
                                    $("#tab_menu_4").removeClass("cls-display-none");
                                    if ($("#icon_collap_layer_menu").hasClass('active')) {
                                        $("#icon_collap_layer_menu").removeClass('active');
                                    }
                                    else {
                                        $("#icon_collap_layer_menu").addClass('active');
                                    }
                                }



                                /* END EXTERNAL SOURCE */

                                /* BEGIN EXTERNAL SOURCE */

                                var url;
                                var hostname = window.location.origin;
                                if (hostname.indexOf("localhost") < 0)
                                    hostname = hostname + "/VivaServices/";
                                else
                                    hostname = "http://localhost:57880";

                                //var urlGetSites = hostname + '/api/GetSites';
                                var urlGetSitesByUid = hostname + '/api/getsitebyuid/?uid=';
                                var urlGetChannels = hostname + '/api/getchannelbylogger/?loggerid=';
                                var urlGetChannelData = hostname + '/api/GetChannelDataChart/?channelid=';
                                var urlGetMultipleChannelsData = hostname + '/api/getmultipledata/?listChannelId=';
                                var urlGetDailyComplexData = hostname + '/api/GetDailyComplexData/';
                                var urlGetSiteInfo = hostname + '/api/GetSiteInfo/';
                                var urlGetGroupChannelbyLogger = hostname + '/api/getgroupchannelbylogger/?loggerid=';
                                var urlGetChannelbyGroup = hostname + '/api/GetChannelByGroupChannel/?loggerid=';
                                var urlGetChannelDataDaily = hostname + '/api/GetChannelDataDaily/?siteid=';
                                var urlGetGroupChannel = hostname + '/api/GetGroupChannel/';
                                var urlUpdateGroupChannel = hostname + '/api/UpdateGroupChannel/';
                                var urlGetValeAlarm = hostname + '/api/GetValueAlarm/?uid=';
                                var urlConfirmAlarm = hostname + '/api/ConfirmAlarm/';
                                var urlGetDisplayGroups = hostname + '/api/GetDisplayGroup';
                                var urlGetSiteByDisplayGroup = hostname + '/api/GetSitesByDisplayGroup/?displaygroup=';

                                let kml_area;
                                let kml_level1;
                                let kml_level2_PVC;
                                let kml_level2_HDPE;
                                let kml_level2_DICL;
                                let kml_level2_uPVC;
                                let kml_areafile = "https://novas-online.vn/dawaco/waterNetwork/kml/vungcn_60.kml";
                                let kml_level1file = "https://novas-online.vn/dawaco/waterNetwork/kml/CAP1_T5.kml";
                                let kml_level2_PVCfile = "https://novas-online.vn/dawaco/waterNetwork/kml/cap2_PVCST.kml";
                                let kml_level2_HDPEfile = "https://novas-online.vn/dawaco/waterNetwork/kml/cap2_HDPE.kml";
                                let kml_level2_DICLfile = "https://novas-online.vn/dawaco/waterNetwork/kml/cap2_DICL.kml";
                                let kml_level2_uPVCfile = "https://novas-online.vn/dawaco/waterNetwork/kml/cap2_uPVC.kml";


                                //var urlMRed = 'http://i748.photobucket.com/albums/xx123/bttrung1988/mRed_zpscf7a64f6.png';
                                var urlMRed = ' ~/App_Themes/red.png';
                                var urlMGreen = 'http://i748.photobucket.com/albums/xx123/bttrung1988/mGreen_zpsf28ed33c.png';
                                var urlMYellow = 'http://i748.photobucket.com/albums/xx123/bttrung1988/mYellow_zps26e7a5c5.png';
                                var urlMOrange = 'http://i748.photobucket.com/albums/xx123/bttrung1988/mOrange_zpsacadba43.png';
                                var map;
                                var markers = [];
                                var omarkers = [];
                                var infowindow = new google.maps.InfoWindow({
                                    content: ''
                                });

                                var infoHtml;
                                var dInfoHtml;
                                var labelHtml;
                                var dLabelHtml;
                                var dLabelPressHtml;
                                var dLabelDisplayHtml;
                                var index;
                                var strDate;
                                var val;
                                var parsedDate;
                                var jsDate;

                                var reds = ['orange', 'deeppink', 'darkviolet', 'brown', 'magenta'];
                                var blues = ['green', 'cyan', 'darkblue', 'limegreen', 'teal'];
                                var mreds = [];
                                var mblues = [];

                                var image_nor = {
                                    url: '../../App_Themes/green.png',
                                    //url:'#',
                                    size: new google.maps.Size(20, 20),
                                    origin: new google.maps.Point(0, 0),
                                    //anchor: new google.maps.Point(-6, 45)
                                };

                                var image_err_low_press = {
                                    url: '../../App_Themes/red.png',
                                    //url:'#',
                                    size: new google.maps.Size(20, 20),
                                    origin: new google.maps.Point(0, 0),
                                    //anchor: new google.maps.Point(-75, 30)
                                };

                                var image_err_sig_delay = {
                                    url: '../../App_Themes/oranges.png',
                                    //url:'#',
                                    size: new google.maps.Size(20, 20),
                                    origin: new google.maps.Point(0, 0),
                                    //anchor: new google.maps.Point(-6, 45)
                                };

                                var image_err_previous = {
                                    url: '../../App_Themes/yellow.png',
                                    //url:'#',
                                    size: new google.maps.Size(20, 20),
                                    origin: new google.maps.Point(0, 0),
                                    //anchor: new google.maps.Point(-6, 45)
                                };
                                var locations = [];


                                var chart;
                                var end;
                                var start;
                                var channels = [];
                                var chartData = [];
                                var sites = [];
                                var valueAxisPress;
                                var valueAxisFlow;
                                var colorRed = [];
                                var colorBlue = [];
                                var img = image_nor;
                                var colors = [];
                                var markerCluster;
                                var countCheck = [];
                                var chartWidth = 0;
                                var chartHeight = 0;

                                var isDisableCluster = true;
                                var isShowInfoHtml = true;

                                var statusShowAll = true;
                                var statusRemoveAlLL = false;
                                var statusRemoveApLuc = false;
                                var statusRemoveLuuLuong = false;


                                var statusImage_nor = true;
                                var statusImage_press = true;
                                var statusImage_delay = true;
                                var statusImage_previous = true;
                                var strListGroup = [];

                                function getQueryStrings() {
                                    var assoc = {};
                                    var decode = function (s) { return decodeURIComponent(s.replace(/\+/g, " ")); };
                                    var queryString = location.search.substring(1);
                                    var keyValues = queryString.split('&');

                                    for (var i in keyValues) {
                                        var key = keyValues[i].split('=');
                                        if (key.length > 1) {
                                            assoc[decode(key[0])] = decode(key[1]);
                                        }
                                    }

                                    return assoc;
                                }

                                function window_init() {
                                    //MAP
                                    var qs = getQueryStrings();
                                    var uid = qs["uid"];

                                    zoom = 12;
                                    center = new google.maps.LatLng(10.7611111, 106.675);
                                    var myOptions = {
                                        zoom: zoom,
                                        center: center,
                                        mapTypeId: google.maps.MapTypeId.ROADMAP,
                                        streetViewControl: true,
                                        fullscreenControl: false
                                    };
                                    map = new google.maps.Map(document.getElementById("map_canvas"), myOptions);

                                    //var url = 'https://trungangis.capnuoctrungan.vn/arcgis/rest/services/mangluoi/mapserver';
                                    //var url = 'http://113.161.76.112:6080/arcgis/rest/services/KHAWASSCOMapService/MapServer';
                                   // var cpc = new gmaps.ags.CopyrightControl(map);
                                   // var dynamap = new gmaps.ags.MapOverlay(url, {});
                                   // dynamap.setMap(map);

                                    //TREEVIEW & MAP CONTENT
                                    var treeViewSite = $find("<%= radTreeViewSite.ClientID %>");
                                    var countSite = 0;
                                    var siteHasNotChannel = 0;
                                    url = urlGetSitesByUid + uid;
                                    $.getJSON(url, function (ds) {
                                        var displayGroup;
                                        $.each(ds, function (i, s) {

                                            //TREEVIEW SITE NODE
                                            sites.push(s);
                                            var gpNode = treeViewSite.findNodeByText(s.DisplayGroup);
                                            if (gpNode == 'undefined' || gpNode == null) {
                                                var gNode = new Telerik.Web.UI.RadTreeNode();
                                                gNode.set_text(s.DisplayGroup);
                                                gNode.set_allowDrag(false);
                                                gNode.set_allowDrop(false);
                                                //gNode.expand();--nghiavt for collape at loading time
                                                treeViewSite.get_nodes().add(gNode);

                                            }

                                            var sNode = new Telerik.Web.UI.RadTreeNode();
                                            sNode.set_text(s.Location);
                                            sNode.set_value(s.SiteId);
                                            sNode.set_category(s.LoggerId);
                                            sNode.set_allowDrag(false);
                                            sNode.set_allowDrop(false);

                                            var gpNode = treeViewSite.findNodeByText(s.DisplayGroup);
                                            gpNode.get_nodes().add(sNode);
                                            if (s.LoggerId != '') url = urlGetChannels + s.LoggerId;
                                            else url = urlGetChannels + 'nothing';
                                            $.getJSON(url, function (dc) {

                                                labelHtml = "<table cellspacing='0' cellpadding='0'  onclick=\"funtionShowInfo('" + s.SiteId + "','" + s.LoggerId + "', '" + s.Location + "')\"  class='custom-table-marker'><tr ><td colspan='6' class='custom-border-bottom'><span>" + s.SiteId + "</span></td></tr>";
                                                infoHtml = '<span style="font-weight:bold">Vị trí: ' + s.Location + '</span>'
                                                    + '<br/><span>Logger Id: ' + s.LoggerId + '</span>'
                                                    + '<span>, Index: ';
                                                index = 0;
                                                dLabelHtml = '';
                                                dLabelPressHtml = '';
                                                dLabelDisplayHtml = '';
                                                dInfoHtml = '';
                                                var hasChannel = false;
                                                var alreadyPressureDisplay = false;
                                                var displayByGroupChannel = 0;
                                                $.each(dc, function (j, c) {
                                                    if (c.ChannelId != null) {
                                                        hasChannel = true;
                                                        //ICON
                                                        switch (c.Status) {
                                                            case 1:
                                                                img = image_nor;
                                                                break;
                                                            case 2:
                                                                img = image_err_low_press;
                                                                break;
                                                            case 3:
                                                                img = image_err_sig_delay;
                                                                break;
                                                            case 4:
                                                                img = image_err_previous;
                                                                break;
                                                            default:
                                                                img = image_nor;
                                                                break;
                                                        }

                                                        //TREEVIEW CHANNEL NODE
                                                        var cNode = new Telerik.Web.UI.RadTreeNode();
                                                        cNode.set_text(c.ChannelName);
                                                        cNode.set_value(c.ChannelId + '|' + s.Location + '|' + c.ChannelName + '|' + c.Unit);
                                                        cNode.set_allowDrag(true);
                                                        cNode.set_allowDrop(true);
                                                        var spNode = treeViewSite.findNodeByText(s.Location);
                                                        spNode.get_nodes().add(cNode);
                                                        //MAP INFOWINDOW CONTENT
                                                        if (c.LastIndex != null && c.LastIndex != 'undefined') {
                                                            index -= c.LastIndex;
                                                        }
                                                        if (c.Timestamp != null && c.Timestamp != 'undefined') {
                                                            parsedDate = new Date(convertDateFromApi(c.Timestamp));
                                                            jsDate = new Date(parsedDate);
                                                            strDate = jsDate.getDate() + "/" + (jsDate.getMonth() + 1) + "/" + jsDate.getFullYear() + " " + jsDate.getHours() + ":" + jsDate.getMinutes();
                                                        }
                                                        else {
                                                            strDate = 'NO DATA';
                                                        }
                                                        if (c.Val != null && c.Val != 'undefined') {
                                                            val = c.Val;
                                                        }
                                                        else {
                                                            val = 'NO DATA';
                                                        }

                                                        dInfoHtml += "<tr><td> " + c.ChannelName + "</td>"
                                                            + '<td style="text-align:right;color:red">' + val + "</td>"
                                                            + '<td style="color:red">' + c.Unit + "</td>"
                                                            + "<td>" + strDate + "</td>"
                                                            + `<td><a href="#"  style="color: #30a0c1" onclick="openChart('${c.ChannelId}','${s.Location} | ${c.ChannelName}','${c.Unit}');"> <i class="fa fa-bar-chart" aria-hidden="true"></i> </a></td></tr>`

                                                        //MAP LABEL CONTENT
                                                        var htmlImg = "";
                                                        if (c.Status1 == true) {
                                                            htmlImg += '<img alt="" border="0" src="' + urlMGreen + '"></img>';
                                                        }
                                                        if (c.Status2 == true) {
                                                            htmlImg += '<img alt="" border="0" src="' + urlMRed + '"></img>';
                                                        }
                                                        if (c.Status3 == true) {
                                                            htmlImg += '<img alt="" border="0" src="' + urlMOrange + '"></img>';
                                                        }
                                                        if (c.Status4 == true) {
                                                            htmlImg += '<img alt="" border="0" src="' + urlMYellow + '"></img>';
                                                        }
                                                        if (c.GroupChannelStatus) {
                                                            if (c.Press1 == true || c.Press2 == true) {
                                                                if (!alreadyPressureDisplay && strDate != 'NO DATA') {
                                                                    dLabelPressHtml = '<tr ><td colspan="6" style=" text-align: center;   background-color: white; padding-top: 3px; padding-bottom: 3px"><span>' + strDate + '</span></td></tr>';
                                                                    alreadyPressureDisplay = true;
                                                                }
                                                            }
                                                            if (c.DisplayLabel) {
                                                                dLabelDisplayHtml += '<tr style="background-color:white"><td colspan="4"  style="text-align:left; padding-right: 5px"><span>' + c.ChannelName + ' </span></td><td></td><td colspan="2" style="text-align:left;color:red"><span>' + val + ' (' + c.Unit + ')' + '</span></td></tr>';
                                                            }
                                                            displayByGroupChannel = 1;
                                                        }
                                                    }
                                                    else {
                                                        siteHasNotChannel++;
                                                    }
                                                });
                                                if (hasChannel) {
                                                    countSite++;
                                                    dLabelHtml += dLabelPressHtml;
                                                    dLabelHtml += dLabelDisplayHtml;
                                                    dLabelHtml += '</table>'
                                                    labelHtml += dLabelHtml;
                                                    infoHtml += '<span style="font-weight:bold;color:blue; padding-right: 10px">' + Math.round(Math.abs(index)) + '</span></span>';
                                                    infoHtml += '<br/><table cellpadding="5" cellspacing="5"  style="margin-top:5px; padding-right: 10px" class="table table-striped dataTable" >';
                                                    infoHtml += dInfoHtml;
                                                    //infoHtml += "<tr><td style=' background-color: white;border-top: unset;'><a href=\"#\"  style='color: #30a0c1;' onclick=\"openChartMinMaxPre('" + s.LoggerId + "');\">MinMax Pressure Day</a></td></tr>"
                                                    infoHtml += '</table>';
                                                    //LOAD TO MAP
                                                    var latlng = new google.maps.LatLng(s.Latitude, s.Longitude);
                                                    var anchor = new google.maps.Point(s.LabelAnchorX = null ? 40 : s.LabelAnchorX, s.LabelAnchorY = null ? 0 : s.LabelAnchorY);
                                                    var omarker = new google.maps.Marker({
                                                        id: 'om_' + s.SiteId,
                                                        position: latlng,
                                                        map: map,
                                                        icon: img,
                                                        html: infoHtml
                                                    });
                                                    var marker = new MarkerWithLabel({
                                                        id: 'm_' + s.SiteId,
                                                        position: latlng,
                                                        map: map,
                                                        icon: img,
                                                        draggable: false,
                                                        raiseOnDrag: true,
                                                        labelContent: labelHtml,
                                                        labelAnchor: anchor,
                                                        labelClass: "labels", // the CSS class for the label
                                                        labelInBackground: false,
                                                        html: infoHtml,
                                                        visible: false
                                                    });


                                                    google.maps.event.addListener(marker, 'click', function () {
                                                        infowindow.setContent(this.html);
                                                        infowindow.open(map, this);
                                                        funtionShowInfo(s.SiteId, s.LoggerId, s.Location);
                                                    });
                                                    google.maps.event.addListener(omarker, 'click', function () {
                                                        infowindow.setContent(this.html);
                                                        infowindow.open(map, this);
                                                    });

                                                    if (!isShowInfoHtml) {
                                                        marker.setVisible(false);
                                                    }
                                                    //green
                                                    if (marker.icon.url == image_nor.url) {
                                                        if (statusImage_nor && displayByGroupChannel == 1) {
                                                            markers.push(marker);
                                                            omarkers.push(omarker);
                                                        } else {
                                                            marker.setVisible(false);
                                                            omarker.setVisible(false);
                                                        }
                                                    } else {
                                                        //ress
                                                        if (marker.icon.url == image_err_low_press.url) {
                                                            if (statusImage_press && displayByGroupChannel == 1) {
                                                                markers.push(marker);
                                                                omarkers.push(omarker);
                                                            } else {
                                                                marker.setVisible(false);
                                                                omarker.setVisible(false);
                                                            }
                                                        } else {
                                                            //yellow
                                                            if (marker.icon.url == image_err_previous.url) {
                                                                if (statusImage_previous && displayByGroupChannel == 1) {
                                                                    markers.push(marker);
                                                                    omarkers.push(omarker);
                                                                } else {
                                                                    marker.setVisible(false);
                                                                    omarker.setVisible(false);
                                                                }
                                                            } else {
                                                                //delay
                                                                if (statusImage_delay && displayByGroupChannel == 1) {
                                                                    markers.push(marker);
                                                                   omarkers.push(omarker);
                                                                } else {
                                                                    marker.setVisible(false);
                                                                    omarker.setVisible(false);
                                                                }
                                                            }
                                                        }
                                                    }
                                                    //if (isDisableCluster) {
                                                    //    markerCluster = new MarkerClusterer(map, markers,
                                                    //        { imagePath: '../../_imgs/iconCluster/m' }
                                                    //    );
                                                    //    markerCluster = new MarkerClusterer(map, omarkers,
                                                    //        { imagePath: '../../_imgs/iconCluster/m' }
                                                    //    );
                                                    //    const styles = markerCluster.getStyles();
                                                    //    for (let i = 0; i < styles.length; i++) {
                                                    //        styles[i].textColor = "white";
                                                    //        styles[i].textSize = 15;
                                                    //    }
                                                    //}

                                                }
                                                hasChannel = false;
                                            });
                                        })
                                    });


                                    //treeViewSite.commitChanges();
                                    //CONTEXT MENU
                                    var contextMenuOptions = {};
                                    contextMenuOptions.classNames = { menu: 'context_menu', menuSeparator: 'context_menu_separator' };
                                    var menuItems = [];
                                    menuItems.push({ className: 'context_menu_item', eventName: 'hide_click', label: 'Hide labels' });
                                    menuItems.push({ className: 'context_menu_item', eventName: 'show_click', label: 'Show labels' });
                                    contextMenuOptions.menuItems = menuItems;
                                    var contextMenu = new ContextMenu(map, contextMenuOptions);

                                    google.maps.event.addListener(map, 'rightclick', function (mouseEvent) {
                                        contextMenu.show(mouseEvent.latLng);
                                    });
                                    google.maps.event.addListener(contextMenu, 'menu_item_selected', function (latLng, eventName) {
                                        switch (eventName) {
                                            case 'hide_click':
                                                for (var i = 0; i < markers.length; i++) {
                                                    markers[i].setVisible(false);
                                                }
                                                break;
                                            case 'show_click':
                                                for (var i = 0; i < markers.length; i++) {
                                                    markers[i].setVisible(true);
                                                }
                                                break;
                                        }
                                    });

                                    FillDiaplayGroups();
                                }

                                document.getElementById('ckArea').addEventListener('change', function (e) {
                                    if (this.checked == true) {
                                        showAreaLayerKML();
                                    }
                                    else {
                                        hideAreaLayerKML();
                                    }
                                })

                                document.getElementById('ckPipeLV1').addEventListener('change', function (e) {
                                    if (this.checked == true) {
                                        showPipeLV1();
                                    }
                                    else {
                                        hidePipeLV1();
                                    }

                                })

                                document.getElementById('ckPipeLineLV2').addEventListener('change', function (e) {

                                    if (this.checked == true) {
                                        showPipeLV2();
                                    }
                                    else {
                                        hidePipeLV2();
                                    }
                                })

                                function showPipeLV2() {
                                    kml_level2_PVC = new google.maps.KmlLayer({
                                        url: kml_level2_PVCfile,
                                        map: map,
                                    });


                                    kml_level2_HDPE = new google.maps.KmlLayer({
                                        url: kml_level2_HDPEfile,
                                        map: map,
                                    });

                                    kml_level2_DICL = new google.maps.KmlLayer({
                                        url: kml_level2_DICLfile,
                                        map: map,
                                    });


                                    kml_level2_uPVC = new google.maps.KmlLayer({
                                        url: kml_level2_uPVCfile,
                                        map: map,
                                    });

                                }

                                function hidePipeLV2() {
                                    kml_level2_PVC.setMap(null);
                                    kml_level2_HDPE.setMap(null);
                                    kml_level2_DICL.setMap(null);
                                    kml_level2_uPVC.setMap(null);
                                }

                                function showPipeLV1() {
                                    kml_level1 = new google.maps.KmlLayer({
                                        url: kml_level1file,
                                        map: map,
                                    })
                                }

                                function hidePipeLV1() {
                                    kml_level1.setMap(null);
                                }

                                function showAreaLayerKML() {
                                    kml_area = new google.maps.KmlLayer({
                                        url: kml_areafile,
                                        map: map,
                                    });
                                }

                                function hideAreaLayerKML() {
                                    kml_area.setMap(null);
                                }



                                function FillDiaplayGroups() {
                                    let filterSitesArea = document.getElementById('filterSitesArea');

                                    filterSitesArea.innerHTML = "";

                                    let content = "";

                                    $.getJSON({ url: urlGetDisplayGroups }, function (dc) {

                                        for (let dg of dc) {
                                            if (dg.trim() != "" && dg != null) {
                                                content += `<div class="checkbox">
                                                <div>
                                                    <input type="checkbox" class="custom-checkbox" checked="checked" value="${dg.trim()}" id="${dg.trim()}" onclick="checkBox_Click(this)">
                                                    <label style="color: white !important; font-weight: 500"> ${dg.trim()}</label>
                                                </div>
                                                </div>`
                                            }
                                        }

                                        filterSitesArea.innerHTML = content;

                                    })
                                }

                                function checkBox_Click(e) {
                                    $.getJSON({ url: urlGetSiteByDisplayGroup + e.value }, function (dc) {

                                        for (let item of dc) {
                                            if (e.checked == true) {
                                                for (let marker of markers) {
                                                    if (marker.id.split('_')[1] == item.SiteID) {
                                                        marker.setVisible(true);
                                                        break;
                                                    }
                                                }
                                                for (let omarker of omarkers) {
                                                    if (omarker.id.split('_')[1] == item.SiteID) {
                                                        omarker.setVisible(true);
                                                        break;
                                                    }
                                                }
                                            }
                                            else {
                                                for (let marker of markers) {
                                                    if (marker.id.split('_')[1] == item.SiteID) {
                                                        marker.setVisible(false);
                                                        break;
                                                    }
                                                }
                                                for (let omarker of omarkers) {
                                                    if (omarker.id.split('_')[1] == item.SiteID) {
                                                        omarker.setVisible(false);
                                                        break;
                                                    }
                                                }
                                            }
                                        }



                                    })

                                }


                                function updateMap() {
                                    $.each(sites, function (i, s) {
                                        if (s.LoggerId != '') url = urlGetChannels + s.LoggerId;
                                        else url = urlGetChannels + 'nothing';
                                        $.getJSON(url, function (dc) {

                                            infoHtml = '<span style="font-weight:bold">Vị trí: ' + s.Location + '</span>'
                                                + '</br><span>Logger Id: ' + s.LoggerId + '</span>'
                                                + ' <span>, Index: ';
                                            index = 0;
                                            labelHtml = '';
                                            dLabelHtml = '';
                                            dLabelPressHtml = '';
                                            dLabelDisplayHtml = '';
                                            dInfoHtml = '';
                                            var hasChannel = false;
                                            var alreadyPressureDisplay = false;
                                            var displayByGroupChannel = 0;
                                            $.each(dc, function (j, c) {
                                                if (c.ChannelId != null) {
                                                    hasChannel = true;
                                                    //ICON
                                                    switch (c.Status) {
                                                        case 1:
                                                            img = image_nor;
                                                            break;
                                                        case 2:
                                                            img = image_err_low_press;
                                                            break;
                                                        case 3:
                                                            img = image_err_sig_delay;
                                                            break;
                                                        case 4:
                                                            img = image_err_previous;
                                                            break;
                                                        default:
                                                            img = image_nor;
                                                            break;
                                                    }
                                                    //MAP INFOWINDOW CONTENT
                                                    if (c.LastIndex != null && c.LastIndex != 'undefined') {
                                                        index -= c.LastIndex;
                                                    }
                                                    if (c.Timestamp != null && c.Timestamp != 'undefined') {
                                                        parsedDate = new Date(convertDateFromApi(c.Timestamp));
                                                        jsDate = new Date(parsedDate);
                                                        strDate = jsDate.getDate() + "/" + (jsDate.getMonth() + 1) + "/" + jsDate.getFullYear() + " " + jsDate.getHours() + ":" + jsDate.getMinutes();
                                                    }
                                                    else {
                                                        strDate = 'NO DATA';
                                                    }
                                                    if (c.Val != null && c.Val != 'undefined') {
                                                        val = c.Val;
                                                    }
                                                    else {
                                                        val = 'NO DATA';
                                                    }
                                                    dInfoHtml += "<tr><td> " + c.ChannelName + "</td>"
                                                        + '<td style="text-align:right;color:red">' + val + "</td>"
                                                        + '<td style="color:red">' + c.Unit + "</td>"
                                                        + "<td>" + strDate + "</td>"
                                                        + `<td><a href="#"  style="color: #30a0c1" onclick="openChart('${c.ChannelId}','${s.Location} | ${c.ChannelName}','${c.Unit}');"> <i class="fa fa-bar-chart" aria-hidden="true"></i> </a></td></tr>`
                                                    //MAP LABEL CONTENT
                                                    var htmlImg = "";
                                                    if (c.Status1 == true) {
                                                        htmlImg += '<img alt="" border="0" src="' + urlMGreen + '"></img>';
                                                    }
                                                    if (c.Status2 == true) {
                                                        htmlImg += '<img alt="" border="0" src="' + urlMRed + '"></img>';
                                                    }
                                                    if (c.Status3 == true) {
                                                        htmlImg += '<img alt="" border="0" src="' + urlMOrange + '"></img>';
                                                    }
                                                    if (c.Status4 == true) {
                                                        htmlImg += '<img alt="" border="0" src="' + urlMYellow + '"></img>';
                                                    }
                                                    if (c.GroupChannelStatus) {
                                                        if (c.Press1 == true || c.Press2 == true) {
                                                            if (!alreadyPressureDisplay && strDate != 'NO DATA') {
                                                                dLabelPressHtml = '<tr ><td colspan="6" style=" text-align: center;   background-color: white; padding-top: 3px; padding-bottom: 3px"><span>' + strDate + '</span></td></tr>';
                                                                alreadyPressureDisplay = true;
                                                            }
                                                        }
                                                        if (c.DisplayLabel) {
                                                            if (statusShowAll) {
                                                                dLabelDisplayHtml += '<tr style="background-color:white">';
                                                                dLabelDisplayHtml += '<td style="text-align:left; padding-right: 5px"><span>' + c.ChannelName + ' </span></td>';
                                                                dLabelDisplayHtml += '<td style="text-align:left;"><span style="color:red"> ' + val + ' (' + c.Unit + ')' + '</span></td>';
                                                                dLabelDisplayHtml += '</tr>';
                                                            }
                                                            if (statusRemoveAlLL) {
                                                                if (c.Press1 == true || c.Press2 == true || c.Flow1 == true || c.Flow2 == true) {
                                                                    dLabelDisplayHtml += '<tr style="background-color:white">';
                                                                    dLabelDisplayHtml += '<td style="text-align:left; padding-right: 5px"><span>' + c.ChannelName + ' </span></td>';
                                                                    dLabelDisplayHtml += '<td style="text-align:left;"><span style="color:red"> ' + val + ' (' + c.Unit + ')' + '</span></td>';
                                                                    dLabelDisplayHtml += '</tr>';
                                                                }
                                                            }
                                                            if (statusRemoveApLuc) {
                                                                if (c.Press1 == true || c.Press2 == true) {
                                                                    dLabelDisplayHtml += '<tr style="background-color:white">';
                                                                    dLabelDisplayHtml += '<td style="text-align:left; padding-right: 5px"><span>' + c.ChannelName + ' </span></td>';
                                                                    dLabelDisplayHtml += '<td style="text-align:left;"><span style="color:red"> ' + val + ' (' + c.Unit + ')' + '</span></td>';
                                                                    dLabelDisplayHtml += '</tr>';
                                                                }
                                                            }
                                                            if (statusRemoveLuuLuong) {
                                                                if (c.Flow1 == true || c.Flow2 == true) {
                                                                    dLabelDisplayHtml += '<tr style="background-color:white">';
                                                                    dLabelDisplayHtml += '<td style="text-align:left; padding-right: 5px"><span>' + c.ChannelName + ' </span></td>';
                                                                    dLabelDisplayHtml += '<td style="text-align:left;"><span style="color:red"> ' + val + ' (' + c.Unit + ')' + '</span></td>';
                                                                    dLabelDisplayHtml += '</tr>';
                                                                }
                                                            }
                                                        }
                                                        displayByGroupChannel = 1;
                                                    }
                                                }
                                            });
                                            if (hasChannel) {
                                                if (statusShowAll) {
                                                    labelHtml = "<table cellspacing='0' cellpadding='0'  onclick=\"funtionShowInfo('" + s.SiteId + "','" + s.LoggerId + "', '" + s.Location + "')\" class='custom-table-marker'>";
                                                    labelHtml += "<tr><td colspan='6' class='custom-border-bottom'><span>" + s.SiteId + "</span></td></tr>";
                                                    dLabelHtml += dLabelPressHtml;
                                                    dLabelHtml += dLabelDisplayHtml;
                                                    dLabelHtml += '</table>'
                                                    labelHtml += dLabelHtml;
                                                } else if (dLabelDisplayHtml != '') {
                                                    labelHtml = "<table cellspacing='0' cellpadding='0'  onclick=\"funtionShowInfo('" + s.SiteId + "','" + s.LoggerId + "', '" + s.Location + "')\" class='custom-table-marker'>";
                                                    dLabelHtml += dLabelDisplayHtml;
                                                    dLabelHtml += '</table>'
                                                    labelHtml += dLabelHtml;
                                                }

                                                infoHtml += '<span style="font-weight:bold;color:blue;">' + Math.round(Math.abs(index)) + '</span></span>';
                                                infoHtml += '<br/><table cellpadding="5" cellspacing="5" style="margin-top:5px; padding-right: 10px" class="table table-striped dataTable" >';
                                                infoHtml += dInfoHtml;
                                                //infoHtml += "<tr><td><a href=\"#\" style='color: #30a0c1' onclick=\"openChartMinMaxPre('" + s.LoggerId + "');\">MinMax Pressure Day</a></td></tr>";
                                                infoHtml += '</table>';
                                                //LOAD TO MAP
                                                loop_m:
                                                for (var k = 0; k < markers.length; k++) {
                                                    if (markers[k].id == ('m_' + s.SiteId)) {

                                                        markers[k].setIcon(img);
                                                        markers[k].html = infoHtml;
                                                        markers[k].labelContent = labelHtml;
                                                        markers[k].label.setContent();
                                                        break loop_m;
                                                    }
                                                }
                                                loop_om:
                                                for (var k = 0; k < omarkers.length; k++) {
                                                    if (omarkers[k].id == ('om_' + s.SiteId)) {
                                                        omarkers[k].setIcon(img);
                                                        break loop_om;
                                                    }
                                                }

                                                //for (var k = 0; k < markers.length; k++) {
                                                //    if (markers[k].id == ('m_' + s.SiteId)) {
                                                //        if (markers[k].icon.url == image_nor.url) {
                                                //            if (statusImage_nor && displayByGroupChannel == 1) {
                                                //                markers[k].setVisible(true);
                                                //                omarkers[k].setVisible(true);
                                                //            } else {
                                                //                markers[k].setVisible(false);
                                                //                omarkers[k].setVisible(false);
                                                //                siteHasNotChannel++
                                                //            }
                                                //        }
                                                //        if (markers[k].icon.url == image_err_low_press.url) {
                                                //            if (statusImage_press && displayByGroupChannel == 1) {
                                                //                markers[k].setVisible(true);
                                                //                omarkers[k].setVisible(true);
                                                //            } else {
                                                //                markers[k].setVisible(false);
                                                //                omarkers[k].setVisible(false);
                                                //                siteHasNotChannel++
                                                //            }
                                                //        }
                                                //        if (markers[k].icon.url == image_err_previous.url) {
                                                //            if (statusImage_previous && displayByGroupChannel == 1) {
                                                //                markers[k].setVisible(true);
                                                //                omarkers[k].setVisible(true);
                                                //            } else {
                                                //                markers[k].setVisible(false);
                                                //                omarkers[k].setVisible(false);
                                                //                siteHasNotChannel++
                                                //            }
                                                //        }
                                                //        if (markers[k].icon.url == image_err_sig_delay.url) {
                                                //            if (statusImage_delay && displayByGroupChannel == 1) {
                                                //                markers[k].setVisible(true);
                                                //                omarkers[k].setVisible(true);
                                                //            } else {
                                                //                markers[k].setVisible(false);
                                                //                omarkers[k].setVisible(false);
                                                //                siteHasNotChannel++
                                                //            }
                                                //        }
                                                //    }
                                                //}
                                            }
                                            hasChannel = false;
                                        });
                                    });
                                }

                                function funtionShowInfo(siteId, loggerId, location) {
                                    countCheck = [];
                                    //$("#bottom_popup_esri").removeClass("cls-display-none");
                                    //$("#bottom_popup_siteinfo").addClass("cls-display-none");
                                    $("#body_table_bottom_eri").empty();
                                    document.getElementById("header_table_bottom_eri").innerText = location;
                                    document.getElementById("ContentPlaceHolder1_hdpLoggerIdPopup").value = loggerId;
                                    var url = urlGetChannels + loggerId;
                                    $.getJSON(url, function (d) {
                                        $("#body_table_bottom_eri").empty();
                                        $.each(d, function (i, val) {
                                            //add value table
                                            if (val.Timestamp != null && val.Timestamp != 'undefined') {
                                                var parsedDate = new Date(parseInt(val.Timestamp.substr(6)));
                                                var jsDate = new Date(parsedDate);
                                                var strDate = jsDate.getDate() + "/" + (jsDate.getMonth() + 1) + "/" + jsDate.getFullYear() + " " + jsDate.getHours() + ":" + jsDate.getMinutes();
                                                $("#body_table_bottom_eri").append("<tr><td>" + val.ChannelName + "</td><td>" + strDate + "</td><td>" + val.Value + " " + val.Unit + "</td></tr>");
                                            }
                                        });

                                    });

                                    //setting modal 
                                    $("#body_modal_setting").empty();
                                    var url = urlGetGroupChannelbyLogger + loggerId;
                                    var groupDefault = [];
                                    var channels = [];
                                    var timeInit = [];
                                    $.getJSON(url, function (ds) {
                                        console.log(ds)
                                        $.each(ds, function (i, s) {
                                            if (s.Groupchannel == "") {
                                                $("#body_modal_setting").append("<div class='checkbox checkbox-info'><label><input id='ckGroup_" + i + "' type='checkbox'  class='custom-checkbox' value='NULL'>NULL</label> </div>");
                                                countCheck.push({ name: 'NULL' });
                                            } else {
                                                $("#body_modal_setting").append("<div class='checkbox checkbox-info'><label><input id='ckGroup_" + i + "' type='checkbox' class='custom-checkbox' value='" + s.Groupchannel + "'>" + s.Groupchannel + "</label> </div>");
                                                countCheck.push({ name: s.Groupchannel });
                                            }
                                            $("#ckGroup_0").prop("checked", true);
                                            if (i == 0) {
                                                groupDefault.push({ id: s.Groupchannel });
                                                var parsedDate = new Date(convertDateFromApi(s.Timestamp));
                                                var jsDate = new Date(parsedDate);
                                                timeInit.push({ timeStamp: jsDate });
                                            }
                                        });

                                        //draw chart data width

                                        var groupname = groupDefault[0].id;
                                        if (groupname == "") {
                                            groupname = "NULL";
                                        }
                                        // unnecessary
                                        /*var url = urlGetChannelbyGroup + loggerId + "&groupchannel=" + groupname;
                                       $.getJSON(url, function (ds) {
                                           $.each(ds, function (i, s) {
                                               channels.push({ id: s.ChannelId, namePath: s.ChannelName })
                                           });

                                           DrawChartDataWidth(channels, timeInit[0].timeStamp);
                                       }); */
                                        //end draw chart data width
                                        /*
                                        var timeStamp = timeInit[0].timeStamp;
                                        siteId = siteId.replace(' ', "_");
                                        DrawChartColumn(siteId, timeStamp); */
                                    });


                                    //end setting modal
                                }

                                function convertDateFromApi(date) {
                                    let stringSplit = date.toString().split("-");
                                    let year = parseInt(stringSplit[0]);
                                    let month = parseInt(stringSplit[1]) < 10 ? `0${parseInt(stringSplit[1])}` : parseInt(stringSplit[1]);
                                    let stringSplit2 = stringSplit[2].split("T");
                                    let day = parseInt(stringSplit2[0]) < 10 ? `0${parseInt(stringSplit2[0])}` : parseInt(stringSplit2[0]);
                                    let stringSplit3 = stringSplit2[1].split(":");
                                    let hours = parseInt(stringSplit3[0]) < 10 ? `0${parseInt(stringSplit3[0])}` : parseInt(stringSplit3[0]);
                                    let minutes = parseInt(stringSplit3[1]) < 10 ? `0${parseInt(stringSplit3[1])}` : parseInt(stringSplit3[1]);
                                    let seconds = parseInt(stringSplit3[2]) < 10 ? `0${parseInt(stringSplit3[2])}` : parseInt(stringSplit3[2]);

                                    let result = `${year}/${month}/${day} ${hours}:${minutes}:${seconds}`;

                                    return result;
                                }

                                function addDays(date, days) {
                                    var result = new Date(date);
                                    result.setDate(result.getDate() + days);
                                    return result;
                                }

                                function DrawChartDataWidth(channels, timeStamp) {
                                    var str_lstChannelid = "";
                                    for (var i = 0; i < channels.length; i++) {
                                        if (i < channels.length - 1) {
                                            str_lstChannelid += channels[i].id + "|";
                                        } else {
                                            str_lstChannelid += channels[i].id;
                                        }
                                    }
                                    var startDate = timeStamp;
                                    var endDate = addDays(startDate, -7);
                                    startDate = toOADate(startDate).toString().replace('.', '_');
                                    endDate = toOADate(endDate).toString().replace('.', '_');
                                    var url = urlGetMultipleChannelsData + str_lstChannelid + "&start=" + endDate + "&end=" + startDate;
                                    //var url = urlGetMultipleChannelsData + str_lstChannelid + "/43838_44976851852/43839_44976851852";

                                    $.getJSON(url, function (d) {
                                        chartData = [];
                                        $.each(d.GetMultipleChannelsDataResult, function (i, val) {
                                            if (val.Timestamp != null && val.Timestamp != 'undefined') {
                                                var parsedDate = new Date(parseInt(val.Timestamp.substr(6)));
                                                var jsDate = new Date(parsedDate);
                                                chartData.push({
                                                    TimeStamp: jsDate
                                                });

                                                for (var j = 0; j < channels.length; j++) {
                                                    if (val.Values[j] != null && val.Values[j] != 'undefined')
                                                        chartData[i]["'" + channels[j].id + "'"] = val.Values[j];
                                                }

                                            }

                                        });
                                        if (chartData.length > 0) {
                                            $("#chart_data_with").removeClass("cls-display-none");
                                            $("#legend_chart_data_with").removeClass("cls-display-none");
                                            $("#img_error_chart_with").addClass("cls-display-none");
                                            //SERIAL CHART
                                            chart = new AmCharts.AmSerialChart();
                                            chart.pathToImages = "../../js/amcharts/images/";
                                            chart.dataProvider = chartData;
                                            chart.categoryField = "TimeStamp";
                                            chart.balloon.bulletSize = 5;
                                            //chart.logo.height = -15000;
                                            //ZOOM
                                            //chart.addListener("dataUpdated", zoomChart);
                                            //AXES
                                            //X
                                            var categoryAxis = chart.categoryAxis;
                                            categoryAxis.parseDates = true;
                                            categoryAxis.minPeriod = "mm";
                                            categoryAxis.dashLength = 1;
                                            categoryAxis.minorGridEnabled = true;
                                            categoryAxis.twoLineMode = true;
                                            categoryAxis.dateFormats = [{
                                                period: 'fff',
                                                format: 'JJ:NN:SS'
                                            }, {
                                                period: 'ss',
                                                format: 'JJ:NN:SS'
                                            }, {
                                                period: 'mm',
                                                format: 'JJ:NN'
                                            }, {
                                                period: 'hh',
                                                format: 'JJ:NN'
                                            }, {
                                                period: 'DD',
                                                format: 'DD'
                                            }, {
                                                period: 'WW',
                                                format: 'DD'
                                            }, {
                                                period: 'MM',
                                                format: 'YYYY'
                                            }, {
                                                period: 'YYYY',
                                                format: 'YYYY'
                                            }];

                                            categoryAxis.axisColor = "#DADADA";
                                            categoryAxis.gridAlpha = 0.15;
                                            //AXE
                                            //Y1
                                            valueAxisPress = new AmCharts.ValueAxis();
                                            valueAxisPress.axisColor = 'red';
                                            valueAxisPress.axisThickness = 1;
                                            //valueAxisPress.title = 'm';
                                            valueAxisPress.titleColor = 'red';
                                            chart.addValueAxis(valueAxisPress);
                                            //Y2 
                                            valueAxisFlow = new AmCharts.ValueAxis();
                                            valueAxisFlow.axisColor = 'blue';
                                            valueAxisFlow.axisThickness = 1;
                                            valueAxisFlow.position = 'right';
                                            valueAxisFlow.title = 'm3/h';
                                            valueAxisFlow.titleColor = 'blue';
                                            chart.addValueAxis(valueAxisFlow);
                                            //GRAPH COLOR
                                            var type;
                                            var color;
                                            switch ("m3") {
                                                case "m":
                                                    type = valueAxisPress;
                                                    color = '#ff0000';
                                                    colors.push(color);
                                                    break;
                                                case "m3/h":
                                                    type = valueAxisFlow;
                                                    color = '#0000ff';
                                                    colors.push(color);
                                                    break;
                                                default:
                                                    type = valueAxisPress;
                                                    break;
                                            }
                                            for (var i = 0; i < channels.length; i++) {
                                                // GRAPH
                                                var graph = new AmCharts.AmGraph();
                                                graph.id = channels[i].id;
                                                graph.valueAxis = type;
                                                graph.title = channels[i].namePath;
                                                graph.valueField = "'" + channels[i].id + "'";
                                                graph.bullet = "round";
                                                graph.bulletBorderColor = "#FFFFFF";
                                                graph.bulletBorderThickness = 2;
                                                graph.bulletBorderAlpha = 1;
                                                graph.bulletSize = 8;
                                                graph.lineThickness = 1;
                                                graph.lineColor = color;
                                                graph.hideBulletsCount = 50;
                                                chart.addGraph(graph);
                                                // CURSOR
                                            }

                                            var chartCursor = new AmCharts.ChartCursor();
                                            chartCursor.categoryBalloonDateFormat = "MMM DD, YYYY JJ:NN";
                                            //chartCursor.categoryBalloonDateFormat = "JJ:NN";
                                            chart.addChartCursor(chartCursor);
                                            // LEGEND
                                            var legend = new AmCharts.AmLegend();
                                            legend.marginLeft = 110;
                                            legend.useGraphSettings = true;
                                            chart.addLegend(legend, "legend_chart_data_with");

                                            //MOUSE
                                            chart.mouseWheelZoomEnabled = true;
                                            chart.mouseWheelScrollEnabled = true;
                                            chart.creditsPosition = "bottom-right";
                                            //EXPORT
                                            chart.amExport = {
                                                top: 21,
                                                right: 21,
                                                buttonColor: '#EFEFEF',
                                                buttonRollOverColor: '#DDDDDD',
                                                exportPNG: true,
                                                exportJPG: true,
                                                exportPDF: true,
                                                exportSVG: true
                                            }
                                            // WRITE
                                            chart.write("chart_data_with");
                                        } else {
                                            $("#chart_data_with").addClass("cls-display-none");
                                            $("#legend_chart_data_with").addClass("cls-display-none");
                                            $("#img_error_chart_with").removeClass("cls-display-none");
                                        }
                                    });
                                }

                                function DrawChartColumn(siteId, timeStamp) {
                                    var startDate = timeStamp;
                                    var endDate = addDays(startDate, -7);
                                    console.log(startDate);
                                    console.log(endDate)
                                    startDate = startDate.getTime() / 1000;
                                    endDate = endDate.getTime() / 1000;
                                    var url = urlGetChannelDataDaily + siteId + "&start=" + endDate + "&end=" + startDate;
                                    $.getJSON(url, function (d) {
                                        chartData = [];
                                        $.each(d, function (i, val) {
                                            if (val.Timestamp != null && val.Timestamp != 'undefined') {
                                                var parsedDate = new Date(convertDateFromApi(val.Timestamp));
                                                var jsDate = new Date(parsedDate);
                                                chartData.push({
                                                    TimeStamp: jsDate.toLocaleDateString()
                                                });

                                                if (val.Value != null && val.Value != 'undefined') {
                                                    chartData[i]["value"] = val.Value;
                                                }
                                            }

                                        });
                                        if (chartData.length > 0) {
                                            $("#chart_data_with_column").removeClass("cls-display-none");
                                            $("#img_error_chart_with_column").addClass("cls-display-none");
                                            // Themes begin
                                            am4core.useTheme(am4themes_animated);

                                            var chart = am4core.create("chart_data_with_column", am4charts.XYChart);
                                            // Add data
                                            chart.data = chartData;
                                            chart.logo.height = -15000;
                                            chart.exporting.menu = new am4core.ExportMenu();
                                            var categoryAxis = chart.xAxes.push(new am4charts.CategoryAxis());
                                            categoryAxis.dataFields.category = "TimeStamp";
                                            categoryAxis.renderer.grid.template.location = 0;
                                            categoryAxis.renderer.minGridDistance = 30;

                                            categoryAxis.renderer.labels.template.adapter.add("dy", function (dy, target) {
                                                if (target.dataItem && target.dataItem.index & 2 == 2) {
                                                    return dy + 25;
                                                }
                                                return dy;
                                            });

                                            var valueAxis = chart.yAxes.push(new am4charts.ValueAxis());

                                            // Create series
                                            var series = chart.series.push(new am4charts.ColumnSeries());
                                            series.dataFields.valueY = "value";
                                            series.dataFields.categoryX = "TimeStamp";
                                            series.name = "value";
                                            series.columns.template.tooltipText = "{categoryX}: [bold]{valueY}[/]";
                                            series.columns.template.fillOpacity = .8;

                                            var columnTemplate = series.columns.template;
                                            columnTemplate.strokeWidth = 2;
                                            columnTemplate.strokeOpacity = 1;

                                            $("#gradient-id-69").addClass("cls-display-none");
                                            $("#filter-id-66").addClass("cls-display-none");

                                        } else {
                                            $("#chart_data_with_column").addClass("cls-display-none");
                                            $("#img_error_chart_with_column").removeClass("cls-display-none");
                                        }
                                    });
                                }


                                function CloseModal() {
                                    var loggerId = document.getElementById("ContentPlaceHolder1_hdpLoggerIdPopup").value;
                                    var str_groupChannel = "";
                                    var channels = [];
                                    for (var i = 0; i < countCheck.length; i++) {
                                        var ckb = "#ckGroup_" + i;
                                        if ($(ckb).is(":checked")) {
                                            if (str_groupChannel == "") {
                                                str_groupChannel += $(ckb).val();
                                            } else {
                                                str_groupChannel += "|" + $(ckb).val();
                                            }
                                        }
                                    }
                                    if (str_groupChannel != "") {
                                        $("#chart_data_with").removeClass("cls-display-none");
                                        $("#legend_chart_data_with").removeClass("cls-display-none");
                                        $("#img_error_chart_with").addClass("cls-display-none");
                                        var url = urlGetChannelbyGroup + loggerId + "&groupchannel=" + str_groupChannel;
                                        $.getJSON(url, function (ds) {
                                            var timeStamp = [];
                                            $.each(ds, function (i, s) {
                                                channels.push({ id: s.ChannelId, namePath: s.ChannelName })
                                                var parsedDate = new Date(convertDateFromApi(s.TimeStamp));
                                                var jsDate = new Date(parsedDate);
                                                timeStamp.push({ timeStamp: jsDate })
                                            });
                                            // unnecessary
                                            //DrawChartDataWidth(channels, timeStamp[0].timeStamp);
                                        });
                                    } else {
                                        $("#chart_data_with").addClass("cls-display-none");
                                        $("#legend_chart_data_with").addClass("cls-display-none");
                                        $("#img_error_chart_with").removeClass("cls-display-none");
                                    }
                                }

                                function closeBottomPopup() {
                                    //$("#bottom_popup_esri").addClass("cls-display-none");
                                }


                                function showPopupInfoSite() {
                                    //$("#bottom_popup_siteinfo").removeClass("cls-display-none");
                                    var loggerId = document.getElementById("ContentPlaceHolder1_hdpLoggerIdPopup").value;

                                    var url = urlGetSiteInfo + loggerId;
                                    $.getJSON(url, function (d) {
                                        var result = d.GetSiteInfoResult;
                                        document.getElementById("txtAliasName").innerText = result.SiteAliasName;
                                        document.getElementById("txtSiteId").innerText = result.SiteId;
                                        document.getElementById("txtDescription").innerText = result.Description;
                                        document.getElementById("txtPieSize").innerText = result.PipeSize;
                                        document.getElementById("txtPhone").innerText = result.TelephoneNumber;
                                        document.getElementById("txtDmain").innerText = result.DMA_In;
                                        document.getElementById("txtDmaout").innerText = result.DMA_Out;
                                        document.getElementById("txtStarthour").innerText = result.StartHour;
                                        document.getElementById("txtDelay").innerText = result.TimeDelayAlarm;
                                    });
                                }

                                function UpdateStGroupChannel(name, index) {
                                    var status = 1;
                                    var flag = document.getElementById("ckbGroupChannel_" + index + "").checked;
                                    if (flag) {
                                        status = 1;
                                    } else {
                                        status = 0;
                                    }

                                    var url = urlUpdateGroupChannel + name + "/" + status;
                                    $.getJSON(url, function (d) { });
                                    //omarkers = [];
                                    //markers = [];
                                    //window_init();
                                    updateMap();
                                }

                                function closePopupSiteInfo() {
                                    //$("#bottom_popup_siteinfo").addClass("cls-display-none");
                                }
                                function resetZoom() {
                                    zoom = 9;
                                    center = new google.maps.LatLng(20.909666, 103.586557);
                                    map.setZoom(zoom);
                                    map.setCenter(center);
                                }

                                function openWin(id) {
                                    loop_ow:
                                    for (var i = 0; i < markers.length; i++) {
                                        if (markers[i].id == ('m_' + id)) {
                                            map.panTo(markers[i].getPosition());
                                            google.maps.event.trigger(markers[i], 'click');
                                            break loop_ow;
                                        }
                                    }

                                };

                                function dtToString(d) {
                                    var u = d.getFullYear() + "|" + (d.getMonth() + 1) + "|" + d.getDate() + "|" + d.getHours() + "|" + d.getMinutes() + "|" + d.getSeconds();
                                    return u;
                                }

                                var toOADate = (function () {
                                    var epoch = new Date(1899, 11, 30);
                                    var msPerDay = 8.64e7;

                                    return function (d) {
                                        var v = -1 * (epoch - d) / msPerDay;

                                        // Deal with dates prior to 1899-12-30 00:00:00
                                        var dec = v - Math.floor(v);

                                        if (v < 0 && dec) {
                                            v = Math.floor(v) - dec;
                                        }

                                        return v;
                                    }
                                }());


                                var fromOADate = (function () {
                                    var epoch = new Date(1899, 11, 30);
                                    var msPerDay = 8.64e7;

                                    return function (n) {
                                        // Deal with -ve values
                                        var dec = n - Math.floor(n);

                                        if (n < 0 && dec) {
                                            n = Math.floor(n) - dec;
                                        }

                                        return new Date(n * msPerDay + +epoch);
                                    }
                                }());

                                /////////////////////chart minmax Press///////////////////////////////////////////////////////////////////////////////////
                                function openChartMinMaxPre(loggerId) {
                                    var window = $find("<%= radminmaxPress.ClientID %>");
                                    window.setSize(chartWidth, chartHeight);
                                    window.show();
                                    window.center();
                                    end = new Date();
                                    start = new Date();
                                    start = new Date(start.setDate(start.getDate() - 30));
                                    var cDtStart = $find("<%=radDateTimePicker5.ClientID %>");
                                    var cDtEnd = $find("<%=radDateTimePicker6.ClientID %>");
                                    cDtStart.set_selectedDate(start);
                                    cDtEnd.set_selectedDate(end);
                                    start = toOADate(start);
                                    end = toOADate(end);
                                    start = start.toString().replace('.', '_');
                                    end = end.toString().replace('.', '_');
                                    var channel = { id: loggerId, max: "_max" };
                                    channels = [];
                                    channels.push(channel);
                                    colors = [];
                                    mreds = [];
                                    mblues = [];
                                    drawChartMinMax(channels[0], start, end);


                                };
                                // this method is called when chart is first inited as we listen for "dataUpdated" event
                                function zoomchartMinMax() {
                                    // different zoom methods can be used - zoomToIndexes, zoomToDates, zoomToCategoryValues
                                    chartMinMax.zoomToIndexes(chartDataMinMax.length - chartDataMinMax.length, chartDataMinMax.length - 1); urlGetDailyComplexData
                                }


                                function drawChartMinMax(channel, start, end) {
                                    //alert(channel.sum);

                                    var url = urlGetDailyComplexData + channel.id + "/" + start + "/" + end;
                                    $.getJSON(url, function (d) {
                                        chartDataMinMax = [];
                                        //alert(channel.base);
                                        $.each(d.GetDailyComplexDataResult, function (i, val) {
                                            if (val.Timestamp != null && val.Timestamp != 'undefined') {
                                                var parsedDate = new Date(parseInt(val.TimeStamp.substr(6)));
                                                var jsDate = new Date(parsedDate);
                                                chartDataMinMax.push({
                                                    TimeStamp: jsDate
                                                });
                                                if (val.MinFlowRate != null && val.MinFlowRate != 'undefined') {
                                                    chartDataMinMax[i]["'" + channel.id + "'"] = val.MinPressure;
                                                    chartDataMinMax[i]["'" + channel.max + "'"] = val.MaxPressure;

                                                }
                                            }
                                        });


                                        //SERIAL CHART
                                        chartMinMax = new AmCharts.AmSerialChart();
                                        chartMinMax.pathToImages = "../../js/amcharts/images/";
                                        chartMinMax.dataProvider = chartDataMinMax;
                                        chartMinMax.type = "serial";
                                        chartMinMax.dataTableId = "chart_table_MinMax";
                                        chartMinMax.categoryField = "TimeStamp";
                                        chartMinMax.balloon.bulletSize = 5;
                                        //ZOOM
                                        chartMinMax.addListener("dataUpdated", zoomchartMinMax);
                                        //AXES
                                        //X

                                        var categoryAxis = chartMinMax.categoryAxis;
                                        categoryAxis.parseDates = true;
                                        categoryAxis.minPeriod = "DD";
                                        categoryAxis.dashLength = 1;
                                        categoryAxis.minorGridEnabled = true;
                                        categoryAxis.twoLineMode = true;
                                        categoryAxis.dateFormats = [{
                                            period: 'fff',
                                            format: 'JJ:NN:SS'
                                        }, {
                                            period: 'ss',
                                            format: 'JJ:NN:SS'
                                        }, {
                                            period: 'mm',
                                            format: 'JJ:NN'
                                        }, {
                                            period: 'hh',
                                            format: 'JJ:NN'
                                        }, {
                                            period: 'DD',
                                            format: 'DD'
                                        }, {
                                            period: 'WW',
                                            format: 'DD'
                                        }, {
                                            period: 'MM',
                                            format: 'YYYY'
                                        }, {
                                            period: 'YYYY',
                                            format: 'YYYY'
                                        }];

                                        categoryAxis.axisColor = "#DADADA";
                                        categoryAxis.gridAlpha = 0.15;
                                        //AXE
                                        //Y1
                                        valueAxisSum = new AmCharts.ValueAxis();
                                        valueAxisSum.axisColor = 'blue';
                                        valueAxisSum.axisThickness = 1;
                                        valueAxisSum.title = 'MinMax Pressure';
                                        valueAxisSum.position = 'left';
                                        valueAxisSum.titleColor = 'blue';
                                        chartMinMax.addValueAxis(valueAxisSum);

                                        //GRAPH COLOR


                                        // GRAPH
                                        var graph1 = new AmCharts.AmGraph();
                                        //alert("a");
                                        graph1.id = "MNF";
                                        graph1.valueAxis = valueAxisSum;
                                        graph1.title = "Min Press";
                                        graph1.valueField = "'" + channel.id + "'";
                                        graph1.bullet = "round";
                                        graph1.bulletBorderColor = "#FFFFFF";
                                        // graph.negativeBase = baseLine;
                                        // graph.negativeLineColor = "red";                        
                                        graph1.bulletBorderThickness = 2;
                                        graph1.bulletBorderAlpha = 1;
                                        graph1.bulletSize = 8;
                                        graph1.lineThickness = 1;
                                        graph1.lineColor = "yellow";
                                        graph1.hideBulletsCount = 50;
                                        //graph.balloonText = "[[Timestamp]]<br><b><span style='font-size:12px;'>Value: [[" + channel.id + "]]</span></b>";                      
                                        chartMinMax.addGraph(graph1);

                                        // GRAPH                       
                                        var graph2 = new AmCharts.AmGraph();
                                        //alert("a");
                                        graph2.id = "MNFSUM";
                                        graph2.valueAxis = valueAxisSum;
                                        graph2.title = "Max Press";
                                        graph2.valueField = "'" + channel.max + "'";
                                        graph2.bullet = "round";
                                        graph2.bulletBorderColor = "#FFFFFF";
                                        // graph.negativeBase = 25;
                                        // graph.negativeLineColor = "green";                        
                                        graph2.bulletBorderThickness = 2;
                                        graph2.bulletBorderAlpha = 1;
                                        graph2.bulletSize = 8;
                                        graph2.lineThickness = 1;
                                        graph2.lineColor = "blue";
                                        graph2.hideBulletsCount = 50;
                                        //graph.balloonText = "[[Timestamp]]<br><b><span style='font-size:12px;'>Value: [[" + channel.id + "]]</span></b>";                      
                                        chartMinMax.addGraph(graph2);


                                        //add table

                                        var total = 0;
                                        var min = 100000;
                                        var max = 0;
                                        // get chart data
                                        var data = chartMinMax.dataProvider;
                                        // create a table
                                        var holder = document.getElementById(chartMinMax.dataTableId);
                                        holder.innerHTML = "";
                                        // if (holder.childElementCount == 0) {
                                        var table = document.createElement("table");
                                        holder.appendChild(table);
                                        var tr, td;

                                        // add first row
                                        for (var x = 0; x < chartMinMax.dataProvider.length; x++) {

                                            // first row
                                            if (x == 0) {
                                                tr = document.createElement("tr");
                                                table.appendChild(tr);
                                                td = document.createElement("th");
                                                //td.innerHTML = chartMinMax.categoryAxis.title;
                                                td.innerHTML = "Timestamp";
                                                tr.appendChild(td);
                                                for (var i = 0; i < chartMinMax.graphs.length; i++) {
                                                    td = document.createElement('th');
                                                    td.innerHTML = chartMinMax.graphs[i].title;
                                                    tr.appendChild(td);
                                                }
                                            }

                                            // add rows
                                            tr = document.createElement("tr");
                                            table.appendChild(tr);
                                            td = document.createElement("td");
                                            td.className = "row-title";

                                            // td.innerHTML = chartMinMax.dataProvider[x][chartMinMax.categoryField].toUTCString();
                                            var todayTime = new Date(chartMinMax.dataProvider[x][chartMinMax.categoryField]);
                                            var month = todayTime.getMonth() + 1;
                                            var day = todayTime.getDate();
                                            var year = todayTime.getFullYear();
                                            var dt = day + "/" + month + "/" + year;
                                            // alert(dt + "aaaa");
                                            // var dt = chartMinMax.dataProvider[x][chartMinMax.categoryField].substr(14);
                                            td.innerHTML = dt;
                                            tr.appendChild(td);
                                            var valuetotal;
                                            for (var i = 0; i < chartMinMax.graphs.length; i++) {
                                                td = document.createElement('td');
                                                valuetotal = chartMinMax.dataProvider[x][chartMinMax.graphs[i].valueField];
                                                td.innerHTML = valuetotal;
                                                tr.appendChild(td);
                                                if (valuetotal > max) {
                                                    max = valuetotal;
                                                }
                                                if (valuetotal < min) {
                                                    min = valuetotal;
                                                }
                                                //if (i == 1)
                                                //   {
                                                //    total += chartMinMax.dataProvider[x][chartMinMax.graphs[i].valueField];
                                                //   }
                                            }
                                        }
                                        //document.getElementById("totalMinMax").innerHTML = Math.round(total);
                                        document.getElementById("minPress").innerHTML = min;
                                        document.getElementById("maxPress").innerHTML = max;
                                        // $("#totalflow").load("total");
                                        //  }//end if


                                        // CURSOR
                                        var chartCursor = new AmCharts.ChartCursor();
                                        chartCursor.categoryBalloonDateFormat = "MMM DD, YYYY ";
                                        chartMinMax.addChartCursor(chartCursor);
                                        // SCROLLBAR
                                        var chartScrollbar = new AmCharts.ChartScrollbar();
                                        chartScrollbar.autoGridCount = true;
                                        chartScrollbar.scrollbarHeight = 20;
                                        chartMinMax.addChartScrollbar(chartScrollbar);
                                        // LEGEND
                                        var legend = new AmCharts.AmLegend();
                                        legend.marginLeft = 110;
                                        legend.useGraphSettings = true;
                                        chartMinMax.addLegend(legend);
                                        //MOUSE
                                        chartMinMax.mouseWheelZoomEnabled = true;
                                        chartMinMax.mouseWheelScrollEnabled = true;
                                        chartMinMax.creditsPosition = "bottom-right";
                                        //EXPORT
                                        chartMinMax.amExport = {
                                            top: 21,
                                            right: 21,
                                            buttonColor: '#EFEFEF',
                                            buttonRollOverColor: '#DDDDDD',
                                            exportPNG: true,
                                            exportJPG: true,
                                            exportPDF: true,
                                            exportSVG: true
                                        }
                                        // WRITE
                                        chartMinMax.write("chart_canvas_MinMax");
                                    });
                                }

                                function openChart(channelId, namePath, unit) {
                                    var window = $find("<%= radWindowChart.ClientID %>");
                                    window.setSize(chartWidth, chartHeight);
                                    window.show();
                                    window.center();
                                    end = new Date();
                                    start = new Date();
                                    start = new Date(start.setDate(start.getDate() - 3));
                                    var cDtStart = $find("<%=radDateTimePickerStart.ClientID %>");
                                    var cDtEnd = $find("<%=radDateTimePickerEnd.ClientID %>");
                                    cDtStart.set_selectedDate(start);
                                    cDtEnd.set_selectedDate(end);
                                    //start = toOADate(start);
                                    //end = toOADate(end);
                                    //start = start.toString().replace('.', '_');
                                    //end = end.toString().replace('.', '_');
                                    start = start.getTime() / 1000;
                                    end = end.getTime() / 1000;
                                    var channel = { id: channelId, namePath: namePath, unit: unit };
                                    channels = [];
                                    channels.push(channel);
                                    colors = [];
                                    mreds = [];
                                    mblues = [];
                                    drawChart(channels[0], start, end);

                                };
                                // this method is called when chart is first inited as we listen for "dataUpdated" event
                                function zoomChart() {
                                    // different zoom methods can be used - zoomToIndexes, zoomToDates, zoomToCategoryValues
                                    chart.zoomToIndexes(chartData.length - chartData.length, chartData.length - 1);
                                }

                                // changes cursor mode from pan to select
                                function setPanSelect() {
                                    if (document.getElementById("rb1").checked) {
                                        chartCursor.pan = false;
                                        chartCursor.zoomable = true;
                                    } else {
                                        chartCursor.pan = true;
                                    }
                                    chart.validateNow();
                                }

                                function drawChart(channel, start, end) {
                                    console.log(start)
                                    console.log(end)
                                    console.log(channel)
                                    var url = urlGetChannelData + channel.id + "&start=" + start + "&end=" + end;
                                    console.log(url)
                                    $.getJSON(url, function (d) {
                                        chartData = [];
                                        console.log(d)
                                        $.each(d, function (i, val) {
                                            if (val.Timestamp != null && val.Timestamp != 'undefined') {
                                                var parsedDate = new Date(convertDateFromApi(val.Timestamp));
                                                var jsDate = new Date(parsedDate);
                                                chartData.push({
                                                    Timestamp: jsDate
                                                });
                                                if (val.Value != null && val.Value != 'undefined')
                                                    chartData[i]["'" + channel.id + "'"] = val.Value;
                                            }
                                        });

                                        console.log(chartData)
                                        //SERIAL CHART
                                        chart = new AmCharts.AmSerialChart();
                                        chart.pathToImages = "../../js/amcharts/images/";
                                        chart.dataProvider = chartData;
                                        chart.categoryField = "Timestamp";
                                        chart.balloon.bulletSize = 5;
                                        //ZOOM
                                        chart.addListener("dataUpdated", zoomChart);
                                        //AXES
                                        //X
                                        var categoryAxis = chart.categoryAxis;
                                        categoryAxis.parseDates = true;
                                        categoryAxis.minPeriod = "mm";
                                        categoryAxis.dashLength = 1;
                                        categoryAxis.minorGridEnabled = true;
                                        categoryAxis.twoLineMode = true;
                                        categoryAxis.dateFormats = [{
                                            period: 'fff',
                                            format: 'JJ:NN:SS'
                                        }, {
                                            period: 'ss',
                                            format: 'JJ:NN:SS'
                                        }, {
                                            period: 'mm',
                                            format: 'JJ:NN'
                                        }, {
                                            period: 'hh',
                                            format: 'JJ:NN'
                                        }, {
                                            period: 'DD',
                                            format: 'DD'
                                        }, {
                                            period: 'WW',
                                            format: 'DD'
                                        }, {
                                            period: 'MM',
                                            format: 'YYYY'
                                        }, {
                                            period: 'YYYY',
                                            format: 'YYYY'
                                        }];

                                        categoryAxis.axisColor = "#DADADA";
                                        categoryAxis.gridAlpha = 0.15;
                                        //AXE
                                        //Y1
                                        valueAxisPress = new AmCharts.ValueAxis();
                                        valueAxisPress.axisColor = 'red';
                                        valueAxisPress.axisThickness = 1;
                                        valueAxisPress.title = 'm';
                                        valueAxisPress.titleColor = 'red';
                                        chart.addValueAxis(valueAxisPress);
                                        //Y2 
                                        valueAxisFlow = new AmCharts.ValueAxis();
                                        valueAxisFlow.axisColor = 'blue';
                                        valueAxisFlow.axisThickness = 1;
                                        valueAxisFlow.position = 'right';
                                        valueAxisFlow.title = 'm3/h';
                                        valueAxisFlow.titleColor = 'blue';
                                        chart.addValueAxis(valueAxisFlow);
                                        //GRAPH COLOR
                                        var type;
                                        var color;
                                        switch (channel.unit) {
                                            case "m":
                                                type = valueAxisPress;
                                                color = '#ff0000';
                                                colors.push(color);
                                                break;
                                            case "m3/h":
                                                type = valueAxisFlow;
                                                color = '#0000ff';
                                                colors.push(color);
                                                break;
                                            default:
                                                type = valueAxisPress;
                                                break;
                                        }
                                        // GRAPH
                                        var graph = new AmCharts.AmGraph();
                                        graph.id = channel.namePath;
                                        graph.valueAxis = type;
                                        graph.title = channel.namePath;
                                        graph.valueField = "'" + channel.id + "'";
                                        graph.bullet = "round";
                                        graph.bulletBorderColor = "#FFFFFF";
                                        graph.bulletBorderThickness = 2;
                                        graph.bulletBorderAlpha = 1;
                                        graph.bulletSize = 8;
                                        graph.lineThickness = 1;
                                        graph.lineColor = color;
                                        graph.hideBulletsCount = 50;
                                        //graph.balloonText = "[[Timestamp]]<br><b><span style='font-size:12px;'>Value: [[" + channel.id + "]]</span></b>";
                                        chart.addGraph(graph);
                                        // CURSOR
                                        var chartCursor = new AmCharts.ChartCursor();
                                        chartCursor.categoryBalloonDateFormat = "MMM DD, YYYY JJ:NN";
                                        chart.addChartCursor(chartCursor);
                                        // SCROLLBAR
                                        var chartScrollbar = new AmCharts.ChartScrollbar();
                                        chartScrollbar.autoGridCount = true;
                                        chartScrollbar.scrollbarHeight = 20;
                                        chart.addChartScrollbar(chartScrollbar);
                                        // LEGEND
                                        var legend = new AmCharts.AmLegend();
                                        legend.marginLeft = 110;
                                        legend.useGraphSettings = true;
                                        chart.addLegend(legend);
                                        //MOUSE
                                        chart.mouseWheelZoomEnabled = true;
                                        chart.mouseWheelScrollEnabled = true;
                                        chart.creditsPosition = "bottom-right";
                                        //EXPORT
                                        chart.amExport = {
                                            top: 21,
                                            right: 21,
                                            buttonColor: '#EFEFEF',
                                            buttonRollOverColor: '#DDDDDD',
                                            exportPNG: true,
                                            exportJPG: true,
                                            exportPDF: true,
                                            exportSVG: true
                                        }
                                        // WRITE
                                        chart.write("chart_canvas");
                                    });
                                };

                                ///////////////////////////////////////////////////////////////////////////////////////////////////////////////////              
                                function updateChartMinMax(start, end) {
                                    //alert("a");
                                    var url = urlGetDailyComplexData + channels[0].id + "/" + start + "/" + end;
                                    //var baseLine = channels[0].base;
                                    $.getJSON(url, function (d) {
                                        chartDataMinMax = [];
                                        $.each(d.GetDailyComplexDataResult, function (i, val) {
                                            if (val.Timestamp != null && val.Timestamp != 'undefined') {
                                                var parsedDate = new Date(parseInt(val.TimeStamp.substr(6)));
                                                var jsDate = new Date(parsedDate);
                                                chartDataMinMax.push({
                                                    TimeStamp: jsDate
                                                });
                                                if (val.Output != null && val.Output != 'undefined') {

                                                    chartDataMinMax[i]["'" + channels[0].id + "'"] = val.MinPressure;
                                                    chartDataMinMax[i]["'" + channels[0].max + "'"] = val.MaxPressure;

                                                }
                                            }
                                        });

                                        $.each(channels, function (k, c) {

                                            var m_f = false;
                                            // alert(chart_flow.graphs.length);
                                            for (var i = 0; i < chartMinMax.graphs.length; i++) {

                                                if (chartMinMax.graphs[i].valueField == ("'" + c.id + "'")) {
                                                    // alert(c.id);
                                                    m_f = true;
                                                }
                                            }
                                            if (m_f == false) {

                                                // GRAPH
                                                var graph1 = new AmCharts.AmGraph();
                                                //alert("a");
                                                graph1.id = "MNF";
                                                graph1.valueAxis = valueAxisSum;
                                                graph1.title = "Min Press";
                                                graph1.valueField = "'" + channels[0].id + "'";
                                                graph1.bullet = "round";
                                                graph1.bulletBorderColor = "#FFFFFF";
                                                graph1.bulletBorderThickness = 2;
                                                graph1.bulletBorderAlpha = 1;
                                                graph1.bulletSize = 8;
                                                graph1.lineThickness = 1;
                                                graph1.lineColor = "yellow";
                                                graph1.hideBulletsCount = 50;
                                                //graph.balloonText = "[[Timestamp]]<br><b><span style='font-size:12px;'>Value: [[" + channel.id + "]]</span></b>";                      
                                                chartMinMax.addGraph(graph1);

                                                // GRAPH                       
                                                var graph2 = new AmCharts.AmGraph();
                                                //alert("a");
                                                graph2.id = "MNFSUM";
                                                graph2.valueAxis = valueAxisSum;
                                                graph2.title = "Max Press";
                                                graph2.valueField = "'" + channels[0].max + "'";
                                                graph2.bullet = "round";
                                                graph2.bulletBorderColor = "#FFFFFF";
                                                graph2.bulletBorderThickness = 2;
                                                graph2.bulletBorderAlpha = 1;
                                                graph2.bulletSize = 8;
                                                graph2.lineThickness = 1;
                                                graph2.lineColor = "blue";
                                                graph2.hideBulletsCount = 50;
                                                //graph.balloonText = "[[Timestamp]]<br><b><span style='font-size:12px;'>Value: [[" + channel.id + "]]</span></b>";                      
                                                chartMinMax.addGraph(graph2);


                                            }
                                        });

                                        //SERIAL CHART
                                        chartMinMax.dataTableId = "chart_table_MinMax";
                                        chartMinMax.dataProvider = chartDataMinMax;
                                        chartMinMax.validateData();
                                        chartMinMax.validateNow();

                                        //add table
                                        var total = 0;
                                        var min = 1000000;
                                        var max = 0;
                                        // get chart data
                                        var data = chartMinMax.dataProvider;
                                        // create a table
                                        var holder = document.getElementById(chartMinMax.dataTableId);
                                        holder.innerHTML = "";
                                        // if (holder.childElementCount == 0) {
                                        var table = document.createElement("table");
                                        holder.appendChild(table);
                                        var tr, td;
                                        // add first row
                                        for (var x = 0; x < chartMinMax.dataProvider.length; x++) {
                                            // first row
                                            if (x == 0) {
                                                tr = document.createElement("tr");
                                                table.appendChild(tr);
                                                td = document.createElement("th");
                                                //td.innerHTML = chartMinMax.categoryAxis.title;
                                                td.innerHTML = "Timestamp";
                                                tr.appendChild(td);
                                                for (var i = 0; i < chartMinMax.graphs.length; i++) {
                                                    td = document.createElement('th');
                                                    td.innerHTML = chartMinMax.graphs[i].title;
                                                    tr.appendChild(td);
                                                }
                                            }
                                            // add rows
                                            tr = document.createElement("tr");
                                            table.appendChild(tr);
                                            td = document.createElement("td");
                                            td.className = "row-title";

                                            // td.innerHTML = chartMinMax.dataProvider[x][chartMinMax.categoryField].toUTCString();
                                            var todayTime = new Date(chartMinMax.dataProvider[x][chartMinMax.categoryField]);
                                            var month = todayTime.getMonth() + 1;
                                            var day = todayTime.getDate();
                                            var year = todayTime.getFullYear();
                                            var dt = day + "/" + month + "/" + year;
                                            td.innerHTML = dt;
                                            tr.appendChild(td);
                                            // alert(chartMinMax.graphs.length);
                                            var valuetotal;
                                            for (var i = 0; i < chartMinMax.graphs.length; i++) {
                                                td = document.createElement('td');
                                                td.innerHTML = chartMinMax.dataProvider[x][chartMinMax.graphs[i].valueField];
                                                tr.appendChild(td);
                                                valuetotal = chartMinMax.dataProvider[x][chartMinMax.graphs[i].valueField];
                                                if (valuetotal > max) {
                                                    max = valuetotal;
                                                }
                                                if (valuetotal < min) {
                                                    min = valuetotal;
                                                }
                                                //if (i == 1) {
                                                //    total += chartMinMax.dataProvider[x][chartMinMax.graphs[i].valueField];
                                                //}
                                            }
                                        }
                                        document.getElementById("minPress").innerHTML = min;
                                        document.getElementById("maxPress").innerHTML = max;
                                        // document.getElementById("totalMinMax").innerHTML = Math.round(total);
                                        // $("#totalflow").load("total");
                                        //  }//end if

                                    });
                                };
                                //////////////////////////////////////////////////////////////////////////////////////////////////////////
                                ///////////////////////////////////////////////////////////////////
                                function updateChart(start, end) {
                                    var multipleChannelId = "";
                                    for (var i = 0; i < channels.length; i++) {
                                        if (i != channels.length - 1)
                                            multipleChannelId += channels[i].id + "|";
                                        else multipleChannelId += channels[i].id;
                                    }
                                    var url = urlGetMultipleChannelsData + multipleChannelId + "&start=" + start + "&end=" + end;
                                    //alert(url);
                                    $.getJSON(url, function (d) {
                                        chartData = [];
                                        $.each(d, function (i, val) {
                                            if (val.Timestamp != null && val.Timestamp != 'undefined') {
                                                var parsedDate = new Date(convertDateFromApi(val.Timestamp));
                                                var jsDate = new Date(parsedDate);

                                                chartData.push({
                                                    Timestamp: jsDate
                                                });

                                                for (var j = 0; j < channels.length; j++) {
                                                    if (val.Values[j] != null && val.Values[j] != 'undefined')
                                                        chartData[i]["'" + channels[j].id + "'"] = val.Values[j];
                                                }
                                            }
                                        });

                                        $.each(channels, function (k, c) {
                                            var m_f = false;
                                            for (var i = 0; i < chart.graphs.length; i++) {
                                                if (chart.graphs[i].valueField == ("'" + c.id + "'")) {
                                                    m_f = true;
                                                }
                                            }
                                            if (m_f == false) {
                                                var type;
                                                var color = "";
                                                switch (c.unit) {
                                                    case "m":
                                                        type = valueAxisPress;
                                                        var fr = false;
                                                        for (var i = 0; i < colors.length; i++) {
                                                            if (colors[i] == '#ff0000') fr = true;
                                                        }
                                                        if (fr == true) {
                                                            if (mreds.length == 0) {
                                                                mreds.push(reds[0]);
                                                                color = mreds[0];
                                                            }
                                                            else if (mreds.length != reds.length) {
                                                                mreds.push(reds[mreds.length]);
                                                                color = mreds[mreds.length - 1];
                                                            }
                                                            else {
                                                                color = randomColor();
                                                            }
                                                            //color = randomColor({
                                                            //    luminosity: 'bright',
                                                            //    hue: 'orange'
                                                            //});
                                                        }
                                                        else color = '#ff0000';
                                                        colors.push(color);
                                                        break;
                                                    case "m3/h":
                                                        type = valueAxisFlow;
                                                        var fb = false;
                                                        for (var i = 0; i < colors.length; i++) {
                                                            if (colors[i] == '#0000ff') fb = true;
                                                        }
                                                        if (fb == true) {
                                                            if (mblues.length == 0) {
                                                                mblues.push(blues[0]);
                                                                color = mblues[0];
                                                            }
                                                            else if (mblues.length != blues.length) {
                                                                mblues.push(blues[mblues.length]);
                                                                color = mblues[mblues.length - 1];
                                                            }
                                                            else {
                                                                color = randomColor();
                                                            }
                                                            //color = randomColor({
                                                            //    luminosity: 'bright',
                                                            //    hue: 'purple'
                                                            //});
                                                        }
                                                        else color = '#0000ff';
                                                        colors.push(color);
                                                        break;
                                                    default:
                                                        type = valueAxisPress;

                                                        break;
                                                }
                                                // GRAPH
                                                var graph = new AmCharts.AmGraph();
                                                graph.id = c.namePath;
                                                graph.valueAxis = type;
                                                graph.title = c.namePath;
                                                graph.valueField = "'" + c.id + "'";
                                                graph.bullet = "round";
                                                graph.bulletBorderColor = "#FFFFFF";
                                                graph.bulletBorderThickness = 2;
                                                graph.bulletBorderAlpha = 1;
                                                graph.bulletSize = 8;
                                                graph.lineThickness = 1;
                                                graph.lineColor = color;
                                                graph.hideBulletsCount = 50;
                                                //graph.balloonText = "[[Timestamp]]<br><b><span style='font-size:12px;'>Value: [[" + channel.id + "]]</span></b>";
                                                chart.addGraph(graph);
                                            }
                                        });
                                        chart.dataProvider = chartData;
                                        chart.validateData();
                                        chart.validateNow();

                                    });
                                }
                                window.onload = window_init;

                                setInterval(updateMap, 120000);
                            </script>
                        </telerik:RadScriptBlock>

                    </section>
                    <!-- /.content -->
                </div>
                <!-- /.content-wrapper -->

                <!-- Main Footer -->
                <footer class="main-footer">
                    <!-- To the right -->
                    <div class="pull-right hidden-xs">
                        <a href="#" class="label label-success">Design By TAWACO VIET NAM</a>
                    </div>
                    <!-- Default to the left -->
                    <strong>
                        <asp:Label ID="lbPageTitle" runat="server" Text="Viwater hệ thống SCADA quản lý mạng lưới cấp nước"></asp:Label>
                    </strong>
                </footer>
                <!-- Main Footer -->
            </div>
            <!-- ./wrapper -->

            <!-- REQUIRED JS SCRIPTS -->

            <!-- jQuery 3 -->
            <script src="../../bower_components/jquery/dist/jquery.min.js"></script>
            <!-- Bootstrap 3.3.7 -->
            <script src="../../bower_components/bootstrap/dist/js/bootstrap.min.js"></script>
            <!-- AdminLTE App -->
            <script src="../../bower_components/dist/js/adminlte.min.js"></script>
        </form>







        <%--<script type="text/javascript" src="/js/Pi-solution/vendor.js"></script>--%>
        <script type="text/javascript" src="/js/Pi-solution/app.js"></script>

        <script type="text/javascript"> 


            function pageLoad(sender, args) {
                $(function () {
                    //resize menu + map by screen
                    var screenheight = $(document).height();
                    var screenwidth = $(document).width();
                    var strh = (screenheight - 50);
                    var strw = (screenwidth - 40);
                    chartWidth = (screenwidth - 350);
                    chartHeight = (screenheight - 100);
                    if (/Android|webOS|iPhone|iPad|iPod|BlackBerry|IEMobile|Opera Mini/i.test(navigator.userAgent)) {
                        strw = (screenwidth + 40);
                        $("#MenuCollapse").attr("style", "display:none");
                        $("#form_Show_Alarm").attr("style", "left:-20px; bottom: unset");
                        //$("#bottom_popup_esri").attr("style", "left:unset; width : 100%");
                        //$("#bottom_popup_siteinfo").attr("style", "left:unset; width : 100%");
                        chartWidth = (screenwidth - 80);
                        chartHeight = (screenheight - 50);
                    }
                    $("#RAD_SPLITTER_PANE_CONTENT_ctl00_ContentPlaceHolder1_RadPane2").css("height", strh);//resize map height
                    $("#RAD_SPLITTER_PANE_CONTENT_ctl00_ContentPlaceHolder1_RadPane2").css("width", screenwidth);//resize map width
                    $("#ctl00_ContentPlaceHolder1_RadSplitter1").css("height", strh)
                    $("#ctl00_ContentPlaceHolder1_RadSplitter1").css("width", strw)
                    $("#RAD_SPLITTER_PANE_CONTENT_ctl00_ContentPlaceHolder1_RadPane1").css("width", "0px");//hide menu in radslide

                    $(".SiteSubMenu").click(function (e) {
                        e.preventDefault();
                        alert($(this).attr("href"));
                        return false;
                    }
                    );
                    $("li").click(function () {
                        if ($("li").hasClass('active')) {
                            $("li").removeClass('active');
                        }
                        else {
                            $(this).addClass('active');
                        }
                        $("#MapJS_rev1_DMA").addClass("open active ");
                    });

                    $(".HeaderLogout").click(function () {
                        var abc = $(this).find("#LogoutRegion");
                        if (abc.hasClass("show")) {
                            $(this).find("#LogoutRegion").removeClass("show");
                        }
                        else {
                            $(this).find("#LogoutRegion").addClass("show");
                        }

                    });

                    setInterval(function () { $(".rwControlButtons").css("width", "auto"); }, 100);
                    $("#btnLogout").click(function () {
                        $.ajax({
                            type: "POST",
                            url: "/Pi-solution/Pi1.asmx/Logout_pi",
                            data: "{}",
                            contentType: "application/json; charset=utf-8",
                            dataType: "json",
                            success: function (result) {
                                window.location.href = result.d;
                            },
                            error: function (error) {
                                alert("The system is under maintenance. Please come back later");
                            }
                        });
                    });
                    // active when click menu
                    var pathname = window.location.pathname;
                    $(".sidebar-nav a").each(function () {
                        if ($(this).attr("href") == pathname) {
                            $(this).addClass("subMenuActive");
                            $(this).parent().parent().parent().addClass("open active");
                            $(this).closest("ul").attr("aria-expanded", "true");
                            $(this).closest("ul").removeClass("collapse");
                            $(this).closest("ul").addClass("sidebar-nav collapse in");
                        }
                    });
                    //privilege  menu
                    $(".privilege").each(function () {
                        var substring = '@' + $(this).attr("href") + '@';
                        if ($("#ContentPlaceHolder1_hidListMenu").val().indexOf(substring) == -1) {
                            $(this).parent().attr("style", "display:none !important");
                        }
                    });
                    //active when click menu
                    $(".sidebar-menu a").each(function () {
                        if ($(this).attr("href") == pathname) {
                            $(this).parent().addClass("active");
                        }
                    });

                    $(".rfdRoundedCorners, .form-control").each(function () {
                        $(this).removeClass("rfdDecorated");
                    });


                    $(".rwControlButtons, .rbDecorated").each(function () {
                        $(this).removeAttr("style");
                        $(this).parent().removeClass("rfdSkinnedButton");

                    });
                    $(".rfdDecorated").each(function () {
                        $(this).parent().removeClass("rfdSkinnedButton");

                    });
                    $("#MenuCollapse").click(function () {
                        $(".sidebar").toggle(500);
                        $(".header").toggleClass('headerHide');
                        $(".app").toggleClass('headerHide');
                        //resize menu + map by screen
                        var screenwidth = $(document).width();
                        if ($(".header").hasClass("headerHide")) {
                            var strw = (screenwidth - 35);
                        }
                        else {
                            var strw = (screenwidth - 220);
                        }
                        $("#RAD_SPLITTER_PANE_CONTENT_ctl00_ContentPlaceHolder1_RadPane2").css("width", strw);//resize map width
                    });

                    var url = urlGetGroupChannel;
                    $.getJSON(url, function (d) {
                        console.log(d);
                        var index = 0;
                        $.each(d, function (i, val) {
                            var id = "ckbGroupChannel_" + index.toString();
                            if (val.Status == 1) {
                                $("#plhListGroupChannel").append("<div class='checkbox'><div><input type='checkbox' onclick='UpdateStGroupChannel(`" + val.GroupChannel + "`, " + index + ")' id='" + id + "' class='custom-checkbox' checked='checked'>" + val.GroupChannel + "</div></div>");
                            } else {
                                $("#plhListGroupChannel").append("<div class='checkbox'><div><input type='checkbox' onclick='UpdateStGroupChannel(`" + val.GroupChannel + "`, " + index + ")' id='" + id + "' class='custom-checkbox' >" + val.GroupChannel + "</div></div>");

                            }
                            index++;
                        });
                    });
                    // test all resulr and then enable to test
                    /* 
                    setInterval(function () {
                        var qs = getQueryStrings();
                        var uid = qs["uid"];
                        var urlAlarm = urlGetValeAlarm + uid;
                        $.getJSON(urlAlarm, function (d) {
                            $("#bodyFormAlarm").empty();
                            console.log(d);
                            var index = 0;
                            $.each(d, function (i, val) {
                                var date = new Date(parseInt(val.TimeStamp.substr(6)));
                                var jsDate = new Date(date).toLocaleDateString();
                                var strtable = "";
                                if (val.Status == "Delay") {
                                    strtable += "<tr style = 'background: #ff0'>";
                                } else {
                                    strtable += "<tr>";
                                }
                                strtable += "<td>" + (index + 1) + "</td>";
                                strtable += "<td>" + val.SialiasName + "</td>";
                                strtable += "<td>" + jsDate + "</td>";
                                strtable += "<td>" + val.NamePath + "</td>";
                                strtable += "<td>" + val.LasValue + "</td>";
                                if (val.Status == "High") {
                                    strtable += "<td ><span class='badge bg-red'>" + val.Status + "</span></td>";
                                } else if (val.Status == "Low") {
                                    strtable += "<td ><span class='badge bg-yellow'>" + val.Status + "</span></td>";
                                } else if (val.Status == "Baseline") {
                                    strtable += "<td ><span class='badge bg-light-blue'>" + val.Status + "</span></td>";
                                } else {
                                    strtable += "<td ><span class='badge bg-lime'>" + val.Status + "</span></td>";
                                }

                                strtable += "</tr>";
                                $("#bodyFormAlarm").append(strtable);
                                index++;
                            });
                            if (index > 0) {
                                $("#noAlarm").addClass("cls-display-none");
                                $("#txtCountAlarm").empty();
                                $("#txtCountAlarm").append("<small class='label pull-right bg-red' >" + index + "</small>");
                            } else {
                                $("#noAlarm").removeClass("cls-display-none");
                                $("#txtCountAlarm").empty();
                                $("#txtCountAlarm").append("<small class='label pull-right bg-red' >" + 0 + "</small>");
                            }
                        });
                    }, 1000)
                    */
                })

            }
            $(document).ready(function () {
                var mq = window.matchMedia("(min-width: 768px)");
                if (mq.matches) {
                    $(".main-sidebar").hover(
                        function () {
                            $('.treeview-menu').removeClass('cls-display-none');
                            $('.treeview-menu').removeClass('in');
                        },
                        function () {
                            $('.treeview-menu').removeClass('in');
                            $('.treeview-menu').removeAttr('style');
                            $('.treeview-menu').parent().removeClass('open active menu-open');
                        }
                    );
                }
            });
            var mq = window.matchMedia("(max-width: 767px)");
            if (mq.matches) {
                var flag = true;
                function displayMenuList() {
                    var id_tab_menu = document.getElementById("tab-icon-menu");
                    if (flag) {
                        id_tab_menu.classList.remove("menu-main-mobile");
                        flag = false;
                    }
                    else {
                        id_tab_menu.classList.add("menu-main-mobile");
                        flag = true;
                    }
                }
            }
            var clickBodyShowAlarm = false;

            var showAlarm = true;

            function btnAlarm_Click() {
                //if (showAlarm) {
                //    $('#form_Show_Alarm').removeClass('cls-display-none');
                //    showAlarm = false;
                //    clickBodyShowAlarm = true;
                //} else {
                //    $('#form_Show_Alarm').addClass('cls-display-none');
                //    showAlarm = true;
                //}
                //$('#body_form_show_alarm').removeClass('cls-display-none');
                $("#btnConfirmAlarm").addClass("btn-info");
            }

            function btnConfirmAlarm_Click() {
                var qs = getQueryStrings();
                var uid = qs["uid"];
                var url = urlConfirmAlarm + uid;
                $.getJSON(url, function (d) { });
                $("#btnConfirmAlarm").removeClass("btn-info");
                $("#btnConfirmAlarm").addClass("btn-success");
            }

            $(document).ready(function () {
                $('.click').click(function (event) {
                    event.stopPropagation();
                    $(".showup").slideToggle("fast");
                });
                $(".showup").on("click", function (event) {
                    event.stopPropagation();
                });
            });

            $(document).on("click", function () {
                $(".showup").hide();
                $("#btnConfirmAlarm").addClass("btn-info");
            });

        </script>

    </body>


</asp:Content>
