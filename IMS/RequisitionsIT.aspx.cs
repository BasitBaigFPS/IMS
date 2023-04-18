using System;
using System.Data;
using System.Linq;
using System.Web;
using System.Web.Security;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Web.UI.WebControls.WebParts;
using System.Web.UI.HtmlControls;
using System.Collections.Generic;
using System.Drawing;
using System.Text;
using System.Data.OleDb;
using System.Configuration;
using Telerik.Web.UI;
using BLL;
using System.IO;
using System.Data.SqlClient;
 



namespace IMS
{
    public partial class RequisitionsIT : System.Web.UI.Page
    {
        DashBoardManager dbm = new DashBoardManager();
        UserManager UMan = new UserManager();
        ItemManager im = new ItemManager();
        IMSManager iman = new IMSManager();
        StoreManager sm = new StoreManager();
        RequisitionManager Reqman = new RequisitionManager();

        //private GridViewHelper helper;

        // Initialize information about the event.
        private const string EventName = "Requisition Submission Date";
        private DateTime EventDate = DateTime.Now +  new TimeSpan(1, 13, 42, 59);

  
        int rowIndex = 1;

        #region Events

        protected void Page_Load(object sender, EventArgs e)
        {
            if (Page.IsPostBack == false)
            {
                SetupForm();


                //lblEvent.InnerText = EventName;
 
                //tmrCheckTime.Enabled = true;



            }
            btnExport.Visible = false;
        }

        // Update the countdown.
        //protected void tmrCheckTime_Tick(object sender, EventArgs e)
        //{
        //    TimeSpan remaining = DateTime.Parse(txtDlvdate.Text) - DateTime.Now;

        //    if (remaining.TotalSeconds < 1)
        //    {
        //        tmrCheckTime.Enabled = false;
        //    }
        //    else
        //    {
        //        lblDays.InnerText = remaining.Days + " days";
        //        lblHours.InnerText = remaining.Hours + " hours";
        //        lblMinutes.InnerText = remaining.Minutes + " minutes";
        //        lblSeconds.InnerText = remaining.Seconds + " seconds";
        //    }
        //}

        protected void btnConfirm_Click(object sender, EventArgs e)
        {
          //  LoadRequisitionItems();

        }

        protected void cmbReqType_SelectedIndexChanged(object sender, Telerik.Web.UI.RadComboBoxSelectedIndexChangedEventArgs e)
        {
            if (cmbReqType.SelectedValue.ToString() != "Choose Requisition Type")
            {
                GetBudgetInfo(int.Parse(cmbReqType.SelectedValue.ToString()));

             //   grdItems.Visible = false;
                btnSubmit.Visible = false;

                LoadRequisitionItems();
            }
        }

