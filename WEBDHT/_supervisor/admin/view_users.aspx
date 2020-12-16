<%@ Page Title="" Language="C#" MasterPageFile="~/_supervisor/master_page.master" AutoEventWireup="true" CodeFile="view_users.aspx.cs" Inherits="_supervisor_admin_view_users" %>

<asp:Content ID="Content1" ContentPlaceHolderID="head" Runat="Server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" Runat="Server">
    <div id="main-content">
        <telerik:RadAjaxPanel ID="RadAjaxPanel1" runat="server">
        <div id="main-content-title">
            <h2>Người dùng</h2>
            <hr class="line" />
        </div>
        <div id="main-content-text">
            <telerik:RadGrid ID="grvUser" runat="server" CellSpacing="0" 
                DataSourceID="UsersDataSource" GridLines="None">
<ClientSettings>
<Selecting CellSelectionMode="None"></Selecting>
</ClientSettings>

<MasterTableView AutoGenerateColumns="False" DataSourceID="UsersDataSource">
<CommandItemSettings ExportToPdfText="Export to PDF"></CommandItemSettings>

<RowIndicatorColumn Visible="True" FilterControlAltText="Filter RowIndicator column">
</RowIndicatorColumn>

<ExpandCollapseColumn Visible="True" FilterControlAltText="Filter ExpandColumn column">
<HeaderStyle Width="20px" ForeColor=""></HeaderStyle>
</ExpandCollapseColumn>

    <Columns>
        <telerik:GridBoundColumn DataField="Uid" 
            FilterControlAltText="Filter Uid column" HeaderText="Người dùng" ReadOnly="True" 
            SortExpression="Uid" UniqueName="Uid">
        </telerik:GridBoundColumn>
        <telerik:GridBoundColumn DataField="StaffId" 
            FilterControlAltText="Filter StaffId column" HeaderText="Mã nhân viên" 
            ReadOnly="True" SortExpression="StaffId" UniqueName="StaffId">
        </telerik:GridBoundColumn>
        <telerik:GridBoundColumn DataField="Role" 
            FilterControlAltText="Filter Role column" HeaderText="Quyền" ReadOnly="True" 
            SortExpression="Role" UniqueName="Role">
        </telerik:GridBoundColumn>
        <telerik:GridCheckBoxColumn DataField="Active" DataType="System.Boolean" 
            FilterControlAltText="Filter Active column" HeaderText="Đang hoạt động" ReadOnly="True" 
            SortExpression="Active" UniqueName="Active">
        </telerik:GridCheckBoxColumn>
        <telerik:GridBoundColumn DataField="TimeStamp" DataType="System.DateTime" DataFormatString="{0:dd/MM/yyyy hh:mm tt}" 
            FilterControlAltText="Filter TimeStamp column" HeaderText="Time Stamp" 
            ReadOnly="True" SortExpression="TimeStamp" UniqueName="TimeStamp">
        </telerik:GridBoundColumn>
        <telerik:GridBoundColumn DataField="Ip" FilterControlAltText="Filter Ip column" 
            HeaderText="IP" ReadOnly="True" SortExpression="Ip" UniqueName="Ip">
        </telerik:GridBoundColumn>
        <telerik:GridBoundColumn DataField="LogCount" DataType="System.Int32" 
            FilterControlAltText="Filter LogCount column" HeaderText="Số lần đăng nhập" 
            ReadOnly="True" SortExpression="LogCount" UniqueName="LogCount">
        </telerik:GridBoundColumn>
        <telerik:GridBoundColumn DataField="FirstName" DataType="System.String" 
            FilterControlAltText="Filter FirstName column" HeaderText="Tên" 
            ReadOnly="True" SortExpression="FirstName" UniqueName="FirstName">
        </telerik:GridBoundColumn>
        <telerik:GridBoundColumn DataField="LastName" DataType="System.String" 
            FilterControlAltText="Filter LastName column" HeaderText="Họ" 
            ReadOnly="True" SortExpression="LastName" UniqueName="LastName">
        </telerik:GridBoundColumn>
    </Columns>
<EditFormSettings>
<EditColumn FilterControlAltText="Filter EditCommandColumn column"></EditColumn>
</EditFormSettings>
</MasterTableView>

<FilterMenu EnableImageSprites="False"></FilterMenu>
        </telerik:RadGrid>
            <asp:ObjectDataSource ID="UsersDataSource" runat="server" 
                OldValuesParameterFormatString="original_{0}" SelectMethod="Get4View" 
                TypeName="UsersBLL"></asp:ObjectDataSource>
        </div>
        </telerik:RadAjaxPanel>
    </div>
</asp:Content>

