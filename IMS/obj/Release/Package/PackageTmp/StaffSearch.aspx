
<%@ Page Title="" Language="C#" MasterPageFile="~/Site3.Master" AutoEventWireup="true" CodeBehind="StaffSearch.aspx.cs" Inherits="IMS.StaffSearch" %>

<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">

      <link href="https://cdn.datatables.net/1.10.20/css/jquery.dataTables.min.css" rel="stylesheet"/>

      <link rel="stylesheet" type="text/css" href="https://cdnjs.cloudflare.com/ajax/libs/twitter-bootstrap/3.3.6/css/bootstrap.min.css" />
      <link rel="stylesheet" type="text/css" href="https://cdnjs.cloudflare.com/ajax/libs/bootstrap-table/1.10.1/bootstrap-table.min.css" />



  <script type="text/javascript" src="https://cdnjs.cloudflare.com/ajax/libs/twitter-bootstrap/3.3.6/js/bootstrap.min.js"></script>
  <script type="text/javascript" src="https://cdnjs.cloudflare.com/ajax/libs/bootstrap-table/1.10.1/bootstrap-table.min.js"></script>
      
 

    <script src="https://code.jquery.com/jquery-3.3.1.js"> </script>
    <script src="https://cdn.datatables.net/1.10.20/js/jquery.dataTables.min.js"> </script>


 
 


</asp:Content>

<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">


     <div class="container">
        <div class="table-wrapper">
            <div class="table-title">
                <div class="row">
                    <div class="col-sm-12">
                        <h2>Search <b>Staff</b></h2>

                        <div class="panel panel-default">
                            <div class="panel-heading">
                                <h5>Find Items Issued to Staff</h5>
                            </div>

                            <div class="panel-body">
                                       <asp:ScriptManager ID="ScriptManager1" runat="server"></asp:ScriptManager>
                                <asp:UpdatePanel ID="UpdatePanel1" runat="server">

                                    <ContentTemplate>

                                        <asp:Button ID="ShowMe" CssClass="btn btn-primary btn-lg" runat="server" Text="Request Spare" ClientIDMode="Static" data-toggle="modal" data-backdrop="static" data-target="#myModal" Style="display: none;" OnClientClick="return  false" />

 
                                 <div class="form-group">
                                    <div class="row">
                                        <div class="col-md-12">
                                            <input type="hidden" id="Hidden6" runat="server" />
                                            <input type="hidden" id="Hidden7" runat="server" />
                                            <input type="hidden" id="Hidden8" runat="server" />

                                            <div class="table-responsive">

                                                <table class="table table-striped table-bordered table-hover" id="dataTables-staffSearch">
                                                    <thead>
                                                        <tr>
                                                            <th style="text-align: center; width: 5%" data-field="IssueDate" data-align="center" data-sortable="true" data-filter-control="input" data-visible="true">IssueDate</th>
                                                            <th style="text-align: center; width: 25%" data-field="Branch" data-sortable="true" data-filter-control="input" data-visible="true">Branch</th>
                                                            <th style="text-align: center; width: 25%" data-field="Employee" data-align="center" data-sortable="true" data-filter-control="input" data-visible="true">Employee</th>
                                                            <th style="text-align: center; width: 10%" data-field="GINCode" data-sortable="true" data-filter-control="input" data-visible="true">GINCode</th> 
                                                            <th style="text-align: center; width: 10%" data-field="InvCode" data-sortable="true" data-filter-control="input" data-visible="true">InvCode</th>
                                                            <th style="text-align: center; width: 25%" data-field="Item" data-sortable="true" data-filter-control="input" data-visible="true">Item</th>
                                                            <th style="text-align: center; width: 5%" data-field="Qtty" data-sortable="true" data-filter-control="input" data-visible="true">Qtty</th>
                                                        </tr>
                                                    </thead>
                                                    <tbody>

                                                        <asp:PlaceHolder ID="PlaceHolder1" runat="server"></asp:PlaceHolder>

                                                    </tbody>

                                                </table>

                                            </div>

                                        </div>
                                    </div>
                                </div>

                                        

                                    </ContentTemplate>
                                </asp:UpdatePanel>

                            </div>

                            <!-- /.panel-body -->
                        </div>



                    </div>
                    <div class="col-sm-12">
                    </div>
                </div>
            </div>





        </div>
    </div>
 



 <script type="text/javascript">



     $(document).ready(function () {
         $('#dataTables-staffSearch').DataTable({

             dom: 'lrftip',
             "lengthMenu": [[10, 25, 50, -1], [10, 25, 50, "All"]]
         });
     });
 
    </script>


</asp:Content>
