<%@ Page Title="" Language="C#" MasterPageFile="~/Site1.Master" AutoEventWireup="true" CodeBehind="WOMain.aspx.cs" Inherits="IMS.WOMain" %>

<%@ Register TagPrefix="telerik" Namespace="Telerik.Web.UI" Assembly="Telerik.Web.UI" %>

<asp:Content ID="Content1" ContentPlaceHolderID="HeadContent" runat="server">
    <style type="text/css">
        .auto-style10 {
            height: 10px;
            width: 50px;
        }
        .auto-style11 {
            width: 50px;
        }
        .auto-style12 {
            width: 11px;
        }
        .auto-style13 {
            height: 10px;
            width: 11px;
        }
        .auto-style14 {
            width: 16px;
        }
        .auto-style15 {
            height: 10px;
            width: 16px;
        }
        .auto-style16 {
            color: #DDE4EC;
            width: 16px;
        }
        .auto-style17 {
            height: 30px;
            width: 16px;
        }
    </style>
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">
</asp:Content>
<asp:Content ID="Content3" ContentPlaceHolderID="MainContent" runat="server">

     <table cellpadding="0" class="auto-style2">
       <tr>
        <td>
            <table align="center" cellpadding="0" class="auto-style4">
                <tr>
                    <td class="auto-style11">&nbsp;</td>
                    <td class="auto-style31">&nbsp;</td>
                    <td class="auto-style12">&nbsp;</td>
                    <td class="auto-style14">&nbsp;</td>
                </tr>
                <tr>
                    <td class="auto-style11">&nbsp;</td>
                    <td class="auto-style31">&nbsp;</td>
                    <td class="auto-style12">&nbsp;</td>
                    <td class="auto-style14">&nbsp;</td>
                </tr>
                <tr>
                    <td class="auto-style10" style="background-color: #F7F7F7; "></td>
                    <td class="auto-style31" style="background-color: #F7F7F7; height: 10px;"></td>
                    <td class="auto-style13" style="background-color: #F7F7F7; "></td>
                    <td style="background-color: #F7F7F7; " class="auto-style15"></td>
                </tr>
                <tr>
                    <td class="auto-style11" style="background-color: #F7F7F7"><strong>Work Order System</strong></td>
                    <td class="auto-style57" style="background-color: #F7F7F7">
                        <img alt="" class="auto-style64" src="images/Items.png" /></td>
                    <td class="auto-style12" style="background-color: #F7F7F7">
                      
                    </td>
                    <td class="auto-style14" style="background-color: #F7F7F7">&nbsp;</td>
                </tr>
                <tr>
                    <td class="auto-style11"></td>
                    <td class="auto-style21">&nbsp;</td>
                    <td class="auto-style12">&nbsp;</td>
                    <td class="auto-style16">&nbsp;</td>
                </tr>
                <tr>
                    <td class="auto-style11">
                        &nbsp;</td>
                    <td class="auto-style20">
                        <asp:TextBox ID="txtuserID" runat="server" Visible="False" Width="16px"></asp:TextBox>
