<%@ Page Title="" Language="C#" MasterPageFile="~/Site1.Master" AutoEventWireup="true" CodeBehind="WorkOrder.aspx.cs" Inherits="IMS.WorkOrder" %>

<%@ Register TagPrefix="telerik" Namespace="Telerik.Web.UI" Assembly="Telerik.Web.UI" %>

<%@ Register Assembly="AjaxControlToolkit" Namespace="AjaxControlToolkit" TagPrefix="asp" %>

<asp:Content ID="Content1" ContentPlaceHolderID="HeadContent" runat="server">

    <style type="text/css">
        body
        {
            font-family: Arial;
            font-size: 10pt;
        }
         
        /*CSS Classes For Design Modal*/
        .modalPopup
        {
            /*min-height: 75px;*/
            min-height: 575px;
            position: fixed;
            z-index: 2000;
            padding: 0;
            background-color: #fff;
            border-radius: 6px;
            background-clip: padding-box;
            border: 1px solid rgba(0, 0, 0, 0.2);
            /*min-width: 290px;*/
               min-width: 1000px;
            box-shadow: 0 5px 10px rgba(0, 0, 0, 0);
        }
        .modalBackground
        {
            position: fixed;
            top: 0;
            left: 0;
            background-color: #000;
            opacity: 0.5;
            z-index: 1800;
            min-height: 100%;
            width: 100%;
            overflow: hidden;
            filter: alpha(opacity=50);
            display: inline-block;
            z-index: 1000;
        }
    </style>

   <%-- Used links for References --%>
    <link media="screen" rel="stylesheet" href='http://cdnjs.cloudflare.com/ajax/libs/twitter-bootstrap/3.0.3/css/bootstrap.min.css' />
    <link rel="stylesheet" type="text/css" href="https://cdnjs.cloudflare.com/ajax/libs/jquery-footable/0.1.0/css/footable.min.css" />
    <script type="text/javascript" src="http://ajax.googleapis.com/ajax/libs/jquery/1.8.3/jquery.min.js"></script>
    <script type="text/javascript" src="https://cdnjs.cloudflare.com/ajax/libs/jquery-footable/0.1.0/js/footable.min.js"></script>

    <script type="text/javascript">
        /* Applied Responsive For Grid View using footable js*/
        $(function () {
            $('[id*=GridView1]').footable();
        });
    </script>





