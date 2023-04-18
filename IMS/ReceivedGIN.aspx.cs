using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Data;
using BLL;
using Telerik.Web.UI;


namespace IMS
{
    public partial class ReceivedGIN : System.Web.UI.Page
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

            UMan.Grpuserdeptid = int.Parse(IMS["grpuserdptid"]);
            UMan.Grpuserbrhid = int.Parse(IMS["grpuserbrhid"]);
            UMan.Grpuserstoreid = int.Parse(IMS["grpuserstoreid"]);

            UMan.Ubrhid = UMan.Grpuserbrhid;
            UMan.Pkdeptid = UMan.Grpuserdeptid;
            UMan.PkstoreID = UMan.Grpuserstoreid;

        }


        public void UserSettings()
        {
            GetUserInfo();

            if (UMan.Ugid==31 || UMan.Ugid==32)
            {
                //int sysid = GetSysinfo();
                cmbbranchfrom.SelectedValue = UMan.Grpuserbrhid.ToString();
                cmbDept.SelectedValue = UMan.Grpuserdeptid.ToString();
            }
            else
            {
                GetRecvDepartment(UMan.Pkdeptid.ToString());

                GetRecvStore();
                
                cmbbranchfrom.Enabled = true;
                cmbDept.Enabled = true;
                cmbstorefrom.Enabled = true;
            }
        }


        public void SetupForm()
        {
            
            GetUserInfo();

            im.CreatedBy = iman.Uid;

            GetRecvBranch(UMan.Ubrhid.ToString());


            im.CreatedBy = iman.Uid;

            GetBranches();

            GetDepartments();


            //GetStores();

            //Telerik.Web.UI.RadComboBoxItem b = new Telerik.Web.UI.RadComboBoxItem();
            //b.Text = "Choose Branch";
            //b.Value = "Choose Branch";
            //cmbbranchfrom.Items.Add(b);
            //cmbbranchfrom.SelectedIndex = cmbbranchfrom.Items.Count - 1;
            //cmbbranchfrom.SelectedValue = "19";

            //Telerik.Web.UI.RadComboBoxItem dpt = new Telerik.Web.UI.RadComboBoxItem();
            //dpt.Text = "Choose Department";
            //dpt.Value = "Choose Department";
            //cmbDept.Items.Add(dpt);
            //cmbDept.SelectedIndex = cmbDept.Items.Count - 1;
            //cmbDept.SelectedValue = "14";

            UserSettings();

            if (UMan.Ugid != 28)
            {
               LoadStores();
            }

        }

        public int GetSysinfo()
        {
            HttpCookie IMS = Request.Cookies["IMS"];
            if (IMS == null)
                Response.Redirect("logout.aspx");
            
            sm.fkbrhID = int.Parse(IMS["ubrhid"]);

            int sysid = UMan.GetSysinfo(sm.fkbrhID);

            return sysid;

        }

        public void GetRecvBranch(string brhid)
        {
            int sysid = GetSysinfo();
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

            if (cmbDeptto.Items.Count <= 1)
            {
                cmbDeptto.DataSource = sm.GetDepartment(UMan.Uid);
                cmbDeptto.DataTextField = "deptName";
                cmbDeptto.DataValueField = "pkdeptID";
                cmbDeptto.DataBind();
                cmbDeptto.SelectedValue = dptid;
            }
            else
            {
                cmbDeptto.SelectedValue = dptid;
            }
            //cmbDeptto.Enabled = false;

        }

        public void GetRecvStore()
        {
                sm.fkbrhID = int.Parse(cmbbranchto.SelectedValue.ToString());
                sm.Token = "SB";

                sm.fkdeptID = UMan.Pkdeptid;

                if (UMan.Pkdeptid == 10 || UMan.Ugid == 2084)
                {
                    sm.Token = "IT";

                    if (UMan.Ugid == 2084)
                    {
                        im.fkIssueToDeptID = UMan.Pkdeptid;
                    }
                    else
                    {
                        im.fkIssueToDeptID = 2;
                    }

                }
                if (UMan.Pkdeptid == 17)
                {
                    sm.Token = "SP";
                }


                sm.fkdeptID = im.fkIssueToDeptID; 
                cmbstoreto.DataSource = sm.GetStores();
                cmbstoreto.DataTextField = "StoreName";
                cmbstoreto.DataValueField = "pkStoreID";
                cmbstoreto.DataBind();
                cmbstoreto.SelectedValue = "1";
               // cmbstoreto.Enabled = false;

        }

        public void GetBranches()
        {
            int sysid = GetSysinfo();
            //int sysid = 1;

            DataSet db;
            if (UMan.Ugid == 28 || UMan.Ugid == 37 || UMan.Ugid == 2084)
            {
                db = im.GetBranches();
            }
            else
            {
                db = im.GetSysBranches(sysid);
            }
            cmbbranchfrom.DataSource = db.Tables[0];
            cmbbranchfrom.DataTextField = "brhName";
            cmbbranchfrom.DataValueField = "pkbrhID";
            cmbbranchfrom.DataBind();

            //cmbbranchfrom.SelectedValue = int.Parse(IMS["ubrhid"]).ToString();
        
        }

        public void LoadStores()
        {
               // sm.fkbrhID = int.Parse(cmbbranchfrom.SelectedValue.ToString());
                sm.Token = "SB";

                if (UMan.Pkdeptid == 10)
                {
                    sm.Token = "ITB";
                    sm.fkbrhID = 19;
                }
                else if (UMan.Pkdeptid == 17)
                {
                    sm.Token = "SP";
                    sm.fkbrhID = UMan.Ubrhid;
                }
                else
                {
                    sm.fkbrhID = int.Parse(cmbbranchfrom.SelectedValue.ToString());
                }

                DataTable dt = sm.GetStores();

                cmbstorefrom.DataSource = dt;
                cmbstorefrom.DataTextField = "StoreName";
                cmbstorefrom.DataValueField = "pkStoreID";
                cmbstorefrom.DataBind();
                cmbstorefrom.SelectedValue = "1";

               // Telerik.Web.UI.RadComboBoxItem s = new Telerik.Web.UI.RadComboBoxItem();
               // s.Text = "Choose Store";
               // s.Value = "Choose Store";
               // cmbstorefrom.Items.Add(s);
               //// cmbstorefrom.SelectedIndex = cmbstorefrom.Items.Count - 1;
               // cmbstorefrom.SelectedValue = "1";

               // cmbstorefrom.DataBind();
               //cmbstorefrom.Enabled = false;
               //cmbRecvStatus.Enabled = false;
        }

        public void GetDepartments()
        {
            cmbDept.DataSource = sm.GetDepartment(UMan.Uid);
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

        #endregion



        #region Events 
        
        protected void Page_Load(object sender, EventArgs e)
        {
            
            String ginno = Request.QueryString["ginno"];     //For Goods Issue Note
            
            if (Page.IsPostBack == false)
            {

                GetUserInfo();

                sm.fkbrhID = UMan.Ubrhid;
                iman.Uid = UMan.Uid;
                iman.Pkdeptid = UMan.Pkdeptid;
                //int.Parse(IMS["udptid"] == null ? "0" : IMS["udptid"]);


                UMan.GetUserInfo(iman.Uid);

                SetupForm();

                if (ginno != null)
                {
                    DashboardSubmit(ginno);
                }

                //if (ginno != null)
                //{

                //    if (ginno.Contains("HO-P") != null)
                //    {
                //        im.fkIssueByBranchID = 19;
                //        im.fkIssueByDeptID = 14;
                //        im.fkIssueByStoreID = 1;
                //    }
                //    else
                //    {
                //        cmbbranchfrom.SelectedValue = "19";
                //        cmbDept.SelectedValue = "10";
                //        cmbstorefrom.SelectedValue = "22";

                //    }
                //}
                //else
                //{
                //    GetRecvStore();

                //    GetRecvDepartment("14");

                //    cmbRecvStatus.SelectedValue = "2";
                //}

            }
            txtginno.Focus();
            
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

        protected void SetupGrid(DataTable GINTable)
        {
            cmbRecvStatus.Enabled = false;

            grdItems.DataSource = GINTable;
            grdItems.DataBind();
            grdItems.Visible = true;

            btnSave.Visible = true;

            ViewState["dtItems"] = GINTable;
          
            RadSlider1.Focus();

        }

        protected void btnSave_Click(object sender, EventArgs e)
        {

            DataTable dt = (DataTable)ViewState["dtItems"];

            if (dt.Rows.Count == 0)
                showMessageBox("Add Items first!!!!!");
            else
            {
                HttpCookie IMS = Request.Cookies["IMS"];
                if (IMS == null)
                    Response.Redirect("logout.aspx");

                sm.fkbrhID = int.Parse(IMS["ubrhid"]);
                im.fkdepartid = int.Parse(IMS["udptid"] == null ? "0" : IMS["udptid"]);
                im.CreatedBy = int.Parse(IMS["uid"]);
                im.receivedByID = int.Parse(IMS["uid"]);


                UserSettings();

                //im.dcdate = Convert.ToDateTime(rddcdate.Text).ToString("yyyy-MM-dd"); 

                im.fkIssueByBranchID = int.Parse(dt.Rows[0]["fkIssuebybranchId"].ToString());
                im.fkIssueByDeptID = int.Parse(dt.Rows[0]["fkIssuebyDeptId"].ToString());
                im.fkIssueByStoreID = int.Parse(dt.Rows[0]["fkIssuebystoreId"].ToString());

                im.fkIssueToBranchID = int.Parse(dt.Rows[0]["fkIssuetobranchId"].ToString());
                im.fkIssueToDeptID = int.Parse(dt.Rows[0]["fkIssueToDeptId"].ToString());
                im.fkIssueToStoreID = int.Parse(dt.Rows[0]["fkIssuetostoreId"].ToString()=="" ? "0" : dt.Rows[0]["fkIssuetostoreId"].ToString());

                im.fkbrhid = im.fkIssueToBranchID;
                im.fkstoreid = im.fkIssueToStoreID;
                im.fkdepartid = im.fkIssueToDeptID;

                
            //    im.fkIssueToBranchID = int.Parse(this.cmbbranchto.SelectedValue.ToString());

           //      

                // if (im.fkIssueByDeptID==14 && UMan.Ugid == 31 || UMan.Ugid == 32)
                //{
                //    im.fkIssueToDeptID = 14;
                //}
                //else
                //{
                //    im.fkIssueToDeptID = im.fkIssueToDeptID;
                //    im.fkIssueToStoreID = 0;
                //}
                
                //if (cmbstoreto.SelectedValue.ToString() != "")
                //{
                //    im.fkIssueToStoreID = int.Parse(cmbstoreto.SelectedValue.ToString());
                //}



                im.RecvStatus = cmbRecvStatus.SelectedValue;
                im.Token = "I";

                


                //string countryName = "USA";
                //DataTable dt = new DataTable();
                int ginackno = (from DataRow dr in dt.Rows select (int)dr["GINNumber"]).First();


               // int i = im.IUReceivedItemsGIN(dt);

                int i = im.IUReceivedItemsGIN(ginackno.ToString());


              //  im.ReceivedAcknowledge(ginackno);

              //  int i=im.RptSerial(im.fkIssueToBranchID, im.fkIssueToStoreID, im.fkIssueToDeptID, 4, im.RecvStatus);

                showMessageBox("Items Successfully Added Into Your Branch!!!!! with GRN Number : " + i.ToString());

                txtgrnno.Text = i.ToString();
               // btnPrint.Visible = true;


                //im.SendReportEmail(im.fkIssueToBranchID, im.fkIssueToStoreID, im.fkIssueToDeptID, 4, i);


               // im.SendReportEmail(im.fkIssueByBranchID, im.fkIssueByStoreID, im.fkIssueByDeptID, 4, i);

                SetupForm();

                btnSubmit.Enabled = false;
                cmbRecvStatus.Enabled = true;

                ViewState["dtItems"] = null;
                grdItems.DataSource = null;
                grdItems.DataBind();

            }



        }

        protected void btnPrint_Click(object sender, EventArgs e)
        {
            Response.Redirect("ReportsMain.aspx?rptname=GoodsReceiptNote&grno="+txtgrnno.Text);
        }

        protected void cmbRecvStatus_SelectedIndexChanged(object sender, Telerik.Web.UI.RadComboBoxSelectedIndexChangedEventArgs e)
        {

            btnSubmit.Enabled = true;
            im.RecvStatus = cmbRecvStatus.SelectedValue;
        }

        protected void btnClose_Click(object sender, EventArgs e)
        {
            ScriptManager.RegisterStartupScript(this, this.GetType(), "Close_Window", "self.close();", true);
        }

        protected void btnSubmit_Click(object sender, EventArgs e)
        {

            im.fkIssueByBranchID = int.Parse(this.cmbbranchfrom.SelectedValue.ToString());
            im.fkIssueByDeptID = int.Parse(cmbDept.SelectedValue.ToString());
            im.fkIssueByStoreID = int.Parse(cmbstorefrom.SelectedValue.ToString() == "" ? "0" : cmbstorefrom.SelectedValue.ToString());
            im.fkIssueToBranchID = int.Parse(this.cmbbranchto.SelectedValue.ToString());
            im.fkIssueToDeptID = int.Parse(cmbDeptto.SelectedValue.ToString() == "" ? im.fkdepartid.ToString() : cmbDeptto.SelectedValue.ToString());
            im.fkIssueToStoreID = int.Parse(cmbstoreto.SelectedValue.ToString());

            if (im.fkIssueByStoreID == 1 && im.fkIssueByDeptID == 14)
            {
                im.fkIssueToDeptID = 14;
            }


            string status = cmbRecvStatus.SelectedValue;

            int GinNo = int.Parse(txtginno.Text);

            

            DataTable GINData = im.GetItemsByGIN(status, GinNo);

            if (GINData.Rows.Count == 0)
            {
                showMessageBox("No Record Found For Your Branch of The GIN No: " + GinNo.ToString() + ", Or This GIN Is Not Confirmed as Yet!!!  Please Select Correct Parameters...");
            }
            else
            {
                SetupGrid(GINData);
            }
        }

        protected void DashboardSubmit(string gincode)
        {
            UMan.Ubrhid = UMan.Grpuserbrhid;
            UMan.Pkdeptid = UMan.Grpuserdeptid;
            UMan.PkstoreID = UMan.Grpuserstoreid;

            int codelength = (gincode.Length - 8);
            txtginno.Text = gincode.Substring(codelength, (gincode.Length - codelength));

            int GinNo = int.Parse(txtginno.Text);
            
            
            if (gincode.Contains("HO-P"))
            {
                im.fkIssueByBranchID = 25;
                im.fkIssueByDeptID = 14;
                im.fkIssueByStoreID = 1;
                
                GetUserInfo();

                im.fkIssueToBranchID=UMan.Ubrhid;
                im.fkIssueToDeptID =14;

                sm.fkbrhID = im.fkIssueToBranchID;
                sm.Token = "SB";
                sm.fkdeptID = im.fkIssueToDeptID; 
                cmbstoreto.DataSource = sm.GetStores();
                cmbstoreto.DataTextField = "StoreName";
                cmbstoreto.DataValueField = "pkStoreID";
                cmbstoreto.DataBind();

                if (im.fkIssueToBranchID == 19 && im.fkIssueByStoreID == 1)
                {
                    cmbstoreto.SelectedValue = "2";                    
                }
                else
                {
                    cmbstoreto.SelectedValue = "1";
                }
                cmbRecvStatus.SelectedValue = "P";
                im.fkIssueToStoreID = int.Parse(cmbstoreto.SelectedValue.ToString());

                GetRecvDepartment("14");

                GetDepartments();
                sm.Token = "SN";
                sm.fkbrhID = 1;
                sm.fkdeptID = im.fkIssueToDeptID; 
                cmbstorefrom.DataSource = sm.GetStores();
                cmbstorefrom.DataTextField = "StoreName";
                cmbstorefrom.DataValueField = "pkStoreID";
                cmbstorefrom.DataBind();

                cmbstorefrom.SelectedValue = "1";
                cmbDept.SelectedValue = "14";
                sm.fkbrhID = im.fkIssueToBranchID;
               //cmbDeptto.SelectedValue = "14";
               ////cmbDeptto.OpenDropDownOnLoad = true;
            }
            else
            {
              //  GetUserInfo();
                
                if (gincode.Contains("HO-IT"))
                {
                    im.fkIssueByBranchID = 19;
                    im.fkIssueByDeptID = 10;
                    im.fkIssueByStoreID = 22;

                    im.fkIssueToBranchID = UMan.Ubrhid;
                    im.fkIssueToDeptID = UMan.Pkdeptid;
                    im.fkIssueToStoreID = UMan.PkstoreID;

                    sm.fkbrhID = im.fkIssueByBranchID;
                    sm.fkdeptID = im.fkIssueToDeptID; 

                }
                else
                {
                    im.fkIssueToBranchID = UMan.Ubrhid;
                    im.fkIssueToDeptID = UMan.Pkdeptid;
                    sm.fkbrhID = im.fkIssueToBranchID;
                    sm.fkdeptID = im.fkIssueToDeptID; 
                }
                
                sm.Token = "SB";

                //cmbstoreto.Enabled = false;

                //cmbstorefrom.DataSource = sm.GetStores();
                //cmbstorefrom.DataTextField = "StoreName";
                //cmbstorefrom.DataValueField = "pkStoreID";
                //cmbstorefrom.DataBind();

                if (gincode.Contains("HO-IT"))
                {
                    cmbbranchfrom.SelectedValue = "19";
                   // GetDepartments();
                    cmbDept.SelectedValue = "10";
                    cmbstorefrom.SelectedValue = "22";

                    im.fkIssueToStoreID = UMan.PkstoreID;

                    GetRecvDepartment(UMan.Pkdeptid.ToString());
                }
                else
                {

                    //Issued Items from Branch Store to Another Branch Store



                    DataTable rcvDT = sm.GetBranchInfo(gincode,cmbstorefrom.SelectedValue.ToString());

                    if (rcvDT.Rows.Count==0)
                    {
                        rcvDT = sm.GetBranchGIN(gincode, cmbbranchto.SelectedValue.ToString());
                    }


                    im.fkIssueByBranchID = int.Parse(rcvDT.Rows[0]["fkIssuebybranchId"].ToString());
                    im.fkIssueByDeptID = int.Parse(rcvDT.Rows[0]["fkIssuebyDeptId"].ToString());
                    im.fkIssueByStoreID = int.Parse(rcvDT.Rows[0]["fkIssuebystoreId"].ToString());

                    im.fkIssueToBranchID = int.Parse(rcvDT.Rows[0]["fkIssuetobranchId"].ToString());
                    im.fkIssueToDeptID = int.Parse(rcvDT.Rows[0]["fkIssueToDeptId"].ToString());
                    im.fkIssueToStoreID = int.Parse(rcvDT.Rows[0]["fkIssuetostoreId"].ToString() == "" ? "0" : rcvDT.Rows[0]["fkIssuetostoreId"].ToString());

                    cmbbranchfrom.SelectedValue = im.fkIssueByBranchID.ToString();
                    cmbstorefrom.SelectedValue = im.fkIssueByStoreID.ToString();
                    cmbDept.SelectedValue = im.fkIssueByDeptID.ToString();

                    cmbbranchto.SelectedValue = im.fkIssueToBranchID.ToString();                    
                    cmbstoreto.SelectedValue = im.fkIssueToStoreID.ToString();
                    cmbDeptto.SelectedValue = im.fkIssueToDeptID.ToString();

                    cmbbranchfrom.Enabled = false;
                    cmbstorefrom.Enabled = false;
                    cmbDept.Enabled = false;

                    cmbbranchto.Enabled = false;
                    cmbstoreto.Enabled = false;
                    cmbDeptto.Enabled = false;

                    //GetDepartments();

                }

              

                //cmbDeptto.SelectedValue = UMan.Pkdeptid.ToString();
                //cmbDeptto.SelectedValue = "2";
                //cmbstoreto.DataSource = sm.GetStores();
                //cmbstoreto.DataTextField = "StoreName";
                //cmbstoreto.DataValueField = "pkStoreID";
                //cmbstoreto.DataBind();
                //cmbstoreto.SelectedValue = "1";



                cmbRecvStatus.SelectedValue = "P";
               


            }


            string status = "P";
            im.RecvStatus = status;

            //int codelength = (gincode.Length - 8);
            //txtginno.Text = gincode.Substring(codelength, (gincode.Length - codelength));

            //int GinNo = int.Parse(txtginno.Text);

            DataTable GINData = im.GetItemsByGIN(status, GinNo);

            if (GINData.Rows.Count == 0)
            {
                showMessageBox("No Record Found For Your Branch of The GIN No: " + GinNo.ToString() + ", Or This GIN Is Not Confirmed as Yet!!!  Please Select Correct Parameters...");
            }
            else
            {
                SetupGrid(GINData);
            }

        }

        protected void cmbbranchfrom_SelectedIndexChanged(object sender, Telerik.Web.UI.RadComboBoxSelectedIndexChangedEventArgs e)
        {
            //GetDepartments();
            //cmbDept.Enabled = true;

            //GetStores();
           
            //if (cmbbranchfrom.SelectedValue == "19" && cmbstorefrom.SelectedValue == "1" && cmbDept.SelectedValue == "14")
            //{
            //    cmbDeptto.SelectedValue = "14";
            //}

         //   UserSettings();

            btnSubmit.Enabled = true;


            if (UMan.Ugid == 28 || UMan.Ugid == 37 || UMan.Ugid == 2084 || UMan.Ugid == 79)
            {
                LoadStores();
            }
        }

     
        #endregion

    }
}