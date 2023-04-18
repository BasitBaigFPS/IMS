<%@ Page Title="" Language="C#" MasterPageFile="~/Site1.Master" AutoEventWireup="true" CodeBehind="UpdateDocument.aspx.cs" Inherits="IMS.UpdateDocument" %>

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



    </script>


</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">

    <script type="text/javascript" src="http://ajax.googleapis.com/ajax/libs/jquery/1.9.1/jquery.min.js"></script>
    <script type="text/javascript">
        //ContentPlaceHolder1_grdItems_txtrate_0

        function ShowHideCancelRemarks() {
            var x = document.getElementById("canceldiv");
            if (x.style.display === "none") {
                x.style.display = "block";
            } else {
                x.style.display = "none";
            }
        }

        function Confirm(docref) {
            //This Function Work with ASP Button Not with RadControlButton.
            var choice = confirm("Are You Sure, You Want to Cancel Full '" + docref + "' ?", "Yes", "No");
            if (choice == false) {
                return false;
            }
            else
            {
                var choicecancel = document.getElementById('<%=checkCancel.ClientID%>');

                choicecancel.value = 'Cancel';
                ShowHideCancelRemarks();
            }
        }

        function CheckDocType(trtype) {
            var choicechk = document.getElementById('<%=chkchoise.ClientID%>');

            choicechk.value = trtype

            document.getElementById('<%=btnDocType.ClientID%>').click();

            ShowHideCancelRemarks();
        }


    </script>

    <div class="container">
        <div class="table-wrapper">
            <div class="table-title">
                <div class="row">
                    <div class="col-sm-12">
                        <h2>Document <b>Modification</b></h2>

                        <div class="panel panel-default">
                            <div class="panel-heading">
                                <h5>Modify/Update Documents</h5>
                            </div>
                            <div class="panel-body">

                                <asp:UpdatePanel ID="UpdatePanel1" runat="server">

                                    <ContentTemplate>

                                        <asp:Button ID="ShowMe" CssClass="btn btn-primary btn-lg" runat="server" Text="Request Spare" ClientIDMode="Static" data-toggle="modal" data-backdrop="static" data-target="#myModal" Style="display: none;" OnClientClick="return  false" />


                                        <div class="row" style="background-color: ghostwhite;">

                                            <div class="col-lg-12">

                                                <div class="form-group">
                                                    <label>Document Type</label>
                                                     <label class="radio-inline">
                                                        <input type="radio" name="optionsRadiosInline" id="optRecv" runat="server" value="GRN" onclick="CheckDocType('GRN')" />GRN (Goods Receive Note)
                                                    </label>
                                                    <label class="radio-inline">
                                                        <input type="radio" name="optionsRadiosInline" id="optIsu" runat="server" value="GIN" onclick="CheckDocType('GIN')" />GIN (Goods Issue Note)
                                                    </label>
                                                    <label class="radio-inline">
                                                        <input type="radio" name="optionsRadiosInline" id="optMir" runat="server" value="MIR" onclick="CheckDocType('MIR')" />MIR (Material Issue Request)
                                                    </label>
