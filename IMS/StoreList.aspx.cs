using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using BLL;

namespace IMS
{
    public partial class StoreList : System.Web.UI.Page
    {
        #region Class Vararibles

        StoreManager sm = new StoreManager();

        #endregion

        #region Helper Methods

        public void FillCombo()
        {
            sm.pkstoreID = 0;
            sm.Token = "B";
            cmbBranches.DataSource = sm.GetBranches();
            cmbBranches.DataTextField = "brhName";
            cmbBranches.DataValueField = "pkbrhID";
            cmbBranches.DataBind();
        }

        public void GetStores()
        {
            if (cmbBranches.SelectedValue != null)
            {
                sm.fkbrhID = int.Parse(cmbBranches.SelectedValue.ToString());
                sm.Token = "SB";
                grdStores.DataSource = sm.GetStores();
                grdStores.DataBind();
            }
        }

        #endregion

        #region Events 
        
        protected void Page_Load(object sender, EventArgs e)
        {
            if (Page.IsPostBack == false)
                FillCombo();
        }

        protected void btnSubmit_Click(object sender, EventArgs e)
        {
            GetStores();
        }

        protected void cmbBranches_SelectedIndexChanged(object sender, Telerik.Web.UI.RadComboBoxSelectedIndexChangedEventArgs e)
        {
            GetStores();
        }

        #endregion
    }
}