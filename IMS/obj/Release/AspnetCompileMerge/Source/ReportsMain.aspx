<%@ Page Language="C#" MasterPageFile="~/Site1.Master" AutoEventWireup="true" CodeBehind="ReportsMain.aspx.cs" Inherits="IMS.ReportsMain" %>

<%@ Register assembly="Telerik.ReportViewer.WebForms, Version=7.2.13.1016, Culture=neutral, PublicKeyToken=a9d7983dfcc261be" namespace="Telerik.ReportViewer.WebForms" tagprefix="telerik" %>



<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">
    <div>  

   </div>          
    <div>  
        <telerik:ReportViewer ID="ReportViewer1" runat="server" Height="602px" Width="918px">
             
        </telerik:ReportViewer>  
    </div>
 
</asp:Content>







