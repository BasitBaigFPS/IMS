<%@ Page Title="" Language="C#" MasterPageFile="~/Site1.Master" AutoEventWireup="true" CodeBehind="DeptInventory.aspx.cs" Inherits="IMS.DeptInventory" %>

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

        .auto-style66 {
            width: 100%;
        }
        .auto-style67 {
            height: 31px;
        }
    </style>

</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">
    <telerik:RadCodeBlock ID="dfg" runat="server">
        <script type="text/javascript">
            

        </script>
    </telerik:RadCodeBlock>
    <telerik:RadWindow ID="NewType" runat="server" DestroyOnClose="True" EnableShadow="True" KeepInScreenBounds="True" Modal="True" ReloadOnShow="True" VisibleStatusbar="False" VisibleTitlebar="False">
        <ContentTemplate>
            <table cellpadding="0" class="auto-style2" style="width: 94%; margin-left: 12px">
                <tr>
                    <td class="auto-style44">&nbsp;</td>
                    <td class="auto-style46">&nbsp;</td>
                </tr>
                <tr>
                    <td class="auto-style44">New Type</td>
                    <td class="auto-style46">
                        <telerik:RadTextBox ID="txtNew" runat="server" Height="25px" Width="200px">
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

    <telerik:RadWindow ID="NewCatagory" runat="server" DestroyOnClose="True" EnableShadow="True" KeepInScreenBounds="True" Modal="True" ReloadOnShow="True" VisibleStatusbar="False" VisibleTitlebar="False">
        <ContentTemplate>
            <table cellpadding="0" class="auto-style2" style="width: 94%; margin-left: 12px">
                <tr>
                    <td class="auto-style47">&nbsp;</td>
                    <td class="auto-style46">&nbsp;</td>
                </tr>
                <tr>
                    <td class="auto-style47">New Catagory</td>
                    <td class="auto-style46">
                        <telerik:RadTextBox ID="txtCatagory" runat="server" Height="25px" Width="200px">
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
                        <td class="auto-style32" style="background-color: #F7F7F7; height: 10px;"></td>
                        <td class="auto-style61" style="background-color: #F7F7F7; height: 10px;"></td>
                        <td class="auto-style31" style="background-color: #F7F7F7; height: 10px;"></td>
                        <td class="auto-style27" style="background-color: #F7F7F7; height: 10px;"></td>
                        <td style="background-color: #F7F7F7; height: 10px;"></td>
                    </tr>
                    <tr>
                        <td class="auto-style56" style="background-color: #F7F7F7; text-align: center;">
                            <img alt="" class="auto-style64" src="images/Items.png" /></td>
                        <td class="auto-style55" style="background-color: #F7F7F7"><strong>Department Inventory</strong></td>
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
                        <td class="auto-style62" colspan="5">
                            <telerik:RadAjaxPanel ID="RadAjaxPanel2" runat="server" Width="300px" HorizontalAlign="NotSet" LoadingPanelID="RadAjaxLoadingPanel2" RenderMode="Inline">
                                <table class="auto-style66">
                                    <tr>
                                        <td class="auto-style67">Branch</td>
                                        <td class="auto-style67">
                                            <telerik:RadComboBox ID="cmbbranch" Runat="server" AutoPostBack="True" MarkFirstMatch="True" OnSelectedIndexChanged="cmbbranch_SelectedIndexChanged" Sort="Ascending" Width="300px">
                                            </telerik:RadComboBox>
                                        </td>
                                        <td class="auto-style67"></td>
                                        <td class="auto-style67">Store</td>
                                        <td class="auto-style67">
                                            <telerik:RadComboBox ID="cmbStores" Runat="server" AutoPostBack="True" MarkFirstMatch="True" OnSelectedIndexChanged="cmbStores_SelectedIndexChanged" Sort="Ascending" Width="300px">
                                            </telerik:RadComboBox>
                                        </td>
                                    </tr>
                                    <tr>
                                        <td>Department</td>
                                        <td>
                                            <telerik:RadComboBox ID="cmbDepartment" Runat="server" MarkFirstMatch="True" MaxHeight="300px" ShowMoreResultsBox="True" Sort="Ascending" ValidationGroup="B" Width="300px" OnSelectedIndexChanged="cmbDepartment_SelectedIndexChanged">
                                            </telerik:RadComboBox>
                                        </td>
                                        <td>&nbsp;</td>
                                        <td>&nbsp;</td>
                                        <td>&nbsp;</td>
                                    </tr>
                                    <tr>
                                        <td>Catagory</td>
                                        <td>
                                            <telerik:RadComboBox ID="cmbCatagories" runat="server" AutoPostBack="True" OnSelectedIndexChanged="cmbCatagories_SelectedIndexChanged" Sort="Ascending" Width="300px">
                                            </telerik:RadComboBox>
                                        </td>
                                        <td>&nbsp;</td>
                                        <td>Sub-Catagory</td>
                                        <td>
                                            <telerik:RadComboBox ID="cmbSubCat" runat="server" AutoPostBack="True" OnSelectedIndexChanged="cmbSubCat_SelectedIndexChanged" Sort="Ascending" Width="300px">
                                            </telerik:RadComboBox>
                                        </td>
                                    </tr>
                                    <tr>
                                        <td>Item Head</td>
                                        <td>
                                            <telerik:RadComboBox ID="cmbItemHead" runat="server" AutoPostBack="True" MarkFirstMatch="True" Sort="Ascending" TabIndex="3" Width="300px">
                                            </telerik:RadComboBox>
                                        </td>
                                        <td>&nbsp;</td>
                                        <td>&nbsp;</td>
                                        <td>&nbsp;</td>
                                    </tr>
                                </table>
                            </telerik:RadAjaxPanel>
                        </td>
                    </tr>
                    <tr>
                        <td class="auto-style62">&nbsp;</td>
                        <td class="auto-style26">
                            <telerik:RadAjaxLoadingPanel ID="RadAjaxLoadingPanel2" runat="server" Skin="Default">
                            </telerik:RadAjaxLoadingPanel>
                        </td>
                        <td class="auto-style18">&nbsp;</td>
                        <td class="auto-style63">&nbsp;</td>
                        <td style="height: 30px">&nbsp;</td>
                    </tr>
                    <tr>
                        <td class="auto-style62">&nbsp;</td>
                        <td class="auto-style26">&nbsp;</td>
                        <td class="auto-style18">&nbsp;</td>
                        <td class="auto-style63">&nbsp;</td>
                        <td style="height: 30px; text-align: right;">
                            <telerik:RadButton ID="btnSubmit" runat="server" Text="Submit" Font-Size="10pt" Height="30px" ButtonType="SkinnedButton" OnClick="btnSubmit_Click">
                            </telerik:RadButton>
                        </td>
                    </tr>
                    <tr>
                        <td class="auto-style62">&nbsp;</td>
                        <td class="auto-style26">&nbsp;</td>
                        <td class="auto-style18">&nbsp;</td>
                        <td class="auto-style63">&nbsp;</td>
                        <td style="height: 30px; text-align: right;">&nbsp;</td>
                    </tr>
                    <tr>
                        <td class="auto-style62" colspan="5">
                            <telerik:RadGrid ID="grdStore" runat="server" AutoGenerateColumns="False" CellSpacing="0" GridLines="None">
                                <ExportSettings FileName="ItemList" OpenInNewWindow="True">
                                </ExportSettings>
                                <MasterTableView CommandItemDisplay="Top">
                                    <CommandItemSettings ShowAddNewRecordButton="False" ShowExportToExcelButton="True" ShowExportToPdfButton="True" ShowExportToWordButton="True" ShowRefreshButton="False" />
                                    <RowIndicatorColumn Visible="False">
                                    </RowIndicatorColumn>
                                    <Columns>
                                        <telerik:GridHyperLinkColumn AllowSorting="False" DataNavigateUrlFields="InvCode" DataNavigateUrlFormatString="ReportsMain.aspx?rptname=ItemLedger&INVCode={0}" DataTextField="InvCode" FilterControlAltText="Filter column column" HeaderText="Inv. Code" UniqueName="column">
                                        </telerik:GridHyperLinkColumn>
                                        <telerik:GridBoundColumn DataField="ItemTitle" FilterControlAltText="Filter column1 column" HeaderText="Item Title" UniqueName="column1">
                                            <ColumnValidationSettings>
                                                <ModelErrorMessage Text="" />
                                            </ColumnValidationSettings>
                                        </telerik:GridBoundColumn>
                                        <telerik:GridBoundColumn DataField="ModelBrand" FilterControlAltText="Filter column2 column" HeaderText="Model/Brand" UniqueName="column2">
                                            <ColumnValidationSettings>
                                                <ModelErrorMessage Text="" />
                                            </ColumnValidationSettings>
                                        </telerik:GridBoundColumn>
                                        <telerik:GridBoundColumn DataField="Unit" FilterControlAltText="Filter column3 column" HeaderText="Unit" UniqueName="column3">
                                            <ColumnValidationSettings>
                                                <ModelErrorMessage Text="" />
                                            </ColumnValidationSettings>
                                        </telerik:GridBoundColumn>
                                        <telerik:GridBoundColumn DataField="CRBalance" FilterControlAltText="Filter column4 column" HeaderText="Balance" UniqueName="column3">
                                            <ColumnValidationSettings>
                                                <ModelErrorMessage Text="" />
                                            </ColumnValidationSettings>
                                        </telerik:GridBoundColumn>
                                    </Columns>
                                </MasterTableView>
                            </telerik:RadGrid>

                        </td>
                    </tr>
                    <tr>
                        <td class="auto-style10">&nbsp;</td>
                        <td class="auto-style15">&nbsp;</td>
                        <td class="auto-style20"></td>
                    </tr>
                    <tr>
                        <td class="auto-style62">&nbsp;</td>
                        <td class="auto-style26">&nbsp;</td>
                        <td class="auto-style18">&nbsp;</td>
                        <td class="auto-style29">&nbsp;</td>
                        <td style="height: 30px; text-align: right;">&nbsp;</td>
                    </tr>
                    <tr>
                        <td class="auto-style22">&nbsp;</td>
                        <td class="auto-style26">&nbsp;</td>
                        <td class="auto-style18">&nbsp;</td>
                        <td class="auto-style29">&nbsp;</td>
                        <td style="height: 30px; text-align: right;">&nbsp;</td>
                    </tr>
                    <tr>
                        <td class="auto-style8">&nbsp;</td>
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
