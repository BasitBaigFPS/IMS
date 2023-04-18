<%@ Page Title="" Language="C#" MasterPageFile="~/Site1.Master" AutoEventWireup="true" CodeBehind="RecvInventory.aspx.cs" Inherits="IMS.RecvInventory" %>
<%@ Register assembly="AjaxControlToolkit" namespace="AjaxControlToolkit" tagprefix="asp" %>
<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
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
        .auto-style55 {
        width: 300px;
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
    .RadComboBox_Default{color:#333;font:normal 12px/16px "Segoe UI",Arial,Helvetica,sans-serif}.RadComboBox{margin:0;padding:0;*zoom:1;display:-moz-inline-stack;display:inline-block;*display:inline;text-align:left;vertical-align:middle;_vertical-align:top;white-space:nowrap}.RadComboBox_Default .rcbReadOnly .rcbInputCellLeft{background-position:0 -88px}.RadComboBox_Default .rcbInputCellLeft{background-position:0 0}.RadComboBox_Default .rcbInputCell{background-image:url('mvwres://Telerik.Web.UI, Version=2013.3.1015.45, Culture=neutral, PublicKeyToken=121fae78165ba3d4/Telerik.Web.UI.Skins.Default.Common.radFormSprite.png');_background-image:url('mvwres://Telerik.Web.UI, Version=2013.3.1015.45, Culture=neutral, PublicKeyToken=121fae78165ba3d4/Telerik.Web.UI.Skins.Default.Common.radFormSpriteIE6.png')}.RadComboBox .rcbInputCell{width:100%;height:20px;_height:22px;line-height:20px;_line-height:22px;text-align:left;vertical-align:middle}.RadComboBox .rcbInputCell{margin:0;padding:0;background-color:transparent;background-repeat:no-repeat;*zoom:1}.RadComboBox_Default .rcbReadOnly .rcbInput{color:#333}.RadComboBox .rcbReadOnly .rcbInput{cursor:default}.RadComboBox_Default .rcbInput{color:#333;font:normal 12px "Segoe UI",Arial,Helvetica,sans-serif;line-height:16px}.RadComboBox .rcbInput{margin:0;padding:0;border:0;background:0;padding:2px 0 1px;_padding:2px 0 0;width:100%;_height:18px;outline:0;vertical-align:middle;-webkit-appearance:none}.RadComboBox_Default .rcbReadOnly .rcbArrowCellRight{background-position:-162px -176px}.RadComboBox_Default .rcbArrowCellRight{background-position:-18px -176px}.RadComboBox_Default .rcbArrowCell{background-image:url('mvwres://Telerik.Web.UI, Version=2013.3.1015.45, Culture=neutral, PublicKeyToken=121fae78165ba3d4/Telerik.Web.UI.Skins.Default.Common.radFormSprite.png');_background-image:url('mvwres://Telerik.Web.UI, Version=2013.3.1015.45, Culture=neutral, PublicKeyToken=121fae78165ba3d4/Telerik.Web.UI.Skins.Default.Common.radFormSpriteIE6.png')}.RadComboBox .rcbArrowCell{width:18px}.RadComboBox .rcbArrowCell{margin:0;padding:0;background-color:transparent;background-repeat:no-repeat;*zoom:1}
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
            width: 312px;
        }
    </style>

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
                    <td class="auto-style32" style="background-color: #F7F7F7; height: 10px;"></td>
                    <td class="auto-style61" style="background-color: #F7F7F7; height: 10px;"></td>
                    <td class="auto-style31" style="background-color: #F7F7F7; height: 10px;"></td>
                    <td class="auto-style27" style="background-color: #F7F7F7; height: 10px;"></td>
                    <td style="background-color: #F7F7F7; height: 10px;"></td>
                </tr>
                <tr>
                    <td class="auto-style56" style="background-color: #F7F7F7; text-align: center;">
                        <img alt="" class="auto-style64" src="images/Items.png" /></td>
                    <td class="auto-style55" style="background-color: #F7F7F7"><strong>Issue Inventory</strong></td>
                    <td class="auto-style57" style="background-color: #F7F7F7"></td>
                    <td class="auto-style58" style="background-color: #F7F7F7"></td>
                    <td class="auto-style59" style="background-color: #F7F7F7"></td>
                </tr>
                <tr>
                    <td class="auto-style6"></td>
                    <td class="auto-style13">&nbsp;</td>
                    <td class="auto-style21">&nbsp;</td>
                    <td class="auto-style28">&nbsp;</td>
                    <td class="auto-style7">&nbsp;</td>
                </tr>
                <tr>
                    <td class="auto-style62" colspan="5"> <telerik:RadAjaxPanel ID="RadAjaxPanel2" runat="server" Width="950px" HorizontalAlign="NotSet" LoadingPanelID="RadAjaxLoadingPanel2" RenderMode="Inline">
                        <table class="auto-style66">
                            <tr>
                                <td colspan="4">
                                    <asp:Panel ID="Panel1" runat="server">
                                        <table class="auto-style66">
                                            <tr>
                                                <td class="auto-style81">&nbsp;</td>
                                                <td class="auto-style89">
                                                    Issued</td>
                                                <td>&nbsp;</td>
                                                <td class="auto-style85">Received</td>
                                                <td>&nbsp;</td>
                                            </tr>
                                            <tr>
                                                <td class="auto-style81">Issued from Branch</td>
                                                <td class="auto-style89">
                                                    <telerik:RadComboBox ID="cmbbranchfrom" Runat="server" AutoPostBack="True" MarkFirstMatch="True" OnSelectedIndexChanged="cmbbranchfrom_SelectedIndexChanged" Sort="Ascending" Width="300px">
                                                    </telerik:RadComboBox>
                                                    <asp:RequiredFieldValidator ID="RequiredFieldValidator1" runat="server" ControlToValidate="cmbbranchfrom" ErrorMessage="*" ForeColor="Red" InitialValue="Choose Branch" ValidationGroup="A"></asp:RequiredFieldValidator>
                                                </td>
                                                <td>Issued to Branch</td>
                                                <td class="auto-style85">
                                                    <telerik:RadComboBox ID="cmbBranchto" Runat="server" AutoPostBack="True" MarkFirstMatch="True" OnSelectedIndexChanged="cmbBranchto_SelectedIndexChanged" Sort="Ascending" Width="300px">
                                                    </telerik:RadComboBox>
                                                </td>
                                                <td>
                                                    <asp:RequiredFieldValidator ID="RequiredFieldValidator3" runat="server" ControlToValidate="cmbBranchto" ErrorMessage="*" ForeColor="Red" InitialValue="Choose Branch" ValidationGroup="A"></asp:RequiredFieldValidator>
                                                </td>
                                            </tr>
                                            <tr>
                                                <td class="auto-style81">Issued from&nbsp; Store</td>
                                                <td class="auto-style89">
                                                    <telerik:RadComboBox ID="cmbstorefrom" Runat="server" AutoPostBack="True" MarkFirstMatch="True" Sort="Ascending" Width="300px" OnSelectedIndexChanged="cmbstorefrom_SelectedIndexChanged">
                                                    </telerik:RadComboBox>
                                                    <asp:RequiredFieldValidator ID="RequiredFieldValidator2" runat="server" ControlToValidate="cmbstorefrom" ErrorMessage="*" ForeColor="Red" InitialValue="Choose Store" ValidationGroup="A"></asp:RequiredFieldValidator>
                                                </td>
                                                <td>Issued to Store</td>
                                                <td class="auto-style85">
                                                    <telerik:RadComboBox ID="cmbStoreto" Runat="server" AutoPostBack="True" MarkFirstMatch="True" Sort="Ascending" Width="300px">
                                                    </telerik:RadComboBox>
                                                </td>
                                                <td>
                                                    <asp:RequiredFieldValidator ID="RequiredFieldValidator4" runat="server" ControlToValidate="cmbStoreto" ErrorMessage="*" ForeColor="Red" InitialValue="Choose Store" ValidationGroup="A"></asp:RequiredFieldValidator>
                                                </td>
                                            </tr>
                                            <tr>
                                                <td class="auto-style82">&nbsp;</td>
                                                <td class="auto-style88">
                                                    &nbsp;</td>
                                                <td class="auto-style9">&nbsp;Deparement</td>
                                                <td class="auto-style86">
                                                    <telerik:RadComboBox ID="cmbDepartmentto" Runat="server" AutoPostBack="True" MarkFirstMatch="True" Sort="Ascending" Width="300px">
                                                    </telerik:RadComboBox>
                                                </td>
                                                <td class="auto-style9">
                                                    <asp:RequiredFieldValidator ID="RequiredFieldValidator5" runat="server" ControlToValidate="cmbDepartmentto" ErrorMessage="*" ForeColor="Red" InitialValue="Choose Department" ValidationGroup="A"></asp:RequiredFieldValidator>
                                                </td>
                                            </tr>
                                            <tr>
                                                <td class="auto-style81">Issued By</td>
                                                <td class="auto-style89">
                                                    <telerik:RadComboBox ID="cmbIssuedby" Runat="server" AutoPostBack="True" MarkFirstMatch="True" Sort="Ascending" Width="300px">
                                                    </telerik:RadComboBox>
                                                </td>
                                                <td>Issued to Person</td>
                                                <td class="auto-style85">
                                                    <telerik:RadComboBox ID="cmbPersonto" Runat="server" AutoPostBack="True" MarkFirstMatch="True" Sort="Ascending" Width="300px">
                                                    </telerik:RadComboBox>
                                                </td>
                                                <td>&nbsp;</td>
                                            </tr>
                                            <tr>
                                                <td class="auto-style81">&nbsp;</td>
                                                <td class="auto-style89">
                                                    &nbsp;</td>
                                                <td>&nbsp;</td>
                                                <td class="auto-style85">&nbsp;</td>
                                                <td>&nbsp;</td>
                                            </tr>
                                            <tr>
                                                <td class="auto-style9">Item Name</td>
                                                <td class="auto-style88">
                                                    <telerik:RadComboBox ID="cmbItem" Runat="server" AutoPostBack="True" MarkFirstMatch="True" Sort="Ascending" Width="300px">
                                                    </telerik:RadComboBox>
                                                    <asp:RequiredFieldValidator ID="RequiredFieldValidator6" runat="server" ControlToValidate="cmbItem" ErrorMessage="*" ForeColor="Red" InitialValue="Choose Item" ValidationGroup="A"></asp:RequiredFieldValidator>
                                                </td>
                                                <td class="auto-style9">&nbsp;</td>
                                                <td class="auto-style86"></td>
                                                <td class="auto-style9"></td>
                                            </tr>
                                            <tr>
                                                <td class="auto-style82">Issuing Type</td>
                                                <td class="auto-style88">
                                                    <telerik:RadComboBox ID="cmbIssueType" Runat="server" AutoPostBack="True" MarkFirstMatch="True" OnSelectedIndexChanged="cmbIssueType_SelectedIndexChanged" Sort="Ascending" Width="300px">
                                                        <Items>
                                                            <telerik:RadComboBoxItem runat="server" Selected="True" Text="Choose Type" Value="Choose Type" />
                                                            <telerik:RadComboBoxItem runat="server" Text="Permenant Issue" Value="P" />
                                                            <telerik:RadComboBoxItem runat="server" Text="Temporary Issue" Value="T" />
                                                        </Items>
                                                    </telerik:RadComboBox>
                                                    <asp:RequiredFieldValidator ID="RequiredFieldValidator7" runat="server" ControlToValidate="cmbIssueType" ErrorMessage="*" ForeColor="Red" InitialValue="Choose Type" ValidationGroup="A"></asp:RequiredFieldValidator>
                                                </td>
                                                <td class="auto-style9">&nbsp;</td>
                                                <td class="auto-style86">&nbsp;</td>
                                                <td class="auto-style9">&nbsp;</td>
                                            </tr>
                                            <tr>
                                                <td class="auto-style81">Acknowledgment Time</td>
                                                <td class="auto-style89">
                                                    <asp:TextBox ID="rdackdate" runat="server"></asp:TextBox>
                                                    <asp:CalendarExtender ID="rdackdate_CalendarExtender" runat="server" Enabled="True" TargetControlID="rdackdate">
                                                    </asp:CalendarExtender>
                                                    <asp:RequiredFieldValidator ID="RequiredFieldValidator8" runat="server" ControlToValidate="rdackdate" ErrorMessage="*" ForeColor="Red" ValidationGroup="A"></asp:RequiredFieldValidator>
                                                </td>
                                                <td>&nbsp;</td>
                                                <td class="auto-style85">&nbsp;</td>
                                                <td>&nbsp;</td>
                                            </tr>
                                            <tr>
                                                <td class="auto-style81">
                                                    <asp:Label ID="lblreceievedate" runat="server" Text="Return Date" Visible="False"></asp:Label>
                                                </td>
                                                <td class="auto-style89">
                                                    <asp:TextBox ID="rdReturndate" runat="server"></asp:TextBox>
                                                    <asp:CalendarExtender ID="rdReturndate_CalendarExtender" runat="server" Enabled="True" TargetControlID="rdReturndate">
                                                    </asp:CalendarExtender>
                                                    <asp:RequiredFieldValidator ID="RequiredFieldValidator9" runat="server" ControlToValidate="rdReturndate" Enabled="False" ErrorMessage="*" ForeColor="Red" ValidationGroup="A"></asp:RequiredFieldValidator>
                                                </td>
                                                <td>&nbsp;</td>
                                                <td class="auto-style85">&nbsp;</td>
                                                <td>&nbsp;</td>
                                            </tr>
                                            <tr>
                                                <td class="auto-style81">&nbsp;</td>
                                                <td class="auto-style89">
                                                    <asp:ValidationSummary ID="ValidationSummary1" runat="server" HeaderText="Remaining Fields" ShowMessageBox="True" ShowSummary="False" />
                                                </td>
                                                <td>&nbsp;</td>
                                                <td class="auto-style85">&nbsp;</td>
                                                <td>&nbsp;</td>
                                            </tr>
                                            <tr>
                                                <td class="auto-style81">&nbsp;</td>
                                                <td class="auto-style89">
                                                    <telerik:RadButton ID="btnSubmit" runat="server" ButtonType="SkinnedButton" Font-Size="10pt" Height="30px" OnClick="btnSubmit_Click" Text="Add Item" ValidationGroup="A">
                                                    </telerik:RadButton>
                                                </td>
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
                                                <td class="auto-style81" colspan="5" style="width: 350px">
                                                    <asp:GridView ID="grdItems" runat="server" AutoGenerateColumns="False" style="font-size: x-small" OnRowCommand="grdItems_RowCommand" OnRowDeleting="grdItems_RowDeleting" OnRowEditing="grdItems_RowEditing" OnRowUpdating="grdItems_RowUpdating">
                                                        <Columns>
                                                            <asp:CommandField ShowDeleteButton="True" />
                                                            <asp:BoundField DataField="Issue Store Name" HeaderText="Issue Store Name" />
                                                            <asp:BoundField DataField="Issue by Name" HeaderText="Issue by Name" />
                                                            <asp:BoundField DataField="Issue to Branch Name" HeaderText="Issue to Branch Name" />
                                                            <asp:BoundField DataField="Issue to Store Name" HeaderText="Issue to Store Name" />
                                                            <asp:BoundField DataField="Issue to Name" HeaderText="Issue to Name" />
                                                            <asp:BoundField DataField="Issue to Department" HeaderText="Issue to Department	" />
                                                            <asp:BoundField DataField="Item Name" HeaderText="Item Name" />
                                                            <asp:BoundField DataField="Item Type" HeaderText="Item Type" />
                                                            <asp:BoundField DataField="Balance" HeaderText="Balance" />
                                                            <asp:TemplateField HeaderText="Qty Issued">
                                                                <ItemTemplate>
                                                                    <asp:TextBox ID="txtqty" runat="server" Width="50px" Text =<%#Eval("Qty Issued") %> AutoPostBack="True" OnTextChanged="txtqty_TextChanged"></asp:TextBox>
                                                                </ItemTemplate>
                                                            </asp:TemplateField>
                                                            <asp:BoundField DataField="Ackdate" HeaderText="Acknowledge Time" />
                                                            <asp:BoundField DataField="Retdate" HeaderText="Return Time" />
                                                        </Columns>
                                                    </asp:GridView>
                                                </td>
                                            </tr>
                                            <tr>
                                                <td class="auto-style77" colspan="2">
                                                    &nbsp;</td>
                                                <td class="auto-style77">&nbsp;</td>
                                                <td class="auto-style85">&nbsp;</td>
                                                <td class="auto-style77">&nbsp;</td>
                                            </tr>
                                            <tr>
                                                <td class="auto-style81">&nbsp;</td>
                                                <td class="auto-style89">
                                                    <telerik:RadButton ID="btnSubmitItem" runat="server" ButtonType="SkinnedButton" Font-Size="10pt" Height="30px" OnClick="btnSubmitItem_Click" Text="Add Issue" ValidationGroup="A">
                                                    </telerik:RadButton>
                                                </td>
                                                <td>&nbsp;</td>
                                                <td class="auto-style85">&nbsp;</td>
                                                <td>&nbsp;</td>
                                            </tr>
                                        </table>
                                    </asp:Panel>
                                </td>
                            </tr>
                            <tr>
                                <td class="auto-style75">&nbsp;</td>
                                <td class="auto-style68">&nbsp;</td>
                                <td class="auto-style67">&nbsp;</td>
                                <td>&nbsp;</td>
                            </tr>
                        </table></telerik:RadAjaxPanel>
                    </td>
                </tr>
                <tr>
                    <td class="auto-style62" colspan="5">
                        &nbsp;</td>
                </tr>
                <tr>
                    <td class="auto-style10">&nbsp;</td>
                    <td class="auto-style15">
                        &nbsp;</td>
                    <td class="auto-style20">
                        </td>
                </tr>
                <tr>
                    <td class="auto-style62">&nbsp;</td>
                    <td class="auto-style26">
                        &nbsp;</td>
                    <td class="auto-style18">
                        &nbsp;</td>
                    <td class="auto-style29">
                        &nbsp;</td>
                    <td style="height: 30px; text-align: right;">
                        &nbsp;</td>
                </tr>
                <tr>
                    <td class="auto-style22">&nbsp;</td>
                    <td class="auto-style26">
                        <telerik:RadAjaxLoadingPanel ID="RadAjaxLoadingPanel2" runat="server" Skin="Default">
                        </telerik:RadAjaxLoadingPanel>
                    </td>
                    <td class="auto-style18">
                        &nbsp;</td>
                    <td class="auto-style29">
                        &nbsp;</td>
                    <td style="height: 30px; text-align: right;">
                        &nbsp;</td>
                </tr>
                <tr>
                    <td class="auto-style8">&nbsp;</td>
                    <td class="auto-style26">
                        &nbsp;</td>
                    <td class="auto-style18">
                        &nbsp;</td>
                    <td class="auto-style29">
                        &nbsp;</td>
                    <td class="auto-style9" style="height: 30px">
                        &nbsp;</td>
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
