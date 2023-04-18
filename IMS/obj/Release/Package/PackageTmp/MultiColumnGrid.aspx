<%@ Page Title="" Language="C#" MasterPageFile="~/Site1.Master" AutoEventWireup="true" CodeBehind="MultiColumnGrid.aspx.cs" Inherits="IMS.MultiColumnGrid" %>

<%@ Register TagPrefix="telerik" Namespace="Telerik.Web.UI" Assembly="Telerik.Web.UI" %>

<%--<!DOCTYPE html PUBLIC "-//W3C//DTD XHTML 1.1//EN" "http://www.w3.org/TR/xhtml11/DTD/xhtml11.dtd">--%>

<asp:Content ID="Content1" ContentPlaceHolderID="HeadContent" runat="server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">
</asp:Content>
<asp:Content ID="Content3" ContentPlaceHolderID="MainContent" runat="server">


  <%--  <telerik:RadScriptManager runat="server" ID="RadScriptManager1" />--%>
   <%-- <telerik:RadSkinManager ID="RadSkinManager1" runat="server" ShowChooser="true" />--%>
    <telerik:RadAjaxManager ID="RadAjaxManager1" runat="server">
        <AjaxSettings>
            <telerik:AjaxSetting AjaxControlID="RadGrid1">
                <UpdatedControls>
                    <telerik:AjaxUpdatedControl ControlID="RadGrid1" LoadingPanelID="RadAjaxLoadingPanel1"></telerik:AjaxUpdatedControl>
                </UpdatedControls>
            </telerik:AjaxSetting>
        </AjaxSettings>
    </telerik:RadAjaxManager>
    <telerik:RadAjaxLoadingPanel ID="RadAjaxLoadingPanel1" runat="server">
    </telerik:RadAjaxLoadingPanel>
    <telerik:RadGrid ID="RadGrid1" runat="server" ShowGroupPanel="true" AllowSorting="true"
        DataSourceID="SqlDataSource1" AllowPaging="true" PageSize="30" AutoGenerateColumns="false" Width="100%">
        <ClientSettings AllowColumnsReorder="true" AllowDragToGroup="true" ReorderColumnsOnClient="true">
            <Scrolling AllowScroll="true" UseStaticHeaders="true"></Scrolling>
            <Resizing AllowColumnResize="true" EnableRealTimeResize="true" />
        </ClientSettings>



        <GroupingSettings ShowUnGroupButton="true"></GroupingSettings>

        <MasterTableView EnableHeaderContextMenu="true">
            <ColumnGroups>
                <telerik:GridColumnGroup HeaderText="ReqTitle"  Name="Company" HeaderStyle-HorizontalAlign="Center">
                </telerik:GridColumnGroup>
                <telerik:GridColumnGroup HeaderText="Consolidate Total" Name="ConsolidateTotal" HeaderStyle-HorizontalAlign="Center">
                </telerik:GridColumnGroup>
                <telerik:GridColumnGroup HeaderText="FPS Karachi" Name="FPSKarachi" ParentGroupName="Company"
                     HeaderStyle-HorizontalAlign="Center">
                </telerik:GridColumnGroup>
                <telerik:GridColumnGroup HeaderText="FPS Hyderabad" Name="FPSHyderabad" ParentGroupName="Company"
                    HeaderStyle-HorizontalAlign="Center">
                </telerik:GridColumnGroup>
                <telerik:GridColumnGroup HeaderText="HSS Karachi" Name="HSSKarachi" ParentGroupName="Company"
                    HeaderStyle-HorizontalAlign="Center">
                </telerik:GridColumnGroup>
            </ColumnGroups>


            <Columns>
                <telerik:GridBoundColumn UniqueName="SubCatTitle" DataField="SubCatTitle" HeaderText="Item Category" HeaderStyle-HorizontalAlign="Center">
                </telerik:GridBoundColumn>
                <telerik:GridBoundColumn UniqueName="ItemTitle" DataField="ItemTitle" HeaderText="Item Title"   HeaderStyle-HorizontalAlign="Center">
                </telerik:GridBoundColumn>
                <telerik:GridBoundColumn UniqueName="Unit" DataField="Unit" HeaderText="Unit"   HeaderStyle-HorizontalAlign="Center">
                </telerik:GridBoundColumn>
                <telerik:GridBoundColumn UniqueName="BrhCode" DataField="brhCode" ColumnGroupName="FPSKarachi"   HeaderStyle-HorizontalAlign="Center"
                    HeaderText="brhCode">
                </telerik:GridBoundColumn>

               <%-- <telerik:GridBoundColumn UniqueName="City" DataField="City" ColumnGroupName="Location"
                    HeaderText="City">
                </telerik:GridBoundColumn>
                <telerik:GridNumericColumn UniqueName="ID" DataField="ID" ColumnGroupName="Category"
                    HeaderText="ID">
                </telerik:GridNumericColumn>
                <telerik:GridBoundColumn UniqueName="CategoryName" DataField="CategoryName" ColumnGroupName="Category"
                    HeaderText="Name">
                </telerik:GridBoundColumn>
                <telerik:GridBoundColumn UniqueName="ProductName" DataField="ProductName" ColumnGroupName="ProductDetails"
                    HeaderText="Name">
                </telerik:GridBoundColumn>
                <telerik:GridBoundColumn UniqueName="Quantity" DataField="Quantity" ColumnGroupName="ProductDetails"
                    HeaderText="Quantity">
                </telerik:GridBoundColumn>
                <telerik:GridNumericColumn UniqueName="Freight" DataField="Freight" ColumnGroupName="OrderDetails"
                    HeaderText="Freight">
                </telerik:GridNumericColumn>
                <telerik:GridDateTimeColumn UniqueName="OrderDate" DataField="OrderDate" ColumnGroupName="OrderDetails"
                    HeaderText="Date">
                </telerik:GridDateTimeColumn>
                <telerik:GridBoundColumn UniqueName="OrderAddress" DataField="OrderAddress" ColumnGroupName="OrderDetails"
                    HeaderText="Address">
                </telerik:GridBoundColumn>--%>

                <telerik:GridNumericColumn UniqueName="QttyRequired" DataField="QttyRequired" ColumnGroupName="ConsolidateTotal" HeaderStyle-HorizontalAlign="Center" HeaderText="Quantity">
                </telerik:GridNumericColumn>
                 <telerik:GridNumericColumn UniqueName="Rate" DataField="Rate" ColumnGroupName="ConsolidateTotal" HeaderStyle-HorizontalAlign="Center" HeaderText="Rate">
                </telerik:GridNumericColumn>
                 <telerik:GridNumericColumn UniqueName="Amount" DataField="Amount" ColumnGroupName="ConsolidateTotal" HeaderStyle-HorizontalAlign="Center" HeaderText="Amount">
                </telerik:GridNumericColumn>

            </Columns>
        </MasterTableView>
    </telerik:RadGrid>
    <asp:SqlDataSource ID="SqlDataSource1" ConnectionString="<%$ ConnectionStrings:INVENTORY %>"
        ProviderName="System.Data.SqlClient" 
        
        
        SelectCommand="SELECT [Srno],[pkReqID],[fkbrhID],[brhCode],[fkstoreID],[ReqNumber],[brhName],[ReqTitle],[RequisitionSubType],[ReqMonths]
      ,[acdDescription],[empName],[fkReqTypID],[fkReqSubTypID],[fkSubCatID],[SubCatTitle],[ItemHeadTitle],[fkItemID],[ItemTitle],[Unit]
      ,[InStockBalance],[QttyRequired],[Rate],[Amount],[StudStrength],[TotalStrength],[PerHeadCost],[BudgetAmount],[CRBalance],[fkcomID],[brhCity],[Company],[IsActive]
  FROM [INVENTORY].[dbo].[tblRequisition_FullView]" runat="server"></asp:SqlDataSource>




</asp:Content>
