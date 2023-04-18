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
    public partial class ItemHead : System.Web.UI.Page
    {
       // UserManager UMan = new UserManager();
        ItemManager im = new ItemManager();
        IMSManager iman = new IMSManager();

        #region Helper Method

        protected void showMessageBox(string message)
        {
            string sScript;
            message = message.Replace("'", "\'");
            sScript = String.Format("alert('{0}');", message);
            ScriptManager.RegisterStartupScript(this, this.GetType(), "alert", sScript, true);
        }

        private void SetupForm()
        {

            HttpCookie IMS = Request.Cookies["IMS"];
            if (IMS == null)
                Response.Redirect("logout.aspx");

            iman.Uid = int.Parse(IMS["uid"]);
            iman.Pkdeptid = int.Parse(IMS["udptid"] == null ? "0" : IMS["udptid"]);
            iman.Pkbrhid = int.Parse(IMS["ubrhid"]);

            //iman.Uid = 1527;
            //iman.Pkdeptid = 14;
            //iman.Pkbrhid = 19;

            GetCategory();


            Telerik.Web.UI.RadComboBoxItem ct = new Telerik.Web.UI.RadComboBoxItem();
            ct.Text = "Choose Category";
            ct.Value = "Choose Category";
            cmbCategory.Items.Add(ct);
            cmbCategory.SelectedIndex = cmbCategory.Items.Count - 1;

            Telerik.Web.UI.RadComboBoxItem sct = new Telerik.Web.UI.RadComboBoxItem();
            sct.Text = "Choose Sub Category";
            sct.Value = "Choose Sub Category";
            cmbSubCategory.Items.Add(sct);
            cmbSubCategory.SelectedIndex = cmbSubCategory.Items.Count - 1;



            txtName.Text = "";
            txtDescription.Text = "";


        }

        public void GetCategory()
        {
            cmbCategory.DataSource = im.GetCategories();
            cmbCategory.DataTextField = "CatTitle";
            cmbCategory.DataValueField = "pkCatID";
            cmbCategory.DataBind();
        }

        public void GetSubCategory(int catid)
        {
            im.CatID = catid;
            cmbSubCategory.DataSource = im.GetSubCategories();
            cmbSubCategory.DataTextField = "SubCatTitle";
            cmbSubCategory.DataValueField = "pkSubCatID";
            cmbSubCategory.DataBind();

            
        }


        public void GetItem()
        {
            if (Request.QueryString["ID"] != null)
            {
                string ID = Request.QueryString["ID"].ToString();

                im.itemid = int.Parse(ID);
                im.Token = "II";

                im = im.GetItem();

                txtName.Text = im.itemtitle;
 
                txtDescription.Text = im.itemdesc;
                if (im.isactive == "True")
                {
                    IsActive.Checked = true;
                }

                cmbCategory.SelectedValue = im.fkcatid.ToString();
                GetSubCategory(int.Parse(cmbCategory.SelectedValue.ToString()));
                cmbSubCategory.SelectedValue = im.fksubcatid.ToString();
            }

        }

        public void saveItem()
        {
            im.itemtitle = txtName.Text;

            im.itemdesc = txtDescription.Text;

            im.fkcatid = int.Parse(cmbCategory.SelectedValue.ToString());
            im.fksubcatid = int.Parse(cmbSubCategory.SelectedValue.ToString());
 

            if (IsActive.Checked==true)
            {
                im.isactive = "True";
            }
            else

            {
                im.isactive = "False";
            }


            if (Request.QueryString["ID"] != null)
            {
                im.itemid = int.Parse(Request.QueryString["ID"].ToString());
                im.Token = "U";
            }
            else
                im.Token = "I";

            int result = im.IUItemHead();

            if (result == 1)
                winMessage.VisibleOnPageLoad = true;

            if (im.Token == "I")
            {
                showMessageBox("Item Head Successfully Inserted...!!!");
            }
            else
            {
                showMessageBox("Item Head Successfully Updated...!!!");
            }

            SetupForm();
            
        }

        #endregion

        protected void Page_Load(object sender, EventArgs e)
        {
            if (Page.IsPostBack == false)
            {
                SetupForm();
                GetItem();

            }
        }

        protected void btnSubmit_Click(object sender, EventArgs e)
        {
            saveItem();
        }
      

 

        protected void cmbCategory_SelectedIndexChanged(object sender, Telerik.Web.UI.RadComboBoxSelectedIndexChangedEventArgs e)
        {
            GetSubCategory(int.Parse(cmbCategory.SelectedValue.ToString()));
        }


        protected void cmbSubCategory_SelectedIndexChanged(object sender, Telerik.Web.UI.RadComboBoxSelectedIndexChangedEventArgs e)
        {
            im.SubCatID = int.Parse(cmbSubCategory.SelectedValue.ToString());
        }


        protected void btnClose_Click(object sender, EventArgs e)
        {
            Response.Redirect("Main.aspx");
        }





    }
}