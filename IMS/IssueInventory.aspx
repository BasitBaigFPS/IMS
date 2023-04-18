<%@ Page Title="" Language="C#" MasterPageFile="~/Site1.Master" AutoEventWireup="true" CodeBehind="IssueInventory.aspx.cs" Inherits="IMS.IssueInventory" %>

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
            width: 509px;
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
        width: 509px;
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
            width: 509px;
            font-family: Arial, Helvetica, sans-serif;
            font-size: xx-large;
        height: 10px;
    }

        .auto-style55 {
            width: 300px;
            font-family: Arial, Helvetica, sans-serif;
            font-size: xx-large;
            color: #C0C0C0;
            height: 55px;
        }

        .auto-style57 {
            font-family: Arial, Helvetica, sans-serif;
            width: 34px;
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

        .auto-style81 {
        }

        .auto-style82 {
            width: 171px;
            height: 22px;
        }

        .auto-style85 {
            width: 160px;
        }

        .auto-style86 {
            height: 22px;
            width: 160px;
        }

        .auto-style88 {
            height: 22px;
            width: 312px;
        }

        .auto-style89 {
            width: 312px;
            text-align: justify;
        }

        .auto-style90 {
            height: 43px;
        }

        .auto-style91 {
            width: 312px;
            height: 43px;
        }

        .auto-style92 {
            text-decoration: underline;
        }

        .auto-style95 {
            width: 171px;
        }

        .auto-style96 {
            height: 43px;
            width: 171px;
        }

        .auto-style97 {
            width: 350px;
        }

        .auto-style98 {
            width: 268435456px;
        }

        .auto-style99 {
            height: 22px;
            width: 268435456px;
        }

        .auto-style100 {
            height: 43px;
            width: 268435456px;
        }
        .auto-style101 {
            font-size: x-large;
        }
    .auto-style102 {
        width: 509px;
        font-family: Arial, Helvetica, sans-serif;
        font-size: xx-large;
        color: #C0C0C0;
        height: 55px;
    }
    .auto-style103 {
        width: 509px;
        height: 10px;
    }
    .auto-style104 {
        width: 509px;
    }
    .auto-style105 {
        font-family: Arial, Helvetica, sans-serif;
        font-size: medium;
        color: #C0C0C0;
        width: 509px;
    }
    .auto-style106 {
        width: 509px;
        font-family: Arial, Helvetica, sans-serif;
        font-size: medium;
        height: 31px;
    }
    </style>
    <link href="CSS/GridViewStyle1.css" rel="stylesheet" type="text/css" />

</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">
    <telerik:RadCodeBlock ID="dfg" runat="server">
    </telerik:RadCodeBlock>

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
                        <td class="auto-style32" style="background-color: #F7F7F7; "></td>
                        <td class="auto-style61" style="background-color: #F7F7F7; height: 10px;"></td>
                        <td class="auto-style31" style="background-color: #F7F7F7; height: 10px;"></td>
                        <td class="auto-style27" style="background-color: #F7F7F7; height: 10px;"></td>
                        <td style="background-color: #F7F7F7; height: 10px;"></td>
                    </tr>
                    <tr>
                        <td class="auto-style102" style="background-color: #F7F7F7; text-align: center;">
                            <img alt=""  src="images/inv_isu.png" /><span class="auto-style101">Issue Inventory</span></td>
                        <td class="auto-style55" style="background-color: #F7F7F7"><strong></strong></td>
                        <td class="auto-style57" style="background-color: #F7F7F7"></td>
                        <td style="background-color: #F7F7F7; text-align: center;">&nbsp;</td>
                        <td class="auto-style59" style="background-color: #F7F7F7; text-align: right;">
                            <telerik:RadButton ID="btnClose" runat="server" Text="Close" Font-Size="10pt" Height="30px" ButtonType="SkinnedButton" OnClick="btnClose_Click" Width="72px" Style="text-align: center">
                            </telerik:RadButton>

                        </td>
                    </tr>
                    <tr>
                        <td class="auto-style103"></td>
                        <td class="auto-style13">
                            <telerik:RadAjaxLoadingPanel ID="RadAjaxLoadingPanel2" runat="server" Skin="Default" Height="16px">
                            </telerik:RadAjaxLoadingPanel>
                        </td>
                        <td class="auto-style21">&nbsp;</td>
                        <td class="auto-style28">&nbsp;</td>
                        <td class="auto-style7">&nbsp;</td>
                    </tr>
                    <tr>
                        <asp:UpdatePanel ID="UpdatePanel1" runat="server" UpdateMode="Conditional" ChildrenAsTriggers="false">
                            <ContentTemplate>

                                <td class="auto-style62" colspan="5">
                                    <telerik:RadAjaxPanel ID="RadAjaxPanel2" runat="server" Width="950px" HorizontalAlign="NotSet" LoadingPanelID="RadAjaxLoadingPanel2" RenderMode="Inline">
                                        <table class="auto-style66">
                                            <tr>
                                                <td colspan="4">
                                                    <asp:Panel ID="Panel1" runat="server">
                                                        <table class="auto-style66">
                                                            <tr>
                                                                <td class="auto-style95">&nbsp;</td>
                                                                <td class="auto-style95" colspan="3">Issuing Type</td>
                                                                <td class="auto-style89" colspan="2">
                                                                    <telerik:RadComboBox ID="cmbIssueType" runat="server" AutoPostBack="True" MarkFirstMatch="True" OnSelectedIndexChanged="cmbIssueType_SelectedIndexChanged" Sort="Ascending" Width="300px">
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
                                                                <td colspan="2" class="auto-style98">&nbsp;</td>
                                                                <td class="auto-style85" colspan="2">&nbsp;</td>
                                                                <td colspan="2">&nbsp;</td>
                                                            </tr>
                                                            <tr>
                                                                <td class="auto-style95">&nbsp;</td>
                                                                <td class="auto-style95" colspan="3">&nbsp;</td>
                                                                <td style="font-weight: 700" colspan="2">&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp; <span class="auto-style92">I s s u e d </span></td>
                                                                <td>&nbsp;</td>
                                                                <td colspan="2" class="auto-style98">&nbsp;</td>
                                                                <td colspan="2">&nbsp;&nbsp;&nbsp;&nbsp;&nbsp; &nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp; <span class="auto-style92"><strong>&nbsp;R e c e i v e d</strong></span></td>
                                                                <td colspan="2">&nbsp;</td>
                                                            </tr>
                                                            <tr>
                                                                <td class="auto-style95">&nbsp;</td>
                                                                <td class="auto-style95" colspan="3">Select System</td>
                                                                <td class="auto-style89" colspan="2">

                                                                    <telerik:RadComboBox ID="cmbSystem" runat="server" AutoPostBack="True" MarkFirstMatch="True" OnSelectedIndexChanged="cmbSystem_SelectedIndexChanged" Sort="Ascending" Width="300px">
                                                                    </telerik:RadComboBox>

                                                                </td>
                                                                <td>&nbsp;</td>
                                                                <td colspan="2" class="auto-style98">&nbsp;</td>
                                                                <td class="auto-style85" colspan="2">&nbsp;</td>
                                                                <td colspan="2">&nbsp;</td>
                                                            </tr>
                                                            <tr>
                                                                <td class="auto-style95">&nbsp;</td>
                                                                <td class="auto-style95" colspan="3">Issued from Branch</td>
                                                                <td class="auto-style89" colspan="2">
                                                                    <telerik:RadComboBox ID="cmbbranchfrom" runat="server" AutoPostBack="True" MarkFirstMatch="True" OnSelectedIndexChanged="cmbbranchfrom_SelectedIndexChanged" Sort="Ascending" Width="300px">
                                                                    </telerik:RadComboBox>
                                                                </td>
                                                                <td>
                                                                    <asp:RequiredFieldValidator ID="RequiredFieldValidator1" runat="server" ControlToValidate="cmbbranchfrom" ErrorMessage="*" ForeColor="Red" InitialValue="Choose Branch" ValidationGroup="A"></asp:RequiredFieldValidator>
                                                                </td>
                                                                <td colspan="2" class="auto-style98">Issued to Branch</td>
                                                                <td class="auto-style85" colspan="2">
                                                                    <telerik:RadComboBox ID="cmbBranchto" runat="server" AutoPostBack="True" MarkFirstMatch="True" OnSelectedIndexChanged="cmbBranchto_SelectedIndexChanged" Sort="Ascending" Width="300px">
                                                                    </telerik:RadComboBox>
                                                                </td>
                                                                <td colspan="2">
                                                                    <asp:RequiredFieldValidator ID="RequiredFieldValidator3" runat="server" ControlToValidate="cmbBranchto" ErrorMessage="*" ForeColor="Red" InitialValue="Choose Branch" ValidationGroup="A"></asp:RequiredFieldValidator>
                                                                </td>
                                                            </tr>
                                                            <tr>
                                                                <td class="auto-style95">&nbsp;</td>
                                                                <td class="auto-style95" colspan="3">Issued from&nbsp; Store</td>
                                                                <td class="auto-style89" colspan="2">
                                                                    <telerik:RadComboBox ID="cmbstorefrom" runat="server" AutoPostBack="True" MarkFirstMatch="True" Sort="Ascending" Width="300px" OnSelectedIndexChanged="cmbstorefrom_SelectedIndexChanged">
                                                                    </telerik:RadComboBox>
                                                                </td>
                                                                <td>
                                                                    <asp:RequiredFieldValidator ID="RequiredFieldValidator2" runat="server" ControlToValidate="cmbstorefrom" ErrorMessage="*" ForeColor="Red" InitialValue="Choose Store" ValidationGroup="A"></asp:RequiredFieldValidator>
                                                                </td>
                                                                <td colspan="2" class="auto-style98">Issued to Store</td>
                                                                <td class="auto-style85" colspan="2">
                                                                    <telerik:RadComboBox ID="cmbStoreto" runat="server" AutoPostBack="True" MarkFirstMatch="True" Sort="Ascending" Width="300px">
                                                                    </telerik:RadComboBox>
                                                                </td>
                                                                <td colspan="2">
                                                                    <asp:RequiredFieldValidator ID="RequiredFieldValidator4" runat="server" ControlToValidate="cmbStoreto" ErrorMessage="*" ForeColor="Red" InitialValue="Choose Store" ValidationGroup="A"></asp:RequiredFieldValidator>
                                                                </td>
                                                            </tr>
                                                            <tr>
                                                                <td class="auto-style82">&nbsp;</td>
                                                                <td class="auto-style82" colspan="3">Issued Department</td>
                                                                <td class="auto-style88" colspan="2">
                                                                    <telerik:RadComboBox ID="cmbDepartmentfrom" runat="server" AutoPostBack="True" MarkFirstMatch="True" Sort="Ascending" Width="300px" OnSelectedIndexChanged="cmbDepartmentfrom_SelectedIndexChanged">
                                                                    </telerik:RadComboBox>
                                                                </td>
                                                                <td class="auto-style9">&nbsp;</td>
                                                                <td class="auto-style99" colspan="2">&nbsp;Department</td>
                                                                <td class="auto-style86" colspan="2">
                                                                    <telerik:RadComboBox ID="cmbDepartmentto" runat="server" AutoPostBack="True" MarkFirstMatch="True" Sort="Ascending" Width="300px" OnSelectedIndexChanged="cmbDepartmentto_SelectedIndexChanged">
                                                                    </telerik:RadComboBox>
                                                                </td>
                                                                <td class="auto-style9" colspan="2">
                                                                    <asp:RequiredFieldValidator ID="RequiredFieldValidator5" runat="server" ControlToValidate="cmbDepartmentto" ErrorMessage="*" ForeColor="Red" InitialValue="Choose Department" ValidationGroup="A"></asp:RequiredFieldValidator>
                                                                </td>
                                                            </tr>
                                                            <tr>
                                                                <td class="auto-style95">&nbsp;</td>
                                                                <td class="auto-style95" colspan="3">Issued By</td>
                                                                <td class="auto-style89" colspan="2">
                                                                    <telerik:RadComboBox ID="cmbIssuedby" runat="server" AutoPostBack="True" MarkFirstMatch="True" Sort="Ascending" Width="300px" OnSelectedIndexChanged="cmbIssuedby_SelectedIndexChanged">
                                                                    </telerik:RadComboBox>
                                                                </td>
                                                                <td>&nbsp;</td>
                                                                <td colspan="2" class="auto-style98">Issued to Person</td>
                                                                <td class="auto-style85" colspan="2">
                                                                    <telerik:RadComboBox ID="cmbPersonto" runat="server" AutoPostBack="True" MarkFirstMatch="True" Sort="Ascending" Width="300px" OnSelectedIndexChanged="cmbPersonto_SelectedIndexChanged">
                                                                    </telerik:RadComboBox>
                                                                </td>
                                                                <td colspan="2">
                                                                    <asp:RequiredFieldValidator ID="RequiredFieldValidator11" runat="server" ControlToValidate="cmbPersonto" ErrorMessage="*" ForeColor="Red" InitialValue="Choose Department" ValidationGroup="A"></asp:RequiredFieldValidator>
                                                                </td>
                                                            </tr>
                                                            <tr>
                                                                <td class="auto-style95">&nbsp;</td>
                                                                <td class="auto-style95" colspan="3">Issuing Status</td>
                                                                <td class="auto-style89" colspan="2">
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
                                                                <td colspan="2" class="auto-style98">&nbsp;</td>
                                                                <td class="auto-style85" colspan="2">
                                                                    <telerik:RadButton ID="btnPrintGatePass" runat="server" ButtonType="SkinnedButton" Font-Size="10pt" Height="30px" OnClick="btnPrintGatePass_Click" Style="text-align: center" TabIndex="8" Text="PrintGP" ValidationGroup="A" Visible="False" Width="44px">
                                                                    </telerik:RadButton>
                                                                </td>
                                                                <td colspan="2">&nbsp;</td>
                                                            </tr>
                                                            <tr>
                                                                <td class="auto-style82">&nbsp;</td>
                                                                <td class="auto-style82" colspan="3">&nbsp;</td>
                                                                <td colspan="2" class="auto-style88">&nbsp;</td>
                                                                <td class="auto-style9">&nbsp;</td>
                                                                <td class="auto-style99" colspan="2">Transfer To</td>
                                                                <td colspan="2">
                                                                    <telerik:RadComboBox ID="cmbSystemTo" runat="server" AutoPostBack="True" MarkFirstMatch="True" OnSelectedIndexChanged="cmbSystemTo_SelectedIndexChanged" Sort="Ascending" Visible="False" Width="300px">
                                                                    </telerik:RadComboBox>
                                                                </td>
                                                                <td class="auto-style9" colspan="2">&nbsp;</td>
                                                            </tr>


                                                            <tr>

                                                                <asp:UpdatePanel ID="UpdatePanel2" runat="server" UpdateMode="Conditional" ChildrenAsTriggers="false">
                                                                    <ContentTemplate>

                                                                        <td class="auto-style82"></td>
                                                                        <td class="auto-style82" colspan="3">Search Item</td>
                                                                        <td class="auto-style88" colspan="2">
       
                                                                           

                                                                     <%--   <telerik:RadComboBox  ID="cmbItemSearch1"  runat="server" AutoPostBack="True" OnSelectedIndexChanged="cmbItemSearch_SelectedIndexChanged" CheckBoxes="true"  Width="350" Height="400px" filter="Contains" Sort="Ascending"  >
                                                                        </telerik:RadComboBox>--%>

<%--                                                                        <telerik:RadComboBox RenderMode="Lightweight" ID="cmbItemSearch" AllowCustomText="true" runat="server" OnSelectedIndexChanged="cmbItemSearch_SelectedIndexChanged" Width="350" Height="400px" filter="Contains" AutoPostBack="True" MarkFirstMatch="True" Sort="Ascending"  CheckBoxes="true" EnableCheckAllItemsCheckBox="true" EmptyMessage="Search for items...">
                                                                        </telerik:RadComboBox>

--%>



                                                                         <telerik:RadComboBox ID="cmbItemSearch" runat="server" AutoPostBack="True" OnSelectedIndexChanged="cmbItemSearch_SelectedIndexChanged"  filter="Contains" Sort="Ascending" Width="400px" ItemsPerRequest="15" MarkFirstMatch="True">
                                                                                    </telerik:RadComboBox>

                                                                        </td>
                                                                        <td class="auto-style9"></td>
                                                                        <td class="auto-style99" colspan="2"></td>
                                                                        <td class="auto-style9" colspan="2"></td>
                                                                        <td class="auto-style9" colspan="2"></td>

                                                                    </ContentTemplate>
                                                                </asp:UpdatePanel>

                                                            </tr>

                                                                <tr style="visibility: hidden">
                                                                <td class="auto-style82">&nbsp;</td>
                                                                <td class="auto-style82" colspan="3" style="visibility: hidden">Category</td>
                                                                <td colspan="2" class="auto-style88" style="visibility: hidden">
                                                                    <telerik:RadComboBox ID="cmbCatagories" runat="server" AutoPostBack="True" OnSelectedIndexChanged="cmbCatagories_SelectedIndexChanged" Sort="Ascending" Width="300px" Visible="False">
                                                                    </telerik:RadComboBox>
                                                                </td>
                                                                <td class="auto-style9" style="visibility: hidden">&nbsp;</td>
                                                                <td class="auto-style99" colspan="2" style="visibility: hidden">&nbsp;</td>
                                                                <td colspan="2" style="visibility: hidden">&nbsp;</td>
                                                                <td class="auto-style9" colspan="2">&nbsp;</td>
                                                            </tr>




                                                            <tr style="visibility: hidden">
                                                                <td class="auto-style82">&nbsp;</td>
                                                                <td class="auto-style82" colspan="3" style="visibility: hidden">Sub. Category</td>
                                                                <td colspan="2" style="visibility: hidden">
                                                                    <telerik:RadComboBox ID="cmbSubCategory" runat="server" AutoPostBack="True" MarkFirstMatch="True" OnSelectedIndexChanged="cmbSubCategory_SelectedIndexChanged" Sort="Ascending" TabIndex="10" Width="300px" Visible="False">
                                                                    </telerik:RadComboBox>
                                                                </td>
                                                                <td class="auto-style9" style="visibility: hidden">&nbsp;</td>
                                                                <td class="auto-style99" colspan="2" style="visibility: hidden">&nbsp;</td>
                                                                <td class="auto-style86" colspan="2" style="visibility: hidden">&nbsp;</td>
                                                                <td class="auto-style9" colspan="2">&nbsp;</td>
                                                            </tr>
                                                            <tr style="visibility: hidden">
                                                                <td class="auto-style82">&nbsp;</td>
                                                                <td class="auto-style82" colspan="3" style="visibility: hidden">Item Head</td>
                                                                <td colspan="2" style="visibility: hidden">
                                                                    <telerik:RadComboBox ID="cmbItemHead" runat="server" AutoPostBack="True" MarkFirstMatch="True" MaxHeight="150px" Sort="Ascending" Width="300px" OnSelectedIndexChanged="cmbItemHead_SelectedIndexChanged" TabIndex="11" Visible="False">
                                                                    </telerik:RadComboBox>
                                                                </td>
                                                                <td class="auto-style9" style="visibility: hidden">&nbsp;</td>
                                                                <td class="auto-style99" colspan="2" style="visibility: hidden">&nbsp;</td>
                                                                <td class="auto-style86" colspan="2" style="visibility: hidden">&nbsp;</td>
                                                                <td class="auto-style9" colspan="2">&nbsp;</td>
                                                            </tr>

                                                        
                                                          
                                                            <tr>
                                                                <td class="auto-style82" style="visibility: hidden">&nbsp;</td>
                                                                <td class="auto-style82" style="visibility: hidden" colspan="3">Item Name</td>
                                                                <td colspan="2" style="visibility: hidden">
                                                                    <telerik:RadComboBox ID="cmbItem" runat="server" AutoPostBack="True" MarkFirstMatch="True" MaxHeight="200px" Sort="Ascending" Width="300px">
                                                                    </telerik:RadComboBox>
                                                                </td>
                                                                <td class="auto-style9" style="visibility: hidden">
                                                                    <asp:RequiredFieldValidator ID="RequiredFieldValidator6" runat="server" ControlToValidate="cmbItem" ErrorMessage="*" ForeColor="Red" InitialValue="Choose Item" ValidationGroup="A"></asp:RequiredFieldValidator>
                                                                </td>
                                                                <td colspan="2" class="auto-style99" style="visibility: hidden">
                                                                    <telerik:RadButton ID="btnSubmit" runat="server" ButtonType="SkinnedButton" Font-Size="10pt" Height="30px" OnClick="btnSubmit_Click" Style="text-align: center" Text="Add Item" ValidationGroup="A" Visible="False" Width="65px">
                                                                    </telerik:RadButton>
                                                                </td>
                                                                <td class="auto-style86" colspan="2" style="visibility: hidden"></td>
                                                                <td colspan="2" class="auto-style9" style="visibility: hidden"></td>
                                                            </tr>
                                                            <tr>
                                                                <td class="auto-style95">&nbsp;</td>
                                                                <td class="auto-style95" colspan="3">Acknowledgment Time</td>
                                                                <td class="auto-style89" colspan="2">
                                                                    <asp:TextBox ID="rdackdate" runat="server"></asp:TextBox>
                                                                    <asp:CalendarExtender ID="rdackdate_CalendarExtender" runat="server" Enabled="True" TargetControlID="rdackdate">
                                                                    </asp:CalendarExtender>
                                                                    <asp:RequiredFieldValidator ID="RequiredFieldValidator8" runat="server" ControlToValidate="rdackdate" ErrorMessage="*" ForeColor="Red" ValidationGroup="A"></asp:RequiredFieldValidator>
                                                                </td>
                                                                <td>&nbsp;</td>
                                                                <td colspan="2" class="auto-style98">&nbsp;</td>
                                                                <td class="auto-style85" colspan="2">GIN No To Confirm:&nbsp;
                                                            <asp:TextBox ID="txtGINConfirm" runat="server" BorderColor="#000066" BorderWidth="1px" Height="20px" TabIndex="20" Width="58px">0</asp:TextBox>
                                                                    &nbsp;
                                                            <telerik:RadButton ID="btnIssueConfirm" runat="server" ButtonType="SkinnedButton" Font-Size="10pt" Height="30px" OnClick="btnIssueConfirm_Click" Style="text-align: center; font-weight: 700; font-style: italic; margin-bottom: 2px;" Text="Confirm" ValidationGroup="A" Width="66px">
                                                            </telerik:RadButton>
                                                                </td>
                                                                <td colspan="2">&nbsp;</td>
                                                            </tr>
                                                            <tr>
                                                                <td class="auto-style95">&nbsp;</td>
                                                                <td class="auto-style95" colspan="3">
                                                                    <asp:Label ID="lblreceievedate" runat="server" Text="Return Date" Visible="False"></asp:Label>
                                                                </td>
                                                                <td class="auto-style89" colspan="2">
                                                                    <asp:TextBox ID="rdReturndate" runat="server"></asp:TextBox>
                                                                    <asp:CalendarExtender ID="rdReturndate_CalendarExtender" runat="server" Enabled="True" TargetControlID="rdReturndate">
                                                                    </asp:CalendarExtender>
                                                                    <asp:RequiredFieldValidator ID="RequiredFieldValidator9" runat="server" ControlToValidate="rdReturndate" Enabled="False" ErrorMessage="*" ForeColor="Red" ValidationGroup="A"></asp:RequiredFieldValidator>
                                                                    &nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;
                                                                </td>
                                                                <td>&nbsp;</td>
                                                                <td class="auto-style98" colspan="2">&nbsp;</td>
                                                                <td class="auto-style85" colspan="2">&nbsp;</td>
                                                                <td colspan="2">&nbsp;</td>
                                                            </tr>
                                                            <tr>
                                                                <td class="auto-style96">&nbsp;</td>
                                                                <td class="auto-style96" colspan="3"></td>
                                                                <td class="auto-style91" colspan="2">
                                                                    <asp:ValidationSummary ID="ValidationSummary1" runat="server" HeaderText="Remaining Fields" Height="48px" ShowMessageBox="True" ShowSummary="False" />
                                                                </td>
                                                                <td class="auto-style90">&nbsp;</td>
                                                                <td colspan="2" class="auto-style100"></td>
                                                                <td class="auto-style90" colspan="2">G.I.N. Number&nbsp;&nbsp;&nbsp;&nbsp;&nbsp; :
                                                            <asp:TextBox ID="txtginno" runat="server" BorderColor="#000066" BorderWidth="1px" Enabled="False" Height="20px" onkeydown="addItem(event);" Style="font-size: x-small" TabIndex="5" Width="75px"></asp:TextBox>
                                                                    &nbsp;<a href="ReportsMain.aspx?rptname=GoodsIssueNote&amp;gino=<%= txtginno.Text %>" target="_blank">Print</a><br />
                                                                    <br />
                                                                    Gate Pass Number:<asp:TextBox ID="txtgpno" runat="server" BorderColor="#000066" BorderWidth="1px" Enabled="False" Height="20px" onkeydown="addItem(event);" Style="font-size: x-small" TabIndex="5" Width="75px"></asp:TextBox>
                                                                    &nbsp;<a href="ReportsMain.aspx?rptname=GatePass&amp;gpno=<%= txtgpno.Text %>" target="_blank">Print</a></td>
                                                                <td colspan="2" class="auto-style90"></td>
                                                            </tr>
                                                            <tr>
                                                                <td class="auto-style95">&nbsp;</td>
                                                                <td class="auto-style95" colspan="3">&nbsp;</td>
                                                                <td class="auto-style89" colspan="2">&nbsp;</td>
                                                                <td>&nbsp;</td>
                                                                <td class="auto-style98" colspan="2">&nbsp;</td>
                                                                <td class="auto-style85" colspan="2">&nbsp;</td>
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
                                                                <td style="width: 350px; text-align: center;" valign="middle" align="center">&nbsp;</td>
                                                                 <td align="center" colspan="12" style="width: 350px;" valign="middle">
                                                                    Remarks :&nbsp; 
                                                                    <asp:TextBox ID="txtremarks" runat="server" BorderColor="#000066" BorderWidth="1px" Height="20px" style="font-size: x-small" TabIndex="5" Width="861px"></asp:TextBox>
                                                                </td>
                                                            </tr>
                                                            <tr>
                                                                <td style="width: 350px; text-align: center;" valign="middle" align="center">&nbsp;</td>
                                                                 <td align="center" colspan="12" style="width: 350px;" valign="middle">&nbsp;</td>
                                                            </tr>
                                                            <tr>
                                                                <td class="auto-style97" style="text-align: center;" valign="middle">&nbsp;</td>
                                                                <td class="auto-style97" style="text-align: center;" valign="middle">&nbsp;</td>
                                                                <td class="auto-style97" style="text-align: center;" valign="middle">&nbsp;</td>
                                                                <td class="auto-style81" colspan="2" style="width: 350px; text-align: center;" valign="middle">&nbsp;</td>
                                                                <td class="auto-style81" colspan="3" style="width: 350px; text-align: right;" valign="middle">&nbsp;</td>
                                                                <td class="auto-style81" colspan="2" style="width: 350px; text-align: right;" valign="middle">
                                                                    <asp:CheckBox ID="chkConfirmIssue" runat="server" OnCheckedChanged="chkConfirmIssue_CheckedChanged" Style="font-size: large" Text="Confirm Issued" TextAlign="Left" Width="150px" />
                                                                </td>
                                                                <td class="auto-style81" colspan="2" style="width: 350px; text-align: center;" valign="middle">
                                                                    <telerik:RadButton ID="btnSubmitItem" runat="server" ButtonType="SkinnedButton" Font-Size="10pt" Height="30px" OnClick="btnSubmitItem_Click" Style="text-align: center; font-weight: 700; font-style: italic" Text="Save GIN" ValidationGroup="A" Width="99px" UseSubmitBehavior="False">
                                                                    </telerik:RadButton>
                                                                </td>
                                                                <td class="auto-style81" style="width: 350px; text-align: center;" valign="middle">&nbsp;</td>
                                                            </tr>
                                                            <tr>
                                                                <td class="auto-style97" style="text-align: center;" valign="middle">&nbsp;</td>
                                                                <td class="auto-style97" style="text-align: center;" valign="middle">&nbsp;</td>
                                                                <td class="auto-style97" style="text-align: center;" valign="middle">&nbsp;</td>
                                                                <td class="auto-style81" colspan="2" style="width: 350px; text-align: left;" valign="middle">&nbsp;</td>
                                                                <td class="auto-style81" colspan="3" style="width: 350px; text-align: center;" valign="middle">Enter OLD GIN # To move Items</td>
                                                                <td class="auto-style81" colspan="2" style="width: 350px; text-align: left;" valign="middle">&nbsp;</td>
                                                                <td class="auto-style81" colspan="2" style="width: 350px; text-align: center;" valign="middle">&nbsp;</td>
                                                                <td class="auto-style81" style="width: 350px; text-align: center;" valign="middle">&nbsp;</td>
                                                            </tr>
                                                            <tr>
                                                                <td class="auto-style97" style="text-align: center;" valign="middle">&nbsp;</td>
                                                                <td class="auto-style97" style="text-align: center;" valign="middle">&nbsp;</td>
                                                                <td class="auto-style97" style="text-align: center;" valign="middle">&nbsp;</td>
                                                                <td class="auto-style81" colspan="2" style="width: 350px; text-align: left;" valign="middle">&nbsp;</td>
                                                                <td class="auto-style81" colspan="3" style="width: 350px; text-align: center;" valign="middle">
                                                                    <telerik:RadButton ID="btnOldGIN" runat="server" ButtonType="SkinnedButton" Font-Size="10pt" Height="30px" OnClick="btnOldGIN_Click" TabIndex="19" Text="Save In OLD GIN" ValidationGroup="A" Width="150px">
                                                                    </telerik:RadButton>
                                                                    <asp:TextBox ID="txtoldGIN" runat="server" BorderColor="#000066" BorderWidth="1px" Height="20px" TabIndex="20" Visible="False" Width="83px">0</asp:TextBox>
                                                                </td>
                                                                <td class="auto-style81" colspan="2" style="width: 350px; text-align: left;" valign="middle">&nbsp;</td>
                                                                <td class="auto-style81" colspan="2" style="width: 350px; text-align: center;" valign="middle">&nbsp;</td>
                                                                <td class="auto-style81" style="width: 350px; text-align: center;" valign="middle">&nbsp;</td>
                                                            </tr>
                                                            <tr>
                                                                <td class="auto-style97" style="text-align: center;" valign="middle">&nbsp;</td>
                                                                <td class="auto-style97" style="text-align: center;" valign="middle">&nbsp;</td>
                                                                <td class="auto-style97" style="text-align: center;" valign="middle">&nbsp;</td>
                                                                <td class="auto-style81" colspan="2" style="width: 350px; text-align: left;" valign="middle">&nbsp;</td>
                                                                <td class="auto-style81" colspan="3" style="width: 350px; text-align: center;" valign="middle">&nbsp;</td>
                                                                <td class="auto-style81" colspan="2" style="width: 350px; text-align: left;" valign="middle">&nbsp;</td>
                                                                <td class="auto-style81" colspan="2" style="width: 350px; text-align: center;" valign="middle">&nbsp;</td>
                                                                <td class="auto-style81" style="width: 350px; text-align: center;" valign="middle">&nbsp;</td>
                                                            </tr>
                                                            <tr>
                                                                <td class="auto-style97" style="text-align: left;" valign="middle">&nbsp;</td>
                                                                <td class="auto-style97" style="text-align: left;" valign="middle">&nbsp;</td>
                                                                <td class="auto-style97" style="text-align: left;" valign="middle">&nbsp;</td>
                                                                <td class="auto-style81" colspan="2" style="width: 350px; text-align: left;" valign="middle">&nbsp;</td>
                                                                <td class="auto-style81" colspan="3" style="width: 350px; text-align: left;" valign="middle">&nbsp;</td>
                                                                <td class="auto-style81" colspan="2" style="width: 350px; text-align: right;" valign="middle">&nbsp;</td>
                                                                <td class="auto-style81" colspan="2" style="width: 350px; text-align: center;" valign="middle">&nbsp;</td>
                                                                <td class="auto-style81" style="width: 350px; text-align: center;" valign="middle">&nbsp;</td>
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
                                    </telerik:RadAjaxPanel>
                                </td>

                            </ContentTemplate>
                        </asp:UpdatePanel>
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
                        <td class="auto-style105">&nbsp;</td>
                        <td class="auto-style26">&nbsp;</td>
                        <td class="auto-style18">&nbsp;</td>
                        <td class="auto-style29">&nbsp;</td>
                        <td style="height: 30px; text-align: right;">&nbsp;</td>
                    </tr>
                    <tr>
                        <td class="auto-style22">&nbsp;</td>
                        <td class="auto-style26">
                            &nbsp;</td>
                        <td class="auto-style18">&nbsp;</td>
                        <td class="auto-style29">&nbsp;</td>
                        <td style="height: 30px; text-align: right;">&nbsp;</td>
                    </tr>
                    <tr>
                        <td class="auto-style106">&nbsp;</td>
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
