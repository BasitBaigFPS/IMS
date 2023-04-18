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
    public partial class StaffReceived : System.Web.UI.Page
    {
         
        UserManager UMan = new UserManager();
        ItemManager im = new ItemManager();
        IMSManager iman = new IMSManager();
      
        DataTable di;
        string str;

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

            
            GetUserInfo();
            GetBranches();
            GetEmployee();
            GetItems();

            if (UMan.Ubrhid==25)
            {
                GetSystem();
            }
            else
            {
                cmbSystem.Visible = false;
            }
        }

        public void GetUserInfo()
        {

            HttpCookie IMS = Request.Cookies["IMS"];
            if (IMS == null)
                Response.Redirect("logout.aspx");


            UMan.Uid = int.Parse(IMS["uid"]);
            UMan.Ubrhid = int.Parse(IMS["grpuserbrhid"]);
            UMan.Pkdeptid = int.Parse(IMS["grpuserdptid"]);
            UMan.Ugid = int.Parse(IMS["ugroupid"]);

        }

        public void GetSystem()
        {
            cmbSystem.DataSource = iman.GetSystem();
            cmbSystem.DataTextField = "SystemName";
            cmbSystem.DataValueField = "pksysID";
            cmbSystem.DataBind();

            Telerik.Web.UI.RadComboBoxItem d = new Telerik.Web.UI.RadComboBoxItem();
            d.Text = "Choose System";
            d.Value = "0";
            cmbSystem.Items.Add(d);
            cmbSystem.SelectedIndex = cmbSystem.Items.Count - 1;

        }


        public int GetSysinfo()
        {
            HttpCookie IMS = Request.Cookies["IMS"];
            if (IMS == null)
                Response.Redirect("logout.aspx");


            int sysid = UMan.GetSysinfo(int.Parse(IMS["ubrhid"]));

            return sysid;

        }

        public void GetBranches()
        {
            //int sysid = GetSysinfo();
            //int sysid = 1;

            DataSet db;
 
            db = im.GetBranches();
 
            cmbbranchfrom.DataSource = db.Tables[0];
            cmbbranchfrom.DataTextField = "brhName";
            cmbbranchfrom.DataValueField = "pkbrhID";
            cmbbranchfrom.DataBind();

            //cmbbranchfrom.SelectedValue = int.Parse(IMS["ubrhid"]).ToString();

        }

        private void GetEmployee()
        {

            UMan.Ubrhid = int.Parse(cmbbranchfrom.SelectedValue.ToString());

            DataSet de = im.GetEmployees(UMan.Ubrhid,0,"F");

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

        public void GetItems()
        {
            
            //DataTable di = im.GetAllItems("ST",0);

            if (UMan.Ugid == 31 || UMan.Ugid == 32 || UMan.Ugid==28)
            {
                im.fkdepartid = 14;
            }
            if (UMan.Ugid == 37 || UMan.Ugid == 2084)
            {
                im.fkdepartid = 10;
            }

            if (UMan.Ugid == 79)
            {
                im.fkdepartid = 17;
            }

            if (UMan.Ugid == 38)
            {
                im.fkdepartid = 2;
            }

            //if (UMan.Pkdeptid==10)
            //{
            //    im.fkdepartid = UMan.Pkdeptid;
            //}
            //if (UMan.Pkdeptid == 2)
            //{
            //    im.fkdepartid = UMan.Pkdeptid;
            //}
            //if (UMan.Pkdeptid == 11)
            //{
            //    im.fkdepartid = UMan.Pkdeptid;
            //}
            //if (UMan.Pkdeptid == 14)
            //{
            //    im.fkdepartid = UMan.Pkdeptid;
            //}
            //if (UMan.Pkdeptid != 10 && UMan.Pkdeptid != 2 && UMan.Pkdeptid != 11 && UMan.Pkdeptid != 14)
            //{
            //    im.fkdepartid = 2;
            //}


            DataTable di = im.GetAllItems();

            if (di.Rows.Count > 0)
            {
                cmbItemSearch.Items.Clear();

                cmbItemSearch.DataSource = di;
                cmbItemSearch.DataTextField = "ItemTitle";
                cmbItemSearch.DataValueField = "ItemCode";
                cmbItemSearch.DataBind();
                //cmbItemSearch.Enabled = false;
                //cmbItemSearch.SelectedValue = cmbItemSearch.SelectedValue;
            }
        }


        public Single GetItemBalance(int brhid,int storeid,string invcode,string token)
        {
            DataTable dtibal = im.getItembalance(brhid, storeid, invcode, token);

            Single itmbalance = 0;

            if (dtibal.Rows.Count > 0)
            {
                itmbalance = Single.Parse(dtibal.Rows[0]["CRBalance"].ToString() == "" ? "0" : dtibal.Rows[0]["CRBalance"].ToString());
            }
            return itmbalance;

        }


        public void ConfirmItemEntry()
        {

            if (cmbPersonto.Text == "No Employees in Branch")
            {
                showMessageBox("Please Select Person Whom you are Receiving These Items!!!!");
                return;
            }


            if (Page.IsValid)
            {

                DataTable dt = (DataTable)ViewState["dt"];
                DataTable ib;

                GetUserInfo();

                

                if (dt.Columns.Count == 0)
                {

                   
                    dt.Columns.Add("Item Code", typeof(string));
                    dt.Columns.Add("Item Name", typeof(string));
                    dt.Columns.Add("Balance", typeof(Single));
                    dt.Columns.Add("Qty Received", typeof(Single));

                }

                int tr = int.Parse(dt.Rows.Count.ToString());

                if (dt.Rows.Count > 0)
                {

                    bool ck = checkItem(dt, cmbItemSearch.SelectedValue.ToString(), "14");

                    if (ck == false)
                    {
                        DataRow dr = dt.NewRow();

                        dr["Item Code"] = cmbItemSearch.SelectedValue.ToString();
                        dr["Item Name"] = cmbItemSearch.SelectedItem.Text.ToString();
                        dr["Balance"] = Single.Parse(dt.Rows[0]["Balance"].ToString() == "" ? "0" : dt.Rows[0]["Balance"].ToString());
                        dr["Qty Received"] = 0;

                        dt.Rows.Add(dr);

                        cmbPersonto.Enabled = false;


                    }

                    else
                    {
                        showMessageBox("Item Already Exists in Current Received!!!!");
                    }
                }

                else
                {

                    DataRow dr = dt.NewRow();

                    dt.Rows.Add(dr);

                    dr["Item Code"] = cmbItemSearch.SelectedValue.ToString();
                    dr["Item Name"] = cmbItemSearch.SelectedItem.Text.ToString();
                    dr["Balance"] = Single.Parse(dt.Rows[0]["Balance"].ToString() == "" ? "0" : dt.Rows[0]["Balance"].ToString());
                    dr["Qty Received"] = 0;

                    //dt.Rows.Add(dr);

                    cmbPersonto.Enabled = false;
                }

                mirdiv.Style.Add("display", "inline");

                ViewState["dt"] = SetDataTable(dt);
                grdItems.DataSource = dt;
                grdItems.DataBind();
                
                grdItems.Visible = true;
                //txtginno.Text = "6";

            }
            //btnSubmitItem.Visible = true;




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
                    dt.Columns.Add("Qty Received", typeof(Single));

                }

                int tr = int.Parse(dt.Rows.Count.ToString());

                Single ItemBalance = GetItemBalance(UMan.Ubrhid, UMan.Pkdeptid , itemcode, "G");

                if (dt.Rows.Count > 0)
                {
                    DataRow dr = dt.NewRow();

                    dr["Item Code"] = itemcode;
                    dr["Item Name"] = itemname;

                    //DataRow[] ItemRow = di.Select("[ItemCode] ='" + itemcode + "'");

                    //if (Single.Parse(dt.Rows[0]["Balance"].ToString() == "" ? "0" : dt.Rows[0]["Balance"].ToString()) == 0)
                    //{
                    //    dr["Balance"] = ItemBalance;
                    //}
                    //else
                    //{
                    //    dr["Balance"] = Single.Parse(dt.Rows[0]["Balance"].ToString() == "" ? "0" : dt.Rows[0]["Balance"].ToString());
                    //}

                    dr["Balance"] = ItemBalance;
                    dr["Qty Received"] = 0;

                    dt.Rows.Add(dr);

                    cmbPersonto.Enabled = false;
                }

                else
                {

                    DataRow dr = dt.NewRow();

                    dt.Rows.Add(dr);

                    dr["Item Code"] = itemcode;
                    dr["Item Name"] = itemname;

                   // DataRow[] ItemRow = di.Select("[ItemCode] ='" + itemcode + "'");

                    if (Single.Parse(dt.Rows[0]["Balance"].ToString() == "" ? "0" : dt.Rows[0]["Balance"].ToString()) == 0)
                    {
                        dr["Balance"] = ItemBalance;
                    }
                    else
                    {
                        dr["Balance"] = Single.Parse(dt.Rows[0]["Balance"].ToString() == "" ? "0" : dt.Rows[0]["Balance"].ToString());
                    }
                    dr["Qty Received"] = 0;

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


        protected void showMessageBox(string message)
        {
            string sScript;
            message = message.Replace("'", "\'");
            sScript = String.Format("alert('{0}');", message);
            ScriptManager.RegisterStartupScript(this, this.GetType(), "alert", sScript, true);

            //ClientScript.RegisterClientScriptBlock(this.GetType(), "alert", "alert('" + message + "');", true);

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
       
        protected void btnClose_Click(object sender, EventArgs e)
        {
            object typ = this.GetType();
            ScriptManager.RegisterStartupScript(this, this.GetType(), "Close_Window", "self.close();", true);
        }

        protected void btnSave_Click(object sender, EventArgs e)
        {
            GetUserInfo();


            DataTable dt1 = (DataTable)ViewState["dt"];

            DataTable dt = SetDataTable(dt1);

            if (dt.Rows.Count == 0)
                showMessageBox("Add Items first!!!!!");
            else
            {
                HttpCookie IMS = Request.Cookies["IMS"];
                if (IMS == null)
                    Response.Redirect("logout.aspx");

                im.fkbrhid = int.Parse(IMS["grpuserbrhid"]);
                im.fkdepartid = int.Parse(IMS["grpuserdptid"] == null ? "0" : IMS["grpuserdptid"]);
                im.CreatedBy = int.Parse(IMS["uid"]);
                im.receivedByID = int.Parse(IMS["uid"]);

                im.fkstoreid = 0;                
                im.fkVendorID = 0;

                if (im.fkbrhid == 25 && im.fkdepartid==14)
                {
                    im.fkstoreid = 1;
                    im.pksysID = int.Parse(cmbSystem.SelectedValue.ToString());
                }
                else if (im.fkbrhid == 19 && im.fkdepartid == 10)
                {
                    im.fkstoreid = 22;
                }
                else if (im.fkbrhid == 19 && im.fkdepartid != 10)
                {
                    im.fkstoreid = 2;
                }
                else if (im.fkdepartid == 17)
                {
                    im.fkstoreid = 0;
                }
                else
                {
                    im.fkdepartid = 14;
                }


                im.dcno = "";
                string dcd = DateTime.Now.ToShortDateString();
                im.dcdate = dcd;


                im.invoice = "";
                im.vehicle = "";
                im.ponumber = "";
                

                im.OLDGRN = int.Parse("0");

                im.Remarks = lblStaff.Text;

                im.RecvfromID = lblStaffID.Text;

                if (im.OLDGRN == 0)
                {
                    im.Token = "I";
                }
                else
                {
                    im.Token = "A";
                }

                im.Remarks = txtremarks.Text;

                int i = im.IUReceivedItemsStaff(dt);

                showMessageBox("Items Return Successfully with GRN Number : " + i.ToString());

                lblGRNNo.Text = i.ToString();
                // btnPrint.Visible = true;
                txtgrnno.Text = i.ToString();

                SetupForm();


                ViewState["dt"] = null;
                grdItems.DataSource = null;
                grdItems.DataBind();

            }

            btnSave.Visible = false;

        }

        protected void btnPrint_Click(object sender, EventArgs e)
        {
            Response.Redirect("ReportsMain.aspx?rptname=GoodsReceiptNote&grno=" + txtgrnno.Text);
        }

        protected void cmbPersonto_SelectedIndexChanged(object sender, Telerik.Web.UI.RadComboBoxSelectedIndexChangedEventArgs e)
        {
            //lblStaff
        }

        protected void cmbItemSearch_SelectedIndexChanged(object sender, Telerik.Web.UI.RadComboBoxSelectedIndexChangedEventArgs e)
        {
            //if (lblStaff.Text=="Staff List")
            //{
            //    ShowCheckedItems(cmbPersonto, StaffClientSide,"Staff");
            //}

            //ConfirmItemEntry();
        }




        protected void btnSubmitItem_Click(object sender, EventArgs e)
        {
            ShowCheckedItems(cmbPersonto, StaffClientSide, "Staff");

            ShowCheckedItems(cmbItemSearch, ItemsClientSide, "Items");

        }


        private void ShowCheckedItems(Telerik.Web.UI.RadComboBox comboBox, Literal literal, string LitType)
        {
            var sb = new StringBuilder();

            var collection = comboBox.CheckedItems;
            string personid = "";
            string persons = "";

            if (collection.Count != 0)
            {

                if (LitType == "Staff")
                {
                    sb.Append("<h3>Selected Persons:</h3><ul class=\"results\">");

                    foreach (var item in collection)
                    {
                        sb.Append("<li>" + item.Text + "</li>");
                        personid = personid + item.Value + ",";
                        persons = persons + item.Text + ",";
                    }
                    sb.Append("</ul>");

                    lblStaffID.Text = personid.TrimStart();
                    lblStaff.Text = persons;

                    literal.Text = sb.ToString();
                }
                else
                {
                    sb.Append("<h3>Selected Items:</h3><ul class=\"results\">");

                    foreach (var item in collection)
                    {
                        sb.Append("<li>" + item.Text + "</li>");
                        personid = personid + item.Value + ",";
                        persons = persons + item.Text + ",";

                        if (literal == ItemsClientSide)
                        {
                            ConfirmItemEntry(item.Value, item.Text, collection.Count);
                        }
                    }
                    sb.Append("</ul>");

                    lblItemID.Text = personid.TrimStart();
                    lblItems.Text = persons;
                }

              

            }
            else
            {
                literal.Text = "<p>No person/Items selected...</p>";

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
                        float bal = float.Parse(lblBal.Text=="" ? "0" : lblBal.Text);


                        DataRow[] ItemRow = ds.Tables[0].Select("[Item Code] ='" + itemid + "'");

                        ItemRow[0]["Qty Received"] = qtty == "" ? "0" : qtty;

                       // ItemRow[0]["Qty Received"] = float.Parse(qtty) > bal ? lblBal.Text : qtty;
                    }
                }

            }

            return ds.Tables[0];

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

            //    chkb = checkItemBalance(dt, dt.Rows[rowindex]["Item Code"].ToString(), cmbDepartmentto.SelectedValue.ToString(), Single.Parse(dt.Rows[rowindex]["Balance"].ToString()), Single.Parse(thisTextBox.Text));

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

        protected void grdItems_NeedDataSource(object sender, Telerik.Web.UI.GridNeedDataSourceEventArgs e)
        {



        }

        protected void grdItems_RowCommand(object sender, GridViewCommandEventArgs e)
        {

            if (e.CommandName == "Delete")
            {
                int index = Convert.ToInt32(e.CommandArgument);

                DataTable dt = (DataTable)ViewState["dt"];

                dt = SetDataTable(dt);

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

        protected void grdItems_DataBound(object sender, EventArgs e)
        {

        }

        protected void grdItems_RowDataBound(object sender, GridViewRowEventArgs e)
        {

            if (e.Row.RowType == DataControlRowType.DataRow)
            {
                Label lblCurrentBalance = (Label)e.Row.FindControl("lblbalance");
                Double CurBal = Convert.ToDouble(lblCurrentBalance.Text == "" ? "0" : lblCurrentBalance.Text);
                TextBox txtqut = (TextBox)e.Row.FindControl("txtqty");


                string rowid = e.Row.RowIndex.ToString();

                txtqut.Attributes.Add("onkeydown", "return IsNumeric(event" + ",'" + rowid + "')");

                string qtyvalue = txtqut.Text;

                txtqut.Attributes.Add("onkeyup", "return CheckBalance(" + CurBal + ",'" + rowid + "')");

                GridViewRow NextRow = e.Row;
                for (int i = 0; i < grdItems.Rows.Count - 1; i++)
                {
                    TextBox curTexbox = grdItems.Rows[i].Cells[3].FindControl("txtqty") as TextBox;
                    TextBox nexTextbox = grdItems.Rows[i + 1].Cells[3].FindControl("txtqty") as TextBox;
                    curTexbox.Attributes.Add("onkeypress", "return clickEnter('" + nexTextbox.ClientID + "', event)");

                    curTexbox.Attributes.Add("onfocusin", " select();");
                }

            }

        }

        protected void grdItems_RowCreated(object sender, GridViewRowEventArgs e)
        {


        }

        protected void cmbSystem_SelectedIndexChanged(object sender, Telerik.Web.UI.RadComboBoxSelectedIndexChangedEventArgs e)
        {
            im.pksysID = int.Parse(cmbSystem.SelectedValue.ToString());          
        }

        protected void cmbbranchfrom_SelectedIndexChanged(object sender, Telerik.Web.UI.RadComboBoxSelectedIndexChangedEventArgs e)
        {
            GetEmployee();
        }


    }
}