&nbsp;
                        <asp:TextBox ID="txtbrhid" runat="server" Visible="False" Width="16px"></asp:TextBox>
                        </td>
                </tr>
                <tr>
                    <td class="auto-style11">
                        &nbsp;</td>
                    <td class="auto-style18">
                        <telerik:RadAjaxManager ID="RadAjaxManager1" runat="server">
                            <AjaxSettings>
                                <telerik:AjaxSetting AjaxControlID="RadGrid1">
                                    <UpdatedControls>
                                        <telerik:AjaxUpdatedControl ControlID="RadGrid1"></telerik:AjaxUpdatedControl>
                                        <telerik:AjaxUpdatedControl ControlID="RadGrid2" LoadingPanelID="RadAjaxLoadingPanel1"></telerik:AjaxUpdatedControl>
                                        <telerik:AjaxUpdatedControl ControlID="RadGrid3" LoadingPanelID="RadAjaxLoadingPanel1"></telerik:AjaxUpdatedControl>
                                    </UpdatedControls>
                                </telerik:AjaxSetting>
                                <telerik:AjaxSetting AjaxControlID="RadGrid2">
                                    <UpdatedControls>
                                        <telerik:AjaxUpdatedControl ControlID="RadGrid2"></telerik:AjaxUpdatedControl>
                                        <telerik:AjaxUpdatedControl ControlID="RadGrid3" LoadingPanelID="RadAjaxLoadingPanel1"></telerik:AjaxUpdatedControl>
                                    </UpdatedControls>
                                </telerik:AjaxSetting>
                                <telerik:AjaxSetting AjaxControlID="RadGrid3">
                                    <UpdatedControls>
                                        <telerik:AjaxUpdatedControl ControlID="RadGrid3"></telerik:AjaxUpdatedControl>
                                    </UpdatedControls>
                                </telerik:AjaxSetting>
                            </AjaxSettings>
                        </telerik:RadAjaxManager>

                        <telerik:RadFormDecorator RenderMode="Lightweight" runat="server" DecorationZoneID="demo" EnableRoundedCorners="false" DecoratedControls="All" />
                        <telerik:RadAjaxLoadingPanel ID="RadAjaxLoadingPanel1" runat="server" Skin="Default"></telerik:RadAjaxLoadingPanel>
                        <div class="demo-container no-bg">

                            <h3>Project/Estimate NO:
                                <asp:TextBox ID="txtEstimateno" runat="server" Width="87px"></asp:TextBox>
