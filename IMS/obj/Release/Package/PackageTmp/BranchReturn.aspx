<%@ Page Title="" Language="C#" MasterPageFile="~/Site1.Master" AutoEventWireup="true" CodeBehind="BranchReturn.aspx.cs" Inherits="IMS.BranchReturn" %>
<%@ Register assembly="AjaxControlToolkit" namespace="AjaxControlToolkit" tagprefix="asp" %>
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
    .RadComboBox_Default{color:#333;font:normal 12px/16px "Segoe UI",Arial,Helvetica,sans-serif}.RadComboBox{margin:0 0 0 0px;
padding:0;*zoom:1;display:-moz-inline-stack;display:inline-block;*display:inline;text-align:left;vertical-align:middle;_vertical-align:top;white-space:nowrap
    }.RadComboBox_Default .rcbReadOnly .rcbInputCellLeft{background-position:0 -88px}.RadComboBox_Default .rcbInputCellLeft{background-position:0 0}.RadComboBox_Default .rcbInputCell{background-image:url('mvwres://Telerik.Web.UI, Version=2013.3.1015.45, Culture=neutral, PublicKeyToken=121fae78165ba3d4/Telerik.Web.UI.Skins.Default.Common.radFormSprite.png');_background-image:url('mvwres://Telerik.Web.UI, Version=2013.3.1015.45, Culture=neutral, PublicKeyToken=121fae78165ba3d4/Telerik.Web.UI.Skins.Default.Common.radFormSpriteIE6.png')}.RadComboBox .rcbInputCell{width:100%;height:20px;_height:22px;line-height:20px;_line-height:22px;text-align:left;vertical-align:middle}.RadComboBox .rcbInputCell{margin:0;padding:0;background-color:transparent;background-repeat:no-repeat;*zoom:1}.RadComboBox_Default .rcbReadOnly .rcbInput{color:#333}.RadComboBox .rcbReadOnly .rcbInput{cursor:default}.RadComboBox_Default .rcbInput{color:#333;font:normal 12px "Segoe UI",Arial,Helvetica,sans-serif;line-height:16px}.RadComboBox .rcbInput{margin:0;padding:0;border:0;background:0;padding:2px 0 1px;_padding:2px 0 0;width:100%;_height:18px;outline:0;vertical-align:middle;-webkit-appearance:none}.RadComboBox_Default .rcbReadOnly .rcbArrowCellRight{background-position:-162px -176px}.RadComboBox_Default .rcbArrowCellRight{background-position:-18px -176px}.RadComboBox_Default .rcbArrowCell{background-image:url('mvwres://Telerik.Web.UI, Version=2013.3.1015.45, Culture=neutral, PublicKeyToken=121fae78165ba3d4/Telerik.Web.UI.Skins.Default.Common.radFormSprite.png');_background-image:url('mvwres://Telerik.Web.UI, Version=2013.3.1015.45, Culture=neutral, PublicKeyToken=121fae78165ba3d4/Telerik.Web.UI.Skins.Default.Common.radFormSpriteIE6.png')}.RadComboBox .rcbArrowCell{width:18px}.RadComboBox .rcbArrowCell{margin:0;padding:0;background-color:transparent;background-repeat:no-repeat;*zoom:1}
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
        .auto-style81 {        text-align: center;
    }
        .auto-style85 {
            width: 160px;
        }
        .auto-style89 {
            width: 312px;
              text-align: justify;
          }
        .auto-style90 {
            font-family: Calibri;
            color: #99CC00;
            font-size: xx-large;
        }
        .auto-style91 {
            height: 30px;
            text-align:center;
       
        }
          .auto-style109 {
              width: 100%;
              border: 1px solid #000080;
          }
          .auto-style113 {
        text-decoration: underline;
        color: #000000;
    }
    .auto-style114 {
        text-align: justify;
    }
    .auto-style115 {
        text-align: justify;
        height: 19px;
    }
    .auto-style116 {
        width: 312px;
        text-align: justify;
        height: 19px;
    }
          </style>

     <link href="CSS/GridViewStyle1.css" rel="stylesheet" type="text/css" />

</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">
     <telerik:RadCodeBlock ID="dfg" runat="server">
         <script type="text/javascript">
             function addItem(event) {

                 var keyCode = ('which' in event) ? event.which : event.keyCode;

                <%-- if (keyCode == 13)
                     document.getElementById('<%=btnAddItem.ClientID%>').click(); --%>
             }
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
                    <td class="auto-style27" style="background-color: #F7F7F7; height: 10px; text-align: center;">
                        &nbsp;</td>
                    <td style="background-color: #F7F7F7; height: 10px;"></td>
                </tr>
                <tr>
                    <td class="auto-style56" style="background-color: #F7F7F7; text-align: center;">
                        <img alt="" class="auto-style64" src="images/Items.png" /></td>
                    <td class="auto-style90" style="background-color: #F7F7F7"><strong>Goods Received Notes (GRN)</strong></td>
                    <td class="auto-style57" style="background-color: #F7F7F7"></td>
                    <td class="auto-style58" style="background-color: #F7F7F7"></td>
                    <td class="auto-style59" style="background-color: #F7F7F7">
                        <telerik:RadButton ID="btnClose" runat="server" Text="Close" Font-Size="10pt" Height="30px" ButtonType="SkinnedButton" OnClick="btnClose_Click" Width="72px" style="text-align: center">
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
                                                <td class="auto-style113"></td>
                                                <td class="auto-style75">
                                                    &nbsp;</td>
                                                <td class="auto-style85">
                                                    &nbsp;</td>
                                                <td>
                                                    
                                                    &nbsp;</tr>
                                            <tr>
                                                <td class="auto-style81" colspan="3">
                                                    <asp:UpdatePanel ID="UpdatePanel1" runat="server">
                                                        <ContentTemplate>
                                                            <table cellpadding="0" cellspacing="1" class="auto-style66">
                                                                <tr>
                                                                    <td class="auto-style81" colspan="4">&nbsp;</td>
                                                                </tr>
                                                                <tr>
                                                                    <td class="auto-style81">
                                                                        <a href="BranchReturnGeneral.aspx" target="_blank">Open GRN (For Old / Un-Recorded Items)</a></strong></td>
                                                                    </td>
                                                                    <td class="auto-style81">&nbsp;</td>
                                                                    <td class="auto-style81">&nbsp;</td>
                                                                    <td class="auto-style81"><strong>G.R.N Number:<asp:TextBox ID="txtgrnno" runat="server" BorderColor="#000066" BorderWidth="1px" Enabled="False" Height="20px" style="font-size: x-small; text-align: center; font-weight: 700; margin-bottom: 0px;" TabIndex="5" Width="75px"></asp:TextBox>
                                                                        &nbsp; <a href="ReportsMain.aspx?rptname=GoodsReceiptNote&amp;grno=<%=txtgrnno.Text%>" target="_blank">Print</a></strong></td>
                                                                    </strong></td>
                                                                </tr>
                                                                <tr>
                                                                    <td class="auto-style81" colspan="4">&nbsp;
                                                                        <table align="center" class="auto-style109">
                                                                            <tr>
                                                                                <td style="text-align: left" valign="middle">&nbsp;&nbsp;&nbsp; <span class="auto-style81"><strong>Received Items By G.I.N No:
                                                                                    <asp:TextBox ID="txtginno" runat="server" BorderColor="#000066" BorderWidth="1px" Height="20px" onkeydown="addItem(event);" style="font-size: x-small; text-align: center; font-weight: 700;" TabIndex="5" Width="75px"></asp:TextBox>
                                                                                    &nbsp;&nbsp;
                                                                                    <telerik:RadButton ID="btnSubmit" runat="server" ButtonType="SkinnedButton" Enabled="False" Font-Size="10pt" Height="30px" OnClick="btnSubmit_Click" style="text-align: center" TabIndex="16" Text="Submit" ValidationGroup="A" Width="60px">
                                                                                    </telerik:RadButton>
                                                                                    </strong></span></td>
                                                                            </tr>
                                                                        </table>
                                                                    </td>
                                                                </tr>
                                                                <tr>
                                                                    <td class=" " colspan="4"></td>
                                                                </tr>
                                                                <tr>
                                                                    <td class="auto-style81" colspan="4">&nbsp;</td>
                                                                </tr>
                                                                <tr>
                                                                    <td class="auto-style114" colspan="1">&nbsp;</td>
                                                                    <td style="color: #000000; background-color: #C0C0C0"><strong style="text-align: center">Sender / Issuer Information</strong></td>
                                                                    <td colspan="1">&nbsp;</td>
                                                                    <td style="color: #000000; background-color: #C0C0C0"><strong style="text-align: center; background-color: #C0C0C0;">Receiver Information</strong></td>
                                                                </tr>
                                                                <tr>
                                                                    <td class="auto-style114" colspan="1">From Branch</td>
                                                                    <td class="auto-style89">
                                                                        <telerik:RadComboBox ID="cmbbranchfrom" Runat="server" AutoPostBack="True" MarkFirstMatch="True" OnSelectedIndexChanged="cmbbranchfrom_SelectedIndexChanged" Sort="Ascending" Width="300px">
                                                                        </telerik:RadComboBox>
                                                                    </td>
                                                                    <td colspan="1">To Branch</td>
                                                                    <td>
                                                                        <telerik:RadComboBox ID="cmbbranchto" Runat="server" AutoPostBack="True" MarkFirstMatch="True" Sort="Ascending" Width="300px">
                                                                        </telerik:RadComboBox>
                                                                    </td>
                                                                </tr>
                                                                <tr>
                                                                    <td class="auto-style114">From Department</td>
                                                                    <td class="auto-style89">
                                                                        <telerik:RadComboBox ID="cmbDept" Runat="server" MarkFirstMatch="True" Sort="Ascending" TabIndex="2" Width="300px">
                                                                        </telerik:RadComboBox>
                                                                    </td>
                                                                    <td>To Dept.</td>
                                                                    <td>
                                                                        <telerik:RadComboBox ID="cmbDeptto" Runat="server" MarkFirstMatch="True" Sort="Ascending" TabIndex="2" Width="300px">
                                                                        </telerik:RadComboBox>
                                                                    </td>
                                                                </tr>
                                                                <tr>
                                                                    <td colspan="2" style="text-align: left">&nbsp;</td>
                                                                    <td class="auto-style89">&nbsp;</td>
                                                                    <td>&nbsp;</td>
                                                                    <td>&nbsp;</td>
                                                                </tr>
                                                                <tr>
                                                                    <td class="auto-style115">From Stores</td>
                                                                    <td class="auto-style116">
                                                                        <telerik:RadComboBox ID="cmbstorefrom" Runat="server" MarkFirstMatch="True" Sort="Ascending" TabIndex="2" Width="300px">
                                                                        </telerik:RadComboBox>
                                                                    </td>
                                                                    <td class="auto-style7">To Store</td>
                                                                    <td class="auto-style7">
                                                                        <telerik:RadComboBox ID="cmbstoreto" Runat="server" MarkFirstMatch="True" Sort="Ascending" TabIndex="2" Width="300px">
                                                                        </telerik:RadComboBox>
                                                                    </td>
                                                                </tr>
                                                                <tr>
                                                                    <td class="auto-style114">Receive Status</td>
                                                                    <td class="auto-style89">
                                                                        <telerik:RadComboBox ID="cmbRecvStatus" Runat="server" AutoPostBack="True" MarkFirstMatch="True" OnSelectedIndexChanged="cmbRecvStatus_SelectedIndexChanged" Sort="Ascending" Width="300px">
                                                                            <Items>
                                                                                <telerik:RadComboBoxItem runat="server" Selected="True" Text="Choose Status" Value="Choose Status" />
                                                                                <telerik:RadComboBoxItem runat="server" Text="Permenant Received" Value="P" />
                                                                                <telerik:RadComboBoxItem runat="server" Text="Temporary Received" Value="T" />
                                                                            </Items>
                                                                        </telerik:RadComboBox>
                                                                    </td>
                                                                    <td>&nbsp;</td>
                                                                    <td>&nbsp;</td>
                                                                </tr>
                                                                <tr>
                                                                    <td class="auto-style81">&nbsp;</td>
                                                                    <td class="auto-style89">&nbsp;</td>
                                                                    <td class="auto-style75">&nbsp;</td>
                                                                    <td class="auto-style85">&nbsp;</td>
                                                                    <td>&nbsp;</td>
                                                                </tr>
                                                                <tr>
                                                                    <td align="center" colspan="5">
                                                                        <asp:GridView ID="grdItems" runat="server" AlternatingRowStyle-CssClass="alt" AutoGenerateColumns="False" CssClass="mGrid" OnRowCommand="grdItems_RowCommand" Width="734px">
                                                                            <AlternatingRowStyle CssClass="alt" />
                                                                            <Columns>
                                                                               <%-- <asp:BoundField DataField="GINCode" HeaderText="GIN Code" />--%>
                                                                                <asp:BoundField DataField="ItemCode" HeaderText="Item Code" >
                                                                                <ItemStyle Font-Names="Calibri" Font-Size="Medium" />
                                                                                </asp:BoundField>
                                                                                <asp:BoundField DataField="ItemTitle" HeaderText="Item Name" >
                                                                                <ControlStyle Width="400px" />
                                                                                <HeaderStyle Width="400px" />
                                                                                <ItemStyle Width="400px" Font-Names="Calibri" Font-Size="Medium" HorizontalAlign="Left" />
                                                                                </asp:BoundField>
                                                                                <asp:BoundField DataField="Model" HeaderText="Model" >
                                                                                <ItemStyle Font-Names="Calibri" Font-Size="Medium" HorizontalAlign="Center" VerticalAlign="Middle" />
                                                                                </asp:BoundField>
                                                                                <asp:BoundField DataField="Brand" HeaderText="Brand" >
                                                                                <ItemStyle Font-Names="Calibri" Font-Size="Medium" HorizontalAlign="Center" VerticalAlign="Middle" />
                                                                                </asp:BoundField>
                                                                                <asp:BoundField DataField="Unit" HeaderText="Unit" >
                                                                                <ItemStyle Font-Names="Calibri" Font-Size="Medium" HorizontalAlign="Center" VerticalAlign="Middle" />
                                                                                </asp:BoundField>
                                                                                <asp:BoundField DataField="Qtty" HeaderText="Quantity" >
                                                                                <ItemStyle Font-Names="Calibri" Font-Size="Medium" HorizontalAlign="Center" VerticalAlign="Middle" />
                                                                                </asp:BoundField>
                                                                            </Columns>
                                                                        </asp:GridView>
                                                                    </td>
                                                                </tr>
                                                                <tr>
                                                                    <td class="auto-style77" colspan="2">&nbsp;</td>
                                                                    <td class="auto-style75">&nbsp;</td>
                                                                    <td class="auto-style85">&nbsp;</td>
                                                                    <td class="auto-style77">&nbsp;</td>
                                                                </tr>
                                                                <tr>
                                                                    <td class="auto-style77" colspan="2">&nbsp;</td>
                                                                    <td class="auto-style75">&nbsp;</td>
                                                                    <td class=" " style="text-align: right">
                                                                        <telerik:RadButton ID="btnSave" runat="server" ButtonType="SkinnedButton" Font-Size="10pt" Height="30px" OnClick="btnSave_Click" style="text-align: center; font-weight: 700; font-style: italic" TabIndex="18" Text="Save GRN" ValidationGroup="A" Visible="False" Width="158px" EnableBrowserButtonStyle="True" UseSubmitBehavior="False">
                                                                        </telerik:RadButton>
                                                                    </td>
                                                                    <td class="auto-style77">&nbsp;</td>
                                                                </tr>
                                                                <tr>
                                                                    <td class="auto-style81" colspan="5" style="text-align: right">&nbsp;</td>
                                                                </tr>
                                                            </table>
                                                            <br />
                                                        </ContentTemplate>
                                                    </asp:UpdatePanel>
                                                </td>
                                                <td class="auto-style91">&nbsp;</td>
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
