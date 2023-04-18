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
using Telerik.Web.UI;
using System.IO;
using System.Text;
using BLL;

namespace IMS
{
    public partial class IssueQuickItems : System.Web.UI.Page
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

            iman.Pkbrhid = UMan.Ubrhid;
            //&& UMan.Uid != 10412
            if (UMan.Uid != 1527 && UMan.Uid != 93 && UMan.Uid != 105 && UMan.Uid != 152 && UMan.Uid != 95 && UMan.Uid != 10400 && UMan.Ugid != 38 && UMan.Uid != 1607)
            {
                ScriptManager.RegisterStartupScript(this, this.GetType(), "redirect", "alert('Please Use Desktop IMS Version for Goods Issue Note (GIN), Thank You :)'); window.location='" + Request.ApplicationPath + "Main.aspx';", true);
            }

            DashBoardManager dbm = new DashBoardManager();
            dbm.fkbrhid = UMan.Ubrhid;

            List<string> MyList = dbm.GetUNRGinList();

            var collection = MyList;

            if (collection.Count != 0)
            {
                ScriptManager.RegisterStartupScript(this, this.GetType(), "alert", "alert('You Have Pending GIN(s) at Your IMS Dashboard, No Transaction is Allowed Until All The Pending GIN Not Received!');window.location ='MainDashboard.aspx';", true);
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

        private void GetEmployee(string type)
        {
            GetUserInfo();
            DataSet de = im.GetEmployees(iman.Pkbrhid,0,"F");

            if (de.Tables[0].Rows.Count > 0)
            {
                cmbPersonto.DataSource = de.Tables[0];
                cmbPersonto.DataTextField = "empName";
                cmbPersonto.DataValueField = "pkempID";
                cmbPersonto.DataBind();
            }
            else
            {
                cmbPersonto.Items.Clear();
                Telerik.Web.UI.RadComboBoxItem ib = new Telerik.Web.UI.RadComboBoxItem();
                ib.Text = "No Employees in Branch";
                ib.Value = "No Employees in Branch";
                cmbPersonto.Items.Add(ib);
                cmbPersonto.SelectedIndex = cmbPersonto.Items.Count - 1;                    
                    
            }
        }
 

        public void SearchItems()
        {
            
                              
                GetUserInfo();
                im.fkdepartid = 14;
                im.fkstoreid = im.GetStore(UMan.Ubrhid);

                if (UMan.Pkdeptid != 14 && UMan.Pkdeptid != 10 && UMan.Ubrhid == 19)
                {
                    im.fkstoreid = 2;
                }
                if (UMan.Pkdeptid==10 && UMan.Ubrhid == 19)
                {
                    im.fkstoreid = 22;
                    im.fkdepartid = 10;
                }
      
                im.pksysID = GetSysinfo();

                //GetDeptInventory(int deptid, int fkbrhid, int headid)
                if (UMan.Ugid == 2084)   //User Group of I.T Assets Manage at Branch Level, More Group can be created for More Assets Management at Branch & Department Level
                {
                    di = im.GetDeptInventory(UMan.Pkdeptid,UMan.Ubrhid,8);
                }
                else
                {
                    di = im.GetStoreInventory(im.fkstoreid, im.fkdepartid);
                }
                

                if (di.Rows.Count > 0)
                {
                    cmbItemSearch.Items.Clear();

                    cmbItemSearch.DataSource = di;
                    cmbItemSearch.DataTextField = "ItemTitle";
                    cmbItemSearch.DataValueField = "ItemCode";
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

            GetEmployee("I");

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
               // ModalPopupExtender1.Show();
                
                cmbPersonto.Filter = RadComboBoxFilter.Contains;
                cmbItemSearch.Filter = RadComboBoxFilter.Contains; 

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
            ShowCheckedItems(cmbPersonto, staffClientSide);

            ShowCheckedItems(cmbItemSearch, itemsClientSide);


        }

        public void ConfirmItemEntry(string itemcode, string itemname, int listno)
        {

            if (cmbPersonto.Text == "No Employees in Branch")
            {
                showMessageBox("Please Select Person Whom you are Issuing These Items!!!!");
                return;
            }


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

                        DataRow[] ItemRow = di.Select("[ItemCode] ='" + itemcode + "'");

                        dr["Balance"] = Single.Parse(ItemRow[0]["CurrentBalance"].ToString() == "" ? "0" : ItemRow[0]["CurrentBalance"].ToString());
                        dr["Qty Issued"] = 0;

                        dt.Rows.Add(dr);

                        cmbPersonto.Enabled = false;
                }

                else
                {

                    DataRow dr = dt.NewRow();

                    dt.Rows.Add(dr);

                    dr["Item Code"] = itemcode;
                    dr["Item Name"] = itemname;

                    DataRow[] ItemRow = di.Select("[ItemCode] ='" + itemcode + "'");

                    dr["Balance"] = Single.Parse(ItemRow[0]["CurrentBalance"].ToString() == "" ? "0" : ItemRow[0]["CurrentBalance"].ToString());
                    dr["Qty Issued"] = 0;

                    //dt.Rows.Add(dr);

                    cmbPersonto.Enabled = false;
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

                im.fkstoreid = im.GetStore(UMan.Ubrhid);
                im.fkdepartid = 14;

                if (UMan.Pkdeptid != 14 && UMan.Pkdeptid != 10 && UMan.Ubrhid == 19)
                {
                    im.fkstoreid = 2;
                }
                if (UMan.Pkdeptid == 10 && UMan.Ubrhid == 19)
                {
                    im.fkstoreid = 22;
                    im.fkdepartid = 10;
                }

                if (UMan.Ugid == 2084)
                {
                    im.fkIssueByDeptID = UMan.Pkdeptid;
                    im.fkstoreid = 0;
                }
                else
                {
                    im.fkIssueByDeptID = im.fkdepartid;
                }
                im.fkIssueByBranchID = UMan.Ubrhid;
                im.fkIssueToBranchID = UMan.Ubrhid;

                //RadComboBoxItem item = cmbPersonto.FindItemByText(cmbPersonto.Text);
                //item.Selected = true;

                im.fkIssueByID = UMan.Uid;
                im.fkIssuedToID = int.Parse(cmbPersonto.SelectedValue.ToString() == "" ? im.CreatedBy.ToString() : cmbPersonto.SelectedValue.ToString());
                im.IssuedStatus = "P";
                im.IssuedType = "I";
                im.Remarks = txtremarks.Text;
                im.IssuetoID = txtpersonid.Text;

                //Use RadComboBox.SelectedIndex
                ////int index = cmbPersonto.FindItemIndexByValue("2");
                //RadComboBox1.SelectedIndex = index;

                ////You can also use the SelectedValue property.
                //RadComboBox1.SelectedValue = value;

                im.IUIssueItemInternal(dt);

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

                cmbPersonto.Enabled = true;
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
            ScriptManager.RegisterStartupScript(this, this.GetType(), "Close_Window", "self.close();", true);
            
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

        //OnSelectedIndexChanged="cmbPersonto_SelectedIndexChanged"

        #endregion

    }
}