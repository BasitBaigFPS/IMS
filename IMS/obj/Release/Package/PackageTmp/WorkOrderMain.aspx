<%@ Page Title="" Language="C#" MasterPageFile="~/Site1.Master" AutoEventWireup="true" CodeBehind="WorkOrderMain.aspx.cs" Inherits="IMS.WorkOrderMain" %>

<asp:Content ID="Content1" ContentPlaceHolderID="HeadContent" runat="server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">
</asp:Content>
<asp:Content ID="Content3" ContentPlaceHolderID="MainContent" runat="server">


    <table cellpadding="0" class="auto-style2">
        <tr>
            <td>
                <table align="center" cellpadding="0" class="auto-style4">
                    <tr>
                        <td class="auto-style22">&nbsp;</td>
                        <td class="auto-style25">&nbsp;</td>
                        <td class="auto-style31">&nbsp;</td>
                        <td class="auto-style27">&nbsp;</td>
                        <td>&nbsp;</td>
                    </tr>
                    <tr>
                        <td class="auto-style32">&nbsp;</td>
                        <td class="auto-style25">&nbsp;</td>
                        <td class="auto-style31">&nbsp;</td>
                        <td class="auto-style27">&nbsp;</td>
                        <td>&nbsp;</td>
                    </tr>
                    <tr>
                        <td class="auto-style32" style="background-color: #F7F7F7; height: 10px;"></td>
                        <td class="auto-style61" style="background-color: #F7F7F7; height: 10px;"></td>
                        <td class="auto-style31" style="background-color: #F7F7F7; height: 10px;"></td>
                        <td class="auto-style27" style="background-color: #F7F7F7; height: 10px;"></td>
                        <td style="background-color: #F7F7F7; height: 10px;"></td>
                    </tr>
                    <tr>
                        <td class="auto-style56" style="background-color: #F7F7F7; text-align: center;">
                            <img alt="" class="auto-style64" src="images/Items.png" /></td>
                        <td class="auto-style55" style="background-color: #F7F7F7"><strong>Work Order System</strong></td>
                        <td class="auto-style57" style="background-color: #F7F7F7"></td>
                        <td class="auto-style58" style="background-color: #F7F7F7"></td>
                        <td class="auto-style59" style="background-color: #F7F7F7"><strong>Work Order System</strong></td>
                    </tr>
                    <tr>
                        <td class="auto-style6"></td>
                        <td class="auto-style13"></td>
                        <td class="auto-style21">&nbsp;</td>
                        <td class="auto-style28">&nbsp;</td>
                        <td class="auto-style7">&nbsp;</td>
                    </tr>
                    <tr>
                        <td class="auto-style10">&nbsp;</td>
                        <td class="auto-style15">&nbsp;</td>
                        <td class="auto-style20">
                            <asp:TextBox ID="txtuserID" runat="server" Visible="False" Width="16px"></asp:TextBox>
                            &nbsp;
                        <asp:TextBox ID="txtbrhid" runat="server" Visible="False" Width="16px"></asp:TextBox>
                        </td>
                    </tr>
                    <tr>
                        <td class="auto-style62">&nbsp;</td>
                        <td class="auto-style26">&nbsp;</td>
                        <td class="auto-style18">





                            <telerik:RadScriptManager runat="server" ID="RadScriptManager1" />
                            <telerik:RadSkinManager ID="RadSkinManager1" runat="server" ShowChooser="true" />
                       <%--     <telerik:MessageBox ID="InformationBox1" runat="server" Type="Info" Icon="Info">
                                <p>
                                    Click on a cell/row to place it in edit mode. Use the Save changes or Cancel changes buttons to process/discard all changes at once.
                                </p>
                            </telerik:MessageBox>--%>
                            <telerik:RadAjaxManager runat="server">
                                <AjaxSettings>
                                    <telerik:AjaxSetting AjaxControlID="RadGrid1">
                                        <UpdatedControls>
                                            <telerik:AjaxUpdatedControl ControlID="RadGrid1" LoadingPanelID="RadAjaxLoadingPanel1" />
                                            <telerik:AjaxUpdatedControl ControlID="SavedChangesList" />
                                        </UpdatedControls>
                                    </telerik:AjaxSetting>
                                    <telerik:AjaxSetting AjaxControlID="ConfigurationPanel1">
                                        <UpdatedControls>
                                            <telerik:AjaxUpdatedControl ControlID="RadGrid1" LoadingPanelID="RadAjaxLoadingPanel1" />
                                        </UpdatedControls>
                                    </telerik:AjaxSetting>
                                </AjaxSettings>
                            </telerik:RadAjaxManager>
                            <telerik:RadAjaxLoadingPanel runat="server" ID="RadAjaxLoadingPanel1"></telerik:RadAjaxLoadingPanel>
                            <telerik:RadFormDecorator RenderMode="Lightweight" ID="RadFormDecorator1" runat="server" DecorationZoneID="demo" DecoratedControls="All" EnableRoundedCorners="false" />
                            <div id="demo" class="demo-container no-bg">
                                <telerik:RadListBox RenderMode="Lightweight" runat="server" ID="SavedChangesList" Width="600px" Height="200px" Visible="false"></telerik:RadListBox>


                            <telerik:RadGrid RenderMode="Lightweight" ID="RadGrid1" GridLines="None" runat="server" AllowAutomaticDeletes="True"
                                    AllowAutomaticInserts="True" PageSize="10" OnItemDeleted="RadGrid1_ItemDeleted" OnItemInserted="RadGrid1_ItemInserted"
                                    OnItemUpdated="RadGrid1_ItemUpdated" OnPreRender="RadGrid1_PreRender" AllowAutomaticUpdates="True" AllowPaging="True"
                                    AutoGenerateColumns="False" OnBatchEditCommand="RadGrid1_BatchEditCommand" DataSourceID="SqlDataSource1">
                                    <MasterTableView CommandItemDisplay="TopAndBottom" DataKeyNames="ProductID"
                                        DataSourceID="SqlDataSource1" HorizontalAlign="NotSet" EditMode="Batch" AutoGenerateColumns="False">
                                        <BatchEditingSettings EditType="Cell" />
                                        <SortExpressions>
                                            <telerik:GridSortExpression FieldName="ProductID" SortOrder="Descending" />
                                        </SortExpressions>
                                        <Columns>
                                            <telerik:GridBoundColumn DataField="ProductName" HeaderStyle-Width="210px" HeaderText="ProductName" SortExpression="ProductName"
                                                UniqueName="ProductName">
                                                <ColumnValidationSettings EnableRequiredFieldValidation="true">
                                                    <RequiredFieldValidator ForeColor="Red" Text="*This field is required" Display="Dynamic">
                                                    </RequiredFieldValidator>
                                                </ColumnValidationSettings>
                                            </telerik:GridBoundColumn>
                                            <telerik:GridTemplateColumn HeaderText="Category" DefaultInsertValue="Beverages" HeaderStyle-Width="150px" UniqueName="CategoryID" DataField="CategoryID">
                                                <ItemTemplate>
                                                    <%# Eval("CategoryName") %>
                                                </ItemTemplate>
                                                <EditItemTemplate>
                                                    <telerik:RadDropDownList RenderMode="Lightweight" runat="server" ID="CategoryIDDropDown" DataValueField="CategoryID"
                                                        DataTextField="CategoryName" DataSourceID="SqlDataSource2">
                                                    </telerik:RadDropDownList>
                                                </EditItemTemplate>
                                            </telerik:GridTemplateColumn>
                                            <telerik:GridNumericColumn DataField="UnitsInStock" HeaderStyle-Width="80px" HeaderText="Units In Stock"
                                                SortExpression="UnitsInStock" UniqueName="UnitsInStock">
                                            </telerik:GridNumericColumn>
                                            <telerik:GridCheckBoxColumn DataField="Discontinued" HeaderStyle-Width="80px" HeaderText="Discontinued" SortExpression="Discontinued"
                                                UniqueName="Discontinued">
                                            </telerik:GridCheckBoxColumn>
                                            <telerik:GridTemplateColumn HeaderText="UnitPrice" HeaderStyle-Width="80px" SortExpression="UnitPrice" UniqueName="TemplateColumn"
                                                DataField="UnitPrice">
                                                <ItemTemplate>
                                                    <asp:Label runat="server" ID="lblUnitPrice" Text='<%# Eval("UnitPrice", "{0:C}") %>'></asp:Label>
                                                </ItemTemplate>
                                                <EditItemTemplate>
                                                    <span>
                                                        <telerik:RadNumericTextBox RenderMode="Lightweight" Width="55px" runat="server" ID="tbUnitPrice">
                                                        </telerik:RadNumericTextBox>
                                                        <span style="color: Red">
                                                            <asp:RequiredFieldValidator ID="RequiredFieldValidator1"
                                                                ControlToValidate="tbUnitPrice" ErrorMessage="*Required" runat="server" Display="Dynamic">
                                                            </asp:RequiredFieldValidator>
                                                        </span>
                                                    </span>
                                                </EditItemTemplate>
                                            </telerik:GridTemplateColumn>
                                            <telerik:GridButtonColumn ConfirmText="Delete this product?" ConfirmDialogType="RadWindow"
                                                ConfirmTitle="Delete" HeaderText="Delete" HeaderStyle-Width="50px"
                                                CommandName="Delete" Text="Delete" UniqueName="DeleteColumn">
                                            </telerik:GridButtonColumn>
                                        </Columns>
                                    </MasterTableView>
                                    <ClientSettings AllowKeyboardNavigation="true"></ClientSettings>
                                </telerik:RadGrid>

                            </div>
                            <asp:SqlDataSource ID="SqlDataSource1" runat="server" ConnectionString="<%$ ConnectionStrings:INVENTORY %>"
                                DeleteCommand="DELETE FROM [Products] WHERE [ProductID] = @ProductID" InsertCommand="INSERT INTO [Products] ([ProductName], [CategoryID], [UnitPrice], [Discontinued], [QuantityPerUnit], [UnitsInStock]) VALUES (@ProductName, @CategoryID, @UnitPrice, @Discontinued, @QuantityPerUnit, @UnitsInStock)"
                                SelectCommand="SELECT [ProductID], [ProductName], [Products].[CategoryID], [Categories].[CategoryName] as CategoryName, [UnitPrice], [Discontinued], [QuantityPerUnit], [UnitsInStock] FROM [Products] JOIN Categories ON Products.CategoryID=Categories.CategoryID"
                                UpdateCommand="UPDATE [Products] SET [ProductName] = @ProductName, [CategoryID] = @CategoryID, [UnitPrice] = @UnitPrice, [Discontinued] = @Discontinued, [QuantityPerUnit] = @QuantityPerUnit, [UnitsInStock] = @UnitsInStock WHERE [ProductID] = @ProductID">
                                <DeleteParameters>
                                    <asp:Parameter Name="ProductID" Type="Int32"></asp:Parameter>
                                </DeleteParameters>
                                <InsertParameters>
                                    <asp:Parameter Name="ProductName" Type="String"></asp:Parameter>
                                    <asp:Parameter Name="CategoryID" Type="Int32"></asp:Parameter>
                                    <asp:Parameter Name="UnitPrice" Type="Decimal"></asp:Parameter>
                                    <asp:Parameter Name="Discontinued" Type="Boolean"></asp:Parameter>
                                    <asp:Parameter Name="QuantityPerUnit" Type="String"></asp:Parameter>
                                    <asp:Parameter Name="UnitsInStock" Type="Int16"></asp:Parameter>
                                </InsertParameters>
                                <UpdateParameters>
                                    <asp:Parameter Name="ProductName" Type="String"></asp:Parameter>
                                    <asp:Parameter Name="CategoryID" Type="Int32"></asp:Parameter>
                                    <asp:Parameter Name="UnitPrice" Type="Decimal"></asp:Parameter>
                                    <asp:Parameter Name="Discontinued" Type="Boolean"></asp:Parameter>
                                    <asp:Parameter Name="QuantityPerUnit" Type="String"></asp:Parameter>
                                    <asp:Parameter Name="UnitsInStock" Type="Int16"></asp:Parameter>
                                    <asp:Parameter Name="ProductID" Type="Int32"></asp:Parameter>
                                </UpdateParameters>
                            </asp:SqlDataSource>


                        </td>
                        <td class="auto-style29">&nbsp;</td>
                        <td style="height: 30px; text-align: right;">&nbsp;</td>
                    </tr>
                    <tr>
                        <td class="auto-style22">&nbsp;</td>
                        <td class="auto-style26"></td>
                        <td class="auto-style18">&nbsp;</td>
                        <td class="auto-style29">&nbsp;</td>
                        <td style="height: 30px; text-align: right;">&nbsp;</td>
                    </tr>
                    <tr>
                        <td class="auto-style8">&nbsp;</td>
                        <td class="auto-style26">&nbsp;</td>
                        <td class="auto-style18">&nbsp;</td>
                        <td class="auto-style29">&nbsp;</td>
                        <td class="auto-style9" style="height: 30px">&nbsp;</td>
                    </tr>
                    <tr>
                        <td class="auto-style22">&nbsp;</td>
                        <td class="auto-style25">&nbsp;</td>
                        <td class="auto-style31">&nbsp;</td>
                        <td class="auto-style27">&nbsp;</td>
                        <td>&nbsp;</td>
                    </tr>
                </table>
            </td>
        </tr>
    </table>



    <asp:SqlDataSource ID="SqlDataSource2" runat="server" ConnectionString="<%$ ConnectionStrings:INVENTORY %>"
        ProviderName="System.Data.SqlClient" 
        SelectCommand="SELECT [CategoryID], [CategoryName] FROM [Categories]">
    </asp:SqlDataSource>

     
    <telerik:ConfiguratorPanel runat="server" ID="ConfigurationPanel1">
        <views>
            <qsf:View>
                <qsf:ConfiguratorColumn runat="server" Title="Enter in edit mode on" Size="Narrow">
                    <qsf:RadioButtonList OnSelectedIndexChanged="rblChangeButtonType_SelectedIndexChanged"
                        RepeatDirection="Vertical" Width="150px" CellPadding="0" CellSpacing="0"
                        ID="rblChangeEditEventType" runat="server" AutoPostBack="True">
                        <asp:ListItem Value="click" Selected="True">Click</asp:ListItem>
                        <asp:ListItem Value="dblclick">Double Click</asp:ListItem>
                        <asp:ListItem Value="mousedown">Mouse Down</asp:ListItem>
                        <asp:ListItem Value="mouseup">Mouse Up</asp:ListItem>
                    </qsf:RadioButtonList>
                </qsf:ConfiguratorColumn>
                <qsf:ConfiguratorColumn runat="server" Title="Select EditType" Size="Narrow">
                    <qsf:RadioButtonList OnSelectedIndexChanged="rblChangeEditType_SelectedIndexChanged"
                        RepeatDirection="Vertical" Width="150px" CellPadding="0" CellSpacing="0"
                        ID="rblChangeEditType" runat="server" AutoPostBack="True">
                        <asp:ListItem Value="Row">Row</asp:ListItem>
                        <asp:ListItem Value="Cell" Selected="True">Cell</asp:ListItem>
                    </qsf:RadioButtonList>
                </qsf:ConfiguratorColumn>
            </qsf:View>
        </views>
    </telerik:ConfiguratorPanel>
        







</asp:Content>