&nbsp;
                                <asp:Button ID="btnSearch" runat="server" OnClick="btnSearch_Click" Text="Search" Width="79px" />
                            </h3>
 
                             <br />
                            <br />


             <asp:UpdatePanel runat="server" ID="pnlUpdate_WoMain">
                 <ContentTemplate>

                                <telerik:RadGrid ID="RadGrid1" runat="server" AllowMultiRowEdit="True" AllowPaging="True"
                                        AllowSorting="True" CellSpacing="0" Culture="en-GB" GridLines="None" AllowAutomaticDeletes="False"
                                        AllowAutomaticUpdates="False" DataSourceID="tblWOMain" ShowFooter="True" Skin="WebBlue"
                                        Width="800px" OnItemUpdated="RadGrid1_ItemUpdated" MasterTableView-AllowAutomaticUpdates="True"
                                        AutoGenerateColumns="False" OnUpdateCommand="RadGrid1_UpdateCommand" OnItemDataBound="RadGrid1_ItemDataBound">
                        

                                <MasterTableView DataSourceID="tblWOMain" Width="100%"  AutoGenerateColumns="False" DataKeyNames="EstimateNo" CommandItemDisplay="Top" EditMode="PopUp">
                                    <Columns>
                                         <telerik:GridEditCommandColumn ButtonType="ImageButton" UniqueName="EditCommandColumn">
                                         </telerik:GridEditCommandColumn>

                                        <telerik:GridBoundColumn DataField="EstimateNo" DataType="System.Int32" FilterControlAltText="Filter EstimateNo column" HeaderText="EstimateNo" SortExpression="EstimateNo" UniqueName="EstimateNo">
                                            <ColumnValidationSettings>
                                                <ModelErrorMessage Text="" />
                                            </ColumnValidationSettings>
                                        </telerik:GridBoundColumn>
                                        <telerik:GridBoundColumn DataField="Description" FilterControlAltText="Filter Description column" HeaderText="Description" SortExpression="Description" UniqueName="Description">
                                            <ColumnValidationSettings>
                                                <ModelErrorMessage Text="" />
                                            </ColumnValidationSettings>
                                        </telerik:GridBoundColumn>
                                         <telerik:GridButtonColumn Text="Delete" CommandName="Delete" ButtonType="ImageButton"/>
                                    </Columns>

                               <%--     <EditFormSettings>
                                    <EditColumn UniqueName="EditCommandColumn1" FilterControlAltText="Filter EditCommandColumn1 column"></EditColumn>
                                    </EditFormSettings>--%>
                                </MasterTableView>

                                <ClientSettings AllowKeyboardNavigation="true" EnablePostBackOnRowClick="true">
                                    <Selecting AllowRowSelect="true"></Selecting>
                                </ClientSettings>
                                <PagerStyle Mode="NextPrevAndNumeric" />
                             </telerik:RadGrid>

               </ContentTemplate>
             </asp:UpdatePanel>
                            <asp:SqlDataSource ID="tblWOMain" runat="server" ConnectionString="<%$ ConnectionStrings:INVENTORY %>"
                              
                                SelectCommand="SELECT [EstimateNo],[Description] FROM [INVENTORY].[dbo].[tblWOMain] where fkUserID=@UserID">       
                                
                                 <SelectParameters>       
                                      <asp:ControlParameter ControlID="txtuserID" Name="UserID" DefaultValue="0" PropertyName="Text"></asp:ControlParameter>                                
                                 </SelectParameters>   
                                
                                                                                
                            </asp:SqlDataSource>
                  
                   <%--         <asp:EntityDataSource ID="EntityDataSource1" runat="server">
                            </asp:EntityDataSource>
                  
                            <asp:EntityDataSource ID="EntityDataSourceWOMain" runat="server" ConnectionString= "INVENTORY"
                                DefaultContainerName="INVENTORY" EntitySetName="tblWOMain" OrderBy="it.[EstimateNo]"
                                EntityTypeFilter="Description" EnableDelete="True" EnableInsert="True" EnableUpdate="True">
                            </asp:EntityDataSource>--%>

                            <br />
                            <br />
                            <h3>Work Details:</h3>
            
             <asp:UpdatePanel runat="server" ID="UpdatePanel_WOMaster">
                 <ContentTemplate>                            
                            
                     <telerik:RadGrid ID="RadGrid2" runat="server" AllowMultiRowEdit="True" AllowPaging="True"
                                        AllowSorting="True" CellSpacing="0" Culture="en-GB" GridLines="None" AllowAutomaticDeletes="False"
                                        AllowAutomaticUpdates="False" DataSourceID="tblWOMaster" ShowFooter="True" Skin="WebBlue"
                                        Width="800px" OnItemUpdated="RadGrid2_ItemUpdated" MasterTableView-AllowAutomaticUpdates="True"
                                        AutoGenerateColumns="False" OnUpdateCommand="RadGrid2_UpdateCommand" OnItemDataBound="RadGrid2_ItemDataBound">



                                <MasterTableView Width="100%" AutoGenerateColumns="False" DataKeyNames="EstMastID" DataSourceID="tblWOMaster" CommandItemDisplay="Top">
                                    <Columns>
                                        <telerik:GridEditCommandColumn ButtonType="ImageButton" UniqueName="EditCommandColumn">
                                        </telerik:GridEditCommandColumn>

                                        <telerik:GridBoundColumn DataField="EstMastID" DataType="System.Int32" HeaderText="EstMastID" ReadOnly="True" SortExpression="EstMastID" UniqueName="EstMastID" FilterControlAltText="Filter EstMastID column" Visible="false">
                                            <ColumnValidationSettings>
                                                <ModelErrorMessage Text=""></ModelErrorMessage>
                                            </ColumnValidationSettings>
                                        </telerik:GridBoundColumn>


                                        <telerik:GridBoundColumn DataField="EstimateNo" DataType="System.Int32" HeaderText="EstimateNo" ReadOnly="True" SortExpression="EstimateNo" UniqueName="EstimateNo" FilterControlAltText="Filter EstimateNo column">
                                            <ColumnValidationSettings>
                                                <ModelErrorMessage Text=""></ModelErrorMessage>
                                            </ColumnValidationSettings>
                                        </telerik:GridBoundColumn>
                                        <telerik:GridBoundColumn DataField="WorkNo" HeaderText="WorkNo" SortExpression="WorkNo" ReadOnly="True"
                                            UniqueName="WorkNo" DataType="System.Int32" FilterControlAltText="Filter WorkNo column">
                                            <ColumnValidationSettings>
                                                <ModelErrorMessage Text=""></ModelErrorMessage>
                                            </ColumnValidationSettings>
                                        </telerik:GridBoundColumn>
                                        <telerik:GridBoundColumn DataField="WorkDesc" HeaderText="WorkDesc" SortExpression="WorkDesc"
                                            UniqueName="WorkDesc" FilterControlAltText="Filter WorkDesc column">
                                            <ColumnValidationSettings>
                                                <ModelErrorMessage Text=""></ModelErrorMessage>
                                            </ColumnValidationSettings>
                                        </telerik:GridBoundColumn>
                                        <telerik:GridBoundColumn DataField="Cost" HeaderText="Cost" SortExpression="Cost"
                                            UniqueName="Cost" DataType="System.Decimal" FilterControlAltText="Filter Cost column">
                                            <ColumnValidationSettings>
                                                <ModelErrorMessage Text=""></ModelErrorMessage>
                                            </ColumnValidationSettings>
                                        </telerik:GridBoundColumn>

                                       
                                        <%--<telerik:GridBoundColumn DataField="OrderDate" DataType="System.DateTime" HeaderText="OrderDate"
                                                    SortExpression="OrderDate" UniqueName="OrderDate" DataFormatString="{0:d}">
                                            </telerik:GridBoundColumn>--%>
                                        <telerik:GridBoundColumn DataField="Paid" DataType="System.Decimal" FilterControlAltText="Filter Paid column" HeaderText="Paid" SortExpression="Paid" UniqueName="Paid">
                                            <ColumnValidationSettings>
                                                <ModelErrorMessage Text="" />
                                            </ColumnValidationSettings>
                                        </telerik:GridBoundColumn>

                                         <telerik:GridButtonColumn Text="Delete" CommandName="Delete" ButtonType="ImageButton" />
                                    </Columns>

                                   <%--  <EditFormSettings>
                                         <EditColumn ButtonType="ImageButton" />
                                     </EditFormSettings>--%>

                                    <EditFormSettings UserControlName="WOMainDetail.ascx" EditFormType="WebUserControl">
                                        <EditColumn UniqueName="EditCommandColumn1">
                                        </EditColumn>
                                    </EditFormSettings>

                                </MasterTableView>
                                <ClientSettings AllowKeyboardNavigation="true" EnablePostBackOnRowClick="true">
                                    <Selecting AllowRowSelect="true"></Selecting>
                                </ClientSettings>
                                <PagerStyle Mode="NextPrevAndNumeric"></PagerStyle>
                            </telerik:RadGrid>

              </ContentTemplate>
             </asp:UpdatePanel>

    <asp:SqlDataSource ID="tblWOMaster" ConnectionString="<%$ ConnectionStrings:INVENTORY %>"
        ProviderName="System.Data.SqlClient" 
        SelectCommand="SELECT EstMastID,EstimateNo,WorkNo,WorkDesc,Cost,Paid FROM [INVENTORY].[dbo].[tblWOMaster] WHERE ([EstimateNo] = @EstimateNo)" 
        DeleteCommand="DELETE FROM [tblWOMaster] WHERE ([EstimateNo] = @EstimateNo) AND ([WorkNo] = @WorkNo)"
        InsertCommand="INSERT INTO [tblWOMaster] ([EstimateNo], [WorkNo],[WorkDesc], [Cost]) VALUES (@EstimateNo, @WorkNo, @WorkDesc, @Cost)"
        UpdateCommand="UPDATE [tblWOMaster] SET [WorkDesc] = @WorkDesc, [Cost] = @Cost WHERE ([EstimateNo] = @EstimateNo) AND ([WorkNo] = @WorkNo)" runat="server">

        <SelectParameters>
            <asp:ControlParameter ControlID="RadGrid1" Name="EstimateNo" PropertyName="SelectedValue" Type="String"></asp:ControlParameter>
        </SelectParameters>


        <DeleteParameters>
            <asp:Parameter Name="EstimateNo" Type="Int32"></asp:Parameter>
            <asp:Parameter Name="WorkNo" Type="Int32"></asp:Parameter>
        </DeleteParameters>
        <InsertParameters>
            <asp:Parameter Name="EstimateNo" Type="Int32"></asp:Parameter>
            <asp:Parameter Name="WorkNo" Type="Int32"></asp:Parameter>
            <asp:Parameter Name="WorkDesc" Type="Decimal"></asp:Parameter>
            <asp:Parameter Name="Cost" Type="Int16"></asp:Parameter>
        </InsertParameters>
        <UpdateParameters>
            <asp:Parameter Name="WorkDesc" Type="Decimal"></asp:Parameter>
            <asp:Parameter Name="Cost" Type="Int16"></asp:Parameter>
            <asp:Parameter Name="EstimateNo" Type="Int32"></asp:Parameter>
            <asp:Parameter Name="WorkNo" Type="Int32"></asp:Parameter>
        </UpdateParameters>        
       

    </asp:SqlDataSource>




                            <br />
