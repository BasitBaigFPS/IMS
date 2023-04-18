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
    public partial class BranchReturnGeneral : System.Web.UI.Page
    {
        UserManager UMan = new UserManager();
        ItemManager im = new ItemManager();
        StoreManager sm = new StoreManager();
        VendorManager vm = new VendorManager();
        IMSManager iman = new IMSManager();

 
        #region Events 
        
        protected void Page_Load(object sender, EventArgs e)
        {

 
            if (Page.IsPostBack == false)
            {
                SetupForm();
            }
 
        }

       
        #endregion



        #region Helper Methods

        public void GetUserInfo()
        {

            HttpCookie IMS = Request.Cookies["IMS"];
            if (IMS == null)
                Response.Redirect("logout.aspx");


            UMan.Uid = int.Parse(IMS["uid"]);
            UMan.Ubrhid = int.Parse(IMS["ubrhid"]);
            UMan.Pkdeptid = int.Parse(IMS["udptid"]);
            UMan.Ugid = int.Parse(IMS["ugroupid"]);
        }


        public void UserSettings()
        {
            GetUserInfo();

        }


        public void SetupForm()
        {

            GetUserInfo();

            im.CreatedBy = iman.Uid;

            DataSet db = im.GetBranches();

            cmbbranchfrom.DataSource = db.Tables[0];
            cmbbranchfrom.DataTextField = "brhName";
            cmbbranchfrom.DataValueField = "pkbrhID";
            // cmbbranchfrom.SelectedValue = int.Parse(IMS["ubrhid"]).ToString();
            cmbbranchfrom.DataBind();
            cmbbranchfrom.Enabled = true;

        }
 
        #endregion

        protected void cmbPersonto_SelectedIndexChanged(object sender, Telerik.Web.UI.RadComboBoxSelectedIndexChangedEventArgs e)
        {

        }

 

    }
}