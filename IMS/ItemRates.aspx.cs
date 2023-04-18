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
using BLL;
using System.Data;

namespace IMS
{
    public partial class ItemRates : System.Web.UI.Page
    {
        UserManager UMan = new UserManager();
        ItemManager im = new ItemManager();
        IMSManager iman = new IMSManager();
        StoreManager sm = new StoreManager();
        RequisitionManager Reqman = new RequisitionManager();

        #region Events

        protected void Page_Load(object sender, EventArgs e)
        {

            if (!Page.IsPostBack)
            {
                btnApplyInventoryRate.Attributes.Add("onclick", "return ConfirmRate();");
                SetupForm();
            }


        }

        protected void btnConfirm_Click(object sender, EventArgs e)
        {
            GetUserInfo();

            string rstat = rdoRateState.SelectedValue;

            if (rstat=="E")
            {
                lblRatstat.Text = "Estimated Rate List";
            }
            else
            {
                lblRatstat.Text = "Actual Rate List";
            }

            if (chkHO.Checked == true)
            {
                Reqman.HORateToken = "HO";
            }
            else
            {
                Reqman.HORateToken = "BR";
            }



            DataTable ItemRateData = Reqman.GetItemsByRateState(int.Parse(cmbReqType.SelectedValue), rstat);

            if (ItemRateData.Rows.Count == 0)
            {
                showMessageBox("No Record Found For This Requisition Type!!!");
            }
            else
            {

                SetupGrid(ItemRateData);

                btnSubmit.Visible = true;
                btnRateApply.Visible = false;
                lblNote.Visible = true;
            }

        }

        protected void cmbReqType_SelectedIndexChanged(object sender, Telerik.Web.UI.RadComboBoxSelectedIndexChangedEventArgs e)
        {
           
            grdItems.Visible = false;
            btnSubmit.Visible = false;
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

        protected void txtrate_TextChanged(object sender, EventArgs e)
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
            ((TextBox)grdItems.Rows[NextRow].FindControl("txtrate")).Focus();

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

                string rstat = rdoRateState.SelectedValue;

                if (chkSyllabus.Checked == true)
                {
                    Reqman.IUSybItemRates(dt, rstat);
                }
                else
                {
                    Reqman.IUItemRates(dt, rstat);
                }

                showMessageBox("Item Rates Has Been Successfully Updated!!!!");

                btnRateApply.Visible = true;
            

                SetupForm();

                //ViewState["dt"] = null;
                //grdItems.DataSource = null;
                //grdItems.DataBind();
                grdItems.DataSource = dt;
                grdItems.DataBind();
                grdItems.Visible = true;

        }

        protected void grdItems_RowUpdated(object sender, GridViewUpdatedEventArgs e)
        {
            //int NextRow = 5;
            e.KeepInEditMode = true;
            GridView GridView1 = (GridView)sender;
            int currRow = GridView1.SelectedRow.RowIndex;
            ((TextBox)grdItems.Rows[currRow].FindControl("txtrate")).Focus();

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


                //Label lblCurrentListPrice = (Label)e.Row.FindControl("lblrate");
                //Double CurPr = Convert.ToDouble(lblCurrentListPrice.Text);
                TextBox txtrat = (TextBox)e.Row.FindControl("txtrate");
                //Label lblTotal = (Label)e.Row.FindControl("lblamt");

                //txtqut.Attributes.Add("onkeyup", "CalculateAmount(" + CurPr + ", '" + txtqut.ClientID + "','" + lblTotal.ClientID + "')");

                //txtqut.Attributes.Add("onblur", "MakeTotal('" + e.Row.RowIndex + "')");

                //txtrat.Attributes.Add("onkeyup", "return IsNumeric(event)");

                //txtrat.Attributes.Add("onblur", "return IsNumeric(event)");

                //GridViewRow NextRow = e.Row;
                string rowid = e.Row.RowIndex.ToString();

                txtrat.Attributes.Add("onkeydown", "return IsNumeric(event" + ",'" + rowid + "')");

            }

        }

        protected void grdItems_RowCreated(object sender, GridViewRowEventArgs e)
        {


        }

        protected void rdoRateState_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (rdoRateState.SelectedValue == "E")
            {
                ViewState["RateState"] = "Estimated ";
            } 
            else
            {
                ViewState["RateState"] = "Actual ";
            }

            string ratstat = (string)ViewState["RateState"];

            btnRateApply.Attributes.Add("onclick", "return Confirm('" + ratstat + "');");

