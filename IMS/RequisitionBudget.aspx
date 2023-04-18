<%@ Page Title="" Language="C#" MasterPageFile="~/Site1.Master" AutoEventWireup="true" CodeBehind="RequisitionBudget.aspx.cs" Inherits="IMS.RequisitionBudget" %>


<asp:Content ID="Content1" ContentPlaceHolderID="HeadContent" runat="server">
    <style type="text/css">
        .auto-style4 {
            border-collapse: collapse;
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

        .auto-style12 {
            width: 1166px;
        }

        .auto-style14 {
            width: 166px;
        }

        .auto-style15 {
            height: 22px;
            width: 166px;
        }

        .auto-style19 {
            width: 434px;
            font-family: Arial, Helvetica, sans-serif;
            font-size: medium;
            height: 33px;
            color: #C0C0C0;
        }

        .auto-style20 {
            height: 33px;
            width: 434px;
        }

        .newStyle1 {
            font-family: Calibri;
            font-size: large;
            text-align: center;
        }

        .auto-style21 {
            height: 19px;
            font-size: large;
        }

        .auto-style25 {
            text-align: left;
        }

        .auto-style26 {
            height: 33px;
        }

        .auto-style27 {
            height: 22px;
            width: 166px;
            background-color: #0066FF;
        }

        </style>
    <link href="CSS/GridViewStyle1.css" rel="stylesheet" type="text/css" />
</asp:Content>

<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">

     <div class="CSSTableGenerator">


        <table class="auto-style12">

            <tr>
                <td class="auto-style8"></td>
                <td colspan="2" style="valign="middle" align="center">
                    <h1 style="font-weight: bold; font-size: medium; color: #000000;"><span style="text-align: center">
                        <em>NEW REQUISITION SETUP</em></span></h1>
                </td>
               
                <td class="auto-style4"></td>
                <td class="auto-style14"></td>
            </tr>
            <tr>
                <td class="auto-style21">&nbsp;</td>
                <td class="auto-style20">&nbsp;</td>                
                <td class="auto-style19">&nbsp;</td>
                <td class="auto-style27" valign="middle">&nbsp;
                    <telerik:RadButton ID="btnClose" runat="server" Text="Close" Font-Size="10pt" Height="30px" ButtonType="SkinnedButton" OnClick="btnClose_Click" Width="72px">
                        </telerik:RadButton>
                </td>
                 <td class="auto-style14"></td>
            </tr>
            <tr>
                <td class="auto-style21">&nbsp;</td>
                <td align="left" class="auto-style25" style="text-align: left"><span style="font-size: small">Requisition Type:&nbsp;&nbsp;</span>&nbsp;&nbsp;&nbsp;&nbsp; &nbsp;
                    <asp:DropDownList ID="ddlReqType" AutoPostBack="true"
                        AppendDataBoundItems="true" runat="server" Height="25px" Width="278px"
                        OnSelectedIndexChanged="ddlReqType_SelectedIndexChanged" Font-Bold="True"
                        ForeColor="#000000">
                    </asp:DropDownList>
                </td>
                <td class="auto-style19">&nbsp;</td>
                <td class="auto-style15">
                    <asp:Label ID="lblCheckBudgState" runat="server" Text="lblCheckBudgState" Visible="False"></asp:Label>
                </td>
                 <td class="auto-style14"></td>
            </tr>
            <tr>
                <td class="auto-style7">&nbsp;</td>
                <td style="text-align: left"><span style="font-size: small">Requisition Sub Type:
                </span>
                    <asp:DropDownList ID="ddlReqSubType" AutoPostBack="true"
                        AppendDataBoundItems="true" runat="server" Height="25px"
                        Width="276px" OnSelectedIndexChanged="ddlReqSubType_SelectedIndexChanged" Font-Bold="True"
                        ForeColor="#000000">
                    </asp:DropDownList>
                </td>
                <td class="auto-style19">&nbsp;</td>
                <td class="auto-style15">&nbsp;</td>
                 <td class="auto-style14"></td>
            </tr>
            <tr>
                <td class="auto-style7">&nbsp;</td>
                <td style="text-align: left"><span style="font-size: small">Requisition Period:</span>&nbsp;&nbsp;&nbsp;&nbsp;
                    <asp:DropDownList ID="ddlQuarter" AutoPostBack="true" AppendDataBoundItems="true"
                        runat="server" Height="25px" Width="274px" Font-Bold="True" ForeColor="#000000" OnSelectedIndexChanged="ddlQuarter_SelectedIndexChanged">
                    </asp:DropDownList>
                </td>
                <td class="auto-style19">
                    <asp:TextBox ID="txtmonths" runat="server" Width="392px" BackColor="Yellow" ForeColor="Black" Visible="False"></asp:TextBox>
                </td>
                <td class="auto-style15">&nbsp;</td>
                 <td class="auto-style14"></td>
            </tr>
            <tr>
                <td class="auto-style7">&nbsp;</td>
                <td style="text-align: left"><span style="font-size: small">Academic Year:&nbsp;&nbsp;&nbsp;&nbsp;&nbsp; </span>&nbsp;&nbsp;&nbsp;
                    <asp:DropDownList ID="ddlAcdYear" AutoPostBack="true" AppendDataBoundItems="true"
                        runat="server" Height="25px" Width="274px" Font-Bold="True" ForeColor="#000000">
                    </asp:DropDownList>
                </td>
                <td class="auto-style19"> Last Submission Date:
                    <input type="date" id="txtSubmissionDate" runat="server" visible="true" />
                      
                </td>
                <td class="auto-style15">
                  &nbsp;
                </td>
                 <td class="auto-style14">
                     &nbsp;
                 </td>
            </tr>
            <tr id="syschoice1" runat="server">
                <td class="auto-style7">&nbsp;</td>
                <td class="auto-style26" colspan="2">
                    <asp:RadioButtonList ID="rdoSysChoice" runat="server" AutoPostBack="True" OnSelectedIndexChanged="rdoSysChoice_SelectedIndexChanged" RepeatDirection="Horizontal" Style="font-size: small" Width="784px" Font-Bold="True" ForeColor="Black">
                        <asp:ListItem Value="1">FPS Karachi</asp:ListItem>
                        <asp:ListItem Value="2">FPS Hyderabad</asp:ListItem>
                        <asp:ListItem Value="3">HSS Karachi</asp:ListItem>
                    </asp:RadioButtonList>
                </td>
                <td class="auto-style19">&nbsp;</td>
                <td class="auto-style15">&nbsp;</td>
            </tr>
            <tr id="syschoice2" style="display:none;" runat="server">
                <td class="auto-style7">&nbsp;</td>
                <td class="auto-style26" colspan="2">
                      <asp:Button ID="btnGenerateITRequisition" runat="server" OnClick="btnGenerateITRequisition_Click" Text="Generate I.T Requisition Setup" Width="176px" />
                </td>
                <td class="auto-style19">&nbsp;</td>
                <td class="auto-style15">&nbsp;</td>
            </tr>
            <tr>
                <td>&nbsp;</td>
                <td align="center" colspan="5" style="font-family: Calibri;  font-weight: normal; font-size: 14px;" valign="top">

                    <div id="mirdiv" style="display: none" runat="server">
                        <table cellspacing="1" style="width: 100%" align="center">
                        
                            <tr>
                                <td>&nbsp;</td>
                                <td>&nbsp;</td>
                                <td>&nbsp;</td>
                                <td>&nbsp;</td>
                                <td>&nbsp;</td>
                            </tr>



                            <tr>

                                <td colspan="3" style="width: 350px; text-align: left;" align="center" valign="middle">
                                    <asp:GridView ID="grdItems" runat="server" AlternatingRowStyle-CssClass="alt" AutoGenerateColumns="False" CssClass="mGrid" OnRowCommand="grdItems_RowCommand" OnRowDeleting="grdItems_RowDeleting" OnRowEditing="grdItems_RowEditing" OnRowUpdating="grdItems_RowUpdating" PagerStyle-CssClass="pgr" Style="font-size: x-small; text-align: left;" Width="600px" OnRowDataBound="grdItems_RowDataBound" HorizontalAlign="Center">
                                        <AlternatingRowStyle CssClass="alt" />
                                        <Columns>
                                            <%--<asp:CommandField ShowDeleteButton="True">
                                                <ControlStyle Width="20px" />
                                                <ItemStyle HorizontalAlign="Center" VerticalAlign="Middle" Width="10px" />
                                            </asp:CommandField>--%>
                                           <asp:CommandField ShowDeleteButton="True"  ControlStyle-Width="50px"/>
                                              <asp:BoundField DataField="fkcomid" Visible="false">
                                            </asp:BoundField>
                                               <asp:BoundField DataField="fksysid"  Visible="false">
                                            </asp:BoundField>
                                               <asp:BoundField DataField="brhcode"  Visible="false">
                                            </asp:BoundField>
                                            
                                            <asp:TemplateField HeaderText="BrhID" Visible="false">
                                                    <ItemTemplate>
                                                        <asp:Label ID="lblBrhID" runat="server" Text='<%#Eval("pkbrhID") %>' />
                                                    </ItemTemplate>
                                                    <ItemStyle HorizontalAlign="Right" VerticalAlign="Middle" />
                                             </asp:TemplateField>

                                            <asp:BoundField DataField="brhname" HeaderText="Branch Name">
                                                <ControlStyle Width="350px"/>
                                                <HeaderStyle Font-Size="12pt" HorizontalAlign="Center" VerticalAlign="Middle"  Width="350px"/>
                                                <ItemStyle HorizontalAlign="Left" VerticalAlign="Middle" Width="150px" />
                                            </asp:BoundField>

                                            <asp:TemplateField HeaderText="Strength">
                                                <ItemTemplate>
                                                    <asp:TextBox ID="txtstrength" runat="server" AutoPostBack="True"   OnTextChanged="txtstrength_TextChanged" Text='<%#Eval("strength") %>' Width="50px" TextMode="Number"></asp:TextBox>
                                                </ItemTemplate>
                                                <ControlStyle Width="80px" />
                                                <HeaderStyle Font-Size="12pt" HorizontalAlign="Center" VerticalAlign="Middle" />
                                                <ItemStyle HorizontalAlign="Center" VerticalAlign="Middle" Width="30px" />
                                            </asp:TemplateField>


                                            <asp:TemplateField HeaderText="PerHeadCost">
                                                <ItemTemplate>
                                                    <asp:TextBox ID="txtperhead" runat="server" AutoPostBack="True" OnTextChanged="txtperhead_TextChanged" Text='<%#Eval("phcost") %>' Width="50px" TextMode="Number"></asp:TextBox>
                                                </ItemTemplate>
                                                <ControlStyle Width="80px" />
                                                <HeaderStyle Font-Size="12pt" HorizontalAlign="Center" VerticalAlign="Middle" />
                                                <ItemStyle HorizontalAlign="Center" VerticalAlign="Middle" Width="30px" />
                                            </asp:TemplateField>

                                            <asp:TemplateField HeaderText="Budget Amount">
                                                <ItemTemplate>
                                                    <asp:TextBox ID="txtBudget" runat="server" AutoPostBack="True" OnTextChanged="txtBudget_TextChanged" Text='<%#Eval("budget") %>' Width="50px" TextMode="Number"></asp:TextBox>
                                                </ItemTemplate>
                                                <ControlStyle Width="80px" />
                                                <HeaderStyle Font-Size="12pt" HorizontalAlign="Center" />
                                                <ItemStyle HorizontalAlign="Center" VerticalAlign="Middle" Width="80px" />
                                            </asp:TemplateField>
                                        </Columns>
                                        <PagerStyle CssClass="pgr" />
                                    </asp:GridView>
                                </td>
                            </tr>
                            
                           <%--  <tr>
                                <td class="auto-style81">&nbsp;</td>
                                <td class="auto-style89">&nbsp;</td>
                                <td>&nbsp;</td>
                                <td class="auto-style85">&nbsp;</td>
                                <td>&nbsp;</td>
                            </tr>--%>

                           

                        </table>
                    </div>

                </td>
            </tr>
            <tr>
                <td class="auto-style7">&nbsp;</td>
                <td class="auto-style20">&nbsp;</td>
                <td style="text-align: right">
                    <asp:Button ID="btnSaveBudget" runat="server" OnClick="btnSaveBudget_Click" Text="Save Budget" Width="176px" />
                </td>
                <td class="auto-style15">&nbsp;</td>
                 <td class="auto-style14"></td>
            </tr>
           


        </table>

    </div>

</asp:Content>

<asp:Content ID="Content3" ContentPlaceHolderID="MainContent" runat="server">

   


</asp:Content>
