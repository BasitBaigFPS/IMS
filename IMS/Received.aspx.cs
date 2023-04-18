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
using Telerik.Web.UI;
using System.Globalization;
using BLL;


namespace IMS
{
    public partial class Received : System.Web.UI.Page
    {
        UserManager UMan = new UserManager();
        ItemManager im = new ItemManager();
        StoreManager sm = new StoreManager();
        VendorManager vm = new VendorManager();
        IMSManager iman = new IMSManager();

        DataTable di;

        #region Helper Methods

        public void GetUserInfo()
        {

            HttpCookie IMS = Request.Cookies["IMS"];
            if (IMS == null)
                Response.Redirect("logout.aspx");


            UMan.Uid = int.Parse(IMS["uid"]);
            UMan.Ubrhid = int.Parse(IMS["grpuserbrhid"]);
            UMan.Pkdeptid = int.Parse(IMS["grpuserdptid"]);
            UMan.PkstoreID = int.Parse(IMS["grpuserstoreid"]);
            UMan.Ugid =  int.Parse(IMS["ugroupid"]);
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
            //im.fkcatid = int.Parse(cmbCategory.SelectedValue.ToString());
            int sysid;

            if (im.fkcatid == 1 || im.fkcatid == 2 || im.fkcatid == 0)
            {
                sysid = 4;
            }
            else
            { 
                sysid = int.Parse(cmbSystem.SelectedValue.ToString());
            }

            return sysid;
        }

        public void SetupForm()
        {

            //sm.fkbrhID = int.Parse("19");
            im.CreatedBy = iman.Uid;
            //iman.Uid = int.Parse("1527");
            //im.fkbrhid = int.Parse("19");

            GetUserInfo();

            GetSystem();

            GetDepartments(iman.Uid);

            GetStores();

            GetVendors();

            GetCategory();

            UserSettings();

            txtdcno.Text = "";
            rddcdate.Text = DateTime.Today.ToString("dd-MM-yyyy"); 
            txtinvoice.Text = "";
            txtvehicle.Text = "";
            txtitembrand.Text = "";
            txtitemmodel.Text = "";

            Telerik.Web.UI.RadComboBoxItem rt = new Telerik.Web.UI.RadComboBoxItem();
            //rt.Text = "Choose Received Type";
            //rt.Value = "Choose Received Type";
            //cmbRecvType.Items.Add(rt);
            cmbRecvType.SelectedIndex = 0;
            //cmbRecvType.SelectedIndex  = cmbRecvType.Items.Count - 1;

            Telerik.Web.UI.RadComboBoxItem sys = new Telerik.Web.UI.RadComboBoxItem();
            sys.Text = "Choose System";
            sys.Value = "Choose System";
            cmbSystem.Items.Add(sys);
            cmbSystem.SelectedIndex = 0;
            //cmbSystem.Items.Count - 1;

            Telerik.Web.UI.RadComboBoxItem dpt = new Telerik.Web.UI.RadComboBoxItem();
            dpt.Text = "Choose Department";
            dpt.Value = "Choose Department";
            cmbDept.Items.Add(dpt);
            cmbDept.SelectedIndex = cmbDept.Items.Count - 1;

            Telerik.Web.UI.RadComboBoxItem s = new Telerik.Web.UI.RadComboBoxItem();
            s.Text = "Choose Store";
            s.Value = "Choose Store";
            cmbstorefrom.Items.Add(s);
            cmbstorefrom.SelectedIndex = cmbstorefrom.Items.Count - 1;

            Telerik.Web.UI.RadComboBoxItem vt = new Telerik.Web.UI.RadComboBoxItem();
            vt.Text = "Choose Vendor";
            vt.Value = "Choose Vendor";
            ddlVendors.Items.Add(vt);
            ddlVendors.SelectedIndex = ddlVendors.Items.Count - 1;

            Telerik.Web.UI.RadComboBoxItem ct = new Telerik.Web.UI.RadComboBoxItem();
            ct.Text = "Choose Category";
            ct.Value = "Choose Category";
            cmbCategory.Items.Add(ct);
            cmbCategory.SelectedIndex = cmbCategory.Items.Count - 1;


            Telerik.Web.UI.RadComboBoxItem sct = new Telerik.Web.UI.RadComboBoxItem();
            sct.Text = "Choose Sub Category";
            sct.Value = "Choose Sub Category";
            cmbSubCategory.Items.Add(sct);
            cmbSubCategory.SelectedIndex = cmbSubCategory.Items.Count - 1;

            Telerik.Web.UI.RadComboBoxItem hd = new Telerik.Web.UI.RadComboBoxItem();
            hd.Text = "Choose Items Head";
            hd.Value = "Choose Items Head";
            cmbItemHead.Items.Add(hd);
            cmbItemHead.SelectedIndex = cmbItemHead.Items.Count - 1;

            Telerik.Web.UI.RadComboBoxItem it = new Telerik.Web.UI.RadComboBoxItem();
            it.Text = "Choose Item";
            it.Value = "Choose Item";
            cmbItem.Items.Add(it);
            cmbItem.SelectedIndex = cmbItem.Items.Count - 1;

            ViewState["dtItems"] = null;

            DataTable dt = new DataTable();
            ViewState["dt"] = dt;

            LoadItems();
        
        }

