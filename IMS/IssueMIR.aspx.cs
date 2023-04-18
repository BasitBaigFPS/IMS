using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Data;
using BLL;


namespace IMS
{
    public partial class IssueMIR : System.Web.UI.Page
    {
        UserManager UMan = new UserManager();
        ItemManager im = new ItemManager();
        StoreManager sm = new StoreManager();
        VendorManager vm = new VendorManager();
        IMSManager iman = new IMSManager();

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


            DashBoardManager dbm = new DashBoardManager();
            dbm.fkbrhid = UMan.Ubrhid;

            List<string> MyList = dbm.GetUNRGinList();

            var collection = MyList;

            if (collection.Count != 0)
            {
                ScriptManager.RegisterStartupScript(this, this.GetType(), "alert", "alert('You Have Pending GIN(s) at Your IMS Dashboard, No Transaction is Allowed Until All The Pending GIN Not Received!');window.location ='MainDashboard.aspx';", true);
            }
 

        }


        public void UserSettings()
        {
            GetUserInfo();
            if (UMan.Ugid == 28 || UMan.Ugid == 30 || UMan.Ugid == 31)
            {
                //int sysid = GetSysinfo();
                cmbbranchto.SelectedValue = "25";
                cmbDeptto.SelectedValue = "14";
                cmbstoreto.SelectedValue = "1";
            }
        }


        public void SetupForm()
        {
            
            DataTable dt = new DataTable();
            ViewState["dt"] = dt;            
            
            GetUserInfo();

            im.CreatedBy = iman.Uid;

            GetRecvBranch(UMan.Ubrhid.ToString());

            GetRecvDepartment(UMan.Pkdeptid.ToString());

            GetRecvStore();

            im.CreatedBy = iman.Uid;

            GetBranches();
            //GetStores();
            GetDepartments();

            UserSettings();

        }

        public int GetSysinfo(int brhid)
        {
            int sysid = UMan.GetSysinfo(brhid);

            return sysid;

            //GetItemCategory(int itemid)
        }


        public void GetRecvBranch(string brhid)
        {
           
            DataSet db = im.GetBranches();

            cmbbranchto.DataSource = db.Tables[0];
            cmbbranchto.DataTextField = "brhName";
            cmbbranchto.DataValueField = "pkbrhID";
            cmbbranchto.DataBind();

            cmbbranchto.SelectedValue = brhid;

            cmbbranchto.Enabled = false;
        
        }

        public void GetRecvDepartment(string dptid)
        {
            
            cmbDeptto.DataSource = sm.GetDepartment(0);
            cmbDeptto.DataTextField = "deptName";
            cmbDeptto.DataValueField = "pkdeptID";
            cmbDeptto.DataBind();

            cmbDeptto.SelectedValue = dptid;
            cmbDeptto.Enabled = false;

            
        }

        public void GetRecvStore()
        {
                sm.fkbrhID = int.Parse(cmbbranchto.SelectedValue.ToString());
                sm.Token = "SB";
                cmbstoreto.DataSource = sm.GetStores();
                cmbstoreto.DataTextField = "StoreName";
                cmbstoreto.DataValueField = "pkStoreID";
                cmbstoreto.DataBind();
                cmbstoreto.SelectedValue = "1";
                cmbstoreto.Enabled = false;

        }

        public void GetBranches()
        {
             
            DataSet db = im.GetBranches();

            cmbbranchfrom.DataSource = db.Tables[0];
            cmbbranchfrom.DataTextField = "brhName";
            cmbbranchfrom.DataValueField = "pkbrhID";
            cmbbranchfrom.DataBind();

            //cmbbranchfrom.SelectedValue = int.Parse(IMS["ubrhid"]).ToString();
        
        }

        public void GetStores()
        {
                sm.fkbrhID = int.Parse(cmbbranchfrom.SelectedValue.ToString());
                sm.Token = "SB";
                cmbstorefrom.DataSource = sm.GetStores();
                cmbstorefrom.DataTextField = "StoreName";
                cmbstorefrom.DataValueField = "pkStoreID";
                cmbstorefrom.DataBind();

                Telerik.Web.UI.RadComboBoxItem s = new Telerik.Web.UI.RadComboBoxItem();
                s.Text = "Choose Store";
                s.Value = "Choose Store";
                cmbstorefrom.Items.Add(s);
                cmbstorefrom.SelectedIndex = cmbstorefrom.Items.Count - 1;

            btnSubmit.Enabled = true;

        }

        public void GetDepartments()
        {
            cmbDept.DataSource = sm.GetDepartment(0);
            cmbDept.DataTextField = "deptName";
            cmbDept.DataValueField = "pkdeptID";
            cmbDept.DataBind();
        }

        protected void showMessageBox(string message)
        {
            string sScript;
            message = message.Replace("'", "\'");
            sScript = String.Format("alert('{0}');", message);
            ScriptManager.RegisterStartupScript(this, this.GetType(), "alert", sScript, true);
        }


        protected void SetupGrid(DataTable MIRTable)
        {
            int rowindex = 0;
            foreach (DataRow row in MIRTable.Rows)
            {               
                MIRTable.Rows[rowindex]["QtyIssue"] = MIRTable.Rows[rowindex]["Qtty"];
                rowindex++;
            }
            
            
            grdItems.DataSource = MIRTable;
            grdItems.DataBind();
            grdItems.Visible = true;

            btnSave.Visible = true;

            ViewState["dt"] = MIRTable;
          
            RadSlider1.Focus();
        }


        #endregion



        #region Events 
        
