<%@ Page Title="" Language="C#" MasterPageFile="~/Site1.Master" MaintainScrollPositionOnPostback="True" AutoEventWireup="true" EnableEventValidation = "false" CodeBehind="RequisitionsIT.aspx.cs" Inherits="IMS.RequisitionsIT" %>

<%@ Register Assembly="AjaxControlToolkit" Namespace="AjaxControlToolkit" TagPrefix="asp" %>
<%@ Register Assembly="Telerik.Web.UI" Namespace="Telerik.Web.UI" TagPrefix="telerik" %>


<asp:Content ID="Content1" ContentPlaceHolderID="HeadContent" runat="server">

    <link href="css2/bootstrap.css" rel="stylesheet" />

    <style type="text/css">
        
                .GridStyle
                {
                font-size: 90%;
                }
                .ColumnHeaderStyle
                {
                    background-color: #000000;
                    color: White;
                    font-weight: bold;
                }
                .AlternatingRowStyle
                {
                    background-color: #66CCFF;
                }
                .RowStyle
                {
                    background-color: #66CCFF;
                }
                .GroupHeaderRowStyle
                {
                    background-color: Blue;
                    text-align: left;
                    font-weight: bold;
                    color: White;
                }

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
        .AlgRgh
        {
           text-align:center;
           font-family:Verdana, Arial, Helvetica, sans-serif;
         }
 
        #dataTables-dbReqSummary td 
        {
            text-align: center; 
            vertical-align: middle;
            height: 50px; 
            width: 50px;
        }

    </style>

</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">


    <script language="javascript" type="text/javascript">

    function OnClientItemChecked(sender, eventArgs) {
        var item = eventArgs.get_item();
        //var obj = {};
        var checked = eventArgs.get_item().get_checked();
        if (checked) {
            var qty = prompt("Please enter quantity for " + item.get_text(), 0);

            
            //obj[item.get_text()] = qty;
            var rowIndex = sender._element.parentNode.parentNode.rowIndex; //wish this code works**

            var i, CellValue;
            i = parseInt(rowIndex);
            i--;
            var str = "ContentPlaceHolder1_grdItems_txtqty_" + i;
            //var str = "MainContent_grdItems_txtqty_" + i;


            document.getElementById(str).readOnly = false;

            if (qty.value == "null")
            {
                //alert(qty);
                qty = "0";
            }

            if (parseFloat(qty) > 0) {


                document.getElementById(str).value = parseFloat(document.getElementById(str).value) + parseFloat(qty);

                if (document.getElementById(str).innerHTML == "NaN") {
                    document.getElementById(str).value = "0";
                }

                var strrema = "ContentPlaceHolder1_grdItems_txtremarks_" + i;

                if (document.getElementById(strrema).value == "") {
                    document.getElementById(strrema).value = item.get_text() + "-" + parseFloat(qty).toString() + ",";
                }
                else {
                    document.getElementById(strrema).value = document.getElementById(strrema).value + item.get_text() + "-" + parseFloat(qty).toString() + ",";
                }
            }
        }
        else
        {
            
            var rowIndex = sender._element.parentNode.parentNode.rowIndex; 

            var i, CellValue;
            i = parseInt(rowIndex);
            i--;

            var strrema = "ContentPlaceHolder1_grdItems_txtremarks_" + i;

            var rembak = document.getElementById(strrema).value;

            //var rema_array = rembak.split(',');

            //var uncheckstring = item.get_text();

            //var a = rema_array.indexOf(uncheckstring.substring(1,5));

            //alert(a);

            var rem = document.getElementById(strrema).value;

            rem = rem.replace(item.get_text() + "-", "");

            rem = rem.replace(",", "");
 
            var qty = rem;

 
            document.getElementById(strrema).value = rem.replace(qty, "");



            document.getElementById(strrema).value = rembak.replace(item.get_text() + "-" + rem + ",", "");



            var str = "ContentPlaceHolder1_grdItems_txtqty_" + i;

            document.getElementById(str).value = parseFloat(document.getElementById(str).value) - parseFloat(qty);


            document.getElementById(str).readOnly = false;

            

            //alert(rembak);

            //document.getElementById(str).value = parseFloat(document.getElementById(str).innerHTML != "NaN" ? document.getElementById(str).innerHTML : "0");


        }

        $.each(obj, function (index, value) {
            alert(index + ' : ' + value);
        });

        //document.getElementById(str).readOnly = true;

        //CellValue = parseFloat(CellValue) + parseFloat(document.getElementById(str).innerHTML != "NaN" ? document.getElementById(str).innerHTML : "0");


        //var grid = document.getElementById("<%=grdItems.ClientID%>");

<%--        var gdview=document.getElementById("<%=grdItems.ClientID %>");
        var value = gdview.rows(rowIndex).cells(0).innerText;--%>

 
        }
 
