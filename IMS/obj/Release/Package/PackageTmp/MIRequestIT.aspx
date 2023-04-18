<%@ Page Title="" Language="C#" MasterPageFile="~/Site1.Master" AutoEventWireup="true" CodeBehind="MIRequestIT.aspx.cs" Inherits="IMS.MIRequestIT" %>

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
            width: 724px;
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
            width: 724px;
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
            width: 724px;
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

        .auto-style56 {
            width: 724px;
            font-family: Arial, Helvetica, sans-serif;
            font-size: xx-large;
            height: 55px;
            text-align: justify;
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
            text-align: left;
        }

        .auto-style90 {
            height: 43px;
        }

        .auto-style91 {
            width: 312px;
            height: 43px;
        }

        .auto-style92 {
            font-size: small;
        }

        .auto-style93 {
            height: 26px;
        }

        .auto-style94 {
            text-align: left;
            height: 26px;
        }

        .auto-style95 {
            width: 160px;
            height: 26px;
        }
        .auto-style96 {
            color: #333333;
            font-size: x-large;
        }
        .auto-style97 {
            width: 724px;
            height: 10px;
        }
        .auto-style98 {
            width: 724px;
        }
        .auto-style99 {
            font-family: Arial, Helvetica, sans-serif;
            font-size: medium;
            color: #C0C0C0;
            width: 724px;
        }
        .auto-style100 {
            width: 724px;
            font-family: Arial, Helvetica, sans-serif;
            font-size: medium;
            height: 31px;
        }
    </style>
    <link href="CSS/GridViewStyle1.css" rel="stylesheet" type="text/css" />
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">
    <telerik:RadCodeBlock ID="dfg" runat="server">
        <script type="text/javascript">
            

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
                        <td class="auto-style32" style="background-color: #F7F7F7; "></td>
                        <td class="auto-style61" style="background-color: #F7F7F7; height: 10px;"></td>
                        <td class="auto-style31" style="background-color: #F7F7F7; height: 10px;"></td>
                        <td class="auto-style27" style="background-color: #F7F7F7; height: 10px;"></td>
                        <td style="background-color: #F7F7F7; height: 10px;"></td>
                    </tr>
                    <tr>
                        <td class="auto-style56" style="background-color: #F7F7F7; ">
                            <img alt="" class="auto-style64" src="images/inv_isu.png" /><span class="auto-style96"><strong>I.T Material Issuing Request (MIR)</strong></span></td>
                        <td class="auto-style55" style="background-color: #F7F7F7">&nbsp;</td>
                        <td class="auto-style57" style="background-color: #F7F7F7"></td>
                        <td style="background-color: #F7F7F7; text-align: center;">&nbsp;</td>
                        <td class="auto-style59" style="background-color: #F7F7F7"></td>
                    </tr>
                    <tr>
                        <td class="auto-style97"></td>
                        <td class="auto-style13">&nbsp;</td>
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
                                                                <td class="auto-style81">&nbsp;</td>
                                                                <td class="auto-style89">&nbsp;</td>
                                                                <td>&nbsp;</td>
                                                                <td class="auto-style85">&nbsp;</td>
                                                                <td>&nbsp;</td>
                                                            </tr>
                                                            <tr>
                                                                <td class="auto-style81">&nbsp;</td>
                                                                <td class="auto-style89">&nbsp;</td>
                                                                <td>&nbsp;</td>
                                                                <td class="auto-style85">&nbsp;</td>
                                                                <td>&nbsp;</td>
                                                            </tr>
                                                            <tr>
                                                                <td class="auto-style81">Request To Store</td>
                                                                <td class="auto-style89">
                                                                    <telerik:RadComboBox ID="cmbStoreTo" runat="server" AutoPostBack="True" MarkFirstMatch="True" OnSelectedIndexChanged="cmbStoreTo_SelectedIndexChanged" Sort="Ascending" Width="300px">
                                                                    </telerik:RadComboBox>
                                                                    <asp:RequiredFieldValidator ID="RequiredFieldValidator7" runat="server" ControlToValidate="cmbStoreTo" ErrorMessage="*" ForeColor="Red" InitialValue="Choose Store" ValidationGroup="A"></asp:RequiredFieldValidator>
                                                                </td>
                                                                <td>Request By Store</td>
                                                                <td class="auto-style85">
                                                                    <telerik:RadComboBox ID="cmbStore" runat="server" AutoPostBack="True" MarkFirstMatch="True" OnSelectedIndexChanged="cmbStore_SelectedIndexChanged" Sort="Ascending" Width="300px">
                                                                    </telerik:RadComboBox>
                                                                </td>
                                                                <td>
                                                                    <asp:RequiredFieldValidator ID="RequiredFieldValidator3" runat="server" ControlToValidate="cmbStore" ErrorMessage="*" ForeColor="Red" InitialValue="Choose Branch" ValidationGroup="A"></asp:RequiredFieldValidator>
                                                                </td>
                                                            </tr>
                                                            <tr>
                                                                <td class="auto-style81">&nbsp;</td>
                                                                <td class="auto-style89">&nbsp;</td>
                                                                <td>&nbsp;</td>
                                                                <td class="auto-style85">&nbsp;</td>
                                                                <td>&nbsp;</td>
                                                            </tr>

                                                            <tr>
                                                                <td class="auto-style82">Request To Department</td>
                                                                <td class="auto-style88">
                                                                    <telerik:RadComboBox ID="cmbDepartmentto" runat="server" AutoPostBack="True" MarkFirstMatch="True" Sort="Ascending" Width="300px" OnSelectedIndexChanged="cmbDepartmentto_SelectedIndexChanged">
                                                                    </telerik:RadComboBox>
                                                                    <asp:RequiredFieldValidator ID="RequiredFieldValidator8" runat="server" ControlToValidate="cmbDepartmentto" ErrorMessage="*" ForeColor="Red" InitialValue="Choose Store" ValidationGroup="A"></asp:RequiredFieldValidator>
                                                                </td>
                                                                <td class="auto-style9">Department</td>
                                                                <td class="auto-style86">
                                                                    <telerik:RadComboBox ID="cmbDepartment" runat="server" AutoPostBack="True" MarkFirstMatch="True" Sort="Ascending" Width="300px" OnSelectedIndexChanged="cmbDepartment_SelectedIndexChanged">
                                                                    </telerik:RadComboBox>
                                                                </td>
                                                                <td class="auto-style9">
                                                                    <asp:RequiredFieldValidator ID="RequiredFieldValidator5" runat="server" ControlToValidate="cmbDepartment" ErrorMessage="*" ForeColor="Red" InitialValue="Choose Department" ValidationGroup="A"></asp:RequiredFieldValidator>
                                                                </td>
                                                            </tr>
                                                            <tr>
                                                                <td class="auto-style81">Request to Person</td>
                                                                <td class="auto-style89">
                                                                    <telerik:RadComboBox ID="cmbIssuedto" runat="server" AutoPostBack="True" MarkFirstMatch="True" Sort="Ascending" Width="300px">
                                                                    </telerik:RadComboBox>
                                                                </td>
                                                                <td>By Person</td>
                                                                <td class="auto-style85">
                                                                    <telerik:RadComboBox ID="cmbPerson" runat="server" AutoPostBack="True" MarkFirstMatch="True" Sort="Ascending" Width="300px">
                                                                    </telerik:RadComboBox>
                                                                </td>
                                                                <td>
                                                                    <asp:RequiredFieldValidator ID="RequiredFieldValidator9" runat="server" ControlToValidate="cmbPerson" ErrorMessage="*" ForeColor="Red" InitialValue="Choose Department" ValidationGroup="A"></asp:RequiredFieldValidator>
                                                                </td>
                                                            </tr>
                                                            <tr>
                                                                <td class="auto-style81">&nbsp;</td>
                                                                <td class="auto-style89">&nbsp;</td>
                                                                <td>&nbsp;</td>
                                                                <td class="auto-style85">&nbsp;</td>
                                                                <td>&nbsp;</td>
                                                            </tr>



                                                            <tr>
                                                                <td class="auto-style92">Get Items By Requisition:</td>
                                                                <td class="auto-style89" colspan="2">
                                                                    <asp:RadioButtonList ID="rdoReqID" runat="server" AutoPostBack="True" OnSelectedIndexChanged="rdoReqID_SelectedIndexChanged" RepeatDirection="Horizontal" Style="font-size: small" Width="427px" Font-Bold="True" ForeColor="Black">
                                                                        <asp:ListItem Value="R">Kitchen &amp; Regular</asp:ListItem>
                                                                        <asp:ListItem Value="A">Art Requisition</asp:ListItem>
                                                                        <asp:ListItem Value="P">Printed Material/Other</asp:ListItem>
                                                                        <asp:ListItem Value="S">Syllabus</asp:ListItem>
                                                                        <asp:ListItem Value="M">Manual MIR</asp:ListItem>
                                                                    </asp:RadioButtonList>
                                                                </td>
                                                                <td>
                                                                    <asp:TextBox ID="txtreqid" runat="server" BorderColor="#000066" BorderWidth="1px" Height="20px" onkeydown="addItem(event);" ReadOnly="True" Style="font-size: medium; font-weight: 700; text-align: center; color: #009933;" TabIndex="5" Width="75px"></asp:TextBox>
                                                                    &nbsp;&nbsp;&nbsp;&nbsp;&nbsp;<asp:Button ID="btnGetItems" runat="server" OnClick="btnGetItems_Click" Text="Get Items" Width="93px" />
                                                                </td>
                                                                <td>&nbsp;</td>
                                                            </tr>

                                                            <tr>
                                                                <td class="auto-style92">&nbsp;</td>
                                                                <td class="auto-style89">&nbsp;
                                                                </td>
                                                                <td>&nbsp;</td>
                                                                <td class="auto-style85">&nbsp;</td>
                                                                <td>&nbsp;</td>
                                                            </tr>

                                                            <tr>
                                                                <td align="center" colspan="5" style="font-family: Calibri; color: #999999; font-weight: normal; font-size: 14px;" valign="top">
                                                                    <div id="mirdiv" style="display: none" runat="server">
                                                                        <table cellspacing="1" style="width: 100%" align="center">

                                                                            <tr>
                                                                                <td class="auto-style81">&nbsp;</td>
                                                                                <td class="auto-style89">&nbsp;</td>
                                                                                <td>&nbsp;</td>
                                                                                <td class="auto-style85">&nbsp;</td>
                                                                                <td>&nbsp;</td>
                                                                            </tr>



                                                                            <tr>

                                                                                 <asp:UpdatePanel ID="UpdatePanel2" runat="server" UpdateMode="Conditional" ChildrenAsTriggers="false">
                                                                                 <ContentTemplate>



                                                                                <td class="auto-style9">Search Item</td>
                                                                                <td class="auto-style88">
                                                                               <%--     <telerik:RadComboBox ID="cmbItemSearch" runat="server" AutoPostBack="True" OnSelectedIndexChanged="cmbItemSearch_SelectedIndexChanged" Sort="Ascending" Width="400px" ItemsPerRequest="15" MarkFirstMatch="True">
                                                                                    </telerik:RadComboBox>--%>

                                                                                 <telerik:RadComboBox ID="cmbItemSearch" Runat="server" AutoPostBack="True" MarkFirstMatch="True" Sort="Ascending" Width="400px" 
                                                                                                         CheckBoxes="true" EnableCheckAllItemsCheckBox="true">
                                                                                                    </telerik:RadComboBox>
                                                                             

                                                                                </td>
                                                                                <td class="auto-style9">&nbsp;
                                                                                       <asp:Literal ID="itemsClientSide" runat="server"></asp:Literal>
                                                                                        <asp:Label ID="lblItems" runat="server" Text="Items List" Visible="False"></asp:Label>
                                                                                        <asp:Label ID="lblItemID" runat="server" Text="ItemID" Visible="False"></asp:Label>

                                                                                </td>
                                                                                <td>&nbsp;</td>
                                                                                <td class="auto-style9">&nbsp;


                                                                                </td>

                                                                                      </ContentTemplate>
                                                                              </asp:UpdatePanel>

                                                                            </tr>



                                                                            <tr>
                                                                                <td class="auto-style9" style="visibility: hidden">Category</td>
                                                                                <td class="auto-style88" style="visibility: hidden">
                                                                                    <telerik:RadComboBox ID="cmbCatagories" runat="server" AutoPostBack="True" OnSelectedIndexChanged="cmbCatagories_SelectedIndexChanged" Sort="Ascending" Width="300px">
                                                                                    </telerik:RadComboBox>
                                                                                </td>
                                                                                <td class="auto-style9" style="visibility: hidden">&nbsp;</td>
                                                                                <td>&nbsp;</td>
                                                                                <td class="auto-style9" style="visibility: hidden">&nbsp;</td>
                                                                            </tr>
                                                                            <tr>
                                                                                <td class="auto-style9" style="visibility: hidden">Sub. Category</td>
                                                                                <td class="auto-style88" style="visibility: hidden">
                                                                                    <telerik:RadComboBox ID="cmbSubCateg" runat="server" AutoPostBack="True" OnSelectedIndexChanged="cmbSubCateg_SelectedIndexChanged" Sort="Ascending" Width="300px">
                                                                                    </telerik:RadComboBox>
                                                                                </td>
                                                                                <td class="auto-style9" style="visibility: hidden">&nbsp;</td>
                                                                                <td class="auto-style86" style="visibility: hidden">&nbsp;</td>
                                                                                <td class="auto-style9" style="visibility: hidden">&nbsp;</td>
                                                                            </tr>
                                                                            <tr>
                                                                                <td class="auto-style9" style="visibility: hidden">Item Head</td>
                                                                                <td class="auto-style88" style="visibility: hidden">
                                                                                    <telerik:RadComboBox ID="cmbItemHead" runat="server" AutoPostBack="True" OnSelectedIndexChanged="cmbItemHead_SelectedIndexChanged" Sort="Ascending" Width="300px">
                                                                                    </telerik:RadComboBox>
                                                                                </td>
                                                                                <td class="auto-style9" style="visibility: hidden">&nbsp;</td>
                                                                                <td class="auto-style86" style="visibility: hidden">&nbsp;</td>
                                                                                <td class="auto-style9" style="visibility: hidden">&nbsp;</td>
                                                                            </tr>
                                                                            <tr>
                                                                                <td class="auto-style9" style="visibility: hidden">Item Name</td>
                                                                                <td class="auto-style88" style="visibility: hidden">
                                                                                    <telerik:RadComboBox ID="cmbItem" runat="server" AutoPostBack="True" MarkFirstMatch="True" Sort="Ascending" Width="300px">
                                                                                    </telerik:RadComboBox>
                                                                                    <asp:RequiredFieldValidator ID="RequiredFieldValidator6" runat="server" ControlToValidate="cmbItem" ErrorMessage="*" ForeColor="Red" InitialValue="Choose Item" ValidationGroup="A"></asp:RequiredFieldValidator>
                                                                                </td>
                                                                                <td class="auto-style9">
                                                                                    <telerik:RadButton ID="btnAddItem" runat="server" ButtonType="SkinnedButton" Font-Size="10pt" Height="30px" OnClick="btnAddItem_Click" Text="Add Item">
                                                                                    </telerik:RadButton>
                                                                                </td>
                                                                                <td class="auto-style86" style="visibility: hidden"></td>
                                                                                <td class="auto-style9" style="visibility: hidden"></td>
                                                                            </tr>
                                                                            <tr>
                                                                                <td class="auto-style82">&nbsp;</td>
                                                                                <td class="auto-style88">&nbsp;</td>
                                                                                <td class="auto-style9">&nbsp;</td>
                                                                                <td class="auto-style86">&nbsp;</td>
                                                                                <td class="auto-style9">&nbsp;</td>
                                                                            </tr>

                                                                        </table>
                                                                    </div>
                                                                </td>
                                                            </tr>

                                                            <tr>
                                                                <td class="auto-style93">Acknowledgment Time</td>
                                                                <td class="auto-style94">
                                                                    <asp:TextBox ID="rdackdate" runat="server"></asp:TextBox>
                                                                    <asp:CalendarExtender ID="rdackdate_CalendarExtender" runat="server" Enabled="True" TargetControlID="rdackdate">
                                                                    </asp:CalendarExtender>
                                                                </td>
                                                                <td class="auto-style93"></td>
                                                                <td class="auto-style95"></td>
                                                                <td class="auto-style93"></td>
                                                            </tr>
                                                            <tr>
                                                                <td class="auto-style90">&nbsp;</td>
                                                                <td class="auto-style91">&nbsp;&nbsp;
                                                                </td>
                                                                <td class="auto-style90"></td>
                                                                <td class="auto-style90">M.I.R No:
                                                    <asp:TextBox ID="txtmirno" runat="server" BorderColor="#000066" BorderWidth="1px" Enabled="False" Height="20px" onkeydown="addItem(event);" Style="font-size: x-small" TabIndex="5" Width="75px"></asp:TextBox>
                                                                    &nbsp;<a href="ReportsMain.aspx?rptname=MaterialIssueRequest&amp;mirno=<%= txtmirno.Text %>" target="_blank">Print</a><br />

                                                                </td>
                                                                <td class="auto-style90"></td>
                                                            </tr>
                                                            <tr>
                                                                <td class="auto-style81">&nbsp;</td>
                                                                <td class="auto-style89">&nbsp;</td>
                                                                <td>&nbsp;</td>
                                                                <td class="auto-style85">&nbsp;</td>
                                                                <td>&nbsp;</td>
                                                            </tr>
                                                            <tr>

                                                                <asp:UpdatePanel ID="UpdatePanel3" runat="server" UpdateMode="Conditional" ChildrenAsTriggers="false">
                                                                    <ContentTemplate>

                                                                <td colspan="5" style="width: 350px; text-align: left;" align="center">
                                                                    <asp:GridView ID="grdItems" runat="server" AlternatingRowStyle-CssClass="alt" AutoGenerateColumns="False" CssClass="mGrid" OnRowCommand="grdItems_RowCommand" OnRowDeleting="grdItems_RowDeleting" OnRowEditing="grdItems_RowEditing" OnRowUpdating="grdItems_RowUpdating" PagerStyle-CssClass="pgr" Style="font-size: x-small; text-align: left;" Width="865px" OnRowDataBound="grdItems_RowDataBound">
                                                                        <AlternatingRowStyle CssClass="alt" />
                                                                        <Columns>
                                                                            <asp:CommandField ShowDeleteButton="True">
                                                                                <ControlStyle Width="10px" />
                                                                                <ItemStyle HorizontalAlign="Left" VerticalAlign="Middle" Width="10px" />
                                                                            </asp:CommandField>

                                                                             <asp:TemplateField HeaderText="ItemID" Visible="false">
                                                                             <ItemTemplate>
                                                                                  <asp:Label ID="lblItemID" runat="server" Text='<%#Eval("Item Code") %>' Width="50px" />
                                                                             </ItemTemplate>    
                                                                             </asp:TemplateField>


                                                                            <asp:BoundField DataField="Item Code" HeaderText="Item Code">
                                                                                <ControlStyle Width="10px" />
                                                                                <HeaderStyle Font-Size="12pt" HorizontalAlign="Center" />
                                                                                <ItemStyle HorizontalAlign="Center" VerticalAlign="Middle" Width="10px" />
                                                                            </asp:BoundField>
                                                                            <asp:BoundField DataField="Item Name" HeaderText="Item Name">
                                                                                <ControlStyle Width="150px" />
                                                                                <HeaderStyle Font-Size="12pt" HorizontalAlign="Center" />
                                                                                <ItemStyle HorizontalAlign="Left" VerticalAlign="Middle" Width="150px" />
                                                                            </asp:BoundField>
                                                                            <asp:BoundField DataField="Balance" HeaderText="Balance">
                                                                                <ControlStyle Width="10px" />
                                                                                <HeaderStyle Font-Size="12pt" HorizontalAlign="Center" />
                                                                                <ItemStyle HorizontalAlign="Center" VerticalAlign="Middle" Width="10px" />
                                                                            </asp:BoundField>
                                                                            <asp:TemplateField HeaderText="Qtty Request">
                                                                                <ItemTemplate>
                                                                                  <%--  <asp:TextBox ID="txtqty" runat="server" AutoPostBack="True" OnTextChanged="txtqty_TextChanged" Text='<%#Eval("Qtty Request") %>' Width="50px"></asp:TextBox>--%>
                                                                                  
                                                                                  <asp:TextBox ID="txtqty" runat="server" AutoPostBack="false" autocomplete="off" OnTextChanged="txtqty_TextChanged" Text='<%#Eval("Qtty Request") %>' onclick="GridRowNo(<%# Container.DataItemIndex %>,this);" Width="50px"></asp:TextBox>

                                                                                </ItemTemplate>
                                                                                <ControlStyle Width="30px" />
                                                                                <HeaderStyle Font-Size="12pt" HorizontalAlign="Center" />
                                                                                <ItemStyle HorizontalAlign="Center" VerticalAlign="Middle" Width="30px" />
                                                                            </asp:TemplateField>
                                                                        </Columns>
                                                                        <PagerStyle CssClass="pgr" />
                                                                    </asp:GridView>
                                                                </td>
                                                            
                                                                 </ContentTemplate>
                                                                </asp:UpdatePanel>                                                                        
                                                                        
                                                             </tr>
                                                            <tr>
                                                                <td class="auto-style77" colspan="2">&nbsp;</td>
                                                                <td class="auto-style77">&nbsp;</td>
                                                                <td class="auto-style85">&nbsp;</td>
                                                                <td class="auto-style77">&nbsp;</td>
                                                            </tr>
                                                            <tr>
                                                                <td class="auto-style81">
                                                                    <telerik:RadButton ID="btnOldMIR" runat="server" ButtonType="SkinnedButton" Font-Size="10pt" Height="30px" OnClick="btnOldMIR_Click" TabIndex="19" Text="OLD MIR Entry" ValidationGroup="A" Width="100px">
                                                                    </telerik:RadButton>
                                                                </td>
                                                                <td class="auto-style89">OLD MIR Number:
                                                    <asp:TextBox ID="txtoldMIR" runat="server" BorderColor="#000066" BorderWidth="1px" Height="20px" TabIndex="20" Visible="False" Width="52px">0</asp:TextBox>
                                                                </td>
                                                                <td>
                                                                    <telerik:RadButton ID="btnSubmit" runat="server" ButtonType="SkinnedButton" Font-Size="10pt" Height="30px" OnClick="btnSubmit_Click" Text="Save MIR" ValidationGroup="A" Style="text-align: center; font-weight: 700; font-style: italic" Width="99px">
                                                                    </telerik:RadButton>
                                                                </td>
                                                                <td class="auto-style85">
                                                                    <telerik:RadButton ID="btnSend" runat="server" ButtonType="SkinnedButton" Font-Size="10pt" Height="30px" OnClick="btnSend_Click" Style="text-align: center; font-weight: 700; font-style: italic" Text="Send MIR" ValidationGroup="A" Width="99px">
                                                                    </telerik:RadButton>
                                                                </td>
                                                                <td>&nbsp;</td>
                                                            </tr>
                                                            <tr>
                                                                <td class="auto-style81">&nbsp;</td>
                                                                <td class="auto-style89">&nbsp;</td>
                                                                <td>&nbsp;</td>
                                                                <td class="auto-style85">&nbsp;</td>
                                                                <td>&nbsp;</td>
                                                            </tr>
                                                        </table>
                                                    </asp:Panel>
                                                </td>
                                            </tr>
                                            <tr>
                                                <td class="auto-style75">
                                                    <telerik:RadSlider ID="RadSlider1" runat="server">
                                                    </telerik:RadSlider>
                                                </td>
                                                <td class="auto-style68">&nbsp;</td>
                                                <td class="auto-style67">&nbsp;
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
                        <td class="auto-style29">&nbsp;</td>
                    </tr>
                    <tr>
                        <td class="auto-style99">&nbsp;</td>
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
                        <td class="auto-style100">&nbsp;</td>
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
