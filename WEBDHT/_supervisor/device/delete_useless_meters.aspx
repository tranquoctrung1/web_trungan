<%@ Page Title="" Language="C#" MasterPageFile="~/_supervisor/master_page.master" AutoEventWireup="true" CodeFile="delete_useless_meters.aspx.cs" Inherits="_supervisor_device_delete_useless_meters" %>

<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="Server">
    <link href="../../css/Config.css" rel="stylesheet" >

    <script type="text/javascript">
        function btnDelete_Clicked() {
            var win = $find('<%=winConfirmDelete.ClientID %>');
            win.show();
        }
        function btnCancel_Clicked() {
            var win = $find('<%=winConfirmDelete.ClientID %>');
            win.close();
        }

        // preventing resubmition form application
        window.history.replaceState('', '', window.location.href)
    </script>
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="Server">
    <div id="main-content2">
        <div id="main-content-title">
            <h2 class="title">Xóa đồng hồ không sử dụng</h2>
        </div>
        <div class="container-fluid m-t">
            <div class="row">
                <div class="col d-flex m-b">
                    <asp:Button ID="btnDelete" runat="server" Text="Xóa"
                        AutoPostBack="False" OnClientClick="btnDelete_Clicked()" CssClass="btn btn-danger"></asp:Button>
                </div>
            </div>
            <telerik:RadGrid ID="grv" runat="server" AutoGenerateColumns="False" AllowMultiRowSelection="True"
                CellSpacing="0" GridLines="None" DataSourceID="MetersDataSource"
                AllowPaging="True" PageSize="20" Width="100%">
                <ClientSettings>
                    <Selecting CellSelectionMode="None" AllowRowSelect="true"></Selecting>
                </ClientSettings>

                <MasterTableView DataSourceID="MetersDataSource">
                    <CommandItemSettings ExportToPdfText="Export to PDF"></CommandItemSettings>

                    <RowIndicatorColumn Visible="True" FilterControlAltText="Filter RowIndicator column">
                    </RowIndicatorColumn>

                    <ExpandCollapseColumn Visible="True" FilterControlAltText="Filter ExpandColumn column">
                    </ExpandCollapseColumn>

                    <Columns>
                        <telerik:GridClientSelectColumn>
                        </telerik:GridClientSelectColumn>
                        <telerik:GridBoundColumn DataField="Serial"
                            FilterControlAltText="Filter Serial column" HeaderText="Serial"
                            UniqueName="Serial">
                        </telerik:GridBoundColumn>
                        <telerik:GridBoundColumn DataField="Provider"
                            FilterControlAltText="Filter Provider column" HeaderText="Nhà sản xuất"
                            UniqueName="Provider">
                        </telerik:GridBoundColumn>
                        <telerik:GridBoundColumn DataField="Marks"
                            FilterControlAltText="Filter Marks column" HeaderText="Hiệu"
                            UniqueName="Marks">
                        </telerik:GridBoundColumn>
                        <telerik:GridBoundColumn DataField="Size"
                            FilterControlAltText="Filter Size column" HeaderText="Cỡ"
                            UniqueName="Size" DataType="System.Int16">
                        </telerik:GridBoundColumn>
                        <telerik:GridBoundColumn DataField="Model"
                            FilterControlAltText="Filter Model column" HeaderText="Model"
                            UniqueName="Model">
                        </telerik:GridBoundColumn>
                        <telerik:GridBoundColumn DataField="Status"
                            FilterControlAltText="Filter Status column" HeaderText="Tình trạng"
                            UniqueName="Status">
                        </telerik:GridBoundColumn>
                    </Columns>
                    <EditFormSettings>
                        <EditColumn FilterControlAltText="Filter EditCommandColumn column"></EditColumn>
                    </EditFormSettings>
                </MasterTableView>

                <FilterMenu EnableImageSprites="False"></FilterMenu>
            </telerik:RadGrid>
            <asp:ObjectDataSource ID="MetersDataSource" runat="server"
                OldValuesParameterFormatString="original_{0}" SelectMethod="GetAllUseless"
                TypeName="MetersBLL"></asp:ObjectDataSource>
            <telerik:RadWindow ID="winConfirmDelete" runat="server" Modal="True"
                VisibleStatusbar="False" Height="120">
                <ContentTemplate>
                    <table style="width: 100%; text-align: center" cellpadding="5">
                        <tr>
                            <td>Bạn có muốn xóa đồng hồ không?
                            </td>
                        </tr>
                        <tr>
                            <td>
                                <asp:Button ID="btnConfim" runat="server" Text="Xóa"
                                    OnClick="btnConfirmDelete_Click" CssClass="btn btn-danger"></asp:Button>
                                <asp:Button ID="btnCancel" runat="server"
                                    OnClientClick="btnCancel_Clicked()"
                                    Text="Hủy thao tác" AutoPostBack="False" CssClass="btn btn-success"></asp:Button>
                            </td>
                        </tr>
                    </table>
                </ContentTemplate>
            </telerik:RadWindow>
            <telerik:RadNotification ID="ntf" runat="server" Title="Message">
            </telerik:RadNotification>
        </di>
    </div>
    <telerik:RadAjaxManagerProxy ID="RadAjaxManagerProxy1" runat="server">
        <AjaxSettings>
            <telerik:AjaxSetting AjaxControlID="btnDelete">
                <UpdatedControls>
                    <telerik:AjaxUpdatedControl ControlID="ntf" />
                </UpdatedControls>
            </telerik:AjaxSetting>
        </AjaxSettings>
    </telerik:RadAjaxManagerProxy>
</asp:Content>

