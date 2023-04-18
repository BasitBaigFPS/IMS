<%@ Page Title="" Language="C#" MasterPageFile="~/Site1.Master" AutoEventWireup="true" CodeBehind="OpeningBalance.aspx.cs" Inherits="IMS.OpeningBalance" %>
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
                    <td class="auto-style55" style="background-color: #F7F7F7"><strong>Opening Balances</strong></td>
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
                    <td class="auto-style62" colspan="5"> <telerik:RadAjaxPanel ID="RadAjaxPanel2" runat="server" Width="550px" HorizontalAlign="NotSet" LoadingPanelID="RadAjaxLoadingPanel2" RenderMode="Inline">
                        <table class="auto-style66">
                            <tr>
                                <td colspan="4">
                                    <asp:Panel ID="Panel1" runat="server">
                                        <table class="auto-style66">
                                            
                                              <tr>
                                                <td class="auto-style77">Select System</td>
                                                <td>
                                                    <telerik:RadComboBox ID="cmbSystem" Runat="server" AutoPostBack="True" MarkFirstMatch="True" OnSelectedIndexChanged="cmbSystem_SelectedIndexChanged" Sort="Ascending" Width="300px">
                                                    </telerik:RadComboBox>
                                                     <asp:RequiredFieldValidator ID="RequiredFieldValidator2" runat="server" ControlToValidate="cmbSystem" ErrorMessage="Choose System" ForeColor="Red" InitialValue="Choose System" ValidationGroup="A">*</asp:RequiredFieldValidator>
                                                </td>
                                            </tr>
                                            
                                            <tr>
                                                <td class="auto-style77">Select Store</td>
                                                <td>
                                                    <telerik:RadComboBox ID="cmbStores" Runat="server" AutoPostBack="True" MarkFirstMatch="True" OnSelectedIndexChanged="cmbStores_SelectedIndexChanged" Sort="Ascending" Width="300px">
                                                    </telerik:RadComboBox>
                                                </td>
                                            </tr>
                                            <tr>
                                                <td class="auto-style77">Department</td>
                                                <td>
                                                    <telerik:RadComboBox ID="cmbDepartment" Runat="server" MarkFirstMatch="True" MaxHeight="300px" ShowMoreResultsBox="True" Sort="Ascending" ValidationGroup="B" Width="300px">
                                                    </telerik:RadComboBox>
                                                    <asp:RequiredFieldValidator ID="RequiredFieldValidator8" runat="server" ControlToValidate="cmbDepartment" ErrorMessage="Department Name" ForeColor="Red" InitialValue="Choose Department" ValidationGroup="A">*</asp:RequiredFieldValidator>
                                                </td>
                                            </tr>
                                              <tr>
                                                  <td class="auto-style77">Location </td>
                                                  <td>
                                                      <telerik:RadComboBox ID="cmbLocation" Runat="server" MarkFirstMatch="True" MaxHeight="300px" ShowMoreResultsBox="True" Sort="Ascending" ValidationGroup="B" Width="300px" OnSelectedIndexChanged="cmbLocation_SelectedIndexChanged">
                                                      </telerik:RadComboBox>
                                                      <asp:RequiredFieldValidator ID="RequiredFieldValidator9" runat="server" ControlToValidate="cmbLocation" ErrorMessage="Location Required" ForeColor="Red" InitialValue="Choose Location" ValidationGroup="A">*</asp:RequiredFieldValidator>
                                                  </td>
                                              </tr>
                                              <tr>
                                                  <td class="auto-style77">&nbsp;</td>
                                                  <td>&nbsp;</td>
                                              </tr>
                                              <tr>
                                                  <td class="auto-style77">Select Category</td>
                                                  <td>
                                                      <telerik:RadComboBox ID="cmbCategory" Runat="server" AutoPostBack="True" MarkFirstMatch="True" OnSelectedIndexChanged="cmbCategory_SelectedIndexChanged" Sort="Ascending" TabIndex="3" Width="300px">
                                                      </telerik:RadComboBox>
                                                  </td>
                                              </tr>
                                              <tr>
                                                  <td class="auto-style77">Select Sub. Cat.</td>
                                                  <td>
                                                      <telerik:RadComboBox ID="cmbSubCategory" Runat="server" AutoPostBack="True" MarkFirstMatch="True" OnSelectedIndexChanged="cmbSubCategory_SelectedIndexChanged" Sort="Ascending" TabIndex="3" Width="300px">
                                                      </telerik:RadComboBox>
                                                  </td>
                                              </tr>
                                              <tr>
                                                  <td class="auto-style77">Select Item Head</td>
                                                  <td>
                                                      <telerik:RadComboBox ID="cmbItemHead" Runat="server" AutoPostBack="True" MarkFirstMatch="True" OnSelectedIndexChanged="cmbItemHead_SelectedIndexChanged" Sort="Ascending" TabIndex="3" Width="300px">
                                                      </telerik:RadComboBox>
                                                  </td>
                                              </tr>
                                              <tr>
                                                  <td class="auto-style77">&nbsp;</td>
                                                  <td>
                                                      &nbsp;</td>
                                              </tr>
                                              <tr>
                                                  <td class="auto-style77">Select Item</td>
                                                  <td>
                                                      <telerik:RadComboBox ID="cmbItem" Runat="server" AutoPostBack="True" MarkFirstMatch="True" MaxHeight="300px" OnSelectedIndexChanged="cmbItem_SelectedIndexChanged" ShowMoreResultsBox="True" Sort="Ascending" ValidationGroup="B" Width="300px">
                                                      </telerik:RadComboBox>
                                                      <asp:RequiredFieldValidator ID="RequiredFieldValidator7" runat="server" ControlToValidate="cmbDepartment" ErrorMessage="Opening Item Required" ForeColor="Red" InitialValue="Choose Item" ValidationGroup="A">*</asp:RequiredFieldValidator>
                                                  </td>
                                              </tr>
                                            <tr>
                                                <td class="auto-style77">&nbsp;</td>
                                                <td>
                                                    &nbsp;</td>
                                            </tr>
                                            <tr>
                                                <td class="auto-style77">OB Quantity</td>
                                                <td>
                                                    <asp:TextBox ID="txtopenbalanceqty" runat="server" ></asp:TextBox>
                                                    <asp:RequiredFieldValidator ID="RequiredFieldValidator1" runat="server" ControlToValidate="txtopenbalanceqty" ErrorMessage="Opening Quantity Required" ForeColor="Red" ValidationGroup="A">*</asp:RequiredFieldValidator>
                                                    <asp:RangeValidator ID="RangeValidator1" runat="server" ControlToValidate="txtopenbalanceqty" ErrorMessage="Enter Numeric Value in Opening Balance Qty" ForeColor="Red" Type="Double">*</asp:RangeValidator>
                                                </td>
                                            </tr>
                                            <tr>
                                                <td class="auto-style77">Order Limit</td>
                                                <td>
                                                    <asp:TextBox ID="txtorderlimit" runat="server"></asp:TextBox>
                                                    <asp:RequiredFieldValidator ID="RequiredFieldValidator6" runat="server" ControlToValidate="txtorderlimit" ErrorMessage="Item Order Limit Required" ForeColor="Red" ValidationGroup="A">*</asp:RequiredFieldValidator>
                                                    <asp:RangeValidator ID="RangeValidator2" runat="server" ControlToValidate="txtorderlimit" ErrorMessage="Enter Numeric Value in Order Limit Qty" ForeColor="Red" Type="Double">*</asp:RangeValidator>
                                                </td>
                                            </tr>
                                            <tr>
                                                <td class="auto-style77">&nbsp;</td>
                                                <td>&nbsp;</td>
                                            </tr>
                                            <tr>
                                                <td class="auto-style77">Item Model</td>
                                                <td>
                                                    <asp:TextBox ID="txtitemmodel" runat="server"></asp:TextBox>
                                                </td>
                                            </tr>
                                            <tr>
                                                <td class="auto-style77">Item Brand</td>
                                                <td>
                                                    <asp:TextBox ID="txtitembrand" runat="server"></asp:TextBox>
                                                </td>
                                            </tr>
                                            <tr>
                                                <td class="auto-style77">&nbsp;</td>
                                                <td>
                                                    <asp:ValidationSummary ID="ValidationSummary1" runat="server" HeaderText="Remaining Fields" ShowMessageBox="True" ShowSummary="False" />
                                                </td>
                                            </tr>
                                            <tr>
                                                <td class="auto-style77">&nbsp;</td>
                                                <td>
                                                    <telerik:RadButton ID="btnSubmit" runat="server" ButtonType="SkinnedButton" Font-Size="10pt" Height="30px" OnClick="btnSubmit_Click" Text="Insert" ValidationGroup="A">
                                                    </telerik:RadButton>
                                                </td>
                                            </tr>
                                            <tr>
                                                <td class="auto-style77">&nbsp;</td>
                                                <td>&nbsp;</td>
                                            </tr>
                                            <tr>
                                                <td class="auto-style77" colspan="2">
                                                    <telerik:RadGrid ID="grdItems" runat="server" CellSpacing="0" GridLines="None">
                                                        <ExportSettings FileName="ItemList" OpenInNewWindow="True">
                                                        </ExportSettings>
                                                        <MasterTableView CommandItemDisplay="Top" HeaderStyle-HorizontalAlign="Center" HeaderStyle-VerticalAlign="Middle" ItemStyle-HorizontalAlign="Center" ItemStyle-VerticalAlign="Middle">
                                                            <CommandItemSettings ShowAddNewRecordButton="False" ShowExportToExcelButton="True" ShowExportToPdfButton="True" ShowExportToWordButton="True" ShowRefreshButton="False" />
                                                            <RowIndicatorColumn Visible="False">
                                                            </RowIndicatorColumn>
                                                        </MasterTableView>
                                                        <HeaderStyle HorizontalAlign="Center" VerticalAlign="Middle" />
                                                        <ItemStyle HorizontalAlign="Center" VerticalAlign="Middle" />
                                                    </telerik:RadGrid>
                                                </td>
                                            </tr>
                                            <tr>
                                                <td class="auto-style77">&nbsp;</td>
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
