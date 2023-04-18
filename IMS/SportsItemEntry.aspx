<%@ Page Title="" Language="C#" MasterPageFile="~/Site1.Master" AutoEventWireup="true" CodeBehind="SportsItemEntry.aspx.cs" Inherits="IMS.SportsItemEntry" %>

<%@ Register Assembly="AjaxControlToolkit" Namespace="AjaxControlToolkit" TagPrefix="asp" %>
<%@ Register Assembly="Telerik.Web.UI" Namespace="Telerik.Web.UI" TagPrefix="telerik" %>




<asp:Content ID="Content1" ContentPlaceHolderID="HeadContent" runat="server">

 
 
    <script type="text/javascript">
        //window.onerror = function (msg, url, linenumber) {
        //    alert('Error message: ' + msg + '\nURL: ' + url + '\nLine Number: ' + linenumber);
        //    return true;
        //};

        function doSomeStuff(ddl) {

            alert('branch');


            var ddlVals = document.getElementById(ddl.id);

            __doPostBack(ddlVals, '');
        }


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


        function CheckTrnsType(trtype)
        {
            
            if (trtype == 'RCV')
            {
                var ttype = document.getElementById('<%=chkTrnType.ClientID%>');                

                ttype.value = trtype;
            }

            var choicechk = document.getElementById('<%=chkchoise.ClientID%>');

            choicechk.value = trtype

            document.getElementById('<%=btnTrnType.ClientID%>').click();                  
        }


        function IsNumeric(e, rowindex) {
            var i = parseInt(rowindex);

            var str = "ContentPlaceHolder1_grdItems_txtqty_" + i;
            var CellValue = document.getElementById(str);

           

            e = (e) ? e : window.event;
            var charCode = (e.which) ? e.which : e.keyCode;

            if (e.keyCode > 47 && e.keyCode < 58 || charCode >= 96 && charCode <= 105 || $.inArray(e.keyCode, [46, 8, 9, 27, 13, 110, 190]) !== -1) {
                return;
            }
            else {
                alert("Please Enter Only Numeric Value...");
                document.getElementById(str).value = parseFloat("0");
                e.preventDefault();

                return false;
            }
        }

        function RecallCalculation(v)
        {
            alert("Im Calling Again");
        }

        function CalculateBalance(rowindex, Trtype, CurrentBal, QuntValue, TotalValue) {

            //e, rowindex, 

            //CheckQuantity(e, rowindex, QuntValue, CurrentBal);

            //alert(Trtype.value);
            var i = parseInt(rowindex);
            var tot;
            var QuntVar = parseFloat(document.getElementById(QuntValue).value != "" ? document.getElementById(QuntValue).value : "0");
            var TotalVar = document.getElementById(TotalValue);
            var TotalPriceValue;

            var ttype = document.getElementById('<%=chkTrnType.ClientID%>');

            //alert(ttype.value);
            // choicechk.value = trtype
            if (ttype.value == 'RCV') {
                TotalPriceValue = parseFloat(CurrentBal + QuntVar);
            }
            else
            {
                TotalPriceValue = parseFloat(CurrentBal - QuntVar);
            }
           
            if (parseFloat(TotalPriceValue) < 0) {

                alert("Insufficient Balance");
                
                var qttychk = "ContentPlaceHolder1_grdItems_txtqty_" + i;

                if (parseFloat(CurrentBal) == 0) {

                    document.getElementById(qttychk).value = parseFloat("0");
                }
                else
                {
                    document.getElementById(qttychk).value = parseFloat(CurrentBal);
                }

                
                return false;
            }
            else
            {
                TotalVar.innerHTML = TotalPriceValue;
            }

        }

        function CheckQuantity(e, rowindex, qtyID, Bal) {

            var i = parseInt(rowindex);

            var QuntVar = parseFloat(document.getElementById(qtyID).value != "" ? document.getElementById(qtyID).value : "0");

            var str = document.getElementById(qtyID) + i;

            var CellValue = document.getElementById(qtyID);


            if (QuntVar > Bal) {

                alert("Please Enter Less Quantity");
                document.getElementById(str).value = parseFloat("0");
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
                                <h5>Sports Items Management</h5>
                                <asp:UpdateProgress ID="updProgress"  AssociatedUpdatePanelID="UpdatePanel2" runat="server">
                                    <ProgressTemplate>
                                        <img alt="progress" src="images/BalanceUpdate.gif" style="width:200px; display: inline-block;margin-left:350px;" />
                                    </ProgressTemplate>
                                </asp:UpdateProgress>
 
                                <asp:UpdatePanel ID="UpdatePanel2" runat="server">
                                    <ContentTemplate>
                                        <asp:Button ID="btnUpdateStock" runat="server" ClientIDMode="Static" Text="Update Stock" class="btn btn-success" Style="display: inline-block; float: right; margin-top: -25px;" OnClick="btnUpdateStock_Click" />
                                    </ContentTemplate>
                                </asp:UpdatePanel>

                            </div>
                            <div class="panel-body">
                                <asp:UpdatePanel ID="UpdatePanel1" runat="server" EnableViewState="true" UpdateMode="Always" ChildrenAsTriggers="true">
    
                                    <ContentTemplate>

                                        <asp:Button ID="ShowMe" CssClass="btn btn-primary btn-lg" runat="server" Text="Request Spare" ClientIDMode="Static" data-toggle="modal" data-backdrop="static" data-target="#myModal" Style="display: none;" OnClientClick="return  false" />


                                        <div class="row" style="background-color: ghostwhite;">

                                            <div class="col-lg-7">

                                                <div class="form-group">
                                                    <label>Transaction Type</label>
                                                    <label class="radio-inline">
                                                        <input type="radio" name="optionsRadiosInline" id="optRecv" runat="server" value="RCV" onclick="CheckTrnsType('RCV');" />Received
                                                    </label>
                                                    <label class="radio-inline">
                                                        <input type="radio" name="optionsRadiosInline" id="optIsu" runat="server" value="ISU" onclick="CheckTrnsType('ISU');" />Issued
                                                    </label>
                                                    <label class="radio-inline">
                                                        <input type="radio" name="optionsRadiosInline" id="optDsp" runat="server" value="DSP" onclick="CheckTrnsType('DSP');" />Dispose
                                                    </label>
                                                    <label class="radio-inline">
                                                        <input type="radio" name="optionsRadiosInline" id="optLos" runat="server" value="LOS" onclick="CheckTrnsType('LOS');" />Lost
                                                    </label>
                                                    <asp:Button runat="server" ID="btnTrnType" Text="" style="display:none;" OnClick="btnTrnType_Click" />
                                                     <input type="text" id="chkTrnType" runat="server" style="display:none;" />
                                                </div>

                                                <div class="form-group">

                                                    <label runat="server" id="ToFromLabel">Receive From:</label>
                                                    <label class="checkbox-inline">
                                                        <input type="checkbox" id="chkvnd" runat="server" onclick="CheckTrnsType('VND');" />
                                                        <label for="chkvnd" id="lblvend" runat="server">Vendor</label>
                                                    </label>
                                                    <label class="checkbox-inline">
                                                        <input type="checkbox" id="chkbranch" runat="server" onclick="CheckTrnsType('BRH');"/>
                                                        <label for="chkbranch" id="lblbranch" runat="server">Branch</label>
                                                    </label>
                                                    <input type="text" runat="server" id="chkchoise" style="display:none;" />

                                                    <asp:Button ID="btnShowItemList" runat="server" ClientIDMode="Static" Text="Update" class="btn btn-success" style="display: inline-block; float:right;" OnClick="btnShowItemList_Click" />
                                                </div>

                                                <div class="form-group">
                                                    

                                                </div>

                                            </div>

                                            <div class="col-lg-5">

                                                <div class="form-group">

                                                </div>

                                                <div class="form-group">


                                                </div>

                                                <div class="form-group">

                                                    <label id="lblPrintDOC" runat="server">Print Document</label>
                              

                                                    <asp:TextBox ID="txtdocno" runat="server" BorderColor="#000066" BorderWidth="1px" Enabled="False"  Height="20px" onkeydown="addItem(event);" style="font-size:medium" Width="75px"></asp:TextBox>
                                                    <a href="ReportsMain.aspx?rptname=SportsTransaction&amp;gino=<%=txtdocno.Text %>" target="_blank">Print</a>

                                                </div>

                                            </div>

                                        </div>

                                        <div class="row" id="branchdiv" runat="server" style="display:none;">

                                            <div class="col-lg-12">
                                                <div class="form-group">
                                                    <label runat="server" id="Label1">Select Branch:</label>
                                                    <asp:DropDownList ID="ddlBranch" runat="server" class="form-control" EnableViewState="true" Font-Overline="False" Font-Size="Small" Height="30px" AutoPostBack="true" Style="width: 300px; text-transform: uppercase; display: inline-block; line-height: 0.8" OnSelectedIndexChanged="ddlBranch_SelectedIndexChanged">
                                                    </asp:DropDownList>

                                                    <asp:Button ID="btnShowstore" runat="server" ClientIDMode="Static" Text="Show Store" class="btn btn-primary" style="display: inline-block;  margin-left:20px" OnClick="btnShowstore_Click" />
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
                                                    <label runat="server" id="lblvndbrh">Select Vendor:</label>
                                                    <asp:DropDownList ID="ddlvendor" runat="server" class="form-control" EnableViewState="true" Font-Overline="False" Font-Size="Small" Height="30px" OnSelectedIndexChanged="ddlvendor_SelectedIndexChanged" Style="width: 300px; text-transform: uppercase; display: inline-block; line-height: 0.8">
                                                    </asp:DropDownList>
                                                </div>

                                            </div>

                                            <div class="col col-lg-6">
                                                <div class="form-group">
                                                    <label runat="server" id="lbldepart">Select Department:</label>
                                                    <asp:DropDownList ID="ddlDepartment" runat="server" class="form-control" EnableViewState="true" Font-Overline="False" Font-Size="Small" Height="30px" Style="width: 300px; text-transform: uppercase; display: inline-block; line-height: 0.8">
                                                    </asp:DropDownList>
                                                </div>
                                            </div>


                                        </div>

                                        <div class="row" style="background-color: ghostwhite;">
                                            <div class="col-lg-6">
                                                <div class="form-group">

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

                                            <label runat="server" id="lblBranchName" style="padding-left:20px;font-size:medium;color:greenyellow;"></label>

                                            <div class="col col-lg-12">

                                                  <div class="form-group">

                                                  

                                                    <asp:GridView ID="grdItems" runat="server" AutoGenerateColumns="False"
                                                    cellclassname="column" class="table table-striped table-hover"
                                                    OnRowCommand="grdItems_RowCommand" OnRowDeleting="grdItems_RowDeleting" OnRowCancelingEdit="grdItems_RowCancelingEdit"
                                                    OnRowEditing="grdItems_RowEditing" OnRowUpdating="grdItems_RowUpdating"
                                                    PagerStyle-CssClass="pgr" Style="font-size: x-small; text-align: center;" Width="1000px"
                                                    AllowSorting="True" OnRowUpdated="grdItems_RowUpdated" OnSorting="grdItems_Sorting"
                                                    OnDataBound="grdItems_DataBound" OnRowCreated="grdItems_RowCreated" OnRowDataBound="grdItems_RowDataBound">

                                                    <PagerStyle CssClass="pgr"></PagerStyle>
                                                    <RowStyle CssClass="gridrow" />
                                                    <RowStyle ForeColor="Black" />
                                                    <SelectedRowStyle BackColor="YellowGreen" ForeColor="Blue" Font-Bold="True" />
                                                    <Columns>
                                                        
                                                        <asp:BoundField DataField="pkInvID" Visible="false" />

                                                        <asp:TemplateField>  
                                                            <HeaderTemplate>                                                                  
                                                                <asp:CheckBox ID="ChkAll" AutoPostBack="true" OnCheckedChanged="ChkAll_CheckedChanged" runat="server" /> 
                                                            </HeaderTemplate>  
                                                            <ItemTemplate>  
                                                                <asp:CheckBox ID="ChkRow" runat="server" CommandArgument='<%# Eval("fkItemID") %>' CommandName="CheckMe"/> 
                                                            </ItemTemplate>  
                                                        </asp:TemplateField>

                                                        <asp:TemplateField HeaderText="S.No">
                                                            <ItemTemplate>
                                                                <%# Container.DataItemIndex + 1 %>
                                                            </ItemTemplate>
                                                            <ItemStyle Width="3%" />
                                                        </asp:TemplateField>

                                                        <asp:TemplateField HeaderText="ItemID" Visible="false">
                                                            <ItemTemplate>
                                                                <asp:Label ID="lblItemID" runat="server" Text='<%#Eval("fkItemID") %>' />
                                                            </ItemTemplate>
                                                            <ItemStyle HorizontalAlign="Left" VerticalAlign="Middle" Width="50px" />
                                                        </asp:TemplateField>

                                                        <asp:BoundField DataField="InvCode" HeaderText="InventoryCode" ItemStyle-Width="150px" ItemStyle-HorizontalAlign="Left" ItemStyle-VerticalAlign="Middle" />
                                                        <asp:BoundField DataField="ItemTitle" HeaderText="Item Name" ItemStyle-Width="500px" ItemStyle-HorizontalAlign="Left" ItemStyle-VerticalAlign="Middle" />


                                                        <asp:TemplateField HeaderText="Balance" Visible="True">
                                                            <ItemTemplate>
                                                                <asp:Label ID="lblcbalance" runat="server" Text='<%#Eval("CRBalance") %>' Font-Size="14px"/>
                                                            </ItemTemplate>
                                                            <ItemStyle HorizontalAlign="Center" VerticalAlign="Middle" Width="50px" />
                                                        </asp:TemplateField>


                                                        <asp:TemplateField HeaderText="Quantity">
                                                            <ItemTemplate>
                                                                                                                                                           
                                                                <asp:TextBox ID="txtqty" runat="server" AutoPostBack="false" autocomplete="off" CssClass="AlgRgh"  Text='<%#Eval("Qtty") %>' onclick="GridRowNo(<%# Container.DataItemIndex %>,this);" Width="50px" Font-Size="14px"></asp:TextBox>                                                               
                                                            </ItemTemplate>
                                                        </asp:TemplateField> 


                                                        <asp:TemplateField HeaderText="New Balace" Visible="true">
                                                            <ItemTemplate>
                                                                <asp:Label ID="lblnewbalance" runat="server" Text='' Font-Size="14px"/>
                                                            </ItemTemplate>
                                                            <ItemStyle HorizontalAlign="Left" VerticalAlign="Middle" Width="50px" />
                                                        </asp:TemplateField>

                                                         <asp:TemplateField HeaderText="Remarks">
                                                            <ItemTemplate>
                                                                <asp:TextBox ID="txtremarks" runat="server" AutoPostBack="false" autocomplete="off" Text='<%#Eval("Remarks") %>' Font-Size="SMALL" Height="30px"  Width="350px"></asp:TextBox>
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
                                                        <asp:Button ID="btnBack" runat="server" Text="Back" class="btn btn-info" CausesValidation="False" OnClick="btnBack_Click" />
                                                    </div>

                                                    <div style="float: right; margin: 5px;">
                                                        <asp:Button ID="btnReport" runat="server" Text="Print Items Balance Report" class="btn btn-warning" CausesValidation="False" OnClick="btnReport_Click" />
                                                    </div>
                                                </div>

                                            </div>
                                        </div>

                                        <!-- /.row (nested) -->

                                    </ContentTemplate>
                                </asp:UpdatePanel>

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
