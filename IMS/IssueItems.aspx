<%@ Page Title="" Language="C#" MasterPageFile="~/Site1.Master" AutoEventWireup="true" CodeBehind="IssueItem.aspx.cs" Inherits="IMS.IssueItem" %>
<%@ Register assembly="AjaxControlToolkit" namespace="AjaxControlToolkit" tagprefix="asp" %>
<asp:Content ID="Content1" ContentPlaceHolderID="HeadContent" runat="server">
    <style type="text/css">
    .auto-style4 {
        border-collapse: collapse;
    }
    .auto-style6 {
        width: 104px;
        height: 19px;
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
    .auto-style9 {
        height: 22px;
    }
    .auto-style10 {
        width: 104px;
        font-family: Arial, Helvetica, sans-serif;
        font-size: medium;
        height: 33px;
        color: #C0C0C0;
    }
        .auto-style13 {
            height: 19px;
            width: 300px;
        }
        .auto-style15 {
            height: 33px;
            width: 300px;
        }
        .auto-style18 {
            font-family: Arial, Helvetica, sans-serif;
            height: 30px;
            width: 34px;
        }
        .auto-style20 {
            height: 33px;
            font-family: Arial, Helvetica, sans-serif;
            width: 34px;
        }
        .auto-style21 {
            height: 19px;
            font-family: Arial, Helvetica, sans-serif;
            width: 34px;
        }
        .auto-style22 {
        width: 104px;
        font-family: Arial, Helvetica, sans-serif;
        font-size: medium;
    }
        .auto-style25 {
            width: 300px;
        }
        .auto-style26 {
            height: 30px;
            width: 300px;
        }
        .auto-style27 {
            font-family: Arial, Helvetica, sans-serif;
            width: 97px;
        }
        .auto-style28 {
            height: 19px;
            font-family: Arial, Helvetica, sans-serif;
            width: 97px;
        }
        .auto-style29 {
            font-family: Arial, Helvetica, sans-serif;
            height: 30px;
            width: 97px;
        }
        .auto-style31 {
            font-family: Arial, Helvetica, sans-serif;
            width: 34px;
        }
        .auto-style32 {
        width: 104px;
        font-family: Arial, Helvetica, sans-serif;
        font-size: xx-large;
    }
        .auto-style55 {
        width: 300px;
        font-family: Arial, Helvetica, sans-serif;
        font-size: xx-large;
        color: #C0C0C0;
        height: 55px;
    }
    .auto-style56 {
        width: 104px;
        font-family: Arial, Helvetica, sans-serif;
        font-size: xx-large;
        height: 55px;
    }
    .auto-style57 {
        font-family: Arial, Helvetica, sans-serif;
        width: 34px;
        height: 55px;
    }
    .auto-style59 {
        height: 55px;
    }
    .auto-style61 {
        width: 300px;
        font-family: Arial, Helvetica, sans-serif;
        font-size: xx-large;
        color: #D1D1D1;
    }
    .auto-style62 {
        font-family: Arial, Helvetica, sans-serif;
        font-size: medium;
        color: #C0C0C0;
    }
    .auto-style64 {
        width: 64px;
        height: 64px;
    }
        .auto-style66 {
            width: 100%;
        }
    .RadComboBox_Default{color:#333;font:normal 12px/16px "Segoe UI",Arial,Helvetica,sans-serif}.RadComboBox{margin:0;padding:0;*zoom:1;display:-moz-inline-stack;display:inline-block;*display:inline;text-align:left;vertical-align:middle;_vertical-align:top;white-space:nowrap}.RadComboBox_Default .rcbReadOnly .rcbInputCellLeft{background-position:0 -88px}.RadComboBox_Default .rcbInputCellLeft{background-position:0 0}.RadComboBox_Default .rcbInputCell{background-image:url('mvwres://Telerik.Web.UI, Version=2013.3.1015.45, Culture=neutral, PublicKeyToken=121fae78165ba3d4/Telerik.Web.UI.Skins.Default.Common.radFormSprite.png');_background-image:url('mvwres://Telerik.Web.UI, Version=2013.3.1015.45, Culture=neutral, PublicKeyToken=121fae78165ba3d4/Telerik.Web.UI.Skins.Default.Common.radFormSpriteIE6.png')}.RadComboBox .rcbInputCell{width:100%;height:20px;_height:22px;line-height:20px;_line-height:22px;text-align:left;vertical-align:middle}.RadComboBox .rcbInputCell{margin:0;padding:0;background-color:transparent;background-repeat:no-repeat;*zoom:1}.RadComboBox_Default .rcbReadOnly .rcbInput{color:#333}.RadComboBox .rcbReadOnly .rcbInput{cursor:default}.RadComboBox_Default .rcbInput{color:#333;font:normal 12px "Segoe UI",Arial,Helvetica,sans-serif;line-height:16px}.RadComboBox .rcbInput{margin:0;padding:0;border:0;background:0;padding:2px 0 1px;_padding:2px 0 0;width:100%;_height:18px;outline:0;vertical-align:middle;-webkit-appearance:none}.RadComboBox_Default .rcbReadOnly .rcbArrowCellRight{background-position:-162px -176px}.RadComboBox_Default .rcbArrowCellRight{background-position:-18px -176px}.RadComboBox_Default .rcbArrowCell{background-image:url('mvwres://Telerik.Web.UI, Version=2013.3.1015.45, Culture=neutral, PublicKeyToken=121fae78165ba3d4/Telerik.Web.UI.Skins.Default.Common.radFormSprite.png');_background-image:url('mvwres://Telerik.Web.UI, Version=2013.3.1015.45, Culture=neutral, PublicKeyToken=121fae78165ba3d4/Telerik.Web.UI.Skins.Default.Common.radFormSpriteIE6.png')}.RadComboBox .rcbArrowCell{width:18px}.RadComboBox .rcbArrowCell{margin:0;padding:0;background-color:transparent;background-repeat:no-repeat;*zoom:1}
        .auto-style67 {
            width: 320px;
        }
        .auto-style68 {
        }
        .auto-style75 {
            width: 130px;
        }
        .auto-style77 {
        }
        .auto-style81 {
        }
        .auto-style82 {
            width: 171px;
            height: 22px;
        }
        .auto-style85 {
            width: 160px;
        }
        .auto-style86 {
            height: 22px;
            width: 160px;
        }
        .auto-style88 {
            height: 22px;
            width: 312px;
        }
        .auto-style89 {
            width: 312px;
        }
        .auto-style90 {
            height: 43px;
        }
        .auto-style91 {
            width: 312px;
            height: 43px;
        }
        .auto-style92 {
            background-color: #FFFFFF;
        }
        .auto-style93 {
            color: blue;
        }
        .auto-style94 {
            height: 22px;
            visibility: hidden;
        }
        .auto-style95 {
            height: 22px;
            width: 312px;
            visibility: hidden;
        }
    </style>
        <link href="CSS/GridViewStyle1.css" rel="stylesheet" type="text/css" />

      <script type="text/javascript">

 
          function CheckBalance(crbal, rowindex)
          {
              var i;
              i = parseInt(rowindex);

              var str = "ContentPlaceHolder1_grdItems_txtqty_" + i;
              var CellV = document.getElementById(str);
              var CellValue = document.getElementById(str).value;
              var noval = 0;
              if (CellValue > parseFloat(crbal)) {                  
                  alert("Please Enter Quantity Less Than or Equal To Current Balance!!!");
                  //CellV.innerHTML = parseFloat("0");
                  //document.getElementById(str).value = parseFloat("0");
                  document.getElementById(str).value = parseFloat(crbal);
                  return false;
              }
              else {
                  return true;
              }
 
          }

          function fnMaxLength(field, maxChars) {

              if (field.value >= maxChars) {

                  var object = "-More than " + maxChars + " characters have been entered.";

                  //errorAlert("error", "Maximum length error", object);

                  alert(object);

                  return false;

              }

          }


         
          function IsNumeric(e, rowindex) {
              var i = parseInt(rowindex);
              var str = "ContentPlaceHolder1_grdItems_txtqty_" + i;
              //cellval = parseFloat(document.getElementById(str).innerHTML != "NaN" ? document.getElementById(str).innerHTML : "0");
              var CellValue = document.getElementById(str);

              e = (e) ? e : window.event;
              var charCode = (e.which) ? e.which : e.keyCode;

              if (charCode >= 48 && charCode <= 57 || charCode >= 96 && charCode <= 105 || (charCode == 8) || (charCode == 46) || (charCode == 13) || (charCode == 190) || (charCode == 110)) {
                  return true;
              }
              else {
                  //CellValue.innerHTML = parseFloat("0");
                  //alert("Please Enter Only Numeric Value...");
                  //e.preventDefault();

                  return false;
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


          </script>

     

    <script type="text/javascript" id="telerikClientEvents2">
//<![CDATA[

	function cmbPersonto_DropDownClosed(sender,args)
	{
	    //Add JavaScript handler code here
          <%ShowStatus();%>
	}
//]]>
</script>





</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">

     <telerik:RadCodeBlock ID="dfg" runat="server">
        
     </telerik:RadCodeBlock>

   


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
                    <td class="auto-style61" style="background-color: #F7F7F7; height: 10px;"></td>
                    <td class="auto-style31" style="background-color: #F7F7F7; height: 10px;"></td>
                    <td class="auto-style27" style="background-color: #F7F7F7; height: 10px;"></td>
                    <td style="background-color: #F7F7F7; height: 10px;"></td>
                </tr>
                <tr>
                    <td class="auto-style56" style="background-color: #F7F7F7; text-align: center;">
                        <img alt="" class="auto-style64" src="images/inv_isu.png" /></td>
                    <td class="auto-style55" style="background-color: #F7F7F7"><strong>Issue Items Internal</strong></td>
                    <td class="auto-style57" style="background-color: #F7F7F7"></td>
                    <td  style="background-color: #F7F7F7; text-align: center;">
                        <telerik:RadButton ID="btnClose" runat="server" Text="Close" Font-Size="10pt" Height="30px" ButtonType="SkinnedButton" OnClick="btnClose_Click" Width="72px" style="text-align: center">
                        </telerik:RadButton>
                    </td>
                    <td class="auto-style59" style="background-color: #F7F7F7"></td>
                </tr>
                <tr>
                    <td class="auto-style6"></td>
                    <td class="auto-style13">&nbsp;</td>
                    <td class="auto-style21">&nbsp;</td>
                    <td class="auto-style28">&nbsp;</td>
                    <td class="auto-style7">&nbsp;</td>
                </tr>
                <tr>
                  
                    <asp:UpdatePanel ID="UpdatePanel1" runat="server" UpdateMode="Conditional" ChildrenAsTriggers="false">
                    <ContentTemplate> 
                    
                      <td class="auto-style62" colspan="5"> 
                         
                           <telerik:RadAjaxPanel ID="RadAjaxPanel2" runat="server" Width="950px" HorizontalAlign="NotSet" LoadingPanelID="RadAjaxLoadingPanel2" RenderMode="Inline">
                       
                               <table class="auto-style66">
                            <tr>
                                <td colspan="4">
                                    <asp:Panel ID="Panel1" runat="server">
                                        <table class="auto-style66">
                                            <tr>
                                                <td class="auto-style81">&nbsp;</td>
                                                <td class="auto-style89">
                                                    Issued</td>
                                                <td>&nbsp;</td>
                                                <td class="auto-style85">Received</td>
                                                <td>&nbsp;</td>
                                            </tr>
                                            <tr>
                                                <td class="auto-style81">Select System</td>
                                                <td class="auto-style89">
                                                    <telerik:RadComboBox ID="cmbSystem" Runat="server" MarkFirstMatch="True" OnSelectedIndexChanged="cmbSystem_SelectedIndexChanged" Sort="Ascending" Width="300px">
                                                    </telerik:RadComboBox>
                                                </td>
                                                <td>&nbsp;</td>
                                                <td class="auto-style85">
                                                    &nbsp;</td>
                                                <td>
                                                    &nbsp;</td>
                                            </tr>
                                            <tr>
                                                <td class="auto-style81">Issued from Branch</td>
                                                <td class="auto-style89">
                                                    <telerik:RadComboBox ID="cmbbranchfrom" Runat="server" AutoPostBack="True" MarkFirstMatch="True" OnSelectedIndexChanged="cmbbranchfrom_SelectedIndexChanged" Sort="Ascending" Width="300px">
                                                    </telerik:RadComboBox>
                                                    <asp:RequiredFieldValidator ID="RequiredFieldValidator1" runat="server" ControlToValidate="cmbbranchfrom" ErrorMessage="*" ForeColor="Red" InitialValue="Choose Branch" ValidationGroup="A"></asp:RequiredFieldValidator>
                                                </td>
                                                <td>Issued to Branch</td>
                                                <td class="auto-style85">
                                                    <telerik:RadComboBox ID="cmbBranchto" Runat="server" AutoPostBack="True" MarkFirstMatch="True" OnSelectedIndexChanged="cmbBranchto_SelectedIndexChanged" Sort="Ascending" Width="300px">
                                                    </telerik:RadComboBox>
                                                </td>
                                                <td>
                                                    <asp:RequiredFieldValidator ID="RequiredFieldValidator3" runat="server" ControlToValidate="cmbBranchto" ErrorMessage="*" ForeColor="Red" InitialValue="Choose Branch" ValidationGroup="A"></asp:RequiredFieldValidator>
                                                </td>
                                            </tr>
                                            <tr>
                                                <td class="auto-style81">&nbsp;</td>
                                                <td class="auto-style89">
                                                    <telerik:RadComboBox ID="cmbStores" Runat="server" AutoPostBack="True" MarkFirstMatch="True" Sort="Ascending" Visible="False" Width="300px">
                                                    </telerik:RadComboBox>
                                                </td>
                                                <td>&nbsp;</td>
                                                <td class="auto-style85">
                                                    &nbsp;</td>
                                                <td>
                                                    &nbsp;</td>
                                            </tr>
                                            <tr>
                                                <td class="auto-style82">Issued Department</td>
                                                <td class="auto-style88">
                                                    <telerik:RadComboBox ID="cmbDepartmentfrom" Runat="server" AutoPostBack="True" MarkFirstMatch="True" Sort="Ascending" Width="300px" OnSelectedIndexChanged="cmbDepartmentfrom_SelectedIndexChanged">
                                                    </telerik:RadComboBox>
                                                </td>
                                                <td class="auto-style9">&nbsp;Department</td>
                                                <td class="auto-style86">
                                                    <telerik:RadComboBox ID="cmbDepartmentto" Runat="server" AutoPostBack="True" MarkFirstMatch="True" Sort="Ascending" Width="300px" OnSelectedIndexChanged="cmbDepartmentto_SelectedIndexChanged" Height="100px" ItemsPerRequest="10">
                                                    </telerik:RadComboBox>
                                                </td>
                                                <td class="auto-style9">
                                                    <asp:RequiredFieldValidator ID="RequiredFieldValidator5" runat="server" ControlToValidate="cmbDepartmentto" ErrorMessage="*" ForeColor="Red" InitialValue="Choose Department" ValidationGroup="A"></asp:RequiredFieldValidator>
                                                </td>
                                            </tr>
                                            <tr>
                                                <td class="auto-style81">Issued By</td>
                                                <td class="auto-style89">
                                                    <telerik:RadComboBox ID="cmbIssuedby" Runat="server" AutoPostBack="True" MarkFirstMatch="True" Sort="Ascending" Width="300px">
                                                    </telerik:RadComboBox>
                                                </td>
                                                <td>Issued to Person</td>
                                                <td class="auto-style85">
                                                    <telerik:RadComboBox ID="cmbPersonto" Runat="server" AutoPostBack="True" MarkFirstMatch="True" Sort="Ascending" Width="300px"  
                                                        CheckBoxes="true" EnableCheckAllItemsCheckBox="true" DropDownAutoWidth="Enabled" 
                                                        OnSelectedIndexChanged="cmbPersonto_SelectedIndexChanged" NoWrap="True" RegisterWithScriptManager="True" OnClientDropDownClosed="cmbPersonto_DropDownClosed">
                                                    </telerik:RadComboBox>
                                                </td>
                                                <td>
                                                    <asp:RequiredFieldValidator ID="RequiredFieldValidator11" runat="server" ControlToValidate="cmbPersonto" ErrorMessage="*" ForeColor="Red" InitialValue="Choose Department" ValidationGroup="A"></asp:RequiredFieldValidator>
                                                </td>
                                            </tr>
                                            <tr>
                                                <td class="auto-style81">&nbsp;</td>
                                                <td class="auto-style89">
                                                    &nbsp;</td>
                                                <td>&nbsp;</td>
                                                <td class="auto-style85">&nbsp;</td>
                                                <td>&nbsp;</td>
                                            </tr>
                                            <tr>
                                                <td class="auto-style81">Issuing Status</td>
                                                <td class="auto-style89">
                                                    <telerik:RadComboBox ID="cmbIssueStatus" Runat="server" AutoPostBack="True" MarkFirstMatch="True" OnSelectedIndexChanged="cmbIssueStatus_SelectedIndexChanged" Sort="Ascending" Width="300px">
                                                        <Items>
                                                            <telerik:RadComboBoxItem runat="server" Selected="True" Text="Choose Status" Value="Choose Status" />
                                                            <telerik:RadComboBoxItem runat="server" Text="Permenant Issue" Value="P" />
                                                            <telerik:RadComboBoxItem runat="server" Text="Temporary Issue" Value="T" />
                                                        </Items>
                                                    </telerik:RadComboBox>
                                                    <asp:RequiredFieldValidator ID="RequiredFieldValidator7" runat="server" ControlToValidate="cmbIssueType" ErrorMessage="*" ForeColor="Red" InitialValue="Choose Type" ValidationGroup="A"></asp:RequiredFieldValidator>
                                                </td>
                                                <td>&nbsp;</td>
                                                <td class="auto-style85">
                                                    
                                                    <asp:Literal ID="itemsClientSide" runat="server"></asp:Literal>
                                                </td>
                                                <td>&nbsp;</td>
                                            </tr>
                                            <tr>
                                                <td class="auto-style81">Issuing Type</td>
                                                <td class="auto-style89">
                                                    <telerik:RadComboBox ID="cmbIssueType" Runat="server" AutoPostBack="True" MarkFirstMatch="True" OnSelectedIndexChanged="cmbIssueType_SelectedIndexChanged" Sort="Ascending" Width="300px">
                                                        <Items>
                                                            <telerik:RadComboBoxItem runat="server" Selected="True" Text="Choose Type" Value="Choose Type" />
                                                            <telerik:RadComboBoxItem runat="server" Text="Internal Issue" Value="I" />
                                                            <telerik:RadComboBoxItem runat="server" Text="External Issue" Value="E" />
                                                        </Items>
                                                    </telerik:RadComboBox>
                                                    <asp:RequiredFieldValidator ID="RequiredFieldValidator10" runat="server" ControlToValidate="cmbIssueType" ErrorMessage="*" ForeColor="Red" InitialValue="Choose Type" ValidationGroup="A"></asp:RequiredFieldValidator>
                                                </td>
                                                <td>&nbsp;</td>
                                                <td class="auto-style85">&nbsp;</td>
                                                <td>&nbsp;</td>
                                            </tr>
                                            <tr>
                                                <td class="auto-style9">&nbsp;</td>
                                                <td class="auto-style88">
                                                    &nbsp;</td>
                                                <td class="auto-style9">
                                                    <telerik:RadButton ID="btnPrint" runat="server" ButtonType="SkinnedButton" Font-Size="10pt" Height="21px" OnClick="btnPrint_Click" TabIndex="8" Text="PrintGIN" ValidationGroup="A" Width="49px" style="text-align: center" Visible="False">
                                                    </telerik:RadButton>
                                                </td>
                                                <td  dir="ltr">&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;
                                                </td>
                                                <td class="auto-style9">&nbsp;</td>
                                            </tr>
                                            <tr>
                                           
                               <%--             <asp:UpdatePanel ID="UpdatePanel2" runat="server" UpdateMode="Conditional" ChildrenAsTriggers="false">
                                            <ContentTemplate> --%>

                                               <td class="auto-style9">Search Item</td>
 
                                                <td class="auto-style9">
          

      <telerik:RadComboBox RenderMode="Lightweight" ID="cmbItemSearch" AllowCustomText="true" runat="server" OnSelectedIndexChanged="cmbItemSearch_SelectedIndexChanged" Width="350" Height="400px" filter="Contains"
                        AutoPostBack="True" MarkFirstMatch="True" Sort="Ascending"  CheckBoxes="true" EnableCheckAllItemsCheckBox="true" EmptyMessage="Search for items...">
                    </telerik:RadComboBox>



                                                </td>
                                                <td class="auto-style9">
                                                    &nbsp;</td>
                                                <td>
                                                    &nbsp;</td>
                                                <td class="auto-style9">&nbsp;</td>
                                           
                                     <%--      </ContentTemplate>
                                           </asp:UpdatePanel> --%>

                                            </tr>
                                            <tr>
                                                <td class="auto-style94">Category</td>
                                                <td class="auto-style95">
                                                    <telerik:RadComboBox ID="cmbCatagories" runat="server" AutoPostBack="True" OnSelectedIndexChanged="cmbCatagories_SelectedIndexChanged" Sort="Ascending" Width="300px">
                                                    </telerik:RadComboBox>
                                                </td>
                                                <td class="auto-style94"></td>
                                                <td class="auto-style94"></td>
                                                <td class="auto-style9"></td>
                                            </tr>
                                            <tr>
                                                <td class="auto-style9" style="visibility: hidden">Sub. Category</td>
                                                <td class="auto-style88" style="visibility: hidden">
                                                    <telerik:RadComboBox ID="cmbSubCategory" Runat="server" AutoPostBack="True" MarkFirstMatch="True" OnSelectedIndexChanged="cmbSubCategory_SelectedIndexChanged" Sort="Ascending" TabIndex="10" Width="300px">
                                                    </telerik:RadComboBox>
                                                </td>
                                                <td class="auto-style9" style="visibility: hidden">&nbsp;</td>
                                                <td class="auto-style86" style="visibility: hidden">&nbsp;</td>
                                                <td class="auto-style9">&nbsp;</td>
                                            </tr>
                                            <tr>
                                                <td class="auto-style9" style="visibility: hidden">Item Head</td>
                                                <td class="auto-style88" style="visibility: hidden">
                                                    <telerik:RadComboBox ID="cmbItemHead" Runat="server" AutoPostBack="True" MarkFirstMatch="True" MaxHeight="150px" OnSelectedIndexChanged="cmbItemHead_SelectedIndexChanged" Sort="Ascending" TabIndex="11" Width="300px">
                                                    </telerik:RadComboBox>
                                                </td>
                                                <td class="auto-style9" style="visibility: hidden">&nbsp;</td>
                                                <td class="auto-style86" style="visibility: hidden">&nbsp;</td>
                                                <td class="auto-style9">&nbsp;</td>


                                            </tr>
                                            
                                            <tr>                                       
                                                <td class="auto-style9" style="visibility: hidden">Item Name</td>
                                                <td class="auto-style88" style="visibility: hidden">
                                                    <telerik:RadComboBox ID="cmbItem" Runat="server" AutoPostBack="True" MarkFirstMatch="True" Sort="Ascending" Width="300px">
                                                    </telerik:RadComboBox>
                                                    <asp:RequiredFieldValidator ID="RequiredFieldValidator6" runat="server" ControlToValidate="cmbItem" ErrorMessage="*" ForeColor="Red" InitialValue="Choose Item" ValidationGroup="A"></asp:RequiredFieldValidator>
                                                </td>
                                                <td class="auto-style9" style="visibility: hidden">
                                                    <telerik:RadButton ID="btnSubmit" runat="server" ButtonType="SkinnedButton" Font-Size="10pt" Height="30px" OnClick="btnSubmit_Click" Text="Add Item" ValidationGroup="A" Visible="False">
                                                    </telerik:RadButton>
                                                </td>
                                                <td class="auto-style86" style="visibility: hidden"></td>
                                                <td class="auto-style9" style="visibility: hidden"></td>
                                            </tr>
                                            <tr>
                                                <td class="auto-style90">Acknowd. Date</td>
                                                <td class="auto-style91">
                                                    <asp:TextBox ID="rdackdate" runat="server"></asp:TextBox>
                                                    <asp:CalendarExtender ID="rdackdate_CalendarExtender" runat="server" Enabled="True"  TargetControlID="rdackdate">
                                                    </asp:CalendarExtender>
                                                </td>
                                                <td class="auto-style90"></td>
                                                <td class="auto-style90">Items Issued Receipt:
                                                    <asp:TextBox ID="txtginno" runat="server" BorderColor="#000066" BorderWidth="1px" Enabled="False" Height="20px" onkeydown="addItem(event);" style="font-size: x-small" TabIndex="5" Width="75px"></asp:TextBox>
                                                    &nbsp;<a href="ReportsMain.aspx?rptname=GoodsIssueNote&amp;gino=<%= txtginno.Text %>" target="_blank">Print</a><br /> </td>
                                                <td class="auto-style90"></td>
                                            </tr>
                                            <tr>
                                                <td class="auto-style90">
                                                    <asp:Label ID="lblreceievedate" runat="server" Text="Return Date" Visible="False"></asp:Label>
                                                </td>
                                                <td class="auto-style91">
                                                    <asp:TextBox ID="rdReturndate" runat="server" Visible="False"></asp:TextBox>
                                                    <asp:CalendarExtender ID="rdReturndate_CalendarExtender" runat="server" Enabled="True" TargetControlID="rdReturndate">
                                                    </asp:CalendarExtender>
                                                    <asp:RequiredFieldValidator ID="RequiredFieldValidator9" runat="server" ControlToValidate="rdReturndate" Enabled="False" ErrorMessage="*" ForeColor="Red" ValidationGroup="A"></asp:RequiredFieldValidator>
                                                </td>
                                                <td class="auto-style90">&nbsp;</td>
                                                <td class="auto-style90">&nbsp;</td>
                                                <td class="auto-style90">&nbsp;</td>
                                            </tr>
                                            <tr>

                                     <%--       <asp:UpdatePanel ID="UpdatePanel3" runat="server" UpdateMode="Conditional" ChildrenAsTriggers="false">
                                            <ContentTemplate> --%>
                                               
                                                <td align="center" colspan="1" style="width: 350px">&nbsp;</td>
                                                <td align="left" colspan="2">
                                                    <asp:GridView ID="grdItems" runat="server" AlternatingRowStyle-CssClass="alt" AutoGenerateColumns="False" CssClass="mGrid" 
                                                        OnRowCommand="grdItems_RowCommand" OnRowDeleting="grdItems_RowDeleting" 
                                                        OnRowEditing="grdItems_RowEditing" OnRowUpdating="grdItems_RowUpdating" OnRowUpdated="grdItems_RowUpdated"
                                                        OnDataBound="grdItems_DataBound" OnRowCreated="grdItems_RowCreated" OnRowDataBound="grdItems_RowDataBound"
                                                        PagerStyle-CssClass="pgr" style="font-size: x-small; text-align: center;" Width="657px">
                                                        <Columns>
                                                            <asp:CommandField ShowDeleteButton="True" />
                                                            <%--<asp:BoundField DataField="Item Code" HeaderText="Item Code" />--%>

                                                            <asp:TemplateField HeaderText="Item Code" Visible="false">
                                                                <ItemTemplate>
                                                                <asp:Label ID="lblItemID" runat="server" Text='<%#Eval("Item Code") %>' Width="50px" />
                                                                </ItemTemplate>
                                                                <ItemStyle HorizontalAlign="Right" VerticalAlign="Middle" />
                                                           </asp:TemplateField>

                                                            <asp:BoundField DataField="Item Name" HeaderText="Item Name" />
                                                          <%--  <asp:BoundField DataField="Balance" HeaderText="Balance" />--%>

                                                            <asp:TemplateField HeaderText="Balance">
                                                            <ItemTemplate>
                                                                 <asp:Label ID="lblbalance" runat="server" Text='<%#Eval("Balance") %>' Width="50px" />
                                                            </ItemTemplate>
                                                              <ItemStyle HorizontalAlign="Right" VerticalAlign="Middle" />
                                                            </asp:TemplateField>

                                                            <asp:TemplateField HeaderText="Qty Issued">
                                                                <ItemTemplate>
                                                                    <asp:TextBox ID="txtqty" runat="server" AutoPostBack="False" OnTextChanged="txtqty_TextChanged" Text='<%#Eval("Qty Issued") %>' onclick="GridRowNo(<%# Container.DataItemIndex %>,this);" Width="50px"></asp:TextBox>
                                                                </ItemTemplate>
                                                            </asp:TemplateField>
                                                        </Columns>
                                                    </asp:GridView>
                                                </td>
                                                <td align="left" style="width: 350px">&nbsp;</td>
                                           
                                      <%--      </ContentTemplate>
                                            </asp:UpdatePanel> --%>

                                            </tr>
                                            <tr>
                                                <td align="left" colspan="5" style="width: 850px">
                                                    <asp:Label ID="lblRecvName" runat="server" Font-Bold="true" ForeColor="Blue" Text="Remarks: (Use This Text Box to Mention any Remarks or Multiple Person(s) Name to Whom you Issue Selected Items)"></asp:Label>
                                                </td>
                                            </tr>
                                            <tr>
                                                <td align="left" colspan="4" style="width: 350px">
                                                    <asp:TextBox ID="txtremarks" runat="server" BorderColor="#000066" BorderWidth="1px" Height="20px" onkeydown="addItem(event);" style="font-size: x-small" TabIndex="5" Width="861px"></asp:TextBox>
                                                </td>
                                            </tr>
                                            <tr>
                                                <td class="auto-style77" colspan="2">
                                                    <asp:TextBox ID="txtpersonid" runat="server" BorderColor="#000066" BorderWidth="1px" Height="20px" onkeydown="addItem(event);" style="font-size: x-small" TabIndex="5" Width="861px" Visible="False"></asp:TextBox>
                                                </td>
                                                <td class="auto-style77">&nbsp;</td>
                                                <td class="auto-style85">&nbsp;</td>
                                                <td class="auto-style77">&nbsp;</td>
                                            </tr>
                                            <tr>
                                                <td class="auto-style81">
                                                    <telerik:RadButton ID="btnOldGIN" runat="server" ButtonType="SkinnedButton" Font-Size="10pt" Height="30px" OnClick="btnOldGIN_Click" TabIndex="19" Text="OLD IIR Entry" ValidationGroup="A" Width="100px">
                                                    </telerik:RadButton>
                                                </td>
                                                <td class="auto-style89">
                                                    OLD IIR Number:
                                                    <asp:TextBox ID="txtoldGIN" runat="server" BorderColor="#000066" BorderWidth="1px" Height="20px" TabIndex="20" Visible="False" Width="52px">0</asp:TextBox>
                                                </td>
                                                <td>
                                                    <telerik:RadButton ID="btnSubmitItem" runat="server" ButtonType="SkinnedButton" Font-Size="10pt" Height="30px" OnClick="btnSubmitItem_Click" Text="Save Receipt" ValidationGroup="A" style="text-align: center; font-weight: 700; font-style: italic" Width="99px" UseSubmitBehavior="False">
                                                    </telerik:RadButton>
                                                </td>
                                                <td class="auto-style85">&nbsp;</td>
                                                <td>&nbsp;</td>
                                            </tr>
                                            <tr>
                                                <td class="auto-style81">&nbsp;</td>
                                                <td class="auto-style89">&nbsp;</td>
                                                <td>&nbsp;</td>
                                                <td class="auto-style85">&nbsp;</td>
                                                <td>&nbsp;</td>
                                            </tr>
                                        </table>
                                    </asp:Panel>
                                </td>
                            </tr>
                            <tr>
                                <td class="auto-style75">
                                    <telerik:RadSlider ID="RadSlider1" runat="server">
                                    </telerik:RadSlider>
                                </td>
                                <td class="auto-style68">&nbsp;</td>
                                <td class="auto-style67">
                                    <span class="auto-style92"><span class="auto-style93">*IIR = Item Issued Receipt</span> </span>&nbsp;&nbsp;&nbsp;&nbsp;
                                </td>
                                <td>&nbsp;</td>
                            </tr>
                        </table>
                    </telerik:RadAjaxPanel>
                    </td>
               

                    </ContentTemplate>
                    </asp:UpdatePanel> 
                        
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

</asp:Content>
