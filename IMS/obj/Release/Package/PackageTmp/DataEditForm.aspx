<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="DataEditForm.aspx.cs" Inherits="IMS.DataEditForm" %>

<%--<%@ Page Language="c#" CodeFile="DefaultCS.aspx.cs" Inherits="Telerik.GridExamplesCSharp.DataEditing.BatchEditing.DefaultCS" %>--%><%--<%@ Register TagPrefix="telerik" Namespace="Telerik.Web.UI" Assembly="Telerik.Web.UI" %>
<%@ Register TagPrefix="telerik" Namespace="Telerik.QuickStart" %>--%>


<!DOCTYPE html PUBLIC "-//W3C//DTD XHTML 1.1//EN" "http://www.w3.org/TR/xhtml11/DTD/xhtml11.dtd">
<html xmlns='http://www.w3.org/1999/xhtml'>
<head>
    <title>Batch Editing in ASP.NET DataGrid control | RadGrid Demo</title>
    <link href="CSS/GridViewStyle1.css" rel="stylesheet" />
    <style type="text/css">
        .auto-style1 {
            width: 79px;
        }

        .auto-style3 {
            height: 10px;
            width: 79px;
        }
    </style>
</head>
<body>
    <form id="form1" runat="server">
        <telerik:RadScriptManager runat="server" ID="RadScriptManager1" />

        <table cellpadding="0" align="center">
            <tr>
                <td align="center">
                    <table align="center" cellpadding="0" class="auto-style4">
                        <tr>
                            <td class="auto-style1">&nbsp;</td>
                            <td class="auto-style25">&nbsp;</td>
                            <td class="auto-style31">&nbsp;</td>
                            <td class="auto-style27">&nbsp;</td>
                            <td>&nbsp;</td>
                        </tr>
                        <tr>
                            <td class="auto-style3" style="background-color: #F7F7F7;"></td>
                            <td class="auto-style61" style="background-color: #F7F7F7;"></td>
                            <td class="auto-style31" style="background-color: #F7F7F7; height: 10px;"></td>
                            <td class="auto-style27" style="background-color: #F7F7F7; height: 10px;"></td>
                            <td style="background-color: #F7F7F7; height: 10px;"></td>
                        </tr>
                        <tr>
                            <td class="auto-style1" style="background-color: #F7F7F7; text-align: center;">&nbsp;</td>
                            <td class="auto-style55" style="background-color: #F7F7F7"><strong>TEST DATA ENTRY FORM</strong></td>
                            <td class="auto-style57" style="background-color: #F7F7F7"></td>
                            <td class="auto-style58" style="background-color: #F7F7F7"></td>
                            <td class="auto-style59" style="background-color: #F7F7F7"></td>
                        </tr>
                        <tr>
                            <td class="auto-style1"></td>
                            <td class="auto-style13" align="center">&nbsp;</td>
                            <td class="auto-style21">&nbsp;</td>
                            <td class="auto-style28">&nbsp;</td>
                            <td class="auto-style7">&nbsp;</td>
                        </tr>
                        <tr>
                            <td class="auto-style1">&nbsp;</td>
                            <td class="auto-style13">


                                <telerik:RadAjaxPanel runat="server" ID="RadAjaxPanel1">
                                    <%--        <telerik:InformationBox ID="InformationBox1" runat="server">
                         Click on a cell/row to place it in edit mode. Use the Save changes or Cancel changes buttons to process/discard all changes at once.
                    </telerik:InformationBox>--%>

                                    <%-- <telerik:RadFormDecorator runat="server" ID="ConfigurationPanel1" Title="Configurator" Expanded="true" DecorationZoneID="rfd-demo-zone">--%>

                                    <%--<telerik:ConfiguratorPanel runat="server" ID="ConfigurationPanel1" Title="Configurator" Expanded="true">--%>

                                    <table cellspacing="0" cellpadding="0">
                                        <tr>
                                            <td style="width: 300px; vertical-align: top;">
                                                <label for="type">
                                                    Select the event which will place the cell/row in edit mode:</label>
                                                <asp:RadioButtonList OnSelectedIndexChanged="rblChangeButtonType_SelectedIndexChanged"
                                                    RepeatDirection="Vertical" Width="150px" CellPadding="0" CellSpacing="0"
                                                    ID="rblChangeEditEventType" runat="server" AutoPostBack="True">
                                                    <asp:ListItem Value="click" Selected="True">Click</asp:ListItem>
                                                    <asp:ListItem Value="dblclick">Double Click</asp:ListItem>
                                                    <asp:ListItem Value="mousedown">Mouse Down</asp:ListItem>
                                                    <asp:ListItem Value="mouseup">Mouse Up</asp:ListItem>
                                                </asp:RadioButtonList>
                                            </td>
                                            <td style="width: 300px; vertical-align: top; padding: 0 0 0 20px;">
                                                <label for="type">
                                                    Select EditType:</label>
                                                <asp:RadioButtonList OnSelectedIndexChanged="rblChangeEditType_SelectedIndexChanged"
                                                    RepeatDirection="Vertical" Width="150px" CellPadding="0" CellSpacing="0"
                                                    ID="rblChangeEditType" runat="server" AutoPostBack="True">
                                                    <asp:ListItem Value="Row">Row</asp:ListItem>
                                                    <asp:ListItem Value="Cell" Selected="True">Cell</asp:ListItem>
                                                </asp:RadioButtonList>
                                            </td>
                                            <td style="width: 300px; vertical-align: top; padding: 0 0 0 20px;">&nbsp;</td>
                                        </tr>
                                        <tr>
                                            <td style="width: 300px; vertical-align: top;">&nbsp;</td>
                                            <td style="width: 300px; vertical-align: top; padding: 0 0 0 20px;">&nbsp;</td>
                                            <td style="width: 300px; vertical-align: top; padding: 0 0 0 20px;">&nbsp;</td>
                                        </tr>
                                        <tr>
                                            <td style="width: 300px; vertical-align: top;">Enter Store ID:
                                                <asp:TextBox ID="txtStoreID" runat="server" Width="58px"></asp:TextBox>
                                            </td>
                                            <td style="width: 300px; vertical-align: top; padding: 0 0 0 20px;">Enter Dept ID:
                                                <asp:TextBox ID="txtDeptID" runat="server" Width="52px"></asp:TextBox>
                                            </td>
                                            <td style="width: 300px; vertical-align: top; padding: 0 0 0 20px;">Enter GRN Number:
                                                <asp:TextBox ID="txtGRN" runat="server" Width="52px" OnTextChanged="txtGRN_TextChanged"></asp:TextBox>
                                            </td>
                                        </tr>
                                        <tr>
                                            <td style="width: 300px; vertical-align: top;">&nbsp;</td>
                                            <td style="width: 300px; vertical-align: top; padding: 0 0 0 20px;">&nbsp;</td>
                                            <td style="width: 300px; vertical-align: top; padding: 0 0 0 20px;">&nbsp;</td>
                                        </tr>
                                        <tr>
                                            <td style="width: 300px; vertical-align: top;">&nbsp;</td>
                                            <td style="width: 300px; vertical-align: top; padding: 0 0 0 20px; text-align: center;">&nbsp;</td>
                                            <td style="width: 300px; vertical-align: top; padding: 0 0 0 20px;">
                                                <asp:Button ID="btnOK" runat="server" OnClick="btnOK_Click" Text="OK" Width="86px" />
                                            </td>
                                        </tr>
                                    </table>

                                    <%--</telerik:ConfiguratorPanel>--%>
                                    <%--  </telerik:RadFormDecorator>--%>

                                    <telerik:RadListBox runat="server" ID="SavedChangesList" Width="600px" Height="200px" Visible="false"></telerik:RadListBox>

                                            
                    