        protected void grdItems_NeedDataSource(object sender, Telerik.Web.UI.GridNeedDataSourceEventArgs e)
        {



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

        protected void btnSubmit_Click(object sender, EventArgs e)
        {
            HttpCookie IMS = Request.Cookies["IMS"];
            if (IMS == null)
                Response.Redirect("logout.aspx");


            //DataTable dt = (DataTable)ViewState["dt"];

            DataTable dt1 = (DataTable)ViewState["dt"];

            DataTable dt = SetDataTable(dt1);


            im.fkdepartid = int.Parse(IMS["udptid"] == null ? "0" : IMS["udptid"]);
            im.CreatedBy = int.Parse(IMS["uid"]);

            int reqno = 0;


            GetUserInfo();
            GetStore();

            btnPost.Visible = true;

            bool budgetok;
 
                Reqman.Uid = int.Parse(IMS["uid"]);
                Reqman.FkReqBudgID = int.Parse(cmbReqType.SelectedValue.ToString());
                //Reqman.StudStrength = int.Parse(txtStrength.Text=="" ? "0" : txtStrength.Text);
                //Reqman.PerHeadCost = int.Parse(txtPerChildCost.Text=="" ? "0" :txtPerChildCost.Text);
                //Reqman.BudgetAmount = Double.Parse(txtAppBudget.Text == "" ? "0" : txtAppBudget.Text);
                Reqman.ExpDelivDate = txtDlvdate.Text.ToString();
                //  Reqman.BudgetAmount = 17754;

               // budgetok = Reqman.CheckBudget(dt, Reqman.BudgetAmount);

                budgetok = true;
                Reqman.Pkdeptid = 10;

             Reqman.Pkbrhid= int.Parse(cmbbranch.SelectedValue.ToString() == "Choose Branch" || cmbbranch.SelectedValue.ToString() == "" ? UMan.Ubrhid.ToString() : cmbbranch.SelectedValue.ToString());
 

            if (budgetok == true)
            {
                int i;
 
                 i = Reqman.IUITRequistion(dt, ref reqno);
 
                if (i == 0)
                {
                    showMessageBox("Requisition Updates Have Been Closed Now , No More Update/Changes Will Saved!!!");
                }
                else
                {
                    if (btnSubmit.Text == "Save & Notify Branch")
                    {
                        im.SendReportEmail(Reqman.Pkbrhid, 0, 10, 8, reqno);
                    }
                    else
                    {
                        showMessageBox("Requisition Has Been Successfully Generated!!!!! with Requisition Number : " + i.ToString());
                        txtReqNo.Text = i.ToString();
                    }

                    SetupForm();

                    ShowReqSummary(int.Parse(txtReqNo.Text));
                }
                ViewState["dt"] = null;
                grdItems.DataSource = null;
                grdItems.DataBind();

            }
            else
            {
                showMessageBox("NOT SAVE!....Your Requisition is Excceed with the Budget/Balance Amount,Please Correct or Reduce Your Quantity To Save!!!!");

            }


            //Response.Redirect("ReportsMain.aspx?rptname=QuarterlyRequisition&reqno=" + txtReqNo.Text,false);

            //btnPrint_Click(sender, e);
            //btnPrintGatePass_Click(sender, e);
        }

        private void ShowReqSummary(int RequID)
        {

            Reqman.Pkbrhid = int.Parse(cmbbranch.SelectedValue.ToString() == "Choose Branch" || cmbbranch.SelectedValue.ToString() == "" ? UMan.Ubrhid.ToString() : cmbbranch.SelectedValue.ToString()); 

            DataTable dt = Reqman.GetReqSummary(RequID);

            StringBuilder htmlhead = new StringBuilder();

            foreach (DataRow row in dt.Rows)
            {
                foreach (DataColumn column in dt.Columns)
                {
                    string colname = column.ColumnName.ToString();

                    if (colname != "fkbrhid" && colname != "fkreqid")
                    {
                        htmlhead.Append("<th data-field=" + colname + "data-align=" + "center" + "data-sortable=" + "true" + " data-filter-control=" + "input" + "data-visible=" + "true" + ">" + colname.ToString().ToUpper() + "</th>");
                    }
                }

                break;
            }

            PlaceHolder1.Controls.Add(new Literal { Text = htmlhead.ToString() });

            StringBuilder html = new StringBuilder();

            foreach (DataRow row in dt.Rows)
            {
                html.Append("<tr>");

                foreach (DataColumn column in dt.Columns)
                {
                    string colname = column.ColumnName.ToString();

                    if (colname != "fkbrhid" && colname != "fkreqid")
                    {
                        html.Append("<td>");
                        html.Append(row[column.ColumnName]);
                        html.Append("</td>");
                    }
                }

                html.Append("</tr>");
            }


            PlaceHolder2.Controls.Add(new Literal { Text = html.ToString() });


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

            //if (e.Row.RowType == DataControlRowType.Header)
            //{
            //    Label lblTitle = (Label)e.Row.FindControl("lblTitle");
            //  //  lblTitle.Text = DataBinder.Eval(e.Row.DataItem, "RequisitionSubType").ToString();              

            //    //(e.HeaderRow.FindControl("lbl") as Label).Text = "Title";

            //}

            if (e.Row.RowType == DataControlRowType.DataRow)
            {
                RadComboBox ddlPersonto = (RadComboBox)e.Row.FindControl("ddlPersonto");

                RadComboBox ddlLocationto = (RadComboBox)e.Row.FindControl("ddlLocationto");

                Label lblCurrentListPrice = (Label)e.Row.FindControl("lblrate");
                Double CurPr = Convert.ToDouble(lblCurrentListPrice.Text == "" ? "0" : lblCurrentListPrice.Text);
                TextBox txtqut = (TextBox)e.Row.FindControl("txtqty");

                ///txtqut.ReadOnly = true;


                Label lblTotal = (Label)e.Row.FindControl("lblamt");

                Label lblLocID = (Label)e.Row.FindControl("lblLocationToID");

                Label lblEmpID = (Label)e.Row.FindControl("lblIssuedToID");

                string locids = lblLocID.Text;

                string empids = lblEmpID.Text;


                string rowid = e.Row.RowIndex.ToString();

                txtqut.Attributes.Add("onkeydown", "return IsNumeric(event" + ",'" + rowid + "')");

                txtqut.Attributes.Add("onkeyup", "CalculateAmount(" + CurPr + ", '" + txtqut.ClientID + "','" + lblTotal.ClientID + "')");

                txtqut.Attributes.Add("onblur", "MakeTotal('" + e.Row.RowIndex + "')");

                GridViewRow NextRow = e.Row;


                for (int i = 0; i < grdItems.Rows.Count - 1; i++)
                {
                    TextBox curTexbox = grdItems.Rows[i].Cells[7].FindControl("txtqty") as TextBox;
                    TextBox nexTextbox = grdItems.Rows[i + 1].Cells[7].FindControl("txtqty") as TextBox;
                    curTexbox.Attributes.Add("onkeypress", "return clickEnter('" + nexTextbox.ClientID + "', event)");

                    curTexbox.Attributes.Add("onfocusin", " select();");
                }

                if (ddlLocationto.CheckedItems.Count > 0)
                {
                    var collection = ddlLocationto.CheckedItems;
                    string locid = "";
                    string locname = "";

                    if (collection.Count != 0)
                    {
                        foreach (var item in collection)
                        {
                            locid = locid + item.Value.TrimEnd() + ",";
                            locname = locname + item.Text + ",";
                        }
                        Label lblLocation = (Label)e.Row.FindControl("lblLocation");


                        lblLocation.Text = locname;
                        //txtremarks.Text = empname;
                    }
                }

                if (ddlLocationto.Items.Count == 0)
                {
                    ddlLocationto.Attributes.Add("visible", "true");

                    string sql = "SELECT pkReqLocID,ReqLocation FROM tblReqLocation";

                    if (Reqman.Pkbrhid==19)
                    {
                        sql = "SELECT pkReqLocID,ReqLocation FROM tblReqLocation where BR_HO='" + "HO" + "'";
                    }
                    else
                    {
                        sql = "SELECT pkReqLocID,ReqLocation FROM tblReqLocation where BR_HO='" + "BR" + "'";
                    }


                    

                    string conString = ConfigurationManager.ConnectionStrings["INVENTORY"].ConnectionString;

                    using (SqlConnection con = new SqlConnection(conString))
                    {
                        using (SqlDataAdapter sda = new SqlDataAdapter(sql, con))
                        {
                            using (DataTable dt = new DataTable())
                            {
                                sda.Fill(dt);

                                if (ddlLocationto != null)
                                {
                                    ddlLocationto.DataSource = dt;
                                    ddlLocationto.DataTextField = "ReqLocation";
                                    ddlLocationto.DataValueField = "pkReqLocID";
                                    ddlLocationto.DataBind();
                                    string selectedLocation = DataBinder.Eval(e.Row.DataItem, "LocName").ToString();
                                    if (selectedLocation != "")
                                    {
                                        //ddlPersonto.Items.FindByValue(selectedEmployee).Selected = true;

                                        //ddlPersonto.Items.FindItemByValue(selectedEmployee).Selected = true;
                                    }
                                }
                            }
                        }
                    }
                }

                if (e.Row.RowType == DataControlRowType.DataRow && grdItems.EditIndex == e.Row.RowIndex)
                {
                    DropDownList ddlLocation = (DropDownList)e.Row.FindControl("ddlLocationto");

                    string sql = "SELECT pkReqLocID,ReqLocation FROM tblReqLocation";

                    if (Reqman.Pkbrhid == 19)
                    {
                        sql = "SELECT pkReqLocID,ReqLocation FROM tblReqLocation where BR_HO='" + "HO" + "'";
                    }
                    else
                    {
                        sql = "SELECT pkReqLocID,ReqLocation FROM tblReqLocation where BR_HO='" + "BR" + "'";
                    }

                    string conString = ConfigurationManager.ConnectionStrings["INVENTORY"].ConnectionString;
                    using (SqlConnection con = new SqlConnection(conString))
                    {
                        using (SqlDataAdapter sda = new SqlDataAdapter(sql, con))
                        {
                            using (DataTable dt = new DataTable())
                            {
                                sda.Fill(dt);
                                ddlLocation.DataSource = dt;
                                ddlLocation.DataTextField = "ReqLocation";
                                ddlLocation.DataValueField = "pkReqLocID";
                                ddlLocation.DataBind();
                                string selectedLocation = DataBinder.Eval(e.Row.DataItem, "LocName").ToString();
                                ddlLocation.Items.FindByValue(selectedLocation).Selected = true;
                            }
                        }
                    }
                }


                if (lblLocID.Text != "")
                {
                    //RadComboBoxItem item = null;
                    var query = from val in locids.Split(',')
                                select int.Parse(val == "" ? "0" : val);
                    foreach (int num in query)
                    {
                        int index = ddlLocationto.FindItemIndexByValue(num.ToString());

                        if (index!=-1)
                        {

                            ddlLocationto.SelectedIndex = index;
                            ddlLocationto.SelectedValue = num.ToString();

                            //item = ddlLocationto.Items[num];
                            ddlLocationto.SelectedItem.Checked = true;
                        }
                        //Console.WriteLine(num);
                    }

                }


                ///Getting Employee Data

                if (ddlPersonto.CheckedItems.Count > 0)
                {
                    var collection = ddlPersonto.CheckedItems;
                    string empid = "";
                    string empname = "";

                    if (collection.Count != 0)
                    {
                        foreach (var item in collection)
                        {
                            empid = empid + item.Value.TrimEnd() + ",";
                            empname = empname + item.Text + ",";
                        }
                        Label lblPerson = (Label)e.Row.FindControl("lblPerson");

                        lblPerson.Text = empname;
                        //txtremarks.Text = empname;
                    }
                }

                if (ddlPersonto.Items.Count == 0)
                {
                        ddlPersonto.Attributes.Add("visible", "true");
                        //iman.Pkbrhid.ToString();
                        string sql = "SELECT pkempID,empName FROM tblEmployees where isactive=1 and fkbrhid=" + Reqman.Pkbrhid.ToString();

                        string conString = ConfigurationManager.ConnectionStrings["INVENTORY"].ConnectionString;

                        using (SqlConnection con = new SqlConnection(conString))
                        {
                            using (SqlDataAdapter sda = new SqlDataAdapter(sql, con))
                            {
                                using (DataTable dt = new DataTable())
                                {
                                    sda.Fill(dt);

                                    if (ddlPersonto != null)
                                    {
                                        ddlPersonto.DataSource = dt;
                                        ddlPersonto.DataTextField = "empName";
                                        ddlPersonto.DataValueField = "pkempID";
                                        ddlPersonto.DataBind();
                                        string selectedEmployee = DataBinder.Eval(e.Row.DataItem, "empName").ToString();
                                        if (selectedEmployee != "")
                                        {
                                            //ddlPersonto.Items.FindByValue(selectedEmployee).Selected = true;

                                            //ddlPersonto.Items.FindItemByValue(selectedEmployee).Selected = true;
                                        }
                                    }
                                }
                            }
                        }
                  }

                if (e.Row.RowType == DataControlRowType.DataRow && grdItems.EditIndex == e.Row.RowIndex)
                {
                        DropDownList ddlEmployee = (DropDownList)e.Row.FindControl("ddlPersonto");
                        string sql = "SELECT pkempID,empName FROM tblEmployees where isactive=1 and fkbrhid=" + Reqman.Pkbrhid.ToString();

                        string conString = ConfigurationManager.ConnectionStrings["INVENTORY"].ConnectionString;
                        using (SqlConnection con = new SqlConnection(conString))
                        {
                            using (SqlDataAdapter sda = new SqlDataAdapter(sql, con))
                            {
                                using (DataTable dt = new DataTable())
                                {
                                    sda.Fill(dt);
                                    ddlEmployee.DataSource = dt;
                                    ddlEmployee.DataTextField = "empName";
                                    ddlEmployee.DataValueField = "pkempID";
                                    ddlEmployee.DataBind();
                                    string selectedEmployee = DataBinder.Eval(e.Row.DataItem, "empName").ToString();
                                    ddlEmployee.Items.FindByValue(selectedEmployee).Selected = true;
                                }
                            }
                        }
                 }

                if (lblEmpID.Text != "")
                {
                    //RadComboBoxItem item = null;
                    var query = from val in empids.Split(',')
                                select int.Parse(val == "" ? "0" : val);
                    foreach (int num in query)
                    {
                        int index = ddlPersonto.FindItemIndexByValue(num.ToString());

                        if (index != -1)
                        {

                            ddlPersonto.SelectedIndex = index;
                            ddlPersonto.SelectedValue = num.ToString();

                            //item = ddlPersonto.Items[num];
                            ddlPersonto.SelectedItem.Checked = true;
                        }
                        //Console.WriteLine(num);
                    }

                }

                //if (UMan.Uid == 119 || UMan.Uid == 152)
                //{
                //    txtqut.Enabled = true;
                //}

                //ReqTypid = Convert.ToInt32(DataBinder.Eval(e.Row.DataItem, "fkReqSubTypID").ToString());
                //double tmpTotal = Convert.ToDouble(DataBinder.Eval(e.Row.DataItem, "Amount").ToString());

                //int checkrow = e.Row.RowIndex;

                //AmtTotal += tmpTotal;
                //grAmtTotal += tmpTotal;
            }


        }

        protected void grdItems_RowCreated(object sender, GridViewRowEventArgs e)
        {

        }

        public void AddNewRow(object sender, GridViewRowEventArgs e)
        {
            GridView GridView1 = (GridView)sender;
            GridViewRow NewTotalRow = new GridViewRow(0, 0, DataControlRowType.DataRow, DataControlRowState.Insert);
            NewTotalRow.Font.Bold = true;
            NewTotalRow.BackColor = System.Drawing.Color.DarkGreen;
            TableCell HeaderCell = new TableCell();
            HeaderCell.Height = 10;
            HeaderCell.HorizontalAlign = HorizontalAlign.Center;
            HeaderCell.ColumnSpan = 8;
            NewTotalRow.Cells.Add(HeaderCell);
            GridView1.Controls[0].Controls.AddAt(e.Row.RowIndex + rowIndex, NewTotalRow);
            rowIndex++;
        }


      

        protected void txtReqNo_TextChanged(object sender, EventArgs e)
        {
            iman.PrintQRF = int.Parse(txtReqNo.Text);
        }




        protected void cmbbranch_SelectedIndexChanged(object sender, Telerik.Web.UI.RadComboBoxSelectedIndexChangedEventArgs e)
        {
           

            if (cmbbranch.SelectedValue.ToString() != "Choose Branch")
            {
                //GetUserInfo();

                int brhid = int.Parse(cmbbranch.SelectedValue.ToString());

                GetReqType();

                cmbReqType.SelectedIndex = 0;

                int budgetID = int.Parse(cmbReqType.SelectedValue.ToString());

                GetReqNo(brhid, budgetID);

                Session["brhid"] = brhid;
              
                LoadRequisitionItems();

                btnSubmit.Text = "Save & Notify Branch";

                //itreqdiv.Style.Add("display", "none");
            }
           // Session["storid"] = GetStore();


            //grdItems.DataSource = null;
            //grdItems.DataBind();
            grdItems.Visible = true;

            btnSubmit.Visible = false;

        }

        #endregion


        #region Helper Methods

        private void SetupForm()
        {
           

            DataTable dt = new DataTable();
            ViewState["dt"] = dt;


            GetUserInfo();

            GetReqType();

            btnSubmit.Visible = false;

            txtDlvdate.Text = DateTime.Today.ToString("dd/MM/yyyy");

            UserSettings();

            //txtAppBudget.Text = "0";
            //txtAmountReq.Text = "0";

        }


        public void GetReqType()
        {
            if (Reqman.Pkdeptid == 0)
            {
                Reqman.Pkdeptid = UMan.Grpuserdeptid;
            }

           // GetUserInfo();



            cmbReqType.DataSource = Reqman.GetReqITType("IT",Reqman.Pkbrhid);   //General I.T Requisition
     
            cmbReqType.DataTextField = "ReqTitle";
            cmbReqType.DataValueField = "pkReqBudgID";
            cmbReqType.DataBind();

            Telerik.Web.UI.RadComboBoxItem hd = new Telerik.Web.UI.RadComboBoxItem();
            hd.Text = "Choose Requisition Type";
            hd.Value = "Choose Requisition Type";
            cmbReqType.Items.Add(hd);
            cmbReqType.SelectedIndex = cmbReqType.Items.Count - 1;

        }

        public void GetBudgetInfo(int budgetid)
        {
            GetUserInfo();

            GetReqNo(Reqman.Pkbrhid, budgetid);

            if (lblReqIds.Text =="Requisition No's: ()")
            {
                return;

            }

            //if (Reqman.Pkbrhid != 19)
            //{
            Reqman.Pkbrhid = 19;
                DataTable budgdt = Reqman.GetReqBudgetInfo(budgetid);

                Reqman.Pkbrhid = iman.Pkbrhid;


                Double BudAmt = 0;

                foreach (DataRow dr in budgdt.Rows)
                {
                    //txtReqtypeID.Text = dr["fkReqTypID"].ToString();
                    //txtSubReqtypeID.Text = dr["fkReqSubTypID"].ToString();
                    //txtReqtype.Text = dr["RequisitionType"].ToString();
                    //txtReqSubType.Text = dr["RequisitionSubType"].ToString();
                    //txtReqMonth.Text = dr["ReqMonths"].ToString();

                    //txtStrength.Text = dr["Strength"].ToString();

                    //txtStrength.Text = Reqman.GetStudStrength(Reqman.Pkbrhid).ToString();

                    //txtPerChildCost.Text = dr["PerHeadCostQuarterly"].ToString();
                    //txtAppCost.Text = "0";

                    //txtAppBudget.Text = dr["BudgetAmount"].ToString()=="" ? "0" : dr["BudgetAmount"].ToString();
                    //txtAmountBal.Text = dr["BalanceAmount"].ToString() == "" ? "0" : dr["BalanceAmount"].ToString();
                    //txtAmountReq.Text = Convert.ToString(double.Parse(txtAppBudget.Text) - double.Parse(txtAmountBal.Text));

                }
           // }
        
        }

        public int GetStore()
        {
            int brhid = iman.Pkbrhid == 0 ? Reqman.Pkbrhid : iman.Pkbrhid;
            
            iman.PkstoreID = iman.GetStores(brhid);
            Reqman.Pkstoreid = iman.PkstoreID;
            return iman.PkstoreID;
        }

        public void LoadBranches()
        {
            if (UMan.Ugid == 37)
            {
                if (cmbbranch.Items.Count == 0)
                {
                    cmbbranch.Visible = true;
                    cmbbranch.DataSource = sm.GetBranches();
                    cmbbranch.DataTextField = "BrhName";
                    cmbbranch.DataValueField = "pkbrhID";
                    cmbbranch.DataBind();

                    Telerik.Web.UI.RadComboBoxItem ib = new Telerik.Web.UI.RadComboBoxItem();
                    ib.Text = "Choose Branch";
                    ib.Value = "Choose Branch";
                    cmbbranch.Items.Add(ib);


                    //Reqman.Pkbrhid = int.Parse(cmbbranch.SelectedValue.ToString());
                }

                cmbbranch.SelectedIndex = cmbbranch.Items.Count - 1;
                //Reqman.Pkbrhid = UMan.Grpuserbrhid; ;

                // iman.Pkbrhid = int.Parse(cmbbranch.SelectedValue.ToString());
            }
            else
            {
                cmbbranch.Visible = false;
            }

        }

        public void GetUserInfo()
        {

            HttpCookie IMS = Request.Cookies["IMS"];
            if (IMS == null)
                Response.Redirect("logout.aspx");


            UMan.Uid = int.Parse(IMS["uid"]);
            UMan.Ubrhid = int.Parse(IMS["ubrhid"]);
            iman.Pkbrhid = int.Parse(IMS["ubrhid"]);
            iman.Pkdeptid = int.Parse(IMS["udptid"]);
            UMan.Ugid = int.Parse(IMS["ugroupid"]);

            UMan.Grpuserbrhid = int.Parse(IMS["grpuserbrhid"]);
            UMan.Grpuserdeptid = int.Parse( IMS["grpuserdptid"]);
            UMan.Grpuserstoreid = int.Parse(IMS["grpuserstoreid"]);

            Reqman.Pkbrhid = UMan.Grpuserbrhid;
            Reqman.Pkdeptid = UMan.Grpuserdeptid;
            Reqman.Pkstoreid = UMan.Grpuserstoreid;

            
            dbm.fkbrhid = iman.Pkbrhid;


            if (cmbbranch.SelectedValue.ToString() != "Choose Branch")
            {
                if (cmbbranch.SelectedValue.ToString()=="" || int.Parse(cmbbranch.SelectedValue.ToString()) == 0)
                {
                    LoadBranches();
                }                
            }
            if (UMan.Ugid == 37)
            {
                txtDlvdate.Enabled = true;
                btnDateExtend.Visible = true;
            // itreqdiv.Style.Add("display", "inline-block");
                

            }
            else
            {
                txtDlvdate.Enabled = false;
                ITReqDiv.Style.Add("display", "none");
                btnNewItem.Style.Add("display", "none");
                brhlabel.Style.Add("display", "none");
            }
            //List<string> MyList = dbm.GetUNRGinList();

            //var collection = MyList;

            //if (collection.Count != 0)
            //{
            //  //  ScriptManager.RegisterStartupScript(this, this.GetType(), "alert", "alert('You Have Pending GIN(s) at Your IMS Dashboard, No Transaction is Allowed Until All The Pending GIN Not Received!');window.location ='MainDashboard.aspx';", true);

            //    showMessageBox("You Have Pending GIN(s) at Your IMS Dashboard, No Transaction is Allowed Until All The Pending GIN Not Received!");
            //}


        }

        public int GetSysinfo()
        {
            HttpCookie IMS = Request.Cookies["IMS"];
            if (IMS == null)
                Response.Redirect("logout.aspx");


            int sysid = UMan.GetSysinfo(int.Parse(IMS["ubrhid"]));

            return sysid;

        }

        public int GetReqNo(int fkbrhid, int budgid=0)
        {
            string reqno;
            if (budgid == 0)
            {
                reqno = Reqman.GetRequisitionNo(fkbrhid);
            }
            else
            {
                reqno = Reqman.GetRequisitionNo(fkbrhid, budgid);
            }

            lblReqIds.Text = "Requisition No's: (" + reqno + ")";

            txtDlvdate.Text = Reqman.GetReqSubDate(fkbrhid, budgid).Substring(0, 10);

            if (reqno == "")
            {
                showMessageBox("No Active Record Found For This Requisition Type!!!");               
                txtReqNo.Text = "";
                lblReqIds.Text = "Requisition No's: (" + "" + ")";
                return 0;
            }

            DateTime d1 = DateTime.Parse(txtDlvdate.Text);
            DateTime d2 = DateTime.Parse(DateTime.Today.ToString("dd/MM/yyyy"));
            
            int res = DateTime.Compare(d1, d2);

            if (res < 1)
            {
                showMessageBox("Requisition Submission Date is Expire, Please Contact HO I.T Dept.");
                return 0;
            }
           

            int i = reqno.IndexOf(',');
            int len = reqno.Length;

            if (i > 0)
            {
                txtReqNo.Text = reqno.Substring(0, i);
            }
            else
            {
                txtReqNo.Text = reqno;
            }
            return int.Parse(txtReqNo.Text);
        
        }


        public bool checkItem(DataTable dt, String InvCode, string deptname)
        {
            bool returnval = false;

            foreach (DataRow dr in dt.Rows)
            {

                if ((dr["Item Code"].ToString() == InvCode) && ((dr["Issue to Department"].ToString() == deptname)))
                {
                    returnval = true;
                }

            }
            return returnval;
        }

        public bool checkItemBalance(DataTable dt, String InvCode, int balance, int qtyrecv)
        {
            bool returnval = false;

            //DataRow[] result = dt.Select("[Item Code] ='" + InvCode + "' AND [Issue to Department Id] =" + DeptID);

            DataRow[] result = dt.Select("[InvCode] ='" + InvCode + "'");

            int i = 0;

            foreach (DataRow row in result)
            {
                i = i + int.Parse(row["QtyRequired"].ToString());
            }

            if (balance < i)
                returnval = true;

            return returnval;
        }

        protected void LoadRequisitionItems()
        {
            GetUserInfo();



            //DataTable ItemRateData = Reqman.GetItemsByReqType(int.Parse(txtReqtypeID.Text), int.Parse(txtSubReqtypeID.Text));

            int brhid = UMan.Ubrhid;

            //if (cmbbranch.SelectedValue.ToString() != "Choose Branch" || cmbbranch.SelectedValue.ToString() !="")
            //{
            brhid = int.Parse(cmbbranch.SelectedValue.ToString() == "Choose Branch" || cmbbranch.SelectedValue.ToString() == "" ? "0" : cmbbranch.SelectedValue.ToString());
            //}



            if (brhid != 0 && Reqman.Pkbrhid != brhid)
            {
                Reqman.Pkbrhid = brhid;
            }

            Reqman.Pkdeptid = 10;

            DataTable ItemRateData;

            if (Reqman.Pkbrhid == 19)
            {
                if (ShowITReq.Checked)
                {
                    ItemRateData = Reqman.GetItemsByReqType(8,18);
                }
                else
                {
                    ItemRateData = Reqman.GetItemsByReqType(8, 27);
                }
               
            }
            else
            {

                ItemRateData = Reqman.GetItemsByReqType(8, 26);
            }


            ItemRateData.DefaultView.Sort = "fkitemid ASC";

            ItemRateData = ItemRateData.DefaultView.ToTable();

            if (ItemRateData.Rows.Count == 0)
            {
                showMessageBox("No Record Found For This Requisition Type!!!");
                lblReqIds.Text = "Requisition No's: (" + "" + ")";
                txtReqNo.Text = "";
            }
            else
            {

                ItemRateData.DefaultView.Sort = "ItemTitle Asc";
                ItemRateData = ItemRateData.DefaultView.ToTable();



                SetupGrid(ItemRateData);

                btnSubmit.Visible = true;
                btnExport.Visible = true;
            }




        }

        protected void SetupGrid(DataTable ItemTable)
        {
            grdItems.Visible = true;
            grdItems.DataSource = ItemTable;
            grdItems.DataBind();
            

          //  btnSave.Visible = true;

           

           // GetUserInfo();

            ViewState["dt"] = ItemTable;


           // CheckBudgetAmount(ItemTable);

            //GridViewHelper helper = new GridViewHelper(this.grdItems);
            //helper.RegisterSummary("In Stock Balance", SummaryOperation.Sum);

       //     helper.RegisterGroup("ItemHeadTitle", true, true);
       //     helper.ApplyGroupSort();

            grdItems.Focus();
           
        }

        protected void  CheckBudgetAmount(DataTable buddt)
        {
            Single esmt_amt = 0;

     

            foreach (DataRow row in buddt.Rows)
            {
                esmt_amt = esmt_amt + Single.Parse(row["Amount"].ToString());
            }

            //txtAmountReq.Text = esmt_amt.ToString();
            //txtAmountBal.Text = (Double.Parse(txtAppBudget.Text) - Double.Parse(txtAmountReq.Text)).ToString();

            //if (esmt_amt > Single.Parse(txtAppBudget.Text) && Reqman.Pkbrhid != 25)
            //{
            //    showMessageBox("You are Exceeding the Approved Budget Amount.....");            
            //}
 
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
                    TextBox lblQty = (TextBox)GR.FindControl("txtqty");
                    Label lblrat = (Label)GR.FindControl("lblrate");

                    //TextBox curTexbox = GR.FindControl("runqtty") as TextBox;

                     
        
                    Label lblLocToID = (Label)GR.FindControl("lblLocationToID");

                    Label lblbrhloc = (Label)GR.FindControl("lblLocation");


                    Label lblIsuToID = (Label)GR.FindControl("lblIssuedToID");

                    Label lblemployee = (Label)GR.FindControl("lblPerson");


                    TextBox txtrema = (TextBox)GR.FindControl("txtremarks");
                    //Label lblamt = (Label)GR.FindControl("lblamt");

                    RadComboBox thisLocRadCombo = (RadComboBox)GR.FindControl("ddlLocationto");

                    RadComboBox thisEmpRadCombo = (RadComboBox)GR.FindControl("ddlPersonto");


                    var loccollection = thisLocRadCombo.CheckedItems;
                    string locid = "";
                    string locname = "";

                    if (loccollection.Count != 0)
                    {
                        foreach (var item in loccollection)
                        {
                            locid = locid + item.Value.TrimEnd() + ",";
                            locname = locname + item.Text + ",";
                        }

                        lblbrhloc.Text = locname;
                        lblLocToID.Text = locid;
                    }


                    var empcollection = thisEmpRadCombo.CheckedItems;
                    string empid = "";
                    string empname = "";

                    if (empcollection.Count != 0)
                    {
                        foreach (var item in empcollection)
                        {
                            empid = empid + item.Value.TrimEnd() + ",";
                            empname = empname + item.Text + ",";
                        }

                        lblemployee.Text = empname;
                        lblIsuToID.Text = empid;
                    }



                    float itm_amount = 0.00F;

                    if (lblItem != null)
                    //string text1 = lblItem.Text;
                    {
                        string itemid = lblItem.Text;
                        string qtty = lblQty.Text;

                        lblrat.Text = "1";

                        string rat = float.Parse(lblrat.Text).ToString();

                        string brlocid = lblLocToID.Text;
                        string brloc = lblbrhloc.Text;

                        string isuid = lblIsuToID.Text;
                        string emp = lblemployee.Text;


                        string rema = txtrema.Text.TrimEnd() == "" ? null : txtrema.Text.TrimEnd();

                        itm_amount = float.Parse(qtty.ToString() == "" ? "0.00F" : qtty.ToString()) * float.Parse(rat.ToString());

                        DataRow[] ItemRow = ds.Tables[0].Select("fkItemID = '" + itemid + "'");

                        ItemRow[0]["QtyRequired"] = qtty == "" ? "0.00F" : qtty;
                        ItemRow[0]["Amount"] = itm_amount;

                        ItemRow[0]["LocToID"] = brlocid;
                        ItemRow[0]["LocName"] = brloc;

                        ItemRow[0]["IsuToID"] = isuid;
                        ItemRow[0]["empName"] = emp;

                        ItemRow[0]["Remarks"] = rema;

                    }
                }

            }

