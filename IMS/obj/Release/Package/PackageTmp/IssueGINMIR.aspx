<%@ Page Title="" Language="C#" MasterPageFile="~/Site1.Master" AutoEventWireup="true" CodeBehind="IssueGINMIR.aspx.cs" Inherits="IMS.IssueGINMIR" %>
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
        .auto-style77 {              text-align: right;
          }
        .auto-style81 {        text-align: center;
    }
        .auto-style85 {
            width: 160px;
              text-align: left;
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
          .auto-style113 {
        text-decoration: underline;
        color: #000000;
    }
    .auto-style114 {
        text-align: justify;
              width: 8px;
          }
          .auto-style115 {
              text-align: center;
              color: #000000;
          }
          .auto-style118 {
              width: 131px;
              text-align: justify;
          }
          .auto-style119 {
              text-align: center;
              width: 8px;
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

             function checkBackKey() {
                 // Check for backSpace key    
                 if (window.event.keyCode == 8) {
                     return false; //aviod postback  
                 }
             }


             function Confirm(MIR) {
                 //This Function Work with ASP Button Not with RadControlButton.
                 var choice = confirm("Are You Sure, You Want to Close This MIR : '" + MIR + "' Permanently?", "Yes", "No");
                 if (choice == false) {
                     return false;
                 }
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
                    <td class="auto-style32" style="background-color: #F7F7F7; height: 10px;">
                        <img alt="" class="auto-style64" src="images/Items.png" /></td>
                    <td class="auto-style61" style="background-color: #F7F7F7; height: 10px;"></td>
                    <td class="auto-style31" style="background-color: #F7F7F7; height: 10px;"></td>
                    <td class="auto-style27" style="background-color: #F7F7F7; height: 10px; text-align: center;">
                        &nbsp;</td>
                    <td style="background-color: #F7F7F7; height: 10px;"></td>
                </tr>
                <tr>
                    <td class="auto-style90" style="background-color: #F7F7F7; text-align: center;" colspan="4">
                        <strong>Goods Issue Notes (GIN)</strong></td>
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
                                                                    <td class="auto-style115" colspan="8"><strong>New MIR Data</strong></td>
                                                                </tr>
                                                                <tr>
                                                                    <td class="auto-style81" colspan="8">&nbsp;</td>
                                                                </tr>
                                                                <tr>
                                                                    <td class="auto-style81" colspan="8">
                                                                        <asp:GridView ID="grdmir" runat="server" AlternatingRowStyle-CssClass="alt" AutoGenerateColumns="False" 
                                                                            CssClass="mGrid" OnRowCommand="grdmir_RowCommand" Width="981px" DataKeyNames="MIRCode"
                                                                            AllowPaging="True" OnPageIndexChanging="grdmir_PageIndexChanging" PageSize="50">


                                                                            <AlternatingRowStyle CssClass="alt" />


                                                                            <Columns>
                                                                               
                                                                                

                                                                            <asp:TemplateField HeaderText="MIRCode">
                                                                                  <ItemTemplate>
                                                                               
                                                                                      <asp:LinkButton ID="lblMirCode" CommandName="MIRCode" runat="server" Width="115%" Text='<%# DataBinder.Eval(Container.DataItem,"MIRCode") %>' CommandArgument='<%# DataBinder.Eval(Container.DataItem,"MIRCode") %>' style="color:blue;font-size:smaller;"></asp:LinkButton>

                                                                                    <%--  <asp:LinkButton ID="btnMirCode" runat="server" CommandName="MIRCode" Text='<%# Eval("MIRCode") %>'>                                                                               
                                                                                      </asp:LinkButton>  --%>


                                                                                  </ItemTemplate>
                                                                                  <HeaderStyle BackColor="Black" ForeColor="White" HorizontalAlign="Left" Width="150px" />
                                                                                  <ItemStyle HorizontalAlign="Left" Width="150px"/>
                                                                            </asp:TemplateField>

                                                                                <asp:BoundField DataField="Branch" HeaderText="Branch Name">
                                                                                <ControlStyle Width="300px" />
                                                                                <HeaderStyle Width="300px" />
                                                                                <ItemStyle Font-Names="Calibri" Font-Size="Medium" HorizontalAlign="Left" Width="300px" />
                                                                                </asp:BoundField>

                                                                                <asp:BoundField DataField="StoreName" HeaderText="Store Name/Department">
                                                                                <ItemStyle Font-Names="Calibri" Font-Size="Medium" HorizontalAlign="Center" VerticalAlign="Middle" Width="300px"/>
                                                                                <ControlStyle Width="300px" />
                                                                                <HeaderStyle Width="300px" />
                                                                                </asp:BoundField>

                                                                                <asp:BoundField DataField="UserName" HeaderText="Sender Name">
                                                                                <ItemStyle Font-Names="Calibri" Font-Size="Medium" HorizontalAlign="Center" VerticalAlign="Middle" Width="100px"/>
                                                                                <ControlStyle Width="100px" />
                                                                                <HeaderStyle Width="100px" />
                                                                                </asp:BoundField>

                                                                                <asp:BoundField DataField="TotalItems" HeaderText="Total Items">
                                                                                <ItemStyle Font-Names="Calibri" Font-Size="Medium" HorizontalAlign="Center" VerticalAlign="Middle" />
                                                                                </asp:BoundField>

                                                                                <asp:BoundField DataField="MIRDate" HeaderText="MIR Date">
                                                                                <ItemStyle Font-Names="Calibri" Font-Size="Medium" HorizontalAlign="Center" VerticalAlign="Middle" />
                                                                                </asp:BoundField>
                                               
                                                                            </Columns>
                                                                            <PagerSettings FirstPageText="First" LastPageText="Last" PageButtonCount="8" Position="Top" />
                                                                        </asp:GridView>
                                                                    </td>
                                                                </tr>
                                                                <tr>
                                                                    <td class="auto-style81" colspan="4">&nbsp;</td>
                                                                </tr>
                                                                <tr>
                                                                    <td class="auto-style114">&nbsp;</td>
                                                                    <td class="auto-style118">
                                                                        <asp:Button ID="btnCloseMIR" runat="server" OnClick="btnCloseMIR_Click" Text="Close This MIR" Width="94px" />
                                                                    </td>
                                                                    <td>&nbsp;</td>
                                                                    <td style="text-align: left"></td>
                                                                    <td><strong>G.I.N Number:<asp:TextBox ID="txtginno" runat="server" BorderColor="#000066" BorderWidth="1px" Enabled="False" Height="20px" style="font-size: x-small; text-align: center; font-weight: 700; margin-bottom: 0px;" TabIndex="5" Width="75px"></asp:TextBox>
                                                                        &nbsp;&nbsp; <a href="ReportsMain.aspx?rptname=GoodsIssueNote&amp;gino=<%=txtginno.Text%>" style="text-align: left" target="_blank">Print</a></strong></td>
                                                                    
                                                                     </tr>
                                                                <tr>
                                                                    <td class="auto-style119">&nbsp;</td>
                                                                    <td class="auto-style118">&nbsp;</td>
                                                                    <td class="auto-style75">&nbsp;</td>
                                                                    <td style="text-align: left">&nbsp; </td>
                                                                    <td>Gate Pass No:<asp:TextBox ID="txtgpno" runat="server" BorderColor="#000066" BorderWidth="1px" Enabled="False" Height="20px" onkeydown="addItem(event);" style="font-size: x-small" TabIndex="5" Width="69px"></asp:TextBox>
                                                                        &nbsp; <a href="ReportsMain.aspx?rptname=GatePass&amp;gpno=<%= txtgpno.Text %>" target="_blank">Print</a></td>

                                                                </tr>
                                                                <tr>
                                                                    <td class="auto-style119">&nbsp;</td>
                                                                    <td class="auto-style118">&nbsp;</td>
                                                                    <td class="auto-style75">&nbsp;</td>
                                                                    <td class="auto-style75">&nbsp;</td>
                                                                </tr>
                                                                <tr>
                                                                    <td class="auto-style119">&nbsp;</td>
                                                                    <td class="auto-style118">&nbsp;<strong>M.I.R No:</strong>&nbsp;
                                                                        </td>
                                                                    <td class="auto-style75" style="text-align: center">
                                                                        <asp:TextBox ID="txtmirno" runat="server" BorderColor="#000066" BorderWidth="1px" Height="20px" onkeydown="addItem(event);" style="font-size: x-small; text-align: left; font-weight: 700; color: #9900CC;" TabIndex="5" Width="236px" Enabled="False"></asp:TextBox>
                                                                    </td>
                                                                    <td>&nbsp;</td>
                                                                    <td>
                                                                        <span>Select System:</span>
                                                                        <telerik:RadComboBox ID="cmbSystem" runat="server" AutoPostBack="True" MarkFirstMatch="True" OnSelectedIndexChanged="cmbSystem_SelectedIndexChanged" Sort="Ascending" Width="300px">
                                                                        </telerik:RadComboBox>


                                                                    </td>
                                                                    <td>&nbsp;</td>
                                                                </tr>
                                                                <tr>

                                                                    <td>&nbsp;</td>
                                                                </tr>
                                                                <tr>

                                                                    <td align="center" colspan="5">
                                                                        <asp:GridView ID="grdItems" runat="server" AllowSorting="True" AlternatingRowStyle-CssClass="alt" AutoGenerateColumns="False" CssClass="mGrid" OnRowCommand="grdItems_RowCommand" OnSorting="grdItems_Sorting" Width="734px" OnSelectedIndexChanged="grdItems_SelectedIndexChanged">
                                                                            <AlternatingRowStyle CssClass="alt" />
                                                                            <Columns>
                                                                                <%-- <asp:BoundField DataField="GINCode" HeaderText="GIN Code" />--%><%--<asp:CommandField ShowDeleteButton="True" />--%><%-- <asp:BoundField DataField="Sno" HeaderText="Item Serial" >
                                                                                <ItemStyle Font-Names="Calibri" Font-Size="Medium" />
                                                                                </asp:BoundField>--%>
                                                                                <asp:TemplateField HeaderText="Item Serial">
                                                                                    <ItemTemplate>
                                                                                        <asp:Label ID="lblserial" runat="server" Text='<%#Eval("Sno") %>' Width="50px" />
                                                                                    </ItemTemplate>
                                                                                </asp:TemplateField>
                                                                                <asp:BoundField DataField="ItemCode" HeaderText="Item Code">
                                                                                <ItemStyle Font-Names="Calibri" Font-Size="Medium" />
                                                                                </asp:BoundField>
                                                                                <asp:BoundField DataField="InvCode" HeaderText="Inv.Code">
                                                                                    <ControlStyle Width="400px" />
                                                                                <ItemStyle Font-Names="Calibri" Font-Size="Medium" />
                                                                                </asp:BoundField>
                                                                                <asp:BoundField DataField="ItemTitle" HeaderText="Item Name">
                                                                                <ControlStyle Width="400px" />
                                                                                <HeaderStyle Width="400px" />
                                                                                <ItemStyle Font-Names="Calibri" Font-Size="Medium" HorizontalAlign="Left" Width="400px" />
                                                                                </asp:BoundField>
                                                                                <asp:BoundField DataField="Unit" HeaderText="Unit">
                                                                                <ItemStyle Font-Names="Calibri" Font-Size="Medium" HorizontalAlign="Center" VerticalAlign="Middle" />
                                                                                </asp:BoundField>
                                                                                <asp:BoundField DataField="Qtty" HeaderText="Qtty Required">
                                                                                <ItemStyle Font-Names="Calibri" Font-Size="Medium" HorizontalAlign="Center" VerticalAlign="Middle" />
                                                                                </asp:BoundField>
                                                                                <asp:BoundField DataField="CRBalance" HeaderText="Qtty Available">
                                                                                <ItemStyle Font-Names="Calibri" Font-Size="Medium" HorizontalAlign="Center" VerticalAlign="Middle" />
                                                                                </asp:BoundField>
                                                                                <asp:BoundField DataField="QtyIssue" Visible="false">
                                                                                <ItemStyle Font-Names="Calibri" Font-Size="Medium" HorizontalAlign="Center" VerticalAlign="Middle" />
                                                                                </asp:BoundField>
                                                                                <asp:TemplateField HeaderText="Qtty Issued">
                                                                                    <ItemTemplate>
                                                                                        <asp:TextBox ID="txtqty" runat="server" AutoPostBack="True" ItemStyle-HorizontalAlign="Center" OnTextChanged="txtqty_TextChanged" Text='<%#Eval("QtyIssue") %>' Width="50px"> 
                                                                                            
                                                                    <%--                     <asp:TextBox ID="search" name="Search" runat="server" onKeyPress="javascript:text_changed();"></asp:TextBox>     --%>                                                                
                                                                                        </asp:TextBox>
                                                                                    </ItemTemplate>
                                                                                </asp:TemplateField>
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
                                                                    <td class="auto-style77" colspan="2">
                                                                        <asp:CheckBox ID="chkConfirmIssue" runat="server" OnCheckedChanged="chkConfirmIssue_CheckedChanged" style="font-size: large" Text="Confirm Issued" TextAlign="Left" />
                                                                    </td>
                                                                    <td class="auto-style75">&nbsp;</td>
                                                                    <td class=" " style="text-align: right">
                                                                        <telerik:RadButton ID="btnSave" runat="server" ButtonType="SkinnedButton" Font-Size="10pt" Height="30px" OnClick="btnSave_Click" style="text-align: center; font-weight: 700; font-style: italic" TabIndex="18" Text="Save GIN" ValidationGroup="A" Visible="False" Width="158px">
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