        public void GetSystem()
        {
            cmbSystem.DataSource = iman.GetSystem();
            cmbSystem.DataTextField = "SystemName";
            cmbSystem.DataValueField = "pksysID";
            cmbSystem.DataBind();

           
        }

        public void GetStores()
        {                                             
                sm.Token = "SB";
                sm.fkdeptID = UMan.Pkdeptid;
                im.fkbrhid = UMan.Ubrhid;

                if (UMan.Pkdeptid==10)
                {
                    sm.Token = "IT";
                }
                if (UMan.Pkdeptid == 17)
                {
                    sm.Token = "SP";
                }

                cmbstorefrom.DataSource = sm.GetStores();
                cmbstorefrom.DataTextField = "StoreName";
                cmbstorefrom.DataValueField = "pkStoreID";
                cmbstorefrom.DataBind();
        }

        public void GetDepartments(int uid)
        {

            cmbDept.DataSource = sm.GetDepartment(uid);
            cmbDept.DataTextField = "deptName";
            cmbDept.DataValueField = "pkdeptID";
            cmbDept.DataBind();            

        }

        public void GetVendors()
        {
            HttpCookie IMS = Request.Cookies["IMS"];

           // UMan.Pkdeptid = int.Parse(IMS["udptid"]);
           UMan.Ugid = int.Parse(IMS["ugroupid"]);

           if (UMan.Ugid == 79)
            {
                vm.Token = "SPV";
            }
            else
            {
                vm.Token = "V";
            }

            ddlVendors.DataSource = vm.GetVondors();
            ddlVendors.DataTextField = "VendorName";
            ddlVendors.DataValueField = "pkVendID";
            ddlVendors.DataBind();
        }

