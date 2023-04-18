using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Configuration;
using System.Data.SqlClient;
using Telerik.Web.UI;
using System.Data;
using System.Text;
using System.Data.OleDb;
using BLL;

namespace IMS
{
    public partial class StoreInventoryBootstrap : System.Web.UI.Page
    {
        ItemManager im = new ItemManager();
        UserManager UMan = new UserManager();
        IMSManager iman = new IMSManager();
        StoreManager sm = new StoreManager();


        public string inventorycall;
       // DataTable DT;
        #region Events

        protected void Page_Load(object sender, EventArgs e)
        {
             
            //Page.Header.DataBind();  

            if (Page.IsPostBack == false)
            {
                CheckUser();

                //if (UMan.Ugid != 79 && UMan.Ugid != 27 && UMan.Ugid != 28 && UMan.Ugid != 29)
                //{

                    DashBoardManager dbm = new DashBoardManager();
                    dbm.fkbrhid = sm.fkbrhID;

                    List<string> MyList = dbm.GetUNRGinList();

                    var collection = MyList;

                    if (collection.Count != 0)
                    {
                        showMessageBox("You Have Pending GIN(s) at Your IMS Dashboard, No Transaction is Allowed Until All The Pending GIN Not Received!");
                       // ScriptManager.RegisterStartupScript(this, this.GetType(), "alert", "alert('You Have Pending GIN(s) at Your IMS Dashboard, No Transaction is Allowed Until All The Pending GIN Not Received!');window.location ='MainDashboard.aspx';", true);
                    }
               // }

                string groupstore = "27,28,29,30,31,32,39";

                string groupdepart = "34,37,38,79,2084";

                //bool grp1 = groupcode.Contains(UMan.Ugid.ToString());

                if (groupstore.Contains(UMan.Ugid.ToString()))
                {
                    inventorycall = "store";

                    GetInventory(int.Parse(cmbStores.SelectedValue.ToString()), int.Parse(cmbbranch.SelectedValue.ToString()));
                }

                if (groupdepart.Contains(UMan.Ugid.ToString()))
                {

                    inventorycall = "depart";
                    GetDeptInventory(iman.Pkdeptid, sm.fkbrhID);
                }
                

                //if (UMan.Ugid != 27 && UMan.Ugid != 29 && UMan.Ugid != 38 && UMan.Ugid != 39 && UMan.Ugid != 49 && UMan.Ugid != 79 && UMan.Ugid != 2084)
                //{                    
                //    GetInventory(int.Parse(cmbStores.SelectedValue.ToString()), int.Parse(cmbbranch.SelectedValue.ToString()));
                //}
                //else
                //{
                //    //GetInventory(int.Parse(cmbStores.SelectedValue.ToString()), int.Parse(cmbbranch.SelectedValue.ToString()));

                //    if (UMan.Ugid == 79)
                //    {
                //       // Response.Redirect("DeptInventoryFull.aspx");

                //        GetDeptInventory(iman.Pkdeptid, sm.fkbrhID);

                //    }
                //    else
                //    {
                //        GetDeptInventory(iman.Pkdeptid, sm.fkbrhID);
                //    }
                //}
            
            }
           
        }

        protected void showMessageBox(string message)
        {
            string sScript;
            message = message.Replace("'", "\'");
            sScript = String.Format("alert('{0}');", message);
            ScriptManager.RegisterStartupScript(this, this.GetType(), "alert", sScript, true);

        }
   



        protected void btnSubmit_Click(object sender, EventArgs e)
        {
            GetInventory(int.Parse(cmbStores.SelectedValue.ToString()), sm.fkbrhID);
        }


        #endregion




        #region Helper Methods


        public void CheckUser()
        {
            HttpCookie IMS = Request.Cookies["IMS"];
            if (IMS == null)
                Response.Redirect("logout.aspx");
            iman.Uid = int.Parse(IMS["uid"]);

            sm.fkbrhID = int.Parse(IMS["grpuserbrhid"]);
            sm.fkdeptID = int.Parse(IMS["grpuserdptid"]);
            sm.pkstoreID = int.Parse(IMS["grpuserstoreid"]);

            iman.Pkdeptid = int.Parse(IMS["grpuserdptid"]);
            iman.Pkbrhid = int.Parse(IMS["grpuserbrhid"]);
            iman.PkstoreID = int.Parse(IMS["grpuserstoreid"]);

 

            iman.Pkdeptid = int.Parse(IMS["udptid"] == null ? "0" : IMS["udptid"]);

            FillBranch(sm.fkbrhID);
        }


