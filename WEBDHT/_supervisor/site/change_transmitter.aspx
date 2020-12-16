<%@ Page Title="" Language="C#" MasterPageFile="~/_supervisor/master_page.master" AutoEventWireup="true" CodeFile="change_transmitter.aspx.cs" Inherits="_supervisor_site_change_transmitter" %>

<asp:Content ID="Content1" ContentPlaceHolderID="head" Runat="Server">
    <link href="../../css/Config.css" rel="stylesheet">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" Runat="Server">
<telerik:RadCodeBlock ID="RadCodeBlock1" runat="server">
    <script type="text/javascript">
        //<![CDATA[

        function btnDelete_Clicked() {
            var win = $find('<%=winConfirmDelete.ClientID %>');
            win.show();
        }
//]]>
    </script>
        <script type="text/javascript">
            //<![CDATA[

            function btnCancel_Clicked() {
                var win = $find('<%=winConfirmDelete.ClientID %>');
                win.close();
            }

            // preventing resubmition form application
            window.history.replaceState('', '', window.location.href)
//]]>
        </script>
    </telerik:RadCodeBlock>
<div id="main-content2">    
    <div id="main-content-title">
            <h2 class="title">Thay bộ hiển thị</h2>
        </div>
        <div class="container-fluid m-t">
            <div class="row">
                <div class="col-sm-6">
                    <div class="group-text">
                        <div class="row">
                            <span>Điểm lắp đặt</span>
                        </div>
                        <div class="row m-b">
                            <telerik:RadComboBox ID="cboSiteIds" Runat="server"
                                DataSourceID="SiteIdDataSource" DataTextField="Id" DataValueField="Id" 
                                AllowCustomText="True" DropDownWidth="350px" EnableLoadOnDemand="True" 
                                Filter="StartsWith" HighlightTemplatedItems="True" >
                                <HeaderTemplate>
                                    <table cellpadding="0" cellspacing="0">
                                        <tr>
                                            <td style="width:50px">Mã NV</td>
                                            <td style="width:50px">Mã vị trí</td>
                                            <td style="width:250px">Vị trí</td>
                                        </tr>
                                    </table>
                                </HeaderTemplate>
                                <ItemTemplate>
                                    <table cellpadding="0" cellspacing="0">
                                        <tr>
                                            <td style="width:50px"><%#DataBinder.Eval(Container.DataItem,"StaffId") %></td>
                                            <td style="width:50px"><%#DataBinder.Eval(Container.DataItem,"Id") %></td>
                                            <td style="width:250px"><%#DataBinder.Eval(Container.DataItem,"Location") %></td>
                                        </tr>
                                    </table>
                                </ItemTemplate>
                            </telerik:RadComboBox>
                            <asp:ObjectDataSource ID="SiteIdDataSource" runat="server" 
                                OldValuesParameterFormatString="original_{0}" SelectMethod="GetAll" 
                                TypeName="SitesBLL"></asp:ObjectDataSource>
                        </div>
                    </div>
                    <div class="group-text">
                        <div class="row">
                            <span>Serial cũ</span>
                        </div>
                        <div class="row m-b">
                            <telerik:RadComboBox ID="cboOldSerials" Runat="server" 
                                DataSourceID="TransmittersDataSource" DataTextField="Serial" 
                                DataValueField="Serial" AllowCustomText="True" EnableLoadOnDemand="True" 
                                Filter="StartsWith" HighlightTemplatedItems="True" DropDownWidth="300px">
                                <HeaderTemplate>
                                        <table cellpadding="0" cellspacing="0">
                                            <tr>
                                                <td style="width:175px">Serial</td>
                                                <td style="width:75px">Hiệu</td>
                                                <td style="width:50px">Cỡ</td>
                                            </tr>
                                        </table>
                                    </HeaderTemplate>
                                    <ItemTemplate>
                                        <table cellpadding="0" cellspacing="0">
                                            <tr>
                                                <td style="width:175px"><%#DataBinder.Eval(Container.DataItem,"Serial") %></td>
                                                <td style="width:75px"><%#DataBinder.Eval(Container.DataItem,"Marks") %></td>
                                                <td style="width:50px"><%#DataBinder.Eval(Container.DataItem,"Size") %></td>
                                            </tr>
                                        </table
                                    </ItemTemplate>
                            </telerik:RadComboBox>
                           <asp:ObjectDataSource ID="TransmittersDataSource" runat="server" 
                                OldValuesParameterFormatString="original_{0}" SelectMethod="GetAllByInstalled" 
                                TypeName="TransmittersBLL">
                                <SelectParameters>
                                    <asp:Parameter DefaultValue="true" Name="installed" Type="Boolean" />
                                </SelectParameters>
                            </asp:ObjectDataSource>
                        </div>
                    </div>
                    <div class="group-text">
                        <div class="row">
                            <span>Chỉ số cũ</span>
                        </div>
                        <div class="row m-b">
                            <telerik:RadNumericTextBox ID="nmrOldIndex" Runat="server">
                                <NumberFormat ZeroPattern="n" DecimalDigits="0"></NumberFormat>
                            </telerik:RadNumericTextBox>
                        </div>
                    </div>
                    <div class="group-text">
                        <div class="row">
                            <span>Ghi chú</span>
                        </div>
                        <div class="row m-b">
                            <telerik:RadTextBox ID="txtDescription" Runat="server" TextMode="MultiLine">
                            </telerik:RadTextBox>
                        </div>
                    </div>
                </div>

                <div class="col-sm-6">
                    <div class="group-text">
                        <div class="row">
                            <span>Ngày thay</span>
                        </div>
                        <div class="row m-b">
                            <telerik:RadDatePicker ID="dtmDateChanged" Runat="server" Culture="en-GB">
                                <Calendar UseColumnHeadersAsSelectors="False" UseRowHeadersAsSelectors="False" 
                                    ViewSelectorText="x">
                                </Calendar>
                                <DateInput DateFormat="dd/MM/yyyy" DisplayDateFormat="dd/MM/yyyy" 
                                    EnableSingleInputRendering="True" LabelWidth="64px">
                                </DateInput>
                                <DatePopupButton HoverImageUrl="" ImageUrl="" TabIndex="-1" />
                            </telerik:RadDatePicker>
                        </div>
                    </div>
                    <div class="group-text">
                        <div class="row">
                            <span>Serial mới</span>
                        </div>
                        <div class="row m-b">
                            <telerik:RadComboBox ID="cboNewSerials" Runat="server" 
                                DataSourceID="TransmittersDataSource1" DataTextField="Serial" 
                                DataValueField="Serial" AllowCustomText="True" EnableLoadOnDemand="True" 
                                Filter="StartsWith" HighlightTemplatedItems="True" DropDownWidth="300px">
                                <HeaderTemplate>
                                        <table cellpadding="0" cellspacing="0">
                                            <tr>
                                                <td style="width:175px">Serial</td>
                                                <td style="width:75px">Hiệu</td>
                                                <td style="width:50px">Cỡ</td>
                                            </tr>
                                        </table>
                                    </HeaderTemplate>
                                    <ItemTemplate>
                                        <table cellpadding="0" cellspacing="0">
                                            <tr>
                                                <td style="width:175px"><%#DataBinder.Eval(Container.DataItem,"Serial") %></td>
                                                <td style="width:75px"><%#DataBinder.Eval(Container.DataItem,"Marks") %></td>
                                                <td style="width:50px"><%#DataBinder.Eval(Container.DataItem,"Size") %></td>
                                            </tr>
                                        </table
                                    </ItemTemplate>
                            </telerik:RadComboBox>
                           <asp:ObjectDataSource ID="TransmittersDataSource1" runat="server" 
                                OldValuesParameterFormatString="original_{0}" SelectMethod="GetAllByInstalled" 
                                TypeName="TransmittersBLL">
                                <SelectParameters>
                                    <asp:Parameter DefaultValue="false" Name="installed" Type="Boolean" />
                                </SelectParameters>
                            </asp:ObjectDataSource>
                        </div>
                    </div>
                    <div class="group-text">
                        <div class="row">
                            <span>Chỉ số mới</span>
                        </div>
                        <div class="row m-b">
                            <telerik:RadNumericTextBox ID="nmrNewIndex" Runat="server">
                                <NumberFormat ZeroPattern="n" DecimalDigits="0"></NumberFormat>
                            </telerik:RadNumericTextBox>
                        </div>
                    </div>
                </div>
            </div>
            <div class="text-center col-sm-12 m-t m-b no-padding" style="clear: both;">
                <asp:Button ID="btnSubmit" runat="server" Text="Thêm/Sửa [A]"
                    OnClick="btnSubmit_Click" CssClass="btn btn-success" AccessKey="A"></asp:Button>
                <asp:Button ID="btnDelete" runat="server"
                    OnClientClick="btnDelete_Clicked()" Text="Xóa" AutoPostBack="False"
                    CssClass="btn btn-danger"></asp:Button>
            </div>
        </div>
    </div>
    <telerik:RadWindow ID="winConfirmDelete" runat="server" Modal="True"
        VisibleStatusbar="False" Height="160">
        <ContentTemplate>
            <table width="100%" style="text-align: center">
                <tr>
                    <td>    Bạn có muốn xóa dữ liệu thay bộ hiển thị tại ngày đã chọn? Thao tác xóa không có tác dụng xóa hiện trạng bộ hiển thị, ngày thay bộ hiển thị của điểm lắp đặt cũng như trạng thái lắp đặt của 2 bộ hiển thị.                            
                    </td>
                </tr>
                <tr>
                    <td>&nbsp</td>
                </tr>
                <tr>
                    <td>
                        <asp:Button ID="btnConfim" runat="server" Text="Xóa"
                            onclick="btnConfim_Click" CssClass="btn btn-danger"></asp:Button>
                        <asp:Button ID="btnCancel" runat="server"
                            OnClientClick="btnCancel_Clicked()" CssClass="btn btn-success"
                            Text="Hủy thao tác" AutoPostBack="False"></asp:Button>
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
                    <telerik:AjaxUpdatedControl ControlID="cboOldSerials" />
                    <telerik:AjaxUpdatedControl ControlID="dtmDateChanged" />
                    <telerik:AjaxUpdatedControl ControlID="cboNewSerials" />
                    <telerik:AjaxUpdatedControl ControlID="nmrOldIndex" />
                    <telerik:AjaxUpdatedControl ControlID="nmrNewIndex" />
                    <telerik:AjaxUpdatedControl ControlID="txtDescription" />
                    
                </UpdatedControls>
            </telerik:AjaxSetting>
            <telerik:AjaxSetting AjaxControlID="btnSubmit">
                <UpdatedControls>
                    <telerik:AjaxUpdatedControl ControlID="ntf" />
                     <telerik:AjaxUpdatedControl ControlID="cboSiteIds" />
                    <telerik:AjaxUpdatedControl ControlID="cboOldSerials" />
                    <telerik:AjaxUpdatedControl ControlID="dtmDateChanged" />
                    <telerik:AjaxUpdatedControl ControlID="cboNewSerials" />
                    <telerik:AjaxUpdatedControl ControlID="nmrOldIndex" />
                    <telerik:AjaxUpdatedControl ControlID="nmrNewIndex" />
                    <telerik:AjaxUpdatedControl ControlID="txtDescription" />
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

