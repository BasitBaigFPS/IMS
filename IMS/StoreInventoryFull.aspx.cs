﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Configuration;
using System.Data.SqlClient;
using Telerik.Web.UI;
using System.Data;  
using BLL;

namespace IMS
{
    public partial class StoreInventoryFull : System.Web.UI.Page
    {
        ItemManager im = new ItemManager();
        UserManager UMan = new UserManager();
        IMSManager iman = new IMSManager();
        StoreManager sm = new StoreManager();

       // DataTable DT;
        #region Events

        protected void Page_Load(object sender, EventArgs e)
        {

            //Page.Header.DataBind();  

            if (Page.IsPostBack == false)
            {

                CheckUser();

                if (UMan.Ugid != 27 && UMan.Ugid != 29 && UMan.Ugid != 38 && UMan.Ugid != 39 && UMan.Ugid != 49 && UMan.Ugid != 79)
                {
                    
                    GetInventory(int.Parse(cmbStores.SelectedValue.ToString()), int.Parse(cmbbranch.SelectedValue.ToString()));
                }
                else
                {
                    //GetInventory(int.Parse(cmbStores.SelectedValue.ToString()), int.Parse(cmbbranch.SelectedValue.ToString()));

                    if (UMan.Ugid == 79)
                    {
                        Response.Redirect("DeptInventoryFull.aspx");
                    }
                    else
                    {
                        GetDeptInventory(iman.Pkdeptid, sm.fkbrhID);
                    }
                }
            
            }
           
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
            sm.fkbrhID = int.Parse(IMS["ubrhid"]);

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
                if (UMan.Ugid == 27 || UMan.Ugid == 29 || UMan.Ugid == 39 || UMan.Ugid == 49)
                {
                    cmbbranch.DataSource = sm.GetBranches();
                    cmbbranch.DataTextField = "BrhName";
                    cmbbranch.DataValueField = "pkbrhID";
                    cmbbranch.DataBind();

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
            sm.fkbrhID = int.Parse(IMS["ubrhid"]);

            UMan.GetUserInfo(iman.Uid);

            if (UMan.Ugid == 28 || UMan.Ugid == 30 || UMan.Ugid == 31 || UMan.Ugid == 32 || UMan.Ugid == 33 || UMan.Ugid == 34)
            {
                sm.Token = "SB";
                sm.fkdeptID = 14;
            }

            if (UMan.Ugid == 37)
            {
                sm.Token = "ITS";
                sm.fkbrhID = brhid;
                sm.fkdeptID = UMan.Pkdeptid; 
                cmbbranch.SelectedValue = brhid.ToString();
            }
            else if (UMan.Ugid == 31 && brhid==19)
            {
                sm.Token = "HO";
                sm.fkbrhID = brhid;
                sm.fkdeptID = 14;
                cmbbranch.SelectedValue = brhid.ToString();
            }
            else if (UMan.Ugid == 28 || UMan.Ugid == 30)
            {
                sm.Token = "SM";
                sm.fkbrhID = brhid;
                sm.fkdeptID = UMan.Pkdeptid; 
                cmbbranch.SelectedValue = brhid.ToString();
            }
            else if (UMan.Ugid == 27 || UMan.Ugid == 29 || UMan.Ugid == 39 || UMan.Ugid == 49)                
            {
                sm.Token = "SB";
                sm.fkbrhID = brhid;
                sm.fkdeptID = UMan.Pkdeptid; 
                cmbbranch.SelectedValue = brhid.ToString();
            }

            cmbStores.DataSource = new DataTable(); 
            cmbStores.DataSource = sm.GetStores();
            cmbStores.DataTextField = "StoreName";
            cmbStores.DataValueField = "pkStoreID";
            cmbStores.DataBind();
             


        }


        public void FillCombo(int brhid)
        {
            HttpCookie IMS = Request.Cookies["IMS"];
            if (IMS == null)
                Response.Redirect("logout.aspx");
            iman.Uid = int.Parse(IMS["uid"]);
            sm.fkbrhID = int.Parse(IMS["ubrhid"]);

            UMan.GetUserInfo(iman.Uid);

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
   
            //    im.pksysID = GetSysID();

                if (brhid == 25 && storeid == 1 || brhid == 19 && storeid == 2 || brhid != 25 && storeid!=22)
                {
                    grdStore.DataSource = null;
                    grdStore.DataSource = im.GetFullStoreInventory(storeid, 14);

                   // DT = im.GetStoreInventory(storeid, 14);
                }
                else if (storeid == 22 && brhid==19)
                {

                    grdStore.DataSource = null;
                    grdStore.DataSource = im.GetFullStoreInventory(brhid, 10);

                   // DT = im.GetStoreInventory(storeid, 10);
                }
                else
                {
                    grdStore.DataSource = null;
                    grdStore.DataSource = im.GetFullStoreInventory(brhid, 2);

                }
               // ViewState["dt"] = DT;
              
              grdStore.DataBind();
              
           
        }

        public void GetDeptInventory(int deptid, int brhid)
        {


            grdStore.DataSource = im.GetDeptInventory(deptid, brhid, 0);
            grdStore.DataBind();

        }


        public void GetGridFilter(int storeid, int brhid)
        {
            if (brhid == 25 && storeid == 1 || brhid == 19 && storeid == 2 || brhid != 25 && storeid != 22)
            {
                grdStore.DataSource = im.GetFullStoreInventory(storeid, 14);
            }
            if (storeid == 22)
            {
                if (brhid == 19)
                {
                    grdStore.DataSource = im.GetFullStoreInventory(storeid, 10);
                }
                else
                {
                    grdStore.DataSource = im.GetDeptInventory(2,brhid, 0);

                }
            }

        }


        protected void grdStore_ItemCommand(object sender, Telerik.Web.UI.GridCommandEventArgs e)
        {
            if (e.CommandName == Telerik.Web.UI.RadGrid.ExportToExcelCommandName ||
                    e.CommandName == Telerik.Web.UI.RadGrid.ExportToWordCommandName ||
                    e.CommandName == Telerik.Web.UI.RadGrid.ExportToPdfCommandName ||
                    e.CommandName == Telerik.Web.UI.RadGrid.ExportToCsvCommandName)
            {


                grdStore.ExportSettings.IgnorePaging = true;
                grdStore.ExportSettings.OpenInNewWindow = true;
                if (e.CommandName == Telerik.Web.UI.RadGrid.ExportToExcelCommandName)
                    grdStore.MasterTableView.ExportToExcel();
                else if (e.CommandName == Telerik.Web.UI.RadGrid.ExportToWordCommandName)
                    grdStore.MasterTableView.ExportToWord();
                else if (e.CommandName == Telerik.Web.UI.RadGrid.ExportToCsvCommandName)
                    grdStore.MasterTableView.ExportToCSV();
                else if (e.CommandName == Telerik.Web.UI.RadGrid.ExportToPdfCommandName)
                    grdStore.MasterTableView.ExportToPdf();

            }
        }

        protected void cmdExportToExcel_OnClick(object sender, EventArgs e)
        {
            grdStore.MasterTableView.ExportToExcel();
            Page.Response.ClearHeaders();
            Page.Response.ClearContent();
        }

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

            grdStore.DataSource = new DataTable();
            grdStore.Rebind();

            GetInventory(int.Parse(cmbStores.SelectedValue.ToString()), int.Parse(cmbbranch.SelectedValue.ToString()));
        }

        protected void grdStore_NeedDataSource(object sender, GridNeedDataSourceEventArgs e)
        {
            GetGridFilter(int.Parse(cmbStores.SelectedValue.ToString() == "" ? "0" : cmbStores.SelectedValue.ToString()), int.Parse(cmbbranch.SelectedValue.ToString() == "" ? "0" : cmbbranch.SelectedValue.ToString()));
        }

        protected void grdStore_ItemCommand1(object sender, GridCommandEventArgs e)
        {

        }

    }
}