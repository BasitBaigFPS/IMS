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
    public partial class UpdateDocument : System.Web.UI.Page
    {
        UserManager UMan = new UserManager();
        ItemManager im = new ItemManager();
        IMSManager iman = new IMSManager();
        StoreManager sm = new StoreManager();
        RequisitionManager Reqman = new RequisitionManager();

        POManager POMan = new POManager();

      
        #region PageEvents

        protected void Page_Load(object sender, EventArgs e)
        {

            if (!IsPostBack)
            {
                SetupForm();
            }
            else
            {

                UpdateRemarks.Value = "";
                CancelRemarks.Value = "";

                CancelRemarks.Attributes.Remove("required");

                if (btnCancel.Text == "Revert")
                {
                    btnCancel.Text = "Cancel";
                }

                //Store
                //localStorage.setItem("btnCancel", "Revert");
                // Retrieve
                //document.getElementById("result").innerHTML = localStorage.getItem("lastname"); 


                //string podate = txtPODate.Value;
               // grdItems.DataSource = null;
              //  grdItems.DataBind();

                //if (checkCancel.Value == "Cancel")
                //{
                //    canceldiv.Attributes.Add("display", "block");
                //}
                 

 
            }
        }

        protected void btnShowItemList_Click(object sender, EventArgs e)
        {
           
        }


        protected void btnShowDocument_Click(object sender, EventArgs e)
        {
            DataTable ItemList = new DataTable();

 
              //  GetUserInfo();

                lbldocumentref.Visible = true;
                lbldocumentdate.Visible = true;

                int rowindex = 0;

                cremark.Visible = false;
                CancelRemarks.Visible = false;

                HttpCookie IMS = Request.Cookies["IMS"];

                UMan.Ugid = int.Parse(IMS["ugroupid"]);
                if (UMan.Ugid != 27)
                {
                    GetUserInfo();
                }
                iman.Pkbrhid = int.Parse(ddlbranch.SelectedValue.ToString() == "" ? iman.Pkbrhid.ToString() : ddlbranch.SelectedValue.ToString());

                iman.Pkdeptid = int.Parse(ddlDepartment.SelectedValue.ToString() == "" ? iman.Pkdeptid.ToString() : ddlDepartment.SelectedValue.ToString());

                if (optRecv.Checked == true)
                {
                    ItemList = iman.GetDOCItems(int.Parse(documentID.Value), optRecv.Value.ToString());
                    if (ItemList.Rows.Count != 0)
                    {
                        lbldocumentref.InnerHtml = "GRN No: " + ItemList.Rows[rowindex]["DocCode"];
                        lbldocumentdate.InnerHtml = "Date Received: " + ItemList.Rows[rowindex]["DCDate"];
                    }
                }
                if (optIsu.Checked == true)
                {
                    ItemList = iman.GetDOCItems(int.Parse(documentID.Value), optIsu.Value.ToString());
                    if (ItemList.Rows.Count != 0)
                    {
                        lbldocumentref.InnerHtml = "GIN No: " + ItemList.Rows[rowindex]["DocCode"];
                        lbldocumentdate.InnerHtml = "Date Issued: " + ItemList.Rows[rowindex]["IssuDate"];
                    }
                }
                if (optMir.Checked == true)
                {
                    ItemList = iman.GetDOCItems(int.Parse(documentID.Value), optMir.Value.ToString());
                    if (ItemList.Rows.Count != 0)
                    {
                        lbldocumentref.InnerHtml = "MIR No: " + ItemList.Rows[rowindex]["DocCode"];
                        lbldocumentdate.InnerHtml = "Date Issued: " + ItemList.Rows[rowindex]["IssuDate"];
                    }
                }
                //if (optReq.Checked == true)
                //{
                //    ItemList = iman.GetDOCItems(int.Parse(documentID.Value), optReq.Value.ToString());
                //    if (ItemList.Rows.Count != 0)
                //    lbldocumentref.InnerHtml = "REQ No: " + ItemList.Rows[rowindex]["DocCode"];
                //}

               
                UMan.Ugid = int.Parse(IMS["ugroupid"]);

                ViewState["usergroup"] = "invalid";

                if (ItemList.Rows.Count == 0)
                {
                    showMessageBox("Record Is Not Available For This Document!!!");

                    lbldocumentref.Visible = false;
                    lbldocumentdate.Visible = false;

                    documentID.Value = "";
                    lbldocumentref.InnerHtml = "";
                    lbldocumentdate.InnerHtml = "";
                }
                else
                {
                    ViewState["dt"] = ItemList;


                    int result;

                    if (UMan.Ugid == 27)
                    {
                        ViewState["usergroup"] = "valid";

                        result = SetupGrid(ItemList);
      
                        grdItems.Focus();
                        btnSubmit.Enabled = true;
                        btnBack.Enabled = true;
                    }
                    else
                    {

                        result = SetupGrid(ItemList);
                        
                        if (result > 5)
                        {
                            ViewState["usergroup"] = "invalid";
                      
                            showMessageBox("This Document Is Not Available for Editing, Document ID : " + int.Parse(documentID.Value).ToString());
                            btnSubmit.Enabled = false;
                            btnBack.Enabled = false;
                        }
                        else
                        {
                            ViewState["usergroup"] = "valid";
                     
                            grdItems.Focus();
                            btnSubmit.Enabled = true;
                            btnBack.Enabled = true;
                        }
                    }

                    

                    UpdateRemarks.Value = "";
                    CancelRemarks.Value = "";

                    foreach (DataRow row in ItemList.Rows)
                    {
                        if (int.Parse(row["Qtty"].ToString()) == 0)
                        {
                            btnCancel.Text = "Revert";
                        }
                        
                        if (row["Remarks"].ToString() != "")
                        {
                            UpdateRemarks.Value = row["Remarks"].ToString();
                        }
                        if (row["CancelReason"].ToString() != "")
                        {
                            CancelRemarks.Value = row["CancelReason"].ToString();
                        }
                    }

                    //UpdateRemarks.Attributes.Add("required", "required");

                    uremark.Visible = true;
                    UpdateRemarks.Visible = true;
                }


        }

        protected void txtqty_TextChanged(object sender, EventArgs e)
        {
            TextBox thisTextBox = (TextBox)sender;
            GridViewRow currentRow = (GridViewRow)thisTextBox.Parent.Parent;
            int rowindex = 0;
            rowindex = currentRow.RowIndex;

            if (Single.Parse(thisTextBox.Text) > 0)
            {
                btnCancel.Text = "Cancel";

                currentRow.Attributes.CssStyle.Value = "background-color: White; color: Black";
            }
            else
            {
                btnCancel.Text = "Revert";
            }


        }

        protected void grdItems_RowCommand(object sender, GridViewCommandEventArgs e)
        {
            string checkperm = (string)ViewState["usergroup"];

            if (checkperm == "invalid")
            {
                showMessageBox("No Operation is Allowed For This Document!!!");
                return;
            }

            if (e.CommandName == "Delete")
            {
                int index = Convert.ToInt32(e.CommandArgument);
                DataTable dt = (DataTable)ViewState["dt"];

                dt.Rows[index].Delete();
                dt.AcceptChanges();
                ViewState["dt"] = dt;
                grdItems.DataSource = dt;
                grdItems.DataBind();
            }

            if (e.CommandName == "Cancel")
            {
                                 
                int itemId = Convert.ToInt32(e.CommandArgument);
             
                DataTable dt = (DataTable)ViewState["dt"];

                DataRow[] ItemRow = dt.Select("fkItemID = '" + itemId + "'");

                ItemRow[0]["Qtty"] = "0";
                ItemRow[0]["IsCancel"] = "True";

                dt.AcceptChanges();
                ViewState["dt"] = dt;

                DataTable dtt = (DataTable)ViewState["dt"];

                grdItems.DataSource = dtt;
                grdItems.DataBind();

                ViewState["dt"] = dtt;

                btnCancel.Attributes.Add("Text", "Revert");

                //foreach (GridViewRow gvRow in grdItems.Rows)
                //{
                //     TextBox lblQty = (TextBox)gvRow.FindControl("txtqty");
                //     string qty = lblQty.Text;

                //     if (qty == "0")
                //    {
                //        gvRow.BackColor = System.Drawing.Color.Red;
                //    }
                //}                 

                

            }

            //string command = e.CommandName;           
            //switch (command)
            //{
            //    case "Delete":
            //        Response.Write("<b>Mark As Deleted for " + itemId + " </b> button clicked");
            //        break;
            //    case "Cancel":
            //        Response.Write("<b>Mark As Cancel for " + itemId + " </b> button clicked");
            //        break;
            //}
        }

        protected void grdItems_RowDataBound(object sender, GridViewRowEventArgs e)
        {

            if (e.Row.RowType == DataControlRowType.DataRow)
            {

                TextBox txtqut = (TextBox)e.Row.FindControl("txtqty");

                txtqut.Attributes.Add("onkeydown", "checkBackKey();");

                string checkperm = (string)ViewState["usergroup"];

                if (checkperm == "invalid")
                {
                    txtqut.Enabled = false;
                }
                else
                {
                    txtqut.Enabled = true;
                }
                if (txtqut.Text == "0")
                {
                    e.Row.Attributes.CssStyle.Value = "background-color: DarkRed; color: White";
              
                    CancelRemarks.Attributes.Add("required", "required");

                    cremark.Visible = true;
                    CancelRemarks.Visible = true;

                    btnCancel.Attributes.Add("Text", "Revert");
                }
                else
                {
                    e.Row.Attributes.CssStyle.Value = "background-color: White; color: Black";
                    CancelRemarks.Attributes.Remove("required");

                    btnCancel.Attributes.Add("Text", "Cancel");
                }
            }

            //if (e.Row.Cells[8].Text.Equals("TextToMatch"))
            //{
            //    e.Row.Attributes.CssStyle.Value = "background-color: DarkRed; color: White";
            //}

        }

        protected void grdItems_SelectedIndexChanged(object sender, EventArgs e)
        {

        }

        protected void grdItems_Sorting(object sender, GridViewSortEventArgs e)
        {

        }

        protected void grdItems_RowEditing(object sender, GridViewEditEventArgs e)
        {
            grdItems.EditIndex = e.NewEditIndex;
            DataTable dtt = (DataTable)ViewState["dt"];
            grdItems.DataSource = SetDataTable(dtt);
        }

        protected void grdItems_RowUpdating(object sender, GridViewUpdateEventArgs e)
        {
            GridViewRow row = grdItems.Rows[e.RowIndex];
            //HiddenField hf_AdNo = row.FindControl("hfAdmissionNo") as HiddenField;
            //HiddenField hf_Sub = row.FindControl("hfSubjectID") as HiddenField;

            TextBox Marks = row.FindControl("txtqty") as TextBox;
            //con = new SqlDbConnect();
            //con.SqlQuery("Update tblSetMarks set Marks=@Marks where SubjectID= @SubId and AdmissionNo=@AdNo");
            //con.Cmd.Parameters.Add(new SqlParameter("@SubId", hf_Sub.Value));
            //con.Cmd.Parameters.Add(new SqlParameter("@AdNo", hf_AdNo.Value));
            //con.Cmd.Parameters.Add(new SqlParameter("@Marks", Marks.Text));
            //con.NonQueryEx();
            grdItems.EditIndex = -1;
            //this.BindGrid();

        }

        protected void grdItems_RowUpdated(object sender, GridViewUpdatedEventArgs e)
        {
            e.KeepInEditMode = true;
            GridView GridView1 = (GridView)sender;
            int currRow = GridView1.SelectedRow.RowIndex;
            ((TextBox)grdItems.Rows[currRow].FindControl("txtqty")).Focus();
        }

        protected void grdItems_DataBound(object sender, EventArgs e)
        {

            //GridViewRow row = new GridViewRow(0, 0, DataControlRowType.Header, DataControlRowState.Normal);
            //for (int i = 0; i < grdItems.Columns.Count-2; i++)
            //{
            //    TableHeaderCell cell = new TableHeaderCell();
            //    TextBox txtSearch = new TextBox();
            //    txtSearch.Attributes["placeholder"] = grdItems.Columns[i].HeaderText;
            //    txtSearch.CssClass = "search_textbox";
            //    cell.Controls.Add(txtSearch);
            //    row.Controls.Add(cell);
            //}
            //grdItems.HeaderRow.Parent.Controls.AddAt(0, row);



        }

        protected void grdItems_RowCreated(object sender, GridViewRowEventArgs e)
        {

        }

        protected void btnSubmit_Click(object sender, EventArgs e)
        {
            HttpCookie IMS = Request.Cookies["IMS"];
            if (IMS == null)
                Response.Redirect("logout.aspx");

            POMan.Pkdeptid = int.Parse(IMS["udptid"] == null ? "0" : IMS["udptid"]);
            POMan.Uid = int.Parse(IMS["uid"]);

            DataTable dt1 = (DataTable)ViewState["dt"];

            DataTable dt = SetDataTable(dt1);

            iman.Remarks = UpdateRemarks.Value;

            iman.CancelRemarks = CancelRemarks.Value;

            if (optRecv.Checked == true)
            {
                int i = iman.UpdateReceivedItem(dt, int.Parse(documentID.Value));
            }
            if (optIsu.Checked == true)
            {
                int i = iman.UpdateIssueItem(dt, int.Parse(documentID.Value));
            }

            showMessageBox("Document Successfully Updated, Document ID : " + int.Parse(documentID.Value).ToString());

 
        }

        protected void btnBack_Click(object sender, EventArgs e)
        {
            Response.Redirect("Main.aspx");
        }

        protected void btnCancel_Click(object sender, EventArgs e)
        {
            string msg = string.Empty;

            string docref = lbldocumentref.InnerHtml;

            btnCancel.Attributes.Add("onclick", "return Confirm('" + docref + "');");

            if (checkCancel.Value == "Cancel")
            {
                CancelRemarks.Attributes.Add("required", "required");

                cremark.Visible = true;
                CancelRemarks.Visible = true;

                iman.CancelRemarks = CancelRemarks.Value;
                iman.Remarks = UpdateRemarks.Value;

                if (optRecv.Checked == true)
                {
                  msg =  iman.CancelDocument("GRN",docref);
                }
                if (optIsu.Checked == true)
                {
                    msg = iman.CancelDocument("GIN", docref);
                }

                showMessageBox(docref + " - " + msg);
            }
            else
            {
                cremark.Visible = true;
                CancelRemarks.Visible = true;

                iman.CancelRemarks = CancelRemarks.Value;
                iman.Remarks = UpdateRemarks.Value;

                if (optRecv.Checked == true)
                {
                    msg = iman.RevertDocument("GRN", docref);
                }
                if (optIsu.Checked == true)
                {
                    msg = iman.RevertDocument("GIN", docref);
                }

                showMessageBox(docref + " - " + msg);


            }
        }


        protected void ChkAll_CheckedChanged(object sender, EventArgs e)
        {
            CheckBox chckheader = (CheckBox)grdItems.HeaderRow.FindControl("ChkAll");

            foreach (GridViewRow row in grdItems.Rows)
            {

                CheckBox chckrw = (CheckBox)row.FindControl("ChkRow");

                if (chckheader.Checked == true)
                {
                    chckrw.Checked = true;
                }
                else
                {
                    chckrw.Checked = false;
                }

            }
        }

        protected void grdItems_RowDeleting(object sender, GridViewDeleteEventArgs e)
        {

        }

        protected void btnDocType_Click(object sender, EventArgs e)
        {
            string mytrntype = string.Empty;
            string choice = chkchoise.Value;

            DataTable chkdt = new DataTable();

            grdItems.DataSource = chkdt;
            grdItems.DataBind();

            documentID.Value = "";
            lbldocumentref.InnerHtml = "";

            btnShowDocument.Enabled = true;

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
            UMan.Ugid = int.Parse(IMS["ugroupid"]);
            iman.Pkbrhid = int.Parse(IMS["ubrhid"]);
            iman.Pkdeptid = int.Parse(IMS["udptid"]);
            iman.Pkdeptid = int.Parse(IMS["grpuserdptid"]);

            //if (UMan.Ugid == 31 || UMan.Ugid == 32 || UMan.Ugid == 28)
            //{
            //    iman.Pkdeptid = 14;
            //}

            if (UMan.Ugid==27)
            {
                lblbrhach.Visible = true;
                lbldepart.Visible = true;
                ddlbranch.Visible = true;
                ddlDepartment.Visible = true;

                PopulateBranch();
                PopulateDepartment();
            }

        }

        private void SetupForm()
        {
            cremark.Visible = false;
            CancelRemarks.Visible = false;
            uremark.Visible = false;
            UpdateRemarks.Visible = false;
            lblbrhach.Visible = false;
            lbldepart.Visible = false;
            ddlbranch.Visible = false;
            ddlDepartment.Visible = false;

            DataTable dt = new DataTable();
            ViewState["dt"] = dt;

            btnShowDocument.Enabled = false;

            btnSubmit.Visible = false;

            GetUserInfo();

       
           // txtDlvdate.Text = DateTime.Today.ToString("dd/MM/yyyy");
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



        protected int SetupGrid(DataTable ItemTable)
        {
            int result = 0;

            DateTime DOCDate;
            DateTime CurDate = DateTime.Now;

            foreach (DataRow row in ItemTable.Rows)
            {
                if (chkchoise.Value == "GRN")
                {
                    DOCDate = DateTime.Parse(row["DCDate"].ToString());
                    result = (CurDate - DOCDate).Days;
                }
                else
                {
                    DOCDate = DateTime.Parse(row["IssuDate"].ToString());
                    result = (CurDate - DOCDate).Days;                       
                }                       
            }
            
            if (result<=5)
            {
                ViewState["usergroup"] = "valid";
            }
            
            grdItems.Visible = false;

            grdItems.DataSource = ItemTable;
            grdItems.DataBind();
            
            ViewState["dt"] = ItemTable;

            grdItems.Visible = true;
               
            //DateTime CurDate = DateTime.Now.AddDays(-50);

            return result;
        }

        private DataTable SetDataTable(DataTable FinalDT)
        {
            GridView GridView1 = (GridView)grdItems;

            DataSet ds = new DataSet();
            //  ds.Tables.Add(FinalDT);

            foreach (GridViewRow GR in GridView1.Rows)
            {
                if (GR.RowType == DataControlRowType.DataRow)
                {                                        
                    int rowid = GR.RowIndex;

                    Label lblitem = (Label)GR.FindControl("lblItemID");
                    TextBox lblQty = (TextBox)GR.FindControl("txtqty");

                    //double PCRatio = 0;
                    if (lblQty != null)
                    {
                        string itemid = lblitem.Text;
                        string qty = lblQty.Text;

                        //PCRatio = Double.Parse(qty.ToString() == "" ? "0" : qty.ToString());

                        //DataRow[] ItemRow = ds.Tables[0].Select("Sno = '" + itemid + "'");

                        DataRow[] ItemRow = FinalDT.Select("fkitemID = '" + itemid + "'");

                        ItemRow[0]["Qtty"] = qty == "" ? "0" : qty;

                        if (float.Parse(qty) > 0)
                        {
                            ItemRow[0]["IsCancel"] = "False";
                            ItemRow[0]["Remarks"] = UpdateRemarks.Value;
                            ItemRow[0]["CancelReason"] = CancelRemarks.Value;
                        }

                    }
                }

            }

            //return ds.Tables[0];
            return FinalDT;

        }


        #endregion

        protected void grdItems_RowCancelingEdit(object sender, GridViewCancelEditEventArgs e)
        {
            grdItems.EditIndex = -1; //swicth back to default mode

           // BindGridView(); // Rebind GridView to show the data in default mode
        }

        protected void ddlbranch_SelectedIndexChanged(object sender, EventArgs e)
        {
            iman.Pkbrhid = int.Parse(ddlbranch.SelectedValue.ToString());
        }

        protected void ddlDepartment_SelectedIndexChanged(object sender, EventArgs e)
        {
            
            iman.Pkdeptid = int.Parse(ddlDepartment.SelectedValue.ToString());
        }



    }
 
}