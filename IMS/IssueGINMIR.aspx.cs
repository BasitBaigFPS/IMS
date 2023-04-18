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
    public partial class IssueGINMIR : System.Web.UI.Page
    {
        UserManager UMan = new UserManager();
        ItemManager im = new ItemManager();
        StoreManager sm = new StoreManager();
        VendorManager vm = new VendorManager();
        IMSManager iman = new IMSManager();

        DataTable MIRDT;

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
            UMan.Grpuserbrhid = int.Parse(IMS["grpuserbrhid"]);
            UMan.Grpuserdeptid = int.Parse(IMS["grpuserdptid"]);
            UMan.Grpuserstoreid = int.Parse(IMS["grpuserstoreid"]);

        }


        public void UserSettings()
        {
            GetUserInfo();

            //if (UMan.Ugid==28 || UMan.Ugid==30)
            //{
            //    //int sysid = GetSysinfo();
            //    //cmbbranchto.SelectedValue = "19";
            //    //cmbDeptto.SelectedValue = "14";
            //    //cmbstoreto.SelectedValue = "1";

            im.fkIssueToBranchID = UMan.Ubrhid;
            im.fkIssueToDeptID = UMan.Pkdeptid;
            im.fkIssueToStoreID = UMan.PkstoreID;

            //}
        }


        public void SetupForm()
        {
            
            DataTable dt = new DataTable();
            ViewState["dt"] = dt;            
            
            GetUserInfo();

            im.CreatedBy = iman.Uid;

           
            im.CreatedBy = iman.Uid;

            UserSettings();

            LoadMIRData();

            btnCloseMIR.Visible = false;

        }

        protected void LoadMIRData()
        {
            MIRDT = im.GetBranchMIR();

            if (MIRDT.Rows.Count != 0)
            {
                ViewState["mirdt"] = MIRDT;
                grdmir.DataSource = MIRDT;
                grdmir.DataBind();
                grdmir.Visible = true;
                

                RadSlider1.Focus();
            }
            else
            {
                grdmir.Visible = true;
                grdmir.Caption = "No New MIR Received";
                
            }

        
        }


        public int GetSysinfo(int brhid)
        {
            int sysid = UMan.GetSysinfo(brhid);

            return sysid;

            //GetItemCategory(int itemid)
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
                if (Single.Parse(MIRTable.Rows[rowindex]["CRBalance"].ToString()) >= Single.Parse(MIRTable.Rows[rowindex]["Qtty"].ToString()))
                {
                    MIRTable.Rows[rowindex]["QtyIssue"] = MIRTable.Rows[rowindex]["Qtty"];

                    //Single.Parse(MIRTable.Rows[rowindex]["QttyIssued"].ToString()) != Single.Parse(MIRTable.Rows[rowindex]["Qtty"].ToString()) &&
                    if (MIRTable.Rows[rowindex]["Balance"].ToString() != string.Empty )
                    {
                        MIRTable.Rows[rowindex]["QtyIssue"] = MIRTable.Rows[rowindex]["Balance"];
                    }
                    
                }
                else
                {
                    MIRTable.Rows[rowindex]["QtyIssue"] = MIRTable.Rows[rowindex]["CRBalance"];
                }


                rowindex++;
            }

            MIRTable.DataSet.AcceptChanges(); 
            MIRTable.DefaultView.Sort = "Sno";
            MIRTable.DefaultView.ApplyDefaultSort = true;

            ViewState["dt"] = MIRTable;

            

            Session["TaskTable"] = MIRTable;

            

            //Session["TaskTable"];

            grdItems.DataSource = MIRTable;
            grdItems.DataBind();
            
            grdItems.Visible = true;

            btnSave.Visible = true;

            
          
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

                DashBoardManager dbm = new DashBoardManager();
                dbm.fkbrhid = sm.fkbrhID;

                List<string> MyList = dbm.GetUNRGinList();

                var collection = MyList;

                if (collection.Count != 0)
                {
                    ScriptManager.RegisterStartupScript(this, this.GetType(), "alert", "alert('You Have Pending GIN(s) at Your IMS Dashboard, No Transaction is Allowed Until All The Pending GIN Not Received!');window.location ='MainDashboard.aspx';", true);
                }


                UMan.GetUserInfo(iman.Uid);
                
                SetupForm();
            }
            txtmirno.Focus();
            
        }


        public void GetSystem()
        {
            cmbSystem.DataSource = iman.GetSystem();
            cmbSystem.DataTextField = "SystemName";
            cmbSystem.DataValueField = "pksysID";
            cmbSystem.DataBind();
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

        protected void grdItems_RowDataBound(object sender, GridViewRowEventArgs e)
        {

            if (e.Row.RowType == DataControlRowType.DataRow)
            {

                TextBox txtqut = (TextBox)e.Row.FindControl("txtqty");

                txtqut.Attributes.Add("onkeydown", "checkBackKey();");
            }
        }


        protected void grdItems_Sorting(object sender, GridViewSortEventArgs e)
        {

        }

        protected void txtqty_TextChanged(object sender, EventArgs e)
        {

            TextBox thisTextBox = (TextBox)sender;
            GridViewRow currentRow = (GridViewRow)thisTextBox.Parent.Parent;
            int rowindex = 0;
            rowindex = currentRow.RowIndex;

            GridView testgrid = (GridView)thisTextBox.Parent.Parent.Parent.Parent;

            testgrid.SelectedIndex = rowindex;
            
            GridViewRow row = testgrid.SelectedRow;

            string itemcode = row.Cells[1].Text;
            string itemname = row.Cells[2].Text;
            string qttyavlb = row.Cells[6].Text;

          // DataTable dt = (DataTable)ViewState["dt"];

           DataTable dt = Session["TaskTable"] as DataTable;

            bool chkb = false;

            float crbal = float.Parse(qttyavlb.ToString());

            string txtboxval = thisTextBox.Text.Trim() == "" ? "0" : thisTextBox.Text.Trim();

            if (float.Parse(txtboxval) <= float.Parse(qttyavlb))
            {
                DataRow[] foundRows;
                foundRows = dt.Select("fkItemID=" + int.Parse(itemcode));

                int qttyisu = (int)foundRows[0]["QtyIssue", DataRowVersion.Default];

                foreach (DataRow dr in foundRows)
                {
                    rowindex =  dr.Table.Rows.IndexOf(dr);
                }


                dt.Rows[rowindex]["QtyIssue"] = float.Parse(thisTextBox.Text.Trim() == "" ? "0" : thisTextBox.Text.Trim());

                dt.AcceptChanges();


                chkb = checkItemBalance(dt, dt.Rows[rowindex]["ItemCode"].ToString(), int.Parse(dt.Rows[rowindex]["fkIssueToStoreID"].ToString()), float.Parse(dt.Rows[rowindex]["CRBalance"].ToString()), float.Parse(thisTextBox.Text.Trim()));

                if (chkb == false)
                {
                    dt.Rows[rowindex]["QtyIssue"] = float.Parse(thisTextBox.Text.Trim());
                    ViewState["dt"] = dt;
                }

                else
                {
                    thisTextBox.Text = "0";
                    showMessageBox("Please Enter Qty Less than Or Equal To The Current Balance");
                }

            }

            else
            {
                //thisTextBox.Text = dt.Rows[rowindex]["CRBalance"].ToString();
                thisTextBox.Text = qttyavlb.ToString();

                showMessageBox("Please Enter Qty Less than Or Equal To The Current Balance");
            }


        }

        public bool checkItemBalance(DataTable dt, String InvCode, int Storeid, Single balance, Single qtyissue)
        {
            bool returnval = false;

            DataRow[] result = dt.Select("[ItemCode] ='" + InvCode + "' AND [fkIssueToStoreID] =" + Storeid);

            //DataRow[] result = dt.Select("[InvCode] ='" + InvCode + "'");

            Single i = 0;

            foreach (DataRow row in result)
            {
                i = i + Single.Parse(row["QtyIssue"].ToString());
            }

            if (balance < i)
                returnval = true;

            return returnval;
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

        private DataTable SetDataTable(DataTable FinalDT)
        {
            GridView GridView1 = (GridView)grdItems;

            DataSet ds = new DataSet();
          //  ds.Tables.Add(FinalDT);

            foreach (GridViewRow GR in GridView1.Rows)
            {

                if (GR.RowType == DataControlRowType.DataRow)
                {
                    int rowid = GR.RowIndex;

                    Label lblsno = (Label)GR.FindControl("lblserial");
                    TextBox lblQty = (TextBox)GR.FindControl("txtqty");

                    double PCRatio = 0;
                    if (lblQty != null)
                    {
                        string itemid = lblsno.Text;
                        string qty = lblQty.Text;


                        PCRatio = Double.Parse(qty.ToString() == "" ? "0" : qty.ToString());

                        //DataRow[] ItemRow = ds.Tables[0].Select("Sno = '" + itemid + "'");

                        DataRow[] ItemRow = FinalDT.Select("Sno = '" + itemid + "'");

                        ItemRow[0]["Qtty"] = qty == "" ? "0" : qty;

                    }
                }

            }

            //return ds.Tables[0];
            return FinalDT;

        }

        protected void btnSave_Click(object sender, EventArgs e)
        {
            HttpCookie IMS = Request.Cookies["IMS"];
            //if (IMS == null)
            //    Response.Redirect("logout.aspx");


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


            DataTable dt1 = (DataTable)ViewState["dt"];

            DataTable dt = SetDataTable(dt1);


            int i = im.IUIssueItemMIR(dt, ref get_GINNo, ref get_GPNo);

            showMessageBox("Items Successfully Posted Into GIN Number : " + i.ToString());


            txtginno.Text = i.ToString();
            txtgpno.Text = get_GPNo.ToString();


            int storeid = im.GetStore(im.fkIssueByBranchID);

            if (UMan.Ugid==28)
            {
                storeid = 1;
            }


            if (im.fkIssueByDeptID == 10)
            {
                storeid = 22;
            }
            if (im.fkbrhid==19 && UMan.Ugid==31)
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
            //Response.Redirect("Main.aspx");
            ScriptManager.RegisterStartupScript(this, this.GetType(), "Close_Window", "self.close();", true);
        }

        protected void grdmir_RowCommand(object sender, GridViewCommandEventArgs e)
        {


            if (e.CommandName == "MIRCode")
            {
                txtmirno.Text = (string)e.CommandArgument;

                LinkButton lnkBtn = (LinkButton)e.CommandSource;    // the button 
                GridViewRow myRow = (GridViewRow)lnkBtn.Parent.Parent;  // the row 

                txtmirno.Text = grdmir.DataKeys[myRow.RowIndex].Value.ToString();

                ViewState["MIR"] = txtmirno.Text;

                string mir = (string)ViewState["MIR"];

                btnCloseMIR.Attributes.Add("onclick", "return Confirm('" + mir + "');");

                btnCloseMIR.Visible = true;

                int MirNo = LoadMirData();

                //GetSystem();
                string checkho = mir.Substring(4, 2);

                string systag = mir.Substring(0, 3);

                int brhid = im.fkIssueByBranchID;

                if (systag == "FPS" || systag == "HSS")
                {
                    im.pksysID = iman.GetBranchSystemID(brhid);
                }
                else
                {
                    im.pksysID = 4;
                }

                if (checkho == "HO")
                {
                    cmbSystem.Visible = true;
                    GetSystem();
                }
                else
                {
                    cmbSystem.Visible = false;
                }

                DataTable MIRData = im.GetItemsByMIR(MirNo);

                

                if (MIRData.Rows.Count == 0)
                {
                    showMessageBox("No Record Found For Your Branch of This MIR No: " + MirNo.ToString() + ", Or This MIR Already Received!!!  Please Select Correct Parameters...");
                }
                else
                {
                    //cmbSystem.Focus();
                    Page.SetFocus(RadSlider1.ClientID);
                    SetupGrid(MIRData);
                }
            }

        }

        public Int32 LoadMirData()
        {
            MIRDT = (DataTable)ViewState["mirdt"];

            string searchExpression = "MIRCode = '" + txtmirno.Text + "'";
            DataRow[] foundRows = MIRDT.Select(searchExpression);
            bool result;
            int f_brhid;
            int f_deptid;
            int f_storid;
            int t_brhid;
            int t_deptid;
            int t_storid;
            int MirNo = 0;
            foreach (DataRow dr in foundRows)
            {
                result = Int32.TryParse(dr["MIRNumber"].ToString(), out MirNo);
                result = Int32.TryParse(dr["branchID"].ToString(), out f_brhid);
                result = Int32.TryParse(dr["DeptID"].ToString(), out f_deptid);
                result = Int32.TryParse(dr["StoreID"].ToString(), out f_storid);
                result = Int32.TryParse(dr["TobranchID"].ToString(), out t_brhid);
                result = Int32.TryParse(dr["ToDeptID"].ToString(), out t_deptid);
                result = Int32.TryParse(dr["ToStoreID"].ToString(), out t_storid);


                im.fkIssueByBranchID = f_brhid;
                im.fkIssueByDeptID = f_deptid;
                im.fkIssueByStoreID = f_storid;

                im.fkIssueToBranchID = t_brhid;
                im.fkIssueToDeptID = t_deptid;
                im.fkIssueToStoreID = t_storid;

            }

            return MirNo;
        }

        protected void grdmir_PageIndexChanging(object sender, GridViewPageEventArgs e)
        {

            MIRDT = (DataTable)ViewState["mirdt"];

            grdmir.DataSource = MIRDT;
            grdmir.DataBind();

            grdmir.PageIndex = e.NewPageIndex;
            grdmir.DataBind();

        }

        #endregion

        protected void btnCloseMIR_Click(object sender, EventArgs e)
        {
          
            string mirno = (string)ViewState["MIR"];
 
            im.CloseMIR(mirno);

            showMessageBox("Successfully Closed The MIR Number : " + mirno);

            SetupForm();

            ViewState["dt"] = null;
            grdItems.DataSource = null;
            grdItems.DataBind();

        }

        protected void cmbSystem_SelectedIndexChanged(object sender, Telerik.Web.UI.RadComboBoxSelectedIndexChangedEventArgs e)
        {
            im.pksysID = int.Parse(cmbSystem.SelectedValue.ToString());

           // int mymirno = int.Parse(txtmirno.Text.Substring(txtmirno.Text.Length - 8, 8));

            int MirNo = LoadMirData();


            im.fkIssueByBranchID = im.fkIssueByBranchID;
            im.fkIssueByDeptID = im.fkIssueByDeptID;
            im.fkIssueByStoreID = im.fkIssueByStoreID;

            im.fkIssueToBranchID = im.fkIssueToBranchID;
            im.fkIssueToDeptID = im.fkIssueToDeptID;
            im.fkIssueToStoreID = im.fkIssueToStoreID;




            DataTable MIRData = im.GetItemsByMIR(MirNo);

            if (MIRData.Rows.Count == 0)
            {
                showMessageBox("No Record Found For Your Branch of This MIR No: " + txtmirno.ToString() + ", Or This MIR Already Received!!!  Please Select Correct Parameters...");
            }
            else
            {
                SetupGrid(MIRData);
            }


        }

        protected void grdItems_SelectedIndexChanged(object sender, EventArgs e)
        {

        }

        
 
    }
}