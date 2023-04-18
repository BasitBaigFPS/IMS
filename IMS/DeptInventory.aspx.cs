using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using Telerik.Web.UI;
using BLL;
using System.Data;

namespace IMS
{
    public partial class DeptInventory : System.Web.UI.Page
    {
        ItemManager im = new ItemManager();
        UserManager UMan = new UserManager();
        IMSManager iman = new IMSManager();
        StoreManager sm = new StoreManager();


        public Boolean Fullrights;

        #region Events

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
            UMan.Ubrhid = int.Parse(IMS["ubrhid"]);
            UMan.Pkdeptid = int.Parse(IMS["udptid"]);
            UMan.Ugid = int.Parse(IMS["ugroupid"]);

           



        }

        public void UserSettings()
        {

          

            if (UMan.Ugid == 37)
            {
                cmbbranch.SelectedValue = UMan.Ubrhid.ToString();
                cmbStores.SelectedValue = "22";
                cmbDepartment.SelectedValue = UMan.Pkdeptid.ToString();
                cmbCatagories.SelectedValue = "8";
               
                //cmbStores.Enabled = false;
                //cmbDepartment.Enabled = false;

            }

            if (UMan.Ugid == 48)
            {
                cmbStores.Visible = false;
                cmbbranch.SelectedValue = UMan.Ubrhid.ToString();
                cmbStores.SelectedValue = "1";
                cmbDepartment.SelectedValue = UMan.Pkdeptid.ToString();
                cmbCatagories.SelectedValue = "11";
                

                //GetSubCategory(int.Parse(cmbCatagories.SelectedValue.ToString()));

                cmbbranch.Enabled = false;
                cmbStores.Enabled = false;
        
                cmbDepartment.Enabled = false;
            }

            if (UMan.Ugid == 27 || UMan.Ugid == 29)
            {
                Fullrights = true;
            }
            else
            {
                Fullrights = false;
            }
            FillCombo(sm.fkbrhID, UMan.Ugid);


        }

        protected void Page_Load(object sender, EventArgs e)
        {
            if (Page.IsPostBack == false)
            {
                HttpCookie IMS = Request.Cookies["IMS"];
                if (IMS == null)
                    Response.Redirect("logout.aspx");

                GetUserInfo();

                sm.fkbrhID = int.Parse(IMS["ubrhid"]);
                iman.Uid = int.Parse(IMS["uid"]);
                iman.Pkdeptid = int.Parse(IMS["udptid"] == null ? "0" : IMS["udptid"]);

                UMan.GetUserInfo(iman.Uid);

                UserSettings();
                
            }
        }

        protected void btnSubmit_Click(object sender, EventArgs e)
        {
            if (cmbStores.Visible == true)
            {
                GetInventory(int.Parse(cmbStores.SelectedValue.ToString()));
            }
            else
            {
                GetInventory(0);

            }

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

        protected void cmbbranch_SelectedIndexChanged(object sender, RadComboBoxSelectedIndexChangedEventArgs e)
        {

        }

        protected void cmbStores_SelectedIndexChanged(object sender, RadComboBoxSelectedIndexChangedEventArgs e)
        {

        }


        #endregion



        #region Helper Methods

        public void FillCombo(int brhid, int usrgrpid)
        {

            if (Fullrights == true)
            {
                cmbbranch.DataSource = sm.GetBranches();
                cmbbranch.DataTextField = "BrhName";
                cmbbranch.DataValueField = "pkbrhID";
                cmbbranch.DataBind();

                sm.Token = "SB";
                cmbStores.DataSource = sm.GetStores();
                cmbStores.DataTextField = "StoreName";
                cmbStores.DataValueField = "pkStoreID";
                cmbStores.SelectedValue = "0";
                cmbStores.DataBind();

            }
            else
            {
                cmbbranch.DataSource = sm.GetBranches(brhid);
                cmbbranch.DataTextField = "brhName";
                cmbbranch.DataValueField = "pkbrhID";
                cmbbranch.DataBind();

                if (usrgrpid != 48)
                {
                    sm.Token = "SB";
                    sm.fkbrhID = brhid;
                    cmbStores.DataSource = sm.GetStores();
                    cmbStores.DataTextField = "StoreName";
                    cmbStores.DataValueField = "pkStoreID";
                    cmbStores.DataBind();
                }
                else
                {
                    cmbStores.Visible = false;
                }

            }



            DataSet ddf = im.GetDepartment(iman.Uid);
            cmbDepartment.DataSource = ddf.Tables[0];
            cmbDepartment.DataTextField = "deptName";
            cmbDepartment.DataValueField = "pkdeptID";
            cmbDepartment.SelectedValue = iman.Pkdeptid.ToString();
            cmbDepartment.DataBind();
            
            
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

            if (usrgrpid == 37)
            {
                cmbStores.SelectedValue = "22";
                cmbStores.DataBind();
            }
            else
            {

                Telerik.Web.UI.RadComboBoxItem s = new Telerik.Web.UI.RadComboBoxItem();
                s.Text = "Choose Store";
                s.Value = "Choose Store";
                cmbStores.Items.Add(s);
                cmbStores.SelectedIndex = cmbStores.Items.Count - 1;            
            }

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
                GetUserInfo();
                
                im.CatID = int.Parse(cmbCatagories.SelectedValue.ToString());
                im.SubCatID = int.Parse(cmbSubCat.SelectedValue.ToString());
                im.HeadID = int.Parse(cmbItemHead.SelectedValue.ToString());
                
                im.Token = "IH";
                //grdStore.DataSource = im.GetStoreInventory(storeid, im.CatID, im.SubCatID, im.HeadID);

                grdStore.DataSource = im.GetDeptInventory(UMan.Pkdeptid, UMan.Ubrhid, im.HeadID);
                grdStore.DataBind();

                if (grdStore.Items.Count == 0)
                {
                    showMessageBox("No Item Found in the Inventory Record....!!! ");
                }

            }
        }

        #endregion

        protected void cmbDepartment_SelectedIndexChanged(object sender, RadComboBoxSelectedIndexChangedEventArgs e)
        {

        }

    }
}