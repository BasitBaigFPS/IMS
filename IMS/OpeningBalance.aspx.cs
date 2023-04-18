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
    public partial class OpeningBalance : System.Web.UI.Page
    {
        ItemManager im = new ItemManager();
        IMSManager iman = new IMSManager();
        UserManager Uman = new UserManager();



        #region Helper Methods

        public int GetSysinfo()
        {
            HttpCookie IMS = Request.Cookies["IMS"];
            if (IMS == null)
                Response.Redirect("logout.aspx");
           

            int sysid = Uman.GetSysinfo(int.Parse(IMS["ubrhid"]));

            return sysid;

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

        protected void showMessageBox(string message)
        {
            string sScript;
            message = message.Replace("'", "\'");
            sScript = String.Format("alert('{0}');", message);
            ScriptManager.RegisterStartupScript(this, this.GetType(), "alert", sScript, true);
        }

        public void GetSystem()
        {
            cmbSystem.DataSource = iman.GetSystem();
            cmbSystem.DataTextField = "SystemName";
            cmbSystem.DataValueField = "pksysID";
            cmbSystem.DataBind();
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

        public void GetStore()
        {         
             
                DataSet ds = im.GetStores(Uman.Ubrhid);
                cmbStores.DataSource = ds.Tables[0];
                cmbStores.DataTextField = "StoreName";
                cmbStores.DataValueField = "pkStoreID";
                cmbStores.DataBind();

                Telerik.Web.UI.RadComboBoxItem sto = new Telerik.Web.UI.RadComboBoxItem();
                sto.Text = "Choose Store";
                sto.Value = "Choose Store";
                cmbStores.Items.Add(sto);
                cmbStores.SelectedIndex = cmbStores.Items.Count - 1;        


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
        }

        public void GetItemHead(int subcatid)
        {
            im.SubCatID = subcatid;

            cmbItemHead.DataSource = im.GetItemHeads();
            cmbItemHead.DataTextField = "ItemHeadTitle";
            cmbItemHead.DataValueField = "pkItemHeadID";
            cmbItemHead.DataBind();

            Telerik.Web.UI.RadComboBoxItem ih = new Telerik.Web.UI.RadComboBoxItem();
            ih.Text = "Choose Item Head";
            ih.Value = "Choose Item Head";
            cmbItemHead.Items.Add(ih);
            cmbItemHead.SelectedIndex = cmbItemHead.Items.Count - 1;

        }

        public void GetItems()
        {

            if (cmbItemHead.SelectedValue != "Choose Item Head")
            {

                DataTable di = im.GetAllItems("2", int.Parse(cmbItemHead.SelectedValue.ToString()));
                cmbItem.DataSource = di;
                cmbItem.DataTextField = "ItemTitle";
                cmbItem.DataValueField = "pkItemID";
                cmbItem.DataBind();


                Telerik.Web.UI.RadComboBoxItem it = new Telerik.Web.UI.RadComboBoxItem();
                it.Text = "Choose Item";
                it.Value = "Choose Item";
                cmbItem.Items.Add(it);
                cmbItem.SelectedIndex = cmbItem.Items.Count - 1;
            }

        }

        

        public void GetDepartments()
        {
            int dp = 0;
            DataSet dd = im.GetDepartment(dp);
            cmbDepartment.DataSource = dd.Tables[0];
            cmbDepartment.DataTextField = "deptName";
            cmbDepartment.DataValueField = "pkdeptID";
            cmbDepartment.DataBind();


            Telerik.Web.UI.RadComboBoxItem d = new Telerik.Web.UI.RadComboBoxItem();
            d.Text = "Choose Department";
            d.Value = "0";
            cmbDepartment.Items.Add(d);
            cmbDepartment.SelectedIndex = cmbDepartment.Items.Count - 1;
        }

        public void GetLoations(int brhid)
        {

            DataSet dl = im.Getlocations(brhid);
            cmbLocation.DataSource = dl.Tables[0];
            cmbLocation.DataTextField = "LocationName";
            cmbLocation.DataValueField = "pkLocID";
            cmbLocation.DataBind();

            Telerik.Web.UI.RadComboBoxItem i = new Telerik.Web.UI.RadComboBoxItem();
            i.Text = "Choose Location";
            i.Value = "Choose Location";
            cmbLocation.Items.Add(i);

            cmbLocation.SelectedIndex = cmbLocation.Items.Count - 1;

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
                //cmbDepartment.SelectedValue = Uman.Pkdeptid.ToString();

                if (Uman.Ubrhid != 19)
                {
                    cmbStores.Enabled = false;
                }
                cmbDepartment.Enabled = false;
            }

            if (Uman.Uid == 94)
            {
                cmbSystem.SelectedValue = "4";
                cmbSystem.DataBind();
                cmbSystem.Enabled = false;
            }


        }

        void ShowGrid()
        {
            GetUserInfo();


            if (cmbStores.SelectedValue != "Choose Store")
            {
                DataTable dg = im.GetStoreInventory(im.pksysID, int.Parse(cmbStores.SelectedValue.ToString()));

                grdItems.DataSource = dg;
                grdItems.DataBind();
            }
        
        }


        void fillcombo() {
            //int fkbrhid = 19;

            HttpCookie IMS = Request.Cookies["IMS"];
            if (IMS == null)
                Response.Redirect("logout.aspx");

            int fkbrhid = int.Parse(IMS["ubrhid"]);

            im.pksysID = GetSysID();

            int fkstoreid = int.Parse(cmbStores.SelectedValue.ToString());
            int fkitemid = (cmbItem.SelectedValue.ToString() == "Choose Item" ? 1 : int.Parse(cmbItem.SelectedValue.ToString()));

            DataTable dt = im.CheckItem(im.pksysID,fkbrhid, fkstoreid, fkitemid);

            if (dt.Rows.Count == 0)
            {
                txtitemmodel.Text = "";
                txtitembrand.Text = "";
                //cmbDepartment.SelectedValue = "Choose Department";
                //cmbLocation.SelectedValue = "Choose Location";
                txtopenbalanceqty.Text = "";
                txtorderlimit.Text = "";
                btnSubmit.Text = "Insert";
                im.Token = "I";


            }
            else
            {
                txtitemmodel.Text = dt.Rows[0]["Model"].ToString();
                txtitembrand.Text = dt.Rows[0]["Brand"].ToString();
                //cmbDepartment.SelectedValue = dt.Rows[0]["fkDeptID"].ToString();
                //cmbLocation.SelectedValue = dt.Rows[0]["fkLocID"].ToString();
                txtopenbalanceqty.Text = dt.Rows[0]["OPBalance"].ToString();
                txtorderlimit.Text = dt.Rows[0]["OrderLimit"].ToString();

                btnSubmit.Text = "Update";
                im.Token = "U";
            }

            btnSubmit.Visible = true;

        }

        #endregion

        #region Events 
        
        protected void Page_Load(object sender, EventArgs e)
        {
            if (Page.IsPostBack == false)
            {

                GetUserInfo();

               
                //iman.Uid = int.Parse(IMS["uid"]);
                //iman.Pkdeptid = int.Parse(IMS["udptid"] == null ? "0" : IMS["udptid"]);
                //iman.Pkbrhid = int.Parse(IMS["ubrhid"]);

                GetSystem();

                Telerik.Web.UI.RadComboBoxItem sys = new Telerik.Web.UI.RadComboBoxItem();
                sys.Text = "Choose System";
                sys.Value = "Choose System";
                cmbSystem.Items.Add(sys);
                cmbSystem.SelectedIndex = cmbSystem.Items.Count - 1;

                GetStore();

                GetDepartments();

                GetLoations(Uman.Ubrhid);

                GetCategory();

                GetSubCategory(int.Parse(cmbCategory.SelectedValue.ToString()));

                GetItemHead(int.Parse(cmbSubCategory.SelectedValue.ToString()));

                GetItems();

                UserSettings();
                //=====================================================

 

                //Telerik.Web.UI.RadComboBoxItem it = new Telerik.Web.UI.RadComboBoxItem();
                //it.Text = "Choose Item";
                //it.Value = "Choose Item";
                //cmbItem.Items.Add(it);
                //cmbItem.SelectedIndex = cmbItem.Items.Count - 1;



                //DataSet dd = im.GetDepartment(iman.Uid);
                //cmbDepartment.DataSource = dd.Tables[0];
                //cmbDepartment.DataTextField = "deptName";
                //cmbDepartment.DataValueField = "pkdeptID";
                //cmbDepartment.DataBind();


                //Telerik.Web.UI.RadComboBoxItem d = new Telerik.Web.UI.RadComboBoxItem();
                //d.Text = "Choose Department";
                //d.Value = "Choose Department";
                //cmbDepartment.Items.Add(d);
                //cmbDepartment.SelectedIndex = cmbDepartment.Items.Count - 1;


                //DataSet dl = im.Getlocations(iman.Pkbrhid);
                //cmbLocation.DataSource = dl.Tables[0];
                //cmbLocation.DataTextField = "LocationName";
                //cmbLocation.DataValueField = "pkLocID";
                //cmbLocation.DataBind();

                //Telerik.Web.UI.RadComboBoxItem i = new Telerik.Web.UI.RadComboBoxItem();
                //i.Text = "Choose Location";
                //i.Value = "Choose Location";
                //cmbLocation.Items.Add(i);

                cmbLocation.SelectedIndex = cmbLocation.Items.Count - 1;



            }
        }

        protected void btnSubmit_Click(object sender, EventArgs e)
        {


            if (Page.IsValid)
            {
                //HttpCookie IMS = Request.Cookies["IMS"];
                //if (IMS == null)
                //    Response.Redirect("logout.aspx");

                GetUserInfo();

                if (btnSubmit.Text == "Update")

                {
                    im.CreatedBy = Uman.Uid;
                    im.fkbrhid = Uman.Ubrhid;

                    im.fkstoreid = int.Parse(cmbStores.SelectedValue.ToString());
                    im.fkdepartid = int.Parse(cmbDepartment.SelectedValue.ToString());
                    im.fklocid = int.Parse(cmbLocation.SelectedValue.ToString());
                    im.fkitemid = int.Parse(cmbItem.SelectedValue.ToString());
                    im.itemmodel = txtitemmodel.Text.ToString();
                    im.itembrand = txtitembrand.Text.ToString();
                    im.opbalance = float.Parse(txtopenbalanceqty.Text.ToString());
                    im.orderlimit = float.Parse(txtorderlimit.Text.ToString());
                    im.pksysID = GetSysID();
                    im.Token = "U";
                    int i = im.IUItemOpeningBalance();

                    showMessageBox("Item Has Been Updated Successfully....!");


                    cmbItem.SelectedValue = "Choose Item";
                    //cmbDepartment.SelectedValue = "Choose Department";
                    cmbLocation.SelectedValue = "Choose Location";
                    txtopenbalanceqty.Text = "";
                    txtorderlimit.Text = "";
                    txtitemmodel.Text = "";
                    txtitembrand.Text = "";



                }

                if (btnSubmit.Text == "Insert")
                {
                    im.CreatedBy = Uman.Uid;
                    im.fkbrhid = Uman.Ubrhid;

                    im.fkstoreid = int.Parse(cmbStores.SelectedValue.ToString());
                    im.fkdepartid = int.Parse(cmbDepartment.SelectedValue.ToString());
                    im.fklocid = int.Parse(cmbLocation.SelectedValue.ToString());
                    im.fkitemid = int.Parse(cmbItem.SelectedValue.ToString());
                    im.itemmodel = txtitemmodel.Text.ToString();
                    im.itemmodel = txtitemmodel.Text.ToString();
                    im.itembrand = txtitembrand.Text.ToString();
                    im.opbalance = float.Parse(txtopenbalanceqty.Text.ToString());
                    im.orderlimit = float.Parse(txtorderlimit.Text.ToString());
                    im.pksysID = GetSysID();
                    im.Token = "I";


                    int i = im.IUItemOpeningBalance();
                    showMessageBox("Item Has Been Inserted Successfully....!");

                    cmbItem.SelectedValue = "Choose Item";
                    //cmbDepartment.SelectedValue = "Choose Department";
                    cmbLocation.SelectedValue = "Choose Location";
                    txtopenbalanceqty.Text = "";
                    txtorderlimit.Text = "";
                    txtitemmodel.Text = "";
                    txtitembrand.Text = "";

                }
                
                ShowGrid();
       
            }

        }

        protected void cmbSystem_SelectedIndexChanged(object sender, Telerik.Web.UI.RadComboBoxSelectedIndexChangedEventArgs e)
        {
            im.pksysID = int.Parse(cmbSystem.SelectedValue.ToString());
           //ShowGrid();
        }

        protected void cmbStores_SelectedIndexChanged(object sender, Telerik.Web.UI.RadComboBoxSelectedIndexChangedEventArgs e)
        {
            
            im.pksysID = int.Parse(cmbSystem.SelectedValue.ToString());

           // ShowGrid();
        }

        protected void cmbItem_SelectedIndexChanged(object sender, Telerik.Web.UI.RadComboBoxSelectedIndexChangedEventArgs e)
        {
            ShowGrid();
            fillcombo();               
        }

        protected void cmbCategory_SelectedIndexChanged(object sender, Telerik.Web.UI.RadComboBoxSelectedIndexChangedEventArgs e)
        {
            GetSubCategory(int.Parse(cmbCategory.SelectedValue.ToString()));
            GetItemHead(int.Parse(cmbSubCategory.SelectedValue.ToString())); 
        }

        protected void cmbSubCategory_SelectedIndexChanged(object sender, Telerik.Web.UI.RadComboBoxSelectedIndexChangedEventArgs e)
        {
            GetItemHead(int.Parse(cmbSubCategory.SelectedValue.ToString()));  
        }

        protected void cmbItemHead_SelectedIndexChanged(object sender, Telerik.Web.UI.RadComboBoxSelectedIndexChangedEventArgs e)
        {
            GetItems();
        }

        protected void cmbLocation_SelectedIndexChanged(object sender, Telerik.Web.UI.RadComboBoxSelectedIndexChangedEventArgs e)
        {
           // ShowGrid();
        }

        
        #endregion

       
      
    }
}