            return ds.Tables[0];

        }

        protected void showMessageBox(string message)
        {
            string sScript;
            message = message.Replace("'", "\'");
            sScript = String.Format("alert('{0}');", message);
            ScriptManager.RegisterStartupScript(this, this.GetType(), "alert", sScript, true);
        }

        public void UserSettings()
        {


            if (UMan.Ugid == 31 || UMan.Ugid == 32)
            {
                int sysid = GetSysinfo();

                cmbbranch.Visible = false;
            }

            if (UMan.Ugid==37)
            {
                cmbbranch.Visible = true;
               // itreqdiv.Style.Add("display", "inline-block");
                btnNewItem.Visible = true;
            }


        }

        protected void ShowGridTotal()
        {

            //GridViewHelper helper = new GridViewHelper(this.GridView1);
            //helper.RegisterSummary("ItemTotal", SummaryOperation.Sum);
        
        }


        #endregion


        private void ExportGridToExcel()
        {
            string textchoice = new string(' ', 50);

            textchoice = cmbReqType.Text;
            
            Response.Clear();
            Response.Buffer = true;
            Response.ClearContent();
            Response.ClearHeaders();
            Response.Charset = "";
            string FileName = new string(' ', 50);
            //FileName = textchoice + DateTime.Now + ".xls";
            FileName = textchoice + ".xls";

            StringWriter strwritter = new StringWriter();
            HtmlTextWriter htmltextwrtter = new HtmlTextWriter(strwritter);
            Response.Cache.SetCacheability(HttpCacheability.NoCache);
            Response.ContentType = "application/vnd.ms-excel";
            Response.AddHeader("Content-Disposition", "attachment;filename=" + FileName);
            grdItems.GridLines = GridLines.Both;
            grdItems.HeaderStyle.Font.Bold = true;
            grdItems.RenderControl(htmltextwrtter);
            Response.Write(strwritter.ToString());
            Response.End();

        }

