using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using BLL;
using Telerik.Web.UI;
using System.Data;


namespace IMS
{
    /// <summary>
    /// Class IssueInventory. This Class is use to Produce GIN (Goods Issue Note) From One Branch/Store/Warehouse to Another Branch.
    /// </summary>
    /// <seealso cref="System.Web.UI.Page" />
    public partial class MaterialReturn : System.Web.UI.Page
    {
        /// <summary>
        /// The im = The Item Manager Class use to Process any kind of query and procedure which is related to the item processing.
        /// </summary>
        ItemManager im = new ItemManager();
        /// <summary>
        /// The iman
        /// </summary>
        IMSManager iman = new IMSManager();
        /// <summary>
        /// The uman
        /// </summary>
        UserManager Uman = new UserManager();

        VendorManager vm = new VendorManager();


        #region Helper Methods

        /// <summary>
        /// Gets the user information.
        /// </summary>
        public void GetUserInfo()
        {
            HttpCookie IMS = Request.Cookies["IMS"];
            if (IMS == null)
                Response.Redirect("logout.aspx");

            Uman.Uid = int.Parse(IMS["uid"]);
            Uman.Ubrhid = int.Parse(IMS["ubrhid"]);
            Uman.Pkdeptid = int.Parse(IMS["udptid"]);
            Uman.Ugid = int.Parse(IMS["ugroupid"]);

            Uman.Grpuserdeptid = int.Parse(IMS["grpuserdptid"]);
            Uman.Grpuserbrhid = int.Parse(IMS["grpuserbrhid"]);
            Uman.Grpuserstoreid = int.Parse(IMS["grpuserstoreid"]);


        }


        /// <summary>
        /// Gets the system.
        /// </summary>
        public void GetSystem()
        {
            cmbSystem.DataSource = iman.GetSystem();
            cmbSystem.DataTextField = "SystemName";
            cmbSystem.DataValueField = "pksysID";
            cmbSystem.DataBind();

        }

        /// <summary>
        /// Gets the sysinfo.
        /// </summary>
        /// <returns>System.Int32.</returns>
        public int GetSysinfo()
        {
            HttpCookie IMS = Request.Cookies["IMS"];
            if (IMS == null)
                Response.Redirect("logout.aspx");
           

            int sysid = Uman.GetSysinfo(int.Parse(IMS["ubrhid"]));

            return sysid;

        }

        /// <summary>
        /// Gets the system identifier.
        /// </summary>
        /// <returns>System.Int32.</returns>
        public int GetSysID()
        { 
          //  im.fkcatid = int.Parse(cmbCatagories.SelectedValue.ToString());
            int sysid;

            //if (im.fkcatid == 1 || im.fkcatid == 2 || im.fkcatid == 8)
            //{
            //    sysid = 4;
            //}
            //else
            //{ 
                sysid = int.Parse(cmbSystem.SelectedValue.ToString());
            //}

            return sysid;
        }
        /// <summary>
        /// Users the settings.
        /// </summary>
        public void UserSettings()
        {

            im.fkIssueToBranchID = Uman.Ubrhid;
            im.fkIssueToDeptID = Uman.Pkdeptid;
            im.fkIssueToStoreID = Uman.PkstoreID;


            if (Uman.Ugid==31 || Uman.Ugid==32)
            {
                int sysid = GetSysinfo();
                cmbSystem.SelectedValue = sysid.ToString();
                cmbSystem.Enabled = false;

                cmbDepartmentfrom.SelectedValue = "14";
                cmbDepartmentfrom.Enabled = false;

               // cmbIssuedby.Enabled = false;

            }

            if (Uman.Ugid == 37)
            {
                
                cmbstorefrom.SelectedValue = "22";
                cmbstorefrom.DataBind();
                cmbSystem.SelectedValue = "4";
                cmbSystem.DataBind();

                cmbstorefrom.Enabled = false;
                cmbDepartmentfrom.Enabled = false;
                cmbSystem.Enabled = false;
            }

            if (Uman.Ugid == 38)
            {
              
                cmbstorefrom.Visible = false;
                cmbSystem.SelectedValue = "4";
                cmbSystem.DataBind();

                cmbstorefrom.Enabled = false;
                cmbDepartmentfrom.Enabled = true;
                cmbSystem.Enabled = false;
            }


            if (Uman.Ugid==28 || Uman.Ugid==30)
            {
                cmbIssueType.SelectedValue = "E";
                cmbIssueType.Enabled = false;
            }

        }

        /// <summary>
        /// Gets the category.
        /// </summary>
 
   
        /// <summary>
        /// Gets the sub category.
        /// </summary>
        /// <param name="catid">The catid.</param>
 

        /// <summary>
        /// Gets the item head.
        /// </summary>
        /// <param name="subcatid">The subcatid.</param>
     
