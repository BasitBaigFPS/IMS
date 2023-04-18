using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace IMS
{
    public partial class Logout : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            if (Request.Cookies["user"] != null)
                Request.Cookies["user"].Expires = DateTime.Now.AddDays(-1);

            string scriptstring = "window.close();";
            ScriptManager.RegisterStartupScript(this, this.GetType(), "alertscript", scriptstring, true);

            Response.Redirect("http://www.google.com");


            //if (Request.Cookies["user"] != null)
            //{
            //    HttpCookie coki = Request.Cookies["user"];
            //    coki.Expires = DateTime.Now.AddDays(-1);
            //    Response.Cookies.Add(coki);

            //    string scriptstring = "window.location = 'default.aspx';";
            //    ScriptManager.RegisterStartupScript(this, this.GetType(), "alertscript", scriptstring, true);
            //}
            //else
            //{
            //    string scriptstring = "window.location = 'default.aspx';";
            //    ScriptManager.RegisterStartupScript(this, this.GetType(), "alertscript", scriptstring, true);
            //}


            //if (Request.Cookies["IMS"] != null)
            //{
            //    HttpCookie myCookie = new HttpCookie("IMS");
            //    myCookie.Expires = DateTime.Now.AddDays(-1);
            //    Response.Cookies.Add(myCookie);
            //}
           
           

        }
    }
}