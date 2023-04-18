<%@ Page Title="" Language="C#" MasterPageFile="~/Site1.Master" AutoEventWireup="true" CodeBehind="NewVendor.aspx.cs" Inherits="IMS.NewVendor" %>
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
    .auto-style11 {
        height: 33px;
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
        .auto-style30 {
            height: 33px;
            font-family: Arial, Helvetica, sans-serif;
            width: 97px;
        color: #C0C0C0;
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
        width: 104px;
        font-family: Arial, Helvetica, sans-serif;
        font-size: medium;
        height: 36px;
        color: #C0C0C0;
    }
    .auto-style50 {
        height: 36px;
        width: 300px;
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
    .auto-style54 {
        width: 64px;
        height: 64px;
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
        width: 104px;
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
        font-size: 38pt;
    }
    </style>

</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">
     <telerik:RadCodeBlock ID="dfg" runat="server">
         <script type="text/javascript">
             function OnClientSelectedIndexChanged(sender, args) {
                    var window = $find("<%= NewType.ClientID %>");
                    var dropdown = $find("<%= cmbTypes.ClientID %>");
                    var selectedItem = dropdown.get_selectedItem();
                    if (selectedItem._text == "Add More...") {
                        window.show();
                        window.setSize(350, 200);
                        window.setUrl("http://www.google.com");
                    }
             }

             function OnCatagoryChanged(sender, args) {
                 var window = $find("<%= NewCatagory.ClientID %>");
                 var dropdown = $find("<%= cmbCatagories.ClientID %>");
                 var selectedItem = dropdown.get_selectedItem();
                 if (selectedItem._text == "Add More...") {
                     window.show();
                     window.setSize(350, 150);
                     window.setUrl("http://www.google.com");
                 }
             }
        </script>
     </telerik:RadCodeBlock>
    <telerik:RadWindow ID="NewType" runat="server"  DestroyOnClose="True" EnableShadow="True" KeepInScreenBounds="True" Modal="True" ReloadOnShow="True" VisibleStatusbar="False" VisibleTitlebar="False">
        <ContentTemplate>
            <table cellpadding="0" class="auto-style2" style="width: 94%; margin-left: 12px">
                <tr>
                    <td class="auto-style44">&nbsp;</td>
                    <td class="auto-style46">&nbsp;</td>
                </tr>
                <tr>
                    <td class="auto-style44">New Type</td>
                    <td class="auto-style46">
                        <telerik:RadTextBox ID="txtNew" Runat="server" Height="25px" Width="200px">
                        </telerik:RadTextBox>
                    </td>
                </tr>
                <tr>
                    <td class="auto-style45">&nbsp;</td>
                    <td class="auto-style46">&nbsp;</td>
                </tr>
                <tr>
                    <td class="auto-style45">&nbsp;</td>
                    <td class="auto-style46">
                        <telerik:RadButton ID="btnNew" runat="server" ButtonType="SkinnedButton" Font-Size="10pt" Height="30px" Text="Submit">
                        </telerik:RadButton>
                        &nbsp;<telerik:RadButton ID="btnCancel" runat="server" ButtonType="SkinnedButton" Font-Size="10pt" Height="30px" Text="Cancel" SingleClick="True">
                        </telerik:RadButton>
                    </td>
                </tr>
            </table>
        </ContentTemplate>
    </telerik:RadWindow>

    <telerik:RadWindow ID="NewCatagory" runat="server"  DestroyOnClose="True" EnableShadow="True" KeepInScreenBounds="True" Modal="True" ReloadOnShow="True" VisibleStatusbar="False" VisibleTitlebar="False">
        <ContentTemplate>
            <table cellpadding="0" class="auto-style2" style="width: 94%; margin-left: 12px">
                <tr>
                    <td class="auto-style47">&nbsp;</td>
                    <td class="auto-style46">&nbsp;</td>
                </tr>
                <tr>
                    <td class="auto-style47">New Catagory</td>
                    <td class="auto-style46">
                        <telerik:RadTextBox ID="txtCatagory" Runat="server" Height="25px" Width="200px">
                        </telerik:RadTextBox>
                    </td>
                </tr>
                <tr>
                    <td class="auto-style48">&nbsp;</td>
                    <td class="auto-style46">&nbsp;</td>
                </tr>
                <tr>
                    <td class="auto-style48">&nbsp;</td>
                    <td class="auto-style46">
                        <telerik:RadButton ID="btnCatagory" runat="server" ButtonType="SkinnedButton" Font-Size="10pt" Height="30px" Text="Submit">
                        </telerik:RadButton>
                        &nbsp;<telerik:RadButton ID="btnCatCancel" runat="server" ButtonType="SkinnedButton" Font-Size="10pt" Height="30px" Text="Cancel" SingleClick="True">
                        </telerik:RadButton>
                    </td>
                </tr>
            </table>
        </ContentTemplate>

    </telerik:RadWindow>

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
                        <img alt="" class="auto-style54" src="images/Vendor.png" /></td>
                    <td class="auto-style55" style="background-color: #F7F7F7"><strong><span class="auto-style64">V</span>ENDOR</strong></td>
                    <td class="auto-style57" style="background-color: #F7F7F7"></td>
                    <td class="auto-style58" style="background-color: #F7F7F7"></td>
                    <td class="auto-style59" style="background-color: #F7F7F7"></td>
                </tr>
                <tr>
                    <td class="auto-style6"></td>
                    <td class="auto-style13"></td>
                    <td class="auto-style21">&nbsp;</td>
                    <td class="auto-style28">&nbsp;</td>
                    <td class="auto-style7">&nbsp;</td>
                </tr>
                <tr>
                    <td class="auto-style62">Name</td>
                    <td class="auto-style26">
                        <telerik:RadTextBox ID="txtName" Runat="server" Height="25px" Width="300px">
                        </telerik:RadTextBox>
                    </td>
                    <td class="auto-style18">
                        &nbsp;</td>
                    <td class="auto-style63">
                        Type</td>
                    <td style="height: 30px">
                        <telerik:RadAjaxPanel ID="RadAjaxPanel1" runat="server" Width="300px" HorizontalAlign="NotSet" LoadingPanelID="RadAjaxLoadingPanel1" RenderMode="Inline">
                        <telerik:RadComboBox ID="cmbTypes" Runat="server"  Width="300px" OnClientSelectedIndexChanged="OnClientSelectedIndexChanged" Sort="Ascending">
                            <Items>
                                <telerik:RadComboBoxItem runat="server" Value="-1" Selected="True" />
                                <telerik:RadComboBoxItem runat="server" Text="Add More..." Value="Add More..." />
                            </Items>
                        </telerik:RadComboBox>
                        </telerik:RadAjaxPanel>
                        <telerik:RadAjaxLoadingPanel ID="RadAjaxLoadingPanel1" runat="server" Skin="Default"></telerik:RadAjaxLoadingPanel>
                    </td>
                </tr>
                <tr>
                    <td class="auto-style49">Address</td>
                    <td class="auto-style50">
                        <telerik:RadTextBox ID="txtAddress" Runat="server" Height="25px" Width="300px">
                        </telerik:RadTextBox>
                    </td>
                    <td class="auto-style51">
                        </td>
                    <td class="auto-style52">
                        Catagory</td>
                    <td class="auto-style53">
                        <telerik:RadAjaxPanel ID="RadAjaxPanel2" runat="server" Width="300px" HorizontalAlign="NotSet" LoadingPanelID="RadAjaxLoadingPanel2" RenderMode="Inline">
                        <telerik:RadComboBox ID="cmbCatagories" Runat="server"  Width="300px" OnClientSelectedIndexChanged="OnCatagoryChanged" Sort="Ascending">
                            <Items>
                                <telerik:RadComboBoxItem runat="server" Text="" Value="-1" />
                                <telerik:RadComboBoxItem runat="server" Text="Add More..." Value="Add More..." />
                            </Items>
                        </telerik:RadComboBox>
                        </telerik:RadAjaxPanel>
                        <telerik:RadAjaxLoadingPanel ID="RadAjaxLoadingPanel2" runat="server" Skin="Default"></telerik:RadAjaxLoadingPanel>
                    </td>
                </tr>
                <tr>
                    <td class="auto-style62">City</td>
                    <td class="auto-style26">
                        <telerik:RadTextBox ID="txtCity" Runat="server" Height="25px" Width="300px">
                        </telerik:RadTextBox>
                    </td>
                    <td class="auto-style18">
                        &nbsp;</td>
                    <td class="auto-style63">
                        Country</td>
                    <td style="height: 30px">
                        <telerik:RadTextBox ID="txtCountry" Runat="server" Height="25px" Width="300px">
                        </telerik:RadTextBox>
                    </td>
                </tr>
                <tr>
                    <td class="auto-style62">Phone</td>
                    <td class="auto-style26">
                        <telerik:RadTextBox ID="txtPhone" Runat="server" Height="25px" Width="300px">
                        </telerik:RadTextBox>
                    </td>
                    <td class="auto-style18">
                        &nbsp;</td>
                    <td class="auto-style63">
                        Fax</td>
                    <td style="height: 30px">
                        <telerik:RadTextBox ID="txtFax" Runat="server" Height="25px" Width="300px">
                        </telerik:RadTextBox>
                    </td>
                </tr>
                <tr>
                    <td class="auto-style10">Email</td>
                    <td class="auto-style15">
                        <telerik:RadTextBox ID="txtEmail" Runat="server" Height="25px" Width="300px">
                        </telerik:RadTextBox>
                    </td>
                    <td class="auto-style20">
                        </td>
                    <td class="auto-style30">
                        Website</td>
                    <td class="auto-style11">
                        <telerik:RadTextBox ID="txtWeb" Runat="server" Height="25px" Width="300px">
                        </telerik:RadTextBox>
                    </td>
                </tr>
                <tr>
                    <td class="auto-style62">Contact Name</td>
                    <td class="auto-style26">
                        <telerik:RadTextBox ID="txtCP" Runat="server" Height="25px" Width="300px">
                        </telerik:RadTextBox>
                    </td>
                    <td class="auto-style18">
                        &nbsp;</td>
                    <td class="auto-style63">
                        Contact Cell</td>
                    <td style="height: 30px">
                        <telerik:RadTextBox ID="txtCPCell" Runat="server" Height="25px" Width="300px">
                        </telerik:RadTextBox>
                    </td>
                </tr>
                <tr>
                    <td class="auto-style62">GL Code</td>
                    <td class="auto-style26">
                        <telerik:RadTextBox ID="txtGLCode" Runat="server" Height="25px" Width="300px">
                        </telerik:RadTextBox>
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
                        <telerik:RadButton ID="btnSubmit" runat="server" Text="Submit" Font-Size="10pt" Height="30px" ButtonType="SkinnedButton">
                        </telerik:RadButton>
                    </td>
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
