using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Data;
using System.Data.SqlClient;
using System.IO;
using System.Globalization;

namespace IMS
{
    public partial class Bootstrap_CRUD : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {

        }



        private void insertEmployee(SqlParameter[] param) {

            string data= "";

            //$sql = "INSERT INTO `employee` (employee_name, employee_salary, employee_age) VALUES('" . $params["name"] . "', '" . $params["salary"] . "','" . $params["age"] . "');  ";
		
            //echo $result = mysqli_query($this->conn, $sql) or die("error to insert employee data");
		
        }



    }
}