using System;
using System.Collections;
using System.Configuration;
using System.Data;
using System.Linq;
using System.Web;
using System.Web.Security;
using System.Web.UI;
using System.Web.UI.HtmlControls;
using System.Web.UI.WebControls;
using System.Web.UI.WebControls.WebParts;
using System.Xml.Linq;
using System.Data.SqlClient;
using System.Collections.Generic;
using System.Drawing;
using System.IO;
using System.Text;
using Telerik.Web.UI;
using System.Globalization;
using BLL;
using DAL;
 

namespace IMS
{
    public partial class ReceivedNew : System.Web.UI.Page
    {
        UserManager UMan = new UserManager();
        ItemManager im = new ItemManager();
        StoreManager sm = new StoreManager();
        VendorManager vm = new VendorManager();
        IMSManager iman = new IMSManager();

        protected void Page_Load(object sender, EventArgs e)
        {

            if (!IsPostBack)
            {
                SetupForm();

                lblvend.Visible = false;
                lblbranch.Visible = false;
                chkvnd.Visible = false;
                chkbranch.Visible = false;

                btnSubmit.Enabled = false;
                btnShowItemList.Visible = false;

             
            }
            else
            {
                //string podate = txtPODate.Value;

            }
        }


        protected void btnTrnType_Click(object sender, EventArgs e)
        {

        }


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
            iman.Pkbrhid = int.Parse(IMS["ubrhid"]);
            iman.Pkdeptid = int.Parse(IMS["udptid"]);
            UMan.Ugid = int.Parse(IMS["ugroupid"]);

            iman.Sysid = IMS["sysid"];

            iman.Pkcomid = int.Parse(IMS["comid"]);

        }

        private string GetGroup(int groupid)
        {
            SqlConnection conn = new SqlConnection();
            SqlCommand cmd = new SqlCommand();

            conn.ConnectionString = SqlHelper.connectionstring;
            cmd.Connection = conn;

            string grpname = "";
            string sql = "SELECT pkgid, IMSUSERGROUP FROM [INVENTORY].[dbo].[tblGroups]";

            try
            {
                SqlDataReader dr = SqlHelper.ExecuteReader(conn, CommandType.Text, sql);

                while (dr.Read())
                {
                    grpname = dr["IMSUSERGROUP"].ToString();
                }
            }
            finally
            {
                conn.Close();
            }
            return grpname;
        }

        private void SetupForm()
        {

            GetUserInfo();

            DataTable ItemList = new DataTable();

            HttpCookie IMS = Request.Cookies["IMS"];
            UMan.Ugid = int.Parse(IMS["ugroupid"]);

            string group = GetGroup(UMan.Ugid);

            //int.Parse(IMS["ugroupid"]);

          //  ItemList = iman.GetItems();

            if (ItemList.Rows.Count == 0)
            {
                showMessageBox("Record Is Not Available For This Document!!!");
            }
            else
            {
                ViewState["dt"] = ItemList;
                SetupGrid(ItemList);

                //btnShowItemList.Text = "Save Monthly Report";
                lblvndbrh.Visible = false;
                lblvend.Visible = false;
                lbldepart.Visible = false;
                ddlDepartment.Visible = false;
                ddlvendor.Visible = false;
            }


        }

        private void PopulateVendor()
        {
            SqlConnection conn = new SqlConnection();
            SqlCommand cmd = new SqlCommand();

            conn.ConnectionString = SqlHelper.connectionstring;
            cmd.Connection = conn;

            DataSet ds;

            ds = SqlHelper.ExecuteDataset(conn, CommandType.Text, "SELECT pkVendID,VendorName,CPName1 FROM tblVendors where IsActive=1 and fkVendTypID=130 order by VendorName");

            DataTable dt = ds.Tables[0];

            ddlvendor.CausesValidation = false;
            ddlvendor.DataSource = dt;
            ddlvendor.DataTextField = "VendorName";
            ddlvendor.DataValueField = "pkVendID";
            ddlvendor.DataBind();
            ddlvendor.Items.Insert(0, new ListItem("==Please Select==", "0"));

            conn.Close();

        }

        private void PopulateBranch()
        {
            SqlConnection conn = new SqlConnection();
            SqlCommand cmd = new SqlCommand();

            conn.ConnectionString = SqlHelper.connectionstring;
            cmd.Connection = conn;

            DataSet ds;

            ds = SqlHelper.ExecuteDataset(conn, CommandType.Text, "SELECT pkbrhid as pkVendID,brhname as VendorName FROM tblBranches where brhisactive=1 order by brhname");

            DataTable dt = ds.Tables[0];

            ddlvendor.CausesValidation = false;
            ddlvendor.DataSource = dt;
            ddlvendor.DataTextField = "VendorName";
            ddlvendor.DataValueField = "pkVendID";
            ddlvendor.DataBind();
            ddlvendor.Items.Insert(0, new ListItem("==Please Select==", "0"));

            conn.Close();

            PopulateDepartment();
        }

        private void PopulateDepartment()
        {
            SqlConnection conn = new SqlConnection();
            SqlCommand cmd = new SqlCommand();

            conn.ConnectionString = SqlHelper.connectionstring;
            cmd.Connection = conn;

            DataSet ds;

            ds = SqlHelper.ExecuteDataset(conn, CommandType.Text, "SELECT pkdeptID,deptName FROM tblDepartments WHERE deptIsActive=1 order by deptName");

            DataTable dt = ds.Tables[0];


            ddlDepartment.CausesValidation = false;
            ddlDepartment.DataSource = dt;
            ddlDepartment.DataTextField = "deptName";
            ddlDepartment.DataValueField = "pkdeptID";
            ddlDepartment.DataBind();
            ddlDepartment.Items.Insert(0, new ListItem("==Please Select==", "0"));

            conn.Close();

        }

