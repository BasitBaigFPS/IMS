<%@ Page Title="" Language="C#" MasterPageFile="~/Site1.Master" AutoEventWireup="true" CodeBehind="SearchGINGRN.aspx.cs" Inherits="IMS.SearchGINGRN" %>

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

        .auto-style13 {
            height: 19px;
            width: 300px;
        }

        .auto-style18 {
            font-family: Arial, Helvetica, sans-serif;
            height: 30px;
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

        .auto-style31 {
            font-family: Arial, Helvetica, sans-serif;
            width: 34px;
        }

        .auto-style32 {
            width: 104px;
            font-family: Arial, Helvetica, sans-serif;
            font-size: xx-large;
        }

        .auto-style55 {
            width: 300px;
            font-family: Arial, Helvetica, sans-serif;
            font-size: large;
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
      <script type="text/javascript" src="http://ajax.googleapis.com/ajax/libs/jquery/1.9.1/jquery.min.js"></script>
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
                        <td class="auto-style55" style="background-color: #F7F7F7"><strong>Search GIN / GRN</strong></td>
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
                                        <td class="auto-style67">Search GIN:</td>
                                        <td class="auto-style67">
                                            <asp:TextBox ID="txtGINSearch" runat="server"></asp:TextBox>
                                        </td>
                                        <td class="auto-style67"></td>
                                        <td class="auto-style67">Search GRN:</td>
                                        <td class="auto-style67">
                                            <asp:TextBox ID="txtGRNSearch" runat="server"></asp:TextBox>
                                        </td>
                                    </tr>
                                    <tr>
                                        <td>&nbsp;</td>
                                        <td>
                                            <asp:Button ID="btnFIND" runat="server" OnClick="btnFIND_Click" Text="FIND" />
                                        </td>
                                        <td>&nbsp;</td>
                                        <td>
                                            &nbsp;</td>
                                        <td>
                                            <asp:Button ID="btnFINDGRN" runat="server" OnClick="btnFINDGRN_Click" Text="FIND" />
                                        </td>
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
                        <td class="auto-style62" colspan="4">

                            <asp:GridView ID="grdItems" runat="server" AlternatingRowStyle-CssClass="alt" AutoGenerateColumns="False"
                                class="table table-striped table-hover" OnRowCommand="grdItems_RowCommand" PagerStyle-CssClass="pgr"
                                Style="font-size: x-small; text-align: center;" Width="759px" OnRowDataBound="grdItems_RowDataBound" OnRowUpdated="grdItems_RowUpdated" OnRowEditing="grdItems_RowEditing">
                                <Columns>
                                    <asp:BoundField DataField="fkItemID" HeaderText="ItemCode" />
                                    <asp:BoundField DataField="InvCode" HeaderText="InventoryCode" />
                                    <asp:BoundField DataField="ItemTitle" HeaderText="Item Name" />
                                    <asp:TemplateField HeaderText="Qty Issued">
                                        <ItemTemplate>
                                            <asp:TextBox ID="txtqty" runat="server" AutoPostBack="true" autocomplete="off" ItemStyle-HorizontalAlign="Center" OnTextChanged="txtqty_TextChanged" Text='<%#Eval("Qtty") %>' Width="50px"></asp:TextBox>
                                        </ItemTemplate>
                                    </asp:TemplateField>
                                </Columns>
                            </asp:GridView>                      

                        </td>
                        <td style="height: 30px; text-align: right;">
                 
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


 



                        </td>
                    </tr>
    
                </table>
            </td>
        </tr>
    </table>
     </telerik:RadAjaxPanel>


</asp:Content>
