<%@ Control Language="C#" AutoEventWireup="true" CodeBehind="HtmlDashletEditor.ascx.cs" Inherits="IMS.JDash.Dashlets.HtmlDashletEditor" %>

<%@ Register assembly="JDash.WebForms" namespace="JDash.WebForms" tagprefix="jdash" %>
<jdash:DashletTitleEditor ID="DashletTitleEditor1" runat="server" />
<jdash:DashletStylesList ID="DashletStylesList1" runat="server" />
<p>
<asp:TextBox ID="htmlInput" runat="server" Rows="5" TextMode="MultiLine"></asp:TextBox> 
</p>
 
