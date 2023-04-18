using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using BLL;
using System.Data;


namespace IMS
{
    public partial class BulkOPBalance : System.Web.UI.Page
    {
        //UserManager UMan = new UserManager();
        ItemManager im = new ItemManager();
        IMSManager iman = new IMSManager();
        UserManager Uman = new UserManager();
        

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


            Uman.Uid = int.Parse(IMS["uid"]);
            Uman.Ubrhid = int.Parse(IMS["ubrhid"]);
            Uman.Pkdeptid = int.Parse(IMS["udptid"]);
            Uman.Ugid =  int.Parse(IMS["ugroupid"]);


        }

        public void SetupGrid()
        { 
            DataTable dt = new DataTable();
            grdItems.DataSource = dt;
            grdItems.DataBind();

            grdItems.Visible = false;

            Telerik.Web.UI.RadComboBoxItem hd = new Telerik.Web.UI.RadComboBoxItem();
            hd.Text = "Choose Items Head";
            hd.Value = "Choose Items Head";
            cmbItemHead.Items.Add(hd);
            cmbItemHead.SelectedIndex = cmbItemHead.Items.Count - 1;
        
        }


        private void SetupForm()
        {
            GetUserInfo();
           
            GetSystem();
            GetStores();
            GetDepartments();
            GetLocations();
            GetCategory();

     

                Telerik.Web.UI.RadComboBoxItem sys = new Telerik.Web.UI.RadComboBoxItem();
                sys.Text = "Choose System";
                sys.Value = "Choose System";
                cmbSystem.Items.Add(sys);
                cmbSystem.SelectedIndex = cmbSystem.Items.Count - 1;

                //Telerik.Web.UI.RadComboBoxItem st = new Telerik.Web.UI.RadComboBoxItem();
                //st.Text = "Choose Store";
                //st.Value = "Choose Store";
                //cmbStores.Items.Add(st);
                //cmbStores.SelectedIndex = cmbStores.Items.Count - 1;

                //Telerik.Web.UI.RadComboBoxItem dp = new Telerik.Web.UI.RadComboBoxItem();
                //dp.Text = "Choose Department";
                //dp.Value = "Choose Department";
                //cmbDepartment.Items.Add(dp);
                //cmbDepartment.SelectedIndex = cmbDepartment.Items.Count - 1;

                //Telerik.Web.UI.RadComboBoxItem lc = new Telerik.Web.UI.RadComboBoxItem();
                //lc.Text = "Choose Locations";
                //lc.Value = "Choose Locations";
                //cmbLocation.Items.Add(lc);
                //cmbLocation.SelectedIndex = cmbLocation.Items.Count - 1;

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

                 UserSettings();
                 btnSave.Visible = false;

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
            im.fkcatid = int.Parse(cmbCategory.SelectedValue.ToString());
            int sysid;

            if (im.fkcatid == 1 || im.fkcatid == 2)
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

        public void UserSettings()
        { 
        
            if (Uman.Ugid==28 || Uman.Ugid==30)
            {
                cmbStores.SelectedValue = "1";
                cmbDepartment.SelectedValue = Uman.Pkdeptid.ToString();

                cmbStores.Enabled = false;
                cmbDepartment.Enabled = false;

            }
        
            if (Uman.Ugid==31 || Uman.Ugid==32)
            {
                int sysid = GetSysinfo();
                cmbSystem.SelectedValue = sysid.ToString();
                cmbSystem.Enabled = false;

                cmbStores.SelectedValue = "2";
                cmbDepartment.SelectedValue = "14";
                    
                //Uman.Pkdeptid.ToString();
                
                cmbStores.Enabled = false;
                cmbDepartment.Enabled = false;

            }

            if (Uman.Uid == 94)
            {
                cmbSystem.SelectedValue = "4";
                cmbSystem.DataBind();
                cmbSystem.Enabled = false;
            }


        
        }

        public void GetStores()
        {
            int brhid = int.Parse(Uman.Ubrhid.ToString());
            
            cmbStores.DataSource = im.GetStores(brhid);
            cmbStores.DataTextField = "StoreName";
            cmbStores.DataValueField = "pkStoreID";
            cmbStores.DataBind();
        }

        public void GetDepartments()
        {
            int uid = int.Parse(Uman.Uid.ToString());
            cmbDepartment.DataSource = im.GetDepartment(uid);
            cmbDepartment.DataTextField = "DeptName";
            cmbDepartment.DataValueField = "pkdeptID";
            cmbDepartment.DataBind();

        }

        public void GetLocations()
        {
            int brhid = int.Parse(Uman.Ubrhid.ToString());
            cmbLocation.DataSource = im.Getlocations(brhid);
            cmbLocation.DataTextField = "LocationName";
            cmbLocation.DataValueField = "pkLocID";
            cmbLocation.DataBind();
            cmbLocation.SelectedValue = "1";

        }

        public void GetCategory()
        {
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

            Telerik.Web.UI.RadComboBoxItem sct = new Telerik.Web.UI.RadComboBoxItem();
            sct.Text = "Choose Sub Category";
            sct.Value = "Choose Sub Category";
            cmbSubCategory.Items.Add(sct);
            cmbSubCategory.SelectedIndex = cmbSubCategory.Items.Count - 1;


        }

        public void GetItemHead(int subcatid)
        {
            im.SubCatID = subcatid;

            cmbItemHead.DataSource = im.GetItemHeads();
            cmbItemHead.DataTextField = "ItemHeadTitle";
            cmbItemHead.DataValueField = "pkItemHeadID";
            cmbItemHead.DataBind();

            Telerik.Web.UI.RadComboBoxItem hd = new Telerik.Web.UI.RadComboBoxItem();
            hd.Text = "Choose Items Head";
            hd.Value = "Choose Items Head";
            cmbItemHead.Items.Add(hd);
            cmbItemHead.SelectedIndex = cmbItemHead.Items.Count - 1;
        }


        public void BindData(int sysid, int id, int id1)
        {
            DataTable dt = new DataTable();
            dt = im.GetItems(sysid,id, id1, "IN");

            dt.Columns.Add("OPBalance", typeof(float));
            dt.Columns.Add("Order Limit", typeof(float));
            dt.Columns.Add("Model", typeof(string));
            dt.Columns.Add("Brand", typeof(string));
            
            grdItems.DataSource = dt;
            grdItems.DataBind();
 

            if (dt.Rows.Count == 0)
            {
                showMessageBox("Item Not Exist OR Already Have Balance in your Store,Please Use Single Item Balance Option to Verify!");
                dt = null;
                ViewState["dt"] = null;
                btnSave.Visible = false;
            }
            else
            {
                grdItems.Visible = true;
                ViewState["dt"] = dt;
                btnSave.Visible = true;
            }




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

        protected void btnSave_Click(object sender, EventArgs e)
        {
            HttpCookie IMS = Request.Cookies["IMS"];
            if (IMS == null)
                Response.Redirect("logout.aspx");

            iman.Pkbrhid = int.Parse(IMS["ubrhid"]);
            iman.Uid = int.Parse(IMS["uid"]);

            im.CreatedBy = iman.Uid;           
            im.fkbrhid = iman.Pkbrhid;
            im.fkstoreid = int.Parse(cmbStores.SelectedValue.ToString());
            im.fkdepartid = int.Parse(cmbDepartment.SelectedValue.ToString());
            im.fklocid = int.Parse(cmbLocation.SelectedValue.ToString());
            im.SubCatID = int.Parse(cmbSubCategory.SelectedValue.ToString());
            im.fkitemheadid = int.Parse(cmbItemHead.SelectedValue.ToString());
            im.pksysID = GetSysID();

            DataTable udt = new DataTable();
            udt =  (DataTable)ViewState["dt"];

            int result = im.IUItemOpeningBalance(udt);

            showMessageBox("Items Opening Balances Successfully Inserted....!!! ");

           // SetupForm();
            SetupGrid();
        }

        #endregion

        protected void cmbStores_SelectedIndexChanged(object sender, Telerik.Web.UI.RadComboBoxSelectedIndexChangedEventArgs e)
        {
   
       


        }

        protected void grdItems_RowCommand(object sender, GridViewCommandEventArgs e)
        {

       
        }

        protected void grdItems_RowEditing(object sender, GridViewEditEventArgs e)
        {



        }

        protected void grdItems_RowUpdating(object sender, GridViewUpdateEventArgs e)
        {

 

        }

        protected void cmbCategory_SelectedIndexChanged(object sender, Telerik.Web.UI.RadComboBoxSelectedIndexChangedEventArgs e)
        {
            GetSubCategory(int.Parse(cmbCategory.SelectedValue.ToString()));
           // GetItemHead(int.Parse(cmbSubCategory.SelectedValue.ToString())); 
        }

        protected void cmbSubCategory_SelectedIndexChanged(object sender, Telerik.Web.UI.RadComboBoxSelectedIndexChangedEventArgs e)
        {
            GetItemHead(int.Parse(cmbSubCategory.SelectedValue.ToString()));            
        }

        protected void txtopbal_TextChanged(object sender, EventArgs e)
        {

            TextBox thisTextBox = (TextBox)sender;
            GridViewRow currentRow = (GridViewRow)thisTextBox.Parent.Parent;
            int rowindex = 0;
            rowindex = currentRow.RowIndex;

            DataTable dt = (DataTable)ViewState["dt"];

            dt.Rows[rowindex]["OPBalance"] = float.Parse(thisTextBox.Text == "" ? "0" : thisTextBox.Text);
            ViewState["dt"] = dt;

            grdItems.DataSource = dt;
            grdItems.DataBind();
        }

        protected void txtOLimit_TextChanged(object sender, EventArgs e)
        {
            TextBox thisTextBox = (TextBox)sender;
            GridViewRow currentRow = (GridViewRow)thisTextBox.Parent.Parent;
            int rowindex = 0;
            rowindex = currentRow.RowIndex;

            DataTable dt = (DataTable)ViewState["dt"];

            dt.Rows[rowindex]["Order Limit"] = float.Parse(thisTextBox.Text == "" ? "0" : thisTextBox.Text);
            ViewState["dt"] = dt;

            grdItems.DataSource = dt;
            grdItems.DataBind();
        }

        protected void txtbrand_TextChanged(object sender, EventArgs e)
        {
            TextBox thisTextBox = (TextBox)sender;
            GridViewRow currentRow = (GridViewRow)thisTextBox.Parent.Parent;
            int rowindex = 0;
            rowindex = currentRow.RowIndex;

            DataTable dt = (DataTable)ViewState["dt"];

            dt.Rows[rowindex]["Brand"] = thisTextBox.Text;
            ViewState["dt"] = dt;

            grdItems.DataSource = dt;
            grdItems.DataBind();
        }

        protected void txtModel_TextChanged(object sender, EventArgs e)
        {
            TextBox thisTextBox = (TextBox)sender;
            GridViewRow currentRow = (GridViewRow)thisTextBox.Parent.Parent;
            int rowindex = 0;
            rowindex = currentRow.RowIndex;

            DataTable dt = (DataTable)ViewState["dt"];

            dt.Rows[rowindex]["Model"] = thisTextBox.Text;
            ViewState["dt"] = dt;

            grdItems.DataSource = dt;
            grdItems.DataBind();
        }

        protected void cmbItemHead_SelectedIndexChanged(object sender, Telerik.Web.UI.RadComboBoxSelectedIndexChangedEventArgs e)
        {
            im.pksysID = GetSysID();
            im.fkbrhid = iman.Pkbrhid;
            im.fkstoreid = int.Parse(cmbStores.SelectedValue.ToString());
            im.fkdepartid = int.Parse(cmbDepartment.SelectedValue.ToString());
            im.fklocid = int.Parse(cmbLocation.SelectedValue.ToString());
            im.SubCatID = int.Parse(cmbSubCategory.SelectedValue.ToString());
            im.fkitemheadid = int.Parse(cmbItemHead.SelectedValue.ToString());


            BindData(im.pksysID,im.fkstoreid, im.fkitemheadid);
        }

        protected void cmbSystem_SelectedIndexChanged(object sender, Telerik.Web.UI.RadComboBoxSelectedIndexChangedEventArgs e)
        {
            im.pksysID = int.Parse(cmbSystem.SelectedValue.ToString());
        }

    }
}