<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="IMSDashboard.aspx.cs" Inherits="IMS.IMSDashboard" %>

<%@ Register assembly="JDash.WebForms" namespace="JDash.WebForms" tagprefix="jdash" %>

<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <title></title>
</head>
<body>
    <form id="form1" runat="server">
    <div>
    
        <asp:ScriptManager ID="ScriptManager1" runat="server">
        </asp:ScriptManager>
    
        <jdash:ResourceManager ID="ResourceManager1" runat="server" />
        <br />
        <jdash:DashboardView ID="DashboardView1" runat="server" />
        <br />
        <br />
    
    </div>
    </form>
</body>
</html>
