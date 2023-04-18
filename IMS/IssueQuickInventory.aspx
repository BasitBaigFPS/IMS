<%@ Page Title="" Language="C#" MasterPageFile="~/Site1.Master" AutoEventWireup="true" CodeBehind="IssueQuickInventory.aspx.cs" Inherits="IMS.IssueQuickInventory" %>

<%@ Register Assembly="AjaxControlToolkit" Namespace="AjaxControlToolkit" TagPrefix="asp" %>

<asp:Content ID="Content1" ContentPlaceHolderID="HeadContent" runat="server">
    <style type="text/css">
        .clearfix {
            width: 230px;
        }
    </style>
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="MainContent" runat="server">

<script type="text/javascript">


    function CheckQuantity(e, rowindex, qtyID, Bal) {

        var i = parseInt(rowindex);

        var QuntVar = parseFloat(document.getElementById(qtyID).value != "" ? document.getElementById(qtyID).value : "0");

        var str = document.getElementById(qtyID) + i;

        var CellValue = document.getElementById(qtyID);

        // alert("Text Quantity ID." + str);

        if (QuntVar > Bal) {

            alert("Please Enter Less/Valid Quantity...");

            //document.getElementById(qtty).innerHTML = parseFloat("0");

            //CellValue.innerHTML = parseFloat("0");

            //QuntVar.innerHTML = parseFloat("0");

            // e.preventDefault();
            return false;
        }



    }


</script>

        <!--inner block start here-->

