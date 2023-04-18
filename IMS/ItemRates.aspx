<%@ Page Title="" Language="C#" MasterPageFile="~/Site1.Master" AutoEventWireup="true" CodeBehind="ItemRates.aspx.cs" Inherits="IMS.ItemRates" %>

<%@ Register Assembly="AjaxControlToolkit" Namespace="AjaxControlToolkit" TagPrefix="asp" %>
<%@ Register Assembly="Telerik.Web.UI" Namespace="Telerik.Web.UI" TagPrefix="telerik" %>



<asp:Content ID="Content1" ContentPlaceHolderID="HeadContent" runat="server">
    <style type="text/css">
        .SubTotalRowStyle {
            border: solid 1px White;
            background-color: #81BEF7;
            font-weight: bold;
            font-size: larger;
        }

        .GrandTotalRowStyle {
            border: solid 1px White;
            background-color: Gray;
            font-weight: bold;
            font-size: larger;
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

        .auto-style11 {
            height: 33px;
        }

        .auto-style13 {
            height: 19px;
            width: 300px;
        }

        .auto-style15 {
            height: 33px;
            width: 300px;
            text-align: left;
            font-weight: 700;
            font-size: medium;
            color: #00CC00;
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
            font-family: Arial, Helvetica, sans-serif;
            font-size: medium;
        }

        .auto-style25 {
            width: 300px;
        }

        .auto-style26 {
            height: 30px;
            width: 300px;
            text-align: right;
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

        .auto-style30 {
            height: 33px;
            font-family: Arial, Helvetica, sans-serif;
            width: 97px;
            color: #C0C0C0;
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

        .auto-style54 {
            width: 64px;
            height: 64px;
        }

        .auto-style55 {
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
            text-align: left;
        }

        .auto-style63 {
            font-family: Arial, Helvetica, sans-serif;
            height: 30px;
            width: 97px;
            color: #C0C0C0;
        }

        .mGrid {
            background-color: #fff;
            margin: 5px 0 10px 0;
            border: solid 1px #525252;
            border-collapse: collapse;
        }

            .mGrid th {
                padding: 4px 2px;
                color: #fff;
                background: #424242 url('CSS/grd_head.png') repeat-x 50% top;
                border-left: solid 1px #525252;
                font-size: 0.9em;
            }

            .mGrid .alt {
                background: #fcfcfc url('CSS/grd_alt.png') repeat-x 50% top;
            }

            .mGrid .column {
                background-color: #034FCD;
                color: white;
                font-weight: bold;
            }


        </style>

</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">

    <telerik:RadWindow ID="NewType" runat="server" DestroyOnClose="True" EnableShadow="True" KeepInScreenBounds="True" Modal="True" ReloadOnShow="True" VisibleStatusbar="False" VisibleTitlebar="False">
        <ContentTemplate>
            <table cellpadding="0" class="auto-style2" style="width: 94%; margin-left: 12px">
                <tr>
                    <td class="auto-style44">&nbsp;</td>
                    <td class="auto-style46">&nbsp;</td>
                </tr>
                <tr>
                    <td class="auto-style44">New Type</td>
                    <td class="auto-style46">
                        <telerik:RadTextBox ID="txtNew" runat="server" Height="25px" Width="200px">
                        </telerik:RadTextBox>
                    </td>
                </tr>
                <tr>
                    <td class="auto-style45">&nbsp;</td>
                    <td class="auto-style46">&nbsp;</td>
                </tr>
                <tr>
                    <td class="auto-style45">&nbsp;</td>
                    <td class="auto-style46">
                        <telerik:RadButton ID="btnNew" runat="server" ButtonType="SkinnedButton" Font-Size="10pt" Height="30px" Text="Submit">
                        </telerik:RadButton>
                        &nbsp;<telerik:RadButton ID="btnCancel" runat="server" ButtonType="SkinnedButton" Font-Size="10pt" Height="30px" Text="Cancel" SingleClick="True">
                        </telerik:RadButton>
                    </td>
                </tr>
            </table>
        </ContentTemplate>
    </telerik:RadWindow>

    <telerik:RadWindow ID="NewCatagory" runat="server" DestroyOnClose="True" EnableShadow="True" KeepInScreenBounds="True" Modal="True" ReloadOnShow="True" VisibleStatusbar="False" VisibleTitlebar="False">
        <ContentTemplate>
            <table cellpadding="0" class="auto-style2" style="width: 94%; margin-left: 12px">
                <tr>
                    <td class="auto-style47">&nbsp;</td>
                    <td class="auto-style46">&nbsp;</td>
                </tr>
                <tr>
                    <td class="auto-style47">New Catagory</td>
                    <td class="auto-style46">
                        <telerik:RadTextBox ID="txtCatagory" runat="server" Height="25px" Width="200px">
                        </telerik:RadTextBox>
                    </td>
                </tr>
                <tr>
                    <td class="auto-style48">&nbsp;</td>
                    <td class="auto-style46">&nbsp;</td>
                </tr>
                <tr>
                    <td class="auto-style48">&nbsp;</td>
                    <td class="auto-style46">
                        <telerik:RadButton ID="btnCatagory" runat="server" ButtonType="SkinnedButton" Font-Size="10pt" Height="30px" Text="Submit">
                        </telerik:RadButton>
                        &nbsp;<telerik:RadButton ID="btnCatCancel" runat="server" ButtonType="SkinnedButton" Font-Size="10pt" Height="30px" Text="Cancel" SingleClick="True">
                        </telerik:RadButton>
                    </td>
                </tr>
            </table>
        </ContentTemplate>

    </telerik:RadWindow>
    <script type="text/javascript" src="http://ajax.googleapis.com/ajax/libs/jquery/1.9.1/jquery.min.js"></script>
    <script type="text/javascript">
        //ContentPlaceHolder1_grdItems_txtrate_0


        function Confirm(rattyp) {
            //This Function Work with ASP Button Not with RadControlButton.
            var choice = confirm("Are You Sure, You Want to Apply '" + rattyp + "' Rates To Branch Requisition?", "Yes", "No");
            if (choice == false) {
                return false;
            }
            
        }

        function ConfirmRate() {
            //This Function Work with ASP Button Not with RadControlButton.
            var choice = confirm("Are You Sure, You Want to Apply Rates To All Branches Stock/Invenotry?", "Yes", "No");
            if (choice == false) {
                return false;
            }
            else
            {
                document.getElementById('<%=btnApplyInventoryRate.ClientID%>').click();
            }
        }

        function confirm_box() {

            var confirm_value = document.createElement("INPUT");
            confirm_value.type = "hidden";
            confirm_value.name = "confirm_value";
            if (confirm("Cheque Number Does Not Match!Do you want to save data?")) {
                confirm_value.value = "Yes";
            } else {
                confirm_value.value = "No";
            }
            document.forms[0].appendChild(confirm_value);
        }



        function IsNumeric(e, rowindex) {

            //var specialKeys = new Array();
            //specialKeys.push(8); //Backspace
            //var keyCode = e.which ? e.which : e.keyCode
            //var ret = ((keyCode >= 48 && keyCode <= 57) || specialKeys.indexOf(keyCode) != -1);
            //document.getElementById('<%=grdItems.ClientID %>').style.display = ret ? "none" : "inline";
            //return ret;

            // Allow: backspace, delete, tab, escape, enter and .
            //if ($.inArray(e.keyCode, [46, 8, 9, 27, 13, 110, 190]) !== -1 ||
                // Allow: Ctrl+A
          //      (e.keyCode == 65 && e.ctrlKey == true) ||
                // Allow: home, end, left, right
          //      (e.keyCode >= 35 && e.keyCode <= 39))
          //  {
                // let it happen, don't do anything
          //      return;
          //  }        
            
            //alert("Row No" + rowindex);
            var i = parseInt(rowindex);
             
            var str = "ContentPlaceHolder1_grdItems_txtrate_" + i;
            //cellval = parseFloat(document.getElementById(str).innerHTML != "NaN" ? document.getElementById(str).innerHTML : "0");
            var CellValue = document.getElementById(str);
            var noval = 0;
            if (e.keyCode > 47 && e.keyCode < 58 || e.keyCode > 95 && e.keyCode < 106 || $.inArray(e.keyCode, [46, 8, 9, 27, 13, 110, 190]) !== -1)
            {
                return;
            }
            else
            {
                CellValue.innerHTML = parseFloat("0");
                alert("Please Enter Only Numeric Value...");
                e.preventDefault();
                
                return noval;
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





    </script>

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
                        <td class="auto-style32" style="background-color: #F7F7F7; height: 10px;"></td>
                        <td class="auto-style61" style="background-color: #F7F7F7; height: 10px;"></td>
                        <td class="auto-style31" style="background-color: #F7F7F7; height: 10px;"></td>
                        <td class="auto-style27" style="background-color: #F7F7F7; height: 10px;"></td>
                        <td style="background-color: #F7F7F7; height: 10px;"></td>
                    </tr>
                    <tr>
                        <td class="auto-style56" style="background-color: #F7F7F7; text-align: center;">
                            <img alt="" class="auto-style54" src="images/Order64.png" /></td>
                        <td class="auto-style55" style="background-color: #F7F7F7">Item Rates Entry</td>
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
                        <td class="auto-style6">&nbsp;</td>
                        <td class="auto-style13">
                            <asp:CheckBox ID="chkSyllabus" runat="server" AutoPostBack="True" OnCheckedChanged="chkSyllabus_CheckedChanged" Text="Syllabus Items List" style="color: #000000" />
                        </td>
                        <td class="auto-style21">&nbsp;
                            <asp:CheckBox ID="chkHO" runat="server" AutoPostBack="True" OnCheckedChanged="chkHO_CheckedChanged" Text="Head Office" style="color: #000000" />
                        </td>
                        <td class="auto-style28">&nbsp;</td>
                        <td class="auto-style7">&nbsp;</td>
                    </tr>
                    <tr>
                        <td class="auto-style62">Requisition Type:</td>
                        <td class="auto-style26">
                            <telerik:RadComboBox ID="cmbReqType" runat="server" Width="300px" Sort="Ascending" OnSelectedIndexChanged="cmbReqType_SelectedIndexChanged" AutoPostBack="True">
                            </telerik:RadComboBox>
                        </td>
                        <td class="auto-style18">&nbsp;</td>
                        <td class="auto-style63">&nbsp;</td>
                        <td style="height: 30px">
                            &nbsp;<a href="ReportsMain.aspx?rptname=ItemsRateList" target="_Blank">Print Item Rate List</a>&nbsp;&nbsp;&nbsp;&nbsp;&nbsp; <br />
                        </td>
                    </tr>
                    <tr>
                        <td class="auto-style62">&nbsp;</td>
                        <td style="text-align: left">
                            <asp:RadioButtonList ID="rdoRateState" runat="server" OnSelectedIndexChanged="rdoRateState_SelectedIndexChanged" RepeatDirection="Horizontal" Width="213px" AutoPostBack="True">
                                <asp:ListItem Value="E">Estimated Rate</asp:ListItem>
                                <asp:ListItem Value="A">Actual Rate</asp:ListItem>
                            </asp:RadioButtonList>
                        </td>
                        <td class="auto-style18">&nbsp;</td>
                        <td class="auto-style63">&nbsp;</td>
                        <td style="padding-left: 10px;">
                            <asp:Button ID="btnRateApply" runat="server" OnClick="btnRateApply_Click" Text="Apply Rate Status on Requisition" Width="244px" />
                        </td>
                    </tr>
                    <tr>
                        <td class="auto-style62">&nbsp;</td>
                        <td class="auto-style26">
                            &nbsp;</td>
                        <td class="auto-style18">&nbsp;</td>
                        <td class="auto-style63">&nbsp;</td>
                        <td style="padding-left: 10px;">
                              <asp:Button ID="btnApplyInventoryRate" runat="server" OnClick="btnApplyInventoryRate_Click" Text="Apply Rate on Overall Stock/Inventory" Width="244px" Height="30px" BackColor="YellowGreen" />
                        </td>
                    </tr>
                    <tr>
                        <td class="auto-style62">&nbsp;</td>
                        <td class="auto-style26">
                            <telerik:RadButton ID="btnConfirm" runat="server" Text="Show Item Rate List" Font-Size="10pt" Height="30px" ButtonType="SkinnedButton" Width="153px" OnClick="btnConfirm_Click" Style="text-align: center; font-size: 9pt; top: 2px; left: -112px;">
                            </telerik:RadButton>
                        </td>
                        <td class="auto-style18">&nbsp;</td>
                        <td class="auto-style63">
                            &nbsp;</td>
                        <td style="height: 30px; width: 300px;">&nbsp;</td>
                    </tr>
                    <tr>
                        <td class="auto-style10">&nbsp;</td>
                        <td class="auto-style15">
                            <asp:Label ID="lblRatstat" runat="server" Text="Rate Status"></asp:Label>
                        </td>
                        <td class="auto-style20"></td>
                        <td class="auto-style30">&nbsp;</td>
                        <td class="auto-style11">&nbsp;</td>
                    </tr>
                    
                    <tr>
                       
                         <td colspan="5">
                             <asp:Label ID="lblNote" runat="server" Text="Note: To Apply Selected Rates On Requisition, First Press Submit To Save Rate as Per Status and Then Click on Apply Rates Button." style="color: #FF0000; font-weight: 700" Visible="False"></asp:Label>                             
                         </td>                        
                    </tr>
                    <tr>
                        <asp:UpdatePanel ID="UpdatePanel1" UpdateMode="Always" runat="server">
                            <ContentTemplate>
                                <td class="auto-style62" colspan="5">
                                    <%--<div>--%>

                                    <asp:GridView ID="grdItems" runat="server"
                                        AutoGenerateColumns="False"
                                        cellclassname="column"
                                        CssClass="mGrid" OnRowCommand="grdItems_RowCommand" OnRowDeleting="grdItems_RowDeleting"
                                        OnRowEditing="grdItems_RowEditing" OnRowUpdating="grdItems_RowUpdating"
                                        PagerStyle-CssClass="pgr" Style="font-size: x-small; text-align: center;" Width="657px"
                                        AllowSorting="True" OnRowUpdated="grdItems_RowUpdated" OnSorting="grdItems_Sorting"
                                        OnDataBound="grdItems_DataBound" OnRowCreated="grdItems_RowCreated" OnRowDataBound="grdItems_RowDataBound">

                                        <PagerStyle CssClass="pgr"></PagerStyle>
                                        <RowStyle CssClass="gridrow" />
                                        <RowStyle ForeColor="Black" />
                                        <SelectedRowStyle BackColor="YellowGreen" ForeColor="Blue" Font-Bold="True" />
                                        <Columns>
                                            <asp:CommandField ShowDeleteButton="false" Visible="false" />

                                            <%--<asp:TemplateField>
                                                                <HeaderTemplate>

                                                                   <div style="text-align: right;">
                                                                    <asp:Label ID="lblTitle" runat ="server" Text ='<%#Eval("RequisitionSubType")%>'></asp:Label>
                                                                    </div>
                                                                
                                                                 </HeaderTemplate>
                                                            </asp:TemplateField>
                                            --%>

                                            <asp:TemplateField HeaderText="S.No">
                                                <ItemTemplate>
                                                    <%# Container.DataItemIndex + 1 %>
                                                </ItemTemplate>
                                                <ItemStyle Width="2%" />
                                            </asp:TemplateField>

                                            <asp:TemplateField HeaderText="Item Category">
                                                <ItemTemplate>
                                                    <asp:Label ID="lblCategory" runat="server" Text='<%#CheckIfTitleExists(Eval("ItemHeadTitle").ToString())%>'></asp:Label>
                                                </ItemTemplate>
                                            </asp:TemplateField>

                                            <asp:BoundField DataField="ItemHeadTitle" HeaderText="Item Head" />

                                            <asp:TemplateField HeaderText="ItemID" Visible="false">
                                                <ItemTemplate>
                                                    <asp:Label ID="lblItemID" runat="server" Text='<%#Eval("fkItemID") %>' Width="50px" />
                                                </ItemTemplate>
                                                <ItemStyle HorizontalAlign="Right" VerticalAlign="Middle" />
                                            </asp:TemplateField>

                                            <asp:BoundField DataField="ItemTitle" HeaderText="Item Name">
                                                <ItemStyle HorizontalAlign="Left" VerticalAlign="Middle" />
                                            </asp:BoundField>
                                            <asp:BoundField DataField="Unit" HeaderText="Unit" />

                                            <asp:TemplateField HeaderText="Rate">
                                                <ItemTemplate>
                                                    <asp:TextBox ID="txtrate" runat="server" AutoPostBack="false" autocomplete="off" OnTextChanged="txtrate_TextChanged" Text='<%#Eval("Rate") %>' onclick="GridRowNo(<%# Container.DataItemIndex %>,this);" Width="50px"></asp:TextBox>
                                                </ItemTemplate>
                                                <ItemStyle HorizontalAlign="Right" VerticalAlign="Middle" />
                                            </asp:TemplateField>


                                        </Columns>

                                        <FooterStyle BackColor="#507CD1" Font-Bold="True" ForeColor="White" />
                                        <PagerStyle BackColor="#2461BF" ForeColor="White" HorizontalAlign="Center" />
                                        <SelectedRowStyle BackColor="#D1DDF1" ForeColor="#333333" Font-Bold="True" />
                                        <HeaderStyle BackColor="#507CD1" Font-Bold="True" ForeColor="White" />
                                        <EditRowStyle BackColor="#2461BF" />
                                        <AlternatingRowStyle BackColor="White" />
                                    </asp:GridView>

                                    <%--</div>--%>
                                </td>
                            </ContentTemplate>
                        </asp:UpdatePanel>
                    </tr>
                    <tr>
                        <td class="auto-style62">&nbsp;</td>
                        <td class="auto-style26">&nbsp;</td>
                        <td class="auto-style18">&nbsp;</td>
                        <td class="auto-style29">&nbsp;</td>
                        <td style="height: 30px; text-align: right;">&nbsp;</td>
                    </tr>
                    <tr>
                        <td class="auto-style22">&nbsp;</td>
                        <td class="auto-style26">&nbsp;</td>
                        <td class="auto-style18">&nbsp;</td>
                        <td class="auto-style29">
                            <telerik:RadButton ID="btnSubmit" runat="server" Text="Submit" Font-Size="10pt" Height="30px" ButtonType="SkinnedButton" OnClick="btnSubmit_Click" style="text-align: center" Width="59px">
                            </telerik:RadButton>
                        </td>
                        <td style="height: 30px; text-align: right;">
                            &nbsp;</td>
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

</asp:Content>