        public void GetCategory()
        {
            im.CatID = 0;
            im.Token = "C";            
            cmbCategory.DataSource = im.GetCategories();
            cmbCategory.DataTextField = "CatTitle";
            cmbCategory.DataValueField = "pkCatID";
            cmbCategory.DataBind();
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

        public void GetItems(int ithead)
        {
           // DataTable di = im.GetAllItems("2");


            im.pksysID = int.Parse(cmbSystem.SelectedValue.ToString());

            if (ithead != 0)
            {

                DataTable di = im.GetItems(im.pksysID, ithead, 0, "IH");
                cmbItem.DataSource = di;
                cmbItem.DataTextField = "ItemTitle";
                cmbItem.DataValueField = "pkItemID";
                cmbItem.DataBind();
            }
            else
            {
                if (UMan.Pkdeptid == 10)
                {
                    im.fkdepartid = UMan.Pkdeptid;
                }
                if (UMan.Pkdeptid == 2)
                {
                    im.fkdepartid = UMan.Pkdeptid;
                }
                if (UMan.Pkdeptid == 11)
                {
                    im.fkdepartid = UMan.Pkdeptid;
                }
                if (UMan.Pkdeptid == 14)
                {
                    im.fkdepartid = UMan.Pkdeptid;
                }
                if (UMan.Pkdeptid != 10 && UMan.Pkdeptid != 2 && UMan.Pkdeptid != 11 && UMan.Pkdeptid != 14)
                {
                    im.fkdepartid = 2;
                }

                DataTable di = im.GetAllItems();

                if (di.Rows.Count > 0)
                {
                    cmbItem.Items.Clear();

                    cmbItem.DataSource = di;
                    cmbItem.DataTextField = "ItemTitle";
                    cmbItem.DataValueField = "pkItemID";
                    cmbItem.DataBind();
                    cmbItem.Enabled = false;
                    cmbItem.SelectedValue = cmbItemSearch.SelectedValue;

                }
            
            }
        }

        public bool checkItem(string ItemID)
                {
                    bool it = false;

                    for (int i = 0; i < this.grdItems.Rows.Count; i++)
                    {
                        string id = this.grdItems.Rows[i].Cells[1].Text;

                        if (ItemID == id)
                        {
                            showMessageBox("Item already in the list.");
                            cmbItem.Focus();
                            it= true;
                            break;
                        }
                    }

                    return it;
        
                }

        protected void showMessageBox(string message)
        {
            string sScript;
            message = message.Replace("'", "\'");
            sScript = String.Format("alert('{0}');", message);
            ScriptManager.RegisterStartupScript(this, this.GetType(), "alert", sScript, true);
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
                    //Label lblBal = (Label)GR.FindControl("lblBalance");

                    TextBox lblModel = (TextBox)GR.FindControl("txtModel");
                    TextBox lblBrand = (TextBox)GR.FindControl("txtBrand");


                    TextBox lblQty = (TextBox)GR.FindControl("txtqty");

                    if (lblItem != null && lblItem.Text != "")
                    {
                        string itemid = lblItem.Text;
                        string qtty = lblQty.Text;
                        string modl = lblModel.Text;
                        string brnd = lblBrand.Text;
                        //float bal = float.Parse(lblBal.Text == "" ? "0" : lblBal.Text);


                        DataRow[] ItemRow = ds.Tables[0].Select("[Item Code] ='" + itemid + "'");

                        ItemRow[0]["Model"] = modl == "" ? "" : modl;
                        ItemRow[0]["Brand"] = brnd == "" ? "" : brnd;

                        ItemRow[0]["Qty Received"] = qtty == "" ? "0" : qtty;

                        // ItemRow[0]["Qty Received"] = float.Parse(qtty) > bal ? lblBal.Text : qtty;
                    }
                }

            }

            return ds.Tables[0];

        }

        public void UserSettings()
        { 
        
            if (UMan.Ugid==31 || UMan.Ugid==32)
            {
                int sysid = GetSysinfo();
                cmbSystem.SelectedValue = sysid.ToString();
                cmbSystem.Enabled = false;
            }

            if (UMan.Uid == 94)
            {
                cmbSystem.SelectedValue = "4";
                cmbSystem.DataBind();
                cmbSystem.Enabled = false;
            }


            if (UMan.Ugid == 37)
            {

                cmbSystem.SelectedValue = "4";
                cmbSystem.DataBind();

                cmbDept.SelectedValue = "10";
                cmbDept.DataBind();

                cmbstorefrom.SelectedValue = "22";
                cmbstorefrom.DataBind();

                //cmbstorefrom.Enabled = false;
                //cmbDept.Enabled = false;
                //cmbSystem.Enabled = false;
            
            }
            if (UMan.Ugid == 79)
            {

                cmbDept.SelectedValue = "17";
                cmbDept.DataBind();
            }




        }

        public void LoadItems()
        {

            if (UMan.Ugid == 31 || UMan.Ugid == 32 || UMan.Ugid == 28)
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
            
            
            
            
            //if (UMan.Pkdeptid == 10)
            //    {
            //        im.fkdepartid = UMan.Pkdeptid;
            //    }
            //    if (UMan.Pkdeptid == 2)
            //    {
            //        im.fkdepartid = UMan.Pkdeptid;
            //    }
            //    if (UMan.Pkdeptid == 11)
            //    {
            //        im.fkdepartid = UMan.Pkdeptid;
            //    }
            //    if (UMan.Pkdeptid == 14)
            //    {
            //        im.fkdepartid = UMan.Pkdeptid;
            //    }
            //    if (UMan.Pkdeptid == 22)
            //    {
            //        im.fkdepartid = UMan.Pkdeptid;
            //    }
            //    if (UMan.Pkdeptid == 17)
            //    {
            //        im.fkdepartid = UMan.Pkdeptid;
            //    }
            //    if (UMan.Pkdeptid != 10 && UMan.Pkdeptid != 2 && UMan.Pkdeptid != 11 && UMan.Pkdeptid != 14 && UMan.Pkdeptid != 22 && UMan.Pkdeptid != 17)
            //    {
            //        im.fkdepartid = 2;
            //    } 


                //  DataTable di = im.GetStoreInventory(storeid, deptfromid);
                DataTable di = im.GetAllItems();

                if (di.Rows.Count > 0)
                {
                    cmbItemSearch.Items.Clear();

                    cmbItemSearch.DataSource = di;
                    cmbItemSearch.DataTextField = "ItemTitle";
                    cmbItemSearch.DataValueField = "pkItemID";
                    cmbItemSearch.DataBind();
                    cmbItemSearch.ItemsPerRequest = 10;

                    Telerik.Web.UI.RadComboBoxItem ib = new Telerik.Web.UI.RadComboBoxItem();
                    ib.Text = "Search Item";
                    ib.Value = "Search Item";
                    cmbItemSearch.Items.Insert(0, ib);
                    cmbItemSearch.SelectedIndex = 0;


                }
                else
                {
                    //cmbItem.Items.Clear();

                    Telerik.Web.UI.RadComboBoxItem ib = new Telerik.Web.UI.RadComboBoxItem();
                    ib.Text = "Search Item";
                    ib.Value = "Search Item";
                    cmbItemSearch.Items.Add(ib);
                    cmbItemSearch.SelectedIndex = cmbItem.Items.Count - 1;

                }
        }