<%--<div class="signup-page-main">
     <div class="signup-main"> --%> 	
    	 <div class="signup-head">
				<span><img alt=""  src="images/inv_isu.png" /></span>
                <h1>Issue Inventory</h1>
			</div>
	<%--		<div class="signup-block">--%>
                 
                  <table style="width:100%;">
                        <tr>
                            <td>&nbsp;</td>
                            <td>&nbsp;</td>
                            <td>&nbsp;</td>
                        </tr>
                        <tr>
                            <td colspan="3"> </td></td>
                        </tr>
                        <tr>
                            <td>&nbsp;</td>
                            <td>&nbsp;</td>
                            <td>&nbsp;</td>
                        </tr>
                        <tr>
      <%--                         <asp:UpdatePanel ID="UpdatePanel1" runat="server" UpdateMode="Conditional" ChildrenAsTriggers="false">
                            <ContentTemplate>--%>

                                <td   colspan="5">
                                    <telerik:RadAjaxPanel ID="RadAjaxPanel2" runat="server" Width="950px" HorizontalAlign="NotSet" LoadingPanelID="RadAjaxLoadingPanel2" RenderMode="Inline">
                                        <table  >
                                            <tr>
                                                <td colspan="4">
                                                    <asp:Panel ID="Panel1" runat="server">
                                                        <table >
                                                            <tr>
                                                                <td  >&nbsp;</td>
                                                                <td   colspan="3">Issuing Type</td>
                                                                <td   colspan="2">
                                                                    <telerik:RadComboBox ID="cmbIssueType" runat="server" AutoPostBack="True" MarkFirstMatch="True" OnSelectedIndexChanged="cmbIssueType_SelectedIndexChanged" Sort="Ascending" Width="300px" BorderStyle="Solid">
                                                                        <Items>
                                                                            <telerik:RadComboBoxItem runat="server" Selected="True" Text="Choose Type" Value="Choose Type" />
                                                                            <telerik:RadComboBoxItem runat="server" Text="Internal Issue" Value="I" />
                                                                            <telerik:RadComboBoxItem runat="server" Text="External Issue" Value="E" />
                                                                        </Items>
                                                                    </telerik:RadComboBox>
                                                                </td>
                                                                <td>
                                                                    <asp:RequiredFieldValidator ID="RequiredFieldValidator10" runat="server" ControlToValidate="cmbIssueType" ErrorMessage="*" ForeColor="Red" InitialValue="Choose Type" ValidationGroup="A"></asp:RequiredFieldValidator>
                                                                </td>
                                                                <td colspan="2" >&nbsp;</td>
                                                                <td   colspan="2">&nbsp;</td>
                                                                <td colspan="2">&nbsp;</td>
                                                            </tr>
                                                            <tr>
                                                                <td  >&nbsp;</td>
                                                                <td   colspan="3">&nbsp;</td>
                                                                <td style="font-weight: 700" colspan="2">&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp; <span class="auto-style92">I s s u e d </span></td>
                                                                <td>&nbsp;</td>
                                                                <td colspan="2"  >&nbsp;</td>
                                                                <td colspan="2">&nbsp;&nbsp;&nbsp;&nbsp;&nbsp; &nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp; <span class="auto-style92"><strong>&nbsp;R e c e i v e d</strong></span></td>
                                                                <td colspan="2">&nbsp;</td>
                                                            </tr>
                                                            <tr>
                                                                <td  >&nbsp;</td>
                                                                <td   colspan="3">Select System</td>
                                                                <td   colspan="2">

                                                                    <telerik:RadComboBox ID="cmbSystem" runat="server" AutoPostBack="True" MarkFirstMatch="True" OnSelectedIndexChanged="cmbSystem_SelectedIndexChanged" Sort="Ascending" Width="300px">
                                                                    </telerik:RadComboBox>

                                                                </td>
                                                                <td>&nbsp;</td>
                                                                <td colspan="2"  >&nbsp;</td>
                                                                <td   colspan="2">&nbsp;</td>
                                                                <td colspan="2">&nbsp;</td>
                                                            </tr>
                                                            <tr>
                                                                <td  >&nbsp;</td>
                                                                <td   colspan="3">Issued from Branch</td>
                                                                <td   colspan="2">
                                                                    <telerik:RadComboBox ID="cmbbranchfrom" runat="server" AutoPostBack="True" MarkFirstMatch="True" OnSelectedIndexChanged="cmbbranchfrom_SelectedIndexChanged" Sort="Ascending" Width="300px">
                                                                    </telerik:RadComboBox>
                                                                </td>
                                                                <td>
                                                                    <asp:RequiredFieldValidator ID="RequiredFieldValidator1" runat="server" ControlToValidate="cmbbranchfrom" ErrorMessage="*" ForeColor="Red" InitialValue="Choose Branch" ValidationGroup="A"></asp:RequiredFieldValidator>
                                                                </td>
                                                                <td colspan="2"  >Issued to Branch</td>
                                                                <td   colspan="2">
                                                                    <telerik:RadComboBox ID="cmbBranchto" runat="server" AutoPostBack="True" MarkFirstMatch="True" OnSelectedIndexChanged="cmbBranchto_SelectedIndexChanged" Sort="Ascending" Width="300px">
                                                                    </telerik:RadComboBox>
                                                                </td>
                                                                <td colspan="2">
                                                                    <asp:RequiredFieldValidator ID="RequiredFieldValidator3" runat="server" ControlToValidate="cmbBranchto" ErrorMessage="*" ForeColor="Red" InitialValue="Choose Branch" ValidationGroup="A"></asp:RequiredFieldValidator>
                                                                </td>
                                                            </tr>
                                                            <tr>
                                                                <td  >&nbsp;</td>
                                                                <td   colspan="3">Issued from&nbsp; Store</td>
                                                                <td   colspan="2">
                                                                    <telerik:RadComboBox ID="cmbstorefrom" runat="server" AutoPostBack="True" MarkFirstMatch="True" Sort="Ascending" Width="300px" OnSelectedIndexChanged="cmbstorefrom_SelectedIndexChanged">
                                                                    </telerik:RadComboBox>
                                                                </td>
                                                                <td>
                                                                    <asp:RequiredFieldValidator ID="RequiredFieldValidator2" runat="server" ControlToValidate="cmbstorefrom" ErrorMessage="*" ForeColor="Red" InitialValue="Choose Store" ValidationGroup="A"></asp:RequiredFieldValidator>
                                                                </td>
                                                                <td colspan="2"  >Issued to Store</td>
                                                                <td   colspan="2">
                                                                    <telerik:RadComboBox ID="cmbStoreto" runat="server" AutoPostBack="True" MarkFirstMatch="True" Sort="Ascending" Width="300px">
                                                                    </telerik:RadComboBox>
                                                                </td>
                                                                <td colspan="2">
                                                                    <asp:RequiredFieldValidator ID="RequiredFieldValidator4" runat="server" ControlToValidate="cmbStoreto" ErrorMessage="*" ForeColor="Red" InitialValue="Choose Store" ValidationGroup="A"></asp:RequiredFieldValidator>
                                                                </td>
                                                            </tr>
                                                            <tr>
                                                                <td  >&nbsp;</td>
                                                                <td   colspan="3">Issued Department</td>
                                                                <td   colspan="2">
                                                                    <telerik:RadComboBox ID="cmbDepartmentfrom" runat="server" AutoPostBack="True" MarkFirstMatch="True" Sort="Ascending" Width="300px" OnSelectedIndexChanged="cmbDepartmentfrom_SelectedIndexChanged">
                                                                    </telerik:RadComboBox>
                                                                </td>
                                                                <td  >&nbsp;</td>
                                                                <td   colspan="2">&nbsp;Department</td>
                                                                <td   colspan="2">
                                                                    <telerik:RadComboBox ID="cmbDepartmentto" runat="server" AutoPostBack="True" MarkFirstMatch="True" Sort="Ascending" Width="300px" OnSelectedIndexChanged="cmbDepartmentto_SelectedIndexChanged">
                                                                    </telerik:RadComboBox>
                                                                </td>
                                                                <td   colspan="2">
                                                                    <asp:RequiredFieldValidator ID="RequiredFieldValidator5" runat="server" ControlToValidate="cmbDepartmentto" ErrorMessage="*" ForeColor="Red" InitialValue="Choose Department" ValidationGroup="A"></asp:RequiredFieldValidator>
                                                                </td>
                                                            </tr>
                                                            <tr>
                                                                <td  >&nbsp;</td>
                                                                <td   colspan="3">Issued By</td>
                                                                <td   colspan="2">
                                                                    <telerik:RadComboBox ID="cmbIssuedby" runat="server" AutoPostBack="True" MarkFirstMatch="True" Sort="Ascending" Width="300px" OnSelectedIndexChanged="cmbIssuedby_SelectedIndexChanged">
                                                                    </telerik:RadComboBox>
                                                                </td>
                                                                <td>&nbsp;</td>
                                                                <td colspan="2"  >Issued to Person</td>
                                                                <td   colspan="2">
                                                                    <telerik:RadComboBox ID="cmbPersonto" runat="server" AutoPostBack="True" MarkFirstMatch="True" Sort="Ascending" Width="300px" OnSelectedIndexChanged="cmbPersonto_SelectedIndexChanged">
                                                                    </telerik:RadComboBox>
                                                                </td>
                                                                <td colspan="2">
                                                                    <asp:RequiredFieldValidator ID="RequiredFieldValidator11" runat="server" ControlToValidate="cmbPersonto" ErrorMessage="*" ForeColor="Red" InitialValue="Choose Department" ValidationGroup="A"></asp:RequiredFieldValidator>
                                                                </td>
                                                            </tr>
                                                            <tr>
                                                                <td  >&nbsp;</td>
                                                                <td   colspan="3">Issuing Status</td>
                                                                <td   colspan="2">
                                                                    <telerik:RadComboBox ID="cmbIssueStatus" runat="server" AutoPostBack="True" MarkFirstMatch="True" OnSelectedIndexChanged="cmbIssueStatus_SelectedIndexChanged" Sort="Ascending" Width="300px">
                                                                        <Items>
                                                                            <telerik:RadComboBoxItem runat="server" Selected="True" Text="Choose Status" Value="Choose Status" />
                                                                            <telerik:RadComboBoxItem runat="server" Text="Permenant Issue" Value="P" />
                                                                            <telerik:RadComboBoxItem runat="server" Text="Temporary Issue" Value="T" />
                                                                        </Items>
                                                                    </telerik:RadComboBox>
                                                                </td>
                                                                <td>
                                                                    <asp:RequiredFieldValidator ID="RequiredFieldValidator7" runat="server" ControlToValidate="cmbIssueType" ErrorMessage="*" ForeColor="Red" InitialValue="Choose Type" ValidationGroup="A"></asp:RequiredFieldValidator>
                                                                    <telerik:RadButton ID="btnPrint" runat="server" ButtonType="SkinnedButton" Font-Size="10pt" Height="22px" OnClick="btnPrint_Click" Style="text-align: center" TabIndex="8" Text="PrintGIN" ValidationGroup="A" Visible="False" Width="40px">
                                                                    </telerik:RadButton>
                                                                </td>
                                                                <td colspan="2"  >&nbsp;</td>
                                                                <td   colspan="2">
                                                                    <telerik:RadButton ID="btnPrintGatePass" runat="server" ButtonType="SkinnedButton" Font-Size="10pt" Height="30px" OnClick="btnPrintGatePass_Click" Style="text-align: center" TabIndex="8" Text="PrintGP" ValidationGroup="A" Visible="False" Width="44px">
                                                                    </telerik:RadButton>
                                                                </td>
                                                                <td colspan="2">&nbsp;</td>
                                                            </tr>
                                                            <tr>
                                                                <td  >&nbsp;</td>
                                                                <td   colspan="3">&nbsp;</td>
                                                                <td colspan="2"  >&nbsp;</td>
                                                                <td  >&nbsp;</td>
                                                                <td   colspan="2">Transfer To</td>
                                                                <td colspan="2">
                                                                    <telerik:RadComboBox ID="cmbSystemTo" runat="server" AutoPostBack="True" MarkFirstMatch="True" OnSelectedIndexChanged="cmbSystemTo_SelectedIndexChanged" Sort="Ascending" Visible="False" Width="300px">
                                                                    </telerik:RadComboBox>
                                                                </td>
                                                                <td   colspan="2">&nbsp;</td>
                                                            </tr>


                                                            <tr>

                                                                <asp:UpdatePanel ID="UpdatePanel2" runat="server" UpdateMode="Conditional" ChildrenAsTriggers="false">
                                                                    <ContentTemplate>

                                                                        <td  ></td>
                                                                        <td   colspan="3">Search Item</td>
                                                                        <td   colspan="2">
       
                                                           

   <telerik:RadComboBox RenderMode="Lightweight" ID="cmbItemSearch" AllowCustomText="true" runat="server" OnSelectedIndexChanged="cmbItemSearch_SelectedIndexChanged" Width="350" Height="400px" filter="Contains"
                        AutoPostBack="True" MarkFirstMatch="True" Sort="Ascending"  CheckBoxes="true" EnableCheckAllItemsCheckBox="true" EmptyMessage="Search for items...">
                    </telerik:RadComboBox>



                                                                        </td>
                                                                         <td>&nbsp;

                                                                         <asp:Literal ID="ItemsClientSide" runat="server"></asp:Literal>
                                                                            <asp:Label ID="lblItems" runat="server" Text="Items List" Visible="False"></asp:Label>
                                                                            <asp:Label ID="lblItemID" runat="server" Text="ItemID" Visible="False"></asp:Label>


                                                                        </td>
                                                                        <td>&nbsp;</td>

                                                                    </ContentTemplate>
                                                                </asp:UpdatePanel>

                                                            </tr>

                                                                <tr style="visibility: hidden">
                                                                <td  >&nbsp;</td>
                                                                <td   colspan="3" style="visibility: hidden">Category</td>
                                                                <td colspan="2"   style="visibility: hidden">
                                                                    <telerik:RadComboBox ID="cmbCatagories" runat="server" AutoPostBack="True" OnSelectedIndexChanged="cmbCatagories_SelectedIndexChanged" Sort="Ascending" Width="300px" Visible="False">
                                                                    </telerik:RadComboBox>
                                                                </td>
                                                                <td   style="visibility: hidden">&nbsp;</td>
                                                                <td   colspan="2" style="visibility: hidden">&nbsp;</td>
                                                                <td colspan="2" style="visibility: hidden">&nbsp;</td>
                                                                <td   colspan="2">&nbsp;</td>
                                                            </tr>




                                                            <tr style="visibility: hidden">
                                                                <td  >&nbsp;</td>
                                                                <td   colspan="3" style="visibility: hidden">Sub. Category</td>
                                                                <td colspan="2" style="visibility: hidden">
                                                                    <telerik:RadComboBox ID="cmbSubCategory" runat="server" AutoPostBack="True" MarkFirstMatch="True" OnSelectedIndexChanged="cmbSubCategory_SelectedIndexChanged" Sort="Ascending" TabIndex="10" Width="300px" Visible="False">
                                                                    </telerik:RadComboBox>
                                                                </td>
                                                                <td   style="visibility: hidden">&nbsp;</td>
                                                                <td   colspan="2" style="visibility: hidden">&nbsp;</td>
                                                                <td   colspan="2" style="visibility: hidden">&nbsp;</td>
                                                                <td   colspan="2">&nbsp;</td>
                                                            </tr>
                                                            <tr style="visibility: hidden">
                                                                <td  >&nbsp;</td>
                                                                <td   colspan="3" style="visibility: hidden">Item Head</td>
                                                                <td colspan="2" style="visibility: hidden">
                                                                    <telerik:RadComboBox ID="cmbItemHead" runat="server" AutoPostBack="True" MarkFirstMatch="True" MaxHeight="150px" Sort="Ascending" Width="300px" OnSelectedIndexChanged="cmbItemHead_SelectedIndexChanged" TabIndex="11" Visible="False">
                                                                    </telerik:RadComboBox>
                                                                </td>
                                                                <td   style="visibility: hidden">&nbsp;</td>
                                                                <td   colspan="2" style="visibility: hidden">&nbsp;</td>
                                                                <td   colspan="2" style="visibility: hidden">&nbsp;</td>
                                                                <td   colspan="2">&nbsp;</td>
                                                            </tr>

                                                        
                                                          
                                                            <tr>
                                                                <td   style="visibility: hidden">&nbsp;</td>
                                                                <td   style="visibility: hidden" colspan="3">Item Name</td>
                                                                <td colspan="2" style="visibility: hidden">
                                                                    <telerik:RadComboBox ID="cmbItem" runat="server" AutoPostBack="True" MarkFirstMatch="True" MaxHeight="200px" Sort="Ascending" Width="300px">
                                                                    </telerik:RadComboBox>
                                                                </td>
                                                                <td   style="visibility: hidden">
                                                                    <asp:RequiredFieldValidator ID="RequiredFieldValidator6" runat="server" ControlToValidate="cmbItem" ErrorMessage="*" ForeColor="Red" InitialValue="Choose Item" ValidationGroup="A"></asp:RequiredFieldValidator>
                                                                </td>
                                                                <td colspan="2"   style="visibility: hidden">
                                                                    <telerik:RadButton ID="btnSubmit" runat="server" ButtonType="SkinnedButton" Font-Size="10pt" Height="30px" OnClick="btnSubmit_Click" Style="text-align: center" Text="Add Item" ValidationGroup="A" Visible="False" Width="65px">
                                                                    </telerik:RadButton>
                                                                </td>
                                                                <td   colspan="2" style="visibility: hidden"></td>
                                                                <td colspan="2"   style="visibility: hidden"></td>
                                                            </tr>
                                                            <tr>
                                                                <td  >&nbsp;</td>
                                                                <td   colspan="3">Acknowledgment Time</td>
                                                                <td   colspan="2">
                                                                    <asp:TextBox ID="rdackdate" runat="server"></asp:TextBox>
                                                                    <asp:CalendarExtender ID="rdackdate_CalendarExtender" runat="server" Enabled="True" TargetControlID="rdackdate">
                                                                    </asp:CalendarExtender>
                                                                    <asp:RequiredFieldValidator ID="RequiredFieldValidator8" runat="server" ControlToValidate="rdackdate" ErrorMessage="*" ForeColor="Red" ValidationGroup="A"></asp:RequiredFieldValidator>
                                                                </td>
                                                                <td>&nbsp;</td>
                                                                <td colspan="2"  >&nbsp;</td>
                                                                <td   colspan="2">GRN No To Confirm:&nbsp;
                                                            <asp:TextBox ID="txtGINConfirm" runat="server" BorderColor="#000066" BorderWidth="1px" Height="20px" TabIndex="20" Width="58px">0</asp:TextBox>
                                                                    &nbsp;
                                                            <telerik:RadButton ID="btnIssueConfirm" runat="server" ButtonType="SkinnedButton" Font-Size="10pt" Height="30px" OnClick="btnIssueConfirm_Click" Style="text-align: center; font-weight: 700; font-style: italic; margin-bottom: 2px;" Text="Confirm" ValidationGroup="A" Width="66px">
                                                            </telerik:RadButton>
                                                                </td>
                                                                <td colspan="2">&nbsp;</td>
                                                            </tr>
                                                            <tr>
                                                                <td  >&nbsp;</td>
                                                                <td   colspan="3">
                                                                    <asp:Label ID="lblreceievedate" runat="server" Text="Return Date" Visible="False"></asp:Label>
                                                                </td>
                                                                <td   colspan="2">
                                                                    <asp:TextBox ID="rdReturndate" runat="server"></asp:TextBox>
                                                                    <asp:CalendarExtender ID="rdReturndate_CalendarExtender" runat="server" Enabled="True" TargetControlID="rdReturndate">
                                                                    </asp:CalendarExtender>
                                                                    <asp:RequiredFieldValidator ID="RequiredFieldValidator9" runat="server" ControlToValidate="rdReturndate" Enabled="False" ErrorMessage="*" ForeColor="Red" ValidationGroup="A"></asp:RequiredFieldValidator>
                                                                    &nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;
                                                                </td>
                                                                <td>&nbsp;</td>
                                                                <td   colspan="2">&nbsp;</td>
                                                                <td   colspan="2">&nbsp;</td>
                                                                <td colspan="2">&nbsp;</td>
                                                            </tr>
                                                            <tr>
                                                                <td  >&nbsp;</td>
                                                                <td   colspan="3"></td>
                                                                <td   colspan="2">
                                                                    <asp:ValidationSummary ID="ValidationSummary1" runat="server" HeaderText="Remaining Fields" Height="48px" ShowMessageBox="True" ShowSummary="False" />
                                                                </td>
                                                                <td  >&nbsp;</td>
                                                                <td colspan="2" class="auto-style100"></td>
                                                                <td   colspan="2">G.I.N. Number&nbsp;&nbsp;&nbsp;&nbsp;&nbsp; :
                                                            <asp:TextBox ID="txtginno" runat="server" BorderColor="#000066" BorderWidth="1px" Enabled="False" Height="20px" onkeydown="addItem(event);" Style="font-size: x-small" TabIndex="5" Width="75px"></asp:TextBox>
                                                                    &nbsp;<a href="ReportsMain.aspx?rptname=GoodsIssueNote&amp;gino=<%= txtginno.Text %>" target="_blank">Print</a><br />
                                                                    <br />
                                                                    Gate Pass Number:<asp:TextBox ID="txtgpno" runat="server" BorderColor="#000066" BorderWidth="1px" Enabled="False" Height="20px" onkeydown="addItem(event);" Style="font-size: x-small" TabIndex="5" Width="75px"></asp:TextBox>
                                                                    &nbsp;<a href="ReportsMain.aspx?rptname=GatePass&amp;gpno=<%= txtgpno.Text %>" target="_blank">Print</a></td>
                                                                <td colspan="2"  ></td>
                                                            </tr>
                                                            <tr>
                                                                <td  >&nbsp;</td>
                                                                <td   colspan="3">&nbsp;</td>
                                                                <td   colspan="2">&nbsp;</td>
                                                                <td>&nbsp;</td>
                                                                <td   colspan="2">&nbsp;</td>
                                                                <td   colspan="2">&nbsp;</td>
                                                                <td colspan="2">&nbsp;</td>
                                                            </tr>
                                                            <tr>

                                                                <asp:UpdatePanel ID="UpdatePanel3" runat="server" UpdateMode="Conditional" ChildrenAsTriggers="false">
                                                                    <ContentTemplate>

                                                                        <td style="width: 350px; text-align: center;" valign="middle" align="center">&nbsp;</td>
                                                                        <td align="center" colspan="12" style="width: 350px;" valign="middle">
                                                                            <asp:GridView ID="grdItems" runat="server" AlternatingRowStyle-CssClass="alt" AutoGenerateColumns="False"
                                                                                CssClass="mGrid" OnRowCommand="grdItems_RowCommand" PagerStyle-CssClass="pgr"
                                                                                Style="font-size: x-small; text-align: center;" Width="759px" OnRowDataBound="grdItems_RowDataBound" OnRowUpdated="grdItems_RowUpdated" OnRowDeleting="grdItems_RowDeleting" OnRowEditing="grdItems_RowEditing">
                                                                                <Columns>
                                                                                    <asp:CommandField ShowDeleteButton="True" />
                                                                                    <asp:BoundField DataField="Issue Store Name" HeaderText="Issue Store Name" Visible="false" />
                                                                                    <asp:BoundField DataField="Issue by Name" HeaderText="Issue by Name" Visible="false" />
                                                                                    <asp:BoundField DataField="Issue to Branch Name" HeaderText="Issue to Branch Name" Visible="false" />
                                                                                    <asp:BoundField DataField="Issue to Store Name" HeaderText="Issue to Store Name" Visible="false" />
                                                                                    <asp:BoundField DataField="Issue to Name" HeaderText="Issue to Name" Visible="false" />
                                                                                    <asp:BoundField DataField="Issue to Department" HeaderText="Issue to Department	" Visible="false" />
                                                                                    <asp:BoundField DataField="Item Name" HeaderText="Item Name" />
                                                                                    <asp:BoundField DataField="Item Type" HeaderText="Item Type" Visible="false" />
                                                                                    <asp:BoundField DataField="Balance" HeaderText="Balance" ItemStyle-HorizontalAlign="Center" />
                                                                                    <asp:TemplateField HeaderText="Qty Issued">
                                                                                        <ItemTemplate>
                                                                                            <asp:TextBox ID="txtqty" runat="server" AutoPostBack="true" autocomplete="off" ItemStyle-HorizontalAlign="Center" OnTextChanged="txtqty_TextChanged" Text='<%#Eval("Qty Issued") %>' Width="50px"></asp:TextBox>
                                                                                        </ItemTemplate>
                                                                                    </asp:TemplateField>
                                                                                    <asp:BoundField DataField="Ackdate" HeaderText="Acknowledge Time" Visible="false" />
                                                                                    <asp:BoundField DataField="Retdate" HeaderText="Return Time" Visible="false" />
                                                                                </Columns>
                                                                            </asp:GridView>
                                                                        </td>
                                                                    </ContentTemplate>
                                                                </asp:UpdatePanel>

                                                            </tr>
                                                            <tr>
                                                                <td   style="text-align: center;" valign="middle">&nbsp;</td>
                                                                <td   style="text-align: center;" valign="middle">&nbsp;</td>
                                                                <td   style="text-align: center;" valign="middle">&nbsp;</td>
                                                                <td   colspan="2" style="width: 350px; text-align: center;" valign="middle">&nbsp;</td>
                                                                <td   colspan="3" style="width: 350px; text-align: right;" valign="middle">&nbsp;</td>
                                                                <td   colspan="2" style="width: 350px; text-align: right;" valign="middle">
                                                                    <asp:CheckBox ID="chkConfirmIssue" runat="server" OnCheckedChanged="chkConfirmIssue_CheckedChanged" Style="font-size: large" Text="Confirm Issued" TextAlign="Left" Width="150px" />
                                                                </td>
                                                                <td   colspan="2" style="width: 350px; text-align: center;" valign="middle">
                                                                    <telerik:RadButton ID="btnSubmitItem" runat="server" ButtonType="SkinnedButton" Font-Size="10pt" Height="30px" OnClick="btnSubmitItem_Click" Style="text-align: center; font-weight: 700; font-style: italic" Text="Save GIN" ValidationGroup="A" Width="99px" UseSubmitBehavior="False">
                                                                    </telerik:RadButton>
                                                                </td>
                                                                <td   style="width: 350px; text-align: center;" valign="middle">&nbsp;</td>
                                                            </tr>
                                                            <tr>
                                                                <td   style="text-align: center;" valign="middle">&nbsp;</td>
                                                                <td   style="text-align: center;" valign="middle">&nbsp;</td>
                                                                <td   style="text-align: center;" valign="middle">&nbsp;</td>
                                                                <td   colspan="2" style="width: 350px; text-align: left;" valign="middle">&nbsp;</td>
                                                                <td   colspan="3" style="width: 350px; text-align: center;" valign="middle">Enter OLD GIN # To move Items</td>
                                                                <td   colspan="2" style="width: 350px; text-align: left;" valign="middle">&nbsp;</td>
                                                                <td   colspan="2" style="width: 350px; text-align: center;" valign="middle">&nbsp;</td>
                                                                <td   style="width: 350px; text-align: center;" valign="middle">&nbsp;</td>
                                                            </tr>
                                                            <tr>
                                                                <td   style="text-align: center;" valign="middle">&nbsp;</td>
                                                                <td   style="text-align: center;" valign="middle">&nbsp;</td>
                                                                <td   style="text-align: center;" valign="middle">&nbsp;</td>
                                                                <td   colspan="2" style="width: 350px; text-align: left;" valign="middle">&nbsp;</td>
                                                                <td   colspan="3" style="width: 350px; text-align: center;" valign="middle">
                                                                    <telerik:RadButton ID="btnOldGIN" runat="server" ButtonType="SkinnedButton" Font-Size="10pt" Height="30px" OnClick="btnOldGIN_Click" TabIndex="19" Text="Save In OLD GIN" ValidationGroup="A" Width="150px">
                                                                    </telerik:RadButton>
                                                                    <asp:TextBox ID="txtoldGIN" runat="server" BorderColor="#000066" BorderWidth="1px" Height="20px" TabIndex="20" Visible="False" Width="83px">0</asp:TextBox>
                                                                </td>
                                                                <td   colspan="2" style="width: 350px; text-align: left;" valign="middle">&nbsp;</td>
                                                                <td   colspan="2" style="width: 350px; text-align: center;" valign="middle">&nbsp;</td>
                                                                <td   style="width: 350px; text-align: center;" valign="middle">&nbsp;</td>
                                                            </tr>
                                                            <tr>
                                                                <td   style="text-align: center;" valign="middle">&nbsp;</td>
                                                                <td   style="text-align: center;" valign="middle">&nbsp;</td>
                                                                <td   style="text-align: center;" valign="middle">&nbsp;</td>
                                                                <td   colspan="2" style="width: 350px; text-align: left;" valign="middle">&nbsp;</td>
                                                                <td   colspan="3" style="width: 350px; text-align: center;" valign="middle">&nbsp;</td>
                                                                <td   colspan="2" style="width: 350px; text-align: left;" valign="middle">&nbsp;</td>
                                                                <td   colspan="2" style="width: 350px; text-align: center;" valign="middle">&nbsp;</td>
                                                                <td   style="width: 350px; text-align: center;" valign="middle">&nbsp;</td>
                                                            </tr>
                                                            <tr>
                                                                <td   style="text-align: left;" valign="middle">&nbsp;</td>
                                                                <td   style="text-align: left;" valign="middle">&nbsp;</td>
                                                                <td   style="text-align: left;" valign="middle">&nbsp;</td>
                                                                <td   colspan="2" style="width: 350px; text-align: left;" valign="middle">&nbsp;</td>
                                                                <td   colspan="3" style="width: 350px; text-align: left;" valign="middle">&nbsp;</td>
                                                                <td   colspan="2" style="width: 350px; text-align: right;" valign="middle">&nbsp;</td>
                                                                <td   colspan="2" style="width: 350px; text-align: center;" valign="middle">&nbsp;</td>
                                                                <td   style="width: 350px; text-align: center;" valign="middle">&nbsp;</td>
                                                            </tr>
                                                        </table>
                                                    </asp:Panel>
                                                </td>
                                            </tr>
                                            <tr>
                                                <td  >&nbsp;</td>
                                                <td  >&nbsp;</td>
                                                <td  >
                                                    <telerik:RadSlider ID="RadSlider1" runat="server">
                                                    </telerik:RadSlider>
                                                </td>
                                                <td>&nbsp;</td>
                                            </tr>
                                        </table>
                                    </telerik:RadAjaxPanel>
                                </td>