            //btnRateApply.Attributes.Add("onclick", "return Confirm(&apos" + ratstat + "&apos);");
            //btnRateApply.Attributes.Add("onclick", "return Confirm(&quot" + ratstat + "&quot);");


            

        }

        protected void btnRateApply_Click(object sender, EventArgs e)
        {
          //To Implement this Javascirpt Login, the Button should be ASP button not RadControlButton.
            
            string ratstat = (string)ViewState["RateState"];

            if (chkSyllabus.Checked == true)
            {
                Reqman.ApplySybRates();
            }
            else
            {
                Reqman.ApplyRates();
            }

            showMessageBox(ratstat + " Rates Has Been Successfully Applied on Requisition Record!!!");


        }

        protected void btnApplyInventoryRate_Click(object sender, EventArgs e)
        {            
            Reqman.ApplyInventoryRates();

            showMessageBox("Rates Has Been Successfully Applied on All Branches & Warehouse Inventory/Stock!!!");
        }   

        #endregion


        #region Helper Methods

        private void SetupForm()
        {


            DataTable dt = new DataTable();
            ViewState["dt"] = dt;


            GetUserInfo();

            GetReqType();

            //btnRateApply.Visible = false;

            btnSubmit.Visible = false;


            UserSettings();

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

            Reqman.Pkbrhid = int.Parse(IMS["ubrhid"]);

            //IMS["grpuserdptid"] = um.Grpuserdeptid.ToString();
            //IMS["grpuserbrhid"] = um.Grpuserbrhid.ToString();
            //IMS["grpuserstoreid"] = um.Grpuserstoreid.ToString();


            //if (UMan.Ugid == 27 || UMan.Ugid == 29 || UMan.Ugid == 39)
            //{
            //    cmbbranch.Visible = true;
            //    cmbbranch.DataSource = sm.GetBranches();
            //    cmbbranch.DataTextField = "BrhName";
            //    cmbbranch.DataValueField = "pkbrhID";
            //    cmbbranch.DataBind();
            //}
            //else
            //{
            //    cmbbranch.Visible = false;
            //}

        }

        public void GetReqType()
        {
            if (iman.Pkdeptid==14)
            {
                cmbReqType.DataSource = Reqman.GetReqType("AL");
            }
            if (iman.Pkdeptid == 10)
            {
                cmbReqType.DataSource = Reqman.GetReqType("ITB");
            }
            

          
            cmbReqType.DataTextField = "ReqTitle";
            cmbReqType.DataValueField = "fkReqSubTypID";
            cmbReqType.DataBind();

            Telerik.Web.UI.RadComboBoxItem hd = new Telerik.Web.UI.RadComboBoxItem();
            hd.Text = "Choose Requisition Type";
            hd.Value = "Choose Requisition Type";
            cmbReqType.Items.Add(hd);
            cmbReqType.SelectedIndex = cmbReqType.Items.Count - 1;

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

        public int GetSysinfo()
        {
            HttpCookie IMS = Request.Cookies["IMS"];
            if (IMS == null)
                Response.Redirect("logout.aspx");


            int sysid = UMan.GetSysinfo(int.Parse(IMS["ubrhid"]));

            return sysid;

        }


        protected void SetupGrid(DataTable ItemTable)
        {
            grdItems.DataSource = ItemTable;
            grdItems.DataBind();
            grdItems.Visible = true;

            //  btnSave.Visible = true;

            GetUserInfo();

            ViewState["dt"] = ItemTable;


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
                    TextBox lblrat = (TextBox)GR.FindControl("txtrate");
                    
                    

                    double itm_amount = 0;
                    if (lblItem != null)
                    //string text1 = lblItem.Text;
                    {
                        string itemid = lblItem.Text;
                        string rat = lblrat.Text == "" ? "0" : lblrat.Text;
                        

                        itm_amount = Double.Parse(rat.ToString()) * Double.Parse(rat.ToString());

                        DataRow[] ItemRow = ds.Tables[0].Select("fkItemID = '" + itemid + "'");

                        ItemRow[0]["Rate"] = rat;
                         
                    }
                }

            }

            return ds.Tables[0];

        }

        #endregion

        protected void chkSyllabus_CheckedChanged(object sender, EventArgs e)
        {
            if (chkSyllabus.Checked == true)
            {
                //GetSybReqType(string token)

                cmbReqType.DataSource = Reqman.GetReqType("SY");
                cmbReqType.DataTextField = "ReqTitle";
                cmbReqType.DataValueField = "fkReqSubTypID";
                cmbReqType.DataBind();

                Telerik.Web.UI.RadComboBoxItem hd = new Telerik.Web.UI.RadComboBoxItem();
                hd.Text = "Choose Requisition Type";
                hd.Value = "Choose Requisition Type";
                cmbReqType.Items.Add(hd);
                cmbReqType.SelectedIndex = cmbReqType.Items.Count - 1;
            }
            else
            {
                GetReqType();
            }
        }

        protected void chkHO_CheckedChanged(object sender, EventArgs e)
        {
            //HORateToken
           
        }

  
       
    }
}