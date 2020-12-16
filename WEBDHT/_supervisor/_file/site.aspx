<%@ Page Title="" Language="C#" MasterPageFile="~/_supervisor/master_page.master" AutoEventWireup="true" CodeFile="site.aspx.cs" Inherits="_supervisor_file_site" %>

<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="Server">
    <link href="../../css/Config.css" rel="stylesheet">

    <script type="text/javascript">
        //<![CDATA[

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
//]]>
    </script>
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="Server">
    <div id="main-content2">

        <div id="main-content-title">
            <h2 class="title">Download file điểm lắp đặt</h2>
        </div>
        <div>
            <div class="container-fluid m-t">
                <div class="row">
                    <div class="col-sm-6">
                        <div class="group-text">
                            <div class="row">
                                <span>Mã vị trí</span>
                            </div>
                            <div class="row m-b">
                                <telerik:RadComboBox ID="cboSiteIds" runat="server"
                                    DataSourceID="SitesDataSource" DataTextField="Id"
                                    DataValueField="Id" AllowCustomText="True" AutoPostBack="True"
                                    DropDownWidth="350px" EnableLoadOnDemand="True" Filter="StartsWith"
                                    HighlightTemplatedItems="True">
                                    <HeaderTemplate>
                                        <table cellpadding="0" cellspacing="0">
                                            <tr>
                                                <td style="width: 50px">Mã NV</td>
                                                <td style="width: 50px">Mã vị trí</td>
                                                <td style="width: 250px">Vị trí</td>
                                            </tr>
                                        </table>
                                    </HeaderTemplate>
                                    <ItemTemplate>
                                        <table cellpadding="0" cellspacing="0">
                                            <tr>
                                                <td style="width: 50px"><%#DataBinder.Eval(Container.DataItem,"StaffId") %></td>
                                                <td style="width: 50px"><%#DataBinder.Eval(Container.DataItem,"Id") %></td>
                                                <td style="width: 250px"><%#DataBinder.Eval(Container.DataItem,"Location") %></td>
                                            </tr>
                                        </table>
                                    </ItemTemplate>
                                </telerik:RadComboBox>
                                <asp:ObjectDataSource ID="SitesDataSource" runat="server"
                                    OldValuesParameterFormatString="original_{0}" SelectMethod="GetAll"
                                    TypeName="SitesBLL"></asp:ObjectDataSource>
                            </div>
                        </div>
                    </div>
                    <div class="col-sm-6">
                        <div class="group-text">

                            <div class="row">
                                <span>&nbsp</span>
                            </div>
                            <div>
                                <asp:Button ID="btnDownload" runat="server" Text="Download"
                                    OnClick="btnDownload_Click" CssClass="btn btn-success"></asp:Button>
                                <asp:Button ID="btnDelete" runat="server"
                                    OnClientClick="btnDelete_Clicked()" Text="Xóa" AutoPostBack="False"
                                    CssClass="btn btn-danger"></asp:Button>
                            </div>
                        </div>
                    </div>
                </div>
            </div>
            <telerik:RadGrid ID="grv" runat="server" AutoGenerateColumns="False" AllowMultiRowSelection="True"
                CellSpacing="0" GridLines="None" DataSourceID="FilesDataSource">
                <ClientSettings>
                    <Selecting CellSelectionMode="None" AllowRowSelect="true"></Selecting>
                </ClientSettings>

                <MasterTableView DataSourceID="FilesDataSource">
                    <CommandItemSettings ExportToPdfText="Export to PDF"></CommandItemSettings>

                    <RowIndicatorColumn Visible="True" FilterControlAltText="Filter RowIndicator column">
                    </RowIndicatorColumn>

                    <ExpandCollapseColumn Visible="True" FilterControlAltText="Filter ExpandColumn column">
                    </ExpandCollapseColumn>

                    <Columns>
                        <telerik:GridClientSelectColumn>
                        </telerik:GridClientSelectColumn>
                        <telerik:GridBoundColumn DataField="FileName"
                            FilterControlAltText="Filter column1 column" HeaderText="Tên file"
                            UniqueName="FileName">
                        </telerik:GridBoundColumn>
                        <telerik:GridBoundColumn DataField="MIMEType"
                            FilterControlAltText="Filter column2 column" HeaderText="MIME Type"
                            UniqueName="column2">
                        </telerik:GridBoundColumn>
                        <telerik:GridBoundColumn DataField="Size"
                            FilterControlAltText="Filter column3 column" HeaderText="Cỡ (bytes)"
                            UniqueName="column3">
                        </telerik:GridBoundColumn>
                        <telerik:GridBoundColumn DataField="UploadDate" DataFormatString="{0:dd/MM/yyyy hh:mm:ss tt}"
                            FilterControlAltText="Filter column4 column" HeaderText="Ngày upload"
                            UniqueName="column4">
                        </telerik:GridBoundColumn>
                    </Columns>
                    <EditFormSettings>
                        <EditColumn FilterControlAltText="Filter EditCommandColumn column"></EditColumn>
                    </EditFormSettings>
                </MasterTableView>

                <FilterMenu EnableImageSprites="False"></FilterMenu>
            </telerik:RadGrid>
            <asp:ObjectDataSource ID="FilesDataSource" runat="server"
                OldValuesParameterFormatString="original_{0}"
                SelectMethod="GetAllBySiteId" TypeName="SiteFilesBLL">
                <SelectParameters>
                    <asp:ControlParameter ControlID="cboSiteIds" Name="siteId"
                        PropertyName="SelectedValue" Type="String" />
                </SelectParameters>
            </asp:ObjectDataSource>
        </div>
        <telerik:RadWindow ID="winConfirmDelete" runat="server" Modal="True"
            VisibleStatusbar="False" Height="160">
            <ContentTemplate>
                <table style="width: 100%; text-align: center">
                    <tr>
                        <td>Bạn có muốn xóa file điểm lắp đặt không?
                        </td>
                    </tr>
                    <tr>
                        <td>&nbsp</td>
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
        <telerik:RadAjaxManagerProxy ID="RadAjaxManagerProxy1" runat="server">
            <AjaxSettings>
                <telerik:AjaxSetting AjaxControlID="cboSiteIds">
                    <UpdatedControls>
                        <telerik:AjaxUpdatedControl ControlID="cboSiteIds" />

                    </UpdatedControls>
                </telerik:AjaxSetting>
                <telerik:AjaxSetting AjaxControlID="btnAdd">
                    <UpdatedControls>
                        <telerik:AjaxUpdatedControl ControlID="ntf" />
                        <telerik:AjaxUpdatedControl ControlID="cboSerials" />

                    </UpdatedControls>
                </telerik:AjaxSetting>
                <telerik:AjaxSetting AjaxControlID="btnDelete">
                    <UpdatedControls>
                        <telerik:AjaxUpdatedControl ControlID="ntf" />
                    </UpdatedControls>
                </telerik:AjaxSetting>
            </AjaxSettings>
        </telerik:RadAjaxManagerProxy>
    </div>
</asp:Content>

