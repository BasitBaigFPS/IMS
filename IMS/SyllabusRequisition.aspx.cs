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
    public partial class SyllabusRequisition : System.Web.UI.Page
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

        private void SetupForm()
        {

            DataTable dt = new DataTable();
            ViewState["dt"] = dt;


            mirdiv.Style.Add("display", "none");

            bindReqType();
            bindReqSubType(int.Parse(ddlReqType.SelectedValue.ToString()));
            bindAcdYear();

            btnProcessReq.Visible = false;

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

        public void bindReqType()
        {
            SqlConnection con = new SqlConnection(strConnString);
            con.Open();
            str = "select pkReqTypID,RequisitionType from tblReqType where pkReqTypID=1 and IsActive=1";
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
            ddlReqType.SelectedIndex = 1;
            ddlReqType.Enabled = false;
            con.Close();
        }

        public void bindReqSubType(int ReqTypID)
        {
            SqlConnection con = new SqlConnection(strConnString);
            con.Open();
            //int ReqTypID = 1;
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
            ddlReqSubType.SelectedIndex = 1;
            con.Close();
        }

        public void bindAcdYear()
        {
            //where isactive=1
            SqlConnection con = new SqlConnection(strConnString);
            con.Open();
            str = "select top 2 pkacdid,acdDescription from tblAcademicYears order by pkacdID desc";
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
            ddlAcdYear.SelectedIndex = 1;
            ddlAcdYear.Enabled = false;
            con.Close();
        }

        public void bindGrid(int sysid)
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
                Reqman.ProduceNewYearStrength(comid, cityid);
            //}

            SqlConnection con = new SqlConnection(strConnString);
            con.Open();
            str = "SELECT [SysID],[Grade],[Total],[IsPosted]  FROM [INVENTORY].[dbo].[View_SyllabusGradeStrength] where SysID=" + sysid.ToString() + " and IsPosted IS NULL Order by Grade";
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
                btnSaveBudget.Visible = false;

                showMessageBox("Distribution Process of This System is Now Finalized, You Can See Data Through Reports Only!!!!");

                btnProcessReq.Visible = true;

            }
            else
            {
                grdGrade.Visible = true;
                btnSaveBudget.Visible = true;
                btnProcessReq.Visible = false;
            }

            //con.Close();
        }

        protected void SetupGrid(DataTable ItemTable)
        {
            grdItems.DataSource = ItemTable;
            grdItems.DataBind();
            grdItems.Visible = true;

            //  btnSave.Visible = true;

            GetUserInfo();

            ViewState["dt"] = ItemTable;

            string rstatus = ItemTable.Rows[0]["RecStatus"].ToString();
            //
            if (rstatus == "NEW")
            {
                lblSybReqExist.Text = "false";
            }
            else
            {
                lblSybReqExist.Text = "true";
            }
           // CheckBudgetAmount(ItemTable);

            GridViewHelper helper = new GridViewHelper(this.grdItems);
            helper.RegisterSummary("In Stock Balance", SummaryOperation.Sum);

            helper.RegisterGroup("ItemHeadTitle", true, true);
            helper.ApplyGroupSort();

            grdItems.Focus();

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

                    Label lblItem = (Label)GR.FindControl("lblItemID");
                    TextBox lblPhc = (TextBox)GR.FindControl("txtqty");

                    float PCRatio = 0.00F;
                    if (lblPhc != null)                 
                    {
                        string itemid = lblItem.Text;
                        string phc = float.Parse(lblPhc.Text).ToString();

                        
                        PCRatio = float.Parse(phc.ToString() == "" ? "0.00F" : phc.ToString());

                        DataRow[] ItemRow = ds.Tables[0].Select("fkItemID = '" + itemid + "'");

                        ItemRow[0]["QtyRequired"] = phc == "" ? "0.00F" : phc;

                    }
                }

            }

            return ds.Tables[0];

        }


        protected void GetReqType()
        {
            GetUserInfo();

            if (rdoSysChoice.SelectedValue.ToString()=="")
            {
                return;
            }

            //DataTable ItemRateData = Reqman.GetItemsByReqType(int.Parse(ddlReqType.SelectedValue.ToString()), int.Parse(ddlReqSubType.SelectedValue.ToString()));

            DataTable ItemRateData = Reqman.GetSybItemsByReqType(int.Parse(ddlReqType.SelectedValue.ToString()), int.Parse(ddlReqSubType.SelectedValue.ToString()), int.Parse(rdoSysChoice.SelectedValue.ToString()), int.Parse(ddlAcdYear.SelectedValue), txtGrade.Text);

            if (ItemRateData.Rows.Count == 0)
            {
                showMessageBox("No Record Found For This Requisition Type!!!");
            }
            else
            {
                SetupGrid(ItemRateData);
            }
            txtReqType.Text = ddlReqSubType.Text + "-" + ddlReqSubType.SelectedItem.Text;
            if (rdoSysChoice.SelectedValue != "")
            {
                txtSysName.Text = rdoSysChoice.SelectedValue.ToString() + "-" + rdoSysChoice.SelectedItem.Text;
            }
            
        }


        protected void ddlReqType_SelectedIndexChanged(object sender, EventArgs e)
        {
           // bindReqSubType(int.Parse(ddlReqType.SelectedValue.ToString()));
        }

        protected void ddlReqSubType_SelectedIndexChanged(object sender, EventArgs e)
        {
           // bindReqQuarter();
            //mirdiv.Style.Add("display", "none");
            //ReqDiv.Style.Add("display", "none");
            if (txtSysName.Text == "")
            {
                rdoSysChoice.SelectedValue = null;
            }

            GetReqType();
            
        }

        protected void btnSaveBudget_Click(object sender, EventArgs e)
        {
            GetUserInfo();


            DataTable dt1 = (DataTable)ViewState["dt"];

            DataTable dt = SetDataTable(dt1);

            //DataTable dt = dt1; 

            int reqno = 0;
            //Reqman.ReqTitle = ddlReqSubType.SelectedItem.ToString();

            Reqman.Pkacdid = int.Parse(ddlAcdYear.SelectedValue);      
            Reqman.Reqtypeid = int.Parse(ddlReqType.SelectedValue.ToString());
            Reqman.Reqsubtypid = int.Parse(ddlReqSubType.SelectedValue.ToString());          
            Reqman.StudStrength = int.Parse(txtGrdStrength.Text);

            int comid = 1;
            int cityid = 1;

            if (int.Parse(rdoSysChoice.SelectedValue) == 2)
            {
                comid = 1;
                cityid = 2;
            }
            if (int.Parse(rdoSysChoice.SelectedValue) == 3)
            {
                comid = 2;
                cityid = 1;
            }


            if (lblSybReqExist.Text == "true")
            {
                Reqman.Token = "U";
            }
            else
            {
                Reqman.Token = "I";                
            }

            if (chkPosted.Checked)
            {
                Reqman.Posted = 1;
            }


           
            Reqman.IUSyllabusReq(dt, comid, cityid,txtGrade.Text);
           

            showMessageBox("Record Has Been Successfully Saved!!!!");
             

              ///  SetupForm();

                ViewState["dt"] = null;
                grdItems.DataSource = null;
                grdItems.DataBind();

        }

        protected void rdoSysChoice_SelectedIndexChanged(object sender, EventArgs e)
        {           
                bindGrid(int.Parse(rdoSysChoice.SelectedValue));
                txtReqType.Text = ddlReqSubType.Text + "-" + ddlReqSubType.SelectedItem.Text;
                txtSysName.Text = rdoSysChoice.SelectedValue.ToString() + "-" + rdoSysChoice.SelectedItem.Text;

                ViewState["System"] = txtSysName.Text;

                string system = (string)ViewState["System"];

                btnProcessReq.Attributes.Add("onclick", "return Confirm('" + system + "');");


                mirdiv.Style.Add("display", "inline");
                ReqDiv.Style.Add("display", "none");
        }

        protected void ChoiceGrade_OnCheckedChanged(object sender, EventArgs e)
        {
            CheckBox chk = sender as CheckBox;

            if (chk.Checked)
            {
                GridViewRow row = (GridViewRow)chk.NamingContainer;

                txtReqType.Text = ddlReqSubType.Text + "-" + ddlReqSubType.SelectedItem.Text;
                txtSysName.Text = rdoSysChoice.SelectedValue.ToString() + "-" + rdoSysChoice.SelectedItem.Text;
                txtGrade.Text = row.Cells[4].Text;
                TextBox txtstrg = (TextBox)row.FindControl("txtstrength");

                txtGrdStrength.Text = txtstrg.Text;

                //ReqDiv.Style.Add("display", "inline");

                GetReqType();
            }
            var rows = grdGrade.Rows;
            int count = grdGrade.Rows.Count;
            for (int i = 0; i < count; i++)
            {
                bool isChecked = ((CheckBox)rows[i].FindControl("ChoiceGrade")).Checked;
                if (isChecked)
                {
                    ReqDiv.Style.Add("display", "inline");
                    break;
                }
                else
                {
                    ReqDiv.Style.Add("display", "none");
                    //txtGrade.Text = "";
                    //txtGrdStrength.Text = "";
                }
            }


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
                
                txtstr.Enabled = false;

                //if (DataBinder.Eval(e.Row.DataItem, "IsPosted") == DBNull.Value)
                //{
                //    e.Row.BackColor = System.Drawing.Color.Cyan;
                //}
                //else
                //{
                //    e.Row.BackColor = System.Drawing.Color.GreenYellow;
                //}
              
                  

                //if (rdoSysChoice.SelectedValue == "1" || rdoSysChoice.SelectedValue == "2" || rdoSysChoice.SelectedValue == "3")
                //{
                //    txtstr.Enabled = true;
             
                //}
                // e.Row.Cells[5].Enabled = false;
            }
        }


        protected string CheckIfTitleExists(string strval)
        {
            string title = (string)ViewState["ItemHeadTitle"];
            if (title == strval)
            {
                return string.Empty;
            }
            else
            {
                title = strval;
                ViewState["ItemHeadTitle"] = title;
                return "<br><b>" + title + "</b><br>";
            }
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

        protected void txtqty_TextChanged(object sender, EventArgs e)
        {

            //TextBox thisTextBox = (TextBox)sender;
            //GridViewRow currentRow = (GridViewRow)thisTextBox.Parent.Parent;
            //int rowindex = 0;
            //rowindex = currentRow.RowIndex;

            //DataTable dt = (DataTable)ViewState["dt"];

            ////bool chkb = false;

            //dt.Rows[rowindex]["QtyRequired"] = Single.Parse(thisTextBox.Text);
            ////  ViewState["dt"] = dt;


            //dt.Rows[rowindex]["QtyRequired"] = Single.Parse(thisTextBox.Text);

            //Single amt = (Single.Parse(thisTextBox.Text) * Single.Parse(dt.Rows[rowindex]["Rate"].ToString()));

            //string checkrow = dt.Rows[rowindex]["QtyRequired"].ToString();


            //dt.Rows[rowindex]["Amount"] = amt;

            //ViewState["dt"] = dt;

            //SetupGrid(dt);


        }

        protected void grdItems_RowUpdating(object sender, GridViewUpdateEventArgs e)
        {
            //grdItems.Focus();

            int NextRow = e.RowIndex; //Go to the next row after canceling the update
            ((TextBox)grdItems.Rows[NextRow].FindControl("txtqty")).Focus();

        }

        protected void grdItems_RowUpdated(object sender, GridViewUpdatedEventArgs e)
        {
            //int NextRow = 5;
            e.KeepInEditMode = true;
            GridView GridView1 = (GridView)sender;
            int currRow = GridView1.SelectedRow.RowIndex;
            ((TextBox)grdItems.Rows[currRow].FindControl("txtqty")).Focus();

        }

        protected void grdItems_Sorting(object sender, GridViewSortEventArgs e)
        {

        }

        protected void grdItems_DataBound(object sender, EventArgs e)
        {

        }

        protected void grdItems_RowDataBound(object sender, GridViewRowEventArgs e)
        {

            if (e.Row.RowType == DataControlRowType.DataRow)
            {


                Label lblCurrentListPrice = (Label)e.Row.FindControl("lblrate");
                TextBox txtqut = (TextBox)e.Row.FindControl("txtqty");

                string rowid = e.Row.RowIndex.ToString();

                txtqut.Attributes.Add("onkeydown", "return IsNumeric(event" + ",'" + rowid + "')");

                GridViewRow NextRow = e.Row;


                for (int i = 0; i < grdItems.Rows.Count - 1; i++)
                {
                    TextBox curTexbox = grdItems.Rows[i].Cells[7].FindControl("txtqty") as TextBox;
                    TextBox nexTextbox = grdItems.Rows[i + 1].Cells[7].FindControl("txtqty") as TextBox;

                    curTexbox.Attributes.Add("onkeypress", "return clickEnter('" + nexTextbox.ClientID + "', event)");

                    curTexbox.Attributes.Add("onfocusin", " select();");
                }

            }

        }


        protected void btnClose_Click(object sender, EventArgs e)
        {
            object typ = this.GetType();
            Response.Redirect("Main.aspx");
        }

        protected void btnProcessReq_Click(object sender, EventArgs e)
        {

            string system = (string)ViewState["System"];

            int comid = 1;
            int cityid = 1;

            if (int.Parse(rdoSysChoice.SelectedValue) == 2)
            {
                comid = 1;
                cityid = 2;
            }
            if (int.Parse(rdoSysChoice.SelectedValue) == 3)
            {
                comid = 2;
                cityid = 1;
            }

            Reqman.Pkacdid = int.Parse(ddlAcdYear.SelectedValue);  
            Reqman.ProcessFinalSyllabusReq(comid,cityid);

            showMessageBox(system + " Syllabus Requisition Has Been Processed and MIR Generated Successfully!!!");
        }


        protected void cmd_Upload_Click(object sender, EventArgs e)
        {
            //string s_Image_Name = txt_Image_Name.Text.ToString();

            //if (FileUpload1.PostedFile != null && FileUpload1.PostedFile.FileName != "")
            //{
            //    byte[] n_Image_Size = new byte[FileUpload1.PostedFile.ContentLength];
            //    HttpPostedFile Posted_Image = FileUpload1.PostedFile;
            //    Posted_Image.InputStream.Read(n_Image_Size, 0, (int)FileUpload1.PostedFile.ContentLength);

            //    SqlConnection conn = new SqlConnection(ConfigurationManager.ConnectionStrings["INVENTORY"].ConnectionString);

            //    SqlCommand cmd = new SqlCommand();
            //    cmd.CommandText = "INSERT INTO tblImages(Name,[Content],Size,Type)" +
            //                      " VALUES (@Image_Name,@Image_Content,@Image_Size,@Image_Type)";
            //    cmd.CommandType = CommandType.Text;
            //    cmd.Connection = conn;

            //    SqlParameter Image_Name = new SqlParameter("@Image_Name", SqlDbType.VarChar, 500);
            //    Image_Name.Value = txt_Image_Name.Text;
            //    cmd.Parameters.Add(Image_Name);

            //    SqlParameter Image_Content = new SqlParameter("@Image_Content", SqlDbType.Image, n_Image_Size.Length);
            //    Image_Content.Value = n_Image_Size;
            //    cmd.Parameters.Add(Image_Content);

            //    SqlParameter Image_Size = new SqlParameter("@Image_Size", SqlDbType.BigInt, 99999);
            //    Image_Size.Value = FileUpload1.PostedFile.ContentLength;
            //    cmd.Parameters.Add(Image_Size);

            //    SqlParameter Image_Type = new SqlParameter("@Image_Type", SqlDbType.VarChar, 500);
            //    Image_Type.Value = FileUpload1.PostedFile.ContentType;
            //    cmd.Parameters.Add(Image_Type);


            //    conn.Open();
            //    cmd.ExecuteNonQuery();
            //    conn.Close();
            //}
        }

        protected void btnGenerateSybReq_Click(object sender, EventArgs e)
        {

           string system = (string)ViewState["System"];

            int comid = 1;
            int cityid = 1;

            if (int.Parse(rdoSysChoice.SelectedValue) == 2)
            {
                comid = 1;
                cityid = 2;
            }
            if (int.Parse(rdoSysChoice.SelectedValue) == 3)
            {
                comid = 2;
                cityid = 1;
            }

            Reqman.Pkacdid = int.Parse(ddlAcdYear.SelectedValue);     
            Reqman.GenerateSyllabusReq(comid,cityid);

            showMessageBox(system + " Syllabus Distribution Has Been Processed and Distribution Reports Generated Successfully!!!");
        }

        protected void chkPosted_CheckedChanged(object sender, EventArgs e)
        {
            if (chkPosted.Checked)
            {
                Reqman.Posted = 1;
            }
        }

    }
}