        public void FillBranch(int brhid)
        {
            //HttpCookie IMS = Request.Cookies["IMS"];
            //if (IMS == null)
            //    Response.Redirect("logout.aspx");
            //iman.Uid = int.Parse(IMS["uid"]);
            //sm.fkbrhID = int.Parse(IMS["ubrhid"]);

            UMan.GetUserInfo(iman.Uid);

            if (cmbbranch.Items.Count() < 2)
            {
                if (UMan.Ugid == 28 || UMan.Ugid == 30 || UMan.Ugid == 31 || UMan.Ugid == 32 || UMan.Ugid == 33 || UMan.Ugid == 34 || UMan.Ugid == 37 || UMan.Ugid == 38)
                {

                    if (UMan.Ugid == 37)
                    {

                        cmbbranch.DataSource = sm.GetBranches();
                        cmbbranch.DataTextField = "BrhName";
                        cmbbranch.DataValueField = "pkbrhID";
                        cmbbranch.DataBind();

                        cmbbranch.Enabled = true;
                        cmbStores.Enabled = true;
                    }
                    else
                    {
                        cmbbranch.DataSource = sm.GetBranches(sm.fkbrhID);
                        cmbbranch.DataTextField = "BrhName";
                        cmbbranch.DataValueField = "pkbrhID";
                        cmbbranch.DataBind();
                        
                        cmbbranch.Enabled = false;
                        cmbStores.Enabled = false;
                    }
                    if (UMan.Ugid != 38)
                    {
                        FillStore(sm.fkbrhID);
                    }
                }
                if (UMan.Ugid == 27 || UMan.Ugid == 29 || UMan.Ugid == 39 || UMan.Ugid == 49 || UMan.Ugid == 79)
                {
                    cmbbranch.DataSource = sm.GetBranches();
                    cmbbranch.DataTextField = "BrhName";
                    cmbbranch.DataValueField = "pkbrhID";
                    cmbbranch.DataBind();

                    cmbbranch.SelectedValue = sm.fkbrhID.ToString();

                   sm.fkbrhID = int.Parse(cmbbranch.SelectedValue.ToString());

                    FillStore(sm.fkbrhID);
                }

            }


        }

        public void FillStore(int brhid)
        {

            HttpCookie IMS = Request.Cookies["IMS"];
            if (IMS == null)
                Response.Redirect("logout.aspx");
            iman.Uid = int.Parse(IMS["uid"]);
            //sm.fkbrhID = int.Parse(IMS["grpuserbrhid"]);
            //sm.fkdeptID = int.Parse(IMS["grpuserdptid"]);
            //sm.pkstoreID = int.Parse(IMS["grpuserstoreid"]);

            UMan.Ugid = int.Parse(IMS["ugroupid"]);

          //  UMan.GetUserInfo(iman.Uid);

            if (UMan.Ugid == 28 || UMan.Ugid == 30 || UMan.Ugid == 31 || UMan.Ugid == 32 || UMan.Ugid == 33 || UMan.Ugid == 34)
            {
                sm.Token = "SB";
                //sm.fkdeptID = 14;
            }

            if (UMan.Ugid == 37)
            {
                sm.Token = "ITS";
                //sm.fkbrhID = brhid;
                //sm.fkdeptID = UMan.Pkdeptid; 
                //cmbbranch.SelectedValue = brhid.ToString();
            }
            else if (UMan.Ugid == 31 && brhid==19)
            {
                sm.Token = "HO";
                //sm.fkbrhID = brhid;
                //sm.fkdeptID = 14;
                //cmbbranch.SelectedValue = brhid.ToString();
            }
            else if (UMan.Ugid == 28 || UMan.Ugid == 30)
            {
                sm.Token = "SM";
                //sm.fkbrhID = brhid;
                //sm.fkdeptID = UMan.Pkdeptid; 
                //cmbbranch.SelectedValue = brhid.ToString();
            }
            else if (UMan.Ugid == 27 || UMan.Ugid == 29 || UMan.Ugid == 39 || UMan.Ugid == 49)                
            {
                sm.Token = "SB";
                //sm.fkbrhID = brhid;
                //sm.fkdeptID = UMan.Pkdeptid; 
                //cmbbranch.SelectedValue = brhid.ToString();
            }
            else if (UMan.Ugid == 79)
            {
                sm.Token = "SP";
                //sm.fkbrhID = brhid;
                //sm.fkdeptID = UMan.Pkdeptid;
                //cmbbranch.SelectedValue = brhid.ToString();
            }



            if (UMan.Pkdeptid == 14)
            {
                cmbStores.DataSource = new DataTable();
                cmbStores.DataSource = sm.GetStores();
                cmbStores.DataTextField = "StoreName";
                cmbStores.DataValueField = "pkStoreID";
                cmbStores.DataBind();

                cmbStores.SelectedIndex = 1;
            }
            else
            {
                cmbStores.DataSource = new DataTable();
                cmbStores.DataSource = sm.GetStores();
                cmbStores.DataTextField = "StoreName";
                cmbStores.DataValueField = "pkStoreID";
                cmbStores.DataBind();

                cmbStores.SelectedIndex = 0;
            }

        }


