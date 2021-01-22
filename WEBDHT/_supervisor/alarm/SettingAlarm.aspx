<%@ Page Language="C#" MasterPageFile="~/_supervisor/master_page.master" AutoEventWireup="true" CodeFile="SettingAlarm.aspx.cs" Inherits="_supervisor_alarm_SettingAlarm" %>


<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="Server">
    <link href="../../css/Config.css" rel="stylesheet">
    <link href="../../bower_components/treeview/qunit-1.12.0.css" rel="stylesheet" />

    <script type="text/javascript">
        // preventing resubmition form application
        window.history.replaceState('', '', window.location.href)
    </script>
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="Server">
    <div id="main-content2">
        <div id="main-content-title">
            <h2 class="title">Cài Đặt Cảnh Báo</h2>
        </div>
        <div class="container-fluid m-t">
            <div class="row">
                <div class="col-sm-6">
                    <div class="group-text">
                        <div class="row">
                            <span>Mã point</span>
                        </div>
                        <div class="row m-b">
                            <telerik:RadComboBox ID="cboIds" runat="server" AllowCustomText="True"
                                EnableLoadOnDemand="True" Filter="StartsWith"
                                HighlightTemplatedItems="True" DataSourceID="IdsDataSource"
                                AutoPostBack="True" OnSelectedIndexChanged="cboIds_SelectedIndexChanged"
                                TabIndex="1">
                            </telerik:RadComboBox>
                            <asp:ObjectDataSource ID="IdsDataSource" runat="server"
                                OldValuesParameterFormatString="original_{0}" SelectMethod="GetAllIds"
                                TypeName="SitesBLL"></asp:ObjectDataSource>
                        </div>
                    </div>
                    <div class="group-text">
                        <div class="row">
                            <span>Ngưỡng trên</span>
                        </div>
                        <div class="row m-b">
                            <telerik:RadNumericTextBox ID="txtbasemax" runat="server"
                                TabIndex="17">
                                <NumberFormat DecimalDigits="0" ZeroPattern="n" />
                            </telerik:RadNumericTextBox>
                        </div>
                    </div>
                </div>
                <div class="col-sm-6">
                    <div class="group-text">
                        <div class="row">
                            <span>Mã Kênh</span>
                        </div>
                        <div class="row m-b">
                            <telerik:RadComboBox ID="cboChannels" runat="server" AllowCustomText="True"
                                EnableLoadOnDemand="True" Filter="StartsWith"
                                HighlightTemplatedItems="True" OnSelectedIndexChanged="cboChannels_SelectedIndexChanged"
                                AutoPostBack="True"
                                TabIndex="1">
                            </telerik:RadComboBox>
                        </div>
                    </div>

                    <div class="group-text">
                        <div class="row">
                            <span>Ngưỡng dưới</span>
                        </div>
                        <div class="row m-b">
                            <telerik:RadNumericTextBox ID="txtbasemin" runat="server"
                                TabIndex="17">
                                <NumberFormat DecimalDigits="0" ZeroPattern="n" />
                            </telerik:RadNumericTextBox>
                        </div>
                    </div>
                </div>
                <div class="col-sm-12">
                    <div id="tree"></div>
                </div>
                <div class="text-center col-sm-12 m-t m-b no-padding" style="clear: both;">
                    <asp:Button ID="btnUpdate" runat="server" Text="Cập Nhật"
                        OnClick="btnUpdate_Click" CssClass="btn btn-success"></asp:Button>

                </div>
            </div>
        </div>
    </div>
    <telerik:RadNotification ID="ntf" runat="server" Title="Message">
    </telerik:RadNotification>
    <telerik:RadAjaxManagerProxy ID="RadAjaxManagerProxy1" runat="server">
        <AjaxSettings>
            <telerik:AjaxSetting AjaxControlID="cboIds">
                <UpdatedControls>
                    <telerik:AjaxUpdatedControl ControlID="cboChannels" />

                </UpdatedControls>
            </telerik:AjaxSetting>

            <telerik:AjaxSetting AjaxControlID="cboChannels">
                <UpdatedControls>
                    <telerik:AjaxUpdatedControl ControlID="txtbasemax" />
                    <telerik:AjaxUpdatedControl ControlID="txtbasemin" />

                </UpdatedControls>
            </telerik:AjaxSetting>
            <telerik:AjaxSetting AjaxControlID="btnUpdate">
                <UpdatedControls>
                    <telerik:AjaxUpdatedControl ControlID="ntf" />

                </UpdatedControls>
            </telerik:AjaxSetting>

        </AjaxSettings>
    </telerik:RadAjaxManagerProxy>
    <%--<script src="../../bower_components/treeview/blanket.min.js"></script>--%>
    <%--<script src="../../bower_components/treeview/qunit-1.12.0.js"></script>--%>
    <script src="../../bower_components/treeview/jquery.js"></script>
    <script src="../../bower_components/treeview/bootstrap-treeview.min.js"></script>
    <script src="https://cdn.jsdelivr.net/npm/axios/dist/axios.min.js"></script>
    <script>

        var tree = [
            {
                text: "Parent 1",
                nodes: [
                    {
                        text: "Child 1",
                        nodes: [
                            {
                                text: "Grandchild 1"
                            },
                            {
                                text: "Grandchild 2"
                            }
                        ]
                    },
                    {
                        text: "Child 2"
                    }
                ]
            },
            {
                text: "Parent 2",
                nodes: [
                    {
                        text: "Child 1",
                        nodes: [
                            {
                                text: "Grandchild 1"
                            },
                            {
                                text: "Grandchild 2"
                            }
                        ]
                    },
                    {
                        text: "Child 2"
                    }
                ]
            },
            {
                text: "Parent 3",
                nodes: [
                    {
                        text: "Child 1",
                        nodes: [
                            {
                                text: "Grandchild 1"
                            },
                            {
                                text: "Grandchild 2"
                            }
                        ]
                    },
                    {
                        text: "Child 2"
                    }
                ]
            },
            {
                text: "Parent 4",
                nodes: [
                    {
                        text: "Child 1",
                        nodes: [
                            {
                                text: "Grandchild 1"
                            },
                            {
                                text: "Grandchild 2"
                            }
                        ]
                    },
                    {
                        text: "Child 2"
                    }
                ]
            },
            {
                text: "Parent 5"
            }
        ];

        function getTree() {
            // Some logic to retrieve, or generate tree structure
            return tree;
        }

        $('#tree').treeview({ data: getTree() });

    </script>
</asp:Content>
