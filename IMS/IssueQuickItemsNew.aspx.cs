using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Web.UI.HtmlControls;
using System.Configuration;
using System.Globalization;
using System.Data;
using System.Text;
using System.Drawing;
using System.Data.SqlClient;
using System.Data.OleDb;
using System.Web.Services;
using Telerik.Web.UI;
using BLL;
using DAL;
 

namespace IMS
{
    public partial class IssueQuickItemsNew : System.Web.UI.Page
    {
        UserManager UMan = new UserManager();
        ItemManager im = new ItemManager();
        IMSManager iman = new IMSManager();
        StoreManager sm = new StoreManager();
        RequisitionManager Reqman = new RequisitionManager();

        POManager POMan = new POManager();
        Boolean employeeselect;
      
        #region PageEvents

        protected void Page_Load(object sender, EventArgs e)
        {

            if (!IsPostBack)
            {
                //SetupForm();
            }
            else
            {
                employeeselect = false;
              
            }
        }

        protected void btnShowItems_Click(object sender, EventArgs e)
        {
            DataTable ItemList = new DataTable();

            btnShowItems.Enabled = false;

            lbldocumentref.Visible = true;

            lbldocumentref.InnerHtml = "Document Reference :";
       

            HttpCookie IMS = Request.Cookies["IMS"];

            UMan.Ugid = int.Parse(IMS["ugroupid"]);

            //if (UMan.Ugid != 27)
            //{
            //    GetUserInfo();
            //}

            UMan.Grpuserdeptid = int.Parse(IMS["grpuserdptid"]);
            UMan.Grpuserbrhid = int.Parse(IMS["grpuserbrhid"]);
            UMan.Grpuserstoreid = int.Parse(IMS["grpuserstoreid"]);

            iman.Pkbrhid = UMan.Grpuserbrhid ;
            iman.PkstoreID = UMan.Grpuserstoreid;
            iman.Pkdeptid = UMan.Grpuserdeptid;

            ViewState["usergroup"] = "invalid";

           // iman.PkstoreID = im.GetStore(iman.Pkbrhid);

            ItemList = im.GetInventoryList(iman.Pkbrhid, iman.PkstoreID, iman.Pkdeptid);

            if (ItemList.Rows.Count == 0)
            {
                showMessageBox("Inventory Record Is Not Available / You Are Not Authorized to Issue Items From Branch Inventory!!!");

                lbldocumentref.Visible = false;
            

                documentID.Value = "";
                lbldocumentref.InnerHtml = "";
            
            }
            else
            {
                
                int result;

                //Session.Add("ItemList", ItemList);

                    ViewState["ItemList"] = ItemList;

                    ViewState["usergroup"] = "valid";

                    result = SetupGrid(ItemList);

                    grdItems.Focus();
                    btnSubmit.Visible = true;
                    btnSubmit.Enabled = true;
                    btnBack.Enabled = true;

               
            }


            //foreach (DataRow row in ItemList.Rows)
            //{

            //    if (row["Remarks"].ToString() != "")
            //    {
            //        UpdateRemarks.Value = row["Remarks"].ToString();
            //    }
            //    if (row["CancelReason"].ToString() != "")
            //    {
            //        CancelRemarks.Value = row["CancelReason"].ToString();
            //    }
            //}

            UpdateRemarks.Value = "";
           


            //UpdateRemarks.Attributes.Add("required", "required");

            uremark.Visible = true;
            UpdateRemarks.Visible = true;

        }

        protected void txtqty_TextChanged(object sender, EventArgs e)
        {
            TextBox thisTextBox = (TextBox)sender;
            GridViewRow currentRow = (GridViewRow)thisTextBox.Parent.Parent;
            int rowindex = 0;
            rowindex = currentRow.RowIndex;

        }