<%--                    OnPreRender="RadGrid1_PreRender"--%>


                                    <telerik:RadGrid ID="RadGrid1" GridLines="None" runat="server" 
                                        AllowAutomaticDeletes="True"
                                        AllowAutomaticInserts="True" 
                                        OnItemDeleted="RadGrid1_ItemDeleted" 
                                        OnItemInserted="RadGrid1_ItemInserted" 
                                        OnItemUpdated="RadGrid1_ItemUpdated"
                                        AllowAutomaticUpdates="True" 
                                        PageSize="10" Skin="Default" 
                                        AllowPaging="True"
                                        AutoGenerateColumns="False" Width="750px" 
                                        OnBatchEditCommand="RadGrid1_BatchEditCommand" 
                                        DataSourceID="SqlDataSource1" 
                                        CellSpacing="0" 
                                        AllowMultiRowEdit="True">

                                        <MasterTableView AutoGenerateColumns="False" CommandItemDisplay="TopAndBottom" DataKeyNames="pkRecvID" DataSourceID="SqlDataSource1" EditMode="Batch" HorizontalAlign="NotSet">
                                            <SortExpressions>
                                                <telerik:GridSortExpression FieldName="fkItemID" SortOrder="Ascending" />
                                            </SortExpressions>
                                            <Columns>
                                                <telerik:GridBoundColumn DataField="pkRecvID" DataType="System.Int32" FilterControlAltText="Filter pkRecvID column" HeaderStyle-Width="60px" HeaderText="pkRecvID" ReadOnly="True" SortExpression="pkRecvID" UniqueName="pkRecvID" Visible="false">
                                                    <HeaderStyle Width="60px" />
                                                </telerik:GridBoundColumn>
                                                <telerik:GridBoundColumn DataField="fkRecvByStoreID" DataType="System.Int32" FilterControlAltText="Filter fkRecvByStoreID column" HeaderStyle-Width="150px" HeaderText="fkRecvByStoreID" SortExpression="fkRecvByStoreID" UniqueName="fkRecvByStoreID" Visible="false">
                                                    <HeaderStyle Width="150px" />
                                                </telerik:GridBoundColumn>
                                                <telerik:GridBoundColumn DataField="fkRecvByDeptID" DataType="System.Int32" FilterControlAltText="Filter fkRecvByDeptID column" HeaderStyle-Width="100px" HeaderText="fkRecvByDeptID" SortExpression="fkRecvByDeptID" UniqueName="fkRecvByDeptID" Visible="false">
                                                    <HeaderStyle Width="100px" />
                                                </telerik:GridBoundColumn>
                                                <telerik:GridBoundColumn DataField="GRNNumber" DataType="System.Int32" FilterControlAltText="Filter GRNNumber column" HeaderStyle-Width="100px" HeaderText="GRNNumber"  ItemStyle-HorizontalAlign="Center" SortExpression="GRNNumber" UniqueName="GRNNumber">
                                                    <HeaderStyle Width="100px" />
                                                    <ItemStyle HorizontalAlign="Center" />
                                                </telerik:GridBoundColumn>
                                                <telerik:GridBoundColumn DataField="fkItemID" DataType="System.Int64" FilterControlAltText="Filter fkItemID column" HeaderText="fkItemID" SortExpression="fkItemID" UniqueName="fkItemID" Visible="false">
                                                </telerik:GridBoundColumn>
                                                <telerik:GridBoundColumn DataField="InvCode" FilterControlAltText="Filter InvCode column" HeaderStyle-Width="150px" HeaderText="InvCode" ItemStyle-Width="150px" SortExpression="InvCode" UniqueName="InvCode">
                                                    <HeaderStyle Width="150px" />
                                                    <ItemStyle Width="150px" />
                                                </telerik:GridBoundColumn>


                                                <telerik:GridTemplateColumn DataField="ItemTitle" FilterControlAltText="Filter ItemTitle column" HeaderStyle-Width="200px" HeaderText="Item Title" UniqueName="ItemTitle">
                                                    <ItemTemplate>
                                                        <telerik:RadDropDownList ID="RadDropDownList1" runat="server" DataSourceID="SqlDataSource2" DataTextField="ItemTitle" DataValueField="pkItemID" SelectedValue='<%# Eval("fkItemID", "{0}") %>'>
                                                        </telerik:RadDropDownList>

                                                 <%--       <%# Eval("fkItemID", "{0}") %>--%>
                                                    </ItemTemplate>



                                                    <HeaderStyle Width="200px" />
                                                </telerik:GridTemplateColumn>


                                                <telerik:GridBoundColumn DataField="Qtty" DataType="System.Double" FilterControlAltText="Filter Qtty column" HeaderStyle-Width="50px" HeaderText="Qtty" ItemStyle-Width="50px"  ItemStyle-BackColor="YellowGreen" SortExpression="Qtty" UniqueName="Qtty">
                                                    <HeaderStyle Width="50px" />
                                                    <ItemStyle Width="50px"  HorizontalAlign="Right" ForeColor="White" Font-Bold="true"/>
                                                </telerik:GridBoundColumn>
                                                <telerik:GridBoundColumn DataField="Remarks" FilterControlAltText="Filter Remarks column" HeaderStyle-Width="250px" HeaderText="Remarks" ItemStyle-Width="250px" SortExpression="Remarks" UniqueName="Remarks">
                                                    <HeaderStyle Width="250px" />
                                                    <ItemStyle Width="250px" />
                                                </telerik:GridBoundColumn>

                                                <telerik:GridButtonColumn ConfirmText="Delete this Entry?" ConfirmDialogType="RadWindow"
                                                    ConfirmTitle="Delete" HeaderText="Delete" HeaderStyle-Width="50px" ButtonType="ImageButton"
                                                    CommandName="Delete" Text="Delete" UniqueName="DeleteColumn">
                                                    <HeaderStyle Width="50px" />
                                                </telerik:GridButtonColumn>


                                            </Columns>
                                            <PagerStyle AlwaysVisible="True" />
                                        </MasterTableView>


                                        <PagerStyle AlwaysVisible="True" />


                                    </telerik:RadGrid>
                                </telerik:RadAjaxPanel>

                            </td>
                            <td class="auto-style21">&nbsp;</td>
                            <td class="auto-style28">&nbsp;</td>
                            <td class="auto-style7">&nbsp;</td>
                        </tr>
                        <tr>
                            <td class="auto-style1">&nbsp;</td>
                            <td class="auto-style13">&nbsp;</td>
                            <td class="auto-style21">&nbsp;</td>
                            <td class="auto-style28">&nbsp;</td>
                            <td class="auto-style7">&nbsp;</td>
                        </tr>
                        <tr>
                            <td class="auto-style1">&nbsp;</td>
                            <td class="auto-style13">

                                <asp:SqlDataSource ID="SqlDataSource1" runat="server" ConnectionString="<%$ ConnectionStrings:INVENTORY %>"

                                    SelectCommand="SELECT R.[pkRecvID] ,R.[fkRecvByStoreID] ,R.[fkRecvByDeptID],R.[GRNNumber] ,R.[fkItemID] ,R.[InvCode] ,C.[CatTitle],I.[ItemTitle],R.[Qtty] ,R.[Remarks] FROM [INVENTORY].[dbo].[tblReceived] R JOIN [INVENTORY].[dbo].[tblItems] I ON I.pkItemID = R.fkItemID JOIN [INVENTORY].[dbo].[tblItemCategory] C ON C.pkCatID = I.fkCatID 
