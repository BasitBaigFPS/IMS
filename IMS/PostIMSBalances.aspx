<%@ Page Title="" Language="C#" MasterPageFile="~/Site1.Master" AutoEventWireup="true" CodeBehind="PostIMSBalances.aspx.cs" Inherits="IMS.PostIMSBalances" %>

<%@ Register Assembly="AjaxControlToolkit" Namespace="AjaxControlToolkit" TagPrefix="asp" %>
<%@ Register Assembly="Telerik.Web.UI" Namespace="Telerik.Web.UI" TagPrefix="telerik" %>



<asp:Content ID="Content1" ContentPlaceHolderID="HeadContent" runat="server">

     <style type="text/css">
        #dvLoading {
            display: none;
            background: url('images/BalanceUpdate.gif');
            height: 500px;
            width: 500px;
            margin-left: 22%;
            margin-top: 15%;
        }
    </style>

 <script type="text/javascript">
     $(function () {
         $("#SyncDB").click(function (e) {
             e.preventDefault();
             $('#dvLoading').show();
             $(this).hide();
             $('#dvLoading').fadeOut(5000);
             setTimeout(function () { $("#SyncDB").show(); }, 5000);
         });
     });
    </script>


</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">

    <script type="text/javascript" src="http://ajax.googleapis.com/ajax/libs/jquery/1.9.1/jquery.min.js"></script>
    <script type="text/javascript">
 
        function Confirm() {
            //This Function Work with ASP Button Not with RadControlButton.
            var choice = confirm("Are You Sure, You Want to Post/Update Stock Balance ???", "Yes", "No");
            if (choice == false) {
                window.open(window.location, '_self').close();
                return false;
            }
        }

 
    </script>

    <div class="container">
        <div class="table-wrapper">
            <div class="table-title">
                <div class="row">
                    <div class="col-sm-12">
                        <h2>Stock/Inventory<b>Balances</b></h2>

                        <div class="panel panel-default">
                            <div class="panel-heading">
                                <h5>Posting/Update</h5>
                            </div>
                            <div class="panel-body">
                                <asp:UpdatePanel ID="UpdatePanel1" runat="server">

                                    <ContentTemplate>

 
                                        <div class="row" style="background-color: ghostwhite;">

                                            <div class="col-lg-4">

                                                <div class="form-group">
                                                </div>
                                            </div>
                                            <div class="col-lg-4">

                                                <div class="form-group">
                                                        <asp:UpdateProgress ID="updProgress" runat="server" AssociatedUpdatePanelID="UpdatePanel1">
                                                            <ProgressTemplate>
                                                                <img alt="progress" src="images/BalanceUpdate.gif" style="width:284px;"/>
                                                            </ProgressTemplate>
                                                        </asp:UpdateProgress>
                                                </div>
                                            </div>                                         

                                            <div class="col-lg-4">

                                                <div class="form-group">
                                                </div>
                                            </div>
                                        </div>
                                        <div class="row" style="background-color: ghostwhite;">
                                            <div class="col-lg-6">

                                                <div class="form-group">
                                                    <label runat="server" id="lblbrhach">Select Branch:</label>
                                                    <asp:DropDownList ID="ddlbranch" runat="server" class="form-control" EnableViewState="true" AutoPostBack="true" Font-Overline="False" Font-Size="Small" Height="30px" OnSelectedIndexChanged="ddlbranch_SelectedIndexChanged" Style="width: 300px; text-transform: uppercase; display: inline-block; line-height: 0.8">
                                                    </asp:DropDownList>
                                                </div>
                                             </div>
                                             <div class="col-lg-6">

                                                <div class="form-group">
                                                    <label runat="server" id="lbldepart">Select Department:</label>
                                                    <asp:DropDownList ID="ddlDepartment" runat="server" class="form-control" EnableViewState="true" AutoPostBack="true" Font-Overline="False" Font-Size="Small" Height="30px" OnSelectedIndexChanged="ddlDepartment_SelectedIndexChanged" Style="width: 300px; text-transform: uppercase; display: inline-block; line-height: 0.8">
                                                    </asp:DropDownList>
                                                 </div>

                                            </div>

                                        </div>

                                        <div class="row">
                                            <div class="col-lg-12" style="background-color: burlywood;margin-bottom:10px;">
                                                <h5></h5>
                                            </div>
                                        </div>

                                        <div class="row" style="background-color: ghostwhite;">
                                            <div class="col-lg-4">

                                                <div class="form-group">
                                                </div>
                                            </div>

                                            <div class="col col-lg-4">
                                                <div class="form-group">
                                                   <asp:Button ID="btnPost" runat="server" Text="Post Balances" class="btn btn-warning" CausesValidation="False" OnClick="btnPost_Click" />                                                    
                                                </div>

                                            </div>

                                            <div class="col-lg-4">

                                                <div class="form-group">
                                                        <asp:UpdateProgress ID="UpdateProgress1" runat="server" AssociatedUpdatePanelID="UpdatePanel1">
                                                            <ProgressTemplate>
                                                                <img alt="progress" src="images/ajax-loader.gif" style="width:100px;"/>
                                                            </ProgressTemplate>
                                                        </asp:UpdateProgress>
                                                </div>
                                        
                                        </div>


                                        <!-- /.row (nested) -->

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

    



</asp:Content>
