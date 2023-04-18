<%@ Page Title="" Language="C#" MasterPageFile="~/Site1.Master" AutoEventWireup="true" CodeBehind="frmInventoryFilter.aspx.cs" Inherits="IMS.frmInventoryFilter" %>
<asp:Content ID="Content1" ContentPlaceHolderID="HeadContent" runat="server">
    <style type="text/css">
        .auto-style4 {
            width: 100%;
        }
    </style>
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">
    <table class="auto-style4">
        <tr>
            <td>&nbsp;</td>
        </tr>
        <tr>
            <td>
                <telerik:RadGrid ID="RadGrid1" runat="server" AllowFilteringByColumn="True" DataSourceID="SqlDataSource1" GroupPanelPosition="Top">
                    <MasterTableView AutoGenerateColumns="False" DataSourceID="SqlDataSource1">
                        <Columns>
                            <telerik:GridBoundColumn DataField="fkbrhID" DataType="System.Int32" FilterControlAltText="Filter fkbrhID column" HeaderText="fkbrhID" SortExpression="fkbrhID" UniqueName="fkbrhID">
                            </telerik:GridBoundColumn>
                            <telerik:GridBoundColumn DataField="fkStoreID" DataType="System.Int32" FilterControlAltText="Filter fkStoreID column" HeaderText="fkStoreID" SortExpression="fkStoreID" UniqueName="fkStoreID">
                            </telerik:GridBoundColumn>
                            <telerik:GridBoundColumn DataField="ItemCode" FilterControlAltText="Filter ItemCode column" HeaderText="ItemCode" SortExpression="ItemCode" UniqueName="ItemCode">
                            </telerik:GridBoundColumn>
                            <telerik:GridBoundColumn DataField="InvCode" FilterControlAltText="Filter InvCode column" HeaderText="InvCode" SortExpression="InvCode" UniqueName="InvCode">
                            </telerik:GridBoundColumn>
                            <telerik:GridBoundColumn DataField="CRBalance" DataType="System.Double" FilterControlAltText="Filter CRBalance column" HeaderText="CRBalance" SortExpression="CRBalance" UniqueName="CRBalance">
                            </telerik:GridBoundColumn>
                            <telerik:GridBoundColumn DataField="QttyIssued" DataType="System.Double" FilterControlAltText="Filter QttyIssued column" HeaderText="QttyIssued" SortExpression="QttyIssued" UniqueName="QttyIssued">
                            </telerik:GridBoundColumn>
                            <telerik:GridBoundColumn DataField="QttyReceived" DataType="System.Double" FilterControlAltText="Filter QttyReceived column" HeaderText="QttyReceived" SortExpression="QttyReceived" UniqueName="QttyReceived">
                            </telerik:GridBoundColumn>
                            <telerik:GridCheckBoxColumn DataField="IsActive" DataType="System.Boolean" FilterControlAltText="Filter IsActive column" HeaderText="IsActive" SortExpression="IsActive" UniqueName="IsActive">
                            </telerik:GridCheckBoxColumn>
                            <telerik:GridBoundColumn DataField="ItemStatus" FilterControlAltText="Filter ItemStatus column" HeaderText="ItemStatus" SortExpression="ItemStatus" UniqueName="ItemStatus">
                            </telerik:GridBoundColumn>
                        </Columns>
                    </MasterTableView>
                </telerik:RadGrid>
                <asp:SqlDataSource ID="SqlDataSource1" runat="server" ConnectionString="<%$ ConnectionStrings:INVENTORY %>" SelectCommand="SELECT [fkbrhID], [fkStoreID], [ItemCode], [InvCode], [CRBalance], [QttyIssued], [QttyReceived], [IsActive], [ItemStatus] FROM [tblInventory] WHERE ([fkStoreID] = @fkStoreID)">
                    <SelectParameters>
                        <asp:Parameter DefaultValue="22" Name="fkStoreID" Type="Int32" />
                    </SelectParameters>
                </asp:SqlDataSource>
            </td>
        </tr>
        <tr>
            <td>&nbsp;</td>
        </tr>
        <tr>
            <td>&nbsp;</td>
        </tr>
        <tr>
            <td>&nbsp;</td>
        </tr>
        <tr>
            <td>&nbsp;</td>
        </tr>
        <tr>
            <td>&nbsp;</td>
        </tr>
        <tr>
            <td>&nbsp;</td>
        </tr>
    </table>
</asp:Content>
<asp:Content ID="Content3" ContentPlaceHolderID="MainContent" runat="server">
</asp:Content>
