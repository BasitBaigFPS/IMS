using System;
using System.Collections;
using System.Configuration;
using System.Data;
using System.Linq;
using System.Web;
using System.Web.Security;
using System.Web.UI;
using System.Web.UI.HtmlControls;
using System.Web.UI.WebControls;
using System.Web.UI.WebControls.WebParts;
using System.Xml.Linq;
using System.Data.SqlClient;
using System.Collections.Generic;
using System.Drawing;
using System.IO;
using BLL;

namespace IMS
{
    public partial class SyllabusRequisitionBranch : System.Web.UI.Page
    {
        RequisitionManager Reqman = new RequisitionManager();
        UserManager UMan = new UserManager();
        string strConnString = ConfigurationManager.ConnectionStrings["INVENTORY"].ConnectionString;
        string str;
        SqlCommand com;
        SqlDataAdapter sqlda;
        DataSet ds;
        

        protected void Page_Load(object sender, EventArgs e)
        {
            if (!IsPostBack)
            {
                SetupForm();
            }
        }

        public int GetSysinfo()
        {
            HttpCookie IMS = Request.Cookies["IMS"];
            if (IMS == null)
                Response.Redirect("logout.aspx");


            int sysid = UMan.GetSysinfo(int.Parse(IMS["ubrhid"]));

            return sysid;

        }


        private void SetupForm()
        {
            HttpCookie IMS = Request.Cookies["IMS"];

            DataTable dt = new DataTable();
            ViewState["dt"] = dt;


            //mirdiv.Style.Add("display", "none");
            mirdiv.Style.Add("display", "inline");

            bindGrid(GetSysinfo(), int.Parse(IMS["ubrhid"].ToString()));          

        }

        protected void showMessageBox(string message)
        {
            string sScript;
            message = message.Replace("'", "\'");
            sScript = String.Format("alert('{0}');", message);
            ScriptManager.RegisterStartupScript(this, this.GetType(), "alert", sScript, true);
        }

        public void GetUserInfo()
        {

            HttpCookie IMS = Request.Cookies["IMS"];
            if (IMS == null)
                Response.Redirect("logout.aspx");


            UMan.Uid = int.Parse(IMS["uid"]);
            UMan.Ugid = int.Parse(IMS["ugroupid"]); 

            Reqman.Uid = int.Parse(IMS["uid"]); 
            Reqman.Pkbrhid = int.Parse(IMS["ubrhid"]);
            Reqman.Pkdeptid = int.Parse(IMS["udptid"]);
                    

        }

        public void bindGrid(int sysid, int fkbrhid)
        {
            //DataTable dt = CheckBudget();
            int comid = 1;
            int cityid = 1;

            if (sysid==2)
            {
              comid=1;
              cityid=2;
            }
            if (sysid == 3)
            {
                comid = 2;
                cityid = 1;
            }

            //string confirmValue = Request.Form["confirm_value"];
            //if (confirmValue == "Yes")
            //{
            //    Reqman.ProduceNewYearStrength(comid, cityid);
            //}

            SqlConnection con = new SqlConnection(strConnString);
            con.Open();

            str = "SELECT fkacdid,fkbrhid,GRADE,0 as [ReqTotal] FROM [INVENTORY].[dbo].[tblBGStrength] where fkbrhid=" + fkbrhid.ToString() + " and fkacdid in (select max(fkacdid) FROM [INVENTORY].[dbo].[tblBGStrength] where fkbrhid=" + fkbrhid.ToString() + ") Order by Grade";
           
            com = new SqlCommand(str, con);
            sqlda = new SqlDataAdapter(com);
            ds = new DataSet();
            sqlda.Fill(ds);

            DataTable dt = new DataTable();
            dt = ds.Tables[0];

            ViewState["dt"] = dt;
            grdGrade.DataSource = dt;
            grdGrade.DataBind();


            if (dt.Rows.Count == 0)
            {
                showMessageBox("Distribution Process of This System is Now Finalized, You Can See Data Through Reports Only!!!!");

                btnProcessReq.Visible = true;
            }
            else
            {
                grdGrade.Visible = true;      
                btnProcessReq.Visible = true;
            }

            //con.Close();
        }

        protected void grdGrade_RowCommand(object sender, GridViewCommandEventArgs e)
        {

            if (e.CommandName == "Delete")
            {
                int index = Convert.ToInt32(e.CommandArgument);
                DataTable dt = (DataTable)ViewState["dt"];

                dt.Rows[index].Delete();
                ViewState["dt"] = dt;
                grdGrade.DataSource = dt;
                grdGrade.DataBind();
            }
        }

        protected void grdGrade_RowEditing(object sender, GridViewEditEventArgs e)
        {



        }

        protected void grdGrade_RowUpdating(object sender, GridViewUpdateEventArgs e)
        {



        }

        protected void grdGrade_RowDataBound(object sender, GridViewRowEventArgs e)
        {
            if (e.Row.RowType == DataControlRowType.DataRow)
            {
                TextBox txtstr = (TextBox)e.Row.FindControl("txtstrength");
                
                txtstr.Enabled = true;
            }
        }

        private DataTable SetDataTable()
        {
            GridView GridView1 = (GridView)grdGrade;

            DataSet ds = new DataSet();
            DataTable dt = (DataTable)ViewState["dt"];

            foreach (GridViewRow GR in GridView1.Rows)
            {

                if (GR.RowType == DataControlRowType.DataRow)
                {
                    int rowid = GR.RowIndex;

                    //TextBox txtacdid = (TextBox)GR.FindControl("fkacdid");
                    //TextBox txtbrhid = (TextBox)GR.FindControl("fkbrhid");
                    TextBox txtgrade = (TextBox)GR.FindControl("Grade");
                    TextBox txttotal = (TextBox)GR.FindControl("txtstrength");

                    int total = 0;
                    if (txttotal != null)
                    {
                        string grade = txtgrade.Text;
                        string val = txttotal.Text;

                        total = int.Parse(val.ToString() == "" ? "0" : val.ToString());

                        DataRow[] ItemRow = dt.Select("Grade = '" + grade + "'");

                        ItemRow[0]["ReqTotal"] = val == "" ? "0" : val;

                    }
                }

            }

            return dt;

        }

        protected void btnClose_Click(object sender, EventArgs e)
        {
            object typ = this.GetType();
            Response.Redirect("Main.aspx");
        }

        protected void btnProcessReq_Click(object sender, EventArgs e)
        {

            DataTable dt = SetDataTable();

            GetUserInfo();

            int LASTMIR = 0;

            LASTMIR = Reqman.IUSyllabusReq(dt, Reqman.Uid);

            txtmirno.Text = LASTMIR.ToString();
            
            showMessageBox("Additional Syllabus Requisition and MIR Generated Successfully, MIR Number = "+LASTMIR.ToString()); 

        }


    }
}