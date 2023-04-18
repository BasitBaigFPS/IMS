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
    public partial class SportsItemEntry : System.Web.UI.Page
    {
        UserManager UMan = new UserManager();
        ItemManager im = new ItemManager();
        IMSManager iman = new IMSManager();
        StoreManager sm = new StoreManager();
        RequisitionManager Reqman = new RequisitionManager();

        POManager POMan = new POManager();

        Boolean allowupdate = false;
        string mytrntype = string.Empty;

        #region PageEvents

        protected void Page_Load(object sender, EventArgs e)
        {

            if (!IsPostBack)
            {
                SetupForm();

                lblvend.Visible = false;
                lblbranch.Visible = false;
                chkvnd.Visible = false;
                chkbranch.Visible = false;

                btnSubmit.Enabled = false;
                btnShowItemList.Visible = false;

            
            }
            else
            {
                //string podate = txtPODate.Value;

            }
        }

        protected void btnShowItemList_Click(object sender, EventArgs e)
        {
            btnShowItemList.Enabled = false;
            allowupdate = true;

            btnSubmit.Enabled = true;

            if (chkchoise.Value != "")
            {
                if (ViewState["dt"] != null)
                {
                    DataTable ItemList = (DataTable)ViewState["dt"];

                    grdItems.DataSource = ItemList;
                    grdItems.DataBind();

                    grdItems.Enabled = true;
                }

            }
        }

        protected void btnReport_Click(object sender, EventArgs e)
        {
            HttpCookie IMS = Request.Cookies["IMS"];
            iman.Pkbrhid = int.Parse(IMS["grpuserbrhid"]);

            string brhid = iman.Pkbrhid.ToString();
           
      //      Response.Redirect("~/ReportsMain.aspx?rptname=SPInventoryBalances&UserBranch=" + brhid);

            ScriptManager.RegisterClientScriptBlock(this, this.GetType(), "openModal", "window.open('ReportsMain.aspx?rptname=SPInventoryBalances&UserBranch=" + brhid + "' ,'_blank');", true);
        }

        //protected void txtqty_TextChanged(object sender, EventArgs e)
        //{
        //    //TextBox thisTextBox = (TextBox)sender;
        //    //GridViewRow currentRow = (GridViewRow)thisTextBox.Parent.Parent;
        //    //int rowindex = 0;
        //    //rowindex = currentRow.RowIndex;

        //    //DataTable dt = (DataTable)ViewState["dt"];

        //    //bool chkb = false;

        //    //if (Single.Parse(thisTextBox.Text) <= Single.Parse(dt.Rows[rowindex]["CRBalance"].ToString()))
        //    //{
        //    //    dt.Rows[rowindex]["Qtty"] = Single.Parse(thisTextBox.Text);
        //    //    ViewState["dt"] = dt;

        //    //    chkb = checkItemBalance(dt, dt.Rows[rowindex]["InvCode"].ToString(), int.Parse(dt.Rows[rowindex]["fkitemid"].ToString()), Single.Parse(dt.Rows[rowindex]["CRBalance"].ToString()), Single.Parse(thisTextBox.Text));

        //    //    if (chkb == true)
        //    //    {
        //    //        dt.Rows[rowindex]["Qtty"] = Single.Parse(thisTextBox.Text);
        //    //        ViewState["dt"] = dt;
        //    //    }
        //    //    else
        //    //    {
        //    //        thisTextBox.Text = "0";
        //    //        showMessageBox("Please Enter Qty Less than Total Current Balance");
        //    //    }

        //    //}

        //    //else
        //    //{
        //    //    thisTextBox.Text = "0";
        //    //    showMessageBox("Please Enter Qty Less than Total Current Balance");
        //    //}

        //}


        protected void ddlvendor_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (chkbranch.Checked == true)
            {

            }
        }


        protected void btnSubmit_Click(object sender, EventArgs e)
        {
            HttpCookie IMS = Request.Cookies["IMS"];
            if (IMS == null)
                Response.Redirect("logout.aspx");


            btnSubmit.Enabled = false;


            DataTable dt1 = (DataTable)ViewState["dt"];

            DataTable dt = SetDataTable(dt1);

            dt = RemoveZeroQtty(dt);
            dt.AcceptChanges();
           
            if (dt.Rows.Count == 0)
            {
                showMessageBox("Add Items first!!!!!");

            }
            else
            {

                im.fkdepartid = int.Parse(IMS["udptid"] == null ? "0" : IMS["udptid"]);
                im.CreatedBy = int.Parse(IMS["uid"]);

                im.OLDGIN = 0;

                im.Token = "I";

                //GetUserInfo();

                im.fkIssueByBranchID = int.Parse(IMS["grpuserbrhid"]);
                im.fkIssueToBranchID = int.Parse(ddlvendor.SelectedValue.ToString() == "" ? im.fkIssueByBranchID.ToString() : ddlvendor.SelectedValue.ToString());

                im.fkIssueByDeptID = int.Parse(IMS["grpuserdptid"]);
                im.fkIssueToDeptID = int.Parse(ddlDepartment.SelectedValue.ToString() == "" ? im.fkIssueByDeptID.ToString() : ddlDepartment.SelectedValue.ToString());
                im.fkdepartid = im.fkIssueToDeptID;

                im.fkIssueByID = int.Parse(im.CreatedBy.ToString());
                im.fkIssuedToID = int.Parse(im.CreatedBy.ToString());

                im.fkstoreid = 0;

                string cvalue = chkchoise.Value;

                if (cvalue=="ISU")
                {
                    im.IssuedType = "I";
                    im.IssuedStatus = "P";
                }
                if (cvalue == "DSP")
                {
                    im.IssuedType = "I";
                    im.IssuedStatus = "DP";
                }
                if (cvalue == "LOS")
                {
                    im.IssuedType = "I";
                    im.IssuedStatus = "LO";
                }

                if (cvalue == "VND" && lblvend.InnerHtml == "Event")
                {
                    im.IssuedType = "E";
                    im.IssuedStatus = "T";
                    cvalue = "Temp";
                }

                im.IssueConfirm = 1;
                
                im.IssuetoID = im.CreatedBy.ToString();

                int i = 0;

                i = im.IUIssueItem(dt);

                txtdocno.Text  = i.ToString();

                sm.fkbrhID = im.fkIssueByBranchID;
                sm.pkstoreID = 0;
                sm.fkdeptID = 17;

              //  sm.UpdateInvBalance(sm.fkbrhID, sm.pkstoreID, sm.fkdeptID);

               // Response.Redirect("~/ReportsMain.aspx?rptname=SportsTransaction&isustat=Temp&gino='" + i.ToString() + "' ,'_blank');", true);

    ///////            ScriptManager.RegisterClientScriptBlock(this, this.GetType(), "openModal", "window.open('ReportsMain.aspx?rptname=SportsTransaction&isustat=" + cvalue + "&gino=" + i.ToString() + "' ,'_blank');", true);

            //    Response.Write("<script>window.open('~/ReportsMain.aspx?rptname=SportsTransaction&isustat=Temp&gino='" + i.ToString()  + "','_blank')</script>");

                //System.Web.UI.ScriptManager.RegisterClientScriptBlock(this, this.GetType(), "openModal", "window.open('ReportsMain.aspx?rptname=SportsTransaction&isustat=Temp&gino=" + i.ToString() + "' ,'_blank');", true);

                showMessageBox("Items " + im.IssuedStatus + " !!!!! with Number : " + i.ToString());


                SetupForm();
                 
            }
 
        }

        protected void btnBack_Click(object sender, EventArgs e)
        {

        }

        protected void btnReset_Click(object sender, EventArgs e)
        {

        }

        protected void btnTrnType_Click(object sender, EventArgs e)
        {
            

            string choice = chkchoise.Value;

            btnShowItemList.Enabled = true;
            btnShowItemList.Visible = true;
           

            allowupdate = true;

            if (optRecv.Checked == true)
            {
                Response.Redirect("~\\Received.aspx");
                mytrntype = "Receving";
                ddlvendor.Visible = false;
                optIsu.Checked = false;
                ToFromLabel.Visible = true;
                ToFromLabel.InnerHtml = "Receive From:";
                lblvndbrh.InnerHtml = "Select Vendor:";
                lblvend.InnerHtml = "Vendor";
                lblvndbrh.Visible = true;
                lblvend.Visible = true;
                lblbranch.Visible = true;
                chkvnd.Visible = true;
                chkbranch.Visible = true;
            }
            else if (optIsu.Checked == true)
            {
                im.IssuedStatus = "P";
                mytrntype = "Issuance";
                ddlvendor.Visible = false;
                ToFromLabel.Visible = true;
                lblvndbrh.Visible = true;
                ToFromLabel.InnerHtml = "Issued To:";
                lblvndbrh.InnerHtml = "Select Branch:";
                lblvend.InnerHtml = "Event";
                lblvend.Visible = true;
                lblbranch.Visible = true;
                chkvnd.Visible = true;
                chkbranch.Visible = true;
                chkvnd.Checked = false;
                if (choice == "VND")
                {
                    chkbranch.Checked = false;
                    chkvnd.Checked = true;
                    lblvndbrh.Visible = false;
                }
                else
                {
                    chkbranch.Checked = true;
                    chkvnd.Checked = false;
                    lblvndbrh.Visible = true;
                }
                if (chkbranch.Checked == true)
                {
                    mytrntype = "Issuance";
                    ddlvendor.Visible = true;
                    ToFromLabel.Visible = true;
                    ToFromLabel.InnerHtml = "Issued To:";
                    lblvend.Visible = true;
                    lblbranch.Visible = true;
                    chkvnd.Visible = true;
                    chkbranch.Visible = true;
                    lbldepart.Visible = true;
                    ddlDepartment.Visible = true;
                    PopulateBranch();
                }

            }
            else if (optDsp.Checked == true)
            {
                mytrntype = "Dispose";
                ddlvendor.Visible = false;
                lbldepart.Visible = false;
                ddlDepartment.Visible = false;
                ToFromLabel.Visible = false;
                lblvndbrh.Visible = false;
                lblvend.Visible = false;
                lblbranch.Visible = false;
                chkvnd.Visible = false;
                chkbranch.Visible = false;
                chkbranch.Checked = false;
                chkvnd.Checked = false;
                im.IssuedStatus = "DP";
            }
            else if (optLos.Checked == true)
            {
                mytrntype = "Lost";
                ddlvendor.Visible = false;
                lbldepart.Visible = false;
                ddlDepartment.Visible = false;
                ToFromLabel.Visible = false;
                lblvndbrh.Visible = false;
                lblvend.Visible = false;
                lblbranch.Visible = false;
                chkvnd.Visible = false;
                chkbranch.Visible = false;
                chkbranch.Checked = false;
                chkvnd.Checked = false;
             
                im.IssuedStatus = "LO";
            }
            if (choice=="VND")
            {
                if (lblvend.InnerHtml == "Vendor" && chkvnd.Checked == true)
                {
                    mytrntype = "Receving";
                    ddlvendor.Visible = true;
                    ToFromLabel.Visible = true;
                    ToFromLabel.InnerHtml = "Receive From:";
                    lblvndbrh.InnerHtml = "Select Vendor:";
                    lblvndbrh.Visible = true;
                    lblvend.Visible = true;
                    lblbranch.Visible = true;
                    chkvnd.Visible = true;
                    chkbranch.Visible = true;
                    chkbranch.Checked = false;
                    lbldepart.Visible = false;
                    ddlDepartment.Visible = false;
                    PopulateVendor();
                }
                else
                {
                    ddlvendor.Visible = false;
                    lblvndbrh.Visible = false;
                    lbldepart.Visible = false;
                    ddlDepartment.Visible = false;
                }

            }
            if (choice == "RCV")
            {
                if (lblvend.InnerHtml == "Vendor")
                {
                    mytrntype = "Receving";
                    ddlvendor.Visible = false;
                    ToFromLabel.Visible = true;
                    ToFromLabel.InnerHtml = "Receive From:";
                    lblvndbrh.InnerHtml = "Select Vendor:";
                    lblvndbrh.Visible = false;
                    lblvend.Visible = true;
                    lblbranch.Visible = true;
                    chkvnd.Visible = true;
                    chkbranch.Visible = true;
                    chkbranch.Checked = false;
                    lbldepart.Visible = false;
                    ddlDepartment.Visible = false;
                    PopulateVendor();
                   // PopulateSportsItems();
                }

            }
            if (choice == "BRH")
            {
                if (chkbranch.Checked == true)
                {
                    mytrntype = "Receving";
                    ddlvendor.Visible = true;
                    ToFromLabel.Visible = true;
                    ToFromLabel.InnerHtml = "Receive From:";
                    lblvndbrh.InnerHtml = "Select Branch:";
                    lblvndbrh.Visible = true;
                    lblvend.Visible = true;
                    lblbranch.Visible = true;
                    chkvnd.Visible = true;
                    chkbranch.Visible = true;
                    chkvnd.Checked = false;
                    lbldepart.Visible = true;
                    ddlDepartment.Visible = true;
                    PopulateBranch();
                    PopulateDepartment();

                     
                }
                else
                {
                    ddlvendor.Visible = false;
                    lblvndbrh.Visible = false;
                    lbldepart.Visible = false;
                    ddlDepartment.Visible = false;
                }
            }

            if (ViewState["dt"] != null)
            {
                DataTable ItemList = (DataTable)ViewState["dt"];

                grdItems.DataSource = ItemList;
                grdItems.DataBind();

                grdItems.Enabled = false;
            }


            // showMessageBox("User Choose Transaction Type :" + mytrntype.ToString());
        }

        #endregion

        #region Helper Methods

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
            iman.Pkbrhid = int.Parse(IMS["grpuserbrhid"]);
            iman.Pkdeptid = int.Parse(IMS["grpuserdptid"]);
            UMan.Ugid = int.Parse(IMS["ugroupid"]);

            iman.Sysid = IMS["sysid"];

            iman.Pkcomid = int.Parse(IMS["comid"]);

            if (UMan.Uid == 157 || UMan.Uid == 89)
            {
                branchdiv.Style.Add("display", "inline");

                PopulateBranchAll();
            }

            //if (UMan.Ugid == 79)
            //{
            //    UMan.Pkdeptid = 17;
            //    iman.Pkdeptid = 17;
            //    IMS["udptid"] = "17";

            //}

        }

        private void SetupForm()
        {

            //DataTable dt = new DataTable();
            //ViewState["dt"] = dt;

            //btnSubmit.Visible = false;

            //btnShowItemList.Enabled = true;

            GetUserInfo();

            DataTable ItemList = new DataTable();

           
            ItemList = iman.GetSportsItems();

            if (ItemList.Rows.Count == 0)
            {
                showMessageBox("No Inventory Item(s) Has Any Balance Right Now!!!");

                SetupGrid(ItemList);

              //  updateprogress.Style.Add("display", "none");
            }
            else
            {
                ViewState["dt"] = ItemList;
                SetupGrid(ItemList);

             //   updateprogress.Style.Add("display", "none");

                //btnShowItemList.Text = "Save Monthly Report";
                lblvndbrh.Visible = false;
                lblvend.Visible = false;
                lbldepart.Visible = false;
                ddlDepartment.Visible = false;
                ddlvendor.Visible = false;
            }


        }

        private void PopulateVendor()
        {
            SqlConnection conn = new SqlConnection();
            SqlCommand cmd = new SqlCommand();

            conn.ConnectionString = SqlHelper.connectionstring;
            cmd.Connection = conn;

            DataSet ds;

            ds = SqlHelper.ExecuteDataset(conn, CommandType.Text, "SELECT pkVendID,VendorName,CPName1 FROM tblVendors where IsActive=1 and fkVendTypID=130 order by VendorName");

            DataTable dt = ds.Tables[0];

            ddlvendor.CausesValidation = false;
            ddlvendor.DataSource = dt;
            ddlvendor.DataTextField = "VendorName";
            ddlvendor.DataValueField = "pkVendID";
            ddlvendor.DataBind();
            ddlvendor.Items.Insert(0, new ListItem("==Please Select==", "0"));

            conn.Close();

        }


        private void PopulateBranchAll()
        {
            SqlConnection conn = new SqlConnection();
            SqlCommand cmd = new SqlCommand();

            conn.ConnectionString = SqlHelper.connectionstring;
            cmd.Connection = conn;

            DataSet ds;

            ds = SqlHelper.ExecuteDataset(conn, CommandType.Text, "SELECT pkbrhid,brhname as BranchName FROM tblBranches where brhisactive=1 order by brhname");

            DataTable dt = ds.Tables[0];



            ddlBranch.CausesValidation = false;
            ddlBranch.DataSource = dt;
            ddlBranch.DataTextField = "BranchName";
            ddlBranch.DataValueField = "pkbrhid";
            ddlBranch.DataBind();
            ddlBranch.Items.Insert(0, new ListItem("==Please Select==", "0"));

            conn.Close();


           // ddlBranch.Attributes.Add("onChange", "doSomeStuff(this);"); // Done on databind.
        }

        private void PopulateBranch()
        {
            SqlConnection conn = new SqlConnection();
            SqlCommand cmd = new SqlCommand();

            conn.ConnectionString = SqlHelper.connectionstring;
            cmd.Connection = conn;

            DataSet ds;

            ds = SqlHelper.ExecuteDataset(conn, CommandType.Text, "SELECT pkbrhid as pkVendID,brhname as VendorName FROM tblBranches where brhisactive=1 order by brhname");

            DataTable dt = ds.Tables[0];

            ddlvendor.CausesValidation = false;
            ddlvendor.DataSource = dt;
            ddlvendor.DataTextField = "VendorName";
            ddlvendor.DataValueField = "pkVendID";
            ddlvendor.DataBind();
            ddlvendor.Items.Insert(0, new ListItem("==Please Select==", "0"));

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

        private void PopulateSportsItems()
        {
            SqlConnection conn = new SqlConnection();
            SqlCommand cmd = new SqlCommand();

            conn.ConnectionString = SqlHelper.connectionstring;
            cmd.Connection = conn;

            DataSet ds;

            ds = SqlHelper.ExecuteDataset(conn, CommandType.Text, "SELECT pkItemID,ItemTitle FROM tblItems where fkCatID=9 order by ItemTitle");

            DataTable dt = ds.Tables[0];

            //ddItems.CausesValidation = false;
            //ddItems.DataSource = dt;
            //ddItems.DataTextField = "ItemTitle";
            //ddItems.DataValueField = "pkItemID";
            //ddItems.DataBind();
            //ddItems.Items.Insert(0, new ListItem("==Please Select==", "0"));

            conn.Close();

        }

        protected void SetupGrid(DataTable ItemTable)
        {
 
            grdItems.Visible = false;

            grdItems.DataSource = ItemTable;
            grdItems.DataBind();

            ViewState["dt"] = ItemTable;

            grdItems.Visible = true;

 

        }

        private DataTable SetDataTable(DataTable FinalDT)
        {
            GridView GridView1 = (GridView)grdItems;

            DataSet ds = new DataSet();
    
            foreach (GridViewRow GR in GridView1.Rows)
            {
                if (GR.RowType == DataControlRowType.DataRow)
                {
                    int rowid = GR.RowIndex;

                    Label lblitem = (Label)GR.FindControl("lblItemID");
                    TextBox lblQty = (TextBox)GR.FindControl("txtqty");
                    TextBox txtrema = (TextBox)GR.FindControl("txtremarks");

                    if (lblQty != null)
                    {
                        string itemid = lblitem.Text;
                        string qty = lblQty.Text;
                        string rema = txtrema.Text.TrimEnd() == "" ? null : txtrema.Text.TrimEnd();

                        DataRow[] ItemRow = FinalDT.Select("fkitemID = '" + itemid + "'");

                        ItemRow[0]["Qtty"] = qty == "" ? "0" : qty;

                        if (float.Parse(qty) > 0)
                        {                            
                            ItemRow[0]["Remarks"] = rema;
                        }

                    }
                }

            }

            //return ds.Tables[0];
            return FinalDT;

        }

        public bool checkItemBalance(DataTable dt, String InvCode, int Itemid, Single balance, Single qtyissue)
        {
            bool returnval = false;

            DataRow[] result = dt.Select("[InvCode] ='" + InvCode + "' AND [fkitemid] =" + Itemid);

            Single i = 0;

            foreach (DataRow row in result)
            {
                i = i + Single.Parse(row["Qtty"].ToString());
            }

            if (i <= balance)
                returnval = true;

            return returnval;
        }

        private DataTable RemoveZeroQtty(DataTable dt)
        {

            for (int i = dt.Rows.Count - 1; i >= 0; i--)
            {
                DataRow dr = dt.Rows[i];
                if (dr["QTTY"].ToString() == "0")
                    dr.Delete();
            }

            return dt;

        }


        #endregion


        #region GridControls

        protected void grdItems_RowCommand(object sender, GridViewCommandEventArgs e)
        {

        }

        protected void grdItems_RowDeleting(object sender, GridViewDeleteEventArgs e)
        {

        }

        protected void grdItems_RowCancelingEdit(object sender, GridViewCancelEditEventArgs e)
        {

        }

        protected void grdItems_RowEditing(object sender, GridViewEditEventArgs e)
        {

        }

        protected void grdItems_RowUpdating(object sender, GridViewUpdateEventArgs e)
        {
            int NextRow = e.RowIndex; //Go to the next row after canceling the update
            ((TextBox)grdItems.Rows[NextRow].FindControl("txtqty")).Focus();
        }

        protected void grdItems_RowUpdated(object sender, GridViewUpdatedEventArgs e)
        {
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

        protected void grdItems_RowCreated(object sender, GridViewRowEventArgs e)
        {

        }

        protected void grdItems_RowDataBound(object sender, GridViewRowEventArgs e)
        {
            if (e.Row.RowType == DataControlRowType.DataRow)
            {
                Label lblCurBal = (Label)e.Row.FindControl("lblcbalance");

                Single CurBal = Convert.ToSingle(lblCurBal.Text == "" ? "0" : lblCurBal.Text);
                
                TextBox txtqut = (TextBox)e.Row.FindControl("txtqty");

                Label lblNewBal = (Label)e.Row.FindControl("lblnewbalance");
                
                txtqut.Attributes.Add("onkeydown", "checkBackKey();");

                if (allowupdate == false)
                {
                    txtqut.Enabled = false;
                }
                else
                {
                    txtqut.Enabled = true;
                }

                string trtyp = String.Empty;

                if (optRecv.Checked == true)
                { trtyp = "RCV"; }
                else
                { trtyp = "ISU"; }

                string rowid = e.Row.RowIndex.ToString();
 
 
                txtqut.Attributes.Add("onkeydown", "return IsNumeric(event" + ",'" + rowid + "')");

                //txtqut.Attributes.Add("onkeyup", "CalculateBalance(event" + ",'" + rowid + "'" + trtyp + "', " + CurBal + ",'" + txtqut.ClientID + "','" + lblNewBal.ClientID + "')");

                txtqut.Attributes.Add("onkeyup", "CalculateBalance('" + rowid + "','" + trtyp + "', " + CurBal + ",'" + txtqut.ClientID + "','" + lblNewBal.ClientID + "')");

                GridViewRow NextRow = e.Row;

            }


        }

        protected void ChkAll_CheckedChanged(object sender, EventArgs e)
        {

        }

        #endregion

        protected void btnUpdateStock_Click(object sender, EventArgs e)
        {
            HttpCookie IMS = Request.Cookies["IMS"];
            sm.fkbrhID = int.Parse(IMS["grpuserbrhid"]);
            im.fkdepartid = int.Parse(IMS["grpuserdptid"]);
            sm.pkstoreID = 0;

         //   updateprogress.Style.Add("display", "block");

            sm.UpdateInvBalance(sm.fkbrhID, sm.pkstoreID, im.fkdepartid);

            SetupForm();
        }

        protected void ddlBranch_SelectedIndexChanged(object sender, EventArgs e)
        {
          
        }

        protected void btnShowstore_Click(object sender, EventArgs e)
        {
            iman.Pkbrhid = int.Parse(ddlBranch.SelectedValue.ToString());

            lblBranchName.InnerHtml = "Sports Inventory of : " + ddlBranch.SelectedItem.Text;

            DataTable ItemList = new DataTable();


            ItemList = iman.GetSportsItems();

            if (ItemList.Rows.Count == 0)
            {
                showMessageBox("No Inventory Item(s) Has Any Balance Right Now!!!");

                SetupGrid(ItemList);

            }
            else
            {
                ViewState["dt"] = ItemList;
                SetupGrid(ItemList);
                lblvndbrh.Visible = false;
                lblvend.Visible = false;
                lbldepart.Visible = false;
                ddlDepartment.Visible = false;
                ddlvendor.Visible = false;
            }

        }

     
    }
 
}