</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">
</asp:Content>
<asp:Content ID="Content3" ContentPlaceHolderID="MainContent" runat="server">

     

    <%--Grid With Add New Employee button Design --%>
    <div align="center" style="padding-top: 20px;">
        <div class="row">
            <div class="col-md-12">
                <div class="form-group">
                    <div class="row">
                        <div class="col-md-12">
                            <asp:GridView ID="GridView1" runat="server" CssClass="footable" AutoGenerateColumns="false"  Style="max-width: 500px">
                                <Columns>
                                    <asp:BoundField DataField="Id" HeaderText="Id" />
                                    <asp:BoundField DataField="Name" HeaderText="Name" />
                                    <asp:BoundField DataField="Country" HeaderText="Country" />
                                    <asp:BoundField DataField="Salary" HeaderText="Salary" DataFormatString="{0:N}" />
                                    <asp:TemplateField HeaderText="">
                                        <ItemTemplate>
                                            <asp:Button ID="btnEdit" runat="server" Text="Edit" OnClick="Edit" CommandArgument='<%# Eval("Id") %>'
                                                class="btn btn-primary" />
                                        </ItemTemplate>
                                    </asp:TemplateField>
                                    <asp:TemplateField HeaderText="">
                                        <ItemTemplate>
                                            <asp:Button ID="btnDelete" runat="server" Text="Delete" OnClick="Delete" CommandArgument='<%# Eval("Id") %>'
                                                class="btn btn-danger" />
                                        </ItemTemplate>
                                    </asp:TemplateField>
                                </Columns>
                                <EmptyDataTemplate>
                                    <table cellpadding="0" cellspacing="0" width="100%" class="footable">
                                        <tr style="background-color: #DCE9F9;">
                                            <th class="hidden-xs">
                                                <b>ID</b>
                                            </th>
                                            <th>
                                                <b>Name</b>
                                            </th>
                                            <th class="hidden-xs">
                                                <b>Country</b>
                                            </th>
                                            <th class="hidden-xs">
                                                <b>Salary</b>
                                            </th>
                                            <th>
                                                &nbsp;
                                            </th>
                                            <th>
                                                &nbsp;
                                            </th>
                                        </tr>
                                        <tr>
                                            <td colspan="6" align="center" style="text-align: center;">
                                                <b>No Records Found</b>
                                            </td>
                                        </tr>
                                    </table>
                                </EmptyDataTemplate>
                            </asp:GridView>
                        </div>
                    </div>
                </div>
                <div class="form-group">
                    <div class="row">
                        <div class="col-md-12">
                            <asp:Button ID="btnAdd" runat="server" Text="Add New Employee" OnClick="Add" class="btn btn-success" />
                        </div>
                    </div>
                </div>
            </div>
        </div>
    </div>
 
    <%--lnkFake Link Button for mpeAddUpdateEmployee ModalPopup as TargetControlID--%>
    <asp:LinkButton ID="lnkFake" runat="server"></asp:LinkButton>
 
    <%--pnlAddUpdateEmployeeDetails Panel With Design--%>

    <asp:Panel ID="pnlAddUpdateEmployeeDetails" runat="server" CssClass="modalPopup" Style="display: none;">
        <div style="overflow-y: auto; overflow-x: hidden; max-height: 450px;">
            <div class="modal-header">
                <asp:Label ID="lblHeading" runat="server" CssClass="modal-title"></asp:Label>
            </div>
            <div class="modal-body">
                <div class="form-group">
                    <div class="row">
                        <div class="col-md-3">
                            <label for="txtName">
                                Name</label>
                        </div>
                        <div class="col-md-6">
                            <asp:TextBox ID="txtName" runat="server" CssClass="form-control" placeholder="Name"
                                Width="150px"></asp:TextBox>
                        </div>
                        <div class="col-md-3">
                            <asp:RequiredFieldValidator ID="rfvName" Display="Dynamic" ValidationGroup="Employee"
                                ErrorMessage="Required" ControlToValidate="txtName" runat="server" ForeColor="Red" />
                        </div>
                    </div>
                </div>
                <div class="form-group">
                    <div class="row">
                        <div class="col-md-3">
                            <label for="txtCountry">
                                Country</label>
                        </div>
                        <div class="col-md-6">
                            <asp:TextBox ID="txtCountry" runat="server" CssClass="form-control" placeholder="Country"
                                Width="150px"></asp:TextBox>
                        </div>
                        <div class="col-md-3">
                            <asp:RequiredFieldValidator ID="rfvCountry" ErrorMessage="Required" Display="Dynamic"
                                ValidationGroup="Employee" ControlToValidate="txtCountry" runat="server" ForeColor="Red" />
                        </div>
                    </div>
                </div>
                <div class="form-group">
                    <div class="row">
                        <div class="col-md-3">
                            <label for="txtSalary">
                                Salary</label>
                        </div>
                        <div class="col-md-6">
                            <asp:TextBox ID="txtSalary" runat="server" CssClass="form-control" placeholder="Salary"
                                Width="150px"></asp:TextBox>
                            <asp:FilteredTextBoxExtender ID="ftSalary" runat="server" TargetControlID="txtSalary"
                                FilterType="Custom" ValidChars="1234567890.">
                            </asp:FilteredTextBoxExtender>
                        </div>
                        <div class="col-md-3">
                            <asp:RequiredFieldValidator ID="rfvSalary" Display="Dynamic" ValidationGroup="Employee"
                                ErrorMessage="Required" ControlToValidate="txtSalary" runat="server" ForeColor="Red" />
                        </div>
                    </div>
                </div>
            </div>
            <div align="center" class="modal-footer">
                <div class="row">
                    <div class="col-md-12">
                        <asp:HiddenField ID="hfAddEditEmployeeId" runat="server" Value="0" />
                        <asp:HiddenField ID="hfAddEdit" runat="server" Value="ADD" />
                        <asp:Button ID="btnSave" runat="server" Text="ADD" OnClick="Save" class="btn btn-success"
                            ValidationGroup="Employee"></asp:Button>
                        <button id="btnCancel" runat="server" class="btn btn-primary">
                            Cancel
                        </button>
                    </div>
                </div>
            </div>
        </div>
    </asp:Panel>
 
     <%--mpeAddUpdateEmployee Modal Popup Extender For pnlAddUpdateEmployeeDetails--%>
    <asp:ModalPopupExtender ID="mpeAddUpdateEmployee" runat="server" PopupControlID="pnlAddUpdateEmployeeDetails"
        TargetControlID="lnkFake" BehaviorID="mpeAddUpdateEmployee" CancelControlID="btnCancel"
        BackgroundCssClass="modalBackground">
    </asp:ModalPopupExtender>
 
    <%--lnkFake1 Link Button for mpeDeleteEmployee ModalPopup as TargetControlID--%>
    <asp:LinkButton ID="lnkFake1" runat="server"></asp:LinkButton>
 
    <%--pnlDeleteEmployee Panel With Design--%>
    <asp:Panel ID="pnlDeleteEmployee" runat="server" CssClass="modalPopup" Style="display: none;">
        <div id="Div1" runat="server" class="header">
        </div>
        <div style="overflow-y: auto; overflow-x: hidden; max-height: 450px;">
            <div class="form-group modal-body">
                <div class="row">
                    <div class="col-md-12">
                        Do you Want to delete this record of Employee ID:
                        <asp:Label id="EMPID" runat="server"/>
                    </div>
                </div>
            </div>
        </div>
        <div align="right" class="modal-footer">
            <div class="row">
                <div class="col-md-12">
                    <asp:HiddenField ID="hfDeleteEmployeeId" runat="server" Value="0" />
                     
                    <asp:Button ID="btnYes" runat="server" Text="Yes" OnClick="Yes" class="btn btn-danger">
                    </asp:Button>
                    <button id="btnNo" runat="server" class="btn btn-default">
                        Cancel
                    </button>
                </div>
            </div>
        </div>
    </asp:Panel>
 
   <%-- mpeDeleteEmployee Modal Popup Extender For pnlDeleteEmployee--%>
    <asp:ModalPopupExtender ID="mpeDeleteEmployee" runat="server" PopupControlID="pnlDeleteEmployee"
        TargetControlID="lnkFake1" BehaviorID="mpeDeleteEmployee" CancelControlID="btnNo" 
        BackgroundCssClass="modalBackground">
    </asp:ModalPopupExtender>












