using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Text;
using BLL;
using Telerik.Web.UI;
using System.Data;


namespace IMS
{
    public partial class IssueItem : System.Web.UI.Page
    {
        UserManager UMan = new UserManager();
        ItemManager im = new ItemManager();
        IMSManager iman = new IMSManager();

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

            if (UMan.Uid != 1527 && UMan.Uid != 93 && UMan.Uid != 105 && UMan.Uid != 152 && UMan.Uid != 95)
            {
                showMessageBox("Please Use Desktop IMS Version for Goods Issue Note, Thank You :)");
                Response.Redirect("Default.aspx");
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

        public int GetSysID()
        { 
            im.fkcatid = int.Parse(cmbCatagories.SelectedValue.ToString());
            int sysid;

            if (im.fkcatid == 1 || im.fkcatid == 2 || im.fkcatid == 8)
            {
                sysid = 4;
            }
            else
            { 
                sysid = int.Parse(cmbSystem.SelectedValue.ToString());
            }

            return sysid;
        }

        public void GetSystem()
        {           
            cmbSystem.DataSource = iman.GetSystem();
            cmbSystem.DataTextField = "SystemName";
            cmbSystem.DataValueField = "pksysID";
            cmbSystem.DataBind();
        }

        public void GetBranch(string type, string brhid)
        {
            //Telerik.Web.UI.RadComboBoxItem bt = new Telerik.Web.UI.RadComboBoxItem();
            //bt.Text = "Choose Branch";
            //bt.Value = "Choose Branch";
            //cmbBranchto.Items.Add(bt);
            //cmbBranchto.SelectedIndex = cmbBranchto.Items.Count - 1;
            
            if (type == "I")
            {
                DataSet db = im.GetBranches();

                cmbbranchfrom.DataSource = db.Tables[0];
                cmbbranchfrom.DataTextField = "brhName";
                cmbbranchfrom.DataValueField = "pkbrhID";
                cmbbranchfrom.SelectedValue = brhid;

                cmbbranchfrom.DataBind();
                cmbbranchfrom.Enabled = false;

            }
            else
            {
                DataSet dbt = im.GetBranches();
                cmbBranchto.DataSource = dbt.Tables[0];
                cmbBranchto.DataTextField = "brhName";
                cmbBranchto.DataValueField = "pkbrhID";
                cmbBranchto.SelectedValue = brhid;

                cmbBranchto.DataBind();
                cmbBranchto.Enabled = false;

            }
        
        }

        public void GetStore()
        {         
                DataSet ds = im.GetStores(UMan.Ubrhid);
                cmbStores.DataSource = ds.Tables[0];
                cmbStores.DataTextField = "StoreName";
                cmbStores.DataValueField = "pkStoreID";
                cmbStores.DataBind();
        }

        public void GetDepartment(string type, int UsrID)
        {

            
            if (type == "I")
            {
                // int dpf = iman.Pkdeptid;
                DataSet ddf = im.GetDepartment(UsrID);
                cmbDepartmentfrom.DataSource = ddf.Tables[0];
                cmbDepartmentfrom.DataTextField = "deptName";
                cmbDepartmentfrom.DataValueField = "pkdeptID";
                cmbDepartmentfrom.DataBind();
            }
            else
            {

                DataSet dd = im.GetDepartment(0);
                cmbDepartmentto.DataSource = dd.Tables[0];
                cmbDepartmentto.DataTextField = "deptName";
                cmbDepartmentto.DataValueField = "pkdeptID";
                cmbDepartmentto.DataBind();

                cmbDepartmentto.SelectedValue = "2";

                //Telerik.Web.UI.RadComboBoxItem id = new Telerik.Web.UI.RadComboBoxItem();
                //id.Text = "Choose Department";
                //id.Value = "Choose Department";
                //cmbDepartmentto.Items.Add(id);
                //cmbDepartmentto.SelectedIndex = cmbDepartmentto.Items.Count - 1;


            }
        }

        private void GetEmployee(string type)
        {
            
            if (type == "I")
            {
                cmbDepartmentfrom.SelectedIndex = cmbDepartmentfrom.Items.Count - 2;

                DataSet de = im.GetEmployees(int.Parse(cmbbranchfrom.SelectedValue.ToString()), int.Parse(cmbDepartmentfrom.SelectedValue.ToString()), type);

                if (de.Tables[0].Rows.Count > 0)
                {
                    cmbIssuedby.DataSource = de.Tables[0];
                    cmbIssuedby.DataTextField = "empName";
                    cmbIssuedby.DataValueField = "pkempID";
                    cmbIssuedby.DataBind();
                }
                else
                {
                    cmbIssuedby.Items.Clear();
                    Telerik.Web.UI.RadComboBoxItem ib = new Telerik.Web.UI.RadComboBoxItem();
                    ib.Text = "No Employees in Branch";
                    ib.Value = "No Employees in Branch";
                    cmbIssuedby.Items.Add(ib);
                    cmbIssuedby.SelectedIndex = cmbIssuedby.Items.Count - 1;
                }

            }
            else
            {
                if (cmbBranchto.SelectedValue != "Choose Branch")
                {
                    DataSet de = im.GetEmployees(int.Parse(cmbBranchto.SelectedValue.ToString()), int.Parse(cmbDepartmentto.SelectedValue.ToString()), type);

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
            }
        }

        public void GetCategory()
        {
            im.CatID = 0;
            im.Token = "C";            
            cmbCatagories.DataSource = im.GetCategories();
            cmbCatagories.DataTextField = "CatTitle";
            cmbCatagories.DataValueField = "pkCatID";
            cmbCatagories.DataBind();
        }

        public void GetSubCategory(int catid)
        {
            im.CatID = catid;
            cmbSubCategory.DataSource = im.GetSubCategories();
            cmbSubCategory.DataTextField = "SubCatTitle";
            cmbSubCategory.DataValueField = "pkSubCatID";
            cmbSubCategory.DataBind();

        }

        public void GetItemHead(int subcatid)
        {
            im.SubCatID = subcatid;

            cmbItemHead.DataSource = im.GetItemHeads();
            cmbItemHead.DataTextField = "ItemHeadTitle";
            cmbItemHead.DataValueField = "pkItemHeadID";
            cmbItemHead.DataBind();
        }

        public void GetItems(int ithead, int token)
        {

            if (token == 2)
            {
                im.fkitemheadid = int.Parse(cmbItemHead.SelectedValue.ToString());
                im.pksysID = GetSysID();

                mysysid = im.pksysID;

                if (cmbBranchto.SelectedValue != "Choose Item")
                {

                    int deptfromid;
                    int storeid;
                    GetUserInfo();

                    if (UMan.Ugid == 31 || UMan.Ugid == 32)
                    {
                        deptfromid = 14;
                    }
                    else
                    {
                        deptfromid = int.Parse(cmbDepartmentfrom.SelectedValue.ToString());

                    }
                    storeid = int.Parse(cmbStores.SelectedValue.ToString());
                    if (deptfromid == 10)
                    {
                        storeid = 22;

                    }

                    im.fkstoreid = storeid;

                    DataTable di = im.GetStoreByDepartment(im.pksysID, storeid, deptfromid, im.fkitemheadid);

                    if (di.Rows.Count > 0)
                    {
                        cmbItem.Items.Clear();

                        cmbItem.DataSource = di;
                        cmbItem.DataTextField = "ItemTitle";
                        cmbItem.DataValueField = "InventoryCode";
                        cmbItem.DataBind();

                        Telerik.Web.UI.RadComboBoxItem ib = new Telerik.Web.UI.RadComboBoxItem();
                        ib.Text = "Choose Item";
                        ib.Value = "Choose Item";
                        cmbItem.Items.Add(ib);
                        cmbItem.SelectedIndex = cmbItem.Items.Count - 1;

                    }
                    else
                    {
                        cmbItem.Items.Clear();

                        Telerik.Web.UI.RadComboBoxItem ib = new Telerik.Web.UI.RadComboBoxItem();
                        ib.Text = "Choose Item";
                        ib.Value = "Choose Item";
                        cmbItem.Items.Add(ib);
                        cmbItem.SelectedIndex = cmbItem.Items.Count - 1;

                    }
                }
            }
            else
            {

                im.Token = "S";
                im.pksysID = GetSysID();

                int deptfromid;
                int storeid;
                GetUserInfo();

                if (UMan.Ugid == 31 || UMan.Ugid == 32)
                {
                    deptfromid = 14;
                }
                else
                {
                    deptfromid = int.Parse(cmbDepartmentfrom.SelectedValue.ToString());

                }
                //storeid = int.Parse(cmbStores.SelectedValue.ToString());

                if (UMan.Uid == 94)
                {
                    storeid = 2;

                }
                else
                {
                    storeid = int.Parse(cmbStores.SelectedValue.ToString());
                }

                im.fkstoreid = storeid;

                if (deptfromid == 10)
                {
                    storeid = 22;

                }

                DataTable di = im.GetStoreInventory(im.pksysID, storeid, deptfromid);

                if (di.Rows.Count > 0)
                {
                    cmbItem.Items.Clear();
                     
                    cmbItem.DataSource = di;
                    cmbItem.DataTextField = "ItemTitle";
                    cmbItem.DataValueField = "InventoryCode";
                    cmbItem.DataBind();
                    cmbItem.Enabled = false;
                    cmbItem.SelectedValue = cmbItemSearch.SelectedValue;

                }

            }

        }

        public void ConfirmItemEntry()
        {

            if (cmbPersonto.Text == "No Employees in Branch")
            {
                showMessageBox("Please Select Department / Person Who is Receiving These Items!!!!");
                return;
            }


            if (Page.IsValid)
            {

                DataTable dt = (DataTable)ViewState["dt"];
                DataTable ib;

                int deptfrom;
                int storeid;
                GetUserInfo();

                if (UMan.Uid == 94)
                {
                    storeid = 2;
                }
                else
                {
                    storeid = int.Parse(cmbStores.SelectedValue.ToString());
                }

                deptfrom = int.Parse(cmbDepartmentfrom.SelectedValue.ToString());
                if (deptfrom == 10)
                {
                    storeid = 22;

                }

                if (UMan.Ugid == 31 || UMan.Ugid == 32)
                {

                    ib = im.getItembalance(int.Parse(cmbbranchfrom.SelectedValue.ToString()), storeid, cmbItem.SelectedValue.ToString(), "S");
                }
                else
                {

                    ib = im.getItembalance(int.Parse(cmbbranchfrom.SelectedValue.ToString()), deptfrom, cmbItem.SelectedValue.ToString(), "D");
                }



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

                    bool ck = checkItem(dt, cmbItem.SelectedValue.ToString(), cmbDepartmentto.SelectedItem.Text.ToString());

                    if (ck == false)
                    {
                        DataRow dr = dt.NewRow();

                        dr["Item Code"] = cmbItem.SelectedValue.ToString();
                        dr["Item Name"] = cmbItem.SelectedItem.Text.ToString();
                        dr["Balance"] = Single.Parse(ib.Rows[0]["CRBalance"].ToString() == "" ? "0" : ib.Rows[0]["CRBalance"].ToString());
                        dr["Qty Issued"] = 0;

                        dt.Rows.Add(dr);

                        cmbbranchfrom.Enabled = false;
                        cmbIssuedby.Enabled = false;
                        cmbBranchto.Enabled = false;
                        cmbPersonto.Enabled = false;
                        cmbDepartmentto.Enabled = false;
                        cmbIssueStatus.Enabled = false;
                        cmbIssueType.Enabled = false;

                    }

                    else
                    {
                        showMessageBox("Item Already Exists in Current Issue!!!!");
                    }
                }

                else
                {

                    DataRow dr = dt.NewRow();

                    dr["Item Code"] = cmbItem.SelectedValue.ToString();
                    dr["Item Name"] = cmbItem.SelectedItem.Text.ToString();
                    dr["Balance"] = Single.Parse(ib.Rows[0]["CRBalance"].ToString() == "" ? "0" : ib.Rows[0]["CRBalance"].ToString());
                    dr["Qty Issued"] = 0;


                    dt.Rows.Add(dr);

                    cmbbranchfrom.Enabled = false;
                    cmbIssuedby.Enabled = false;
                    cmbBranchto.Enabled = false;
                    cmbPersonto.Enabled = false;
                    cmbDepartmentto.Enabled = false;

                    cmbIssueStatus.Enabled = false;
                    cmbIssueType.Enabled = false;
                }


                ViewState["GINSaved"] = null;
                ViewState["dt"] = SetDataTable(dt);
                grdItems.DataSource = dt;
                grdItems.DataBind();

                grdItems.Visible = true;
               
                //txtginno.Text = "6";

            }
            btnSubmitItem.Visible = true;
        
        
        
        
        }

        public void SearchItems()
        {
            if (cmbBranchto.SelectedValue != "Search Item")
            {
                im.Token = "S";
                im.pksysID = GetSysID();
                int deptfromid;
                int storeid;
                GetUserInfo();

                if (UMan.Ugid == 31 || UMan.Ugid == 32)
                {
                    deptfromid = 14;
                }
                else
                {
                    deptfromid = int.Parse(cmbDepartmentfrom.SelectedValue.ToString());

                }

                if (UMan.Uid ==94)
                {
                    storeid = 2;
                }
                else
                {
                    storeid = int.Parse(cmbStores.SelectedValue.ToString());
                }
                if (deptfromid == 10)
                {
                    storeid = 22;

                }

                im.fkstoreid = storeid;

              //  DataTable di = im.GetStoreInventory(storeid, deptfromid);
                DataTable di = im.GetStoreInventory(im.pksysID, storeid, deptfromid);

                if (di.Rows.Count > 0)
                {
                    cmbItemSearch.Items.Clear();

                    cmbItemSearch.DataSource = di;
                    cmbItemSearch.DataTextField = "ItemTitle";
                    cmbItemSearch.DataValueField = "InventoryCode";
                    cmbItemSearch.DataBind();
                    cmbItemSearch.ItemsPerRequest = 10;

                    Telerik.Web.UI.RadComboBoxItem ib = new Telerik.Web.UI.RadComboBoxItem();
                    ib.Text = "Search Item";
                    ib.Value = "Search Item";
                    cmbItemSearch.Items.Insert(0, ib);
                    //cmbItemSearch.Items.Add(ib);
                    cmbItemSearch.SelectedIndex = 0;


                    //Telerik.Web.UI.RadComboBoxItem ib = new Telerik.Web.UI.RadComboBoxItem();
                    //ib.Text = "Search Item";
                    //ib.Value = "Search Item";
                    //cmbItemSearch.Items.Add(ib);
                    //cmbItemSearch.SelectedIndex = cmbItemSearch.Items.Count - 1;

                }
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

            GetSystem();

            Telerik.Web.UI.RadComboBoxItem sys = new Telerik.Web.UI.RadComboBoxItem();
            sys.Text = "Choose System";
            sys.Value = "Choose System";
            cmbSystem.Items.Add(sys);
            cmbSystem.SelectedIndex = 0;

            //Issuer Setups

            GetBranch("I", int.Parse(IMS["ubrhid"]).ToString());

            iman.Uid = int.Parse(IMS["uid"]);
            iman.Pkdeptid = int.Parse(IMS["udptid"] == null ? "0" : IMS["udptid"]);

            GetDepartment("I", iman.Uid);

            GetEmployee("I");


            //Receiver Setups

            GetBranch("R", int.Parse(IMS["ubrhid"]).ToString());

            GetStore();

            GetDepartment("R", iman.Uid);

            GetEmployee("E");


            im.CatID = 0;
            im.Token = "C";
            cmbCatagories.DataSource = im.GetCategories();
            cmbCatagories.DataTextField = "CatTitle";
            cmbCatagories.DataValueField = "pkCatID";
            cmbCatagories.DataBind();


            Telerik.Web.UI.RadComboBoxItem it = new Telerik.Web.UI.RadComboBoxItem();
            it.Text = "Choose Item";
            it.Value = "Choose Item";
            cmbItem.Items.Add(it);
            cmbItem.SelectedIndex = cmbItem.Items.Count - 1;

            rdackdate.Text = DateTime.Today.ToString("dd/MM/yyyy"); 

            UserSettings();
            //cmbIssueStatus.Visible = false;

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

        public bool checkItemBalance(DataTable dt, String InvCode, String DeptID, Single balance, Single qtyissue)
        {
            bool returnval = false;

            //DataRow[] result = dt.Select("[Item Code] ='" + InvCode + "' AND [Issue to Department Id] =" + DeptID);

            DataRow[] result = dt.Select("[Item Code] ='" + InvCode + "'");

            Single i = 0;

            foreach (DataRow row in result)
            {
               i = i + Single.Parse(row["Qty Issued"].ToString());
            }

            if (balance < i)
                returnval = true;
            
            return returnval;
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
               
            if (UMan.Ugid==31 || UMan.Ugid==32)
            {
                int sysid = GetSysinfo();
                cmbSystem.SelectedValue = sysid.ToString();
                cmbSystem.Enabled = false;
                cmbDepartmentfrom.Enabled = false;
                cmbIssuedby.Enabled = false;
            }
        }

        #endregion

        #region Events 
        
        protected void Page_Load(object sender, EventArgs e)
        {
            if (Page.IsPostBack == false)
            {
                cmbItemSearch.Filter = RadComboBoxFilter.Contains; 
                String isutype = Request.QueryString["issuetype"];
                cmbIssueType.SelectedValue = isutype;
                cmbIssueType.Enabled = false;
                SetupForm();
            }
        }

        protected void cmbSystem_SelectedIndexChanged(object sender, Telerik.Web.UI.RadComboBoxSelectedIndexChangedEventArgs e)
        {
            im.pksysID = int.Parse(cmbSystem.SelectedValue.ToString());
        }

        protected void cmbIssueType_SelectedIndexChanged(object sender, Telerik.Web.UI.RadComboBoxSelectedIndexChangedEventArgs e)
        {
            if (cmbIssueType.SelectedValue == "T")
            {
                rdReturndate.Visible = true;
            }
           
        }

        protected void cmbIssueStatus_SelectedIndexChanged(object sender, Telerik.Web.UI.RadComboBoxSelectedIndexChangedEventArgs e)
        {

            if (cmbIssueStatus.SelectedValue == "T")
            {
                lblreceievedate.Visible = true;
                rdReturndate.Visible = true;
                RequiredFieldValidator9.Enabled = true;
            }
            else
            {
                lblreceievedate.Visible = false;
                rdReturndate.Visible = false;
                RequiredFieldValidator9.Enabled = false;

                ShowCheckedItems(cmbPersonto, itemsClientSide);
                btnSubmit.Visible = true;
                 
            }


            SearchItems();
          

        }

        protected void cmbbranchfrom_SelectedIndexChanged(object sender, Telerik.Web.UI.RadComboBoxSelectedIndexChangedEventArgs e)
        {

            //if (cmbbranchfrom.SelectedValue != "Choose Branch")
            //{
            //    GetEmployee("I");
            //}

        }

        protected void cmbBranchto_SelectedIndexChanged(object sender, Telerik.Web.UI.RadComboBoxSelectedIndexChangedEventArgs e)
        {

            //if (cmbBranchto.SelectedValue != "Choose Branch")
            //{
            //    GetDepartment("R",0);
            //}
        
        }

        protected void cmbDepartmentfrom_SelectedIndexChanged(object sender, Telerik.Web.UI.RadComboBoxSelectedIndexChangedEventArgs e)
        {
           // GetEmployee("I");
        }

        protected void cmbDepartmentto_SelectedIndexChanged(object sender, Telerik.Web.UI.RadComboBoxSelectedIndexChangedEventArgs e)
        {
            GetEmployee("E");
            btnSubmit.Visible = true;
        }

        //protected void cmbPersonto_SelectedIndexChanged(object sender, Telerik.Web.UI.RadComboBoxSelectedIndexChangedEventArgs e)
        //{
        //    btnSubmit.Visible = true;
        //}

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
                Double CurBal = Convert.ToDouble(lblCurrentBalance.Text);
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

                    if (lblItem != null)  
                    {
                        string itemid = lblItem.Text;
                        string qtty = lblQty.Text;
                        float bal = float.Parse(lblBal.Text);


                        DataRow[] ItemRow = ds.Tables[0].Select("[Item Code] ='" + itemid + "'");

                        ItemRow[0]["Qty Issued"] = qtty == "" ? "0" : qtty;

                        ItemRow[0]["Qty Issued"] = float.Parse(qtty) > bal ? lblBal.Text : qtty;
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

        protected void btnSubmitItem_Click(object sender, EventArgs e)
        {
            btnSubmitItem.Visible = false;

            if (ViewState["GINSaved"] == null)
            {
                ViewState["GINSaved"] = "SavingGIN";
            }
            else
            {
                Response.Redirect("IssueItems.aspx", false);
                return;
            }

            

            HttpCookie IMS = Request.Cookies["IMS"];
            if (IMS == null)
                Response.Redirect("logout.aspx");


            DataTable dt1 = (DataTable)ViewState["dt"];

            DataTable dt = SetDataTable(dt1);

            dt = RemoveZeroQtty(dt);

            if (dt.Rows.Count == 0)
            {
                showMessageBox("Add Items first!!!!!");

                //   cmbbranchfrom.Enabled = true;

               // cmbIssuedby.Enabled = true;
                cmbBranchto.Enabled = true;

                cmbPersonto.Enabled = true;
                cmbDepartmentto.Enabled = true;

                cmbIssueStatus.Enabled = true;
                cmbIssueType.Enabled = true;

            }
            else
            {

                im.fkdepartid = int.Parse(IMS["udptid"] == null ? "0" : IMS["udptid"]);
                im.CreatedBy = int.Parse(IMS["uid"]);

                im.OLDGIN = int.Parse(txtoldGIN.Text);

                if (im.OLDGIN == 0)
                {
                    im.Token = "I";
                }
                else
                {
                    im.Token = "A";
                }

                int get_GINNo = 0;

                GetUserInfo();

                if (UMan.Ugid == 31 || UMan.Ugid == 32 || UMan.Ugid == 28)
                {
                    im.fkIssueByDeptID =  14;
                    im.fkIssueToDeptID = 14;
                }
                else 
                {
                    im.fkIssueByDeptID = int.Parse(cmbDepartmentfrom.SelectedValue.ToString());
                    im.fkIssueToDeptID = int.Parse(cmbDepartmentto.SelectedValue.ToString());
                }

                im.fkIssueByBranchID = UMan.Ubrhid;
                im.fkIssueToBranchID = UMan.Ubrhid;
               
                im.fkIssueByID = UMan.Uid;
                im.fkIssuedToID = int.Parse(cmbPersonto.SelectedValue.ToString() == "" ? im.CreatedBy.ToString() : cmbPersonto.SelectedValue.ToString());
                im.IssuedStatus = cmbIssueStatus.SelectedValue;
                im.IssuedType = "I";
                im.Remarks = txtremarks.Text;
                im.IssuetoID = txtpersonid.Text;

                im.IUIssueItemInternal(dt);
                
                //try
                //{
                //    im.IUIssueItemInternal(dt);
                //}
                //catch(Exception ee)
                //{
                //    //This is a Test error handling from SQL Server Stored Procedure through RaiseError Event.
                //    //RAISERROR('Fee Structure Setup Not in Admission Setup Table.',16,1);
                //    string errmsg = ee.Message.ToString();

                //    if (errmsg == "Fee Structure Setup Not in Admission Setup Table.")
                //    {
                //        showMessageBox(ee.Message);
                //    }
                //}

                //im.IUIssueItemInternal(dt, ref get_GINNo);

                int storeid = im.GetStore(im.fkIssueByBranchID);

                if (im.fkIssueByDeptID == 14 && im.fkIssueByID == 1527)
                {
                    storeid = 1;
                }
               

                if (im.fkIssueByDeptID == 10)
                {
                    storeid = 22;
                }
                if (im.fkIssueByID == 94)
                {
                    storeid = 2;
                }


                int i;  // im.RptSerial(im.fkIssueByBranchID, storeid, im.fkIssueByDeptID, 3, im.IssuedStatus);

                if (im.OLDGIN != 0)
                {
                    i = im.OLDGIN;
                }
                else
                {
                    i = im.RptSerial(im.fkIssueByBranchID, storeid, im.fkIssueByDeptID, 3, im.IssuedStatus);
                }

                txtginno.Text = i.ToString();

                showMessageBox("Record Successfully Saved, Your (GIN) Goods Issued Note # is : " + i.ToString());
                
        //        im.SendReportEmail(im.fkIssueByBranchID, storeid, im.fkIssueByDeptID, 3, i);
         

                //Response.Redirect("ReportsMain.aspx?rptname=GoodsIssueNote&gino=" + txtginno.Text,false);

                //btnPrint_Click(sender, e);
                //btnPrintGatePass_Click(sender, e);

                SetupForm();

                ViewState["dt"] = null;
                grdItems.DataSource = null;
                grdItems.DataBind();



                // cmbbranchfrom.Enabled = true;
  
                //cmbIssuedby.Enabled = true;
                //cmbBranchto.Enabled = true;
 
                cmbPersonto.Enabled = true;
                cmbDepartmentto.Enabled = true;

                cmbIssueStatus.Enabled = true;
                cmbIssueType.Enabled = true;

            }

        }

        protected void btnSubmit_Click(object sender, EventArgs e)
        {

           
        }

        protected void btnPrint_Click(object sender, EventArgs e)
        {
            //Response.Redirect("ReportsMain.aspx?rptname=GoodsIssueNote&gino=" + txtginno.Text);

            //string strurl = "<script> window.open('ReportsMain.aspx?rptname=GoodsIssueNote&gino=" + txtginno.Text + "'); </script>";

            //string strurl = "ReportsMain.aspx?rptname=GoodsIssueNote&gino=" + txtginno.Text;
            //Page.ClientScript.RegisterStartupScript(this.GetType(), "script", "OpenWindow", "window.open(" + strurl + ",'_newtab');", true);

            //Response.Write(strurl);

            string url = "ReportsMain.aspx?rptname=GoodsIssueNote&gino=" + txtginno.Text;

            Response.Write("<script>" + "window.open(" + url + ",'_newtab')" + "</script>");

            //Response.Write("<script>" + "window.open(" + url + ",'_blank')" + "</script>");

          //   string s = "window.open('" + url + "', 'popup_window', 'width=300,height=100,left=100,top=100,resizable=yes');";
          //  ClientScript.RegisterStartupScript(this.GetType(), "script", s, true);


        }

        protected void btnOldGIN_Click(object sender, EventArgs e)
        {
            txtoldGIN.Visible = true;
        }

        protected void cmbCatagories_SelectedIndexChanged(object sender, Telerik.Web.UI.RadComboBoxSelectedIndexChangedEventArgs e)
        {

            if (cmbCatagories.SelectedValue == "1" || cmbCatagories.SelectedValue == "2")
            {
                cmbSystem.SelectedValue = "4";
            }
            else
            {
                cmbSystem.SelectedValue = GetSysID().ToString();
            }
        
    
            GetSubCategory(int.Parse(cmbCatagories.SelectedValue.ToString()));

            GetItemHead(int.Parse(cmbSubCategory.SelectedValue.ToString()));

            Telerik.Web.UI.RadComboBoxItem hd = new Telerik.Web.UI.RadComboBoxItem();
            hd.Text = "Choose Items Head";
            hd.Value = "Choose Items Head";
            cmbItemHead.Items.Add(hd);
            cmbItemHead.SelectedIndex = cmbItemHead.Items.Count - 1;



             RadSlider1.Focus();
        }

        protected void cmbSubCategory_SelectedIndexChanged(object sender, Telerik.Web.UI.RadComboBoxSelectedIndexChangedEventArgs e)
        {
            GetItemHead(int.Parse(cmbSubCategory.SelectedValue.ToString()));

            Telerik.Web.UI.RadComboBoxItem hd = new Telerik.Web.UI.RadComboBoxItem();
            hd.Text = "Choose Items Head";
            hd.Value = "Choose Items Head";
            cmbItemHead.Items.Add(hd);
            cmbItemHead.SelectedIndex = cmbItemHead.Items.Count - 1;


            cmbItem.Items.Clear();

            Telerik.Web.UI.RadComboBoxItem ib = new Telerik.Web.UI.RadComboBoxItem();
            ib.Text = "Choose Item";
            ib.Value = "Choose Item";
            cmbItem.Items.Add(ib);
            cmbItem.SelectedIndex = cmbItem.Items.Count - 1;


            RadSlider1.Focus();
        }

        protected void cmbItemHead_SelectedIndexChanged(object sender, Telerik.Web.UI.RadComboBoxSelectedIndexChangedEventArgs e)
        {
            GetItems(int.Parse(cmbItemHead.SelectedValue.ToString()),2);
            RadSlider1.Focus();
        }

        protected void cmbItemSearch_SelectedIndexChanged(object sender, Telerik.Web.UI.RadComboBoxSelectedIndexChangedEventArgs e)
        {
            GetItems(0, 1);
            ConfirmItemEntry();

            //btnSubmit.Visible = true;
        }

        protected void btnClose_Click(object sender, EventArgs e)
        {
            ViewState["GINSaved"] = null;
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
                sb.Append("<h3>Selected Persons:</h3><ul class=\"results\">");

                foreach (var item in collection)
                {
                    sb.Append("<li>" + item.Text + "</li>");
                    personid = personid + item.Value + ",";
                    persons = persons + item.Text + ",";                    
                }
                sb.Append("</ul>");

                literal.Text = sb.ToString();
               // iman.IssuetoID = personid.TrimStart();
                txtpersonid.Text = personid.TrimStart();
                txtremarks.Text = persons;
           
            }
            else
            {
                literal.Text = "<p>No person selected</p>";
                
            }
        }

        //OnSelectedIndexChanged="cmbPersonto_SelectedIndexChanged"
        protected void cmbPersonto_SelectedIndexChanged(object sender, Telerik.Web.UI.RadComboBoxSelectedIndexChangedEventArgs e)
        {
            cmbIssueStatus.Visible = true;
        }

        protected void ShowStatus()
        {
            cmbIssueStatus.Visible = true;
           // cmbIssueStatus.SelectedIndex = 2;
            cmbItemSearch.Focus();
        }
          



        private void generate_controls()
        {

            //generating the lable controls:
                  //int n = Int32.Parse(ddllabels.SelectedItem.Value);
                  //for (int i = 1; i <= n; i++)
                  //{
                  //   Label lbl = new Label();
                  //   lbl.Text = "Label" + (i).ToString();
                  //   pnldynamic.Controls.Add(lbl);
                  //   pnldynamic.Controls.Add(new LiteralControl("<br />"));
                  //}
      
                  //generating the text box controls:

                  //int m = Int32.Parse(ddltextbox.SelectedItem.Value);
                  //for (int i = 1; i <= m; i++)
                  //{
                  //   TextBox txt = new TextBox();
                  //   txt.Text = "Text Box" + (i).ToString();
                  //   pnldynamic.Controls.Add(txt);
                  //   pnldynamic.Controls.Add(new LiteralControl("<br />"));
                  //}



        }


        #endregion

    }
}