        public void FillCombo(int brhid)
        {
            HttpCookie IMS = Request.Cookies["IMS"];
            if (IMS == null)
                Response.Redirect("logout.aspx");
            iman.Uid = int.Parse(IMS["uid"]);
            sm.fkbrhID = int.Parse(IMS["grpuserbrhid"]);
            sm.fkdeptID = int.Parse(IMS["grpuserdptid"]);
            sm.pkstoreID = int.Parse(IMS["grpuserstoreid"]);
            UMan.Ugid = int.Parse(IMS["ugroupid"]);


            //UMan.GetUserInfo(iman.Uid);

            if (cmbbranch.SelectedValue.ToString() != sm.fkbrhID.ToString() && UMan.Ugid != 31)
            {
              sm.fkbrhID =brhid;
            }


            if (UMan.Ugid == 31 && sm.fkbrhID == brhid || UMan.Ugid == 32 && sm.fkbrhID == brhid || UMan.Ugid == 33 && sm.fkbrhID == brhid || UMan.Ugid == 39 && sm.fkbrhID == brhid)
            {
                sm.Token = "SB";
                if (cmbbranch.Items.Count() < 2)
                {

                    cmbbranch.DataSource = sm.GetBranches();
                    cmbbranch.DataTextField = "BrhName";
                    cmbbranch.DataValueField = "pkbrhID";
                    cmbbranch.DataBind();
                }

                
                cmbStores.DataSource = sm.GetStores();
                cmbStores.DataTextField = "StoreName";
                cmbStores.DataValueField = "pkStoreID";
                cmbStores.DataBind();

            }
            else
            {
                if (UMan.Ugid == 27 || UMan.Ugid == 29 || UMan.Ugid == 39)
                {
                    sm.fkbrhID = brhid;
                    sm.Token = "SB";
                    if (cmbbranch.Items.Count() < 2)
                    {
                        cmbbranch.DataSource = sm.GetBranches();
                        cmbbranch.DataTextField = "BrhName";
                        cmbbranch.DataValueField = "pkbrhID";
                        cmbbranch.DataBind();   
                    }
                     
                    //brhid = int.Parse(cmbbranch.SelectedValue.ToString());
                }
                else
                {
                    cmbbranch.DataSource = sm.GetBranches(brhid);
                    cmbbranch.DataTextField = "brhName";
                    cmbbranch.DataValueField = "pkbrhID";
                    cmbbranch.DataBind();
                }
                if (UMan.Ugid == 37)
                {
                    sm.Token = "ITS";
                }
                else if (UMan.Ugid == 31)
                {
                    sm.Token = "HO";
                }
                else if (UMan.Ugid == 28 || UMan.Ugid == 30)
                {
                    sm.Token = "SM";
                }

                sm.fkbrhID = brhid;
                cmbbranch.SelectedValue = brhid.ToString();
                cmbStores.DataSource = sm.GetStores();
                cmbStores.DataTextField = "StoreName";
                cmbStores.DataValueField = "pkStoreID";
                cmbStores.DataBind();


            }
            
            
            im.CatID = 0;
            im.Token = "C";
        }