        protected void grdItems_RowCommand(object sender, GridViewCommandEventArgs e)
        {
            string checkperm = (string)ViewState["usergroup"];

            if (checkperm == "invalid")
            {
                showMessageBox("No Operation is Allowed For This Document!!!");
                return;
            }

            if (e.CommandName == "Delete")
            {
                int index = Convert.ToInt32(e.CommandArgument);
                DataTable dt = (DataTable)ViewState["dt"];

                dt.Rows[index].Delete();
                dt.AcceptChanges();
                ViewState["dt"] = dt;
                grdItems.DataSource = dt;
                grdItems.DataBind();
            }

            if (e.CommandName == "Cancel")
            {
                                 
                int itemId = Convert.ToInt32(e.CommandArgument);
             
                DataTable dt = (DataTable)ViewState["dt"];

                DataRow[] ItemRow = dt.Select("fkItemID = '" + itemId + "'");

                ItemRow[0]["Qtty"] = "0";
                ItemRow[0]["IsCancel"] = "True";

                dt.AcceptChanges();
                ViewState["dt"] = dt;

                DataTable dtt = (DataTable)ViewState["dt"];

                grdItems.DataSource = dtt;
                grdItems.DataBind();

                ViewState["dt"] = dtt;
        

                

            }
 
        }

        protected void grdItems_RowDataBound(object sender, GridViewRowEventArgs e)
        {
            HttpCookie IMS = Request.Cookies["IMS"];
            iman.Pkbrhid = int.Parse(IMS["ubrhid"]);

            if (e.Row.RowType == DataControlRowType.DataRow)
            {
                //DropDownList ddlPersonto = (DropDownList)e.Row.FindControl("ddlPersonto");

                RadComboBox ddlPersonto = (RadComboBox)e.Row.FindControl("ddlPersonto");

                TextBox txtremarks = (TextBox)e.Row.FindControl("txtremarks");


                Label lblCurBal = (Label)e.Row.FindControl("lblcbalance");

                Single CurBal = Convert.ToSingle(lblCurBal.Text == "" ? "0" : lblCurBal.Text);

                TextBox txtqut = (TextBox)e.Row.FindControl("txtqty");

                Label lblNewBal = (Label)e.Row.FindControl("lblnewbalance");

                txtqut.Attributes.Add("onkeydown", "checkBackKey();");


                string trtyp = "ISU"; 

                string rowid = e.Row.RowIndex.ToString();


                txtqut.Attributes.Add("onkeydown", "return IsNumeric(event" + ",'" + rowid + "')");

                txtqut.Attributes.Add("onkeyup", "CalculateBalance('" + rowid + "','" + trtyp + "', " + CurBal + ",'" + txtqut.ClientID + "','" + lblNewBal.ClientID + "')");

                GridViewRow NextRow = e.Row;

                if (ddlPersonto.CheckedItems.Count > 0)
                {
                    var collection = ddlPersonto.CheckedItems;
                    string empid = "";
                    string empname = "";

                    if (collection.Count != 0)
                    {
                        foreach (var item in collection)
                        {
                            empid = empid + item.Value.TrimEnd() + ",";
                            empname = empname + item.Text + ",";
                        }
                        Label lblPerson = (Label)e.Row.FindControl("lblPerson");

                        lblPerson.Text = empname;
                        //txtremarks.Text = empname;
                    }
                }



                if (ddlPersonto.Items.Count == 0)
                {
                    if (chkchoise.Value == "INDV" && chkSingle.Checked == true)
                    {
                        ddlPersonto.Attributes.Add("visible", "true");
                        
                        string sql = "SELECT pkempID,empName FROM tblEmployees where fkbrhid=" + iman.Pkbrhid.ToString();

                        string conString = ConfigurationManager.ConnectionStrings["INVENTORY"].ConnectionString;

                        using (SqlConnection con = new SqlConnection(conString))
                        {
                            using (SqlDataAdapter sda = new SqlDataAdapter(sql, con))
                            {
                                using (DataTable dt = new DataTable())
                                {
                                    sda.Fill(dt);

                                    if (ddlPersonto != null)
                                    {
                                        ddlPersonto.DataSource = dt;
                                        ddlPersonto.DataTextField = "empName";
                                        ddlPersonto.DataValueField = "pkempID";
                                        ddlPersonto.DataBind();
                                        string selectedEmployee = DataBinder.Eval(e.Row.DataItem, "empName").ToString();
                                        if (selectedEmployee != "")
                                        {
                                            //ddlPersonto.Items.FindByValue(selectedEmployee).Selected = true;

                                            //ddlPersonto.Items.FindItemByValue(selectedEmployee).Selected = true;
                                        }
                                    }
                                }
                            }
                        }
                    }
                }

                if (chkchoise.Value == "BULK" && chkSingle.Checked == false)
                {
                    ddlPersonto.Attributes.Add("visible", "false");
                }


                //if (txtqut.Text == "0")
                //{
                //    e.Row.Attributes.CssStyle.Value = "background-color: DarkRed; color: White";
              
                //    CancelRemarks.Attributes.Add("required", "required");

                //    cremark.Visible = true;
                //    CancelRemarks.Visible = true;

                  
                //}
                //else
                //{
                //    e.Row.Attributes.CssStyle.Value = "background-color: White; color: Black";
                //    CancelRemarks.Attributes.Remove("required");         
                //}
            }

            if (e.Row.RowType == DataControlRowType.DataRow && grdItems.EditIndex == e.Row.RowIndex)
            {
                if (chkchoise.Value == "INDV" && chkSingle.Checked == true)
                {
                    DropDownList ddlEmployee = (DropDownList)e.Row.FindControl("ddlPersonto");
                    string sql = "SELECT pkempID,empName FROM tblEmployees where fkbrhid=" + iman.Pkbrhid.ToString();

                    string conString = ConfigurationManager.ConnectionStrings["INVENTORY"].ConnectionString;
                    using (SqlConnection con = new SqlConnection(conString))
                    {
                        using (SqlDataAdapter sda = new SqlDataAdapter(sql, con))
                        {
                            using (DataTable dt = new DataTable())
                            {
                                sda.Fill(dt);
                                ddlEmployee.DataSource = dt;
                                ddlEmployee.DataTextField = "empName";
                                ddlEmployee.DataValueField = "pkempID";
                                ddlEmployee.DataBind();
                                string selectedEmployee = DataBinder.Eval(e.Row.DataItem, "empName").ToString();
                                ddlEmployee.Items.FindByValue(selectedEmployee).Selected = true;
                            }
                        }
                    }
                }
            }
 

            //if (e.Row.Cells[8].Text.Equals("TextToMatch"))
            //{
            //    e.Row.Attributes.CssStyle.Value = "background-color: DarkRed; color: White";
            //}

        }