        private void PopulateItems(string usergroup)
        {
            SqlConnection conn = new SqlConnection();
            SqlCommand cmd = new SqlCommand();

            conn.ConnectionString = SqlHelper.connectionstring;
            cmd.Connection = conn;

            DataSet ds;

            string sql = "";

            if (usergroup == "ST-USER")
            {
                sql = "SELECT pkItemID,ItemTitle FROM tblItems where fkCatID in (1,2,3,4,5) order by ItemTitle";
            }
            if (usergroup == "GR-USER")
            {
                sql = "SELECT pkItemID,ItemTitle FROM tblItems where fkCatID in (6,7,10,13,14,15,16,17) order by ItemTitle";
            }
            if (usergroup == "IT-USER")
            {
                sql = "SELECT pkItemID,ItemTitle FROM tblItems where fkCatID in (8) order by ItemTitle";
            }
            if (usergroup == "SP-USER")
            {
                sql = "SELECT pkItemID,ItemTitle FROM tblItems where fkCatID in (9) order by ItemTitle";
            }
            if (usergroup == "LB-USER")
            {
                sql = "SELECT pkItemID,ItemTitle FROM tblItems where fkCatID in (11) order by ItemTitle";
            }
            if (usergroup == "RPT-USER")
            {
                sql = "SELECT pkItemID,ItemTitle FROM tblItems where fkCatID in (1,2,3,4,5,8,9) order by ItemTitle";
            }
            if (usergroup == "ADMIN")
            {
                sql = "SELECT pkItemID,ItemTitle FROM tblItems where fkCatID not null order by ItemTitle";
            }

            ds = SqlHelper.ExecuteDataset(conn, CommandType.Text, sql);

            DataTable dt = ds.Tables[0];

            //ddItems.CausesValidation = false;
            //ddItems.DataSource = dt;
            //ddItems.DataTextField = "ItemTitle";
            //ddItems.DataValueField = "pkItemID";
            //ddItems.DataBind();
            //ddItems.Items.Insert(0, new ListItem("==Please Select==", "0"));

            conn.Close();

        }

        protected void SetupGrid(DataTable ItemTable)
        {

            grdItems.Visible = false;

            grdItems.DataSource = ItemTable;
            grdItems.DataBind();

            ViewState["dt"] = ItemTable;

            grdItems.Visible = true;



        }

        private DataTable SetDataTable(DataTable FinalDT)
        {
            GridView GridView1 = (GridView)grdItems;

            DataSet ds = new DataSet();

            foreach (GridViewRow GR in GridView1.Rows)
            {
                if (GR.RowType == DataControlRowType.DataRow)
                {
                    int rowid = GR.RowIndex;

                    Label lblitem = (Label)GR.FindControl("lblItemID");
                    TextBox lblQty = (TextBox)GR.FindControl("txtqty");
                    TextBox txtrema = (TextBox)GR.FindControl("txtremarks");

                    if (lblQty != null)
                    {
                        string itemid = lblitem.Text;
                        string qty = lblQty.Text;
                        string rema = txtrema.Text.TrimEnd() == "" ? null : txtrema.Text.TrimEnd();

                        DataRow[] ItemRow = FinalDT.Select("fkitemID = '" + itemid + "'");

                        ItemRow[0]["Qtty"] = qty == "" ? "0" : qty;

                        if (float.Parse(qty) > 0)
                        {
                            ItemRow[0]["Remarks"] = rema;
                        }

                    }
                }

            }

            //return ds.Tables[0];
            return FinalDT;

        }

        public bool checkItemBalance(DataTable dt, String InvCode, int Itemid, Single balance, Single qtyissue)
        {
            bool returnval = false;

            DataRow[] result = dt.Select("[InvCode] ='" + InvCode + "' AND [fkitemid] =" + Itemid);

            Single i = 0;

            foreach (DataRow row in result)
            {
                i = i + Single.Parse(row["Qtty"].ToString());
            }

            if (i <= balance)
                returnval = true;

            return returnval;
        }

        private DataTable RemoveZeroQtty(DataTable dt)
        {

            for (int i = dt.Rows.Count - 1; i >= 0; i--)
            {
                DataRow dr = dt.Rows[i];
                if (dr["QTTY"].ToString() == "0")
                    dr.Delete();
            }

            return dt;

        }


        public void UserSettings()
        {

            //if (UMan.Ugid == 31 || UMan.Ugid == 32)
            //{
            //    int sysid = GetSysinfo();
            //    cmbSystem.SelectedValue = sysid.ToString();
            //    cmbSystem.Enabled = false;
            //}

            //if (UMan.Uid == 94)
            //{
            //    cmbSystem.SelectedValue = "4";
            //    cmbSystem.DataBind();
            //    cmbSystem.Enabled = false;
            //}


            //if (UMan.Ugid == 37)
            //{

            //    cmbSystem.SelectedValue = "4";
            //    cmbSystem.DataBind();

            //    cmbDept.SelectedValue = "10";
            //    cmbDept.DataBind();

            //    cmbstorefrom.SelectedValue = "22";
            //    cmbstorefrom.DataBind();

            //}


        }

        #endregion

    }
 
}