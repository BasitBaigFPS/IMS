<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="DefaultTelerikPivotGrid.aspx.cs" Inherits="IMS.DefaultTelerikPivotGrid" %>

 

<%@ Register TagPrefix="telerik" Namespace="Telerik.QuickStart" %>
<%@ Register TagPrefix="telerik" Namespace="Telerik.Web.UI" Assembly="Telerik.Web.UI" %>

<!DOCTYPE html PUBLIC "-//W3C//DTD XHTML 1.1//EN" "http://www.w3.org/TR/xhtml11/DTD/xhtml11.dtd">

<html xmlns='http://www.w3.org/1999/xhtml'>
<head runat="server">
    <title>Telerik ASP.NET Example</title>
    <link href="styles.css" rel="stylesheet" />

    <style type="text/css">

        .RadPivotGrid_Metro .rpgContentZoneDiv td {
    white-space: nowrap;
            }
 
        .checkBoxesLabel {
            color: #555555;
            font-size: 12px;
            line-height: normal;
            font-weight: bold;
            text-transform: uppercase;
        }
 
        ul.checkbox-list {
            margin:10px 0 0 0;
        }





    </style>



</head>
<body>
    <form id="form1" runat="server">
    <telerik:RadScriptManager runat="server" ID="RadScriptManager1" />
    <telerik:RadSkinManager ID="RadSkinManager1" runat="server" ShowChooser="true" />
        <telerik:RadAjaxLoadingPanel ID="RadAjaxLoadingPanel1" runat="server">
        </telerik:RadAjaxLoadingPanel>
    <telerik:RadAjaxManager ID="RadAjaxManager1" runat="server" DefaultLoadingPanelID="RadAjaxLoadingPanel1">
        <AjaxSettings>
            <telerik:AjaxSetting AjaxControlID="RadPivotGrid1">
                <UpdatedControls>
                    <telerik:AjaxUpdatedControl ControlID="RadPivotGrid1" />
                </UpdatedControls>
            </telerik:AjaxSetting>
            <telerik:AjaxSetting AjaxControlID="ConfiguratorPanel1">
                <UpdatedControls>
                    <telerik:AjaxUpdatedControl ControlID="ConfiguratorPanel1" />
                    <telerik:AjaxUpdatedControl ControlID="RadPivotGrid1" />
                </UpdatedControls>
            </telerik:AjaxSetting>
        </AjaxSettings>
    </telerik:RadAjaxManager>
    <telerik:RadPivotGrid RenderMode="Lightweight" AllowPaging="True" Height="500px"
                ID="RadPivotGrid1" runat="server" ColumnHeaderZoneText="ColumnHeaderZone" OnNeedDataSource="RadPivotGrid1_NeedDataSource1" AggregatesLevel="2">
                <ClientSettings EnableFieldsDragDrop="true">
                    <Scrolling AllowVerticalScroll="true"></Scrolling>
                </ClientSettings>
                <Fields>
                    <telerik:PivotGridRowField DataField="Category" ZoneIndex="0">
                    </telerik:PivotGridRowField>
                    <telerik:PivotGridRowField DataField="ProductName" ZoneIndex="1">
                    </telerik:PivotGridRowField>
                    <telerik:PivotGridColumnField DataField="Year">
                    </telerik:PivotGridColumnField>
                    <telerik:PivotGridColumnField DataField="Quarter" DataFormatString="Quarter {0}">
                    </telerik:PivotGridColumnField>
                    <telerik:PivotGridAggregateField DataField="TotalPrice" Aggregate="Sum" DataFormatString="{0:C}">
                    </telerik:PivotGridAggregateField>
                    <telerik:PivotGridAggregateField DataField="Quantity" Aggregate="Sum">
                    </telerik:PivotGridAggregateField>
                </Fields>
                <SortExpressions>
                    <telerik:PivotGridSortExpression FieldName="TotalPrice" SortOrder="Descending"></telerik:PivotGridSortExpression>
                </SortExpressions>
            </telerik:RadPivotGrid>
    <telerik:ConfiguratorPanel runat="server" ID="ConfiguratorPanel1">
        <Views>
            <qsf:View>
                <label class="checkBoxesLabel">Use check boxes bellow to customize the RadPivotGrid control</label>
                    <ul class="checkbox-list">
                    <li><span class="checkbox">
                        <asp:CheckBox ID="chkBox1" runat="server" Text="AllowSorting" AutoPostBack="true" CssClass="cellType"></asp:CheckBox></span>
                    </li>
                    <li><span class="checkbox">
                        <asp:CheckBox ID="chkBox2" runat="server" Text="ShowColumnHeaderZone" Checked="true" AutoPostBack="true" CssClass="cellType"></asp:CheckBox></span>
                    </li>
                    <li><span class="checkbox">
                        <asp:CheckBox ID="chkBox3" runat="server" Text="ShowRowHeaderZone" Checked="true" AutoPostBack="true"></asp:CheckBox></span>
                    </li>
                    <li><span class="checkbox">
                        <asp:CheckBox ID="chkBox4" runat="server" Text="ShowDataHeaderZone" Checked="true" AutoPostBack="true" CssClass="cellType"></asp:CheckBox></span>
                    </li>
                    <li><span class="checkbox">
                        <asp:CheckBox ID="chkBox5" runat="server" Text="EnableZoneContextMenu" Checked="false" AutoPostBack="true" CssClass="cellType"></asp:CheckBox></span>
                    </li>
                </ul>
            </qsf:View>
        </Views>
    </telerik:ConfiguratorPanel>
    </form>
</body>
</html>