        public override void VerifyRenderingInServerForm(Control control)
        {
            /* Confirms that an HtmlForm control is rendered for the specified ASP.NET
               server control at run time. */

            // This Method is associate with the Export Command of Grid to Excel, also an addition in HTML <@Page......  EnableEventValidation = "false" 
            //
        }

        //public override void VerifyRenderingInServerForm(Control control)
        //{
        //    return;
        //}

        protected void btnExport_Click(object sender, EventArgs e)
        {

            ExportGridToExcel();

            //Response.Clear();
            //Response.Buffer = true;
            //Response.AddHeader("content-disposition", "attachment;filename=GridViewExport.xls");
            //Response.Charset = "";
            //Response.ContentType = "application/vnd.ms-excel";
            //using (StringWriter sw = new StringWriter())
            //{
            //    HtmlTextWriter hw = new HtmlTextWriter(sw);

            //    //To Export all pages
            //    grdItems.AllowPaging = false;
            //    this.DataBind();
            //    //this.BindGrid();

            //    grdItems.HeaderRow.BackColor = Color.White;
            //    foreach (TableCell cell in grdItems.HeaderRow.Cells)
            //    {
            //        cell.BackColor = grdItems.HeaderStyle.BackColor;
            //    }
            //    foreach (GridViewRow row in grdItems.Rows)
            //    {
            //        row.BackColor = Color.White;
            //        foreach (TableCell cell in row.Cells)
            //        {
            //            if (row.RowIndex % 2 == 0)
            //            {
            //                cell.BackColor = grdItems.AlternatingRowStyle.BackColor;
            //            }
            //            else
            //            {
            //                cell.BackColor = grdItems.RowStyle.BackColor;
            //            }
            //            cell.CssClass = "textmode";
            //        }
            //    }

            //    grdItems.RenderControl(hw);

            //    //style to format numbers to string
            //    string style = @"<style> .textmode { } </style>";
            //    Response.Write(style);
            //    Response.Output.Write(sw.ToString());
            //    Response.Flush();
            //    Response.End();
            //}

        }


