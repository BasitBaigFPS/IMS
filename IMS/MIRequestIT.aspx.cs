using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using BLL;
using System.Drawing;
using System.IO;
using System.Text;
using System.Data;
using System.Web.Mail;


namespace IMS
{
    public partial class MIRequestIT : System.Web.UI.Page
    {
        UserManager UMan = new UserManager();
        ItemManager im = new ItemManager();
        IMSManager iman = new IMSManager();

        DataTable di;
        DataTable storeDT;

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

            if (UMan.Ugid == 28 || UMan.Ugid == 30)
            { 
              //Response.Redirect("IssueMIR.aspx");
                Response.Redirect("IssueGINMIR.aspx");
            }


        }

        public void UserSettings()
        { 
            if (UMan.Ugid==31 || UMan.Ugid==32)
            {
                int sysid = GetSysinfo();
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

        public void GetStores(string type)
        {
            int brhid = int.Parse(UMan.Ubrhid.ToString());

            im.fkdepartid = UMan.Pkdeptid;

            if (UMan.Ugid == 30 || UMan.Ugid == 31 || UMan.Ugid == 32)
            {
                if (type == "I")
                {
                    cmbStore.DataSource = im.GetStores(brhid);
                    cmbStore.DataTextField = "StoreName";
                    cmbStore.DataValueField = "pkStoreID";
                    cmbStore.DataBind();
                }
                else
                {
                    im.fkdepartid = 14;
                    cmbStoreTo.DataSource = im.GetStores(int.Parse("25"));
                    cmbStoreTo.DataTextField = "StoreName";
                    cmbStoreTo.DataValueField = "pkStoreID";
                    cmbStoreTo.DataBind();
                    cmbStoreTo.SelectedValue = "1";
                }
            }
            else
            { 
                cmbStore.Items.Clear();
                Telerik.Web.UI.RadComboBoxItem s = new Telerik.Web.UI.RadComboBoxItem();
                s.Text = "Choose Store";
                s.Value = "Choose Store";
                cmbStore.Items.Add(s);
                cmbStore.SelectedIndex = cmbStore.Items.Count - 1;      
      
                cmbStoreTo.Items.Clear();
                Telerik.Web.UI.RadComboBoxItem st = new Telerik.Web.UI.RadComboBoxItem();
                st.Text = "Choose Store";
                st.Value = "Choose Store";
                cmbStoreTo.Items.Add(st);
                cmbStoreTo.SelectedIndex = cmbStoreTo.Items.Count - 1;   

            }
        }

        public void GetDepartment(string type)
        {

            if (type == "I")
            {               
                    DataSet ddf = im.GetDepartment(UMan.Uid);
                    cmbDepartment.DataSource = ddf.Tables[0];
                    cmbDepartment.DataTextField = "deptName";
                    cmbDepartment.DataValueField = "pkdeptID";
                    cmbDepartment.DataBind();

            }
            else
            {

                DataSet dd = im.GetDepartment(0);
                cmbDepartmentto.DataSource = dd.Tables[0];
                cmbDepartmentto.DataTextField = "deptName";
                cmbDepartmentto.DataValueField = "pkdeptID";
                cmbDepartmentto.DataBind();

                if (cmbStoreTo.SelectedValue == "1")
                {
                    cmbDepartment.SelectedValue = "14";
                    cmbDepartment.Enabled = false;

                    cmbDepartmentto.SelectedValue = "14";
                    cmbDepartmentto.Enabled = false;
                }
                else
                {
                    cmbDepartment.Enabled = true;
                    cmbDepartmentto.Enabled = true;
                }
            }
        }

        private void GetEmployee(string type)
        {
            
            if (type == "I")
            {
                //cmbDepartmentto.SelectedIndex = cmbDepartmentto.Items.Count - 2;
                //int.Parse(cmbDepartment.SelectedValue.ToString())

                im.fkIssueByID = UMan.Uid;

                DataSet de = im.GetEmployees(UMan.Ubrhid, UMan.Pkdeptid, type);

                if (de.Tables[0].Rows.Count > 0)
                {
                    cmbPerson.DataSource = de.Tables[0];
                    cmbPerson.DataTextField = "empName";
                    cmbPerson.DataValueField = "pkempID";
                    cmbPerson.DataBind();
                }
                else
                {
                    cmbPerson.Items.Clear();
                    Telerik.Web.UI.RadComboBoxItem ib = new Telerik.Web.UI.RadComboBoxItem();
                    ib.Text = "No Employees in Branch";
                    ib.Value = "No Employees in Branch";
                    cmbPerson.Items.Add(ib);
                    cmbPerson.SelectedIndex = cmbPerson.Items.Count - 1;
                }

            }
            else
            {

                DataSet de = im.GetEmpStore(int.Parse(cmbStoreTo.SelectedValue.ToString() == "Choose Store" ? "1" : cmbStoreTo.SelectedValue.ToString()), int.Parse(cmbDepartmentto.SelectedValue.ToString()), type);

                    if (de.Tables[0].Rows.Count > 0)
                    {
                        cmbIssuedto.DataSource = de.Tables[0];
                        cmbIssuedto.DataTextField = "empName";
                        cmbIssuedto.DataValueField = "pkempID";
                        cmbIssuedto.DataBind();
                    }
                    else
                    {
                        cmbIssuedto.Items.Clear();
                        Telerik.Web.UI.RadComboBoxItem ib = new Telerik.Web.UI.RadComboBoxItem();
                        ib.Text = "No Employees in Branch";
                        ib.Value = "No Employees in Branch";
                        cmbIssuedto.Items.Add(ib);
                        cmbIssuedto.SelectedIndex = cmbIssuedto.Items.Count - 1;                    
                    
                    }

                
            }
        }

        public void GetCategory()
        {
            cmbCatagories.DataSource = im.GetCategories();
            cmbCatagories.DataTextField = "CatTitle";
            cmbCatagories.DataValueField = "pkCatID";
            cmbCatagories.DataBind();
        }

        public void GetSubCategory(int catid)
        {
            im.CatID = catid;
            
            cmbSubCateg.DataSource = im.GetSubCategories();
            cmbSubCateg.DataTextField = "SubCatTitle";
            cmbSubCateg.DataValueField = "pkSubCatID";
            cmbSubCateg.DataBind();
        }

        public void GetItemHead(int subcatid)
        {
            im.SubCatID = subcatid;

            cmbItemHead.DataSource = im.GetItemHeads();
            cmbItemHead.DataTextField = "ItemHeadTitle";
            cmbItemHead.DataValueField = "pkItemHeadID";
            cmbItemHead.DataBind();

           // cmbItemHead.Items.Clear();
            Telerik.Web.UI.RadComboBoxItem h = new Telerik.Web.UI.RadComboBoxItem();
            h.Text = "Choose Item Head";
            h.Value = "Choose Item Head";
            cmbItemHead.Items.Add(h);
            cmbItemHead.SelectedIndex = cmbItemHead.Items.Count - 1;  


        }

        public void GetItems()
        {

            if (cmbItemHead.SelectedValue != "Choose Item Head")
            {

                DataTable di = im.GetAllItems("2", int.Parse(cmbItemHead.SelectedValue.ToString()));
                cmbItem.DataSource = di;
                cmbItem.DataTextField = "ItemTitle";
                cmbItem.DataValueField = "ItemCode";
                cmbItem.DataBind();


                Telerik.Web.UI.RadComboBoxItem it = new Telerik.Web.UI.RadComboBoxItem();
                it.Text = "Choose Item";
                it.Value = "Choose Item";
                cmbItem.Items.Add(it);
                cmbItem.SelectedIndex = cmbItem.Items.Count - 1;
            }

        }

        public void GetAllItems()
        {

            im.Token = "S";


            int deptfromid;
            int storeid;
            GetUserInfo();

            if (UMan.Ugid == 31 || UMan.Ugid == 32)
            {
                deptfromid = 14;
            }
            else
            {
                deptfromid = int.Parse(cmbDepartment.SelectedValue.ToString());

            }
            storeid = int.Parse(cmbStore.SelectedValue.ToString());
            if (deptfromid == 10)
            {
                storeid = 22;

            }



            DataTable di = im.GetAllItems(0);

            if (di.Rows.Count > 0)
            {
                cmbItem.Items.Clear();

                cmbItem.DataSource = di;
                cmbItem.DataTextField = "ItemTitle";
                cmbItem.DataValueField = "ItemCode";
                cmbItem.DataBind();
                cmbItem.Enabled = false;
                cmbItem.SelectedValue = cmbItemSearch.SelectedValue;

            }

        }

        public void SearchItems()
        {
           
                im.Token = "S";
             
                int deptfromid;
                int storeid;
                GetUserInfo();

                if (UMan.Ugid == 31 || UMan.Ugid == 32)
                {
                    deptfromid = 14;
                }
                else
                {
                    deptfromid = int.Parse(cmbDepartment.SelectedValue.ToString());

                }
                storeid = int.Parse(cmbStore.SelectedValue.ToString());
                if (deptfromid == 10)
                {
                    storeid = 22;

                }


                DataTable di = im.GetAllItems(0);

                if (di.Rows.Count > 0)
                {
                    cmbItemSearch.Items.Clear();

                    cmbItemSearch.DataSource = di;
                    cmbItemSearch.DataTextField = "ItemTitle";
                    cmbItemSearch.DataValueField = "ItemCode";
                    cmbItemSearch.DataBind();
                    cmbItemSearch.ItemsPerRequest = 20;

                    ViewState["di"] = di;

                    Telerik.Web.UI.RadComboBoxItem ib = new Telerik.Web.UI.RadComboBoxItem();
                    ib.Text = "Search Item";
                    ib.Value = "Search Item";
                    cmbItemSearch.Items.Insert(0,ib);
                    //cmbItemSearch.Items.Add(ib);
                    cmbItemSearch.SelectedIndex = 0;
                        //cmbItemSearch.Items.Count - 1;

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

        public void GetStoreItems()
        {
            int storeid = int.Parse(cmbStore.SelectedValue.ToString());
            storeDT = im.GetStoreInventory(storeid, 14);
             
        }

        public void ConfirmItemEntry()
        {
            
            if (Page.IsValid)
            {
                

                GetUserInfo();

                int brhid = UMan.Ubrhid;
                int storeid = int.Parse(cmbStore.SelectedValue.ToString());
                string itemcod = cmbItem.SelectedValue.ToString();

                DataTable dt1 = (DataTable)ViewState["dt"];

                DataTable dt = SetDataTable(dt1);

                DataTable ib = im.getItembalance(brhid, storeid, itemcod, "M");

                if (dt.Columns.Count == 0)
                {
                    dt.Columns.Add("Item Code", typeof(string));
                    dt.Columns.Add("Item Name", typeof(string));
                    dt.Columns.Add("Balance", typeof(int));
                    dt.Columns.Add("Qtty Request", typeof(int));

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

                        if (ib.Rows.Count > 0)
                        {
                            dr["Balance"] = int.Parse(ib.Rows[0]["CRBalance"].ToString() == "" ? "0" : ib.Rows[0]["CRBalance"].ToString());
                        }
                        else
                        {
                            dr["Balance"] = int.Parse("0");
                        }


                        dr["Qtty Request"] = 0;

                        dt.Rows.Add(dr);

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
                    dr["Balance"] = int.Parse("0");
                    dr["Qtty Request"] = 0;


                    //if (rdackdate.Text != "")
                    //    dr["Ackdate"] = rdackdate.Text.ToString();


                    dt.Rows.Add(dr);

                    cmbDepartmentto.Enabled = false;

                }

                ViewState["dt"] = dt;
                grdItems.DataSource = dt;
                grdItems.DataBind();

                grdItems.Visible = true;

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


            //Requestee Setups

            GetStores("I");

            //GetStoreItems();

            GetDepartment("I");

            GetEmployee("I");


            //Receiver Setups

            GetStores("R");

            GetDepartment("R");

            GetEmployee("S");


            GetCategory();

            rdackdate.Text = DateTime.Today.ToString("dd/MM/yyyy"); 

            UserSettings();
            btnGetItems.Visible = false;
            txtreqid.Visible = false;

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

        public bool checkItemBalance(DataTable dt, String InvCode, String DeptID, int balance, int qtyrequest)
        {
            bool returnval = false;

            //DataRow[] result = dt.Select("[Item Code] ='" + InvCode + "' AND [Issue to Department Id] =" + DeptID);

            DataRow[] result = dt.Select("[Item Code] ='" + InvCode + "'");

            int i = 0;

            foreach (DataRow row in result)
            {
               i = i + int.Parse(row["Qtty Request"].ToString());
            }

            //if (balance <= i)
           returnval = false;
            
            return returnval;
        }

        protected void showMessageBox(string message)
        {
            string sScript;
            message = message.Replace("'", "\'");
            sScript = String.Format("alert('{0}');", message);
            ScriptManager.RegisterStartupScript(this, this.GetType(), "alert", sScript, true);
        }

        private void sendEmail()
        {
            try
            {
                //string pBody = "ASA,<br>We would like to inform you that the following student has been mark withdrawal.";
                //pBody = pBody + "<br>Please acknowledge!<br>";
                //pBody = pBody + "<br>User Name: " + Request.Cookies["smsuser"]["ename"].ToString();
                //pBody = pBody + "<br><br>Branch Name: " + Request.Cookies["smsuser"]["ebrh"].ToString() + "<br><br>";
                //pBody = pBody + "Student Name   : " + studname + "<br>";
                //pBody = pBody + "Roll No: " + rno + "<br>";
                //pBody = pBody + "Grade  : " + grd + "<br>";
                //pBody = pBody + "Section: " + sec + "<br>";
                //pBody = pBody + "<br><br>Regards,<br>SMS 2.0 Development Team";
                //pBody = pBody + "<br>(This is a system generated email. Please do not reponsed directly to this email. This is for your information only)";


                //string pGmailEmail = "support@fps.edu.pk";
                //string pGmailPassword = "fpsfps";

                //MailMessage myMail = new MailMessage();

                //myMail.Fields.Add("http://schemas.microsoft.com/cdo/configuration/smtpauthenticate", 1);
                //myMail.Fields.Add("http://schemas.microsoft.com/cdo/configuration/smtpserver", "mail.fps.edu.pk");
                //myMail.Fields.Add("http://schemas.microsoft.com/cdo/configuration/smtpserverport", "25");
                //myMail.Fields.Add("http://schemas.microsoft.com/cdo/configuration/sendusing", "2");
                //myMail.Fields.Add("http://schemas.microsoft.com/cdo/configuration/sendusername", pGmailEmail);
                //myMail.Fields.Add("http://schemas.microsoft.com/cdo/configuration/sendpassword", pGmailPassword);
                //myMail.Fields.Add("http://schemas.microsoft.com/cdo/configuration/smtpusessl", "false");

                //myMail.From = "support@fps.edu.pk";
                //myMail.To = System.Configuration.ConfigurationManager.AppSettings.Get("billEmail");

                ////myMail.To = "basitbaig@fps.edu.pk";
                //myMail.Cc = Request.Cookies["smsuser"]["brhEmail"].ToString();
                //myMail.Bcc = "zahid.hussain@fps.edu.pk;basitbaig@fps.edu.pk";
                //myMail.Subject = "Student Withdrawal Info";
                //myMail.BodyFormat = MailFormat.Html;
                //myMail.Body = pBody;

                //SmtpMail.Send(myMail);

            }


            catch (Exception ex)
            {
                string errormsg = ex.Message;
                return;
            }

    }

        public int GetReqID(string ReqType)
        {
            GetUserInfo();
            return iman.GetReqID(UMan.Ubrhid, ReqType);
        
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

                if (storeDT==null)
                {
                    GetStoreItems();
                }

               // GetUserInfo();

                if (dt.Columns.Count == 0)
                {


                    dt.Columns.Add("Item Code", typeof(string));
                    dt.Columns.Add("Item Name", typeof(string));
                    dt.Columns.Add("Balance", typeof(Single));
                    dt.Columns.Add("Qtty Request", typeof(Single));

                }

                int tr = int.Parse(dt.Rows.Count.ToString());

                if (dt.Rows.Count > 0)
                {


                    DataRow dr = dt.NewRow();

                    dr["Item Code"] = itemcode;
                    dr["Item Name"] = itemname;

                    DataRow[] ItemRow = di.Select("[ItemCode] ='" + itemcode + "'");

                    DataRow[] ItemRow2 = storeDT.Select("[ItemCode] ='" + itemcode + "'");

                    if (ItemRow2.Length != 0)
                    {

                        dr["Balance"] = Single.Parse(ItemRow2[0]["Current Balance"].ToString() == "" ? "0" : ItemRow2[0]["Current Balance"].ToString());
                    }
                    //dr["Balance"] = Single.Parse(ItemRow[0]["Current Balance"].ToString() == "" ? "0" : ItemRow[0]["Current Balance"].ToString());
                    dr["Qtty Request"] = 0;

                    dt.Rows.Add(dr);



                }

                else
                {

                    DataRow dr = dt.NewRow();

                    dt.Rows.Add(dr);

                    dr["Item Code"] = itemcode;
                    dr["Item Name"] = itemname;

                    DataRow[] ItemRow = di.Select("[ItemCode] ='" + itemcode + "'");

                    DataRow[] ItemRow2 = storeDT.Select("[ItemCode] ='" + itemcode + "'");

                    if (ItemRow2.Length != 0)
                    {
                        dr["Balance"] = Single.Parse(ItemRow2[0]["Current Balance"].ToString() == "" ? "0" : ItemRow2[0]["Current Balance"].ToString());
                    }
                   // dr["Balance"] = Single.Parse(ItemRow[0]["Current Balance"].ToString() == "" ? "0" : ItemRow[0]["Current Balance"].ToString());
                    dr["Qtty Request"] = 0;

                    //dt.Rows.Add(dr);

                }

                if (dt.Rows.Count == listno)
                {
                    mirdiv.Style.Add("display", "inline");

                    ViewState["dt"] = SetDataTable(dt);
                    grdItems.DataSource = dt;
                    grdItems.DataBind();

                    grdItems.Visible = true;
                }
                //txtginno.Text = "6";
                //else
                //{
                //    ViewState["dt"] = SetDataTable(dt);
                //    grdItems.DataSource = dt;
                //    grdItems.DataBind();

                //    grdItems.Visible = true;


                //}

            }


        }

        private void ShowCheckedItems(Telerik.Web.UI.RadComboBox comboBox, Literal literal)
        {
            var sb = new StringBuilder();

            var collection = comboBox.CheckedItems;
 

            if (collection.Count != 0)
            {
                //sb.Append("<h3>Selected List:</h3><ul class=\"results\">");

                foreach (var item in collection)
                {
                    //sb.Append("<li>" + item.Text + "</li>");
                    //personid = personid + item.Value.TrimEnd() + ",";
                    //persons = persons + item.Text + ",";

                    if (literal == itemsClientSide)
                    {
                        ConfirmItemEntry(item.Value, item.Text, collection.Count);
                    }
                }
                //sb.Append("</ul>");

                literal.Text = sb.ToString();
            }
            else
            {
                literal.Text = "<p>No Item List selected</p>";

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

        protected void grdItems_RowCommand(object sender, GridViewCommandEventArgs e)
        {

            if (e.CommandName == "Delete")
            {
                int index = Convert.ToInt32(e.CommandArgument);
                DataTable dt = (DataTable)ViewState["dt"];

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
            

            //    dt.Rows[rowindex]["Qtty Request"] = int.Parse(thisTextBox.Text);
            //    ViewState["dt"] = dt;

            //    string isutodeptID =  cmbDepartmentto.SelectedValue.ToString();

            //    chkb = checkItemBalance(dt, dt.Rows[rowindex]["Item Code"].ToString(), isutodeptID, int.Parse(dt.Rows[rowindex]["Balance"].ToString()), int.Parse(thisTextBox.Text));

            //    if (chkb == false)
            //    {
            //        dt.Rows[rowindex]["Qtty Request"] = int.Parse(thisTextBox.Text);
            //        ViewState["dt"] = dt;
            //    }

        }

        protected void grdItems_RowUpdating(object sender, GridViewUpdateEventArgs e)
        {



        }

        protected void cmbCatagories_SelectedIndexChanged(object sender, Telerik.Web.UI.RadComboBoxSelectedIndexChangedEventArgs e)
        {
            GetSubCategory(int.Parse(cmbCatagories.SelectedValue.ToString()));
            GetItemHead(int.Parse(cmbSubCateg.SelectedValue.ToString())); 
        }

        protected void cmbSubCateg_SelectedIndexChanged(object sender, Telerik.Web.UI.RadComboBoxSelectedIndexChangedEventArgs e)
        {
            GetItemHead(int.Parse(cmbSubCateg.SelectedValue.ToString()));         
        }

        protected void cmbItemHead_SelectedIndexChanged(object sender, Telerik.Web.UI.RadComboBoxSelectedIndexChangedEventArgs e)
        {
            GetItems();
        }

        protected void btnOldMIR_Click(object sender, EventArgs e)
        {
             txtoldMIR.Visible = true;
        }

        protected void btnAddItem_Click(object sender, EventArgs e)
        {
            ShowCheckedItems(cmbItemSearch, itemsClientSide);
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

                    Label lblitem = (Label)GR.FindControl("lblItemID");
                    TextBox lblQty = (TextBox)GR.FindControl("txtqty");

                    double PCRatio = 0;
                    if (lblQty != null)
                    {
                        string itemid = lblitem.Text;
                        string qty = lblQty.Text;


                        PCRatio = Double.Parse(qty.ToString() == "" ? "0" : qty.ToString());

                        DataRow[] ItemRow = ds.Tables[0].Select("[Item Code] = '" + itemid + "'");

                        ItemRow[0]["Qtty Request"] = qty == "" ? "0" : qty;

                    }
                }

            }

            return ds.Tables[0];

        }

        protected void btnSubmit_Click(object sender, EventArgs e)
        {


            DataTable dt1 = (DataTable)ViewState["dt"];


            DataTable dt = SetDataTable(dt1);


            if (dt.Rows.Count == 0)
            {
                showMessageBox("Add Items first!!!!!");

            }
            else
            {

                GetUserInfo();

                im.OLDMIR = int.Parse(txtoldMIR.Text);

                if (im.OLDMIR == 0)
                {
                    im.Token = "I";
                }
                else
                {
                    im.Token = "A";
                }

                int get_MIRNo = 0;


                im.CreatedBy = UMan.Uid;
                im.fkIssueByBranchID = UMan.Ubrhid;
                im.fkIssueToBranchID = iman.GetBranchBYStore(int.Parse(cmbStoreTo.SelectedValue.ToString()));

                im.fkIssueByStoreID = int.Parse(cmbStore.SelectedValue.ToString());
                im.fkIssueToStoreID = int.Parse(cmbStoreTo.SelectedValue.ToString());

                if (im.fkIssueByStoreID == 0)
                {
                    im.fkIssueByDeptID = int.Parse(cmbDepartment.SelectedValue.ToString());
                }
                else
                {
                    im.fkIssueByDeptID = 14;
                }

               // im.fkIssueByDeptID = int.Parse(cmbDepartment.SelectedValue.ToString());
                im.fkIssueToDeptID = int.Parse(cmbDepartmentto.SelectedValue.ToString());

                im.fkIssueByID = UMan.Uid;
                im.fkIssuedToID = int.Parse(cmbIssuedto.SelectedValue.ToString());

                im.REQNumber = int.Parse(txtreqid.Text=="" ? "0" : txtreqid.Text);



                int i = im.IUMaterialIssueRequest(dt, ref get_MIRNo);

                showMessageBox("Record Saved, Your (MIR) Material Issuance Request Number Is : " + i.ToString());

                txtmirno.Text = i.ToString();


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


                im.SendReportEmail(im.fkIssueByBranchID, storeid, im.fkIssueByDeptID, 7, i);



               // Response.Redirect("ReportsMain.aspx?rptname=GoodsIssueNote&gino=" + txtginno.Text,false);

                //btnPrint_Click(sender, e);
                //btnPrintGatePass_Click(sender, e);

                SetupForm();

                ViewState["dt"] = null;
                grdItems.DataSource = null;
                grdItems.DataBind();


            }

        }

        protected void btnPrint_Click(object sender, EventArgs e)
        {
            string url = "ReportsMain.aspx?rptname=MaterialIssueRequest&mirno=" + txtmirno.Text;

            Response.Write("<script>" + "window.open(" + url + ",'_newtab')" + "</script>");
        }

        protected void btnSend_Click(object sender, EventArgs e)
        {
            // imsinfo@fps.edu.pk   = ims123info*
            // imssupport@fps.edu.pk = ims123supp*

            //sendEmail();

           showMessageBox("MIR Successfully Submited!");

       

           Response.Redirect("Main.aspx");

           //Sending MIR Generation Message to Main Store.
           Server.Transfer("http://221.132.117.58:7700/sendsms_url.html?Username=03028501537&Password=123.123&From=FPS-KHI&To=03343379794&Message=PLZ CHECK MIR");
        }

        protected void btnGetItems_Click(object sender, EventArgs e)
        {
            int reqid = int.Parse(txtreqid.Text);
            string reqtyp = rdoReqID.SelectedValue;

            DataTable dt = iman.GetReqItems(reqid, reqtyp);

            ViewState["dt"] = dt;
            grdItems.DataSource = dt;
            grdItems.DataBind();

            if (dt.Rows.Count == 0)
            {
                showMessageBox("Requisition Already Submitted To Main Store OR MIR/GIN Have Been Issued on This Requisition!");
                dt = null;
                ViewState["dt"] = null;
            }
            else
            {
                grdItems.Visible = true;
            }
        }

        protected void grdItems_RowDataBound(object sender, GridViewRowEventArgs e)
        {
            if (e.Row.RowType == DataControlRowType.DataRow)
            {
                TextBox txtqut = (TextBox)e.Row.FindControl("txtqty");
                txtqut.Enabled = false;

                txtqut.Attributes.Add("autocomplete", "off");

                if (rdoReqID.SelectedValue == "M")
                {
                    txtqut.Enabled = true;
                }
                // e.Row.Cells[5].Enabled = false;
            }
        }

        protected void rdoReqID_SelectedIndexChanged(object sender, EventArgs e)
        {
            
            if (rdoReqID.SelectedValue == "M")
            {
                DataTable dt = new DataTable();
                ViewState["dt"] = dt;

                grdItems.DataSource = dt;
                grdItems.DataBind();
                txtreqid.Text = "";
                btnGetItems.Visible = false;
                txtreqid.Visible = false;
                mirdiv.Style.Add("display", "inline");
                SearchItems();
            }
            else
            {
                mirdiv.Style.Add("display", "none");
                txtreqid.Text = GetReqID(rdoReqID.SelectedValue).ToString();
                btnGetItems.Visible = true;
                txtreqid.Visible = true;
                txtreqid.Enabled = true;
            }

        }

        protected void cmbStoreTo_SelectedIndexChanged(object sender, Telerik.Web.UI.RadComboBoxSelectedIndexChangedEventArgs e)
        {

        }

        protected void cmbDepartmentto_SelectedIndexChanged(object sender, Telerik.Web.UI.RadComboBoxSelectedIndexChangedEventArgs e)
        {

        }

        protected void cmbDepartment_SelectedIndexChanged(object sender, Telerik.Web.UI.RadComboBoxSelectedIndexChangedEventArgs e)
        {

        }

        protected void cmbStore_SelectedIndexChanged(object sender, Telerik.Web.UI.RadComboBoxSelectedIndexChangedEventArgs e)
        {

        }

        protected void cmbItemSearch_SelectedIndexChanged(object sender, Telerik.Web.UI.RadComboBoxSelectedIndexChangedEventArgs e)
        {
            GetAllItems();

            ConfirmItemEntry();
            //btnAddItem.Visible = true;
        }

        #endregion

    }
}