        protected void grdItems_SelectedIndexChanged(object sender, EventArgs e)
        {

        }

        protected void grdItems_Sorting(object sender, GridViewSortEventArgs e)
        {

        }

        protected void grdItems_RowUpdating(object sender, GridViewUpdateEventArgs e)
        {
            GridViewRow row = grdItems.Rows[e.RowIndex];
            //HiddenField hf_AdNo = row.FindControl("hfAdmissionNo") as HiddenField;
            //HiddenField hf_Sub = row.FindControl("hfSubjectID") as HiddenField;

            TextBox Marks = row.FindControl("txtqty") as TextBox;
            //con = new SqlDbConnect();
            //con.SqlQuery("Update tblSetMarks set Marks=@Marks where SubjectID= @SubId and AdmissionNo=@AdNo");
            //con.Cmd.Parameters.Add(new SqlParameter("@SubId", hf_Sub.Value));
            //con.Cmd.Parameters.Add(new SqlParameter("@AdNo", hf_AdNo.Value));
            //con.Cmd.Parameters.Add(new SqlParameter("@Marks", Marks.Text));
            //con.NonQueryEx();
            grdItems.EditIndex = -1;
            //this.BindGrid();



            //string city = (gvCustomers.Rows[e.RowIndex].FindControl("ddlCities") as DropDownList).SelectedItem.Value;
            //string customerId = gvCustomers.DataKeys[e.RowIndex].Value.ToString();
            //string conString = ConfigurationManager.ConnectionStrings["conString"].ConnectionString;
            //using (SqlConnection con = new SqlConnection(conString))
            //{
            //    string query = "UPDATE Customers SET City = @City WHERE CustomerId = @CustomerId";
            //    using (SqlCommand cmd = new SqlCommand(query, con))
            //    {
            //        cmd.Parameters.AddWithValue("@CustomerId", customerId);
            //        cmd.Parameters.AddWithValue("@City", city);
            //        con.Open();
            //        cmd.ExecuteNonQuery();
            //        con.Close();
            //        Response.Redirect(Request.Url.AbsoluteUri);
            //    }
            //}


        }