        public void LoadItems(int deptid)
        {
            if (UMan.Pkdeptid == 10)
            {
                im.fkdepartid = UMan.Pkdeptid;
            }
            if (UMan.Pkdeptid == 11)
            {
                im.fkdepartid = UMan.Pkdeptid;
            }
            if (UMan.Pkdeptid == 14)
            {
                im.fkdepartid = UMan.Pkdeptid;
            }
            if (UMan.Pkdeptid != 10 && UMan.Pkdeptid != 2 && UMan.Pkdeptid != 11 && UMan.Pkdeptid != 14)
            {
                im.fkdepartid = 2;
            }

            if (UMan.Ugid == 79)
            {
                im.fkdepartid = 17;
            }


            //  DataTable di = im.GetStoreInventory(storeid, deptfromid);
            DataTable di = im.GetAllItems();

            if (di.Rows.Count > 0)
            {
                cmbItemSearch.Items.Clear();

                cmbItemSearch.DataSource = di;
                cmbItemSearch.DataTextField = "ItemTitle";
                cmbItemSearch.DataValueField = "pkItemID";
                cmbItemSearch.DataBind();
                cmbItemSearch.ItemsPerRequest = 10;

                Telerik.Web.UI.RadComboBoxItem ib = new Telerik.Web.UI.RadComboBoxItem();
                ib.Text = "Search Item";
                ib.Value = "Search Item";
                cmbItemSearch.Items.Insert(0, ib);
                cmbItemSearch.SelectedIndex = 0;


            }
            else
            {
                //cmbItem.Items.Clear();

                Telerik.Web.UI.RadComboBoxItem ib = new Telerik.Web.UI.RadComboBoxItem();
                ib.Text = "Search Item";
                ib.Value = "Search Item";
                cmbItemSearch.Items.Add(ib);
                cmbItemSearch.SelectedIndex = cmbItem.Items.Count - 1;

            }
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
                    dt.Columns.Add("Model", typeof(string));
                    dt.Columns.Add("Brand", typeof(string));
                    //dt.Columns.Add("Balance", typeof(Single));
                    dt.Columns.Add("Qty Received", typeof(Single));

                }

                int tr = int.Parse(dt.Rows.Count.ToString());

                if (dt.Rows.Count > 0)
                {
                    DataRow dr = dt.NewRow();

                    dr["Item Code"] = itemcode;
                    dr["Item Name"] = itemname;

                    dr["Model"] = "";
                    dr["Brand"] = "";

                  //  DataRow[] ItemRow = di.Select("[ItemCode] ='" + itemcode + "'");

                 //   dr["Balance"] = Single.Parse(ItemRow[0]["Current Balance"].ToString() == "" ? "0" : ItemRow[0]["Current Balance"].ToString());
                    dr["Qty Received"] = 0;

                    dt.Rows.Add(dr);


                }

                else
                {

                    DataRow dr = dt.NewRow();

                    dt.Rows.Add(dr);

                    dr["Item Code"] = itemcode;
                    dr["Item Name"] = itemname;
                    dr["Model"] = "";
                    dr["Brand"] = "";

                   // DataRow[] ItemRow = di.Select("[ItemCode] ='" + itemcode + "'");

                   // dr["Balance"] = Single.Parse(ItemRow[0]["Current Balance"].ToString() == "" ? "0" : ItemRow[0]["Current Balance"].ToString());
                    dr["Qty Received"] = 0;


                }

