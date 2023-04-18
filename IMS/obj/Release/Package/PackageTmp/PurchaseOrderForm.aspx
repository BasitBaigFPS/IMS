<%@ Page Title="" Language="C#" MasterPageFile="~/Site1.Master" AutoEventWireup="true" CodeBehind="PurchaseOrderForm.aspx.cs" Inherits="IMS.PurchaseOrderForm" %>

<%@ Register Assembly="AjaxControlToolkit" Namespace="AjaxControlToolkit" TagPrefix="asp" %>
<%@ Register Assembly="Telerik.Web.UI" Namespace="Telerik.Web.UI" TagPrefix="telerik" %>



<asp:Content ID="Content1" ContentPlaceHolderID="HeadContent" runat="server">

    <script type="text/javascript">
        //window.onerror = function (msg, url, linenumber) {
        //    alert('Error message: ' + msg + '\nURL: ' + url + '\nLine Number: ' + linenumber);
        //    return true;
        //};


        function validate() {
            var result = true;

            var namefield = document.getElementById("yourname");
            var nameerr = document.getElementById("nameerr");
            var namefieldRE = /^[\w ]+$/;

            var emailfield = document.getElementById("youremail");
            var emailerr = document.getElementById("emailerr");

            var emailfieldRE = /^[\w\-\.\+]+\@[a-zA-Z0-9\.\-]+\.[a-zA-z0-9]{2,4}$/;

            if (!namefield.value.match(namefieldRE)) {
                nameerr.innerHTML = "Please fill in your name";
                nameerr.style.color = "#ff0000";
                result = false;
            } else {
                nameerr.innerHTML = "";
                result = true;
            }

            if (!emailfield.value.match(emailfieldRE)) {
                emailerr.innerHTML = "Please fill in your email";
                emailerr.style.color = "#ff0000";
                result = false;
            } else {
                emailerr.innerHTML = "";
                result = true;
            }

            return result;
        }

        function doTotals() {
            var animals = ['Tiger_', 'bobcat_', 'elephant_', 'penguin_'];
            var priceStr = 'price';
            var quantityStr = 'quantity';
            var subtotalStr = 'subtotal';
            var total = 0;
            for (var i = 0; i < animals.length; i++) {
                var price = document.getElementById(animals[i] + priceStr).value;
                var quantity = document.getElementById(animals[i] + quantityStr).value;
                document.getElementById(animals[i] + subtotalStr)
                    .innerHTML = parseInt(price) * parseInt(quantity);
                total += price * quantity;
            }
            document.getElementById("finaltotal").innerHTML = total;
        }

        function setup() {
            var lastCol = document.getElementById("subtotal_header");

            var theForm = document.getElementById("souvenirsorderform");

            var amounts = document.getElementsByTagName("select");
            for (var i = 0; i < amounts.length; i++) {
                amounts[i].onchange = doTotals;
            }

            theForm.onsubmit = validate;
        }

        window.onload = setup;

    </script>


</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">

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


    </script>

    <div class="container">
        <div class="table-wrapper">
            <div class="table-title">
                <div class="row">
                    <div class="col-sm-12">
                        <h2>Purchase <b>Order</b></h2>


                        <div class="panel panel-default">
                            <div class="panel-heading">
                                <h5>Purchase Order Preparation</h5>

                            </div>
                            <div class="panel-body">
