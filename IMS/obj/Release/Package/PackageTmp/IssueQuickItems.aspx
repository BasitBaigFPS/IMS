<%@ Page Title="" Language="C#" MasterPageFile="~/Site1.Master" AutoEventWireup="true" CodeBehind="IssueQuickItems.aspx.cs" Inherits="IMS.IssueQuickItems" %>
<%@ Register assembly="AjaxControlToolkit" namespace="AjaxControlToolkit" tagprefix="asp" %>

<%@ Register Assembly="AjaxControlToolkit" Namespace="AjaxControlToolkit" TagPrefix="cc1" %>

<asp:Content ID="Content1" ContentPlaceHolderID="HeadContent" runat="server">
    <style type="text/css">
        .auto-style4 {
            border-collapse: collapse;
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

        .auto-style12 {
            width: 1166px;
        }

        .auto-style14 {
            width: 166px;
        }

        .auto-style15 {
            height: 22px;
            width: 166px;
        }

        .auto-style19 {
            width: 434px;
            font-family: Arial, Helvetica, sans-serif;
            font-size: medium;
            height: 33px;
            color: #C0C0C0;
        }

        .auto-style20 {
            height: 33px;
            width: 434px;
        }

        .newStyle1 {
            font-family: Calibri;
            font-size: large;
            text-align: center;
        }

        .auto-style21 {
            height: 19px;
            font-size: large;
        }

        .auto-style27 {
            height: 22px;
            width: 166px;
            background-color: #0066FF;
        }

        .auto-style28 {
            font-family: Arial, Helvetica, sans-serif;
            font-size: medium;
            height: 22px;
        }

        .auto-style29 {
            font-size: medium;
        }

        </style>
    <link href="CSS/GridViewStyle1.css" rel="stylesheet" type="text/css" />
</asp:Content>

<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">

     <%--<script type="text/javascript">--%>
     <script type="text/javascript">

         function CheckBalance(crbal, rowindex)
         {
             var i;
             i = parseInt(rowindex);

             var str = "MainContent_grdItems_txtqty_" + i;
             var CellV = document.getElementById(str);
             var CellValue = document.getElementById(str).value;
             var noval = 0;
             if (CellValue > parseFloat(crbal)) {                  
                 alert("Please Enter Quantity Less Than or Equal To Current Balance!!!");
                 //CellV.innerHTML = parseFloat("0");
                 //document.getElementById(str).value = parseFloat("0");
                 document.getElementById(str).value = parseFloat(crbal);
                 return false;
             }
             else {
                 return true;
             }
 
         }


         function IsNumeric(e, rowindex) {


             var i = parseInt(rowindex);

             var str = "MainContent_grdItems_txtqty_" + i;
             //cellval = parseFloat(document.getElementById(str).innerHTML != "NaN" ? document.getElementById(str).innerHTML : "0");
             var CellValue = document.getElementById(str);

             e = (e) ? e : window.event;
             var charCode = (e.which) ? e.which : e.keyCode;

             if (e.keyCode > 47 && e.keyCode < 58 || charCode >= 96 && charCode <= 105 || $.inArray(e.keyCode, [46, 8, 9, 27, 13, 110, 190]) !== -1) {
                 return;
             }
             else {
                 //CellValue.innerHTML = parseFloat("0");
                 alert("Please Enter Only Numeric Value...");
                 document.getElementById(str).value = parseFloat("0");
                 e.preventDefault();

                 return false;
             }

         }


         function clickEnter(obj, event) {
             var keyCode;
             if (event.keyCode > 0) {
                 keyCode = event.keyCode;
             }
             else if (event.which > 0) {
                 keyCode = event.which;
             }
             else {
                 keycode = event.charCode;
             }
             if (keyCode == 13) {
                 //  obj.select();
                 document.getElementById(obj).focus();

                 return false;
             }
             else {
                 return true;
             }
         }

         function getPassword() {
             var pwd = prompt('Please enter your password:', '');

             if (pwd != null) {
                 if (pwd != '') {
                     document.getElementById('hidPassword').value = pwd;
                     return true;
                 }
             }

             return false;
         }

       </script>

</asp:Content>

<asp:Content ID="Content3" ContentPlaceHolderID="MainContent" runat="server">

    

<%--<asp:LinkButton ID="lnkDummy" runat="server"></asp:LinkButton>
<cc1:ModalPopupExtender ID="ModalPopupExtender1" BehaviorID="mpe" runat="server"
    PopupControlID="pnlPopup" TargetControlID="lnkDummy" BackgroundCssClass="modalBackground" CancelControlID = "btnHide">
</cc1:ModalPopupExtender>
<asp:Panel ID="pnlPopup" runat="server" CssClass="modalPopup" Style="display: none">
    <div class="header">
       Confirmation Required!!!
    </div>
    <div class="body">
        Please Enter The Password:
        <br />
        <asp:Button ID="btnHide" runat="server" Text="Hide Modal Popup" />
    </div>
</asp:Panel>--%>



    <div class="CSSTableGenerator">


        <table class="auto-style12">

            <tr>
                <td class="auto-style28" colspan="5">
                    <h1 style="font-weight: bold; font-size: medium; color: #000000;"><span style="text-align: center">
                        <em>ISSUE ITEMS INTERNAL</em></span></h1>
                </td>
            </tr>


            <tr>
                <td class="auto-style8">&nbsp;</td>
                <td colspan="2" style="valign="middle" align="center">
                    &nbsp;</td>
               
                <td class="auto-style4">
                    <telerik:RadButton ID="btnRefresh" runat="server" Text="Refresh" Font-Size="10pt" Height="30px" ButtonType="SkinnedButton" OnClick="btnRefresh_Click" Width="72px">
                        </telerik:RadButton>
                </td>
                <td class="auto-style14">&nbsp;</td>
            </tr>
            <tr>
                <td class="auto-style21">&nbsp;</td>
                <td class="auto-style20">

                    <asp:RadioButtonList ID="rdoGIN" runat="server" AutoPostBack="True" OnSelectedIndexChanged="rdoGIN_SelectedIndexChanged" RepeatDirection="Horizontal" Style="font-size: small" Width="427px" Font-Bold="True" ForeColor="Black">
                        <asp:ListItem Value="N">New GIN</asp:ListItem>
                        <asp:ListItem Value="O">OLD/Existing GIN</asp:ListItem>
                    </asp:RadioButtonList>
                </td>                
                <td class="auto-style19">
                   <span style="font-size: small"> GIN Number : </span>
                    <asp:TextBox ID="txtginno" runat="server" BorderColor="#000066" BorderWidth="1px" Height="20px" Style="font-size: medium; font-weight: 700; text-align: center; color: #009933;" TabIndex="5" Width="75px"></asp:TextBox>
                &nbsp;&nbsp; 
                    &nbsp;<a href="ReportsMain.aspx?rptname=GoodsIssueNote&amp;gino=<%= txtginno.Text %>" target="_blank"><span class="auto-style29">Print GIN</span></a><br />

                </td>
                <td class="auto-style27" valign="middle">&nbsp;
                    <telerik:RadButton ID="btnClose" runat="server" Text="Close" Font-Size="10pt" Height="30px" ButtonType="SkinnedButton" OnClick="btnClose_Click" Width="72px">
                        </telerik:RadButton>
                </td>
                 <td class="auto-style14"></td>
            </tr>

             <tr>
                <td class="auto-style7">&nbsp;</td>
                <td style="text-align: left"><span style="font-size: small">Search Item:
                </span>

                    <telerik:RadComboBox RenderMode="Lightweight" ID="cmbItemSearch" AllowCustomText="true" runat="server" Width="500" Height="400px" filter="Contains"
                        AutoPostBack="True" MarkFirstMatch="True" Sort="Ascending"  CheckBoxes="true" EnableCheckAllItemsCheckBox="true" EmptyMessage="Search for items...">
                    </telerik:RadComboBox>

                </td>
                <td class="auto-style19">&nbsp;
                    <asp:Literal ID="itemsClientSide" runat="server"></asp:Literal>
                    <asp:Label ID="lblItems" runat="server" Text="Items List" Visible="False"></asp:Label>
                    <asp:Label ID="lblItemID" runat="server" Text="ItemID" Visible="False"></asp:Label>

                </td>
                <td class="auto-style15">&nbsp;</td>
                 <td class="auto-style14"></td>
            </tr>


            <tr>
                <td class="auto-style7">&nbsp;</td>
                <td style="text-align: left"><span style="font-size: small">Issued To:&nbsp;&nbsp;&nbsp;
                </span>
                

                    <telerik:RadComboBox RenderMode="Lightweight" ID="cmbPersonto" AllowCustomText="true" runat="server" Width="300" Height="400px" filter="Contains"
                              CheckBoxes="true" EnableCheckAllItemsCheckBox="true" EmptyMessage="Search for people...">
                    </telerik:RadComboBox>



             
                </td>
                <td class="auto-style19">&nbsp;
                     <asp:Literal ID="staffClientSide" runat="server"></asp:Literal>
                    <asp:Label ID="lblStaff" runat="server" Text="Staff List" Visible="False"></asp:Label>
                    <asp:Label ID="lblStaffID" runat="server" Text="Staff ID" Visible="False"></asp:Label>

                </td>
                <td class="auto-style15">&nbsp;</td>
                 <td class="auto-style14"></td>
            </tr>
         
             <tr>
                 <td class="auto-style7">&nbsp;</td>
                  <td style="text-align: left"><span style="font-size: small"> </span>
                    <asp:TextBox ID="txtpersonid" runat="server" BorderColor="#000066" BorderWidth="1px" Height="20px" onkeydown="addItem(event);" style="font-size: x-small" TabIndex="5" Width="350px" Visible="False"></asp:TextBox>
                </td>
                <td class="auto-style77">&nbsp;</td>
                <td class="auto-style15">&nbsp;</td>
                <td class="auto-style14"></td>
             </tr>

            <tr>
                <td class="auto-style7">&nbsp;</td>
                <td style="text-align: left"><span style="font-size: small">
                </span>
                    
                </td>
                <td class="auto-style9">
                    <telerik:RadButton ID="btnSubmitItem" runat="server" ButtonType="SkinnedButton" Font-Size="10pt" Height="30px" OnClick="btnSubmitItem_Click" Text="Add Item" ValidationGroup="A" Visible="True">
                    </telerik:RadButton>
                </td>
                <td class="auto-style15">&nbsp;</td>
                <td class="auto-style14"></td>
            </tr>
            <tr>
                <td>&nbsp;</td>
                <td align="center" colspan="4" style="font-family: Calibri;  font-weight: normal; font-size: 14px;" valign="top">

                    <div id="mirdiv" style="display: none" runat="server">
                        <table cellspacing="1" style="width: 100%" align="center">
                        
                            <tr>
                                <td>&nbsp;</td>
                                <td>&nbsp;</td>
                                <td>&nbsp;</td>
                                <td>&nbsp;</td>
                                <td>&nbsp;</td>
                            </tr>

                            <tr>

                                <td colspan="3" style="width: 350px; text-align: left;" align="center">
                                    <asp:GridView ID="grdItems" runat="server" AlternatingRowStyle-CssClass="alt" AutoGenerateColumns="False" CssClass="mGrid" 
                                        OnRowCommand="grdItems_RowCommand" OnRowDeleting="grdItems_RowDeleting" 
                                        OnRowEditing="grdItems_RowEditing" OnRowUpdating="grdItems_RowUpdating" 
                                        OnRowUpdated="grdItems_RowUpdated" OnSorting="grdItems_Sorting" OnDataBound="grdItems_DataBound" OnRowDataBound="grdItems_RowDataBound"
                                        PagerStyle-CssClass="pgr" Style="font-size: x-small; text-align: left;" Width="865px" HorizontalAlign="Center">
                                        <AlternatingRowStyle CssClass="alt" />
                                        <Columns>

                                            <asp:CommandField ShowDeleteButton="True" />
 
                                             <asp:TemplateField HeaderText="Item Code" Visible="True">
                                                                <ItemTemplate>
                                                                <asp:Label ID="lblItemID" runat="server" Text='<%#Eval("Item Code") %>' Width="50px" />
                                                                </ItemTemplate>
                                                                <ItemStyle HorizontalAlign="Right" VerticalAlign="Middle" />
                                             </asp:TemplateField>
                                            <asp:BoundField DataField="Item Name" HeaderText="Item Name" />
     
                                            <asp:TemplateField HeaderText="Balance">
                                                <ItemTemplate>
                                                   <asp:Label ID="lblbalance" runat="server" Text='<%#Eval("Balance") %>' Width="50px" />
                                                </ItemTemplate>
                                                    <ItemStyle HorizontalAlign="Right" VerticalAlign="Middle" />
                                            </asp:TemplateField>
                                            <asp:TemplateField HeaderText="Qty Issued">
                                                <ItemTemplate>
                                                    <%--<asp:TextBox ID="txtqty" runat="server" AutoPostBack="True" OnTextChanged="txtqty_TextChanged" Text='<%#Eval("Qty Issued") %>' Width="50px"></asp:TextBox>--%>
                                                    <asp:TextBox ID="txtqty" runat="server" AutoPostBack="false" autocomplete="off" OnTextChanged="txtqty_TextChanged" Text='<%#Eval("Qty Issued") %>' onclick="GridRowNo(<%# Container.DataItemIndex %>,this);" Width="50px"></asp:TextBox>
                                                </ItemTemplate>
                                            </asp:TemplateField>                                        


                                        </Columns>
                                        <PagerStyle CssClass="pgr" />
                                    </asp:GridView>
                                </td>
                            </tr>
                            
                           <%--  <tr>
                                <td class="auto-style81">&nbsp;</td>
                                <td class="auto-style89">&nbsp;</td>
                                <td>&nbsp;</td>
                                <td class="auto-style85">&nbsp;</td>
                                <td>&nbsp;</td>
                            </tr>--%>

                           

                        </table>
                    </div>

                    </td>
            </tr>
             <tr>
                <td align="left" colspan="5" style="width: 350px">
                      <asp:Label ID="lblRecvName" runat="server" Font-Bold="True" ForeColor="Blue" Text="Remarks: (Use This Text Box to Mention any Remarks or Multiple Person(s) Name to Whom you Issue Selected Items)" Width="700px"></asp:Label>   
                     <asp:TextBox ID="txtremarks" runat="server" BorderColor="#000066" BorderWidth="1px" Height="20px" onkeydown="addItem(event);" style="font-size: x-small" TabIndex="5" Width="861px"></asp:TextBox>
                    </td>
                </tr>
            <tr>
                <td class="auto-style7">&nbsp;</td>
                <td class="auto-style20">&nbsp;</td>
                <td style="text-align: right">
                    &nbsp;</td>
                <td class="auto-style15">&nbsp;</td>
                 <td class="auto-style14">&nbsp;</td>
            </tr>
           


            <tr>
                <td class="auto-style7">&nbsp;</td>
                <td class="auto-style20">&nbsp;</td>
                <td style="text-align: right">
                    <asp:Button ID="btnConfirm" runat="server" OnClick="btnConfirm_Click" Text="Confirm Issued" Width="176px" />
                </td>
                <td class="auto-style15">&nbsp;</td>
                 <td class="auto-style14"></td>
            </tr>
           


        </table>

    </div>

   

</asp:Content>