<%--                            <asp:EntityDataSource ID="EntityDataSourceWorkDetail" runat="server" ConnectionString= "INVENTORY>"
                                         DefaultContainerName="WOMaster" EntitySetName="tblWOMaster" OrderBy="it.[EstimateNo]"
                                         EntityTypeFilter="WorkDesc" EnableDelete="True" EnableFlattening="False" EnableInsert="True" EnableUpdate="True">
                            </asp:EntityDataSource>--%>
                            <br />
                            <h3>Payment details:</h3>
                            <telerik:RadGrid RenderMode="Lightweight" ID="RadGrid3" ShowStatusBar="True" runat="server" AllowPaging="True" AllowAutomaticUpdates="True"
                                PageSize="5" DataSourceID="SqlDataSource3" CellSpacing="0" GridLines="None" OnItemDataBound="RadGrid3_ItemDataBound">
                              
                                  <MasterTableView Width="100%" AutoGenerateColumns="False" DataKeyNames="WorkNo"
                                    DataSourceID="SqlDataSource3">
                                    <Columns>
                                         <telerik:GridEditCommandColumn ButtonType="ImageButton" UniqueName="EditCommandColumn">
                                        </telerik:GridEditCommandColumn>

                                        <telerik:GridBoundColumn DataField="EstimateNo" HeaderText="EstimateNo" SortExpression="EstimateNo"
                                            UniqueName="EstimateNo" DataType="System.Int32" FilterControlAltText="Filter EstimateNo column">
                                            <ColumnValidationSettings>
                                                <ModelErrorMessage Text=""></ModelErrorMessage>
                                            </ColumnValidationSettings>
                                        </telerik:GridBoundColumn>
                                        <telerik:GridBoundColumn DataField="WorkNo" HeaderText="WorkNo" SortExpression="WorkNo"
                                            UniqueName="WorkNo" DataType="System.Int32" FilterControlAltText="Filter WorkNo column">
                                            <ColumnValidationSettings>
                                                <ModelErrorMessage Text=""></ModelErrorMessage>
                                            </ColumnValidationSettings>
                                        </telerik:GridBoundColumn>
                                        <telerik:GridBoundColumn DataField="PayID" HeaderText="PayID" SortExpression="PayID"
                                            UniqueName="PayID" DataType="System.Int32" FilterControlAltText="Filter PayID column">
                                            <ColumnValidationSettings>
                                                <ModelErrorMessage Text=""></ModelErrorMessage>
                                            </ColumnValidationSettings>
                                        </telerik:GridBoundColumn>
                                        <telerik:GridBoundColumn DataField="fkVendID" DataType="System.Int32" FilterControlAltText="Filter fkVendID column" HeaderText="fkVendID" SortExpression="fkVendID" UniqueName="fkVendID">
                                            <ColumnValidationSettings>
                                                <ModelErrorMessage Text="" />
                                            </ColumnValidationSettings>
                                        </telerik:GridBoundColumn>
                                        <telerik:GridBoundColumn DataField="GrossAmt" DataType="System.Decimal" FilterControlAltText="Filter GrossAmt column" HeaderText="GrossAmt" SortExpression="GrossAmt" UniqueName="GrossAmt">
                                            <ColumnValidationSettings>
                                                <ModelErrorMessage Text="" />
                                            </ColumnValidationSettings>
                                        </telerik:GridBoundColumn>
                                        <telerik:GridBoundColumn DataField="PaidAmt" DataType="System.Decimal" FilterControlAltText="Filter PaidAmt column" HeaderText="PaidAmt" SortExpression="PaidAmt" UniqueName="PaidAmt">
                                            <ColumnValidationSettings>
                                                <ModelErrorMessage Text="" />
                                            </ColumnValidationSettings>
                                        </telerik:GridBoundColumn>
                                        <telerik:GridBoundColumn DataField="Discount" DataType="System.Decimal" FilterControlAltText="Filter Discount column" HeaderText="Discount" SortExpression="Discount" UniqueName="Discount">
                                            <ColumnValidationSettings>
                                                <ModelErrorMessage Text="" />
                                            </ColumnValidationSettings>
                                        </telerik:GridBoundColumn>
                                        <telerik:GridBoundColumn DataField="PayRecmd" DataType="System.Decimal" FilterControlAltText="Filter PayRecmd column" HeaderText="PayRecmd" SortExpression="PayRecmd" UniqueName="PayRecmd">
                                            <ColumnValidationSettings>
                                                <ModelErrorMessage Text="" />
                                            </ColumnValidationSettings>
                                        </telerik:GridBoundColumn>
                                        <telerik:GridBoundColumn DataField="BillInvoice" FilterControlAltText="Filter BillInvoice column" HeaderText="BillInvoice" SortExpression="BillInvoice" UniqueName="BillInvoice">
                                            <ColumnValidationSettings>
                                                <ModelErrorMessage Text="" />
                                            </ColumnValidationSettings>
                                        </telerik:GridBoundColumn>
                                        <telerik:GridBoundColumn DataField="PayDetail" FilterControlAltText="Filter PayDetail column" HeaderText="PayDetail" SortExpression="PayDetail" UniqueName="PayDetail">
                                            <ColumnValidationSettings>
                                                <ModelErrorMessage Text="" />
                                            </ColumnValidationSettings>
                                        </telerik:GridBoundColumn>
                                    </Columns>
                                            <EditFormSettings>
                                                <EditColumn ButtonType="ImageButton" />
                                            </EditFormSettings>

                                </MasterTableView>
                                <PagerStyle Mode="NextPrevAndNumeric"></PagerStyle>
                            </telerik:RadGrid>
                        </div>

                       

                        <%--"name=INVENTORY"--%>




                    </td>
                    <td class="auto-style12">
                        &nbsp;</td>
                    <td style="text-align: right;" class="auto-style17">
                        &nbsp;</td>
                </tr>
                <tr>
                    <td class="auto-style11">
                        </td>
                    <td class="auto-style18">
                        &nbsp;</td>
                    <td class="auto-style12">
                        &nbsp;</td>
                    <td style="text-align: right;" class="auto-style17">
                        &nbsp;</td>
                </tr>
                <tr>
                    <td class="auto-style11">
                        &nbsp;</td>
                    <td class="auto-style18">
                        &nbsp;</td>
                    <td class="auto-style12">
                        &nbsp;</td>
                    <td class="auto-style17">
                        &nbsp;</td>
                </tr>
                <tr>
                    <td class="auto-style11">&nbsp;</td>
                    <td class="auto-style31">&nbsp;</td>
                    <td class="auto-style12">&nbsp;</td>
                    <td class="auto-style14">&nbsp;</td>
                </tr>
            </table>
        </td>
    </tr>
    </table>
    
