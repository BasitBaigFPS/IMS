<%@ Page Title="" Language="C#" MasterPageFile="~/Site1.Master" AutoEventWireup="true" CodeBehind="WarehouseMain.aspx.cs" Inherits="IMS.WarehouseMain" %>

<%@ Register TagPrefix="telerik" Namespace="Telerik.Web.UI" Assembly="Telerik.Web.UI" %>

<asp:Content ID="HeaderContent" runat="server" ContentPlaceHolderID="HeadContent">
</asp:Content>
<asp:Content ID="BodyContent" runat="server" ContentPlaceHolderID="MainContent">

      <asp:TextBox ID="txtbranchID" runat="server" Visible="False" Width="16px"></asp:TextBox>
      <asp:TextBox ID="txtstoreID" runat="server" Visible="False" Width="16px"></asp:TextBox>


        <div class="enjoy-css" style="
    display: inline-block;
    position: fixed;
    top: 0;
    bottom: 0;
    left: 0;
    right: 0;
    width: 200px;
    height: 100px;
    margin: auto;
    background-color: #f3f3f3;">IMS</div>



</asp:Content>

