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
using System.Text;
using BLL;

namespace IMS
{
    public partial class InventoryStatus : System.Web.UI.Page
    {
        UserManager UMan = new UserManager();
        ItemManager im = new ItemManager();
        IMSManager iman = new IMSManager();

        DataTable di;
        int mysysid;
        string multiname;

        #region Helper Methods

        public void GetUserInfo()
        {

            HttpCookie IMS = Request.Cookies["IMS"];
            if (IMS == null)
                Response.Redirect("logout.aspx");


            UMan.Uid = int.Parse(IMS["uid"]);
            UMan.Ubrhid = int.Parse(IMS["ubrhid"]);
            UMan.Pkdeptid = int.Parse(IMS["udptid"]);
            UMan.Ugid =  int.Parse(IMS["ugroupid"]);

            UMan.Grpuserdeptid = int.Parse(IMS["grpuserdptid"]);
            UMan.Grpuserbrhid = int.Parse(IMS["grpuserbrhid"]);
            UMan.Grpuserstoreid = int.Parse(IMS["grpuserstoreid"]);


            iman.Pkbrhid = UMan.Grpuserbrhid;

            //if (UMan.Uid != 1527 && UMan.Uid != 93 && UMan.Uid != 105 && UMan.Uid != 152 && UMan.Uid != 95)
            //{
            //    ScriptManager.RegisterStartupScript(this, this.GetType(), "redirect", "alert('Please Use Desktop IMS Version for Goods Issue Note (GIN), Thank You :)'); window.location='" + Request.ApplicationPath + "/Main.aspx';", true);
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

   
        public void SearchItems()
        {
            
                              
                GetUserInfo();
                im.fkdepartid = UMan.Pkdeptid;

                if (im.fkdepartid == 14 && UMan.Ubrhid == 19)
                {
                    im.Token = "SM";
                }
                if (im.fkdepartid == 10 && UMan.Ubrhid == 19)
                {
                    im.Token = "IT";
                }

                if (im.Token != null)
                {
                    im.fkstoreid = im.GetStore(UMan.Ubrhid, im.Token);

                    im.pksysID = GetSysinfo();

                    di = im.GetStoreInventory(im.fkstoreid, im.fkdepartid);
                }
                else
                {
                    im.pksysID = GetSysinfo();
                    im.fkbrhid = UMan.Ubrhid;
                    di = im.GetDeptInventory(im.fkdepartid,im.fkbrhid,0);

                }



                    if (di.Rows.Count > 0)
                    {
                        cmbItemSearch.Items.Clear();

                        cmbItemSearch.DataSource = di;
                        cmbItemSearch.DataTextField = "ItemTitle";
                        cmbItemSearch.DataValueField = "InventoryCode";
                        cmbItemSearch.DataBind();
                        cmbItemSearch.ItemsPerRequest = 10;

                        ViewState["di"] = di;
                    }
                
                
        }

        private void SetupForm()
        {

            DataTable dt = new DataTable();
            ViewState["dt"] = dt;


            HttpCookie IMS = Request.Cookies["IMS"];
            if (IMS == null)
                Response.Redirect("logout.aspx");
            
            GetUserInfo();

            UserSettings();

            SearchItems();

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
           
        }

        #endregion

        #region Events 
        
        protected void Page_Load(object sender, EventArgs e)
        {
            if (Page.IsPostBack == false)
            {
                String isutype = Request.QueryString["issuetype"];
                SetupForm();
            }
        }

        protected void grdItems_NeedDataSource(object sender, Telerik.Web.UI.GridNeedDataSourceEventArgs e)
        {



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

                Label lblCurrentBalance = (Label)e.Row.FindControl("lblbalance");
                Double CurBal = Convert.ToDouble(lblCurrentBalance.Text);
                TextBox txtqut = (TextBox)e.Row.FindControl("txtqty");

                string rowid = e.Row.RowIndex.ToString();

                txtqut.Attributes.Add("onkeydown", "return IsNumeric(event" + ",'" + rowid + "')");


                txtqut.Attributes.Add("onkeyup", "return CheckBalance(" + CurBal + ",'" + rowid + "')");

                GridViewRow NextRow = e.Row;


                for (int i = 0; i < grdItems.Rows.Count - 1; i++)
                {
                    TextBox curTexbox = grdItems.Rows[i].Cells[4].FindControl("txtqty") as TextBox;
                    TextBox nexTextbox = grdItems.Rows[i + 1].Cells[4].FindControl("txtqty") as TextBox;
                    curTexbox.Attributes.Add("onkeypress", "return clickEnter('" + nexTextbox.ClientID + "', event)");

                    curTexbox.Attributes.Add("onfocusin", " select();");
                }

            }

        }