         public int GetSysinfo()
        {
            HttpCookie IMS = Request.Cookies["IMS"];
            if (IMS == null)
                Response.Redirect("logout.aspx");
           

            int sysid = UMan.GetSysinfo(int.Parse(cmbbranch.SelectedValue.ToString()));

            return sysid;

        }

        public int GetSysID()
        { 
            
            int sysid;

            if (im.fkcatid == 1 || im.fkcatid == 2)
            {
                sysid = 4;
            }
            else
            {
                sysid = GetSysinfo();
            }

            return sysid;
        }




       
        public void GetInventory(int storeid, int brhid)
        {
         
            DataTable dt = new DataTable();

            HttpCookie IMS = Request.Cookies["IMS"];

            iman.Pkdeptid = int.Parse(IMS["grpuserdptid"]);

            //if (ViewState["inventory"] == null)
            //{
                
                if (brhid == 25 && storeid == 1 || brhid == 19 && storeid == 2 || brhid != 25 && storeid != 22 && storeid != 17)
                {
                    dt = im.GetFullStoreInventory(storeid, 14);
                }
                else if (storeid == 22 && brhid == 19)
                {
                    dt = im.GetFullStoreInventory(brhid, 10);
                }
                else if (iman.Pkdeptid == 14)
                {
                    dt = im.GetFullStoreInventory(storeid, iman.Pkdeptid);
                }
                else
                {
                    dt = im.GetFullStoreInventory(brhid, 2);
                }

                //ViewState["inventory"] = dt;
            //}
            //else
            //{
            //    dt = (DataTable)ViewState["inventory"];
            //}

            //    im.pksysID = GetSysID();
            //ReportsMain.aspx?rptname=ItemLedger&amp;INVCode={0}

            StringBuilder html = new StringBuilder();

            foreach (DataRow row in dt.Rows)
            {
                html.Append("<tr>");
                foreach (DataColumn column in dt.Columns)
                {                  
                    string colname = column.ColumnName.ToString();

                    // string doubleQuotedPath = string.Format(@"""{0}""", "StudentForm.aspx");
                    //ItemCode
                        //                    <th align="center">Inventory Code</th>
                        //<th align="center">ItemTitle</th>
                        //<th align="center">OPBalance</th>
                        //<th align="center">QttyReceived</th>
                        //<th align="center">QttyIssued</th>
                        //<th align="center">Current Balance</th>
                    //data-filter-control="select"
                    //
                    if (colname == "pkInvID")
                    {
                        html.Append("<td  padding-left: 0%; text-align: center;>");
                        html.Append("<input type='checkbox' value='" + row[column.ColumnName] + "' name='" + row[column.ColumnName] + "'/>");
                        html.Append("</td>");
                    }
                    else if (colname == "InventoryCode")
                    {

                        
                        html.Append("<td style='" + "align-text:center;font-family:" + "Courier New" + ", Courier; font-size:14px;width:175px; " + "'>");
                        string doubleQuotedPath = string.Format(@"""{0}""", "ReportsMain.aspx" + "?rptname=ItemLedger&amp;INVCode=" + row[column.ColumnName]);

                        html.Append("<a href=" + doubleQuotedPath + ">");
                        html.Append(row[column.ColumnName]);
                        html.Append("</a>");

                        html.Append("</td>");
                    }
                    else
                    {
                        if (colname != "fkItemID" && colname != "ItemCode" && colname != "ItemName" && colname != "ItemStatus" && colname != "Opening Balance Date" && colname != "OrderLimit")
                        {
                            html.Append("<td  padding-left: 0%; text-align: center;>");
                            html.Append(row[column.ColumnName]);
                            html.Append("</td>");
                        }
                    }                   
                }
                html.Append("</tr>");
            }

            //Table end.
            //html.Append("</table>");

            //Append the HTML string to Placeholder.
            PlaceHolder1.Controls.Add(new Literal { Text = html.ToString() });

        }

        public void GetDeptInventory(int deptid, int brhid)
        {

            if (UMan.Ugid == 37 || UMan.Ugid == 2084)
            {
                GetITInventory(deptid, brhid);
            }
            else
            {
                GetInventory(deptid, brhid);
            }

            cmbbranch.Enabled = false;
            cmbStores.Enabled = false;

            //grdStore.DataSource = im.GetDeptInventory(deptid, brhid, 0);
            //grdStore.DataBind();

        }

