using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Configuration;
using System.Data.SqlClient;
using Telerik.Web.UI;
using System.Data;
using System.Net;
using System.Net.Mail;
using System.Net.Mime;
using System.Text;
using System.Data.SqlClient;
using BLL;

namespace IMS
{
    public partial class StaffSearch : System.Web.UI.Page
    {
        ItemManager im = new ItemManager();
        UserManager UMan = new UserManager();
        IMSManager iman = new IMSManager();
        StoreManager sm = new StoreManager();

       // DataTable DT;
        #region Events

        protected void Page_Load(object sender, EventArgs e)
        {

            //Page.Header.DataBind();  

            if (Page.IsPostBack == false)
            {

                CheckUser();

                GetInventory();
            
            }
           
        }

 
        #endregion




        #region Helper Methods


        public void CheckUser()
        {
            HttpCookie IMS = Request.Cookies["IMS"];
            if (IMS == null)
                Response.Redirect("logout.aspx");
            iman.Uid = int.Parse(IMS["uid"]);
            sm.fkbrhID = int.Parse(IMS["ubrhid"]);

            iman.Pkdeptid = int.Parse(IMS["udptid"] == null ? "0" : IMS["udptid"]);

 
        }

 
        public void GetInventory()
        {
            DataTable dt = new DataTable();


            dt = iman.GetStaffItems(iman.Pkdeptid);
 
 
            StringBuilder html = new StringBuilder();
 
            foreach (DataRow row in dt.Rows)
            {

                html.Append("<tr>");
                foreach (DataColumn column in dt.Columns)
                {
 
                    string colname = column.ColumnName.ToString();

                    if (colname == "Branch" || colname == "Employee" || colname == "Item")
                    {
                        html.Append("<td style='" + "text-align:left;font-family:" + "Courier New" + ", Courier; font-size:14px;width:25%;" + "'>");
                        html.Append(row[column.ColumnName]);
                        html.Append("</td>");
                    }
                    else
                    {
                        html.Append("<td style='" + "text-align:center;font-family:" + "Courier New" + ", Courier; font-size:14px;width:10%;" + "'>");
                        html.Append(row[column.ColumnName]);
                        html.Append("</td>");
                    }


                }
                html.Append("</tr>");
            }


 
                PlaceHolder1.Controls.Clear();
                PlaceHolder1.Controls.Add(new Literal { Text = html.ToString() });
 
        }
 


        #endregion

 
    }
}