<%--    <asp:SqlDataSource ID="SqlDataSource1" ConnectionString="<%$ ConnectionStrings:INVENTORY %>"
        ProviderName="System.Data.SqlClient"
        SelectCommand="SELECT [EstimateNo],[Description] FROM [INVENTORY].[dbo].[tblWOMain] where fkUserID=@UserID" runat="server"

        DeleteCommand="DELETE FROM [tblWOMain] WHERE [EstimateNo] = @EstimateNo"
        InsertCommand="INSERT INTO [tblWOMain] ([EstimateNo],[Description]) VALUES (@EstimateNo, @Description)"
        UpdateCommand="UPDATE [tblWOMain] SET [Description] = @Description WHERE [EstimateNo] = @EstimateNo">
        <DeleteParameters>
            <asp:Parameter Name="EstimateNo" Type="String"></asp:Parameter>
        </DeleteParameters>
        <InsertParameters>
            <asp:Parameter Name="EstimateNo" Type="String"></asp:Parameter>
            <asp:Parameter Name="Description" Type="String"></asp:Parameter>
        </InsertParameters>
        <UpdateParameters>
            <asp:Parameter Name="Description" Type="String"></asp:Parameter>
            <asp:Parameter Name="EstimateNo" Type="String"></asp:Parameter>
        </UpdateParameters>

        <SelectParameters>
            <asp:ControlParameter ControlID="txtuserID" Name="UserID" DefaultValue="0" PropertyName="Text"></asp:ControlParameter>
        </SelectParameters>

    </asp:SqlDataSource>

    <asp:SqlDataSource ID="SqlDataSource2" ConnectionString="<%$ ConnectionStrings:INVENTORY %>"
        ProviderName="System.Data.SqlClient"
        SelectCommand="SELECT EstMastID,EstimateNo,WorkNo,WorkDesc,Cost,Paid FROM [INVENTORY].[dbo].[tblWOMaster] WHERE ([EstimateNo] = @EstimateNo)"
        DeleteCommand="DELETE FROM [tblWOMaster] WHERE ([EstimateNo] = @EstimateNo) AND ([WorkNo] = @WorkNo)"
        InsertCommand="INSERT INTO [tblWOMaster] ([EstimateNo], [WorkNo],[WorkDesc], [Cost]) VALUES (@EstimateNo, @WorkNo, @WorkDesc, @Cost)"
        UpdateCommand="UPDATE [tblWOMaster] SET [WorkDesc] = @WorkDesc, [Cost] = @Cost WHERE ([EstimateNo] = @EstimateNo) AND ([WorkNo] = @WorkNo)" runat="server">

<%--        <SelectParameters>
            <asp:ControlParameter ControlID="RadGrid1" Name="EstimateNo" PropertyName="SelectedValue" Type="String"></asp:ControlParameter>
        </SelectParameters>--%>


<%--        <DeleteParameters>
            <asp:Parameter Name="EstimateNo" Type="Int32"></asp:Parameter>
            <asp:Parameter Name="WorkNo" Type="Int32"></asp:Parameter>
        </DeleteParameters>
        <InsertParameters>
            <asp:Parameter Name="EstimateNo" Type="Int32"></asp:Parameter>
            <asp:Parameter Name="WorkNo" Type="Int32"></asp:Parameter>
            <asp:Parameter Name="WorkDesc" Type="Decimal"></asp:Parameter>
            <asp:Parameter Name="Cost" Type="Int16"></asp:Parameter>
        </InsertParameters>
        <UpdateParameters>
            <asp:Parameter Name="WorkDesc" Type="Decimal"></asp:Parameter>
            <asp:Parameter Name="Cost" Type="Int16"></asp:Parameter>
            <asp:Parameter Name="EstimateNo" Type="Int32"></asp:Parameter>
            <asp:Parameter Name="WorkNo" Type="Int32"></asp:Parameter>
        </UpdateParameters>--%>


