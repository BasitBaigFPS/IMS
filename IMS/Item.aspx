<%@ Page Title="" Language="C#" MasterPageFile="~/Site1.Master" AutoEventWireup="true" CodeBehind="Item.aspx.cs" Inherits="IMS.Item" %>
<asp:Content ID="Content1" ContentPlaceHolderID="HeadContent" runat="server">
    <style type="text/css">
    .auto-style4 {
        border-collapse: collapse;
    }
    .auto-style6 {
        width: 50px;
        height: 19px;
    }
    .auto-style7 {
        height: 19px;
    }
    .auto-style8 {
        width: 50px;
        font-family: Arial, Helvetica, sans-serif;
        font-size: medium;
        height: 22px;
    }
    .auto-style9 {
        height: 22px;
    }
    .auto-style10 {
        width: 50px;
        font-family: Arial, Helvetica, sans-serif;
        font-size: medium;
        height: 33px;
        color: #C0C0C0;
    }
        .auto-style13 {
            height: 19px;
            width: 50px;
        }
        .auto-style15 {
            height: 33px;
            width: 50px;
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
        width: 50px;
        font-family: Arial, Helvetica, sans-serif;
        font-size: medium;
    }
        .auto-style25 {
            width: 50px;
        }
        .auto-style26 {
            height: 30px;
            width: 50px;
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
        width: 50px;
        font-family: Arial, Helvetica, sans-serif;
        font-size: xx-large;
    }
        .auto-style44 {
            font-family: Arial, Helvetica, sans-serif;
            font-size: 12pt;
            width: 69px;
        }
        .auto-style45 {
            width: 69px;
        }
        .auto-style46 {
            width: 164px;
        }
        .auto-style47 {
            font-family: Arial, Helvetica, sans-serif;
            font-size: 12pt;
            width: 118px;
        }
        .auto-style48 {
            width: 118px;
        }
    .auto-style49 {
        width: 50px;
        font-family: Arial, Helvetica, sans-serif;
        font-size: medium;
        height: 36px;
        color: #C0C0C0;
    }
    .auto-style50 {
        height: 36px;
        width: 50px;
    }
    .auto-style51 {
        height: 36px;
        font-family: Arial, Helvetica, sans-serif;
        width: 34px;
    }
    .auto-style52 {
        height: 36px;
        font-family: Arial, Helvetica, sans-serif;
        width: 97px;
        color: #C0C0C0;
    }
    .auto-style53 {
        height: 36px;
    }
    .auto-style55 {
        width: 50px;
        font-family: Arial, Helvetica, sans-serif;
        font-size: xx-large;
        color: #C0C0C0;
        height: 55px;
    }
    .auto-style56 {
        width: 50px;
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
        width: 50px;
        font-family: Arial, Helvetica, sans-serif;
        font-size: xx-large;
        color: #D1D1D1;
    }
    .auto-style62 {
        width: 50px;
        font-family: Arial, Helvetica, sans-serif;
        font-size: medium;
        color: #C0C0C0;
    }
    .auto-style63 {
        font-family: Arial, Helvetica, sans-serif;
        height: 30px;
        width: 97px;
        color: #C0C0C0;
    }
    .auto-style64 {
        width: 64px;
        height: 64px;
    }
    .auto-style65 {
        font-size: 38pt;
    }
        .auto-style66 {
            width: 100%;
        }
        .auto-style67 {
            font-family: Calibri;
            color: #666666;
        }
    </style>

</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">
     <telerik:RadCodeBlock ID="dfg" runat="server">
        <script type="text/javascript">
           
             <%--function OnCatagoryChanged(sender, args) {
                 var window = $find("<%= NewCatagory.ClientID %>");
                 var dropdown = $find("<%= cmbCategory.ClientID %>");
                 var selectedItem = dropdown.get_selectedItem();
                 if (selectedItem._text == "Add More...") {
                     window.show();
                     window.setSize(350, 150);
                     window.setUrl("http://www.google.com");
                 }
             }--%>

            function CheckItem(value) {
               
                alert(value);

                 
              //  document.getElementById('<%=txtName.ClientID%>').OnTextChanged();
            }

        </script> 


     </telerik:RadCodeBlock>


   <%-- <table cellpadding="0" class="auto-style2" style="display:none;">
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
                    <td class="auto-style32">&nbsp;</td>
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
                        </td>
                    <td class="auto-style55" style="background-color: #F7F7F7"></td>
                    <td class="auto-style57" style="background-color: #F7F7F7"></td>
                    <td class="auto-style58" style="background-color: #F7F7F7"></td>
                    <td class="auto-style59" style="background-color: #F7F7F7"></td>
                </tr>
           </table>
        </td>
    </tr>