<%--                                <asp:UpdatePanel ID="UpdatePanel1" runat="server">

                                    <ContentTemplate>--%>

                                        <asp:Button ID="ShowMe" CssClass="btn btn-primary btn-lg" runat="server" Text="Request Spare" ClientIDMode="Static" data-toggle="modal" data-backdrop="static" data-target="#myModal" style="display: none;" OnClientClick="return  false" />


                                        <div class="row" style="background-color: ghostwhite;">

                                            <div class="col-lg-5">

                                                <div class="form-group">
                                                    <div style="float: left; margin: 5px;margin-top:10px;">
                                                        <label>Select PO Type:</label>
                                                        <label class="checkbox-inline">
                                                            <input type="checkbox" id="chkNewPO" runat="server" />NEW PO
                                                        </label>
                                                        <label class="checkbox-inline">
                                                            <input type="checkbox" id="chkOLDPO" runat="server" />OLD PO
                                                        </label>
                                                    </div>
                                                </div>

                                                <div class="form-group">
                                                        <div style="float: left; margin: 5px;margin-top:10px;">
                                                    <label>Select System:</label>
                                                    <label class="checkbox-inline">
                                                        <input type="checkbox" id="chkfps" runat="server" />FPS-KHI
                                                    </label>
                                                    <label class="checkbox-inline">
                                                        <input type="checkbox" id="chkhyd" runat="server" />FPS-HYD
                                                    </label>
                                                    <label class="checkbox-inline">
                                                        <input type="checkbox" id="chkhss" runat="server" />HSS
                                                    </label>
                                                    <label class="checkbox-inline">
                                                        <input type="checkbox" id="chkho" runat="server" />HO
                                                    </label>
                                                    </div>
                                                </div>

                                                <div class="form-group">

                                                    <div style="float: left; margin: 5px;">
                                                        <label>Academic Year:</label>
                                                        <asp:DropDownList ID="ddlAcdYear" runat="server" class="form-control" Height="30px" style="width: 200px; text-transform: uppercase; display: inline-block; line-height: 0.8">
                                                            <asp:ListItem>==Please Select==</asp:ListItem>
                                                            <asp:ListItem Value="12" Selected="True">2019-2020</asp:ListItem>
                                                            <asp:ListItem Value="11">2018-2019</asp:ListItem>
                                                        </asp:DropDownList>
                                                    </div>
                                                </div>

                                            </div>

                                            <div class="col-lg-7">

                                                <div class="form-group">

                                                    <label>Requisition Type</label>
                                                    <label class="radio-inline">
                                                        <input type="radio" name="optionsRadiosInline" id="optSyb" value="SYB" runat="server" checked="" />Syllabus
                                                    </label>
                                                    <label class="radio-inline">
                                                        <input type="radio" name="optionsRadiosInline" id="optRegS" value="STN" runat="server" checked="" />Stationery
                                                    </label>
                                                    <label class="radio-inline">
                                                        <input type="radio" name="optionsRadiosInline" id="optRegK" runat="server" value="KTC" />Kitchen/Cleaning
                                                    </label>
                                                    <label class="radio-inline">
                                                        <input type="radio" name="optionsRadiosInline" id="optRegA" runat="server" value="ART" />Art
                                                    </label>
                                                    <label class="radio-inline">
                                                        <input type="radio" name="optionsRadiosInline" id="optMan" runat="server" value="MAN" />Manual
                                                    </label>
                                                    <label class="radio-inline">
                                                        <input type="radio" name="optionsRadiosInline" id="optIT" runat="server" value="IT" />I.T
                                                    </label>

                                                </div>
                                                <div class="form-group">

                                                    <label>Select Vendor:</label>
                                                    <asp:DropDownList ID="ddlvendor" runat="server" class="form-control" EnableViewState="true" Font-Overline="False" Font-Size="Small" Height="30px" style="width: 300px; text-transform: uppercase; display: inline-block; line-height: 0.8">
                                                    </asp:DropDownList>
                                                </div>
                                                <div class="form-group">
                                                    <label for="contactname" class="form-control-label">Contact Name:</label>

                                                    <input id="contactname" type="text" runat="server" placeholder="Person Name" class="form-control" style="width: 300px; text-transform: uppercase; display: inline-block; line-height: 0.8" />
                                                </div>

                                            </div>

                                        </div>


                                        <div class="row">
                                            <div class="col-lg-12" style="background-color: burlywood;">
                                                <h5></h5>
                                            </div>
                                        </div>

                                        <div class="row" style="background-color: ghostwhite;">
                                            <div class="col-lg-6">
                                                <div class="form-group">
                                                    <label>Department:</label>
                                                    <asp:DropDownList ID="ddlDepartment" runat="server" class="form-control" Height="30px" style="width: 250px; margin-top: 10px; text-transform: uppercase; display: inline-block; line-height: 0.8">
                                                        <asp:ListItem Selected="True">==Please Select==</asp:ListItem>
                                                    </asp:DropDownList>
                                                </div>
                                            </div>


                                            <div class="col col-lg-3" style="width: 221px;">
                                                <div class="form-group">
                                                    <label>PO Number:</label>
                                                    <input id="txtPONO" type="text" runat="server" class="form-control" style="width: 80px; margin-top: 10px; margin-right: -10px; text-transform: uppercase; display: inline-block; line-height: 0.8" />
                                                    &nbsp;&nbsp;<a href="ReportsMain.aspx?rptname=PurchaseOrder&amp;pono=<%= txtPONO.Value %>" target="_blank" style="display: inline-block;">Print</a>
                                                </div>
                                            </div>
                                            <div class="col col-lg-3">
                                                <div class="form-group">
                                                    <label>PO Date:</label>
                                                    <input type="date" id="txtPODate" runat="server" class="form-control" onkeydown="return (event.keyCode!=13);" style="width: 135px; margin-left: 42px; margin-top: 10px; display: inline-block; line-height: 0.8" />
                                                </div>
                                            </div>


                                        </div>

                                        <div class="row" style="background-color: ghostwhite;">
                                            <div class="col-lg-6">
                                                <div class="form-group">
                                                    <div class="form-group">
                                                        <label>Delivery Date:</label>
                                                        <input type="date" id="txtDelvDate" runat="server" class="form-control" style="width: 135px; margin-top: 10px; display: inline-block; line-height: 0.8" />
                                                    </div>
                                                </div>
                                            </div>


                                            <div class="col col-lg-3" style="width: 221px;">
                                                <div class="form-group">
                                                    <label>Quotation ID:</label>
                                                    <input id="txtQuot" type="text" runat="server" class="form-control" style="width: 100px; margin-top: 10px; margin-right: -10px; text-transform: uppercase; display: inline-block; line-height: 0.8" />
                                                </div>
                                            </div>
                                            <div class="col col-lg-3">
                                                <div class="form-group">
                                                    <label>Quotation Date:</label>
                                                    <input type="date" id="txtQuotDate" runat="server" class="form-control" onkeydown="return (event.keyCode!=13);" style="width: 135px; margin-top: 10px; display: inline-block; line-height: 0.8" />
                                                </div>
                                            </div>

                                        </div>

                                        <div class="row" style="background-color: ghostwhite;">
                                            <div class="col-lg-8">

                                                <div class="form-group">
                                                    <label>Delivery At:</label>
                                                    <input id="txtDelivAt" type="text" runat="server" class="form-control" style="width: 550px; margin-top: 10px; text-transform: uppercase; display: inline-block; line-height: 0.8" />
                                                </div>
                                                <div class="form-group">
                                                    <label>Term & Conditions:</label>
                                                    <textarea id="txtTermCond" class="form-control" runat="server" cols="1" rows="2" style="width: 665px; margin-bottom: -10px;"></textarea>
                                                </div>

                                            </div>


                                            <div class="col col-lg-4" style="width: 221px; margin-left: 50px;">
                                                <div class="form-group" style="margin-top: 60px;">
                                                    <label>Total PO Cost:</label>
                                                    <input id="txtPOCost" type="text" runat="server" class="form-control" style="width: 100px; margin-top: 10px; margin-right: -10px; text-transform: uppercase; display: inline-block; line-height: 0.8" readonly />
                                                </div>

                                                <div class="form-group">
                                                    <asp:Button ID="btnShowItemList" runat="server" Text="Show Item" class="btn btn-success" OnClick="btnShowItemList_Click" />

                                                </div>


                                            </div>


                                        </div>

                                        <div class="row" style="background-color: ghostwhite;">


                                            <div class="col-lg-10" style="margin-left: 10px; margin-right: 10px;">

                                                <asp:GridView ID="grdItems" runat="server" AutoGenerateColumns="False"
                                                    cellclassname="column" class="table table-striped table-hover"
                                                    OnRowCommand="grdItems_RowCommand" OnRowDeleting="grdItems_RowDeleting"
                                                    OnRowEditing="grdItems_RowEditing" OnRowUpdating="grdItems_RowUpdating"
                                                    Pagerstyle-CssClass="pgr" style="font-size: x-small; text-align: center;" Width="1800px"
                                                    AllowSorting="True" OnRowUpdated="grdItems_RowUpdated" OnSorting="grdItems_Sorting"
                                                    OnDataBound="grdItems_DataBound" OnRowCreated="grdItems_RowCreated" OnRowDataBound="grdItems_RowDataBound">

                                                    <Pagerstyle CssClass="pgr"></Pagerstyle>
                                                    <Rowstyle CssClass="gridrow" />
                                                    <Rowstyle ForeColor="Black" />
                                                    <SelectedRowstyle BackColor="YellowGreen" ForeColor="Blue" Font-Bold="True" />
                                                    <Columns>
                                                        <asp:CommandField ShowDeleteButton="false" Visible="false" />

                                                        <asp:TemplateField>  
                                                            <HeaderTemplate> 
                                                                 
                                                                <asp:CheckBox ID="ChkAll" AutoPostBack="true" OnCheckedChanged="ChkAll_CheckedChanged" runat="server" /> </HeaderTemplate>  
                                                            <ItemTemplate>  
                                                                <asp:CheckBox ID="ChkRow" runat="server" /> </ItemTemplate>  
                                                        </asp:TemplateField>



                                                        <asp:TemplateField HeaderText="S.No">
                                                            <ItemTemplate>
                                                                <%# Container.DataItemIndex + 1 %>
                                                            </ItemTemplate>
                                                            <Itemstyle Width="2%" />
                                                        </asp:TemplateField>


                                                        <asp:BoundField DataField="pkreqpoID" Visible="false" />

                                                        <asp:TemplateField HeaderText="Item ID" Visible="true">
                                                            <ItemTemplate>
                                                                <asp:Label ID="lblItemID" runat="server" Text='<%#Eval("fkItemID") %>' />
                                                            </ItemTemplate>
                                                            <Itemstyle HorizontalAlign="Left" VerticalAlign="Middle" Width="50px" />
                                                        </asp:TemplateField>
                                              
                                                        <asp:BoundField DataField="ItemTitle" HeaderText="Item Name" Itemstyle-Width="400px" Itemstyle-HorizontalAlign="Left" Itemstyle-VerticalAlign="Middle" />

                                                        <asp:BoundField DataField="Unit" HeaderText="Unit" Itemstyle-Width="150px" />

                                                        <asp:BoundField DataField="Balance" HeaderText="In Stock Balance">
                                                            <Itemstyle Font-Bold="True" Font-Size="Larger" ForeColor="#006600" />
                                                        </asp:BoundField>

                                                        <asp:TemplateField HeaderText="Quantity Demand">
                                                            <ItemTemplate>
                                                                <asp:Label ID="lblqtyDemand" runat="server" Text='<%#Eval("QuantityDemand") %>' Width="50px" />
                                                            </ItemTemplate>
                                                            <Itemstyle HorizontalAlign="Right" VerticalAlign="Middle" />
                                                        </asp:TemplateField>

                                                        <asp:TemplateField HeaderText="InStock">
                                                            <ItemTemplate>
                                                                <asp:TextBox ID="txtqty" runat="server" AutoPostBack="false" autocomplete="off" CssClass="AlgRgh" OnTextChanged="txtqty_TextChanged" Text='<%#Eval("InStock") %>' onclick="GridRowNo(<%# Container.DataItemIndex %>,this);" Width="50px" Font-Size="14px"></asp:TextBox>
                                                            </ItemTemplate>
                                                            <Itemstyle HorizontalAlign="Right" VerticalAlign="Middle" Font-Size="14px" />
                                                        </asp:TemplateField>

                                                        <asp:TemplateField HeaderText="PO-Quantity">
                                                            <ItemTemplate>
                                                                <asp:Label ID="lblpoqty" runat="server" Text='<%#Eval("POQuantity") %>' Width="50px" />
                                                            </ItemTemplate>
                                                            <Itemstyle HorizontalAlign="Right" VerticalAlign="Middle" />
                                                        </asp:TemplateField>

                                                        <asp:TemplateField HeaderText="Order Quantity">
                                                            <ItemTemplate>
                                                                <asp:TextBox ID="txtOrdqty" runat="server" AutoPostBack="false" autocomplete="off" CssClass="AlgRgh" OnTextChanged="txtOrdqty_TextChanged" Text='<%#Eval("OrderQuantity") %>' onclick="GridRowNo(<%# Container.DataItemIndex %>,this);" Width="50px" Font-Size="14px"></asp:TextBox>
                                                            </ItemTemplate>
                                                            <Itemstyle HorizontalAlign="Right" VerticalAlign="Middle" Font-Size="14px" />
                                                        </asp:TemplateField>

                                                        <asp:TemplateField HeaderText="Rate">
                                                            <ItemTemplate>
                                                                <asp:Label ID="lblrate" runat="server" Text='<%#Eval("Rate") %>' Width="50px" />
                                                            </ItemTemplate>
                                                            <Itemstyle HorizontalAlign="Right" VerticalAlign="Middle" />
                                                        </asp:TemplateField>


                                                        <asp:TemplateField HeaderText="Amount" Itemstyle-HorizontalAlign="Right">
                                                            <ItemTemplate>
                                                                <asp:Label ID="lblamt" runat="server" Text='<%# Eval("Amount") %>' />
                                                            </ItemTemplate>
                                                            <FooterTemplate>
                                                                <div style="text-align: right;">
                                                                    <asp:Label ID="lblTotalAmount" runat="server" Font-Bold="true" />
                                                                </div>
                                                            </FooterTemplate>
                                                            <Itemstyle Font-Bold="True" Font-Size="Larger" ForeColor="Black" />
                                                        </asp:TemplateField>

                                                    </Columns>

                                                    <Footerstyle BackColor="#507CD1" Font-Bold="True" ForeColor="White" />
                                                    <Pagerstyle BackColor="#2461BF" ForeColor="White" HorizontalAlign="Center" />
                                                    <SelectedRowstyle BackColor="#D1DDF1" ForeColor="#333333" Font-Bold="True" />
                                                    <Headerstyle BackColor="#507CD1" Font-Bold="True" ForeColor="White" />
                                                    <EditRowstyle BackColor="#2461BF" />
                                                    <AlternatingRowstyle BackColor="White" />

                                                </asp:GridView>

                                            </div>


                                        </div>

                                        <div class="row">
                                            <div class="col-lg-12" style="background-color: burlywood;">

                                                <h5></h5>

                                            </div>
                                        </div>

                                        <div class="row" style="background-color: ghostwhite;">
                                            <div class="col-lg-12">
                                                <div class="form-group">
                                                    <label>Total Quantity:</label>
                                                    <input type="text" id="txtTotalQuantity" runat="server" class="form-control" style="width: 100px; margin-top: 10px; margin-right: -10px; text-transform: uppercase; display: inline-block; line-height: 0.8" readonly />
                                                </div>
                                                <div class="form-group">
                                                    <label>Total Amount:</label>
                                                    <input type="text" id="txtTotalAmount" runat="server" class="form-control" style="width: 100px;  margin-top: 10px; display: inline-block; line-height: 0.8" readonly />
                                                </div>
                                            </div>
                                        </div>



                                        <div class="row" style="background-color: AppWorkspace;">
                                            <div class="col-lg-12">

                                                <div class="form-group">
                                                    <div style="float: left; margin: 5px;">
                                                        <asp:Button ID="btnSubmit" runat="server" Text="Save" class="btn btn-success" EnableViewState="False" OnClick="btnSubmit_Click" />
                                                    </div>

                                                    <div style="float: left; margin: 5px;">
                                                        <asp:Button ID="btnReset" runat="server" Text="Cancel" class="btn btn-warning" CausesValidation="False" OnClick="btnReset_Click" />
                                                    </div>

                                                    <div style="float: left; margin: 5px;">
                                                        <asp:Button ID="btnBack" runat="server" Text="Back" class="btn btn-info" CausesValidation="False" OnClick="btnBack_Click" />
                                                    </div>

                                                </div>
                                            </div>
                                        </div>

                                        <!-- /.row (nested) -->

   <%--                                 </ContentTemplate>
                                </asp:UpdatePanel>--%>

                            </div>

                            <!-- /.panel-body -->
                        </div>



                    </div>
                    <div class="col-sm-12">
                    </div>
                </div>
            </div>





        </div>
    </div>

    <script type="text/javascript">
        //Put your JavaScript code here.

        function CalculateAmount(CurrentPrice, InStock, Demand, QuntValue, TotalValue) {


            //alert(document.getElementById(InStock).value);

            var rate = parseFloat(document.getElementById(CurrentPrice).innerHTML);

            var stock = parseFloat(document.getElementById(InStock).value);

            var POQtty = document.getElementById(QuntValue);

            var reqdemand = parseFloat(document.getElementById(Demand).innerHTML);

            var OrderQtty = parseFloat(reqdemand - stock);

            POQtty.innerHTML = parseFloat(OrderQtty);

            var TotalVar = document.getElementById(TotalValue);

            var TotalPriceValue = parseFloat(rate * OrderQtty);

            //alert(TotalPriceValue);

            TotalVar.innerHTML = TotalPriceValue;


            //ContentPlaceHolder1_grdItems_lblpoqty_0
            //var TotalRq = parseFloat(TotalReq.get_value() != "" ? TotalReq.get_value() : "0") + TotalPriceValue;

            //var TotalRq = parseFloat(TotalReq.get_value()) + parseFloat(TotalPriceValue);

            //TotalReq.set_value(parseFloat(TotalRq));
            //document.getElementById(txtAmountReq).value = TotalRq;

        }

        function IsNumeric(e, rowindex) {


            var i = parseInt(rowindex);

            //var itm = "MainContent_grdItems_lblItemID_" + i;
            //var ItemID = document.getElementById(itm).innerHTML

            //alert(" Item ID" + ItemID.toString());

            var str = "ContentPlaceHolder1_grdItems_txtqty_" + i;
            var CellValue = document.getElementById(str);



            e = (e) ? e : window.event;
            var charCode = (e.which) ? e.which : e.keyCode;

            if (e.keyCode > 47 && e.keyCode < 58 || charCode >= 96 && charCode <= 105 || $.inArray(e.keyCode, [46, 8, 9, 27, 13, 110, 190]) !== -1) {

                //if (document.getElementById(itm).value == "Duplicating - R") {
                //    alert("This Item is Not Allowed to Enter Requisition Value...");
                //    document.getElementById(itm).value = parseFloat("0");
                //    e.preventDefault();
                //    return false;
                //}
                //else {
                //    return;
                //}

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


        function MakeTotal(rowindex, TotalCost, TotalAmount, TotalQtty) {
            // var strBudget = "ctl00_ContentPlaceHolder1_txtAppBudget";


            var POCost = document.getElementById(TotalCost);

            var POAmount = document.getElementById(TotalAmount);

            var POQtty = document.getElementById(TotalQtty);

                var grid = document.getElementById("<%=grdItems.ClientID%>");

                var totalrow = parseFloat(grid.rows.length - 1);

                var i, CellValueQ, CellValueA
                i = parseInt(rowindex) + 1;

               
                CellValueA = 0;
                CellValueQ = 0;

                for (i = 0 ; i < totalrow ; i++) {
                    var stra = "ContentPlaceHolder1_grdItems_lblamt_" + i;

                    var strq = "ContentPlaceHolder1_grdItems_lblpoqty_" + i;

                    CellValueA = parseFloat(CellValueA) + parseFloat(document.getElementById(stra).innerHTML != "NaN" ? document.getElementById(stra).innerHTML : "0");

                    CellValueQ = parseFloat(CellValueQ) + parseFloat(document.getElementById(strq).innerHTML != "NaN" ? document.getElementById(strq).innerHTML : "0");
                }

                //alert(CellValueA);

                POAmount.value = CellValueA;

                POCost.value = CellValueA;

                POQtty.value = CellValueQ;


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



</asp:Content>