<%--    </asp:SqlDataSource>

    <asp:SqlDataSource ID="SqlDataSource3" ConnectionString="<%$ ConnectionStrings:INVENTORY %>" 
        ProviderName="System.Data.SqlClient"
        SelectCommand="SELECT [EstimateNo], [WorkNo], [PayID], [fkVendID], [GrossAmt], [PaidAmt], [Discount], [PayRecmd], [BillInvoice], [PayDetail] FROM [tblWODetail] WHERE (([EstimateNo] = @EstimateNo) AND ([WorkNo] = @WorkNo) AND ([PayID] = @PayID)) ORDER BY [WorkNo], [PayID]" runat="server"

        DeleteCommand="DELETE FROM [tblWODetail] WHERE [EstimateNo] = @EstimateNo AND [WorkNo] = @WorkNo AND [PayID] = @PayID"
        InsertCommand="INSERT INTO [tblWODetail] ([EstimateNo], [WorkNo],[PayID],[fkVendID], [GrossAmt], [Discount], [PayRecmd],[BillInvoice], [PayDetail]) VALUES (@EstimateNo, @WorkNo, @PayID, @fkVendID, @GrossAmt,@Discount,@PayRecmd,@BillInvoice,@PayDetail)"
   <%--     SelectCommand="SELECT * FROM [Order Details] WHERE [OrderID] = @OrderID"
        UpdateCommand="UPDATE [tblWODetail] SET [fkVendID] = @fkVendID, [GrossAmt] = @GrossAmt, [Discount] = @Discount, [PayRecmd] = @PayRecmd, [BillInvoice] = @BillInvoice, [PayDetail] = @PayDetail WHERE [EstimateNo] = @EstimateNo AND [WorkNo] = @WorkNo AND [PayID] = @PayID">
     
        <SelectParameters>
            <asp:Parameter Name="EstimateNo" Type="Int32"></asp:Parameter>
        </SelectParameters>
        <DeleteParameters>
            <asp:Parameter Name="EstimateNo" Type="Int32"></asp:Parameter>
            <asp:Parameter Name="WorkNo" Type="Int32"></asp:Parameter>
            <asp:Parameter Name="PayID" Type="Int32"></asp:Parameter>
        </DeleteParameters>
        <InsertParameters>
            <asp:Parameter Name="EstimateNo" Type="Int32"></asp:Parameter>
            <asp:Parameter Name="WorkNo" Type="Int32"></asp:Parameter>
            <asp:Parameter Name="PayID" Type="Int32"></asp:Parameter>
            <asp:Parameter Name="fkVendID" Type="Int16"></asp:Parameter>
            <asp:Parameter Name="GrossAmt" Type="Single"></asp:Parameter>
            <asp:Parameter Name="PaidAmt" Type="Single"></asp:Parameter>
            <asp:Parameter Name="Discount" Type="Single"></asp:Parameter>
            <asp:Parameter Name="PayRecmd" Type="Single"></asp:Parameter>
            <asp:Parameter Name="BillInvoice" Type="Single"></asp:Parameter>
            <asp:Parameter Name="PayDetail" Type="String"></asp:Parameter>
        </InsertParameters>
        <UpdateParameters>
            <asp:Parameter Name="EstimateNo" Type="Int32"></asp:Parameter>
            <asp:Parameter Name="WorkNo" Type="Int32"></asp:Parameter>
            <asp:Parameter Name="PayID" Type="Decimal"></asp:Parameter>
            <asp:Parameter Name="fkVendID" Type="Int16"></asp:Parameter>
            <asp:Parameter Name="GrossAmt" Type="Single"></asp:Parameter>
            <asp:Parameter Name="PaidAmt" Type="Single"></asp:Parameter>
            <asp:Parameter Name="Discount" Type="Single"></asp:Parameter>
            <asp:Parameter Name="PayRecmd" Type="Single"></asp:Parameter>
            <asp:Parameter Name="BillInvoice" Type="Single"></asp:Parameter>
            <asp:Parameter Name="PayDetail" Type="String"></asp:Parameter>

        </UpdateParameters>


      <SelectParameters>
            <asp:ControlParameter ControlID="RadGrid1" Name="EstimateNo" PropertyName="SelectedValue" Type="String"></asp:ControlParameter>
           <%-- <asp:ControlParameter ControlID="RadGrid2" Name="WorkNo" DefaultValue="1" PropertyName="SelectedValue" Type="String"></asp:ControlParameter>
        </SelectParameters>

    </asp:SqlDataSource>--%>


 


</asp:Content>
