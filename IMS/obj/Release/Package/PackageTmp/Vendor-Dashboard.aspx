<%@ Page Title="" Language="C#" MasterPageFile="~/Site1.Master" AutoEventWireup="true" CodeBehind="Vendor-Dashboard.aspx.cs" Inherits="IMS.Vendor_Dashboard" %>
<asp:Content ID="Content1" ContentPlaceHolderID="HeadContent" runat="server">
    <style type="text/css">
        .auto-style4 {
            width: 60%;
            border-collapse: collapse;
        }
    </style>
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">
    <table cellpadding="0" class="auto-style2">
        <tr>
            <td style="text-align: center">
                <div align="center">
                <table cellpadding="0" class="auto-style4">
                    <tr>
                        <td>&nbsp;</td>
                    </tr>
                    <tr>
                        <td>
                            <telerik:RadGrid ID="RadGrid1" runat="server" AllowPaging="True" AllowSorting="True" CellSpacing="0" GridLines="None">
                                <ClientSettings>
                                    <Selecting AllowRowSelect="True" />
                                </ClientSettings>
                                <MasterTableView>
                                    <CommandItemTemplate>
                                        <telerik:RadMenu ID="RadMenu1" Runat="server">
                                            <Items>
                                                <telerik:RadMenuItem runat="server" Text="Add New">
                                                </telerik:RadMenuItem>
                                            </Items>
                                        </telerik:RadMenu>
                                    </CommandItemTemplate>
                                </MasterTableView>
                            </telerik:RadGrid>
                        </td>
                    </tr>
                </table>
            </div></td>
        </tr>
    </table>
</asp:Content>