WHERE R.fkRecvByStoreID=@fkRecvByStoreID AND R.fkRecvByDeptID=@fkRecvByDeptID AND R.GRNNumber=@GRNNumber ORDER BY R.[fkItemID]"


                                    DeleteCommand="DELETE FROM [tblReceived] WHERE [pkRecvID] = @pkRecvID"

                                    InsertCommand="INSERT INTO [tblReceived] ([GRNCode], [fkItemID], [InvCode], [Qtty]) VALUES (@GRNCode, @fkItemID, @InvCode, @Qtty)"
                                   
                                    UpdateCommand="UPDATE [tblReceived] SET [Qtty] = @Qtty, [Remarks] = @Remarks WHERE [pkRecvID] = @pkRecvID">


                                    <SelectParameters>
                                        <asp:ControlParameter ControlID="txtStoreID" Name="fkRecvByStoreID" PropertyName="Text" Type="Int32" />
                                        <asp:ControlParameter ControlID="txtDeptID" Name="fkRecvByDeptID" PropertyName="Text" Type="Int32" />
                                        <asp:ControlParameter ControlID="txtGRN" Name="GRNNumber" PropertyName="Text" Type="Int32" />
                                    </SelectParameters>


                                    <DeleteParameters>
                                        <asp:Parameter Name="pkRecvID" Type="Int32"></asp:Parameter>
                                    </DeleteParameters>

                                    <InsertParameters>
                                        <asp:Parameter Name="GRNCode" Type="String" />
                                        <asp:Parameter Name="fkItemID" Type="Int64" />
                                        <asp:Parameter Name="InvCode" Type="String" />
                                        <asp:Parameter Name="Qtty" Type="Double" />
                                        <asp:Parameter Name="Remarks" Type="String" />
                                    </InsertParameters>

                                    <UpdateParameters>
                                        <asp:Parameter Name="pkRecvID" Type="Int32" />
                                        <asp:Parameter Name="GRNCode" Type="String" />
                                        <asp:Parameter Name="fkItemID" Type="Int64" />
                                        <asp:Parameter Name="InvCode" Type="String" />
                                        <asp:Parameter Name="Qtty" Type="Double" />
                                        <asp:Parameter Name="Remarks" Type="String" />
                                    </UpdateParameters>

                                </asp:SqlDataSource>

                            </td>
                            <td class="auto-style21">&nbsp;</td>
                            <td class="auto-style28">&nbsp;</td>
                            <td class="auto-style7">&nbsp;</td>
                        </tr>
                        <tr>
                            <td class="auto-style1">&nbsp;</td>
                            <td class="auto-style13">&nbsp;</td>
                            <td class="auto-style21">&nbsp;</td>
                            <td class="auto-style28">&nbsp;</td>
                            <td class="auto-style7">&nbsp;</td>
                        </tr>
                        <tr>
                            <td class="auto-style1">
                                <asp:SqlDataSource ID="SqlDataSource2" runat="server" ConnectionString="<%$ ConnectionStrings:INVENTORY %>"
                                    SelectCommand="SELECT [pkItemID], [ItemTitle] FROM [tblItems]"></asp:SqlDataSource>
                            </td>
                        </tr>
                        <tr>
                            <td class="auto-style1">&nbsp;</td>
                        </tr>
                    </table>
                </td>
            </tr>
        </table>

    </form>
</body>
</html>