        protected void txtqty_TextChanged(object sender, EventArgs e)
        {

            //TextBox thisTextBox = (TextBox)sender;
            //GridViewRow currentRow = (GridViewRow)thisTextBox.Parent.Parent;
            //int rowindex = 0;
            //rowindex = currentRow.RowIndex;

            //DataTable dt = (DataTable)ViewState["dt"];

            //bool chkb = false;

            //if (Single.Parse(thisTextBox.Text) <= Single.Parse(dt.Rows[rowindex]["Balance"].ToString()))
            //{
            //    dt.Rows[rowindex]["Qty Issued"] = Single.Parse(thisTextBox.Text);
            //    ViewState["dt"] = dt;

            //    chkb = checkItemBalance(dt, dt.Rows[rowindex]["Item Code"].ToString(), int.Parse(dt.Rows[rowindex]["Issue Store Id"].ToString()), Single.Parse(dt.Rows[rowindex]["Balance"].ToString()), Single.Parse(thisTextBox.Text));

            //    if (chkb == false)
            //    {
            //        dt.Rows[rowindex]["Qty Issued"] = Single.Parse(thisTextBox.Text);
            //        ViewState["dt"] = dt;
            //    }

            //    else
            //    {
            //        thisTextBox.Text = "0";
            //        showMessageBox("Please Enter Qty Less than Total Current Balance");
            //    }

            //}

            //else
            //{
            //    thisTextBox.Text = "0";
            //    showMessageBox("Please Enter Qty Less than Total Current Balance");
            //}


        }

        protected void btnSubmitItem_Click(object sender, EventArgs e)
        {
           // ShowCheckedItems(cmbPersonto, staffClientSide);

            ShowCheckedItems(cmbItemSearch, itemsClientSide);

        }

