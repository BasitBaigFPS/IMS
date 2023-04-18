<%@ Page Language="C#" MasterPageFile="~/Site1.Master" AutoEventWireup="true" CodeBehind="ReportsMain.aspx.cs" Inherits="IMS.ReportsMain" %>


<%@ Register Assembly="Telerik.ReportViewer.WebForms, Version=9.0.15.225, Culture=neutral, PublicKeyToken=a9d7983dfcc261be" Namespace="Telerik.ReportViewer.WebForms" TagPrefix="telerik" %>


<asp:Content ID="Content1" ContentPlaceHolderID="HeadContent" runat="server">



       
    <style type="text/css">
.RadButton_Default.rbLinkButton.rbRounded{border-color:#8a8a8a;color:#333;background-color:#e8e8e8;background-image:-webkit-linear-gradient(top,#faf9f9 0,#e8e8e8 100%);background-image:-moz-linear-gradient(top,#faf9f9 0,#e8e8e8 100%);background-image:-ms-linear-gradient(top,#faf9f9 0,#e8e8e8 100%);background-image:-o-linear-gradient(top,#faf9f9 0,#e8e8e8 100%);background-image:linear-gradient(top,#faf9f9 0,#e8e8e8 100%)}.RadButton_Default.RadButton.rbLinkButton{background-color:#fafafa;border:1px solid #8a8a8a;_border:1px solid #8a8a8a!important;color:#333}.RadButton_Default.rbLinkButton.rbRounded{border-color:#8a8a8a;color:#333;background-color:#e8e8e8;background-image:-webkit-linear-gradient(top,#faf9f9 0,#e8e8e8 100%);background-image:-moz-linear-gradient(top,#faf9f9 0,#e8e8e8 100%);background-image:-ms-linear-gradient(top,#faf9f9 0,#e8e8e8 100%);background-image:-o-linear-gradient(top,#faf9f9 0,#e8e8e8 100%);background-image:linear-gradient(top,#faf9f9 0,#e8e8e8 100%)}.RadButton_Default.RadButton.rbLinkButton{background-color:#fafafa;border:1px solid #8a8a8a;_border:1px solid #8a8a8a!important;color:#333}.RadButton_Default.rbLinkButton.rbRounded{border-color:#8a8a8a;color:#333;background-color:#e8e8e8;background-image:-webkit-linear-gradient(top,#faf9f9 0,#e8e8e8 100%);background-image:-moz-linear-gradient(top,#faf9f9 0,#e8e8e8 100%);background-image:-ms-linear-gradient(top,#faf9f9 0,#e8e8e8 100%);background-image:-o-linear-gradient(top,#faf9f9 0,#e8e8e8 100%);background-image:linear-gradient(top,#faf9f9 0,#e8e8e8 100%)}.RadButton_Default.RadButton.rbLinkButton{background-color:#fafafa;border:1px solid #8a8a8a;_border:1px solid #8a8a8a!important;color:#333}.RadButton_Default.rbLinkButton.rbRounded{border-color:#8a8a8a;color:#333;background-color:#e8e8e8;background-image:-webkit-linear-gradient(top,#faf9f9 0,#e8e8e8 100%);background-image:-moz-linear-gradient(top,#faf9f9 0,#e8e8e8 100%);background-image:-ms-linear-gradient(top,#faf9f9 0,#e8e8e8 100%);background-image:-o-linear-gradient(top,#faf9f9 0,#e8e8e8 100%);background-image:linear-gradient(top,#faf9f9 0,#e8e8e8 100%)}.RadButton_Default.RadButton.rbLinkButton{background-color:#fafafa;border:1px solid #8a8a8a;_border:1px solid #8a8a8a!important;color:#333}.RadButton_Default.rbLinkButton.rbRounded{border-color:#8a8a8a;color:#333;background-color:#e8e8e8;background-image:-webkit-linear-gradient(top,#faf9f9 0,#e8e8e8 100%);background-image:-moz-linear-gradient(top,#faf9f9 0,#e8e8e8 100%);background-image:-ms-linear-gradient(top,#faf9f9 0,#e8e8e8 100%);background-image:-o-linear-gradient(top,#faf9f9 0,#e8e8e8 100%);background-image:linear-gradient(top,#faf9f9 0,#e8e8e8 100%)}.RadButton_Default.RadButton.rbLinkButton{background-color:#fafafa;border:1px solid #8a8a8a;_border:1px solid #8a8a8a!important;color:#333;
            text-align: center;
            font-weight: 700;
        }.rbLinkButton.rbRounded{border-radius:4px}.RadButton.rbLinkButton{border:0 none;outline:0}.rbLinkButton.rbRounded{border-radius:4px}.RadButton.rbLinkButton{border:0 none;outline:0}.rbLinkButton.rbRounded{border-radius:4px}.RadButton.rbLinkButton{border:0 none;outline:0}.rbLinkButton.rbRounded{border-radius:4px}.RadButton.rbLinkButton{border:0 none;outline:0}.rbLinkButton.rbRounded{border-radius:4px}.RadButton.rbLinkButton{border:0 none;outline:0}.RadButton_Default{font-family:"Segoe UI",Arial,Helvetica,sans-serif;font-size:12px}.rbLinkButton{display:inline-block;height:20px;line-height:20px;position:relative;border:1px solid;padding:0 4px;cursor:pointer;vertical-align:bottom;text-decoration:none}.RadButton{cursor:pointer}.RadButton{font-size:12px;font-family:"Segoe UI",Arial,Helvetica,sans-serif}.RadButton_Default{font-family:"Segoe UI",Arial,Helvetica,sans-serif;font-size:12px}.rbLinkButton{display:inline-block;height:20px;line-height:20px;position:relative;border:1px solid;padding:0 4px;cursor:pointer;vertical-align:bottom;text-decoration:none}.RadButton{cursor:pointer}.RadButton{font-size:12px;font-family:"Segoe UI",Arial,Helvetica,sans-serif}.RadButton_Default{font-family:"Segoe UI",Arial,Helvetica,sans-serif;font-size:12px}.rbLinkButton{display:inline-block;height:20px;line-height:20px;position:relative;border:1px solid;padding:0 4px;cursor:pointer;vertical-align:bottom;text-decoration:none}.RadButton{cursor:pointer}.RadButton{font-size:12px;font-family:"Segoe UI",Arial,Helvetica,sans-serif}.RadButton_Default{font-family:"Segoe UI",Arial,Helvetica,sans-serif;font-size:12px}.rbLinkButton{display:inline-block;height:20px;line-height:20px;position:relative;border:1px solid;padding:0 4px;cursor:pointer;vertical-align:bottom;text-decoration:none}.RadButton{cursor:pointer}.RadButton{font-size:12px;font-family:"Segoe UI",Arial,Helvetica,sans-serif}.RadButton_Default{font-family:"Segoe UI",Arial,Helvetica,sans-serif;font-size:12px}.rbLinkButton{display:inline-block;height:20px;line-height:20px;position:relative;border:1px solid;padding:0 4px;cursor:pointer;vertical-align:bottom;text-decoration:none}.RadButton{cursor:pointer}.RadButton{font-size:12px;font-family:"Segoe UI",Arial,Helvetica,sans-serif}.rbText{display:inline-block}.rbText{display:inline-block}.rbText{display:inline-block}.rbText{display:inline-block}.rbText{display:inline-block}
        .auto-style9 {
            color: #000000;
        }
        .auto-style10 {
            color: #000000;
            font-size: x-small;
        }
        </style>
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">
 
    <script type="text/javascript">  

        //function Confirm() {
        //    var r = jConfirm("Your Shift End ! Do you still want to Continue ? ")
        //    if (r == true) {
        //        jAlert("You pressed OK!")
        //    }
        //    else {
        //        jAlert("You pressed Cancel!")
        //    }
 

        // Force the viewer to always use the PDF plug-in for printing in Chrome browser.
        // In the other browsers the report document will be downloaded as a PDF file:
            var printMode = /(chrome)/.test(navigator.userAgent.toLowerCase())
           ? telerikReportViewer.PrintModes.FORCE_PDF_PLUGIN
           : telerikReportViewer.PrintModes.FORCE_PDF_FILE;

        $("#reportViewer1")
            .telerik_ReportViewer({
                serviceUrl: "../api/reports/",
                templateUrl: 'src/templates/telerikReportViewerTemplate-9.0.15.225.htmll',
                reportSource: { report: "product catalog.trdx" },
                printMode: printMode
            });

        </script> 

  <div id="reportViewer1">  

        <script type="text/javascript">
            FireFoxHelper.prototype.PDFPluginPrintEnabled = function () {
                alert("Firefox");
                var pdfPlugins = navigator.mimeTypes["application/pdf"];
                var pdfPlugin = pdfPlugins != null ? pdfPlugins.enabledPlugin : null;
                var isEnabled = false;
                if (pdfPlugin) {
                    var description = pdfPlugin.description;

                    isEnabled = (description.indexOf("Adobe") != -1 &&
                                (description.indexOf("Version") == -1 || parseFloat(description.split("Version")[1]) >= 6));
                }

                return isEnabled;
            }

            GetBrowserHelper = function () {
                if (window.navigator) {
                    var userAgent = window.navigator.userAgent.toLowerCase();
                    if (userAgent.indexOf("msie") > -1
                        || (userAgent.indexOf("mozilla") > -1 && userAgent.indexOf("trident") > -1))
                        return new IEBrowserHelper();
                    else if (userAgent.indexOf("firefox") > -1)
                        return new FireFoxHelper();
                    else if (userAgent.indexOf("chrome") > -1)
                        return new ChromeHelper();
                    else
                        return new OtherBrowsersHelper();
                }
                return null;
            }




             </script>
       


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
                    <td class="auto-style61" style="background-color: #F7F7F7; "></td>
                    <td class="auto-style31" style="background-color: #F7F7F7; height: 10px;"></td>
                    <td class="auto-style27" style="background-color: #F7F7F7; height: 10px;"></td>
                    <td style="background-color: #F7F7F7; height: 10px;"></td>
                </tr>
                <tr>
                    <td class="auto-style56" style="background-color: #F7F7F7; text-align: center;font-size: large; font-weight: 700;">
                        <img alt="" class="auto-style64" src="images/Report2.png" />  IMS REPORTING PANEL</td>
                    <td class="auto-style55" style="background-color: #F7F7F7; text-align: center;">

                        <asp:CheckBox ID="chkTempIssue" runat="server" Font-Size="X-Small" ForeColor="Black" OnCheckedChanged="chkTempIssue_CheckedChanged" Text="Temporary Issued" />
                    </td>
                    <td class="auto-style57" style="background-color: #F7F7F7; text-align: center;">
                        <telerik:RadButton ID="btnClose" runat="server" Text="Close" Font-Size="10pt" Height="30px" ButtonType="SkinnedButton" OnClick="btnClose_Click" Width="72px">
                        </telerik:RadButton>
                    </td>
                    <td class="auto-style58" style="background-color: #F7F7F7"></td>
                    <td class="auto-style59" style="background-color: #F7F7F7"></td>
                </tr>
                <tr>
                    <td class="auto-style10" style="background-color: #F7F7F7; text-align: center;font-weight: 700;">
                        <asp:CheckBox ID="chkShowCancel" runat="server" Font-Size="X-Small" ForeColor="Black" OnCheckedChanged="chkShowCancel_CheckedChanged" Text="Show Cancelled" />
                    </td>
                    <td class="auto-style55" style="background-color: #F7F7F7; text-align: center;">
                        &nbsp;</td>
                    <td class="auto-style57" style="background-color: #F7F7F7; text-align: center;">
                        &nbsp;</td>
                    <td class="auto-style58" style="background-color: #F7F7F7">&nbsp;</td>
                    <td class="auto-style59" style="background-color: #F7F7F7">&nbsp;</td>
                </tr>
                <tr>
                    <td class="auto-style10" style="background-color: #F7F7F7; text-align: center;font-weight: 700;">
                        Document Number:<asp:TextBox ID="txtDocID" runat="server"></asp:TextBox>
                               &nbsp;<asp:Button ID="btnRptShow" runat="server" OnClick="btnRptShow_Click" Text="Show Report" Width="92px" />
                    </td>
                    <td class="auto-style55" style="background-color: #F7F7F7; text-align: center;">
                        <asp:Button ID="btnAssets" runat="server" OnClick="btnAssets_Click" Text="Assets Report" Width="119px" />
                    </td>
                    <td class="auto-style57" style="background-color: #F7F7F7; text-align: center;">
                        <asp:Button ID="btnRPWidth" runat="server" OnClick="btnRPWidth_Click" Text="Set Report Panel Width" Width="195px" />
                    </td>
                    <td class="auto-style58" style="background-color: #F7F7F7">&nbsp;
                        <asp:Button ID="btnOpenRDLC" runat="server" Text="Open RDLC" OnClick="btnOpenRDLC_Click" Visible="False" />
                        
                    </td>
                    <td class="auto-style59" style="background-color: #F7F7F7">&nbsp;</td>
                </tr>
                <tr>
                    <td class="auto-style62" colspan="5"> 
                        <telerik:RadAjaxPanel ID="RadAjaxPanel2" runat="server" Width="550px" HorizontalAlign="NotSet" LoadingPanelID="RadAjaxLoadingPanel2" RenderMode="Inline">
                           <table class="auto-style66">
                            <tr>
                                <td colspan="4">
                                    <asp:Panel ID="Panel1" runat="server">
                                        <table class="auto-style66">
                                            <tr>
                                               
                                                <td>
                                                        <telerik:ReportViewer ID="ReportViewer1" showDocumentMap="true" runat="server" Height="1300px" Width="918px" ShowDocumentMapButton="True" DocumentMapVisible="True" ShowPrintPreviewButton="true" ViewMode="PrintPreview" ShowZoomSelect="True" ZoomMode="PageWidth" Skin="WebBlue"></telerik:ReportViewer>  
                                                
                                                </td>
                                            </tr>

                                        </table>
                                    </asp:Panel>
                                </td>
                            </tr>
                            <tr>
                                <td class="auto-style75">&nbsp;</td>
                                <td class="auto-style68">&nbsp;</td>
                                <td class="auto-style67">&nbsp;</td>
                                <td>&nbsp;</td>
                            </tr>
                          </table>

                        </telerik:RadAjaxPanel>
                    </td>
                </tr>
                <tr>
                    <td class="auto-style62" colspan="5">
                        &nbsp;</td>
                </tr>
                <tr>
                    <td class="auto-style10">&nbsp;</td>
                    <td class="auto-style15">
                        &nbsp;</td>
                    <td class="auto-style20">
                        </td>
                </tr>
                <tr>
                    <td class="auto-style62">&nbsp;</td>
                    <td class="auto-style26">
                        &nbsp;</td>
                    <td class="auto-style18">
                        &nbsp;</td>
                    <td class="auto-style29">
                        &nbsp;</td>
                    <td style="height: 30px; text-align: right;">
                        &nbsp;</td>
                </tr>
                <tr>
                    <td class="auto-style22">&nbsp;</td>
                    <td class="auto-style26">
                        <telerik:RadAjaxLoadingPanel ID="RadAjaxLoadingPanel2" runat="server" Skin="Default">
                        </telerik:RadAjaxLoadingPanel>
                    </td>
                    <td class="auto-style18">
                        &nbsp;</td>
                    <td class="auto-style29">
                        &nbsp;</td>
                    <td style="height: 30px; text-align: right;">
                        &nbsp;</td>
                </tr>
                <tr>
                    <td class="auto-style8">&nbsp;</td>
                    <td class="auto-style26">
                        &nbsp;</td>
                    <td class="auto-style18">
                        &nbsp;</td>
                    <td class="auto-style29">
                        &nbsp;</td>
                    <td class="auto-style9" style="height: 30px">
                        &nbsp;</td>
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
           
 

   </div>
 
 
</asp:Content>







