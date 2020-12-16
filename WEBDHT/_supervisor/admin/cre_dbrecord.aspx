<%@ Page Title="" Language="C#" MasterPageFile="~/_supervisor/master_page.master" AutoEventWireup="true" CodeFile="cre_dbrecord.aspx.cs" Inherits="_supervisor_admin_cre_dbrecord" %>

<asp:Content ID="Content1" ContentPlaceHolderID="head" Runat="Server">
    <style type="text/css">
        .style1
        {
            width: 100%;
            table-layout:fixed;
        }
    </style>
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" Runat="Server">
    <div id="main-content">
        <telerik:RadAjaxPanel ID="RadAjaxPanel1" runat="server">
        <div id="main-content-title">
            <h2>Thêm mới record database</h2>
            <hr class="line" />
            </div>
        <div id="main-content-text">
            <telerik:RadPanelBar ID="RadPanelBar1" runat="server" Width="100%" 
                AllowCollapseAllItems="True" ExpandMode="SingleExpandedItem" >
            <Items>
                <telerik:RadPanelItem runat="server" Text="Cấp điểm lắp đặt" Expanded="true">
                    <ContentTemplate>
                        <table class="style1">
                            <tr>
                                <td>Cấp điểm lắp đặt:</td>
                                <td>Cấp:</td>
                                <td>Mô tả:</td>
                                <td>&nbsp</td>
                            </tr>
                            <tr>
                                <td>
                                    <telerik:RadComboBox ID="cboLevels" runat="server" AllowCustomText="true" AutoPostBack="true" 
                                        DataTextField="Level" DataValueField="Description" 
                                        Filter="StartsWith" HighlightTemplatedItems="True" OnSelectedIndexChanged="cboLevels_SelectedIndexChanged" DataSourceID="LevelsDataSource">
                                        <HeaderTemplate>
                                            <table  cellpadding="0" cellspacing="0">
                                                <tr>
                                                    <td style="width: 70px">Cấp ĐH</td>
                                                    <td style="width: 60px">Mô tả</td>
                                                </tr>
                                            </table>
                                        </HeaderTemplate>
                                        <ItemTemplate>
                                            <table cellpadding="0" cellspacing="0">
                                                <tr>
                                                    <td style="width: 70px"><%#DataBinder.Eval(Container.DataItem,"Level") %></td>
                                                    <td style="width: 60px"><%#DataBinder.Eval(Container.DataItem,"Description") %></td>
                                                </tr>
                                            </table>
                                        </ItemTemplate>
                                    </telerik:RadComboBox>
                                     <asp:ObjectDataSource ID="LevelsDataSource" runat="server" 
                                        OldValuesParameterFormatString="original_{0}" SelectMethod="GetAll" 
                                        TypeName="SiteLevelsBLL"></asp:ObjectDataSource>
                                </td>
                                <td>
                                    <telerik:RadTextBox ID="txtLevel" runat="server">
                                    </telerik:RadTextBox>
                                </td>
                                <td>
                                    <telerik:RadTextBox ID="txtLevelDescription" runat="server">
                                    </telerik:RadTextBox>
                                </td>
                                <td>
                                    <telerik:RadButton ID="btnLevelAdd" runat="server" Text="Thêm/Sửa" OnClick="btnLevelAdd_Click" >
                                    </telerik:RadButton>
                                    <telerik:RadButton ID="btnLevelDelete" runat="server" Text="Xóa" OnClick="btnLevelDelete_Click">
                                    </telerik:RadButton>
                                </td>
                            </tr>
                        </table>
                    </ContentTemplate>
                </telerik:RadPanelItem>
                <telerik:RadPanelItem runat="server" Text="Nhóm điểm lắp đặt" Expanded="True">
                    <ContentTemplate>
                        <table class="style1">
                            <tr>
                                <td>Nhóm điểm lắp đặt:</td>
                                <td>Nhóm:</td>
                                <td>Mô tả:</td>
                                <td>&nbsp</td>
                            </tr>
                            <tr>
                                <td>
                                    <telerik:RadComboBox ID="cboGroups" runat="server" AllowCustomText="true" OnSelectedIndexChanged="cboGroups_SelectedIndexChanged"
                                        AutoPostBack="true" DropDownWidth="280px"
                                        DataValueField="Description" Filter="StartsWith" HighlightTemplatedItems="True" DataSourceID="GroupsDataSource" DataTextField="Group">
                                        <HeaderTemplate>
                                            <table cellpadding="0" cellspacing="0">
                                                <tr>
                                                    <td style="width: 80px">Nhóm ĐH</td>
                                                    <td style="width: 200px">Mô tả</td>
                                                </tr>
                                            </table>
                                        </HeaderTemplate>
                                        <ItemTemplate>
                                            <table cellpadding="0" cellspacing="0">
                                                <tr>
                                                    <td style="width: 80px"><%#DataBinder.Eval(Container.DataItem,"Group") %></td>
                                                    <td style="width: 200px"><%#DataBinder.Eval(Container.DataItem,"Description") %></td>
                                                </tr>
                                            </table>
                                        </ItemTemplate>
                                    </telerik:RadComboBox>
                                    <asp:ObjectDataSource ID="GroupsDataSource" runat="server" 
                                        OldValuesParameterFormatString="original_{0}" SelectMethod="GetAll" 
                                        TypeName="SiteGroupsBLL"></asp:ObjectDataSource>
                                </td>
                                <td>
                                    <telerik:RadTextBox ID="txtGroup" runat="server">
                                    </telerik:RadTextBox>
                                </td>
                                <td>
                                    <telerik:RadTextBox ID="txtGroupDescription" runat="server">
                                    </telerik:RadTextBox>
                                </td>
                                <td>
                                    <telerik:RadButton ID="btnGroupAdd" runat="server" Text="Thêm/Sửa" OnClick="btnGroupAdd_Click" >
                                    </telerik:RadButton>
                                    <telerik:RadButton ID="btnGroupDelete" runat="server" Text="Xóa"  OnClick="btnGroupDelete_Click">
                                    </telerik:RadButton>
                                </td>
                            </tr>
                        </table>
                    </ContentTemplate>
                </telerik:RadPanelItem>
                <telerik:RadPanelItem runat="server" Text="Nhóm điểm lắp đặt 2" Expanded="True">
                    <ContentTemplate>
                        <table class="style1">
                            <tr>
                                <td>Nhóm điểm lắp đặt:</td>
                                <td>Nhóm:</td>
                                <td>Mô tả:</td>
                                <td>&nbsp</td>
                            </tr>
                            <tr>
                                <td>
                                    <telerik:RadComboBox ID="cboGroup2s" runat="server" AllowCustomText="true" OnSelectedIndexChanged="cboGroup2s_SelectedIndexChanged"
                                        AutoPostBack="true" DropDownWidth="280px"
                                        DataValueField="Description" Filter="StartsWith" HighlightTemplatedItems="True" DataSourceID="Group2sDataSource" DataTextField="Group">
                                        <HeaderTemplate>
                                            <table cellpadding="0" cellspacing="0">
                                                <tr>
                                                    <td style="width: 80px">Nhóm ĐH</td>
                                                    <td style="width: 280px">Mô tả</td>
                                                </tr>
                                            </table>
                                        </HeaderTemplate>
                                        <ItemTemplate>
                                            <table cellpadding="0" cellspacing="0">
                                                <tr>
                                                    <td style="width: 80px"><%#DataBinder.Eval(Container.DataItem,"Group") %></td>
                                                    <td style="width: 280px"><%#DataBinder.Eval(Container.DataItem,"Description") %></td>
                                                </tr>
                                            </table>
                                        </ItemTemplate>
                                    </telerik:RadComboBox>
                                    <asp:ObjectDataSource ID="Group2sDataSource" runat="server" 
                                        OldValuesParameterFormatString="original_{0}" SelectMethod="GetAll" 
                                        TypeName="SiteGroup2sBLL"></asp:ObjectDataSource>
                                </td>
                                <td>
                                    <telerik:RadTextBox ID="txtGroup2" runat="server">
                                    </telerik:RadTextBox>
                                </td>
                                <td>
                                    <telerik:RadTextBox ID="txtGroup2Description" runat="server">
                                    </telerik:RadTextBox>
                                </td>
                                <td>
                                    <telerik:RadButton ID="btnGroup2Add" runat="server" Text="Thêm/Sửa" OnClick="btnGroup2Add_Click" >
                                    </telerik:RadButton>
                                    <telerik:RadButton ID="btnGroup2Delete" runat="server" Text="Xóa"  OnClick="btnGroup2Delete_Click">
                                    </telerik:RadButton>
                                </td>
                            </tr>
                        </table>
                    </ContentTemplate>
                </telerik:RadPanelItem>

                <telerik:RadPanelItem runat="server" Text="Nhóm điểm lắp đặt 3" Expanded="True">
                    <ContentTemplate>
                        <table class="style1">
                            <tr>
                                <td>Nhóm điểm lắp đặt:</td>
                                <td>Nhóm:</td>
                                <td>Mô tả:</td>
                                <td>&nbsp</td>
                            </tr>
                            <tr>
                                <td>
                                    <telerik:RadComboBox ID="cboGroup3s" runat="server" AllowCustomText="true" OnSelectedIndexChanged="cboGroup3s_SelectedIndexChanged"
                                        AutoPostBack="true" DropDownWidth="280px"
                                        DataValueField="Description" Filter="StartsWith" HighlightTemplatedItems="True" DataSourceID="Group3sDataSource" DataTextField="Group">
                                        <HeaderTemplate>
                                            <table cellpadding="0" cellspacing="0">
                                                <tr>
                                                    <td style="width: 80px">Nhóm ĐH</td>
                                                    <td style="width: 280px">Mô tả</td>
                                                </tr>
                                            </table>
                                        </HeaderTemplate>
                                        <ItemTemplate>
                                            <table cellpadding="0" cellspacing="0">
                                                <tr>
                                                    <td style="width: 80px"><%#DataBinder.Eval(Container.DataItem,"Group") %></td>
                                                    <td style="width: 280px"><%#DataBinder.Eval(Container.DataItem,"Description") %></td>
                                                </tr>
                                            </table>
                                        </ItemTemplate>
                                    </telerik:RadComboBox>
                                    <asp:ObjectDataSource ID="Group3sDataSource" runat="server" 
                                        OldValuesParameterFormatString="original_{0}" SelectMethod="GetAll" 
                                        TypeName="SiteGroup3sBLL"></asp:ObjectDataSource>
                                </td>
                                <td>
                                    <telerik:RadTextBox ID="txtGroup3" runat="server">
                                    </telerik:RadTextBox>
                                </td>
                                <td>
                                    <telerik:RadTextBox ID="txtGroup3Description" runat="server">
                                    </telerik:RadTextBox>
                                </td>
                                <td>
                                    <telerik:RadButton ID="btnGroup3Add" runat="server" Text="Thêm/Sửa" OnClick="btnGroup3Add_Click" >
                                    </telerik:RadButton>
                                    <telerik:RadButton ID="btnGroup3Delete" runat="server" Text="Xóa"  OnClick="btnGroup3Delete_Click">
                                    </telerik:RadButton>
                                </td>
                            </tr>
                        </table>
                    </ContentTemplate>
                </telerik:RadPanelItem>

                <telerik:RadPanelItem runat="server" Text="Nhóm điểm lắp đặt 4" Expanded="True">
                    <ContentTemplate>
                        <table class="style1">
                            <tr>
                                <td>Nhóm điểm lắp đặt:</td>
                                <td>Nhóm:</td>
                                <td>Mô tả:</td>
                                <td>&nbsp</td>
                            </tr>
                            <tr>
                                <td>
                                    <telerik:RadComboBox ID="cboGroup4s" runat="server" AllowCustomText="true" OnSelectedIndexChanged="cboGroup4s_SelectedIndexChanged"
                                        AutoPostBack="true" DropDownWidth="280px"
                                        DataValueField="Description" Filter="StartsWith" HighlightTemplatedItems="True" DataSourceID="Group4sDataSource" DataTextField="Group">
                                        <HeaderTemplate>
                                            <table cellpadding="0" cellspacing="0">
                                                <tr>
                                                    <td style="width: 80px">Nhóm ĐH</td>
                                                    <td style="width: 280px">Mô tả</td>
                                                </tr>
                                            </table>
                                        </HeaderTemplate>
                                        <ItemTemplate>
                                            <table cellpadding="0" cellspacing="0">
                                                <tr>
                                                    <td style="width: 80px"><%#DataBinder.Eval(Container.DataItem,"Group") %></td>
                                                    <td style="width: 280px"><%#DataBinder.Eval(Container.DataItem,"Description") %></td>
                                                </tr>
                                            </table>
                                        </ItemTemplate>
                                    </telerik:RadComboBox>
                                    <asp:ObjectDataSource ID="Group4sDataSource" runat="server" 
                                        OldValuesParameterFormatString="original_{0}" SelectMethod="GetAll" 
                                        TypeName="SiteGroup4sBLL"></asp:ObjectDataSource>
                                </td>
                                <td>
                                    <telerik:RadTextBox ID="txtGroup4" runat="server">
                                    </telerik:RadTextBox>
                                </td>
                                <td>
                                    <telerik:RadTextBox ID="txtGroup4Description" runat="server">
                                    </telerik:RadTextBox>
                                </td>
                                <td>
                                    <telerik:RadButton ID="btnGroup4Add" runat="server" Text="Thêm/Sửa" OnClick="btnGroup4Add_Click" >
                                    </telerik:RadButton>
                                    <telerik:RadButton ID="btnGroup4Delete" runat="server" Text="Xóa"  OnClick="btnGroup4Delete_Click">
                                    </telerik:RadButton>
                                </td>
                            </tr>
                        </table>
                    </ContentTemplate>
                </telerik:RadPanelItem>

                <telerik:RadPanelItem runat="server" Text="Nhóm điểm lắp đặt 5" Expanded="True">
                    <ContentTemplate>
                        <table class="style1">
                            <tr>
                                <td>Nhóm điểm lắp đặt:</td>
                                <td>Nhóm:</td>
                                <td>Mô tả:</td>
                                <td>&nbsp</td>
                            </tr>
                            <tr>
                                <td>
                                    <telerik:RadComboBox ID="cboGroup5s" runat="server" AllowCustomText="true" OnSelectedIndexChanged="cboGroup5s_SelectedIndexChanged"
                                        AutoPostBack="true" DropDownWidth="280px"
                                        DataValueField="Description" Filter="StartsWith" HighlightTemplatedItems="True" DataSourceID="Group5sDataSource" DataTextField="Group">
                                        <HeaderTemplate>
                                            <table cellpadding="0" cellspacing="0">
                                                <tr>
                                                    <td style="width: 80px">Nhóm ĐH</td>
                                                    <td style="width: 280px">Mô tả</td>
                                                </tr>
                                            </table>
                                        </HeaderTemplate>
                                        <ItemTemplate>
                                            <table cellpadding="0" cellspacing="0">
                                                <tr>
                                                    <td style="width: 80px"><%#DataBinder.Eval(Container.DataItem,"Group") %></td>
                                                    <td style="width: 280px"><%#DataBinder.Eval(Container.DataItem,"Description") %></td>
                                                </tr>
                                            </table>
                                        </ItemTemplate>
                                    </telerik:RadComboBox>
                                    <asp:ObjectDataSource ID="Group5sDataSource" runat="server" 
                                        OldValuesParameterFormatString="original_{0}" SelectMethod="GetAll" 
                                        TypeName="SiteGroup5sBLL"></asp:ObjectDataSource>
                                </td>
                                <td>
                                    <telerik:RadTextBox ID="txtGroup5" runat="server">
                                    </telerik:RadTextBox>
                                </td>
                                <td>
                                    <telerik:RadTextBox ID="txtGroup5Description" runat="server">
                                    </telerik:RadTextBox>
                                </td>
                                <td>
                                    <telerik:RadButton ID="btnGroup5Add" runat="server" Text="Thêm/Sửa" OnClick="btnGroup5Add_Click" >
                                    </telerik:RadButton>
                                    <telerik:RadButton ID="btnGroup5Delete" runat="server" Text="Xóa"  OnClick="btnGroup5Delete_Click">
                                    </telerik:RadButton>
                                </td>
                            </tr>
                        </table>
                    </ContentTemplate>
                </telerik:RadPanelItem>

                <telerik:RadPanelItem runat="server" Text="Quản lý" Expanded="True">
                    <ContentTemplate>
                        <table class="style1">
                            <tr>
                                <td>Quản lý đồng hồ:</td>
                                <td>Quản lý:</td>
                                <td>Mô tả:</td>
                                <td>&nbsp</td>
                            </tr>
                            <tr>
                                <td>
                                     <telerik:RadComboBox ID="cboCompanies" runat="server" DropDownWidth="250" OnSelectedIndexChanged="cboCompanies_SelectedIndexChanged" 
                                        DataTextField="Company" AllowCustomText="true" AutoPostBack="true"
                                        DataValueField="Description" Filter="StartsWith" HighlightTemplatedItems="True" DataSourceID="CompaniesDataSource">
                                        <HeaderTemplate>
                                            <table cellpadding="0" cellspacing="0">
                                                <tr>
                                                    <td style="width: 50px">Công ty</td>
                                                    <td style="width: 200px">Mô tả</td>
                                                </tr>
                                            </table>
                                        </HeaderTemplate>
                                        <ItemTemplate>
                                            <table cellpadding="0" cellspacing="0">
                                                <tr>
                                                    <td style="width: 50px"><%#DataBinder.Eval(Container.DataItem,"Company") %></td>
                                                    <td style="width: 200px"><%#DataBinder.Eval(Container.DataItem,"Description") %>
                                                    </td>
                                                </tr>
                                            </table>
                                        </ItemTemplate>
                                    </telerik:RadComboBox>
                                    <asp:ObjectDataSource ID="CompaniesDataSource" runat="server" 
                                        OldValuesParameterFormatString="original_{0}" SelectMethod="GetAll" 
                                        StartRowIndexParameterName="" TypeName="SiteCompaniesBLL">
                                    </asp:ObjectDataSource>
                                </td>
                                <td>
                                    <telerik:RadTextBox ID="txtCompany" runat="server">
                                    </telerik:RadTextBox>
                                </td>
                                <td>
                                    <telerik:RadTextBox ID="txtCompanyDescription" runat="server">
                                    </telerik:RadTextBox>
                                </td>
                                <td>
                                    <telerik:RadButton ID="btnCompanyAdd" runat="server" Text="Thêm/Sửa" OnClick="btnCompanyAdd_Click">
                                    </telerik:RadButton>
                                    <telerik:RadButton ID="btnCompanyDelete" runat="server" Text="Xóa" OnClick="btnCompanyDelete_Click">
                                    </telerik:RadButton>
                                </td>
                            </tr>
                        </table>
                    </ContentTemplate>
                </telerik:RadPanelItem>
                <telerik:RadPanelItem runat="server" Text="Trạng thái điểm lắp đặt" 
                    Expanded="True">
                    <ContentTemplate>
                        <table class="style1">
                            <tr>
                                <td>Trạng thái điểm lắp đặt:</td>
                                <td>Trạng thái:</td>
                                <td>Mô tả:</td>
                                <td>&nbsp</td>
                            </tr>
                            <tr>
                                <td>
                                    <telerik:RadComboBox ID="cboStatus" runat="server"  AllowCustomText="true" OnSelectedIndexChanged="cboStatus_SelectedIndexChanged"
                                        DataTextField="Status" DropDownWidth="200" AutoPostBack="true" DataSourceID="StatusDataSource"
                                        DataValueField="Description" Filter="StartsWith" HighlightTemplatedItems="True">
                                        <HeaderTemplate>
                                            <table cellpadding="0" cellspacing="0">
                                                <tr>
                                                    <td style="width: 70px">Trạng thái</td>
                                                    <td style="width: 130px">Mô tả</td>
                                                </tr>
                                            </table>
                                        </HeaderTemplate>
                                        <ItemTemplate>
                                            <table cellpadding="0" cellspacing="0">
                                                <tr>
                                                    <td style="width: 70px"><%#DataBinder.Eval(Container.DataItem,"Status") %></td>
                                                    <td style="width: 130px"><%#DataBinder.Eval(Container.DataItem,"Description") %></td>
                                                </tr>
                                            </table>
                                        </ItemTemplate>
                                    </telerik:RadComboBox>
                                    <asp:ObjectDataSource ID="StatusDataSource" runat="server" 
                                        OldValuesParameterFormatString="original_{0}" SelectMethod="GetAll" 
                                        TypeName="SiteStatusBLL"></asp:ObjectDataSource>
                                </td>
                                <td>
                                    <telerik:RadTextBox ID="txtStatus" runat="server">
                                    </telerik:RadTextBox>
                                </td>
                                <td>
                                    <telerik:RadTextBox ID="txtStatusDescription" runat="server">
                                    </telerik:RadTextBox>
                                </td>
                                <td>
                                    <telerik:RadButton ID="btnStatusAdd" runat="server" Text="Thêm/Sửa" OnClick="btnStatusAdd_Click">
                                    </telerik:RadButton>
                                    <telerik:RadButton ID="btnStatusDelete" runat="server" Text="Xóa" OnClick="btnStatusDelete_Click">
                                    </telerik:RadButton>
                                </td>
                            </tr>
                        </table>
                    </ContentTemplate>
                </telerik:RadPanelItem>
                <telerik:RadPanelItem runat="server" Text="Tình trạng điểm lắp đặt" 
                    Expanded="True">
                    <ContentTemplate>
                        <table class="style1">
                            <tr>
                                <td>Tình trạng điểm lắp đặt:</td>
                                <td>Tình trạng:</td>
                                <td>Mô tả:</td>
                                <td>&nbsp</td>
                            </tr>
                            <tr>
                                <td>
                                    <telerik:RadComboBox ID="cboAvailabilities" runat="server" AllowCustomText="true" AutoPostBack="true"
                                        DataTextField="Availability" OnSelectedIndexChanged="cboAvailabilities_SelectedIndexChanged" 
                                        DataValueField="Description" Filter="StartsWith" DataSourceID="AvailabilitiesDataSource"
                                        HighlightTemplatedItems="True" DropDownWidth="190px">
                                        <HeaderTemplate>
                                            <table cellpadding="0" cellspacing="0">
                                                <tr>
                                                    <td style="width: 70px">Tình trạng</td>
                                                    <td style="width: 120px">Mô tả</td>
                                                </tr>
                                            </table>
                                        </HeaderTemplate>
                                        <ItemTemplate>
                                            <table cellpadding="0" cellspacing="0">
                                                <tr>
                                                    <td style="width: 70px"><%#DataBinder.Eval(Container.DataItem, "Availability")%></td>
                                                    <td style="width: 120px"><%#DataBinder.Eval(Container.DataItem,"Description") %></td>
                                                </tr>
                                            </table>
                                        </ItemTemplate>
                                    </telerik:RadComboBox>
                                    <asp:ObjectDataSource ID="AvailabilitiesDataSource" runat="server" 
                                        OldValuesParameterFormatString="original_{0}" SelectMethod="GetAll" 
                                        TypeName="SiteAvailabilitiesBLL"></asp:ObjectDataSource>
                                </td>
                                <td>
                                    <telerik:RadTextBox ID="txtAvailability" runat="server">
                                    </telerik:RadTextBox>
                                </td>
                                <td>
                                    <telerik:RadTextBox ID="txtAvailabilityDescription" runat="server">
                                    </telerik:RadTextBox>
                                </td>
                                <td>
                                    <telerik:RadButton ID="btnAvailabilityAdd" runat="server" Text="Thêm/Sửa" OnClick="btnAvailabilityAdd_Click">
                                    </telerik:RadButton>
                                    <telerik:RadButton ID="btnAvailabilityDelete" runat="server" Text="Xóa" OnClick="btnAvailabilityDelete_Click">
                                    </telerik:RadButton>
                                </td>
                            </tr>
                        </table>
                    </ContentTemplate>
                </telerik:RadPanelItem>
                <telerik:RadPanelItem Text="Tình trạng thiết bị" Expanded="True">
                    <ContentTemplate>
                        <table class="style1">
                            <tr>
                                <td>Tình trạng thiết bị:</td>
                                <td>Tình trạng:</td>
                                <td>Mô tả:</td>
                                <td>&nbsp</td>
                            </tr>
                            <tr>
                                <td>
                                    <telerik:RadComboBox ID="cboStatusDevice" runat="server" AllowCustomText="True" AutoPostBack="true"
                                        DataTextField="Status" OnSelectedIndexChanged="cboStatusDevice_SelectedIndexChanged" DataSourceID="DeviceStatusDataSource"
                                        DataValueField="Description" Filter="StartsWith" HighlightTemplatedItems="True">
                                        <HeaderTemplate>
                                            <table cellpadding="0" cellspacing="0">
                                                <tr>
                                                    <td style="width: 70px">Tình trạng</td>
                                                    <td style="width: 60px">Mô tả</td>
                                                </tr>
                                            </table>
                                        </HeaderTemplate>
                                        <ItemTemplate>
                                            <table cellpadding="0" cellspacing="0">
                                                <tr>
                                                    <td style="width: 70px"><%#DataBinder.Eval(Container.DataItem,"Status") %></td>
                                                    <td style="width: 60px"><%#DataBinder.Eval(Container.DataItem,"Description") %></td>
                                                </tr>
                                            </table>
                                        </ItemTemplate>
                                    </telerik:RadComboBox>
                                    <asp:ObjectDataSource ID="DeviceStatusDataSource" runat="server" 
                                        OldValuesParameterFormatString="original_{0}" SelectMethod="GetAll" 
                                        TypeName="DeviceStatusBLL"></asp:ObjectDataSource>
                                </td>
                                <td>
                                    <telerik:RadTextBox ID="txtStatusDevice" runat="server">
                                    </telerik:RadTextBox>
                                </td>
                                <td>
                                    <telerik:RadTextBox ID="txtStatusDeviceDescription" runat="server">
                                    </telerik:RadTextBox>
                                </td>
                                <td>
                                    <telerik:RadButton ID="btnStatusDeviceAdd" runat="server" Text="Thêm/Sửa" OnClick="btnStatusDeviceAdd_Click">
                                    </telerik:RadButton>
                                    <telerik:RadButton ID="btnStatusDeviceDelete" runat="server" Text="Xóa" OnClick="btnStatusDeviceDelete_Click">
                                    </telerik:RadButton>
                                </td>
                            </tr>
                        </table>
                    </ContentTemplate>
                </telerik:RadPanelItem>
                <telerik:RadPanelItem Text="Loại kiểm định" Expanded="True">
                    <ContentTemplate>
                        <table class="style1">
                            <tr>
                                <td>Loại kiểm định:</td>
                                <td>Loại:</td>
                                <td>Mô tả:</td>
                                <td>&nbsp</td>
                            </tr>
                            <tr>
                                <td>
                                    <telerik:RadComboBox ID="cboMeterAccreditationTypes" runat="server" AllowCustomText="True" AutoPostBack="true" 
                                        DataTextField="AccreditationType"  DataSourceID="AccreditationTypesDataSource"
                                        OnSelectedIndexChanged="cboMeterAccreditationTypes_SelectedIndexChanged"
                                        DataValueField="Description" Filter="StartsWith" 
                                        HighlightTemplatedItems="True">
                                        <HeaderTemplate>
                                            <table cellpadding="0" cellspacing="0">
                                                <tr>
                                                    <td style="width: 40px">Loại</td>
                                                    <td style="width: 90px">Mô tả</td>
                                                </tr>
                                            </table>
                                        </HeaderTemplate>
                                        <ItemTemplate>
                                            <table cellpadding="0" cellspacing="0">
                                                <tr>
                                                    <td style="width: 40px"><%#DataBinder.Eval(Container.DataItem, "AccreditationType")%></td>
                                                    <td style="width: 90px"><%#DataBinder.Eval(Container.DataItem,"Description") %></td>
                                                </tr>
                                            </table>
                                        </ItemTemplate>
                                    </telerik:RadComboBox>
                                     <asp:ObjectDataSource ID="AccreditationTypesDataSource" runat="server" 
                                        OldValuesParameterFormatString="original_{0}" SelectMethod="GetAll" 
                                        TypeName="MeterAccreditationTypesBLL"></asp:ObjectDataSource>
                                </td>
                                <td>
                                    <telerik:RadTextBox ID="txtMeterAccreditationType" runat="server">
                                    </telerik:RadTextBox>
                                </td>
                                <td>
                                    <telerik:RadTextBox ID="txtMeterAccreditationTypeDescription" runat="server">
                                    </telerik:RadTextBox>
                                </td>
                                <td>
                                    <telerik:RadButton ID="btnMeterAccreditationTypeAdd" runat="server" Text="Thêm/Sửa" OnClick="btnMeterAccreditationTypeAdd_Click">
                                    </telerik:RadButton>
                                    <telerik:RadButton ID="btnMeterAccreditationTypeDelete" runat="server" Text="Xóa" OnClick="btnMeterAccreditationTypeDelete_Click">
                                    </telerik:RadButton>
                                </td>
                            </tr>
                        </table>
                    </ContentTemplate>
                </telerik:RadPanelItem>
                <telerik:RadPanelItem Text="Quyền sử dụng" Expanded="true">
                    <ContentTemplate>
                        <table class="style1">
                            <tr>
                                <td>Quyền sử dụng:</td>
                                <td>Quyền:</td>
                                <td>Mô tả:</td>
                                <td>&nbsp</td>
                            </tr>
                            <tr>
                                <td>
                                    <telerik:RadComboBox ID="cboRoles" runat="server" DropDownWidth="400px" AutoPostBack="true" Filter="StartsWith"
                                        OnSelectedIndexChanged="cboRoles_SelectedIndexChanged" AllowCustomText="true" HighlightTemplatedItems="true"
                                        DataTextField="Role" DataValueField="Description" DataSourceID="RolesDataSource">
                                        <HeaderTemplate>
                                            <table cellpadding="0" cellspacing="0">
                                                <tr>
                                                    <td style="width:200px">Quyền</td>
                                                    <td style="width:200px">Mô tả</td>
                                                </tr>
                                            </table>
                                        </HeaderTemplate>
                                        <ItemTemplate>
                                            <table cellpadding="0" cellspacing="0">
                                                <tr>
                                                    <td style="width:200px"><%#DataBinder.Eval(Container.DataItem,"Role") %></td>
                                                    <td style="width:200px"><%#DataBinder.Eval(Container.DataItem,"Description") %></td>
                                                </tr>
                                            </table>
                                        </ItemTemplate>
                                    </telerik:RadComboBox>
                                    <asp:ObjectDataSource ID="RolesDataSource" runat="server" 
                                    OldValuesParameterFormatString="original_{0}" SelectMethod="GetAll" 
                                    TypeName="UserRolesBLL"></asp:ObjectDataSource>
                                </td>
                                <td>
                                    <telerik:RadTextBox ID="txtRole" runat="server">
                                    </telerik:RadTextBox>
                                </td>
                                <td>
                                    <telerik:RadTextBox ID="txtRoleDecription" runat="server">
                                    </telerik:RadTextBox>
                                </td>
                                <td>
                                    <telerik:RadButton ID="btnRoleAdd" runat="server" Text="Thêm/Sửa" OnClick="btnRoleAdd_Click">
                                    </telerik:RadButton>
                                    <telerik:RadButton ID="btnRoleDelete" runat="server" Text="Xóa" OnClick="btnRoleDelete_Click">
                                    </telerik:RadButton>
                                </td>
                            </tr>
                        </table>
                    </ContentTemplate>
                </telerik:RadPanelItem>
                 <telerik:RadPanelItem Text="Nhân viên" Expanded="true">
                    <ContentTemplate>
                        <table class="style1">
                            <tr>
                                <td>Mã nhân viên:</td>
                                <td>Tên:</td>
                                <td>Họ:</td>
                                <td>&nbsp</td>
                            </tr>
                            <tr>
                                <td>
                                    <telerik:RadComboBox ID="cboStaffs" Runat="server" AllowCustomText="True" 
                                        EnableLoadOnDemand="True" Filter="StartsWith" DropDownWidth="300" 
                                        HighlightTemplatedItems="True" DataSourceID="StaffDataSource" 
                                        OnSelectedIndexChanged="cboStaffs_SelectedIndexChanged"
                                        DataTextField="Id" DataValueField="Id" AutoPostBack="True">
                                        <HeaderTemplate>
                                            <table cellpadding="0" cellspacing="0">
                                                <tr>
                                                    <td style="width:50px">Mã NV</td>
                                                    <td style="width:100px">Tên</td>
                                                    <td style="width:150px">Họ</td>
                                                </tr>
                                            </table>
                                        </HeaderTemplate>
                                        <ItemTemplate>
                                            <table cellpadding="0" cellspacing="0">
                                                <tr>
                                                    <td style="width:50px"><%#DataBinder.Eval(Container.DataItem,"Id") %></td>
                                                    <td style="width:100px"><%#DataBinder.Eval(Container.DataItem,"FirstName") %></td>
                                                    <td style="width:150px"><%#DataBinder.Eval(Container.DataItem,"LastName") %></td>
                                                </tr>
                                            </table>
                                        </ItemTemplate>
                                    </telerik:RadComboBox>
                                    <asp:ObjectDataSource ID="StaffDataSource" runat="server" 
                                        OldValuesParameterFormatString="original_{0}" SelectMethod="GetAll" 
                                        TypeName="UserStaffsBLL"></asp:ObjectDataSource>
                                </td>
                                <td>
                                    <telerik:RadTextBox ID="txtFirstName" runat="server">
                                    </telerik:RadTextBox>
                                </td>
                                <td>
                                    <telerik:RadTextBox ID="txtLastName" runat="server">
                                    </telerik:RadTextBox>
                                </td>
                                <td>
                                    <telerik:RadButton ID="btnStaffAdd" runat="server" Text="Thêm/Sửa" OnClick="btnStaffAdd_Click">
                                    </telerik:RadButton>
                                    <telerik:RadButton ID="btnStaffDelete" runat="server" Text="Xóa" OnClick="btnStaffDelete_Click">
                                    </telerik:RadButton>
                                </td>
                            </tr>
                        </table>
                    </ContentTemplate>
                 </telerik:RadPanelItem>
            </Items>
        </telerik:RadPanelBar>
        <telerik:RadNotification ID="ntf" runat="server" Title="Message">
        </telerik:RadNotification>
        </div>
        </telerik:RadAjaxPanel>
    </div>
</asp:Content>

