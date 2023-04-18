<%@ Page Title="" Language="C#" MasterPageFile="~/Site1.Master" AutoEventWireup="true" CodeBehind="InternalGIN.aspx.cs" Inherits="IMS.InternalGIN" %>

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
                        <h2>Sports <b>Items</b></h2>

                        <div class="panel panel-default">
                            <div class="panel-heading">
                                <h5>Goods Issue Note (Internal)</h5>
                            </div>
                            <div class="panel-body">
<%--                                <asp:UpdatePanel ID="UpdatePanel1" runat="server">

                                    <ContentTemplate>--%>

                                        <asp:Button ID="ShowMe" CssClass="btn btn-primary btn-lg" runat="server" Text="Request Spare" ClientIDMode="Static" data-toggle="modal" data-backdrop="static" data-target="#myModal" Style="display: none;" OnClientClick="return  false" />


                                        <div class="row" style="background-color: ghostwhite;">

                                            <div class="col-lg-5">

                                                <div class="form-group">
                                                    <label>Transaction Type</label>
 

                                                </div>

                                                <div class="form-group">


                                                </div>

                                            </div>

                                            <div class="col-lg-7">

                                                <div class="form-group">

                                                </div>

                                                <div class="form-group">


                                                </div>

                                                <div class="form-group">
                                                 </div>

                                            </div>

                                        </div>


                                        <div class="row">
                                            <div class="col-lg-12" style="background-color: burlywood;margin-bottom:10px;">
                                                <h5></h5>
                                            </div>
                                        </div>

                                        <div class="row" style="background-color: ghostwhite;">
                                            <div class="col-lg-6">

                                                <div class="form-group">
                                                     <label>Select Vendor:</label>
                                                    <asp:DropDownList ID="ddlvendor" runat="server" class="form-control" EnableViewState="true" Font-Overline="False" Font-Size="Small" Height="30px" Style="width: 300px; text-transform: uppercase; display: inline-block; line-height: 0.8">
                                                    </asp:DropDownList>
                                                </div>

                                            </div>

                                            <div class="col col-lg-3" style="width: 221px;">
                                                <div class="form-group">
 
                                                </div>
                                            </div>
                                            <div class="col col-lg-3">
                                                <div class="form-group">
 
                                                </div>
                                            </div>


                                        </div>

                                        <div class="row" style="background-color: ghostwhite;">
                                            <div class="col-lg-6">
                                                <div class="form-group">
                                                    <div class="form-group">
                                                      </div>
                                                </div>
                                            </div>

                                            <div class="col col-lg-3" style="width: 221px;">
                                                <div class="form-group">
                                                   </div>
                                            </div>
                                            <div class="col col-lg-3">
                                                <div class="form-group">
                                                    </div>
                                            </div>

                                        </div>

                                        <div class="row" style="background-color: ghostwhite;">
                                            <div class="col-lg-8">

                                                <div class="form-group">
                                                  </div>

                                                <div class="form-group">
                                                  </div>

                                            </div>


                                            <div class="col col-lg-4" style="width: 221px; margin-left: 50px;">
                                                <div class="form-group" style="margin-top: 60px;">
                                               </div>

                                                <div class="form-group">
                                                    <asp:Button ID="btnShowItemList" runat="server" Text="Show Item" class="btn btn-success" OnClick="btnShowItemList_Click" />

                                                </div>


                                            </div>


                                        </div>

                                        <div class="row" style="background-color: ghostwhite;">


                                            <div class="col-lg-10" style="margin-left: 10px; margin-right: 10px;">

                                             

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
