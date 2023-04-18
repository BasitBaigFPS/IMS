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
    public partial class RequisitionBudget : System.Web.UI.Page
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

            GetUserInfo();
        }

        private void SetupForm()
        {

            DataTable dt = new DataTable();
            ViewState["dt"] = dt;


            mirdiv.Style.Add("display", "none");
            bindReqType();



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

            UMan.Grpuserbrhid = int.Parse(IMS["grpuserbrhid"]);
            UMan.Grpuserdeptid = int.Parse(IMS["grpuserdptid"]);
            UMan.Grpuserstoreid = int.Parse(IMS["grpuserstoreid"]);
                    

        }

        public void bindReqType()
        {
            GetUserInfo();

            SqlConnection con = new SqlConnection(strConnString);
            con.Open();
            str = "select pkReqTypID,RequisitionType from tblReqType where pkReqTypID!=1 and IsActive=1";
            if (UMan.Ugid == 37)
            {
                str = "select pkReqTypID,RequisitionType from tblReqType where pkReqTypID=8 and IsActive=1";
            }

            com = new SqlCommand(str, con);
            sqlda = new SqlDataAdapter(com);
            ds = new DataSet();
            sqlda.Fill(ds, "tblReqType");
            ddlReqType.Items.Clear();
            ddlReqType.Items.Add("--Select--");
            ddlReqType.DataValueField = "pkReqTypID";
            ddlReqType.DataTextField = "RequisitionType";
            ddlReqType.DataSource = ds;
            ddlReqType.DataMember = "tblReqType";
            ddlReqType.DataBind();
            con.Close();
        }

        public void bindReqSubType(int ReqTypID)
        {
            SqlConnection con = new SqlConnection(strConnString);
            con.Open();
            str = "select pkReqSubTypID,RequisitionSubType from tblReqSubType where IsActive=1 and fkReqTypID=" + ReqTypID.ToString();
            com = new SqlCommand(str, con);
            sqlda = new SqlDataAdapter(com);
            ds = new DataSet();
            sqlda.Fill(ds, "tblReqSubType");
            ddlReqSubType.Items.Clear();
            ddlReqSubType.Items.Add("--Select--");
            ddlReqSubType.DataValueField = "pkReqSubTypID";
            ddlReqSubType.DataTextField = "RequisitionSubType";
            ddlReqSubType.DataSource = ds;
            ddlReqSubType.DataMember = "tblReqSubType";
            ddlReqSubType.DataBind();
            con.Close();

            if (UMan.Ugid == 37)
            {
                syschoice1.Style.Add("display", "none");
                btnSaveBudget.Visible = false;
            }
        }

        public void bindReqQuarter()
        {
            SqlConnection con = new SqlConnection(strConnString);
            con.Open();

            str = "select pkQuatID,QuarterDescription from tblQuarter_View where IsActive=1";

            if (UMan.Ugid == 37)
            {
                str = "select top 1 1 as pkQuatID,'Annual I.T Requisition' as QuarterDescription from tblQuarter_View";
            }
            com = new SqlCommand(str, con);
            sqlda = new SqlDataAdapter(com);
            ds = new DataSet();
            sqlda.Fill(ds, "tblQuarter_View");
            ddlQuarter.Items.Clear();
            ddlQuarter.Items.Add("--Select--");
            ddlQuarter.DataValueField = "pkQuatID";
            ddlQuarter.DataTextField = "QuarterDescription";
            ddlQuarter.DataSource = ds;
            ddlQuarter.DataMember = "tblQuarter_View";
            ddlQuarter.DataBind();
            con.Close();
        }

        public void bindAcdYear()
        {
            SqlConnection con = new SqlConnection(strConnString);
            con.Open();

            str = "select top 2 pkacdid,acdDescription from tblAcademicYears order by pkacdID desc";
            if (UMan.Ugid == 37)
            {
                syschoice1.Style.Add("display", "none");

                syschoice2.Style.Add("display", "inline");

                str = "select top 1 pkacdid,acdDescription from tblAcademicYears order by pkacdID desc";
            }

            com = new SqlCommand(str, con);
            sqlda = new SqlDataAdapter(com);
            ds = new DataSet();
            sqlda.Fill(ds, "tblAcademicYears");

            ddlAcdYear.Items.Clear();
            ddlAcdYear.Items.Add("--Select--");
            ddlAcdYear.DataValueField = "pkacdid";
            ddlAcdYear.DataTextField = "acdDescription";
            ddlAcdYear.DataSource = ds;
            ddlAcdYear.DataMember = "tblAcademicYears";
            ddlAcdYear.DataBind();
            con.Close();
        }

        public void bindGrid(int sysid)
        {
            DataTable dt = CheckBudget();

            if (dt.Rows.Count == 0)
            {
                SqlConnection con = new SqlConnection(strConnString);
                con.Open();

                int qtrno = int.Parse(ddlQuarter.SelectedIndex.ToString());

                if (qtrno == 1)
                {
                 //   str = "SELECT 0 as pkReqBudgID, pkbrhID,fkcomid,fksysid,brhname,brhcode,(isnull(dbo.GetStudStrength(pkbrhID),0)+isnull(dbo.GetNewStudStrength(pkbrhID),0)) as strength, 0 as phcost, 0 as budget from [INVENTORY].[dbo].[tblBranches] where fkSysID=" + sysid.ToString();
              
                    str = "SELECT 0 as pkReqBudgID, pkbrhID,fkcomid,fksysid,brhname,brhcode,s.TotalStrength as strength,0 as phcost,0 as budget from [INVENTORY].[dbo].[tblBranches] B";
                    str = str + " INNER JOIN (select fkbrhid,fkacdid,sum(total) as TotalStrength FROM [INVENTORY].[dbo].[tblBGStrength] WHERE FKACDID=" + int.Parse(ddlAcdYear.SelectedValue).ToString() + " group by fkbrhid,fkacdid) S";
                    str = str + " ON B.PKBRHID = S.FKBRHID where B.fkSysID=" + sysid.ToString() + " AND S.FKACDID=" + int.Parse(ddlAcdYear.SelectedValue).ToString();              
                }
                else
                {
                    str = "SELECT 0 as pkReqBudgID, pkbrhID,fkcomid,fksysid,brhname,brhcode,(isnull(dbo.GetStudStrength(pkbrhID),0)) as strength, 0 as phcost, 0 as budget from [INVENTORY].[dbo].[tblBranches] where fkSysID=" + sysid.ToString();
                }
                com = new SqlCommand(str, con);
                sqlda = new SqlDataAdapter(com);
                ds = new DataSet();
                sqlda.Fill(ds);
           

                dt = ds.Tables[0];

                lblCheckBudgState.Text = "false";
            }
            else
            {
              
                lblCheckBudgState.Text = "true";
            }

            ViewState["dt"] = dt;
            grdItems.DataSource = dt;
            grdItems.DataBind();

            grdItems.Visible = true;

            //con.Close();
        }

        private DataTable CheckBudget()
        {
            int comid=0;
            int city=0;

            if (int.Parse(rdoSysChoice.SelectedValue)==1)
            {
              comid=1;
              city=1;
            }
            
            if (int.Parse(rdoSysChoice.SelectedValue)==2)
            {
              comid=1;
              city=2;
            }
            
            if (int.Parse(rdoSysChoice.SelectedValue)==3)
            {
              comid=2;
              city=1;
            }

            SqlConnection con = new SqlConnection(strConnString);
            con.Open();
            str = "SELECT [pkReqBudgID],[pkbrhID],[fkcomid],[fkSysID],[brhName],[brhCode],[fkcityid],[fkDeptID],[fkacdID],[fkQuatID],[fkReqTypID],[fkReqSubTypID],[Strength] as strength,[PerHeadCostQuarterly] as phcost,[BudgetAmount] as budget,[IsActive]";
            str = str + " FROM [INVENTORY].[dbo].[View_RequisitionBudget] where fkcomid=" + comid + " and fkcityid=" + city + " and fkacdID=" + ddlAcdYear.SelectedValue + " and fkQuatID=" + ddlQuarter.SelectedValue + " and ";
            str = str + " fkReqTypID=" + ddlReqType.SelectedValue + " and fkReqSubTypID=" + ddlReqSubType.SelectedValue;


            com = new SqlCommand(str, con);
            sqlda = new SqlDataAdapter(com);
            ds = new DataSet();
            sqlda.Fill(ds);

            DataTable dt = ds.Tables[0];

            //ViewState["dt"] = dt;
            //grdItems.DataSource = dt;
            //grdItems.DataBind();

            //grdItems.Visible = true;

            return dt;


        }

        private DataTable SetDataTable(DataTable FinalDT)
        {
            GridView GridView1 = (GridView)grdItems;

            DataSet ds = new DataSet();
            ds.Tables.Add(FinalDT);

            foreach (GridViewRow GR in GridView1.Rows)
            {

                if (GR.RowType == DataControlRowType.DataRow)
                {
                    int rowid = GR.RowIndex;

                    Label lblBrh = (Label)GR.FindControl("lblBrhID");
                    TextBox lblStr = (TextBox)GR.FindControl("txtstrength");
                    TextBox lblPhc = (TextBox)GR.FindControl("txtperhead");
                    //TextBox lblBud = (TextBox)GR.FindControl("txtBudget");

                    float budget = 0.00F;
         
                    if (lblPhc != null)                 
                    {
                        string brid = lblBrh.Text;
                        string stg = lblStr.Text;
                        string phc = float.Parse(lblPhc.Text).ToString();


                        budget = float.Parse(phc.ToString() == "" ? "0.00F" : phc.ToString()) * float.Parse(stg.ToString() == "" ? "0.00F" : stg.ToString());

                        DataRow[] ItemRow = ds.Tables[0].Select("pkbrhID = '" + brid + "'");

                        ItemRow[0]["budget"] = budget;

                    }
                }

            }

            return ds.Tables[0];

        }

        protected void ddlReqType_SelectedIndexChanged(object sender, EventArgs e)
        {
            bindReqSubType(int.Parse(ddlReqType.SelectedValue.ToString()));
        }

        protected void ddlReqSubType_SelectedIndexChanged(object sender, EventArgs e)
        {


            bindReqQuarter();


        }

        protected void ddlQuarter_SelectedIndexChanged(object sender, EventArgs e)
        {
            txtmonths.Text = ddlQuarter.SelectedItem.ToString();
            bindAcdYear();
        }

        protected void btnSaveBudget_Click(object sender, EventArgs e)
        {
            GetUserInfo();


            DataTable dt1 = (DataTable)ViewState["dt"];

            DataTable dt = SetDataTable(dt1);       

            int reqno = 0;

            Reqman.Pkacdid = int.Parse(ddlAcdYear.SelectedValue);
            Reqman.QurtID = int.Parse(ddlQuarter.SelectedValue);
            Reqman.Reqtypeid = int.Parse(ddlReqType.SelectedValue.ToString());
            Reqman.Reqsubtypid = int.Parse(ddlReqSubType.SelectedValue.ToString());
            Reqman.ReqMonths = txtmonths.Text;
            Reqman.ReqTitle = ddlReqSubType.SelectedItem.ToString();

            if (Reqman.Reqtypeid == 3) 
            {
                Reqman.Pkdeptid = 31;
            }


            if (lblCheckBudgState.Text == "true")
            {
                Reqman.Token = "U";
            }
            else
            {
                Reqman.Token = "I";                
            }
            int i = Reqman.IUReqBudget(dt, ref reqno);
           

                showMessageBox("New Requisition Budget Has Been Successfully Generated!!!!!" + i.ToString());
             

                SetupForm();

                ViewState["dt"] = null;
                grdItems.DataSource = null;
                grdItems.DataBind();

                object typ = this.GetType();
                ScriptManager.RegisterStartupScript(this, this.GetType(), "Close_Window", "self.close();", true);
        }

        protected void rdoSysChoice_SelectedIndexChanged(object sender, EventArgs e)
        {
            //if (rdoSysChoice.SelectedValue == "1")
            //{
                //DataTable dt = new DataTable();
                //grdItems.DataSource = dt;
                //grdItems.DataBind();

                bindGrid(int.Parse(rdoSysChoice.SelectedValue));

                mirdiv.Style.Add("display", "inline");
                //SearchItems();
           // }
           // else
           // {
                //mirdiv.Style.Add("display", "none");
                //txtreqid.Text = GetReqID(rdoReqID.SelectedValue).ToString();
                //btnGetItems.Visible = true;
                
           // }

        }

        protected void txtstrength_TextChanged(object sender, EventArgs e)
        {

            TextBox thisTextBox = (TextBox)sender;
            GridViewRow currentRow = (GridViewRow)thisTextBox.Parent.Parent;
            int rowindex = 0;
            rowindex = currentRow.RowIndex;

            DataTable dt = (DataTable)ViewState["dt"];

            dt.Rows[rowindex]["Strength"] = int.Parse(thisTextBox.Text);
            ViewState["dt"] = dt;

            //grdBranches.DataSource = dt;
           // grdBranches.DataBind();

        }

        protected void txtperhead_TextChanged(object sender, EventArgs e)
        {

            TextBox thisTextBox = (TextBox)sender;
            GridViewRow currentRow = (GridViewRow)thisTextBox.Parent.Parent;
            int rowindex = 0;
            rowindex = currentRow.RowIndex;

            DataTable dt = (DataTable)ViewState["dt"];

            dt.Rows[rowindex]["phcost"] = int.Parse(thisTextBox.Text);
            dt.Rows[rowindex]["budget"] = Double.Parse(dt.Rows[rowindex]["Strength"].ToString() == "" ? "0" : dt.Rows[rowindex]["Strength"].ToString()) * Double.Parse(dt.Rows[rowindex]["phcost"].ToString() == "" ? "0" : dt.Rows[rowindex]["phcost"].ToString());

            ViewState["dt"] = dt;

            grdItems.DataSource = dt;
            grdItems.DataBind();

            //Double.Parse(phc.ToString() == "" ? "0" : phc.ToString()) * Double.Parse(stg.ToString() == "" ? "0" : stg.ToString());
           // grdBranches.DataSource = dt;
           // grdBranches.DataBind();

        }

        protected void txtBudget_TextChanged(object sender, EventArgs e)
        {

            TextBox thisTextBox = (TextBox)sender;
            GridViewRow currentRow = (GridViewRow)thisTextBox.Parent.Parent;
            int rowindex = 0;
            rowindex = currentRow.RowIndex;

            DataTable dt = (DataTable)ViewState["dt"];

            dt.Rows[rowindex]["budget"] = int.Parse(thisTextBox.Text);
            ViewState["dt"] = dt;

           // grdBranches.DataSource = dt;
           // grdBranches.DataBind();
        }

        protected void grdItems_RowCommand(object sender, GridViewCommandEventArgs e)
        {

            if (e.CommandName == "Delete")
            {
                int index = Convert.ToInt32(e.CommandArgument);
                DataTable dt = (DataTable)ViewState["dt"];

                dt.Rows[index].Delete();
                ViewState["dt"] = dt;
                grdItems.DataSource = dt;
                grdItems.DataBind();
            }
        }

        protected void grdItems_RowEditing(object sender, GridViewEditEventArgs e)
        {



        }

        protected void grdItems_RowDeleting(object sender, GridViewDeleteEventArgs e)
        {




        }

        protected void grdItems_RowUpdating(object sender, GridViewUpdateEventArgs e)
        {



        }

        protected void grdItems_RowDataBound(object sender, GridViewRowEventArgs e)
        {
            if (e.Row.RowType == DataControlRowType.DataRow)
            {
                TextBox txtstr = (TextBox)e.Row.FindControl("txtstrength");
                TextBox txtphc = (TextBox)e.Row.FindControl("txtperhead");
                TextBox txtbug = (TextBox)e.Row.FindControl("txtBudget");
                txtstr.Enabled = false;


                if (rdoSysChoice.SelectedValue == "1" || rdoSysChoice.SelectedValue == "2" || rdoSysChoice.SelectedValue == "3")
                {
                    txtstr.Enabled = true;
                    txtphc.Enabled = true;
                    txtbug.Enabled = true;
                }
                // e.Row.Cells[5].Enabled = false;
            }
        }

        protected void btnClose_Click(object sender, EventArgs e)
        {
            object typ = this.GetType();
            ScriptManager.RegisterStartupScript(this, this.GetType(), "Close_Window", "self.close();", true);
        }

        protected void btnGenerateITRequisition_Click(object sender, EventArgs e)
        {
            HttpCookie IMS = Request.Cookies["IMS"];

            Reqman.Uid = int.Parse(IMS["uid"]);
            Reqman.Pkdeptid = int.Parse(IMS["udptid"]);
            Reqman.Pkbrhid = int.Parse(IMS["ubrhid"]);

            Reqman.Pkacdid = int.Parse(ddlAcdYear.SelectedValue.ToString());

            Reqman.SubmissionDate = txtSubmissionDate.Value;

            if (Reqman.CheckITReqBudget() == false)
            {
                Reqman.IUITReqBudget();

                showMessageBox("New I.T Requisition Setup Has Been Successfully Generated!!!!!");
            }
            else
            {
                showMessageBox("Annual I.T Requisition Already Genrated. Please Proceed to Requisition Entry Form at Material Menu!");
            }

        }

    }
}