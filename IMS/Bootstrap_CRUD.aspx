<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="Bootstrap_CRUD.aspx.cs" Inherits="IMS.Bootstrap_CRUD" %>

<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <title></title>
    <link href="CSS/bootstrap.min.css" rel="stylesheet" />
    <link href="CSS/jquery.bootgrid.css" rel="stylesheet" />

    <script src="js2/jquery-2.1.1.min.js"></script>
    <script src="JS/bootstrap.min.js"></script>
    <script src="JS/jquery.bootgrid.min.js"></script>
    

</head>
<body>
     


        <div class="col-lg-12">
		<div class="well clearfix">
			<div class="pull-right"><button type="button" class="btn btn-xs btn-primary" id="command-add" data-row-id="0">
			<span class="glyphicon glyphicon-plus"></span> Record</button></div></div>
		    <table id="employee_grid" class="table table-condensed table-hover table-striped" width="60%" cellspacing="0" data-toggle="bootgrid">
			<thead>
				<tr>
					<th data-column-id="id" data-type="numeric" data-identifier="true">Empid</th>
					<th data-column-id="employee_name">Name</th>
					<th data-column-id="employee_salary">Salary</th>
					<th data-column-id="employee_age">Age</th>
					<th data-column-id="commands" data-formatter="commands" data-sortable="false">Commands</th>
				</tr>
			</thead>
		</table>
    </div>

        <div id="add_model" class="modal fade">
            <div class="modal-dialog">
                <div class="modal-content">
                    <div class="modal-header">
                        <button type="button" class="close" data-dismiss="modal" aria-hidden="true">&times;</button>
                        <h4 class="modal-title">Add Employee</h4>
                    </div>
                    <div class="modal-body">
                        <form method="post" id="frm_add">
                            <input type="hidden" value="add" name="action" id="action">
                            <div class="form-group">
                                <label for="name" class="control-label">Name:</label>
                                <input type="text" class="form-control" id="name" name="name" />
                            </div>
                            <div class="form-group">
                                <label for="salary" class="control-label">Salary:</label>
                                <input type="text" class="form-control" id="salary" name="salary" />
                            </div>
                            <div class="form-group">
                                <label for="salary" class="control-label">Age:</label>
                                <input type="text" class="form-control" id="age" name="age" />
                            </div>
                        </form>
                    </div>
                    <div class="modal-footer">
                        <button type="button" class="btn btn-default" data-dismiss="modal">Close</button>
                        <button type="button" id="btn_add" class="btn btn-primary">Save</button>
                    </div>
            
                </div>
            </div>
        </div>


    <div id="edit_model" class="modal fade">
        <div class="modal-dialog">
            <div class="modal-content">
                <div class="modal-header">
                    <button type="button" class="close" data-dismiss="modal" aria-hidden="true">&times;</button>
                    <h4 class="modal-title">Edit Employee</h4>
                </div>
                <div class="modal-body">
                    <form method="post" id="frm_edit">
                        <input type="hidden" value="edit" name="action" id="action">

                        <input type="hidden" value="0" name="edit_id" id="edit_id">

                        <div class="form-group">
                            <label for="name" class="control-label">Name:</label>
                            <input type="text" class="form-control" id="edit_name" name="edit_name" />
                        </div>

                        <div class="form-group">
                            <label for="salary" class="control-label">Salary:</label>
                            <input type="text" class="form-control" id="edit_salary" name="edit_salary" />
                        </div>
                        <div class="form-group">
                            <label for="salary" class="control-label">Age:</label>
                            <input type="text" class="form-control" id="edit_age" name="edit_age" />
                        </div>
                    </form>
                </div>
                <div class="modal-footer">
                    <button type="button" class="btn btn-default" data-dismiss="modal">Close</button>
                    <button type="button" id="btn_edit" class="btn btn-primary">Save</button>
                </div>
              
            </div>
        </div>
    </div>

    

    <script type="text/javascript">

        var grid = $("#employee_grid").bootgrid({
            ajax: true,
            rowSelect: true,
            post: function () {
                /* To accumulate custom parameter with the request object */
                return {
                    id: "b0df282a-0d67-40e5-8558-c9e93b7befed"
                };
            },

            url: "Bootstrap_CRUD.aspx",
            formatters: {
                "commands": function (column, row) {
                    return "<button type=\"button\" class=\"btn btn-xs btn-default command-edit\" data-row-id=\"" + row.id + "\"><span class=\"glyphicon glyphicon-edit\"></span></button> " +
                        "<button type=\"button\" class=\"btn btn-xs btn-default command-delete\" data-row-id=\"" + row.id + "\"><span class=\"glyphicon glyphicon-trash\"></span></button>";
                }
            }
        })

        $("#command-add").click(function () {
            $('#add_model').modal('show');
        });


        $("#btn_add").click(function () {
            ajaxAction('add');
        });

        function ajaxAction(action) {
            data = $("#frm_" + action).serializeArray();
            $.ajax({
                type: "POST",
                url: "Bootstrap_CRUD.aspx",
                data: data,
                dataType: "json",
                success: function (response) {
                    $('#' + action + '_model').modal('hide');
                    $("#employee_grid").bootgrid('reload');
                }
            });
        }



    </script>

</body>
</html>