        public void ConfirmItemEntry(string itemcode, string itemname, int listno)
        {
            if (Page.IsValid)
            {
                if (di == null || di.Rows.Count == 0)
                {
                    di = (DataTable)ViewState["di"];
                }

                DataTable dt = (DataTable)ViewState["dt"];
                DataTable ib;

                GetUserInfo();

                if (dt.Columns.Count == 0)
                {

                    dt.Columns.Add("Item Code", typeof(string));
                    dt.Columns.Add("Item Name", typeof(string));
                    dt.Columns.Add("Balance", typeof(Single));
                    dt.Columns.Add("Qty Issued", typeof(Single));

                }

                int tr = int.Parse(dt.Rows.Count.ToString());

                if (dt.Rows.Count > 0)
                {
                        DataRow dr = dt.NewRow();

                        dr["Item Code"] = itemcode;
                        dr["Item Name"] = itemname;

                        DataRow[] ItemRow = di.Select("[InventoryCode] ='" + itemcode + "'");

                        dr["Balance"] = Single.Parse(ItemRow[0]["CurrentBalance"].ToString() == "" ? "0" : ItemRow[0]["CurrentBalance"].ToString());
                        dr["Qty Issued"] = 0;

                        dt.Rows.Add(dr);

                }

                else
                {

                    DataRow dr = dt.NewRow();

                    dt.Rows.Add(dr);

                    dr["Item Code"] = itemcode;
                    dr["Item Name"] = itemname;

                    DataRow[] ItemRow = di.Select("[InventoryCode] ='" + itemcode + "'");

                   // int rn = int.Parse(ItemRow[0].ToString());

                    
                    dr["Balance"] = Single.Parse(ItemRow[0]["CurrentBalance"].ToString() == "" ? "0" : ItemRow[0]["CurrentBalance"].ToString());
                    dr["Qty Issued"] = 0;

                    //dt.Rows.Add(dr);

                    
                }

                if (dt.Rows.Count == listno)
                {
                    mirdiv.Style.Add("display", "inline");

                    ViewState["dt"] = SetDataTable(dt);
                    grdItems.DataSource = dt;
                    grdItems.DataBind();

                    grdItems.Visible = true;
                }
                //txtginno.Text = "6";

            }
     

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
                    Label lblBal = (Label)GR.FindControl("lblBalance");
                    TextBox lblQty = (TextBox)GR.FindControl("txtqty");

                    if (lblItem != null && lblItem.Text != "")
                    {
                        string itemid = lblItem.Text;
                        string qtty = lblQty.Text;
                        float bal = float.Parse(lblBal.Text == "" ? "0" : lblBal.Text);


                        DataRow[] ItemRow = ds.Tables[0].Select("[Item Code] ='" + itemid + "'");

                        ItemRow[0]["Qty Issued"] = qtty == "" ? "0" : qtty;

                        // ItemRow[0]["Qty Received"] = float.Parse(qtty) > bal ? lblBal.Text : qtty;
                    }
                }

            }