<%--                                                    <label class="radio-inline">
                                                        <input type="radio" name="optionsRadiosInline" id="optReq" runat="server" value="REQ" onclick="CheckDocType('REQ')" />REQ (Requisition)
                                                    </label>--%>
                                                    <asp:Button runat="server" ID="btnDocType" Text="" style="display:none;" OnClick="btnDocType_Click" />
                                                    <input type="text" runat="server" id="chkchoise" style="display:none;" />
                                                </div>

                                                <div class="form-group">


                                                </div>

                                            </div>
                                        </div>
                                        <div class="row" style="background-color: ghostwhite;">
                                            <div class="col-lg-6">

                                                <div class="form-group">
                                                    <label runat="server" id="lblbrhach">Select Branch:</label>
                                                    <asp:DropDownList ID="ddlbranch" runat="server" class="form-control" EnableViewState="true" AutoPostBack="true" Font-Overline="False" Font-Size="Small" Height="30px" OnSelectedIndexChanged="ddlbranch_SelectedIndexChanged" Style="width: 300px; text-transform: uppercase; display: inline-block; line-height: 0.8">
                                                    </asp:DropDownList>
                                                </div>
                                             </div>
                                             <div class="col-lg-6">

                                                <div class="form-group">
                                                    <label runat="server" id="lbldepart">Select Department:</label>
                                                    <asp:DropDownList ID="ddlDepartment" runat="server" class="form-control" EnableViewState="true" AutoPostBack="true" Font-Overline="False" Font-Size="Small" Height="30px" OnSelectedIndexChanged="ddlDepartment_SelectedIndexChanged" Style="width: 300px; text-transform: uppercase; display: inline-block; line-height: 0.8">
                                                    </asp:DropDownList>
                                                 </div>

                                            </div>

                                        </div>





                                        <div class="row">
                                            <div class="col-lg-12" style="background-color: burlywood;margin-bottom:10px;">
                                                <h5></h5>
                                            </div>
                                        </div>

                                        <div class="row" style="background-color: ghostwhite;">
                                            <div class="col-lg-4">
                                                <div class="form-group">
                                                     <label>Document ID:</label>
                                                      <input type="text" id="documentID" runat="server" class="form-control" style="width: 100px; display: inline-block; line-height: 0.8" />
                                                      <asp:Button ID="btnShowDocument" runat="server" Text="Show" class="btn btn-success" style="width: 100px; display: inline-block; line-height: 1.5" OnClick="btnShowDocument_Click" />
                                                 </div>

                                            </div>
                                            <div class="col col-lg-6">
                                                <div class="form-group">                                                    
                                                     <label for="documentID" id="lbldocumentref" runat="server" style="font-size:large;">Document Reference :</label>
                                                     <label for="documentDate" id="lbldocumentdate" runat="server" style="font-size:large;">Document Date :</label>
                                                </div>
                                            </div>

                                            <div class="col col-lg-2">
                                                <div class="form-group">
                                                   <asp:Button ID="btnCancel" runat="server" Text="Cancel" class="btn btn-warning" CausesValidation="False" OnClick="btnCancel_Click"/>
                                                    <input type="text" runat="server" id="checkCancel" style="display:none;" />
                                                </div>
                                            </div>
                                        </div>

                                        <div class="row" style="background-color: ghostwhite;">
                                            <div class="col-lg-1">
                                                <div class="form-group">
                                                    <div class="form-group">


                                                     </div>
                                                </div>
                                            </div>

                                            <div class="col col-lg-10">

                                                  <div class="form-group">

                                                  

                                                    <asp:GridView ID="grdItems" runat="server" AutoGenerateColumns="False"
                                                    cellclassname="column" class="table table-striped table-hover"
                                                    OnRowCommand="grdItems_RowCommand" OnRowDeleting="grdItems_RowDeleting" OnRowCancelingEdit="grdItems_RowCancelingEdit"
                                                    OnRowEditing="grdItems_RowEditing" OnRowUpdating="grdItems_RowUpdating"
                                                    PagerStyle-CssClass="pgr" Style="font-size: x-small; text-align: center;" Width="1800px"
                                                    AllowSorting="True" OnRowUpdated="grdItems_RowUpdated" OnSorting="grdItems_Sorting"
                                                    OnDataBound="grdItems_DataBound" OnRowCreated="grdItems_RowCreated" OnRowDataBound="grdItems_RowDataBound">

                                                    <PagerStyle CssClass="pgr"></PagerStyle>
                                                    <RowStyle CssClass="gridrow" />
                                                    <RowStyle ForeColor="Black" />
                                                    <SelectedRowStyle BackColor="YellowGreen" ForeColor="Blue" Font-Bold="True" />
                                                    <Columns>
                                                        

                                                         <asp:BoundField DataField="pkDocID" Visible="false" />

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
                                                            <ItemStyle Width="2%" />
                                                        </asp:TemplateField>


                                                       

                                                        <asp:TemplateField HeaderText="ItemID" Visible="false">
                                                            <ItemTemplate>
                                                                <asp:Label ID="lblItemID" runat="server" Text='<%#Eval("fkItemID") %>' />
                                                            </ItemTemplate>
                                                            <ItemStyle HorizontalAlign="Left" VerticalAlign="Middle" Width="50px" />
                                                        </asp:TemplateField>

                                                        <asp:BoundField DataField="InvCode" HeaderText="InventoryCode" ItemStyle-Width="150px" ItemStyle-HorizontalAlign="Left" ItemStyle-VerticalAlign="Middle" />
                                                        <asp:BoundField DataField="ItemTitle" HeaderText="Item Name" ItemStyle-Width="500px" ItemStyle-HorizontalAlign="Left" ItemStyle-VerticalAlign="Middle" />

                                                        <asp:TemplateField HeaderText="Quantity">
                                                            <ItemTemplate>
                                                                <asp:TextBox ID="txtqty" runat="server" AutoPostBack="True" ItemStyle-HorizontalAlign="Center" OnTextChanged="txtqty_TextChanged" Text='<%#Eval("Qtty") %>' Width="50px">                                                                                                                                                               
                                                                </asp:TextBox>
                                                            </ItemTemplate>
                                                        </asp:TemplateField> 

                                                         <asp:CommandField ShowEditButton="True" />

                                                        <asp:TemplateField HeaderText="">
                                                            <ItemTemplate>
                                                                <asp:LinkButton ID="btnCancelTrans" runat="server" CommandArgument='<%# Eval("fkItemID") %>' CommandName="Cancel" Text="Cancel" />
                                                            </ItemTemplate>
                                                        </asp:TemplateField>

                                                        <asp:CommandField ShowDeleteButton="true" Visible="true" />


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

                                            <div class="col col-lg-1">
                                                <div class="form-group">
                                                </div>
                                            </div>

                                        </div>

                                        <div class="row" style="background-color: ghostwhite;">
                                            <div class="col-lg-12">

                                                <div class="form-group" runat="server">

                                                    <label id="cremark" runat="server">Cancel Remarks:</label>
                                                    <input type="text" id="CancelRemarks" runat="server" class="form-control" style="width: 700px; display: inline-block; line-height: 0.8" />

                                                </div>

                                                <div class="form-group">
                                                    <label id="uremark" runat="server">Update Remarks:</label>
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