        protected void grdItems_RowUpdated(object sender, GridViewUpdatedEventArgs e)
        {
            e.KeepInEditMode = true;
            GridView GridView1 = (GridView)sender;
            int currRow = GridView1.SelectedRow.RowIndex;
            ((TextBox)grdItems.Rows[currRow].FindControl("txtqty")).Focus();
        }

        protected void grdItems_RowCreated(object sender, GridViewRowEventArgs e)
        {
            

            if (chkchoise.Value == "BULK" && chkSingle.Checked == false)
            {
                e.Row.Cells[8].Visible = false;
            }

        }

        protected void grdItems_RowDeleting(object sender, GridViewDeleteEventArgs e)
        {

        }

        protected void grdItems_RowEditing(object sender, GridViewEditEventArgs e)
        {
            grdItems.EditIndex = e.NewEditIndex;

            //DataTable dtt = (DataTable)ViewState["dt"];
            //grdItems.DataSource = SetDataTable(dtt);
        }

        private DataTable SetDataTable(DataTable FinalDT)
        {
            GridView GridView1 = (GridView)grdItems;

            //DataSet ds = new DataSet();
            //  ds.Tables.Add(FinalDT);

            foreach (GridViewRow GR in GridView1.Rows)
            {
                if (GR.RowType == DataControlRowType.DataRow)
                {
                    int rowid = GR.RowIndex;

                    Label lblitem = (Label)GR.FindControl("lblItemID");

                    Label lblCBal = (Label)GR.FindControl("lblcbalance");

                    TextBox lblQty = (TextBox)GR.FindControl("txtqty");

                    Label lblnewbal = (Label)GR.FindControl("lblnewbalance");

                    Label lblIsuToID = (Label)GR.FindControl("lblIssuedToID");

                    Label lblemployee = (Label)GR.FindControl("lblPerson");

                    TextBox TxtRema = (TextBox)GR.FindControl("txtremarks");

                    RadComboBox thisRadCombo = (RadComboBox)GR.FindControl("ddlPersonto");

                    var collection = thisRadCombo.CheckedItems;
                    string empid = "";
                    string empname = "";

                    if (collection.Count != 0)
                    {
                        foreach (var item in collection)
                        {
                            empid = empid + item.Value.TrimEnd() + ",";
                            empname = empname + item.Text + ",";
                        }

                        lblemployee.Text = empname;
                        lblIsuToID.Text = empid;
                    }

                    //double PCRatio = 0;
                    if (lblQty != null && lblQty.Text!="0")
                    {
                        string itemid = lblitem.Text;
                        string qty = lblQty.Text;

                        string isuid = lblIsuToID.Text == "" ? lblEmpID.Text : lblIsuToID.Text;
                        string emp = lblemployee.Text;
                        string rema = TxtRema.Text;

                        //PCRatio = Double.Parse(qty.ToString() == "" ? "0" : qty.ToString());
                        //DataRow[] ItemRow = ds.Tables[0].Select("Sno = '" + itemid + "'");

                        DataRow[] ItemRow = FinalDT.Select("fkitemID = '" + itemid + "'");

                        ItemRow[0]["Qtty"] = qty == "" ? "0" : qty;

                        string newbal = (float.Parse(lblCBal.Text) - float.Parse(qty)).ToString();

                        if (float.Parse(qty) > 0)
                        {
                            ItemRow[0]["NewBal"] = float.Parse(newbal);
                            ItemRow[0]["IsuToID"] = isuid;
                            ItemRow[0]["empName"] = emp;
                            ItemRow[0]["Remarks"] = rema;
                        }
                    }
                }

            }

            FinalDT.AcceptChanges();

            ViewState["LastItemList"] = FinalDT;

            ViewState["FirstItemList"] = FinalDT.Copy();

            DataTable FirstDT = new DataTable();

            FirstDT = ((DataTable)ViewState["FirstItemList"]).Copy();

            foreach (DataRow dtRow in FirstDT.Rows)
            {
                // On all tables' columns
                foreach (DataColumn dc in FirstDT.Columns)
                {
                   // var field1 = dtRow[dc].ToString();

                    if (dtRow["Qtty"].ToString() == "" || dtRow["Qtty"].ToString() == "0")
                    {
                        dtRow.Delete();

                        break;
                    }
                }
            }
            FirstDT.AcceptChanges();
            //return ds.Tables[0];
            return FirstDT;

        }

