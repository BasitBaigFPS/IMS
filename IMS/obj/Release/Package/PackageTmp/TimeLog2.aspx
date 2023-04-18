<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="TimeLog2.aspx.cs" Inherits="IMS.TimeLog2" %>

<!DOCTYPE html>

<html style="height:100%; margin:0; padding:0">
	<head>
		<meta http-equiv="Content-Type" content="text/html; charset=UTF-8"/>
		<title>Clock</title>
		<style type="text/css">
			/* Customizable font and colors */
			html {
				background: #000000;
				font-family: sans-serif;
				font-weight: bold;
				color: #F8F817;
			}
		</style>





	</head>
	
	<body style="display:flex; height:70%; margin:0; padding:0; justify-content:center; align-items:center">

      
        
               <h1>Time System</h1>
        
        <br />
        <p>
        <span id="clocktext" style="font-kerning: none"></span></p>
		<script type="text/javascript">
		    "use strict";

		    var textElem = document.getElementById("clocktext");
		    var targetWidth = 0.9;  // Proportion of full screen width
		    var curFontSize = 20;  // Do not change

		    function updateClock() {
		        var d = new Date();
		        var s = "";
		        s += ((d.getHours() + 11) % 12 + 1) + ":";
		        s += (10 > d.getMinutes() ? "0" : "") + d.getMinutes() + ":";
		        s += (10 > d.getSeconds() ? "0" : "") + d.getSeconds() + "\u00A0";
		        s += d.getHours() >= 12 ? "pm" : "am";
		        textElem.textContent = s;
		        setTimeout(updateClock, 1000 - d.getTime() % 1000 + 20);
		    }

		    function updateTextSize() {
		        for (var i = 0; 3 > i; i++) {  // Iterate for better better convergence
		            curFontSize *= targetWidth / (textElem.offsetWidth / textElem.parentNode.offsetWidth);
		            textElem.style.fontSize = curFontSize + "pt";
		        }
		    }

		    updateClock();
		    updateTextSize();
		    window.addEventListener("resize", updateTextSize);
		</script>
	</body>
</html>
