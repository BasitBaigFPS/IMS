<%@ Page Title="" Language="C#" MasterPageFile="~/Site1.Master" AutoEventWireup="true" CodeBehind="IssueQuickItemsNew.aspx.cs" Inherits="IMS.IssueQuickItemsNew" %>

<%@ Register Assembly="AjaxControlToolkit" Namespace="AjaxControlToolkit" TagPrefix="asp" %>
<%@ Register Assembly="Telerik.Web.UI" Namespace="Telerik.Web.UI" TagPrefix="telerik" %>



<asp:Content ID="Content1" ContentPlaceHolderID="HeadContent" runat="server">

    <script type="text/javascript">

        function checkBackKey() {
            // Check for backSpace key    
            if (window.event.keyCode == 8) {
                return false; //aviod postback  
            }
        }

        function ConfirmSave() {
            //This Function Work with ASP Button Not with RadControlButton.
            var choice = confirm("Are You Sure, You Want to Save New GIN ?", "Yes", "No");
            if (choice == false) {
                return false;
            }
            else {
                var btnsave = document.getElementById('<%=btnSubmit.ClientID%>');

                alert(btnsave.innerText);

                //btnsave.innerText = "Confirm";
            }
        }

        function EmployeeClick() 
        {
            var lit = document.getElementById("ItemsClientSide");            

            var e = document.getElementById("ddlEmployees");
            lit.innerHTML = e.options[e.selectedIndex].value;

        }

    </script>

    <style type="text/css">

            .Grid {background-color: #fff; margin: 5px 0 10px 0; border: solid 1px #525252; border-collapse:collapse; font-family:Calibri; color: #474747;}

            .Grid td {

                  padding: 2px;

                  border: solid 1px #c1c1c1; }

            .Grid th  {

                  padding : 4px 2px;

                  color: #fff;

                  background: #363670 url(Images/grid-header.png) repeat-x top;

                  border-left: solid 1px #525252;

                  font-size: 1.5em; }

            .Grid .alt {

                  background: #fcfcfc url(Images/grid-alt.png) repeat-x top; }

            .Grid .pgr {background: #363670 url(Images/grid-pgr.png) repeat-x top; }

            .Grid .pgr table { margin: 3px 0; }

            .Grid .pgr td { border-width: 0; padding: 0 6px; border-left: solid 1px #666; font-weight: bold;  color: #fff; line-height: 12px; }  

            .Grid .pgr a { color: Gray; text-decoration: none; }

            .Grid .pgr a:hover { color: #000; text-decoration: none; }



    </style>


</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">

    <script type="text/javascript" src="http://ajax.googleapis.com/ajax/libs/jquery/1.9.1/jquery.min.js"></script>
    <script type="text/javascript">
        //ContentPlaceHolder1_grdItems_txtrate_0



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

        function RecallCalculation(v) {
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

 
            TotalPriceValue = parseFloat(CurrentBal - QuntVar);
           

            if (parseFloat(TotalPriceValue) < 0) {

                alert("Insufficient Balance");

                var qttychk = "ContentPlaceHolder1_grdItems_txtqty_" + i;

                if (parseFloat(CurrentBal) == 0) {

                    document.getElementById(qttychk).value = parseFloat("0");
                }
                else {
                    document.getElementById(qttychk).value = parseFloat(CurrentBal);
                }


                return false;
            }
            else {
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
 
        function CheckTrnsType(trtype) {
        
            if (trtype == "BULK")
            {
                document.getElementById('<%=btnShowItems.ClientID %>').style.display = 'none';
            }
            var choicechk = document.getElementById('<%=chkchoise.ClientID%>');

            choicechk.value = trtype

            document.getElementById('<%=btnTrnType.ClientID%>').click();
        }


    </script>

    <div class="container">
        <div class="table-wrapper">
            <div class="table-title">
                <div class="row">
                    <div class="col-sm-12">
                        <h2>GIN <b>(Goods Issue Note)</b></h2>

                        <div class="panel panel-default">
                            <div class="panel-heading">
                                <h5>Issue Items Internal</h5>
                            </div>

                            <div class="panel-body">

                                <asp:UpdatePanel ID="UpdatePanel1" runat="server">

                                    <ContentTemplate>

                                        <asp:Button ID="ShowMe" CssClass="btn btn-primary btn-lg" runat="server" Text="Request Spare" ClientIDMode="Static" data-toggle="modal" data-backdrop="static" data-target="#myModal" Style="display: none;" OnClientClick="return  false" />

                                         <div class="row" style="background-color: ghostwhite;">
                                            <div class="col-lg-6">
                                                <div class="form-group">
                                                    <div class="form-group">
                                                        
                                                    <label runat="server" id="ToFromLabel">Issuance Type:</label>
                                                    <label class="radio-inline">
                                                        <input type="radio" name="optionsRadiosInline" id="chkbulk" runat="server" onclick="CheckTrnsType('BULK');" />
                                                        <label for="chkvnd" id="lblBulk" runat="server">Group Issuance</label>
                                                    </label>
                                                    <label class="radio-inline">
                                                        <input type="radio" name="optionsRadiosInline" id="chkSingle" runat="server" onclick="CheckTrnsType('INDV');"/>
                                                        <label for="chkbranch" id="lblSingle" runat="server">Individual Issuance</label>
                                                    </label>
                                                    <input type="text" runat="server" id="chkchoise" style="display:none;" />
                                                    <asp:Button runat="server" ID="btnTrnType" Text="" style="display:none;" OnClick="btnTrnType_Click" /> 
                                                        

                                                     </div>
                                                </div>
                                            </div>

                                        </div>

                                        <div class="row" style="background-color: ghostwhite;">
                                            <div class="col-lg-4">
                                                <div class="form-group">
                                                     <label>Document ID:</label>
                                                      <input type="text" id="documentID" runat="server" class="form-control" style="width: 100px; display: inline-block; line-height: 0.8" />
                                                      <asp:Button ID="btnShowItems" runat="server" Text="New GIN" class="btn btn-success" style="width: 100px; display: inline-block; line-height: 1.5" OnClick="btnShowItems_Click"/>
                                                 </div>

                                            </div>
                                            <div class="col col-lg-6">
                                                <div class="form-group">                                                    
                                                     <label for="documentID" id="lbldocumentref" runat="server" style="font-size:large;">Document Reference :</label>
                                  
                                                </div>
                                            </div>

                                            <div class="col col-lg-2">
                                                <div class="form-group">
                                                    <a href="ReportsMain.aspx?rptname=GoodsIssueNote&amp;gino=<%= documentID.Value %>" target="_blank"><span class="auto-style29">Print GIN</span></a>
                                                <%--   <asp:Button ID="btnPrint" runat="server" Text="Print" class="btn btn-warning" CausesValidation="False" OnClick="btnPrint_Click"/>--%>
                                                  <input type="text" id="chkTrnType" runat="server" value="ISU" style="display:none;" />
                                                </div>
                                            </div>
                                        </div>

                                        <div class="row">
                                            <div class="col-lg-12" style="background-color: burlywood;margin-bottom:10px;">
                                                <h5></h5>
                                            </div>
                                        </div>

                                        <div class="row" style="background-color: ghostwhite;">
                                          
                                            <div class="col col-lg-6">
                                                <div class="form-group">
                                                        <label for="ddlPersonto" id="lblPersonlist" runat="server" visible="false">Select Employees</label>
                                                       <telerik:RadComboBox ID="ddlEmployees" runat="server" class="form-control" RenderMode="Lightweight" Filter="Contains"  AllowCustomText="true" AutoPostBack="False" MarkFirstMatch="True" Sort="Ascending"  Visible="false" CheckBoxes="true" EnableCheckAllItemsCheckBox="true" EmptyMessage="Select Employee" Width="300px"  OnItemChecked="ddlEmployees_ItemChecked"></telerik:RadComboBox>   
                                              
                                                        <asp:Button ID="btnShowEmpList" runat="server" Text="Show List" class="btn btn-success" EnableViewState="False" Visible="false" style=" display: inline-block;" OnClick="btnShowEmpList_Click" />

                                                        <asp:Literal ID="ItemsClientSide" runat="server"></asp:Literal>
                                                        <asp:Label ID="lblemployees" runat="server" Text="Items List" Visible="False"></asp:Label>
                                                        <asp:Label ID="lblEmpID" runat="server" Text="ItemID" Visible="False"></asp:Label>   
                                                    
                                                 </div>
                                            </div>
                                            <div class="col col-lg-6">
                                                <div class="form-group">
                                               
                                                 </div>
                                            </div>

                                        </div>

                                        <div class="row" style="background-color: ghostwhite;">
 
                                            <div class="col col-lg-12">

                                                  <div class="form-group">
                                                                                                                                                                                                              
                                                    <asp:GridView ID="grdItems" runat="server" AutoGenerateColumns="False"
                                                    cellclassname="column" class="table table-striped table-hover" CssClass="Grid"  
                                                    OnRowCommand="grdItems_RowCommand" OnRowDeleting="grdItems_RowDeleting" OnRowCancelingEdit="grdItems_RowCancelingEdit"
                                                    OnRowEditing="grdItems_RowEditing" OnRowUpdating="grdItems_RowUpdating"
                                                    PagerStyle-CssClass="pgr" Style="font-size: x-small; text-align: center;" Width="1000px"
                                                    AllowSorting="True" OnRowUpdated="grdItems_RowUpdated" OnSorting="grdItems_Sorting"
                                                     OnRowCreated="grdItems_RowCreated" OnRowDataBound="grdItems_RowDataBound">

                                                    <PagerStyle CssClass="pgr"></PagerStyle>
                                                    <RowStyle CssClass="gridrow" />
                                                    <RowStyle ForeColor="Black" />
                                                    <SelectedRowStyle BackColor="YellowGreen" ForeColor="Blue" Font-Bold="True" />
                                                    <Columns>
                                                        
                                                        <asp:BoundField DataField="pkInvID" Visible="false" />

                                                        <asp:TemplateField Visible="false">  
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
                                                            <ItemStyle Width="3%" Font-Size="Large" />
                                                        </asp:TemplateField>

                                                        <asp:TemplateField HeaderText="ItemID" Visible="false">
                                                            <ItemTemplate>
                                                                <asp:Label ID="lblItemID" runat="server" Text='<%#Eval("fkItemID") %>' />
                                                            </ItemTemplate>
                                                            <ItemStyle HorizontalAlign="Left" VerticalAlign="Middle"/>
                                                        </asp:TemplateField>

                                                        <asp:BoundField DataField="ItemName" HeaderText="Item Name"  ItemStyle-HorizontalAlign="Left" ItemStyle-VerticalAlign="Middle"  ItemStyle-Font-Size="Large"/>


                                                        <asp:TemplateField HeaderText="Balance" Visible="True">
                                                            <ItemTemplate>
                                                                <asp:Label ID="lblcbalance" runat="server" Text='<%#Eval("CurrentBalance") %>' Font-Size="14px" Width="30px"/>
                                                            </ItemTemplate>
                                                            <ItemStyle HorizontalAlign="Center" VerticalAlign="Middle" />
                                                        </asp:TemplateField>


                                                        <asp:TemplateField HeaderText="Quantity">
                                                            <ItemTemplate>
                                                                                                                                                           
                                                                <asp:TextBox ID="txtqty" runat="server" AutoPostBack="false" autocomplete="off" CssClass="AlgRgh"  Text='<%#Eval("Qtty") %>' onclick="GridRowNo(<%# Container.DataItemIndex %>,this);" Width="50px" Font-Size="14px"></asp:TextBox>                                                               
                                                            </ItemTemplate>
                                                        </asp:TemplateField> 


                                                        <asp:TemplateField HeaderText="New Balance" Visible="true">
                                                            <ItemTemplate>
                                                                <asp:Label ID="lblnewbalance" runat="server" Text='<%# Eval("NewBal")%>' Font-Size="14px" Width="30px"/>
                                                            </ItemTemplate>
                                                            <ItemStyle HorizontalAlign="Center" VerticalAlign="Middle" />
                                                        </asp:TemplateField>

                                                    <asp:TemplateField HeaderText="Issued-To">
                                                            <ItemTemplate>
                                                                <asp:Label ID="lblPerson" runat="server" Text='<%# Eval("empName")%>'></asp:Label>
                                                                <asp:Label ID="lblIssuedToID" runat="server" style="display:none;" Text='<%# Eval("IsuToID")%>'></asp:Label>

                                                                <telerik:RadComboBox ID="ddlPersonto" runat="server" class="form-control" RenderMode="Lightweight" Filter="Contains" AllowCustomText="true" AutoPostBack="False" MarkFirstMatch="True" Sort="Ascending"   CheckBoxes="true" EnableCheckAllItemsCheckBox="true" EmptyMessage="Select Employee"  OnItemChecked="ddlPersonto_ItemChecked" ></telerik:RadComboBox>                                                                                                                                                           
                                                            </ItemTemplate>
                                                        </asp:TemplateField> 


<%--                                                         <asp:TemplateField HeaderText="Issued-To">
                                                            <ItemTemplate>
                                                                <asp:Label ID="lblPerson" runat="server" Text='<%# Eval("empName")%>'></asp:Label>
                                                            </ItemTemplate>
                                                            <ItemTemplate>
                                                                <asp:DropDownList ID="ddlPersonto" runat="server" AutoPostBack="true">
                                                                    <asp:ListItem Value="-1">Select</asp:ListItem>
                                                                </asp:DropDownList>
                                                            </ItemTemplate>
                                                        </asp:TemplateField>--%>


                                                         <asp:TemplateField HeaderText="Remarks">
                                                            <ItemTemplate>
                                                                <asp:TextBox ID="txtremarks" runat="server" AutoPostBack="false" autocomplete="off" Text='<%#Eval("Remarks") %>' Font-Size="10pt" Height="30px" Width="250px"></asp:TextBox>
                                                            </ItemTemplate>
                                                            <ItemStyle HorizontalAlign="Right" VerticalAlign="Middle" />
                                                        </asp:TemplateField>

                                                   <%--      <asp:CommandField ShowEditButton="True" />--%>

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
                                            <div class="col-lg-12">

                                                <div class="form-group">
                                                    <label id="uremark" runat="server">Remarks:</label>
                                                    <input type="text" id="UpdateRemarks" runat="server" class="form-control" style="width: 700px; display: inline-block; line-height: 0.8;" />
                                                </div>

                                            </div>


                                            <div class="col col-lg-4" style="width: 221px; margin-left: 50px;">
                                                <div class="form-group" style="margin-top: 60px;">

                                               </div>
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
                                                        <asp:Button ID="btnRevert" runat="server" Text="Revert" class="btn btn-success" EnableViewState="False" OnClick="btnRevert_Click" />
                                                    </div>

                                                    <div style="float: left; margin: 5px;">
                                                        <asp:Button ID="btnBack" runat="server" Text="Back" class="btn btn-info" CausesValidation="False" OnClick="btnBack_Click" />
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