        protected void btnSubmit_Click(object sender, EventArgs e)
        {
            HttpCookie IMS = Request.Cookies["IMS"];
            if (IMS == null)
                Response.Redirect("logout.aspx");

            POMan.Pkdeptid = int.Parse(IMS["udptid"] == null ? "0" : IMS["udptid"]);
            POMan.Uid = int.Parse(IMS["uid"]);

            if (ViewState["CheckSave"]==null)
            {
                ViewState["CheckSave"] = "Save";
            }
            else
            {
                btnSubmit.Text = "Confirm Save";
            }

            if (btnSubmit.Text == "Save")
            {
               

                //SetBalances();
                DataTable dt1 = (DataTable)ViewState["ItemList"];

                DataTable dt = SetDataTable(dt1);

                grdItems.Visible = false;

                grdItems.DataSource = dt;
                grdItems.DataBind();
                grdItems.Visible = true;

                btnSubmit.Attributes.Add("onclick", "return ConfirmSave();");

                btnSubmit.Text = "Confirm Save";
                btnRevert.Enabled = true;

                ViewState["FinalItemList"] = dt;
            }
            else
            {
                btnSubmit.Visible = false;
                btnShowItems.Enabled = true;

                DataTable dt = (DataTable)ViewState["FinalItemList"];

                im.CreatedBy = int.Parse(IMS["uid"]);
                im.fkIssueByID = int.Parse(IMS["uid"]);
                im.fkstoreid = 0;
                im.fkIssuedToID = 0;
                im.IssuedStatus = "P";
                im.IssuedType = "I";
                im.Remarks = UpdateRemarks.Value;
                im.Token = "I";
                im.OLDGIN = 0;
                 
                            
                im.IUIssueItemInternal(dt);

                foreach (DataRow row in dt.Rows)
                {
                    im.fkbrhid = int.Parse(row["fkbrhid"].ToString());
                    im.fkstoreid = int.Parse(row["fkStoreID"].ToString());
                    im.fkdepartid = int.Parse(row["fkDeptID"].ToString());
                    break;
                }

                int serial = im.RptSerial(im.fkbrhid, im.fkstoreid, im.fkdepartid, 3, im.IssuedStatus);
                
                documentID.Value = serial.ToString();

                lbldocumentref.InnerText = "GIN Number : " + serial.ToString();

                showMessageBox("GIN Successfully Saved, Document ID : " + serial.ToString());
                ViewState["CheckSave"] = null;
               btnSubmit.Text = "Save";
               btnRevert.Enabled = false;
            }

 
        }

        protected void btnRevert_Click(object sender, EventArgs e)
        {
            DataTable RevertItemTable = ((DataTable)ViewState["LastItemList"]).Copy();

              SetupGrid(RevertItemTable);

             // Session["FirstItemList"] = null;

              btnSubmit.Text = "Save";
        }

        protected void btnBack_Click(object sender, EventArgs e)
        {
            Response.Redirect("Main.aspx");
        }

        protected void ChkAll_CheckedChanged(object sender, EventArgs e)
        {
            CheckBox chckheader = (CheckBox)grdItems.HeaderRow.FindControl("ChkAll");

            foreach (GridViewRow row in grdItems.Rows)
            {

                CheckBox chckrw = (CheckBox)row.FindControl("ChkRow");

                if (chckheader.Checked == true)
                {
                    chckrw.Checked = true;
                }
                else
                {
                    chckrw.Checked = false;
                }

            }
        }





