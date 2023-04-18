<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="frmImagesTesting.aspx.cs" Inherits="IMS.frmImagesTesting" %>

<!DOCTYPE html PUBLIC "-//W3C//DTD XHTML 1.0 Transitional//EN" "http://www.w3.org/TR/xhtml1/DTD/xhtml1-transitional.dtd">
<html xmlns="http://www.w3.org/1999/xhtml">



<head runat="server">
    <title></title>

    <link href="Scripts/css/jquery.Jcrop.css" rel="stylesheet" type="text/css" />
    <link href="Scripts/css/jquery.Jcrop.min.css" rel="stylesheet" type="text/css" />
<%--    <script type="text/javascript" src="http://ajax.googleapis.com/ajax/libs/jquery/1.3/jquery.min.js"></script>--%>
  <%--  <script type="text/javascript" src="script/jquery.Jcrop.pack.js"></script>--%>

    <script type="text/javascript" src="../Scripts/js/jquery.Jcrop.js"></script>
    <script type="text/javascript" src="../Scripts/js/jquery.Jcrop.min.js"></script>
    <script type="text/javascript" src="../Scripts/js/jquery.color.js"></script>
    <script type="text/javascript" src="../Scripts/js/jquery.min.js"></script>

    <script type="text/javascript">
        jQuery(document).ready(function () {
            jQuery('#imgCrop').Jcrop({
                onSelect: storeCoords
            });

        });
        function storeCoords(c) {
            jQuery('#X').val(c.x);
            jQuery('#Y').val(c.y);
            jQuery('#W').val(c.w);
            jQuery('#H').val(c.h);
        };

    </script>

    <script src="Scripts/js/jquery.min.js"></script>
    <script src="Scripts/js/jquery.Jcrop.js"></script>
    <link rel="stylesheet" href="Scripts/css/main.css" type="text/css" />
    <link rel="stylesheet" href="Scripts/css/demos.css" type="text/css" />
    <link rel="stylesheet" href="Scripts/css/jquery.Jcrop.css" type="text/css" />

    <script type="text/javascript">

        $(function () {

            $('#cropbox').Jcrop({
                aspectRatio: 1,
                onSelect: updateCoords
            });

        });

        function updateCoords(c) {
            $('#x').val(c.x);
            $('#y').val(c.y);
            $('#w').val(c.w);
            $('#h').val(c.h);
        };

        function checkCoords() {
            if (parseInt($('#w').val())) return true;
            alert('Please select a crop region then press submit.');
            return false;
        };

</script>
    <style type="text/css">
        #target {
            background-color: #ccc;
            width: 500px;
            height: 330px;
            font-size: 24px;
            display: block;
        }
    </style>



   

</head>
<body>

     


    <form id="form1" runat="server">

        <div>

            <asp:Panel ID="pnlUpload" runat="server">

                <asp:FileUpload ID="Upload" runat="server" />

                <br />

                <asp:Button ID="btnUpload" runat="server" OnClick="btnUpload_Click" Text="Upload" />

                <asp:Label ID="lblError" runat="server" Visible="false" />
                <asp:Label ID="Label1" runat="server" Visible="false" />
            </asp:Panel>

            <asp:Panel ID="pnlCrop" runat="server" Visible="false">

                <asp:Image ID="imgCrop" runat="server" />

                <br />

                <asp:HiddenField ID="X" runat="server" />

                <asp:HiddenField ID="Y" runat="server" />

                <asp:HiddenField ID="W" runat="server" />

                <asp:HiddenField ID="H" runat="server" />

                <asp:Button ID="btnCrop" runat="server" Text="Crop" OnClick="btnCrop_Click" />

            </asp:Panel>

            <asp:Panel ID="pnlCropped" runat="server" Visible="false">

                <asp:Image ID="imgCropped" runat="server" />

            </asp:Panel>

        </div>

    </form>
</body>
</html>