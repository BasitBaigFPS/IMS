<%@ Page Title="" Language="C#" MasterPageFile="~/Site1.Master" AutoEventWireup="true" CodeBehind="Received.aspx.cs" Inherits="IMS.Received" %>

<%@ Register Assembly="AjaxControlToolkit" Namespace="AjaxControlToolkit" TagPrefix="asp" %>
<asp:Content ID="Content1" ContentPlaceHolderID="HeadContent" runat="server">
    <style type="text/css">
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

        .auto-style13 {
            height: 19px;
            width: 300px;
        }

        .auto-style15 {
            height: 33px;
            width: 300px;
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
            width: 104px;
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

        .auto-style31 {
            font-family: Arial, Helvetica, sans-serif;
            width: 34px;
        }

        .auto-style32 {
            width: 104px;
            font-family: Arial, Helvetica, sans-serif;
            font-size: xx-large;
        }

        .auto-style56 {
            width: 104px;
            font-family: Arial, Helvetica, sans-serif;
            font-size: xx-large;
            height: 55px;
        }

        .auto-style57 {
            font-family: Arial, Helvetica, sans-serif;
            width: 34px;
            height: 55px;
        }

        .auto-style58 {
            font-family: Arial, Helvetica, sans-serif;
            width: 97px;
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
        }

        .auto-style64 {
            width: 64px;
            height: 64px;
        }

        .auto-style66 {
            width: 100%;
        }

        .RadComboBox_Default {
            color: #333;
            font: normal 12px/16px "Segoe UI",Arial,Helvetica,sans-serif;
        }

        .RadComboBox {
            margin: 0;
            padding: 0;
            *zoom: 1;
            display: -moz-inline-stack;
            display: inline-block;
            *display: inline;
            text-align: left;
            vertical-align: middle;
            _vertical-align: top;
            white-space: nowrap;
        }

        .RadComboBox_Default .rcbReadOnly .rcbInputCellLeft {
            background-position: 0 -88px;
        }

        .RadComboBox_Default .rcbInputCellLeft {
            background-position: 0 0;
        }

        .RadComboBox_Default .rcbInputCell {
            background-image: url('mvwres://Telerik.Web.UI, Version=2013.3.1015.45, Culture=neutral, PublicKeyToken=121fae78165ba3d4/Telerik.Web.UI.Skins.Default.Common.radFormSprite.png');
            _background-image: url('mvwres://Telerik.Web.UI, Version=2013.3.1015.45, Culture=neutral, PublicKeyToken=121fae78165ba3d4/Telerik.Web.UI.Skins.Default.Common.radFormSpriteIE6.png');
        }

        .RadComboBox .rcbInputCell {
            width: 100%;
            height: 20px;
            _height: 22px;
            line-height: 20px;
            _line-height: 22px;
            text-align: left;
            vertical-align: middle;
        }

        .RadComboBox .rcbInputCell {
            margin: 0;
            padding: 0;
            background-color: transparent;
            background-repeat: no-repeat;
            *zoom: 1;
        }

        .RadComboBox_Default .rcbReadOnly .rcbInput {
            color: #333;
        }

        .RadComboBox .rcbReadOnly .rcbInput {
            cursor: default;
        }

        .RadComboBox_Default .rcbInput {
            color: #333;
            font: normal 12px "Segoe UI",Arial,Helvetica,sans-serif;
            line-height: 16px;
        }

        .RadComboBox .rcbInput {
            margin: 0;
            padding: 0;
            border: 0;
            background: 0;
            padding: 2px 0 1px;
            _padding: 2px 0 0;
            width: 100%;
            _height: 18px;
            outline: 0;
            vertical-align: middle;
            -webkit-appearance: none;
        }

        .RadComboBox_Default .rcbReadOnly .rcbArrowCellRight {
            background-position: -162px -176px;
        }

        .RadComboBox_Default .rcbArrowCellRight {
            background-position: -18px -176px;
        }

        .RadComboBox_Default .rcbArrowCell {
            background-image: url('mvwres://Telerik.Web.UI, Version=2013.3.1015.45, Culture=neutral, PublicKeyToken=121fae78165ba3d4/Telerik.Web.UI.Skins.Default.Common.radFormSprite.png');
            _background-image: url('mvwres://Telerik.Web.UI, Version=2013.3.1015.45, Culture=neutral, PublicKeyToken=121fae78165ba3d4/Telerik.Web.UI.Skins.Default.Common.radFormSpriteIE6.png');
        }

        .RadComboBox .rcbArrowCell {
            width: 18px;
        }

        .RadComboBox .rcbArrowCell {
            margin: 0;
            padding: 0;
            background-color: transparent;
            background-repeat: no-repeat;
            *zoom: 1;
        }

        .auto-style67 {
            width: 320px;
        }

        .auto-style68 {
        }

        .auto-style75 {
            width: 130px;
        }

        .auto-style77 {
        }

        .auto-style81 {
        }

        .auto-style82 {
            width: 171px;
            height: 30px;
        }

        .auto-style85 {
            width: 160px;
        }

        .auto-style89 {
            width: 312px;
            text-align: left;
        }

        .auto-style90 {
            font-family: Calibri;
            color: #99CC00;
            font-size: xx-large;
        }

        .auto-style91 {
            height: 30px;
            text-align: center;
        }

        .auto-style93 {
            width: 160px;
            height: 30px;
            text-align: center;
        }

        .auto-style95 {
            height: 30px;
            width: 130px;
            text-align: center;
        }

        .auto-style108 {
            color: #000000;
            font-size: smaller;
        }

        .auto-style109 {
            width: 100%;
            border: 1px solid #000080;
        }

        .auto-style110 {
            text-align: center;
            font-weight: bold;
            background-color: #CCCCCC;
        }

        .auto-style111 {
            font-size: smaller;
            color: #000000;
            text-align: center;
            font-weight: bold;
            background-color: #CCCCCC;
        }

        .auto-style112 {
            text-align: center;
        }
    </style>
    <link href="CSS/GridViewStyle1.css" rel="stylesheet" type="text/css" />
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">
    <telerik:RadCodeBlock ID="dfg" runat="server">
        <script type="text/javascript">
            function addItem(event) {

                var keyCode = ('which' in event) ? event.which : event.keyCode;

                if (keyCode == 13)
                    document.getElementById('<%=btnAddItem.ClientID%>').click();
             }
             function clientValidation(sender, args) {
                 if (args.value !== "") {
                     var textBoxB = document.getElementById('rddcdate');
                     args.IsValid = (textBoxB.value !== "");
                 }
                 return;
             }

             function checkDate(sender, args) {
                 if (sender._selectedDate > new Date()) {
                     alert("You cannot select a day greater than today!");
                     sender._selectedDate = new Date();
                     // set the date back to the current date
                     sender._textbox.set_Value(sender._selectedDate.format(sender._format));
                 }
             };

        </script>
    </telerik:RadCodeBlock>

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
                        <td class="auto-style27" style="background-color: #F7F7F7; height: 10px; text-align: center;">&nbsp;</td>
                        <td style="background-color: #F7F7F7; height: 10px;"></td>
                    </tr>
                    <tr>
                        <td class="auto-style56" style="background-color: #F7F7F7; text-align: center;">
                            <img alt="" class="auto-style64" src="images/Items.png" /></td>
                        <td class="auto-style90" style="background-color: #F7F7F7"><strong>Goods Received Notes (GRN)</strong></td>
                        <td class="auto-style57" style="background-color: #F7F7F7"></td>
                        <td class="auto-style58" style="background-color: #F7F7F7"></td>
                        <td class="auto-style59" style="background-color: #F7F7F7">
                            <telerik:RadButton ID="btnClose" runat="server" Text="Close" Font-Size="10pt" Height="30px" ButtonType="SkinnedButton" OnClick="btnClose_Click" Width="72px" Style="text-align: center">
                            </telerik:RadButton>
                        </td>
                    </tr>
                    <tr>
                        <td class="auto-style6"></td>
                        <td class="auto-style13">&nbsp;</td>
                        <td class="auto-style21">&nbsp;</td>
                        <td class="auto-style28">&nbsp;</td>
                        <td class="auto-style7">&nbsp;</td>
                    </tr>
                    <tr>
                        <td class="auto-style62" colspan="5">
                            <table class="auto-style66">
                                <tr>
                                    <td colspan="4">
                                        <asp:Panel ID="Panel1" runat="server">
                                            <table class="auto-style66">
                                                <tr>
                                                    <td>Received Type</td>
                                                    <td style="text-align: left" valign="middle">
                                                        <telerik:RadComboBox ID="cmbRecvType" runat="server" AutoPostBack="True" MarkFirstMatch="True" OnSelectedIndexChanged="cmbRecvType_SelectedIndexChanged" Sort="Ascending" Width="300px">
                                                            <Items>
                                                                <telerik:RadComboBoxItem runat="server" Text="Choose Type" Value="Choose Type" Selected="True" />
                                                                <telerik:RadComboBoxItem runat="server" Text="GIN Received" Value="G" />
                                                                <telerik:RadComboBoxItem runat="server" Text="Vendor Recieved" Value="V" />
                                                                <telerik:RadComboBoxItem runat="server" Text="Staff Returned/Initial Stock" Value="S" />
                                                                <telerik:RadComboBoxItem runat="server" Text="Branch Returned" Value="B" />
                                                            </Items>
                                                        </telerik:RadComboBox>
                                                    </td>
                                                    <td>
                                                        <strong>G.R.N Number:</strong></td>
                                                    <td>
                                                        <asp:TextBox ID="txtgrnno" runat="server" BorderColor="#000066" BorderWidth="1px" Enabled="False" Height="20px" onkeydown="addItem(event);" Style="font-size: x-small; text-align: center; font-weight: 700;" TabIndex="5" Width="75px"></asp:TextBox>
                                                        <a href="ReportsMain.aspx?rptname=GoodsReceiptNote&amp;grno=<%= txtgrnno.Text %>" target="_blank">Print</a></td>
                                                    <td>&nbsp;</td>
                                                </tr>
                                                <tr>
                                                    <td class="auto-style81">Select System</td>
                                                    <td class="auto-style89">
                                                        <telerik:RadComboBox ID="cmbSystem" runat="server" MarkFirstMatch="True" OnSelectedIndexChanged="cmbSystem_SelectedIndexChanged" Sort="Ascending" Width="300px">
                                                        </telerik:RadComboBox>
                                                    </td>
                                                    <td class="auto-style75">&nbsp;</td>
                                                    <td class="auto-style85">
                                                        <telerik:RadButton ID="btnPrint" runat="server" ButtonType="SkinnedButton" Font-Size="10pt" Height="30px" OnClick="btnPrint_Click" TabIndex="8" Text="Print" ValidationGroup="A" Visible="False" Width="16px">
                                                        </telerik:RadButton>
                                                    </td>
                                                    <td>&nbsp;</td>
                                                </tr>
                                                <tr>
                                                    <td class="auto-style81">Department</td>
                                                    <td class="auto-style89">
                                                        <telerik:RadComboBox ID="cmbDept" runat="server" MarkFirstMatch="True" Sort="Ascending" TabIndex="2" Width="300px" OnSelectedIndexChanged="cmbDept_SelectedIndexChanged">
                                                        </telerik:RadComboBox>
                                                    </td>
                                                    <td class="auto-style75">&nbsp;</td>
                                                    <td class="auto-style85">&nbsp;</td>
                                                    <td>&nbsp;</td>
                                                </tr>
                                                <tr>
                                                    <td class="auto-style81">Stores</td>
                                                    <td class="auto-style89">
                                                        <telerik:RadComboBox ID="cmbstorefrom" runat="server" MarkFirstMatch="True" Sort="Ascending" TabIndex="2" Width="300px" OnSelectedIndexChanged="cmbstorefrom_SelectedIndexChanged">
                                                        </telerik:RadComboBox>
                                                    </td>
                                                    <td class="auto-style75">&nbsp;</td>
                                                    <td class="auto-style85">&nbsp;</td>
                                                    <td>&nbsp;</td>
                                                </tr>
                                                <tr>
                                                    <td class="auto-style81">Vendors</td>
                                                    <td class="auto-style89">
                                                        <telerik:RadComboBox ID="ddlVendors" runat="server" MarkFirstMatch="True" Sort="Ascending" TabIndex="3" Width="300px">
                                                        </telerik:RadComboBox>
                                                    </td>
                                                    <td class="auto-style95"></td>
                                                    <td class="auto-style93"></td>
                                                    <td class="auto-style91"></td>
                                                </tr>
                                                <tr>
                                                    <td class="auto-style81" colspan="4">
                                                        <table align="center" class="auto-style109">
                                                            <tr>
                                                                <td class="auto-style110"><span class="auto-style108">D.C No.</span></td>
                                                                <td class="auto-style111">D.C Date</td>
                                                                <td class="auto-style111">Invoice No</td>
                                                                <td class="auto-style111">P.O. Number</td>
                                                                <td class="auto-style111">Vehicle No.</td>
                                                            </tr>
                                                            <tr>
                                                                <td class="auto-style112">
                                                                    <asp:TextBox ID="txtdcno" runat="server" BorderColor="#000066" BorderWidth="1px" Height="20px" onkeydown="addItem(event);" Style="font-size: x-small" TabIndex="4" Width="100px"></asp:TextBox>
                                                                </td>
                                                                <td class="auto-style112">
                                                                    <asp:TextBox ID="rddcdate" runat="server" Style="font-size: x-small; text-align: center;" Width="150px" TabIndex="5"></asp:TextBox>
                                                                    <asp:CalendarExtender ID="rddcdate_CalendarExtender" runat="server" Enabled="True" TargetControlID="rddcdate" OnClientDateSelectionChanged="checkDate" TodaysDateFormat="dd-MM-yyyy" Format="dd-MM-yyyy">
                                                                    </asp:CalendarExtender>
                                                                    <%-- <asp:RequiredFieldValidator ID="RequiredFieldValidator1" runat="server" ControlToValidate="rddcdate" ErrorMessage="*" Font-Size="14pt" ForeColor="Red"></asp:RequiredFieldValidator></td>--%>
                                                                    <td class="auto-style112">
                                                                        <asp:TextBox ID="txtinvoice" runat="server" BorderColor="#000066" BorderWidth="1px" Height="20px" onkeydown="addItem(event);" Style="font-size: x-small" TabIndex="6" Width="75px"></asp:TextBox>
                                                                    </td>
                                                                    <td class="auto-style112">
                                                                        <asp:TextBox ID="txtporder" runat="server" BorderColor="#000066" BorderWidth="1px" Height="20px" onkeydown="addItem(event);" Style="font-size: x-small" TabIndex="7" Width="75px"></asp:TextBox>
                                                                    </td>
                                                                    <td class="auto-style112">
                                                                        <asp:TextBox ID="txtvehicle" runat="server" BorderColor="#000066" BorderWidth="1px" Height="20px" onkeydown="addItem(event);" Style="font-size: x-small" TabIndex="8" Width="75px"></asp:TextBox>
                                                                    </td>
                                                            </tr>
                                                        </table>
                                                    </td>
                                                    <td class="auto-style91">&nbsp;</td>
                                                </tr>
                                                <tr>
                                                    <td class="auto-style81" colspan="4">
                                                        <asp:UpdatePanel ID="UpdatePanel1" runat="server">
                                                            <ContentTemplate>
                                                                <table cellpadding="0" cellspacing="1" class="auto-style66">
                                                                    <tr>
                                                                        <td class="auto-style81" colspan="4">&nbsp;</td>
                                                                    </tr>
                                                                    <tr>
                                                                        <td class="auto-style81">Search Item</td>
                                                                        <td class="auto-style89">


                                                                            <telerik:RadComboBox RenderMode="Lightweight" ID="cmbItemSearch" AllowCustomText="true" runat="server" Width="350" Height="400px" Filter="Contains"
                                                                                AutoPostBack="True" MarkFirstMatch="True" Sort="Ascending" CheckBoxes="true" EnableCheckAllItemsCheckBox="true" EmptyMessage="Search for items...">
                                                                            </telerik:RadComboBox>
                                                                        </td>
                                                                        <td>&nbsp;

                                                                         <asp:Literal ID="ItemsClientSide" runat="server"></asp:Literal>
                                                                            <asp:Label ID="lblItems" runat="server" Text="Items List" Visible="False"></asp:Label>
                                                                            <asp:Label ID="lblItemID" runat="server" Text="ItemID" Visible="False"></asp:Label>


                                                                        </td>
                                                                        <td>&nbsp;</td>
                                                                    </tr>
                                                                    <tr>
                                                                        <td class="auto-style81">Receive Status</td>
                                                                        <td class="auto-style89">
                                                                            <telerik:RadComboBox ID="cmbRecvStatus" runat="server" AutoPostBack="True" MarkFirstMatch="True" OnSelectedIndexChanged="cmbRecvStatus_SelectedIndexChanged" Sort="Ascending" Width="300px">
                                                                                <Items>
                                                                                    <telerik:RadComboBoxItem runat="server" Selected="True" Text="Choose Status" Value="Choose Status" />
                                                                                    <telerik:RadComboBoxItem runat="server" Text="Permenant Receive" Value="Permenant Receive" />
                                                                                    <telerik:RadComboBoxItem runat="server" Text="Temporary Receive" Value="Temporary Receive" />
                                                                                </Items>
                                                                            </telerik:RadComboBox>
                                                                          <%--  <asp:RequiredFieldValidator ID="RequiredFieldValidator6" runat="server" ControlToValidate="cmbRecvStatus" ErrorMessage="*" Font-Size="14pt" ForeColor="Red"></asp:RequiredFieldValidator>--%>
                                                                        </td>
                                                                        <td>&nbsp;</td>
                                                                        <td>&nbsp;</td>
                                                                    </tr>
                                                                    <tr>
                                                                        <td class="auto-style81">&nbsp;</td>
                                                                        <td class="auto-style89">
                                                                            &nbsp;</td>
                                                                        <td align="left" valign="middle">
                                                                            <telerik:RadButton ID="btnAddItem" runat="server" ButtonType="SkinnedButton" Font-Size="10pt" Height="16px" OnClick="btnAddItem_Click" Style="top: 2px; left: 16px; " TabIndex="16" Text="Add Item" ValidationGroup="A" Width="90px">
                                                                            </telerik:RadButton>
                                                                        </td>
                                                                        <td>&nbsp;</td>
                                                                    </tr>
                                                                    <tr>
                                                                        <td class="auto-style81">&nbsp;</td>
                                                                        <td class="auto-style89">&nbsp;</td>
                                                                        <td>&nbsp;</td>
                                                                        <td>&nbsp;</td>
                                                                    </tr>
                                                                    <tr>
                                                                        <td class="auto-style81">&nbsp;</td>
                                                                        <td class="auto-style89">
                                                                            <asp:GridView ID="grdItems" runat="server" AlternatingRowStyle-CssClass="alt" AutoGenerateColumns="False" CssClass="mGrid" HorizontalAlign="Center" OnDataBound="grdItems_DataBound" OnRowCommand="grdItems_RowCommand" OnRowDataBound="grdItems_RowDataBound" OnRowDeleting="grdItems_RowDeleting" OnRowEditing="grdItems_RowEditing" OnRowUpdated="grdItems_RowUpdated" OnRowUpdating="grdItems_RowUpdating" OnSorting="grdItems_Sorting" PagerStyle-CssClass="pgr" Style="font-size: x-small; text-align: left;" Width="400px">
                                                                                <AlternatingRowStyle CssClass="alt" />
                                                                                <Columns>
                                                                                    <asp:CommandField ShowDeleteButton="True" />
                                                                                    <asp:TemplateField HeaderText="Item Code" Visible="True">
                                                                                        <ItemTemplate>
                                                                                            <asp:Label ID="lblItemID" runat="server" Text='<%#Eval("Item Code") %>' Width="50px" />
                                                                                        </ItemTemplate>
                                                                                        <ItemStyle HorizontalAlign="Right" VerticalAlign="Middle" />
                                                                                    </asp:TemplateField>
                                                                                    <asp:BoundField DataField="Item Name" HeaderText="Item Name" HeaderStyle-Width="500" ItemStyle-Width="500" />
                                                                                    <%--   <asp:TemplateField HeaderText="Balance">
                                                <ItemTemplate>
                                                   <asp:Label ID="lblbalance" runat="server" Text='<%#Eval("Balance") %>' Width="50px" />
                                                </ItemTemplate>
                                                    <ItemStyle HorizontalAlign="Right" VerticalAlign="Middle" />
                                            </asp:TemplateField>--%>
                                                                                    <asp:TemplateField HeaderText="Model">
                                                                                        <ItemTemplate>
                                                                                            <asp:TextBox ID="txtModel" runat="server" autocomplete="off" AutoPostBack="false" Text='<%#Eval("Model") %>' Width="50px"></asp:TextBox>
                                                                                        </ItemTemplate>
                                                                                    </asp:TemplateField>
                                                                                    <asp:TemplateField HeaderText="Brand">
                                                                                        <ItemTemplate>
                                                                                            <asp:TextBox ID="txtBrand" runat="server" autocomplete="off" AutoPostBack="false" Text='<%#Eval("Brand") %>' Width="50px"></asp:TextBox>
                                                                                        </ItemTemplate>
                                                                                    </asp:TemplateField>
                                                                                    <asp:TemplateField HeaderText="Qty Received">
                                                                                        <ItemTemplate>
                                                                                            <%--<asp:TextBox ID="txtqty" runat="server" AutoPostBack="True" OnTextChanged="txtqty_TextChanged" Text='<%#Eval("Qty Issued") %>' Width="50px"></asp:TextBox>--%>
                                                                                            <asp:TextBox ID="txtqty" runat="server" autocomplete="off" AutoPostBack="false" onclick="GridRowNo(<%# Container.DataItemIndex %>,this);" OnTextChanged="txtqty_TextChanged" Text='<%#Eval("Qty Received") %>' Width="50px"></asp:TextBox>
                                                                                        </ItemTemplate>
                                                                                    </asp:TemplateField>
                                                                                </Columns>
                                                                            </asp:GridView>
                                                                        </td>
                                                                        <td>&nbsp;</td>
                                                                        <td>&nbsp;</td>
                                                                    </tr>
                                                                    <tr>
                                                                        <td class="auto-style81">
                                                                            <telerik:RadButton ID="btnOldGRN" runat="server" ButtonType="SkinnedButton" Font-Size="10pt" Height="30px" OnClick="btnOldGRN_Click" TabIndex="19" Text="OLD GRN Entry" ValidationGroup="A" Width="100px">
                                                                            </telerik:RadButton>
                                                                        </td>
                                                                        <td class="auto-style89">OLD GRN No:
                                                                            <asp:TextBox ID="txtoldGRN" runat="server" BorderColor="#000066" BorderWidth="1px" Height="20px" style="margin-bottom: 0px" TabIndex="20" Visible="False" Width="97px">0</asp:TextBox>
                                                                        </td>
                                                                        <td>
                                                                            <telerik:RadButton ID="btnSave" runat="server" ButtonType="SkinnedButton" Font-Size="10pt" Height="30px" OnClick="btnSave_Click" Style="text-align: center; font-style: italic; top: 2px; left: 18px; width: 84px;" TabIndex="18" Text="Save" ValidationGroup="A" Visible="False">
                                                                            </telerik:RadButton>
                                                                        </td>
                                                                        <td>&nbsp;</td>
                                                                    </tr>
                                                                    <tr style="visibility: hidden">
                                                                        <td class="auto-style81">&nbsp;</td>
                                                                        <td class="auto-style89">
                                                                            <telerik:RadComboBox ID="cmbCategory" runat="server" AutoPostBack="True" MarkFirstMatch="True" OnSelectedIndexChanged="cmbCategory_SelectedIndexChanged" Sort="Ascending" TabIndex="9" Visible="False" Width="300px">
                                                                            </telerik:RadComboBox>
                                                                        </td>
                                                                        <td>&nbsp;</td>
                                                                        <td>&nbsp;</td>
                                                                    </tr>
                                                                    <tr>
                                                                        <td class="auto-style81" style="visibility: hidden">&nbsp;</td>
                                                                        <td class="auto-style89" style="visibility: hidden">
                                                                            <telerik:RadComboBox ID="cmbSubCategory" runat="server" AutoPostBack="True" MarkFirstMatch="True" OnSelectedIndexChanged="cmbSubCategory_SelectedIndexChanged" Sort="Ascending" TabIndex="10" Width="300px" Visible="False">
                                                                            </telerik:RadComboBox>
                                                                        </td>
                                                                        <td style="visibility: hidden">&nbsp;</td>
                                                                        <td style="visibility: hidden">&nbsp;</td>
                                                                    </tr>
                                                                    <tr>
                                                                        <td class="auto-style81" style="visibility: hidden">&nbsp;</td>
                                                                        <td class="auto-style89" style="visibility: hidden">
                                                                            <telerik:RadComboBox ID="cmbItemHead" runat="server" AutoPostBack="True" MarkFirstMatch="True" OnSelectedIndexChanged="cmbItemHead_SelectedIndexChanged" Sort="Ascending" TabIndex="11" Width="300px" Visible="False">
                                                                            </telerik:RadComboBox>
                                                                        </td>
                                                                        <td style="visibility: hidden">&nbsp;</td>
                                                                        <td style="visibility: hidden">&nbsp;</td>
                                                                    </tr>
                                                                    <tr style="visibility: hidden">
                                                                        <td class="auto-style81">&nbsp;</td>
                                                                        <td class="auto-style89">&nbsp;</td>
                                                                        <td>&nbsp;</td>
                                                                        <td>&nbsp;</td>
                                                                    </tr>
                                                                    <tr style="visibility: hidden">
                                                                        <td class="auto-style81">Items</td>
                                                                        <td class="auto-style89">
                                                                            <telerik:RadComboBox ID="cmbItem" runat="server" MarkFirstMatch="True" Sort="Ascending" TabIndex="12" Width="300px" Visible="False">
                                                                            </telerik:RadComboBox>
                                                                        </td>
                                                                        <td>&nbsp;</td>
                                                                        <td>&nbsp;</td>
                                                                    </tr>
                                                                    <tr style="visibility: hidden">
                                                                        <td class="auto-style82">Item Model</td>
                                                                        <td class="auto-style89">
                                                                            <asp:TextBox ID="txtitemmodel" runat="server" TabIndex="13" Width="216px"></asp:TextBox>
                                                                        </td>
                                                                        <td>&nbsp;</td>
                                                                        <td>&nbsp;</td>
                                                                    </tr>
                                                                    <tr style="visibility: hidden">
                                                                        <td class="auto-style82">Item Brand</td>
                                                                        <td class="auto-style89">
                                                                            <asp:TextBox ID="txtitembrand" runat="server" TabIndex="14" Width="214px"></asp:TextBox>
                                                                        </td>
                                                                        <td>&nbsp;</td>
                                                                        <td>&nbsp;</td>
                                                                    </tr>
                                                                    <tr style="visibility: hidden">
                                                                        <td class="auto-style82">Receive Status</td>
                                                                        <td class="auto-style89">&nbsp;</td>
                                                                        <td>&nbsp;</td>
                                                                        <td>&nbsp;</td>
                                                                    </tr>
                                                                    <tr style="visibility: hidden">
                                                                        <td class="auto-style82">Quantity</td>
                                                                        <td class="auto-style89">
                                                                            <%--<asp:TextBox ID="txtQty" runat="server" BorderColor="#000066" BorderWidth="1px" Height="20px" onkeydown="addItem(event);" TabIndex="15" Width="100px"></asp:TextBox>--%>
                                                                        </td>
                                                                        <td>&nbsp;</td>
                                                                        <td>&nbsp;</td>
                                                                    </tr>
                                                                </table>
                                                                <br />
                                                            </ContentTemplate>
                                                        </asp:UpdatePanel>
                                                    </td>
                                                    <td class="auto-style91">&nbsp;</td>
                                                </tr>
                                                <tr>
                                                    <td class="auto-style77" colspan="2">&nbsp;</td>
                                                    <td class="auto-style75">&nbsp;</td>
                                                    <td class="auto-style85">&nbsp;</td>
                                                    <td class="auto-style77">&nbsp;</td>
                                                </tr>
                                                <tr>
                                                    <td class="auto-style77" colspan="2">
                                                        &nbsp;</td>
                                                    <td class="auto-style75">&nbsp;</td>
                                                    <td class="auto-style85">
                                                        &nbsp;</td>
                                                    <td class="auto-style77">&nbsp;</td>
                                                </tr>
                                                <tr>
                                                    <td class="auto-style81" colspan="5" style="text-align: right">&nbsp;</td>
                                                </tr>
                                            </table>
                                        </asp:Panel>
                                    </td>
                                </tr>
                                <tr>
                                    <td class="auto-style75">&nbsp;</td>
                                    <td class="auto-style68">&nbsp;</td>
                                    <td class="auto-style67">
                                        <telerik:RadSlider ID="RadSlider1" runat="server">
                                        </telerik:RadSlider>
                                    </td>
                                    <td>&nbsp;</td>
                                </tr>
                            </table>
                        </td>
                    </tr>
                    <tr>
                        <td class="auto-style62" colspan="5">&nbsp;</td>
                    </tr>
                    <tr>
                        <td class="auto-style10">&nbsp;</td>
                        <td class="auto-style15">&nbsp;</td>
                        <td class="auto-style20"></td>
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
                        <td class="auto-style26">
                            <telerik:RadAjaxLoadingPanel ID="RadAjaxLoadingPanel2" runat="server" Skin="Default">
                            </telerik:RadAjaxLoadingPanel>
                        </td>
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
