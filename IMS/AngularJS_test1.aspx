<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="AngularJS_test1.aspx.cs" Inherits="IMS.AngularJS_test1" %>

<!DOCTYPE html PUBLIC "-//W3C//DTD XHTML 1.0 Transitional//EN" "http://www.w3.org/TR/xhtml1/DTD/xhtml1-transitional.dtd">
<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <title></title>
    <style>
        table, th, td
        {
            border: 1px solid grey;
            border-collapse: collapse;
            padding: 5px;
        }
        table th
        {
            background-color: #274257;
            color: #fff;
        }
        table tr:nth-child(odd)
        {
            background-color: #f1f1f1;
        }
        table tr:nth-child(even)
        {
            background-color: #ffffff;
        }
    </style>

    <script src="http://ajax.googleapis.com/ajax/libs/angularjs/1.3.14/angular.min.js"></script>

    <style>
    .center {
      margin: auto;
      width: 20%;
      border: 3px solid #73AD21;
      padding: 10px;
    }
    </style>
</head>
<body>
    <form id="form1" runat="server">
    <div ng-app="myApp" ng-controller="myCntrl" class="center">
        <table>
            <tr>
                <td>
                    Student Name :
                </td>
                <td>
                    <input type="text" id="txtStudentName" ng-model="studentName" />
                </td>
            </tr>
            <tr>
                <td colspan="2" align="center">
                    <input type="button" value="Save" ng-click="Save()" />
                </td>
            </tr>
        </table>
        <br />
        <br />
        <table>
            <thead>
                <tr>
                    <th>
                        StudentID
                    </th>
                    <th>
                        StudentName
                    </th>
                    <th>
                    </th>
                    <th>
                    </th>
                </tr>
            </thead>
            <tr ng-repeat="student in StudentList | orderBy : studentorder ">
                <td ng-bind="student.StudentID">
                </td>
                <td ng-bind="student.StudentName">
                  
                </td>

                <td>
                    <%--<a class="edit" href="#" ng-click="Update(student.StudentID)">Update</a>--%>

                    <a class="edit" href="#" editable-text="student.StudentName">Update</a>
                    
                </td>
                <td>
                    <a href="#" ng-click="Delete(student.StudentID)">Delete</a>
                </td>
            </tr>
        </table>
    </div>

 
    <script>

        var app = angular.module("myApp", ["xeditable"]);

        app.controller("myCntrl", function ($scope, $http) {

            $scope.studentorder = "StudentID";
            $scope.studentName = "";

            $scope.Save = function () {
                var httpreq = {
                    method: 'POST',
                    url: 'AngularJS_test1.aspx/Save',
                    headers: {
                        'Content-Type': 'application/json; charset=utf-8',
                        'dataType': 'json'
                    },
                    data: { StudentName: $scope.studentName }
                }
                $http(httpreq).success(function (response) {
                    $scope.fillList();
                    alert("Saved successfully.");
                })
            };

           

            $scope.Update = function (SID) {

                $scope.studentName = { StudentName: $scope.studentName };

                var httpreq = {
                    method: 'POST',
                    url: 'AngularJS_test1.aspx/Update',
                    headers: {
                        'Content-Type': 'application/json; charset=utf-8',
                        'dataType': 'json'
                    },
                    data: {
                         StudentID: SID,
                         StudentName: $scope.studentName
                    }
                }
                $http(httpreq).success(function (response) {
                    $scope.fillList();
                    alert("Updated successfully.");
                })


            };

            $scope.Delete = function (SID) {
                if (confirm("Are you sure want to delete?")) {
                    var httpreq = {
                        method: 'POST',
                        url: 'AngularJS_test1.aspx/Delete',
                        headers: {
                            'Content-Type': 'application/json; charset=utf-8',
                            'dataType': 'json'
                        },
                        data: { StudentID: SID }
                    }
                    $http(httpreq).success(function (response) {
                        $scope.fillList();
                        alert("Deleted successfully.");
                    })
                }
            };
            $scope.fillList = function () {
                $scope.studentName = "";
                var httpreq = {
                    method: 'POST',
                    url: 'AngularJS_test1.aspx/GetList',
                    headers: {
                        'Content-Type': 'application/json; charset=utf-8',
                        'dataType': 'json'
                    },
                    data: {}
                }
                $http(httpreq).success(function (response) {
                    $scope.StudentList = response.d;
                })
            };
            $scope.fillList();
        });
    </script>


    </form>
</body>
</html>