        protected void ExportToExcel(object sender, EventArgs e)
        {
            Response.Clear();
            Response.Buffer = true;
            Response.AddHeader("content-disposition", "attachment;filename=GridViewExport.xls");
            Response.Charset = "";
            Response.ContentType = "application/vnd.ms-excel";
            using (StringWriter sw = new StringWriter())
            {
                HtmlTextWriter hw = new HtmlTextWriter(sw);

                //To Export all pages
                grdItems.AllowPaging = false;

               // this.BindGrid();

                grdItems.HeaderRow.BackColor = Color.White;
                foreach (TableCell cell in grdItems.HeaderRow.Cells)
                {
                    cell.BackColor = grdItems.HeaderStyle.BackColor;
                }
                foreach (GridViewRow row in grdItems.Rows)
                {
                    row.BackColor = Color.White;
                    foreach (TableCell cell in row.Cells)
                    {
                        if (row.RowIndex % 2 == 0)
                        {
                            cell.BackColor = grdItems.AlternatingRowStyle.BackColor;
                        }
                        else
                        {
                            cell.BackColor = grdItems.RowStyle.BackColor;
                        }
                        cell.CssClass = "textmode";
                    }
                }

                grdItems.RenderControl(hw);

                //style to format numbers to string
                string style = @"<style> .textmode { } </style>";
                Response.Write(style);
                Response.Output.Write(sw.ToString());
                Response.Flush();
                Response.End();
            }
        }

 
        protected void ddlPersonto_ItemChecked(object sender, Telerik.Web.UI.RadComboBoxItemEventArgs e)
        {

        }