</script>



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

            var strrema = "ContentPlaceHolder1_grdItems_txtremarks_" + i;

            //var itm = "MainContent_grdItems_lblItemID_" + i;
            //var ItemID = document.getElementById(itm).innerHTML

            //alert(" Item ID" + ItemID.toString());

            var str = "MainContent_grdItems_txtqty_" + i;
            var CellValue = document.getElementById(str);

            

            e = (e) ? e : window.event;
            var charCode = (e.which) ? e.which : e.keyCode;

            if (e.keyCode > 47 && e.keyCode < 58 || charCode >= 96 && charCode <= 105 || $.inArray(e.keyCode, [46, 8, 9, 27, 13, 110, 190]) !== -1) {

                if (document.getElementById(strrema).value == "") {
                    alert("Please Choose Location To Enter the Quantity!");
                    document.getElementById(itm).value = parseFloat("0");
                    e.preventDefault();
                    return false;
                }
                else {

                    return;
                }
 
            }
            else {
                //CellValue.innerHTML = parseFloat("0");
                alert("Please Enter Only Numeric Value...");
                document.getElementById(str).value = parseFloat("0");
                e.preventDefault();

                return false;
            }

        }


        function MakeTotal(rowindex) {
            // var strBudget = "ctl00_ContentPlaceHolder1_txtAppBudget";


<%--            var Budget = $find("<%=txtAppBudget.ClientID %>");

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

            Balance.set_value(parseFloat(bagval - parseFloat(CellValue)));--%>

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

        function GetQuantity(value) {

            alert(value);
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


      <div class="col-lg-12" style="align-content:center;background-color:lightgrey;">
          <div style="display: inline-block; margin-left:40px; margin-top: 20px;">
              <img alt="" src="images/Items.png" />
              <strong>Annual I.T Requisition</strong>
          </div>
          <div style="display: inline-block; margin-left: 490px; margin-top: 20px;">
              <telerik:RadButton ID="btnClose" runat="server" Text="Close" Font-Size="10pt" Height="30px" ButtonType="SkinnedButton" OnClick="btnClose_Click">
              </telerik:RadButton>
          </div>
     </div>

    <div class="col-lg-6">

        <div style="display: inline-block; margin-left: 300px; margin-top: 20px;">
            <label id="brhlabel" runat="server">Select Branch :</label>
            <telerik:RadComboBox ID="cmbbranch" runat="server" AutoPostBack="True" MarkFirstMatch="True" OnSelectedIndexChanged="cmbbranch_SelectedIndexChanged" Sort="Ascending" Width="300px">
            </telerik:RadComboBox>

        </div>

        <div style="display: inline-block; margin-left: 300px; margin-top: 20px;">
            <label>Requisition Type:</label>
            <telerik:RadComboBox ID="cmbReqType" runat="server" Width="300px" Sort="Ascending" OnSelectedIndexChanged="cmbReqType_SelectedIndexChanged" AutoPostBack="True">
            </telerik:RadComboBox>
        </div>

        <div id="ITReqDiv" runat="server" style="display: inline-block; margin-left: 300px; margin-top: 20px;">
            <label>Show Overall I.T Requisition Items: </label>
            <asp:CheckBox ID="ShowITReq" runat="server" AutoPostBack="true" OnCheckedChanged="ShowITReq_CheckedChanged" />
        </div>

        <asp:Label ID="lblReqIds" runat="server" Visible="false"></asp:Label>

        <div style="display: inline-block; margin-left: 300px; margin-top: 20px;">
            <label style="display:inline-block;">Last Submission Date:</label>
        </div>  
        <div style="display: inline-block; margin-top: 20px;">
            <asp:TextBox ID="txtDlvdate" CssClass="form-control" runat="server" Width="125px"></asp:TextBox>
            <asp:CalendarExtender ID="txtDlvdate_CalendarExtender" runat="server" Enabled="True" TargetControlID="txtDlvdate">
            </asp:CalendarExtender>
        </div>  
        <div style="display: inline-block; margin-top: 20px;">
            <telerik:RadButton CssClass="form-control" ID="btnDateExtend" runat="server" Visible="false"  Text="Extend Date" Font-Size="10pt" Height="30px" ButtonType="SkinnedButton" Width="120px" OnClick="btnDateExtend_Click" Style="text-align: center">
            </telerik:RadButton>

<%--            <label id="lblEvent" runat="server" style="display:inline-block;"/>
            <label id="lblDays" runat="server" style="display:inline-block;"/>
            <label id="lblHours" runat="server" style="display:inline-block;"/>
            <label id="lblMinutes" runat="server" style="display:inline-block;"/>
            <label id="lblSeconds" runat="server" style="display:inline-block;"/>
            <asp:Timer ID="tmrCheckTime" runat="server" OnTick="tmrCheckTime_Tick" />--%>
        </div>

    </div>

    
    
    <div class="col-lg-6">

        <div style="display: inline-block; margin-left: 10px; margin-top: 65px;">
            <label>Requisition No:</label>
            <telerik:RadTextBox ID="txtReqNo" runat="server" Height="25px" Width="100px" Style="font-weight: 700; text-align: center; font-size: medium" OnTextChanged="txtReqNo_TextChanged" AutoPostBack="true">
            </telerik:RadTextBox>
            &nbsp;<a href="ReportsMain.aspx?rptname=ITRequisition&amp;reqno=<%= txtReqNo.Text %>" target="_blank">Print</a>
        </div>

    </div>

    <div class="col-lg-12">
        <div style="display: inline-block;margin-top: 20px;">
            <asp:Button ID="btnExport" runat="server" OnClick="btnExport_Click" Text="Export to Excel" />
        </div>

        <div style="display: inline-block; margin-top: 20px;">
           <telerik:RadButton ID="btnConfirm" runat="server" Visible="false" Text="Show Item List" Font-Size="10pt" Height="30px" ButtonType="SkinnedButton" Width="120px" OnClick="btnConfirm_Click" Style="text-align: center">
            </telerik:RadButton>
       </div>

        <div style="display: inline-block; margin-left: 10px; margin-top: 80px;align-content:flex-end;">
            <asp:Button ID="btnNewItem" class="form-control-success" runat="server" OnClick="btnNewItem_Click" Text="Add Item Into Requisition" />
        </div>

    </div>

    <div class="col-lg-12">

        <div style="display: inline-block; margin-top: 20px;">
            <asp:UpdatePanel ID="UpdatePanel1" UpdateMode="Always" runat="server">
                <ContentTemplate>

                   <%-- <td class="auto-style62" colspan="5">--%>
                        <div>

                            <asp:GridView ID="grdItems" runat="server"
                                AutoGenerateColumns="False"
                                cellclassname="column" class="table table-striped table-hover"
                                OnRowCommand="grdItems_RowCommand" OnRowDeleting="grdItems_RowDeleting"
                                OnRowEditing="grdItems_RowEditing" OnRowUpdating="grdItems_RowUpdating"
                                PagerStyle-CssClass="pgr" Style="font-size: x-small; text-align: center;" Width="1500px"
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

                                    <%--  <asp:TemplateField>
                                                    <ItemTemplate>
                                                        <asp:HiddenField ID="hfSubCategory" runat="server"
                                                                         Value='<%#Eval("ReqGroup")%>' />
                                                    </ItemTemplate>
                                               </asp:TemplateField>--%>



                                    <asp:BoundField DataField="ReqGroup" HeaderText="Requisition Group" ItemStyle-Width="150px" ItemStyle-HorizontalAlign="Left" ItemStyle-VerticalAlign="Middle" Visible="false" />

                                    <asp:TemplateField HeaderText="Item Category" Visible="false">
                                        <ItemTemplate>
                                            <asp:Label ID="lblCategory" runat="server" Text='<%#CheckIfTitleExists(Eval("ItemHeadTitle").ToString())%>' Width="200px" Visible="false"></asp:Label>
                                        </ItemTemplate>
                                        <ItemStyle HorizontalAlign="Left" VerticalAlign="Middle" Width="100px" />
                                    </asp:TemplateField>

                                    <asp:BoundField DataField="ItemHeadTitle" HeaderText="Item Head" ItemStyle-Width="200px" ItemStyle-HorizontalAlign="Left" ItemStyle-VerticalAlign="Middle" Visible="false" />

                                    <asp:TemplateField HeaderText="ItemID" Visible="false">
                                        <ItemTemplate>
                                            <asp:Label ID="lblItemID" runat="server" Text='<%#Eval("fkItemID") %>' />
                                        </ItemTemplate>
                                        <ItemStyle HorizontalAlign="Left" VerticalAlign="Middle" Width="50px" />
                                    </asp:TemplateField>



                                    <asp:BoundField DataField="InvCode" HeaderText="Item Code" Visible="false" />

                                    <asp:BoundField DataField="ItemTitle" HeaderText="Item Name" ItemStyle-Width="300px" ItemStyle-HorizontalAlign="Left" ItemStyle-VerticalAlign="Middle" />

                                    <asp:BoundField DataField="Unit" HeaderText="Unit" ItemStyle-Width="100px" Visible="false" />

                                    <asp:BoundField DataField="Balance" HeaderText="In Stock Balance">
                                        <ItemStyle Font-Bold="True" Font-Size="Larger" ForeColor="#006600" />
                                    </asp:BoundField>

                                    <asp:BoundField DataField="ProposedQtty" HeaderText="Proposed Qtty" Visible="false">
                                        <ItemStyle Font-Bold="True" Font-Size="14px" ForeColor="#180066" />
                                    </asp:BoundField>


                                    <asp:TemplateField HeaderText="Qty Required">
                                        <ItemTemplate>
                                            <asp:TextBox ID="txtqty" runat="server" Enabled="true" AutoPostBack="false" autocomplete="off" CssClass="AlgRgh" OnTextChanged="txtqty_TextChanged" Text='<%#Eval("QtyRequired") %>' onclick="GridRowNo(<%# Container.DataItemIndex %>,this);" Width="50px" Font-Size="14px"></asp:TextBox>
                                        </ItemTemplate>
                                        <ItemStyle HorizontalAlign="Right" VerticalAlign="Middle" Font-Size="14px" />
                                    </asp:TemplateField>

                                    <asp:TemplateField HeaderText="Rate" Visible="false">
                                        <ItemTemplate>
                                            <asp:Label ID="lblrate" runat="server" Text='<%#Eval("Rate") %>' Width="50px" />
                                        </ItemTemplate>
                                        <ItemStyle HorizontalAlign="Right" VerticalAlign="Middle" Font-Size="12px" />
                                    </asp:TemplateField>


                                    <%--<asp:BoundField DataField="Amount" HeaderText="Amount" >--%>

                                    <asp:TemplateField HeaderText="Amount" ItemStyle-HorizontalAlign="Right" Visible="false">
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

                                    <asp:TemplateField HeaderText="Location">
                                        <ItemTemplate>
                                            <asp:Label ID="lblLocation" runat="server" Text='<%# Eval("LocName")%>'></asp:Label>
                                            <asp:Label ID="lblLocationToID" runat="server" Style="display: none;" Text='<%# Eval("LocToID")%>'></asp:Label>
                                            <input type="hidden" id="locqtty" runat="server" />
                                            <telerik:RadComboBox ID="ddlLocationto" runat="server" class="form-control" RenderMode="Lightweight" Filter="Contains" AllowCustomText="true" AutoPostBack="False" MarkFirstMatch="True" Sort="Ascending" CheckBoxes="true" EnableCheckAllItemsCheckBox="true" EmptyMessage="Select Location" OnClientItemChecked="OnClientItemChecked"></telerik:RadComboBox>
                                        </ItemTemplate>
                                    </asp:TemplateField>

                                    <asp:TemplateField HeaderText="Issued-To">
                                        <ItemTemplate>
                                            <asp:Label ID="lblPerson" runat="server" Text='<%# Eval("empName")%>'></asp:Label>
                                            <asp:Label ID="lblIssuedToID" runat="server" Style="display: none;" Text='<%# Eval("IsuToID")%>'></asp:Label>

                                            <telerik:RadComboBox ID="ddlPersonto" runat="server" class="form-control" RenderMode="Lightweight" Filter="Contains" AllowCustomText="true" AutoPostBack="False" MarkFirstMatch="True" Sort="Ascending" CheckBoxes="true" EnableCheckAllItemsCheckBox="true" EmptyMessage="Select Person Name" OnItemChecked="ddlPersonto_ItemChecked"></telerik:RadComboBox>
                                        </ItemTemplate>
                                    </asp:TemplateField>

                                    <asp:TemplateField HeaderText="Remarks">
                                        <ItemTemplate>
                                            <asp:TextBox ID="txtremarks" runat="server" AutoPostBack="false" autocomplete="off" Text='<%#Eval("Remarks") %>' Width="350px"></asp:TextBox>
                                        </ItemTemplate>
                                        <ItemStyle HorizontalAlign="Right" VerticalAlign="Middle" />
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
                  <%--  </td>--%>
                </ContentTemplate>
            </asp:UpdatePanel>

        </div>
    </div>
    <div class="col-lg-12">
        <div style="display: inline-block; margin-left: 10px; margin-top: 20px;">
            <telerik:RadButton ID="btnSubmit" runat="server" Text="Save Requisition" Font-Size="10pt" Height="30px" ButtonType="SkinnedButton" OnClick="btnSubmit_Click" Style="text-align: center; top: 2px; left: 76px; width: 227px;">
            </telerik:RadButton>
        </div>
        <div style="display: inline-block; margin-left: 10px; margin-top: 20px;">
            <telerik:RadButton ID="btnPost" runat="server" Visible="false" Text="Submit Requisition" Font-Size="10pt" Height="30px" ButtonType="SkinnedButton" OnClick="btnPost_Click" Style="text-align: center; top: 2px; left: 76px; width: 227px;">
            </telerik:RadButton>

        </div>

    </div>



  

    <div id="GridID" runat="server" class="panel-body">

        <div class="table-responsive">
            <table class="table table-striped table-bordered table-hover" id="dataTables-dbReqSummary">
                <thead>
                    <tr>
                        <asp:PlaceHolder ID="PlaceHolder1" runat="server"></asp:PlaceHolder>
                    </tr>
                </thead>
                <tbody>
                    <asp:PlaceHolder ID="PlaceHolder2" runat="server"></asp:PlaceHolder>
                </tbody>

            </table>

        </div>
    </div>

</asp:Content>


