using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using Telerik.Web.UI;
using BLL;

namespace IMS
{
    public partial class StoreInventory : System.Web.UI.Page
    {
        ItemManager im = new ItemManager();
        UserManager UMan = new UserManager();
        IMSManager iman = new IMSManager();
        StoreManager sm = new StoreManager();


        #region Events

        protected void Page_Load(object sender, EventArgs e)
        {
            if (Page.IsPostBack == false)
            {
                HttpCookie IMS = Request.Cookies["IMS"];
                if (IMS == null)
                    Response.Redirect("logout.aspx");
                iman.Uid = int.Parse(IMS["uid"]);
                sm.fkbrhID = int.Parse(IMS["ubrhid"]);
                
                iman.Pkdeptid = int.Parse(IMS["udptid"] == null ? "0" : IMS["udptid"]);

               

                FillCombo(sm.fkbrhID);
            }
        }

        protected void btnSubmit_Click(object sender, EventArgs e)
        {
            GetInventory(int.Parse(cmbStores.SelectedValue.ToString()));
        }

        protected void cmbCatagories_SelectedIndexChanged(object sender, Telerik.Web.UI.RadComboBoxSelectedIndexChangedEventArgs e)
        {
            im.CatID = int.Parse(cmbCatagories.SelectedValue.ToString());
            im.Token = "C";
            cmbSubCat.DataSource = im.GetSubCategories();
            cmbSubCat.DataTextField = "SubCatTitle";
            cmbSubCat.DataValueField = "pkSubCatID";
            cmbSubCat.DataBind();

            GetItemHead(int.Parse(cmbSubCat.SelectedValue.ToString()));
        }

        protected void cmbSubCat_SelectedIndexChanged(object sender, Telerik.Web.UI.RadComboBoxSelectedIndexChangedEventArgs e)
        {

            GetItemHead(int.Parse(cmbSubCat.SelectedValue.ToString()));

        }

        #endregion



        #region Helper Methods

        public void FillCombo(int brhid)
        {
            HttpCookie IMS = Request.Cookies["IMS"];
            if (IMS == null)
                Response.Redirect("logout.aspx");
            iman.Uid = int.Parse(IMS["uid"]);
            sm.fkbrhID = int.Parse(IMS["ubrhid"]);

            UMan.GetUserInfo(iman.Uid);

            if (UMan.Ugid == 27 && sm.fkbrhID == brhid || UMan.Ugid == 29 && sm.fkbrhID == brhid || UMan.Ugid == 39 && sm.fkbrhID == brhid)
            {

                if (cmbbranch.Items.Count() < 2)
                {

                    cmbbranch.DataSource = sm.GetBranches();
                    cmbbranch.DataTextField = "BrhName";
                    cmbbranch.DataValueField = "pkbrhID";
                    cmbbranch.DataBind();
                }

                sm.Token = "SB";
                cmbStores.DataSource = sm.GetStores();
                cmbStores.DataTextField = "StoreName";
                cmbStores.DataValueField = "pkStoreID";
                cmbStores.DataBind();

            }
            else
            {
                if (UMan.Ugid == 27 || UMan.Ugid == 29 || UMan.Ugid == 39)
                { }
                else
                {
                    cmbbranch.DataSource = sm.GetBranches(brhid);
                    cmbbranch.DataTextField = "brhName";
                    cmbbranch.DataValueField = "pkbrhID";
                    cmbbranch.DataBind();
                }
                sm.Token = "SB";
                sm.fkbrhID = brhid;
                cmbStores.DataSource = sm.GetStores();
                cmbStores.DataTextField = "StoreName";
                cmbStores.DataValueField = "pkStoreID";
                cmbStores.DataBind();


            }
            
            
            im.CatID = 0;
            im.Token = "C";
            cmbCatagories.DataSource = im.GetCategories();
            cmbCatagories.DataTextField = "CatTitle";
            cmbCatagories.DataValueField = "pkCatID";
            cmbCatagories.DataBind();

            im.CatID = int.Parse(cmbCatagories.SelectedValue.ToString());
            im.Token = "C";
            cmbSubCat.DataSource = im.GetSubCategories();
            cmbSubCat.DataTextField = "SubCatTitle";
            cmbSubCat.DataValueField = "pkSubCatID";
            cmbSubCat.DataBind();

            im.SubCatID = int.Parse(cmbSubCat.SelectedValue.ToString());
            cmbItemHead.DataSource = im.GetItemHeads();
            cmbItemHead.DataTextField = "ItemHeadTitle";
            cmbItemHead.DataValueField = "pkItemHeadID";
            cmbItemHead.DataBind();



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
            im.fkcatid = int.Parse(cmbCatagories.SelectedValue.ToString());
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

        public void GetItemHead(int subcatid)
        {
            im.SubCatID = subcatid;

            cmbItemHead.DataSource = im.GetItemHeads();
            cmbItemHead.DataTextField = "ItemHeadTitle";
            cmbItemHead.DataValueField = "pkItemHeadID";
            cmbItemHead.DataBind();
        }

        public void GetInventory(int storeid)
        {
            if (cmbCatagories.SelectedValue != null && cmbSubCat.SelectedValue != null)
            {
                im.CatID = int.Parse(cmbCatagories.SelectedValue.ToString());
                im.SubCatID = int.Parse(cmbSubCat.SelectedValue.ToString());
                im.HeadID = int.Parse(cmbItemHead.SelectedValue.ToString());
                im.pksysID = GetSysID();

                im.Token = "IH";
                grdStore.DataSource = im.GetStoreInventory(storeid, im.CatID, im.SubCatID, im.HeadID);
                grdStore.DataBind();
            }
        }

        #endregion

        protected void cmbbranch_SelectedIndexChanged(object sender, RadComboBoxSelectedIndexChangedEventArgs e)
        {
            FillCombo(int.Parse(cmbbranch.SelectedValue.ToString()));
        }

        protected void cmbStores_SelectedIndexChanged(object sender, RadComboBoxSelectedIndexChangedEventArgs e)
        {

        }

    }
}