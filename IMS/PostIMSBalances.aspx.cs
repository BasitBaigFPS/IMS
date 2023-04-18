using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Web.UI.HtmlControls;
using System.Configuration;
using System.Globalization;
using System.Data;
using System.Text;
using System.Data.SqlClient;
using System.Data.OleDb;
using System.Web.Services;
using Telerik.Web.UI;
using BLL;
using DAL;
 

namespace IMS
{
    public partial class PostIMSBalances : System.Web.UI.Page
    {
        StoreManager STMan = new StoreManager();



        protected void showMessageBox(string message)
        {
            string sScript;
            message = message.Replace("'", "\'");
            sScript = String.Format("alert('{0}');", message);
            ScriptManager.RegisterStartupScript(this, this.GetType(), "alert", sScript, true);
        }


        protected void Page_Load(object sender, EventArgs e)
        {
            if (Page.IsPostBack == false)
            {

                SetupForm();
            }
        }

        private void SetupForm()
        {

            HttpCookie IMS = Request.Cookies["IMS"];
            if (IMS == null)
                Response.Redirect("logout.aspx");

            //iman.Uid = int.Parse(IMS["uid"]);

            //STMan.fkbrhID = int.Parse(IMS["ubrhid"]);
            //STMan.fkdeptID = int.Parse(IMS["udptid"] == null ? "0" : IMS["udptid"]);
            //STMan.pkstoreID = 0;

            PopulateBranch();
            PopulateDepartment();

        }

        private void PopulateBranch()
        {
            SqlConnection conn = new SqlConnection();
            SqlCommand cmd = new SqlCommand();

            conn.ConnectionString = SqlHelper.connectionstring;
            cmd.Connection = conn;

            DataSet ds;

            ds = SqlHelper.ExecuteDataset(conn, CommandType.Text, "SELECT pkbrhid,brhname as BranchName FROM tblBranches where brhisactive=1 order by brhname");

            DataTable dt = ds.Tables[0];

            ddlbranch.CausesValidation = false;
            ddlbranch.DataSource = dt;
            ddlbranch.DataTextField = "BranchName";
            ddlbranch.DataValueField = "pkbrhid";
            ddlbranch.DataBind();
            ddlbranch.Items.Insert(0, new ListItem("==Please Select==", "0"));

            conn.Close();

            PopulateDepartment();
        }

        private void PopulateDepartment()
        {
            SqlConnection conn = new SqlConnection();
            SqlCommand cmd = new SqlCommand();

            conn.ConnectionString = SqlHelper.connectionstring;
            cmd.Connection = conn;

            DataSet ds;

            ds = SqlHelper.ExecuteDataset(conn, CommandType.Text, "SELECT pkdeptID,deptName FROM tblDepartments WHERE deptIsActive=1 order by deptName");

            DataTable dt = ds.Tables[0];


            ddlDepartment.CausesValidation = false;
            ddlDepartment.DataSource = dt;
            ddlDepartment.DataTextField = "deptName";
            ddlDepartment.DataValueField = "pkdeptID";
            ddlDepartment.DataBind();
            ddlDepartment.Items.Insert(0, new ListItem("==Please Select==", "0"));

            conn.Close();

        }



        protected void ddlbranch_SelectedIndexChanged(object sender, EventArgs e)
        {
            STMan.fkbrhID = int.Parse(ddlbranch.SelectedValue.ToString());
        }

        protected void ddlDepartment_SelectedIndexChanged(object sender, EventArgs e)
        {
            STMan.fkdeptID = int.Parse(ddlDepartment.SelectedValue.ToString());
        }

     
        protected void btnPost_Click(object sender, EventArgs e)
        {
            btnPost.Attributes.Add("onclick", "return Confirm();");

           // SetupForm();

            STMan.fkbrhID = int.Parse(ddlbranch.SelectedValue.ToString());

            STMan.fkdeptID = int.Parse(ddlDepartment.SelectedValue.ToString());

            if (STMan.fkdeptID == 10)
            { STMan.Token = "IT"; }
            else
            { STMan.Token = "SB"; }


            DataTable dt = STMan.GetStores();

            if (dt.Rows.Count > 0)
            {
                foreach (DataRow row in dt.Rows)
                {
                    STMan.pkstoreID = int.Parse(row[0].ToString());

                    if (STMan.pkstoreID == 1 && STMan.fkdeptID==8)
                    {
                        STMan.pkstoreID = 2;
                        STMan.fkdeptID = 14; 
                    }

                    if (STMan.pkstoreID == 22)
                    { STMan.fkdeptID = 10; }


                    //else
                    //{
                    //    STMan.fkdeptID = 2;
                    //    STMan.UpdateInvBalance(STMan.fkbrhID, STMan.pkstoreID, STMan.fkdeptID);
                    //    STMan.fkdeptID = 14;
                    //}

                    try
                    {
                        STMan.UpdateInvBalance(STMan.fkbrhID, STMan.pkstoreID, STMan.fkdeptID);
                    }
                    catch (Exception er)
                    {
                        showMessageBox("An error occurred: '{0}'" + er);
                    }
                    finally
                    {
                        showMessageBox("Store Inventory Balances Have Been Successfully Updated......");
                    }
                   
                }
            }
          //  Response.Redirect("Main.aspx");
        }




    }
 
}