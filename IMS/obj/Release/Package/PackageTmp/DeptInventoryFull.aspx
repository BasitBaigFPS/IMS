<%@ Page Title="" Language="C#" MasterPageFile="~/Site1.Master" AutoEventWireup="true" CodeBehind="DeptInventoryFull.aspx.cs" Inherits="IMS.DeptInventoryFull" %>

<asp:Content ID="Content1" ContentPlaceHolderID="HeadContent" runat="server">
    <style type="text/css">

        a.LN1 {
            font-style:normal;
            font-weight:bold;
            font-size:1.0em;
        }

        a.LN2:link {
            color:#A4DCF5;
            text-decoration:none;
        }

        a.LN3:visited {
            color:#A4DCF5;
            text-decoration:none;
        }

        a.LN4:hover {
            color:#A4DCF5;
            text-decoration:none;
        }

        a.LN5:active {
            color:#A4DCF5;
            text-decoration:none;
        }

        .auto-style4 {
            border-collapse: collapse;
        }

        .auto-style6 {
            width: 104px;
            height: 19px;
        }

        .auto-style7 {
            height: 19px;
        }

        .auto-style8 {
            width: 104px;
            font-family: Arial, Helvetica, sans-serif;
            font-size: medium;
            height: 22px;
        }

        .auto-style9 {
            height: 22px;
        }

        .auto-style10 {
            width: 104px;
            font-family: Arial, Helvetica, sans-serif;
            font-size: medium;
            height: 33px;
            color: #C0C0C0;
        }

        .auto-style13 {
            height: 19px;
            width: 300px;
        }

        .auto-style15 {
            height: 33px;
            width: 300px;
        }

        .auto-style18 {
            font-family: Arial, Helvetica, sans-serif;
            height: 30px;
            width: 34px;
        }

        .auto-style20 {
            height: 33px;
            font-family: Arial, Helvetica, sans-serif;
            width: 34px;
        }

        .auto-style21 {
            height: 19px;
            font-family: Arial, Helvetica, sans-serif;
            width: 34px;
        }

        .auto-style22 {
            width: 104px;
            font-family: Arial, Helvetica, sans-serif;
            font-size: medium;
        }

        .auto-style25 {
            width: 300px;
        }

        .auto-style26 {
            height: 30px;
            width: 300px;
        }

        .auto-style27 {
            font-family: Arial, Helvetica, sans-serif;
            width: 97px;
        }

        .auto-style28 {
            height: 19px;
            font-family: Arial, Helvetica, sans-serif;
            width: 97px;
        }

        .auto-style29 {
            font-family: Arial, Helvetica, sans-serif;
            height: 30px;
            width: 97px;
        }

        .auto-style31 {
            font-family: Arial, Helvetica, sans-serif;
            width: 34px;
        }

        .auto-style32 {
            width: 104px;
            font-family: Arial, Helvetica, sans-serif;
            font-size: xx-large;
        }

        .auto-style44 {
            font-family: Arial, Helvetica, sans-serif;
            font-size: 12pt;
            width: 69px;
        }

        .auto-style45 {
            width: 69px;
        }

        .auto-style46 {
            width: 164px;
        }

        .auto-style47 {
            font-family: Arial, Helvetica, sans-serif;
            font-size: 12pt;
            width: 118px;
        }

        .auto-style48 {
            width: 118px;
        }

        .auto-style55 {
            width: 300px;
            font-family: Arial, Helvetica, sans-serif;
            font-size: xx-large;
            color: #C0C0C0;
            height: 55px;
        }

        .auto-style56 {
            width: 104px;
            font-family: Arial, Helvetica, sans-serif;
            font-size: xx-large;
            height: 55px;
        }

        .auto-style57 {
            font-family: Arial, Helvetica, sans-serif;
            width: 34px;
            height: 55px;
        }

        .auto-style58 {
            font-family: Arial, Helvetica, sans-serif;
            width: 97px;
            height: 55px;
        }

        .auto-style59 {
            height: 55px;
        }

        .auto-style61 {
            width: 300px;
            font-family: Arial, Helvetica, sans-serif;
            font-size: xx-large;
            color: #D1D1D1;
        }

        .auto-style62 {
            font-family: Arial, Helvetica, sans-serif;
            font-size: medium;
            color: #C0C0C0;
        }

        .auto-style63 {
            font-family: Arial, Helvetica, sans-serif;
            height: 30px;
            width: 97px;
            color: #C0C0C0;
        }

        .auto-style64 {
            width: 64px;
            height: 64px;
        }

        .auto-style66 {
            width: 100%;
        }
        .auto-style67 {
            height: 31px;
        }

        table#table1 {
    width:80%; 
    margin-left:10%; 
    margin-right:15%;
  }


    </style>