<%--    <asp:SqlDataSource ID="SqlDataSource1" ConnectionString="<%$ ConnectionStrings:INVENTORY %>"
        ProviderName="System.Data.SqlClient" 
        SelectCommand="SELECT [EstimateNo],[Description] FROM [INVENTORY].[dbo].[tblWOMain] where fkUserID=@UserID" runat="server">
         <SelectParameters>       
              <asp:ControlParameter ControlID="txtuserID" Name="UserID" DefaultValue="0" PropertyName="Text"></asp:ControlParameter>                                
         </SelectParameters>
    </asp:SqlDataSource>--%>



    <asp:SqlDataSource ID="SqlDataSource3" ConnectionString="<%$ ConnectionStrings:INVENTORY %>" ProviderName="System.Data.SqlClient"
        SelectCommand="SELECT [EstimateNo], [WorkNo], [PayID], [fkVendID], [GrossAmt], [PaidAmt], [Discount], [PayRecmd], [BillInvoice], [PayDetail] FROM [tblWODetail] WHERE (([EstimateNo] = @EstimateNo) AND ([WorkNo] = @WorkNo)) ORDER BY [WorkNo], [PayID]" runat="server">
        <SelectParameters>  
            <asp:ControlParameter ControlID="RadGrid1" Name="EstimateNo"  PropertyName="SelectedValue" Type="String"></asp:ControlParameter>          
            <asp:ControlParameter ControlID="RadGrid2" Name="WorkNo"  DefaultValue="1"  PropertyName="SelectedValue" Type="String"></asp:ControlParameter>
        </SelectParameters>
         
    </asp:SqlDataSource>

</asp:Content>
 
<%--
                
    --%>