        public void GetITInventory(int deptid, int brhid)
        {

            DataTable dt = new DataTable();


            dt = im.GetDeptInventory(deptid, brhid, 8);
 
            StringBuilder html = new StringBuilder();

            foreach (DataRow row in dt.Rows)
            {
                html.Append("<tr>");
                foreach (DataColumn column in dt.Columns)
                {
                    string colname = column.ColumnName.ToString();

                    // string doubleQuotedPath = string.Format(@"""{0}""", "StudentForm.aspx");
                    //ItemCode
                    //                    <th align="center">Inventory Code</th>
                    //<th align="center">ItemTitle</th>
                    //<th align="center">OPBalance</th>
                    //<th align="center">QttyReceived</th>
                    //<th align="center">QttyIssued</th>
                    //<th align="center">Current Balance</th>
                    //data-filter-control="select"

                    if (colname == "InventoryCode")
                    {
                        html.Append("<td  padding-left: 0%; text-align: center;>");
                        html.Append("checkbox");
                        html.Append("</td>");

                        html.Append("<td style='" + "align-text:center;font-family:" + "Courier New" + ", Courier; font-size:14px;width:175px; " + "'>");
                        string doubleQuotedPath = string.Format(@"""{0}""", "ReportsMain.aspx" + "?rptname=ItemLedger&amp;INVCode=" + row[column.ColumnName]);

                        html.Append("<a href=" + doubleQuotedPath + ">");
                        html.Append(row[column.ColumnName]);
                        html.Append("</a>");

                        html.Append("</td>");
                    }
                    else
                    {
                        if (colname != "fkItemID" && colname != "ItemCode" && colname != "ItemName" && colname != "ItemStatus" && colname != "Opening Balance Date" && colname != "OrderLimit")
                        {
                            html.Append("<td  padding-left: 0%; text-align: center;>");
                            html.Append(row[column.ColumnName]);
                            html.Append("</td>");
                        }
                    }
                }
                html.Append("</tr>");
            }

            //Table end.
            //html.Append("</table>");

            //Append the HTML string to Placeholder.
            PlaceHolder1.Controls.Add(new Literal { Text = html.ToString() });



        }

        //public void GetGridFilter(int storeid, int brhid)
        //{
        //    if (brhid == 19 && storeid == 1 || brhid == 19 && storeid == 2 || brhid != 19 && storeid != 22)
        //    {
        //        grdStore.DataSource = im.GetFullStoreInventory(storeid, 14);
        //    }
        //    if (storeid == 22)
        //    {
        //        if (brhid == 19)
        //        {
        //            grdStore.DataSource = im.GetFullStoreInventory(storeid, 10);
        //        }
        //        else
        //        {
        //            grdStore.DataSource = im.GetDeptInventory(2,brhid, 0);

        //        }
        //    }

        //}


        //protected void grdStore_ItemCommand(object sender, Telerik.Web.UI.GridCommandEventArgs e)
        //{
        //    if (e.CommandName == Telerik.Web.UI.RadGrid.ExportToExcelCommandName ||
        //            e.CommandName == Telerik.Web.UI.RadGrid.ExportToWordCommandName ||
        //            e.CommandName == Telerik.Web.UI.RadGrid.ExportToPdfCommandName ||
        //            e.CommandName == Telerik.Web.UI.RadGrid.ExportToCsvCommandName)
        //    {


        //        grdStore.ExportSettings.IgnorePaging = true;
        //        grdStore.ExportSettings.OpenInNewWindow = true;
        //        if (e.CommandName == Telerik.Web.UI.RadGrid.ExportToExcelCommandName)
        //            grdStore.MasterTableView.ExportToExcel();
        //        else if (e.CommandName == Telerik.Web.UI.RadGrid.ExportToWordCommandName)
        //            grdStore.MasterTableView.ExportToWord();
        //        else if (e.CommandName == Telerik.Web.UI.RadGrid.ExportToCsvCommandName)
        //            grdStore.MasterTableView.ExportToCSV();
        //        else if (e.CommandName == Telerik.Web.UI.RadGrid.ExportToPdfCommandName)
        //            grdStore.MasterTableView.ExportToPdf();

