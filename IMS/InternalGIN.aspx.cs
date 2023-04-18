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
using System.Data.SqlClient;
using System.Data.OleDb;
using System.Web.Services;
using Telerik.Web.UI;
using BLL;
using DAL;
 

namespace IMS
{
    public partial class InternalGIN : System.Web.UI.Page
    {
        UserManager UMan = new UserManager();
        ItemManager im = new ItemManager();
        IMSManager iman = new IMSManager();
        StoreManager sm = new StoreManager();
        RequisitionManager Reqman = new RequisitionManager();

        POManager POMan = new POManager();

      

        #region PageEvents

        protected void Page_Load(object sender, EventArgs e)
        {

            if (!IsPostBack)
            {
              //  SetupForm();

            
            }
            else
            {
                //string podate = txtPODate.Value;

            }
        }

        protected void btnShowItemList_Click(object sender, EventArgs e)
        {

            btnShowItemList.Enabled = false;

            //int fkacdid = int.Parse(ddlAcdYear.SelectedValue.ToString());
            //int fkcomid=1;
            //int fkcityid=1;
            //string potype = "STN";
            //int HOToken=0;

            //if (chkfps.Checked==true)
            //{ fkcomid = 1; fkcityid = 1; }

            //if (chkhyd.Checked == true)
            //{ fkcomid = 1; fkcityid = 2; }

            //if (chkhss.Checked == true)
            //{ fkcomid = 2; fkcityid = 1; }

            //if (chkho.Checked == true)
            //{ fkcomid = 1; fkcityid = 1; HOToken = 1; }

            //if (optRegS.Checked==true)
            //{ potype = optRegS.Value; }

            //if (optRegK.Checked == true)
            //{ potype = optRegK.Value; }

            //if (optRegA.Checked == true)
            //{ potype = optRegA.Value; }



            //DataTable POItemList = POMan.GetPOItemsByReqType(fkacdid, fkcomid, fkcityid, potype, HOToken);

            //if (POItemList.Rows.Count == 0)
            //{
            //    showMessageBox("No Record Found For This Requisition Type!!!");

            //}
            //else
            //{
            //    //SetupGrid(POItemList);
            //}
        }



        protected void txtqty_TextChanged(object sender, EventArgs e)
        {

        }


        protected void btnSubmit_Click(object sender, EventArgs e)
        {
            HttpCookie IMS = Request.Cookies["IMS"];
            if (IMS == null)
                Response.Redirect("logout.aspx");

            POMan.Pkdeptid = int.Parse(IMS["udptid"] == null ? "0" : IMS["udptid"]);
            POMan.Uid = int.Parse(IMS["uid"]);

    

           // showMessageBox("Purchase Order Has Been Successfully Generated!!!!! with PO-Number : " + POno.ToString());
 

        }

        protected void btnBack_Click(object sender, EventArgs e)
        {

        }

        protected void btnReset_Click(object sender, EventArgs e)
        {

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
            iman.Pkbrhid = int.Parse(IMS["ubrhid"]);
            iman.Pkdeptid = int.Parse(IMS["udptid"]);
            UMan.Ugid = int.Parse(IMS["ugroupid"]);

            Reqman.Pkbrhid = int.Parse(IMS["ubrhid"]);
            Reqman.Pkdeptid = int.Parse(IMS["udptid"]);
        }

        private void SetupForm()
        {

            DataTable dt = new DataTable();
            ViewState["dt"] = dt;

            btnSubmit.Visible = false;

            btnShowItemList.Enabled = true;

       //     PopulateVendor();
       //     PopulateDepartment();

           // txtDlvdate.Text = DateTime.Today.ToString("dd/MM/yyyy");
        }

       
   
     


        #endregion

 

    }
 
}