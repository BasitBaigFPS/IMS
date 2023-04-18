<%@ Page Title="" Language="C#" MasterPageFile="~/Site1.Master" AutoEventWireup="true" CodeBehind="StaffReceived.aspx.cs" Inherits="IMS.StaffReceived" %>


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

        .auto-style25 {
            text-align: left;
        }

        .auto-style27 {
            height: 22px;
            width: 166px;
            background-color: #0066FF;
        }

        .auto-style28 {
            font-size: medium;
        }

        </style>
    <link href="CSS/GridViewStyle1.css" rel="stylesheet" type="text/css" />
</asp:Content>




<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">

     <script type="text/javascript">

         function IsNumeric(e, rowindex) {


             var i = parseInt(rowindex);

             var str = "ContentPlaceHolder1_grdItems_txtrate_" + i;
             //cellval = parseFloat(document.getElementById(str).innerHTML != "NaN" ? document.getElementById(str).innerHTML : "0");
             var CellValue = document.getElementById(str);

             if (e.keyCode > 47 && e.keyCode < 58 || $.inArray(e.keyCode, [46, 8, 9, 27, 13, 110, 190]) !== -1) {
                 return;
             }
             else {
                 CellValue.innerHTML = parseFloat("0");
                 alert("Please Enter Only Numeric Value...");
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

         function addItem(event) {

             var keyCode = ('which' in event) ? event.which : event.keyCode;

             if (keyCode == 13)
                 document.getElementById('<%=txtgrnno.ClientID%>').click();
             }

         function GridRowNo(r, obj) {
             TotalAmount(r, obj);
             cell = document.getElementById('<%=grdItems.ClientID %>').rows[parseInt(r) + 1].cells[1];
            setFocusToTextBox(obj);

            return r;
            // Function returns the product of a and b
        }

        function setFocusToTextBox(obj) {
            document.getElementById(obj).focus();
        }

        $(document).ready(function () {

            var x = GridRowNo(r);

            var divLoc = $('#idVal').offset();
            //$('html, body').animate({ scrollTop: divLoc.left }, "fast");

            $('html, body').animate({
                scrollTop: 2000,
                scrollLeft: 300
            }, 1000);

        });

        function CheckGrid(source) {
            var isChecked = source.checked;
            $("#chkGrid input[id*='ChoiceGrade']").each(function (index) {
                $(this).attr('checked', false);
            });
            source.checked = isChecked;

        }

        function Confirm() {
            var confirm_value = document.createElement("INPUT");
            confirm_value.type = "hidden";
            confirm_value.name = "confirm_value";
            if (confirm("Do you want to Reprocess New Year Strength?")) {
                confirm_value.value = "Yes";
            } else {
                confirm_value.value = "No";
            }
            document.forms[0].appendChild(confirm_value);
        }


        function Confirm(system) {
            //This Function Work with ASP Button Not with RadControlButton.
            var choice = confirm("Are You Sure?, You Want to Finalize '" + system + "' Annual Syllabus Requisition & MIR?", "Yes", "No");
            if (choice == false) {
                return false;
            }
        }
 

     </script>



     <div class="CSSTableGenerator">


        <table>

            <tr>
                <td class="auto-style8"></td>
                <td colspan="2" style="valign="middle" align="center">
                    <h1 style="font-weight: bold; font-size: medium; color: #000000;">
                        <span style="text-align: center">I T E M S&nbsp;&nbsp;&nbsp;&nbsp; R E T U R N&nbsp;&nbsp;&nbsp;&nbsp; F R O M &nbsp;&nbsp;&nbsp;S T A F F</span>
                    </h1>
                </td>
               
                <td class="auto-style4"></td>
                <td class="auto-style14"></td>
            </tr>
            <tr>
                <td class="auto-style21">&nbsp;</td>
                <td class="auto-style20">&nbsp;</td>                
                <td class="auto-style19">&nbsp;</td>
                <td class="auto-style27" valign="middle">&nbsp;
                    <telerik:RadButton ID="btnClose" runat="server" Text="Close" Font-Size="10pt" Height="30px" ButtonType="SkinnedButton" OnClick="btnClose_Click" Width="72px">
                        </telerik:RadButton>
                </td>
                 <td class="auto-style14"></td>
            </tr>
            <tr>
                <td class="auto-style21">&nbsp;</td>
                <td align="left" class="auto-style25" style="text-align: left">&nbsp;</td>
                <td class="auto-style19">&nbsp;</td>
                <td class="auto-style15">
                    &nbsp;</td>
                 <td class="auto-style14">
                      
                     
                     &nbsp;</td>
            </tr>


            <tr>
                <td class="auto-style21">&nbsp;</td>
                <td align="left" class="auto-style25" style="text-align: left">SELECT SYSTEM: 
                    
                     <telerik:RadComboBox ID="cmbSystem" runat="server" AutoPostBack="True" MarkFirstMatch="True" OnSelectedIndexChanged="cmbSystem_SelectedIndexChanged" Sort="Ascending" Width="300px">
                     </telerik:RadComboBox>
              </td>
                <td class="auto-style19">&nbsp;</td>
                <td class="auto-style15">
                    &nbsp;</td>
                 <td class="auto-style14">
                      
                     
                     &nbsp;</td>
            </tr>

            <tr>
                <td class="auto-style114" colspan="1">From Branch</td>
                <td class="auto-style89">
                    <telerik:RadComboBox ID="cmbbranchfrom" Runat="server" AutoPostBack="True" MarkFirstMatch="True" OnSelectedIndexChanged="cmbbranchfrom_SelectedIndexChanged" Sort="Ascending" Width="300px">
                    </telerik:RadComboBox>
                </td>
                <td>To Branch</td>
                <td>
 
                </td>
            </tr>


            <tr>
                <td class="auto-style21">&nbsp;</td>
                <td align="left" class="auto-style25" style="text-align: left"><span style="font-size: small">SELECT STAFF:&nbsp;&nbsp;</span>&nbsp;&nbsp;&nbsp;&nbsp; &nbsp;
                    <telerik:RadComboBox ID="cmbPersonto" Runat="server" AutoPostBack="True" MarkFirstMatch="True" Sort="Ascending" Width="300px"  
                        CheckBoxes="true" EnableCheckAllItemsCheckBox="true" DropDownAutoWidth="Enabled" 
                        OnSelectedIndexChanged="cmbPersonto_SelectedIndexChanged" NoWrap="True" RegisterWithScriptManager="True" OpenDropDownOnLoad="False" BorderStyle="None">
                    </telerik:RadComboBox>
                </td>
                <td class="auto-style19">&nbsp;
                    <asp:Literal ID="StaffClientSide" runat="server"></asp:Literal>
                    <asp:Label ID="lblStaff" runat="server" Text="Staff List" Visible="False"></asp:Label>
                    <asp:Label ID="lblStaffID" runat="server" Text="StaffID" Visible="False"></asp:Label>
                </td>
                <td class="auto-style15">
                    <asp:Label ID="lblGRNNo" runat="server" Text="GRN No." Visible="False"></asp:Label>
                </td>
                 <td class="auto-style14">
                      
                     
                 </td>
            </tr>


            <tr>
                <td class="auto-style7">&nbsp;</td>
                <td style="text-align: left"><span style="font-size: small">SELECT ITEMS:&nbsp;&nbsp;</span>&nbsp;&nbsp;&nbsp;&nbsp; &nbsp;
                     <telerik:RadComboBox ID="cmbItemSearch" Runat="server" AutoPostBack="True" MarkFirstMatch="True" Sort="Ascending" Width="300px"  
                        CheckBoxes="true" EnableCheckAllItemsCheckBox="true" DropDownAutoWidth="Enabled" 
                        OnSelectedIndexChanged="cmbItemSearch_SelectedIndexChanged" NoWrap="True" RegisterWithScriptManager="True" OpenDropDownOnLoad="False" BorderStyle="None">
                    </telerik:RadComboBox>
                </td>
                <td class="auto-style19">&nbsp;

                    <asp:Literal ID="ItemsClientSide" runat="server"></asp:Literal>
                    <asp:Label ID="lblItems" runat="server" Text="Items List" Visible="False"></asp:Label>
                    <asp:Label ID="lblItemID" runat="server" Text="ItemsID" Visible="False"></asp:Label>

 
                </td>
                <td class="auto-style15">&nbsp;
                    <strong>G.R.N Number:</strong>
                
                    <asp:TextBox ID="txtgrnno" runat="server" BorderColor="#000066" BorderWidth="1px" Enabled="True" Height="20px" onkeydown="addItem(event);" style="font-size: x-small; text-align: center; font-weight: 700;" TabIndex="5" Width="75px" AutoPostBack="True"></asp:TextBox>
                   
                    <a href="ReportsMain.aspx?rptname=GoodsReceiptNote&amp;grno=<%=txtgrnno.Text %>" target="_blank"><span class="auto-style28">Print</span></a>

                </td>
                 <td class="auto-style14">

                 </td>
            </tr>

         <tr>
                <td class="auto-style7">&nbsp;</td>
                <td style="text-align: Left">
                    Remarks:
                    <asp:TextBox ID="txtremarks" runat="server" Width="490px"></asp:TextBox>
                    
                </td>
                <td class="auto-style9">
                    
                    &nbsp;</td>
                <td class="auto-style15">&nbsp;</td>
                <td class="auto-style14">&nbsp;</td>
            </tr>

         <tr>
                <td class="auto-style7">&nbsp;</td>
                <td style="text-align: right">
                    <telerik:RadButton ID="btnSubmitItem" runat="server" ButtonType="SkinnedButton" Font-Size="10pt" Height="30px" OnClick="btnSubmitItem_Click" Text="Add Item" ValidationGroup="A" Visible="True">
                    </telerik:RadButton>
                    
                </td>
                <td class="auto-style9">
                    
                </td>
                <td class="auto-style15">&nbsp;</td>
                <td class="auto-style14"></td>
            </tr>

            <tr>
               
               <asp:UpdatePanel ID="UpdatePanel1" UpdateMode="Always" runat="server">
                 <ContentTemplate>
                
                 <td>&nbsp;</td>
                 <td align="left" colspan="5" style="font-family: Calibri;  font-weight: normal; font-size: 14px;" valign="top">

                    <div id="mirdiv" style="display: none" runat="server">

                        <table  id="chkGrid" cellspacing="1" style="width: 100%" align="center">
                        
                            <tr>
                                <td>&nbsp;</td>
                                <td>&nbsp;</td>
                                <td>&nbsp;</td>
                                <td>&nbsp;</td>
                                <td>&nbsp;</td>
                            </tr>

                            <tr>

                                <td colspan="1" style="width: 350px; text-align: left;" align="center">
                        
                                    <asp:GridView ID="grdItems" runat="server" AlternatingRowStyle-CssClass="alt" AutoGenerateColumns="False" CssClass="mGrid" 
                                                OnRowCommand="grdItems_RowCommand" OnRowDeleting="grdItems_RowDeleting" 
                                                OnRowEditing="grdItems_RowEditing" OnRowUpdating="grdItems_RowUpdating" OnRowUpdated="grdItems_RowUpdated"
                                                OnDataBound="grdItems_DataBound" OnRowCreated="grdItems_RowCreated" OnRowDataBound="grdItems_RowDataBound"
                                                PagerStyle-CssClass="pgr" style="font-size: x-small; text-align: center;" Width="657px">
                                                <Columns>
                                                    <asp:CommandField ShowDeleteButton="True" />
                                                    <%--<asp:BoundField DataField="Item Code" HeaderText="Item Code" />--%>

                                                    <asp:TemplateField HeaderText="Item Code" Visible="false">
                                                        <ItemTemplate>
                                                        <asp:Label ID="lblItemID" runat="server" Text='<%#Eval("Item Code") %>' Width="50px" />
                                                        </ItemTemplate>
                                                        <ItemStyle HorizontalAlign="Right" VerticalAlign="Middle" />
                                                    </asp:TemplateField>

                                                    <asp:BoundField DataField="Item Name" HeaderText="Item Name" />
                                                    <%--  <asp:BoundField DataField="Balance" HeaderText="Balance" />--%>

                                                    <asp:TemplateField HeaderText="Balance">
                                                    <ItemTemplate>
                                                            <asp:Label ID="lblbalance" runat="server" Text='<%#Eval("Balance") %>' Width="50px"  />
                                                        
                                                    </ItemTemplate>
                                                           <ItemStyle HorizontalAlign="Center" VerticalAlign="Middle" />
                                                    </asp:TemplateField>

                                                    <asp:TemplateField HeaderText="Qty Received" ItemStyle-HorizontalAlign="Center" ItemStyle-VerticalAlign="Middle" HeaderStyle-HorizontalAlign="Center" HeaderStyle-VerticalAlign="Middle">
                                                        <ItemTemplate>
                                                            <asp:TextBox ID="txtqty" runat="server" AutoPostBack="False" OnTextChanged="txtqty_TextChanged" Text='<%#Eval("Qty Received") %>' onclick="GridRowNo(<%# Container.DataItemIndex %>,this);" Width="50px"></asp:TextBox>
                                                        </ItemTemplate>
                                                    </asp:TemplateField>
                                                </Columns>
                                            </asp:GridView>
                                </td>
                                
                                <td>&nbsp;</td> 
                               <td>&nbsp;</td> 
                                <td>&nbsp;</td>
                            </tr>
                            <tr>
                                <td>&nbsp;</td>
                                <td>&nbsp;</td>
                                <td>&nbsp;</td>
                                <td>&nbsp;</td>
                                <td>&nbsp;</td>
                            </tr>



                        </table>
                    </div>

                </td>
               
                


                </ContentTemplate>
              </asp:UpdatePanel>

            </tr>
            <tr>
                <td class="auto-style7">&nbsp;</td>
                <td class="auto-style20">&nbsp;</td>
                <td style="text-align: right">
                    <asp:Button ID="btnSave" runat="server" OnClick="btnSave_Click" Text="Receive Items" Width="176px" />
                </td>
                <td class="auto-style15">&nbsp;</td>
                <td class="auto-style14"></td>
            </tr>
           


        </table>

    </div>

</asp:Content>

<asp:Content ID="Content3" ContentPlaceHolderID="MainContent" runat="server">

   


</asp:Content>