        #endregion

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


            UMan.Uid = int.Parse(IMS["uid"]);
            UMan.Ugid = int.Parse(IMS["ugroupid"]);
            iman.Pkbrhid = int.Parse(IMS["ubrhid"]);
            iman.Pkdeptid = int.Parse(IMS["udptid"]);


            if (UMan.Ugid == 31 || UMan.Ugid == 32 || UMan.Ugid == 28)
            {
                iman.Pkdeptid = 14;
            }

        }

        private void SetupForm()
        {
            
            
            uremark.Visible = false;
            UpdateRemarks.Visible = false;
 

            DataTable dt = new DataTable();
            ViewState["dt"] = dt;

            btnShowItems.Enabled = false;

            btnSubmit.Visible = false;

            GetUserInfo();

       
           // txtDlvdate.Text = DateTime.Today.ToString("dd/MM/yyyy");
        }

        protected int SetupGrid(DataTable ItemTable)
        {
            int result = 0;

            DateTime DOCDate;
            DateTime CurDate = DateTime.Now;
           
            grdItems.DataSource = ItemTable;
            grdItems.DataBind();
            
            grdItems.Visible = true;

            return result;
        }

        public void SetBalances()
        {
            GridView GridView1 = (GridView)grdItems;

            DataTable wkDT = (DataTable)ViewState["dt"];

            //DataSet ds = new DataSet();
            //  ds.Tables.Add(FinalDT);

            if (wkDT==null)
            {
                return;
            }

            foreach (GridViewRow GR in GridView1.Rows)
            {
                if (GR.RowType == DataControlRowType.DataRow)
                {
                    int rowid = GR.RowIndex;

                    Label lblitem = (Label)GR.FindControl("lblItemID");

                    Label lblCBal = (Label)GR.FindControl("lblcbalance");
                    
                    TextBox lblQty = (TextBox)GR.FindControl("txtqty");

                    Label lblnewbal = (Label)GR.FindControl("lblnewbalance");

                    Label lblIsuToID = (Label)GR.FindControl("lblIssuedToID");

                    Label lblemployee = (Label)GR.FindControl("lblPerson");

                    TextBox TxtRema = (TextBox)GR.FindControl("txtremarks");


                    if (lblQty != null || lblQty.Text!="0")
                    {
                        string itemid = lblitem.Text;
                        string qty = lblQty.Text;
                        
                        string isuid = lblIsuToID.Text;
                        string emp = lblemployee.Text;
                        string rema = TxtRema.Text;

                        DataRow[] ItemRow = wkDT.Select("fkitemID = '" + itemid + "'");

                        ItemRow[0]["Qtty"] = qty == "" ? "0" : qty;

                        string newbal = (float.Parse(lblCBal.Text) - float.Parse(qty)).ToString();

                        if (float.Parse(qty) > 0)
                        {                           
                            ItemRow[0]["NewBal"] = newbal;
                            ItemRow[0]["IsuToID"] = isuid;
                            ItemRow[0]["empName"] = emp;
                            ItemRow[0]["Remarks"] = rema;
                        }
                    }
                }
                wkDT.AcceptChanges();

              
            }

            SetupGrid(wkDT);
        }


        #endregion

        protected void grdItems_RowCancelingEdit(object sender, GridViewCancelEditEventArgs e)
        {
            grdItems.EditIndex = -1; //swicth back to default mode

           // BindGridView(); // Rebind GridView to show the data in default mode
        }
  