</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">
     <telerik:RadCodeBlock ID="dfg" runat="server">
        <script type="text/javascript">
            

        </script>

         <script type="text/javascript">
             function onRequestStart(sender, args) {
                 if (args.get_eventTarget().indexOf("ExportToExcelButton") >= 0 ||
                         args.get_eventTarget().indexOf("ExportToWordButton") >= 0 ||
                         args.get_eventTarget().indexOf("ExportToCsvButton") >= 0) {
                     args.set_enableAjax(false);
                 }
             }
    </script>

         
    <telerik:RadAjaxManager ID="RadAjaxManager1" runat="server">
        <ClientEvents OnRequestStart="onRequestStart" />
        <AjaxSettings>
            <telerik:AjaxSetting AjaxControlID="grdStore">
                <UpdatedControls>
                    <telerik:AjaxUpdatedControl ControlID="grdStore" />
                </UpdatedControls>
            </telerik:AjaxSetting>
        </AjaxSettings>
    </telerik:RadAjaxManager>

    </telerik:RadCodeBlock>
 
     <telerik:RadAjaxPanel ID="RadAjaxPanel2" runat="server" Width="300px" HorizontalAlign="NotSet" LoadingPanelID="RadAjaxLoadingPanel2" RenderMode="Inline">

    <table id="table1" cellpadding="0" class="auto-style2" width="50%">
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
                        <td class="auto-style32" style="background-color: #F7F7F7; height: 10px;"></td>
                        <td class="auto-style61" style="background-color: #F7F7F7; height: 10px;"></td>
                        <td class="auto-style31" style="background-color: #F7F7F7; height: 10px;"></td>
                        <td class="auto-style27" style="background-color: #F7F7F7; height: 10px;"></td>
                        <td style="background-color: #F7F7F7; height: 10px;"></td>
                    </tr>
                    <tr>
                        <td class="auto-style56" style="background-color: #F7F7F7; text-align: center;">
                            <img alt="" class="auto-style64" src="images/Items.png" /></td>
                        <td class="auto-style55" style="background-color: #F7F7F7"><strong>Department Inventory</strong></td>
                        <td class="auto-style57" style="background-color: #F7F7F7"></td>
                        <td class="auto-style58" style="background-color: #F7F7F7"></td>
                        <td class="auto-style59" style="background-color: #F7F7F7"></td>
                    </tr>
                    <tr>
                        <td class="auto-style6"></td>
                        <td class="auto-style13"></td>
                        <td class="auto-style21">&nbsp;</td>
                        <td class="auto-style28">&nbsp;</td>
                        <td class="auto-style7">&nbsp;</td>
                    </tr>
                    <tr>
                        <td class="auto-style62" colspan="5">
                           <%-- <telerik:RadAjaxPanel ID="RadAjaxPanel2" runat="server" Width="300px" HorizontalAlign="NotSet" LoadingPanelID="RadAjaxLoadingPanel2" RenderMode="Inline">--%>
                                <table class="auto-style66">
                                    <tr>
                                        <td class="auto-style67">Branch</td>
                                        <td class="auto-style67">
                                            <telerik:RadComboBox ID="cmbbranch" Runat="server" AutoPostBack="True" MarkFirstMatch="True"  Sort="Ascending" Width="300px" OnSelectedIndexChanged="cmbbranch_SelectedIndexChanged">
                                            </telerik:RadComboBox>
                                        </td>
                                        <td class="auto-style67"></td>
                                        <td class="auto-style67">Department</td>
                                        <td class="auto-style67">
                                            <telerik:RadComboBox ID="cmbDepartment" Runat="server" AutoPostBack="True" MarkFirstMatch="True"  Sort="Ascending" Width="300px" OnSelectedIndexChanged="cmbDepartment_SelectedIndexChanged">
                                            </telerik:RadComboBox>
                                        </td>
                                    </tr>
                                    <tr>
                                        <td>&nbsp;</td>
                                        <td>
                                            &nbsp;</td>
                                        <td>&nbsp;</td>
                                        <td>&nbsp;</td>
                                        <td>&nbsp;</td>
                                    </tr>
                                </table>
                       
                        </td>
                    </tr>
                    <tr>
                        <td class="auto-style62">&nbsp;</td>
                        <td class="auto-style26">
          
                        </td>
                        <td class="auto-style18">&nbsp;</td>
                        <td class="auto-style63">&nbsp;</td>
                        <td style="height: 30px">&nbsp;</td>
                    </tr>
                    <tr>
                        <td class="auto-style62">&nbsp;</td>
                        <td class="auto-style26">&nbsp;</td>
                        <td class="auto-style18">&nbsp;</td>
                        <td class="auto-style63">&nbsp;</td>
                        <td style="height: 30px; text-align: right;">
                            <telerik:RadButton ID="btnSubmit" runat="server" Text="Submit" Font-Size="10pt" Height="30px" visible="false" ButtonType="SkinnedButton" OnClick="btnSubmit_Click">
                            </telerik:RadButton>
                        </td>
                    </tr>
                    <tr>
                        <td class="auto-style62">&nbsp;</td>
                        <td class="auto-style26">&nbsp;</td>
                        <td class="auto-style18">&nbsp;</td>
                        <td class="auto-style63">&nbsp;</td>
                        <td style="height: 30px; text-align: right;">&nbsp;</td>
                    </tr>
                    <tr>
                        <td class="auto-style62" colspan="5">

                           
                              <%--  <table id="studentTable" width="100%" align="center" cellpadding="2" cellspacing="2" border="0" bgcolor="#EAEAEA" >  
                                    <tr align="left" style="background-color:#004080;color:White;" >  
                                        <td>Inventory Code</td>                                          
                                        <td>Item Title</td>  
                                        <td>OPBalance</td>  
                                        <td>QttyReceived</td>  
                                        <td>QttyIssued</td>  
                                        <td>Current Balance</td>  
                                    </tr><%=getStoreData()%>  
                                </table>  
                            --%>



 


                               <telerik:RadGrid ID="grdDepartment" runat="server" AutoGenerateColumns="False" GridLines="Both" GroupPanelPosition="Top"  AllowFilteringByColumn="True" AllowSorting="True" OnNeedDataSource="grdDepartment_NeedDataSource" OnItemCommand="grdDepartment_ItemCommand">
                                   <SortingSettings SortedBackColor="Aqua" />
                                <ExportSettings FileName="ItemList" OpenInNewWindow="True" ExportOnlyData="True" IgnorePaging="True">
                                </ExportSettings>
                                   <ClientSettings AllowDragToGroup="True">
                                       <Selecting AllowRowSelect="True" CellSelectionMode="MultiColumn" />
                                       <Resizing AllowColumnResize="True" AllowResizeToFit="True" AllowRowResize="True" EnableRealTimeResize="True" ResizeGridOnColumnResize="True" ShowRowIndicatorColumn="False" />
                                       <Animation AllowColumnReorderAnimation="True" />
                                   </ClientSettings>
                                   <MasterTableView CommandItemDisplay="Top" AllowMultiColumnSorting="True"  ShowFooter="True">
                                       <CommandItemSettings ShowAddNewRecordButton="False" ShowExportToExcelButton="True" />
                                       <RowIndicatorColumn Visible="False">
                                       </RowIndicatorColumn>
                                       <Columns>
                                           <telerik:GridHyperLinkColumn AllowSorting="False" DataNavigateUrlFields="Inventory Code" DataNavigateUrlFormatString="ReportsMain.aspx?rptname=ItemLedger&amp;INVCode={0}" DataTextField="Inventory Code" FilterControlAltText="Filter column column" HeaderText="Inv. Code" Target="_new" UniqueName="column">
                                               <ItemStyle Font-Bold="True" Font-Underline="True" ForeColor="Blue" />
                                           </telerik:GridHyperLinkColumn>
                                           <telerik:GridBoundColumn DataField="ItemTitle" FilterControlAltText="Filter column1 column" HeaderText="Item Title" UniqueName="column1">
                                               <ColumnValidationSettings>
                                                   <ModelErrorMessage Text="" />
                                               </ColumnValidationSettings>
                                           </telerik:GridBoundColumn>
                                           <telerik:GridBoundColumn DataField="OPBalance" FilterControlAltText="Filter column2 column" HeaderText="Opening_Balance" UniqueName="column2">
                                               <ColumnValidationSettings>
                                                   <ModelErrorMessage Text="" />
                                               </ColumnValidationSettings>
                                               <ItemStyle HorizontalAlign="Center" VerticalAlign="Middle" />
                                           </telerik:GridBoundColumn>
                                           <telerik:GridBoundColumn DataField="QttyReceived" FilterControlAltText="Filter column3 column" HeaderText="Receive" UniqueName="column3">
                                               <ColumnValidationSettings>
                                                   <ModelErrorMessage Text="" />
                                               </ColumnValidationSettings>
                                               <ItemStyle HorizontalAlign="Center" VerticalAlign="Middle" />
                                           </telerik:GridBoundColumn>
                                           <telerik:GridBoundColumn DataField="QttyIssued" FilterControlAltText="Filter column4 column" HeaderText="Issued" UniqueName="column4">
                                               <ColumnValidationSettings>
                                                   <ModelErrorMessage Text="" />
                                               </ColumnValidationSettings>
                                               <ItemStyle HorizontalAlign="Center" VerticalAlign="Middle" />
                                           </telerik:GridBoundColumn>
                                           <telerik:GridBoundColumn DataField="Current Balance" FilterControlAltText="Filter column5 column" HeaderText="Balance" UniqueName="column5">
                                               <ColumnValidationSettings>
                                                   <ModelErrorMessage Text="" />
                                               </ColumnValidationSettings>
                                               <ItemStyle HorizontalAlign="Center" VerticalAlign="Middle" />
                                           </telerik:GridBoundColumn>
                                       </Columns>
                                       <PagerStyle AlwaysVisible="True" />
                                   </MasterTableView>
                                   <FilterItemStyle ForeColor="#00C000" />
                                   <ItemStyle HorizontalAlign="Left" VerticalAlign="Middle" />
                                   <PagerStyle AlwaysVisible="True" Position="TopAndBottom" />
                                   <SelectedItemStyle ForeColor="Purple" />
                            </telerik:RadGrid>




                        </td>
                    </tr>
    
                </table>
            </td>
        </tr>
    </table>
     </telerik:RadAjaxPanel>


</asp:Content>
