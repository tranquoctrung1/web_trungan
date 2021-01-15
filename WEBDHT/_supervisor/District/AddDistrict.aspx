<%@ Page Language="C#"  MasterPageFile="~/_supervisor/master_page.master" AutoEventWireup="true" CodeFile="AddDistrict.aspx.cs" Inherits="_supervisor_District_AddDistrict" %>


<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="Server">
    <link href="../../css/Config.css" rel="stylesheet">
    <style type="text/css">
        .group-text.change-size {
            height: 55px
        }

        .row.m-b.out {
            display: flex;
            justify-content: center;
            align-items: center;
            height: 33px !important
        }
    </style>
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
            <h2 class="title">Thêm Quận</h2>
        </div>
        <div class="container-fluid m-t">
            <div class="row">
                <div class="col-sm-4">
                    <div class="group-text">
                        <div class="row">
                            <span>Mã Quận</span>
                        </div>
                        <div class="row m-b">
                            <telerik:RadComboBox ID="cboDistrict" runat="server" AllowCustomText="True"
                                EnableLoadOnDemand="True" Filter="StartsWith" AutoPostBack="true"
                                HighlightTemplatedItems="True" DataSourceID="DistrictDataSource"
                                DataTextField="IdDistrict" DataValueField="IdDistrict" DropDownWidth="275px"
                                TabIndex="1" onselectedindexchanged="cboDistrict_SelectedIndexChanged">
                                <HeaderTemplate>
                                    <table cellpadding="0" cellspacing="0">
                                        <tr>
                                            <td style="width: 70px">Id</td>
                                            <td style="width: 100px">Tên Quận</td>
                                            <td style="width: 100px">Mô tả</td>
                                        </tr>
                                    </table>
                                </HeaderTemplate>
                                <ItemTemplate>
                                    <table cellpadding="0" cellspacing="0">
                                        <tr>
                                            <td style="width: 70px"><%#DataBinder.Eval(Container.DataItem,"IdDistrict") %></td>
                                            <td style="width: 100px"><%#DataBinder.Eval(Container.DataItem,"Name") %></td>
                                            <td style="width: 100px"><%#DataBinder.Eval(Container.DataItem,"Description") %></td>
                                        </tr>
                                    </table>
                                </ItemTemplate>
                            </telerik:RadComboBox>
                            <asp:ObjectDataSource ID="DistrictDataSource" runat="server"
                                OldValuesParameterFormatString="original_{0}" SelectMethod="GetDistricts"
                                TypeName="DistrictBLL"></asp:ObjectDataSource>
                        </div>
                    </div>
                </div>
                <div class="col-sm-4">
                    <div class="group-text">
                        <div class="row">
                            <span>Tên Quận</span>
                        </div>
                        <div class="row m-b">
                            <telerik:RadTextBox ID="txtNameDistrict" runat="server">
                            </telerik:RadTextBox>
                        </div>
                    </div>
                </div>
                <div class="col-sm-4">
                    <div class="group-text">
                        <div class="row">
                            <span>Mô tả</span>
                        </div>
                        <div class="row m-b">
                            <telerik:RadTextBox ID="txtDescription" runat="server" TextMode="MultiLine">
                            </telerik:RadTextBox>
                        </div>
                    </div>
                </div>

                <div class="text-center col-sm-12 m-t m-b no-padding" style="clear: both;">
                    <asp:Button ID="btnAdd" runat="server" Text="Thêm/Sửa"
                        OnClick="btnAdd_Click" CssClass="btn btn-success"></asp:Button>
                    <asp:Button ID="btnDelete" runat="server" AutoPostBack="false"
                        OnClientClick="btnDelete_Clicked()" Text="Xóa"
                        CssClass="btn btn-danger"></asp:Button>
                </div>
            </div>
        </div>

    </div>
    <telerik:RadWindow ID="winConfirmDelete" runat="server" Modal="True"
        VisibleStatusbar="False" Height="160">
        <ContentTemplate>
            <table width="100%" style="text-align: center">
                <tr>
                    <td>Bạn có muốn xóa quận không?
                    </td>
                </tr>
                <tr>
                    <td>&nbsp</td>
                </tr>
                <tr>
                    <td>
                        <asp:Button ID="btnConfim" runat="server" Text="Xóa"
                            OnClick="btnConfim_Click" CssClass="btn btn-danger"></asp:Button>
                        <asp:Button ID="btnCancel" runat="server"
                            OnClientClick="btnCancel_Clicked()" CssClass="btn btn-success"
                            Text="Hủy thao tác" AutoPostBack="False"></asp:Button>
                    </td>
                </tr>
            </table>
        </ContentTemplate>
    </telerik:RadWindow>
    <telerik:RadNotification ID="ntf" runat="server"></telerik:RadNotification>
    <telerik:RadAjaxManagerProxy ID="RadAjaxManagerProxy1" runat="server">
        <AjaxSettings>
            <telerik:AjaxSetting AjaxControlID="cboDistrict">
                <UpdatedControls>
                     <telerik:AjaxUpdatedControl ControlID="txtNameDistrict" />
                     <telerik:AjaxUpdatedControl ControlID="txtDescription" />
                </UpdatedControls>
            </telerik:AjaxSetting>
            <telerik:AjaxSetting AjaxControlID="btnAdd">
                <UpdatedControls>
                     <telerik:AjaxUpdatedControl ControlID="cboDistrict" />
                     <telerik:AjaxUpdatedControl ControlID="txtNameDistrict" />
                     <telerik:AjaxUpdatedControl ControlID="txtDescription" />
                    <telerik:AjaxUpdatedControl ControlID="ntf" />
                </UpdatedControls>
            </telerik:AjaxSetting>
            <telerik:AjaxSetting AjaxControlID="btnDelete">
                <UpdatedControls>
                    <telerik:AjaxUpdatedControl ControlID="ntf" />
                </UpdatedControls>
            </telerik:AjaxSetting>
           
        </AjaxSettings>
    </telerik:RadAjaxManagerProxy>
</asp:Content>