            return ds.Tables[0];

        }


        private DataTable RemoveZeroQtty(DataTable dt)
        {

            for (int i = dt.Rows.Count - 1; i >= 0; i--)
            {
                DataRow dr = dt.Rows[i];
                if (dr["Qty Issued"].ToString() == "0")
                    dr.Delete();
            }

            return dt;

        }

        protected void btnConfirm_Click(object sender, EventArgs e)
        {

            HttpCookie IMS = Request.Cookies["IMS"];
            if (IMS == null)
                Response.Redirect("logout.aspx");


            DataTable dt = (DataTable)ViewState["dt"];


            dt = SetDataTable(dt);

            dt = RemoveZeroQtty(dt);

            if (dt.Rows.Count == 0)
            {
                showMessageBox("Add Items first!!!!!");
            }
            else
            {

                im.fkdepartid = int.Parse(IMS["udptid"] == null ? "0" : IMS["udptid"]);
                im.CreatedBy = int.Parse(IMS["uid"]);

                
                if (rdoGIN.SelectedValue == "O")
                {
                    im.OLDGIN = int.Parse(txtginno.Text);
                    im.Token = "A";
                }
                else
                { 
                    im.Token = "I";
                }
                

                int get_GINNo = 0;

                GetUserInfo();

                if (im.fkdepartid != 17 && im.fkdepartid != 22)
                {

                    im.fkstoreid = im.GetStore(UMan.Ubrhid, "SM");
                    im.fkdepartid = 14;
                }

                if (UMan.Pkdeptid != 14 && UMan.Pkdeptid != 10 && UMan.Pkdeptid != 22 && UMan.Pkdeptid != 17 && UMan.Ubrhid == 19)
                {
                    im.fkstoreid = 2;
                }
                if (UMan.Pkdeptid == 10 && UMan.Ubrhid == 19)
                {
                    im.fkstoreid = 22;
                    im.fkdepartid = 10;
                }
               


                im.fkIssueByDeptID = im.fkdepartid;

                im.fkIssueToDeptID = im.fkdepartid; 

             

                im.fkIssueByBranchID = UMan.Grpuserbrhid;
                im.fkIssueToBranchID =UMan.Grpuserbrhid;

                im.fkIssueByID = UMan.Uid;

                txtpersonid.Text = UMan.Uid.ToString();

               // im.fkIssuedToID = int.Parse(cmbPersonto.SelectedValue.ToString() == "" ? im.CreatedBy.ToString() : cmbPersonto.SelectedValue.ToString());
                im.IssuedStatus = "P";
                im.IssuedType = "I";
                im.Remarks = txtremarks.Text;
                im.IssuetoID = txtpersonid.Text;
                im.Itemstatustype = cmbStatusType.SelectedValue;

                im.ItemStatusUpdate(dt);

                int storeid = im.fkstoreid;

                //if (im.fkIssueByDeptID == 14 && im.fkIssueByID == 1527)
                //{
                //    storeid = 1;
                //}

                //if (im.fkIssueByDeptID == 10)
                //{
                //    storeid = 22;
                //}
                //if (im.fkIssueByID == 94)
                //{
                //    storeid = 2;
                //}


                int i;  // im.RptSerial(im.fkIssueByBranchID, storeid, im.fkIssueByDeptID, 3, im.IssuedStatus);

                if (im.OLDGIN != 0)
                {
                    i = im.OLDGIN;
                }
                else
                {
                    i = im.RptSerial(im.fkIssueByBranchID, storeid, im.fkIssueByDeptID, 3, im.IssuedStatus);
                }

                showMessageBox("Record Successfully Saved, Your (GIN) Goods Issued Note # is : " + i.ToString());

                txtginno.Text = i.ToString();
                txtginno.Enabled = false;

                im.SendReportEmail(im.fkIssueByBranchID, storeid, im.fkIssueByDeptID, 3, i);


                SetupForm();

                ViewState["dt"] = null;
                grdItems.DataSource = null;
                grdItems.DataBind();



                // cmbbranchfrom.Enabled = true;

                //cmbIssuedby.Enabled = true;
                //cmbBranchto.Enabled = true;

          
            }
           
        }

        protected void btnPrint_Click(object sender, EventArgs e)
        {
          //  string url = "ReportsMain.aspx?rptname=GoodsIssueNote&gino=" + txtginno.Text;

          //  Response.Write("<script>" + "window.open(" + url + ",'_newtab')" + "</script>");
        }

        protected void btnOldGIN_Click(object sender, EventArgs e)
        {
           // txtoldGIN.Visible = true;
        }

     
        protected void btnClose_Click(object sender, EventArgs e)
        {
            Response.Redirect("Main.aspx");
        }

        private void ShowCheckedItems(Telerik.Web.UI.RadComboBox comboBox, Literal literal)
        {
            var sb = new StringBuilder();
            
            var collection = comboBox.CheckedItems;
            string personid="";
            string persons = "";

            if (collection.Count != 0)
            {
                sb.Append("<h3>Selected List:</h3><ul class=\"results\">");

                foreach (var item in collection)
                {
                    sb.Append("<li>" + item.Text + "</li>");
                    personid = personid + item.Value.TrimEnd() + ",";
                    persons = persons + item.Text + ",";

                    if (literal == itemsClientSide)
                    {
                        ConfirmItemEntry(item.Value, item.Text, collection.Count);
                    }
                }
                sb.Append("</ul>");

                literal.Text = sb.ToString();
               // iman.IssuetoID = personid.TrimStart();
                if (txtpersonid.Text == "")
                {
                    txtpersonid.Text = personid.TrimStart();
                }
               // txtremarks.Text = persons;
              
            }
            else
            {
                literal.Text = "<p>No List selected</p>";
                
            }
        }

        protected void rdoGIN_SelectedIndexChanged(object sender, EventArgs e)
        {

            if (rdoGIN.SelectedValue == "N")
            {
                txtginno.Enabled = false;
            }
            else
            {
                txtginno.Enabled = true;

            }

        }

        protected void btnRefresh_Click(object sender, EventArgs e)
        {

        }

        protected void cmbStatusType_SelectedIndexChanged(object sender, Telerik.Web.UI.RadComboBoxSelectedIndexChangedEventArgs e)
        {
            string statustype = cmbStatusType.SelectedValue;
        }

        //OnSelectedIndexChanged="cmbPersonto_SelectedIndexChanged"

        #endregion

    }
}