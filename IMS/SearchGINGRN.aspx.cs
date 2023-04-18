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
using System.Data.Common;
using System.Data.Services;
using BLL;
using DAL;

namespace IMS
{
    public partial class SearchGINGRN : System.Web.UI.Page
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


            }

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

        }

        protected void btnFIND_Click(object sender, EventArgs e)
        {
            FINDGIN(txtGINSearch.Text);
        }

        private void FINDGIN(string GINNumber)
        {
            CheckUser();
            
            SqlConnection conn = new SqlConnection();
            SqlCommand cmd = new SqlCommand();

            conn.ConnectionString = SqlHelper.connectionstring;
            cmd.Connection = conn;

            DataSet ds;

            //fkIssueByDeptID
            //fkIssueByStoreID

            string sql = "SELECT pkIssuID,GINNumber,fkItemID,InvCode,dbo.Get_ItemName(fkItemID) as ItemTitle,Qtty FROM tblIssued ";
            sql = sql + " where fkIssueByBranchID=" + sm.fkbrhID.ToString() + " and fkIssueByDeptID=" + iman.Pkdeptid.ToString() + " and IsCancel is null and IsReceived is null ";
            sql = sql + " and isnull(IssuedConfirm,0)=0 and GINNumber=" + GINNumber;

                   ds = SqlHelper.ExecuteDataset(conn, CommandType.Text, sql);

            DataTable dt = ds.Tables[0];

            ViewState["dt"] = dt;
            grdItems.DataSource = dt;
            grdItems.DataBind();

            conn.Close();

        }

        protected void btnFINDGRN_Click(object sender, EventArgs e)
        {
            FINDGRN(txtGRNSearch.Text);
        }

        private void FINDGRN(string GRNNumber)
        {
            CheckUser();

            SqlConnection conn = new SqlConnection();
            SqlCommand cmd = new SqlCommand();

            conn.ConnectionString = SqlHelper.connectionstring;
            cmd.Connection = conn;

            DataSet ds;

            //fkIssueByDeptID
            //fkIssueByStoreID

            string sql = "SELECT pkRecvID,GRNNumber,fkItemID,InvCode,dbo.Get_ItemName(fkItemID) as ItemTitle,Qtty FROM tblReceived ";
            sql = sql + " where fkRecvByBranchID=" + sm.fkbrhID.ToString() + " and fkRecvByDeptID=" + iman.Pkdeptid.ToString() + " and IsCancel is null ";
            sql = sql + " and GRNNumber=" + GRNNumber;

            ds = SqlHelper.ExecuteDataset(conn, CommandType.Text, sql);

            DataTable dt = ds.Tables[0];

            ViewState["dt"] = dt;
            grdItems.DataSource = dt;
            grdItems.DataBind();

            conn.Close();

        }

        protected void txtqty_TextChanged(object sender, EventArgs e)
        {

        }

        protected void grdItems_RowDataBound(object sender, GridViewRowEventArgs e)
        {

        }

        protected void grdItems_RowUpdated(object sender, GridViewUpdatedEventArgs e)
        {

        }

        protected void grdItems_RowEditing(object sender, GridViewEditEventArgs e)
        {

        }

        protected void grdItems_RowCommand(object sender, GridViewCommandEventArgs e)
        {

        }




    }

    
        #endregion




}
