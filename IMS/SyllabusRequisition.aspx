<%@ Page Title="" Language="C#" MasterPageFile="~/Site1.Master" AutoEventWireup="true" CodeBehind="SyllabusRequisition.aspx.cs" Inherits="IMS.SyllabusRequisition" %>


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

        .auto-style12 {
            width: 1166px;
        }

        .auto-style14 {
            width: 166px;
        }

        .auto-style15 {
            height: 22px;
            width: 166px;
        }

        .auto-style19 {
            width: 434px;
            font-family: Arial, Helvetica, sans-serif;
            font-size: medium;
            height: 33px;
            color: #C0C0C0;
        }

        .auto-style20 {
            height: 33px;
            width: 434px;
        }

        .newStyle1 {
            font-family: Calibri;
            font-size: large;
            text-align: center;
        }

        .auto-style21 {
            height: 19px;
            font-size: large;
        }

        .auto-style25 {
            text-align: left;
        }

        .auto-style26 {
            height: 33px;
        }

        .auto-style27 {
            height: 22px;
            width: 166px;
            background-color: #0066FF;
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


         function GridRowNo(r, obj) {
             TotalAmount(r, obj);
             cell = document.getElementById('<%=grdItems.ClientID %>').rows[parseInt(r) + 1].cells[1];
            setFocusToTextBox(obj);

            return r;
            // Function returns the product of a and b
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



     <div class="CSSTableGenerator">


        <table class="auto-style12">

            <tr>
                <td class="auto-style8"></td>
                <td colspan="2" style="valign="middle" align="center">
                    <h1 style="font-weight: bold; font-size: medium; color: #000000;">
                        <span style="text-align: center">A N N U A L&nbsp;&nbsp;&nbsp;&nbsp; S Y L L A B U S&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;     R E Q U I S I T I O N</span>
                    </h1>
                </td>
               
                <td class="auto-style4"></td>
                <td class="auto-style14"></td>
            </tr>
            <tr>
                <td class="auto-style21">&nbsp;</td>
                <td class="auto-style20">
            <%--    Upload and Save Image Into the Database    
                    <asp:TextBox runat="server" ID="txt_Image_Name"></asp:TextBox><br />
                    <asp:FileUpload runat="server" ID="FileUpload1" /><br />
                    <asp:Button runat="server" ID="cmd_Upload" Text="Upload Image" OnClick="cmd_Upload_Click" />--%>

                </td>                
                <td class="auto-style19">&nbsp;</td>
                <td class="auto-style27" valign="middle">&nbsp;
                    <telerik:RadButton ID="btnClose" runat="server" Text="Close" Font-Size="10pt" Height="30px" ButtonType="SkinnedButton" OnClick="btnClose_Click" Width="72px">
                        </telerik:RadButton>
                </td>
                 <td class="auto-style14"></td>
            </tr>
            <tr>
                <td class="auto-style21">&nbsp;</td>
                <td align="left" class="auto-style25" style="text-align: left"><span style="font-size: small">Requisition Type:&nbsp;&nbsp;</span>&nbsp;&nbsp;&nbsp;&nbsp; &nbsp;
                    <asp:DropDownList ID="ddlReqType" AutoPostBack="true"
                        AppendDataBoundItems="true" runat="server" Height="25px" Width="278px"
                        OnSelectedIndexChanged="ddlReqType_SelectedIndexChanged" Font-Bold="True"
                        ForeColor="#000000">
                    </asp:DropDownList>
                </td>
                <td class="auto-style19">&nbsp;</td>
                <td class="auto-style15">
                    <asp:Label ID="lblSybReqExist" runat="server" Text="lblCheckBudgState" Visible="False"></asp:Label>
                </td>
                 <td class="auto-style14"></td>
            </tr>
            <tr>
                <td class="auto-style7">&nbsp;</td>
                <td style="text-align: left"><span style="font-size: small">Requisition Sub Type:
                </span>
                    <asp:DropDownList ID="ddlReqSubType" AutoPostBack="true"
                        AppendDataBoundItems="true" runat="server" Height="25px"
                        Width="276px" OnSelectedIndexChanged="ddlReqSubType_SelectedIndexChanged" Font-Bold="True"
                        ForeColor="#000000">
                    </asp:DropDownList>
                </td>
                <td class="auto-style19">&nbsp;</td>
                <td class="auto-style15">
                    <asp:Button ID="btnGenerateSybReq" runat="server" OnClick="btnGenerateSybReq_Click" Text="Generate Syllabus Distribution" Width="176px" />

                </td>
                 <td class="auto-style14"></td>
            </tr>

            <tr>
                <td class="auto-style7">&nbsp;</td>
                <td style="text-align: left"><span style="font-size: small">Academic Year:&nbsp;&nbsp;&nbsp;&nbsp;&nbsp; </span>&nbsp;&nbsp;&nbsp;
                    <asp:DropDownList ID="ddlAcdYear" AutoPostBack="true" AppendDataBoundItems="true"
                        runat="server" Height="25px" Width="274px" Font-Bold="True" ForeColor="#000000">
                    </asp:DropDownList>
                </td>
                <td class="auto-style19">&nbsp;</td>
                <td class="auto-style15">
                    <asp:Button ID="btnProcessReq" runat="server" OnClick="btnProcessReq_Click" Text="Process Requisition/MIR" Width="176px" />

                </td>
                 <td class="auto-style14"></td>
            </tr>
            <tr>
                <td class="auto-style7">&nbsp;</td>
                <td class="auto-style26" colspan="2">
                    <asp:RadioButtonList ID="rdoSysChoice" runat="server" AutoPostBack="True" OnSelectedIndexChanged="rdoSysChoice_SelectedIndexChanged" RepeatDirection="Horizontal" Style="font-size: small" Width="784px" Font-Bold="True" ForeColor="Black">
                        <asp:ListItem Value="1">FPS Karachi</asp:ListItem>
                        <asp:ListItem Value="2">FPS Hyderabad</asp:ListItem>
                        <asp:ListItem Value="3">HSS Karachi</asp:ListItem>
                    </asp:RadioButtonList>
                </td>
                <td class="auto-style19">
                <strong><a href="ReportsMain.aspx?rptname=SYB_ReqType_PCRatio" target="_blank" style="text-align: left"><span style="font-size: medium">View/Print PC Ratio List</span></a></strong>

                </td>
                <td class="auto-style15">&nbsp;</td>
            </tr>
            <tr>
               
               <asp:UpdatePanel ID="UpdatePanel1" UpdateMode="Always" runat="server">
                 <ContentTemplate>
                
                 <td>&nbsp;</td>
                 <td align="left" colspan="5" style="font-family: Calibri;  font-weight: normal; font-size: 14px;" valign="top">

                    <div id="mirdiv" style="display: none" runat="server">

                        <table  id="chkGrid" cellspacing="1" style="width: 100%" align="center">
                        
                            <tr>
                                <td>&nbsp;</td>
                                <td>&nbsp;</td>
                                <td>&nbsp;</td>
                                <td>&nbsp;</td>
                                <td>&nbsp;</td>
                            </tr>

                            <tr>

                                <td colspan="1" style="width: 350px; text-align: left;" align="center">
                                    <asp:GridView ID="grdGrade" runat="server" AlternatingRowStyle-CssClass="alt" AutoGenerateColumns="False" CssClass="mGrid" 
                                        OnRowCommand="grdGrade_RowCommand" OnRowEditing="grdGrade_RowEditing" 
                                        OnRowUpdating="grdGrade_RowUpdating" PagerStyle-CssClass="pgr" Style="font-size: x-small; text-align: left;" Width="350px" 
                                        OnRowDataBound="grdGrade_RowDataBound" HorizontalAlign="Center">
                                        <AlternatingRowStyle CssClass="alt" />
                                        <Columns>

                                            <asp:TemplateField HeaderText="Select Choice">
                                                <ItemTemplate>
                                                    <asp:CheckBox ID="ChoiceGrade" runat="server" onclick="CheckGrid(this);" OnCheckedChanged="ChoiceGrade_OnCheckedChanged" Width="20px" AutoPostBack="true"/>
                                                </ItemTemplate>
                                                <ControlStyle Width="20px" />
                                                <HeaderStyle Font-Size="12pt" HorizontalAlign="Center" VerticalAlign="Middle" />
                                                <ItemStyle HorizontalAlign="Center" VerticalAlign="Middle" Width="20px" Font-Size="Medium"/>
                                             </asp:TemplateField>  

                                              <asp:BoundField DataField="SysID"  Visible="false"></asp:BoundField>
                                              <asp:BoundField DataField="ComID" Visible="false"></asp:BoundField>
                                              <asp:BoundField DataField="CityID"  Visible="false"></asp:BoundField>
                                              
                                            

                                            <asp:BoundField DataField="Grade" HeaderText="Grade Title">
                                                <ControlStyle Width="50px"/>
                                                <HeaderStyle Font-Size="12pt" HorizontalAlign="Center" VerticalAlign="Middle" />
                                                <ItemStyle HorizontalAlign="Left" VerticalAlign="Middle" Width="50px"  Font-Size="Medium"/>
                                            </asp:BoundField>

                                            <asp:TemplateField HeaderText="Strength">
                                                <ItemTemplate>
                                                    <asp:TextBox ID="txtstrength" runat="server" AutoPostBack="True"  Text='<%#Eval("Total") %>' Width="50px" TextMode="Number"></asp:TextBox>
                                                </ItemTemplate>
                                                <ControlStyle Width="80px" />
                                                <HeaderStyle Font-Size="12pt" HorizontalAlign="Center" VerticalAlign="Middle" />
                                                <ItemStyle HorizontalAlign="Center" VerticalAlign="Middle" Width="30px" Font-Size="Medium"/>
                                            </asp:TemplateField>
                                            <asp:BoundField DataField="IsPosted" Visible="false"></asp:BoundField>
                                        </Columns>
                                        <PagerStyle CssClass="pgr" />
                                    </asp:GridView>
                                </td>
                                
                                <td style="text-align: left" valign="top">
                                    <span style="font-size: small">Requisition Type  :</span>&nbsp;
                                    <asp:TextBox ID="txtReqType" runat="server" Width="200px" ForeColor="Black" Visible="True" Enabled="false"></asp:TextBox>
                                    <br><br><span style="font-size: small">Company/System:</span>
                                    <asp:TextBox ID="txtSysName" runat="server" Width="200px" ForeColor="Black" Visible="True" Enabled="false"></asp:TextBox>
                                    <br><br><span style="font-size: small">Selected Grade:</span>&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;
                                    <asp:TextBox ID="txtGrade" runat="server" Width="200px" ForeColor="Black" Visible="True" Enabled="false"></asp:TextBox>
                                    <br><br><span style="font-size: small">Grade Strength:</span>&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;
                                    <asp:TextBox ID="txtGrdStrength" runat="server" Width="200px" ForeColor="Black" Visible="True" Enabled="false"></asp:TextBox>
                                </td>
                               <td>&nbsp;</td> 
                                <td>&nbsp;</td>
                            </tr>
                            <tr>
                                <td>&nbsp;</td>
                                <td>&nbsp;</td>
                                <td>&nbsp;</td>
                                <td>&nbsp;</td>
                                <td>&nbsp;</td>
                            </tr>

                            <tr>
                                <td colspan="3" style="width: 800px; text-align: left;" align="center">                                    
                                     <div id="ReqDiv" style="display: none" runat="server">

                                          <asp:GridView ID="grdItems" runat="server" GridLines="Both"
                                            AutoGenerateColumns="False"
                                            cellclassname="column"
                                            CssClass="mGrid" OnRowCommand="grdItems_RowCommand" OnRowDeleting="grdItems_RowDeleting"
                                            OnRowEditing="grdItems_RowEditing" OnRowUpdating="grdItems_RowUpdating"
                                            PagerStyle-CssClass="pgr" Style="font-size: x-small; text-align: center;" Width="800px"
                                            AllowSorting="True" OnRowUpdated="grdItems_RowUpdated" OnSorting="grdItems_Sorting"
                                            OnDataBound="grdItems_DataBound" OnRowDataBound="grdItems_RowDataBound">

                                            <PagerStyle CssClass="pgr"></PagerStyle>
                                            <RowStyle CssClass="gridrow" />
                                            <RowStyle ForeColor="Black" />
                                            <SelectedRowStyle BackColor="YellowGreen" ForeColor="Blue" Font-Bold="True" />
                                            <Columns>
                                                <asp:CommandField ShowDeleteButton="false" Visible="false" />

                                                <asp:TemplateField HeaderText="S.No">
                                                    <ItemTemplate>
                                                        <%# Container.DataItemIndex + 1 %>
                                                    </ItemTemplate>                                                    
                                                    <HeaderStyle Font-Size="10pt" HorizontalAlign="Center" VerticalAlign="Middle" />
                                                    <ItemStyle HorizontalAlign="Center" VerticalAlign="Middle" Width="2%" Font-Size="Small"/>
                                                </asp:TemplateField>

                                                <asp:TemplateField HeaderText="Item Category">
                                                    <ItemTemplate>
                                                        <asp:Label ID="lblCategory" runat="server" Text='<%#CheckIfTitleExists(Eval("ItemHeadTitle").ToString())%>'></asp:Label>
                                                    </ItemTemplate>
                                                    <HeaderStyle Font-Size="10pt" HorizontalAlign="Center" VerticalAlign="Middle" />
                                                    <ItemStyle HorizontalAlign="Left" VerticalAlign="Middle" Width="20%" Font-Size="Small"/>
                                                </asp:TemplateField>

                                                <asp:BoundField DataField="ItemHeadTitle" HeaderText="Item Head">
                                                        <HeaderStyle Font-Size="10pt" HorizontalAlign="Center" VerticalAlign="Middle" />
                                                        <ItemStyle HorizontalAlign="Left" VerticalAlign="Middle" Width="20%" Font-Size="Small"/>
                                                </asp:BoundField>

                                                <asp:TemplateField HeaderText="ItemID" Visible="false">
                                                    <ItemTemplate>
                                                        <asp:Label ID="lblItemID" runat="server" Text='<%#Eval("fkItemID") %>' Width="50px" />
                                                    </ItemTemplate>    
                                                </asp:TemplateField>

                                                <asp:BoundField DataField="InvCode" HeaderText="Item Code" Visible="false" />
                                                <asp:BoundField DataField="ItemTitle" HeaderText="Item Name">                                                    
                                                      <HeaderStyle Font-Size="10pt" HorizontalAlign="Center" VerticalAlign="Middle" />
                                                      <ItemStyle HorizontalAlign="Left" VerticalAlign="Middle" Width="40%" Font-Size="Small"/>
                                                </asp:BoundField>
                                                <asp:BoundField DataField="Unit" HeaderText="Unit">
                                                      <HeaderStyle Font-Size="10pt" HorizontalAlign="Center" VerticalAlign="Middle" />
                                                      <ItemStyle HorizontalAlign="Left" VerticalAlign="Middle" Width="5%" Font-Size="Small"/>
                                                </asp:BoundField>
                                                

                                                <asp:TemplateField HeaderText="PerChild Ratio">
                                                    <ItemTemplate>
                                                        <asp:TextBox ID="txtqty" runat="server" AutoPostBack="false" autocomplete="off" OnTextChanged="txtqty_TextChanged" Text='<%#Eval("QtyRequired") %>' onclick="GridRowNo(<%# Container.DataItemIndex %>,this);" Width="50px"></asp:TextBox>
                                                    </ItemTemplate>
 
                                                    <HeaderStyle Font-Size="10pt" HorizontalAlign="Center" VerticalAlign="Middle" />
                                                    <ItemStyle HorizontalAlign="Right" VerticalAlign="Middle" Width="10%" Font-Size="Small"/>

                                                </asp:TemplateField>


                                                
                                            </Columns>

                                            <FooterStyle BackColor="#507CD1" Font-Bold="True" ForeColor="White" />
                                            <PagerStyle BackColor="#2461BF" ForeColor="White" HorizontalAlign="Center" />
                                            <SelectedRowStyle BackColor="#D1DDF1" ForeColor="#333333" Font-Bold="True" />
                                            <HeaderStyle BackColor="#507CD1" Font-Bold="True" ForeColor="White" />
                                            <EditRowStyle BackColor="#2461BF" />
                                            <AlternatingRowStyle BackColor="White" />
                                        </asp:GridView>
                                     </div>
                                </td>
                            </tr>

                        </table>
                    </div>

                </td>
               
                


                </ContentTemplate>
              </asp:UpdatePanel>

            </tr>
            <tr>
                <td class="auto-style7">&nbsp;</td>
                <td class="auto-style20">
                    <asp:CheckBox ID="chkPosted" runat="server" OnCheckedChanged="chkPosted_CheckedChanged" style="font-size: small" Text="Post This Grade?" />
                </td>
                <td style="text-align: right">
                    <asp:Button ID="btnSaveBudget" runat="server" OnClick="btnSaveBudget_Click" Text="Save Ratio" Width="176px" />
                </td>
                <td class="auto-style15">&nbsp;</td>
                <td class="auto-style14"></td>
            </tr>
           


        </table>

    </div>

</asp:Content>

<asp:Content ID="Content3" ContentPlaceHolderID="MainContent" runat="server">

   


</asp:Content>