        /// <summary>
        /// Gets the items.
        /// </summary>
        /// <param name="ithead">The ithead.</param>
        /// <param name="token">The token.</param>
        public void GetItems(int ithead, int token)
        {

 

                im.Token = "S";
                im.pksysID = GetSysID();

                int deptfromid;
                int storeid;
                GetUserInfo();

                DataTable di;

                if (Uman.Ugid == 31 || Uman.Ugid == 32)
                {
                    deptfromid = 14;
                }
                else
                {
                    deptfromid = int.Parse(cmbDepartmentfrom.SelectedValue.ToString());

                }

                if (Uman.Ugid != 38)
                {
                    storeid = int.Parse(cmbstorefrom.SelectedValue.ToString());

                    di = im.GetStoreInventory(im.pksysID, storeid, deptfromid);
       
                }
                else
                {
                    im.fkbrhid = Uman.Ubrhid;
                    di = im.GetDeptInventory(deptfromid, im.fkbrhid, 0);
                }

                //DataTable di = im.GetStoreInventory(im.pksysID, storeid, deptfromid);

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


        public void GetVendors()
        {
            vm.Token = "V";
            cmbVendors.DataSource = vm.GetVondors();
            cmbVendors.DataTextField = "VendorName";
            cmbVendors.DataValueField = "pkVendID";
            cmbVendors.DataBind();
        }

 
        /// <summary>
        /// Confirms the item entry.
        /// </summary>
       public void ConfirmItemEntry()
        {
            if (Page.IsValid)
            {

                DataTable dt = (DataTable)ViewState["dt"];
                DataTable ib;

                cmbItem.SelectedValue = cmbItemSearch.SelectedValue;  
 
                if (cmbstorefrom.SelectedValue.ToString() != "No Store in this Branch")
                {
                    ib = im.getItembalance(int.Parse(cmbbranchfrom.SelectedValue.ToString()), int.Parse(cmbstorefrom.SelectedValue.ToString()), cmbItem.SelectedValue.ToString(), "S");
                }
                else
                {
                    im.fkdepartid = Uman.Pkdeptid;

                    ib = im.getItembalance(int.Parse(cmbbranchfrom.SelectedValue.ToString()), im.fkdepartid, cmbItem.SelectedValue.ToString(), "D");
                }
                
               

                if (dt.Columns.Count == 0)
                {

                    dt.Columns.Add("Issue Branch Id", typeof(int));
                    dt.Columns.Add("Issue Branch Name", typeof(string));
                    dt.Columns.Add("Issue Store Id", typeof(int));
                    dt.Columns.Add("Issue Store Name", typeof(string));
                    dt.Columns.Add("Issue by Id", typeof(int));
                    dt.Columns.Add("Issue by Name", typeof(string));
      
                    dt.Columns.Add("Issue to Vendor", typeof(int));

                    dt.Columns.Add("Item Code", typeof(string));
                    dt.Columns.Add("Item Name", typeof(string));
                    dt.Columns.Add("Balance", typeof(Single));
                    dt.Columns.Add("Qty Issued", typeof(Single));
                    dt.Columns.Add("Item Status", typeof(string));
                    dt.Columns.Add("Item Type", typeof(string));
                    dt.Columns.Add("Ackdate", typeof(string));
                    dt.Columns.Add("Retdate", typeof(string));

                }

                int tr = int.Parse(dt.Rows.Count.ToString());

                if (dt.Rows.Count > 0)
                {
                    bool ck = false;
                    //bool ck = checkItem(dt, cmbItem.SelectedValue.ToString(), int.Parse(cmbStoreto.SelectedValue.ToString()), cmbDepartmentto.SelectedItem.Text.ToString());

                    if (ck == false)
                    {
                        DataRow dr = dt.NewRow();
                        dr["Issue Branch Id"] = int.Parse(cmbbranchfrom.SelectedValue.ToString());
                        dr["Issue Branch Name"] = cmbbranchfrom.SelectedItem.Text.ToString();
                        dr["Issue Store Id"] = int.Parse(cmbstorefrom.SelectedValue.ToString() == "No Store in this Branch" ? "0" : cmbstorefrom.SelectedValue.ToString());
                        dr["Issue Store Name"] = cmbstorefrom.SelectedItem.Text.ToString();
                        dr["Issue by Id"] = dr["Issue by Id"] = int.Parse(cmbIssuedby.SelectedValue.ToString() == "No Employees in Branch" ? Uman.Uid.ToString() : cmbIssuedby.SelectedValue.ToString());
                        dr["Issue by Name"] = cmbIssuedby.SelectedItem.Text.ToString();

                        dr["Issue to Vendor"] = int.Parse(cmbVendors.SelectedValue.ToString() == "No Employees in Branch" ? "0" : cmbVendors.SelectedValue.ToString());

                        //dr["Item Code"] = cmbItem.SelectedValue.ToString();
                        //dr["Item Name"] = cmbItem.SelectedItem.Text.ToString();

                        dr["Item Code"] = cmbItemSearch.SelectedValue.ToString();
                        dr["Item Name"] = cmbItemSearch.SelectedItem.Text.ToString();


                        dr["Balance"] = Single.Parse(ib.Rows[0]["CRBalance"].ToString() == "" ? "0" : ib.Rows[0]["CRBalance"].ToString());
                        dr["Qty Issued"] = 0;
                        dr["Item Status"] = cmbIssueStatus.SelectedValue.ToString();
                        dr["Item Type"] = cmbIssueType.SelectedValue.ToString();
                        if (rdackdate.Text != "")
                            dr["Ackdate"] = rdackdate.Text.ToString();

                        if (rdReturndate.Visible == true)
                            dr["Retdate"] = rdReturndate.Text.ToString();
                        dt.Rows.Add(dr);

                        cmbbranchfrom.Enabled = false;
                        cmbstorefrom.Enabled = false;
                        cmbIssuedby.Enabled = false;
                        //cmbIssueStatus.Enabled = false;
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
                    dr["Issue Branch Id"] = int.Parse(cmbbranchfrom.SelectedValue.ToString());
                    dr["Issue Branch Name"] = cmbbranchfrom.SelectedItem.Text.ToString();
                    dr["Issue Store Id"] = int.Parse(cmbstorefrom.SelectedValue.ToString()=="No Store in this Branch" ? "0":cmbstorefrom.SelectedValue.ToString());
                    dr["Issue Store Name"] = cmbstorefrom.SelectedItem.Text.ToString();
                    dr["Issue by Id"] = int.Parse(cmbIssuedby.SelectedValue.ToString() == "No Employees in Branch" ? Uman.Uid.ToString() : cmbIssuedby.SelectedValue.ToString());
                    dr["Issue by Name"] = cmbIssuedby.SelectedItem.Text.ToString();

                    dr["Issue to Vendor"] = int.Parse(cmbVendors.SelectedValue.ToString() == "No Employees in Branch" ? "0" : cmbVendors.SelectedValue.ToString());
 
                    //dr["Item Code"] = cmbItem.SelectedValue.ToString();
                    //dr["Item Name"] = cmbItem.SelectedItem.Text.ToString();

                    dr["Item Code"] = cmbItemSearch.SelectedValue.ToString();
                    dr["Item Name"] = cmbItemSearch.SelectedItem.Text.ToString();


                    dr["Balance"] = Single.Parse(ib.Rows[0]["CRBalance"].ToString() == "" ? "0" : ib.Rows[0]["CRBalance"].ToString());
                    dr["Qty Issued"] = 0;
                    dr["Item Status"] = cmbIssueStatus.SelectedValue.ToString();
                    dr["Item Type"] = cmbIssueType.SelectedValue.ToString();

                    if (rdackdate.Text != "")
                        dr["Ackdate"] = rdackdate.Text.ToString();

                    if (rdReturndate.Visible == true)
                        dr["Retdate"] = rdReturndate.Text.ToString();

                    dt.Rows.Add(dr);

                    cmbbranchfrom.Enabled = false;
                    cmbstorefrom.Enabled = false;
                    cmbIssuedby.Enabled = false;
 

                 //   cmbIssueStatus.Enabled = false;
                    cmbIssueType.Enabled = false;
                }

                ViewState["GINSaved"] = null;
                ViewState["dt"] = dt;
                grdItems.DataSource = dt;
                grdItems.DataBind();

                grdItems.Visible = true;

                btnSubmitItem.Visible = true;
            }


            btnSubmitItem.Visible = true;
        
        }

       /// <summary>
       /// Searches the items.
       /// </summary>
       public void SearchItems()
        {


  
                im.Token = "S";
                im.pksysID = GetSysID();
                int deptfromid;
                int storeid=0;
                GetUserInfo();
                DataTable di;

                if (Uman.Ugid == 31 || Uman.Ugid == 32)
                {
                    deptfromid = 14;
                }
                else
                {
                    deptfromid = int.Parse(cmbDepartmentfrom.SelectedValue.ToString());

                }

                if (Uman.Ugid != 38)
                {
                    storeid = int.Parse(cmbstorefrom.SelectedValue.ToString());

                    if (cmbDepartmentfrom.SelectedValue.ToString() != "14")
                    {

                        if (deptfromid == 10)
                        {
                            storeid = 22;
                        }
                        else
                        {
                            deptfromid = 2;
                        }

                        im.fkbrhid = Uman.Ubrhid;
                        di = im.GetDeptInventory(deptfromid, im.fkbrhid, 0);

                    }
                    else
                    {
                        //  DataTable di = im.GetStoreInventory(storeid, deptfromid);
                        di = im.GetStoreInventory(im.pksysID, storeid, deptfromid);
                    }
                }
                else
                {
                    im.fkbrhid = Uman.Ubrhid;
                    di = im.GetDeptInventory(deptfromid, im.fkbrhid, 0);
                }
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
                    cmbItemSearch.SelectedIndex = 0;
                 }

        }

       /// <summary>
       /// Setups the form.
       /// </summary>
       /// <param name="start">if set to <c>true</c> [start].</param>
        private void SetupForm(bool start)
        {
            //Uman.Grpuserdeptid = int.Parse(IMS["grpuserdptid"]);
            //Uman.Grpuserbrhid = int.Parse(IMS["grpuserbrhid"]);
            //Uman.Grpuserstoreid = int.Parse(IMS["grpuserstoreid"]);


            DataTable dt = new DataTable();
            ViewState["dt"] = dt;


            HttpCookie IMS = Request.Cookies["IMS"];
            if (IMS == null)
                Response.Redirect("logout.aspx");

            GetUserInfo();

            GetSystem();

            DataSet db = im.GetBranches();

            cmbbranchfrom.DataSource = db.Tables[0];
            cmbbranchfrom.DataTextField = "brhName";
            cmbbranchfrom.DataValueField = "pkbrhID";
            cmbbranchfrom.SelectedValue = Uman.Grpuserbrhid.ToString();

            iman.Uid = int.Parse(IMS["uid"]);
            iman.Pkdeptid = Uman.Grpuserdeptid;

            cmbbranchfrom.DataBind();
            cmbbranchfrom.Enabled = false;

            cmbIssueStatus.Enabled = true;

            im.Token = "FROM";
            im.fkdepartid = iman.Pkdeptid;

            if (cmbbranchfrom.SelectedValue != "Choose Branch")
            {
                if (Uman.Ugid == 28 || Uman.Ugid == 30 || Uman.Ugid == 31)
                {
                    DataSet ds = im.GetStores(int.Parse(cmbbranchfrom.SelectedValue.ToString()));
                    cmbstorefrom.DataSource = ds.Tables[0];
                    cmbstorefrom.DataTextField = "StoreName";
                    cmbstorefrom.DataValueField = "pkStoreID";
                    cmbstorefrom.DataBind();
                    cmbstorefrom.SelectedIndex = 0;
                    cmbIssuedby.SelectedIndex = 1;
                }
                else if(Uman.Ugid == 37)
                {
                    DataSet ds = im.GetStores(int.Parse(cmbbranchfrom.SelectedValue.ToString()));
                    cmbstorefrom.DataSource = ds.Tables[0];
                    cmbstorefrom.DataTextField = "StoreName";
                    cmbstorefrom.DataValueField = "pkStoreID";
                    cmbstorefrom.DataBind();                    
                    cmbstorefrom.SelectedIndex = 2;
                    cmbIssuedby.SelectedIndex = 1;
                }
                else
                {
                    cmbstorefrom.Items.Clear();
                    Telerik.Web.UI.RadComboBoxItem s = new Telerik.Web.UI.RadComboBoxItem();
                    s.Text = "No Store in this Branch";
                    s.Value = "No Store in this Branch";
                    cmbstorefrom.Items.Add(s);
                    cmbstorefrom.SelectedIndex = cmbstorefrom.Items.Count - 1;
                }

                // int dpf = iman.Pkdeptid;
                DataSet ddf = im.GetDepartment(iman.Uid);
                cmbDepartmentfrom.DataSource = ddf.Tables[0];
                cmbDepartmentfrom.DataTextField = "deptName";
                cmbDepartmentfrom.DataValueField = "pkdeptID";
                cmbDepartmentfrom.DataBind();

                cmbDepartmentfrom.SelectedValue = iman.Pkdeptid.ToString();

                im.fkIssueByID = iman.Uid;



                DataSet de = im.GetEmployees(int.Parse(IMS["ubrhid"]), int.Parse(cmbDepartmentfrom.SelectedValue.ToString()), "I");

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
                cmbstorefrom.Items.Clear();
                Telerik.Web.UI.RadComboBoxItem s = new Telerik.Web.UI.RadComboBoxItem();
                s.Text = "Choose Store";
                s.Value = "Choose Store";
                cmbstorefrom.Items.Add(s);
                cmbstorefrom.SelectedIndex = cmbstorefrom.Items.Count - 1;

                cmbIssuedby.Items.Clear();
                Telerik.Web.UI.RadComboBoxItem ib = new Telerik.Web.UI.RadComboBoxItem();
                ib.Text = "Choose Employee";
                ib.Value = "Choose Employee";
                cmbIssuedby.Items.Add(ib);
                cmbIssuedby.SelectedIndex = cmbIssuedby.Items.Count - 1;


            }

            if (start==true)
            {
                    Telerik.Web.UI.RadComboBoxItem sys = new Telerik.Web.UI.RadComboBoxItem();
                    sys.Text = "Choose System";
                    sys.Value = "Choose System";
                    cmbSystem.Items.Add(sys);
                    cmbSystem.SelectedIndex = 0;

                    Telerik.Web.UI.RadComboBoxItem idf = new Telerik.Web.UI.RadComboBoxItem();
                    idf.Text = "Choose Department";
                    idf.Value = "Choose Department";
                    cmbDepartmentfrom.Items.Add(idf);
                    cmbDepartmentfrom.SelectedIndex = cmbDepartmentfrom.Items.Count - 2;

            }

            GetVendors();
 

            Telerik.Web.UI.RadComboBoxItem it = new Telerik.Web.UI.RadComboBoxItem();
            it.Text = "Choose Item";
            it.Value = "Choose Item";
            cmbItem.Items.Add(it);
            cmbItem.SelectedIndex = cmbItem.Items.Count - 1;

            //rdackdate.Text = DateTime.Today.ToString("dd/MM/yyyy");
            rdackdate.Text = DateTime.Today.ToString("MM/dd/yyyy"); 
            im.IssueConfirm = 0;

            UserSettings();
        
        
        }

        /// <summary>
        /// Checks the item.
        /// </summary>
        /// <param name="dt">The dt.</param>
        /// <param name="InvCode">The inv code.</param>
        /// <param name="Storeid">The storeid.</param>
        /// <param name="deptname">The deptname.</param>
        /// <returns><c>true</c> if XXXX, <c>false</c> otherwise.</returns>
        public bool checkItem(DataTable dt, String InvCode, int Storeid, string deptname)
        {
            bool returnval = false;

                foreach (DataRow dr in dt.Rows)
                {

                    if ((dr["Item Code"].ToString() == InvCode) && ((dr["Issue to Department"].ToString() == deptname) && ((dr["Issue to Store Id"].ToString() == Storeid.ToString()))))
                    {
                        returnval = true;
                    }

                }
            return returnval;
        }

        /// <summary>
        /// Checks the item balance.
        /// </summary>
        /// <param name="dt">The dt.</param>
        /// <param name="InvCode">The inv code.</param>
        /// <param name="Storeid">The storeid.</param>
        /// <param name="balance">The balance.</param>
        /// <param name="qtyissue">The qtyissue.</param>
        /// <returns><c>true</c> if XXXX, <c>false</c> otherwise.</returns>
        public bool checkItemBalance(DataTable dt, String InvCode, int Storeid, Single balance, Single qtyissue)
        {
            bool returnval = false;

            DataRow[] result = dt.Select("[Item Code] ='" + InvCode +"' AND [Issue Store Id] ="+ Storeid);

            //DataRow[] result = dt.Select("[InvCode] ='" + InvCode + "'");

            Single i = 0;

            foreach (DataRow row in result)
            {
               i = i + Single.Parse(row["Qty Issued"].ToString());
            }

            if (balance < i)
                returnval = true;
            
            return returnval;
        }

        /// <summary>
        /// Shows the message box.
        /// </summary>
        /// <param name="message">The message.</param>
        protected void showMessageBox(string message)
        {
            string sScript;
            message = message.Replace("'", "\'");
            sScript = String.Format("alert('{0}');", message);
            ScriptManager.RegisterStartupScript(this, this.GetType(), "alert", sScript, true);
        }

        #endregion

        #region Events 
                
        /// <summary>
        /// Handles the Load event of the Page control.
        /// </summary>
        /// <param name="sender">The source of the event.</param>
        /// <param name="e">The <see cref="EventArgs"/> instance containing the event data.</param>
        protected void Page_Load(object sender, EventArgs e)
        {
            cmbItemSearch.Filter = RadComboBoxFilter.Contains; 
            if (Page.IsPostBack == false)
            {
               
                SetupForm(true);
            }
        }

        /// <summary>
        /// Handles the SelectedIndexChanged event of the cmbSystem control.
        /// </summary>
        /// <param name="sender">The source of the event.</param>
        /// <param name="e">The <see cref="Telerik.Web.UI.RadComboBoxSelectedIndexChangedEventArgs"/> instance containing the event data.</param>
        protected void cmbSystem_SelectedIndexChanged(object sender, Telerik.Web.UI.RadComboBoxSelectedIndexChangedEventArgs e)
        {
            //im.pksysID = int.Parse(cmbSystem.SelectedValue.ToString());

            //if (im.pksysID == 4)
            //{
            //    cmbCatagories.SelectedValue = "1";
            //}

            SearchItems();
            //cmbBranchto.SelectedValue = "3";
            cmbIssueStatus.Focus();
        }

        /// <summary>
        /// Handles the SelectedIndexChanged event of the cmbSystemTo control.
        /// </summary>
        /// <param name="sender">The source of the event.</param>
        /// <param name="e">The <see cref="Telerik.Web.UI.RadComboBoxSelectedIndexChangedEventArgs"/> instance containing the event data.</param>
 
        /// <summary>
        /// Handles the SelectedIndexChanged event of the cmbIssueType control.
        /// </summary>
        /// <param name="sender">The source of the event.</param>
        /// <param name="e">The <see cref="Telerik.Web.UI.RadComboBoxSelectedIndexChangedEventArgs"/> instance containing the event data.</param>
        protected void cmbIssueType_SelectedIndexChanged(object sender, Telerik.Web.UI.RadComboBoxSelectedIndexChangedEventArgs e)
        {
            if (cmbIssueType.SelectedValue == "I")
            {
              Response.Redirect("IssueQuickItems.aspx?issuetype=I");
            }

        }

        /// <summary>
        /// Handles the SelectedIndexChanged event of the cmbIssueStatus control.
        /// </summary>
        /// <param name="sender">The source of the event.</param>
        /// <param name="e">The <see cref="Telerik.Web.UI.RadComboBoxSelectedIndexChangedEventArgs"/> instance containing the event data.</param>
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
            }

