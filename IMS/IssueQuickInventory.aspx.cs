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
    public partial class IssueQuickInventory : System.Web.UI.Page
    {

        //UserManager UMan = new UserManager();
        ItemManager im = new ItemManager();
        IMSManager iman = new IMSManager();
        UserManager Uman = new UserManager();

        DataTable di;

        #region Helper Methods

        public void GetUserInfo()
        {
            HttpCookie IMS = Request.Cookies["IMS"];
            if (IMS == null)
                Response.Redirect("logout.aspx");


            Uman.Uid = int.Parse(IMS["uid"]);
            Uman.Ubrhid = int.Parse(IMS["ubrhid"]);
            Uman.Pkdeptid = int.Parse(IMS["udptid"]);
            Uman.Ugid = int.Parse(IMS["ugroupid"]);

            DashBoardManager dbm = new DashBoardManager();
            dbm.fkbrhid = Uman.Ubrhid;

            List<string> MyList = dbm.GetUNRGinList();

            var collection = MyList;

            if (collection.Count != 0)
            {
                ScriptManager.RegisterStartupScript(this, this.GetType(), "alert", "alert('You Have Pending GIN(s) at Your IMS Dashboard, No Transaction is Allowed Until All The Pending GIN Not Received!');window.location ='MainDashboard.aspx';", true);
            }


        }

        private void GetEmployee()
        {




        }

        public void GetSystem()
        {
            cmbSystem.DataSource = iman.GetSystem();
            cmbSystem.DataTextField = "SystemName";
            cmbSystem.DataValueField = "pksysID";
            cmbSystem.DataBind();

            cmbSystemTo.DataSource = iman.GetSystem();
            cmbSystemTo.DataTextField = "SystemName";
            cmbSystemTo.DataValueField = "pksysID";
            cmbSystemTo.DataBind();

        }

        public int GetSysinfo()
        {
            HttpCookie IMS = Request.Cookies["IMS"];
            if (IMS == null)
                Response.Redirect("logout.aspx");


            int sysid = Uman.GetSysinfo(int.Parse(IMS["ubrhid"]));

            return sysid;

        }

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

        public void UserSettings()
        {
            if (Uman.Ugid == 31 || Uman.Ugid == 32)
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
                cmbStoreto.Visible = false;
                cmbstorefrom.SelectedValue = "22";
                cmbstorefrom.DataBind();
                cmbSystem.SelectedValue = "4";
                cmbSystem.DataBind();

                cmbstorefrom.Enabled = false;
                cmbDepartmentfrom.Enabled = false;
                cmbSystem.Enabled = false;
            }


            if (Uman.Ugid == 28 || Uman.Ugid == 30)
            {
                cmbIssueType.SelectedValue = "E";
                cmbIssueType.Enabled = false;
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


            cmbItem.Items.Clear();

            Telerik.Web.UI.RadComboBoxItem ib = new Telerik.Web.UI.RadComboBoxItem();
            ib.Text = "Choose Item";
            ib.Value = "Choose Item";
            cmbItem.Items.Add(ib);
            cmbItem.SelectedIndex = cmbItem.Items.Count - 1;


        }

        public void GetItems(int ithead, int token)
        {

            if (token == 2)
            {

                im.fkitemheadid = int.Parse(cmbItemHead.SelectedValue.ToString());
                im.pksysID = GetSysID();

                if (cmbBranchto.SelectedValue != "Choose Item")
                {
                    im.Token = "S";



                    DataTable di = im.GetStoreInventory(im.pksysID, int.Parse(cmbstorefrom.SelectedValue.ToString()), int.Parse(cmbDepartmentfrom.SelectedValue.ToString()));

                    if (di.Rows.Count > 0)
                    {
                        cmbItem.Items.Clear();

                        cmbItem.DataSource = di;
                        cmbItem.DataTextField = "ItemTitle";
                        cmbItem.DataValueField = "InventoryCode";
                        cmbItem.DataBind();

                    }
                    else
                    {
                        //cmbItem.Items.Clear();

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
           //     im.pksysID = GetSysID();

                int deptfromid;
                int storeid;
                GetUserInfo();

                if (Uman.Ugid == 31 || Uman.Ugid == 32)
                {
                    deptfromid = 14;
                }
                else
                {
                    deptfromid = int.Parse(cmbDepartmentfrom.SelectedValue.ToString());

                }
                storeid = int.Parse(cmbstorefrom.SelectedValue.ToString());

                DataTable di;

                if (cmbDepartmentto.SelectedValue.ToString() != "14")
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
                    im.pksysID = GetSysID();
                    //  DataTable di = im.GetStoreInventory(storeid, deptfromid);
                    di = im.GetStoreInventory(im.pksysID, storeid, deptfromid);
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
        }

        //public void ConfirmItemEntry()
        //{
        //    if (Page.IsValid)
        //    {

        //        DataTable dt = (DataTable)ViewState["dt"];
        //        DataTable ib;

        //        cmbItem.SelectedValue = cmbItemSearch.SelectedValue;

        //        if (cmbDepartmentto.SelectedValue.ToString() != "14")
        //        {
        //            if (int.Parse(cmbDepartmentfrom.SelectedValue.ToString()) == 10)
        //            {
        //                ib = im.getItembalance(int.Parse(cmbbranchfrom.SelectedValue.ToString()), int.Parse(cmbstorefrom.SelectedValue.ToString()), cmbItem.SelectedValue.ToString(), "S");
        //            }
        //            else
        //            {
        //                ib = im.getItembalance(int.Parse(cmbbranchfrom.SelectedValue.ToString()), 2, cmbItem.SelectedValue.ToString(), "D");
        //            }
        //        }
        //        else
        //        {
        //            ib = im.getItembalance(int.Parse(cmbbranchfrom.SelectedValue.ToString()), int.Parse(cmbstorefrom.SelectedValue.ToString()), cmbItem.SelectedValue.ToString(), "S");
        //        }

        //        if (dt.Columns.Count == 0)
        //        {

        //            dt.Columns.Add("Issue Branch Id", typeof(int));
        //            dt.Columns.Add("Issue Branch Name", typeof(string));
        //            dt.Columns.Add("Issue Store Id", typeof(int));
        //            dt.Columns.Add("Issue Store Name", typeof(string));
        //            dt.Columns.Add("Issue by Id", typeof(int));
        //            dt.Columns.Add("Issue by Name", typeof(string));
        //            dt.Columns.Add("Issue to Branch Id", typeof(int));
        //            dt.Columns.Add("Issue to Branch Name", typeof(string));
        //            dt.Columns.Add("Issue to Store Id", typeof(int));
        //            dt.Columns.Add("Issue to Store Name", typeof(string));
        //            dt.Columns.Add("Issue to Id", typeof(int));
        //            dt.Columns.Add("Issue to Name", typeof(string));
        //            dt.Columns.Add("Issue to Department", typeof(string));
        //            dt.Columns.Add("Issue to Department Id", typeof(int));
        //            dt.Columns.Add("Item Code", typeof(string));
        //            dt.Columns.Add("Item Name", typeof(string));
        //            dt.Columns.Add("Balance", typeof(Single));
        //            dt.Columns.Add("Qty Issued", typeof(Single));
        //            dt.Columns.Add("Item Status", typeof(string));
        //            dt.Columns.Add("Item Type", typeof(string));
        //            dt.Columns.Add("Ackdate", typeof(string));
        //            dt.Columns.Add("Retdate", typeof(string));

        //        }

        //        int tr = int.Parse(dt.Rows.Count.ToString());

        //        if (dt.Rows.Count > 0)
        //        {

        //            bool ck = checkItem(dt, cmbItem.SelectedValue.ToString(), int.Parse(cmbStoreto.SelectedValue.ToString()), cmbDepartmentto.SelectedItem.Text.ToString());

        //            if (ck == false)
        //            {
        //                DataRow dr = dt.NewRow();
        //                dr["Issue Branch Id"] = int.Parse(cmbbranchfrom.SelectedValue.ToString());
        //                dr["Issue Branch Name"] = cmbbranchfrom.SelectedItem.Text.ToString();
        //                dr["Issue Store Id"] = int.Parse(cmbstorefrom.SelectedValue.ToString());
        //                dr["Issue Store Name"] = cmbstorefrom.SelectedItem.Text.ToString();
        //                dr["Issue by Id"] = dr["Issue by Id"] = int.Parse(cmbIssuedby.SelectedValue.ToString() == "No Employees in Branch" ? Uman.Uid.ToString() : cmbIssuedby.SelectedValue.ToString());
        //                dr["Issue by Name"] = cmbIssuedby.SelectedItem.Text.ToString();
        //                dr["Issue to Branch Id"] = int.Parse(cmbBranchto.SelectedValue.ToString());
        //                dr["Issue to Branch Name"] = cmbBranchto.SelectedItem.Text.ToString();
        //                dr["Issue to Store Id"] = int.Parse(cmbStoreto.SelectedValue.ToString());
        //                dr["Issue to Store Name"] = cmbStoreto.SelectedItem.Text.ToString();
        //                dr["Issue to Id"] = int.Parse(cmbPersonto.SelectedValue.ToString());
        //                dr["Issue to Name"] = cmbPersonto.SelectedItem.Text.ToString();
        //                dr["Issue to Department"] = cmbDepartmentto.SelectedItem.Text.ToString();
        //                dr["Issue to Department Id"] = cmbDepartmentto.SelectedValue.ToString();
        //                //dr["Item Code"] = cmbItem.SelectedValue.ToString();
        //                //dr["Item Name"] = cmbItem.SelectedItem.Text.ToString();

        //                dr["Item Code"] = cmbItemSearch.SelectedValue.ToString();
        //                dr["Item Name"] = cmbItemSearch.SelectedItem.Text.ToString();


        //                dr["Balance"] = Single.Parse(ib.Rows[0]["CRBalance"].ToString() == "" ? "0" : ib.Rows[0]["CRBalance"].ToString());
        //                dr["Qty Issued"] = 0;
        //                dr["Item Status"] = cmbIssueStatus.SelectedValue.ToString();
        //                dr["Item Type"] = cmbIssueType.SelectedValue.ToString();
        //                if (rdackdate.Text != "")
        //                    dr["Ackdate"] = rdackdate.Text.ToString();

        //                if (rdReturndate.Visible == true)
        //                    dr["Retdate"] = rdReturndate.Text.ToString();
        //                dt.Rows.Add(dr);

        //                cmbbranchfrom.Enabled = false;
        //                cmbstorefrom.Enabled = false;
        //                cmbIssuedby.Enabled = false;
        //                cmbBranchto.Enabled = false;
        //                cmbStoreto.Enabled = false;
        //                cmbPersonto.Enabled = false;
        //                cmbDepartmentto.Enabled = false;
        //                cmbIssueStatus.Enabled = false;
        //                cmbIssueType.Enabled = false;

        //            }

        //            else
        //            {
        //                showMessageBox("Item Already Exists in Current Issue!!!!");
        //            }
        //        }

        //        else
        //        {

        //            DataRow dr = dt.NewRow();
        //            dr["Issue Branch Id"] = int.Parse(cmbbranchfrom.SelectedValue.ToString());
        //            dr["Issue Branch Name"] = cmbbranchfrom.SelectedItem.Text.ToString();
        //            dr["Issue Store Id"] = int.Parse(cmbstorefrom.SelectedValue.ToString());
        //            dr["Issue Store Name"] = cmbstorefrom.SelectedItem.Text.ToString();
        //            dr["Issue by Id"] = int.Parse(cmbIssuedby.SelectedValue.ToString() == "No Employees in Branch" ? Uman.Uid.ToString() : cmbIssuedby.SelectedValue.ToString());
        //            dr["Issue by Name"] = cmbIssuedby.SelectedItem.Text.ToString();
        //            dr["Issue to Branch Id"] = int.Parse(cmbBranchto.SelectedValue.ToString());
        //            dr["Issue to Branch Name"] = cmbBranchto.SelectedItem.Text.ToString();

        //            if (int.Parse(cmbstorefrom.SelectedValue.ToString()) != 22)
        //            {
        //                dr["Issue to Store Id"] = int.Parse(cmbStoreto.SelectedValue.ToString());
        //            }

        //            dr["Issue to Store Name"] = cmbStoreto.SelectedItem.Text.ToString();
        //            dr["Issue to Id"] = int.Parse(cmbPersonto.SelectedValue.ToString() == "No Employees in Branch" ? "0" : cmbPersonto.SelectedValue.ToString());
        //            dr["Issue to Name"] = cmbPersonto.SelectedItem.Text.ToString();
        //            dr["Issue to Department"] = cmbDepartmentto.SelectedItem.Text.ToString();
        //            dr["Issue to Department Id"] = cmbDepartmentto.SelectedValue.ToString();
        //            //dr["Item Code"] = cmbItem.SelectedValue.ToString();
        //            //dr["Item Name"] = cmbItem.SelectedItem.Text.ToString();

        //            dr["Item Code"] = cmbItemSearch.SelectedValue.ToString();
        //            dr["Item Name"] = cmbItemSearch.SelectedItem.Text.ToString();


        //            dr["Balance"] = Single.Parse(ib.Rows[0]["CRBalance"].ToString() == "" ? "0" : ib.Rows[0]["CRBalance"].ToString());
        //            dr["Qty Issued"] = 0;
        //            dr["Item Status"] = cmbIssueStatus.SelectedValue.ToString();
        //            dr["Item Type"] = cmbIssueType.SelectedValue.ToString();

        //            if (rdackdate.Text != "")
        //                dr["Ackdate"] = rdackdate.Text.ToString();

        //            if (rdReturndate.Visible == true)
        //                dr["Retdate"] = rdReturndate.Text.ToString();

        //            dt.Rows.Add(dr);

        //            cmbbranchfrom.Enabled = false;
        //            cmbstorefrom.Enabled = false;
        //            cmbIssuedby.Enabled = false;
        //            cmbBranchto.Enabled = false;
        //            cmbStoreto.Enabled = false;
        //            cmbPersonto.Enabled = false;
        //            cmbDepartmentto.Enabled = false;

        //            cmbIssueStatus.Enabled = false;
        //            cmbIssueType.Enabled = false;
        //        }

        //        ViewState["GINSaved"] = null;
        //        ViewState["dt"] = dt;
        //        grdItems.DataSource = dt;
        //        grdItems.DataBind();

        //        grdItems.Visible = true;

        //        btnSubmitItem.Visible = true;
        //    }


        //    btnSubmitItem.Visible = true;

        //}

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

                    btnSubmitItem.Visible = true;
                }
                //txtginno.Text = "6";

            }


        }

        public void SearchItems()
        {


            if (cmbBranchto.SelectedValue != "Search Item")
            {
                im.Token = "S";
                im.pksysID = GetSysID();
                int deptfromid;
                int storeid;
               // GetUserInfo();

                if (Uman.Ugid == 31 || Uman.Ugid == 32)
                {
                    deptfromid = 14;
                }
                else
                {
                    deptfromid = int.Parse(cmbDepartmentfrom.SelectedValue.ToString());

                }
                storeid = int.Parse(cmbstorefrom.SelectedValue.ToString());

                DataTable di;

                if (cmbDepartmentto.SelectedValue.ToString() != "14")
                {

                    if (deptfromid == 10)
                    {
                        storeid = 22;
                    }
                    else if (deptfromid != 14)
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

        }

        private void SetupForm(bool start)
        {

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
            cmbbranchfrom.SelectedValue = int.Parse(IMS["ubrhid"]).ToString();

            iman.Uid = int.Parse(IMS["uid"]);
            iman.Pkdeptid = int.Parse(IMS["udptid"] == null ? "0" : IMS["udptid"]);

            cmbbranchfrom.DataBind();
            cmbbranchfrom.Enabled = false;

            cmbIssueStatus.Enabled = false;

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

                    if (Uman.Ugid == 28 || Uman.Ugid == 30)
                    {
                        cmbstorefrom.SelectedIndex = 0;
                        cmbIssuedby.SelectedIndex = 1;
                    }
                    if (Uman.Ugid == 37)
                    {
                        cmbstorefrom.SelectedIndex = 2;
                        cmbIssuedby.SelectedIndex = 1;
                    }

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

                DataSet de = im.GetEmployees(int.Parse(cmbbranchfrom.SelectedValue.ToString()), int.Parse(cmbDepartmentfrom.SelectedValue.ToString()), "I");

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

            if (start == true)
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



            DataSet dbt = im.GetBranches();
            cmbBranchto.DataSource = dbt.Tables[0];
            cmbBranchto.DataTextField = "brhName";
            cmbBranchto.DataValueField = "pkbrhID";
            cmbBranchto.DataBind();

            Telerik.Web.UI.RadComboBoxItem bt = new Telerik.Web.UI.RadComboBoxItem();
            bt.Text = "Choose Branch";
            bt.Value = "Choose Branch";
            cmbBranchto.Items.Add(bt);
            cmbBranchto.SelectedIndex = cmbBranchto.Items.Count - 1;


            Telerik.Web.UI.RadComboBoxItem it = new Telerik.Web.UI.RadComboBoxItem();
            it.Text = "Choose Item";
            it.Value = "Choose Item";
            cmbItem.Items.Add(it);
            cmbItem.SelectedIndex = cmbItem.Items.Count - 1;

            rdackdate.Text = DateTime.Today.ToString("MM/dd/yyyy");
            im.IssueConfirm = 0;

            UserSettings();


        }

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

        public bool checkItemBalance(DataTable dt, String InvCode, int Storeid, Single balance, Single qtyissue)
        {
            bool returnval = false;

            DataRow[] result = dt.Select("[Item Code] ='" + InvCode + "' AND [Issue Store Id] =" + Storeid);

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

        private void ShowCheckedItems(Telerik.Web.UI.RadComboBox comboBox, Literal literal)
        {
            var sb = new StringBuilder();

            var collection = comboBox.CheckedItems;
            string personid = "";
            string persons = "";

            List<string> list = new List<string>();

           

            if (collection.Count != 0)
            {
                sb.Append("<h3>Selected List:</h3><ul class=\"results\">");

                foreach (var item in collection)
                {
                    list.Add(item.Text);
                    
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
                SetupForm(true);
            }
        }

        protected void cmbSystem_SelectedIndexChanged(object sender, Telerik.Web.UI.RadComboBoxSelectedIndexChangedEventArgs e)
        {
            im.pksysID = int.Parse(cmbSystem.SelectedValue.ToString());

            if (im.pksysID == 4)
            {
                cmbCatagories.SelectedValue = "1";
            }

            SearchItems();
            //cmbBranchto.SelectedValue = "3";
            cmbIssueStatus.Focus();
        }

        protected void cmbSystemTo_SelectedIndexChanged(object sender, Telerik.Web.UI.RadComboBoxSelectedIndexChangedEventArgs e)
        {
            im.pksysIDTo = int.Parse(cmbSystemTo.SelectedValue.ToString());
        }

        protected void cmbIssueType_SelectedIndexChanged(object sender, Telerik.Web.UI.RadComboBoxSelectedIndexChangedEventArgs e)
        {
            if (cmbIssueType.SelectedValue == "I")
            {
                Response.Redirect("IssueQuickItems.aspx?issuetype=I");
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
            }

            SearchItems();

        }

        protected void cmbbranchfrom_SelectedIndexChanged(object sender, Telerik.Web.UI.RadComboBoxSelectedIndexChangedEventArgs e)
        {

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


                DataSet de = im.GetEmployees(int.Parse(cmbbranchfrom.SelectedValue.ToString()), int.Parse(cmbDepartmentfrom.SelectedValue.ToString()), "I");

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

        protected void cmbBranchto_SelectedIndexChanged(object sender, Telerik.Web.UI.RadComboBoxSelectedIndexChangedEventArgs e)
        {


            if (cmbBranchto.SelectedValue != "Choose Branch")
            {


                DataSet ds = im.GetStores(int.Parse(cmbBranchto.SelectedValue.ToString()));

                if (ds.Tables[0].Rows.Count > 0)
                {
                    cmbStoreto.DataSource = ds.Tables[0];
                    cmbStoreto.DataTextField = "StoreName";
                    cmbStoreto.DataValueField = "pkStoreID";
                    cmbStoreto.DataBind();
                }
                else
                {
                    cmbStoreto.Items.Clear();
                    Telerik.Web.UI.RadComboBoxItem s = new Telerik.Web.UI.RadComboBoxItem();
                    s.Text = "No Store in this Branch";
                    s.Value = "No Store in this Branch";
                    cmbStoreto.Items.Add(s);
                    cmbStoreto.SelectedIndex = cmbStoreto.Items.Count - 1;
                }




                DataSet de = im.GetEmployees(int.Parse(cmbBranchto.SelectedValue.ToString()));

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

                btnSubmit.Visible = true;

            }

            else
            {
                cmbStoreto.Items.Clear();
                Telerik.Web.UI.RadComboBoxItem s = new Telerik.Web.UI.RadComboBoxItem();
                s.Text = "Choose Store";
                s.Value = "Choose Store";
                cmbStoreto.Items.Add(s);
                cmbStoreto.SelectedIndex = cmbStoreto.Items.Count - 1;

                cmbPersonto.Items.Clear();
                Telerik.Web.UI.RadComboBoxItem ib = new Telerik.Web.UI.RadComboBoxItem();
                ib.Text = "Choose Employee";
                ib.Value = "Choose Employee";
                cmbPersonto.Items.Add(ib);
                cmbPersonto.SelectedIndex = cmbPersonto.Items.Count - 1;

            }



            int dp = 0;
            DataSet dd = im.GetDepartment(dp);
            cmbDepartmentto.DataSource = dd.Tables[0];
            cmbDepartmentto.DataTextField = "deptName";
            cmbDepartmentto.DataValueField = "pkdeptID";
            cmbDepartmentto.DataBind();
            if (cmbbranchfrom.SelectedValue == "25" && cmbstorefrom.SelectedValue == "1" && cmbDepartmentfrom.SelectedValue == "14")
            {
                cmbDepartmentto.SelectedValue = "14";
                cmbDepartmentto.Enabled = false;


            }


        }

        protected void cmbstorefrom_SelectedIndexChanged(object sender, Telerik.Web.UI.RadComboBoxSelectedIndexChangedEventArgs e)
        {

            int storeid = int.Parse(cmbstorefrom.SelectedValue.ToString());

            DataSet dd = im.GetDepartment(iman.Uid);
            cmbDepartmentto.DataSource = dd.Tables[0];
            cmbDepartmentto.DataTextField = "deptName";
            cmbDepartmentto.DataValueField = "pkdeptID";
            cmbDepartmentto.DataBind();

            if (storeid == 1)
            {
                cmbDepartmentto.SelectedValue = "14";
            }

        }

        protected void cmbDepartmentfrom_SelectedIndexChanged(object sender, Telerik.Web.UI.RadComboBoxSelectedIndexChangedEventArgs e)
        {
            DataSet de = im.GetEmployees(int.Parse(cmbbranchfrom.SelectedValue.ToString()), int.Parse(cmbDepartmentfrom.SelectedValue.ToString()), "I");

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

        protected void cmbDepartmentto_SelectedIndexChanged(object sender, Telerik.Web.UI.RadComboBoxSelectedIndexChangedEventArgs e)
        {


            DataSet de = im.GetEmployees(int.Parse(cmbBranchto.SelectedValue.ToString()), int.Parse(cmbDepartmentto.SelectedValue.ToString()), "R");

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

        protected void cmbPersonto_SelectedIndexChanged(object sender, Telerik.Web.UI.RadComboBoxSelectedIndexChangedEventArgs e)
        {

            if (cmbIssuedby.SelectedValue == cmbPersonto.SelectedValue)
            {
                cmbSystemTo.Visible = true;
            }
            else
            {
                cmbSystemTo.Visible = false;
            }
            btnSubmit.Visible = true;
            cmbIssueStatus.Enabled = true;
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
                //(DataTable)ViewState["dt"];
                grdItems.DataSource = dt;
                grdItems.DataBind();

            }
        }

        protected void grdItems_RowDeleting(object sender, GridViewDeleteEventArgs e)
        {

        }

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

        protected void btnPrintGatePass_Click(object sender, EventArgs e)
        {
            // Response.Redirect("ReportsMain.aspx?rptname=GatePass&gpno=" + txtgpno.Text);

            string url = "ReportsMain.aspx?rptname=GatePass&gpno=" + txtgpno.Text;
            string s = "window.open('" + url + "', 'popup_window', 'width=300,height=100,left=100,top=100,resizable=yes');";
            ClientScript.RegisterStartupScript(this.GetType(), "script", s, true);


        }

        protected void btnOldGIN_Click(object sender, EventArgs e)
        {
            txtoldGIN.Visible = true;
        }

        protected void btnClose_Click(object sender, EventArgs e)
        {
            ViewState["GINSaved"] = null;
            ScriptManager.RegisterStartupScript(this, this.GetType(), "Close_Window", "self.close();", true);
        }

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

        protected void btnIssueConfirm_Click(object sender, EventArgs e)
        {

            string status = cmbIssueStatus.SelectedValue.ToString();

            im.fkIssueByBranchID = int.Parse(cmbbranchfrom.SelectedValue.ToString());

            im.fkIssueByDeptID = int.Parse(cmbDepartmentfrom.SelectedValue.ToString());

            im.fkIssueByStoreID = int.Parse(cmbstorefrom.SelectedValue.ToString());

            im.IssueConfirm = 1;

            im.UpdateIssueConfirm(int.Parse(txtGINConfirm.Text), status);

            showMessageBox("GIN Status Updated As Confirm to Issued,Now Receiver Branch Can Received These Items!!!!");



            //  Response.Redirect("Main.aspx");
        }

        protected void cmbCatagories_SelectedIndexChanged(object sender, Telerik.Web.UI.RadComboBoxSelectedIndexChangedEventArgs e)
        {

            if (cmbCatagories.SelectedValue == "1" || cmbCatagories.SelectedValue == "2" || cmbCatagories.SelectedValue == "8")
            {
                cmbSystem.SelectedValue = "4";
            }
            else
            {
                cmbSystem.SelectedValue = im.pksysID.ToString();
            }


            // GetSubCategory(int.Parse(cmbCatagories.SelectedValue.ToString()));

            //  GetItemHead(int.Parse(cmbSubCategory.SelectedValue.ToString()));



            //cmbSubCategory.Items.Clear();

            Telerik.Web.UI.RadComboBoxItem subc = new Telerik.Web.UI.RadComboBoxItem();
            subc.Text = "Choose Sub Category";
            subc.Value = "Choose Sub Category";
            cmbSubCategory.Items.Add(subc);
            cmbSubCategory.SelectedIndex = cmbSubCategory.Items.Count - 1;



            // cmbItemHead.Items.Clear();

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

        protected void cmbSubCategory_SelectedIndexChanged(object sender, Telerik.Web.UI.RadComboBoxSelectedIndexChangedEventArgs e)
        {
            //GetItemHead(int.Parse(cmbSubCategory.SelectedValue.ToString()));




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
            // GetItems(int.Parse(cmbItemHead.SelectedValue.ToString()),2);
            RadSlider1.Focus();
        }

        protected void cmbItemSearch_SelectedIndexChanged(object sender, Telerik.Web.UI.RadComboBoxSelectedIndexChangedEventArgs e)
        {
            GetItems(0, 1);
        //    ConfirmItemEntry();
        }

        protected void cmbIssuedby_SelectedIndexChanged(object sender, Telerik.Web.UI.RadComboBoxSelectedIndexChangedEventArgs e)
        {
            if (cmbPersonto.SelectedValue == cmbIssuedby.SelectedValue)
            {
                cmbSystemTo.Visible = true;
            }
            else
            {
                cmbSystemTo.Visible = false;
            }
            btnSubmit.Visible = true;
        }

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
        protected void grdItems_RowUpdated(object sender, GridViewUpdatedEventArgs e)
        {

            e.KeepInEditMode = true;
            GridView GridView1 = (GridView)sender;
            int currRow = GridView1.SelectedRow.RowIndex;
            ((TextBox)grdItems.Rows[currRow].FindControl("txtqty")).Focus();

        }
        protected void grdItems_RowEditing(object sender, GridViewEditEventArgs e)
        {

        }

     
        #endregion

        #region RecordSave

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

            if (dt.Rows.Count == 0)
            {
                showMessageBox("Add Items first!!!!!");

                //   cmbbranchfrom.Enabled = true;
                cmbstorefrom.Enabled = true;
                cmbIssuedby.Enabled = true;
                cmbBranchto.Enabled = true;
                cmbStoreto.Enabled = true;
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
                    int fkstoreid = int.Parse(dt.Rows[0]["Issue Store Id"].ToString());
                    bool ginIsConfirmed = im.checkGINConfirmStatus(im.OLDGIN, fkstoreid);

                    if (ginIsConfirmed == true)
                    {
                        showMessageBox("This GIN is Already Confirmed, No More Additional Entries Allowed,Save Again To Create New GIN!!!");
                        txtoldGIN.Text = "0";
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

                if (cmbSystemTo.Visible == true)
                {
                    im.pksysIDTo = int.Parse(cmbSystemTo.SelectedValue.ToString());
                }

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

                    im.fkIssueByDeptID = int.Parse(cmbDepartmentfrom.SelectedValue);
                    im.fkIssuedToID = int.Parse(cmbPersonto.SelectedValue.ToString());

                    i = im.IUIssueItem(dt, ref get_GINNo, ref get_GPNo);
                }


                if (i == 0)
                {
                    showMessageBox("Something Went Wrong!!!!!!  GIN NOT SAVED...Please Verify and Do it Again....");
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
                cmbBranchto.Enabled = true;
                cmbStoreto.Enabled = true;
                cmbPersonto.Enabled = true;
                cmbDepartmentto.Enabled = true;

                cmbIssueStatus.Enabled = true;
                cmbIssueType.Enabled = true;

            }

        }

        protected void btnSubmit_Click(object sender, EventArgs e)
        {


        }


        //Convert List To DataTable.
        static DataTable ListToDataTable<T>(IEnumerable<T> list)
        {
            var dt = new DataTable();

            foreach (var info in typeof(T).GetProperties())
            {
                dt.Columns.Add(new DataColumn(info.Name, info.PropertyType));
            }
            foreach (var t in list)
            {
                var row = dt.NewRow();
                foreach (var info in typeof(T).GetProperties())
                {
                    row[info.Name] = info.GetValue(t, null);
                }
                dt.Rows.Add(row);
            }
            return dt;
        }


        // GridView gv = (GridView)sender;
        //gv.PageIndex = e.NewPageIndex;
        //helper = new DataHelper();
        //emplist = helper.GetEmployeeData();
        
        //DataTable dt = new DataTable();

        //if (emplist != null)
        //{
        //    if (emplist.Count > 0)
        //    {

        //        dt = ListToDataTable(emplist);
        //        if (dt != null)
        //        {
        //            if (dt.Rows.Count > 0)
        //            {
        //                BindGridView(gv, dt);
        //            }
        //        }
        //    }
        //}




        #endregion
    }
}