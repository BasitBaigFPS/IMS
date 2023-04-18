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
    public partial class ItemsList : System.Web.UI.Page
    {
        ItemManager im = new ItemManager();

        #region Helper Methods

        public void FillCombo()
        {
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

        public void GetItemHead(int subcatid)
        {
            im.SubCatID = subcatid;

            cmbItemHead.DataSource = im.GetItemHeads();
            cmbItemHead.DataTextField = "ItemHeadTitle";
            cmbItemHead.DataValueField = "pkItemHeadID";
            cmbItemHead.DataBind();
        }


        public void GetItems()
        {
            if (cmbCatagories.SelectedValue != null && cmbSubCat.SelectedValue != null)
            {
                im.SubCatID = int.Parse(cmbSubCat.SelectedValue.ToString());
                int IHid = int.Parse(cmbItemHead.SelectedValue.ToString());
                im.Token = "IH";
                grdItems.DataSource = im.GetItems(IHid, im.Token);
                grdItems.DataBind();
            }
        }

        #endregion

        #region Events 
        
        protected void Page_Load(object sender, EventArgs e)
        {
            if (Page.IsPostBack == false)
            {
                FillCombo();
            }
        }

        protected void btnSubmit_Click(object sender, EventArgs e)
        {
            GetItems();
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
        



        #endregion

        protected void cmbSubCat_SelectedIndexChanged(object sender, Telerik.Web.UI.RadComboBoxSelectedIndexChangedEventArgs e)
        {

            GetItemHead(int.Parse(cmbSubCat.SelectedValue.ToString()));

        }


     
    }
}