<%--                            </ContentTemplate>
                        </asp:UpdatePanel>--%>
                        </tr>
                        <tr>
                            <td>&nbsp;</td>
                            <td>&nbsp;</td>
                            <td>&nbsp;</td>
                        </tr>
                        <tr>
                            <td>&nbsp;</td>
                            <td>&nbsp;</td>
                            <td>&nbsp;</td>
                        </tr>
                        <tr>
                            <td>&nbsp;</td>
                            <td>&nbsp;</td>
                            <td>&nbsp;</td>
                        </tr>
                        <tr>
                            <td>&nbsp;</td>
                            <td>&nbsp;</td>
                            <td>&nbsp;</td>
                        </tr>
                    </table>





					<div class="forgot-top-grids">
						<div class="forgot-grid">
							<ul>
								<li>
									<input type="checkbox" id="brand1" value="1">
									<label for="brand1"><span></span>I agree to the terms</label>
								</li>
							</ul>
						</div>
						
						<div class="clearfix"> </div>
					</div>
					<input type="submit" name="Sign In" value="Sign up">	
                    
                    
                    
                    													
		 


				<div class="sign-down">
				<h4>Already have an account? <a href="login.html"> Login here.</a></h4>
				  <h5><a href="index.html">Go Back to Home</a></h5>
				</div>
			    
	
			    
			        
			    
	
			    
			        
			    
	
			    
			        
			    
	
			    
		<%--	</div>--%>
<%--    </div>
</div>--%>


<!--inner block end here-->
<!--copy rights start here-->
<div class="copyrights">
	 <p>© 2016 Shoppy. All Rights Reserved | Design by  <a href="http://w3layouts.com/" target="_blank">W3layouts</a> </p>
</div>	
<!--COPY rights end here-->
<!--scrolling js-->
		<script src="js/jquery.nicescroll.js"></script>
		<script src="js/scripts.js"></script>
		<!--//scrolling js-->
<script src="js/bootstrap.js"> </script>
<!-- mother grid end here-->


</asp:Content>
<asp:Content ID="Content3" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">




</asp:Content>