            SearchItems();

        }

        /// <summary>
        /// Handles the SelectedIndexChanged event of the cmbbranchfrom control.
        /// </summary>
        /// <param name="sender">The source of the event.</param>
        /// <param name="e">The <see cref="Telerik.Web.UI.RadComboBoxSelectedIndexChangedEventArgs"/> instance containing the event data.</param>
        protected void cmbbranchfrom_SelectedIndexChanged(object sender, Telerik.Web.UI.RadComboBoxSelectedIndexChangedEventArgs e)
        {
            im.IssuedType = cmbIssueType.SelectedValue.ToString();
            im.Token = "FROM";
            im.fkdepartid = int.Parse(cmbDepartmentfrom.SelectedValue.ToString());
            im.fkIssueByStoreID = int.Parse(cmbstorefrom.SelectedValue.ToString());

            if (cmbbranchfrom.SelectedValue != "Choose Branch")
            {
                DataSet ds = im.GetStores(int.Parse(cmbbranchfrom.SelectedValue.ToString()));

                if (ds.Tables[0].Rows.Count > 0)
                {

                    //choose store
                    cmbstorefrom.DataSource = ds.Tables[0];
                    cmbstorefrom.DataTextField = "StoreName";
                    cmbstorefrom.DataValueField = "pkStoreID";
                    cmbstorefrom.DataBind();



                    Telerik.Web.UI.RadComboBoxItem s = new Telerik.Web.UI.RadComboBoxItem();
                    s.Text = "Choose Store";
                    s.Value = "Choose Store";
                    cmbstorefrom.Items.Add(s);
                    cmbstorefrom.SelectedIndex = cmbstorefrom.Items.Count - 1;

                }

                else
                {
                    cmbstorefrom.Items.Clear();
                    Telerik.Web.UI.RadComboBoxItem s = new Telerik.Web.UI.RadComboBoxItem();
                    s.Text = "No Store in this Branch";
                    s.Value = "No Store in this Branch";
                    cmbstorefrom.Items.Add(s);
                    cmbstorefrom.SelectedIndex = cmbstorefrom.Items.Count - 1;
                }


                DataSet de = im.GetEmployees(int.Parse(cmbbranchfrom.SelectedValue.ToString()), int.Parse(cmbDepartmentfrom.SelectedValue.ToString()),"I");

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
                cmbstorefrom.Items.Clear();
                Telerik.Web.UI.RadComboBoxItem s = new Telerik.Web.UI.RadComboBoxItem();
                s.Text = "Choose Store";
                s.Value = "Choose Store";
                cmbstorefrom.Items.Add(s);
                cmbstorefrom.SelectedIndex = cmbstorefrom.Items.Count - 1;

                cmbIssuedby.Items.Clear();
                Telerik.Web.UI.RadComboBoxItem ib = new Telerik.Web.UI.RadComboBoxItem();
                ib.Text = "Choose Employee";
                ib.Value = "Choose Employee";
                cmbIssuedby.Items.Add(ib);
                cmbIssuedby.SelectedIndex = cmbIssuedby.Items.Count - 1;


            }



        }

