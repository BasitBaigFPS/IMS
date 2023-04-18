<%@ Page Title="" Language="C#" MasterPageFile="~/Site3.Master" AutoEventWireup="true" CodeBehind="StoreInventoryBootstrap.aspx.cs" Inherits="IMS.StoreInventoryBootstrap" %>

<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">

    <style type="text/css">
        a.LN1 {
            font-style: normal;
            font-weight: bold;
            font-size: 1.0em;
        }

        a.LN2:link {
            color: #A4DCF5;
            text-decoration: none;
        }

        a.LN3:visited {
            color: #A4DCF5;
            text-decoration: none;
        }

        a.LN4:hover {
            color: #A4DCF5;
            text-decoration: none;
        }

        a.LN5:active {
            color: #A4DCF5;
            text-decoration: none;
        }

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

        .auto-style44 {
            font-family: Arial, Helvetica, sans-serif;
            font-size: 12pt;
            width: 69px;
        }

        .auto-style45 {
            width: 69px;
        }

        .auto-style46 {
            width: 164px;
        }

        .auto-style47 {
            font-family: Arial, Helvetica, sans-serif;
            font-size: 12pt;
            width: 118px;
        }

        .auto-style48 {
            width: 118px;
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

        .auto-style58 {
            font-family: Arial, Helvetica, sans-serif;
            width: 97px;
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

        .auto-style63 {
            font-family: Arial, Helvetica, sans-serif;
            height: 30px;
            width: 97px;
            color: #C0C0C0;
        }

        .auto-style64 {
            width: 64px;
            height: 64px;
        }

        .auto-style66 {
            width: 100%;
        }

        .auto-style67 {
            height: 31px;
        }

        table#table1 {
            width: 80%;
            margin-left: 10%;
            margin-right: 15%;
        }
    </style>


    <%--   <link rel="stylesheet" href="CSS/foundation.css" />--%>

<%--    <script src="export/js/jquery.min.js"></script>
    <script src="export/js/bootstrap-table.js"></script>
    <script src="export/js/ga.js"></script>--%>


  <script type="text/javascript" src="http://code.jquery.com/jquery-latest.min.js"></script>

   

<%--    <script src="JS/jquery.dataTables.min.js"></script>

      <script type="text/javascript" src="https://cdnjs.cloudflare.com/ajax/libs/bootstrap-table/1.10.1/bootstrap-table.min.js">
     </script>
    --%>

  <script type="text/javascript" src="https://cdnjs.cloudflare.com/ajax/libs/twitter-bootstrap/3.3.6/js/bootstrap.min.js"></script>

    <script src="assets/js/bootstrap-table.min.js"></script>

  <script type="text/javascript" src="export/js/bootstrap-table-filter-control.js"></script>
  <script type="text/javascript" src="export/js/tableExport.js"></script>

  <script type="text/javascript" src="https://cdnjs.cloudflare.com/ajax/libs/bootstrap-table/1.10.1/extensions/export/bootstrap-table-export.js"></script>
  <script type="text/javascript" src="https://cdnjs.cloudflare.com/ajax/libs/bootstrap-table/1.10.1/extensions/toolbar/bootstrap-table-toolbar.js"></script>
  
  <link rel="stylesheet" type="text/css" href="https://cdnjs.cloudflare.com/ajax/libs/twitter-bootstrap/3.3.6/css/bootstrap.min.css" />
  <link rel="stylesheet" type="text/css" href="https://cdnjs.cloudflare.com/ajax/libs/bootstrap-table/1.10.1/bootstrap-table.min.css" />

    <script src="JS/jquery-3.3.1.js"></script> 



    <style>
        .w70 {width: 70px !important;}
    </style>


  <script type="text/javaScript">


      /* Custom filtering function which will search data in column four between two values */
      $.fn.dataTable.ext.search.push(
          function (settings, data, dataIndex) {
              var min = parseInt($('#min').val(), 10);
              var max = parseInt($('#max').val(), 10);
              var age = parseFloat(data[6]) || 0; // use data for the balance column

              if ((isNaN(min) && isNaN(max)) ||
                   (isNaN(min) && age <= max) ||
                   (min <= age && isNaN(max)) ||
                   (min <= age && age <= max)) {
                  return true;
              }
              return false;
          }
      );

       
      //$(document).ready(function () {
      //    var table = $('#table').DataTable();

      //    //alert('Hello');
      //    // Event listener to the two range filtering inputs to redraw on input
      //    $('#min, #max').keyup(function () {
      //        table.draw();
      //    });
      //});




      $(document).ready(function () {

          

          $('#min, #max').on("keyup", function () {
              // could bind bind GridView here??

              var table = $('#table').DataTable();

              $.fn.dataTable.ext.search.push(
              function (settings, data, dataIndex) {
                  var min = parseInt($('#min').val(), 10);
                  var max = parseInt($('#max').val(), 10);
                  var age = parseFloat(data[6]) || 0; // use data for the balance column

                  if ((isNaN(min) && isNaN(max)) ||
                       (isNaN(min) && age <= max) ||
                       (min <= age && isNaN(max)) ||
                       (min <= age && age <= max)) {

                      return true;
                  }
                  return false;
              }

              //alert('Hello');
              );
          })
          
      });


      function detailFormatter(index, row) {
          var html = [];
          $.each(row, function (key, value) {
              html.push('<p><b>' + key + ':</b> ' + value + '</p>');
          });
          return html.join('');
      }

      function DoOnCellHtmlData(cell, row, col, data) {
          var result = "";
          if (typeof data != 'undefined' && data != "") {
              var html = $.parseHTML(data);

              $.each(html, function () {
                  if (typeof $(this).html() === 'undefined')
                      result += $(this).text();
                  else if (typeof $(this).attr('class') === 'undefined' || $(this).hasClass('th-inner') === true)
                      result += $(this).html();
              });
          }
          return result;
      }

      $(function () {
          $('#toolbar').find('select').change(function () {
              $('#table').bootstrapTable('refreshOptions', {
                  exportDataType: $(this).val()
              });
          });
      })

      $(document).ready(function () {
          $('#table').bootstrapTable('refreshOptions', {
              exportOptions: {
                  ignoreColumn: [0, 1], // or as string array: ['0','checkbox']
                  onCellHtmlData: DoOnCellHtmlData
              }
          });
      });







      //function queryParams() {
      //    var params = {};
      //    $('#toolbar').find('input[name]').each(function () {
      //        params[$(this).attr('name')] = $(this).val();
      //    });
      //    return params;
      //}

      function responseHandler(res) {
          return res.rows;
      }

  </script>




</asp:Content>

<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">


<%--    <script type="text/javascript">
        function onRequestStart(sender, args) {
            if (args.get_eventTarget().indexOf("ExportToExcelButton") >= 0 ||
                    args.get_eventTarget().indexOf("ExportToWordButton") >= 0 ||
                    args.get_eventTarget().indexOf("ExportToCsvButton") >= 0) {
                args.set_enableAjax(false);
            }
        }
    </script>--%>


    <table id="table1" cellpadding="0" class="auto-style2" width="50%">
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
                            <img alt="" class="auto-style64" src="images/Items.png" /></td>
                        <td class="auto-style55" style="background-color: #F7F7F7"><strong>Store Inventory</strong></td>
                        <td class="auto-style57" style="background-color: #F7F7F7"></td>
                        <td class="auto-style58" style="background-color: #F7F7F7"></td>
                        <td class="auto-style59" style="background-color: #F7F7F7"></td>
                    </tr>
                    <tr>
                        <td class="auto-style6"></td>
                        <td class="auto-style13"></td>
                        <td class="auto-style21">&nbsp;</td>
                        <td class="auto-style28">&nbsp;</td>
                        <td class="auto-style7">&nbsp;</td>
                    </tr>
                    <tr>

                        <asp:ScriptManager ID="ScriptManager1" runat="server"></asp:ScriptManager>
                        <asp:UpdatePanel ID="UpdatePanel1" runat="server">
                            <ContentTemplate>


                                <td class="auto-style62" colspan="5">
                                    <%-- <telerik:RadAjaxPanel ID="RadAjaxPanel2" runat="server" Width="300px" HorizontalAlign="NotSet" LoadingPanelID="RadAjaxLoadingPanel2" RenderMode="Inline">--%>
                                    <table class="auto-style66">
                                        <tr>
                                            <td class="auto-style67">Branch</td>
                                            <td class="auto-style67">
                                                <telerik:RadComboBox ID="cmbbranch" runat="server" AutoPostBack="True" MarkFirstMatch="True" Sort="Ascending" Width="300px" OnSelectedIndexChanged="cmbbranch_SelectedIndexChanged">
                                                </telerik:RadComboBox>
                                            </td>
                                            <td class="auto-style67"></td>
                                            <td class="auto-style67">Store</td>
                                            <td class="auto-style67">
                                                <telerik:RadComboBox ID="cmbStores" runat="server" AutoPostBack="True" MarkFirstMatch="True" Sort="Ascending" Width="300px" OnSelectedIndexChanged="cmbStores_SelectedIndexChanged">
                                                </telerik:RadComboBox>
                                            </td>
                                        </tr>
                                        <tr>
                                            <td>&nbsp;</td>
                                            <td>&nbsp;</td>
                                            <td>&nbsp;</td>
                                            <td>&nbsp;</td>
                                            <td>&nbsp;</td>
                                        </tr>
                                    </table>

                                </td>
                            </ContentTemplate>
                        </asp:UpdatePanel>
                    </tr>

                    <tr>
                        <td colspan="5">

                            <div id="FilterDiv" style="background-color:beige;">

                                <table class="display" id="FilterTable">

                                    <thead>
                                        <tr>
                                            <h4>Data Filter</h4>
                                        </tr>
                                    </thead>
                                    <tbody>
                                        <tr>
                                            <td style="width: 500px">
                                                Min.Bal:
                                                <input type="text" id="min" name="min" style="width: 25%;"   onkeyup="SearchBal();"/>
                                                Max.Bal:
                                                <input type="text" id="max" name="max" style="width: 25%;"  onkeyup="SearchBal();"/>
                                            </td>
                                        </tr>
                                    </tbody>

                                </table>
                            </div>

                        
                            <div class="container">
                                <h1 align="center">Store/Department Inventory</h1>
                                <br>

                                <div id="toolbar">

                                    <select class="form-control">
                                        <option value="">Export Basic</option>
                                        <option value="all">Export All</option>
                                        <option value="selected">Export Selected</option>
                                    </select>
                                     
                               <%--          <div class="form-inline" role="form">

                                   <div class="form-group">
                                            <span>Offset: </span>
                                            <input name="offset" class="form-control w70" type="number" value="0">
                                        </div>
                                        <div class="form-group">
                                            <span>Limit: </span>
                                            <input name="limit" class="form-control w70" type="number" value="100">
                                        </div>
                                        <div class="form-group">
                                            <input name="search" class="form-control" type="text" placeholder="Search">
                                        </div>
        
                                        <button id="ok" type="submit" class="btn btn-default">OK</button>
                                    </div>--%>
                                </div>

                                <table id="table" class="table" 
                                    data-toggle="table"
                                    data-height="500"      
                                    data-show-refresh="true"
                                    data-show-toggle="true"
                                    data-show-columns="true"
                                    data-show-export="true"
                                    data-click-to-select="true"
                                    data-toolbar="#toolbar"
                                    data-pagination="true"
                                    data-search="true"
                                    data-detail-view="false"
                                    data-detail-formatter="detailFormatter"
                                    data-query-params="queryParams"
                                    data-response-handler="responseHandler"
                                    data-filter-control="true"
                                    data-lengthMenu="[[10, 25, 50, -1], [10, 25, 50, "All"]]"
                                    data-url="../json/data1.json">
                                    <thead>

                                        <tr>
                                          
                                            <th style="width:10%" data-field="checkbox"    data-checkbox="true"  > </th>
                                            <th style="width:20%" data-field="InventoryCode" data-sortable="true" data-filter-control="input"  data-visible="true">Inventory Code</th>
                                            <th style="width:120%" data-field="ItemTitle" data-sortable="true" data-filter-control="input"  data-visible="true">Item Title</th>
                                            <th data-field="OPBalance"  data-sortable="true" data-filter-control="input" data-visible="true">Opening Balance</th>
                                            <th data-field="qttyreceived"  data-sortable="true" data-filter-control="input" data-visible="true">Qty. Received</th>
                                            <th data-field="qttyissued" data-sortable="true" data-filter-control="input" data-visible="true">Qty. Issued</th>
                                            <th data-field="CurrentBalance"  data-sortable="true" data-filter-control="select" data-visible="true">Current Balance</th>
                                        </tr>
                                    </thead>
                                    <tbody>

                                        <asp:PlaceHolder ID="PlaceHolder1" runat="server"></asp:PlaceHolder>

                                    </tbody>
                                    <tfoot>

                                    </tfoot>
                                </table>
                            </div>
                   




        <%--                    <div class="table-responsive">
                                <p>
                                    <button id="btn-export">Export</button>
                                </p>

                                <table class="display" id="dataTables-dbstudents">

                                    <thead>
                                        <tr>
                                            <th align="center">Inventory Code</th>
                                            <th align="center">Item Title</th>
                                            <th align="center">Opening Balance</th>
                                            <th align="center">Qty. Received</th>
                                            <th align="center">Qty. Issued</th>
                                            <th align="center">Current Balance</th>
                                        </tr>
                                    </thead>
                                    <tbody>

                                        <asp:PlaceHolder ID="PlaceHolder1" runat="server"></asp:PlaceHolder>

                                    </tbody>

                                </table>

                            </div>--%>

                        </td>
                    </tr>

                </table>
            </td>
        </tr>
    </table>


   <%-- <script src="https://code.jquery.com/jquery-3.5.1.js"> </script>
    <script src="https://cdn.datatables.net/1.10.24/js/jquery.dataTables.min.js"> </script>

      <script type="text/javascript">
 
          $(document).ready(function () {
             $('#table').DataTable({
                 "lengthMenu": [[10, 25, 50, -1], [10, 25, 50, "All"]]
             });
         }); 
    
     </script>--%>


</asp:Content>
