<%@ Page Language="C#"  AutoEventWireup="true" CodeBehind="Default.aspx.cs" Inherits="Default" %>


 
<!DOCTYPE html PUBLIC "-//W3C//DTD XHTML 1.0 Transitional//EN" "http://www.w3.org/TR/xhtml1/DTD/xhtml1-transitional.dtd">

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">

	<title></title>
    <!--[if lte IE 9]>
<div id="warning">
<h4 class="red">Your Browser Is Not Supported!</h4><br />
<p>Please upgrade to <a href='http://getfirefox.com'>FireFox</a>, <a href='http://www.opera.com/download/'>Opera</a>, <a href='http://www.apple.com/safari/'>Safari</a> or <a href='http://www.microsoft.com/windows/downloads/ie/getitnow.mspx'>Internet Explorer 7 or 8</a>. Thank You!&nbsp;&nbsp;&nbsp;<a href="#" onClick="document.getElementById('warning').style.display = 'none';"><b>Close Window</b></a></p>
</div>
<![endif]-->
  
 
	<telerik:RadStyleSheetManager id="RadStyleSheetManager1" runat="server" />
</head>

<body>

    <form id="form1" runat="server">
	<telerik:RadScriptManager ID="RadScriptManager1" runat="server">
		<Scripts>
			<asp:ScriptReference Assembly="Telerik.Web.UI" Name="Telerik.Web.UI.Common.Core.js" />
			<asp:ScriptReference Assembly="Telerik.Web.UI" Name="Telerik.Web.UI.Common.jQuery.js" />
			<asp:ScriptReference Assembly="Telerik.Web.UI" Name="Telerik.Web.UI.Common.jQueryInclude.js" />
		</Scripts>
	
	</telerik:RadScriptManager>
          <script type="text/javascript">
                     //Put your JavaScript code here.

         </script>   

	<telerik:RadAjaxManager ID="RadAjaxManager1" runat="server">
	</telerik:RadAjaxManager>
	<div>

	</div>
	</form>
</body>
</html>
