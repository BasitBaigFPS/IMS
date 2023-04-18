<%@ Page Title="" Language="C#" MasterPageFile="~/Site1.Master" AutoEventWireup="true" CodeBehind="SyllabusRequisitionBranch.aspx.cs" Inherits="IMS.SyllabusRequisitionBranch" %>


<asp:Content ID="Content1" ContentPlaceHolderID="HeadContent" runat="server">
    <style type="text/css">
        .auto-style4 {
            border-collapse: collapse;
        }

        .auto-style7 {
            height: 19px;
        }

        .auto-style8 {
            width: 104px;
            font-family: Arial, Helvetica, sans-serif;
            font-size: medium;
            height: 22px;
        }

        .newStyle1 {
            font-family: Calibri;
            font-size: large;
            text-align: center;
        }

        .auto-style20 {
            font-size: medium;
        }
        .abc {
      margin-left: 25% !important;
        
        }
    </style>
    <link href="CSS/GridViewStyle1.css" rel="stylesheet" type="text/css" />
</asp:Content>




<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">

    <script type="text/javascript">

        function IsNumeric(e, rowindex) {


            var i = parseInt(rowindex);

            var str = "MainContent_grdItems_txtqty_" + i;
            //cellval = parseFloat(document.getElementById(str).innerHTML != "NaN" ? document.getElementById(str).innerHTML : "0");
            var CellValue = document.getElementById(str);

            e = (e) ? e : window.event;
            var charCode = (e.which) ? e.which : e.keyCode;

            if (e.keyCode > 47 && e.keyCode < 58 || charCode >= 96 && charCode <= 105 || $.inArray(e.keyCode, [46, 8, 9, 27, 13, 110, 190]) !== -1) {
                return;
            }
            else {
                //CellValue.innerHTML = parseFloat("0");
                alert("Please Enter Only Numeric Value...");
                document.getElementById(str).value = parseFloat("0");
                e.preventDefault();

                return false;
            }

        }


        function clickEnter(obj, event) {
            var keyCode;
            if (event.keyCode > 0) {
                keyCode = event.keyCode;
            }
            else if (event.which > 0) {
                keyCode = event.which;
            }
            else {
                keycode = event.charCode;
            }
            if (keyCode == 13) {
                //  obj.select();
                document.getElementById(obj).focus();

                return false;
            }
            else {
                return true;
            }
        }




        function setFocusToTextBox(obj) {
            document.getElementById(obj).focus();
        }

        $(document).ready(function () {

            var x = GridRowNo(r);

            var divLoc = $('#idVal').offset();
            //$('html, body').animate({ scrollTop: divLoc.left }, "fast");

            $('html, body').animate({
                scrollTop: 2000,
                scrollLeft: 300
            }, 1000);

        });

        function CheckGrid(source) {
            var isChecked = source.checked;
            $("#chkGrid input[id*='ChoiceGrade']").each(function (index) {
                $(this).attr('checked', false);
            });
            source.checked = isChecked;

        }

        function Confirm() {
            var confirm_value = document.createElement("INPUT");
            confirm_value.type = "hidden";
            confirm_value.name = "confirm_value";
            if (confirm("Do you want to Reprocess New Year Strength?")) {
                confirm_value.value = "Yes";
            } else {
                confirm_value.value = "No";
            }
            document.forms[0].appendChild(confirm_value);
        }


        function Confirm(system) {
            //This Function Work with ASP Button Not with RadControlButton.
            var choice = confirm("Are You Sure?, You Want to Finalize '" + system + "' Annual Syllabus Requisition & MIR?", "Yes", "No");
            if (choice == false) {
                return false;
            }
        }

    </script>



    <div class="CSSTableGenerator" style="position: fixed; width: 40%; margin-left: 15%; margin-top: 5%;">
        <table width="100px">
            <tr>
                <td colspan="5" align="center">
                    <h1 style="font-weight: bold; font-size: medium; color: #000000;">
                        <span style="text-align: center">S Y L L A B U S&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;R E Q U I S I T I O N</span>
                    </h1>
                </td>
            </tr>
            <tr>
                <td><span class="auto-style20">M.I.R No:</span>
                    <asp:TextBox ID="txtmirno" runat="server" BorderColor="#000066" BorderWidth="1px" Enabled="False" Height="20px" onkeydown="addItem(event);" Style="font-size: small; font-weight: 700;" TabIndex="5" Width="75px"></asp:TextBox>
                    &nbsp;<a href="ReportsMain.aspx?rptname=MaterialIssueRequest&amp;mirno=<%= txtmirno.Text %>" target="_blank" style="font-size:14px">Print</a><br />

                </td>
            </tr>

            <tr>
                <td align="left" style="font-family: Calibri; font-weight: normal; font-size: 14px;" valign="top">

                    <asp:UpdatePanel ID="UpdatePanel1" UpdateMode="Always" runat="server">
                        <ContentTemplate>

                            <div id="mirdiv" style="display: block" runat="server">

                                <table id="chkGrid" cellspacing="1" style="width: 100%">

                                    <tr>
                                        <td>Additional New Students Syllabus Request</td>
                                    </tr>

                                    <tr>

                                        <td style="width: 50%; margin-left: 20%; text-align:center;">
                                            <asp:GridView ID="grdGrade" runat="server" AlternatingRowStyle-CssClass="alt" AutoGenerateColumns="False"
                                                OnRowCommand="grdGrade_RowCommand" OnRowEditing="grdGrade_RowEditing"
                                                OnRowUpdating="grdGrade_RowUpdating" PagerStyle-CssClass="pgr" Style="font-size: x-small;" Width="50%"
                                                OnRowDataBound="grdGrade_RowDataBound" HorizontalAlign="Center" BackColor="White" BorderColor="#3366CC" BorderStyle="None" BorderWidth="1px"  CssClass="abc">
                                                <AlternatingRowStyle CssClass="alt" />
                                                <Columns>
                                               
                                                    <asp:BoundField DataField="fkacdid" Visible="false"></asp:BoundField>
                                                    <asp:BoundField DataField="fkbrhid" Visible="false"></asp:BoundField>

                                                    <asp:TemplateField HeaderText="Grade">
                                                        <ItemTemplate>
                                                            <asp:TextBox ID="Grade" runat="server" Text='<%#Eval("Grade") %>' Enabled="false"></asp:TextBox>
                                                        </ItemTemplate>
                                                        <ControlStyle Width="50px" />
                                                        <HeaderStyle Font-Size="12pt" HorizontalAlign="Center" VerticalAlign="Middle" />
                                                        <ItemStyle HorizontalAlign="Center" VerticalAlign="Middle" Width="50px" Font-Size="Medium" />
                                                    </asp:TemplateField>

                                                    <asp:TemplateField HeaderText="Total">
                                                        <ItemTemplate>
                                                            <asp:TextBox ID="txtstrength" runat="server" Text='<%#Eval("ReqTotal") %>' Width="50px" TextMode="Number"></asp:TextBox>
                                                        </ItemTemplate>
                                                        <ControlStyle Width="80px" />
                                                        <HeaderStyle Font-Size="12pt" HorizontalAlign="Center" VerticalAlign="Middle" />
                                                        <ItemStyle HorizontalAlign="Center" VerticalAlign="Middle" Width="30px" Font-Size="Medium" />
                                                    </asp:TemplateField>
                                                </Columns>
                                                <FooterStyle BackColor="#99CCCC" ForeColor="#003399" />
                                                <HeaderStyle BackColor="#003399" Font-Bold="True" ForeColor="#CCCCFF" />
                                                <PagerStyle CssClass="pgr" BackColor="#99CCCC" ForeColor="#003399" HorizontalAlign="Left" />
                                                <RowStyle BackColor="White" ForeColor="#003399" />
                                                <SelectedRowStyle BackColor="#009999" Font-Bold="True" ForeColor="#CCFF99" />
                                                <SortedAscendingCellStyle BackColor="#EDF6F6" />
                                                <SortedAscendingHeaderStyle BackColor="#0D4AC4" />
                                                <SortedDescendingCellStyle BackColor="#D6DFDF" />
                                                <SortedDescendingHeaderStyle BackColor="#002876" />
                                            </asp:GridView>
                                        </td>

                                    </tr>

                                    <tr>
                                        <td>&nbsp;</td>
                                    </tr>

                                </table>
                            </div>

                        </ContentTemplate>
                    </asp:UpdatePanel>

                </td>
            </tr>

            <tr>
                <td  style="text-align: center;">
                    <asp:Button ID="btnProcessReq" runat="server" OnClick="btnProcessReq_Click" Text="Process Requisition/MIR" Width="223px" Height="34px" />

                    <asp:Button ID="btnClose" runat="server" OnClick="btnClose_Click" Text="< Back" Height="34px" />
                    <%--    <telerik:RadButton ID="btnClose0" runat="server" Text="Close" Font-Size="10pt" Height="30px" ButtonType="SkinnedButton" OnClick="btnClose_Click" Width="72px" Style="line-height: 30px; height: 30px; position: relative;">
                        </telerik:RadButton>--%>
                </td>

            </tr>



        </table>

    </div>
    <br />
    <br />
</asp:Content>
