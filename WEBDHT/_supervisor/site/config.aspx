<%@ Page Title="" Language="C#" MasterPageFile="~/_supervisor/master_page.master" AutoEventWireup="true" CodeFile="config.aspx.cs" Inherits="_supervisor_site_config" %>

<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="Server">
    <link href="../../css/Config.css" rel="stylesheet">
    <style type="text/css">
       .group-text.change-size
       {
          
           height: 55px
       }
       .row.m-b.out
       {
           display: flex;
           justify-content: center;
           align-items: center;
           height: 33px !important
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
            <h2 class="title">Cấu hình logger điểm lắp đặt</h2>
        </div>
        <div class="container-fluid m-t">
            <div class="row">
                <div class="col-sm-6">
                    <div class="group-text">
                        <div class="row">
                            <span>Mã point</span>
                        </div>
                        <div class="row m-b">
                            <telerik:RadComboBox ID="cboSiteIds" runat="server"
                                DataSourceID="SitesDataSource" DataTextField="Id" DataValueField="Id"
                                AllowCustomText="True" DropDownWidth="350px" EnableLoadOnDemand="True"
                                Filter="StartsWith" HighlightTemplatedItems="True"
                                OnSelectedIndexChanged="cboSiteIds_SelectedIndexChanged"
                                AutoPostBack="True">
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

                    <div class="group-text">
                        <div class="row">
                            <span>Interval</span>
                        </div>
                        <div class="row m-b">
                            <telerik:RadNumericTextBox ID="nmrInterval" runat="server">
                                <NumberFormat DecimalDigits="0" ZeroPattern="n" />
                            </telerik:RadNumericTextBox>
                        </div>
                    </div>
                </div>

                <div class="col-sm-6">
                    <div class="group-text">
                        <div class="row">
                            <span>Id logger</span>
                        </div>
                        <div class="row m-b">
                            <telerik:RadTextBox ID="txtLoggerId" runat="server">
                            </telerik:RadTextBox>
                        </div>
                    </div>
                    <div class="group-text">
                        <div class="row">
                            <span>Giờ bắt đầu ngày</span>
                        </div>
                        <div class="row m-b">
                            <telerik:RadTimePicker ID="tmStart" runat="server">
                            </telerik:RadTimePicker>
                        </div>
                    </div>
                </div>
            </div>
            <div class="row">
                <div class="col-sm-2">
                    <div class="group-text">
                        <div class="row">
                            <span>Kênh ID</span>
                        </div>
                        <div class="row m-b">
                            <telerik:RadTextBox ID="txtChannelId1" runat="server"
                                Style="top: 0px; left: 0px">
                            </telerik:RadTextBox>
                        </div>
                    </div>
                    <div class="group-text">
                        <div class="row">
                            <span>Kênh ID</span>
                        </div>
                        <div class="row m-b">
                            <telerik:RadTextBox ID="txtChannelId2" runat="server"
                                Style="top: 0px; left: 0px">
                            </telerik:RadTextBox>
                        </div>
                    </div>
                    <div class="group-text">
                        <div class="row">
                            <span>Kênh ID</span>
                        </div>
                        <div class="row m-b">
                           <telerik:RadTextBox ID="txtChannelId3" runat="server"
                                Style="top: 0px; left: 0px">
                            </telerik:RadTextBox>
                        </div>
                    </div>
                    <div class="group-text">
                        <div class="row">
                            <span>Kênh ID</span>
                        </div>
                        <div class="row m-b">
                            <telerik:RadTextBox ID="txtChannelId4" runat="server"
                                Style="top: 0px; left: 0px">
                            </telerik:RadTextBox>
                        </div>
                    </div>
                </div>
                <div class="col-sm-2">
                    <div class="group-text">
                        <div class="row">
                            <span>Tên</span>
                        </div>
                        <div class="row m-b">
                            <telerik:RadTextBox ID="txtChannelName1" runat="server"
                                Style="top: 0px; left: 0px">
                            </telerik:RadTextBox>
                        </div>
                    </div>
                    <div class="group-text">
                        <div class="row">
                            <span>Tên</span>
                        </div>
                        <div class="row m-b">
                             <telerik:RadTextBox ID="txtChannelName2" runat="server"
                                Style="top: 0px; left: 0px">
                            </telerik:RadTextBox>
                        </div>
                    </div>
                    <div class="group-text">
                        <div class="row">
                            <span>Tên</span>
                        </div>
                        <div class="row m-b">
                            <telerik:RadTextBox ID="txtChannelName3" runat="server"
                                Style="top: 0px; left: 0px">
                            </telerik:RadTextBox>
                        </div>
                    </div>
                    <div class="group-text">
                        <div class="row">
                            <span>Tên</span>
                        </div>
                        <div class="row m-b">
                            <telerik:RadTextBox ID="txtChannelName4" runat="server"
                                Style="top: 0px; left: 0px">
                            </telerik:RadTextBox>
                        </div>
                    </div>
                </div>
                <div class="col-sm-2">
                    <div class="group-text">
                        <div class="row">
                            <span>Đơn vị</span>
                        </div>
                        <div class="row m-b">
                             <telerik:RadComboBox ID="cboUnit1" runat="server"
                                DataSourceID="ChannelUnitsDataSource" DataTextField="Unit"
                                DataValueField="Unit" AllowCustomText="True" EnableLoadOnDemand="True"
                                Filter="StartsWith" HighlightTemplatedItems="True">
                                <HeaderTemplate>
                                    <table cellpadding="0" cellspacing="0">
                                        <tr>
                                            <td style="width: 80px">Đơn vị</td>
                                            <td style="width: 80px">Mô tả</td>
                                        </tr>
                                    </table>
                                </HeaderTemplate>
                                <ItemTemplate>
                                    <table cellpadding="0" cellspacing="0">
                                        <tr>
                                            <td style="width: 80px"><%#DataBinder.Eval(Container.DataItem,"Unit") %></td>
                                            <td style="width: 80px"><%#DataBinder.Eval(Container.DataItem,"Description") %></td>
                                        </tr>
                                    </table>
                                </ItemTemplate>
                            </telerik:RadComboBox>
                            <asp:ObjectDataSource ID="ChannelUnitsDataSource" runat="server"
                                OldValuesParameterFormatString="original_{0}" SelectMethod="GetAll"
                                TypeName="ChannelUnitsBLL"></asp:ObjectDataSource>
                        </div>
                    </div>
                    <div class="group-text">
                        <div class="row">
                            <span>Đơn vị</span>
                        </div>
                        <div class="row m-b">
                             <telerik:RadComboBox ID="cboUnit2" runat="server"
                                DataSourceID="ChannelUnitsDataSource" DataTextField="Unit"
                                DataValueField="Unit" AllowCustomText="True" EnableLoadOnDemand="True"
                                Filter="StartsWith" HighlightTemplatedItems="True">
                                <HeaderTemplate>
                                    <table cellpadding="0" cellspacing="0">
                                        <tr>
                                            <td style="width: 80px">Đơn vị</td>
                                            <td style="width: 80px">Mô tả</td>
                                        </tr>
                                    </table>
                                </HeaderTemplate>
                                <ItemTemplate>
                                    <table cellpadding="0" cellspacing="0">
                                        <tr>
                                            <td style="width: 80px"><%#DataBinder.Eval(Container.DataItem,"Unit") %></td>
                                            <td style="width: 80px"><%#DataBinder.Eval(Container.DataItem,"Description") %></td>
                                        </tr>
                                    </table>
                                </ItemTemplate>
                            </telerik:RadComboBox>
                            <asp:ObjectDataSource ID="ObjectDataSource1" runat="server"
                                OldValuesParameterFormatString="original_{0}" SelectMethod="GetAll"
                                TypeName="ChannelUnitsBLL"></asp:ObjectDataSource>
                        </div>
                    </div>
                    <div class="group-text">
                        <div class="row">
                            <span>Đơn vị</span>
                        </div>
                        <div class="row m-b">
                             <telerik:RadComboBox ID="cboUnit3" runat="server"
                                DataSourceID="ChannelUnitsDataSource" DataTextField="Unit"
                                DataValueField="Unit" AllowCustomText="True" EnableLoadOnDemand="True"
                                Filter="StartsWith" HighlightTemplatedItems="True">
                                <HeaderTemplate>
                                    <table cellpadding="0" cellspacing="0">
                                        <tr>
                                            <td style="width: 80px">Đơn vị</td>
                                            <td style="width: 80px">Mô tả</td>
                                        </tr>
                                    </table>
                                </HeaderTemplate>
                                <ItemTemplate>
                                    <table cellpadding="0" cellspacing="0">
                                        <tr>
                                            <td style="width: 80px"><%#DataBinder.Eval(Container.DataItem,"Unit") %></td>
                                            <td style="width: 80px"><%#DataBinder.Eval(Container.DataItem,"Description") %></td>
                                        </tr>
                                    </table>
                                </ItemTemplate>
                            </telerik:RadComboBox>
                            <asp:ObjectDataSource ID="ObjectDataSource2" runat="server"
                                OldValuesParameterFormatString="original_{0}" SelectMethod="GetAll"
                                TypeName="ChannelUnitsBLL"></asp:ObjectDataSource>
                        </div>
                    </div>
                    <div class="group-text">
                        <div class="row">
                            <span>Đơn vị</span>
                        </div>
                        <div class="row m-b">
                             <telerik:RadComboBox ID="cboUnit4" runat="server"
                                DataSourceID="ChannelUnitsDataSource" DataTextField="Unit"
                                DataValueField="Unit" AllowCustomText="True" EnableLoadOnDemand="True"
                                Filter="StartsWith" HighlightTemplatedItems="True">
                                <HeaderTemplate>
                                    <table cellpadding="0" cellspacing="0">
                                        <tr>
                                            <td style="width: 80px">Đơn vị</td>
                                            <td style="width: 80px">Mô tả</td>
                                        </tr>
                                    </table>
                                </HeaderTemplate>
                                <ItemTemplate>
                                    <table cellpadding="0" cellspacing="0">
                                        <tr>
                                            <td style="width: 80px"><%#DataBinder.Eval(Container.DataItem,"Unit") %></td>
                                            <td style="width: 80px"><%#DataBinder.Eval(Container.DataItem,"Description") %></td>
                                        </tr>
                                    </table>
                                </ItemTemplate>
                            </telerik:RadComboBox>
                            <asp:ObjectDataSource ID="ObjectDataSource3" runat="server"
                                OldValuesParameterFormatString="original_{0}" SelectMethod="GetAll"
                                TypeName="ChannelUnitsBLL"></asp:ObjectDataSource>
                        </div>
                    </div>
                </div>
                <div class="col-sm-1 no-padding">
                    <div class="group-text change-size">
                         <div class="row">
                            <span>&nbsp</span>
                        </div>
                        <div class="row m-b out">
                            <span>Áp lực trước </span>
                            <asp:RadioButton ID="rdoPress1" runat="server" GroupName="Channel1" CssClass="radiob" />
                        </div>
                    </div>
                     <div class="group-text change-size" >
                          <div class="row">
                            <span>&nbsp</span>
                        </div>
                        <div class="row m-b out">
                            <span>Áp lực trước</span>
                            <asp:RadioButton ID="rdoPress2" runat="server" GroupName="Channel2" CssClass="radiob" />
                        </div>
                    </div>
                    <div class="group-text change-size">
                         <div class="row">
                            <span>&nbsp</span>
                        </div>
                        <div class="row m-b out">
                            <span>Áp lực trước</span>
                            <asp:RadioButton ID="rdoPress3" runat="server" GroupName="Channel3" CssClass="radiob" />
                        </div>
                    </div>
                    <div class="group-text change-size">
                         <div class="row">
                            <span>&nbsp</span>
                        </div>
                        <div class="row m-b out">
                            <span>Áp lực trước</span>
                            <asp:RadioButton ID="rdoPress4" runat="server" GroupName="Channel4" CssClass="radiob" />
                        </div>
                    </div>
                </div>
                 <div class="col-sm-1 no-padding">
                     <div class="group-text change-size">
                          <div class="row">
                            <span>&nbsp</span>
                        </div>
                        <div class="row m-b out">
                            <span>Áp lực sau</span>
                            <asp:RadioButton ID="rdoPress11" runat="server" GroupName="Channel1" CssClass="radiob" />
                        </div>
                    </div>
                     <div class="group-text change-size">
                          <div class="row">
                            <span>&nbsp</span>
                        </div>
                        <div class="row m-b out">
                            <span>Áp lực sau</span>
                            <asp:RadioButton ID="rdoPress12" runat="server" GroupName="Channel2" CssClass="radiob" />
                        </div>
                    </div>
                     <div class="group-text change-size">
                          <div class="row">
                            <span>&nbsp</span>
                        </div>
                        <div class="row m-b out">
                            <span>Áp lực sau</span>
                            <asp:RadioButton ID="rdoPress13" runat="server" GroupName="Channel3" CssClass="radiob" />
                        </div>
                    </div>
                     <div class="group-text change-size">
                          <div class="row">
                            <span>&nbsp</span>
                        </div>
                        <div class="row m-b out">
                            <span>Áp lực sau</span>
                            <asp:RadioButton ID="rdoPress14" runat="server" GroupName="Channel4" CssClass="radiob" />
                        </div>
                    </div>
                </div>
                 <div class="col-sm-2">
                      <div class="group-text change-size">
                           <div class="row">
                            <span>&nbsp</span>
                        </div>
                        <div class="row m-b out">
                            <span>Lưu lượng thuận</span>
                            <asp:RadioButton ID="rdoForwardFlow1" runat="server" GroupName="Channel1" CssClass="radiob" />
                        </div>
                    </div>
                     <div class="group-text change-size">
                          <div class="row">
                            <span>&nbsp</span>
                        </div>
                        <div class="row m-b out">
                            <span>Lưu lượng thuận</span>
                            <asp:RadioButton ID="rdoForwardFlow2" runat="server" GroupName="Channel2" CssClass="radiob" />
                        </div>
                    </div>
                     <div class="group-text change-size">
                          <div class="row">
                            <span>&nbsp</span>
                        </div>
                        <div class="row m-b out">
                            <span>Lưu lượng thuận</span>
                            <asp:RadioButton ID="rdoForwardFlow3" runat="server" GroupName="Channel3" CssClass="radiob" />
                        </div>
                    </div>
                     <div class="group-text change-size">
                          <div class="row">
                            <span>&nbsp</span>
                        </div> 
                        <div class="row m-b out">
                            <span>Lưu lượng thuận</span>
                            <asp:RadioButton ID="rdoForwardFlow4" runat="server" GroupName="Channel4" CssClass="radiob" />
                        </div>
                    </div>
                </div>
                 <div class="col-sm-2">
                     <div class="group-text change-size">
                          <div class="row">
                            <span>&nbsp</span>
                        </div>
                        <div class="row m-b out" >
                            <span>Lưu lượng nghịch</span>
                            <asp:RadioButton ID="rdoReverseFlow1" runat="server" GroupName="Channel1" CssClass="radiob" />
                        </div>
                    </div>
                     <div class="group-text change-size">
                          <div class="row">
                            <span>&nbsp</span>
                        </div>
                        <div class="row m-b out">
                            <span>Lưu lượng nghịch</span>
                            <asp:RadioButton ID="rdoReverseFlow2" runat="server" GroupName="Channel2" CssClass="radiob" />
                        </div>
                    </div>
                     <div class="group-text change-size">
                          <div class="row ">
                            <span>&nbsp</span>
                        </div>
                        <div class="row m-b out">
                            <span>Lưu lượng nghịch</span>
                            <asp:RadioButton ID="rdoReverseFlow3" runat="server" GroupName="Channel3" CssClass="radiob" />
                        </div>
                    </div>
                     <div class="group-text change-size">
                          <div class="row">
                            <span>&nbsp</span>
                        </div>
                        <div class="row m-b out">
                            <span>Lưu lượng nghịch</span>
                            <asp:RadioButton ID="rdoReverseFlow4" runat="server" GroupName="Channel4" CssClass="radiob" />
                        </div>
                    </div>

                </div>
            </div>

             <div class="text-center col-sm-12 m-t m-b no-padding" style="clear: both;">
                <asp:Button ID="btnAdd" runat="server" Text="Thêm/Sửa"
                    OnClick="btnAdd_Click" CssClass="btn btn-success"></asp:Button>
                <asp:Button ID="btnDelete" runat="server"
                    OnClick="btnDelete_Click" Text="Xóa cấu hình" 
                    CssClass="btn btn-danger"></asp:Button>
            </div>

        </div>
    </div>
    <telerik:RadNotification ID="ntf" runat="server"></telerik:RadNotification>
    <telerik:RadAjaxManagerProxy ID="RadAjaxManagerProxy1" runat="server">
        <AjaxSettings>
            <telerik:AjaxSetting AjaxControlID="cboSiteIds">
                <UpdatedControls>
                    <telerik:AjaxUpdatedControl ControlID="txtLoggerId" />
                    <telerik:AjaxUpdatedControl ControlID="nmrInterval" />
                    <telerik:AjaxUpdatedControl ControlID="tmStart" />
                    <telerik:AjaxUpdatedControl ControlID="txtChannelId1" />
                    <telerik:AjaxUpdatedControl ControlID="txtChannelName1" />
                    <telerik:AjaxUpdatedControl ControlID="cboUnit1" />
                    <telerik:AjaxUpdatedControl ControlID="rdoPress1" />
                    <telerik:AjaxUpdatedControl ControlID="rdoPress11" />
                    <telerik:AjaxUpdatedControl ControlID="rdoForwardFlow1" />
                    <telerik:AjaxUpdatedControl ControlID="rdoReverseFlow1" />
                    <telerik:AjaxUpdatedControl ControlID="txtChannelId2" />
                    <telerik:AjaxUpdatedControl ControlID="txtChannelName2" />
                    <telerik:AjaxUpdatedControl ControlID="cboUnit2" />
                    <telerik:AjaxUpdatedControl ControlID="rdoPress2" />
                    <telerik:AjaxUpdatedControl ControlID="rdoPress12" />
                    <telerik:AjaxUpdatedControl ControlID="rdoForwardFlow2" />
                    <telerik:AjaxUpdatedControl ControlID="rdoReverseFlow2" />
                    <telerik:AjaxUpdatedControl ControlID="txtChannelId3" />
                    <telerik:AjaxUpdatedControl ControlID="txtChannelName3" />
                    <telerik:AjaxUpdatedControl ControlID="cboUnit3" />
                    <telerik:AjaxUpdatedControl ControlID="rdoPress3" />
                    <telerik:AjaxUpdatedControl ControlID="rdoPress13" />
                    <telerik:AjaxUpdatedControl ControlID="rdoForwardFlow3" />
                    <telerik:AjaxUpdatedControl ControlID="rdoReverseFlow3" />
                    <telerik:AjaxUpdatedControl ControlID="txtChannelId4" />
                    <telerik:AjaxUpdatedControl ControlID="txtChannelName4" />
                    <telerik:AjaxUpdatedControl ControlID="cboUnit4" />
                    <telerik:AjaxUpdatedControl ControlID="rdoPress4" />
                    <telerik:AjaxUpdatedControl ControlID="rdoPress14" />
                    <telerik:AjaxUpdatedControl ControlID="rdoForwardFlow4" />
                    <telerik:AjaxUpdatedControl ControlID="rdoReverseFlow4" />
                </UpdatedControls>
            </telerik:AjaxSetting>
            <telerik:AjaxSetting AjaxControlID="btnAdd">
                <UpdatedControls>
                    <telerik:AjaxUpdatedControl ControlID="ntf" />
                    <telerik:AjaxUpdatedControl ControlID="cboSiteIds" />
                    <telerik:AjaxUpdatedControl ControlID="txtLoggerId" />
                    <telerik:AjaxUpdatedControl ControlID="nmrInterval" />
                    <telerik:AjaxUpdatedControl ControlID="tmStart" />
                    <telerik:AjaxUpdatedControl ControlID="txtChannelId1" />
                    <telerik:AjaxUpdatedControl ControlID="txtChannelName1" />
                    <telerik:AjaxUpdatedControl ControlID="cboUnit1" />
                    <telerik:AjaxUpdatedControl ControlID="rdoPress1" />
                    <telerik:AjaxUpdatedControl ControlID="rdoPress11" />
                    <telerik:AjaxUpdatedControl ControlID="rdoForwardFlow1" />
                    <telerik:AjaxUpdatedControl ControlID="rdoReverseFlow1" />
                    <telerik:AjaxUpdatedControl ControlID="txtChannelId2" />
                    <telerik:AjaxUpdatedControl ControlID="txtChannelName2" />
                    <telerik:AjaxUpdatedControl ControlID="cboUnit2" />
                    <telerik:AjaxUpdatedControl ControlID="rdoPress2" />
                    <telerik:AjaxUpdatedControl ControlID="rdoPress12" />
                    <telerik:AjaxUpdatedControl ControlID="rdoForwardFlow2" />
                    <telerik:AjaxUpdatedControl ControlID="rdoReverseFlow2" />
                    <telerik:AjaxUpdatedControl ControlID="txtChannelId3" />
                    <telerik:AjaxUpdatedControl ControlID="txtChannelName3" />
                    <telerik:AjaxUpdatedControl ControlID="cboUnit3" />
                    <telerik:AjaxUpdatedControl ControlID="rdoPress3" />
                    <telerik:AjaxUpdatedControl ControlID="rdoPress13" />
                    <telerik:AjaxUpdatedControl ControlID="rdoForwardFlow3" />
                    <telerik:AjaxUpdatedControl ControlID="rdoReverseFlow3" />
                    <telerik:AjaxUpdatedControl ControlID="txtChannelId4" />
                    <telerik:AjaxUpdatedControl ControlID="txtChannelName4" />
                    <telerik:AjaxUpdatedControl ControlID="cboUnit4" />
                    <telerik:AjaxUpdatedControl ControlID="rdoPress4" />
                    <telerik:AjaxUpdatedControl ControlID="rdoPress14" />
                    <telerik:AjaxUpdatedControl ControlID="rdoForwardFlow4" />
                    <telerik:AjaxUpdatedControl ControlID="rdoReverseFlow4" />
                </UpdatedControls>
            </telerik:AjaxSetting>
            <telerik:AjaxSetting AjaxControlID="btnDelete">
                <UpdatedControls>
                    <telerik:AjaxUpdatedControl ControlID="ntf" />
                    <telerik:AjaxUpdatedControl ControlID="cboSiteIds" />
                    <telerik:AjaxUpdatedControl ControlID="txtLoggerId" />
                    <telerik:AjaxUpdatedControl ControlID="nmrInterval" />
                    <telerik:AjaxUpdatedControl ControlID="tmStart" />
                    <telerik:AjaxUpdatedControl ControlID="txtChannelId1" />
                    <telerik:AjaxUpdatedControl ControlID="txtChannelName1" />
                    <telerik:AjaxUpdatedControl ControlID="cboUnit1" />
                    <telerik:AjaxUpdatedControl ControlID="rdoPress1" />
                    <telerik:AjaxUpdatedControl ControlID="rdoPress11" />
                    <telerik:AjaxUpdatedControl ControlID="rdoForwardFlow1" />
                    <telerik:AjaxUpdatedControl ControlID="rdoReverseFlow1" />
                    <telerik:AjaxUpdatedControl ControlID="txtChannelId2" />
                    <telerik:AjaxUpdatedControl ControlID="txtChannelName2" />
                    <telerik:AjaxUpdatedControl ControlID="cboUnit2" />
                    <telerik:AjaxUpdatedControl ControlID="rdoPress2" />
                    <telerik:AjaxUpdatedControl ControlID="rdoPress12" />
                    <telerik:AjaxUpdatedControl ControlID="rdoForwardFlow2" />
                    <telerik:AjaxUpdatedControl ControlID="rdoReverseFlow2" />
                    <telerik:AjaxUpdatedControl ControlID="txtChannelId3" />
                    <telerik:AjaxUpdatedControl ControlID="txtChannelName3" />
                    <telerik:AjaxUpdatedControl ControlID="cboUnit3" />
                    <telerik:AjaxUpdatedControl ControlID="rdoPress3" />
                    <telerik:AjaxUpdatedControl ControlID="rdoPress13" />
                    <telerik:AjaxUpdatedControl ControlID="rdoForwardFlow3" />
                    <telerik:AjaxUpdatedControl ControlID="rdoReverseFlow3" />
                    <telerik:AjaxUpdatedControl ControlID="txtChannelId4" />
                    <telerik:AjaxUpdatedControl ControlID="txtChannelName4" />
                    <telerik:AjaxUpdatedControl ControlID="cboUnit4" />
                    <telerik:AjaxUpdatedControl ControlID="rdoPress4" />
                    <telerik:AjaxUpdatedControl ControlID="rdoPress14" />
                    <telerik:AjaxUpdatedControl ControlID="rdoForwardFlow4" />
                    <telerik:AjaxUpdatedControl ControlID="rdoReverseFlow4" />
                </UpdatedControls>
            </telerik:AjaxSetting>
        </AjaxSettings>
    </telerik:RadAjaxManagerProxy>
</asp:Content>

