<%@ Page Title="" Language="C#" MasterPageFile="~/Site1.Master" AutoEventWireup="true" CodeBehind="CustomBalanceUpdate.aspx.cs" Inherits="IMS.CustomBalanceUpdate" %>
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
        width: 282px;
        font-family: Arial, Helvetica, sans-serif;
        font-size: medium;
        height: 33px;
        color: #C0C0C0;
    }
        .auto-style13 {
            height: 19px;
            width: 459px;
        }
        .auto-style15 {
            height: 33px;
            width: 459px;
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
            width: 282px;
            font-family: Arial, Helvetica, sans-serif;
            font-size: medium;
        }
        .auto-style25 {
        width: 459px;
    }
        .auto-style26 {
        height: 30px;
        width: 459px;
        text-align: center;
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
        width: 282px;
        font-family: Arial, Helvetica, sans-serif;
        font-size: xx-large;
            height: 10px;
        }
        .auto-style55 {
        width: 459px;
        font-family: Arial, Helvetica, sans-serif;
        font-size: small;
        color: #C0C0C0;
        height: 55px;
    }
    .auto-style56 {
        width: 282px;
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
        width: 459px;
        font-family: Arial, Helvetica, sans-serif;
        font-size: xx-large;
        color: #D1D1D1;
            height: 10px;
        }
    .auto-style62 {
            width: 282px;
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
            width: 282px;
            font-family: Arial, Helvetica, sans-serif;
            font-size: xx-large;
        }
        .auto-style67 {
            width: 282px;
            height: 10px;
        }
        .auto-style68 {
            width: 282px;
            font-family: Arial, Helvetica, sans-serif;
            font-size: medium;
            height: 31px;
        }
        .auto-style69 {
            height: 30px;
            width: 459px;
            text-align: left;
            color: #000000;
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
                    <td class="auto-style66">&nbsp;</td>
                    <td class="auto-style25">&nbsp;</td>
                    <td class="auto-style31">&nbsp;</td>
                    <td class="auto-style27">&nbsp;</td>
                    <td>&nbsp;</td>
                </tr>
                <tr>
                    <td class="auto-style32" style="background-color: #F7F7F7; "></td>
                    <td class="auto-style61" style="background-color: #F7F7F7; "></td>
                    <td class="auto-style31" style="background-color: #F7F7F7; height: 10px;"></td>
                    <td class="auto-style27" style="background-color: #F7F7F7; height: 10px;"></td>
                    <td style="background-color: #F7F7F7; height: 10px;"></td>
                </tr>
                <tr>
                    <td class="auto-style56" style="background-color: #F7F7F7; text-align: center;">
                        <img alt="" class="auto-style64" src="images/PostBalance.png" /></td>
                    <td class="auto-style55" style="background-color: #F7F7F7">
                        <dl>
                            <dd>
                                <h1><strong><span class="auto-style65">Inventory Balance Update</span></strong></h1>
                            </dd>
                        </dl>
                    </td>
                    <td class="auto-style57" style="background-color: #F7F7F7"></td>
                    <td class="auto-style58" style="background-color: #F7F7F7"></td>
                    <td class="auto-style59" style="background-color: #F7F7F7"></td>
                </tr>
                <tr>
                    <td class="auto-style67"></td>
                    <td class="auto-style13">
              
                    </td>
                    <td class="auto-style21">&nbsp;</td>
                    <td class="auto-style28">&nbsp;</td>
                    <td class="auto-style7">&nbsp;</td>
                </tr>
                <tr>
                    <td class="auto-style62">&nbsp;</td>
                    <td class="auto-style26">
                        <asp:UpdatePanel ID="UpdatePanel1" runat="server">
                        </asp:UpdatePanel>
                    </td>
                    <td class="auto-style18">
                        &nbsp;</td>
                    <td class="auto-style63">
                        &nbsp;</td>
                    <td style="height: 30px">
                        &nbsp;</td>
                </tr>
                <tr>
                    <td class="auto-style62">&nbsp;</td>
                    <td class="auto-style26">

                        <asp:UpdateProgress ID="updProgress"
                            AssociatedUpdatePanelID="UpdatePanel2"
                            runat="server">
                            <ProgressTemplate>
                                <img alt="progress" src="images/BalanceUpdate.gif" style="width: 284px" />
                            </ProgressTemplate>
                        </asp:UpdateProgress>

                        <asp:UpdatePanel ID="UpdatePanel2" runat="server">
                            <ContentTemplate>
                                <asp:Label ID="lblText" runat="server" Text=""></asp:Label>
                                <br />
                            </ContentTemplate>
                        </asp:UpdatePanel>



                    </td>
                    <td class="auto-style18">
                        &nbsp;</td>
                    <td class="auto-style63">
                        &nbsp;</td>
                    <td style="height: 30px">
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
                    <td class="auto-style69">
                        <label for="txtDateFrom">From Date : </label><input id="txtDateFrom" type="date" value="" runat="server"/> 
                        <label for="txtDateTo">To Date : </label><input id="txtDateTo" type="date" value="" runat="server"/> 

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
                        &nbsp;</td>
                </tr>
                <tr>
                    <td class="auto-style68">&nbsp;</td>
                    <td class="auto-style26">
                                <asp:Button ID="btnInvoke" runat="server" Text="Update Balance"
                                    OnClick="btnInvoke_Click" Width="231px" />
                            </td>
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