</table>--%>


      <div class="col-lg-12" style="align-content:center;">
          <div style="display: inline-block; margin-left: 490px; margin-top: 20px;">
              <img alt="" class="auto-style64" src="images/Items.png" />
              <strong><span>I</span>TEM CREATION</strong>
          </div>
          <div style="display: inline-block; margin-left: 490px; margin-top: 20px;">
              <telerik:RadButton ID="btnClose" runat="server" Text="Close" Font-Size="10pt" Height="30px" ButtonType="SkinnedButton" OnClick="btnClose_Click">
              </telerik:RadButton>
          </div>
     </div>
 
        <div class="col-lg-12">

            <div style="display: inline-block; margin-left:500px; margin-top:20px;">
                <label>Item Title :</label>
                <telerik:RadTextBox ID="txtName" runat="server" class="form-control" Height="25px" Width="300px"  OnTextChanged="txtName_TextChanged">
                </telerik:RadTextBox>
            </div>

            <div style="display: inline-block; margin-left:490px; margin-top:20px;">
                <label>Description :</label>
                <telerik:RadTextBox ID="txtDescription" Runat="server" Height="25px" Width="300px">
                </telerik:RadTextBox>
            </div>

            <div style="display: inline-block; margin-left:505px; margin-top:20px;">
                <label>Catagory :</label>
                <telerik:RadComboBox ID="cmbCategory" Runat="server"  Width="300px" Sort="Ascending" AutoPostBack="True" OnSelectedIndexChanged="cmbCategory_SelectedIndexChanged">
                    <Items>
                        <telerik:RadComboBoxItem runat="server" Text="" Value="-1" />
                        <telerik:RadComboBoxItem runat="server" Text="Add More..." Value="Add More..." />
                    </Items>
                </telerik:RadComboBox>
            </div>

            <div style="display: inline-block; margin-left:476px; margin-top:20px;">
                <label>Sub-Catagory :</label>
                <telerik:RadComboBox ID="cmbSubCategory" Runat="server"  Width="300px" Sort="Ascending" AutoPostBack="True" OnSelectedIndexChanged="cmbSubCategory_SelectedIndexChanged">
                    <Items>
                        <telerik:RadComboBoxItem runat="server" Text="" Value="-1" />
                        <telerik:RadComboBoxItem runat="server" Text="Add More..." Value="Add More..." />
                    </Items>
                </telerik:RadComboBox>
            </div>

            <div style="display: inline-block; margin-left:497px; margin-top:20px;">
                <label>Item Head :</label>
                <telerik:RadComboBox ID="cmbItemHead" Runat="server" Sort="Ascending" TabIndex="3" Width="300px" OnSelectedIndexChanged="cmbItemHead_SelectedIndexChanged">                        
                    <Items>
                        <telerik:RadComboBoxItem runat="server" Text="" Value="-1" />
                        <telerik:RadComboBoxItem runat="server" Text="Add More..." Value="Add More..." />
                    </Items>
                </telerik:RadComboBox>
            </div>

            <div style="display: inline-block; margin-left:535px; margin-top:20px;">
                <label>Unit :</label>
                <telerik:RadTextBox ID="txtUnit" Runat="server" Height="25px" Width="172px">
                </telerik:RadTextBox>
            </div>

            <div style="display: inline-block; margin-left:40px; margin-top:20px;">
                <label>IsActive :</label>
                <asp:CheckBox ID="IsActive" runat="server" />
            </div>

            <div id="yearlyitem" runat="server" style="display: inline-block; margin-left:90px; margin-top:20px;">
                <label>Is Yearly Item? :</label>
                 <asp:CheckBox ID="IsYearly" runat="server" />
            </div>

            <div style="display: inline-block; margin-left:90px; margin-top:20px;">
                <label>Add Into Requisition Item List? :</label>
                 <asp:CheckBox ID="IsReqItem" runat="server" AutoPostBack="true" OnCheckedChanged="IsReqItem_CheckedChanged" />
            </div>

            <div style="display: inline-block; margin-left:497px; margin-top:20px;">
                <label>Item Type :</label>
                <telerik:RadComboBox ID="cmbItemType" Runat="server"  Width="300px" Visible="false"  Sort="Ascending" OnSelectedIndexChanged="cmbItemType_SelectedIndexChanged">                        
                    <Items>
                        <telerik:RadComboBoxItem runat="server" Text="" Value="-1" />
                        <telerik:RadComboBoxItem runat="server" Text="Add More..." Value="Add More..." />
                    </Items>
                </telerik:RadComboBox>
            </div>

        </div>
    <div class="col-lg-12">

        <div style="display: inline-block; margin-left: 800px; margin-top: 20px;">
            <telerik:RadButton ID="btnSubmit" runat="server" Text="Save" Font-Size="10pt" Height="30px" ButtonType="SkinnedButton" OnClick="btnSubmit_Click">
            </telerik:RadButton>
        </div>



    </div>


      <div class="col-lg-12">

             <div style="display: inline-block; margin-left:490px; margin-top:20px;">

                <label>Similar / Matched Items Reference: :</label>
 
                <span style="color:red">
                        
                <asp:Literal ID="ltlItemsList" runat="server"></asp:Literal>
                </span>
            </div>
 
      </div>

   <%-- <table cellpadding="0" class="auto-style2" style="display:none;">
    <tr>
        <td>
            <table align="center" cellpadding="0" class="auto-style4">

                <tr>
                    <td class="auto-style6"></td>
                    <td class="auto-style13"></td>
                    <td class="auto-style21">&nbsp;</td>
                    <td class="auto-style28">&nbsp;</td>
                    <td class="auto-style7">&nbsp;</td>
                </tr>
                <tr>
                    <td class="auto-style62">Title</td>
                    <td class="auto-style26">

                    </td>
                    <td class="auto-style18">
                        &nbsp;</td>
                    <td class="auto-style63">
                        Code</td>
                    <td style="height: 30px">
                        <telerik:RadTextBox ID="txtCode" Runat="server" Height="25px" Width="300px">
                        </telerik:RadTextBox>
                    </td>
                </tr>
                <tr>
                    <td class="auto-style62">Description</td>
                    <td class="auto-style50">

             ​<textarea id="txtDescription" rows="10" cols="1" Width="300px"></textarea> 
                    </td>
                    <td class="auto-style51">
                        </td>
                    <td class="auto-style52">
                        GL Code</td>
                    <td class="auto-style53">
                        <telerik:RadTextBox ID="txtGLCode" Runat="server" Height="25px" Width="300px">
                        </telerik:RadTextBox>
                    </td>
                </tr>
                <tr>
                    <td class="auto-style62">Catagory</td>
                    <td class="auto-style26">

                    </td>
                    <td class="auto-style18">
                        &nbsp;</td>
                    <td class="auto-style63" style="width: 110px">
                        &nbsp;</td>
                    <td style="height: 30px">
                        &nbsp;</td>
                </tr>
                <tr>
                    <td class="auto-style62">Sub-Catagory</td>
                    <td class="auto-style26">

                    </td>
                    <td class="auto-style18">
                        &nbsp;</td>
                    <td class="auto-style63">
                        &nbsp;</td>
                    <td style="height: 30px">
                        &nbsp;</td>
                </tr>
                <tr>
                    <td class="auto-style62">Item Head</td>
                    <td class="auto-style26">

                    </td>
                    <td class="auto-style18">
                        &nbsp;</td>
                    <td class="auto-style63">
                        &nbsp;</td>
                    <td style="height: 30px">
                        &nbsp;</td>
                </tr>
                <tr>
                    <td class="auto-style62">Unit</td>
                    <td class="auto-style26">

                    </td>
                    <td class="auto-style18">
                        &nbsp;</td>
                    <td class="auto-style63">
                        Item type</td>
                    <td style="height: 30px">
                        <
                            <Items>
                                <telerik:RadComboBoxItem runat="server" Text="" Value="-1" />
                                <telerik:RadComboBoxItem runat="server" Text="Add More..." Value="Add More..." />
                            </Items>
                        </telerik:RadComboBox>
                        </td>
                </tr>
                <tr>
                    <td class="auto-style62">IsActive</td>
                    <td class="auto-style15">
                        
                    </td>
                    <td class="auto-style20">
                    </td>
                    <td class="auto-style63">
                        Is Yearly Item?</td>
                    <td>
                        
                        
                    </td>
                </tr>
                <tr>
                    <td>

                    </td>
                </tr>


                <tr>
                    <td class="auto-style62">&nbsp;</td>
                    <td class="auto-style26">
                        <telerik:RadWindow ID="winMessage" runat="server">
                            <ContentTemplate>
                                <table class="auto-style66" style="width: 300px">
                                    <tr>
                                        <td class="auto-style67">&nbsp;</td>
                                        <td class="auto-style67">Item has been saved successfully.</td>
                                        <td class="auto-style67">&nbsp;</td>
                                    </tr>
                                    <tr>
                                        <td>&nbsp;</td>
                                        <td>
                                            <input id="Button1" type="button" value="Ok" />
                                        </td>
                                        <td>&nbsp;</td>
                                    </tr>
                                </table>
                            </ContentTemplate>
                        </telerik:RadWindow>
                    </td>
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
                        &nbsp;</td>
                    <td class="auto-style18">
                        &nbsp;</td>
                    <td class="auto-style29">
                        &nbsp;</td>
                    <td style="height: 30px; text-align: right;">

                    </td>
                </tr>
                <tr>
                    <td class="auto-style8">

                    </td>
                </tr>

            </table>
        </td>
    </tr>

</table>--%>

</asp:Content>
