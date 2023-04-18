<%@ Page Title="" Language="C#" MasterPageFile="~/Site1.Master" MaintainScrollPositionOnPostback="True" AutoEventWireup="true" EnableEventValidation = "false" CodeBehind="RequisitionsLab.aspx.cs" Inherits="IMS.labrequisitions" %>

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
            text-align: right;
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

        .auto-style50 {
            height: 36px;
            width: 300px;
        }

        .auto-style51 {
            height: 36px;
            font-family: Arial, Helvetica, sans-serif;
            width: 34px;
        }

        .auto-style53 {
            height: 36px;
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


        .auto-style64 {
            font-family: Arial, Helvetica, sans-serif;
            font-size: medium;
            color: #C0C0C0;
            text-align: center;
            height: 30px;
        }

        .auto-style65 {
            height: 30px;
        }

        .auto-style66 {
            font-family: Arial, Helvetica, sans-serif;
            font-size: medium;
            color: #C0C0C0;
            text-align: left;
        }

        .auto-style67 {
            font-family: Arial, Helvetica, sans-serif;
            font-size: medium;
            color: #C0C0C0;
            text-align: left;
            height: 30px;
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





    <script type="text/javascript">
        //Put your JavaScript code here.

        function CalculateAmount(CurrentPrice, QuntValue, TotalValue) {

            var tot;
            var QuntVar = parseFloat(document.getElementById(QuntValue).value != "" ? document.getElementById(QuntValue).value : "0");
            var TotalVar = document.getElementById(TotalValue);
            var TotalPriceValue = parseFloat(CurrentPrice * QuntVar);

            TotalVar.innerHTML = TotalPriceValue;

            //var TotalRq = parseFloat(TotalReq.get_value() != "" ? TotalReq.get_value() : "0") + TotalPriceValue;

            //var TotalRq = parseFloat(TotalReq.get_value()) + parseFloat(TotalPriceValue);

            //TotalReq.set_value(parseFloat(TotalRq));
            //document.getElementById(txtAmountReq).value = TotalRq;

        }

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


        function MakeTotal(rowindex) {
            // var strBudget = "ctl00_ContentPlaceHolder1_txtAppBudget";

            var Budget = $find("<%=txtAppBudget.ClientID %>");

            var TotalReq = $find("<%=txtAmountReq.ClientID %>");
            var Balance = $find("<%=txtAmountBal.ClientID %>");

            var bagval = parseFloat(Budget.get_value());

            var grid = document.getElementById("<%=grdItems.ClientID%>");
            var totalrow = parseFloat(grid.rows.length - 1);

            var i, CellValue
            i = parseInt(rowindex) + 1;

            CellValue = 0;

            for (i = 0 ; i < totalrow ; i++) {
                var str = "ContentPlaceHolder1_grdItems_lblamt_" + i;
                CellValue = parseFloat(CellValue) + parseFloat(document.getElementById(str).innerHTML != "NaN" ? document.getElementById(str).innerHTML : "0");
            }

            TotalReq.set_value(parseFloat(CellValue));

            Balance.set_value(parseFloat(bagval - parseFloat(CellValue)));

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
                        <td class="auto-style55" style="background-color: #F7F7F7; text-align: center;" colspan="3">Branch Quarterly Requisition </td>
                        <td class="auto-style59" style="background-color: #F7F7F7"></td>
                    </tr>
                    <tr>
                        <td class="auto-style6"></td>
                        <td class="auto-style13"></td>
                        <td class="auto-style21">&nbsp;</td>
                        <td class="auto-style28">Select Branch</td>
                        <td class="auto-style7">
                            <telerik:RadComboBox ID="cmbbranch" runat="server" AutoPostBack="True" MarkFirstMatch="True" OnSelectedIndexChanged="cmbbranch_SelectedIndexChanged" Sort="Ascending" Width="300px">
                            </telerik:RadComboBox>
                        </td>
                    </tr>
                    <tr>
                        <td class="auto-style64">Requisition Type:</td>
                        <td class="auto-style26">
                            <telerik:RadComboBox ID="cmbReqType" runat="server" Width="300px" Sort="Ascending" OnSelectedIndexChanged="cmbReqType_SelectedIndexChanged" AutoPostBack="True">
                            </telerik:RadComboBox>
                        </td>
                        <td class="auto-style18"></td>
                        <td class="auto-style62">Requisition No:</td>
                        <td class="auto-style65">
                            <telerik:RadTextBox ID="txtReqNo" runat="server" Height="25px" Width="100px" Style="font-weight: 700; text-align: center; font-size: medium" OnTextChanged="txtReqNo_TextChanged" AutoPostBack="true">
                            </telerik:RadTextBox>
                            &nbsp;<a href="ReportsMain.aspx?rptname=QuarterlyRequisition&amp;reqno=<%= txtReqNo.Text %>" target="_blank">Print</a>&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;
                            <br />
                        </td>
                    </tr>
                    <tr>
                        <td class="auto-style62">&nbsp;</td>
                        <td class="auto-style26">&nbsp;</td>
                        <td class="auto-style18">&nbsp;</td>
                        <td class="auto-style63">&nbsp;</td>
                        <td style="height: 30px">
                            <asp:Label ID="lblReqIds" runat="server" Text="Requisition No's:"></asp:Label>
                        </td>
                    </tr>
                    <tr>
                        <td class="auto-style66">Requisition Type:</td>
                        <td class="auto-style26">
                            <telerik:RadTextBox ID="txtReqtype" runat="server" Height="25px" Width="300px" Enabled="False">
                            </telerik:RadTextBox>
                        </td>
                        <td class="auto-style18">&nbsp;</td>
                        <td class="auto-style62">Requisition Months:</td>
                        <td style="height: 30px">
                            <telerik:RadTextBox ID="txtReqMonth" runat="server" Height="25px" Width="300px" Enabled="False">
                            </telerik:RadTextBox>
                        </td>
                    </tr>
                    <tr>
                        <td class="auto-style66">Requisition Sub.Type:</td>
                        <td class="auto-style26">
                            <telerik:RadTextBox ID="txtReqSubType" runat="server" Height="25px" Width="300px" Enabled="False">
                            </telerik:RadTextBox>
                        </td>
                        <td class="auto-style18">&nbsp;</td>
                        <td class="auto-style62">&nbsp;</td>
                        <td style="padding-left: 10px;">&nbsp;</td>
                    </tr>
                    <tr>
                        <td class="auto-style66">Total Strength:</td>
                        <td class="auto-style50">
                            <telerik:RadTextBox ID="txtStrength" runat="server" Height="25px" Width="80px" Enabled="False" Style="font-weight: 700">
                            </telerik:RadTextBox>
                        </td>
                        <td class="auto-style51"></td>
                        <td class="auto-style66">Approved Cost:</td>
                        <td class="auto-style53" style="height: 30px;">
                            <telerik:RadTextBox ID="txtAppCost" runat="server" Height="25px" Width="300px" Enabled="False">
                            </telerik:RadTextBox>
                        </td>
                    </tr>
                    <tr>
                        <td class="auto-style66">Approved Budget:</td>
                        <td class="auto-style26">
                            <telerik:RadTextBox ID="txtAppBudget" runat="server" Height="25px" Width="80px" Enabled="False" Style="font-weight: 700">
                            </telerik:RadTextBox>
                            &nbsp;Amount Required:
                        <telerik:RadTextBox ID="txtAmountReq" runat="server" Height="25px" Width="79px" Enabled="False" Style="font-weight: 700">
                        </telerik:RadTextBox>
                        </td>
                        <td class="auto-style18">&nbsp;</td>
                        <td class="auto-style66">Per Child Cost:</td>
                        <td style="height: 30px;">
                            <telerik:RadTextBox ID="txtPerChildCost" runat="server" Height="25px" Width="107px" Enabled="False" Style="font-weight: 700">
                            </telerik:RadTextBox>
                        </td>
                    </tr>
                    <tr>
                        <td class="auto-style67">Balance Amount:</td>
                        <td class="auto-style26">&nbsp;<telerik:RadTextBox ID="txtAmountBal" runat="server" Height="25px" Width="79px" Enabled="False" Style="font-weight: 700">
                        </telerik:RadTextBox>
                        </td>
                        <td class="auto-style18"></td>
                        <td class="auto-style63">
                            <telerik:RadTextBox ID="txtReqtypeID" runat="server" Height="25px" Width="26px" Enabled="False" Visible="False">
                            </telerik:RadTextBox>
                            &nbsp;&nbsp;
                        <telerik:RadTextBox ID="txtSubReqtypeID" runat="server" Height="25px" Width="26px" Enabled="False" Visible="False">
                        </telerik:RadTextBox>
                        </td>
                        <td class="auto-style26">&nbsp;</td>
                    </tr>
                    <tr>
                        <td class="auto-style66">Exp. Delivery Date:</td>
                        <td class="auto-style26">

                            <asp:TextBox ID="txtDlvdate" runat="server" Width="152px"></asp:TextBox>
                            <asp:CalendarExtender ID="txtDlvdate_CalendarExtender" runat="server" Enabled="True" TargetControlID="txtDlvdate">
                            </asp:CalendarExtender>
                            <asp:RequiredFieldValidator ID="RequiredFieldValidator8" runat="server" ControlToValidate="txtDlvdate" ErrorMessage="*" ForeColor="Red" ValidationGroup="A"></asp:RequiredFieldValidator>

                        </td>
                        <td class="auto-style18">&nbsp;</td>
                        <td align="center">&nbsp;</td>
                        <td style="height: 30px; width: 300px;">&nbsp;</td>
                    </tr>
                    <tr>
                        <td class="auto-style10">&nbsp;</td>
                        <td class="auto-style15">
                            <telerik:RadButton ID="btnConfirm" runat="server" Text="Show Item List" Font-Size="10pt" Height="30px" ButtonType="SkinnedButton" Width="91px" OnClick="btnConfirm_Click" Style="text-align: center">
                            </telerik:RadButton>
                        </td>
                        <td class="auto-style20"></td>
                        <td class="auto-style30">&nbsp;</td>
                        <td class="auto-style11">&nbsp;</td>
                    </tr>
                    <tr>
                        <td class="auto-style62" colspan="5">
                            <asp:Button ID="btnExport" runat="server" OnClick="btnExport_Click" Text="Export to Excel" />
                        </td>
                    </tr>
                    <tr>
                        <asp:UpdatePanel ID="UpdatePanel1" UpdateMode="Always" runat="server">
                            <ContentTemplate>

                                <td class="auto-style62" colspan="5">
                                    <div>

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



                                                <asp:BoundField DataField="InvCode" HeaderText="Item Code" Visible="false" />
                                                <asp:BoundField DataField="ItemTitle" HeaderText="Item Name">
                                                    <ItemStyle HorizontalAlign="Left" VerticalAlign="Middle" />
                                                </asp:BoundField>
                                                <asp:BoundField DataField="Unit" HeaderText="Unit" />
                                                <asp:BoundField DataField="Balance" HeaderText="In Stock Balance">
                                                    <ItemStyle Font-Bold="True" Font-Size="Larger" ForeColor="#006600" />
                                                </asp:BoundField>
                                                <asp:TemplateField HeaderText="Qty Required">
                                                    <ItemTemplate>
                                                        <asp:TextBox ID="txtqty" runat="server" AutoPostBack="false" autocomplete="off" OnTextChanged="txtqty_TextChanged" Text='<%#Eval("QtyRequired") %>' onclick="GridRowNo(<%# Container.DataItemIndex %>,this);" Width="50px"></asp:TextBox>
                                                    </ItemTemplate>
                                                    <ItemStyle HorizontalAlign="Right" VerticalAlign="Middle" />
                                                </asp:TemplateField>

                                                <asp:TemplateField HeaderText="Rate">
                                                    <ItemTemplate>
                                                        <asp:Label ID="lblrate" runat="server" Text='<%#Eval("Rate") %>' Width="50px" />
                                                    </ItemTemplate>
                                                    <ItemStyle HorizontalAlign="Right" VerticalAlign="Middle" />
                                                </asp:TemplateField>


                                                <%--<asp:BoundField DataField="Amount" HeaderText="Amount" >--%>

                                                <asp:TemplateField HeaderText="Amount" ItemStyle-HorizontalAlign="Right">
                                                    <ItemTemplate>
                                                        <asp:Label ID="lblamt" runat="server" Text='<%# Eval("Amount") %>' />
                                                    </ItemTemplate>
                                                    <FooterTemplate>
                                                        <div style="text-align: right;">
                                                            <asp:Label ID="lblTotalAmount" runat="server" Font-Bold="true" />
                                                        </div>
                                                    </FooterTemplate>
                                                    <ItemStyle Font-Bold="True" Font-Size="Larger" ForeColor="Black" />
                                                </asp:TemplateField>


                                                <%-- <ControlStyle Width="500px" />                                                          
                                                         </asp:BoundField>--%>
                                            </Columns>

                                            <FooterStyle BackColor="#507CD1" Font-Bold="True" ForeColor="White" />
                                            <PagerStyle BackColor="#2461BF" ForeColor="White" HorizontalAlign="Center" />
                                            <SelectedRowStyle BackColor="#D1DDF1" ForeColor="#333333" Font-Bold="True" />
                                            <HeaderStyle BackColor="#507CD1" Font-Bold="True" ForeColor="White" />
                                            <EditRowStyle BackColor="#2461BF" />
                                            <AlternatingRowStyle BackColor="White" />
                                        </asp:GridView>



                                    </div>
                                </td>
                            </ContentTemplate>
                        </asp:UpdatePanel>
                    </tr>
                    <tr>
                        <td class="auto-style62" colspan="5"></td>
                    </tr>
                    <tr>
                        <td class="auto-style62">&nbsp;</td>
                        <td class="auto-style26">&nbsp;</td>
                        <td class="auto-style18">&nbsp;</td>
                        <td class="auto-style29">
                            <telerik:RadButton ID="btnSubmit" runat="server" Text="Submit Requisition" Font-Size="10pt" Height="30px" ButtonType="SkinnedButton" Width="122px" OnClick="btnSubmit_Click" Style="text-align: center">
                            </telerik:RadButton>
                        </td>
                        <td style="height: 30px; text-align: center;">&nbsp;</td>
                    </tr>
                    <tr>
                        <td class="auto-style22">&nbsp;</td>
                        <td class="auto-style26">&nbsp;</td>
                        <td class="auto-style18">&nbsp;</td>
                        <td class="auto-style29">&nbsp;</td>
                        <td style="height: 30px; text-align: right;">&nbsp;</td>
                    </tr>
                    <tr>
                        <td class="auto-style22" colspan="5">&nbsp;</td>
                    </tr>
                    <tr>
                        <td class="auto-style22">&nbsp;</td>
                        <td class="auto-style26">&nbsp;</td>
                        <td class="auto-style18">&nbsp;</td>
                        <td class="auto-style29">&nbsp;</td>
                        <td style="height: 30px; text-align: right;">&nbsp;</td>
                    </tr>
                    <tr>
                        <td class="auto-style22">&nbsp;</td>
                        <td class="auto-style26">&nbsp;</td>
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

</asp:Content>