        protected void btnPost_Click(object sender, EventArgs e)
        {

        }

        protected void btnDateExtend_Click(object sender, EventArgs e)
        {
            string extdate = txtDlvdate.Text;

            HttpCookie IMS = Request.Cookies["IMS"];

            Reqman.Pkdeptid = int.Parse(IMS["grpuserdptid"]);
            Reqman.Uid = int.Parse(IMS["uid"]);

            if (cmbbranch.SelectedValue.ToString() == "Choose Branch")
            {
                Reqman.ExtendReqDate(txtReqNo.Text, extdate, "ALL");
            }
            else
            {
                Reqman.ExtendReqDate(txtReqNo.Text, extdate, "");
            }

            showMessageBox("Requisition Date Successfully Extended");
        }

        protected void ShowITReq_CheckedChanged(object sender, EventArgs e)
        {
            LoadRequisitionItems();
        }

        protected void btnNewItem_Click(object sender, EventArgs e)
        {

            if (btnNewItem.Text == "Add Item Into Requisition")
            {
                btnNewItem.Text = "Refresh Items List";
                Response.Write("<script>window.open ('Item.aspx','_blank');</script>");
            }
            else
            {
                btnNewItem.Text = "Add Item Into Requisition";
                LoadRequisitionItems();
            }
        }

        protected void btnClose_Click(object sender, EventArgs e)
        {
            Response.Redirect("Main.aspx");
        }

        
      

    }
}