                if (dt.Rows.Count == listno)
                {
                   // mirdiv.Style.Add("display", "inline");

                   // ViewState["dt"] = SetDataTable(dt);

                    ViewState["GRNSaved"] = null;
                    ViewState["dt"] = dt;

                    grdItems.DataSource = dt;
                    grdItems.DataBind();

                    grdItems.Visible = true;

                    btnSave.Visible = true;
                }
                //txtginno.Text = "6";

            }


        }


        private void ShowCheckedItems(Telerik.Web.UI.RadComboBox comboBox, Literal literal)
        {
            var sb = new StringBuilder();

            var collection = comboBox.CheckedItems;
            string personid = "";
            string persons = "";

            if (collection.Count != 0)
            {
                sb.Append("<h3>Selected List:</h3><ul class=\"results\">");

                foreach (var item in collection)
                {
                    sb.Append("<li>" + item.Text + "</li>");
                    personid = personid + item.Value.TrimEnd() + ",";
                    persons = persons + item.Text + ",";

                    if (literal == ItemsClientSide)
                    {
                        ConfirmItemEntry(item.Value, item.Text, collection.Count);
                    }
                }
                sb.Append("</ul>");

                literal.Text = sb.ToString();
            

            }
            else
            {
                literal.Text = "<p>No List selected</p>";

            }
        }


        #endregion

        #region Events 
        
        protected void Page_Load(object sender, EventArgs e)
        {
            if (Page.IsPostBack == false)
            {
                cmbItemSearch.Filter = RadComboBoxFilter.Contains; 

                HttpCookie IMS = Request.Cookies["IMS"];
                if (IMS == null)
                    Response.Redirect("logout.aspx");

                sm.fkbrhID = int.Parse(IMS["grpuserbrhid"]);
                iman.Uid = int.Parse(IMS["uid"]);

                iman.Pkdeptid = int.Parse(IMS["grpuserdptid"] == null ? "0" : IMS["grpuserdptid"]);

                DashBoardManager dbm = new DashBoardManager();
                dbm.fkbrhid = sm.fkbrhID;

                dbm.fkdepartid = iman.Pkdeptid;

                if (sm.fkbrhID != 25 && iman.Pkdeptid != 14)
                {
                    List<string> MyList = dbm.GetUNRGinList();

                    var collection = MyList;

                    if (iman.Pkdeptid != 17 && iman.Pkdeptid != 2)
                    {
                        if (collection.Count != 0)
                        {
                            ScriptManager.RegisterStartupScript(this, this.GetType(), "alert", "alert('You Have Pending GIN(s) at Your IMS Dashboard, No Transaction is Allowed Until All The Pending GIN Not Received!');window.location ='MainDashboard.aspx';", true);
                        }
                    }
                }
                UMan.GetUserInfo(iman.Uid);
                SetupForm();
            }
            cmbRecvType.Focus();
            
        }

      
        protected void grdItems_RowCommand(object sender, GridViewCommandEventArgs e)
        { 
            if (e.CommandName == "Delete")
            {      
                int index = Convert.ToInt32(e.CommandArgument);
                DataTable dt = (DataTable)ViewState["dt"];
              
                dt.Rows[index].Delete();
                ViewState["dt"] = dt;
                DataView view = new DataView(dt);
                grdItems.DataSource = view;
                grdItems.DataBind();

                if (grdItems.Rows.Count < 1)
                    btnAddItem.Visible = false;
            }
        }

        protected void grdItems_RowDeleting(object sender, GridViewDeleteEventArgs e)
        {

        }

        protected void cmbSystem_SelectedIndexChanged(object sender, Telerik.Web.UI.RadComboBoxSelectedIndexChangedEventArgs e)
        {
            im.pksysID = int.Parse(cmbSystem.SelectedValue.ToString());
             

        }

        protected void cmbCategory_SelectedIndexChanged(object sender, Telerik.Web.UI.RadComboBoxSelectedIndexChangedEventArgs e)
        {
            GetSubCategory(int.Parse(cmbCategory.SelectedValue.ToString()));

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
            
            
            Telerik.Web.UI.RadComboBoxItem it = new Telerik.Web.UI.RadComboBoxItem();
            it.Text = "Choose Item";
            it.Value = "Choose Item";
            cmbItem.Items.Add(it);
            cmbItem.SelectedIndex = cmbItem.Items.Count - 1;

            RadSlider1.Focus();
        }

        protected void cmbItemHead_SelectedIndexChanged(object sender, Telerik.Web.UI.RadComboBoxSelectedIndexChangedEventArgs e)
        {

            //if (cmbItemHead.SelectedValue != "Choose Items Head")
            //{
                GetItems(int.Parse(cmbItemHead.SelectedValue.ToString()));
                RadSlider1.Focus();
            //}
        }

        protected void cmbDept_SelectedIndexChanged(object sender, Telerik.Web.UI.RadComboBoxSelectedIndexChangedEventArgs e)
        {
           if (int.Parse(cmbDept.SelectedValue.ToString())==22)
           {
               cmbstorefrom.Visible = false;                
           }
        }
      
        protected void cmbstorefrom_SelectedIndexChanged(object sender, Telerik.Web.UI.RadComboBoxSelectedIndexChangedEventArgs e)
        {
            
        }


        protected void grdItems_NeedDataSource(object sender, Telerik.Web.UI.GridNeedDataSourceEventArgs e)
        {



        }
      
        protected void grdItems_RowEditing(object sender, GridViewEditEventArgs e)
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

                //Label lblCurrentBalance = (Label)e.Row.FindControl("lblbalance");
              //  Double CurBal = Convert.ToDouble(lblCurrentBalance.Text);
                TextBox txtqut = (TextBox)e.Row.FindControl("txtqty");

                string rowid = e.Row.RowIndex.ToString();

                txtqut.Attributes.Add("onkeydown", "return IsNumeric(event" + ",'" + rowid + "')");


             //   txtqut.Attributes.Add("onkeyup", "return CheckBalance(" + CurBal + ",'" + rowid + "')");

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

        protected void btnAddItem_Click(object sender, EventArgs e)
        {
            ShowCheckedItems(cmbItemSearch, ItemsClientSide);
            
            //cmbRecvStatus.Enabled = false;
            
            //bool exec = checkItem(cmbItem.SelectedValue.ToString());

            //if (exec)
            //    return;

            //DataTable dt;

            //if (ViewState["dtItems"] != null)
            //    dt = (DataTable)ViewState["dtItems"];
            //else
            //{
            //    dt = new DataTable();
            //    DataColumn dc1 = new DataColumn("ID");
            //    DataColumn dc2 = new DataColumn("ITEM");
            //    DataColumn dc3 = new DataColumn("QTY");              
            //    DataColumn dc4 = new DataColumn("Model");
            //    DataColumn dc5 = new DataColumn("Brand");
            //    DataColumn dc6 = new DataColumn("Action");

            //    dt.Columns.Add(dc1);
            //    dt.Columns.Add(dc2);
            //    dt.Columns.Add(dc3);
            //    dt.Columns.Add(dc4);
            //    dt.Columns.Add(dc5);
            //}

            //DataRow dr = dt.NewRow();

            //dr[0] = cmbItem.SelectedValue.ToString();
            //dr[1] = cmbItem.SelectedItem.Text;
            //dr[2] = txtqty.Text;
            //dr[3] = txtitemmodel.Text;
            //dr[4] = txtitembrand.Text;

            //dt.Rows.Add(dr);

            //DataView view = new DataView(dt);
            //grdItems.DataSource = view;
            //grdItems.DataBind();

            //ViewState["dtItems"] = dt;

            //btnSave.Visible = true;
            //txtqty.Text = string.Empty;
            //RadSlider1.Focus();

        }

        protected void btnSave_Click(object sender, EventArgs e)
        {
            if (ViewState["GRNSaved"] == null)
            {
                ViewState["GRNSaved"] = "SavingGRN";
            }
            else
            {
                Response.Redirect("Received.aspx", false);
                return;
            }

            DataTable dt1 = (DataTable)ViewState["dt"];

            DataTable dt = SetDataTable(dt1);
            
            //DataTable dt = (DataTable)ViewState["dtItems"];

            btnSave.Visible = false;

            if (dt.Rows.Count == 0)
                showMessageBox("Add Items first!!!!!");
            else
            {
                HttpCookie IMS = Request.Cookies["IMS"];
                if (IMS == null)
                    Response.Redirect("logout.aspx");

                sm.fkbrhID = int.Parse(IMS["grpuserbrhid"]);
                im.fkdepartid = int.Parse(IMS["udptid"] == null ? "0" : IMS["udptid"]);



                im.CreatedBy = int.Parse(IMS["uid"]);
                im.receivedByID = int.Parse(IMS["uid"]);

                im.fkbrhid = int.Parse(IMS["grpuserbrhid"]);
                im.fkstoreid = int.Parse(cmbstorefrom.SelectedValue.ToString() == "Choose Store" ? "0" : cmbstorefrom.SelectedValue.ToString());
                im.fkdepartid = int.Parse(cmbDept.SelectedValue.ToString());
                im.fkVendorID = int.Parse(ddlVendors.SelectedValue.ToString() == "Choose Vendor" ? "0" : ddlVendors.SelectedValue.ToString());

                im.dcno = txtdcno.Text;

                if (int.Parse( IMS["ugroupid"])==79)
                {
                    im.fkdepartid = 17;
                }
                if (IMS["ugroupid"].ToString().Contains("28,30,31,32"))
                {
                    im.fkdepartid = 14;
                }

  
              //  string dcd = String.Format("{0:yyyy-dd-MM}", rddcdate.Text);

              //  DateTime dtime = DateTime.Parse(dcd);

                string dcd = rddcdate.Text;
                im.dcdate = dcd;

                im.invoice = txtinvoice.Text;
                im.vehicle = txtvehicle.Text;
                im.ponumber = txtporder.Text;

                im.OLDGRN = int.Parse(txtoldGRN.Text);

                if (im.OLDGRN == 0)
                {
                    im.Token = "I";
                }
                else
                {
                    im.Token = "A";
                }

                im.pksysID = int.Parse(cmbSystem.SelectedValue.ToString());

              //  im.pksysID = GetSysID();
                int i = im.IUReceivedItems(dt);


                //sm.fkbrhID = im.fkbrhid;
                //sm.pkstoreID = 0;
                //sm.fkdeptID = 17;

                sm.UpdateInvBalance(sm.fkbrhID, sm.pkstoreID, im.fkdepartid);


                showMessageBox("Items Received!!!!! with GRN Number : " + i.ToString());

                txtgrnno.Text = i.ToString();
               // btnPrint.Visible = true;

               // SetupForm();

                txtoldGRN.Visible = false;
                ViewState["dtItems"] = null;
                grdItems.DataSource = null;
                grdItems.DataBind();

            }

            btnSave.Visible = false;

        }

        protected void btnOldGRN_Click(object sender, EventArgs e)
        {
            txtoldGRN.Visible = true;
        }

        protected void btnPrint_Click(object sender, EventArgs e)
        {
            //Response.Redirect("ReportsMain.aspx?rptname=GoodsReceiptNote&grno="+txtgrnno.Text);

            Page.Server.Transfer("ReportsMain.aspx?rptname=GoodsReceiptNote&grno=" + txtgrnno.Text);
        }

        protected void cmbRecvStatus_SelectedIndexChanged(object sender, Telerik.Web.UI.RadComboBoxSelectedIndexChangedEventArgs e)
        {
            im.RecvStatus = cmbRecvStatus.SelectedValue;
            RadSlider1.Focus();
        }

        protected void btnClose_Click(object sender, EventArgs e)
        {
            ViewState["GRNSaved"] = null;
            ScriptManager.RegisterStartupScript(this, this.GetType(), "Close_Window", "self.close();", true);
        }

        protected void cmbRecvType_SelectedIndexChanged(object sender, Telerik.Web.UI.RadComboBoxSelectedIndexChangedEventArgs e)
        {
            
            if (cmbRecvType.SelectedValue == "G")
            {
                Response.Redirect("ReceivedGIN.aspx");
            }

            if (cmbRecvType.SelectedValue == "S")
            {
                Response.Redirect("StaffReceived.aspx");
            }

            if (cmbRecvType.SelectedValue == "B")
            {
                Response.Redirect("BranchReturn.aspx");
            }


        }

        protected void cmbItemSearch_SelectedIndexChanged(object sender, Telerik.Web.UI.RadComboBoxSelectedIndexChangedEventArgs e)
        {
            GetItems(0);
            RadSlider1.Focus();
        }

        protected void cmbPersonto_SelectedIndexChanged(object sender, Telerik.Web.UI.RadComboBoxSelectedIndexChangedEventArgs e)
        {
            //cmbIssueStatus.Visible = true;
        }


        #endregion






    }
}