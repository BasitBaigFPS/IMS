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
    public partial class PurchaseOrderForm : System.Web.UI.Page
    {
        UserManager UMan = new UserManager();
        ItemManager im = new ItemManager();
        IMSManager iman = new IMSManager();
        StoreManager sm = new StoreManager();
        RequisitionManager Reqman = new RequisitionManager();

        POManager POMan = new POManager();

        decimal sumFooterValue = 0;

        #region PageEvents

        protected void Page_Load(object sender, EventArgs e)
        {

            if (!IsPostBack)
            {
                SetupForm();

                txtPODate.Value = Convert.ToDateTime(DateTime.Now.ToString()).ToString("yyyy-MM-dd");

                txtQuotDate.Value = Convert.ToDateTime(DateTime.Now.ToString()).ToString("yyyy-MM-dd");

                txtDelvDate.Value = Convert.ToDateTime(DateTime.Now.ToString()).ToString("yyyy-MM-dd");

                ddlAcdYear.SelectedIndex = 2;
                ddlDepartment.SelectedValue = "14";
            }
            else
            {
                string podate = txtPODate.Value;

               // txtQuotDate.Value = Convert.ToDateTime(DateTime.Now.ToString()).ToString("yyyy-MM-dd");

              //  txtDelvDate.Value = Convert.ToDateTime(DateTime.Now.ToString()).ToString("yyyy-MM-dd");

            }
        }

        protected void btnShowItemList_Click(object sender, EventArgs e)
        {

            btnShowItemList.Enabled = false;

            int fkacdid = int.Parse(ddlAcdYear.SelectedValue.ToString());
            int fkcomid=1;
            int fkcityid=1;
            string potype = "STN";
            int HOToken=0;

            if (chkfps.Checked==true)
            { fkcomid = 1; fkcityid = 1; }

            if (chkhyd.Checked == true)
            { fkcomid = 1; fkcityid = 2; }

            if (chkhss.Checked == true)
            { fkcomid = 2; fkcityid = 1; }

            if (chkho.Checked == true)
            { fkcomid = 1; fkcityid = 1; HOToken = 1; }

            if (optRegS.Checked==true)
            { potype = optRegS.Value; }

            if (optRegK.Checked == true)
            { potype = optRegK.Value; }

            if (optRegA.Checked == true)
            { potype = optRegA.Value; }

            if (optSyb.Checked == true)
            { potype = optSyb.Value; }

            DataTable POItemList = POMan.GetPOItemsByReqType(fkacdid, fkcomid, fkcityid, potype, HOToken);

            if (POItemList.Rows.Count == 0)
            {
                showMessageBox("No Record Found For This Requisition Type!!!");

            }
            else
            {

                SetupGrid(POItemList);
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

        protected void grdItems_RowDeleting(object sender, GridViewDeleteEventArgs e)
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

                Label lblCurrentListPrice = (Label)e.Row.FindControl("lblrate");
                TextBox txtqut = (TextBox)e.Row.FindControl("txtqty");
                Label lblDemandQty = (Label)e.Row.FindControl("lblqtyDemand");


                Double CurPr = Convert.ToDouble(lblCurrentListPrice.Text == "" ? "0" : lblCurrentListPrice.Text);

                Double InStockQtty = Convert.ToDouble(txtqut.Text == "" ? "0" : txtqut.Text);

                Double DemandQtty = Convert.ToDouble(lblDemandQty.Text == "" ? "0" : lblDemandQty.Text);


                Label lblPOQtty = (Label)e.Row.FindControl("lblpoqty");
                                
                Label lblTotal = (Label)e.Row.FindControl("lblamt");

                string rowid = e.Row.RowIndex.ToString();

                txtqut.Attributes.Add("onkeydown", "return IsNumeric(event" + ",'" + rowid + "')");

                txtqut.Attributes.Add("onkeyup", "CalculateAmount('" + lblCurrentListPrice.ClientID + "', '" + txtqut.ClientID + "','" + lblDemandQty.ClientID + "','" + lblPOQtty.ClientID + "','" + lblTotal.ClientID + "')");


                txtqut.Attributes.Add("onblur", "MakeTotal('" + e.Row.RowIndex + "','" + txtPOCost.ClientID + "','" + txtTotalAmount.ClientID + "','" +txtTotalQuantity.ClientID + "')");

                GridViewRow NextRow = e.Row;


                for (int i = 0; i < grdItems.Rows.Count - 1; i++)
                {
                    TextBox curTexbox = grdItems.Rows[i].Cells[5].FindControl("txtqty") as TextBox;
                    TextBox nexTextbox = grdItems.Rows[i + 1].Cells[5].FindControl("txtqty") as TextBox;
                    curTexbox.Attributes.Add("onkeypress", "return clickEnter('" + nexTextbox.ClientID + "', event)");

                    curTexbox.Attributes.Add("onfocusin", " select();");
                }
            }

            if (e.Row.RowType == DataControlRowType.DataRow)
            {
                Label lblAmt = (Label)e.Row.FindControl("lblTotalAmount");
                decimal Profitprice;
                //if (Decimal.TryParse(lblAmt.Text, out Profitprice))
                //{
                //    sumFooterValue += Profitprice;
                //}
            }
            if (e.Row.RowType == DataControlRowType.Footer)
            {
                Label lblTotalAmt = (Label)e.Row.FindControl("lblTotalAmt");
                //lblTotalAmt.Text = sumFooterValue.ToString();
            }

        }

        protected void txtqty_TextChanged(object sender, EventArgs e)
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

            for (int i = dt.Rows.Count - 1; i >= 0; i--)
            {
                DataRow dr = dt.Rows[i];
                if (float.Parse(dr["Amount"].ToString()) == 0)
                    dr.Delete();
            }
            dt.AcceptChanges();

     
            int POno = 0;

            POMan.VendorID = int.Parse(ddlvendor.SelectedValue.ToString());
            POMan.ExpDelivDate = txtDelvDate.Value;

            POMan.Pkdeptid = int.Parse(ddlDepartment.SelectedValue.ToString());
            POMan.POIssuDate = txtPODate.Value;
            POMan.QuotDate = txtQuotDate.Value;

            POMan.QuotID = int.Parse(txtQuot.Value=="" ? "0" : txtQuot.Value);
            POMan.ContPerson = contactname.Value;
            POMan.ShipAt = txtDelivAt.Value;
            POMan.TermsConditions = txtTermCond.Value;

            POMan.GrossAmount = double.Parse(txtPOCost.Value);

            POMan.NewPO = false;

            if(chkNewPO.Checked==true)
            {
                POMan.NewPO = true;
            }
            
            POno = POMan.IUPurchaseOrder(dt, ref POno);

            showMessageBox("Purchase Order Has Been Successfully Generated!!!!! with PO-Number : " + POno.ToString());
            txtPONO.Value = POno.ToString();

            ViewState["dt"] = null;
            grdItems.DataSource = null;
            grdItems.DataBind();

        }

        protected void btnBack_Click(object sender, EventArgs e)
        {

        }

        protected void btnReset_Click(object sender, EventArgs e)
        {

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
            iman.Pkbrhid = int.Parse(IMS["ubrhid"]);
            iman.Pkdeptid = int.Parse(IMS["udptid"]);
            UMan.Ugid = int.Parse(IMS["ugroupid"]);

            Reqman.Pkbrhid = int.Parse(IMS["ubrhid"]);
            Reqman.Pkdeptid = int.Parse(IMS["udptid"]);
        }

        private void SetupForm()
        {

            DataTable dt = new DataTable();
            ViewState["dt"] = dt;

            btnSubmit.Visible = false;

            btnShowItemList.Enabled = true;

            PopulateVendor();
            PopulateDepartment();

           // txtDlvdate.Text = DateTime.Today.ToString("dd/MM/yyyy");
        }

        private void PopulateVendor()
        {
            SqlConnection conn = new SqlConnection();
            SqlCommand cmd = new SqlCommand();

            conn.ConnectionString = SqlHelper.connectionstring;
            cmd.Connection = conn;

            DataSet ds;

            ds = SqlHelper.ExecuteDataset(conn, CommandType.Text, "SELECT pkVendID,VendorName,CPName1 FROM tblVendors where IsActive=1 order by VendorName");
 
            DataTable dt = ds.Tables[0];

            ddlvendor.CausesValidation = false;
            ddlvendor.DataSource = dt;
            ddlvendor.DataTextField = "VendorName";
            ddlvendor.DataValueField = "pkVendID";
            ddlvendor.DataBind();
            ddlvendor.Items.Insert(0, new ListItem("==Please Select==", "0"));

            conn.Close();

        }
       
        private void PopulateDepartment()
        {
            SqlConnection conn = new SqlConnection();
            SqlCommand cmd = new SqlCommand();

            conn.ConnectionString = SqlHelper.connectionstring;
            cmd.Connection = conn;

            DataSet ds;

            ds = SqlHelper.ExecuteDataset(conn, CommandType.Text, "SELECT pkdeptID,deptName FROM [INVENTORY].[dbo].[tblDepartments] where deptIsActive=1 order by deptName");

            DataTable dt = ds.Tables[0];


            ddlDepartment.CausesValidation = false;
            ddlDepartment.DataSource = dt;
            ddlDepartment.DataTextField = "deptName";
            ddlDepartment.DataValueField = "pkdeptID";
            ddlDepartment.DataBind();
            ddlDepartment.Items.Insert(0, new ListItem("==Please Select==", "0"));

            conn.Close();

        }

        protected void SetupGrid(DataTable ItemTable)
        {
            grdItems.DataSource = ItemTable;
            grdItems.DataBind();
            grdItems.Visible = true;

            txtPOCost.Value = "0";
            txtTotalAmount.Value = "0";
            txtTotalQuantity.Value = "0";

           
            float amttot=0;

            for (int i = 0; i < grdItems.Rows.Count - 1; i++)
            {
                GridViewRow row = new GridViewRow(i, i, DataControlRowType.DataRow, DataControlRowState.Normal);

                TableCell cellamt = new TableCell();
                cellamt.Text = ItemTable.Rows[i]["Amount"].ToString();
                
                
                //Label txtamt =   row. FindControl("lblamt") as Label;

                amttot = amttot + float.Parse(cellamt.Text == null ? "0" : cellamt.Text);

                txtPOCost.Value = amttot.ToString();
                txtTotalAmount.Value = amttot.ToString();
            }



            ViewState["dt"] = ItemTable;

            GridViewHelper helper = new GridViewHelper(this.grdItems);
            helper.RegisterSummary("In Stock Balance", SummaryOperation.Sum);

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
                    CheckBox chkRow = (GR.Cells[0].FindControl("ChkRow") as CheckBox);

                    int rowid = GR.RowIndex;

                    Label lblItem = (Label)GR.FindControl("lblItemID");
                    TextBox txtQty = (TextBox)GR.FindControl("txtqty");
                    Label lblQty = (Label)GR.FindControl("lblpoqty");

                    Label lblrat = (Label)GR.FindControl("lblrate");

                    //TextBox txtrema = (TextBox)GR.FindControl("txtremarks");
                    Label lblamt = (Label)GR.FindControl("lblamt");

                    if (chkRow.Checked)
                    {                        
                        //pkreqpoID


                        double itm_amount = 0;
                        if (lblItem != null)
                        //string text1 = lblItem.Text;
                        {
                            string itemid = lblItem.Text;
                            string qttyd = lblQty.Text;
                            string qtty = txtQty.Text;
                            string rat = lblrat.Text;
                            double poqtty;
                            //string rema = txtrema.Text.TrimEnd() == "" ? null : txtrema.Text.TrimEnd();

                            poqtty = Double.Parse(qttyd == "" ? "0" : qttyd) - Double.Parse(qtty == "" ? "0" : qtty);

                            itm_amount = poqtty * Double.Parse(rat.ToString());

                            // itm_amount = Double.Parse(lblamt.Text);

                            DataRow[] ItemRow = ds.Tables[0].Select("fkItemID = '" + itemid + "'");

                            ItemRow[0]["InStock"] = qtty == "" ? "0" : qtty;
                            ItemRow[0]["POQuantity"] = poqtty;
                            ItemRow[0]["Amount"] = itm_amount;
                            // ItemRow[0]["Remarks"] = rema;

                        }

                    }
                    else
                    {
                        string skipitemid = lblItem.Text;
                        DataRow[] ItemRow = ds.Tables[0].Select("fkItemID = '" + skipitemid + "'");
                        ItemRow[0]["POQuantity"] = 0;
                        ItemRow[0]["Amount"] = 0;
                    }

                }

            }

            return ds.Tables[0];

        }


        #endregion

        //protected void txtPODate_PreRender(object sender, EventArgs e)
        //{
        //    //txtPODate.Attributes["min"] = DateTime.Now.ToString("yyyy-MM-dd");
        //}

        protected void txtDelvDate_PreRender(object sender, EventArgs e)
        {
           // txtDelvDate.Attributes["min"] = DateTime.Now.ToString("yyyy-MM-dd");
        }

        protected void txtQuotDate_PreRender(object sender, EventArgs e)
        {
            //txtQuotDate.Attributes["min"] = DateTime.Now.ToString("yyyy-MM-dd");
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

        protected void txtOrdqty_TextChanged(object sender, EventArgs e)
        {

        }

    }
 
}