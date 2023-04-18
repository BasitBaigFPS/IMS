﻿using System;
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
using BLL;
using System.Data;


namespace IMS
{
    public partial class RequisitionsTest : System.Web.UI.Page
    {
        
            
        UserManager UMan = new UserManager();
        ItemManager im = new ItemManager();
        IMSManager iman = new IMSManager();
        StoreManager sm = new StoreManager();
        RequisitionManager Reqman = new RequisitionManager();

        //private GridViewHelper helper;

        // To keep track of the previous row Group Identifier
        int intPreviousRowID = 0;
        // To keep track the Index of Group Total
        int intSubTotalIndex = 1;

        int groupno;


        double AmtTotal = 0;
        double grAmtTotal = 0;

        int ReqTypid = 0;
        int rowIndex = 0;
        bool newRow;
        
        int mysysid;

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

            txtAppBudget.Text = "0";
            txtAmountReq.Text = "0";

        }


        public void GetReqType()
        {
            
            cmbReqType.DataSource = Reqman.GetReqType("RT");
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

            //if (Reqman.Pkbrhid != 19)
            //{

                DataTable budgdt = Reqman.GetReqBudgetInfo(budgetid);


                Double BudAmt = 0;

                foreach (DataRow dr in budgdt.Rows)
                {
                    txtReqtypeID.Text = dr["fkReqTypID"].ToString();
                    txtSubReqtypeID.Text = dr["fkReqSubTypID"].ToString();
                    txtReqtype.Text = dr["RequisitionType"].ToString();
                    txtReqSubType.Text = dr["RequisitionSubType"].ToString();
                    txtReqMonth.Text = dr["ReqMonths"].ToString();

                    //txtStrength.Text = dr["Strength"].ToString();

                    txtStrength.Text = Reqman.GetStudStrength(Reqman.Pkbrhid).ToString();

                    txtPerChildCost.Text = dr["PerHeadCostQuarterly"].ToString();
                    txtAppCost.Text = "0";

                    //txtAppBudget.Text = dr["BudgetAmount"].ToString();

                    //if (txtSubReqtypeID.Text == "6")
                    //{
                    //    txtAppBudget.Text = dr["BudgetAmount"].ToString();
                    //    txtAmountReq.Text = "";
                    //}
                    //else
                    //{
                    //    BudAmt = ((int.Parse(txtStrength.Text) * int.Parse(txtPerChildCost.Text)) - int.Parse(dr["BudgetAmount"].ToString()));
                    //    txtAppBudget.Text = BudAmt.ToString();
                    //    txtAmountReq.Text = "";
                    //}

                    txtAppBudget.Text = dr["BudgetAmount"].ToString()=="" ? "0" : dr["BudgetAmount"].ToString();
                    txtAmountReq.Text = "0";

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

        public void GetUserInfo()
        {

            HttpCookie IMS = Request.Cookies["IMS"];
            if (IMS == null)
                Response.Redirect("logout.aspx");


            UMan.Uid = int.Parse(IMS["uid"]);
            iman.Pkbrhid = int.Parse(IMS["ubrhid"]);
            iman.Pkdeptid = int.Parse(IMS["udptid"]);
            UMan.Ugid = int.Parse(IMS["ugroupid"]);
            
            Reqman.Pkbrhid = int.Parse(IMS["ubrhid"]);


            if (UMan.Ugid == 27 || UMan.Ugid == 29 || UMan.Ugid == 39)
            {
                cmbbranch.Visible = true;
                cmbbranch.DataSource = sm.GetBranches();
                cmbbranch.DataTextField = "BrhName";
                cmbbranch.DataValueField = "pkbrhID";
                cmbbranch.DataBind();
            }
            else
            {
                cmbbranch.Visible = false;
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

        public int GetReqNo(int fkbrhid)
        {
            int reqno = 0;
            //int reqno = Reqman.GetRequisitionNo(fkbrhid);

            //txtReqNo.Text = reqno.ToString();
            return reqno;
        
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


        protected void SetupGrid(DataTable ItemTable)
        {
            grdItems.DataSource = ItemTable;
            grdItems.DataBind();
            grdItems.Visible = true;

          //  btnSave.Visible = true;

            GetUserInfo();

            ViewState["dt"] = ItemTable;


            CheckBudgetAmount(ItemTable);

            GridViewHelper helper = new GridViewHelper(this.grdItems);
            helper.RegisterSummary("In Stock Balance", SummaryOperation.Sum);

            helper.RegisterGroup("ItemHeadTitle", true, true);
            helper.ApplyGroupSort();

            grdItems.Focus();
           
        }

        protected void  CheckBudgetAmount(DataTable buddt)
        {
            Single esmt_amt = 0;

            foreach (DataRow row in buddt.Rows)
            {
                esmt_amt = esmt_amt + Single.Parse(row["Amount"].ToString());
            }

            txtAmountReq.Text = esmt_amt.ToString();
            txtAmountBal.Text = (Double.Parse(txtAppBudget.Text) - Double.Parse(txtAmountReq.Text)).ToString();

            if (esmt_amt > Single.Parse(txtAppBudget.Text) && Reqman.Pkbrhid != 19)
            {
                showMessageBox("You are Exceeding the Approved Budget Amount.....");            
            }
 
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
            }


        }

        protected void ShowGridTotal()
        {

            //GridViewHelper helper = new GridViewHelper(this.GridView1);
            //helper.RegisterSummary("ItemTotal", SummaryOperation.Sum);
        
        }


        #endregion


        #region Events

        protected void Page_Load(object sender, EventArgs e)
        {
            if (Page.IsPostBack == false)
            {
                SetupForm();
            }



        }

        protected void btnConfirm_Click(object sender, EventArgs e)
        {
            GetUserInfo();

            DataTable ItemRateData = Reqman.GetItemsByReqType(int.Parse(txtReqtypeID.Text), int.Parse(txtSubReqtypeID.Text));

            if (ItemRateData.Rows.Count == 0)
            {
                showMessageBox("No Record Found For This Requisition Type!!!");
            }
            else
            {

                SetupGrid(ItemRateData);

                btnSubmit.Visible = true;
            }

        }

        protected void cmbReqType_SelectedIndexChanged(object sender, Telerik.Web.UI.RadComboBoxSelectedIndexChangedEventArgs e)
        {
            GetBudgetInfo(int.Parse(cmbReqType.SelectedValue.ToString()));
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
                        //Label lblamt = (Label)GR.FindControl("lblamt");

                        double itm_amount = 0;
                        if (lblItem != null)
                        //string text1 = lblItem.Text;
                        {
                            string itemid = lblItem.Text;
                            string qtty = lblQty.Text;
                            string rat = lblrat.Text;

                            itm_amount = Double.Parse(qtty.ToString()) * Double.Parse(rat.ToString());

                            DataRow[] ItemRow = ds.Tables[0].Select("fkItemID = '" + itemid + "'");

                            ItemRow[0]["QtyRequired"] = qtty;
                            ItemRow[0]["Amount"] = itm_amount;

                        }
                    }

            }

            return ds.Tables[0];
        
        }



        protected void btnSubmit_Click(object sender, EventArgs e)
        {
            HttpCookie IMS = Request.Cookies["IMS"];
            if (IMS == null)
                Response.Redirect("logout.aspx");

            DataTable dt1 = (DataTable)ViewState["dt"];

            DataTable dt = SetDataTable(dt1);

            im.fkdepartid = int.Parse(IMS["udptid"] == null ? "0" : IMS["udptid"]);
            im.CreatedBy = int.Parse(IMS["uid"]);

            int reqno = 0;


            GetUserInfo();
            GetStore();



             bool budgetok;
             if (Reqman.Pkbrhid != 19)
             {
                 Reqman.Uid = int.Parse(IMS["uid"]);
                 Reqman.FkReqBudgID = int.Parse(cmbReqType.SelectedValue.ToString());
                 Reqman.StudStrength = int.Parse(txtStrength.Text);
                 Reqman.PerHeadCost = int.Parse(txtPerChildCost.Text);
                 Reqman.BudgetAmount = Double.Parse(txtAppBudget.Text);
                 Reqman.ExpDelivDate = txtDlvdate.Text.ToString();


                 budgetok = Reqman.CheckBudget(dt, Reqman.BudgetAmount);
             }
             else
             {

                 Reqman.Uid = int.Parse(IMS["uid"]);
                 Reqman.FkReqBudgID = int.Parse(cmbReqType.SelectedValue.ToString());
                 Reqman.StudStrength = int.Parse("0");
                 Reqman.PerHeadCost = int.Parse("0");
                 Reqman.BudgetAmount = Double.Parse("0");
                 Reqman.ExpDelivDate = txtDlvdate.Text.ToString();
                 
                 budgetok = true;
             }

            if (budgetok == true)
            {
                int i = Reqman.IURequistion(dt, ref reqno);
                showMessageBox("Requisition Has Been Successfully Generated!!!!! with Requisition Number : " + i.ToString());
                txtReqNo.Text = i.ToString();

                SetupForm();

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

        public void SetTotal()
        {
            double totreq=0;

            foreach (GridViewRow gr in grdItems.Rows)
            {
                totreq = totreq + double.Parse(gr.Cells[8].Text == "" ? "0" : gr.Cells[8].Text);
            }

            txtAmountReq.Text = totreq.ToString("{0:0,0.##}");

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

                            
                    Label lblCurrentListPrice = (Label)e.Row.FindControl("lblrate");
                    Double CurPr = Convert.ToDouble(lblCurrentListPrice.Text);
                    TextBox txtqut = (TextBox)e.Row.FindControl("txtqty");
                    Label lblTotal = (Label)e.Row.FindControl("lblamt");
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

                    //ReqTypid = Convert.ToInt32(DataBinder.Eval(e.Row.DataItem, "fkReqSubTypID").ToString());
                    //double tmpTotal = Convert.ToDouble(DataBinder.Eval(e.Row.DataItem, "Amount").ToString());

                    //int checkrow = e.Row.RowIndex;

                    //AmtTotal += tmpTotal;
                    //grAmtTotal += tmpTotal;
            }


            if (e.Row.RowType == DataControlRowType.Footer)
            {
                e.Row.Visible = true;
                Label lblTotalqty = (Label)e.Row.FindControl("lblTotalAmount");
                lblTotalqty.Text = txtAmountReq.Text;
            }

             //This is for calculation of column (Total = Direct + Referral)
            //if (e.Row.RowType == DataControlRowType.DataRow)
            //{
            //    intPreviousRowID = Convert.ToInt32(DataBinder.Eval(e.Row.DataItem, "Year").ToString());
            //    double dblDirectRevenue = Convert.ToDouble(DataBinder.Eval(e.Row.DataItem, "DirectRevenue").ToString());
            //    double dblReferralRevenue = Convert.ToDouble(DataBinder.Eval(e.Row.DataItem, "ReferralRevenue").ToString());
            //    Label lblTotalRevenue = ((Label)e.Row.FindControl("lblTotalRevenue"));
            //    lblTotalRevenue.Text = string.Format("{0:0.00}", (dblDirectRevenue + dblReferralRevenue));

            //    //dblSubTotalDirectRevenue += dblDirectRevenue;
            //    //dblSubTotalReferralRevenue += dblReferralRevenue;
            //    //dblSubTotalTotalRevenue += (dblDirectRevenue + dblReferralRevenue);
            //}


        }

        protected void grdItems_RowCreated(object sender, GridViewRowEventArgs e)
        {

            //bool newRow = false;
            //if ((ReqTypid > 0) && (DataBinder.Eval(e.Row.DataItem, "fkReqSubTypID") != null))
            //{
            //    if (ReqTypid != Convert.ToInt32(DataBinder.Eval(e.Row.DataItem, "fkReqSubTypID").ToString()))
            //        newRow = true;
            //}
            //if ((ReqTypid > 0) && (DataBinder.Eval(e.Row.DataItem, "fkReqSubTypID") == null))
            //{
            //    newRow = true;
            //    rowIndex = 0;
            //}

            //if (newRow)
            //{
            //    GridView GridView1 = (GridView)sender;
            //    GridViewRow NewTotalRow = new GridViewRow(0, 0, DataControlRowType.DataRow, DataControlRowState.Insert);
            //    NewTotalRow.Font.Bold = true;
            //    NewTotalRow.BackColor = System.Drawing.Color.Gray;
            //    NewTotalRow.ForeColor = System.Drawing.Color.White;
            //    TableCell HeaderCell = new TableCell();

            //    HeaderCell.Text = "Sub Total";
            //    HeaderCell.Font.Size = 14;
            //    HeaderCell.HorizontalAlign = HorizontalAlign.Left;
            //    HeaderCell.ColumnSpan = 7;
                
            //    NewTotalRow.Cells.Add(HeaderCell);
            //    HeaderCell = new TableCell();
            //    HeaderCell.HorizontalAlign = HorizontalAlign.Right;
            //    HeaderCell.Text = string.Format("{0:0.00}", AmtTotal);
            //    NewTotalRow.Cells.Add(HeaderCell);
            //    GridView1.Controls[0].Controls.AddAt(e.Row.RowIndex + rowIndex, NewTotalRow);
            //    rowIndex++;
            //    AmtTotal = 0;
            //}



            //bool IsTotalRowNeedToAdd = false;
            //bool IsGrandTotalRowNeedtoAdd = false;


            //if ((intPreviousRowID > 0) && (DataBinder.Eval(e.Row.DataItem, "fkReqSubTypID") != null))
            //    if (intPreviousRowID != Convert.ToInt32(DataBinder.Eval(e.Row.DataItem, "fkReqSubTypID").ToString()))
            //        IsTotalRowNeedToAdd = true;

            //if ((intPreviousRowID > 0) && (DataBinder.Eval(e.Row.DataItem, "fkReqSubTypID") == null))
            //{
            //    IsTotalRowNeedToAdd = true;
            //    intSubTotalIndex = 0;
            //    IsGrandTotalRowNeedtoAdd = true;
            //}

            //if (IsTotalRowNeedToAdd)
            //{
            //    groupno++;

            //    GridView grdView1 = (GridView)sender;

            //    // Creating a Row
            //    GridViewRow SubTotalRow = new GridViewRow(0, 0, DataControlRowType.DataRow, DataControlRowState.Insert);

            //    //Adding Total Cell
            //    TableCell HeaderCell = new TableCell();
            //    HeaderCell.Font.Size = 14;
            //    HeaderCell.Text = "Sub Total";
            //    HeaderCell.HorizontalAlign = HorizontalAlign.Left;
            //    HeaderCell.ColumnSpan = 7; // For merging first, second row cells to one
            //    HeaderCell.CssClass = "SubTotalRowStyle";
            //    SubTotalRow.Cells.Add(HeaderCell);

            //    //Adding Direct Revenue Column
            //    HeaderCell = new TableCell();
            //    HeaderCell.Text = string.Format("{0:0.00}", AmtTotal);
            //    HeaderCell.HorizontalAlign = HorizontalAlign.Right;
            //    HeaderCell.CssClass = "SubTotalRowStyle";
            //    SubTotalRow.Cells.Add(HeaderCell);


            //    if (groupno > 1 && intSubTotalIndex > 0)
            //    {
            //        intSubTotalIndex--;
            //    }

            //    //Adding the Row at the RowIndex position in the Grid
            //    grdView1.Controls[0].Controls.AddAt(e.Row.RowIndex + intSubTotalIndex, SubTotalRow);
            //    intSubTotalIndex++;

            //    AmtTotal = 0;


            //}




            //if (IsGrandTotalRowNeedtoAdd)
            //{
            //    GridView grdView1 = (GridView)sender;

            //    // Creating a Row
            //    GridViewRow GrandTotalRow = new GridViewRow(0, 0, DataControlRowType.DataRow, DataControlRowState.Insert);

            //    //Adding Total Cell
            //    TableCell HeaderCell = new TableCell();
            //    HeaderCell.Font.Size = 14;
            //    HeaderCell.Text = "Grand Total";
            //    HeaderCell.HorizontalAlign = HorizontalAlign.Left;
            //    HeaderCell.ColumnSpan = 7; // For merging first, second row cells to one
            //    HeaderCell.CssClass = "GrandTotalRowStyle";
            //    GrandTotalRow.Cells.Add(HeaderCell);

            //    //Adding Direct Revenue Column
            //    HeaderCell = new TableCell();
            //    HeaderCell.Text = string.Format("{0:0.00}", grAmtTotal);
            //    HeaderCell.HorizontalAlign = HorizontalAlign.Right;
            //    HeaderCell.CssClass = "GrandTotalRowStyle";
            //    GrandTotalRow.Cells.Add(HeaderCell);


            //    //Adding the Row at the RowIndex position in the Grid
            //    grdView1.Controls[0].Controls.AddAt(e.Row.RowIndex, GrandTotalRow);
            //}

   


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
            HeaderCell.ColumnSpan =8;
            NewTotalRow.Cells.Add(HeaderCell);
            GridView1.Controls[0].Controls.AddAt(e.Row.RowIndex + rowIndex, NewTotalRow);
            rowIndex++;
        }

        protected void cmbbranch_SelectedIndexChanged(object sender, Telerik.Web.UI.RadComboBoxSelectedIndexChangedEventArgs e)
        {
            Reqman.Pkbrhid = int.Parse(cmbbranch.SelectedValue.ToString());
            GetReqNo(Reqman.Pkbrhid);
            Session["brhid"] = Reqman.Pkbrhid;
            Session["storid"] = GetStore();

        }

        #endregion

        protected void txtReqNo_TextChanged(object sender, EventArgs e)
        {
           
        }

        protected void txtAmountReq_TextChanged(object sender, EventArgs e)
        {
            txtAmountBal.Text = (double.Parse(txtAppBudget.ToString()) - double.Parse(txtAmountReq.ToString())).ToString();
        }
    
    }
}