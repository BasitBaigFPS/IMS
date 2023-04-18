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
    public partial class BulkOPBalanceFA : System.Web.UI.Page
    {
        //UserManager UMan = new UserManager();
        ItemManager im = new ItemManager();
        IMSManager iman = new IMSManager();
        UserManager Uman = new UserManager();
        StoreManager Sman = new StoreManager();
        DataTable edt;
      

        #region Helper Methods


        protected void showMessageBox(string message)
        {
            string sScript;
            message = message.Replace("'", "\'");
            sScript = String.Format("alert('{0}');", message);
            ScriptManager.RegisterStartupScript(this, this.GetType(), "alert", sScript, true);
        }

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

        public void GetBranch()
        {
            cmbBranch.DataSource = Sman.GetBranches();
            cmbBranch.DataTextField = "brhName";
            cmbBranch.DataValueField = "pkbrhID";
            cmbBranch.DataBind();
        }

        public void GetStores()
        {
            int brhid = int.Parse(Uman.Ubrhid.ToString());
            
            cmbStores.DataSource = im.GetStores(brhid);
            cmbStores.DataTextField = "StoreName";
            cmbStores.DataValueField = "pkStoreID";
            cmbStores.DataBind();
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

             GetItemHead(int.Parse(cmbSubCategory.SelectedValue.ToString()));
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
            i.Value = "0";
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

                cmbStores.SelectedValue = "22";
                cmbDepartment.SelectedValue = Uman.Pkdeptid.ToString();
                
                cmbStores.Enabled = false;
                cmbDepartment.Enabled = false;

            }

             if (Uman.Ugid==37)
            {
                cmbBranch.SelectedValue = Uman.Ubrhid.ToString();
                cmbStores.SelectedValue = "22";
                cmbDepartment.SelectedValue = Uman.Pkdeptid.ToString();
                cmbCategory.SelectedValue = "8";
                cmbLocation.SelectedValue = "1";

                 GetSubCategory(int.Parse(cmbCategory.SelectedValue.ToString()));

                //cmbStores.Enabled = false;
                //cmbDepartment.Enabled = false;

            }

             if (Uman.Ugid == 48)
             {
                 cmbStores.Visible = false;
                 cmbBranch.SelectedValue = Uman.Ubrhid.ToString();
                 cmbStores.SelectedValue = "1";
                 cmbDepartment.SelectedValue = Uman.Pkdeptid.ToString();
                 cmbCategory.SelectedValue = "11";
                 cmbLocation.SelectedValue = "24";

                 GetSubCategory(int.Parse(cmbCategory.SelectedValue.ToString()));

                 cmbBranch.Enabled = false;
                 cmbStores.Enabled = false;
                 cmbLocation.Enabled = false;
                 cmbDepartment.Enabled = false;
             }

             if (Uman.Ugid == 79)
             {
                 cmbStores.Visible = false;
             }
          
        
        }

        private void SetupForm()
        {
            GetUserInfo();
           
            DataTable dt = new DataTable();
            grdItems.DataSource = dt;
            grdItems.DataBind();
            grdItems.Visible = false;



            GetBranch();

                Telerik.Web.UI.RadComboBoxItem brh = new Telerik.Web.UI.RadComboBoxItem();
                brh.Text = "Choose Branch";
                brh.Value = "Choose Branch";
                cmbBranch.Items.Add(brh);
                cmbBranch.SelectedIndex = cmbBranch.Items.Count - 1;


            GetStores();
            GetDepartments();
            GetLoations(Uman.Ubrhid);
            GetCategory();

            GetSubCategory(int.Parse(cmbCategory.SelectedValue.ToString()));

            GetItemHead(int.Parse(cmbSubCategory.SelectedValue.ToString()));

            UserSettings();

        }

        private void GetDeptEmployee()
        { 
            int brhid = int.Parse(cmbBranch.SelectedValue.ToString());
            int dptid = int.Parse(cmbDepartment.SelectedValue.ToString());

            DataSet de = im.GetEmployees(brhid, dptid, "E");
            edt = de.Tables[0];
            ViewState["edt"] = edt;
        }

      
        public void BindData()
        {
           

            im.fkbrhid = int.Parse(cmbBranch.SelectedValue.ToString());
            im.fkdepartid = int.Parse(cmbDepartment.SelectedValue.ToString());

            if (im.fkdepartid == 14 || im.fkdepartid == 10)
            {
                im.fkstoreid = int.Parse(cmbStores.SelectedValue.ToString());
            }
            else
            {
                cmbStores.Visible = false;
            }
            
            im.fklocid = int.Parse(cmbLocation.SelectedValue.ToString());
            im.SubCatID = int.Parse(cmbSubCategory.SelectedValue.ToString());
            im.fkitemheadid = int.Parse(cmbItemHead.SelectedValue.ToString() == "Choose Item Head" ? "0" : cmbItemHead.SelectedValue.ToString());
            
            
            DataTable dt = new DataTable();
            dt = im.GetItems(im.fkbrhid,im.fkdepartid, im.fkitemheadid, "FA");

            dt.Columns.Add("OPBalance", typeof(float));
            dt.Columns.Add("Order Limit", typeof(float));
            dt.Columns.Add("Model", typeof(string));
            dt.Columns.Add("Brand", typeof(string));
            dt.Columns.Add("Person", typeof(string));
            

            grdItems.DataSource = dt;
            grdItems.DataBind();

            grdItems.Visible = true;

            ViewState["dt"] = dt;
            GetDeptEmployee();

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

        protected void btnRefresh_Click(object sender, EventArgs e)
        {
             BindData();
        }

        protected void btnSave_Click(object sender, EventArgs e)
        {
            HttpCookie IMS = Request.Cookies["IMS"];
            if (IMS == null)
                Response.Redirect("logout.aspx");

            iman.Pkbrhid = int.Parse(IMS["ubrhid"]);
            iman.Uid = int.Parse(IMS["uid"]);
            Uman.Pkdeptid = int.Parse(IMS["udptid"]);

            im.CreatedBy = iman.Uid;           
            im.fkbrhid = iman.Pkbrhid;

            if (cmbStores.Visible == true)
            {
                im.fkstoreid = int.Parse(cmbStores.SelectedValue.ToString());
            }
            else
            {
                im.fkstoreid = 0;
            }

            im.fkdepartid = int.Parse(cmbDepartment.SelectedValue.ToString());
            im.fklocid = int.Parse(cmbLocation.SelectedValue.ToString());
            im.SubCatID = int.Parse(cmbSubCategory.SelectedValue.ToString());
            im.fkitemheadid = int.Parse(cmbItemHead.SelectedValue.ToString());


            im.fkbrhid = int.Parse(cmbBranch.SelectedValue.ToString());
            im.fkIssueByBranchID = int.Parse(cmbBranch.SelectedValue.ToString());
            im.fkIssueByDeptID = int.Parse(cmbDepartment.SelectedValue.ToString());
           

            DataTable udt = new DataTable();
            udt =  (DataTable)ViewState["dt"];

            int result = im.IUItemOpeningBalance_FA(udt);

            showMessageBox("Items Opening Balances Successfully Inserted....!!! ");

        //    SetupForm();
        }

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
            
        }

        protected void cmbSubCategory_SelectedIndexChanged(object sender, Telerik.Web.UI.RadComboBoxSelectedIndexChangedEventArgs e)
        {
            GetItemHead(int.Parse(cmbSubCategory.SelectedValue.ToString()));            
        }

        protected void cmbItemHead_SelectedIndexChanged(object sender, Telerik.Web.UI.RadComboBoxSelectedIndexChangedEventArgs e)
        {            
            BindData();
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

        protected void ddlEmployee_SelectedIndexChanged(object sender, EventArgs e)
        {
            
            DropDownList thisddlist = (DropDownList)sender; 
            int rowid = int.Parse(thisddlist.SelectedIndex.ToString());
            GridViewRow currentRow = (GridViewRow)thisddlist.Parent.Parent;

             

            int rowindex = 0;
            rowindex = currentRow.RowIndex;

           
            DataTable dt = (DataTable)ViewState["dt"];

            dt.Rows[rowindex]["Person"] = thisddlist.Text;
            ViewState["dt"] = dt;

            grdItems.DataSource = dt;
            grdItems.DataBind();

            thisddlist.SelectedValue = dt.Rows[rowindex]["Person"].ToString();


        }

        protected void cmbBranch_SelectedIndexChanged(object sender, Telerik.Web.UI.RadComboBoxSelectedIndexChangedEventArgs e)
        {
                BindData();
        }

        protected void grdItems_RowDataBound(object sender, GridViewRowEventArgs e)
        {

             //Handle the Gridview RowDatabound Event
            if(e.Row.RowType  == DataControlRowType.DataRow)
            {
                //Check if it is a DataRow.
                //Cast the row item as DatarowView
                DataRowView drv=e.Row.DataItem as DataRowView ;

                //Get the Value City for the Current Row
                //String City=drv["City"].ToString();

                string empid = drv["Person"].ToString();
                DropDownList ddl = (DropDownList)e.Row.FindControl("ddlEmployee");


                    //Find the DropDownList inside the Rows
                    

                    //Bind the Temporory Table we have Created
                    DataTable empdt = new DataTable();
                    empdt = (DataTable)ViewState["edt"];
                    ddl.DataSource = empdt;

                    //Set the Display value
                    ddl.DataTextField = "empName";
                    ddl.DataValueField = "pkempID";


                    if (empid != "")
                    {
                        ddl.SelectedValue = empid;
                        ddl.DataBind();
                    }
                    else
                    {
                        //Bind the values to DropDownList
                        ddl.DataBind();
                        ddl.Items.Insert(0, new ListItem("--Select--", "0"));
                    }


                //Find the Current City and set that as Selected
                //ddl.Items.FindByText(City).Selected=true;
            }
        }

        protected void cmbDepartment_SelectedIndexChanged(object sender, Telerik.Web.UI.RadComboBoxSelectedIndexChangedEventArgs e)
        {
                BindData();
        }



        #endregion

    }
}