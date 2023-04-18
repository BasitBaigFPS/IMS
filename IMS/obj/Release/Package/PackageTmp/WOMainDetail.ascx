<%@ Control Language="C#" AutoEventWireup="true" CodeBehind="WOMainDetail.ascx.cs" Inherits="IMS.WOMainDetail" %>

<%@ Register TagPrefix="telerik" Namespace="Telerik.Web.UI" Assembly="Telerik.Web.UI" %>
<table id="Table2" cellspacing="2" cellpadding="1" width="100%" border="0" rules="none"
    style="border-collapse: collapse;">
    <tr class="EditFormHeader">
        <td colspan="2">
            <b>Work Details</b>
        </td>
    </tr>
    <tr>
        <td>
            <table id="Table3" width="450px" border="0" class="module">
                <tr>
                    <td class="title" style="font-weight: bold;" colspan="2">Work Info:</td>
                </tr>
                
                <tr>
                    <td>EstMastID:
                    </td>
                    <td>
                        <asp:TextBox ID="TextBox2" Enabled="false" runat="server" Text='<%# DataBinder.Eval(Container, "DataItem.EstMastID") %>'>
                        </asp:TextBox>
                    </td>
                </tr>
                
                
                <tr>
                    <td>Estimate No:
                    </td>
                    <td>
                        <asp:TextBox ID="TextBox1" Enabled="false" runat="server" Text='<%# DataBinder.Eval(Container, "DataItem.EstimateNo") %>'>
                        </asp:TextBox>
                    </td>
                </tr>

                <tr>
                    <td>Work No:
                    </td>
                    <td>
                        <asp:TextBox ID="TextBox7"  Enabled="false" runat="server" Text='<%# DataBinder.Eval(Container, "DataItem.WorkNo") %>'>
                        </asp:TextBox>
                    </td>
                </tr>
                <tr>
                    <td>Work Description:
                    </td>
                    <td>
                        <asp:TextBox ID="TextBox8" runat="server" width="500px" Text='<%# DataBinder.Eval(Container, "DataItem.WorkDesc") %>'>' TabIndex="1">
                        </asp:TextBox>
                    </td>
                </tr>
                <tr>
                    <td>Cost:
                    </td>
                    <td>
                        <asp:TextBox ID="TextBox9" runat="server" Text='<%# DataBinder.Eval(Container, "DataItem.Cost") %>'>' TabIndex="2">
                        </asp:TextBox>
                    </td>
                </tr>
              <%--  <tr>
                    <td colspan="2">
                        <b>Personal Info:</b>
                    </td>
                </tr>
                <tr>
                    <td>Title Of Courtesy
                    </td>
                    <td>
                        <asp:DropDownList ID="ddlTOC" runat="server" SelectedValue='<%# DataBinder.Eval(Container, "DataItem.TitleOfCourtesy") %>'
                            DataSource='<%# (new string[] { "Dr.", "Mr.", "Mrs.", "Ms." }) %>' TabIndex="7"
                            AppendDataBoundItems="True">
                            <asp:ListItem Selected="True" Text="Select" Value="">
                            </asp:ListItem>
                        </asp:DropDownList>
                    </td>
                </tr>
                <tr>
                    <td>FirstName:
                    </td>
                    <td>
                        <asp:TextBox ID="TextBox2" Text='<%# Bind( "FirstName") %>' runat="server" TabIndex="8">
                        </asp:TextBox>
                    </td>
                </tr>
                <tr>
                    <td>Last Name:
                    </td>
                    <td>
                        <asp:TextBox ID="TextBox3" Text='<%# Bind( "LastName") %>' runat="server" TabIndex="9">
                        </asp:TextBox>
                    </td>
                </tr>
                <tr>
                    <td>Birth Date:
                    </td>
                    <td>
                        <telerik:RadDatePicker ID="BirthDatePicker" runat="server" MinDate="1/1/1900" DbSelectedDate='<%# DataBinder.Eval(Container, "DataItem.BirthDate") %>'
                            TabIndex="4">
                        </telerik:RadDatePicker>
                    </td>
                </tr>
                <tr>
                    <td>Hire Date:
                    </td>
                    <td>
                        <telerik:RadDatePicker ID="HireDatePicker" DbSelectedDate='<%# DataBinder.Eval(Container, "DataItem.HireDate") %>'
                            runat="server" TabIndex="10">
                        </telerik:RadDatePicker>
                    </td>
                </tr>
                <tr>
                    <td>Title:
                    </td>
                    <td>
                        <asp:TextBox ID="TextBox4" Text='<%# DataBinder.Eval(Container, "DataItem.Title") %>' runat="server" TabIndex="11">
                        </asp:TextBox>
                    </td>
                </tr>
                <tr>
                    <td>Home Phone:
                    </td>
                    <td>
                        <telerik:RadMaskedTextBox ID="HomePhoneBox" runat="server" SelectionOnFocus="SelectAll"
                            Text='<%# DataBinder.Eval(Container, "DataItem.HomePhone") %>' PromptChar="_" Mask="(###) ###-####"
                            TabIndex="3">
                        </telerik:RadMaskedTextBox>
                    </td>
                </tr>--%>
            </table>
        </td>
      <%--  <td style="vertical-align: top">
            <table id="Table1" cellspacing="1" cellpadding="1" width="250" border="0" class="module">
                <tr>
                    <td>Notes:
                    </td>
                </tr>
                <tr>
                    <td>
                        <asp:TextBox ID="TextBox1" Text='<%# DataBinder.Eval(Container, "DataItem.Notes") %>' runat="server" TextMode="MultiLine"
                            Rows="5" Columns="40" TabIndex="5">
                        </asp:TextBox>
                    </td>
                </tr>
                <tr>
                    <td>Address:
                    </td>
                </tr>
                <tr>
                    <td>
                        <asp:TextBox ID="TextBox6" Text='<%# DataBinder.Eval(Container, "DataItem.Address") %>' runat="server" TextMode="MultiLine"
                            Rows="2" Columns="40" TabIndex="6">
                        </asp:TextBox>
                    </td>
                </tr>
            </table>
        </td>--%>
    </tr>
    <tr>
        <td colspan="2"></td>
    </tr>
    <tr>
        <td></td>
        <td></td>
    </tr>
    <tr>
        <td align="right" colspan="2">
            <asp:Button ID="btnUpdate" Text='<%# (Container is GridEditFormInsertItem) ? "Insert" : "Update" %>'
                runat="server" CommandName='<%# (Container is GridEditFormInsertItem) ? "PerformInsert" : "Update" %>'></asp:Button>&nbsp;
                                    <asp:Button ID="btnCancel" Text="Cancel" runat="server" CausesValidation="False"
                                        CommandName="Cancel"></asp:Button>
        </td>
    </tr>
</table>