        protected void ddlPersonto_ItemChecked(object sender, RadComboBoxItemEventArgs e)
        {

            RadComboBox thisRadCombo = (RadComboBox)sender;
            GridViewRow currentRow = (GridViewRow)thisRadCombo.Parent.Parent;
            GridView GridView1 = (GridView)thisRadCombo.Parent.Parent.Parent.Parent;

            int currRow = currentRow.RowIndex;

            //int currRow = GridView1.SelectedRow.RowIndex;
            ((TextBox)grdItems.Rows[currRow++].FindControl("txtremarks")).Focus();

            TextBox txtremarks = (TextBox)currentRow.FindControl("txtremarks");
            Label lblPerson = (Label)currentRow.FindControl("lblPerson");
            Label lblIssuedToID = (Label)currentRow.FindControl("lblIssuedToID");

            //string selectedEmployee = DataBinder.Eval(currentRow.DataItem, "empName").ToString();
     

            var collection = thisRadCombo.CheckedItems;
            string empid = "";
            string empname = "";

            if (collection.Count != 0)
            {
                foreach (var item in collection)
                {
                    empid = empid + item.Value.TrimEnd() + ",";
                    empname = empname + item.Text + ",";
                }

                lblPerson.Text = empname;
                lblIssuedToID.Text = empid;
                //txtremarks.Text = empname;
            }
         
        }
 
        protected void ddlEmployees_ItemChecked(object sender, RadComboBoxItemEventArgs e)
        {
             
            RadComboBox thisRadCombo = (RadComboBox)sender;

            Literal literal;

            var collection = thisRadCombo.CheckedItems;
            string empid = "";
            string empname = "";

            if (collection.Count != 0)
            {
                foreach (var item in collection)
                {
                    empid = empid + item.Value.TrimEnd() + ",";
                    empname = empname + item.Text + ",";
                }

                lblemployees.Text = empname;
                lblEmpID.Text = empid;
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

                    //if (literal == ItemsClientSide)
                    //{
                    //    ConfirmItemEntry(item.Value, item.Text, collection.Count);
                    //}
                }
                sb.Append("</ul>");
                employeeselect = true;
                literal.Text = sb.ToString();
                lblemployees.Text = persons;
                lblEmpID.Text = personid;

            }
            else
            {
                literal.Text = "<p>No List selected</p>";
                employeeselect = false;
                showMessageBox("No Employee Selected, Please Select Employee First!");
            }
        }

        protected void btnTrnType_Click(object sender, EventArgs e)
        {
            HttpCookie IMS = Request.Cookies["IMS"];
            iman.Pkbrhid = int.Parse(IMS["ubrhid"]);

            lbldocumentref.InnerHtml = "";

            if (chkchoise.Value == "BULK" && chkbulk.Checked==true)
            {

                btnShowItems.Attributes.Add("style", "display:none");
                btnShowEmpList.Visible = true;

                string sql = "SELECT pkempID,empName FROM tblEmployees where fkbrhid=" + iman.Pkbrhid.ToString() + " and Isactive=1 Order by empName";

                string conString = ConfigurationManager.ConnectionStrings["INVENTORY"].ConnectionString;

                using (SqlConnection con = new SqlConnection(conString))
                {
                    using (SqlDataAdapter sda = new SqlDataAdapter(sql, con))
                    {
                        using (DataTable dt = new DataTable())
                        {
                            sda.Fill(dt);

                            if (ddlEmployees != null)
                            {
                                ddlEmployees.DataSource = dt;
                                ddlEmployees.DataTextField = "empName";
                                ddlEmployees.DataValueField = "pkempID";
                                ddlEmployees.DataBind();                               
                            }
                        }
                    }
                }

             

                lblPersonlist.Visible = true;
                ddlEmployees.Visible = true;
                grdItems.Visible = false;
            }
            else
            {
                btnShowItems.Attributes.Add("style", "display:inline");
                btnShowEmpList.Visible = false;
                lblPersonlist.Visible = false;
                ddlEmployees.Visible = false;
                ItemsClientSide.Text = "";
                btnShowItems.Enabled = true;
                grdItems.Visible = false;
            }
        }

        protected void btnShowEmpList_Click(object sender, EventArgs e)
        {
            ShowCheckedItems(ddlEmployees, ItemsClientSide);

            if (employeeselect == true)
            {
                btnShowItems_Click(sender, e);
            }
            else
            {
                btnShowEmpList.Visible = true;
            }
        }

    }
 
}