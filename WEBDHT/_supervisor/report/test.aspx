<%@ Page Title="" Language="C#" MasterPageFile="~/_supervisor/master_page.master" AutoEventWireup="true" CodeFile="test.aspx.cs" Inherits="_supervisor_report_test" %>

<asp:Content ID="Content1" ContentPlaceHolderID="head" Runat="Server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" Runat="Server">
    <telerik:RadGrid ID="RadGrid1" runat="server" CellSpacing="0" 
        DataSourceID="SqlDataSource1" GridLines="None">
        <MasterTableView AutoGenerateColumns="False" DataKeyNames="Serial" 
            DataSourceID="SqlDataSource1">
            <CommandItemSettings ExportToPdfText="Export to PDF">
            </CommandItemSettings>
            <RowIndicatorColumn Visible="True" FilterControlAltText="Filter RowIndicator column">
                <HeaderStyle Width="20px"></HeaderStyle>
            </RowIndicatorColumn>
            <ExpandCollapseColumn Visible="True" FilterControlAltText="Filter ExpandColumn column">
                <HeaderStyle Width="20px"></HeaderStyle>
            </ExpandCollapseColumn>
            <Columns>
                <telerik:GridBoundColumn DataField="Serial" 
                    FilterControlAltText="Filter Serial column" HeaderText="Serial" ReadOnly="True" 
                    SortExpression="Serial" UniqueName="Serial">
                </telerik:GridBoundColumn>
                <telerik:GridBoundColumn DataField="ReceiptDate" DataType="System.DateTime" 
                    FilterControlAltText="Filter ReceiptDate column" HeaderText="ReceiptDate" 
                    SortExpression="ReceiptDate" UniqueName="ReceiptDate">
                </telerik:GridBoundColumn>
                <telerik:GridBoundColumn DataField="AccreditedDate" DataType="System.DateTime" 
                    FilterControlAltText="Filter AccreditedDate column" HeaderText="AccreditedDate" 
                    SortExpression="AccreditedDate" UniqueName="AccreditedDate">
                </telerik:GridBoundColumn>
                <telerik:GridBoundColumn DataField="ExpiryDate" DataType="System.DateTime" 
                    FilterControlAltText="Filter ExpiryDate column" HeaderText="ExpiryDate" 
                    SortExpression="ExpiryDate" UniqueName="ExpiryDate">
                </telerik:GridBoundColumn>
                <telerik:GridBoundColumn DataField="AccreditationDocument" 
                    FilterControlAltText="Filter AccreditationDocument column" 
                    HeaderText="AccreditationDocument" SortExpression="AccreditationDocument" 
                    UniqueName="AccreditationDocument">
                </telerik:GridBoundColumn>
                <telerik:GridBoundColumn DataField="AccreditationType" 
                    FilterControlAltText="Filter AccreditationType column" 
                    HeaderText="AccreditationType" SortExpression="AccreditationType" 
                    UniqueName="AccreditationType">
                </telerik:GridBoundColumn>
                <telerik:GridBoundColumn DataField="Provider" 
                    FilterControlAltText="Filter Provider column" HeaderText="Provider" 
                    SortExpression="Provider" UniqueName="Provider">
                </telerik:GridBoundColumn>
                <telerik:GridBoundColumn DataField="Marks" 
                    FilterControlAltText="Filter Marks column" HeaderText="Marks" 
                    SortExpression="Marks" UniqueName="Marks">
                </telerik:GridBoundColumn>
                <telerik:GridBoundColumn DataField="Size" DataType="System.Int16" 
                    FilterControlAltText="Filter Size column" HeaderText="Size" 
                    SortExpression="Size" UniqueName="Size">
                </telerik:GridBoundColumn>
                <telerik:GridBoundColumn DataField="Model" 
                    FilterControlAltText="Filter Model column" HeaderText="Model" 
                    SortExpression="Model" UniqueName="Model">
                </telerik:GridBoundColumn>
                <telerik:GridBoundColumn DataField="Status" 
                    FilterControlAltText="Filter Status column" HeaderText="Status" 
                    SortExpression="Status" UniqueName="Status">
                </telerik:GridBoundColumn>
                <telerik:GridCheckBoxColumn DataField="Installed" DataType="System.Boolean" 
                    FilterControlAltText="Filter Installed column" HeaderText="Installed" 
                    SortExpression="Installed" UniqueName="Installed">
                </telerik:GridCheckBoxColumn>
                <telerik:GridBoundColumn DataField="InitialIndex" DataType="System.Double" 
                    FilterControlAltText="Filter InitialIndex column" HeaderText="InitialIndex" 
                    SortExpression="InitialIndex" UniqueName="InitialIndex">
                </telerik:GridBoundColumn>
                <telerik:GridBoundColumn DataField="Description" 
                    FilterControlAltText="Filter Description column" HeaderText="Description" 
                    SortExpression="Description" UniqueName="Description">
                </telerik:GridBoundColumn>
                <telerik:GridBoundColumn DataField="ApprovalDate" DataType="System.DateTime" 
                    FilterControlAltText="Filter ApprovalDate column" HeaderText="ApprovalDate" 
                    SortExpression="ApprovalDate" UniqueName="ApprovalDate">
                </telerik:GridBoundColumn>
                <telerik:GridCheckBoxColumn DataField="Approved" DataType="System.Boolean" 
                    FilterControlAltText="Filter Approved column" HeaderText="Approved" 
                    SortExpression="Approved" UniqueName="Approved">
                </telerik:GridCheckBoxColumn>
                <telerik:GridBoundColumn DataField="ApprovalDecision" 
                    FilterControlAltText="Filter ApprovalDecision column" 
                    HeaderText="ApprovalDecision" SortExpression="ApprovalDecision" 
                    UniqueName="ApprovalDecision">
                </telerik:GridBoundColumn>
                <telerik:GridBoundColumn DataField="SerialTransmitter" 
                    FilterControlAltText="Filter SerialTransmitter column" 
                    HeaderText="SerialTransmitter" SortExpression="SerialTransmitter" 
                    UniqueName="SerialTransmitter">
                </telerik:GridBoundColumn>
            </Columns>
            <EditFormSettings>
                <EditColumn FilterControlAltText="Filter EditCommandColumn column">
                </EditColumn>
            </EditFormSettings>
        </MasterTableView>
        <FilterMenu EnableImageSprites="False">
        </FilterMenu>
    </telerik:RadGrid>
    <asp:SqlDataSource ID="SqlDataSource1" runat="server" 
        ConnectionString="<%$ ConnectionStrings:web_dht_r02ConnectionString %>" 
        SelectCommand="SELECT * FROM [t_Devices_Meters] WHERE ([Size] = @Size) ORDER BY [Serial]">
        <SelectParameters>
            <asp:Parameter DefaultValue="250" Name="Size" Type="Int16" />
        </SelectParameters>
    </asp:SqlDataSource>
</asp:Content>

