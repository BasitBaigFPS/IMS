
//in the name of ALLAH the most merciful and the most beneficient

using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using BLL;

namespace IMS
{
    public partial class Store : System.Web.UI.Page
    {
        #region Class Vararibles

                StoreManager sm = new StoreManager();

        #endregion

        #region Helper Method

        public void FillCombo()
        {
            sm.pkstoreID = 0;
            sm.Token = "B";
            cmbBranches.DataSource = sm.GetBranches();
            cmbBranches.DataTextField = "brhName";
            cmbBranches.DataValueField = "pkbrhID";
            cmbBranches.DataBind();
        }

        public void getStore()
        {
            if (Request.QueryString["ID"] != null)
            {
                string ID = Request.QueryString["ID"].ToString();

                sm.pkstoreID = int.Parse(ID);
                sm.Token = "SN";

                sm = sm.GetStore();

                txtName.Text = sm.storeName;
                txtDes.Text = sm.Description;
                txtGLCode.Text = sm.GLCode;
                cmbBranches.SelectedValue = sm.fkbrhID.ToString();
            }

        }

        public void saveStore()
        {
            sm.storeName = txtName.Text;
            sm.Description = txtDes.Text;
            sm.GLCode = txtGLCode.Text;
            sm.fkbrhID = int.Parse(cmbBranches.SelectedValue.ToString());

            if (Request.QueryString["ID"] != null)
            {
                sm.pkstoreID = int.Parse(Request.QueryString["ID"].ToString());
                sm.Token = "U";
            }
            else
                sm.Token = "I";

            int result = sm.IUItem();

            //if (result == 1)
            //    winMessage.VisibleOnPageLoad = true;

        }

        #endregion

        #region Event

        protected void Page_Load(object sender, EventArgs e)
        {
            if (Page.IsPostBack == false)
            {
                FillCombo();
                getStore();
            }
        }

        protected void btnSubmit_Click(object sender, EventArgs e)
        {
            saveStore();
        }        
        
        #endregion
    }
}