        protected void Page_Load(object sender, EventArgs e)
        {
            if (Page.IsPostBack == false)
            {

                GetUserInfo();

                sm.fkbrhID = UMan.Ubrhid;
                iman.Uid = UMan.Uid;
                iman.Pkdeptid = UMan.Pkdeptid;
                    //int.Parse(IMS["udptid"] == null ? "0" : IMS["udptid"]);

                UMan.GetUserInfo(iman.Uid);
                
                SetupForm();
            }
            txtmirno.Focus();
            
        }

        protected void grdItems_RowCommand(object sender, GridViewCommandEventArgs e)
        { 
            if (e.CommandName == "Delete")
            {      
                int index = Convert.ToInt32(e.CommandArgument);
                DataTable dt = (DataTable)ViewState["dtItems"];
              
                dt.Rows[index].Delete();
                ViewState["dtItems"] = dt;
                DataView view = new DataView(dt);
                grdItems.DataSource = view;
                grdItems.DataBind();

              
            }
        }

        protected void cmbDept_SelectedIndexChanged(object sender, Telerik.Web.UI.RadComboBoxSelectedIndexChangedEventArgs e)
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

            if (int.Parse(thisTextBox.Text) <= int.Parse(dt.Rows[rowindex]["CRBalance"].ToString()))
            {
                dt.Rows[rowindex]["QtyIssue"] = int.Parse(thisTextBox.Text);
                ViewState["dt"] = dt;

                //chkb = checkItemBalance(dt, dt.Rows[rowindex]["Item Code"].ToString(), int.Parse(dt.Rows[rowindex]["Issue Store Id"].ToString()), int.Parse(dt.Rows[rowindex]["Balance"].ToString()), int.Parse(thisTextBox.Text));

                //if (chkb == false)
                //{
                //    dt.Rows[rowindex]["QtyIssue"] = int.Parse(thisTextBox.Text);
                //    ViewState["dt"] = dt;
                //}

                //else
                //{
                //    thisTextBox.Text = "0";
                //    showMessageBox("Please Enter Qty Less than Total Current Balance");
                //}

            }

            else
            {
                thisTextBox.Text = "0";
                showMessageBox("Please Enter Qty Less than Total Current Balance");
            }


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
       
        protected void btnSave_Click(object sender, EventArgs e)
        {
             HttpCookie IMS = Request.Cookies["IMS"];
            if (IMS == null)
                Response.Redirect("logout.aspx");


            DataTable dt = (DataTable)ViewState["dt"];

            im.fkdepartid = int.Parse(IMS["udptid"] == null ? "0" : IMS["udptid"]);
            im.CreatedBy = int.Parse(IMS["uid"]);

            im.OLDGIN = 0;
            im.Token = "I";

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

 
            int i = im.IUIssueItemMIR(dt, ref get_GINNo, ref get_GPNo);

            showMessageBox("Items Inserted!!!!! with GIN Number : " + i.ToString());

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


            im.SendReportEmail(im.fkIssueByBranchID, storeid, im.fkIssueByDeptID, 3, i);


            // Response.Redirect("ReportsMain.aspx?rptname=GoodsIssueNote&gino=" + txtginno.Text,false);

            //btnPrint_Click(sender, e);
            //btnPrintGatePass_Click(sender, e);

            SetupForm();

            ViewState["dt"] = null;
            grdItems.DataSource = null;
            grdItems.DataBind();

        }

        protected void btnPrint_Click(object sender, EventArgs e)
        {
           // Response.Redirect("ReportsMain.aspx?rptname=GoodsReceiptNote&grno="+txtgrnno.Text);

            string url = "ReportsMain.aspx?rptname=GoodsIssueNote&gino=" + txtginno.Text;

            Response.Write("<script>" + "window.open(" + url + ",'_newtab')" + "</script>");


        }

        protected void btnClose_Click(object sender, EventArgs e)
        {
            ScriptManager.RegisterStartupScript(this, this.GetType(), "Close_Window", "self.close();", true);
        }

        protected void btnSubmit_Click(object sender, EventArgs e)
        {

            GetUserInfo();
            if (UMan.Ugid == 28 || UMan.Ugid == 30 || UMan.Ugid == 31)
            {
                im.fkIssueByDeptID = 14;
                im.fkIssueToDeptID = 14;
            }
            else
            {
                im.fkIssueByDeptID = int.Parse(cmbDept.SelectedValue.ToString());
                im.fkIssueToDeptID = int.Parse(cmbDeptto.SelectedValue.ToString());            
            }
            im.fkIssueByBranchID = int.Parse(this.cmbbranchfrom.SelectedValue.ToString());            
            im.fkIssueByStoreID = int.Parse(cmbstorefrom.SelectedValue.ToString());
            im.fkIssueToBranchID = int.Parse(this.cmbbranchto.SelectedValue.ToString());           
            im.fkIssueToStoreID = int.Parse(cmbstoreto.SelectedValue.ToString());


            int MirNo = int.Parse(txtmirno.Text);

            DataTable MIRData = im.GetItemsByMIR(MirNo);

            if (MIRData.Rows.Count == 0)
            {
                showMessageBox("No Record Found For Your Branch of This MIR No: " + MirNo.ToString() + ", Or This MIR Already Received!!!  Please Select Correct Parameters...");
            }
            else
            {
                SetupGrid(MIRData);
            }


        }

        protected void cmbbranchfrom_SelectedIndexChanged(object sender, Telerik.Web.UI.RadComboBoxSelectedIndexChangedEventArgs e)
        {
             GetStores();
            
        }

        protected void cmbstorefrom_SelectedIndexChanged(object sender, Telerik.Web.UI.RadComboBoxSelectedIndexChangedEventArgs e)
        {

            btnSubmit.Enabled = true;
        }
     
        #endregion



    }
}