        //    }
        //}

        //protected void cmdExportToExcel_OnClick(object sender, EventArgs e)
        //{
        //    grdStore.MasterTableView.ExportToExcel();
        //    Page.Response.ClearHeaders();
        //    Page.Response.ClearContent();
        //}

        public string getStoreData()
        {
            string data = "";
            //using (SqlConnection conn = new SqlConnection(connectionString))
            //{
                //using (SqlCommand cmd = new SqlCommand())
                //{
                    //cmd.Connection = conn;
                    //cmd.CommandType = CommandType.StoredProcedure;
                    //cmd.CommandText = "UspGetStudents";
                    //cmd.Connection.Open();

                    //DataTableReader reader = DT.CreateDataReader();

                  //  using (SqlDataReader sqlRdr = cmd.ExecuteReader())

                   DataTable dt = (DataTable)ViewState["dt"];


                   using (DataTableReader reader = dt.CreateDataReader())
                    {
                        // table = new DataTable();  
                        // table.Load(reader);  
                        //if (sqlRdr.HasRows)
                        //<td><a href="#">&nbsp;</a></td>
                        //<td style="cursor:pointer" onclick="location.href='mylink.html'"><a class="LN1 LN2 LN3 LN4 LN5" href="mylink.html" target="_top">link</a></td>
                        if (reader.HasRows)
                        {
                            while (reader.Read())
                            {
                                string invcode = reader.GetString(0);
                                string itemtitle = reader.GetString(1);
                                string opbalance = reader.GetDouble(2).ToString();
                                string received = reader.GetDouble(3).ToString();
                                string issued = reader.GetDouble(4).ToString();
                                string crbalance = reader.GetDouble(5).ToString();
                                data += "<tr><td>" + invcode + "</td><td>" + itemtitle + "</td><td>" + opbalance + "</td><td>" + received + "</td><td>" + issued + "</td><td>" + crbalance + "</td></tr>";
                                //data += "<tr><td style=" + "cursor:pointer" + "onclick=" + "location.href='" + "ReportsMain.aspx?rptname=ItemLedger&INVCode={0}'>" + "<a class=" + "LN1 LN2 LN3 LN4 LN5" + "href=" + "ReportsMain.aspx?rptname=ItemLedger&INVCode={0}" + "target=" + "_new">" + invcode + "</td><td>" + itemtitle + "</td><td>" + opbalance + "</td><td>" + received + "</td><td>" + issued + "</td><td>" + crbalance + "</td></tr>";  
                            }
                        }
                    }
               // }
                return data;
            //}
        }  




        #endregion

        //protected void cmbbranch_SelectedIndexChanged(object sender, RadComboBoxSelectedIndexChangedEventArgs e)
        //{
        //    FillCombo(int.Parse(cmbbranch.SelectedValue.ToString()));
        //}

        protected void cmbStores_SelectedIndexChanged(object sender, RadComboBoxSelectedIndexChangedEventArgs e)
        {
            GetInventory(int.Parse(cmbStores.SelectedValue.ToString()), int.Parse(cmbbranch.SelectedValue.ToString()));
        }


        protected void cmbbranch_SelectedIndexChanged(object sender, RadComboBoxSelectedIndexChangedEventArgs e)
        {
            sm.fkbrhID = int.Parse(cmbbranch.SelectedValue.ToString());

            cmbStores.Items.Clear();

            FillStore(sm.fkbrhID);

            //grdStore.DataSource = new DataTable();
            //grdStore.Rebind();

            if (cmbStores.SelectedValue.ToString() != "")
            {
                GetInventory(int.Parse(cmbStores.SelectedValue.ToString()), int.Parse(cmbbranch.SelectedValue.ToString()));
            }

        }

        //protected void grdStore_NeedDataSource(object sender, GridNeedDataSourceEventArgs e)
        //{
        //    GetGridFilter(int.Parse(cmbStores.SelectedValue.ToString() == "" ? "0" : cmbStores.SelectedValue.ToString()), int.Parse(cmbbranch.SelectedValue.ToString() == "" ? "0" : cmbbranch.SelectedValue.ToString()));
        //}

        protected void grdStore_ItemCommand1(object sender, GridCommandEventArgs e)
        {

        }

      
    }
}