        /// <summary>
        /// Handles the SelectedIndexChanged event of the cmbBranchto control.
        /// </summary>
        /// <param name="sender">The source of the event.</param>
        /// <param name="e">The <see cref="Telerik.Web.UI.RadComboBoxSelectedIndexChangedEventArgs"/> instance containing the event data.</param>
         
        
        
        /// <summary>
        /// Handles the SelectedIndexChanged event of the cmbstorefrom control.
        /// </summary>
        /// <param name="sender">The source of the event.</param>
        /// <param name="e">The <see cref="Telerik.Web.UI.RadComboBoxSelectedIndexChangedEventArgs"/> instance containing the event data.</param>
        protected void cmbstorefrom_SelectedIndexChanged(object sender, Telerik.Web.UI.RadComboBoxSelectedIndexChangedEventArgs e)
        {
            
            int storeid = int.Parse(cmbstorefrom.SelectedValue.ToString());

         }

        /// <summary>
        /// Handles the SelectedIndexChanged event of the cmbDepartmentfrom control.
        /// </summary>
        /// <param name="sender">The source of the event.</param>
        /// <param name="e">The <see cref="Telerik.Web.UI.RadComboBoxSelectedIndexChangedEventArgs"/> instance containing the event data.</param>
        protected void cmbDepartmentfrom_SelectedIndexChanged(object sender, Telerik.Web.UI.RadComboBoxSelectedIndexChangedEventArgs e)
        {
            DataSet de = im.GetEmployees(int.Parse(cmbbranchfrom.SelectedValue.ToString()), int.Parse(cmbDepartmentfrom.SelectedValue.ToString()),"I");

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

        protected void cmbVendors_SelectedIndexChanged(object sender, Telerik.Web.UI.RadComboBoxSelectedIndexChangedEventArgs e)
        {


         }


      


        /// <summary>
        /// Handles the RowCommand event of the grdItems control.
        /// </summary>
        /// <param name="sender">The source of the event.</param>
        /// <param name="e">The <see cref="GridViewCommandEventArgs"/> instance containing the event data.</param>
        protected void grdItems_RowCommand(object sender, GridViewCommandEventArgs e)
        {

            if (e.CommandName == "Delete")
            {
                int index = Convert.ToInt32(e.CommandArgument);
                DataTable dt = (DataTable)ViewState["dt"];

                dt.Rows[index].Delete();
                ViewState["dt"] = dt;
                //(DataTable)ViewState["dt"];
                grdItems.DataSource = dt;
                grdItems.DataBind();
                
            }
        }

        protected void grdItems_RowDeleting(object sender, GridViewDeleteEventArgs e)
        {

        }

        /// <summary>
        /// Handles the TextChanged event of the txtqty control.
        /// </summary>
        /// <param name="sender">The source of the event.</param>
        /// <param name="e">The <see cref="EventArgs"/> instance containing the event data.</param>
        protected void txtqty_TextChanged(object sender, EventArgs e)
        {

            TextBox thisTextBox = (TextBox)sender;
            GridViewRow currentRow = (GridViewRow)thisTextBox.Parent.Parent;
            int rowindex = 0;
            rowindex = currentRow.RowIndex;

            DataTable dt = (DataTable)ViewState["dt"];

            bool chkb = false;

            if (Single.Parse(thisTextBox.Text) <= Single.Parse(dt.Rows[rowindex]["Balance"].ToString()))
            {
                dt.Rows[rowindex]["Qty Issued"] = Single.Parse(thisTextBox.Text);
                ViewState["dt"] = dt;

                chkb = checkItemBalance(dt, dt.Rows[rowindex]["Item Code"].ToString(), int.Parse(dt.Rows[rowindex]["Issue Store Id"].ToString()), Single.Parse(dt.Rows[rowindex]["Balance"].ToString()), Single.Parse(thisTextBox.Text));

                if (chkb == false)
                {
                    dt.Rows[rowindex]["Qty Issued"] = Single.Parse(thisTextBox.Text);
                    ViewState["dt"] = dt;
                }

                else
                {
                    thisTextBox.Text = "0";
                    showMessageBox("Please Enter Qty Less than Total Current Balance");
                }

            }

            else
            {
                thisTextBox.Text = "0";
                showMessageBox("Please Enter Qty Less than Total Current Balance");
            }


        }

        /// <summary>
        /// Handles the Click event of the btnPrint control.
        /// </summary>
        /// <param name="sender">The source of the event.</param>
        /// <param name="e">The <see cref="EventArgs"/> instance containing the event data.</param>
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

        /// <summary>
        /// Handles the Click event of the btnPrintGatePass control.
        /// </summary>
        /// <param name="sender">The source of the event.</param>
        /// <param name="e">The <see cref="EventArgs"/> instance containing the event data.</param>
        protected void btnPrintGatePass_Click(object sender, EventArgs e)
        {
           // Response.Redirect("ReportsMain.aspx?rptname=GatePass&gpno=" + txtgpno.Text);

            string url = "ReportsMain.aspx?rptname=GatePass&gpno=" + txtgpno.Text;
            string s = "window.open('" + url + "', 'popup_window', 'width=300,height=100,left=100,top=100,resizable=yes');";
            ClientScript.RegisterStartupScript(this.GetType(), "script", s, true);


        }

        /// <summary>
        /// Handles the Click event of the btnOldGIN control.
        /// </summary>
        /// <param name="sender">The source of the event.</param>
        /// <param name="e">The <see cref="EventArgs"/> instance containing the event data.</param>
        //protected void btnOldGIN_Click(object sender, EventArgs e)
        //{
        //    txtoldGIN.Visible = true;
        //}

        /// <summary>
        /// Handles the Click event of the btnClose control.
        /// </summary>
        /// <param name="sender">The source of the event.</param>
        /// <param name="e">The <see cref="EventArgs"/> instance containing the event data.</param>
        protected void btnClose_Click(object sender, EventArgs e)
        {
            ViewState["GINSaved"] = null;
            ScriptManager.RegisterStartupScript(this, this.GetType(), "Close_Window", "self.close();", true);
        }

        /// <summary>
        /// Handles the CheckedChanged event of the chkConfirmIssue control.
        /// </summary>
        /// <param name="sender">The source of the event.</param>
        /// <param name="e">The <see cref="EventArgs"/> instance containing the event data.</param>
        protected void chkConfirmIssue_CheckedChanged(object sender, EventArgs e)
        {
            if (chkConfirmIssue.Checked == true)
            {
                im.IssueConfirm = 1;
            }
            else
            {
                im.IssueConfirm = 0;
            }

        }

        /// <summary>
        /// Handles the Click event of the btnIssueConfirm control.
        /// </summary>
        /// <param name="sender">The source of the event.</param>
        /// <param name="e">The <see cref="EventArgs"/> instance containing the event data.</param>
        //protected void btnIssueConfirm_Click(object sender, EventArgs e)
        //{
            
        //    string status = cmbIssueStatus.SelectedValue.ToString();

        //    im.fkIssueByBranchID = int.Parse(cmbbranchfrom.SelectedValue.ToString());

        //    im.fkIssueByDeptID = int.Parse(cmbDepartmentfrom.SelectedValue.ToString());

        //    im.fkIssueByStoreID = int.Parse(cmbstorefrom.SelectedValue.ToString());

        //    im.IssueConfirm = 1;

        //    im.UpdateIssueConfirm(int.Parse(txtGINConfirm.Text), status);

        //    showMessageBox("GIN Status Updated As Confirm to Issued,Now Receiver Branch Can Received These Items!!!!");



        //   //  Response.Redirect("Main.aspx");
        //}

        /// <summary>
        /// Handles the SelectedIndexChanged event of the cmbCatagories control.
        /// </summary>
        /// <param name="sender">The source of the event.</param>
        /// <param name="e">The <see cref="Telerik.Web.UI.RadComboBoxSelectedIndexChangedEventArgs"/> instance containing the event data.</param>
        //protected void cmbCatagories_SelectedIndexChanged(object sender, Telerik.Web.UI.RadComboBoxSelectedIndexChangedEventArgs e)
        //{

        //    if (cmbCatagories.SelectedValue == "1" || cmbCatagories.SelectedValue == "2" || cmbCatagories.SelectedValue == "8")
        //    {
        //        cmbSystem.SelectedValue = "4";
        //    }
        //    else
        //    {
        //        cmbSystem.SelectedValue = im.pksysID.ToString();
        //    }


        //   // GetSubCategory(int.Parse(cmbCatagories.SelectedValue.ToString()));

        //  //  GetItemHead(int.Parse(cmbSubCategory.SelectedValue.ToString()));



        //    //cmbSubCategory.Items.Clear();

        //    Telerik.Web.UI.RadComboBoxItem subc = new Telerik.Web.UI.RadComboBoxItem();
        //    subc.Text = "Choose Sub Category";
        //    subc.Value = "Choose Sub Category";
        //    cmbSubCategory.Items.Add(subc);
        //    cmbSubCategory.SelectedIndex = cmbSubCategory.Items.Count - 1;



        //    // cmbItemHead.Items.Clear();

        //    Telerik.Web.UI.RadComboBoxItem hd = new Telerik.Web.UI.RadComboBoxItem();
        //    hd.Text = "Choose Items Head";
        //    hd.Value = "Choose Items Head";
        //    cmbItemHead.Items.Add(hd);
        //    cmbItemHead.SelectedIndex = cmbItemHead.Items.Count - 1;

        //    cmbItem.Items.Clear();

        //    Telerik.Web.UI.RadComboBoxItem ib = new Telerik.Web.UI.RadComboBoxItem();
        //    ib.Text = "Choose Item";
        //    ib.Value = "Choose Item";
        //    cmbItem.Items.Add(ib);
        //    cmbItem.SelectedIndex = cmbItem.Items.Count - 1;


        //    RadSlider1.Focus();
        //}

        /// <summary>
        /// Handles the SelectedIndexChanged event of the cmbSubCategory control.
        /// </summary>
        /// <param name="sender">The source of the event.</param>
        /// <param name="e">The <see cref="Telerik.Web.UI.RadComboBoxSelectedIndexChangedEventArgs"/> instance containing the event data.</param>
        //protected void cmbSubCategory_SelectedIndexChanged(object sender, Telerik.Web.UI.RadComboBoxSelectedIndexChangedEventArgs e)
        //{
        //    //GetItemHead(int.Parse(cmbSubCategory.SelectedValue.ToString()));


           

        //    Telerik.Web.UI.RadComboBoxItem hd = new Telerik.Web.UI.RadComboBoxItem();
        //    hd.Text = "Choose Items Head";
        //    hd.Value = "Choose Items Head";
        //    cmbItemHead.Items.Add(hd);
        //    cmbItemHead.SelectedIndex = cmbItemHead.Items.Count - 1;

        //    cmbItem.Items.Clear();

        //    Telerik.Web.UI.RadComboBoxItem ib = new Telerik.Web.UI.RadComboBoxItem();
        //    ib.Text = "Choose Item";
        //    ib.Value = "Choose Item";
        //    cmbItem.Items.Add(ib);
        //    cmbItem.SelectedIndex = cmbItem.Items.Count - 1;



        //     RadSlider1.Focus();
        //}

        ///// <summary>
        ///// Handles the SelectedIndexChanged event of the cmbItemHead control.
        ///// </summary>
        ///// <param name="sender">The source of the event.</param>
        ///// <param name="e">The <see cref="Telerik.Web.UI.RadComboBoxSelectedIndexChangedEventArgs"/> instance containing the event data.</param>
        //protected void cmbItemHead_SelectedIndexChanged(object sender, Telerik.Web.UI.RadComboBoxSelectedIndexChangedEventArgs e)
        //{
        //   // GetItems(int.Parse(cmbItemHead.SelectedValue.ToString()),2);
        //     RadSlider1.Focus();
        //}

        /// <summary>
        /// Handles the SelectedIndexChanged event of the cmbItemSearch control.
        /// </summary>
        /// <param name="sender">The source of the event.</param>
        /// <param name="e">The <see cref="Telerik.Web.UI.RadComboBoxSelectedIndexChangedEventArgs"/> instance containing the event data.</param>
        protected void cmbItemSearch_SelectedIndexChanged(object sender, Telerik.Web.UI.RadComboBoxSelectedIndexChangedEventArgs e)
        {

            string itmid = cmbItemSearch.SelectedValue.ToString();
            string itemnam = cmbItemSearch.SelectedItem.Text.ToString();
            
            
            
            GetItems(0, 1);
            ConfirmItemEntry();
        }

    
        protected void cmbIssuedby_SelectedIndexChanged(object sender, Telerik.Web.UI.RadComboBoxSelectedIndexChangedEventArgs e)
        {
           
            btnSubmit.Visible = true;
        }

     

        #endregion

        #region RecordSave

        /// <summary>
        /// Handles the Click event of the btnSubmitItem control.
        /// </summary>
        /// <param name="sender">The source of the event.</param>
        /// <param name="e">The <see cref="EventArgs"/> instance containing the event data.</param>
        protected void btnSubmitItem_Click(object sender, EventArgs e)
        {
            if (ViewState["GINSaved"] == null)
            {
                ViewState["GINSaved"] = "SavingGIN";
            }
            else
            {
                Response.Redirect("IssueInventory.aspx", false);
                return;
            }
            
            btnSubmitItem.Visible = false;

            HttpCookie IMS = Request.Cookies["IMS"];
            if (IMS == null)
                Response.Redirect("logout.aspx");


            DataTable dt = (DataTable)ViewState["dt"];


            DataRow dr = dt.Rows[0];

            dr["Retdate"] = rdReturndate.Text.ToString();
            dr.AcceptChanges();
            

            //rdReturndate.Text.ToString();

            if (dt.Rows.Count == 0)
            {
                showMessageBox("Add Items first!!!!!");

                //   cmbbranchfrom.Enabled = true;
                cmbstorefrom.Enabled = true;
                cmbIssuedby.Enabled = true;
                cmbVendors.Enabled = true;


                cmbIssueStatus.Enabled = true;
                cmbIssueType.Enabled = true;

            }
            else
            {

                im.fkdepartid = int.Parse(IMS["udptid"] == null ? "0" : IMS["udptid"]);
                im.CreatedBy = int.Parse(IMS["uid"]);

             //   im.OLDGIN = int.Parse(txtoldGIN.Text);

                if (im.OLDGIN == 0)
                {
                    im.Token = "I";
                }
                else
                {
                    im.Token = "A";
                    int fkstoreid = int.Parse(dt.Rows[0]["Issue Store Id"].ToString());
                    bool ginIsConfirmed = im.checkGINConfirmStatus(im.OLDGIN, fkstoreid);

                    if (ginIsConfirmed==true)
                    {
                        showMessageBox("This GIN is Already Confirmed, No More Additional Entries Allowed,Save Again To Create New GIN!!!");
                        //txtoldGIN.Text = "0";
                        btnSubmitItem.Visible = true;
                        return;
                    }
                }


                if (chkConfirmIssue.Checked == true)
                {
                    im.IssueConfirm = 1;
                }
                else
                {
                    im.IssueConfirm = 0;
                }

                int get_GINNo = 0;
                int get_GPNo = 0;
                int i;

                im.pksysID = int.Parse(cmbSystem.SelectedValue.ToString());

                GetUserInfo();

 

                if (im.pksysIDTo != 0)
                {
                    i = im.IUTransferInternal(dt, ref get_GINNo);

                }
                else
                {
                    if (Uman.Ugid == 31 || Uman.Ugid == 32 || Uman.Ugid == 28)
                    {
                        im.fkIssueByDeptID = 14;
                        im.fkdepartid = 14;

                    }

 
                        im.fkIssueByDeptID = int.Parse(cmbDepartmentfrom.SelectedValue.ToString());
                        im.fkVendorID = int.Parse(cmbVendors.SelectedValue.ToString());

                        i = im.MaterialReturn(dt, ref get_GINNo, ref get_GPNo);
                }

             
                if (i == 0)
                {
                    showMessageBox("There was Something Wrong!!!!!!  GIN NOT SAVED...Please Verify and Do it Again....");
                }
                else
                {
                    showMessageBox("Items Inserted!!!!! with GIN Number : " + i.ToString());
                }
             
                txtginno.Text = i.ToString();
                txtgpno.Text = get_GPNo.ToString();

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


          //      im.SendReportEmail(im.fkIssueByBranchID, storeid, im.fkIssueByDeptID, 3, i);


               // Response.Redirect("ReportsMain.aspx?rptname=GoodsIssueNote&gino=" + txtginno.Text,false);

                //btnPrint_Click(sender, e);
                //btnPrintGatePass_Click(sender, e);

                SetupForm(false);

                ViewState["dt"] = null;
                grdItems.DataSource = null;
                grdItems.DataBind();

                // cmbbranchfrom.Enabled = true;
                cmbstorefrom.Enabled = true;
                cmbIssuedby.Enabled = true;
 
                cmbIssueStatus.Enabled = true;
                cmbIssueType.Enabled = true;

            }

        }

        /// <summary>
        /// Handles the Click event of the btnSubmit control.
        /// </summary>
        /// <param name="sender">The source of the event.</param>
        /// <param name="e">The <see cref="EventArgs"/> instance containing the event data.</param>
        protected void btnSubmit_Click(object sender, EventArgs e)
        {

        
        }


        #endregion

        /// <summary>
        /// Handles the RowDataBound event of the grdItems control.
        /// </summary>
        /// <param name="sender">The source of the event.</param>
        /// <param name="e">The <see cref="GridViewRowEventArgs"/> instance containing the event data.</param>
        protected void grdItems_RowDataBound(object sender, GridViewRowEventArgs e)
        {

            if (e.Row.RowType == DataControlRowType.DataRow)
            {


              //  string balqty = Convert.ToString(DataBinder.Eval(e.Row.DataItem, "Balance"));
              //  TextBox txtqut = (TextBox)e.Row.FindControl("txtqty");

               // string rowid = e.Row.RowIndex.ToString();

                //txtqut.Attributes.Add("onkeydown", "return IsNumeric(event" + ",'" + rowid + "')");

               // txtqut.Attributes.Add("onkeyup", "CheckQuantity(event" + ",'" + rowid + "','" + txtqut.ClientID + "','" + balqty + "')");

                
                
                
                //txtqut.Attributes.Add("onblur", "MakeTotal('" + e.Row.RowIndex + "')");

                //GridViewRow NextRow = e.Row;


                //for (int i = 0; i < grdItems.Rows.Count - 1; i++)
                //{
                //    TextBox curTexbox = grdItems.Rows[i].Cells[7].FindControl("txtqty") as TextBox;
                //    TextBox nexTextbox = grdItems.Rows[i + 1].Cells[7].FindControl("txtqty") as TextBox;
                //    curTexbox.Attributes.Add("onkeypress", "return clickEnter('" + nexTextbox.ClientID + "', event)");

                //    curTexbox.Attributes.Add("onfocusin", " select();");
                //}


            }



        }

        /// <summary>
        /// Handles the RowUpdated event of the grdItems control.
        /// </summary>
        /// <param name="sender">The source of the event.</param>
        /// <param name="e">The <see cref="GridViewUpdatedEventArgs"/> instance containing the event data.</param>
        protected void grdItems_RowUpdated(object sender, GridViewUpdatedEventArgs e)
        {

            e.KeepInEditMode = true;
            GridView GridView1 = (GridView)sender;
            int currRow = GridView1.SelectedRow.RowIndex;
            ((TextBox)grdItems.Rows[currRow].FindControl("txtqty")).Focus();

        }

        /// <summary>
        /// Handles the RowEditing event of the grdItems control.
        /// </summary>
        /// <param name="sender">The source of the event.</param>
        /// <param name="e">The <see cref="GridViewEditEventArgs"/> instance containing the event data.</param>
        protected void grdItems_RowEditing(object sender, GridViewEditEventArgs e)
        {

        }

     
        
    }
}