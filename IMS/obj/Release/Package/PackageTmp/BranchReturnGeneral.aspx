<%@ Page Title="" Language="C#" MasterPageFile="~/Site1.Master" AutoEventWireup="true" CodeBehind="BranchReturnGeneral.aspx.cs" Inherits="IMS.BranchReturnGeneral" %>
<%@ Register assembly="AjaxControlToolkit" namespace="AjaxControlToolkit" tagprefix="asp" %>
<asp:Content ID="Content1" ContentPlaceHolderID="HeadContent" runat="server">

    <link href="CSS/bootstrap.css" rel="stylesheet" />
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">
     <telerik:RadCodeBlock ID="dfg" runat="server">
         <script type="text/javascript">
             function addItem(event) {

                 var keyCode = ('which' in event) ? event.which : event.keyCode;

                <%-- if (keyCode == 13)
                     document.getElementById('<%=btnAddItem.ClientID%>').click(); --%>
             }
        </script>
     </telerik:RadCodeBlock>

    <div id="wrapper">


        <div id="page-wrapper">
            <div id="page-inner">
                <div class="row">
                    <div class="col-md-12">
                        <h3 class="page-header">Item Received From Branches <small>Un-Recorded Items.</small>
                        </h3>
                    </div>
                </div>
                <!-- /. ROW  -->
                <div class="row">
                    <div class="col-lg-12">
                        <div class="panel panel-default">

                                      

                            <div class="panel-heading">
                                Goods Received Notes (GRN)
                            </div>

                            <div class="panel-body">


                                 

                                <asp:UpdatePanel ID="UpdatePanel1" runat="server">
                                    <ContentTemplate>

                                    

                                        <div class="row">

                                                                       <div class="col-lg-4">


                                            </div>


                                            <div class="col-lg-4">
                                                <label style="background-color:rgb(61, 113, 121)">Sender / Issuer Information</label><br />
                                                <div class="form-group">
                                                    <label>From Branch</label><br />
                                                    <telerik:RadComboBox ID="cmbbranchfrom" runat="server" AutoPostBack="True" MarkFirstMatch="True" Sort="Ascending" Width="300px">
                                                    </telerik:RadComboBox>
                                                </div>
                                                <div class="form-group">
                                                    <label>From Person/Employee</label><br />
                                                    <telerik:RadComboBox ID="cmbPersonto" runat="server" AutoPostBack="True" MarkFirstMatch="True" Sort="Ascending" Width="300px" OnSelectedIndexChanged="cmbPersonto_SelectedIndexChanged">
                                                    </telerik:RadComboBox>
                                                </div>

 
  
                                                <div class="form-group">
                                                    <label>Receive Status</label><br />
                                                                        <telerik:RadComboBox ID="cmbRecvStatus" Runat="server" AutoPostBack="True" MarkFirstMatch="True"  Sort="Ascending" Width="300px">
                                                                            <Items>
                                                                                <telerik:RadComboBoxItem runat="server" Selected="True" Text="Choose Status" Value="Choose Status" />
                                                                                <telerik:RadComboBoxItem runat="server" Text="Permenant Received" Value="P" />
                                                                                <telerik:RadComboBoxItem runat="server" Text="Temporary Received" Value="T" />
                                                                            </Items>
                                                                        </telerik:RadComboBox>
                                                </div>
                                                <div class="form-group">

                                                    <telerik:RadComboBox RenderMode="Lightweight" ID="cmbItemSearch" AllowCustomText="true" runat="server" Width="500" Height="400px" filter="Contains"
                                                        AutoPostBack="True" MarkFirstMatch="True" Sort="Ascending"  CheckBoxes="true" EnableCheckAllItemsCheckBox="true" EmptyMessage="Search for items...">
                                                    </telerik:RadComboBox>

                                                </div>


                                                <div class="form-group">

                                                    <label>Item Detail</label><br />
     <asp:GridView ID="grdItems" runat="server" AlternatingRowStyle-CssClass="alt" AutoGenerateColumns="False" CssClass="mGrid"   Width="734px">
                                                                            <AlternatingRowStyle CssClass="alt" />
                                                                            <Columns>
                                                                               <%-- <asp:BoundField DataField="GINCode" HeaderText="GIN Code" />--%>
                                                                                <asp:BoundField DataField="ItemCode" HeaderText="Item Code" >
                                                                                <ItemStyle Font-Names="Calibri" Font-Size="Medium" />
                                                                                </asp:BoundField>
                                                                                <asp:BoundField DataField="ItemTitle" HeaderText="Item Name" >
                                                                                <ControlStyle Width="400px" />
                                                                                <HeaderStyle Width="400px" />
                                                                                <ItemStyle Width="400px" Font-Names="Calibri" Font-Size="Medium" HorizontalAlign="Left" />
                                                                                </asp:BoundField>
                                                                                <asp:BoundField DataField="Model" HeaderText="Model" >
                                                                                <ItemStyle Font-Names="Calibri" Font-Size="Medium" HorizontalAlign="Center" VerticalAlign="Middle" />
                                                                                </asp:BoundField>
                                                                                <asp:BoundField DataField="Brand" HeaderText="Brand" >
                                                                                <ItemStyle Font-Names="Calibri" Font-Size="Medium" HorizontalAlign="Center" VerticalAlign="Middle" />
                                                                                </asp:BoundField>
                                                                                <asp:BoundField DataField="Unit" HeaderText="Unit" >
                                                                                <ItemStyle Font-Names="Calibri" Font-Size="Medium" HorizontalAlign="Center" VerticalAlign="Middle" />
                                                                                </asp:BoundField>
                                                                                <asp:BoundField DataField="Qtty" HeaderText="Quantity" >
                                                                                <ItemStyle Font-Names="Calibri" Font-Size="Medium" HorizontalAlign="Center" VerticalAlign="Middle" />
                                                                                </asp:BoundField>
                                                                            </Columns>
                                                                        </asp:GridView>
                                                </div>

                                            </div>

                                            <div class="col-lg-4">
                                                <label style="background-color:rgb(61, 113, 121)">Receiver Information</label><br />
                                                <div class="form-group">
                                                    <label>To Branch</label><br />
                                                    <telerik:RadComboBox ID="cmbbranchto" runat="server" AutoPostBack="True" MarkFirstMatch="True" Sort="Ascending" Width="300px">
                                                    </telerik:RadComboBox>
                                                </div>
                                                <div class="form-group">
                                                    <label>To Department</label><br />
                                                    <telerik:RadComboBox ID="cmbDeptto" runat="server" MarkFirstMatch="True" Sort="Ascending" TabIndex="2" Width="300px">
                                                    </telerik:RadComboBox>
                                                </div>
                                                <div class="form-group">
                                                    <label>To Store</label><br />
                                                                        <telerik:RadComboBox ID="cmbstoreto" Runat="server" MarkFirstMatch="True" Sort="Ascending" TabIndex="2" Width="300px">
                                                                        </telerik:RadComboBox>
                                                </div>
                                                <div class="form-group">
                                                    <label>From Department</label><br />
                                                    <telerik:RadComboBox ID="RadComboBox5" runat="server" MarkFirstMatch="True" Sort="Ascending" TabIndex="2" Width="300px">
                                                    </telerik:RadComboBox>
                                                </div>
                                                <div class="form-group">
                                                    <label>From Department</label><br />
                                                    <telerik:RadComboBox ID="RadComboBox6" runat="server" MarkFirstMatch="True" Sort="Ascending" TabIndex="2" Width="300px">
                                                    </telerik:RadComboBox>
                                                </div>


                                            </div>


                                        </div>
                                        

                                    </ContentTemplate>
                                </asp:UpdatePanel>

                                  

                            </div>
                            <!-- /.panel-body -->
                        </div>
                        <!-- /.panel -->
                    </div>
                    <!-- /.col-lg-12 -->
                </div>

                <footer><p>All right reserved. Template by: <a href="http://webthemez.com">WebThemez</a></p></footer>
            </div>
            <!-- /. PAGE INNER  -->
        </div>





    </div>


        <script src="js2/jquery-2.1.1.min.js"></script>
    <script src="JS/bootstrap.min.js"></script>

   

</asp:Content>
